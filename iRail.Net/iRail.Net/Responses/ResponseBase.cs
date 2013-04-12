using System;
using System.Xml.Serialization;

namespace iRail.Net.Responses
{
    [SerializableAttribute]
    [XmlTypeAttribute(AnonymousType = true)]
    public abstract class ResponseBase
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
    }
}
