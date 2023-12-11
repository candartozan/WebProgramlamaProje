using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProgramlamaProje.MVC.Models
{
	public class UserLoginViewModel
	{
		[Required(ErrorMessage = "Eposta giriş için gereklidir.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre giriş gereklidir.")]
		public string Password { get; set; }
	}
}