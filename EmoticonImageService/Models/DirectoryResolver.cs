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
            return Path.Combine(GetDataDirectory(), relativePath.Replace(AppData, ""));
        }

        private static string GetDataDirectory()
        {
            return AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        }
    }
}