using SUS.HTTP;
using System;
using System.Net;

namespace MyFirstMvcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);
            server.AddRoute("/contacts", Contacts);

            server.Start(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }


        static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }
        static HttpResponse Contacts(HttpRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
