using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface IBrandService
	{
		List<Brand> GetAllBrands();
		void AddOneBrand(Brand entity);
		Brand GetBrandById(int id);
		void RemoveOneBrand(int id);
		void UpdateOneBrand(Brand entity);
	}
}
