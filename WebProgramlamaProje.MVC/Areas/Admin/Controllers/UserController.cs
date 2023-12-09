using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Business.Concrete;
using WebProgramlamaProje.DataAccess.Concrete;

namespace WebProgramlamaProje.MVC.Areas.Admin.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userManager;

		public UserController(IUserService userManager)
		{
			_userManager = userManager;
		}

		// GET: Admin/User
		public ActionResult Index()
		{
			var users = _userManager.GetAllUsersWithDetails();
			return View(users);
		}
	}
}