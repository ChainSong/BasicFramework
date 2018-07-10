using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;

namespace BasicFramework.Dao
{
    public class RegionAccessor : BaseAccessor
    {
        public Region AddRegion(Region region)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Code", DbType.String, string.IsNullOrEmpty(region.Code) ? System.Data.SqlTypes.SqlString.Null : region.Code, ParameterDirection.Input),
                new DbParam("@Name", DbType.String, string.IsNullOrEmpty(region.Name) ? System.Data.SqlTypes.SqlString.Null : region.Name, ParameterDirection.Input),
                new DbParam("@SupperID", DbType.Int64, region.SupperID, ParameterDirection.Input),
                new DbParam("@Grade", DbType.Int32, region.Grade, ParameterDirection.Input),
                new DbParam("@IsParent", DbType.Boolean, false, ParameterDirection.Input)
            };

            return this.ExecuteDataTable("Proc_AddRegion", dbParams).ConvertToEntity<Region>();
        }

        public IEnumerable<Region> GetRegionAndSunRegions(long RegionID)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                DataTable dtable = new DataTable();
                IList<IdsForInt64> ids = new List<IdsForInt64>() { new IdsForInt64(RegionID) };
                SqlCommand cmd = new SqlCommand("Proc_GetReginAndSunRegionsByRegionIDs", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EndCityIDs", ids);
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                Adp.Fill(dtable);
                return dtable.ConvertToEntityCollection<Region>();
            }
        }
    }
}
