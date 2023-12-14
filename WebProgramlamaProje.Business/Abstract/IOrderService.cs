using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface IOrderService
	{
		List<Order> GetAllOrders();
		List<Order> GetUserOrders(int id);
		void Add(Order order);
		void UpdateOrder(Order order);
		void DeleteOrder(int id);
		List<CargoCompany> GetCargoCompanies();
		List<OrderStatus> GetOrderStatuses();
	}
}
