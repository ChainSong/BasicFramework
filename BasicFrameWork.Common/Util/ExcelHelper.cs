using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace BasicFramework.Common
{
    public sealed class ExcelHelper : IDisposable
    {
        private OleDbConnection connection = null;
        private bool isTempFile = false;
        private string path = string.Empty;

        public ExcelHelper()
        {
        }

        public ExcelHelper(string path)
        {
            this.path = path;
            this.CreateExcelConnection();
        }

        public ExcelHelper(Stream st, string filePath)
        {
            string fileName = string.Concat("temp_excel_", Guid.NewGuid().ToString(), Path.GetFileName(filePath));
            string directory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "temp");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            this.path = Path.Combine(directory, fileName);

            using (FileStream sm = File.Create(this.path))
            {
                st.CopyTo(sm);
                st.Flush();
                st.Close();
            }

            isTempFile = true;
            this.CreateExcelConnection();
        }

        public static void ReadExcelByOLEDB(string fullpath, string sheetName, Action<IDataReader, int> action)
        {
            using (var myConn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullpath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"))
            {
                using (var cmd = myConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "$]";
                    cmd.CommandType = CommandType.Text;
                    myConn.Open();
                    int row = 0;
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            action(reader, row++);
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
                if (isTempFile)
                {
                    File.Delete(path);
                }
            }
        }

        public bool DropSheet()
        {
            IList<string> sheets = GetSheetNameList();
            sheets.Each((i, x) => ExcuteExcelQueryCmd(string.Format("drop table [{0}]", x), null));
            return true;
        }

        public bool ExportExcel(DataTable dt, string sheetName)
        {
            DataColumnCollection dcc = dt.Columns;

            CreateSheet(dcc, sheetName);

            OleDbDataAdapter da = SetSheetQueryAdapter(dt, sheetName);

            da.Update(dt);

            return true;
        }

        public bool ExportExcel(DataSet ds)
        {
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                ExcuteExcelQueryCmd(string.Format("insert into [{0}]", ds.Tables[i].TableName), null);
            }

            return true;
        }

        public DataSet GetAllDataFromAllSheets()
        {
            DataSet ds = new DataSet();
            IList<string> sheetNames = GetSheetNameList();

            sheetNames.Each((i, x) =>
            {
                DataTable dt = GetAllDataFromExcel(x);
                dt.TableName = x;
                ds.Tables.Add(dt);
            });

            return ds;
        }

        public DataTable GetAllDataFromExcel()
        {
            string sheetName = GetSheetName();

            return GetAllDataFromExcel(sheetName);
        }

        public DataTable GetAllDataFromExcel(string sheetName)
        {
            string cmdText = string.Concat("SELECT * FROM [" + sheetName + "]");
            return ExecuteExcelAdapterCmd(cmdText, null);
        }

        public DataTable GetScopeDataFromExcel(string fromColumn, int fromRow, string toColumn, int toRow)
        {
            string sheetName = GetSheetName();

            return GetScopeDataFromExcel(sheetName, fromColumn, fromRow, toColumn, toRow);
        }

        public DataTable GetScopeDataFromExcel(string sheetName, string fromColumn, int fromRow, string toColumn, int toRow)
        {
            sheetName = string.Concat(sheetName, fromColumn, fromRow.ToString(), ":", toColumn, toRow.ToString());

            return GetAllDataFromExcel(sheetName);
        }

        public IList<string> GetSheetNameList()
        {
            DataTable dt = new DataTable();
            IList<string> alsheetName = new List<string>();
            dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            if (dt != null)
            {
                var rsResult = dt.CreateDataReader();
                if (rsResult != null)
                {
                    while (rsResult.Read())
                    {
                        int i = rsResult.GetString(2).IndexOf('$');
                        if (i > 0)
                        {
                            if (rsResult.GetString(2).Substring(i).Length == 1)
                            {
                                alsheetName.Add(rsResult.GetString(2));
                            }
                        }
                    }

                    rsResult.Close();
                    rsResult = null;
                }
            }

            return alsheetName;
            //int length = dt.Rows.Count;

            //List<string> sheets = new List<string>();

            //for (int i = 0; i < length; i++)
            //{
            //    sheets.Add(dt.Rows[i]["TABLE_NAME"].ToString());
            //}

            //return sheets;
        }

        private OleDbCommand AddCommandParameters(OleDbParameter[] parms, OleDbCommand cmd)
        {
            if (parms != null)
            {
                foreach (OleDbParameter param in parms)
                {
                    cmd.Parameters.Add(param);
                }
            }
            return cmd;
        }

        private string AddWithComma(string strSource, string strAdd)
        {
            if (strSource != "") strSource = strSource += ", ";
            return strSource + strAdd;
        }

        private void CreateExcelConnection()
        {
            string extension = Path.GetExtension(path);
            string connStr = string.Empty;

            try
            {
                if (extension == ".xls")
                    connStr = Constants.Excel03ConString;
                else if (extension == ".xlsx")
                    connStr = Constants.Excel07ConString;
                else
                    return;
            }
            catch
            {
                throw;
            }

            connStr = string.Format(connStr, path);
            connection = new OleDbConnection(connStr);

            try
            {
                connection.Open();
            }
            catch
            {
                throw;
            }
        }

        private void CreateSheet(DataColumnCollection dcc, string sheetName)
        {
            StringBuilder cmdText = new StringBuilder("CREATE TABLE [");
            cmdText.Append(sheetName);
            cmdText.Append("] ([");
            foreach (DataColumn column in dcc)
            {
                cmdText.Append(column.ColumnName);
                cmdText.Append("] String, [");
            }

            cmdText.Remove(cmdText.Length - 3, 3);
            cmdText.Append(")");

            ExcuteExcelQueryCmd(cmdText.ToString(), null);
        }

        private int ExcuteExcelQueryCmd(string cmdText, OleDbParameter[] parms)
        {
            int result;
            using (OleDbCommand cmd = new OleDbCommand(cmdText, connection))
            {
                AddCommandParameters(parms, cmd);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }

        private DataTable ExecuteExcelAdapterCmd(string cmdText, OleDbParameter[] parms)
        {
            DataTable dt = null;
            using (OleDbCommand cmd = new OleDbCommand(cmdText, connection))
            {
                AddCommandParameters(parms, cmd);

                dt = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(dt);
            }
            return dt;
        }

        private string GetExcelRangeByColumnCount(int count)
        {
            const int CARRY = 26; //Excel column range base on the characters from A - Z then AA - ZZ then AAA - ZZZ ...

            int tempC = count;
            int mod = 0;
            List<byte> listI = new List<byte>();

            for (int i = 0; tempC > 0; i++)
            {
                tempC -= 1;
                mod = tempC % CARRY;
                tempC = tempC / CARRY;
                listI.Add((byte)(mod + 65));
            }
            listI.Reverse();
            return new ASCIIEncoding().GetString(listI.ToArray());
        }

        private string GetSheetName()
        {
            DataTable dt = new DataTable();
            dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            return dt.Rows[0]["TABLE_NAME"].ToString();
        }

        private OleDbDataAdapter SetSheetQueryAdapter(DataTable dt, string sheetName)
        {
            try
            {
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                string strInsertPar = "";
                string strInsert = "";

                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                {
                    strInsert = AddWithComma(strInsert, dt.Columns[iCol].ColumnName);
                    strInsertPar = AddWithComma(strInsertPar, "?");
                }

                string sheetRange = GetExcelRangeByColumnCount(dt.Columns.Count);

                string strTable = "[" + sheetName + "$A:" + sheetRange + "]";
                strInsert = "INSERT INTO " + strTable + "(" + strInsert + ") Values (" + strInsertPar + ")";

                oleda.InsertCommand = new OleDbCommand(strInsert, connection);
                OleDbParameter oleParIns = null;
                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                {
                    oleParIns = new OleDbParameter("?", dt.Columns[iCol].DataType.ToString());
                    oleParIns.SourceColumn = dt.Columns[iCol].ColumnName;
                    oleda.InsertCommand.Parameters.Add(oleParIns);
                    oleParIns = null;
                }
                return oleda;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        #region COM Operate Excel

        private Excel.Application app = null;
        private Excel.Workbook book = null;
        private object misValue = Missing.Value;
        private Excel.Worksheet sheet = null;
        private IList<Excel.Worksheet> sheets = null;

        /// <summary>
        /// 根据自定义方法生成Excel
        /// </summary>
        /// <param name="action"></param>
        /// <param name="filePath"></param>
        public void CreateExcelByAction(string filePath, Action<object> action)
        {
            if (action == null)
            {
                return;
            }

            _initializeExcel();
            action(sheet);

            _checkExcelExist(filePath);
            _saveExcel(filePath);

            _releaseExcelObject();
        }

        public void CreateExcelByDataSet(string filePath, DataSet ds)
        {
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return;
            }
            _initializeMultiSheetsExcel();
            int index = 1;
            foreach (DataTable dt in ds.Tables)
            {
                Excel.Worksheet workSheet = null;
                if (index <= 3)
                {
                    workSheet = book.Worksheets.get_Item(index);
                }
                else
                {
                    workSheet = book.Worksheets.Add(misValue, book.Worksheets[index - 1], misValue, misValue);
                }
                if (!string.IsNullOrEmpty(dt.TableName))
                {
                    workSheet.Name = dt.TableName;
                }
                sheets.Add(workSheet);
                index++;

                _fillExcelByDataTable(dt, workSheet);
            }

            _checkExcelExist(filePath);
            _saveExcel(filePath);

            _releaseExcelObject();
        }

        /// <summary>
        /// 根据DataTable生成Excel
        /// </summary>
        public void CreateExcelByDataTable(string filePath, DataTable dt)
        {
            if (dt == null || dt.Rows == null || dt.Columns == null)
            {
                return;
            }
            _initializeExcel();

            if (!string.IsNullOrEmpty(dt.TableName))
            {
                sheet.Name = dt.TableName;
            }

            _fillExcelByDataTable(dt, sheet);

            _checkExcelExist(filePath);
            _saveExcel(filePath);

            _releaseExcelObject();
        }

        /// <summary>
        /// 根据自定义方法读取Excel
        /// </summary>
        /// <param name="filePath">Excel 路径</param>
        /// <param name="sheetName">需要读取的Excel</param>
        /// <param name="action">action</param>
        public T ReadExcelByAction<T>(string filePath, string sheetName, Func<object, T> action)
        {
            _openExcel(filePath);

            try
            {
                sheet = app.Sheets[sheetName];
                if (sheet == null)
                {
                    throw new Exception(sheetName + " 页面不存在");
                }

                T retult = action(sheet);
                return retult;
            }
            finally
            {
                _releaseExcelObject();
            }
        }

        public T ReadExcelByAction<T>(string filePath, int sheetIndex, Func<object, T> action)
        {
            _openExcel(filePath);

            sheet = app.Sheets[sheetIndex];
            if (sheet == null)
            {
                throw new Exception("这个页面不存在");
            }

            T retult = action(sheet);
            _releaseExcelObject();

            return retult;
        }

        public void RealeaseExcelObject()
        {
            _releaseExcelObject();
        }

        //----------------------------------------------
        //-----------对Excel对象的公共操作--------------
        //----------------------------------------------
        private void _checkExcelExist(string filePath)
        {
            string folderPath = filePath.Substring(0, filePath.LastIndexOf('\\'));
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void _fillExcelByDataTable(DataTable dt, Excel.Worksheet workSheet)
        {
            //Excel Header
            DataColumnCollection columns = dt.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                workSheet.Cells[1, i + 1] = columns[i].ColumnName;
            }

            //Excel Data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    workSheet.Cells[2 + i, 1 + j] = dt.Rows[i][j];
                }
            }
        }

        private void _initializeExcel()
        {
            app = new Excel.Application();
            book = app.Workbooks.Add(misValue);
            sheet = (Excel.Worksheet)book.Worksheets.get_Item(1);
        }

        private void _initializeMultiSheetsExcel()
        {
            app = new Excel.Application();
            book = app.Workbooks.Add(misValue);
            sheets = new List<Excel.Worksheet>();
        }

        private void _openExcel(string filePath)
        {
            app = new Excel.Application();
            book = app.Workbooks.Open(
                //Paths.QuestionnaireScorePath,
              filePath,
              misValue, //updatelinks
              false,    //readonly
              5,        //format
              "",       //Password
              "",       //writeResPass
              true,     //ignoreReadOnly
              Excel.XlPlatform.xlWindows, //origin
              "\t",     //delimiter
              true,     //editable
              false,    //Notify
              0,        //converter
              true      //AddToMru
              );
        }

        private void _releaseExcelObject()
        {
            app.AlertBeforeOverwriting = false;

            book.Close(true, misValue, misValue);
            app.Quit();

            if (sheet != null)
            {
                _releaseObject(sheet);
            }
            if (sheets != null)
            {
                _releaseObject(sheets);
            }
            _releaseObject(book);
            _releaseObject(app);
        }

        private void _releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
        }

        private void _saveExcel(string filePath)
        {
            book.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
        }

        #endregion COM Operate Excel
    }
}