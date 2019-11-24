using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Common.Proxy.RestProxy
{
    public class BaseApiProxy : IApiProxy
    {
        #region Declarations              
        protected Lazy<Uri> _baseAddress;
        protected readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        #endregion Declarations

        
    }
}
