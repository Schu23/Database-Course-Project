using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //27
            /*string[,] items = DBModel.sharedDBModel().topFiveItems();

            for(int i = 0; i < 5; i++ )
            {
                System.Diagnostics.Debug.WriteLine("itemName:" + items[i, 0]);
                System.Diagnostics.Debug.WriteLine("itemOther:" + items[i, 1]);
                System.Diagnostics.Debug.WriteLine("itemImage:" + items[i, 2]);
            }*/

            //28
            /*decimal[] prices = DBModel.sharedDBModel().getEverySumOfThisMonth();

            foreach (var i in prices)
            {
                System.Diagnostics.Debug.WriteLine("28price:" + i);
            }*/

            //29
            /*item[] allItems = DBModel.sharedDBModel().getAllItemsOfThisShop("");
            foreach (var i in allItems)
            {
                System.Diagnostics.Debug.WriteLine("29item:" + i.itemDate);
            }*/

        }
        protected void returnBack (object sender , EventArgs e)
        {
            string returnURL = Session["returnURL"].ToString();
            Session.Remove("returnURL");
            Session.Remove("errorMessage");

            Response.Redirect(returnURL);
        }
    }
}