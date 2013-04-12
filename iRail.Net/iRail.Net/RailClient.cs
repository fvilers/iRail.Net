using iRail.Net.Model;
using iRail.Net.Requests;
using iRail.Net.Responses;
using iRail.Net.Wrappers;
using System;
using System.Threading.Tasks;

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

        public async Task<Station[]> ListAllStationsAsync(Language lang)
        {
            if (lang == null) throw new ArgumentNullException("lang");

            var request = new ListAllStationsRequest
            {
                Lang = lang
            };
            var response = await GetAsync<ListAllStationsRequest, ListAllStationsResponse>(request);

            return response.Stations;
        }

        // TODO: find out how to use transportType
        public async Task<Connection[]> SchedulesAsync(string fromStation, string toStation, DateTime? when = null, TimeSel timeSel = null, TransportType transportType = null)
        {
            if (fromStation == null) throw new ArgumentNullException("fromStation");
            if (toStation == null) throw new ArgumentNullException("toStation");

            var request = new SchedulesRequest
            {
                FromStation = fromStation,
                ToStation = toStation
            };

            if (when.HasValue)
            {
                request.Date = String.Format("{0:ddMMyy}", when.Value);
                request.Time = String.Format("{0:HHmm}", when.Value);
            }

            if (timeSel != null)
            {
                request.TimeSel = timeSel;
            }

            var response = await GetAsync<SchedulesRequest, SchedulesResponse>(request);

            return response.Connections;
        }

        public async Task<Liveboard> LiveboardAsync(string station, bool? fast = null)
        {
            if (station == null) throw new ArgumentNullException("station");

            var request = new LiveboardRequest
            {
                Station = station
            };

            if (fast.HasValue)
            {
                request.Fast = fast.Value;
            }

            var response = await GetAsync<LiveboardRequest, LiveboardResponse>(request);

            return response.Liveboard;
        }

        public async Task<Liveboard> LiveboardByStationIdAsync(string stationId)
        {
            if (stationId == null) throw new ArgumentNullException("stationId");

            var request = new LiveboardRequest
            {
                StationId = stationId
            };
            var response = await GetAsync<LiveboardRequest, LiveboardResponse>(request);

            return response.Liveboard; // TODO: change response (see VehicleInformation)
        }

        public async Task<VehicleInformation> VehiculeAsync(string vehicleId, bool? fast = null)
        {
            if (vehicleId == null) throw new ArgumentNullException("vehicleId");

            var request = new VehicleRequest
            {
                VehicleId = vehicleId
            };

            if (fast.HasValue)
            {
                request.Fast = fast.Value;
            }

            var response = await GetAsync<VehicleRequest, VehicleResponse>(request);

            return response;
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
