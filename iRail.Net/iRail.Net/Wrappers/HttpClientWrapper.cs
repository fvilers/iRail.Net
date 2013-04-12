using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using iRail.Net.Requests;

namespace iRail.Net.Wrappers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public async Task<string> GetAsync(JsonRequestBase jsonRequest)
        {
            if (jsonRequest == null) throw new ArgumentNullException("jsonRequest");

            var requestUri = jsonRequest.ToRequestUri();
            Debug.WriteLine(requestUri);
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(requestUri);
            }
        }
    }
}
