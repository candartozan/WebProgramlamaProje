using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.DataAccess.Abstract;

namespace WebProgramlamaProje.DataAccess.Concrete
{
	public abstract class GenericDal<T> : IGenericDal<T> where T : class, new()
	{
		protected GenericDal()
		{

		}

		public void Create(T entity)
		{
			using (var context = new Context())
			{
				context.Set<T>().Add(entity);
			}
		}

		public IEnumerable<T> FindAll()
		{
			using (var context = new Context())
			{
				return context.Set<T>().ToList();
			}
		}

		public T FindByCondition(Expression<Func<T, bool>> expression)
		{
			using (var context = new Context())
			{
				return context.Set<T>().Where(expression).SingleOrDefault();
			}
		}

		public void Remove(T entity)
		{
			using (var context = new Context())
			{
				context.Set<T>().Remove(entity);
			}
		}

		public void Update(T entity)
		{
			using (var context = new Context())
			{
				context.Set<T>().AddOrUpdate(entity);
			}
		}
	}
}
