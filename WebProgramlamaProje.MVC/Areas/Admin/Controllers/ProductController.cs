using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.MVC.Areas.Admin.Models;

namespace WebProgramlamaProje.MVC.Areas.Admin.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IBrandService _brandService;

		public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_brandService = brandService;
		}

		// GET: Admin/Product
		public ActionResult Index()
		{
			var products = _productService.GetAllProductWithDetails();
			return View(products);
		}

		[HttpGet]
		public ActionResult Add()
		{
			var model = new ProductInsertionViewModel();
			model.BrandSelectList = GetBrandSelectlist();
			model.CategorySelectList = GetCategorySelectlist();

			return View(model);
		}

		[HttpPost]
		public ActionResult Add(ProductInsertionViewModel model)
		{
			if (ModelState.IsValid)
			{
				model.Product.DateOfAddition = DateTime.Now;

				_productService.AddOneProduct(model.Product);
				return RedirectToAction("Index");
			}

			model.BrandSelectList = GetBrandSelectlist();
			model.CategorySelectList = GetCategorySelectlist();
			return View(model);
		}

		public ActionResult Remove(int id)
		{
			_productService.RemoveOneProduct(id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			var model = new ProductInsertionViewModel();
			model.Product = _productService.GetProductWithDetailsById(id);
			model.BrandSelectList = GetBrandSelectlist();
			model.CategorySelectList = GetCategorySelectlist();

			return View(model);
		}

		[HttpPost]
		public ActionResult Update(ProductInsertionViewModel model)
		{
			if (ModelState.IsValid)
			{
				_productService.UpdateOneProduct(model.Product);
				return RedirectToAction("Index");
			}

			model.BrandSelectList = GetBrandSelectlist();
			model.CategorySelectList = GetCategorySelectlist();
			return View(model);
		}

		private List<SelectListItem> GetBrandSelectlist()
		{
			var brands = _brandService.GetAllBrands();
			var list = new List<SelectListItem>();

			foreach (var b in brands)
			{
				list.Add(new SelectListItem { Text = b.Name, Value = b.Id.ToString() });
			}

			return list;
		}

		private List<SelectListItem> GetCategorySelectlist()
		{
			var categories = _categoryService.GetAllCategories();
			var list = new List<SelectListItem>();

			foreach (var c in categories)
			{
				list.Add(new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
			}

			return list;
		}

	}
}