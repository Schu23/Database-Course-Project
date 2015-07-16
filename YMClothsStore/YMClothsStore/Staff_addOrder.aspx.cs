using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Staff_addOrder : System.Web.UI.Page
    {
        protected item[] items;
        protected staff theStaff;
        protected string [] itemAmount = new string [5] ;
        protected string[] itemId = new string[5];
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            items = DBModel.sharedDBModel().getAllItemsOfThisShop(theStaff.staffId);
        }
        protected void Add_NewOrder(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine( "i am at here !! now ! ");
            itemId[0] =Request.Form["clothes_id_1"];
            itemId[1] =Request.Form["clothes_id_2"];
            itemId[2] =Request.Form["clothes_id_3"];
            itemId[3] =Request.Form["clothes_id_4"];
            itemId[4] =Request.Form["clothes_id_5"];
            itemAmount[0] = Request.Form["clothes_amount_1"];
            itemAmount[1] = Request.Form["clothes_amount_2"];
            itemAmount[2] = Request.Form["clothes_amount_3"];
            itemAmount[3] = Request.Form["clothes_amount_4"];
            itemAmount[4] = Request.Form["clothes_amount_5"];
             order newOrder =  DBModel.sharedDBModel().addOrderInfo(theStaff.staffId);
             if (newOrder.orderId != null)
             {
                 for (int i = 0; i < 5; i++)
                 {
                     System.Diagnostics.Debug.WriteLine("debug get the item id :" + itemId[i] + "and amount :" + itemAmount[i]);
                     if (itemId[i] != null && itemAmount[i]!=null)
                     {
                         if (DBModel.sharedDBModel().addOrderDetailToOrderWithOrderIdAndItemIdAndItemAmount(newOrder.orderId, itemId[i], int.Parse(itemAmount[i])))
                         {
                             Response.Redirect("Staff_addOrder.aspx");
                         }
                         else
                             Response.Redirect("Error.aspx");
                     }
                 }
             }
            
        }
    }
}