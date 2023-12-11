using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.DataAccess.Abstract;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Concrete
{
	public class UserManager : IUserService
	{
		private readonly IUserDal _userDal;
		private readonly IRoleDal _roleDal;

		public UserManager(IUserDal userDal, IRoleDal roleDal)
		{
			_userDal = userDal;
			_roleDal = roleDal;
		}

		public void AddUser(User user)
		{
			_userDal.Create(user);
		}

		public List<User> GetAllUsersWithDetails()
		{
			var user = _userDal.FindAll();

			foreach (var u in user)
			{
				u.Role = _roleDal.FindByCondition(r => r.Id == u.RoleId);
			}

			return user.ToList();
		}

		public User GetUserWithDetailsById(int id)
		{
			var user = _userDal.FindByCondition(u => u.Id == id);
			user.Role = _roleDal.FindByCondition(r => r.Id == user.RoleId);
			return user;
		}

		public bool IsUserMailExist(string mail)
		{
			var user = _userDal.FindByCondition(u => u.Email.Equals(mail));
			return user != null ? true : false;
		}

		public void RemoveUser(int id)
		{
			var user = _userDal.FindByCondition(u => u.Id == id);
			_userDal.Remove(user);
		}

		public void UpdateUser(User user)
		{
			_userDal.Update(user);
		}
	}
}
