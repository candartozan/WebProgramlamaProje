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
		public List<Brand> GetAllBrands()
		{
			return _brandDal.FindAll().ToList();
		}
	}
}
