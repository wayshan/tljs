<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="ChangePwd.aspx.cs" Inherits="Mx.Web.uadm.ChangePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentNav" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <%--<h3 class="page-title">
                            Form validation
                        </h3>--%>
            <!-- BEGIN BREADCRUMBS -->
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="#">首页</a> <span class="icon-angle-right"></span>
                </li>
                <li><a href="ChangePwd.aspx">修改密码</a> <span class="icon-angle-right"></span></li>
            </ul>
            <!-- END BREADCRUMBS -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12">
        <div class="social-box">
            <div class="header">
                <h4>
                    修改登录密码</h4>
            </div>
            <div class="body">
                <fieldset class="span6 offset2">
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            旧密码</label>
                        <div class="controls">
                            <asp:TextBox ID="txtOPwd" ClientIDMode="Static" TextMode="Password" class="input-block-level" runat="server"
                                placeholder="请输入旧密码"></asp:TextBox>
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            密码</label>
                        <div class="controls">
                            <asp:TextBox ID="txtPwd" ClientIDMode="Static" TextMode="Password" class="input-block-level" runat="server"
                                placeholder="请输入新密码"></asp:TextBox>
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            确认密码</label>
                        <div class="controls">
                            <asp:TextBox ID="txtRePwd" ClientIDMode="Static" TextMode="Password" class="input-block-level" runat="server"
                                placeholder="确认登录密码"></asp:TextBox>
                        </div>
                    </div>                    
                </fieldset>
                <div class="clearfix">
                </div>
                <div class="form-actions" style="display:none">
                    <div class="span6 offset2">
                        <asp:Button ID="BtnSubmit" ClientIDMode="Static" OnClick="BtnSubmit_Click" Text="更新" runat="server" class="btn btn-primary"
                            data-loading-text="提交中..." />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentJs" runat="server">
    <!-- BEGIN JAVASCRIPT CODES -->
    <!-- BEGIN GENERAL JAVASCRIPT CODE -->
    <script>        window.jQuery || document.write('<script src="../assets/plugins/jquery/jquery-1.9.0.js"><\/script>')</script>
    <script src="../assets/plugins/jquery.ui/jquery-ui-1.10.1.custom.min.js"></script>
    <script src="../assets/plugins/jquery.ui.touch-punch/jquery.ui.touch-punch.js"></script>
    <script src="../assets/plugins/twitter-bootstrap/bootstrap.js"></script>
    <script src="../assets/plugins/jquery.slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/jquery.cookie/jquery.cookie.js"></script>
    <script src="../assets/plugins/jquery.simplecolorpicker/jquery.simplecolorpicker.js"></script>
    <script src="../assets/plugins/jquery.uipro/uipro.min.js"></script>
    <script src="../assets/plugins/jquery.ui.chatbox/jquery.ui.chatbox.js"></script>
    <script src="../assets/plugins/jquery.livefilter/jquery.liveFilter.js"></script>
    <script src="../assets/js/chatboxManager.js"></script>
    <script src="../assets/js/extents.js"></script>
    <script src="../assets/js/app.js"></script>
    <script src="../assets/js/demo-settings.js"></script>
    <script src="../assets/js/sidebar.js"></script>
    <script>
      /*<![CDATA[*/
      $(function() {
        App.init();
        DemoSettings.init({
          urlThemes: '/templates/social/assets/css/themes/social.theme-'
        });
        SideBar.init({
          shortenOnClickOutside: false
        });
      });
      /*]]>*/
    </script>
    <!-- END GENERAL JAVASCRIPT CODE -->
    <!-- BEGIN JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <script src="../assets/plugins/jquery.validation/jquery.validate.js"></script>
    <script src="../assets/plugins/jquery.validation/localization/messages_zh.js"></script>
    <script src="../assets/plugins/jquery.chosen/chosen.jquery.min.js"></script>
    <script src="../assets/plugins/jquery.maskedinput/jquery.maskedinput.min.js"></script>
    <script src="../assets/js/form-stuff.validation.js"></script>

    <script src="../assets/js/jquery.validate.extension.js" type="text/javascript"></script>

    <script>

    var rulesOpts = null;
    function InitRules() {
            var dataInfo = { a: 'cpwd', opw: function () { return $("#txtOPwd").val(); } };
            var remoteInfo = GetRemoteInfo('/Ajax/AjaxValid.ashx', dataInfo);
            rulesOpts = {
                <%=txtOPwd.UniqueID %>: {
                    required: true,
                    remote: remoteInfo
                },
                <%=txtPwd.UniqueID %>: {
                    required: true,
                    minlength: 6,
                    maxlength: 16
                },
                <%=txtRePwd.UniqueID %>: {
                    required: true,
                    minlength: 6,
                    equalTo: "#txtPwd"
                }
            };
        }         
        InitRules();        
        
        $(function () {            
            FormValidation.init();
        });
    </script>
    <!-- END JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <!-- END JAVASCRIPT CODES -->
</asp:Content>
