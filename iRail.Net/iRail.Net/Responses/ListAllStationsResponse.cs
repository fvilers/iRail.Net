using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using iRail.Net.Model;

namespace iRail.Net.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "stations", Namespace = "", IsNullable = false)]
    public class ListAllStationsResponse
    {
        [XmlElement("station", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Station[] Stations { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
    }
}
