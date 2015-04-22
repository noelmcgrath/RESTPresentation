using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Starbucks.Models;


namespace Starbucks.Controllers
{
	public class PaymentController : ApiController
	{
		private Starbucks.Controllers.Repository c_repository;


		public PaymentController()
		{
			this.c_repository = new Starbucks.Controllers.Repository();
		}

		// GET api/payment/5
		public HttpResponseMessage Get(
			int id)
		{
			return base.Request.CreateResponse<Starbucks.Models.Payment>(
				HttpStatusCode.OK,
				new Payment("444", 4.80M));
		}


		// PUT api/payment/5
		public HttpResponseMessage Put(
			int id,
			Starbucks.Models.Payment payment)
		{
			if (payment.amount == 4.81M)
			{
				var _response = Request.CreateResponse<Starbucks.Models.Payment>(HttpStatusCode.InternalServerError, payment);
				return _response;
			}
			else
			{
				var _response = Request.CreateResponse<Starbucks.Models.Payment>(HttpStatusCode.OK, payment);
				var _uri = Url.Link("DefaultApi", new { id = id });
				_response.Headers.Location = new Uri(_uri);

				return _response;
			}
		}

		
	}
}
