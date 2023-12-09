using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Brand
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Marka Adı boş olamaz.")]
		public String Name { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
