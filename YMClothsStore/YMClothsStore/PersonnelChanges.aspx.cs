using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace YMClothsStore
{
    public partial class PersonnelChanges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 这里应该返回这个店里的所有员工的列表
        }


        

        //获取当前店里的员工列表
        protected ArrayList  staffs = DBModel.sharedDBModel().findStaffInformationById("shopid");



        // 添加新员工
        protected void addEmployee(object sender , EventArgs e)
        {
            string freshmanName = Request.Form["freshmanName"];
            DBModel.sharedDBModel().addStaff(freshmanName);
        }

        // 开除员工
        protected void fireEmployee(object sender , EventArgs e)
        {
           string fireId = Request.Form["fireEmployeeId"];
           DBModel.sharedDBModel().deleteStaffById(fireId);
        }
    }
}