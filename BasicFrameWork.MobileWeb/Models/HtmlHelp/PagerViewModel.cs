using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicFramework.MobileWeb.Models.HtmlHelp
{
    public class PagerViewModel
    {
        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public string FormID { get; set; }

        public string Identify { get; set; }

        public bool WritePageIndexAndCount
        {
            get
            {
                return this.writePageIndexAndCount;
            }
            set
            {
                this.writePageIndexAndCount = value;
            }
        }

        private bool writePageIndexAndCount = true;
    }
}