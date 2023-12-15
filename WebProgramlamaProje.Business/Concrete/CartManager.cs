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
	public class CartManager : ICartService
	{
		private readonly ICartDal _cartDal;
		private readonly ICartItemDal _cartItemDal;
		private readonly IProductDal _productDal;

		public CartManager(ICartDal cartDal, ICartItemDal cartItemDal, IProductDal productDal)
		{
			_cartDal = cartDal;
			_cartItemDal = cartItemDal;
			_productDal = productDal;
		}

		public void AddCart(Cart cart)
		{
			var cartItems = cart.CartItems;
			cart.CartItems = null;
			_cartDal.Create(cart);

			foreach (var ci in cartItems)
			{
				ci.Product = null;
				ci.CartId = cart.Id;
				_cartItemDal.Create(ci);
			}
		}

		public Cart GetCartById(int id)
		{
			var cart = _cartDal.FindByCondition(c => c.UserId == id);
			var cartItems = _cartItemDal.FindAll().Where(ci => ci.CartId == cart.Id).ToList();
			cart.CartItems = cartItems;
			foreach (var ci in cart.CartItems)
			{
				ci.Product = _productDal.FindByCondition(p => p.Id == ci.ProductId);
			}
			return cart;
		}

		public void RemoveCart(int id)
		{
			var cart = _cartDal.FindByCondition(c => c.Id == id);
			cart.CartItems = _cartItemDal.FindAll().Where(ci => ci.CartId == cart.Id).ToList();

			foreach (var ci in cart.CartItems)
			{
				_cartItemDal.Remove(ci);
			}
			_cartDal.Remove(cart);
		}
	}
}
