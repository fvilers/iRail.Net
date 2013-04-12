using iRail.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRail.Net.Requests
{
    public abstract class JsonRequestBase
    {
        private const string ApiUrl = "http://api.irail.be";
        private readonly string _method;
        private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();

        protected JsonRequestBase(string method)
        {
            if (method == null) throw new ArgumentNullException("method");
            _method = method;
            _parameters.Add("format", "json");
        }

        public Language Language
        {
            get { return GetParameter<Language>("lang"); }
            set { SetParameter("lang", value); }
        }

        public Uri ToRequestUri()
        {
            var query = String.Join("&", _parameters.Select(x => String.Format("{0}={1}", Uri.EscapeUriString(x.Key), Uri.EscapeUriString(x.Value.ToString()))));
            var requestUri = new Uri(new Uri(ApiUrl), String.Concat(_method, "?", query));
            
            return requestUri;
        }

        protected T GetParameter<T>(string key)
        {
            return (T)_parameters[key];
        }

        protected void SetParameter(string key, object value)
        {
            if (value != null)
            {
                _parameters.Add(key, value);
            }
            else
            {
                _parameters.Remove(key);
            }
        }
    }
}