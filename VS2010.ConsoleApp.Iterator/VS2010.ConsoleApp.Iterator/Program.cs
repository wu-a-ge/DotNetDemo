using System;
using System.Collections.Generic;
using System.Collections;
using Ch11Ex03;

namespace VS2010.ConsoleApp.Iterator
{
    class Program
    {
        private static IEnumerable IteratorMethod()
        {
            yield return "1";
            yield return 2;
            yield return true;
            yield return 4;
        }
        private static IEnumerable<int> IteratorMethodGeneric()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }

        private static IEnumerator IteratorManual()
        {
            yield return "5";
            yield return 2;

        }

        private IEnumerator IteratorCollection()
        {
            var list = new List<int> { 2, 3, 4 };
            return list.GetEnumerator();
        }

        static void Main(string[] args)
        {
            //foreach (var s in IteratorMethod())
            //{
            //    Console.WriteLine(s);
            //}
            //foreach (var s in IteratorMethodGeneric())
            //{
            //    Console.WriteLine(s);
            //}
            var ienumerator = IteratorManual();
            while (ienumerator.MoveNext())
            {
                Console.WriteLine(ienumerator.Current);
            }
            Console.Read();
        }
        //static void Main(string[] args)
        //{
        //    Primes primesFrom2To1000 = new Primes(2, 1000);
        //    foreach (long i in primesFrom2To1000)
        //        Console.Write("{0} ", i);

        //    Console.ReadKey();
        //}
    }
}
