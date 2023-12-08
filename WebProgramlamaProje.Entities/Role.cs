using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Role
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}
