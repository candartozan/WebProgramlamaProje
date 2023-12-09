using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;

namespace WebProgramlamaProje.MVC.Areas.Admin.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		// GET: Admin/Product
		public ActionResult Index()
		{
			var products = _productService.GetAllProductWithDetails();
			return View(products);
		}
	}
}