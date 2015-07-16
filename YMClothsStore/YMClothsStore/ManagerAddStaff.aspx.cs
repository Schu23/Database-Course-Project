using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class ManagerAddStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void confirmAddStaff(object sender, EventArgs e)
        {
            string staffName = Request.Form["staffName"];
            string staffGender = Request.Form["gender"];
            string staffPhone = Request.Form["staffPhone"];
            string defaultPassword = "123456";
            staff manager = (staff)Session["staff"];
            string managerShopId;
            if(manager != null)
            {
                managerShopId = manager.shopId;
            }
            else
            {
                managerShopId = "SYSTEM";
            }
           
            System.Diagnostics.Debug.WriteLine(staffPhone);
            System.Diagnostics.Debug.WriteLine("gender:  " + staffGender);
            staff newStaff = DBModel.sharedDBModel().addNewStaff(staffName, defaultPassword, managerShopId, 2, staffGender);
            Response.Redirect("PersonnelChanges.aspx");
        }
    }
}