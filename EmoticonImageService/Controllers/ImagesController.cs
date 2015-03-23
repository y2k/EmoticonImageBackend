using EmoticonImageService.Models;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System;

namespace EmoticonImageService.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private IEmoticonRepository _repository;

        public ImagesController(IEmoticonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get(string filter)
        {
            return _repository.GetImageWithDescription(GetCurrentUrl(), filter);
        }

        [HttpPost]
        public string Post(ImageUpdateDataContract value)
        {
            return _repository.UploadImageByUrl(value.Url);
        }

        public class ImageUpdateDataContract
        {
            public string Url { get; set; }
        }

        Uri GetCurrentUrl()
        {
            return new Uri(Url.Action("Get", "Media", null, Request.Scheme));
        }
    }
}