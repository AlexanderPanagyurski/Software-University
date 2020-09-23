using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.GET, "/", Index));
            routeTable.Add(new Route(HttpMethodType.GET, "/users/login", Login));
            routeTable.Add(new Route(HttpMethodType.POST, "/users/login", DoLogin));
            var httpServer = new HttpServer(80);
            await httpServer.StartAsync();
        }

        public static HttpResponse Index(HttpRequest httpRequest)
        {
            var content = "<h1>Home Page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCodeType.OK, stringContent);

            return response;
        }

        public static HttpResponse Login(HttpRequest httpRequest)
        {
            var content = "<h1>Login Page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCodeType.OK, stringContent);

            return response;
        }

        public static HttpResponse DoLogin(HttpRequest httpRequest)
        {
            var content = "<h1>Login Page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCodeType.OK, stringContent);

            return response;
        }
    }
}
