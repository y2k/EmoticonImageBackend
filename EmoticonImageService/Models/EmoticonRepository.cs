using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace EmoticonImageService.Models
{
    public class EmoticonRepository : IEmoticonRepository
    {
        private const int EmoticonsPerPage = 32;

        #region IEmoticonRepository Members

        public IEnumerable<string> GetImageWithDescription(Uri baseUrl, string filter)
        {
            var parts = Regex.Replace(filter.ToUpper(), "[ ,.\\+]+", " ").Split(' ').Where(s => s.Length >= 3).Distinct().ToList();

            using (var context = new EmoticonContext())
            {
                return parts
                    .SelectMany(s => context.Emoticons.Where(a => a.Description.Contains(s)))
                    .GroupBy(s => s.Id)
                    .OrderByDescending(s => s.Count())
                    .Take(EmoticonsPerPage)
                    .Select(s => s.First().ImageId)
                    .Select(s => new Uri(baseUrl + "/" + s).AbsoluteUri)
                    .ToList();
            }
        }

        public string UploadImageByUrl(string url)
        {
            if (url == null) throw new NullReferenceException();

            var path = DirectoryResolver.Instance.GetFullPath("~/App_Data/Images/" + Guid.NewGuid() + ".tmp");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            DownloadImageToPath(url, path);

            var hash = ComputeMd5FromFile(path);
            try
            {
                var dest = Path.Combine(Path.GetDirectoryName(path), hash);
                File.Move(path, dest);
            }
            finally
            {
                File.Delete(path);
            }
            return hash;
        }

        public void AddImageDescription(string imageId, string description)
        {
            if (imageId == null || description == null) throw new NullReferenceException();

            using (var context = new EmoticonContext())
            {
                var e = context.Emoticons.FirstOrDefault(s => s.ImageId == imageId)
                    ?? new EmoticonContext.Emoticon { ImageId = imageId, Description = "" };
                e.Description = Regex
                    .Replace((e.Description + " " + description).ToUpper(), "[ ,.\\+]+", " ")
                    .Split(' ').Where(s => s.Length >= 3).Distinct().Aggregate((a, s) => a + " " + s);

                if (e.Id == 0) context.Emoticons.Add(e);
                context.SaveChanges();
            }
        }

        #endregion

        #region Private methods

        private static string ComputeMd5FromFile(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var input = new FileStream(path, FileMode.Open))
                {
                    return BitConverter.ToString(md5.ComputeHash(input)).Replace("-", "");
                }
            }
        }

        private static void DownloadImageToPath(string url, string path)
        {
            new WebClient().DownloadFile(url, path);
        }

        #endregion
    }
}