using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.DataAccess.Concrete
{
	public class Context : DbContext
	{
		public Context() : base()
		{
			Database.SetInitializer(new DbInitializer());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
