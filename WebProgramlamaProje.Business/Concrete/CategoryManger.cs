using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.DataAccess.Abstract;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Concrete
{
	public class CategoryManger : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManger(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public List<Category> GetAllCategories()
		{
			return _categoryDal.FindAll().ToList();
		}
	}
}
