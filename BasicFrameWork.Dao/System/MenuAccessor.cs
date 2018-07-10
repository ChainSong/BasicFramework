using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BasicFramework.Common;
using BasicFramework.Entity;

namespace BasicFramework.Dao
{
    public class MenuAccessor : BaseAccessor
    {
        

        public IEnumerable<Menu> GetApplicationMenus()
        {
            return this.ExecuteDataTable("Proc_GetMenus").ConvertToEntityCollection<Menu>();
        }
    }
}