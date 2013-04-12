using System;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Platform
    {
        [XmlAttribute("normal")]
        public string Normal { get; set; }

        [XmlText]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value ?? Normal;
        }
    }
}
