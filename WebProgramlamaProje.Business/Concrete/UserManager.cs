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

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public List<User> GetAllUsers()
		{
			return _userDal.FindAll().ToList();
		}
	}
}
