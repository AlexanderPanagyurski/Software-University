using SIS.Common;
using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SIS.HTTP
{
    public class HttpResponse
    {
        //TODO: override ToString(); HttpVersion; Status Code + Status Message

        public HttpResponse(HttpResponseCodeType statusCode, byte[] body)
        {
            this.Version = HttpVersionType.Http11;
            this.StatusCode = statusCode;
            this.Headers = new List<Header>();
            this.ResponseCookies = new List<ResponseCookie>();
            this.Body = body;

            if (body != null && body.Length > 0)
            {
                this.Headers.Add(new Header("Content-Length", body.Length.ToString()));
            }
        }

        public HttpVersionType Version { get; set; }

        public HttpResponseCodeType StatusCode { get; set; }

        public IList<Header> Headers { get; set; }

        public IList<ResponseCookie> ResponseCookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var httpVersionAsString = this.Version switch
            {
                HttpVersionType.Http10 => "HTTP/1.0",
                HttpVersionType.Http11 => "HTTP/1.1",
                HttpVersionType.Http20 => "HTTP/2.0",
                _ => "HTTP/1.1"
            };

            sb.Append($"{httpVersionAsString} {(int)this.StatusCode} {this.StatusCode}" + GlobalConstants.HttpNewLine);

            foreach (var header in Headers)
            {
                sb.Append(header.ToString() + GlobalConstants.HttpNewLine);
            }

            foreach (var responseCookie in ResponseCookies)
            {
                sb.Append($"Set Cookie: {responseCookie}"+GlobalConstants.HttpNewLine);
            }

            sb.Append(GlobalConstants.HttpNewLine);

            return sb.ToString();
        }
    }
}
