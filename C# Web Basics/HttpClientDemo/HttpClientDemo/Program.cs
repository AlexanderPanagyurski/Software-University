using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        private const string NewLine = "\r\n";
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 80);
            tcpListener.Start();
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    string requestString =
                        Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requestString);

                    string html = $"<h1>Hello from Alex's Server {DateTime.Now}</h1>" +
                        $"<form action=/tweet method=post><input type=username /><input type=password />" +
                        $"<input type=submit /></form>";

                    string response = OpenHttpServerLocalHost(html);

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }
            }
        }
        private static string OpenHttpServerLocalHost(string html)
        {
            html= "<img src=\"https://http.cat/200\" width=\"520\" height=\"440\" >";

            return "HTTP/1.1 200 OK" + NewLine +
                        "Server: Alex's Server 2020" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Lenght: " + html.Length + NewLine +
                        NewLine +
                        html + NewLine + "<h1>Server: Alex's Server 2020, </h1>" + $"{DateTime.Now}" + NewLine;
        }

        private static string HttpRedirectToWebsite(string link, string html)
        {
            return "HTTP/1.1 307 Temporary Redirect" + NewLine +
                        "Server: Alex's Server 2020" + NewLine +
                         "Location: " + link + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        // "Content-Disposition: attachment; filename=niki.txt" + NewLine +
                        "Content-Lenght: " + html.Length + NewLine +
                        NewLine +
                        html + NewLine + $"{DateTime.Now}" + NewLine;
        }
        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}
