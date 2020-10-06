using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            var response = File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
            return response;
        }

        internal HttpResponse BootstrapJs(HttpRequest request)
        {
            var response = File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
            return response;
        }

        internal HttpResponse CustomJs(HttpRequest request)
        {
            var response = File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
            
            return response;
        }

        internal HttpResponse CustomCss(HttpRequest request)
        {
            var response = File("wwwroot/css/custom.js", "text/css");
            return response;
        }

        internal HttpResponse BootstrapCss(HttpRequest arg)
        {
            var response = File("wwwroot/css/bootstrap.min.css","text/css");
            return response;
        }
    }
}
