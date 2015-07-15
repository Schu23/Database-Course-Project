using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YMClothsStore
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
        protected void loginSubmit(object sender, EventArgs e)
        {
         string  username = Request.Form["username"];
         string  pwd = Request.Form["password"];
         System.Diagnostics.Debug.WriteLine("Debug : username:"+username+"password:"+pwd);
            if(username.Equals("") || pwd.Equals(""))
            {
                System.Diagnostics.Debug.WriteLine("kong");
                Session["errorMessage"] = "用户名和密码不能为空";
                Session["returnURL"] = "Login.aspx";
                Response.Redirect("Error.aspx");
            }
            else
            {
              staff theStaff =  DBModel.sharedDBModel().loginWithStaffLoginNameAndPassword(username, pwd);
              if(theStaff == null)
              {
                  System.Diagnostics.Debug.WriteLine("用户名密码错误");
                  Session["errorMessage"] = "用户名和密码错误";
                  Session["returnURL"] = "Login.aspx";
                  Response.Redirect("Error.aspx");
              }
                else
              {
                  Session["Staff"] = theStaff;
                  System.Diagnostics.Debug.WriteLine("success !" + "usr job :" + theStaff.staffJob);
                  if(theStaff.staffJob.Equals("Manager")) 
                      Response.Redirect("ManagerIndex.aspx");
                  if (theStaff.staffJob.Equals("Boss"))
                      Response.Redirect("BossIndex.aspx");
                 else
                      Response.Redirect("Index.aspx");
              }
            }  
        }
        protected void rememberMe(object sender, EventArgs e)
        {
  /*          //Example Code from Stack Overflow
            int timeout = rememberMe ? 525600 : 30; // Timeout in minutes, 525600 = 365 days.
            var ticket = new FormsAuthenticationTicket(userName, rememberMe, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            cookie.Expires = System.DateTime.Now.AddMinutes(timeout);// Not my line
            cookie.HttpOnly = true; // cookie not available in javascript.
            Response.Cookies.Add(cookie);
   * */
        }

    }
}