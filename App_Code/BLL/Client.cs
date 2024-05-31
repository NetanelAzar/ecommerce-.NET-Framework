using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
	public class Client
	{
		
	
			public int ClientID { get; set; }
			public string ClientName { get; set; }
			public string ClientLastname { get; set; }
			public string Address { get; set; }
			public string CityCode { get; set; }
			public string ClientPhone { get; set; }
			public string ClientMail { get; set; }
			public string ClientPassword { get; set; }
			public int Status { get; set; }
		    public DateTime AddDate { get; set; }




		public static List<Client> GetAll()
		{
			return ClientDAL.GetAll();
		}

		public static Client GetById(int Id)
		{
			return ClientDAL.GetById(Id);
		}

		public void Save()
		{
			ClientDAL.Save(this);
		}

	}
}