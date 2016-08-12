using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComposableAPIGenericMethod
{
    class Program
    {
        public static IEnumerable<int> Unique(IEnumerable<int> nums)
        {
            Dictionary<int, int> uniqueVals =
                new Dictionary<int, int>();
            Console.WriteLine("\tEntering Unique");
            foreach (int num in nums)
            {
                Console.WriteLine("\tForearch unique  {0}", num);
                if (!uniqueVals.ContainsKey(num))
                {
                    Console.WriteLine("\tUnique Adding {0}", num);
                    uniqueVals.Add(num, num);
                    yield return num;
                    Console.WriteLine
                       ("\tUnique after yield return");
                }
            }
            Console.WriteLine("\tExiting Unique ");
        }


        public static IEnumerable<int> Square(IEnumerable<int> nums)
        {
            Console.WriteLine("\tEntering Square");
            foreach (int num in nums)
            {
                Console.WriteLine("\tForeach Square {0}", num);
                yield return num * num;
                Console.WriteLine
                       ("\tSquare after yield return");
            }
            Console.WriteLine("\tExiting Square ");
        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 5, 6, 7, 8 };
            foreach (int num in Square(Unique(nums)))
                Console.WriteLine("Number returned from Unique: {0}", num);

            Console.Read();
        }
    }
}
