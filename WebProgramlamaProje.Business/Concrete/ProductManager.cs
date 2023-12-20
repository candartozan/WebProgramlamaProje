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
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;
		private readonly ICategoryDal _categoryDal;
		private readonly IBrandDal _brandDal;

		public ProductManager(IProductDal productDal, ICategoryDal categoryDal, IBrandDal brandDal)
		{
			_productDal = productDal;
			_categoryDal = categoryDal;
			_brandDal = brandDal;
		}

		public void AddOneProduct(Product entity)
		{
			_productDal.Create(entity);
		}

		public List<Product> GetAllProductWithDetails()
		{
			var products = _productDal.FindAll();
			foreach (var p in products)
			{
				p.Brand = _brandDal.FindByCondition(b => b.Id == p.BrandId);
				p.Category = _categoryDal.FindByCondition(c => c.Id == p.CategoryId);
			}

			return products.ToList();
		}

		public List<Product> GetAllProductWithDetails(string searchTerm)
		{
			IEnumerable<Product> products;
			if (searchTerm == null)
			{
				products = _productDal.FindAll();
			}
			else
			{
				products = _productDal.FindAll().Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));
			}

			foreach (var p in products)
			{
				p.Brand = _brandDal.FindByCondition(b => b.Id == p.BrandId);
				p.Category = _categoryDal.FindByCondition(c => c.Id == p.CategoryId);
			}

			return products.ToList();
		}

		public Product GetProductWithDetailsById(int id)
		{
			var product = _productDal.FindByCondition(p => p.Id == id);
			product.Category = _categoryDal.FindByCondition(c => c.Id == product.CategoryId);
			product.Brand = _brandDal.FindByCondition(c => c.Id == product.BrandId);

			return product;
		}

		public List<Product> GetShowCase()
		{
			var products = _productDal.FindAll().OrderByDescending(p => p.Id).Take(3);
			foreach (var p in products)
			{
				p.Brand = _brandDal.FindByCondition(b => b.Id == p.BrandId);
				p.Category = _categoryDal.FindByCondition(c => c.Id == p.CategoryId);
			}

			return products.ToList();
		}

		public void RemoveOneProduct(int id)
		{
			var product = _productDal.FindByCondition(p => p.Id == id);
			_productDal.Remove(product);
		}

		public void UpdateOneProduct(Product entity)
		{
			_productDal.Update(entity);
		}
	}
}
