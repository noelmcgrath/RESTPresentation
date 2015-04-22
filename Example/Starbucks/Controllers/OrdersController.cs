using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Starbucks.Controllers
{
	public class OrdersController : ApiController
	{
		private Starbucks.Controllers.Repository c_repository = new Starbucks.Controllers.Repository();


		// GET api/orders/5
		public HttpResponseMessage Get(
			int id)
		{
			return base.Request.CreateResponse<Starbucks.Models.Order>(
				HttpStatusCode.OK,
				this.c_repository.GetOrder());
		}


		// POST api/orders
		public HttpResponseMessage Post(
			Starbucks.Models.Order order)
		{
			var _order = this.c_repository.SaveOrder();
			var _response = Request.CreateResponse<Starbucks.Models.Order>(HttpStatusCode.Created, _order);
			var _uri = Url.Link("DefaultApi", new { id = _order.id });
			_response.Headers.Location = new Uri(_uri);

			return _response;
		}


		// PUT api/orders/5
		public HttpResponseMessage Put(
			int id,
			Starbucks.Models.Order order)
		{
			var _order = this.c_repository.GetOrder();
			if (order.additions == "invalid")
			{
				var _response = Request.CreateResponse<Starbucks.Models.Order>(HttpStatusCode.Conflict, _order);
				var _uri = Url.Link("DefaultApi", new { id = _order.id });
				_response.Headers.Location = new Uri(_uri);

				return _response;
			}
			else
			{
				_order.additions = order.additions;
				_order.price = 4.80M;
				this.c_repository.UpdateOrder(_order);

				var _updatedOrder = this.c_repository.GetOrder();
				var _response = Request.CreateResponse<Starbucks.Models.Order>(HttpStatusCode.OK, _updatedOrder);
				var _uri = Url.Link("DefaultApi", new { id = _order.id });
				_response.Headers.Location = new Uri(_uri);

				return _response;
			}
		}


		// DELETE api/orders/5
		public void Delete(int id)
		{
		}
	}
}
