using SIS.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener;
        private readonly IList<Route> routeTable;

        //TODO: actions

        public HttpServer(int port, IList<Route> routeTable)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);
            this.routeTable = routeTable;
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

            try
            {

                byte[] requestBytes = new byte[1000000];
                int byteRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, byteRead);

                var request = new HttpRequest(requestAsString);
                var route = this.routeTable
                    .FirstOrDefault(rt => rt.HttpMethod == request.Method && rt.Path == request.Path);
                HttpResponse response;
                if (route == null)
                {
                    response = new HttpResponse(HttpResponseCodeType.NotFound, new byte[0]);
                }
                else
                {
                    response = route.Action(request); 
                }


                response.Headers.Add(new Header("Server", "SoftUniServer/1.0"));

                response.ResponseCookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
                {
                    HttpOnly = true,
                    MaxAge = 3600
                });

                byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await networkStream.WriteAsync(response.Body, 0, response.Body.Length);
                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
            catch (Exception ex)
            {
                var errorResponse = new HttpResponse(HttpResponseCodeType.InternalServerError, Encoding.UTF8.GetBytes(ex.Message));
                errorResponse.Headers.Add(new Header("Content-Type", "text/plain"));

                byte[] responseBytes = Encoding.UTF8.GetBytes(errorResponse.ToString());
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await networkStream.WriteAsync(errorResponse.Body, 0, errorResponse.Body.Length);
            }

        }
    }
}
