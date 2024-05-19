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
	public partial class CategoryList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{



			if (!IsPostBack)
			{
				///חיבור מאגר המוצרים לרפיטר
				List<Category> LstCategory = (List<Category>) Application["Categories"];
				RptCat.DataSource = LstCategory;
				RptCat.DataBind();
			}
		}
	}
}