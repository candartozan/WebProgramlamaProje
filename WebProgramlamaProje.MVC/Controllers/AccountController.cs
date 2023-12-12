using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;
using WebProgramlamaProje.MVC.Models;

namespace WebProgramlamaProje.MVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		// GET: Account
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(UserLoginViewModel model)
		{
			if (ModelState.IsValid)
			{

				User user = _userService.GetUserByEmailPassword(model.Email, model.Password);

				if (user != null)
				{
					Session["UserName"] = user.Name;
					Session["UserId"] = user.Id;
					Session["UserRoleId"] = user.RoleId;
					Session.Timeout = 60;
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("", "Geçersiz kullanıcı adı ve şifre.");
				return View(model);

			}
			return View(model);
		}

		public ActionResult Logout()
		{
			Session["UserName"] = string.Empty;
			Session["UserId"] = string.Empty;
			Session["UserRoleId"] = string.Empty;
			return RedirectToAction("Index", "Home");
		}
	}
}