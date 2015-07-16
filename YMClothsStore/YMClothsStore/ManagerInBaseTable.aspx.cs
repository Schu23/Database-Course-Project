using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class ManagerInBaseTable : System.Web.UI.Page
    {
        protected staff theStaff;
        protected inBase[] searchResult;
        protected inDetail[] getInBaseDetail;
        protected string inBaseId;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            searchResult = DBModel.sharedDBModel().getAllinBaseInfoByStaffId(theStaff.staffId);
        }
        protected void Search_InBase(object sender, EventArgs e)
        {
            string searchKey = Request.Form["searchKey"];
         //   searchResult = DBModel.sharedDBModel().geti
        }
        protected void SearchDetailOrder(object sender, EventArgs e)
        {
            inBaseId = Request.Form[""];
        }
    }
}