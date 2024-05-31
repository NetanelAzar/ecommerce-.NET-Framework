using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace DAL
{
	public class ProductDAL
	{
		public static List<Product> GetAll()
		{

			DbContext Db = new DbContext();//יצירת אובייקט מסוג גישה לבסיס הנתונים 
			string Sql = "Select * from T_Product";//הגדרת משפט השאילתה
			DataTable Dt = Db.Execute(Sql);//הפעלת השאילתה וקבלת התוצאות לתוך טבלת התנונים
			List<Product> LstProd = new List<Product>();//יצירת רשימה של מוצרים

			for (int i = 0; i < Dt.Rows.Count; i++)
			{
				Product P = new Product()
				{
					Pid = int.Parse(Dt.Rows[i]["Pid"] + ""),
					Pname = Dt.Rows[i]["Pname"] + "",
					Price = float.Parse(Dt.Rows[i]["Price"] + ""),
					Pdesc = Dt.Rows[i]["Pdesc"] + "",
					Picname = Dt.Rows[i]["Picname"] + "",
					Cid = int.Parse(Dt.Rows[i]["Cid"] + ""),
					AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + ""),

				};
				LstProd.Add(P);

			}

			Db.Close();
			return LstProd;
		}








		public static Product GetById(int Id)
		{

			DbContext Db = new DbContext();//יצירת אובייקט מסוג גישה לבסיס הנתונים 
			string Sql = $"Select * from T_Product where Pid={Id}";//הגדרת משפט השאילתה
			DataTable Dt = Db.Execute(Sql);//הפעלת השאילתה וקבלת התוצאות לתוך טבלת התנונים
			Product Tmp = null;
			if (Dt.Rows.Count > 0)
			{
				    Tmp = new Product()
				    {
					Pid = int.Parse(Dt.Rows[0]["Pid"] + ""),
					Pname = Dt.Rows[0]["Pname"] + "",
					Price = float.Parse(Dt.Rows[0]["Price"] + ""),
					Pdesc = Dt.Rows[0]["Pdesc"] + "",
					Picname = Dt.Rows[0]["Picname"] + "",
					Cid = int.Parse(Dt.Rows[0]["Cid"] + ""),
					AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + ""),

				     };
			}

			Db.Close();
			return Tmp;

		}




		public static void Save(Product product)
		{
			DbContext Db = new DbContext();//יצירת אובייקט מסוג גישה לבסיס הנתונים 
			string Sql;

			if (product.Pid == 0)
			{
				//INSERT מוצר חדש 
				Sql = $"INSERT INTO T_Product (Pname, Price, Pdesc, Picname, Cid, AddDate, Status) " +
					  $"VALUES ('{product.Pname}', {product.Price}, '{product.Pdesc}', '{product.Picname}', {product.Cid}, '{product.AddDate}', {product.Status})";
			}
			else
			{
				///עדכון מוצר
				Sql = $"UPDATE T_Product SET " +
					  $"Pname = '{product.Pname}', " +
					  $"Price = {product.Price}, " +
					  $"Pdesc = '{product.Pdesc}', " +
					  $"Picname = '{product.Picname}', " +
					  $"Cid = {product.Cid}, " +
					  $"AddDate = '{product.AddDate}', " +
					  $"Status = {product.Status} " +
					  $"WHERE Pid = {product.Pid}";
			}

			Db.Execute(Sql); // ביצוע השאילתה על בסיס הנתונים
			Db.Close();// סגירת הגישה לבסיס הנתונים
		}

	}
}