﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Region
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public virtual ICollection<City> Cities { get; set; }
	}
}
