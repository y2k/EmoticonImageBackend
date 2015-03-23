using System;
using System.IO;

namespace EmoticonImageService.Models
{
    public class DirectoryResolver
    {
        private const string AppData = "~/App_Data/";

        public static DirectoryResolver Instance { get; } = new DirectoryResolver();

        DirectoryResolver() { }

        public string GetFullPath(string relativePath)
        {
            if (!relativePath.StartsWith(AppData)) throw new ArgumentException();
            var path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            return Path.Combine(path, relativePath.Replace(AppData, ""));
        }
    }
}