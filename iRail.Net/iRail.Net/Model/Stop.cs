using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    public class Stop
    {
        [XmlElement("station", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Station Station { get; set; }

        [XmlElement("time", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Time Time { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("delay")]
        public int Delay { get; set; }
    }
}