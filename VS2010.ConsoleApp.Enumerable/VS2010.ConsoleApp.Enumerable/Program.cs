using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.Enumerable
{
    /// <summary>
    /// 使用的迭代器模式，它会先生成一个具体迭代器类来迭代聚集对象(数据或集合)
    /// 聚集对象被包含在具体迭代器内部
    /// </summary>
    class Program:IEnumerable<int>
    {
        private List<int> lists = new List<int>() { 1,2,3};
        /// <summary>
        /// 这个方法返回类型会造成生成一个实现IEnumerable,IEnumerator其及泛型接口的具体迭代器类
        /// 然后在这个方法内部返回一个具体迭代器对象
        /// 它这里要实现IEnumerable及其泛型接口,是因为方法返回的是IEnumerable！而在外部迭代此方法需要先返回一个IEnumerable，再通过IEnumerable的GetEnumerator方法返回的IEnumerator接口迭代。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetTest()
        {
            foreach (var item in lists)
            {
                yield return item;
            }
        }
      
        /// <summary>
        /// 这个方法会生成一个实现IEnumerator其及泛型接口的具体迭代器类
        ///在这个方法内部返回一个具体的迭代器对象！！所以在这个方法内部可以写任意复杂的代码
        ///这些代码最终会被生成一个类
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in lists)
            {
                yield return item;   
            }

        }
        static void Main(string[] args)
        {
            var tt = new Program();
            foreach (var item in tt)
            {
                Console.WriteLine(item);
            }
            foreach (var item1 in tt.GetTest())
            {
                Console.WriteLine(item1);
            }

        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
          return  this.GetEnumerator();
        }
    }
}
