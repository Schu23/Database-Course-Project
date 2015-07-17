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
            newSize = Request.Form["size"];
            newColor = Request.Form["color"];
            string newPriceStr = Request.Form["price"];
            newPrice = float.Parse(newPriceStr);

            DateTime now = DateTime.Now;
            string strBaseLocation = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());
            if (file1.PostedFile.ContentLength != 0)
            {
                file1.PostedFile.SaveAs(strBaseLocation + now.DayOfYear.ToString() + file1.PostedFile.ContentLength.ToString() + ".jpg");
            }

            item newItem = DBModel.sharedDBModel().addItemByBoss(newName, newSize, newColor, newPrice);
            image neImage = DBModel.sharedDBModel().addImageToItem(newItem.itemId, file1.PostedFile.ContentLength.ToString() + ".jpg");


        }
    }
}