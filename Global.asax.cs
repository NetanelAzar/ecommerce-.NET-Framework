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
using DAL;
namespace Ecommerce
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{


		



			Application["Products"] = Product.GetAll();
			Application["Categories"] = CategoryDAL.GetAll();
			Application["Clients"] = ClientDAL.GetAll();
			Application["Cities"] = CityDAL.GetAll();






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