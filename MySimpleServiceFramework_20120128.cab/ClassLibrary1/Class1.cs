using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ClassLibrary1
{
	// 查询订单的输出参数类型
	public sealed class Order
	{
		public int OrderID { get; set; }
		public int CustomerID { get; set; }
		public string CustomerName { get; set; }
		public DateTime OrderDate { get; set; }
		public double SumMoney { get; set; }
		public string Comment { get; set; }
		public bool Finished { get; set; }
		public List<OrderDetail> Detail { get; set; }
	}

	public sealed class OrderDetail
	{
		public int OrderID { get; set; }
		public int Quantity { get; set; }
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string Unit { get; set; }
		public double UnitPrice { get; set; }
	}

	// 查询订单的输入参数
	public sealed class QueryOrderCondition
	{
		public int? OrderId;
		public int? CustomerId;
		public DateTime StartDate;
		public DateTime EndDate;
	}

	public static class DataFactory
	{
		public static Order CreateRandomOrder()
		{
			Random rand = new Random();

			Order order = new Order {
				OrderID = rand.Next(1000, 10000),
				CustomerID = rand.Next(1, 100),
				CustomerName = "客户名_" + DateTime.Now.ToString(),
				OrderDate = DateTime.Now,
				Comment = Guid.NewGuid().ToString(),
				Finished = false,
				Detail = new List<OrderDetail>()
			};

			order.Detail.Add(new OrderDetail {
				OrderID = order.OrderID,
				Quantity = rand.Next(1, 10),
				ProductID = rand.Next(101, 500),
				ProductName = "商品1" + Guid.NewGuid().ToString("N"),
			});
			order.Detail.Add(new OrderDetail {
				OrderID = order.OrderID,
				Quantity = rand.Next(1, 10),
				ProductID = rand.Next(101, 500),
				ProductName = "商品2" + Guid.NewGuid().ToString("N"),
			});

			return order;
		}


		public static QueryOrderCondition CreateQueryOrderCondition()
		{
			return new QueryOrderCondition {
				CustomerId = 3,
				StartDate = new DateTime(2010, 1, 1),
				EndDate = new DateTime(2011, 12, 1)
			};
		}

	}

}
