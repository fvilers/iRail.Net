using System;
using System.Globalization;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Time
    {
        [XmlAttribute("formatted")]
        public DateTime Formatted { get; set; }

        [XmlText]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value ?? Formatted.ToString(CultureInfo.InvariantCulture);
        }
    }
}
