using System;

namespace EmoticonImageService.Models
{
    public class DirectoryResolver
    {
        public static DirectoryResolver Instance { get; } = new DirectoryResolver();

        private DirectoryResolver() { }

        public Uri CreateAsoluteUri(string path)
        {
            // new Uri(HttpContext.Current.Request.Url, "/" + s);
            throw new NotImplementedException();
        }

        public string GetFullPath(string relativePath)
        {
            // HttpContext.Current.Server.MapPath("~/App_Data/Images/" + Guid.NewGuid() + ".tmp");
            return Microsoft.AspNet.Hosting.HostingUtilities.GetWebRoot(relativePath);
        }
    }
}