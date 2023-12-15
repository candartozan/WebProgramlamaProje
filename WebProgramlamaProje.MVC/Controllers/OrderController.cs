using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;
using WebProgramlamaProje.MVC.Infrastructure;
using WebProgramlamaProje.MVC.Models;

namespace WebProgramlamaProje.MVC.Controllers
{
	[CustomAuthenticationFilter]
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			this._orderService = orderService;
		}

		// GET: Order
		public ActionResult Index()
		{
			var orders = _orderService.GetUserOrders((int)Session["UserId"]);
			return View(orders);
		}

		public ActionResult PlaceOrder(int addressId,int cargoCompanyId)
		{
			var cart = SessionCart.GetCart();
			if (cart.CartItems.Count > 0)
			{
				cart.UserId = (int)Session["UserId"];

				var order = new Order { AddressId = addressId, CargoCompanyId = cargoCompanyId, UserId = (int)Session["UserId"], OrderStatusId = 1, Cart = SessionCart.GetCart(), DateOfOrder = DateTime.Now };
				_orderService.Add(order);
				SessionCart.ClearCart();

				return RedirectToAction("Index", "Order");
			}
			return RedirectToAction("Index", "Cart");
		}
	}
}