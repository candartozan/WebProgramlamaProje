using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;
using WebProgramlamaProje.MVC.Infrastructure;

namespace WebProgramlamaProje.MVC.Controllers
{
	[CustomAuthenticationFilter]
	public class AddressController : Controller
	{
		private readonly IAddressService _addressService;

		public AddressController(IAddressService addressService)
		{
			_addressService = addressService;
		}

		// GET: Address
		public ActionResult Index()
		{
			var addresses = _addressService.GetAddressesByUserId(Convert.ToInt32(Session["UserId"]));
			return View(addresses);
		}

		[HttpGet]
		public ActionResult Add()
		{
			TempData["District"] = GetDistricts();
			return View();
		}

		[HttpPost]
		public ActionResult Add(Address model)
		{
			if (ModelState.IsValid)
			{
				if (model.DistrictId == 0)
				{
					ModelState.AddModelError("", "İlçe seçin.");
					return View(model);
				}
				model.DateOfCreation = DateTime.Now;
				model.UserId = Convert.ToInt32(Session["UserId"]);

				_addressService.AddAddress(model);

				return RedirectToAction("Index", "Address");
			}

			TempData["District"] = GetDistricts();
			return View(model);
		}

		public ActionResult Remove(int id)
		{
			_addressService.RemoveAddress(id);
			return RedirectToAction("Index", "Address");
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			var model = _addressService.GetAddressesById(id);
			TempData["District"] = GetDistricts();

			return View(model);
		}

		[HttpPost]
		public ActionResult Update(Address model)
		{
			if (ModelState.IsValid)
			{
				if (model.DistrictId == 0)
				{
					ModelState.AddModelError("", "İlçe seçin.");
					return View(model);
				}

				_addressService.UpdateAddress(model);

				return RedirectToAction("Index", "Address");
			}

			TempData["District"] = GetDistricts();
			return View(model);
		}

		private List<SelectListItem> GetDistricts()
		{
			var districts = _addressService.GetDistricts();
			var list = new List<SelectListItem>();

			foreach (var d in districts)
			{
				list.Add(new SelectListItem { Text = d.Name, Value = d.Id.ToString() });
			}

			return list;
		}
	}
}