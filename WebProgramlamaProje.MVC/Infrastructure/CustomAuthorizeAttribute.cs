using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Business.Concrete;
using WebProgramlamaProje.DataAccess.Concrete;

namespace WebProgramlamaProje.MVC.Infrastructure
{
	public class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		private readonly string[] allowedroles;
		private readonly IUserService _userService;

		public CustomAuthorizeAttribute(params string[] roles)
		{
			this.allowedroles = roles;
			_userService = new UserManager(new UserDal(), new RoleDal());
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			bool authorize = false;
			var userId = Convert.ToString(httpContext.Session["UserId"]);
			if (!string.IsNullOrEmpty(userId))
			{
				var userRole = _userService.GetUserWithDetailsById(Convert.ToInt32(userId)).Role;

				foreach (var role in allowedroles)
				{
					if (role == userRole.Name) return true;
				}
			}

			return authorize;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result = new RedirectToRouteResult(
			   new RouteValueDictionary
			   {
					 { "area" , "" },
					{ "controller", "Home" },
					{ "action", "AccessDenied" }
			   });
		}
	}
}