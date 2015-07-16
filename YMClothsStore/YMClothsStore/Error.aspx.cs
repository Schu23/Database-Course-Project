using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace YMClothsStore
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool succeed = DBModel.sharedDBModel().addOrderDetailToOrderWithOrderIdAndItemIdAndItemAmount("order_677740", "item_1436972475", 2);
                        	
            System.Diagnostics.Debug.WriteLine("Succeed:" + succeed);
        }
        protected void returnBack (object sender , EventArgs e)
        {
            string returnURL = Session["returnURL"].ToString();
            Session.Remove("returnURL");
            Session.Remove("errorMessage");

            Response.Redirect(returnURL);
        }
    }
}