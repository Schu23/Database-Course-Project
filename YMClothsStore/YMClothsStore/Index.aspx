<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="YMClothsStore.Index" %>
<!--登入后的首页-->
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>首页|原木衣橱连锁管理系统</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- index css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/staff_index.css">

    <!-- chart css and js -->
    <script src="amcharts/amcharts.js" type="text/javascript"></script>
    <script src="amcharts/serial.js" type="text/javascript"></script>

    <script src="jQuery/jquery-1.10.2.js"></script>
    <script src="scripts/staff_index.js"></script>
    

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
            <a class="navbar-brand" runat="server" href="~/Index.aspx">原木衣橱连锁</a>
          </div><!-- navbar header -->
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <!-- 服装有关 -->
            <ul class="nav navbar-nav navbar-left">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">查询服装信息</a></li>
                </ul>
              </li>
              <!-- 订单有关 -->
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">订单 <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">查询订单</a></li>
                  <li><a href="#">增加订单</a></li>
                  <li><a href="#">删除订单</a></li>
                  <li><a href="#">修改订单</a></li>
                </ul>
              </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                  <span class="glyphicon glyphicon-user" aria-hidden="true"></span>  
                    <%: theStaff.staffName %>
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
    <div class="container">
      <div class="row">
        <div class="col-md-6">
          <br/><h2 class="text-center">最近成交五笔订单</h2><br/><br/>
          <!-- 信息表格 -->
          <div class="container">
            <!-- <div class="table-responsive"> -->
              <table class="table table-striped">
                <thead>
                  <tr>
                    <th>订单编号</th>
                    <th>订单时间</th>
                    <th>总价</th>
                    <th>修改</th>
                    <th>删除</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td id="staffId">23980012398001</td>
                    <td>2015-07-14 21:58</td>
                    <td>666.66元</td>
                    <td>
                      <button type="button" class="btn btn-success btn-sm">
                        修改
                      </button>
                    </td>
                    <td>
                      <button type="button" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#delete_orderId">
                        删除
                      </button>
                      <!-- Modal -->
                      <div class="modal fade" id="delete_orderId" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                          <div class="modal-content">
                            <div class="modal-header">
                              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                              <h4 class="modal-title" id="myModalLabel">删除订单</h4>
                            </div>
                            <div class="modal-body">
                              你确定要删除订单2398001吗？
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-primary" onclick="delete(this)">确定</button>
                              <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                            </div>
                          </div>
                        </div>
                      </div><!--modal-->
                    </td>
                  </tr>
                  <tr>
                    <th>订单编号</th>
                    <th>订单时间</th>
                    <th>总价</th>
                    <th>修改</th>
                    <th>删除</th>
                  </tr>
                  <tr>
                    <th>订单编号</th>
                    <th>订单时间</th>
                    <th>总价</th>
                    <th>修改</th>
                    <th>删除</th>
                  </tr>
                  <tr>
                    <th>订单编号</th>
                    <th>订单时间</th>
                    <th>总价</th>
                    <th>修改</th>
                    <th>删除</th>
                  </tr>
                  <tr>
                    <th>订单编号</th>
                    <th>订单时间</th>
                    <th>总价</th>
                    <th>修改</th>
                    <th>删除</th>
                  </tr>
                </tbody>
              </table>
            <!-- </div> -->
          </div>
        </div>
        <div class="col-md-6 text-center">
          <br/><h2>最热卖五件商品</h2><br/><br/>
          <div class="row" id="clothes">
            <!-- 第一个需要offset 后面格式相同 -->
            <div class="col-md-2 col-sm-2 col-xs-4 col-sm-offset-1">
              <img class="img-responsive" src="images/logo.png">
              <br/><h4>衣服1</h4>
              <button type="button" class="btn btn-info">查看信息</button>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-4">
              <img class="img-responsive" src="images/logo.png">
              <br/><h4>衣服1</h4>
              <button type="button" class="btn btn-info">查看信息</button>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-4">
              <img class="img-responsive" src="images/logo.png">
              <br/><h4>衣服1</h4>
              <button type="button" class="btn btn-info">查看信息</button>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-4">
              <img class="img-responsive" src="images/logo.png">
              <br/><h4>衣服1</h4>
              <button type="button" class="btn btn-info">查看信息</button>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-4">
              <img class="img-responsive" src="images/logo.png">
              <br/><h4>衣服1</h4>
              <button type="button" class="btn btn-info">查看信息</button>
            </div>
          </div>
        </div>
      </div>
      <br/><br/><h2 class="text-center">最近一个月销售记录</h2><br/>
      <div id="chartdiv" style="width: 100%; height: 400px;"></div>
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
