using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
	public partial class ProductsList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack) 
			{
				///לשלוף את רישמת המוצרים מתוך האפליקשיין 
				//לקשר את רשימת המוצרים לפקד ההרפיטר
				//נבצע קשירה של הנתונים לפקד הרפיטר באמצעות ההאפליקצייה 
				List<Product> LstProd;
				LstProd =(List<Product>) Application["Products"];

				//קישור רשימת מוצרים עם הרפיטר 
				RptProducts.DataSource = LstProd;
				// עבור כל פריט במקור הנתנוים יתבצע שכפול אייטם טמפלייט של הרפיטר
				RptProducts.DataBind();//קשירת הנתונים לרפיטר
			}

		}
	}
}