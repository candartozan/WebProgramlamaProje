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

			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			builder.RegisterType<CategoryManger>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();

			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
