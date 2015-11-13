using Newtonsoft.Json;
using System.Text;
using System.Web.Mvc;

namespace Sky.Web.Mvc
{
    public class SkyController : Controller
    {
        protected JsonResult Json(object data, params JsonConverter[] converters)
        {
            return Json(data, null, null, JsonRequestBehavior.DenyGet, converters);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return Json(data, contentType, contentEncoding, behavior, null);
        }

        protected JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior, params JsonConverter[] converters)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                Converters = converters
            };
        }
    }
}
