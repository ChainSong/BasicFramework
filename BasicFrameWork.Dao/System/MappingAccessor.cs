using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.Entity.DataBaseEntity;
using BasicFramework.Entity.System;
using System.Linq;

namespace BasicFramework.Dao
{
    public class MappingAccessor : BaseAccessor
    {
        public IEnumerable<RoleMenu> GetAllRoleMenus()
        {
            return this.ExecuteDataTable("Proc_GetRoleMenus").ConvertToEntityCollection<RoleMenu>();
        }

        public IEnumerable<UserRoleMapping> GetUserRoleMapping()
        {
            return base.ExecuteDataTable("Proc_GetUserRoleMapping").ConvertToEntityCollection<UserRoleMapping>();
        }
        
        public int AddOrUpdateUserRoleMapping(IEnumerable<UserRoleMapping> userRoleMappings)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AddOrUpdateUserRoleMapping", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserRoleMapping", userRoleMappings.Select(userRole => new UserRoleMappingToDb(userRole)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@ReturnValue", 0);
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                cmd.Parameters[1].SqlDbType = SqlDbType.Int;

                conn.Open();

                cmd.ExecuteNonQuery();

                return cmd.Parameters[1].Value.ObjectToInt32();
            }
        }

        public int AddRoleMenuMapping(IEnumerable<Mapping> roleMenuMappings)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AddRoleMenuMapping", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleMenuMapping", roleMenuMappings.Select(mp => new SimpleMappingToDb(mp)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@ReturnValue", 0);
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                cmd.Parameters[1].SqlDbType = SqlDbType.Int;

                conn.Open();

                cmd.ExecuteNonQuery();

                return cmd.Parameters[1].Value.ObjectToInt32();
            }
        }
    }
}