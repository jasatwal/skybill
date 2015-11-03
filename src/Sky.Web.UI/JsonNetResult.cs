using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Sky.Web.UI
{
    public class JsonNetResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException();

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            if (ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;

            if (Data == null)
                return;

            response.Write(JsonConvert.SerializeObject(Data));
        }
    }
}
