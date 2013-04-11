using System;
using System.Threading.Tasks;
using iRail.Net.Model;
using iRail.Net.Requests;
using iRail.Net.Responses;
using iRail.Net.Wrappers;

namespace iRail.Net
{
    public class RailClient : IRailClient
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly ISerializationWrapper _serializer;

        public RailClient(IHttpClientWrapper httpClient, ISerializationWrapper serializer)
        {
            if (httpClient == null) throw new ArgumentNullException("httpClient");
            if (serializer == null) throw new ArgumentNullException("serializer");
            _httpClient = httpClient;
            _serializer = serializer;
        }

        public async Task<Station[]> ListAllStationsAsync(Lang lang)
        {
            if (lang == null) throw new ArgumentNullException("lang");

            var request = new ListAllStationsRequest
            {
                Lang = lang
            };
            var response = await GetAsync<ListAllStationsRequest, ListAllStationsResponse>(request);

            return response.Stations;
        }

        private async Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request)
            where TRequest : RequestBase
        {
            var xml = await _httpClient.GetAsync(request);
            var response = _serializer.Deserialize<TResponse>(xml);

            return response;
        }
    }
}
