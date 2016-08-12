#define TEST
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Configuration;
using System.IO;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Net;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web;
using System.Reflection;
using VS2008.ConsoleApp.Test.HttpsService;
using System.Text.RegularExpressions;
namespace VS2008.ConsoleApp.Test
{

     
 
    public abstract class A

　　{

　　public A()

　　{

　　Console.WriteLine('A');

　　}

　　public virtual void Fun()

　　{

　　Console.WriteLine("A.Fun()");

　　}
    }
　　

    public class B : A
    {

        public B()
        {

            Console.WriteLine('B');

        }

        public new void Fun()
        {

            Console.WriteLine("B.Fun()");

        }
    }
　　
    class Program
    {
        /// <summary>
        /// 定义此方法会生成相应的类
        /// </summary>
        /// <returns></returns>
        //public IEnumerator<int> GetEnumerator()
        //{
        //    yield return 3;
        //    yield return 4;
        //}
        /// <summary>
        /// 定义此方法会生成相应的类
        /// </summary>
        /// <returns></returns>
        //private static  IEnumerable<int> Test()
        //{
        //     yield return 1;
        //     yield return 2;

        //}
         
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader( File.Open("author.txt",FileMode.Open));
            while (stream.ReadLine()!=null)
            {
                
            }
              

            Console.Read();
        }
        
        public static string Md5(string str)
        {
            string result = "";
            result = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            return result;
        }

    }
    

  



}
