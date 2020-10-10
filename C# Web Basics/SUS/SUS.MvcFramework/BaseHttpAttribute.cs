using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        protected BaseHttpAttribute()
        {
        }

        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
