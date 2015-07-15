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
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff =(staff)Session["Staff"];
        }
    }
}