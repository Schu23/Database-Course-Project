using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Boss_shopInfo : System.Web.UI.Page
    {
        protected staff theStaff;
        protected shop[] allShop;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            allShop = DBModel.sharedDBModel().getAllShop();

        }
        protected void closeShop(object sender, EventArgs e)
        {
            string closeId = Request.Params["close"];
            shop temp = DBModel.sharedDBModel().findShopByShopId(closeId);
            if (temp != null)
            {
                if(DBModel.sharedDBModel().modifyShopInfo(temp.shopId,temp.shopAddress,0,temp.shopPhone))
                {
                    System.Diagnostics.Debug.WriteLine("success!");
                    Response.Redirect("Boss_shopInfo.aspx");
                }
                else
                {
                    Session["errorMessage"] = "关店失败";
                    Session["returnURL"] = "Boss_shopInfo.aspx";
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Session["errorMessage"] = "店不存在，请仔细检查";
                Session["returnURL"] = "Boss_shopInfo.aspx";
                Response.Redirect("Error.aspx");
            }

        }
    }
}