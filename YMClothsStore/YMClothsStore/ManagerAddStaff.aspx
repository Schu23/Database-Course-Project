<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerAddStaff.aspx.cs" Inherits="YMClothsStore.ManagerAddStaff" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>添加员工 |原木衣橱</title>

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
            <a runat="server" class="navbar-brand" href="~/ManagerIndex.aspx">原木衣橱连锁</a>
          </div><!-- navbar header -->
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <!-- 服装有关 -->
            <ul class="nav navbar-nav navbar-left">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/Manager_ClothesInfo.aspx">查询服装信息</a></li>
                  <li><a runat="server" href="~/Manager_StockInfo.aspx">查询服装库存</a></li>
                </ul>
              </li>
              <!-- 订单有关 -->
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">订单管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/Manager_OrderInfo.aspx">查询订单</a></li>
                  <li><a runat="server" href="~/Manager_AddOrder.aspx">增加订单</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">报表管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/ManagerOrderInfoTable.aspx">查看订单报表</a></li>
                  <li><a runat="server" href="~/ManagerInBaseTable.aspx">查看入库报表</a></li>
                  <li><a runat="server" href="~/ManagerOutBaseTable.aspx">查看出库报表</a></li>
                  <li><a runat="server" href="~/ManagerStockInfoTable.aspx">查看调货报表</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">员工管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/PersonnelChanges.aspx">查看员工信息</a></li>
                  <li><a runat="server" href="~/ManagerAddStaff.aspx">添加员工</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">盘点<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/Manager_CheckDetail.aspx">盘点</a></li>
                  <li><a runat="server" href="~/Manager_CheckInfoTable.aspx">查看盘点记录</a></li>
                </ul>
              </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                  <span class="glyphicon glyphicon-user" aria-hidden="true"></span>  
                     <%:theStaff.staffName %>
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
      <h2 class="sub-header">添加员工</h2>
      <br/>
    </div>

    <div class="container addstaff-form">
      <!-- form在这里！ -->
      <form runat="server" class="">
        <!-- 输入姓名 name:staffName -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-3 name-offset col-sm-offset-1">
              <label class="control-label text-right">姓名：</label>
            </div>
            <div class="col-sm-7">
              <input type="text" class="form-control" name="staffName" id="staffName" required>
            </div>
            <div class="col-sm-1">
              <label class="check-wrong" id="staffName"></label>
            </div>
          </div>
        </div>
        <!-- 选择性别；value值分别为female和male；name:staffGender -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-3 name-offset col-sm-offset-1">
              <label class="control-label text-right">性别：</label>
            </div>
            <div class="col-sm-2">
                <select class="form-control" name="gender">
                    <option value="female">女</option>
                    <option value="male">男</option>
                </select>
            </div>
          </div>
        </div>
        <!-- 输入联系方式 name:staffPhone -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-3 name-offset col-sm-offset-1">
              <label class="control-label text-right">联系方式：</label>
            </div>
            <div class="col-sm-7">
              <input type="text" class="form-control" name="staffPhone" id="staffPhone" required>
            </div>
            <div class="col-sm-1">
              <label class="check-wrong" id="staffPhone"></label>
            </div>
          </div>
        </div>
        <!-- 分店名称 name:shopName 不允许输入 直接从session中获取值并添加到placeholder和传到后端中 -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-3 name-offset col-sm-offset-1">
              <label for="disabledTextInput" class="control-label text-right">分店名称：</label>
            </div>
            <div class="col-sm-7">
              <input type="text" class="form-control" name="shopName" id="disabledTextInput" placeholder="纽约分店" disabled>
            </div>
            <div class="col-sm-1">
              <label class="check-wrong" id="shopName"></label>
            </div>
          </div>
        </div>
        <!-- 职位 name:staffJob 不允许输入 默认为普通员工 给后端传普通员工应该就ok了 -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-3 name-offset col-sm-offset-1">
              <label for="disabledTextInput" class="control-label text-right">职位：</label>
            </div>
            <div class="col-sm-7">
              <input type="text" class="form-control" name="staffJob" id="disabledTextInput" placeholder="普通员工" disabled>
            </div>
            <div class="col-sm-1">
              <label class="check-wrong" id="staffJob"></label>
            </div>
          </div>
        </div>
        <!-- 提交按钮 -->
        <div class="text-center">
          <br/>
          <asp:Button runat="server" CssClass=" btn btn-primary btn-block" Text="添加" OnClick="confirmAddStaff" />
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

