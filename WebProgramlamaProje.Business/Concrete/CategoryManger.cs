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

		public Category AddOneCategory(Category entity)
		{
			_categoryDal.Create(entity);
			return _categoryDal.FindByCondition(c => c.Name.Equals(entity.Name));
		}

		public List<Category> GetAllCategories()
		{
			return _categoryDal.FindAll().ToList();
		}

		public Category GetCategoryById(int id)
		{
			return _categoryDal.FindByCondition(c => c.Id.Equals(id));
		}

		public void RemoveOneCategory(int id)
		{
			var entitiy = _categoryDal.FindByCondition(c => c.Id.Equals(id));
			_categoryDal.Remove(entitiy);
		}

		public void UpdateOneCategory(Category entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
