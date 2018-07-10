using System.Collections.Generic;
using System.Data;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.Entity.System;
namespace BasicFramework.Dao
{
    public class LoginAccessor : BaseAccessor
    {
        public User CheckLoginUser(string UserName, string Password)
        {
            DbParam[] paras = {
                      new DbParam("@Name", DbType.String,UserName, ParameterDirection.Input, 50),
                      new DbParam("@Password", DbType.String, Password, ParameterDirection.Input,50)
                        };
            return base.ExecuteDataTable("Proc_CheckLoginUser", paras).ConvertToEntity<User>();
        }
    }
}
