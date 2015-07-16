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
            item aItem = DBModel.sharedDBModel().addItemByBoss("学霸", "xlxlxlx", "hihihihi", (float)0.2);
            //bool succeed = DBModel.sharedDBModel().deletdShopByShopId("shop_1436970733");
            	
            System.Diagnostics.Debug.WriteLine("Succeed:" + aItem.itemDate);

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