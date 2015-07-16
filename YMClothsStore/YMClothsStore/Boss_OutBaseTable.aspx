<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boss_OutBaseTable.aspx.cs" Inherits="YMClothsStore.Boss_OutBaseTable" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>出库报表|原木衣橱</title>

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
                    刘旭东
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
      <h2 class="sub-header">出库报表信息查询</h2>
    </div>
    <!-- 搜索框 -->
    <div class="container text-center main-search">
      <form role="search">
        <div class="row">
          <div class="col-md-7 col-sm-7 col-sm-offset-2">
            <div class="form-group">
              <input type="text" class="form-control" placeholder="关键字" name="searchKey">
            </div>
          </div>
          <div class="col-md-1 col-sm-1 search-padding">
            <button type="submit" class="btn btn-default">搜索</button>
          </div>
        </div>
      </form>
    </div>
<!--     <div class="container text-center main-sort">
      <div class="btn-group" role="group" aria-label="selectStaffBtnGroup">
        <button type="button" class="btn btn-info">按出库单号</button>
        <button type="button" class="btn btn-primary">按出库类型</button>
        <button type="button" class="btn btn-info">按审核员编号</button>
        <button type="button" class="btn btn-info">按出库时间</button>
      </div>
    </div> -->
    <!-- 信息表格 -->
    <div class="container table-container">
      <div class="table-responsive">
        <table class="table table-striped">
          <thead>
            <tr id="table-title">
              <th>出库单号</th>
              <th>出库类型</th>
              <th>审核员编号</th>
              <th>出库时间</th>
            </tr>
          </thead>
          <tbody id="table-body">
            <tr>
              <td>2536svs</td>
              <td>调货</td>
              <td>322dfb</td>
              <td>19:37:17</td>
            </tr>
            <tr>
              <td>2536svs</td>
              <td>调货</td>
              <td>322dfb</td>
              <td>19:37:17</td>
            </tr>
            <tr>
              <td>2536svs</td>
              <td>调货</td>
              <td>322dfb</td>
              <td>19:37:17</td>
            </tr>
            <tr>
              <td>2536svs</td>
              <td>调货</td>
              <td>322dfb</td>
              <td>19:37:17</td>
            </tr>
            <tr>
              <td>2536svs</td>
              <td>调货</td>
              <td>322dfb</td>
              <td>19:37:17</td>
            </tr>
            <tr>
              <td>2536svs</td>
              <td>调货</td>
              <td>322dfb</td>
              <td>19:37:17</td>
            </tr>
            <tr>
              <td>2536svs</td>
              <td>调货</td>
              <td>322dfb</td>
              <td>19:37:17</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <!-- 分页导航 -->
    <nav class="text-center">
      <ul class="pagination">
        <!-- <li><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>
        <li class="active"><a href="#">1</a></li>
        <li><a href="#">2</a></li>
        <li><a href="#">3</a></li>
        <li><a href="#">4</a></li>
        <li><a href="#">5</a></li>
        <li>
          <a href="#" aria-label="Next">
            <span aria-hidden="true">&raquo;</span>
          </a>
        </li> -->
      </ul>
    </nav>
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
