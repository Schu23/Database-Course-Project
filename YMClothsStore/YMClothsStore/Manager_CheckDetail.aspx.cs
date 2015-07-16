using System;
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
        protected string[] reallyCheck = new string[50];
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
           check checker = DBModel.sharedDBModel().addNewCheckRecord(theStaff.staffId);
           checkDetailTable = DBModel.sharedDBModel().getCheckDetailInfoWithStaffId(checker.checkId ,theStaff.staffId);
        }
        protected void sumbitCheck(object sender, EventArgs e)
        { 
            // it is very dirty and hard just because i don't know how to dynamicly get the value of the input type !
            //  liu 
        reallyCheck[0] = Request.Form["check_id0"];
        reallyCheck[1] = Request.Form["check_id1"];
        reallyCheck[2] = Request.Form["check_id2"];
        reallyCheck[3] = Request.Form["check_id3"];
        reallyCheck[4] = Request.Form["check_id4"];
        reallyCheck[5] = Request.Form["check_id5"];
        reallyCheck[6] = Request.Form["check_id6"];
        reallyCheck[7] = Request.Form["check_id7"];
        reallyCheck[8] = Request.Form["check_id8"];
        reallyCheck[9] = Request.Form["check_id9"];
        reallyCheck[10] = Request.Form["check_id10"];
        for (int i = 0 ;i<10 ; i++)
        {
           if(reallyCheck[i] !=null && int.Parse(reallyCheck[i]) != checkDetailTable[i].currentAmount)
           {
               int x = Convert.ToInt16(checkDetailTable[i].currentAmount);
               stock temp = DBModel.sharedDBModel().changeStockByStaffIdAndItemId(theStaff.staffId,checkDetailTable[i].itemId, x);
             
           }
        }
        
        }
    }
}