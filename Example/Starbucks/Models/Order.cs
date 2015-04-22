using System;
using System.Collections.Generic;

namespace Starbucks.Models
{
	public class Order
	{
		public int id;
		public string drink;
		public decimal price;
		public string additions;
		public List<link> links;


		public Order(
			int id,
			string drink,
			decimal price)
		{
			this.id = id;
			this.drink = drink;
			this.price = price;
		}
	}


	public class link
	{
		public string rel;
		public string href;

		public link(
			string rel, 
			string href)
		{
			this.rel = rel;
			this.href = href;
		}
	}
}