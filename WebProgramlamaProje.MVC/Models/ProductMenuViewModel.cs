using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Models
{
	public class ProductMenuViewModel
	{
		public List<Product> Products {  get; set; }
		public List<Category> Categories { get; set; }
		public List<Brand> Brands { get; set; }
	}
}