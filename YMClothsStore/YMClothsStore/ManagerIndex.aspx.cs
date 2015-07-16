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
        protected order[] getStaffOrder = { };
        protected decimal[] orderMonthChart = null;
        protected string[,] hotItems = null; 
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];

            getStaffOrder = DBModel.sharedDBModel().getAllOrderInfo(theStaff.staffId);
            orderMonthChart = DBModel.sharedDBModel().getEverySumOfThisMonth(theStaff.staffId);
            hotItems = DBModel.sharedDBModel().topFiveItems(theStaff.staffId);
        }
    }
}