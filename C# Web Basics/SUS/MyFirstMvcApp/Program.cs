using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            HomeController homeController = new HomeController();
            server.AddRoute("/", homeController.Index());
            server.AddRoute("/niki", (request) =>
            {
                return new HttpResponse("text/html", new byte[] { 0x56, 0x57 });
            });
            server.AddRoute("/favicon.ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);
            await server.StartAsync(80);
        }

      


      
       
    }
}
