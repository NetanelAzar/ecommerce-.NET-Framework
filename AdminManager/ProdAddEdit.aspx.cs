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
					Product Tmp= Product.GetById(pid);
					if (Tmp != null)
					{
						TxtPname.Text = Tmp.Pname;
						TxtPrice.Text = Tmp.Price + "";
						TxtPdesc.Text = Tmp.Pdesc;
						ImgPicname.ImageUrl = "/uploads/prods/" + Tmp.Picname;
						HidPid.Value = Pid;
					}
					else
					{
						Pid = "-1";
					}
				}
			}
		}

		protected void BtnSave_Click(object sender, EventArgs e)
		{
			string Picname = "";
			//נבדטק האם נבחקר קובץ תמונה
			if(UploadPic.HasFile)
			{
				//נשמור תחת שם שאנחנו בוחרים באקראי
				Picname = GlobFunk.GetRandStr(8);

				string OriginalFileName = UploadPic.FileName;
				string Ext = OriginalFileName.Substring(OriginalFileName.LastIndexOf('.'));//מהנקודה האחרונה עד הסוף
				Picname+= Ext;//השם המלר של הקובץ אחרי ההשינוי
				string FullPath=Server.MapPath("/uploads/prods/");
				UploadPic.SaveAs(FullPath + Picname);

			}
			else 
			{
				Picname = ImgPicname.ImageUrl.Substring(ImgPicname.ImageUrl.LastIndexOf('/')+1);
			}







            Product product = new Product
            {
               Pid = int.Parse(HidPid.Value),
               Pname = TxtPname.Text,
               Price = float.Parse(TxtPrice.Text),
               Pdesc = TxtPdesc.Text,
               Picname = Picname
            };

                product.Save();

            List<Product> LstProd = Product.GetAll();
            Application["Products"] = LstProd;

            Response.Redirect("ProductsList.aspx");
		}
	}
}