﻿using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SIS.HTTP
{
    public class HtmlResponse : HttpResponse
    {
        public HtmlResponse(string html)
            : base()
        {
            this.StatusCode = HttpResponseCodeType.OK;
            byte[] byteData= Encoding.UTF8.GetBytes(html);
            this.Body = byteData;
            this.Headers.Add(new Header("Content-Type", "text/html"));
            this.Headers.Add(new Header("Content-Length", this.Body.Length.ToString()));
        }

        internal HtmlResponse()
        {
        }
    }
}
