<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boss_ClothesInfo.aspx.cs" Inherits="YMClothsStore.Boss_ClothesInfo" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>查看服装信息|原木衣橱</title>

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
      <h2 class="sub-header">服装信息查询</h2>
    </div>

      <form runat ="server" role="search">
    <!-- 搜索框 -->
    <div class="container text-center main-search">
        <div class="row">
          <div class="col-md-3 col-sm-3 col-sm-offset-1">
            <select class="form-control" name="searchCondition">
              <option value ="unknown">请选择</option>
              <option value ="itemId">服装编号</option>
              <option value ="itemName">服装名称</option>
            </select>
          </div>
          <div class="col-md-6 col-sm-6 search-key-padding">
            <div class="form-group">
              <input type="text" class="form-control" placeholder="关键字" name="searchKey">
            </div>
          </div>
          <div class="col-md-1 col-sm-1 search-padding">
              <asp:Button runat="server" Text="搜索" OnClick="SearchItem" CssClass="btn btn-default" />
          </div>
        </div>
      <button type="button" class="btn btn-default" onclick="window.location.href='/Boss_AddressClothes.aspx'"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>添加服装</button>
    </div>
    <!-- 信息表格 -->
    <div class="container table-container">
      <div class="table-responsive">
        <table class="table table-striped">
          <thead>
            <tr id="table-title">
              <th>服装编号</th>
              <th>服装名称</th>
              <th>尺寸</th>
              <th>颜色</th>
              <th>单价</th>
              <th>上市日期</th>
              <th>图片</th>
            </tr>
          </thead>
          <tbody id="table-body">
            <%--<tr>
              <td id="itemId">001</td>
              <td>T恤</td>
              <td>XL</td>
              <td>黄色</td>
              <td>88</td>
              <td>2015/4/24</td>
              <td><button type="button" class="btn btn-success btn-sm" data-toggle="modal" data-target=".bs-example-modal-sm">查看图片</button></td>
            </tr>--%>

              <%foreach (var item in searchResult){ %>
                    <tr>
                        <td><%:item.itemId %></td>
                        <td><%:item.itemName %></td>
                        <td><%:item.itemSize %></td>
                        <td><%:item.itemColor %></td>
                        <td><%:item.itemPrice %></td>
                        <td><%:item.itemDate %></td>
                        <td><asp:Button Text="查看图片" CssClass="btn btn-success btn-sm" runat="server" OnClick="showIamgeByItemId"/></td>
                    </tr>
              <%} %>

          </tbody>
        </table>
        <!--modal-->
        <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
          <div class="modal-dialog modal-sm">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">图片详情</h4>
              </div>
              <div class="modal-body">
                  <img class="text-center img-responsive" src="/Users/ZTR/Downloads/HUPAwIDrYEZfxcu.jpg">
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
              </div>
            </div>
          </div>
        </div>
        <!--modal-->   
      </div>
    </div>
    </form>
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

