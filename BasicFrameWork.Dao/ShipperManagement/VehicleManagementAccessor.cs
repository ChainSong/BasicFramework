using BasicFramework.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Common;
using System.Data.SqlClient;
using BasicFramework.Entity.DataBaseEntity;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.Entity.ShipperManagement;


namespace BasicFramework.Dao.ShipperManagement
{
   
    public class VehicleManagementAccessor : BaseAccessor
    {
        //查询
        public IEnumerable<Vehicle> GetCRMVehicleByConditionNoPaging(VehicleSearchCondition SearchCondition)
        {
            string sqlWhere = this.GenGetVehicleWhere(SearchCondition);
            DbParam[] dbParams = new DbParam[]{
            new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input)
            };

            return this.ExecuteDataTable("Proc_GetVehicleByConditionNoPaging", dbParams).ConvertToEntityCollection<Vehicle>();
        }
        
        
        //两个
        public IEnumerable<Vehicle> GetVehicleByCondition(VehicleSearchCondition Vehicle, int PageIndex, int PageSize, out int RowCount)
        {
            string sqlWhere = this.GenGetVehicleWhere(Vehicle);
              int tempRowCount = 0;
              DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
              DataTable dt = this.ExecuteDataTable("Proc_GetVehicleByCondition", dbParams);
             RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Vehicle>();

        }

        public IEnumerable<Vehicle> GetVehicleView(string id) //, int PageIndex, int PageSize, out int RowCount
        {
            //int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperID", DbType.String, id, ParameterDirection.Input),
                //new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                //new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                //new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetShipperMappingVehicleView", dbParams);
            //RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Vehicle>();

        
        }


        /// <summary>
        /// 通过承运商ID查询该承运商下面有哪些车辆 
        /// </summary>
        /// <param name="shipperid"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetShipperMappingVehicleBySID(string shipperid, int PageIndex, int PageSize, out int RowCount)
        {
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperID", DbType.String, shipperid, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetShipperMappingVehicleBySID", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Vehicle>();
        }
        //手机端查询
        public IEnumerable<Vehicle> GetCRMVehicleBykeyword(string keyword, int PageIndex, int PageSize, out int RowCount)
        {
            string sqlWhere = this.GenGetCRMVehicleWheres(keyword);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetCRMVehicleByConditionurl", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Vehicle>();

        }
       
        //通过shipperid查车辆再在结果集里面根据关键字查询  分页
        public IEnumerable<Vehicle> GetShipperMappingVehicleInfoByShipperIDandkeyWord(string id, string keyword, int PageIndex, int PageSize, out int RowCount)
        {
            string sqlWhere = this.GenGetCRMVehicleWheres(keyword);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperID", DbType.String, id, ParameterDirection.Input),
                new DbParam("@where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetShipperMappingVehicleInfoByShipperIDandkeyWord", dbParams);
            RowCount = (int)dbParams[4].Value;
            return dt.ConvertToEntityCollection<Vehicle>();
        }

        //未明
        //private string QuerySql(CRMVehicleSearchCondition Vehicle)
        //{
        //    StringBuilder sb = new StringBuilder();



        //    return sb.ToString();
        //}


