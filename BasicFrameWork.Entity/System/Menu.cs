using System.Collections.Generic;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class Menu
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        public IEnumerable<Menu> Children { get; set; }

        [EntityPropertyExtension("Link", "Link")]
        public string Link { get; set; }

        [EntityPropertyExtension("SuperID", "SuperID")]
        public long SuperID { get; set; }

        [EntityPropertyExtension("DisplayOrder", "DisplayOrder")]
        public int DisplayOrder { get; set; }

        [EntityPropertyExtension("Scenarios", "Scenarios")]
        public int Scenarios { get; set; }

        [EntityPropertyExtension("Glyphicon", "Glyphicon")]
        public string Glyphicon { get; set; }
    }
}