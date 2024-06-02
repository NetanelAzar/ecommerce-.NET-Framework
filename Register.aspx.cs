using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsCallback)
			{
				List<City> LstCity = (List<City>)Application["Cities"];

				for (int i = 0; i < LstCity.Count; i++)
				{
					DDLCity.Items.Add(new ListItem(LstCity[i].CityName, LstCity[i].CityCode + ""));
				}

				DDLCity.DataSource = LstCity;//הגדרת מקור הנתנונים
				DDLCity.DataTextField = "CityName";//הגדרת השדה שישמש עבור התצוגה
				DDLCity.DataValueField = "CityCode";//הגדרת השדה שישמש  עבוא המפתח של הפריט

				DDLCity.DataBind();// הכנסת החיבור למקור הנתנונים לפעולה

			}

		}

		protected void BtnReg_Click(object sender, EventArgs e)
		{




			List<Client> LstClient = (List<Client>)Application["Clients"];
			if (LstClient == null) LstClient = new List<Client>(); // השתמש ברשימת הלקוחות הקיימת או צור רשימה חדשה אם היא לא קיימת

			Client Tmp;
			Tmp = new Client()
			{

				ClientName = $"{TxtFullname.Text}",
				ClientLastname = $"{TxtLastName.Text}",
				Address = $"{TxtAdd.Text}",
				CityCode = $"{DDLCity.SelectedValue}",
				ClientPhone = $"{TxtPhone.Text}",
				ClientMail = $"{TxtMail.Text}",
				ClientPassword = $"{TxtPass.Text}",

			};

			bool validPassword = Tmp.ClientPassword.Length >= 6; // בודק  אם הסיסמא תקינה
			bool emailExists = Tmp.ClientMail == TxtMail.Text; // בודק אם כתובת האימייל כבר קיימת במערכת

			if (!validPassword)
			{
				LtlPassMsg.Text = "סיסמא חייבת להיות לפחות באורך 6 תווים";
			}
			else if (emailExists)
			{
				MailMsg.Text = "כתובת האימייל כבר קיימת במערכת";
			}
			else
			{
				LstClient.Add(Tmp); // הוסף לקוח לרשימה
				Application["Clients"] = LstClient; // שמור את רשימת הלקוחות באפליקציה
				Session["Login"] = Tmp; // התחבר למערכת כלקוח הנוכחי
				Response.Redirect("ProductsList.aspx");
			}
		}

	}


}
