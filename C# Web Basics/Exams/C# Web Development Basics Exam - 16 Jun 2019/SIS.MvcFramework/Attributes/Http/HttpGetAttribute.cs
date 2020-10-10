using SIS.HTTP.Enums;

namespace SIS.MvcFramework.Attributes
{
    public class HttpGetAttribute : BaseHttpAttribute
    {
        private string v;

        public HttpGetAttribute(string v)
        {
            this.v = v;
        }

        public override HttpRequestMethod Method => HttpRequestMethod.Get;
    }
}
