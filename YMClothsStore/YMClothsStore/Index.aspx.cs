﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Index : System.Web.UI.Page
    {
        protected staff theStaff;
        protected order[] getStaffOrder = new order[5];
        protected string[,] hotItems = null;
        protected decimal[] orderMonthChart = null;
     //   protected string[] topFiveItemId;
     //   protected string[] topFiveItemName;
     //   protected string[] topFiveItemImgid;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff =(staff)Session["Staff"];
           // 为空返回什么数值?
           //  string [,] showItems = DBModel.sharedDBModel().topFiveItems();
           order[] getAllStaffOrder = DBModel.sharedDBModel().getAllOrderInfo(theStaff.staffId);
           for (int i = 0; i < 5;  i++)
           {
               getStaffOrder[i] = getAllStaffOrder[i];
           }
              hotItems = DBModel.sharedDBModel().topFiveItems(theStaff.staffId);
            // 前端 no problems 
           orderMonthChart = DBModel.sharedDBModel().getEverySumOfThisMonth(theStaff.staffId);
           System.Diagnostics.Debug.WriteLine("month order debug :"+ orderMonthChart.Length);
        }
    }
}