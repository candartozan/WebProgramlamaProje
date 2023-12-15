using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.MVC.Models
{
	public static class SessionCart
	{
		public static Cart GetCart()
		{
			var context = HttpContext.Current;
			if (string.IsNullOrEmpty(Convert.ToString(context.Session["Cart"])))
			{
				Cart newCart = new Cart();
				context.Session["Cart"] = newCart;
				return newCart;
			}

			var cart = (Cart)context.Session["Cart"];
			return cart;
		}

		public static void AddProductToCart(Product product)
		{
			var context = HttpContext.Current;
			var cart = (Cart)context.Session["Cart"];

			var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == product.Id);

			if (cartItem != null)
			{
				cartItem.Quantity++;
				context.Session["Cart"] = cart;
			}
			else
			{
				cart.CartItems.Add(new CartItem { ProductId = product.Id, Product = product, Quantity = 1 });
				context.Session["Cart"] = cart;
			}
		}

		public static void ClearCart()
		{
			var context = HttpContext.Current;
			var cart = (Cart)context.Session["Cart"];

			cart.CartItems = new List<CartItem>();
			context.Session["Cart"] = cart;
		}

		public static void RemoveProductFromCart(int id)
		{
			var context = HttpContext.Current;
			var cart = (Cart)context.Session["Cart"];

			cart.CartItems.Remove(
				cart
				.CartItems
				.FirstOrDefault(ci => ci.ProductId == id));

			context.Session["Cart"] = cart;
		}
	}
}