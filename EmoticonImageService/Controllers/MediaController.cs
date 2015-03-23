using EmoticonImageService.Models;
using Microsoft.AspNet.Mvc;
using System.Net;

namespace EmoticonImageService.Controllers
{
    public class MediaController : Controller
    {
        private IImageRepository _repository;

        public MediaController(IImageRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Get(string id, string format, int? size = null, int? width = null, int? maxHeight = null)
        {
            if (size.HasValue && (size < 16 || size > 512)) return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

            if (size.HasValue)
            {
                var data = _repository.Square(id, size.Value, format);
                if (data != null)
                {
                    InitializeCache();
                    return new FileContentResult(data, "image/jpeg");
                }
            }
            else if (width.HasValue && maxHeight.HasValue)
            {
                var data = _repository.Thumbnail(id, width.Value, maxHeight.Value, format);
                if (data != null)
                {
                    InitializeCache();
                    return new FileContentResult(data, "image/jpeg");
                }
            }
            else
            {
                var path = _repository.Get(id);
                if (path != null)
                {
                    InitializeCache();
                    return new FilePathResult(path, "image/jpeg");
                }
            }

            // TODO:
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
        }

        void InitializeCache()
        {
#if !DEBUG
                    var cache = Response.Cache;
                    cache.SetCacheability(HttpCacheability.Public);
                    cache.SetExpires(new DateTime(2525, 1, 1));
#endif
        }
    }
}