using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Areas.Admin.Models
{
	public class ProductInsertionViewModel
	{
		public Product Product { get; set; } = new Product();
		public List<SelectListItem> CategorySelectList { get; set; } = new List<SelectListItem>();
		public List<SelectListItem> BrandSelectList { get; set; } = new List<SelectListItem>();
	}
}