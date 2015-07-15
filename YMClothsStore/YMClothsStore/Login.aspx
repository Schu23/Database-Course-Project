<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YMClothsStore.Login" %>
<!-- 登录界面-->
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>登录</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- signin css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/signin.css">

  </head>

  <body>

    <div class="container">
      <div class="row">
        <div class="col-md-6 left-side-panel">
          <div class="text-center logo-offset">
            <img class="img-responsive big-logo-responsive" src="images/logo-2.png">
            <img class="img-responsive big-logo-responsive" src="images/title.png">
          </div>
        </div>
        <div class="col-md-6 right-side-panel">
           <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">登录</h2></br>
            <label>邮箱：</label>
            <input type="text"  name="username" class="form-control" placeholder="请输入员工编号" required autofocus>
            <label class="validation">
              <!-- <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> 不存在此员工 -->
            </label></br>
            <label>密码：</label>
            <input type="password" name="password" class="form-control" placeholder="请输入密码" required>
            <label class="validation">
              <!-- <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> 密码错误！ -->
            </label>
            <!-- <div class="checkbox">
              <label>
                <input type="checkbox" value="remember-me"> 记住我
              </label>
            </div> -->
             <asp:Button runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="登录"  OnClick="loginSubmit" />
          </form>
          <footer class="footer text-center">
              <p class="footer-text">原木衣橱连锁店管理系统@2015</p>
          </footer>
        </div>
      </div>
    </div>
    
    <!-- Bootstrap core JavaScript -->
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script src="Bootstrap/bootstrap.min.js"></script>
  </body>
</html>
