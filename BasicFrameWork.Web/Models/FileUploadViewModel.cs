using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicFramework.Web.Models
{
    public class FileUploadViewModel
    {
        public string FileElementID { get; set; }

        public string HiddenFileID { get; set; }

        public string HiddenFileValue { get; set; }

        public bool IsReadOnly { get; set; }

        public bool LoadJs = true;

        public bool IsMultiple { get; set; }

        public bool OnlyShowAudit { get; set; }

        public bool IsCoverOld { get; set; }
    }
}