using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicFramework.Web.Common
{
    public class BaseViewModel
    {
        /// <summary>
        /// 当前第几页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页多少条
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; }
    }
}