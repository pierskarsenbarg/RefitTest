using System.Web.Http;
using Refit.WebApi.Attributes;
using Refit.WebApi.Models;

namespace Refit.WebApi.Controllers
{
    public class HeaderController : ApiController
    {
        public string HeaderCode;

        [HeaderAttribute]
        public ApiString Get()
        {
            return new ApiString {Value = HeaderCode};
        }
    }
}
