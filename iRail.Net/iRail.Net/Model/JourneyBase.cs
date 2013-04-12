using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public abstract class JourneyBase
    {
        [XmlElement("vehicle", Form = XmlSchemaForm.Unqualified)]
        public string Vehicle { get; set; }

        [XmlElement("station", IsNullable = true)]
        public Station Station { get; set; }

        [XmlElement("time", IsNullable = true)]
        public Time Time { get; set; }

        [XmlElement("platform", IsNullable = true)]
        public Platform Platform { get; set; }

        [XmlElement("direction", IsNullable = true)]
        public Direction Direction { get; set; }

        [XmlAttribute("delay")]
        public int Delay { get; set; }
    }
}
