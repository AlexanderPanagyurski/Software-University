using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Enums
{
    public enum HttpResponseCodeType
    {
        Unknown = 0,
        OK = 200,
        Created = 201,
        Accepted = 202,
        MovedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501,
    }
}
