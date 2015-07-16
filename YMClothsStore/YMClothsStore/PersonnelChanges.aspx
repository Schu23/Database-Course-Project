<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonnelChanges.aspx.cs" Inherits="YMClothsStore.PersonnelChanges" %>
<!--自己店里人事变动-->
<!--店长可改-->
<!--总店修改店的信息-->
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

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/staffInfo.css">

    <!-- jquery & ajax -->
    <script src="JQuery/jquery-1.10.2.js"></script>
   <!-- <script type="text/javascript" src="scripts/staffInfo.js"></script>-->

      <script>
          $(function () {

              var pageArray = [];

              var liCount = $('tr').length;//获取获取记录条数
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
              $('.btn-danger').click(function () {
                  var staffName = $(this).parent().prev().prev().prev().html();
                  var staffId = $(this).parent().prev().prev().prev().prev().html();
                  $('#delete_modal').html('你确定要移除员工' + staffName + '（编号' + staffId + '）吗？');
                  $("#fire").val(staffId);
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
            <a class="navbar-brand" href="#">原木衣橱连锁</a>
          </div><!-- navbar header -->
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <!-- 服装有关 -->
            <ul class="nav navbar-nav navbar-left">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">查询服装信息</a></li>
                  <li><a href="#">查询服装库存</a></li>
                </ul>
              </li>
              <!-- 订单有关 -->
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">订单管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">查询订单</a></li>
                  <li><a href="#">增加订单</a></li>
                  <li><a href="#">删除订单</a></li>
                  <li><a href="#">修改订单</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">报表管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">查看订单报表</a></li>
                  <li><a href="#">查看入库报表</a></li>
                  <li><a href="#">查看出库报表</a></li>
                  <li><a href="#">查看调货报表</a></li>
                </ul>
              </li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">员工管理<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">查看/修改员工信息</a></li>
                  <li><a href="#">添加员工</a></li>
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
                  <li class="text-center"><a href="#">修改个人信息</a></li>
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
      <h2 class="sub-header">员工信息查询</h2>
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
<!--               <option value ="staffJob">职位</option>
              <option value ="shopId">所在门店</option> -->
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
          <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>添加员工</button>
        </div>
      </div>
    </div>
    <!-- 信息表格 -->
    <div class="container table-container">
      <div class="table-responsive">
        <form runat="server" method="get" >
        <table class="table table-striped">
          <thead>
            <tr id="table-title">
              <th>员工编号</th>
              <th>姓名</th>
              <th>性别</th>
              <th>联系方式</th>
              <th>移除员工</th>
            </tr>
          </thead>

          <tbody id="table-body">
              <%foreach (var staff in staffs){%>
            <tr>
              <td id="staffId"><%:staff.staffId %></td>
              <td><%: staff.staffName %></td>
              <td><%: staff.staffGender %></td>
              <td><%: staff.staffPhone %></td>
              <td>
                <button type="button" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#my_modal" id ="<%:staff.staffId %>">
                  移除
                </button>
                
              </td>
            </tr>
              <% } %>
          </tbody>
 
        </table>
            <!-- Modal -->
                 
                <div class="modal fade" id="my_modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">移除员工</h4>
                      </div>
                      <div class="modal-body" id="delete_modal"></div><input runat="server" type="hidden" name="fire" id="fire" />
                      <div class="modal-footer">  
                         <asp:Button Text="确定" CssClass="btn btn-primary" runat="server" OnClick="fireEmployee" />
                         <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>          
                      </div>
                    </div>
                  </div>
                </div>
             <!--modal-->
          </form>   
      </div>
    </div>
    
    <!-- 分页导航 -->
    <nav class="text-center">
      <ul class="pagination">
        <!--<li>
          <a href="#" aria-label="Previous">
            <span aria-hidden="true">&laquo;</span>
          </a>
        </li>
        <li class="active"><a href="#">1</a></li>
        <li><a href="#">2</a></li>
        <li><a href="#">3</a></li>
        <li><a href="#">4</a></li>
        <li><a href="#">5</a></li>
        <li>
          <a href="#" aria-label="Next">
            <span aria-hidden="true">&raquo;</span>
          </a>
        </li>-->
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