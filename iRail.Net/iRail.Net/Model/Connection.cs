using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Connection
    {
        [XmlElement("duration", Form = XmlSchemaForm.Unqualified)]
        public int Duration { get; set; }

        [XmlElement("departure")]
        public Departure Departure { get; set; }

        [XmlElement("arrival")]
        public Arrival Arrival { get; set; }

        [XmlElement("vias", Form = XmlSchemaForm.Unqualified)]
        public ViaCollection Vias { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}