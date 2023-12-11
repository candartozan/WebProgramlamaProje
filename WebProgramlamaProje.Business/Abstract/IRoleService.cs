using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface IRoleService
	{
		List<Role> GetAllRoles();
	}
}
