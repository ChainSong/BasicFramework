using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace BasicFramework.Entity
{
    public class StringsToDb : SqlDataRecord
    {
        public StringsToDb(string str)
            : base(s_metadata)
        {
            SetSqlString(0, str);
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("Str",SqlDbType.NVarChar,50)
        };
    }
}
