using System.Collections.Generic;
using System.Xml.Serialization;

namespace BasicFramework.Entity
{
    public class Table
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Column")]
        public List<Column> ColumnCollection { get; set; }
    }
}