using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Areas.Admin.Controllers
{
	public class BrandController : Controller
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		// GET: Admin/Brand
		public ActionResult Index()
		{
			var brands = _brandService.GetAllBrands();
			return View(brands);
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(Brand model)
		{
			if (ModelState.IsValid)
			{
				_brandService.AddOneBrand(model);
				return RedirectToAction("Index");
			}
			return View();
		}

		public ActionResult Remove(int id)
		{
			_brandService.RemoveOneBrand(id);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			var model = _brandService.GetBrandById(id);
			return View(model);
		}

		[HttpPost]
		public ActionResult Update(Brand model)
		{
			if (ModelState.IsValid)
			{
				_brandService.UpdateOneBrand(model);

				return RedirectToAction("Index");
			}
			return View();
		}
	}
}