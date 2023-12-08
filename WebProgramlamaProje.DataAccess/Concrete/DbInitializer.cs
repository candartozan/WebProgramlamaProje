using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.DataAccess.Concrete
{
	public class DbInitializer : CreateDatabaseIfNotExists<Context>
	{
		protected override void Seed(Context context)
		{
			var roles = new List<Role> {
				new Role { Id = 1, Name = "Admin", Description = "Yönetici rolüdür. User rolünü de kapsar." },
				new Role { Id = 2, Name = "User", Description = "Normal kullanıcı rolüdür." }
			};
			context.Roles.AddRange(roles);

			context.Users.Add(new User
			{
				Name = "Candar",
				Surname = "Tozan",
				Email = "candar@tozan.com",
				Password = "pass123",
				PhoneNumber = "55533322211",
				RoleId = 1,
				DateOfRegistration = DateTime.Now
			});

			context.SaveChanges();
		}
	}
}
