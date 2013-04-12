using iRail.Net.Requests;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace iRail.Net.Wrappers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public async Task<Tuple<bool, string>> TryGetAsync(JsonRequestBase request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var requestUri = request.ToRequestUri();
            
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(requestUri);
                var output = await response.Content.ReadAsStringAsync();

                return new Tuple<bool,string>(response.IsSuccessStatusCode, output);
            }
        }
    }
}
