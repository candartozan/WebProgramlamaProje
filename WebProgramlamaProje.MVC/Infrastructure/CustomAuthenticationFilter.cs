using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebProgramlamaProje.MVC.Infrastructure
{
	public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
	{
		public void OnAuthentication(AuthenticationContext filterContext)
		{
			if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserName"])))
			{
				filterContext.Result = new HttpUnauthorizedResult();
			}
		}

		public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
		{
			if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
			{
				filterContext.Result = new RedirectToRouteResult(
				new RouteValueDictionary
				{
					 { "area" , "" },
					 { "controller", "Account" },
					 { "action", "Login" }
				});
			}
		}
	}
}