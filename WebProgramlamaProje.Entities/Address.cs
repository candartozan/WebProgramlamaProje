using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Address
	{
		public int Id { get; set; }
		public int UserId { get; set; }

		[Required(ErrorMessage = "İlçe boş olamaz.")]
		public int DistrictId { get; set; }

		[Required(ErrorMessage = "Adres başlığı boş olamaz.")]
		public String Title { get; set; }

		[Required(ErrorMessage = "Adres açıklaması boş olamaz.")]
		public String Description { get; set; }
		public DateTime DateOfCreation { get; set; }
		public District District { get; set; }
		public virtual User User { get; set; }
	}
}
