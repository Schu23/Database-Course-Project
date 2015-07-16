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
            //bool test = DBModel.sharedDBModel().addInDetailToInWithItemIdAndItemAmount("inBase_9118795447", "item_875412", 2);
            	
            //for(int i = 0; i < test.Length; i++) {
              //  System.Diagnostics.Debug.WriteLine("test:" + test);

            //}
            
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