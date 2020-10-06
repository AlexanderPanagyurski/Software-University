using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public  HttpResponse Home(HttpRequest request)
        {
            return this.View();
        }
        public  HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
