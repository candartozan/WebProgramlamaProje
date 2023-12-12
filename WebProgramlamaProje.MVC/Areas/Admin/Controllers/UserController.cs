using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Business.Concrete;
using WebProgramlamaProje.DataAccess.Concrete;
using WebProgramlamaProje.MVC.Areas.Admin.Models;
using WebProgramlamaProje.MVC.Infrastructure;

namespace WebProgramlamaProje.MVC.Areas.Admin.Controllers
{
	[CustomAuthenticationFilter]
	[CustomAuthorize("Admin")]
	public class UserController : Controller
	{
		private readonly IUserService _userManager;
		private readonly IRoleService _roleService;

		public UserController(IUserService userManager, IRoleService roleService)
		{
			_userManager = userManager;
			_roleService = roleService;
		}

		// GET: Admin/User
		public ActionResult Index()
		{
			var users = _userManager.GetAllUsersWithDetails();
			return View(users);
		}

		[HttpGet]
		public ActionResult Add()
		{
			var model = new UserInsertionViewModel();
			model.RoleList = GetRoleList();

			return View(model);
		}

		[HttpPost]
		public ActionResult Add(UserInsertionViewModel model)
		{
			if (ModelState.IsValid)
			{
				var isMeailExist = _userManager.IsUserMailExist(model.User.Email);
				if (!isMeailExist)
				{
					model.User.DateOfRegistration = DateTime.Now;

					_userManager.AddUser(model.User);
					return RedirectToAction("Index");
				}
				ModelState.AddModelError("", "Bu eposta başka bir kullanıcı tarafından kullanılıyor. Lütfen başka bir eposta seçin.");
			}

			model.RoleList = GetRoleList();
			return View(model);
		}

		public ActionResult Remove(int id)
		{
			_userManager.RemoveUser(id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			var model = new UserInsertionViewModel();
			var user = _userManager.GetUserWithDetailsById(id);
			model.User = user;
			model.RoleList = GetRoleList();
			return View(model);
		}

		[HttpPost]
		public ActionResult Update(UserInsertionViewModel model)
		{
			if (ModelState.IsValid)
			{
				_userManager.UpdateUser(model.User);
				return RedirectToAction("Index");
			}
			model.RoleList = GetRoleList();
			return View(model);
		}

		private List<SelectListItem> GetRoleList()
		{
			var list = new List<SelectListItem>();
			var roles = _roleService.GetAllRoles();

			foreach (var r in roles)
			{
				list.Add(new SelectListItem { Text = r.Name, Value = r.Id.ToString() });
			}

			return list;
		}
	}
}