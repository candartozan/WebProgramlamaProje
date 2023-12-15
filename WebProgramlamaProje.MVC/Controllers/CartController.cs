using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;
using WebProgramlamaProje.MVC.Models;

namespace WebProgramlamaProje.MVC.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IAddressService _addressService;

		public CartController(IProductService productService, IOrderService orderService, IAddressService addressService)
		{
			_productService = productService;
			_orderService = orderService;
			_addressService = addressService;
		}

		// GET: Cart
		public ActionResult Index()
		{
			var model = SessionCart.GetCart();

			return View(model);
		}

		public ActionResult AddCart(int id)
		{
			var product = _productService.GetProductWithDetailsById(id);
			SessionCart.AddProductToCart(product);
			return RedirectToAction("Index", "Cart");
		}

		public ActionResult RemoveFromCart(int id)
		{
			SessionCart.RemoveProductFromCart(id);

			return RedirectToAction("Index", "Cart");
		}

		[HttpGet]
		public ActionResult SelectOrderDetails()
		{
			var cart = SessionCart.GetCart();
			if (cart.CartItems.Count > 0)
			{
				var model = new OrderSelect();
				model.Addresses = Address();
				model.CargoC = CargoC();
				return View(model);
			}
			return RedirectToAction("Index", "Cart");
		}

		[HttpPost]
		public ActionResult SelectOrderDetails(OrderSelect model)
		{
			return RedirectToAction("PlaceOrder", "Order", new { addressId = model.AdresId, cargoCompanyId = model.CargoId });
		}

		private List<SelectListItem> Address()
		{
			var list = new List<SelectListItem>();
			var addresses = _addressService.GetAddressesByUserId((int)Session["UserId"]);
			foreach (var address in addresses)
			{
				list.Add(new SelectListItem { Text = address.Title, Value = address.Id.ToString() });
			}

			return list;
		}

		private List<SelectListItem> CargoC()
		{
			var list = new List<SelectListItem>();
			var cargos = _orderService.GetCargoCompanies();
			foreach (var c in cargos)
			{
				list.Add(new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
			}

			return list;
		}
	}
}