using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
	public partial class Login1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnLogin_Click(object sender, EventArgs e)
		{
			List<Client> LstClient = (List<Client>)Application["Clients"];///הגדרת רשימה עבור לקוחות

			string Email = TxtEmail.Text;
			string Password = TxtPassword.Text;
			for (int i = 0; i < LstClient.Count; i++)
			{
				Console.WriteLine(LstClient[i].ClientMail);
				Console.WriteLine(LstClient[i].ClientPassword);
				if (LstClient[i].ClientMail == Email && LstClient[i].ClientPassword == Password)//מציאת שם משתמש וסיסמא
				{
					///ניצור משתנה מסוג סשן
					Session["Login"] = LstClient[i];
					Response.Redirect("AdminManager/CatAddEdit.aspx");
				}
			}
			LtlMsg.Text = "שם וסיסמא אינם תקינים";
		}
	}
}