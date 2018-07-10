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
    public class UserAccessor : BaseAccessor
    {
        public IEnumerable<User> GetUsersByCondition(User user, int pageIndex, int pageSize, out int rowCount)
        {
            string strSQL = this.GetSqlWhere(user);
            DbParam[] dbParams = {
                           new DbParam("@where",DbType.String,strSQL,ParameterDirection.Input),
                           new DbParam("@PageIndex",DbType.Int32,pageIndex,ParameterDirection.Input),
                           new DbParam("@PageSize",DbType.Int32,pageSize,ParameterDirection.Input),
                           new DbParam("@RowCount",DbType.Int32,0,ParameterDirection.Output)
                          };

            IEnumerable<User> userCollection = base.ExecuteDataTable("Proc_GetUsersByCondition", dbParams).ConvertToEntityCollection<User>();
            rowCount = (int)dbParams[3].Value;
            return userCollection;
        }

        public User GetUserById(long id)
        {
            DbParam[] paras = {
                      new DbParam("@ID", DbType.Int64, id, ParameterDirection.Input)
                             };
            return base.ExecuteDataTable("Proc_GetUserByID", paras).ConvertToEntity<User>();
        }

        public User CheckLoginUser(string UserName, string Password, long ProjectID)
        {
            DbParam[] paras = {
                      new DbParam("@Name", DbType.String,UserName, ParameterDirection.Input, 50),
                      new DbParam("@Password", DbType.String, Password, ParameterDirection.Input,50),
                      new DbParam("@ProjectID", DbType.Int64, ProjectID, ParameterDirection.Input,50)
                                                  };
            return base.ExecuteDataTable("Proc_CheckLoginUser", paras).ConvertToEntity<User>();
        }

        public int AddOrUpdateUsers(IEnumerable<User> userCollection)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AddOrUpdateUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Users", userCollection.Select(u => new UserToDb(u)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@ReturnValue", 0);
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                cmd.Parameters[1].SqlDbType = SqlDbType.Int;

                conn.Open();

                cmd.ExecuteNonQuery();

                return cmd.Parameters[1].Value.ObjectToInt32();
            }
        }

        public long AddUser(string name, string displyName, string password, bool state, char sex, string tel, string mobile, string email, int userType, long customerOrShipperID, out int returnVal)
        {
            DbParam[] dbParams = {
                             new DbParam("@Name", DbType.String, name, ParameterDirection.Input),
                             new DbParam("@DisplyName", DbType.String, displyName, ParameterDirection.Input),
                             new DbParam("@Password", DbType.String, password, ParameterDirection.Input),
                             new DbParam("@State", DbType.Boolean, state, ParameterDirection.Input),
                             new DbParam("@Sex", DbType.String, sex, ParameterDirection.Input),
                             new DbParam("@Tel", DbType.String, tel, ParameterDirection.Input),
                             new DbParam("@Mobile", DbType.String, mobile, ParameterDirection.Input),
                             new DbParam("@Email", DbType.String, email, ParameterDirection.Input),
                             new DbParam("@UserType", DbType.Int32, userType, ParameterDirection.Input),
                             new DbParam("@CustomerOrShipperID", DbType.Int64, customerOrShipperID, ParameterDirection.Input),
                             new DbParam("@ReturnVal", DbType.Int32, 0, ParameterDirection.Output)
                             };

            long userID = base.ExecuteScalar("Proc_AddUser", dbParams).ObjectToInt64();
            returnVal = dbParams[10].Value.ObjectToInt32();
            return userID;
        }

        public void UpdateUser(long ID, string name, string displyName, bool state, char sex, string tel, string mobile, string email, int userType, long customerOrShipperID)
        {
            DbParam[] dbParams = {
                             new DbParam("@ID", DbType.Int64, ID, ParameterDirection.Input),
                             new DbParam("@Name", DbType.String, name, ParameterDirection.Input),
                             new DbParam("@DisplyName", DbType.String, displyName, ParameterDirection.Input),
                             new DbParam("@State", DbType.Boolean, state, ParameterDirection.Input),
                             new DbParam("@Sex", DbType.String, sex, ParameterDirection.Input),
                             new DbParam("@Tel", DbType.String, tel, ParameterDirection.Input),
                             new DbParam("@Mobile", DbType.String, mobile, ParameterDirection.Input),
                             new DbParam("@Email", DbType.String, email, ParameterDirection.Input),
                             new DbParam("@UserType", DbType.Int32, userType, ParameterDirection.Input),
                             new DbParam("@CustomerOrShipperID", DbType.Int64, customerOrShipperID, ParameterDirection.Input)
                             };
            base.ExecuteNoQuery("Proc_UpdateUser", dbParams);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.ExecuteDataTable("Proc_GetAllUsers").ConvertToEntityCollection<User>();
        }

        public bool UpdateUserPassword(long ID, string Password)
        {
            DbParam[] dbParams = {
                             new DbParam("@ID", DbType.String, ID, ParameterDirection.Input),
                             new DbParam("@Password", DbType.String, Password, ParameterDirection.Input)
                             
                             };  
               
           return base.ExecuteScalar("Proc_UserPassword_Alter", dbParams).ObjectToInt64() >=0 ? true : false;  
        }


        public string GetSqlWhere(User user)
        {
            if (user == null)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(user.Name))
            {
                sb.Append(" AND Name like '%" + user.Name + "%'");
            }
            if (!string.IsNullOrEmpty(user.DisplayName))
            {
                sb.Append(" AND DisplayName like '%" + user.DisplayName + "%'");
            }

            if (user.State.HasValue)
            {
                sb.Append(" AND State=" + (user.State.Value ? "1" : "0") + " ");
            }

            if (user.UserType.HasValue)
            {
                sb.Append("And UserType=" + user.UserType.Value.ToString() + " ");
            }

            return sb.ToString();
        }

    }
}