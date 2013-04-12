using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Via
    {
        [XmlElement("timeBetween", Form = XmlSchemaForm.Unqualified)]
        public int TimeBetween { get; set; }

        [XmlElement("vehicle", Form = XmlSchemaForm.Unqualified)]
        public string Vehicle { get; set; }

        [XmlElement("arrival")]
        public Arrival Arrival { get; set; }

        [XmlElement("departure")]
        public Departure Departure { get; set; }

        [XmlElement("station", IsNullable = true)]
        public Station Station { get; set; }

        [XmlElement("direction", IsNullable = true)]
        public Direction Direction { get; set; }
    }
}
