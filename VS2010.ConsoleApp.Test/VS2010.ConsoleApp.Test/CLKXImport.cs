using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Flh.Core.DBUtility;
namespace VS2010.ConsoleApp.Test
{
     static  class CLKXImport
    {
        public static string ToJson()
        {
            JArray root = new JArray();
            var titleInfoObj = new JObject();
            titleInfoObj.Add("type", "title_info");
            titleInfoObj.Add("data",new JArray(GetClkxIds()));
            root.Add(titleInfoObj);
            var t1 = new JObject();
            t1.Add("type","writer_info");
            t1.Add("data",new JArray( "*:*"));
            root.Add(t1);
             t1 = new JObject();
            t1.Add("type", "organ_info");
            t1.Add("data", new JArray("*:*"));
            root.Add(t1);
             t1 = new JObject();
            t1.Add("type", "fund_info");
            t1.Add("data", new JArray("*:*"));
            root.Add(t1);
             t1 = new JObject();
            t1.Add("type", "media_info");
            t1.Add("data", new JArray("*:*"));
            root.Add(t1);
             t1 = new JObject();
            t1.Add("type", "subject_info");
            t1.Add("data", new JArray("*:*"));
            root.Add(t1);
             t1 = new JObject();
            t1.Add("type", "class_info");
            t1.Add("data", new JArray("*:*"));
            root.Add(t1);
            return JsonConvert.SerializeObject(root);

        }

         /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
         private static string GetClkxIds()
         {
             var lists = new List<string>();
             lists.Add("classids_s:563 AND years:[2000TO2014]");
             return string.Join(",", lists);
         }
    }
}
