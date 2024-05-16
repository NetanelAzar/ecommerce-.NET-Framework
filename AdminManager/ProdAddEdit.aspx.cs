using BLL;
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
	public partial class ProdAddEdit : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string Pid = Request["Pid"] + "";
				if (string.IsNullOrEmpty(Pid))
				{
					Pid = "-1";
				}
				else
				{ 
					int pid=int.Parse(Pid);//המרה של המשתנה למספר שלם , לצורך חיפוש במאגר
					List<Product> LstProd = (List<Product>)Application["Products"];
					for (int i = 0; i < LstProd.Count; i++) 
					{
						if (LstProd[i].Pid == pid) 
						{
							TxtPname.Text = LstProd[i].Pname;
							TxtPrice.Text=LstProd[i].Price+"";
							TxtPdesc.Text = LstProd[i].Pdesc;
							TxtPicname.Text = LstProd[i].Picname;
							HidPid.Value=Pid;
						}
					}
				}
			}
		}

		protected void BtnSave_Click(object sender, EventArgs e)
		{
			string Sql = "";
			if (HidPid.Value == "-1")//הוספת מוצר חדש
			{
				Sql = "insert into T_Product (Pname, Price, Pdesc, Picname) values";
				Sql += $" N'{TxtPname.Text}',{TxtPrice.Text} ,N'{TxtPdesc.Text}',N'{TxtPicname.Text}'";
			}
			else///עדכון מוצר
			{
				Sql = " Update T_Product set ";
				Sql += $" Pname=N'{TxtPname.Text}',";
				Sql += $" Price=N'{TxtPrice.Text}',";
				Sql += $" Pdesc=N'{TxtPdesc.Text}',";
				Sql += $" Picname=N'{TxtPicname.Text}' ";
				Sql += $" where Pid={HidPid.Value}";
			}


			//שליפת מחרוזת התתחברות מתוך קובץ הגדרות האפליקציה / שרת
			string Connstr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
			SqlConnection Conn = new SqlConnection(Connstr);
			Conn.Open();//פתיחת הצינור לבסיס הנתונים

			SqlCommand Cmd = new SqlCommand(Sql, Conn);
			Cmd.ExecuteNonQuery();//הפעלת השאילתה שלא מחזירה נתונים

			///טעינה מחודשת של רשימת המוצרים אל האפליקישיין
			List<Product> LstProd = new List<Product>();
			Sql = "select * from T_Product";
			Cmd.CommandText=Sql;


			SqlDataReader Dr = Cmd.ExecuteReader();// קבלת תוצאות השאילתה לתוך אובייקט קורא נתנוים

			while (Dr.Read())
			{
				Product P = new Product()
				{

					Pid = int.Parse(Dr["Pid"] + ""),
					Pname = Dr["Pname"] + "",
					Price = float.Parse(Dr["Price"] + ""),
					Pdesc = Dr["Pdesc"] + "",
					Picname = Dr["Picname"] + "",



				};

				LstProd.Add(P);
			}
			
			Conn.Close();
			Application["Products"] = LstProd;
			Response.Redirect("ProductsList.aspx");
		}
	}
}