using System;
using System.Collections.Generic;
using System.Data;
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
			DbContext Db = new DbContext();
			string Sql;

			if (category.Cid == 0)
			{
				Sql = $"INSERT INTO T_Category (Cname, Cdesc, Picname, ParentCid, AddDate, Status) " +
					  $"VALUES ('{category.Cname}', '{category.Cdesc}', '{category.Picname}', {category.ParentCid}, '{category.AddDate}', {category.Status})";
			}
			else
			{
				Sql = $"UPDATE T_Category SET " +
					  $"Cname = '{category.Cname}', " +
					  $"Cdesc = '{category.Cdesc}', " +
					  $"Picname = '{category.Picname}', " +
					  $"ParentCid = {category.ParentCid}, " +
					  $"AddDate = '{category.AddDate}', " +
					  $"Status = {category.Status} " +
					  $"WHERE Cid = {category.Cid}";
			}

			Db.Execute(Sql);
			Db.Close();
		}
	}
}
