using EmoticonImageService.Models;
using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmoticonImageService.Controllers
{
    [Route("api/[controller]")]
    public class EmoticonsController : Controller
    {
        private IEmoticonRepository _repository;

        public EmoticonsController(IEmoticonRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public void Post(ImageDescription value)
        {
            _repository.AddImageDescription(value.ImageId, value.Description);
        }

        public class ImageDescription
        {
            [Required]
            public string ImageId { get; set; }

            [Required]
            public string Description { get; set; }
        }
    }
}