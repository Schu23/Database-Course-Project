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
            if(DBModel.sharedDBModel().addNewShop(managerID, branchAddress, shopPhone).Equals("false"))
            {
                System.Diagnostics.Debug.WriteLine("新建分店失败");
                Session["errorMessage"] = "新建分店失败";
                Session["returnURL"] = "BranchChange.aspx";
                Response.Redirect("Error.aspx");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("add new branch success");
            }
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