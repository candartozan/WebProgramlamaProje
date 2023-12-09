using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface IProductService
	{
		void AddOneProduct(Product entity);
		List<Product> GetAllProductWithDetails();
		Product GetProductWithDetailsById(int id);
		void RemoveOneProduct(int id);
		void UpdateOneProduct(Product entity);
	}
}
