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
        protected staff staffToFind;
        protected void Page_Load(object sender, EventArgs e)
        {
          //获取当前店里的员工列表
          //now it is hard code ！！！！！
           // string fireId = Request.QueryString["fire"];
          //  System.Diagnostics.Debug.WriteLine("debug: fire the man id :" + fireId);
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
           if (DBModel.sharedDBModel().addNewStaff(freshmanName,freshmanPassword,freshmanShop,freshmanJob,freshmanGender,"13333333") !=null)
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
        
            string fireId = Request.Params["fire"];
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
        //查找员工
        protected void SearchByStaffId(string id)
        {
            staffToFind = DBModel.sharedDBModel().findStaffByStaffId(id);
        }
        protected void SearchByStaffName(string name)
        {
            staffToFind = DBModel.sharedDBModel().getStaffWithStaffName(name).FirstOrDefault();
        }
        protected void SearchStaff(object sender, EventArgs e)
        {
            string option = Request.Form["searchCondition"];
            string value = Request.Form["searchKey"];
            System.Diagnostics.Debug.WriteLine("option is:" + option);
            if (option.Equals("staffId"))
            {
                SearchByStaffId(value);
            }
            else
            {
                SearchByStaffName(value);
            }


        }
    }
}