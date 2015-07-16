using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class ManagerIndex : System.Web.UI.Page
    {
        protected staff theStaff;
        protected order[] getStaffOrder = new order[5];
        protected decimal[] orderMonthChart = null;
        protected string[,] hotItems = null; 
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            order[] getAllStaffOrder = DBModel.sharedDBModel().getAllOrderInfo(theStaff.staffId);
            for (int i = 0; i < 5; i++)
            {
                getStaffOrder[i] = getAllStaffOrder[i];
            }
            orderMonthChart = DBModel.sharedDBModel().getEverySumOfThisMonth(theStaff.staffId);
            hotItems = DBModel.sharedDBModel().topFiveItems(theStaff.staffId);
            System.Diagnostics.Debug.WriteLine("size of the hotItems:" + hotItems.GetLength(0));
        }
    }
}