using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public int BrandId { get; set; }

		[Required(ErrorMessage ="Ürün adı boş olamaz.")]
		public String Name { get; set; }

		public Decimal Price { get; set; }
		public int Stock { get; set; }
		public String PhotoUrl { get; set; }
		public DateTime DateOfAddition { get; set; }
		public virtual Category Category { get; set; }
		public virtual Brand Brand { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
