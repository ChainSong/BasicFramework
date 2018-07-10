using System.Collections.Generic;
using System.Linq;

namespace BasicFramework.Web.Areas.System.Models
{
    public class DemoPagerViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public static IEnumerable<DemoPagerViewModel> GetList(int pageIndex, int pageSize, out int pageCount)
        {
            IList<DemoPagerViewModel> vms = new List<DemoPagerViewModel>();
            for (int i = 0; i < 100; i++)
            {
                vms.Add(new DemoPagerViewModel() { ID = i + 1, Name = "Name" + (i + 1).ToString() });
            }
            pageCount = 20;
            return vms.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}