using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Starbucks.Models;

namespace Starbucks.Controllers
{
	public class Repository
	{
		public Order SaveOrder()
		{
			var _link = new Starbucks.Models.link("http://localhost:7000/api/payment", "http://localhost:7000/api/payment/order/123");
			var _links = new List<Starbucks.Models.link> { _link };

			var _order = new Starbucks.Models.Order(123, "coffee", 4.50M);
			_order.id = 123;
			_order.links = _links;

			var json = JsonConvert.SerializeObject(_order);
			File.WriteAllText(@"D:\temp\order.txt", json);

			return _order;
		}


		public Order GetOrder()
		{
			var json = File.ReadAllText(@"D:\temp\order.txt");
			return JsonConvert.DeserializeObject<Order>(json); ;
		}


		public void UpdateOrder(
			Order order)
		{
			var json = JsonConvert.SerializeObject(order);
			File.WriteAllText(@"D:\temp\order.txt", json);
		}
	}
}