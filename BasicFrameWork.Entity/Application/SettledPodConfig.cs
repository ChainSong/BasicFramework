using System.Collections.Generic;
using System.Xml.Serialization;
using BasicFramework.Entity.Application;

namespace BasicFramework.Entity
{
    public class SettledPodConfig
    {
        [XmlAttribute("Target")]
        public int Target { get; set; }

        [XmlAttribute("TargetID")]
        public long TargetID { get; set; }

        [XmlAttribute("UseNew")]
        public int UseNew { get; set; }

        [XmlAttribute("IsGroupedPods")]
        public int IsGroupedPods { get; set; }

        [XmlAttribute("InstanceName")]
        public string InstanceName { get; set; }
    }
}
