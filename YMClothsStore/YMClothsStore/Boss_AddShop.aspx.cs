using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Boss_AddShop : System.Web.UI.Page
    {
        protected staff theStaff;
        protected address[] addresses;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            addresses = DBModel.sharedDBModel().getAllAddressInfo();
        }
        protected void Submit_Click(object sender ,EventArgs e)
        {
            string address = addresses[0].addressName;
            string manager = Request.Form["staffId"];
            string phone = Request.Form["shopPhone"];
            shop temp = DBModel.sharedDBModel().addNewShopWithManagerIdAndAddressIdAndShopPhone(manager,address,phone);
            if (temp != null)
            {
                System.Diagnostics.Debug.WriteLine("address  success");
                Response.Redirect("Boss_AddShop.aspx");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("address  failed");
                Session["errorMessage"] = "添加分店失败，请检查你的权限和网络";
                Session["returnURL"] = "Boss_AddAddres.aspx";
                Response.Redirect("Error.aspx");
            }
        }
    }
}