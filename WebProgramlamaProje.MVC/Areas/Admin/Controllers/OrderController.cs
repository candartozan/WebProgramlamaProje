using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Areas.Admin.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		// GET: Admin/Order
		public ActionResult Index()
		{
			var model = _orderService.GetAllOrders();
			return View(model);
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			var model = _orderService.GetOrder(id);
			var statuses = _orderService.GetOrderStatuses();
			var list = new List<SelectListItem>();

			foreach (var s in statuses)
			{
				list.Add(new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
			}
			TempData["Status"] = list;
			return View(model);
		}

		[HttpPost]
		public ActionResult Update(Order model)
		{
			var order = model;
			_orderService.UpdateOrderStatus(model.Id,model.OrderStatusId);
			return RedirectToAction("Index", "Order");
		}
	}
}