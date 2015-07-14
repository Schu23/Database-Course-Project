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

    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">

  </head>

  <body>

    <!-- <div class="container">
      <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">
          <div class="navbar-header">
            <a class="navbar-brand" href="#">
              <img class="logo-responsive" alt="Brand" src="images/logo.png">
            </a>
            <a class="navbar-brand name" href="#">原木衣橱连锁</a>
          </div>
        </div>
      </nav>
    </div> -->

    <div class="container">
      <div class="row">
        <div class="col-md-6 left-side-panel">
          <div class="text-center logo-offset">
            <img src="images/logo.png">
            <h1>原木衣橱</h1>
          </div>
          
        </div>
        <div class="col-md-6 col-signin right-side-panel">
          <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">登录</h2></br>
            <label>员工编号：</label>
            <input name="username" type="text" class="form-control" placeholder="请输入员工编号" required autofocus>
            <label class="validation">
              <!-- <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> 不存在此员工 -->
            </label></br></br>
            <label>密码：</label>
            <input name="password" type="password" class="form-control" placeholder="请输入密码" required>
            <label class="validation">
              <!-- <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> 密码错误！ -->
            </label>
            <div class="checkbox">
              <label>
                <input type="checkbox" value="remember-me"> 记住我
              </label>
            </div>
             
              
               <asp:Button runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="登录"  OnClick="loginSubmit" />
          </form>
        </div>
      </div>
    </div>
    <footer class="footer">
      <div class="container">
        <p class="text-center">原木衣橱连锁店管理系统@2015</p>
      </div>
    </footer>
    <!-- Bootstrap core JavaScript -->
    <script src="JQuery/jquery-1.10.2.js"></script>
    <script src="Bootstrap/bootstrap.min.js"></script>
  </body>
</html>
