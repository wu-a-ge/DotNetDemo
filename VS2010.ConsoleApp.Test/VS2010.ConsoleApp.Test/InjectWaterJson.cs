using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace VS2010.ConsoleApp.Test
{
    class InjectWaterJson
    {
        public static String Test()
        {
            JObject obj = new JObject();
            obj.Add("guid",Guid.NewGuid().ToString());
            obj.Add("user_id", 24324);
            obj.Add("site_Id", 3);
            obj.Add("site_type", 0);
            obj.Add("inject_position", 1);
            obj.Add("classes", "ZZ");
            obj.Add("threshold", 1000);
            obj.Add("begin_date", "2014-08-01");
            obj.Add("end_date", "2014-08-31");
            obj.Add("continue_inject", false);
            obj.Add("ratio", 2.2);
            obj.Add("inject_type", 0);
            JArray date_table =new JArray();
            JObject month = new JObject();
            JArray datas=new JArray();
            month.Add("modify_month",String.Format("{0:yyyy-MM}",DateTime.Now));
            int day = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            for (int i = 1; i <= day; i++)
            {
                DateTime date =  new DateTime(DateTime.Now.Year,DateTime.Now.Month,i);
                JObject model = new JObject();
                model.Add("modify_date",String.Format("{0:yyyy-MM-dd}",date));
                model.Add("modfiy_value", 1000);
                datas.Add(model);
            }
            month.Add("datas", datas);
            date_table.Add(month);
            obj.Add("date_table", date_table);
            return JsonConvert.SerializeObject(obj);
        }

      
    }
}
