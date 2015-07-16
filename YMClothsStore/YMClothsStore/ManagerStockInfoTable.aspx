<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerStockInfoTable.aspx.cs" Inherits="YMClothsStore.ManagerStockInfoTable" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>查询订单信息 |原木衣橱</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/staffInfo.css">

    <!-- jquery & ajax -->
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="scripts/orderInfo.js"></script>
    <script type="text/javascript">
    $(function(){
        // 模态框设置
        $('.btn-success').click(function(){
            var orderId = $(this).parent().prev().prev().prev().html();
            $('#myModalLabel').html('订单编号：'+orderId);
        })
    });
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
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="manager_clothesinfo.html">查询服装信息</a></li>
                  <li><a href="manager_stockinfo.html">查询服装库存</a></li>
                </ul>
              </li>
              <!-- 订单有关 -->
              <li class="dropdown active">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">订单管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li class="active"><a href="manager_orderInfo.html">查询订单</a></li>
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
      <h2 class="sub-header">订单查询</h2>
    </div>
    <!-- 搜索框 -->
    <div class="container text-center main-search">
      <form role="search">
        <div class="row">
          <div class="col-md-3 col-sm-3">
            <select class="form-control" name="searchCondition">
              <option value ="unknown">请选择</option>
              <option value ="staffId">员工编号</option>
              <option value ="staffName">姓名</option>
            </select>
          </div>
          <div class="col-md-8 col-sm-8 search-key-padding">
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
    <div class="container text-center main-sort">
      <div class="row">
        <div class="col-md-6 text-right">
          <div class="btn-group" role="group" aria-label="selectStaffBtnGroup">
            <button type="button" class="btn btn-info">按编号</button>
            <button type="button" class="btn btn-primary">按姓名</button>
          </div>
        </div>
        <div class="col-md-6 text-left">
          <button type="button" class="btn btn-default" onclick="window.location.href='staff_addorder.html'"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>添加订单</button>
        </div>
      </div>
    </div>
    <!-- 信息表格 -->
    <div class="container table-container">
      <div class="table-responsive">
        <table class="table table-striped">
          <thead>
            <tr id="table-title">
              <th>订单编号</th>
              <th>订单总价</th>
              <th>订单时间</th>
              <th>订单明细</th>
            </tr>
          </thead>
          <tbody id="table-body">
            <tr>
              <td id="orderId">289374982747932</td>
              <td>666.66元</td>
              <td>2015-07-16 09:30</td>
              <td>
                <button type="button" class="btn btn-success btn-sm" data-toggle="modal" data-target="#detail_modal">查看明细</button>
              </td>
            </tr>
            <tr>
              <td id="orderId">049873627383940</td>
              <td>666.66元</td>
              <td>2015-07-16 09:30</td>
              <td>
                <button type="button" class="btn btn-success btn-sm" data-toggle="modal" data-target="#detail_modal">查看明细</button>
              </td>
            </tr>
            <tr>
              <td id="orderId">838267284947322</td>
              <td>666.66元</td>
              <td>2015-07-16 09:30</td>
              <td>
                <button type="button" class="btn btn-success btn-sm" data-toggle="modal" data-target="#detail_modal">查看明细</button>
              </td>
            </tr>
          </tbody>
        </table>
        <!-- Modal -->
        <div class="modal fade" id="detail_modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <!-- 订单编号 -->
                <h4 class="modal-title" id="myModalLabel">订单编号：</h4>
              </div>
              <div class="modal-body">
                <!-- 订单明细表格 -->
                <table class="table table-striped">
                  <thead>
                    <tr id="modal">
                      <th>服装编号</th>
                      <th>服装名称</th>
                      <th>服装数量</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr id="modal">
                      <th>001</th>
                      <th>长裙</th>
                      <th>4</th>
                    </tr>
                    <tr id="modal">
                      <th>001</th>
                      <th>长裙</th>
                      <th>4</th>
                    </tr>
                  </tbody>
                </table>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
              </div>
            </div>
          </div>
        </div><!--modal-->
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
