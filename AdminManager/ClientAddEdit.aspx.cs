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
	public partial class ClientAddEdit : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string ClientID = Request["ClientID"] + "";
				if (string.IsNullOrEmpty(ClientID))
				{
					ClientID = "-1";
				}
				else
				{
					int clientID = int.Parse(ClientID);//המרה של המשתנה למספר שלם , לצורך חיפוש במאגר
					Client Tmp = Client.GetById(clientID);
					if (Tmp != null)
					{
						TxtFirstName.Text = Tmp.ClientName;
						TxtLastName.Text = Tmp.ClientLastname;
						TxtAddress.Text = Tmp.Address;
						TxtPhone.Text = Tmp.ClientPhone;
						TxtMail.Text = Tmp.ClientMail;
						TetCityCode.Text = Tmp.CityCode;
						TxtPassword.Text = Tmp.ClientPassword;
						ImgPicname.ImageUrl = "/uploads/prods/" + Tmp.Picname;
						HidClient.Value = ClientID;
					}
					else
					{
						ClientID = "-1";
					}

				}
			}
		}

	

	  protected void BtnSave_Click(object sender, EventArgs e)
		{ 
        
			string Picname = "";
			//נבדטק האם נבחקר קובץ תמונה
			if (UploadPic.HasFile)
			{
				//נשמור תחת שם שאנחנו בוחרים באקראי
				Picname = GlobFunk.GetRandStr(8);

				string OriginalFileName = UploadPic.FileName;
				string Ext = OriginalFileName.Substring(OriginalFileName.LastIndexOf('.'));//מהנקודה האחרונה עד הסוף
				Picname += Ext;//השם המלר של הקובץ אחרי ההשינוי
				string FullPath = Server.MapPath("/uploads/prods/");
				UploadPic.SaveAs(FullPath + Picname);

			}
			else
			{
				Picname = ImgPicname.ImageUrl.Substring(ImgPicname.ImageUrl.LastIndexOf('/') + 1);
			}







			
	     	Client client = new Client
		    {
			    ClientID = int.Parse(HidClient.Value),
			    ClientName = TxtFirstName.Text,
				ClientLastname = TxtLastName.Text,
				Address = TxtAddress.Text,
				ClientPhone = TxtPhone.Text,
				 ClientMail = TxtMail.Text,
				 CityCode = TetCityCode.Text,
				 ClientPassword = TxtPassword.Text,
				Picname = Picname
			};

		     client.Save();

			List<Client> LstClient = Client.GetAll();
			Application["Clients"] = LstClient;

			Response.Redirect("ClientList.aspx");


		}
	}
}