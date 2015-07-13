using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class ChangeSelfInfo : System.Web.UI.Page
    {
        // TODO
        protected Staff theStaff = DBModel.sharedDBModel().findStaffInformationById("null now");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void modifyEmployeesInfo()
        {
            // get new info from view 
            string employeeId = Request.Form["EmployeeId"];
            string employeeName = Request.Form["EmployeeName"];
            string employeePhone = Request.Form["EmployeePhone"];
            string employeePwd = Request.Form["EmployeePwd"];
            string employeeJob = Request.Form["EmployeeJob"];
            string employeeGender = Request.Form["EmployeeGender"];
            int employeeShopId =int.Parse(Request.Form["EmployeeShopId"]);
            Staff updateStaff = new Staff();
            // set new info 
            updateStaff.staffLogId = theStaff.staffLogId;
            updateStaff.staffId =  theStaff.staffId;
            updateStaff.staffName = employeeName;
            updateStaff.staffPhone = employeePhone;
            updateStaff.password = employeePwd;
            updateStaff.staffJob = employeeJob;
            updateStaff.staffGender = employeeGender;
            updateStaff.shopId = employeeShopId;
            // update database 
            DBModel.sharedDBModel().modifyPersonalInformation(updateStaff);

        }
    }
}