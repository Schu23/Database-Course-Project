using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Staff_clothesInfo : System.Web.UI.Page
    {

        protected staff theStaff;
        protected item[] searchResult;


        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            searchResult = DBModel.sharedDBModel().getAllItemsOfThisShop(theStaff.staffId);
        }

        protected void SerachSubmit(object sender , EventArgs e)
        {
            string condition = Request.Form["searchCondition"];
            string serachKey = Request.Form["searchKey"];
            System.Diagnostics.Debug.WriteLine("serach key and serach condition test :" + serachKey + condition);

            if(condition.Equals("staffName"))
            {
               searchResult = DBModel.sharedDBModel().getItemByItemName(serachKey);
            }
            else
                searchResult = DBModel.sharedDBModel().getItemByItemId(serachKey);
        }
    }
}