using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Staff_OrderInfo : System.Web.UI.Page
    {
      protected  staff theStaff;
      protected  order[] searchResult;
      protected orderDetail[] getOrderDetail;
      protected string orderId; 
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff =(staff)Session["Staff"];
            searchResult = DBModel.sharedDBModel().getAllOrderInfo(theStaff.staffId);
          
        }
        protected void Search_Order(object sender , EventArgs e)
        {
            string serachKey = Request.Form["searchKey"];
            System.Diagnostics.Debug.WriteLine("serach key and serach condition test :" + serachKey );
          //  searchResult = DBModel.sharedDBModel().getOrderInfoByOrderId(serachKey);
            
        }
        protected void SearhDetailOrder(object sender, EventArgs e)
        {
            orderId = Request.Params["order"];
            System.Diagnostics.Debug.WriteLine("order id :" + orderId);
            getOrderDetail = DBModel.sharedDBModel().getOrderDetailInfoByOrderId(orderId);
        }

    }
}