using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Refit.WebApi.Controllers;

namespace Refit.WebApi.Attributes
{
    public class HeaderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            string headerCode;
            KeyValuePair<string, IEnumerable<string>> header =
                filterContext.Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "x-header");
            if (header.Key != null)
            {
                var controller = (HeaderController) filterContext.ControllerContext.Controller;
                controller.HeaderCode = header.Value.First();
            }
        }
    }
}