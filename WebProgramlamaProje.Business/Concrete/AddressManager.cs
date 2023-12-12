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
	public class AddressManager : IAddressService
	{
		private readonly IAddressDal _addressDal;
		private readonly IDistrictDal _districtDal;
		private readonly ICityDal _cityDal;
		private readonly IRegionDal _regionDal;

		public void AddAddress(Address address)
		{
			_addressDal.Create(address);
		}

		public List<Address> GetAddresses()
		{
			return _addressDal.FindAll().ToList();
		}

		public List<Address> GetAddressesByUserId(int id)
		{
			var list = _addressDal.FindAll().Where(a => a.UserId == id);
			foreach (var a in list)
			{
				a.District = _districtDal.FindByCondition(d => d.Id == a.DistrictId);
				a.District.City = _cityDal.FindByCondition(c => c.Id == a.District.CityId);
			}

			return list.ToList();
		}

		public List<City> GetCities()
		{
			return _cityDal.FindAll().ToList();
		}

		public List<District> GetDistricts()
		{
			return _districtDal.FindAll().ToList();
		}

		public List<Region> GetRegions()
		{
			return _regionDal.FindAll().ToList();
		}

		public void RemoveAddress(int id)
		{
			var address = _addressDal.FindByCondition(a => a.Id == id);
			_addressDal.Remove(address);
		}

		public void UpdateAddress(Address address)
		{
			_addressDal.Update(address);
		}
	}
}
