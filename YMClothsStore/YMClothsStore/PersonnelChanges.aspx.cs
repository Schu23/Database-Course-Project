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
            staffs = DBModel.sharedDBModel().findStaffsByShopId("shop_1436970752");
          System.Diagnostics.Debug.WriteLine(staffs[0].staffName);
             
        }

        // 添加新员工
        protected void addEmployee(object sender , EventArgs e)
        {
            string freshmanName = Request.Form["freshmanName"];
            string freshmanPassword = Request.Form["freshmanPwd"];
            string freshmanShop = Request.Form["freshmanShop"];
            int freshmanJob = int.Parse(Request.Form["freshmanJob"]);
            string freshmanGender = Request.Form["freshmanGender"];
           if (DBModel.sharedDBModel().addNewStaff(freshmanName,freshmanPassword,freshmanShop,freshmanJob,freshmanGender) !=null)
            {
                System.Diagnostics.Debug.WriteLine("add new staff success");
                //调回到当前界面
               Response.Redirect("PersonnelChanges.aspx");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("add new staff failed");
                Session["errorMessage"] = "添加新员工失败";
                Session["returnURL"] = "PersonnelChanges.aspx";
                Response.Redirect("Error.aspx");
            }
        }

        // 开除员工
        protected void fireEmployee(object sender , EventArgs e)
        {
           string fireId = Convert.ToString(Session["fireEmployeeId"]);
           Session.Remove("fireEmployeeId");
           System.Diagnostics.Debug.WriteLine("debug: fire the man id :"+fireId);
           if( DBModel.sharedDBModel().deleteStaffByStaffId(fireId))
           {
               System.Diagnostics.Debug.WriteLine("Fire employee success");
               //重定向到当前页面
               Response.Redirect("PersonnelChanges.aspx");
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