using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Invoice
	{
		[Key, ForeignKey("Order")]
		public int Id { get; set; }
		public int OrderId { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public virtual Order Order { get; set; }
    }
}
