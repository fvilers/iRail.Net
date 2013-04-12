﻿using iRail.Net.Model;
using iRail.Net.Requests;
using iRail.Net.Responses;
using iRail.Net.Wrappers;
using System;
using System.Threading.Tasks;

namespace iRail.Net
{
    // TODO: NuGet package
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

        public async Task<Station[]> ListAllStationsAsync(Language language = null)
        {
            if (language == null) throw new ArgumentNullException("language");

            var request = new ListAllStationsRequest
            {
                Language = language
            };
            var response = await GetAsync<ListAllStationsRequest, ListAllStationsResponse>(request);

            return response.Stations;
        }

        // TODO: find out how to use transportType
        public async Task<Connection[]> SchedulesAsync(string fromStation, string toStation, DateTime? when = null, TimeSel timeSel = null, TransportType transportType = null, Language language = null)
        {
            if (fromStation == null) throw new ArgumentNullException("fromStation");
            if (toStation == null) throw new ArgumentNullException("toStation");

            var request = new SchedulesRequest
            {
                FromStation = fromStation,
                ToStation = toStation,
                Language = language
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

        public async Task<Departure[]> LiveboardAsync(string station, bool? fast = null, Language language = null)
        {
            if (station == null) throw new ArgumentNullException("station");

            var request = new LiveboardRequest
            {
                Station = station,
                Language = language
            };

            if (fast.HasValue)
            {
                request.Fast = fast.Value;
            }

            var response = await GetAsync<LiveboardRequest, LiveboardResponse>(request);

            return response.Departures.Items;
        }

        public async Task<Departure[]> LiveboardByStationIdAsync(string stationId, Language language = null)
        {
            if (stationId == null) throw new ArgumentNullException("stationId");

            var request = new LiveboardRequest
            {
                StationId = stationId,
                Language = language
            };
            var response = await GetAsync<LiveboardRequest, LiveboardResponse>(request);

            return response.Departures.Items;
        }

        public async Task<Stop[]> VehiculeAsync(string vehicleId, bool? fast = null, Language language = null)
        {
            if (vehicleId == null) throw new ArgumentNullException("vehicleId");

            var request = new VehicleRequest
            {
                VehicleId = vehicleId,
                Language = language
            };

            if (fast.HasValue)
            {
                request.Fast = fast.Value;
            }

            var response = await GetAsync<VehicleRequest, VehicleResponse>(request);

            return response.Stops.Items;
        }

        private async Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request)
            where TRequest : JsonRequestBase
        {
            var result = await _httpClient.TryGetAsync(request);
            
            if (!result.Item1)
            {
                throw new RailClientException(await _serializer.DeserializeAsync<ErrorResponse>(result.Item2));
            }

            return await _serializer.DeserializeAsync<TResponse>(result.Item2);
        }
    }

    public class RailClientException : Exception
    {
        public int ErrorCode { get; private set; }

        public RailClientException(ErrorResponse errorResponse)
            : base(errorResponse.Message)
        {
            ErrorCode = errorResponse.ErrorCode;
        }
    }
}
