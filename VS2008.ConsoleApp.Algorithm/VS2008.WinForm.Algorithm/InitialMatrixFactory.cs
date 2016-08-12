using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using VS2008.ConsoleApp.Algorithm;
namespace VS2008.WinForm.Algorithm
{
    class InitialMatrixFactory
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Algorithm"];
        private static string ClassName = ConfigurationManager.AppSettings["ClassName"];
        public static IInitialMatrix GetInitialClass()
        {
            return (IInitialMatrix)Assembly.Load(AssemblyName).CreateInstance(AssemblyName+"."+ClassName);
        }
    }
}
