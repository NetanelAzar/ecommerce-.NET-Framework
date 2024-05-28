using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
	public class Product
	{
		public int Pid { get; set; }
		public string Pname { get; set; }
		public float Price { get; set; }
		public string Pdesc { get; set; }
		public string Picname { get; set; }
		public int Cid { get; set; }
		public int Status { get; set; }
		public DateTime AddDate { get; set; }




	  public static List<Product> GetAll()
	  {
		return ProductDAL.GetAll();
	  }


		public static Product GetById(int Id)
		{
			return ProductDAL.GetById(Id);
		}
	}

}