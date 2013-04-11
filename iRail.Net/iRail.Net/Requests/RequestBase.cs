using System;
using System.Collections.Generic;
using System.Linq;

namespace iRail.Net.Requests
{
    public abstract class RequestBase
    {
        private readonly string _method;
        private const string ApiUrl = "http://api.irail.be";
        private Dictionary<string, object> _parameters = new Dictionary<string, object>();

        public RequestBase(string method)
        {
            if (method == null) throw new ArgumentNullException("method");
            _method = method;
        }

        protected Dictionary<string, object> Parameters
        {
            get { return _parameters; }
        }

        public Uri ToRequestUri()
        {
            var query = String.Join("&", _parameters.Select(x => String.Format("{0}={1}", x.Key, x.Value)));
            var requestUri = new Uri(new Uri(ApiUrl), String.Concat(_method, "?", query));

            return requestUri;
        }
    }
}