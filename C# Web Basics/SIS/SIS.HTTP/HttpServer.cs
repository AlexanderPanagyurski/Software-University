using SIS.Common;
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
            string request = Encoding.UTF8.GetString(requestBytes, 0, byteRead);
            byte[] fileContent = Encoding.UTF8.GetBytes("<h1>Hello, World</h1>");
            string headers = "HTTP/1.0 200 OK" + GlobalConstants.HttpNewLine +
                             "Server: SoftUniServer/1.0" + GlobalConstants.HttpNewLine +
                             "Content-Type: text/html" + GlobalConstants.HttpNewLine +
                             "Content-Length: " + fileContent.Length + GlobalConstants.HttpNewLine + GlobalConstants.HttpNewLine;

            byte[] headersBytes = Encoding.UTF8.GetBytes(headers);
            await networkStream.WriteAsync(headersBytes, 0, headersBytes.Length);
            await networkStream.WriteAsync(fileContent, 0, fileContent.Length);
            Console.WriteLine(request);
            Console.WriteLine(new string('=',60));
        }
    }
}
