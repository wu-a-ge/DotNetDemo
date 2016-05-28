using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using ADOX;
using System.IO;
namespace vs2010.consoleApp.demo
{

    class ExportAccess
    {
        private static String Table_name = "export.mdb";
        static String JetProvider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};";
        static Dictionary<String, ISet<String>> typeFields = new Dictionary<string, ISet<string>>();
        static Dictionary<String, ISet<String>> typeSqlParams = new Dictionary<string, ISet<String>>();
        static Dictionary<String, String> typeInsertSql = new Dictionary<string, string>();
        static int threshold = 100000;
        private static void InitFields()
        {
            ISet<String> qkFields = new HashSet<String>();
            qkFields.UnionWith("lngid,titletype,mediaid,media_c,media_e,years,vol,num,volumn,specialnum,subjectnum,gch,title_c,title_e,keyword_c,keyword_e,remark_c,remark_e,class,beginpage,endpage,jumppage,pagecount,showwriter,showorgan,imburse,author_e,medias_qk,refercount,referids,intpdf,isqwkz,intgby,isinclude,range,fstorgan,fstwriter,muinfo,language,issn,type".Split(','));

            typeFields.Add("1", qkFields);


        }

        public static void Export()
        {
            InitFields();
           
            int fileCounts = 1;
            //mdb
            String connectionString = String.Format(JetProvider, fileCounts + "_" + Table_name);
            InitMdb(connectionString);
            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();
            //read file
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(@"d:\data", FileMode.Open)));
            String line = reader.ReadLine();
            int counts = 1;
            while (line != null)
            {
                String[] fieldValues = line.Split(',');
                String type = fieldValues[fieldValues.Length - 1];
                ACEParameterHelper parameterHelper = new ACEParameterHelper();
                int i=0;
                foreach (String paramField in typeSqlParams[type])
                {
                    parameterHelper.AddParameter<String>(paramField, fieldValues[i]);
                    i++;
                }
                AccessHelper.ExecuteNonQuery(conn,typeInsertSql[type], parameterHelper.GetParameters());
                if (counts >= threshold)
                {
                   
                    fileCounts++;
                    conn.Close();
                    connectionString = String.Format(JetProvider, fileCounts + "_" + Table_name);
                    InitMdb(connectionString);
                    conn = new OleDbConnection(connectionString);
                    conn.Open();
                    counts = 0;
                }
                counts++;
                 line = reader.ReadLine();
            }
            if (conn != null)
                conn.Close();
        }

        public static void InitMdb(String connectionString)
        {
            CreateMdb(connectionString);
            CreateTable(connectionString);

        }
        public static void CreateMdb(String connectionString)
        {


            ADOX.CatalogClass cat = new ADOX.CatalogClass();
            cat.Create(connectionString);
            cat = null;


        }
        public static void CreateTable(String connectionString)
        {
            foreach (KeyValuePair<string, ISet<string>> pair in typeFields)
            {
                StringBuilder builder = new StringBuilder(100);
                StringBuilder insertSqlBuilder=new StringBuilder(100);
                String insertSql = "insert into table_" + pair.Key + "({0}) values ({1})";
                ISet<String> paramsFields=new HashSet<string>();
                builder.Append("CREATE TABLE table_" + pair.Key + " ( ");
                int i = 0;
                foreach (String field in pair.Value)
                {
                    paramsFields.Add("@" + field);
                    String tempfield = "["+field+"]";
                    insertSqlBuilder.Append(tempfield);
                    builder.Append(tempfield);
                    builder.Append(" memo");
                    i++;
                    if (i == pair.Value.Count)
                        continue;
                    builder.Append(",");
                    insertSqlBuilder.Append(",");
                }
                builder.Append(" )");
                typeInsertSql.Add(pair.Key, String.Format(insertSql,insertSqlBuilder.ToString(),String.Join(",",paramsFields)));
                typeSqlParams.Add(pair.Key, paramsFields);
                Console.WriteLine(builder);
                Console.WriteLine(typeInsertSql);
                AccessHelper.ExecuteNonQuery(connectionString, builder.ToString());


            }
        }
    }
}
