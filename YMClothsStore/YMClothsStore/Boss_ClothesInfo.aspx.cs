using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Boss_ClothesInfo : System.Web.UI.Page
    {
        protected staff theStaff;
        protected item[] searchResult;
        protected string getItemImagePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            searchResult = DBModel.sharedDBModel().getAllItems();
        }
        protected void SearchByItemId(string id )
        {
            searchResult = DBModel.sharedDBModel().getItemByItemId(id);
        }
        protected void SearchByItemName(string name)
        {
            searchResult = DBModel.sharedDBModel().getItemByItemName(name);
        }
        protected void showIamgeByItemId(object sender, EventArgs e)
        {
            string searchKey = Request.Form[""];
            getItemImagePath = DBModel.sharedDBModel().getImagePathWithItemId(searchKey);
        }

        protected void SearchItem(object sender, EventArgs e)
        {
            string option = Request.Form["searchCondition"];
            string value = Request.Form["searchKey"];
            System.Diagnostics.Debug.WriteLine("option is:" + option);
            if (option.Equals("itemId"))
            {
                SearchByItemId(value);
            }
            else
            {
                SearchByItemName(value);
            }
           

        }
    }
}