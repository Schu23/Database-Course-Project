<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeSelfInfo.aspx.cs" Inherits="YMClothsStore.ChangeSelfInfo" %>
<!--修改个人信息界面-->
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>修改个人信息</title>

    <!-- Bootstrap core CSS -->
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- settings css -->
    <link rel="stylesheet" type="text/css" href="stylesheets/settings.css">
    <script src="JQuery/jquery-1.10.2.js"></script>
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
            <a class="navbar-brand" href="#">原木衣橱连锁</a>
          </div><!-- navbar header -->
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <!-- 服装有关 -->
            <ul class="nav navbar-nav navbar-left">
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">服装<span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">查询服装信息</a></li>
                  <li><a href="#">查询服装库存</a></li>
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
                  <li class="text-center"><a href="#">修改个人信息</a></li>
                  <li class="text-center"><a href="~/Login.aspx">退出</a></li>
                </ul>
              </li>
            </ul>
          </div><!-- /.navbar-collapse -->
        </div>
      </nav>
    </div>

     <form  runat="server"  class="col-sm-12" accept-charset="UTF-8" novalidate>
    <div class="container">
      <legend>账号设置</legend>
      <div class="row">
        <div class="col-md-3">
          <ul class="nav nav-pills nav-stacked">
            <li role="presentation" class="active"><a href="#personal-info" data-toggle="pill">个人信息</a></li>
            <li role="presentation"><a href="#phone-setting" data-toggle="pill">修改手机号</a></li>
            <li role="presentation"><a href="#email-setting" data-toggle="pill">修改用户名</a></li>
            <li role="presentation"><a href="#pwd-setting" data-toggle="pill">修改密码</a></li>
          </ul>
        </div>
        <div class="col-md-9">
          <!-- Tab panes -->
          <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in active" id="personal-info">
              <div class="thumbnail">
                <div class="caption">
                  <div class="container">
                    <legend><%:theStaff.staffName %></legend>
                    <div class="row">
                      <div class="col-md-6">
                        <h3>个人信息</h3><br/>
                        <p>编号：<%:theStaff.staffId %></p>
                        <p>职位：<%: theStaff.staffJob %></p>
                        <p>所在门店：<%: theStaff.shopId %></p>
                        <p>联系方式：<%: theStaff.staffPhone %></p>
                      </div>
                      <div class="col-md-6">
                        <h3>所在分店信息</h3></br>
                        <p>编号：<%:theStaff.shopId %></p>
                        <p>地址：淮海路666号</p>
                        <p>门店电话：(021)68738726</p>
                      </div>
                    </div>
                  </div>
                </div>  
              </div>
            </div>
            <div role="tabpanel" class="tab-pane fade active" id="phone-setting">
              <div class="thumbnail">
                <div class="caption">
                  <div class="container">
      
                      <div class="form-group">
                        <label for="id-newphone" class="control-label">新的手机号</label>
                        <div class="row">
                          <div class="col-sm-8">
                            <input type="text" class="form-control" name="newphone" id="id-newphone" oninput="phoneInput(event)" required>
                          </div>
                          <div class="col-sm-4">
                            <label class="check-wrong" id="newphone-check"></label>
                          </div>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="id-conphone" class="control-label">确认手机号</label>
                        <div class="row">
                          <div class="col-sm-8">
                            <input type="text" class="form-control" name="conphone" id="id-conphone" oninput="conphoneInput(event)" required>
                          </div>
                          <div class="col-sm-4">
                            <label class="check-wrong" id="conphone-check"></label>
                          </div>
                        </div>
                      </div>
                        <!--send here -->
                        <asp:Button Text="提交" runat="server" class="btn btn-primary" Onclick="modifyEmployeePhone"/>
                  
           
                  </div>
                </div>  
              </div>
            </div>


                    <div role="tabpanel" class="tab-pane fade" id="email-setting">
              <div class="thumbnail">
                <div class="caption">
                  <div class="container">
                      <div class="form-group">
                        <label for="id-newemail" class="control-label">新的用户名</label>
                        <div class="row">
                          <div class="col-sm-8">
                            <input type="text" class="form-control" name="newemail" id="id-newemail" oninput="isEmail(event)" required>
                          </div>
                          <div class="col-sm-4">
                            <label class="check-wrong" id="newemail-check"></label>
                          </div>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="id-conemail" class="control-label">确认用户名</label>
                        <div class="row">
                          <div class="col-sm-8">
                            <input type="text" class="form-control" name="conemail" id="id-conemail" oninput="confirmEmail(event)" required>
                          </div>
                          <div class="col-sm-4">
                            <label class="check-wrong" id="conemail-check"></label>
                          </div>
                        </div>
                      </div>
                      <!--TODO HERE  staff login name -->
                      <asp:Button Text="提交" CssClass="btn btn-primary" runat="server" OnClick="modifyEmployeeEmail"  />
                  </div>
                </div>  
              </div>
            </div>


            <div role="tabpanel" class="tab-pane fade active" id="pwd-setting">
              <div class="thumbnail">
                <div class="caption">
                  <div class="container">
                  
                      <div class="form-group">
                        <label for="id-oldpwd" class="control-label">当前密码</label>
                        <div class="row">
                          <div class="col-sm-8">
                            <input type="password" class="form-control" name="oldpwd" id="id-oldpwd" required>
                          </div>
                          <div class="col-sm-4">
                            <label class="check-wrong"></label>
                          </div>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="id-newpwd" class="control-label">新的密码</label>
                        <div class="row">
                          <div class="col-sm-8">
                            <input type="password" class="form-control" name="newpwd" id="id-newpwd" oninput="isPassword(event)" required>
                          </div>
                          <div class="col-sm-4">
                            <label class="check-wrong" id="newpwd-check"></label>
                          </div>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="id-conpwd" class="control-label">确认密码</label>
                        <div class="row">
                          <div class="col-sm-8">
                            <input type="password" class="form-control" name="conpwd" id="id-conpwd" oninput="confirmPassword(event)" required>
                          </div>
                          <div class="col-sm-4">
                            <label class="check-wrong" id="conpwd-check"></label>
                          </div>
                        </div>
                      </div>
                      <asp:Button Text="提交" runat="server" CssClass="btn btn-primary" OnClick="modifyEmployeePwd" />
       
                  </div>
                </div>  
              </div>
            </div><!--pwd-setting-->
          </div>
        </div>
      </div>

    </div>
     </form>
    <!-- Bootstrap core JavaScript -->
    
    <script src="Bootstrap/bootstrap.min.js"></script>
    
  </body>
</html>