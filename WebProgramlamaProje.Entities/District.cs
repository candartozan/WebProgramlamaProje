using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class District
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public int CityId { get; set; }
		public City City { get; set; }
	}
}
