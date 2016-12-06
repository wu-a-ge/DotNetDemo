using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Dynamic;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json.Linq;
using VS2010.ConsoleApp.Test.Tree;
using VS2010.ConsoleApp.TestLibrary;
using System.Web.Script.Serialization;
using System.Linq;
using System.IO;
 

namespace VS2010.ConsoleApp.Test
{
    class Program
    {
        private class JsonTest
        {
          
        }
 

        static void Main(string[] args)
        {
            new B().test();
            
            /*
            Dictionary<String,String> typeFields=new Dictionary<string, string>();
            typeFields.Add("1", "lngid,titletype,mediaid,media_c,media_e,years,vol,num,volumn,specialnum,subjectnum,gch,title_c,title_e,keyword_c,keyword_e,remark_c,remark_e,class,beginpage,endpage,jumppage,pagecount,showwriter,showorgan,imburse,author_e,medias_qk,refercount,referids,intpdf,isqwkz,intgby,isinclude,range,fstorgan,fstwriter,muinfo,language,issn,type");
            typeFields.Add("2", "lngid,title_c,title_e,bstitlename_pair,showwriter,author_e,bssubjectcode,bsspeciality,bsdegree,showorgan,bstutorsname,years,bsstudydirection,language,class,class,keyword_c,bsmarkskeywords,keyword_e,remark_c,remark_e,bsdigestlanguages,imburse,strreftext,bsdatabsename,pagecount,bsthesissize,bscontributionpeople,bscontributiontime,fulltextaddress,netfulltextaddr,type");
            typeFields.Add("3", "lngid,title_c,title_e,years,hymeetingrecordname,hyenmeetingrecordname,showwriter,author_e,showorgan,media_c,media_e,hymeetingdate,hymeetingplace,num,hyhostorganization,hypressorganization,hypressdate,hypressplace,hysocietyname,hychiefeditor,beginpage,endpage,jumppage,class,keyword_c,keyword_e,remark_c,remark_e,imburse,pagecount,hythesissize,language,strreftext,fulltextpath,netfulltextaddr,type");
            typeFields.Add("4", "lngid,title_c,zlmaintype,years,showwriter,showorgan,zlprovincecode,zlapplicationnum,zlapplicationdata,media_c,zlopendata,zlpriority,zlmainclassnum,zlclassnum,zlinternationalpub,zlinternationalapp,remark_c,keyword_c,zlsovereignty,zlagents,zlagency,zllegalstatus,pagecount,zlthesissize,fulltextaddress,netfulltextaddr,type");
            typeFields.Add("5", "lngid,title_c,title_e,bzmaintype,years,media_c,bznum2,bzpubdate,bzimpdate,bzstatus,bzcountry,bzissued,showorgan,showwriter,bzcommittee,bzapproved,bzlevel,class,keyword_c,keyword_e,bzintclassnum,remark_c,bzpagenum,language,bzrelationship,bzreplacedbz,bzsubsbz,bzrefbz,pagecount,bzthesissize,fulltextaddress,netfulltextaddr,netfulltextaddr,type");
            typeFields.Add("6", "lngid,title_c,cgitemnumber,years,cglimituse,cgprovinces,class,cgcgtypes,keyword_c,remark_c,cgprojectname,cgappunit,cgappdate,cgawards,cgdecunit,cgdecdate,cgrecomunit,cgrecomdate,cgrecomnum,cgrecomcode,cgregunit,media_c,cgregdate,cgplanname,cgplandate,cgprocesstimes,showorgan,showwriter,cgindustry,cginduscode,cgpatents,cgpatentnum,cgpatentsauthno,cgtransnotes,cgtransrange,cgtranscond,cgtranscontent,cgtransmode,cgtranscost,cginvestment,cgbuildtimes,cginvestexplain,cgoutputvalue,cgtaxes,cgforeiexch,cgsavemoney,cgpromoteways,cgpromoterange,cgpromotetrack,cgpromoteexp,cgcontactunit,cgcontactaddr,cgcontacted,cgcontactphone,cgcontactfax,cgzipcode,cgcontactemail,netfulltextaddr,fulltextaddress,type");

            String connString = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False; Data Source=D:\\tmp\\hydx\\hydx.mdb";
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                String sql = "insert into {0} ({1})  values ({2})";
               // string strSql = "insert into hydx(lngid,class,title_c,title_e,years,showwriter,showorgan,media_c,media_e,remark_c,remark_e,keyword_c,keyword_e,gch,vol,num,specialnum,subjectnum,volumn,intpdf) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')";
                /*OleDbParameter[] prams = {
                                             new OleDbParameter("@dh", objCbyEntity.Dh),
                                             new OleDbParameter("@xm", objCbyEntity.Xm)
                                         };#1#
                StreamReader reader = new StreamReader(File.OpenRead("d:\\_user_flh_HYDXDataExport_2316-r-00000"), Encoding.UTF8);
                String line = reader.ReadLine();
                while (line != null)
                {
                    line = line.Replace("'", "''");
                    String[] fields = line.Split('|');
                    try
                    {
                        String type = fields[fields.Length - 1];
                        StringBuilder builder=new StringBuilder(100);
                        int len = typeFields[type].Split(',').Length;
                        for (int i = 0; i <len ; i++)
                        {
                            builder.Append("'");
                            builder.Append(fields[i]);
                            builder.Append("'");
                            if (i == len-1)
                                continue;
                            builder.Append(",");
                        }
                        String insert_sql = String.Format(sql, "table_" + type, typeFields[type], builder);
                        Console.WriteLine(insert_sql);
                       /* OleDbParameter[] values = new OleDbParameter[fields.Length];
                        for (int i = 0; i < fields.Length; i++)
                        {
                            OleDbParameter param = new OleDbParameter();
                            param.ParameterName = "?";
                            param.OleDbType = OleDbType.LongVarWChar;
                            param.Size = 65535;
                            param.Value = fields[i];
                            values[i] = param;
                        }#1#

                        var result = ExecuteNonQuery(conn, insert_sql, null);
                        line = reader.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(line);
                        Console.WriteLine(fields.Length);
                        Console.WriteLine(e);
                        throw e;

                    }
                    
                }

              
            }*/

        }

        public static int ExecuteNonQuery(string connectionString, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        public static int ExecuteNonQuery(OleDbConnection connection, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, connection, null, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //cmd属性赋值
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //是否需要用到事务处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
       
        static void TestDynamic()
        {
            dynamic t1 = Class1.GetData();
            dynamic t2 = Class1.GetData();
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            dynamic t3 = 5;
            t3.ToString();
            t3.ToString();
            t3.ToString();
            t3.ToString();
            t3.ToString();
            t3.ToString();
            dynamic t4 = new ExpandoObject();
            
        }
        static void ConvertJsonGO()
        {
            string json = "{name:'hooyes',pwd:'hooyespwd',books:{a:'红楼梦',b:'水浒传',c:{arr:['宝玉','林黛玉']}},arr:['good','very good']}";

            dynamic dy = ConvertJson(json);

            Console.WriteLine(dy.name);

            Console.WriteLine(dy.books.a);

            Console.WriteLine(dy.arr[1]);

            foreach (var s in dy.books.c.arr)
            {
                Console.WriteLine(s);
            }
        }
        static dynamic ConvertJson(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });
            dynamic dy = jss.Deserialize(json, typeof(object));
            //dynamic dy = jss.DeserializeObject(json);
            return dy;
        }

    
    }


}


