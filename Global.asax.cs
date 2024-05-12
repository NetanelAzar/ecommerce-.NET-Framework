using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;///
using System.Data.SqlClient;///בשביל האובייקטים לעבודה מול בסיס הנתנוים 
namespace Ecommerce
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			List<Product> LstProd=new List<Product>();//יצירת רשימה של מוצרים
			Product P;
			string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EcommerceDB.mdf;Integrated Security=True;Connect Timeout=30";
			SqlConnection Conn = new SqlConnection(Connstr);
			Conn.Open();//פתיחת הצינור לבסיס הנתונים
			string Sql = "SELECT * FROM T_Product";
			SqlCommand Cmd = new SqlCommand(Sql, Conn);
			SqlDataReader Dr = null;
			Dr=Cmd.ExecuteReader();// קבלת תוצאות השאילתה לתוך אובייקט קורא נתנוים
			while (Dr.Read())
			{
				P = new Product()
				{
					Pid = int.Parse(Dr["Pid"]+""),
					Pname = Dr["Pname"]+"",
					Price=float.Parse( Dr["Price"]+""),
					Pdesc = Dr["Pdesc"]+"",
					Picname = Dr["Picname"]+"",
					Cid = int.Parse( Dr["Cid"]+""),
					AddDate = DateTime.Parse(Dr["AddDate"]+""),

				};
				LstProd.Add(P);
			}
			Application["Products"]=LstProd;


			List<Category> LstCategory = new List<Category>();
			Category Cat;

			string SqlCat = "SELECT * FROM T_Category";
			SqlCommand CmdCat = new SqlCommand(SqlCat, Conn);
			while (Dr.Read())
			{
				Cat = new Category()
				{
					Cid = int.Parse(Dr["Cid"]+""),
					Cname= Dr["Cname"]+"",
					Cdesc= Dr["Cdesc"]+"",
					Picname = Dr["Picname"]+"",
					ParentCid = int.Parse(Dr["ParentCid"]+""),
					AddDate= DateTime.Parse(Dr["AddDate"]+""),

				};
				LstCategory.Add(Cat);
			}
			Application["Categories"] = LstCategory;





			List<City> LstCity = new List<City>();///הגדרת רשימה עבור לקוחות
			City Cty;

			Cty = new City()
			{
				CityCode = "10",
				CityName = "אשקלון"
			};
			LstCity.Add(Cty);

			Cty = new City()
			{
				CityCode = "20",
				CityName = "תל אביב"
			};
			LstCity.Add(Cty);

			Cty = new City()
			{
				CityCode = "30",
				CityName = "אשדוד"
			};
			LstCity.Add(Cty);

			Application["Cities"] = LstCity;








			Conn.Close();//סגירת הצינור לבסיס הנתונים		
		}
		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}