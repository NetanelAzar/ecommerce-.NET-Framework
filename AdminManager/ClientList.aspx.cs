using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.AdminManager
{
	public partial class ClientList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			///חיבור מאגר המוצרים לרפיטר
			List<Client> LstClient = (List<Client>)Application["Clients"];
			RptClient.DataSource = LstClient;
			RptClient.DataBind();
		}
	}
}