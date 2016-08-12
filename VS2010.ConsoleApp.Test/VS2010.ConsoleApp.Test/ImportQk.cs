using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VCube.ServiceProxy;
namespace VS2010.ConsoleApp.Test
{
    public sealed class ImportQk
    {
        private static Dictionary<string,string> dics=new Dictionary<string, string>();

        static ImportQk()
        {
            dics.Add("title_info","mediaid");
            dics.Add("media_info", "mediaid");
            dics.Add("class_info", "mediaids_s");
            dics.Add("subject_info", "mediaids_s");
            dics.Add("organ_info", "mediaids_s");
            dics.Add("writer_info", "mediaids_s");
            dics.Add("fund_info", "mediaids_s");
        }

        public static string ToJson()
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "qikan.xls" + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT qk FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等   

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                JArray root=new JArray();
                
                List<string> list=new List<string>(50);
                foreach (DataRow row in OleDsExcle.Tables[0].Rows)
                {
                    list.Add(row[0].ToString());
                }
                var mediaIds = GetMediaIds( list);
                var titleInfoObj = new JObject();
                titleInfoObj.Add("type", "title_info");
                titleInfoObj.Add("data",GetData("title_info",mediaIds));
                var writerInfo = new JObject();
                writerInfo.Add("type","writer_info");
                writerInfo.Add("data", GetData("writer_info", mediaIds));
                var organInfo = new JObject();
                organInfo.Add("type", "organ_info");
                organInfo.Add("data", GetData("organ_info", mediaIds));
                var fundInfo = new JObject();
                fundInfo.Add("type", "fund_info");
                fundInfo.Add("data", GetData("fund_info", mediaIds));
                var mediaInfo = new JObject();
                mediaInfo.Add("type", "media_info");
                mediaInfo.Add("data", GetData("media_info", mediaIds));
                var subjectInfo = new JObject();
                subjectInfo.Add("type", "subject_info");
                subjectInfo.Add("data", GetData("subject_info", mediaIds));
                var domainInfo = new JObject();
                domainInfo.Add("type", "class_info");
                domainInfo.Add("data", GetData("class_info", mediaIds));
                root.Add(titleInfoObj);
                root.Add(writerInfo);
                root.Add(organInfo);
                root.Add(fundInfo);
                root.Add(mediaInfo);
                root.Add(subjectInfo);
                root.Add(domainInfo);
                return JsonConvert.SerializeObject(root);
            }
            catch (Exception err)
            {

                throw;
            }
            return "";
        }

        private static JArray GetData(string tableName, string mediaIds)
        {
            var mediaid=   mediaIds.Split(',');
            var fieldName = dics[tableName];
            if(tableName.Equals("title_info",StringComparison.Ordinal))
            return new JArray(mediaid.Select(y => string.Format("{0}:{1} AND type:1 AND language:1", fieldName, y)));
            else
                return new JArray(mediaid.Select(y => string.Format("{0}:{1}", fieldName, y)));
        }

        private static string GetMediaIds(List<string> gchs)
        {
            List<string> list = new List<string>(100);

            var length = Math.Ceiling((double) gchs.Count/250);
            for (int i = 0; i < length; i++)
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "media_info.mdb;" + "Persist Security Info=False";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = string.Format("SELECT mediaid FROM media_info where {0}",string.Join(" OR ",gchs.Skip(i*250).Take(250).Select(y=>string.Format("gch='{0}'",y))));
                OleDbDataAdapter da = new OleDbDataAdapter(sql, OleConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                OleConn.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(row[0].ToString().ToLowerInvariant());

                }
            }
           
           return string.Join(",", list);

        }
    }
}
