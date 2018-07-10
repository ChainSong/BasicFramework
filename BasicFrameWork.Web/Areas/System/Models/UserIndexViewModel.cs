using System.Collections.Generic;
using System.Web.Mvc;
using BasicFramework.Entity;
using BasicFramework.Web.Common;

namespace BasicFramework.Web.Areas.System.Models
{
    public class UserIndexViewModel : BaseViewModel
    {
        public string OriginalPassword { get; set; }

        public User User { get; set; }

        public IEnumerable<User> UserCollection { get; set; }

        public IEnumerable<SelectListItem> States
        {
            get
            {
                return ApplicationConfigHelper.GetTargetApplicationConfig("States");
            }
        }

        public IEnumerable<SelectListItem> UserTypes
        {
            get
            {
                return ApplicationConfigHelper.GetTargetApplicationConfig("UserType");
            }
        }

        public IEnumerable<SelectListItem> Sexs
        {
            get
            {
                return ApplicationConfigHelper.GetTargetApplicationConfig("Sex");
            }
        }
    }
}