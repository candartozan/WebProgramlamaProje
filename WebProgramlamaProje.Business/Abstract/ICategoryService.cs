﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface ICategoryService
	{
		Category AddOneCategory(Category entity);
		List<Category> GetAllCategories();
		Category GetCategoryById(int id);
		void RemoveOneCategory(int id);
		void UpdateOneCategory(Category entity);
	}
}
