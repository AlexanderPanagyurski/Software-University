﻿using SIS.HTTP;
using SIS.HTTP.Enums;
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
            routeTable.Add(new Route(HttpMethodType.GET, "/contacts", Contacts));
            routeTable.Add(new Route(HttpMethodType.GET, "/favicon.ico", FavICon));


            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse FavICon(HttpRequest arg)
        {
            throw new NotImplementedException();
        }

        private static HttpResponse Contacts(HttpRequest httpRequest)
        {
            var content = "<h1>Contacts Page";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCodeType.OK, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));

            return response;
        }

        public static HttpResponse Index(HttpRequest httpRequest)
        {
            var content = "<h1>Home Page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCodeType.OK, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));

            return response;
        }

        public static HttpResponse Login(HttpRequest httpRequest)
        {
            var content = "<h1>Login Page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCodeType.OK, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));

            return response;
        }

        public static HttpResponse DoLogin(HttpRequest httpRequest)
        {
            var content = "<h1>Login Page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCodeType.OK, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));

            return response;
        }
    }
}