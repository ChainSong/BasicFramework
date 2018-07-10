using System.Data;
using Microsoft.SqlServer.Server;

namespace BasicFramework.Entity
{
    public class IdsForInt32 : SqlDataRecord
    {
        public IdsForInt32(int id)
            : base(s_metadata)
        {
            SetSqlInt32(0, id);
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID",SqlDbType.Int)
        };
    }
}