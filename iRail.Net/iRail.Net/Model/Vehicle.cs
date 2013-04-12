using System;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Vehicle
    {
        [XmlAttribute("locationX")]
        public string LocationX { get; set; }

        [XmlAttribute("locationY")]
        public string LocationY { get; set; }

        [XmlText]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}