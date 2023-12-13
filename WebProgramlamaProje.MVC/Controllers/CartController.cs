using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.MVC.Models;

namespace WebProgramlamaProje.MVC.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductService _productService;

		public CartController(IProductService productService)
		{
			_productService = productService;
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
	}
}