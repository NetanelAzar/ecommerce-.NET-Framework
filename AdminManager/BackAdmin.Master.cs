using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.AdminManager
{
	public partial class BackAdmin : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["login"] == null)
			{
				Response.Redirect("/login.aspx");
			}
		}
	}
}