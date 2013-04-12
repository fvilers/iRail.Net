using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using iRail.Net.Requests;

namespace iRail.Net.Wrappers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public async Task<string> GetAsync(RequestBase request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var requestUri = request.ToRequestUri();
            Debug.WriteLine(requestUri);
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(requestUri);
            }
        }
    }
}
