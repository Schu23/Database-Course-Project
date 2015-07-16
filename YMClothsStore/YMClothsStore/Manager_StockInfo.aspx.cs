using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Manager_StockInfo : System.Web.UI.Page
    {
        protected staff theStaff;
        protected item[] searchResult;
        protected stock[] thisStock = new stock[100];

        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            searchResult = DBModel.sharedDBModel().getAllItemsOfThisShop(theStaff.staffId);
            for (int i = 0; i < searchResult.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine("test debug shopid and item id  :: " + theStaff.shopId + searchResult[i].itemId);
                thisStock[i]= DBModel.sharedDBModel().getItemStockInThisShop(theStaff.staffId, searchResult[i].itemId);  
            }
            System.Diagnostics.Debug.WriteLine("stock debug :" + thisStock.Length);
        }

        protected void SerachSubmit(object sender, EventArgs e)
        {

            //getItemStockInThisShop
            string condition = Request.Form["searchCondition"];
            string serachKey = Request.Form["searchKey"];
            System.Diagnostics.Debug.WriteLine("serach key and serach condition test :" + serachKey + condition);

            if (condition.Equals("staffName"))
            {
                searchResult = DBModel.sharedDBModel().getItemByItemName(serachKey);
            }
            else
                searchResult = DBModel.sharedDBModel().getItemByItemId(serachKey);

            for(int i = 0; i < searchResult.Length; i ++)
            {
                stock x = DBModel.sharedDBModel().getItemStockInThisShop(theStaff.staffId, searchResult[i].itemId);
                thisStock[i] = x; 
            }

        }
    }
}