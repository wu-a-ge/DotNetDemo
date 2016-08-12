using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using MySimpleServiceFramework;


namespace ServiceLibrary
{
	[MyService]
	public class OrderService
	{
		[MyServiceMethod]
		public static string Hello(string name)
		{
			return "Hello " + name;
		}

		[MyServiceMethod]
		public List<Order> QueryOrder(QueryOrderCondition query)
		{
			// 模拟查询过程，这里就直接返回一个列表。		
			List<Order> list = new List<Order>();
			for( int i = 0; i < 10; i++ )
				list.Add(DataFactory.CreateRandomOrder());

			return list;
		}

		public string HiddenMethod(string aa)
		{
			// 这个方法应该是不能以服务方式被调用到的。
			throw new NotImplementedException();
		}
	}
}