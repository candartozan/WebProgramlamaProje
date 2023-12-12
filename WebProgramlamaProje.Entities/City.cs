using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class City
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public int RegionId { get; set; }
		public virtual Region Region { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
