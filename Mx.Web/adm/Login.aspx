<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mx.Web.adm.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>用户登录 - 淘礼金数据系统</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="../assets/css/twitter-bootstrap/bootstrap.css" rel="stylesheet">
    <link href="../assets/css/social.css" rel="stylesheet">
    <link href="../assets/css/font-awesome.css" rel="stylesheet">
    <link href="../assets/css/twitter-bootstrap/bootstrap-responsive.css" rel="stylesheet">
	<link href="../Styles/css.css" rel="stylesheet">
    <style type="text/css">
        body
        {
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #e9eaed;
        }
    </style>
    <style>
        .wraper #main
        {
            margin-top: 40px;
        }
    </style>
</head>
<body>
    <div class="container">
        <form id="form1" class="form-login" runat="server">
        <div class="admlogo"></div>
        <h2 class="form-heading">
            用户登录</h2>
        <asp:TextBox ID="txtUserName" MaxLength="20" CssClass="input-block-level" runat="server"
            placeholder="用户名"></asp:TextBox>
        <asp:TextBox ID="txtPassWd" TextMode="Password" MaxLength="16" CssClass="input-block-level"
            runat="server" placeholder="密码"></asp:TextBox>
        <asp:TextBox ID="txtCode" MaxLength="4" runat="server" placeholder="验证码"></asp:TextBox>
        <img style="margin-bottom:15px; height:30px" width="70" src="/comm/CheckCode.aspx" border="0" onclick='this.src="../comm/CheckCode.aspx?r="+Math.random()' />
        <div class="row-fluid">
            <%--<label class="checkbox span6">
                <input type="checkbox" value="remember-me">
                记住我
            </label>--%>
            <asp:Button ID="BtnLogin" runat="server" CssClass="btn btn-primary pull-right span6" OnClick="BtnLogin_Click" Text="登录" />
            
        </div>
        </form>
        <div class="form-footer-copyright">
            <%=DateTime.Now.Year %> © <small>淘礼金数据系统</small>
        </div>
    </div>
</body>
</html>
