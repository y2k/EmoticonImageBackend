using EmoticonImageBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmoticonImageBackend.Controllers
{
    public class ImageController : ApiController
    {
        private IEmoticonRepository _repository;

        public ImageController(IEmoticonRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Image
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Image/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Image
        public void Post([FromBody]ImageUpdateDataContract value)
        {
            _repository.UploadImageByUrl(value.Url);
        }

        // PUT: api/Image/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Image/5
        public void Delete(int id)
        {
        }

        public class ImageUpdateDataContract
        {
            public string Url { get; set; }
        }
    }
}
