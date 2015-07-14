using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class BranchChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // 新增分店 
        protected void addNewBrach (object sender, EventArgs e)
        {
            string managerID = Request.Form["managerId"];
            string branchAddress = Request.Form["BrachAddress"];
            string shopPhone = Request.Form["ShopPhone"];
            DBModel.sharedDBModel().addNewShop(managerID, branchAddress, shopPhone);
        }
        //删除分店
        protected void deleteBranch (object sender , EventArgs e)
        {
            string deleteShopId = Request.Form["DeleteId"];
            DBModel.sharedDBModel().deletdShop("ddd");

        }
     // protected void m
    }
}