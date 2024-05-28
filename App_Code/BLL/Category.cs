using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;



namespace BLL
{
	public class Category
	{
		public int Cid { get; set; }
		public string Cname { get; set; }
		public string Cdesc { get; set; }
		public string Picname {  get; set; }
		public int ParentCid { get; set; }
		public int Status { get; set; }
		public DateTime AddDate { get; set; }




		public static List<Category> GetAll()
		{
			return CategoryDAL.GetAll();
		}


		public static Category GetById(int Id)
		{
			return CategoryDAL.GetById(Id);
		}
	}
}