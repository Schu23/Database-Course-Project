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
            //32
            checkDetail[] ckecks = DBModel.sharedDBModel().getCheckDetailInfoWithStaffId("staff_1436923452");
            foreach (var i in ckecks)
            {
                System.Diagnostics.Debug.WriteLine("29item:" + i.itemId);
            }
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