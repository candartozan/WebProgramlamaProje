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
		private readonly IUserService _userManager = new UserManager(new UserDal());
		// GET: Admin/User
		public ActionResult Index()
		{
			var users = _userManager.GetAllUsers();
			return View(users);
		}
	}
}