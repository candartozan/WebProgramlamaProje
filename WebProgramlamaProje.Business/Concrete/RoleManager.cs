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
	public class RoleManager : IRoleService
	{
		private readonly IRoleDal _roleDal;

		public RoleManager(IRoleDal roleDal)
		{
			_roleDal = roleDal;
		}

		public List<Role> GetAllRoles()
		{
			return _roleDal.FindAll().ToList();
		}
	}
}
