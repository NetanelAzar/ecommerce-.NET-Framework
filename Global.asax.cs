using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;///
using System.Data.SqlClient;///בשביל האובייקטים לעבודה מול בסיס הנתנוים 
using System.Configuration;
using DATA;
namespace Ecommerce
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{


		



			Application["Products"] = Product.GetAll();


			List<Client> LstClient = new List<Client>();//הגדרת רשימה עבור לקוחות
	     	string Sql = "SELECT * FROM T_Client"; // שאילתה
			string ConnStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
			SqlConnection Conn = new SqlConnection(ConnStr);
			Conn.Open();//פתיחת הצינור לבסיס הנתונים
			SqlCommand Cmd = new SqlCommand(Sql, Conn);
			SqlDataReader Dr = Cmd.ExecuteReader();


			Client Tmp;
			Tmp = new Client()
			{
				ClientMail = "netanelazar880@gmail.com",
				ClientPassword = "12345",
				ClientID = 3,
				ClientName = "netanel",
				ClientLastname = "azar",
			};

			LstClient.Add(Tmp);
			Dr.Close();
			Application["Clients"] = LstClient;//









			/*			List<Category> LstCategory = new List<Category>();
			List<Client> LstClient = new List<Client>();//הגדרת רשימה עבור לקוחות*/







			/*

			Product P;
			//שליפת מחרוזת התתחברות מתוך קובץ הגדרות האפליקציה / שרת
			string Connstr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
			SqlConnection Conn = new SqlConnection(Connstr);
			string Sql = "SELECT * FROM T_Product";
			Conn.Open();//פתיחת הצינור לבסיס הנתונים

			SqlCommand Cmd = new SqlCommand(Sql, Conn);
			SqlDataReader Dr = Cmd.ExecuteReader();// קבלת תוצאות השאילתה לתוך אובייקט קורא נתנוים;
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
			Dr.Close();
			Application["Products"]=LstProd;



			Category Cat;

			Sql = "SELECT * FROM T_Category"; // שאילתה
			Cmd = new SqlCommand(Sql, Conn);
			Dr = Cmd.ExecuteReader();
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



	



			Sql = "SELECT * FROM T_Client"; // שאילתה
			Cmd = new SqlCommand(Sql, Conn);
			Dr = Cmd.ExecuteReader();


			Client Tmp;
			Tmp = new Client()
			{
				ClientMail = "daniel21@gmail.com",
				ClientPassword = "2323",
				ClientID = 3,
				ClientName = "daniel",
				ClientLastname = "gamliel",
				ClientAddress = "gedera"
			};
		
			LstClient.Add(Tmp);
			Application["Clients"] = LstClient;//





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
					*/
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