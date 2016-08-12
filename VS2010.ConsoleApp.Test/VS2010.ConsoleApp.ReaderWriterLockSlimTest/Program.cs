using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace VS2010.ConsoleApp.ReaderWriterLockSlimTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> dic=new Dictionary<int, string>();
            ReaderWriterLockSlim cacheLock=new ReaderWriterLockSlim();
            cacheLock.EnterReadLock();
            try
            {
                if (dic.ContainsKey(1))
                {
                    Console.WriteLine(dic[1]);
                }
                else
                {
                    cacheLock.EnterUpgradeableReadLock();
                    try
                    {

                    }
                    finally
                    {
                        cacheLock.EnterUpgradeableReadLock();
                    }
                }
            }
            finally 
            {
               
               cacheLock.ExitReadLock();
            }
           
            
        }

        private static void TT(object obj)
        {

        }
    }
}
