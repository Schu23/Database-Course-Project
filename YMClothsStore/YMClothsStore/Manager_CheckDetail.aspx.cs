

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Manager_CheckDetail : System.Web.UI.Page
    {
        protected  staff theStaff;
        protected checkDetail[] checkDetailTable;
        protected void Page_Load(object sender, EventArgs e)
        {
           check checker = DBModel.sharedDBModel().addNewCheckRecord(theStaff.staffId);
           checkDetailTable = DBModel.sharedDBModel().getCheckDetailInfoWithStaffId(checker.checkId ,theStaff.staffId);
        }
        protected void sumbitCheck(object sender, EventArgs e)
        {
            
           string[] the =   Request.Form["check_id"].Count ;
           
        }
    }
}