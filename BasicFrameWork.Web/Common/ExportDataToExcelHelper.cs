using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using we = System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BasicFramework.Biz;
using BasicFramework.Entity;
using BasicFramework.Web.Common;
using MyFile = System.IO.File;
using UtilConstants = BasicFramework.Common.Constants;
using BasicFramework.Common;
using System.Text;


namespace BasicFramework.Web.Common
{
    public class ExportDataToExcelHelper
    {
        /// <summary>
        ///  将DataSet写入到Excel文件中
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fname"></param>
        /// <returns></returns>

        public static void ExportDataSetToExcel(DataSet ds, string fname)
        {
            string[,] head1 = new string[4, ds.Tables[0].Columns.Count - 1];
            //string path = "D:\\";
            // path = System.Configuration.ConfigurationManager.AppSettings["Email"].ToString();
            AppLibrary.WriteExcel.XlsDocument doc = new AppLibrary.WriteExcel.XlsDocument();
            string Time = DateTime.Now.ToString("yyyy-MM-dd");
            //doc.FileName = fname+ ".xls";
            doc.FileName = HttpUtility.UrlEncode(fname, System.Text.Encoding.UTF8);
            string SheetName = string.Empty;

            //计算当前多少个SHEET
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                SheetName = ds.Tables[i].TableName;
                AppLibrary.WriteExcel.Worksheet sheet = doc.Workbook.Worksheets.Add(SheetName);
                AppLibrary.WriteExcel.Cells cells = sheet.Cells;
                AppLibrary.WriteExcel.XF center = doc.NewXF();//添加样式的  
                center.HorizontalAlignment = AppLibrary.WriteExcel.HorizontalAlignments.Centered;
                center.Font.FontName = "宋体";//字体  
                center.TextDirection = AppLibrary.WriteExcel.TextDirections.LeftToRight;//文本位置  
                center.Font.Bold = true;//加粗  
                AppLibrary.WriteExcel.ColumnInfo colInfo = new AppLibrary.WriteExcel.ColumnInfo(doc, sheet);
                colInfo.ColumnIndexStart = 0;  //开始列  
                colInfo.ColumnIndexEnd = 20;   //结束列
                colInfo.Width = 5000;   //列宽
                colInfo.Collapsed = true;
            
              //  colInfo.Width = 150;
                sheet.AddColumnInfo(colInfo);
                //边框线的样式
                center.DiagonalLineStyle = new AppLibrary.WriteExcel.LineStyle();
                center.BottomLineStyle = 1;
                center.LeftLineStyle = 1;
                center.TopLineStyle = 1;
                center.RightLineStyle = 1;
                center.RightLineColor = AppLibrary.WriteExcel.Colors.Grey;
                center.LeftLineColor = AppLibrary.WriteExcel.Colors.Grey;
                center.TopLineColor = AppLibrary.WriteExcel.Colors.Grey;
                center.BottomLineColor = AppLibrary.WriteExcel.Colors.Grey;
                sheet.AddColumnInfo(colInfo);
                AppLibrary.WriteExcel.XF Head = doc.NewXF();//添加样式的  
                Head.HorizontalAlignment = AppLibrary.WriteExcel.HorizontalAlignments.Centered;
                Head.Font.FontName = "宋体";//字体  

                Head.PatternColor = AppLibrary.WriteExcel.Colors.Default16;
                //Head.TextDirection = AppLibrary.WriteExcel.TextDirections.Default;//文本位置  
                Head.Font.Bold = true;//加粗  
                Head.Pattern = 1;
                Head.Font.Height = 230;
               
                //边框线的样式
                Head.DiagonalLineStyle = new AppLibrary.WriteExcel.LineStyle();
                Head.BottomLineStyle = 1;
                Head.LeftLineStyle = 1;
                Head.TopLineStyle = 1;
                Head.RightLineStyle = 1;
                Head.RightLineColor = AppLibrary.WriteExcel.Colors.Grey;
                Head.LeftLineColor = AppLibrary.WriteExcel.Colors.Grey;
                Head.TopLineColor = AppLibrary.WriteExcel.Colors.Grey;
                Head.BottomLineColor = AppLibrary.WriteExcel.Colors.Grey;
                AppLibrary.WriteExcel.XF XFstyle = doc.NewXF();//添加样式的  

                //XFstyle.TextDirection = AppLibrary.WriteExcel.TextDirections.Left;//文本位置  
                XFstyle.Font.Bold = false;//加粗  
                //边框线的样式
                XFstyle.DiagonalLineStyle = new AppLibrary.WriteExcel.LineStyle();
            
                    for (int cols = 0; cols < ds.Tables[i].Columns.Count; cols++) 
                    {
                        cells.Add(1, cols + 1, ds.Tables[i].Columns[cols].ToString(), center);
                    }
                //第一行表头
                //第一行显示表的列名
                //标题占四行

                for (int rows = 0; rows < ds.Tables[i].Rows.Count; rows++)
                {
                    for (int cols = 0; cols < ds.Tables[i].Columns.Count; cols++)//因为表一有一列城市是不需要的  所以采用这种写法
                    {
                        cells.Add(rows + 2, cols + 1, ds.Tables[i].Rows[rows][cols].ToString());
                    }
                }
            }
            GC.Collect();
            doc.Send();

        }
        /// <summary>
        ///  将Datatable写入到Excel文件中
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fname"></param>
        /// <returns></returns>

        public static void ExportDataTableToExcel(DataTable dt, string FileName)
        {
        
            var sbHtml = new StringBuilder();
            sbHtml.Append("<style>td{mso-number-format:\"\\@\";}</style>");
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            sbHtml.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", dt.Columns[i].ColumnName);
            }

            sbHtml.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbHtml.Append("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", dt.Rows[i][j].ToString());
                }
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("</table>");
            HttpResponse Response;
            Response = we.HttpContext.Current.Response;
            Response.Charset = "UTF-8";
            Response.HeaderEncoding = Encoding.UTF8;
            Response.AppendHeader("content-disposition", "attachment;filename=" + FileName);
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/ms-excel";
            Response.Write("<meta http-equiv='content-type' content='application/ms-excel; charset=UTF-8'/>" + sbHtml.ToString());
            Response.Flush();
            Response.End();
             
        }
         
    }
}