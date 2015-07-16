using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Boss_AddAddress : System.Web.UI.Page
    {

        staff theStaff;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
        }
        protected void addNewAddress(object sender, EventArgs e)
        {
            string addressName = Request.Form["addressName"];
            string addressDetail = Request.Form["addressDetail"];
            address temp = DBModel.sharedDBModel().addNewAddress(addressName, addressDetail);
            if (temp !=null)
            {
                System.Diagnostics.Debug.WriteLine("address  success");
                Response.Redirect("Boss_AddAddress.aspx");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("address  failed");
                Session["errorMessage"] = "添加新地址失败，请检查你的权限和网络";
                Session["returnURL"] = "Boss_AddAddres.aspx";
                Response.Redirect("Error.aspx");
            }
        }
    }
}