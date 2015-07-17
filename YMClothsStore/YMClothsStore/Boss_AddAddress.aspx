<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boss_AddAddress.aspx.cs" Inherits="YMClothsStore.Boss_AddAddress" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>添加地址|原木衣橱</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/addStaff.css">

    <!-- jquery & ajax -->
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="scripts/addStaff.js"></script>

  </head>

  <body>

    <!-- navbar container -->
    <div class="container">
      <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">
          <!-- Brand and toggle get grouped for better mobile display -->
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="#">
              <img class="logo-responsive" alt="Brand" src="images/logo.png">
            </a>
            <a runat="server" class="navbar-brand" href="~/Boss_Index.aspx">原木衣橱连锁</a>
          </div><!-- navbar header -->
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <!-- 服装有关 -->
            <ul class="nav navbar-nav navbar-left">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/Boss_ClothesInfo.aspx">查询服装信息</a></li>
                  <li><a runat="server" href="~/Boss_AddressClothes.aspx">增加服装信息</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">报表管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/Boss_OutBaseTable.aspx">查看出库报表</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">分店管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/Boss_ShopInfo.aspx">查看分店信息</a></li>
                  <li><a runat="server" href="~/Boss_AddShop.aspx">添加分店</a></li>
                  <li><a runat="server" href="~/Boss_AddAddress.aspx">添加地址</a></li>
                </ul>
              </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                  <span class="glyphicon glyphicon-user" aria-hidden="true"></span>  
                一个老总
                  <span class="caret"></span>
                </a>
                <ul class="dropdown-menu">
                  <li class="text-center"><a runat="server" href="~/ChangeSelfInfo.aspx">修改个人信息</a></li>
                  <li class="text-center"><a runat="server" href="~/Login.aspx">退出</a></li>
                </ul>
              </li>
            </ul>
          </div><!-- /.navbar-collapse -->
        </div>
      </nav>
    </div>
    <!-- 标题 -->
    <div class="container">
      <h2 class="sub-header">添加地址</h2>
      <br/>
    </div>

    <div class="container addstaff-form">
      <!-- form在这里！ -->
      <form class="" runat="server">
        <!-- 输入地址名称 name:addressName -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-3 name-offset col-sm-offset-1">
              <label for="disabledTextInput" class="control-label text-right">地址名称：</label>
            </div>
            <div class="col-sm-7">
              <input type="text" class="form-control" name="addressName" required>
            </div>
          </div>
        </div>
        <!-- 输入地址详情 name:addressDetail -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-3 name-offset col-sm-offset-1">
              <label class="control-label text-right">地址详情：</label>
            </div>
            <div class="col-sm-7">
              <input type="text" class="form-control" name="addressDetail" id="addressDetail" required>
            </div>
          </div>
        </div>
        <!-- 提交按钮 -->
        <div class="text-center">
          <br/>
            <asp:Button Text="提交" runat="server" CssClass="btn btn-primary submit-btn" OnClick="addNewAddress" />
         
        </div>
        
      </form>
    </div>
    
    <footer class="footer">
      <div class="container">
        <hr/>
        <p class="text-center">原木衣橱连锁店管理系统@2015</p>
      </div>
    </footer>
    <!-- Bootstrap core JavaScript -->
    
    <script src="Bootstrap/bootstrap.min.js"></script>
    
  </body>
</html>
