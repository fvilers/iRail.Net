using iRail.Net.Model;
using System;
using System.Xml.Serialization;

namespace iRail.Net.Responses
{
    [SerializableAttribute]
    [XmlType(AnonymousType = true)]
    [XmlRoot("vehicleinformation", Namespace = "", IsNullable = false)]
    public class VehicleResponse : VehicleInformation
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
    }
}
