using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
	public class City
	{
		public int CityId { get; set; }
		public string CityCode { get; set; }
		public string CityName { get; set; }
		public int Status { get; set; }
		public DateTime AddDate { get; set; }






		public static List<City> GetAll()
		{
			return CityDAL.GetAll();
		}

		public static City GetById(int Id)
		{
			return CityDAL.GetById(Id);
		}

		public void Save()
		{
			CityDAL.Save(this);
		}




	}
}