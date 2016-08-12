using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.Test
{
    static class PbInfo
    {
        public static string ToJson()
        {
            var lists=new List<string>(50);
            var sqlconnection = "server=192.168.30.60;database=TianYuanData;User ID=sa;Password=www.tydata.net";
            //单篇屏蔽
            var ds1=  SqlHelper.ExecuteDataset(sqlconnection, CommandType.Text, "select  KWXZID from KWPBInfo where ZF=2 and ZK=1 and lib=1");
            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                lists.Add(string.Format("NOT lngid:{0}",row[0].ToString().ToLowerInvariant()));
            }
            //通过期刊屏蔽
            var ds2= SqlHelper.ExecuteDataset(sqlconnection, CommandType.Text,
                                    " select KWXZID from KWPBInfo where ZF=1 and ZT=2 and ZK=1 and ZR=0 and lib=1");
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                lists.Add(string.Format("NOT gch:\"{0}\"", row[0].ToString().ToLowerInvariant()));
            }
            //通过时间期段屏蔽
            var ds3=  SqlHelper.ExecuteDataset(sqlconnection, CommandType.Text,
                                    "select KWXZID,ZS,ZE,ZP,ZQ from KWPBInfo where ZF=1 and ZT=3 and ZR=5 and ZK=1 and lib=1");

            //foreach (DataRow row in ds3.Tables[0].Rows)
            //{
            //    lists.Add(string.Format("gch:\"{0}\" AND years:[{1} TO {2}] AND ", row["KWXZID"].ToString().ToLowerInvariant(),row["ZS"],row["ZE"]));
            //}
            var root = new JArray();
            var titleInfo = new JObject();
            titleInfo.Add("type","title_info");
            titleInfo.Add("data",new JArray(lists));
            root.Add(titleInfo);
            return JsonConvert.SerializeObject(root);
            

        }
    }
}