        public IEnumerable<Vehicle> AddOrUpdateVehicles(IEnumerable<Vehicle> Vehicle)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                string message = "";
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateVehicle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vehicle", Vehicle.Select(p => new CRMVehicleToDb(p)));
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
                return ds.Tables[0].ConvertToEntityCollection<Vehicle>();
            }
        }

        //删除
        public bool DeleteVehicle(string ID)
        {
            DbParam[] dbParams = new DbParam[] {
                           new DbParam("@ID",DbType.String,ID,ParameterDirection.Input)
                        };
            string str = this.ExecuteScalar("Proc_DeleteVehicle", dbParams).ToString();
            if (!string.IsNullOrEmpty(str))
            {
                return true;
            }
            else
                return false;
           //base.ExecuteNoQuery("Proc_DeleteCRMVehicle", Db);
        }


         

        //根据ID查询
        public Vehicle GetCRMVehicleSearchConditionID(string id)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
 
               
                DbParam[] dbParams = new DbParam[]{
                new DbParam("@VehicleID", DbType.String, id, ParameterDirection.Input),
               
            };
                DataTable dt = this.ExecuteDataTable("Proc_GetVehicleSearchID", dbParams);
                
                return dt.ConvertToEntity<Vehicle>();
                 
            }
        }
        public Vehicle GetCRMVehiclebyID(string id)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                DbParam[] dbParams = new DbParam[]{
                new DbParam("@VehicleID", DbType.String, id, ParameterDirection.Input),
               
            };
                DataTable dt = this.ExecuteDataTable("Proc_GetCRMVehiclebyID", dbParams);

                return dt.ConvertToEntity<Vehicle>();

            }
        }
        private string GenGetVehicleWhere(VehicleSearchCondition SearchCondition)
        {
            StringBuilder sb = new StringBuilder();
            //车牌号
            if (!string.IsNullOrEmpty(SearchCondition.CarNo))
            {
                sb.Append(" AND Vehicle.CarNo like '%").Append(SearchCondition.CarNo.Trim()).Append("%' ");
            }
            //车型编码
            if (!string.IsNullOrEmpty(SearchCondition.CarTypeNo))
            {
                sb.Append(" AND Vehicle.CarTypeNo like '%").Append(SearchCondition.CarTypeNo.Trim()).Append("%' ");
            }
            //物流公司
            if (!string.IsNullOrEmpty(SearchCondition.LogisticCompany))
            {
                sb.Append(" AND Vehicle.LogisticCompany like '%").Append(SearchCondition.LogisticCompany.Trim()).Append("%' ");
            }
            //已行驶公里数
            if (!string.IsNullOrEmpty(SearchCondition.DrivedJourney))
            {
                sb.Append(" AND Vehicle.DrivedJourney='").Append(SearchCondition.DrivedJourney.Trim()).Append("' ");
            }
            //上牌日期
            if (!string.IsNullOrEmpty(SearchCondition.StartBoardlotTime))
            {
                sb.Append("and  Vehicle.BoardlotDate>='").Append(SearchCondition.StartBoardlotTime.Trim()).Append("'");
                //sb.Append(" AND CRM_Vehicle.BoardlotDate='").Append(SearchCondition.BoardlotDate).Append("' ");
            }
            if (!string.IsNullOrEmpty(SearchCondition.EndBoardlotTime))
            {
                sb.Append("and  Vehicle.BoardlotDate<='").Append(SearchCondition.EndBoardlotTime.Trim()).Append("'");
                //sb.Append(" AND CRM_Vehicle.BoardlotDate='").Append(SearchCondition.BoardlotDate).Append("' ");
            }
            //车龄
            if (!string.IsNullOrEmpty(SearchCondition.CarAge))
            {
                sb.Append(" AND Vehicle.CarAge like '%").Append(SearchCondition.CarAge.Trim()).Append("%' ");
            }
            //号牌种类
            if (!string.IsNullOrEmpty(SearchCondition.CarNumType))
            {
                sb.Append(" AND Vehicle.CarNumType='").Append(SearchCondition.CarNumType.Trim()).Append("' ");
            }
            //车身颜色
            if (!string.IsNullOrEmpty(SearchCondition.CarBodyColor))
            {
                sb.Append(" AND Vehicle.CarBodyColor like '%").Append(SearchCondition.CarBodyColor.Trim()).Append("%' ");
            }
            //生产厂家
            if (!string.IsNullOrEmpty(SearchCondition.Manufacturer))
            {
                sb.Append(" AND Vehicle.Manufacturer like '%").Append(SearchCondition.Manufacturer.Trim()).Append("%' ");
            }
            //整备质量
            if (!string.IsNullOrEmpty(SearchCondition.EntireCarWeight))
            {
                sb.Append(" AND Vehicle.EntireCarWeight='").Append(SearchCondition.EntireCarWeight.Trim()).Append("' ");
            }
            //燃料种类
            if (!string.IsNullOrEmpty(SearchCondition.FuelType))
            {
                sb.Append(" AND Vehicle.FuelType='").Append(SearchCondition.FuelType.Trim()).Append("' ");
            }
            //开始服务日期
            if (!string.IsNullOrEmpty(SearchCondition.StartServiceTime))
            {
                sb.Append("and  Vehicle.StartServiceDate>='").Append(SearchCondition.StartServiceTime).Append("'");
                //sb.Append(" AND CRM_Vehicle.StartServiceDate='").Append(SearchCondition.StartServiceDate).Append("' ");
            }
            if (!string.IsNullOrEmpty(SearchCondition.EndServiceTime))
            {
                sb.Append("and  Vehicle.StartServiceDate<='").Append(SearchCondition.EndServiceTime).Append("'");
                //sb.Append(" AND CRM_Vehicle.StartServiceDate='").Append(SearchCondition.StartServiceDate).Append("' ");
            }



            return sb.ToString();

        }

        private string GenGetCRMVehicleWheres(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" and (");
            //车牌号
            sb.Append("  Vehicle.CarNo like ").Append("'%" + keyword + "%'");

            //车型编码
            sb.Append(" or Vehicle.CarTypeNo like ").Append("'%" + keyword + "%'");

            //物流公司
            sb.Append(" or Vehicle.LogisticCompany like ").Append("'%" + keyword + "%'");

            //已行驶公里数
            sb.Append(" or Vehicle.DrivedJourney like ").Append("'%" + keyword + "%'");

            //车龄
            sb.Append(" or Vehicle.CarAge like ").Append("'%" + keyword + "%'");

            //号牌种类
            sb.Append(" or  Vehicle.CarNumType like ").Append("'%" + keyword + "%'");

            //车身颜色
            sb.Append(" or Vehicle.CarBodyColor like ").Append("'%" + keyword + "%'");

            //整备质量
            sb.Append(" or Vehicle.EntireCarWeight like ").Append("'%" + keyword + "%'");

            //燃料种类
            sb.Append(" or Vehicle.FuelType like ").Append("'%" + keyword + "%'").Append(")");

            return sb.ToString();

        }

        // 获取所有的车辆
        public IEnumerable<Vehicle> GetVehicleList()
        {
           
            return this.ExecuteDataTable("Proc_GetVehicleList").ConvertToEntityCollection<Vehicle>();
        }

       

        /// <summary>
        ///获取所有车辆 分页
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetAllVehicle(VehicleSearchCondition vsc, int PageIndex, int PageSize, out int RowCount)//Vehicle Vehicle,
        {

            string Where = SqlWhere(vsc);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                 
                new DbParam("@Where", DbType.String,Where , ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetAllVehicle", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Vehicle>();

        }
        private string SqlWhere(VehicleSearchCondition vsc)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(vsc.CarNo))
            {
                IEnumerable<string> numbers = Enumerable.Empty<string>();
                if (vsc.CarNo.IndexOf("\n") > 0)
                {
                    numbers = vsc.CarNo.Split('\n').Select(s => { return s.Trim(); });
                }
                if (vsc.CarNo.IndexOf(',') > 0)
                {
                    numbers = vsc.CarNo.Split(',').Select(s => { return s.Trim(); });
                }

                if (numbers != null && numbers.Any())
                {
                    numbers = numbers.Where(c => !string.IsNullOrEmpty(c));
                }

                if (numbers != null && numbers.Any())
                {
                    sb.Append(" and CarNo in ( ");
                    foreach (string s in numbers)
                    {
                        sb.Append("'").Append(s).Append("',");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(" ) ");
                }
                else
                {
                    sb.Append(" and CarNo  like '%" + vsc.CarNo.Trim() + "%' ");
                }
            }
            if (!string.IsNullOrEmpty(vsc.ShipperID))
            {
                sb.Append(" and SID  ='" + vsc.ShipperID.Trim() + "' ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 根据车牌号码查询
        /// </summary>
        /// <param name="vsc"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RowCount"></param>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetAllVehicles(VehicleSearchCondition vsc, int PageIndex, int PageSize, out int RowCount)//Vehicle Vehicle,
        {

            string Where = SqlWheres(vsc);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                 
                new DbParam("@Where", DbType.String,Where , ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };
            DataTable dt = this.ExecuteDataTable("Proc_GetAllVehicles", dbParams);
            RowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Vehicle>();

        }
        private string SqlWheres(VehicleSearchCondition vsc)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(vsc.CarNo))
            {
                IEnumerable<string> numbers = Enumerable.Empty<string>();
                if (vsc.CarNo.IndexOf("\n") > 0)
                {
                    numbers = vsc.CarNo.Split('\n').Select(s => { return s.Trim(); });
                }
                if (vsc.CarNo.IndexOf(',') > 0)
                {
                    numbers = vsc.CarNo.Split(',').Select(s => { return s.Trim(); });
                }

                if (numbers != null && numbers.Any())
                {
                    numbers = numbers.Where(c => !string.IsNullOrEmpty(c));
                }

                if (numbers != null && numbers.Any())
                {
                    sb.Append(" and CarNo in ( ");
                    foreach (string s in numbers)
                    {
                        sb.Append("'").Append(s).Append("',");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(" ) ");
                }
                else
                {
                    sb.Append(" and CarNo  like '%" + vsc.CarNo.Trim() + "%' ");
                }
            }
            return sb.ToString();
        }






        /// <summary>
        /// 分配车辆信息
        /// </summary>
        /// <param name="crmCar"></param>
        /// <returns></returns>
        public IEnumerable<ShipperVehicleMapping> AddShipperMappingVehicle(string carno, string ShipperName, string UserName)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                string message = "";
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateShipperVehicleMapping", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Vehicle", crmcar.Select(p => new CRMShipperToVehicleToDb(p)));
                cmd.Parameters.AddWithValue("@Vehicle", carno);
                cmd.Parameters[0].SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters[0].Size = 50;
                cmd.Parameters.AddWithValue("@ShipperName", ShipperName);
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
                return ds.Tables[0].ConvertToEntityCollection<ShipperVehicleMapping>();

                //string message = "";
                //SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateVehicle", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Vehicle", Vehicle.Select(p => new CRMVehicleToDb(p)));
                //cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                //cmd.Parameters.AddWithValue("@message", message);
                //cmd.Parameters[1].SqlDbType = SqlDbType.NVarChar;
                //cmd.Parameters[1].Size = 10;
                //cmd.Parameters[1].Direction = ParameterDirection.Output;
                //conn.Open();
                //DataSet ds = new DataSet();
                //SqlDataAdapter sda = new SqlDataAdapter();
                //sda.SelectCommand = cmd;
                //sda.Fill(ds);
                //message = sda.SelectCommand.Parameters["@message"].Value.ToString();
                //conn.Close();
                //return ds.Tables[0].ConvertToEntityCollection<Vehicle>();
               
            }

        }

        public bool DeleteShipperMappingVehicle(string vehicleno)
        {
            //string where = this.where(vehicleno, shippername);
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String,vehicleno , ParameterDirection.Input)
            };
            
            string str = this.ExecuteScalar("Proc_DeleteShipperMappingVehicle", dbParams).ToString();
            if (!string.IsNullOrEmpty(str))
            {
                return true;
            }
            else {
                return false;
            }
           
            
        }
        //public string where(string vehicleno, string shippername)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    if (!string.IsNullOrEmpty(vehicleno) && !string.IsNullOrEmpty(shippername))
        //    {
        //        sb.Append("and VehicleNo = '"+vehicleno+"' and ShipperName = '"+shippername+"'");
        //    }
             

        //    return sb.ToString();
        //}

        public IEnumerable<Vehicle> GetCRM_ShipperMappingVehicle(string shippername)
        { 
            
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperName", DbType.String, shippername, ParameterDirection.Input)
                 
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetShipperMappingVehicle", dbParams);
       
            return dt.ConvertToEntityCollection<Vehicle>();
        }


        public IEnumerable<Vehicle> GetCRMShipperMappingVehicle(string shippername, string vehicleno)
        {
            string Where = SqlWhere(vehicleno,shippername);
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, Where, ParameterDirection.Input)
            
            };
            DataTable dt = this.ExecuteDataTable("Pro_GetShipperVehicleMapping", dbParams);
            return dt.ConvertToEntityCollection<Vehicle>();
        }

        public IEnumerable<ShipperVehicleMapping> GetShipperMappingVehicle(string shippername)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperName", DbType.String, shippername, ParameterDirection.Input)
            };
            return this.ExecuteDataTable("Proc_GetShipperMappingVehicle", dbParams).ConvertToEntityCollection<ShipperVehicleMapping>();

        }

        private string SqlWhere(string vehicle,string shippername)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(vehicle))
            {
                IEnumerable<string> numbers = Enumerable.Empty<string>();
                if (vehicle.IndexOf("\n") > 0)
                {
                    numbers = vehicle.Split('\n').Select(s => { return s.Trim(); });
                }
                if (vehicle.IndexOf(',') > 0)
                {
                    numbers = vehicle.Split(',').Select(s => { return s.Trim(); });
                }

                if (numbers != null && numbers.Any())
                {
                    numbers = numbers.Where(c => !string.IsNullOrEmpty(c));
                }

                if (numbers != null && numbers.Any())
                {
                    sb.Append(" and CarNo in ( ");
                    foreach (string s in numbers)
                    {
                        sb.Append("'").Append(s).Append("',");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(" ) ");
                }
                else
                {
                    sb.Append(" and CarNo  like '%" + vehicle.Trim() + "%' ");
                }
            }
            if (!string.IsNullOrEmpty(shippername))
            {
                sb.Append("and ShipperName ='" + shippername+"'");
            
            }
            return sb.ToString();
        }

        




        //public IEnumerable<CRMVehicle> SearchVehicle(string vehicleNo, int PageIndex, int PageSize, out int RowCount)
        //{
        //    string sqlWhere = this.SearchVehicle(vehicleNo);
        //    int tempRowCount = 0;
        //    DbParam[] dbParams = new DbParam[]{
        //        new DbParam("@Where", DbType.String,sqlWhere , ParameterDirection.Input),
        //        new DbParam("@PageIndex", DbType.Int32, PageIndex, ParameterDirection.Input),
        //        new DbParam("@PageSize", DbType.Int32, PageSize, ParameterDirection.Input),
        //        new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
        //    };
        //    DataTable dt = this.ExecuteDataTable("Proc_SearchVehicle", dbParams);
        //    RowCount = (int)dbParams[3].Value;
        //    return dt.ConvertToEntityCollection<CRMVehicle>();
             
        //}

        //    private string SearchVehicle(string vehicle)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        if (!string.IsNullOrEmpty(vehicle))
        //        {
        //            IEnumerable<string> numbers = Enumerable.Empty<string>();
        //            if (vehicle.IndexOf("\n") > 0)
        //            {
        //                numbers = vehicle.Split('\n').Select(s => { return s.Trim(); });
        //            }
        //            if (vehicle.IndexOf(',') > 0)
        //            {
        //                numbers = vehicle.Split(',').Select(s => { return s.Trim(); });
        //            }

        //            if (numbers != null && numbers.Any())
        //            {
        //                numbers = numbers.Where(c => !string.IsNullOrEmpty(c));
        //            }

        //            if (numbers != null && numbers.Any())
        //            {
        //                sb.Append(" and VehicleNo in ( ");
        //                foreach (string s in numbers)
        //                {
        //                    sb.Append("'").Append(s).Append("',");
        //                }
        //                sb.Remove(sb.Length - 1, 1);
        //                sb.Append(" ) ");
        //            }
        //            else
        //            {
        //                sb.Append(" and VehicleNo  like '%" + vehicle.Trim() + "%' ");
        //            }
        //        }
        //        return sb.ToString();
        //    }
    
    
    
    
    }
}
