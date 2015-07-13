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
        protected string username;
        protected string pwd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginSubmit(object sender, EventArgs e)
        {
           username = Request.Form["username"];
           pwd = Request.Form["password"];
           bool loginStatus = DBModel.GetInstance().checkUser(username, pwd);
           System.Diagnostics.Debug.WriteLine(username);
           System.Diagnostics.Debug.WriteLine(pwd);
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