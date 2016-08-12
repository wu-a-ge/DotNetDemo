using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace VS2010.ConsoleApp.Test
{
    //[DataContract]
    public class User
    {
        /// <summary>
        /// 编号
        /// </summary>
        //[DataMember]
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        //[DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        //[DataMember]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        //[DataMember]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 相关URL
        /// </summary>
        //[DataMember]
        public List<string> Urls { get; set; }
        /// <summary>
        /// 薪水
        /// </summary>
        //[ScriptIgnore]//使用JavaScriptSerializer序列化时不序列化此字段
        //[IgnoreDataMember]//使用DataContractJsonSerializer序列化时不序列化此字段
        //[JsonIgnore]//使用JsonConvert序列化时不序列化此字段
        public int Salary { get; set; }
        /// <summary>
        /// 权利级别
        /// </summary>
        //[DataMember]
        public Priority Priority { get; set; }

        public User()
        {
            Urls = new List<string>();
        }
    }
    /// <summary>
    /// 权利级别
    /// </summary>
    public enum Priority : byte
    {
        Lowest = 0x1,
        BelowNormal = 0x2,
        Normal = 0x4,
        AboveNormal = 0x8,
        Highest = 0x16
    }
    public sealed class JsonParameter
    {
        public string Fid;
        public string Sid;
        public string FName;
        public string SName;
        [NonSerialized]
        public int StartYear;
        [NonSerialized]
        public int EndYear;
        [NonSerialized]
        public bool YearChange;
    }

    class JsonTest
    {
        /// <summary>
        /// 性能优势太低，还有个问题，必须指明要进行序列化和反序列化的类类型，也即
        /// 序列化和反序列化是一对的，不能单独使用一个功能！
        /// </summary>
        public static void DataContractJsonSerializer()
        {
            User user = new User { UserId = 1, UserName = "李刚", CreateDate = DateTime.Now.AddYears(-30), Birthday = DateTime.Now.AddYears(-50), Priority = Priority.AboveNormal, Salary = 50000 };
            string result = string.Empty;
            //DataContractJsonSerializer类在System.ServiceModel.Web.dll中，注意添加这个引用
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(User));

            using (MemoryStream stream = new MemoryStream())
            {
                //JSON序列化
                serializer.WriteObject(stream, user);
                result = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine("使用DataContractJsonSerializer序列化后的结果：{0},长度：{1}", result, result.Length);
            }
            result = "{\"costTime\":0,\"factes\":[],\"objectName\":\"\",\"page\":0,\"pageSize\":0,\"results\":[],\"tokens\":\"\",\"totalNum\":0}";
            //JSON反序列化
            byte[] buffer = Encoding.UTF8.GetBytes(result);
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                //换成动态类型
                dynamic user1 = serializer.ReadObject(stream);
                Console.WriteLine("使用DataContractJsonSerializer反序列化后的结果：UserId:{0},UserName:{1},CreateDate:{2},Priority:{3}", user1.UserId, user1.UserName, user1.CreateDate, user1.Priority);
            }
        }
        /// <summary>
        /// 此序列化性能比较好
        /// </summary>
        public static void JavaScriptSerializer()
        {
            List<User> lists = new List<User>();
            User user = new User { UserId = 1, UserName = "李刚", CreateDate = DateTime.Now.AddYears(-30), Birthday = DateTime.Now.AddYears(-50), Priority = Priority.Highest, Salary = 500000 };
            lists.Add(user);
            lists.Add(user);
            //JavaScriptSerializer类在System.Web.Extensions.dll中，注意添加这个引用
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //JSON序列化
            string result = serializer.Serialize(lists);
            Console.WriteLine("使用JavaScriptSerializer序列化后的结果：{0},长度：{1}", result, result.Length);
            //JSON反序列化
            //user = serializer.Deserialize<User>(result);
            //此方法将对象反序列化为字典集合，数组反序列化为数组(类型是ArrayList)
            dynamic user1 = serializer.DeserializeObject(result);
            foreach (KeyValuePair<string, object> k in user1)
            {
                Console.WriteLine(k.Key + ":" + k.Value);
            }
            Console.WriteLine(user1["UserId"]);
            //Console.WriteLine("使用JavaScriptSerializer反序列化后的结果：UserId:{0},UserName:{1},CreateDate:{2},Priority:{3}", user.UserId, user.UserName, user.CreateDate, user.Priority);

        }
        /// <summary>
        ///此序列化可以考虑，性能最好，功能多
        /// </summary>
        public static void JsonConvertDemo()
        {
            List<User> lists = new List<User>();
           
            var user = new  JsonParameter { Fid = "24244",  Sid = "23242",FName="中文文献",SName="英文文献" };
            //lists.Add(user);
            //lists.Add(user);
            //JsonConvert类在Newtonsoft.Json.Net35.dll中，注意到http://www.codeplex.com/json/下载这个dll并添加这个引用
            //JSON序列化
            string result = JObject.FromObject(user).ToString();
            Console.WriteLine("使用JsonConvert序列化后的结果：{0},长度：{1}", result, result.Length);
            //JSON反序列化
            //数组反序列化为一个数组，但是这个数组很特别
            User user1 = JObject.Parse(result).ToObject<User>();
            //Console.WriteLine("使用JsonConvert反序列化后的结果：UserId:{0},UserName:{1},CreateDate:{2},Priority:{3}", user.UserId, user.UserName, user.CreateDate, user.Priority);

        }
        public static void JsonConvertLinqDemo()
        {
            User user = new User { UserId = 1, UserName = "周公", CreateDate = DateTime.Now.AddYears(-8), Birthday = DateTime.Now.AddYears(-32), Priority = Priority.Lowest, Salary = 500, Urls = new List<string> { "http://zhoufoxcn.blog.51cto.com", "http://blog.csdn.net/zhoufoxcn" } };
            //JsonConvert类在Newtonsoft.Json.Net35.dll中，注意到http://www.codeplex.com/json/下载这个dll并添加这个引用
            //JSON序列化
            string result = JsonConvert.SerializeObject(user);
            Console.WriteLine("使用JsonConvert序列化后的结果：{0},长度：{1}", result, result.Length);
            //使用Linq to JSON
            JObject jobject = JObject.Parse(result);
            JToken token = jobject["Urls"];
            List<string> urlList = new List<string>();
            foreach (JToken t in token)
            {
                urlList.Add(t.ToString());
            }
            Console.Write("使用Linq to JSON反序列化后的结果：[");
            for (int i = 0; i < urlList.Count - 1; i++)
            {
                Console.Write(urlList[i] + ",");
            }
            Console.WriteLine(urlList[urlList.Count - 1] + "]");
        }



    }
}
