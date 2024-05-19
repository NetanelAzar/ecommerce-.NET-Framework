﻿using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.AdminManager
{
	public partial class CatAddEdit : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string Cid = Request["Cid"] + "";
				if (string.IsNullOrEmpty(Cid))
				{
					Cid = "-1";
				}
				else
				{
					int cid = int.Parse(Cid);//המרה של המשתנה למספר שלם , לצורך חיפוש במאגר
					List<Category> LstCategory = (List<Category>)Application["Categories"];

					for (int i = 0; i < LstCategory.Count; i++)
					{
						if (LstCategory[i].Cid == cid)
						{
							TxtCname.Text = LstCategory[i].Cname;
							TxtParentCid.Text = LstCategory[i].ParentCid + "";
							TxtCdesc.Text = LstCategory[i].Cdesc;
							TxtCPicname.Text = LstCategory[i].Picname;
							HidCid.Value = Cid;
						}
					}
				}
			}
		}

        protected void BtnSave_Click(object sender, EventArgs e)
        {

			string Sql = "";
			if (HidCid.Value == "-1")//הוספת מוצר חדש
			{
				Sql = "INSERT INTO T_Category (Cname, ParentCid, Cdesc, Picname) VALUES";
				Sql += $" N'{TxtCname.Text}',{TxtParentCid.Text} ,N'{TxtCdesc.Text}',N'{TxtCPicname.Text}'";
			}
			else///עדכון מוצר
			{
				Sql = " UPDATE T_Category SET ";
				Sql += $" Cname=N'{TxtCname.Text}',";
				Sql += $" ParentCid=N'{TxtParentCid.Text}',";
				Sql += $" Cdesc=N'{TxtCdesc.Text}',";
				Sql += $" Picname=N'{TxtCPicname.Text}' ";
				Sql += $" WHERE  Cid={HidCid.Value}";
			}







			//שליפת מחרוזת התתחברות מתוך קובץ הגדרות האפליקציה / שרת
			string Connstr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
			SqlConnection Conn = new SqlConnection(Connstr);
			Conn.Open();//פתיחת הצינור לבסיס הנתונים

			SqlCommand Cmd = new SqlCommand(Sql, Conn);
			Cmd.ExecuteNonQuery();//הפעלת השאילתה שלא מחזירה נתונים

			List<Category> LstCategory = new List<Category>();
			Sql = "SELECT * FROM T_Category";
			Cmd.CommandText = Sql;



			SqlDataReader Dr = Cmd.ExecuteReader();// קבלת תוצאות השאילתה לתוך אובייקט קורא נתנוים

			while (Dr.Read())
			{
				Category Cat = new Category()
				{
					Cid = int.Parse(Dr["Cid"] + ""),
					Cname = Dr["Cname"] + "",
					Cdesc = Dr["Cdesc"] + "",
					Picname = Dr["Picname"] + "",
					ParentCid = int.Parse(Dr["ParentCid"] + ""),


				};
				LstCategory.Add(Cat);
			}
			Conn.Close();
			Application["Categories"] = LstCategory;
			Response.Redirect("CategoryList.aspx");


		}
	}
}