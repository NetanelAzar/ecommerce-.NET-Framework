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
	public partial class CatAddEdit : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string Cid = Request["Cid"] + "";
				if (string.IsNullOrEmpty(Cid))
				{
					Cid = "-1";
				}
				else
				{
					int cid = int.Parse(Cid);//המרה של המשתנה למספר שלם , לצורך חיפוש במאגר
					Category Tmp=Category.GetById(cid);
						if (Tmp!=null)
						{
							TxtCname.Text = Tmp.Cname;
							TxtParentCid.Text = Tmp.ParentCid + "";
							TxtCdesc.Text = Tmp.Cdesc;
							ImgPicname.ImageUrl = "/uploads/prods/" + Tmp.Picname;
							HidCid.Value = Cid;
						}
						else
						{
							Cid = "-1";
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








			Category category = new Category
			{
				Cid = int.Parse(HidCid.Value),
				Cname = TxtCname.Text,
				ParentCid = int.Parse(TxtParentCid.Text),
				Cdesc = TxtCdesc.Text,
				Picname = Picname
			};

			category.Save();

			List<Category> LstCategory = Category.GetAll();
			Application["Categories"] = LstCategory;

			Response.Redirect("CategoryList.aspx");



		}
	}
}