using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Manager_ApplyPage : System.Web.UI.Page
    {
        protected apply applyResult ;
        protected staff theStaff;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff =(staff) Session["Staff"];
        }
        protected void addStock_Submit(object sender, EventArgs e)
        {
            string shopId = Request.Form["shopid"];
            string itemId = Request.Form["clothesId"];
            string itemAmount = Request.Form["amount"];
            //int itemAmount = Convert.ToInt32(itemAmount);
            System.Diagnostics.Debug.WriteLine(shopId + itemId + itemAmount);
            applyResult = DBModel.sharedDBModel().addApplyFromOtherShop(theStaff.staffId,shopId);
            if (applyResult != null)
            {
                if (DBModel.sharedDBModel().addApplyDetailInfoFromOtherShopWithApplyIdItemIdAndItemAmount(theStaff.staffId,applyResult.applyId, itemId, int.Parse(itemAmount)))
                {
                    System.Diagnostics.Debug.WriteLine("diao huo chenggong ");
                    Response.Redirect("Manager_StockInfo.aspx");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("diaohuo shi bai ");
                    Session["errorMessage"] = "从分店调货失败，对方的库存已经不足";
                    Session["returnURL"] = "Manager_AddStockPage.aspx";
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("diaohuo shi bai ");
                Session["errorMessage"] = "从分店调货失败，对方的库存已经不足";
                Session["returnURL"] = "Manager_AddStockPage.aspx";
                Response.Redirect("Error.aspx");
            }
        }
    }
}