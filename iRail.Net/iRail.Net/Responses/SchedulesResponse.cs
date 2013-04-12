using iRail.Net.Model;
using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Responses
{
    [SerializableAttribute]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(ElementName = "connections", Namespace = "", IsNullable = false)]
    public class SchedulesResponse
    {
        [XmlElement("connection", Form = XmlSchemaForm.Unqualified)]
        public Connection[] Connections { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
    }
}
