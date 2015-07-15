<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="YMClothsStore.Error" %>
<!--出错跳转页面-->
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>发生错误啦</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- signin css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/404page.css">

  </head>

  <body>

    <div class="container">
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
    </div>

    <div class="wrap text-center">
      <img class="img-responsive logo" src="images/404.png">
      <br/> 
        <form runat="server">
        <p><%: Session["errorMessage"] %></p>
         <br/>
            <asp:Button Text="返回" runat="server" CssClass="btn btn-danger btn-lg" OnClick="returnBack" />
       </form>
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