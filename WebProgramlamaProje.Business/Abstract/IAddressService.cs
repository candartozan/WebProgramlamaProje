using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramlamaProje.Entities;

namespace WebProgramlamaProje.Business.Abstract
{
	public interface IAddressService
	{
		List<Region> GetRegions();
		List<City> GetCities();
		List<District> GetDistricts();
		List<Address> GetAddresses();
		List<Address> GetAddressesByUserId(int id);
		void AddAddress(Address address);
		void RemoveAddress(int id);
		void UpdateAddress(Address address);
	}
}
