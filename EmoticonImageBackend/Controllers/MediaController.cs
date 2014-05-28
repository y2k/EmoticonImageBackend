using EmoticonImageBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmoticonImageBackend.Controllers
{
    public class MediaController : Controller
    {
        private ICacheModel _repository;

        public MediaController(ICacheModel repository)
        {
            _repository = repository;
        }

        public ActionResult Get(string id, string format, int? size = null, int? width = null, int? maxHeight = null)
        {
            if (size.HasValue && (size < 16 || size > 512)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (size.HasValue)
            {
                var data = _repository.Square(id, size.Value, format);
                if (data != null)
                {
#if !DEBUG
                    var cache = Response.Cache;
                    cache.SetCacheability(HttpCacheability.Public);
                    cache.SetExpires(new DateTime(2525, 1, 1));
#endif
                    return new FileContentResult(data, "image/jpeg");
                }
            }
            else if (width.HasValue && maxHeight.HasValue)
            {
                var data = _repository.Thumbnail(id, width.Value, maxHeight.Value, format);
                if (data != null)
                {
#if !DEBUG
                    var cache = Response.Cache;
                    cache.SetCacheability(HttpCacheability.Public);
                    cache.SetExpires(new DateTime(2525, 1, 1));
#endif
                    return new FileContentResult(data, "image/jpeg");
                }
            }
            else
            {
                var path = _repository.Get(id);
                if (path != null)
                {
#if !DEBUG
                    var cache = Response.Cache;
                    cache.SetCacheability(HttpCacheability.Public);
                    cache.SetExpires(new DateTime(2525, 1, 1));
#endif
                    return new FilePathResult(path, "image/jpeg");
                }
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}