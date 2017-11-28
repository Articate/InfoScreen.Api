using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace InfoScreen.WebApi.Controllers
{
    public class HomeController : BaseApiController
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public HttpResponseMessage Index()
        {
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            var url = $"{Request?.RequestUri?.Scheme}://{Request?.RequestUri?.Host}:{Request?.RequestUri?.Port}";
            response.Headers.Add("X-System", "Swagger");
            response.Headers.Location = new System.Uri($"{url}/swagger");
            return response;
        }
    }
}