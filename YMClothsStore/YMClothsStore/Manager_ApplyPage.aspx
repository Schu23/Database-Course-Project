<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_ApplyPage.aspx.cs" Inherits="YMClothsStore.Manager_ApplyPage" %>

<!-- 调货页面 -->

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>申请调货 |原木衣橱</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/addStaff.css">

    <!-- jquery & ajax -->
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="scripts/addStaff.js"></script>
    <script type="text/javascript">
      // 手机号修改－验证手机号是否输入正确
      function isNum(event){
          var reg = /\d/; //验证规则
          if (!reg.test(event.target.value)) {
            $("#check").replaceWith('<label class="check-wrong" id="check"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></label>');
            return false;
          }else{
            $("#check").replaceWith('<label class="check-ok" id="check"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span></label>');
            return true;
          };
      }
    </script>

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
            <a class="navbar-brand" href="manager_index.html">原木衣橱连锁</a>
          </div><!-- navbar header -->
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <!-- 服装有关 -->
            <ul class="nav navbar-nav navbar-left">
              <li class="dropdown active">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="manager_clothesinfo.html">查询服装信息</a></li>
                  <li class="active"><a href="manager_stockinfo.html">查询服装库存</a></li>
                </ul>
              </li>
              <!-- 订单有关 -->
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">订单管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="manager_orderInfo.html">查询订单</a></li>
                  <li><a href="manager_addOrder.html">增加订单</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">报表管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="manager_ordertable.html">查看订单报表</a></li>
                  <li><a href="manager_inbasetable.html">查看入库报表</a></li>
                  <li><a href="manager_outbasetable.html">查看出库报表</a></li>
                  <li><a href="manager_applytable.html">查看调货报表</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">员工管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="manager_staffInfo.html">查看/修改员工信息</a></li>
                  <li><a href="manager_addStaff.html">添加员工</a></li>
                </ul>
              </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                  <span class="glyphicon glyphicon-user" aria-hidden="true"></span>  
                    刘旭东
                  <span class="caret"></span>
                </a>
                <ul class="dropdown-menu">
                  <li class="text-center"><a href="staff_setting.html">修改个人信息</a></li>
                  <li class="text-center"><a href="#">退出</a></li>
                </ul>
              </li>
            </ul>
          </div><!-- /.navbar-collapse -->
        </div>
      </nav>
    </div>
    <!-- 标题 -->
    <div class="container">
      <h2 class="sub-header">申请调货</h2>
      <br/>
    </div>

    <div class="container addstaff-form" style="width:50%;">
      <!-- form在这里！ -->
      <form runat="server">
        <!-- 输入调货分店ID name:shopId -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-2 name-offset col-sm-offset-3">
              <label class="control-label text-right">调货分店ID：</label>
            </div>
            <div class="col-sm-5">
              <input type="text" class="form-control" name="shopId" required>
            </div>
          </div>
        </div>
        <!-- 输入调货产品id name:clothesId -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-2 name-offset col-sm-offset-3">
              <label class="control-label text-right">调货产品ID：</label>
            </div>
            <div class="col-sm-5">
              <input type="text" class="form-control" name="clothesId" required>
            </div>
          </div>
        </div>
        <!-- 输入调货量 name:amount -->
        <div class="form-group">
          <div class="row">
            <div class="col-sm-2 name-offset col-sm-offset-3">
              <label class="control-label text-right">调货量：</label>
            </div>
            <div class="col-sm-5">
              <input type="text" class="form-control" name="amount" id="amount" required>
            </div>
            <div class="col-sm-2">
              <label class="check-wrong" id="check"></label>
            </div>
          </div>
        </div>
        <!-- 提交按钮 -->
        <div class="text-center">
          <br/>
        <asp:Button Text="提交" runat="server" CssClass="btn, btn-primary submit-btn" OnClick ="addStock_Submit" />
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
