using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int CartId { get; set; }
		public int AddressId { get; set; }
		public int CargoCompanyId { get; set; }
		public int InvoiceId { get; set; }
		public int OrderStatusId { get; set; }
		public DateTime DateOfOrder { get; set; }
		public User User { get; set; }
        public Cart Cart { get; set; }
        public Address Address { get; set; }
		public CargoCompany CargoCompany { get; set; }
		public Invoice Invoice { get; set; }
		public OrderStatus OrderStatus { get; set; }
	}
}
