using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Boss_OutBaseTable : System.Web.UI.Page
    {
        protected staff theStaff;
        protected outBase[] searchResult;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            searchResult = DBModel.sharedDBModel().getAllOutBaseInfoByStaffId(theStaff.staffId);
        }
        protected void Search_OutBase(object sender, EventArgs e)
        {
            string searchKey = Request.Form["searchKey"];
            searchResult = DBModel.sharedDBModel().getOutBaseInfoByOutBaseId(searchKey);
        }
    }
}