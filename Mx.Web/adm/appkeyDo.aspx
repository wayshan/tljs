<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="appkeyDo.aspx.cs" Inherits="Mx.Web.adm.appkeyDo" %>

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
                <li><a href="appkeyList.aspx">授权管理</a> <span class="icon-angle-right"></span></li>
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
                    添加/编辑</h4>
            </div>
            <div class="body">
                <fieldset class="span6 offset2">                                    
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            AppKey</label>
                        <div class="controls">
                            <asp:TextBox ID="txtAppKey" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="AppKey"></asp:TextBox>
                        </div>
                    </div>
                     <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            AppSecret</label>
                        <div class="controls">
                            <asp:TextBox ID="txtAppSecret" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="AppSecret"></asp:TextBox>
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            名称</label>
                        <div class="controls">
                            <asp:TextBox ID="txtAppName" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="名称"></asp:TextBox>
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            淘宝授权帐号</label>
                        <div class="controls">
                            <asp:TextBox ID="txtTbAccount" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="淘宝授权帐号"></asp:TextBox>
                        </div>
                    </div>
                    <!-- Multiple Checkboxes (inline) -->
                    <div class="control-group">
                        <label class="control-label">
                            是否默认
                        </label>
                        <div class="controls">
                            <label class="checkbox">
                                <asp:CheckBox ID="chbIsDefault" ClientIDMode="Static" runat="server" />
                            </label>
                        </div>
                    </div>
                </fieldset>
                <div class="clearfix">
                </div>
                <div class="form-actions" style="display:none">
                    <div class="span6 offset2">
                        <asp:Button ID="BtnSubmit" ClientIDMode="Static" OnClick="BtnSubmit_Click" Text="添加" runat="server" class="btn btn-primary"
                            data-loading-text="提交中..." />
                        <asp:Button ID="BtnUpdate" ClientIDMode="Static" OnClick="BtnUpdate_Click" Text="更新" runat="server" Visible="false"
                            class="btn btn-success" data-loading-text="提交中..." />
                        <button id="cancel-button" onclick="location.href='AdminList.aspx'" type="button"
                            class="btn btn-danger">
                            取消</button>
                            
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentJs" runat="server">
    <!-- BEGIN JAVASCRIPT CODES -->
    <!-- BEGIN GENERAL JAVASCRIPT CODE -->
    <script>        window.jQuery || document.write('<script src="../assets/plugins/jquery/jquery.min.js"><\/script>')</script>
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
    <script>

        var rulesOpts = {
            <%=txtAppKey.UniqueID %>: {
                required: true
            },
            <%=txtAppSecret.UniqueID %>: {
                required: true
            },
            <%=txtAppName.UniqueID %>: {
                required: true
            },
            <%=txtTbAccount.UniqueID %>: {
                required: true
            }          
        };
        
        
        $(function () {            
            FormValidation.init();
        });
    </script>
    <!-- END JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <!-- END JAVASCRIPT CODES -->
</asp:Content>
