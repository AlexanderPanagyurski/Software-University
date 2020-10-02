using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable;

        public HttpServer()
        {
            this.routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();
        }
        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);

            }
        }
        public void Start(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
        }
    }
}
