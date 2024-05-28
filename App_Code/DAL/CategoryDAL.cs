using BLL;
using DATA;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL
{
	public class CategoryDAL
	{



		public static List<Category> GetAll()
		{
			DbContext Db = new DbContext();//יצירת אובייקט מסוג גישה לבסיס הנתונים 
			string Sql = "Select * from T_Category";//הגדרת משפט השאילתה
			DataTable Dt = Db.Execute(Sql);//הפעלת השאילתה וקבלת התוצאות לתוך טבלת התנונים
			List<Category> LstCategory = new List<Category>();
			for (int i = 0; i < Dt.Rows.Count; i++)
			{
		  Category Cat = new Category()
				   {
					Cid = int.Parse(Dt.Rows[i]["Cid"] + ""),
					Cname = Dt.Rows[i]["Cname"] + "",
					Cdesc = Dt.Rows[i]["Cdesc"] + "",
					Picname = Dt.Rows[i]["Picname"] + "",
					ParentCid = int.Parse(Dt.Rows[i]["ParentCid"] + ""),
					AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + ""),

				   };
				LstCategory.Add(Cat);

			}
			Db.Close();
			return LstCategory;
		}


		public static Category GetById(int Id)
		{
			DbContext Db = new DbContext();//יצירת אובייקט מסוג גישה לבסיס הנתונים 
			string Sql = $"Select * from T_Category where Pid={Id}";//הגדרת משפט השאילתה
			DataTable Dt = Db.Execute(Sql);//הפעלת השאילתה וקבלת התוצאות לתוך טבלת התנונים
			Category Tmp = null;
			if (Dt.Rows.Count > 0)
			{
				Tmp = new Category()
				{
					Cid = int.Parse(Dt.Rows[0]["Cid"] + ""),
					Cname = Dt.Rows[0]["Cname"] + "",
					Cdesc = Dt.Rows[0]["Cdesc"] + "",
					Picname = Dt.Rows[0]["Picname"] + "",
					ParentCid = int.Parse(Dt.Rows[0]["ParentCid"] + ""),
					AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + ""),
				};
			}
			Db.Close();
			return Tmp;
		}
	}
}