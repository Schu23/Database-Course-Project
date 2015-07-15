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
        //  找到该员工 
        protected staff theStaff;
        protected void Page_Load(object sender, EventArgs e)
        {
            theStaff = (staff)Session["Staff"];
            System.Diagnostics.Debug.WriteLine("staff id " + theStaff.staffId);
        }
       // 更新员工的电话号码
        protected void modifyEmployeePhone(object sender , EventArgs e)
        {
            string employeePhone = Request.Form["newphone"];
            string conPhone = Request.Form["conPhone"];
            System.Diagnostics.Debug.WriteLine("phone :" + employeePhone);
            if (employeePhone.Equals(conPhone))
            {
                theStaff.staffPhone = employeePhone;
                if (DBModel.sharedDBModel().modifyPersonalInformation(theStaff))
                {

                    Response.Redirect("ChangeSelfInfo.aspx");
                }
                else
                {
                    Session["errorMessage"] ="修改失败，请检查网络";
                    Session["returnURL"] = "ChangeSelfInfo.aspx";
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Session["errorMessage"] = "手机号码不一致";
                Session["returnURL"] = "ChangeSelfInfo.aspx";
                Response.Redirect("Error.aspx");
            }

                
        }
        //更改员工的密码
        protected void modifyEmployeePwd (object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("debug:LL start it !");
            string oldPwd = Request.Form["oldpwd"];
            string newPwd = Request.Form["newpwd"];
            string conPwd = Request.Form["conpwd"];
            System.Diagnostics.Debug.WriteLine("debug:LL"+oldPwd);
            System.Diagnostics.Debug.WriteLine(theStaff.password);
            if(theStaff.password.Equals(oldPwd))
            {
               if(newPwd.Equals(conPwd))
               {
                   theStaff.password = newPwd;
                   if (DBModel.sharedDBModel().modifyPersonalInformation(theStaff))
                   {

                       Response.Redirect("ChangeSelfInfo.aspx");
                   }
                   else
                   {
                       Session["errorMessage"] = "网络问题";
                       Session["returnURL"] = "ChangeSelfInfo.aspx";
                       Response.Redirect("Error.aspx");
                   }
               }
               else
               {
                   Session["errorMessage"] = "确认密码不一致";
                   Session["returnURL"] = "ChangeSelfInfo.aspx";
                   Response.Redirect("Error.aspx");
               }
            }
            else
            {
                Session["errorMessage"] = "原密码错误！";
                Session["returnURL"] = "ChangeSelfInfo.aspx";
                Response.Redirect("Error.aspx");
            }           
        }
        // 更改邮箱
        protected void modifyEmployeeEmail(object sender , EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("debug:LL start it !");
            string newEmail = Request.Form["newemail"];
            string conEmial = Request.Form["conemail"];
            System.Diagnostics.Debug.WriteLine("debug here :" + newEmail + conEmial);
           if(newEmail.Equals(conEmial))
           {
               theStaff.staffLoginName = newEmail;
               System.Diagnostics.Debug.WriteLine("test email:"+newEmail);
                if (DBModel.sharedDBModel().modifyPersonalInformation(theStaff))
                {
                    System.Diagnostics.Debug.WriteLine("test mailin loop :" + theStaff.staffLoginName);
                    Response.Redirect("ChangeSelfInfo.aspx");
                }
                else
                {
                    Session["errorMessage"] = "网络问题";
                    Session["returnURL"] = "ChangeSelfInfo.aspx";
                    Response.Redirect("Error.aspx");
                }
           }
           else
           {
               Session["errorMessage"] = "确认登录名不同";
               Session["returnURL"] = "ChangeSelfInfo.aspx";
               Response.Redirect("Error.aspx");
           }



        }
    }
}