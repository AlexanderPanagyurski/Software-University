using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Exceptions
{
    public class HttpServerException : Exception
    {
        public HttpServerException()
        {
        }

        public HttpServerException(string message)
            : base(message)
        {
        }
    }
}
