using SIS.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener;
        //TODO: actions
        public HttpServer(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);

        }

        public async Task ResetAsync()
        {
            this.tcpListener.Stop();
            await this.StartAsync();
        }

        public async Task StartAsync()
        {
            this.tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                await Task.Run(() => ProcessClientAsync(tcpClient));
            }
        }

        public void Stop()
        {
            this.tcpListener.Stop();
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using NetworkStream networkStream = tcpClient.GetStream();
            byte[] requestBytes = new byte[1000000];
            int byteRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string requestAsString  = Encoding.UTF8.GetString(requestBytes, 0, byteRead);

            var request = new HttpRequest(requestAsString);
            string content = "<h1>Random Page</h1>";
            if (request.Path == "/")
            {
                content = "<h1>Home Page</h1>";
            }
            else if (request.Path == "/users/login")
            {
                content= "<h1>Login Page</h1>";
            }
            byte[] stringContent = Encoding.UTF8.GetBytes(content);
            var response = new HttpResponse(HttpResponseCodeType.OK , stringContent);
            response.Headers.Add(new Header("Server", "SoftUniServer/1.0"));
            response.Headers.Add(new Header("Content-Type", "text/html"));

            byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
            await networkStream.WriteAsync(response.Body, 0, response.Body.Length);
            Console.WriteLine(request);
            Console.WriteLine(new string('=',60));
        }
    }
}
