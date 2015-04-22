using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Starbucks.Models
{
	public class Payment
	{
		public string cardNo;
		public decimal amount;


		public Payment(
			string cardNo, 
			decimal amount)
		{
			this.cardNo = cardNo;
			this.amount = amount;
		}
	}
}
