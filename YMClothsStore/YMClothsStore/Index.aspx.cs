using System;
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
        protected order[] getStaffOrder = null;
        protected string[,] showItems;
     //   protected string[] topFiveItemId;
     //   protected string[] topFiveItemName;
     //   protected string[] topFiveItemImgid;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff =(staff)Session["Staff"];
            string [,] showItems = DBModel.sharedDBModel().topFiveItems("");
            /*       for(int i = 0 ; i<5 ; i ++)
                   {
                       topFiveItemId[i] = showItems[i, 0];
                       topFiveItemName[i] = showItems[i, 1];
                       topFiveItemImgid[i] = showItems[i, 2];

                   }
            */
        }
    }
}