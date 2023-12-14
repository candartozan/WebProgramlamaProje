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

		public CartManager(ICartDal cartDal, ICartItemDal cartItemDal)
		{
			_cartDal = cartDal;
			_cartItemDal = cartItemDal;
		}

		public void AddCart(Cart cart)
		{
			_cartDal.Create(cart);
			foreach (var ci in cart.CartItems)
			{
				ci.CartId = cart.Id;
				_cartItemDal.Create(ci);
			}
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
