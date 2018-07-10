using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.Entity.DataBaseEntity;
using BasicFramework.Entity.ShipperManagement;

namespace BasicFramework.Dao
{
    public class ShipperManagementAccessor : BaseAccessor
    {
        public CRMShipperInfo GetCRMShipperInfoByID(long ID)
        {
            CRMShipperInfo shipperInfo = new CRMShipperInfo();
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ID", DbType.Int64, ID, ParameterDirection.Input)
            };

            DataSet ds = base.ExecuteDataSet("Proc_GetShipperByID", dbParams);
            if (ds != null)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    shipperInfo.Shipper = ds.Tables[0].ConvertToEntity<Shipper>();
                }
                else
                {
                    return shipperInfo;
                }

                if (ds.Tables[1] != null)
                {
                    shipperInfo.ShipperCooperationCollection = ds.Tables[1].ConvertToEntityCollection<ShipperCooperation>();
                }

                if (ds.Tables[2] != null)
                {
                    shipperInfo.ShipperTransportationLineCollection = ds.Tables[2].ConvertToEntityCollection<ShipperTransportationLine>();
                }

                if (ds.Tables[3] != null)
                {
                    shipperInfo.ShipperTerminalInfoCollection = ds.Tables[3].ConvertToEntityCollection<ShipperTerminalInfo>();
                }
            }

            return shipperInfo;
        }

        public IEnumerable<Shipper> GetCRMShippersByConditionNoPaging(ShipperSearchCondition SearchCondition)
        {
            string sqlWhere = this.GenGetCRMShipperWhere(SearchCondition);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input)
            };

            return this.ExecuteDataTable("Proc_GetShipperByConditionNoPaging", dbParams).ConvertToEntityCollection<Shipper>();
        }

        public IEnumerable<Shipper> GetCRMShippersByCondition(ShipperSearchCondition SearchCondition, int pageIndex, int pageSize, out int rowCount)
        {
            string sqlWhere = this.GenGetCRMShipperWhere(SearchCondition);
            int tempRowCount = 0;
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Where", DbType.String, sqlWhere, ParameterDirection.Input),
                new DbParam("@PageIndex", DbType.Int32, pageIndex, ParameterDirection.Input),
                new DbParam("@PageSize", DbType.Int32, pageSize, ParameterDirection.Input),
                new DbParam("@RowCount", DbType.Int32, tempRowCount, ParameterDirection.Output)
            };

            DataTable dt = this.ExecuteDataTable("Proc_GetShipperByCondition", dbParams);
            rowCount = (int)dbParams[3].Value;
            return dt.ConvertToEntityCollection<Shipper>();
        }

        public IEnumerable<ShipperCooperation> GetCRMShipperCooperationsByCRMShipperID(long CRMShipperID)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperID", DbType.Int64, CRMShipperID, ParameterDirection.Input)
            };

            return base.ExecuteDataTable("Proc_GetShipperCooperationByShipperID", dbParams).ConvertToEntityCollection<ShipperCooperation>();
        }

        public IEnumerable<ShipperTransportationLine> GetCRMShipperTransportationLinesByCRMShipperID(long CRMShipperID)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperID", DbType.Int64, CRMShipperID, ParameterDirection.Input)
            };

            return base.ExecuteDataTable("Proc_GetShipperTransportationLineByShipperID", dbParams).ConvertToEntityCollection<ShipperTransportationLine>();
        }

        public IEnumerable<ShipperTerminalInfo> GetCRMShipperTerminalInfosByCRMShipperID(long CRMShipperID)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ShipperID", DbType.Int64, CRMShipperID, ParameterDirection.Input)
            };

            return base.ExecuteDataTable("Proc_GetShipperTerminalInfosByShipperID", dbParams).ConvertToEntityCollection<ShipperTerminalInfo>();
        }

        public void DeleteCRMShipper(long ID)
        {
            DbParam[] Db = {
                           new DbParam("@ID",DbType.Int64,ID,ParameterDirection.Input)
                        };

            base.ExecuteNoQuery("Proc_DeleteShipper", Db);
        }

        public void DeleteCRMShipperTransportationLine(long ID)
        {
            DbParam[] Db = {
                           new DbParam("@ID",DbType.Int64,ID,ParameterDirection.Input)
                        };

            base.ExecuteNoQuery("Proc_DeleteShipperTransportationLine", Db);
        }

        public void DeleteCRMShipperTerminalInfo(long ID)
        {
            DbParam[] Db = {
                           new DbParam("@ID",DbType.Int64,ID,ParameterDirection.Input)
                        };

            base.ExecuteNoQuery("Proc_DeleteShipperTerminalInfo", Db);
        }

        public void DeleteCRMShipperCooperation(long ID)
        {
            DbParam[] Db = {
                           new DbParam("@ID",DbType.Int64,ID,ParameterDirection.Input)
                        };

            base.ExecuteNoQuery("Proc_DeleteShipperCooperation", Db);
        }

        public IEnumerable<long> AddOrUpdateCRMShippers(IEnumerable<Shipper> CRMShippers)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateShipper", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Shipper", CRMShippers.Select(c => new ShipperToDb(c)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IList<long> IDs = new List<long>();
                while (reader.Read())
                {
                    IDs.Add(reader.IsDBNull(0) ? 0 : reader.GetInt64(0));
                }

                return IDs;
            }
        }

        public IEnumerable<long> AddOrUpdateCRMShipperCooperations(IEnumerable<ShipperCooperation> CRMShipperCooperations)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateShipperCooperation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShipperCopperation", CRMShipperCooperations.Select(c => new ShipperCoopperationToDb(c)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IList<long> IDs = new List<long>();
                while (reader.Read())
                {
                    IDs.Add(reader.IsDBNull(0) ? 0 : reader.GetInt64(0));
                }

                return IDs;
            }
        }

        public IEnumerable<ShipperTransportationLine> AddOrUpdateCRMShipperTransportationLines(IEnumerable<ShipperTransportationLine> CRMShipperTransportationLines)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateShipperTransportationLine", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShipperTransportationLine", CRMShipperTransportationLines.Select(c => new ShipperTransportationLineToDb(c)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                conn.Open();

                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                Adp.Fill(dtable);
                return dtable.ConvertToEntityCollection<ShipperTransportationLine>();

            }
        }

        public IEnumerable<ShipperTerminalInfo> AddOrUpdateCRMShipperTerminalInfos(IEnumerable<ShipperTerminalInfo> CRMShipperTerminalInfos)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateShipperTerminalInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TerminalInfo", CRMShipperTerminalInfos.Select(c => new ShipperTerminalInfoToDb(c)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                conn.Open();

                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                Adp.Fill(dtable);
                return dtable.ConvertToEntityCollection<ShipperTerminalInfo>();

            }
        }

        private string GenGetCRMShipperWhere(ShipperSearchCondition SearchCondition)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(SearchCondition.Name))
            {
                sb.Append(" AND a.Name like '%").Append(SearchCondition.Name.Trim()).Append("%' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.Attribution))
            {
                sb.Append(" AND a.Attribution='").Append(SearchCondition.Attribution).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.RegisteredCapitalRange))
            {
                sb.Append(" AND a.RegisteredCapitalRange='").Append(SearchCondition.RegisteredCapitalRange).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.AnnualTurnoverRange))
            {
                sb.Append(" AND a.AnnualTurnoverRange='").Append(SearchCondition.AnnualTurnoverRange).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.TrunkOfVehicleType))
            {
                sb.Append(" AND a.TrunkOfVehicleType like '%").Append(SearchCondition.TrunkOfVehicleType).Append("%' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.FrequencyOfDeparture))
            {
                sb.Append(" AND a.FrequencyOfDeparture='").Append(SearchCondition.FrequencyOfDeparture).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.TrunkOfVehicleRange))
            {
                sb.Append(" AND a.TrunkOfVehicleRange='").Append(SearchCondition.TrunkOfVehicleRange).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.DeliveryOfVehicleRange))
            {
                sb.Append(" AND a.DeliveryOfVehicleRange='").Append(SearchCondition.DeliveryOfVehicleRange).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.WarehouseAreaRange))
            {
                sb.Append(" AND a.WarehouseAreaRange='").Append(SearchCondition.WarehouseAreaRange).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.Recommended))
            {
                sb.Append(" AND a.Recommended='").Append(SearchCondition.Recommended).Append("' ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.StartPlaceIDs))
            {
                StringBuilder startPlaceSB = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
                {
                    DataTable dtable = new DataTable();
                    SqlCommand cmd = new SqlCommand("Proc_GetReginAndSunRegionsByRegionIDs", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EndCityIDs", SearchCondition.StartPlaceIDs.Split(',').Select(c => new IdsForInt64(c.ObjectToInt64())));
                    cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                    SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                    Adp.Fill(dtable);
                    for (int i = 0; i < dtable.Rows.Count; i++)
                    {
                        startPlaceSB.Append(dtable.Rows[i][0].ToString()).Append(",");
                    }

                    startPlaceSB.Remove(startPlaceSB.Length - 1, 1);

                    sb.Append(" AND b.StartCityID IN (").Append(startPlaceSB.ToString()).Append(") ");
                }  
            }

            if (!string.IsNullOrEmpty(SearchCondition.EndPlaceIDs))
            {
                StringBuilder endPlaceSB = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
                {
                    DataTable dtable = new DataTable();
                    SqlCommand cmd = new SqlCommand("Proc_GetReginAndSunRegionsByRegionIDs", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EndCityIDs", SearchCondition.EndPlaceIDs.Split(',').Select(c => new IdsForInt64(c.ObjectToInt64())));
                    cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                    SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                    Adp.Fill(dtable);
                    for (int i = 0; i < dtable.Rows.Count; i++)
                    {
                        endPlaceSB.Append(dtable.Rows[i][0].ToString()).Append(",");
                    }

                    endPlaceSB.Remove(endPlaceSB.Length - 1, 1);

                    sb.Append(" AND b.EndCityID IN (").Append(endPlaceSB.ToString()).Append(") ");
                }
            }

            if (!string.IsNullOrEmpty(SearchCondition.CoverRegionIDs))
            {
                var CoverRegionIDs = SearchCondition.CoverRegionIDs.Split(',');
                sb.Append(" AND b.CoverRegionID IN (");
                CoverRegionIDs.Each((i, s) => { sb.Append(s).Append(","); });
                sb.Remove(sb.Length - 1, 1);
                sb.Append(") ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.TransportMode))
            {
                var transportModes = SearchCondition.TransportMode.Split('|');
                sb.Append(" AND (");
                transportModes.Each((i, t) => {
                    sb.Append("a.TransportMode like '%").Append(t).Append("%' ").Append(" OR ");
                });
                sb.Remove(sb.Length - 3, 3);
                sb.Append(") ");
            }

            if (!string.IsNullOrEmpty(SearchCondition.ProductType))
            {
                var productTypes = SearchCondition.ProductType.Split('|');
                sb.Append(" AND (");
                productTypes.Each((i, t) =>
                {
                    sb.Append("c.Str7 like '%").Append(t).Append("%' ").Append(" OR ");
                });
                sb.Remove(sb.Length - 3, 3);
                sb.Append(") ");
            }
            
            if (!string.IsNullOrEmpty(SearchCondition.KeyWord))
            {
                sb.Append(" AND (").Append("c.Name like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR a.Name like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Remark like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Str1 like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Str2 like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Str3 like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Str4 like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Str5 like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Str6 like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR c.Str7 like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR a.AnnualTurnover like '%").Append(SearchCondition.KeyWord.Trim())
                  .Append("%' OR a.Remark like '%").Append(SearchCondition.KeyWord.Trim()).Append("%')");
            }

            if (!string.IsNullOrEmpty(SearchCondition.PartnerShipType))
            {
                sb.Append(" AND a.PartnershipTypes = '").Append(SearchCondition.PartnerShipType).Append("' ");
            }

            return sb.ToString();
        }

        //承运商车辆管理 根据SID查询当前承运商已有车辆
        public IEnumerable<ShipperVehicleMapping> GetShipperToVehicle(long SID)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@SID", DbType.Int64, SID, ParameterDirection.Input),
                              };
            return this.ExecuteDataTable("Proc_GetShipperToVehicle", dbParams).ConvertToEntityCollection<ShipperVehicleMapping>();
        }
        //public IEnumerable<ShipperToVehicle> GetShipperToVehicle()
        //{
        //    return this.ExecuteDataTable("Proc_GetShipperToVehicle").ConvertToEntityCollection<ShipperToVehicle>();
        //}

        //所有的承运商
        public IEnumerable<Shipper> GetAllShippers()
        {
            return this.ExecuteDataTable("Proc_GetAllShippers").ConvertToEntityCollection<Shipper>();
        }
    }
}
