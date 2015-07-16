<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boss_shopInfo.aspx.cs" Inherits="YMClothsStore.Boss_shopInfo" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>查询分店信息 |原木衣橱</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/staffInfo.css">

    <!-- jquery & ajax -->
    <script src="jQuery/jquery-1.10.2.js"></script>
    <script type="text/javascript">
    $(function(){
        var pageArray = [];

        //获取记录条数
        var liCount = 0;
        var $tr = $('tr');
        $tr.each(function(){
            if ($(this).attr('id')=="table-title") {}
            else{
                liCount++;
            }
        });
        var PageSize  = 10;//设置每页，你准备显示几条
        var PageCount  = Math.ceil(liCount/PageSize);//计算出总共页数
        
        var i=0;
        for(i=1; i<=PageCount; i++){
            $('<li id="page-li"><a class="page-a" href="#" pageNum="'+(i-1)+'" >第'+i+'页</a></li>').appendTo('.pagination');//显示分页按钮
        }
        // 获取整个table中的所有行值并存入pagearray
        var $tr = $('tr');
        $tr.each(function(){
            if ($(this).attr('id')=="table-title") {}
            else{
                pageArray.push(this);
            }
        });
        // 清空table 只显示第一页数据
        $('#table-body').html('');
        for(i=0;i<PageSize;i++){
            $('#table-body').append(pageArray[i]);
        }
        // 显示分页内容的方法
        function showPage(whichPage){
            $('#table-body').html('');
            var page = whichPage;
            var initial = (page)*PageSize;
            var end = (++page)*PageSize;
            for(i = initial; i < end ; i++){
                $('#table-body').append(pageArray[i]);
            }
        }
        // 当分页符号被点击时的效果
        $('.page-a').click(function(){
            showPage($(this).attr('pagenum'));
        })
        // 模态框设置
        $('.btn-danger').click(function(){
            var staffName = $(this).parent().prev().prev().prev().html();
            var staffId = $(this).parent().prev().prev().prev().prev().html();
            $('#delete_modal').html('你确定要关闭门店'+staffName+'（编号'+staffId+'）吗？');
        })
    });
    </script>

  </head>

  <body>

    <!-- navbar container -->
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
      <h2 class="sub-header">门店信息查询</h2>
    </div>
    <!-- 搜索框 -->
    <div class="container text-center main-search">
      
    </div>
    <div class="container text-center main-sort">
      <a runat="server" type="button" class="btn btn-default" href="~/Boss_AddShop.aspx"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>添加门店</a>
    </div>
    <!-- 信息表格 -->
    <div class="container table-container">
      <div class="table-responsive">
        <table class="table table-striped">
          <thead>
            <tr id="table-title">
              <th>门店编号</th>
              <th>门店地址</th>
              <th>门店状态</th>
              <th>联系方式</th>
              <th>门店操作</th>
            </tr>
          </thead>
          <tbody id="table-body">
            <tr>
              <td>address_001</td>
              <td>纽约</td>
              <td>已关闭</td>
              <td>68736273</td>
              <td>
                <button type="button" class="btn btn-default btn-sm disabled">已关闭</button>
              </td>
            </tr>
            <tr>
              <td>address_002</td>
              <td>巴黎</td>
              <td>运营中</td>
              <td>68736273</td>
              <td>
                <button type="button" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#delete_shop">关店</button>
              </td>
            </tr>
            
          </tbody>
        </table>
        <!-- Modal -->
        <div class="modal fade" id="delete_shop" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">关闭门店</h4>
              </div>
              <div class="modal-body" id="delete_modal">
                你确定要关闭门店吗？
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-primary">确定</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
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
