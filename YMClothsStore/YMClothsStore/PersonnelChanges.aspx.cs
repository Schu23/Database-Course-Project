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
        protected staff[]  staffs;
        protected void Page_Load(object sender, EventArgs e)
        {
          //获取当前店里的员工列表
          //now it is hard code ！！！！！
          staffs = DBModel.sharedDBModel().findStaffInformationById("1423");
          System.Diagnostics.Debug.WriteLine(staffs[0].staffName);
        }

        // 添加新员工
        protected void addEmployee(object sender , EventArgs e)
        {
            string freshmanName = Request.Form["freshmanName"];
            /*if (!DBModel.sharedDBModel().addNewStaff(freshmanName).Equals("0"))
            {
                System.Diagnostics.Debug.WriteLine("add new staff success");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("add new staff failed");
                Session["errorMessage"] = "添加新员工失败";
                Session["returnURL"] = "PersonnelChanges.aspx";
                Response.Redirect("Error.aspx");
            }*/
        }

        // 开除员工
        protected void fireEmployee(object sender , EventArgs e)
        {
           string fireId = Request.Form["fireEmployeeId"];

           if( DBModel.sharedDBModel().deleteStaffById(fireId))
           {
               System.Diagnostics.Debug.WriteLine("Fire employee success");
           }
           else
           {
               System.Diagnostics.Debug.WriteLine("Fire employee failed");
               Session["errorMessage"] = "开除员工失败，请检查连接和自己的权限";
               Session["returnURL"] = "PersonnelChanges.aspx";
               Response.Redirect("Error.aspx");
           }
        }
    }
}