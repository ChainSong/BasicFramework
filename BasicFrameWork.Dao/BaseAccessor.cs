using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BasicFramework.Entity;
using BasicFramework.Exceptions;
using System.Configuration;
using System.Data.SqlClient;

namespace BasicFramework.Dao
{
    public class BaseAccessor
    {
        protected static Database _dataBase;

        protected DbConnection _connection;

        protected DbTransaction _transAction;

        static BaseAccessor()
        {
            _dataBase = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }

        public BaseAccessor()
        { }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void BeginTransaction(IsolationLevel iso = IsolationLevel.ReadCommitted)
        {
            if (this._connection == null)
            {
                this.CreateConnection();
            }

            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }

            if (this._transAction == null)
            {
                this._transAction = this._connection.BeginTransaction(iso);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Commit()
        {
            if (this._transAction != null)
            {
                this._transAction.Commit();
                this._transAction.Dispose();
                this._transAction = null;
                this.ReleaseConnection();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RollBack()
        {
            if (this._transAction != null)
            {
                this._transAction.Rollback();
                this._transAction.Dispose();
                this._transAction = null;
                this.ReleaseConnection();
            }
        }

        internal DataRowCollection ExecuteDataRows(string spName, params DbParam[] parameters)
        {
            DataTable dt = this.ExecuteDataTable(spName, parameters);

            return dt == null || dt.Rows.Count == 0 ? null : dt.Rows;
        }

        internal DataRowCollection ExecuteDataRowsBySqlString(string sql, params DbParam[] parameters)
        {
            DataTable dt = this.ExecuteDataTableBySqlString(sql, parameters);

            return dt == null || dt.Rows.Count == 0 ? null : dt.Rows;
        }

        internal DataSet ExecuteDataSet(string spName, params DbParam[] parameters)
        {
            return this.ExecuteDataSet(spName, ExecuteType.StoredProc, parameters);
        }

        internal DataSet ExecuteDataSetBySqlString(string sql, params DbParam[] parameters)
        {
            return this.ExecuteDataSet(sql, ExecuteType.SqlString, parameters);
        }

        internal DataTable ExecuteDataTable(string spName, params DbParam[] parameters)
        {
            DataSet ds = this.ExecuteDataSet(spName, parameters);

            return ds == null || ds.Tables.Count == 0 ? null : ds.Tables[0];
        }

        internal DataTable ExecuteDataTableBySqlString(string sql, params DbParam[] parameters)
        {
            DataSet ds = this.ExecuteDataSetBySqlString(sql, parameters);

            return ds == null || ds.Tables.Count == 0 ? null : ds.Tables[0];
        }

        internal void ExecuteNoQuery(string spName, params DbParam[] parameters)
        {
            this.ExecuteNonQuery(spName, ExecuteType.StoredProc, parameters);
        }

        internal void ExecuteNoQueryBySqlString(string sql, params DbParam[] parameters)
        {
            this.ExecuteNonQuery(sql, ExecuteType.SqlString, parameters);
        }

        internal T ExecuteObject<T>(string spName, Func<DataRow, T> objCreator, params DbParam[] parameters)
        {
            return this.ExecuteObjects(spName, objCreator, parameters).FirstOrDefault();
        }

        internal T ExecuteObjectBySqlString<T>(string sql, Func<DataRow, T> objCreator, params DbParam[] parameters)
        {
            return this.ExecuteObjectsBySqlString(sql, objCreator, parameters).FirstOrDefault();
        }

        internal IEnumerable<T> ExecuteObjects<T>(string spName, Func<DataRow, T> objCreator, params DbParam[] parameters)
        {
            return this.ExecuteObjects(spName, objCreator, ExecuteType.StoredProc, parameters);
        }

        internal IEnumerable<T> ExecuteObjectsBySqlString<T>(string sql, Func<DataRow, T> objCreator, params DbParam[] parameters)
        {
            return this.ExecuteObjects(sql, objCreator, ExecuteType.SqlString, parameters);
        }

        internal Object ExecuteScalar(string spName, params DbParam[] parameters)
        {
            return this.ExecuteScalar(spName, ExecuteType.StoredProc, parameters);
        }

        internal Object ExecuteScalarBySqlString(string sql, params DbParam[] parameters)
        {
            return this.ExecuteScalar(sql, ExecuteType.SqlString, parameters);
        }

        protected void CreateConnection()
        {
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                this._connection = _dataBase.CreateConnection();
                this._connection.Open();
            }
        }

        protected void ReleaseConnection()
        {
            if (this._transAction == null && this._connection != null && this._connection.State != ConnectionState.Closed)
            {
                this._connection.Close();
                this._connection.Dispose();
                this._connection = null;
            }
        }

        private void AddParameterToDataBase(Database database, DbCommand command, params DbParam[] parameters)
        {
            if (parameters != null)
            {
                foreach (DbParam param in parameters)
                {
                    if (param.Direction == ParameterDirection.Input)
                    {
                        _dataBase.AddInParameter(command, param.Name, param.Type, param.Value);
                    }
                    else if (param.Direction == ParameterDirection.Output)
                    {
                        _dataBase.AddOutParameter(command, param.Name, param.Type, 0);
                    }
                }
            }
        }

        private DataSet ExecuteDataSet(Database dataBase, DbCommand command)
        {
            if (this._transAction != null)
            {
                return dataBase.ExecuteDataSet(command, this._transAction);
            }
            else
            {
                return dataBase.ExecuteDataSet(command);
            }
        }

        private DataSet ExecuteDataSet(string spNameOrSqlString, ExecuteType type, params DbParam[] parameters)
        {
            DataSet ds = null;

            try
            {
                this.CreateConnection();

                using (DbCommand command = type == ExecuteType.StoredProc ? _dataBase.GetStoredProcCommand(spNameOrSqlString) : _dataBase.GetSqlStringCommand(spNameOrSqlString))
                {
                    command.Connection = this._connection;
                    command.CommandTimeout = 180;//默认180秒

                    this.AddParameterToDataBase(_dataBase, command, parameters);

                    ds = this.ExecuteDataSet(_dataBase, command);

                    this.SetValueToParameters(command, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex.Message, ex.InnerException);
            }
            finally
            {
                ReleaseConnection();
            }

            return ds;
        }

        private void ExecuteNonQuery(Database dataBase, DbCommand command)
        {
            if (this._transAction != null)
            {
                dataBase.ExecuteNonQuery(command, this._transAction);
            }
            else
            {
                dataBase.ExecuteNonQuery(command);
            }
        }

        private void ExecuteNonQuery(string spNameOrSqlString, ExecuteType type, params DbParam[] parameters)
        {
            try
            {
                this.CreateConnection();

                using (DbCommand command = type == ExecuteType.StoredProc ? _dataBase.GetStoredProcCommand(spNameOrSqlString) : _dataBase.GetSqlStringCommand(spNameOrSqlString))
                {
                    command.Connection = _connection;
                    command.CommandTimeout = 180;//默认180秒

                    this.AddParameterToDataBase(_dataBase, command, parameters);

                    this.ExecuteNonQuery(_dataBase, command);

                    this.SetValueToParameters(command, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex.Message, ex.InnerException);
            }
            finally
            {
                this.ReleaseConnection();
            }
        }

        private IEnumerable<T> ExecuteObjects<T>(string spNameOrSqlString, Func<DataRow, T> objCreator, ExecuteType type, params DbParam[] parameters)
        {
            IList<T> list = new List<T>();

            DataRowCollection drs = type == ExecuteType.StoredProc ? this.ExecuteDataRows(spNameOrSqlString, parameters) : this.ExecuteDataRowsBySqlString(spNameOrSqlString, parameters);

            if (drs != null)
            {
                foreach (DataRow dr in drs)
                {
                    list.Add(objCreator(dr));
                }
                return list;
            }

            return Enumerable.Empty<T>();
        }

        private Object ExecuteScalar(Database dataBase, DbCommand command)
        {
            if (this._transAction != null)
            {
                return dataBase.ExecuteScalar(command, this._transAction);
            }
            else
            {
                return dataBase.ExecuteScalar(command);
            }
        }

        private Object ExecuteScalar(string spNameOrSqlString, ExecuteType type, params DbParam[] parameters)
        {
            Object obj = null;

            try
            {
                this.CreateConnection();

                using (DbCommand command = type == ExecuteType.StoredProc ? _dataBase.GetStoredProcCommand(spNameOrSqlString) : _dataBase.GetSqlStringCommand(spNameOrSqlString))
                {
                    command.Connection = this._connection;
                    command.CommandTimeout = 180;//默认180秒

                    this.AddParameterToDataBase(_dataBase, command, parameters);

                    obj = this.ExecuteScalar(_dataBase, command);

                    this.SetValueToParameters(command, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex.Message, ex.InnerException);
            }
            finally
            {
                ReleaseConnection();
            }

            return obj;
        }

        private void SetValueToParameters(DbCommand command, params DbParam[] parameters)
        {
            if (parameters != null)
            {
                if (parameters != null)
                {
                    foreach (DbParam param in parameters)
                    {
                        if (param.Direction == ParameterDirection.Output)
                        {
                            param.Value = command.Parameters[param.Name].Value;
                        }
                    }
                }
            }
        }

        public bool BulkCopy(string connectionString, String tableName, DataTable table)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conn))
                {
                    sqlBulkCopy.BulkCopyTimeout = 90;
                    sqlBulkCopy.DestinationTableName = tableName;
                    sqlBulkCopy.WriteToServer(table);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}