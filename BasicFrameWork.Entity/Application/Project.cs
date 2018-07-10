using System.Collections.Generic;
using System.Xml.Serialization;

namespace BasicFramework.Entity.Application
{
    public class Project
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Module")]
        public List<Module> ModuleCollection { get; set; }

        [XmlElement("CalculateMethod")]
        public string CalculateMethod { get; set; }

        [XmlElement("PODNumberCreator")]
        public string PODNumberCreator { get; set; }

        [XmlElement("SettledPodConfigs")]
        public SettledPodConfigs SettledPodConfigs { get; set; }
    }
}