using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.DataAccess.Abstract
{
	public interface IGenericDal<T> where T : class, new()
	{
		IEnumerable<T> FindAll();
		T FindByCondition(Expression<Func<T, bool>> expression);
		void Create(T entity);
		void Remove(T entity);
		void Update(T entity);
	}
}
