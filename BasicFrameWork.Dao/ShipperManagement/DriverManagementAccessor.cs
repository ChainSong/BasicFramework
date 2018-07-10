using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BasicFramework.Common;
using System.Threading.Tasks;
using BasicFramework.Entity;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using System.Data.SqlClient;
using BasicFramework.Entity.DataBaseEntity;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;

namespace BasicFramework.Dao.ShipperManagement
{
    public class DriverManagementAccessor : BaseAccessor
    {
        //查询
        public IEnumerable<Driver> GetCRMDriverByConditionNoPaging(DriverSearchCondition SearchCondition)
        {
            string sqlWhere = this.GenGetDriverWhere(SearchCondition);
            DbParam[] dbParams = new DbParam[]{
           new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input)
           };
            return this.ExecuteDataTable("Proc_GetDriverByConditionNoPaging", dbParams).ConvertToEntityCollection<Driver>();
        }


        //查询及页数。。
        public IEnumerable<Driver> GetCRMDriverByCondition(DriverSearchCondition Driver, int PageIndex, int PageSize, out int RowCount)
        {
            string sqlWhere = this.GenGetDriverWhere(Driver);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetDriverByCondition", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }
        //手机端的查询    条件是或者
        public IEnumerable<Driver> GetCRMDriverBykeyWord(string keyword, int PageIndex, int PageSize, out int RowCount)
        {
            string sqlWhere = this.GenGetCRMDriverWheres(keyword);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetCRMDriverByCondition", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }

        /// <summary>
        /// 通过车辆ID查询该车辆由那几位司机驾驶
        /// </summary>
        /// <param name="shipperid"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public IEnumerable<Driver> GetVehicleMappingDriverVID(string vid, int PageIndex, int PageSize, out int RowCount)
        {
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@VID", DbType.String, vid, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetVehicleMappingDriverVID", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }
 
        /// <summary>
        /// 通过车辆id查询该车由哪几位司机驾驶待条件分页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keyword"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public IEnumerable<Driver> GetVehicleMappingDriverInfoByVIDandkeyWord(string id, string keyword, int PageIndex, int PageSize, out int RowCount)
        {
            string sqlWhere = this.GenGetCRMDriverWheres(keyword);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@VID", DbType.String, id, ParameterDirection.Input),
                new DbParam("@where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetVehicleMappingDriverInfoByVIDandkeyWord", dbParams);
            RowCount = (int)dbParams[4].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }


        /// <summary>
        /// 通过shipperID查询当前承运商有哪些司机服务
        /// </summary>
        /// <param name="shipperid"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public IEnumerable<Driver> GetShippingMappingDriverSID(string Sid, int PageIndex, int PageSize, out int RowCount)
        {
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@SID", DbType.String, Sid, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetShippingMappingDriverSID", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }
        
        /// <summary>
        /// 通过shipperid查询该承运商由哪几位司机驾驶待条件分页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keyword"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public IEnumerable<Driver> GetShipperMappingDriverInfoBySIDandkeyWord(string id, string keyword, int PageIndex, int PageSize, out int RowCount)
        {
            string sqlWhere = this.GenGetCRMDriverWheres(keyword);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@SID", DbType.String, id, ParameterDirection.Input),
                new DbParam("@where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetShipperMappingDriverInfoBySIDandkeyWord", dbParams);
            RowCount = (int)dbParams[4].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }


        //新增或更新
        public IEnumerable<Driver> AddOrUpdateCRMDriver(IEnumerable<Driver> CRMDriver)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                string message = "";
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateDriver", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Driver", CRMDriver.Select(p => new CRMDriverToDb(p)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters[1].SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters[1].Size = 10;
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                message = sda.SelectCommand.Parameters["@message"].Value.ToString();
                conn.Close();
                return ds.Tables[0].ConvertToEntityCollection<Driver>();
            }
        }

        //根据ID查询
        public Driver GetCRMDriverSearchConditionByID(string id)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {


                DbParam[] dbParams = new DbParam[]{
                new DbParam("@ID", DbType.String, id, ParameterDirection.Input),
               
            };
                DataTable dt = this.ExecuteDataTable("Proc_GetDriverSearchByID", dbParams);

                return dt.ConvertToEntity<Driver>();
                //SqlCommand cmd = new SqlCommand("Proc_GetCRMVehicleSearchID", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@VehicleID", id);
                //cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                //conn.Open();
                //DataTable ds = new DataTable();
                //SqlDataAdapter VSC = new SqlDataAdapter(cmd);
                //VSC.Fill(ds);  
                //return ds.ConvertToEntity<CRMVehicle>();
            }
        }
        private string GenGetCRMDriverWheres(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" and (");
            sb.Append("  CRM_Driver.DriverName like").Append("'%" + keyword + "%'");
            sb.Append(" or CRM_Driver.DriverLogisticsCompany like").Append("'%" + keyword + "%'");
            sb.Append(" or CRM_Driver.DriverPhone like").Append("'%" + keyword + "%'");
            sb.Append(" or CRM_Driver.DriverCardNo like").Append("'%" + keyword + "%'");
            sb.Append(" or CRM_Driver.DriverStartServeForRunbowDate like").Append("'%" + keyword + "%'");
            sb.Append(" or CRM_Driver.DriverServiceArea like").Append("'%" + keyword + "%'");
            sb.Append(" or CRM_Driver.DriverMainRoute like").Append("'%" + keyword + "%'").Append(")");
            return sb.ToString();
        }

        //删除
        public bool DeleteCRMDriver(string ID)
        {
            DbParam[] dbParams = new DbParam[] {
                           new DbParam("@ID",DbType.String,ID,ParameterDirection.Input)
                        };
            string str = this.ExecuteScalar("Proc_DeleteDriver", dbParams).ToString();
            if (!string.IsNullOrEmpty(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GenGetDriverWhere(DriverSearchCondition SearchCondition)
        {
            StringBuilder sb = new StringBuilder();

            //司机姓名
            if (!string.IsNullOrEmpty(SearchCondition.DriverName))
            {
                sb.Append(" AND Driver.DriverName like '%").Append(SearchCondition.DriverName.Trim()).Append("%' ");
            }
            //物流公司
            if (!string.IsNullOrEmpty(SearchCondition.DriverLogisticsCompany))
            {
                sb.Append(" AND Driver.DriverLogisticsCompany like '%").Append(SearchCondition.DriverLogisticsCompany.Trim()).Append("%' ");
            }
            //联系电话
            if (!string.IsNullOrEmpty(SearchCondition.DriverPhone))
            {
                sb.Append(" AND Driver.DriverPhone like '%").Append(SearchCondition.DriverPhone.Trim()).Append("%' ");
            }
            //开始为虹迪服务日期
            if (!string.IsNullOrEmpty(SearchCondition.StartServeForRunbowTime))
            {
                sb.Append(" and Driver.DriverStartServeForRunbowDate>='").Append(SearchCondition.StartServeForRunbowTime).Append("'");
                //sb.Append(" AND CRM_Driver.DriverStartServeForRunbowDate='").Append(SearchCondition.DriverStartServeForRunbowDate).Append("' ");
            }
            if (!string.IsNullOrEmpty(SearchCondition.EndServeForRunbowTime))
            {
                sb.Append(" and Driver.DriverStartServeForRunbowDate<='").Append(SearchCondition.EndServeForRunbowTime).Append("'");
                //sb.Append(" AND CRM_Driver.DriverStartServeForRunbowDate='").Append(SearchCondition.DriverStartServeForRunbowDate).Append("' ");
            }
            //身份证号码
            if (!string.IsNullOrEmpty(SearchCondition.DriverIDCard))
            {
                sb.Append(" AND Driver.DriverIDCard like '%").Append(SearchCondition.DriverIDCard.Trim()).Append("%' ");
            }
            //驾驶证档案号
            if (!string.IsNullOrEmpty(SearchCondition.DriverCardNo))
            {
                sb.Append(" AND Driver.DriverCardNo like '%").Append(SearchCondition.DriverCardNo.Trim()).Append("%' ");
            }
            //是否在服务中
            if (!string.IsNullOrEmpty(SearchCondition.DriverIsServing))
            {
                sb.Append(" AND Driver.DriverIsServing='").Append(SearchCondition.DriverIsServing.Trim()).Append("' ");
            }
            //驾照类型
            if (!string.IsNullOrEmpty(SearchCondition.DriverCardType))
            {
                sb.Append(" AND Driver.DriverCardType='").Append(SearchCondition.DriverCardType.Trim()).Append("' ");
            }
            //登记证签发地
            if (!string.IsNullOrEmpty(SearchCondition.DriverRegistrationCardSignedAddress))
            {
                sb.Append(" AND Driver.DriverRegistrationCardSignedAddress like '%").Append(SearchCondition.DriverRegistrationCardSignedAddress.Trim()).Append("%' ");
            }
            //服务区域
            if (!string.IsNullOrEmpty(SearchCondition.DriverServiceArea))
            {
                sb.Append(" AND Driver.DriverServiceArea like '%").Append(SearchCondition.DriverServiceArea.Trim()).Append("%' ");
            }
            //驾驶车辆牌号
            if (!string.IsNullOrEmpty(SearchCondition.DriverCarNo))
            {
                sb.Append(" AND Driver.DriverCarNo like '%").Append(SearchCondition.DriverCarNo.Trim()).Append("%' ");
            }
            //主要行驶路线
            if (!string.IsNullOrEmpty(SearchCondition.DriverMainRoute))
            {
                sb.Append(" AND Driver.DriverMainRoute like '%").Append(SearchCondition.DriverMainRoute).Append("%' ");
            }

            return sb.ToString();
        }

        public IEnumerable<Driver> GetDriverList()
        {
            return this.ExecuteDataTable("Proc_GetDriverList").ConvertToEntityCollection<Driver>();
        }



        //车辆司机管理 分页
        public IEnumerable<Driver> GetAllDriver(DriverSearchCondition ds, int PageIndex, int PageSize, out int RowCount)
        {
            string Where = SqlWhere(ds);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, Where, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetAllDriver", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }

        public IEnumerable<Driver> GetAllDrivers(DriverSearchCondition ds, int PageIndex, int PageSize, out int RowCount)
        {
            string Where = SqlWhere(ds);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, Where, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetAllDrivers", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Driver>();
        }


        private string SqlWhere(DriverSearchCondition ds)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(ds.DriverName))
            {
                IEnumerable<string> numbers = Enumerable.Empty<string>();
                if (ds.DriverName.IndexOf("\n") > 0)
                {
                    numbers = ds.DriverName.Split('\n').Select(s => { return s.Trim(); });
                }
                if (ds.DriverName.IndexOf(',') > 0)
                {
                    numbers = ds.DriverName.Split(',').Select(s => { return s.Trim(); });
                }

                if (numbers != null && numbers.Any())
                {
                    numbers = numbers.Where(c => !string.IsNullOrEmpty(c));
                }

                if (numbers != null && numbers.Any())
                {
                    sb.Append(" and DriverName in ( ");
                    foreach (string s in numbers)
                    {
                        sb.Append("'").Append(s).Append("',");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(" ) ");
                }
                else
                {
                    sb.Append(" and DriverName  like '%" + ds.DriverName.Trim() + "%' ");
                }
            }
            if (!string.IsNullOrEmpty(ds.VehicleID))
            {
                sb.Append("and VID ='" + ds.VehicleID.Trim()+ " ' ");
            }

            return sb.ToString();
        }

        public IEnumerable<VehicleDriverMapping> AddOrUpdateVehicleDriverMapping(string VehicleNo, string DriverName, string UserName)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                string message = "";
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateVehicleDriverMapping", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo);
                cmd.Parameters[0].SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters[0].Size = 50;
                cmd.Parameters.AddWithValue("@Driver", DriverName);
                cmd.Parameters[1].SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters[1].Size = 50;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters[2].SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters[2].Size = 50;
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters[3].SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters[3].Size = 50;
                cmd.Parameters[3].Direction = ParameterDirection.Output;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                message = sda.SelectCommand.Parameters["@message"].Value.ToString();
                conn.Close();
                return ds.Tables[0].ConvertToEntityCollection<VehicleDriverMapping>();
            }

        }
        
        public IEnumerable<Driver> GetCRM_VehicleMappingDriver(string vehicleno)
        {

            DbParam[] dbParams = new DbParam[]{
                new DbParam("@VehicleNo", DbType.String, vehicleno, ParameterDirection.Input)
                 
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetCRM_VehicleMappingDriver", dbParams);

            return dt.ConvertToEntityCollection<Driver>();
        }



        public IEnumerable<Driver> GetCRMVehicleMappingDriver(string vehicleno, string drivername)
        {
            string Where = SqlWhere(vehicleno, drivername);
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, Where, ParameterDirection.Input)
            
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetCRMVehicleMappingDriver", dbParams);
            return dt.ConvertToEntityCollection<Driver>();
        }

        private string SqlWhere(string vehicleno, string drivername)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(drivername))
            {
                IEnumerable<string> numbers = Enumerable.Empty<string>();
                if (drivername.IndexOf("\n") > 0)
                {
                    numbers = drivername.Split('\n').Select(s => { return s.Trim(); });
                }
                if (drivername.IndexOf(',') > 0)
                {
                    numbers = drivername.Split(',').Select(s => { return s.Trim(); });
                }

                if (numbers != null && numbers.Any())
                {
                    numbers = numbers.Where(c => !string.IsNullOrEmpty(c));
                }

                if (numbers != null && numbers.Any())
                {
                    sb.Append(" and d.DriverName in ( ");
                    foreach (string s in numbers)
                    {
                        sb.Append("'").Append(s).Append("',");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(" ) ");
                }
                else
                {
                    sb.Append(" and d.DriverName  like '%" + drivername.Trim() + "%' ");
                }
            }
            if (!string.IsNullOrEmpty(vehicleno))
            {
                sb.Append("and VehicleNo ='" + vehicleno + "'");

            }
            return sb.ToString();
        }


        public IEnumerable<VehicleDriverMapping> GetVehicleMappingDriver(string vehicleno)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@VehicleNo", DbType.String, vehicleno, ParameterDirection.Input)
            };
           // return this.ExecuteDataTable("Proc_GetVehicleMappingDriverView", dbParams).ConvertToEntityCollection<VehicleDriverMapping>();
            DataTable dt = this.ExecuteDataTable("Proc_GetVehicleMappingDriverView", dbParams);

            return dt.ConvertToEntityCollection<VehicleDriverMapping>();
 
        }


        public IEnumerable<Driver> GetDriverView(string vehicleno)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@VehicleNo", DbType.String, vehicleno, ParameterDirection.Input)  

          };
            DataTable dt = this.ExecuteDataTable("Proc_GetVehicleMappingDriverView", dbParams);

            return dt.ConvertToEntityCollection<Driver>();
        }

        public bool DeleteVehicleDriverMapping(string drivername)
        {
            //string where = this.where(vehicleno, shippername);
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String,drivername , ParameterDirection.Input)
            };

            string str = this.ExecuteScalar("Proc_DeleteVehicleDriverMapping", dbParams).ToString();
            if (!string.IsNullOrEmpty(str))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }

}
