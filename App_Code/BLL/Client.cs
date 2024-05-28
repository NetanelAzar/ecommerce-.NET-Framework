using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
	public class Client
	{
		
	
			public int ClientID { get; set; }
			public string ClientName { get; set; }
			public string ClientLastname { get; set; }
			public string Address { get; set; }
			public string CityCode { get; set; }
			public string PhoneNumber { get; set; }
			public string ClientMail { get; set; }
			public string ClientPassword { get; set; }
			public bool Status { get; set; }
			public string DateTime { get; set; }
		
	}
}