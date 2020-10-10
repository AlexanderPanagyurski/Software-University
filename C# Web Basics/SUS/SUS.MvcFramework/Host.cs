using SUS.HTTP;
using SUS.Mvcframework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            // TODO: {controller}/{action}/{id}
            List<Route> routeTable = new List<Route>();
            AutoRegisterStaticFile(routeTable);

            application.ConfigureServices();
            application.Configure(routeTable);



            IHttpServer server = new HttpServer(routeTable);

            // Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "http://localhost/");
            await server.StartAsync(port);
        }

        private static void AutoRegisterStaticFile(List<Route> routeTable)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);

            foreach (var staticFile in staticFiles)
            {
                var url = staticFile.Replace("wwwroot", string.Empty)
                    .Replace("\\", "/");

                routeTable.Add(new Route(url, HttpMethod.Get, (request) =>
                {
                    var fileContent = File.ReadAllBytes(staticFile);
                    var fileExtension = new FileInfo(staticFile).Extension;

                    var contentType = fileExtension switch
                    {
                        ".txt" => "text/plain",
                        ".js" => "text/javascript",
                        ".jpg" => "image/jpg",
                        ".jpeg" => "image/jpg",
                        ".css" => "text/css",
                        ".html" => "text/html",
                        ".gif" => "image/gif",
                        ".ico" => "image/vnd.microsoft.icon",
                        ".png" => "image/png",
                        _ => "text/plain"
                    };

                    return new HttpResponse(contentType, fileContent, HttpStatusCode.Ok);
                }));
            }
        }
    }
}
