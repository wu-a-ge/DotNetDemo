using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace vs2010.consoleApp.demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> lists = new List<int>(){1077660,1076172,6249743,8783673,4084155,554119,6409052,6407771,334237,4026334,329962,4028056,640759,4534095,2160074,6040348,5074735,6034419,5890656,3056295,1052614};
            //foreach (var i in lists)
            //{
            //    String path = @"D:\data\" + i + "-r-00000";
            //    writeFile(path, i + ".txt");
            //    //  ExportAccess.Export(path, i);
            //}
         
            //Console.WriteLine(Des.ToDESEncrypt("加密测试", "vip-cqu123456"));
            WebServiceTest.TestLocalhost();

        }

        private static void writeFile(String originaPath,String fileName)
        {
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(originaPath, FileMode.Open)));
            StreamWriter writer = new StreamWriter(fileName);
            String line = reader.ReadLine();
            while (line != null)
            {
                JObject obj = JObject.Parse(line);
                StringBuilder builder=new StringBuilder();
                foreach (var prop in obj)
                {
                    builder.Append(prop.Value);
                    builder.Append("    ");
                }
                writer.WriteLine(builder);
                line = reader.ReadLine();
            }
            reader.Close();
            
        }
    }
}
