using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Boss_AddressClothes : System.Web.UI.Page
    {
        string newName;
        string newSize;
        string newColor;
        float newPrice;
        string newImagePath;
        staff theStaff;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff =(staff)Session["Staff"];
        }
       protected void addNewAddress(object sender, EventArgs e)
        {

        }

        protected void confirmToAddItem(object sender, EventArgs e)
        {
            newName = Request.Form["clothesName"];
            newSize = Request.Form["sizes"];
            newColor = Request.Form["color"];
            string newPriceStr = Request.Form["price"];
            newPrice = float.Parse(newPriceStr);

        }
    }
}