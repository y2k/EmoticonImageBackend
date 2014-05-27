using EmoticonImageBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmoticonImageBackend.Controllers
{
    public class EmoticonsController : ApiController
    {
        private IEmoticonRepository _repository;

        public EmoticonsController(IEmoticonRepository repository)
        {
            _repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get(string filter, int toId = 0)
        {
            return _repository.TestGetAll().Where(s => s.ToUpper().Contains(filter.ToUpper())).Skip(toId).ToList();
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post(ImageDescription value)
        {
            _repository.AddImageDescription(value.ImageId, value.Description);
        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}

        public class ImageDescription
        {
            [Required]
            public string ImageId { get; set; }

            [Required]
            public string Description { get; set; }
        }
    }
}