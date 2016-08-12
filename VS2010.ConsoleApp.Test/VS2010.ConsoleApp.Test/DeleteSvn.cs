using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace VS2010.ConsoleApp.Test
{
   public class DeleteSvn
    {
       public static void Execute() 
       {
           string path = @"F:\快盘\项目\GIS\zdWebApp\zdWebApp";
           RecursionDelete(path);
       }
       private static void RecursionDelete(string path) 
       {
           var dires = Directory.GetDirectories(path);
           foreach (var item in dires)
           {
               if (item.Substring(item.LastIndexOf("\\") + 1, 4) == ".svn")
               {
                   Directory.Delete(item,true);
               }
               else
               {
                   RecursionDelete(item);

               }
           }
       }
    }
}
