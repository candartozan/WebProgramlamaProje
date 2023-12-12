using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProgramlamaProje.MVC.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Ad alanı boş olamaz.")]
		public String Name { get; set; }

		[Required(ErrorMessage = "Soyad alanı boş olamaz.")]
		public String Surname { get; set; }

		[Required(ErrorMessage = "Eposta boş olamaz.")]
		public String Email { get; set; }

		[Required(ErrorMessage = "Şifre boş olamaz.")]
		public String Password { get; set; }

		[Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
		public String ConfirmPassword { get; set; }
	}
}