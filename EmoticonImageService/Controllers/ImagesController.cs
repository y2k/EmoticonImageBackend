using EmoticonImageService.Models;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

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
            return _repository.GetImageWithDescription(filter);
        }

        //// GET: api/Image/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Image
        public string Post([FromBody]ImageUpdateDataContract value)
        {
            return _repository.UploadImageByUrl(value.Url);
        }

        //// PUT: api/Image/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Image/5
        //public void Delete(int id)
        //{
        //}

        public class ImageUpdateDataContract
        {
            public string Url { get; set; }
        }
    }
}