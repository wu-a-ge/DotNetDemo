using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace VS2010.ConsoleApp.Test
{
    class ImportIp
    {
        public static void Import()
        {
            var readFile =new StreamReader(File.Open("qqwry.txt",FileMode.Open,FileAccess.Read),Encoding.Default);
            var writeFile =new StreamWriter(File.Create("importip.txt"));
            String line = readFile.ReadLine();
            var reg = new Regex(@"\s+");
            while (line != null)
            {
            
                var columns = reg.Split(line);
                writeFile.WriteLine(string.Join(",",columns));
                line = readFile.ReadLine();
            }
            readFile.Close();
            writeFile.Close();
        }
    }
}
