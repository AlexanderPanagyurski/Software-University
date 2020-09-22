using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Enums
{
    public enum HttpMethodType
    {
        Unknown = 0,
        GET = 1,
        POST = 2,
        PUT = 3,
        DELETE = 4,
        TRACE = 5,
        OPTIONS = 6,
        CONNECT = 7,
        HEAD = 8
    }
}
