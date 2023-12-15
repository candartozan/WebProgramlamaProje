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
		public int Id { get; set; }
		public int OrderId { get; set; }
		public DateTime DateOfInvoice { get; set; }
	}
}
