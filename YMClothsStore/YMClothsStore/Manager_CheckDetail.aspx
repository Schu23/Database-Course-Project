<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_CheckDetail.aspx.cs" Inherits="YMClothsStore.Manager_CheckDetail" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>首页|原木衣橱连锁管理</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/staffInfo.css">

    <!-- jquery & ajax -->
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="scripts/staffInfo.js"></script>

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
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="manager_clothesinfo.html">查询服装信息</a></li>
                  <li><a href="manager_stockinfo.html">查询服装库存</a></li>
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
              <li class="dropdown active">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">盘点<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li class="active"><a href="manager_checkdetail.html">盘点</a></li>
                  <li><a href="manager_checkInfoTable.html">查看盘点记录</a></li>
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
      <h2 class="sub-header">库存盘点</h2>
    </div>

    <!-- form -->
    <form class="">
    <div class="container table-container">
      <div class="table-responsive">
        <table class="table table-striped">
          <thead>
            <tr id="table-title">
              <th>货物编号</th>
              <th>理论库存</th>
              <th>实际库存</th>
            </tr>
          </thead>
          <tbody id="table-body">
            <tr>
              <td>123733</td>
              <td>234</td>
              <td><input type="text" class="form-control" name="check_id_1" placeholder="实际库存"></td>
            </tr>
             <tr>
              <td>123733</td>
              <td>234</td>
              <td><input type="text" class="form-control" name="check_id_2" placeholder="实际库存"></td>
            </tr>
            <tr>
              <td>123733</td>
              <td>234</td>
              <td><input type="text" class="form-control" name="check_id_3" placeholder="实际库存"></td>
            </tr>
            <tr>
              <td>123733</td>
              <td>234</td>
              <td><input type="text" class="form-control" name="check_id_4" placeholder="实际库存"></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </form>
    <!--提交按钮-->
     <div class="text-center">
          <br/>
          <button type="submit" class="btn btn-primary submit-btn">提交</button>
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


