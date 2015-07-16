<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_AddOrder.aspx.cs" Inherits="YMClothsStore.Manager_AddOrder" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>添加订单 |原木衣橱</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/addOrder.css">

    <!-- jquery & ajax -->
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="scripts/addOrder.js"></script>
    

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
      <h2 class="sub-header">增加订单</h2>
      <br/>
    </div>

    <div class="container addstaff-form">
      <!-- form在这里！ -->
      <form class="" runat="server">
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in active" id="personal-info">
              <div class="thumbnail">
                <div class="caption">
                  <!-- TODO: 给订单添加货物 js css -->
                  <!-- name：clothes_id_1 和 clothes_amount_1 -->
                  <legend class="name form-inline">
                    <h4>添加一个新订单：</h4>
                  </legend>
                

                    <div class="form-inline text-center" id="inline-1">
                    <div class="form-group">
                      <label>服装编号：</label>
                      <input type="text" class="form-control" name="clothes_id_1" placeholder="服装编号:" required>
                        <label>数量：</label>
                      <input type="text" class="form-control" name="clothes_amount_1" placeholder="数量" required>
                    </div>
                  </div><br />
                  <div class="form-inline text-center" id="inline-2">
                    <div class="form-group">
                      <label>服装编号：</label>
                        <input type="text" class="form-control" name="clothes_id_2" placeholder="服装编号:" >
                        <label>数量：</label>
                      <input type="text" class="form-control" name="clothes_amount_2" placeholder="数量">
                    </div>
                  </div><br />
                  <div class="form-inline text-center" id="inline-3">
                    <div class="form-group">
                      <label>服装编号：</label>
                      <input type="text" class="form-control" name="clothes_id_3" placeholder="服装编号:" >
                      <label>数量：</label>
                      <input type="text" class="form-control" name="clothes_amount_3" placeholder="数量" >
                    </div>
                  </div><br />
                  <div class="form-inline text-center" id="inline-4">
                    <div class="form-group">
                      <label>服装编号：</label>
                      <input type="text" class="form-control" name="clothes_id_4" placeholder="服装编号:" >
                      <label>数量：</label>
                      <input type="text" class="form-control" name="clothes_amount_4" placeholder="数量" />
                    </div>
                  </div><br />
                  <div class="form-inline text-center" id="inline-5">
                    <div class="form-group">
                      <label>服装编号：</label>
                     <input type="text" class="form-control" name="clothes_id_5" placeholder="服装编号:" >
                      <label>数量：</label>
                      <input type="text" class="form-control" name="clothes_amount_5" placeholder="数量" >
                    </div>
                  </div>

        
                </div>  
              </div>
            </div>
        
        <!-- 提交按钮 -->
        <div class="text-center">
          <br/>
        <asp:Button Text="提交" runat="server" OnClick="Add_NewOrder"  CssClass="btn btn-primary btn-lg"/>
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
