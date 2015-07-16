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
  <!--  <script src="scripts/staff_index.js"></script> -->
    
          <script>
           
              var chart;
              var chartData = [];
              var chartCursor;


              AmCharts.ready(function () {
                  // generate some data first
                  generateChartData();

                  // SERIAL CHART
                  chart = new AmCharts.AmSerialChart();

                  chart.dataProvider = chartData;
                  chart.categoryField = "date";
                  chart.balloon.bulletSize = 5;

                  // listen for "dataUpdated" event (fired when chart is rendered) and call zoomChart method when it happens
                  chart.addListener("dataUpdated", zoomChart);

                  // AXES
                  // category
                  var categoryAxis = chart.categoryAxis;
                  categoryAxis.parseDates = true; // as our data is date-based, we set parseDates to true
                  categoryAxis.minPeriod = "DD"; // our data is daily, so we set minPeriod to DD
                  categoryAxis.dashLength = 1;
                  categoryAxis.minorGridEnabled = true;
                  categoryAxis.twoLineMode = true;
                  categoryAxis.dateFormats = [{
                      period: 'fff',
                      format: 'JJ:NN:SS'
                  }, {
                      period: 'ss',
                      format: 'JJ:NN:SS'
                  }, {
                      period: 'mm',
                      format: 'JJ:NN'
                  }, {
                      period: 'hh',
                      format: 'JJ:NN'
                  }, {
                      period: 'DD',
                      format: 'DD'
                  }, {
                      period: 'WW',
                      format: 'DD'
                  }, {
                      period: 'MM',
                      format: 'MMM'
                  }, {
                      period: 'YYYY',
                      format: 'YYYY'
                  }];

                  categoryAxis.axisColor = "#DADADA";

                  // value
                  var valueAxis = new AmCharts.ValueAxis();
                  valueAxis.axisAlpha = 0;
                  valueAxis.dashLength = 1;
                  // 基线！！
                  valueAxis.baseValue = 250;
                  chart.addValueAxis(valueAxis);

                  // GRAPH
                  var graph = new AmCharts.AmGraph();
                  graph.title = "red line";
                  graph.valueField = "visits";
                  graph.bullet = "round";
                  graph.bulletBorderColor = "#FFFFFF";
                  graph.bulletBorderThickness = 2;
                  graph.bulletBorderAlpha = 1;
                  graph.lineThickness = 2;
                  graph.lineColor = "#5fb503";
                  // 基线！！
                  graph.negativeBase = 250;
                  graph.negativeLineColor = "#efcc26";
                  graph.hideBulletsCount = 50; // this makes the chart to hide bullets when there are more than 50 series in selection
                  chart.addGraph(graph);

                  // CURSOR
                  chartCursor = new AmCharts.ChartCursor();
                  chartCursor.cursorPosition = "mouse";
                  chartCursor.pan = true; // set it to fals if you want the cursor to work in "select" mode
                  chart.addChartCursor(chartCursor);

                  // SCROLLBAR
                  var chartScrollbar = new AmCharts.ChartScrollbar();
                  chart.addChartScrollbar(chartScrollbar);

                  chart.creditsPosition = "bottom-right";

                  // WRITE
                  chart.write("chartdiv");
              });

              // generate some random data, quite different range
              function generateChartData() {
                  var firstDate = new Date();
                  firstDate.setDate(firstDate.getDate() - 30);

                  <% for (var i = 0; i < 30; i++) { %>
                  // we create date objects here. In your data, you can have date strings
                  // and then set format of your dates using chart.dataDateFormat property,
                  // however when possible, use date objects, as this will speed up chart rendering.
                  var newDate = new Date(firstDate);
                  newDate.setDate(newDate.getDate() +<%: i%>);
                  var visits = <%:orderMonthChart[i]%>;
                  // visits = orderMonth[i];
                  chartData.push({
                      date: newDate,
                      visits: visits
                  });
                  <% } %>
              }
             

              // this method is called when chart is first inited as we listen for "dataUpdated" event
              function zoomChart() {
                  // different zoom methods can be used - zoomToIndexes, zoomToDates, zoomToCategoryValues
                  chart.zoomToIndexes(chartData.length - 40, chartData.length - 1);
              }

              // changes cursor mode from pan to select
              function setPanSelect() {
                  if (document.getElementById("rb1").checked) {
                      chartCursor.pan = false;
                      chartCursor.zoomable = true;
                  } else {
                      chartCursor.pan = true;
                  }
                  chart.validateNow();
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
            <a class="navbar-brand" runat="server" href="~/Index.aspx">原木衣橱连锁</a>
          </div><!-- navbar header -->
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <!-- 服装有关 -->
            <ul class="nav navbar-nav navbar-left">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a runat="server" href="~/Staff_clothesInfo.aspx">查询服装信息</a></li>
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
                  </tr>
                </thead>
                <tbody>
                    <%if (getStaffOrder != null) { %>
                    <%foreach (var  order in getStaffOrder) { %>
                  <tr>
                    <td id="staffId"><%: order.orderId %></td>
                    <td><%: order.orderTime %></td>
                    <td><%: order.totalPrice %></td>
                  </tr>
                    <% } } %>
                </tbody>
              </table>
            <!-- </div> -->
          </div>
        </div>
        <div class="col-md-6 text-center">
          <br/><h2>最热卖五件商品</h2><br/><br/>
          <div class="row" id="clothes">
            <!-- 第一个需要offset 后面格式相同 -->
      <% if (hotItems !=null) { %>
            <div class="col-md-2 col-sm-2 col-xs-4 col-sm-offset-1">
              <img class="img-responsive" src="<%: hotItems[0,2] %>">
              <br/><h4><%:hotItems[0,1] %></h4>
              <button type="button" class="btn btn-info">补货</button>
            </div>
            <% if (hotItems.Length >1){ %>
           <% for (int i = 1 ;i< hotItems.GetLength(0) ; i++) { %>
            <div class="col-md-2 col-sm-2 col-xs-4">
              <img class="img-responsive" src="<%: hotItems[i,2] %>">
              <br/><h4><%: hotItems[i,1] %></h4>
              <button type="button" class="btn btn-info">补货</button>
            </div>
            <% } } } %>
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
