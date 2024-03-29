﻿using System;

namespace iRail.Net.Requests
{
    public class VehicleRequest : JsonRequestBase
    {
        public VehicleRequest(string vehicleId)
            : base("/vehicle/")
        {
            if (vehicleId == null) throw new ArgumentNullException("vehicleId");

            VehicleId = vehicleId;
        }

        public string VehicleId
        {
            get { return GetParameter<string>("id"); }
            private set { SetParameter("id", value); }
        }

        public bool? Fast
        {
            get { return GetParameter<bool?>("fast"); }
            set { SetParameter("fast", value); }
        }
    }
}
