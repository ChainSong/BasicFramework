using System.Collections.Generic;
using System.Xml.Serialization;
using BasicFramework.Entity.Application;

namespace BasicFramework.Entity
{
    [XmlRoot("Projects")]
    public class Projects
    {
        [XmlElement("Project")]
        public List<Project> ProjectCollection { get; set; }
    }
}