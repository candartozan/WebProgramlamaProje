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
		List<Product> GetAllProductWithDetails(string searchTerm);
		List<Product> GetAllProductWithDetails(string searchTerm, int categoryId, int brandId);
		Product GetProductWithDetailsById(int id);
		List<Product> GetShowCase();
		void RemoveOneProduct(int id);
		void UpdateOneProduct(Product entity);
	}
}
