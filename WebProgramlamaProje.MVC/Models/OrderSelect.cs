using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProgramlamaProje.MVC.Models
{
	public class OrderSelect
	{
		public List<SelectListItem> CargoC { get; set; }
		public List<SelectListItem> Addresses { get; set; }
		public int CargoId { get; set; }
		public int AdresId { get; set; }
	}
}