using System.Web.Http;

namespace InfoScreen.WebApi.Controllers
{
    public class PingController : BaseApiController
    {
        /// <summary>
        /// Ping-tjeneste
        /// </summary>
        /// <returns>'Pong'</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        public IHttpActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}