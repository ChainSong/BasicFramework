using System.Collections.Generic;
using System.Xml.Serialization;

namespace BasicFramework.Entity
{
    public class Column
    {
        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [XmlAttribute("DbColumnName")]
        public string DbColumnName { get; set; }

        [XmlAttribute("IsKey")]
        public bool IsKey { get; set; }

        [XmlAttribute("IsSearchCondition")]
        public bool IsSearchCondition { get; set; }

        [XmlAttribute("IsHide")]
        public bool IsHide { get; set; }

        [XmlAttribute("IsReadOnly")]
        public bool IsReadOnly { get; set; }

        [XmlAttribute("Group")]
        public string Group { get; set; }

        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlAttribute("DefaultValue")]
        public string DefaultValue { get; set; }

        [XmlAttribute("Order")]
        public int Order { get; set; }

        [XmlAttribute("IsShowInList")]
        public bool IsShowInList { get; set; }

        [XmlAttribute("IsImportColumn")]
        public bool IsImportColumn { get; set; }

        [XmlAttribute("SearchConditionOrder")]
        public int SearchConditionOrder { get; set; }

        [XmlAttribute("ForView")]
        public bool ForView { get; set; }

        [XmlElement("RoleID")]
        public List<long> ShowRoleIDs { get; set; }

        [XmlAttribute("CustomerID")]
        public long CustomerID { get; set; }

        [XmlElement("Column")]
        public List<Column> InnerColumns { get; set; }
    }
}