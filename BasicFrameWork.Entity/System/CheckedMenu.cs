using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class CheckedMenu : Menu
    {
        [EntityPropertyExtension("IsChecked", "IsChecked")]
        public bool IsChecked { get; set; }

        [EntityPropertyExtension("IsOpen", "IsOpen")]
        public bool IsOpen { get; set; }

        public CheckedMenu(CheckedMenu menu)
        {
            ID = menu.ID; 
            Name = menu.Name;
            Children = menu.Children;
            IsChecked = menu.IsChecked;
            IsOpen = menu.IsOpen;
            DisplayOrder = menu.DisplayOrder;
            Glyphicon = menu.Glyphicon;
            Scenarios = menu.Scenarios;
            Link = menu.Link;
            SuperID = menu.SuperID;
        }

        public CheckedMenu() { }
    }

    public class RoleMenu : CheckedMenu
    {
        [EntityPropertyExtension("RoleID", "RoleID")]
        public long RoleID { get; set; }

        [EntityPropertyExtension("CanAdd", "CanAdd")]
        public bool CanAdd { get; set; }

        [EntityPropertyExtension("CanDelete", "CanDelete")]
        public bool CanDelete { get; set; }

        [EntityPropertyExtension("CanEdit", "CanEdit")]
        public bool CanEdit { get; set; }

        [EntityPropertyExtension("CanExport", "CanExport")]
        public bool CanExport { get; set; }
    }
}