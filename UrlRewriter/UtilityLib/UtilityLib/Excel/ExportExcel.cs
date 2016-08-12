using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Web;
using Microsoft.Win32;
namespace UtilityLib.Excel
{
    public sealed class ExportExcel
    {
        private const string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;";
        private ExportExcel() { }
        /// <summary>
        /// 创建表时如果文件不存在就会创建文件
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="excelPath">指定一个文件路径，但文件可以不存在</param>
        /// <returns></returns>
        public static void DataTableToExcel(DataTable dt, string excelPath)
        {
            if (dt == null)
            {
                throw new ArgumentException("数据表不能为空","dt");
            }

            int rows = dt.Rows.Count;
            int cols = dt.Columns.Count;
            StringBuilder sb;
            string connString;

            if (rows == 0)
            {
                 throw new ArgumentException("数据表没有数据","dt");
            }

            sb = new StringBuilder();
            connString = string.Format(ConnectionString, excelPath);
            //生成创建表的脚本,创建表时就会创建文件
              sb.Append("CREATE TABLE ");
              sb.Append(dt.TableName + " ( ");
  
              for (int i = 0; i < cols; i++)
              {
                  if (i < cols - 1)
                      sb.AppendFormat("{0} varchar,",string.IsNullOrEmpty(dt.Columns[i].Caption)?dt.Columns[i].ColumnName:dt.Columns[i].Caption);
                  else
                      sb.AppendFormat("{0} varchar)", string.IsNullOrEmpty(dt.Columns[i].Caption)?dt.Columns[i].ColumnName:dt.Columns[i].Caption);
              }
              using (OleDbConnection conn = new OleDbConnection(connString))
              {
                  OleDbCommand cmd = new OleDbCommand();
                  cmd.Connection = conn;
                  cmd.CommandText = sb.ToString();
                  try
                  {
                      conn.Open();
                      cmd.ExecuteNonQuery();
                     
                  }
                  catch (Exception e)
                  {
                      throw new Exception("创建表失败",e);
                  }
                  #region 生成插入数据脚本
                  sb.Remove(0, sb.Length);
                  sb.Append("INSERT INTO ");
                  sb.Append(dt.TableName + " ( ");
                  //添加列名
                  for (int i = 0; i < cols; i++)
                  {
                      if (i < cols - 1)
                          sb.Append(string.IsNullOrEmpty(dt.Columns[i].Caption) ? dt.Columns[i].ColumnName : dt.Columns[i].Caption + ",");
                      else
                          sb.Append(string.IsNullOrEmpty(dt.Columns[i].Caption) ? dt.Columns[i].ColumnName : dt.Columns[i].Caption + ") values (");
                  }
                  //添加参数
                  for (int i = 0; i < cols; i++)
                  {
                      if (i < cols - 1)
                          sb.Append("@" +  dt.Columns[i].ColumnName + ",");
                      else
                          sb.Append("@" +  dt.Columns[i].ColumnName+ ")");
                  }
                  #endregion
                  cmd.CommandText = sb.ToString();
                  OleDbParameterCollection paramCols =cmd.Parameters;
                  for (int i = 0; i < cols; i++)
                  {
                      paramCols.Add(new OleDbParameter("@" + dt.Columns[i].ColumnName, OleDbType.VarChar));
                  }
                  //遍历DataTable将数据插入新建的Excel文件中
                  foreach (DataRow row in dt.Rows)
                  {
                      for (int i = 0; i < paramCols.Count; i++)
                      {
                          paramCols[i].Value = row[i];
                      }
                      cmd.ExecuteNonQuery();
                  }
                  cmd.Dispose();
                
              } 
        }
        /// <summary>
        /// 把Grid中的数据导入到Excel
        /// </summary>
        /// <param name="FResponse">System.Web.HttpResponse</param>
        /// <param name="FileName">文件名称要有扩展名.xls</param>
        /// <param name="gridView">数据源GridView</param>
        public static void GridViewToExcelDownLoad(System.Web.HttpResponse FResponse, string FileName, System.Web.UI.WebControls.GridView gridView,params string[] charset)
        {
            string  charType=(charset.Length==0?"gb2312":charset[0]);
            FResponse.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.GetEncoding("GB2312")).Replace("+", " "));
            FResponse.Charset = charType;
            FResponse.ContentEncoding = System.Text.Encoding.GetEncoding(charType); //"GB2312");//解决中文乱码的关键
            FResponse.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            gridView.RenderControl(hw);
            FResponse.Write(tw.ToString());
            FResponse.End();
        }



    }
}
