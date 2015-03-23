using System;
using System.Collections.Generic;

namespace EmoticonImageService.Models
{
    public interface IEmoticonRepository
    {
        string UploadImageByUrl(string url);

        void AddImageDescription(string imageId, string description);

        IEnumerable<string> GetImageWithDescription(Uri baseUrl, string filter);
    }
}