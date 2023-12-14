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
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;
		private readonly ICargoCompanyDal _cargoCompanyDal;
		private readonly IOrderStatusDal _orderStatusDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public void Add(Order order)
		{
			_orderDal.Create(order);
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
			}

			return orders;
		}

		public List<CargoCompany> GetCargoCompanies()
		{
			return _cargoCompanyDal.FindAll().ToList();
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
			}

			return orders;
		}

		public void UpdateOrder(Order order)
		{
			_orderDal.Update(order);
		}
	}
}
