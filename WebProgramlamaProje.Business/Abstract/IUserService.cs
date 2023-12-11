using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface IUserService
	{
		List<User> GetAllUsersWithDetails();
		User GetUserWithDetailsById(int id);
		void AddUser(User user);
		void RemoveUser(int id);
		void UpdateUser(User user);
		bool IsUserMailExist(String mail);
	}
}
