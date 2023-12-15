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
			this.Configuration.LazyLoadingEnabled = false;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<District> Districts { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<CargoCompany> CargoCompanies { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
