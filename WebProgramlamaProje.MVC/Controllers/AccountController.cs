using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Entities;
using WebProgramlamaProje.MVC.Infrastructure;
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

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(UserRegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (_userService.IsUserMailExist(model.Email))
				{
					ModelState.AddModelError("", "Bu mail adresi başka bir kullanıcı tarafından kullanılıyor.");
					return View(model);
				}
				var user = new User();
				user.Email = model.Email;
				user.Password = model.Password;
				user.Name = model.Name;
				user.Surname = model.Surname;
				user.DateOfRegistration = DateTime.Now;
				user.RoleId = 2;
				_userService.AddUser(user);

				return RedirectToAction("Login", "Account");
			}
			return View(model);
		}

		[HttpGet]
		[CustomAuthenticationFilter]
		public ActionResult Profile()
		{
			var user = _userService.GetUserWithDetailsById(Convert.ToInt32(Session["UserId"]));
			return View(user);
		}

		public ActionResult Profile(User model)
		{
			if (ModelState.IsValid)
			{
				_userService.UpdateUser(model);
				TempData["UserInfo"] = "Bilgiler Güncellendi";
			}
			return View(model);
		}
	}
}