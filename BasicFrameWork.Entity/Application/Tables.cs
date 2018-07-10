using System.Collections.Generic;
using System.Xml.Serialization;

namespace BasicFramework.Entity
{
    public class Tables
    {
        [XmlElement("Table")]
        public List<Table> TableCollection { get; set; }
    }
}