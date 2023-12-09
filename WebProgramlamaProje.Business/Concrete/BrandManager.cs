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
	public class BrandManager : IBrandService
	{
		private readonly IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public void AddOneBrand(Brand entity)
		{
			_brandDal.Create(entity);
		}

		public List<Brand> GetAllBrands()
		{
			return _brandDal.FindAll().ToList();
		}

		public Brand GetBrandById(int id)
		{
			return _brandDal.FindByCondition(c => c.Id.Equals(id));
		}

		public void RemoveOneBrand(int id)
		{
			var entity = _brandDal.FindByCondition(c => c.Id.Equals(id));
			_brandDal.Remove(entity);
		}

		public void UpdateOneBrand(Brand entity)
		{
			_brandDal.Update(entity);
		}
	}
}
