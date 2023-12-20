using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductService _productService;

		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		// GET: Home
		public ActionResult Index()
		{
			List<Product> model = _productService.GetShowCase();

			return View(model);
		}

		public ActionResult AccessDenied()
		{
			return View();
		}

		public ActionResult About()
		{
			var model = _productService.GetAllProductWithDetails();
			return View(model);
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}