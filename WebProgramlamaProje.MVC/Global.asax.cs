using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.Business.Concrete;
using WebProgramlamaProje.DataAccess.Abstract;
using WebProgramlamaProje.DataAccess.Concrete;

namespace WebProgramlamaProje.MVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();
			builder.RegisterType<CategoryDal>().As<ICategoryDal>().SingleInstance();
			builder.RegisterType<BrandDal>().As<IBrandDal>().SingleInstance();
			builder.RegisterType<ProductDal>().As<IProductDal>().SingleInstance();
			builder.RegisterType<RoleDal>().As<IRoleDal>().SingleInstance();
			builder.RegisterType<AddressDal>().As<IAddressDal>().SingleInstance();
			builder.RegisterType<DistrictDal>().As<IDistrictDal>().SingleInstance();
			builder.RegisterType<CityDal>().As<ICityDal>().SingleInstance();
			builder.RegisterType<RegionDal>().As<IRegionDal>().SingleInstance();
			builder.RegisterType<OrderDal>().As<IOrderDal>().SingleInstance();
			builder.RegisterType<OrderStatusDal>().As<IOrderStatusDal>().SingleInstance();
			builder.RegisterType<CargoCompanyDal>().As<ICargoCompanyDal>().SingleInstance();
			builder.RegisterType<InvoiceDal>().As<IInvoiceDal>().SingleInstance();
			builder.RegisterType<CartDal>().As<ICartDal>().SingleInstance();
			builder.RegisterType<CartItemDal>().As<ICartItemDal>().SingleInstance();

			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			builder.RegisterType<CategoryManger>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
			builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
			builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
			builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
			builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
			builder.RegisterType<CartManager>().As<ICartService>().SingleInstance();

			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
