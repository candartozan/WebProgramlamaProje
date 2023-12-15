using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface ICartService
	{
		void AddCart(Cart cart);
		void RemoveCart(int id);
		Cart GetCartById(int id);
	}
}
