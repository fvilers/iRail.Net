using System.Xml.Schema;
using System.Xml.Serialization;

namespace iRail.Net.Model
{
    public class VehicleInformation
    {
        [XmlElement("vehicle", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public Vehicle Vehicle { get; set; }

        [XmlElement("stops", Form = XmlSchemaForm.Unqualified)]
        public CollectionStop Stops { get; set; }

    }
}
