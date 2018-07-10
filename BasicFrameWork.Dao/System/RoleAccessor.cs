using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using System.Text;
using BasicFramework.Entity.DataBaseEntity;

namespace BasicFramework.Dao
{
    public class RoleAccessor : BaseAccessor
    {
        public int AddOrUpdateRoles(IEnumerable<Role> roleCollection)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AddOrUpdateRoles", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Roles", roleCollection.Select(role => new RolesToDb(role)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@ReturnValue", 0);
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                cmd.Parameters[1].SqlDbType = SqlDbType.Int;

                conn.Open();

                cmd.ExecuteNonQuery();

                return cmd.Parameters[1].Value.ObjectToInt32();
            }
        }

        public Role GetRoleByID(long id)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ID", DbType.Int64, id, ParameterDirection.Input)
            };

            return this.ExecuteDataTable("Proc_GetRoleByID", dbParams).ConvertToEntity<Role>();
        }

        public IEnumerable<Role> GetRolesByCondition(Role role, int PageIndex, int PageSize, out int RowCount)
        {
            string strSQL = this.GetSqlWhere(role);
            DbParam[] dbParams = {
                           new DbParam("@where",DbType.String,strSQL,ParameterDirection.Input),
                           new DbParam("@PageIndex",DbType.Int32,PageIndex,ParameterDirection.Input),
                           new DbParam("@PageSize",DbType.Int32,PageSize,ParameterDirection.Input),
                           new DbParam("@RowCount",DbType.Int32,0,ParameterDirection.Output)
                          };

            IEnumerable<Role> rollist = base.ExecuteDataTable("Proc_GetRolesByCondition", dbParams).ConvertToEntityCollection<Role>();
            RowCount = (int)dbParams[3].Value;
            return rollist;
        }

        public string GetSqlWhere(Role role)
        {
            if (role == null)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(role.Description))
            {
                sb.Append(" AND Description like '%" + role.Description + "%'");
            }

            if (!string.IsNullOrEmpty(role.Name))
            {
                sb.Append(" AND Name like '%" + role.Name + "%'");
            }

            if(role.State.HasValue)
            {
                sb.Append(" AND State=" + (role.State.Value ? "1" : "0") + " ");
            }

            return sb.ToString();
        }
    }
}