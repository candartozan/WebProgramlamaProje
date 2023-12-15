using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Cart
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public Decimal CartTotal
		{
			get
			{
				if (CartItems.Count > 0)
				{
					return CartItems.Sum(ci => ci.Product.Price * ci.Quantity);
				}
				else { return 0; }
			}
		}
		public virtual User User { get; set; }
		public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
	}
}
