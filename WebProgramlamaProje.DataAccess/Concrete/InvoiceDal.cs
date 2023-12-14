using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.DataAccess.Abstract;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.DataAccess.Concrete
{
	public class InvoiceDal : GenericDal<Invoice>, IInvoiceDal
	{
	}
}
