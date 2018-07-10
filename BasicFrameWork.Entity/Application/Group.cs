using System.Xml.Serialization;

namespace BasicFramework.Entity
{
    public class Group
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsHide")]
        public bool IsHide { get; set; }
    }
}