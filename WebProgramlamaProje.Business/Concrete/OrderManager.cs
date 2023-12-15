using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Business.Abstract;
using WebProgramlamaProje.DataAccess.Abstract;
using WebProgramlamaProje.DataAccess.Concrete;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;
		private readonly ICargoCompanyDal _cargoCompanyDal;
		private readonly IOrderStatusDal _orderStatusDal;
		private readonly IAddressDal _addressDal;
		private readonly ICartDal _cartDal;
		private readonly IInvoiceDal _invoiceDal;
		private readonly ICartItemDal _cartItemDal;
		private readonly IProductDal _productDal;
		private readonly IUserDal _userDal;

		public OrderManager(IOrderDal orderDal, IAddressDal addressDal, ICargoCompanyDal cargoCompanyDal, IOrderStatusDal orderStatusDal, ICartDal cartService = null, IInvoiceDal invoiceDal = null, ICartItemDal cartItemDal = null, IProductDal productDal = null, IUserDal userDal = null)
		{
			_orderDal = orderDal;
			_addressDal = addressDal;
			_cargoCompanyDal = cargoCompanyDal;
			_orderStatusDal = orderStatusDal;
			_cartDal = cartService;
			_invoiceDal = invoiceDal;
			_cartItemDal = cartItemDal;
			_productDal = productDal;
			_userDal = userDal;
		}

		public void Add(Order order)
		{
			var cart = order.Cart;
			order.Cart = null;

			var cartItems = cart.CartItems;
			cart.CartItems = null;
			_cartDal.Create(cart);

			foreach (var ci in cartItems)
			{
				ci.Product = null;
				ci.CartId = cart.Id;
				_cartItemDal.Create(ci);
			}

			order.CartId = cart.Id;
			_orderDal.Create(order);


			var invoice = new Invoice() { DateOfInvoice = DateTime.Now, OrderId = order.Id };
			_invoiceDal.Create(invoice);
			order.InvoiceId = invoice.Id;

			_orderDal.Update(order);

		}

		public void DeleteOrder(int id)
		{
			var order = _orderDal.FindByCondition(o => o.Id == id);
			_orderDal.Remove(order);
		}

		public List<Order> GetAllOrders()
		{
			var orders = _orderDal.FindAll().ToList();

			foreach (var o in orders)
			{
				o.CargoCompany = _cargoCompanyDal.FindByCondition(cc => cc.Id == o.CargoCompanyId);
				o.OrderStatus = _orderStatusDal.FindByCondition(os => os.Id == o.OrderStatusId);
				o.Address = _addressDal.FindByCondition(a => a.Id == o.AddressId);
				o.Cart = _cartDal.FindByCondition(c => c.Id == o.CartId);
				o.Cart.CartItems = _cartItemDal.FindAll().Where(ci => ci.CartId == o.CartId).ToList();
				o.User = _userDal.FindByCondition(u => u.Id == o.UserId);
				foreach (var ci in o.Cart.CartItems)
				{
					ci.Product = _productDal.FindByCondition(p => p.Id == ci.ProductId);
				}
			}

			return orders;
		}

		public List<CargoCompany> GetCargoCompanies()
		{
			return _cargoCompanyDal.FindAll().ToList();
		}

		public Order GetOrder(int id)
		{
			var order = _orderDal.FindByCondition(o => o.Id == id);
			return order;
		}

		public List<OrderStatus> GetOrderStatuses()
		{
			return _orderStatusDal.FindAll().ToList();
		}

		public List<Order> GetUserOrders(int id)
		{
			var orders = _orderDal.FindAll().Where(o => o.UserId == id).ToList();

			foreach (var o in orders)
			{
				o.CargoCompany = _cargoCompanyDal.FindByCondition(cc => cc.Id == o.CargoCompanyId);
				o.OrderStatus = _orderStatusDal.FindByCondition(os => os.Id == o.OrderStatusId);
				o.Address = _addressDal.FindByCondition(a => a.Id == o.AddressId);
				o.Cart = _cartDal.FindByCondition(c => c.Id == o.CartId);
				o.Cart.CartItems = _cartItemDal.FindAll().Where(ci => ci.CartId == o.CartId).ToList();
				foreach (var ci in o.Cart.CartItems)
				{
					ci.Product = _productDal.FindByCondition(p => p.Id == ci.ProductId);
				}
			}

			return orders;
		}

		public void UpdateOrder(Order order)
		{
			_orderDal.Update(order);
		}

		public void UpdateOrderStatus(int id, int orderStatusId)
		{
			var order = _orderDal.FindByCondition(o => o.Id == id);
			order.OrderStatusId = orderStatusId;
			_orderDal.Update(order);
		}
	}
}
