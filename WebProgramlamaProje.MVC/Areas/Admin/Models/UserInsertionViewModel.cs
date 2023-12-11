using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Areas.Admin.Models
{
	public class UserInsertionViewModel
	{
		public User User { get; set; } = new User();
		public List<SelectListItem> RoleList { get; set; } = new List<SelectListItem>();
	}
}