using Microsoft.Extensions.Logging;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            this.logger.Log("Hellow from Index");
            return this.View();
        }


    }
}