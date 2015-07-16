<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerStockInfoTable.aspx.cs" Inherits="YMClothsStore.ManagerStockInfoTable" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>调货报表 |原木衣橱</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/settings.css">
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script src="scripts/settings.js"></script>

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
      <form runat="server">
           <div class="container">
      <legen>调货报表信息查询</legen>
      <br>
      <br>
      <div class="row">
        <div class="col-md-3">
          <ul class="nav nav-pills nav-stacked" id="myTabs">
            <li role="presentation" class="active"><a href="#in" data-toggle="pill">调入本店</a></li>
            <li role="presentation"><a href="#out" data-toggle="pill">调出本店</a></li>
          </ul>
        </div>
        <div class="col-md-9">
          <!-- Tab panes -->
          <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in" id="out">
              <div class="thumbnail">
                <div class="caption">
                  <div class="container table-container">
                    <div class="table-responsive">
                      <table class="table table-striped">
                        <thead>
                          <tr id="table-title">
                            <th>申请单号</th>
                            <th>到达门店</th>
                            <th>申请状态</th>
                            <th>申请时间</th>
                            <th>审批调货</th>
                          </tr>
                        </thead>
                        <tbody id="table-body">
                         <%foreach(var inApply in applyInResult) { %>
                             <input style="display:none" type="text" name="tempApplyState" value="<%:inApply.state %>" />
                             <input style="display:none" type="text" name="tempApplyId" value="<%:inApply.applyId %>" />
                            <tr>
                                <td><%:inApply.applyId %></td>
                                <td><%:inApply.inShop %></td>
                                <td><%:inApply.state %></td>
                                <td><%:inApply.applyTime %></td>
                                <%if(inApply.state.Equals("yes")){ %>
                                <td><button type="button" class="btn btn-success btn-sm" data-toggle="modal" disabled>已调货</button></td>
                                <%} else {%>
                                 <%--<td><asp:Button runat="server" type="button" class="btn btn-danger btn-sm" data-toggle="modal" onclick="AgreeTo">同意调货</asp:Button></td>--%>
                                <td><asp:Button runat="server" CssClass="btn btn-danger btn-sm" OnClick="AgreeWithTheApply" /></td>
                               
                                <%} %>
                               
                            </tr>
                            <%} %>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div role="tabpanel" class="tab-pane fade in active" id="in">
              <div class="thumbnail">
                <div class="caption">
                  <div class="container table-container">
                    <div class="table-responsive">
                      <table class="table table-striped">
                        <thead>
                          <tr id="table-title">
                            <th>申请单号</th>
                            <th>出发门店</th>
                            <th>申请状态</th>
                            <th>申请时间</th>  
                          </tr>
                        </thead>
                        <tbody id="table-body">
                          <%foreach(var outApply in applyOutResult) { %>
                            <tr>
                                <td><%:outApply.applyId %></td>
                                <td><%:outApply.outShop %></td>
                                <td><%:outApply.state %></td>
                                <td><%:outApply.applyTime %></td>
                            </tr>
                            <%} %>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

    </div>
      </form>
   

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
