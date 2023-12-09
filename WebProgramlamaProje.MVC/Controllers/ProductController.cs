using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.MVC.Models;

namespace WebProgramlamaProje.MVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly IBrandService _brandService;
		private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_brandService = brandService;
		}

		// GET: Product
		public ActionResult Index()
		{
			var model = new ProductMenuViewModel();
			model.Products = _productService.GetAllProductWithDetails();
			model.Brands = _brandService.GetAllBrands();
			model.Categories = _categoryService.GetAllCategories();
			return View(model);
		}
	}
}