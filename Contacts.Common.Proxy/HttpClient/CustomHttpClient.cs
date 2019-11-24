using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Contacts.Common.Proxy.HttpClient
{
    public class CustomHttpClient : System.Net.Http.HttpClient
    {
        #region Constructors
        public CustomHttpClient()
        {
            
        }
        public CustomHttpClient(Dictionary<string, string> headers)
            : this(headers, new HttpClientHandler())
        {
        }
        public CustomHttpClient(Dictionary<string, string> headers, HttpClientHandler handler)
            : base(handler)
        {
            if (headers != null &&
            headers.Any())
            {
                foreach (var key in headers.Keys)
                {
                    this.DefaultRequestHeaders.TryAddWithoutValidation(key, headers[key]);
                }
            }
        }
        #endregion Constructors
    }
}
