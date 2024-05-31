using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
	public class CategoryDAL
	{
		public static List<Category> GetAll()
		{
			DbContext Db = new DbContext();
			string Sql = "Select * from T_Category";
			DataTable Dt = Db.Execute(Sql);
			List<Category> LstCategory = new List<Category>();

			for (int i = 0; i < Dt.Rows.Count; i++)
			{
				Category Cat = new Category()
				{
					Cid = int.Parse(Dt.Rows[i]["Cid"].ToString()),
					Cname = Dt.Rows[i]["Cname"].ToString(),
					Cdesc = Dt.Rows[i]["Cdesc"].ToString(),
					Picname = Dt.Rows[i]["Picname"].ToString(),
					ParentCid = int.Parse(Dt.Rows[i]["ParentCid"].ToString()),
					Status = int.Parse(Dt.Rows[i]["Status"].ToString()),
					AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString())
				};
				LstCategory.Add(Cat);
			}

			Db.Close();
			return LstCategory;
		}

		public static Category GetById(int Id)
		{
			DbContext Db = new DbContext();
			string Sql = $"Select * from T_Category where Cid={Id}";
			DataTable Dt = Db.Execute(Sql);
			Category Tmp = null;

			if (Dt.Rows.Count > 0)
			{
				Tmp = new Category()
				{
					Cid = int.Parse(Dt.Rows[0]["Cid"].ToString()),
					Cname = Dt.Rows[0]["Cname"].ToString(),
					Cdesc = Dt.Rows[0]["Cdesc"].ToString(),
					Picname = Dt.Rows[0]["Picname"].ToString(),
					ParentCid = int.Parse(Dt.Rows[0]["ParentCid"].ToString()),
					Status = int.Parse(Dt.Rows[0]["Status"].ToString()),
					AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString())
				};
			}

			Db.Close();
			return Tmp;
		}

		public static void Save(Category category)
		{
			// יצירת חיבור למסד הנתונים
			DbContext Db = new DbContext();


			
			string Sql;
		// הגדרת השאילתא לביצוע השמירה או העדכון
			if (category.Cid == -1)
			{
				Sql = "INSERT INTO T_Category (Cname, Cdesc, Picname, ParentCid, Status) " +
					  "VALUES (@Cname, @Cdesc, @Picname, @ParentCid,  @Status);" +
					  "SELECT SCOPE_IDENTITY();";
			}
			else
			{
				Sql = "UPDATE T_Category SET " +
					  "Cname = @Cname, " +
					  "Cdesc = @Cdesc, " +
					  "Picname = @Picname, " +
					  "ParentCid = @ParentCid, " +
					  "Status = @Status " +
					  "WHERE Cid = @Cid";
			}
			// ביצוע השאילתה על ידי קריאה למתודת ExecuteNonQuery 
			using (SqlCommand cmd = new SqlCommand(Sql, Db.Conn))
			{
				// הגדרת פרמטרים והוספתם לפקודה
				cmd.Parameters.AddWithValue("@Cname", category.Cname);
				cmd.Parameters.AddWithValue("@Cdesc", category.Cdesc);
				cmd.Parameters.AddWithValue("@Picname", category.Picname);
				cmd.Parameters.AddWithValue("@ParentCid", category.ParentCid);
				cmd.Parameters.AddWithValue("@Status", category.Status);

				if (category.Cid > 0)
				{
					// אם ה-Cid של הקטגוריה קיים כבר,
					// נפעיל את השאילתה עדכון על מנת לעדכן את הרשומה					
					cmd.Parameters.AddWithValue("@Cid", category.Cid);
					cmd.ExecuteNonQuery();
				}
				else
				{
				
					category.Cid = Convert.ToInt32(cmd.ExecuteScalar());
				}
			}

			Db.Close();
		}
	}
}
