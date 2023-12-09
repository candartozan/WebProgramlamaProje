using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Areas.Admin.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		// GET: Admin/Category
		public ActionResult Index()
		{
			var categories = _categoryService.GetAllCategories();
			return View(categories);
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(Category model)
		{
			if (ModelState.IsValid)
			{
				var result = _categoryService.AddOneCategory(model);
				if (result != null)
				{
					TempData["CategoryMessage"] = $"{model.Name}, kategorilere eklendi.";
					return RedirectToAction("Index");
				}
				ModelState.AddModelError("", "Kategori Eklenemedi");
			}
			return View();
		}
	}
}