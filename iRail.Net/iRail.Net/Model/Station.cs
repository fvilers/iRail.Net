using System;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Station
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("locationX")]
        public decimal LocationX { get; set; }

        [XmlAttribute("locationY")]
        public decimal LocationY { get; set; }

        [XmlAttribute("standardname")]
        public string StandardName { get; set; }

        [XmlText]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value ?? StandardName;
        }
    }
}