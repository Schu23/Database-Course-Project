using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class ManagerStockInfoTable : System.Web.UI.Page
    {
        protected staff theStaff;
        //所有向本店申请调货的调货申请表
        protected apply[] applyOutResult;
        //本店所有调货申请表
        protected apply[] applyInResult;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            applyOutResult = DBModel.sharedDBModel().getAllApllyToThisShop(theStaff.staffId);
           // applyInResult = DBModel.sharedDBModel().
        }
        protected void AgreeWithTheApply(object sender, EventArgs e)
        {
            string idOfApplyToAgreeWith = Request.Form["tempApplyId"];
        }


    }
}