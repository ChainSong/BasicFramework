using System.Xml.Serialization;

namespace BasicFramework.Entity
{
    public class Module
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("UseCustomerOrderNumber")]
        public bool UseCustomerOrderNumber { get; set; }

        [XmlAttribute("AutoAllocateShipper")]
        public bool AutoAllocateShipper { get; set; }

        [XmlElement("Groups")]
        public Groups Groups { get; set; }

        [XmlElement("Tables")]
        public Tables Tables { get; set; }
    }
}