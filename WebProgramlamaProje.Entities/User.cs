using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class User
	{
		public int Id { get; set; }
		public int RoleId { get; set; }

		[Required(ErrorMessage = "Ad alanı boş olamaz.")]
		public String Name { get; set; }

		[Required(ErrorMessage = "Soyad alanı boş olamaz.")]
		public String Surname { get; set; }

		[Required(ErrorMessage = "Eposta boş olamaz.")]
		public String Email { get; set; }

		[Required(ErrorMessage = "Şifre boş olamaz.")]
		public String Password { get; set; }
		public String PhoneNumber { get; set; }
		public DateTime DateOfRegistration { get; set; }
		public virtual Role Role { get; set; }
		public virtual ICollection<Address> Addresses { get; set; }
	}
}