using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
			DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים 
			string Sql;

			if (product.Pid == -1)
			{
				// INSERT מוצר חדש 
				Sql = "INSERT INTO T_Product (Pname, Price, Pdesc, Picname, Cid, Status) " +
					  "VALUES (@Pname, @Price, @Pdesc, @Picname, @Cid, @Status)";
			}
			else
			{
				// עדכון מוצר
				Sql = "UPDATE T_Product SET " +
					  "Pname = @Pname, " +
					  "Price = @Price, " +
					  "Pdesc = @Pdesc, " +
					  "Picname = @Picname, " +
					  "Cid = @Cid, " +
					  "Status = @Status " +
					  "WHERE Pid = @Pid";
			}

			using (SqlCommand cmd = new SqlCommand(Sql, Db.Conn))
			{
				cmd.Parameters.AddWithValue("@Pname", product.Pname);
				cmd.Parameters.AddWithValue("@Price", product.Price);
				cmd.Parameters.AddWithValue("@Pdesc", product.Pdesc);
				cmd.Parameters.AddWithValue("@Picname", product.Picname);
				cmd.Parameters.AddWithValue("@Cid", product.Cid);
				cmd.Parameters.AddWithValue("@Status", product.Status);

				if (product.Pid != 0)
				{
					cmd.Parameters.AddWithValue("@Pid", product.Pid);
				}

				cmd.ExecuteNonQuery(); // ביצוע השאילתה על בסיס הנתונים
			}

			Db.Close(); // סגירת הגישה לבסיס הנתונים
		}


	}
}