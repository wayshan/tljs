<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Mx.Web.adm.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .textlable
    {
      float: left;
      padding-top: 5px;
      padding-left: 10px;
      font-weight:bold;
    }
    .cursorauto
    {
       cursor:auto;
        }
</style>
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
                    信息统计[每1分钟自动更新数据]
                </h4>
            </div>
            <div class="body">
                <fieldset class="span12 offset">                   
                    <div class="control-group">
                        <label class="control-label cursorauto">
                            目前工作手机：</label>
                        <span id="LbTotalMobileCount" class="textlable"></span>                        
                        <label class="control-label cursorauto">
                            正常工作：</label>                        
                        <a href="MobileStatusList.aspx?sta=1">
                        <span id="LbWorkCount" class="textlable"></span></a>
                        <label class="control-label cursorauto">
                            非正常：</label>  
                        <a href="MobileStatusList.aspx?sta=-1">
                        <span id="LbNotWorkCount" class="textlable"></span>
                        </a>
                    </div>
                                  
                    <div class="control-group">
                        <label class="control-label cursorauto">
                            数据源数量：</label>                        
                        <span id="LbDataCount" class="textlable"></span>                       
                    </div>

                    <div class="control-group">
                        <label class="control-label cursorauto">
                            最新特殊日志：</label>                         
                    </div>
                    
                    <div class="social-box">
                        <div class="body">
                            <table class="table table-bordered table-striped table-hover" id="footable">
                                <thead>
                                    <tr>
                                        <th data-type="numeric" data-sort-ignore="true">
                                            ID
                                        </th>                            
                                        <th data-sort-ignore="true">
                                            手机类型
                                        </th>
                                        <th data-sort-ignore="true">
                                            手机编号
                                        </th>
                                        <th data-hide="phone" data-sort-ignore="true">
                                            IMEI
                                        </th>
                                        <th data-hide="phone" data-sort-ignore="true">
                                            备注
                                        </th>
                                        <th data-hide="phone" data-sort-ignore="true">
                                            添加时间
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    
                                </tbody>                    
                            </table>
                        </div>
                    </div>                    

                </fieldset>
                <div class="clearfix">
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
    
    <script>

        $(function () {
            initData();
            setInterval(initData, 60000);
        })

        function initData() {            
            $.ajax({
                type: 'GET',
                url: "/Ajax/OtherHandler.ashx",
                data: { "act": "adindex" },
                beforeSend: function () { $("table tbody").html("<tr><td colspan='6'>加载中……</td></tr>") },
                success: function (result) {
                    // alert(result.notWorkCount);
                    $("#LbTotalMobileCount").html(result.totalMobileCount);
                    $("#LbWorkCount").html(result.workCount);
                    $("#LbNotWorkCount").html(result.notWorkCount);
                    $("#LbDataCount").html(result.totalSourceCount);                    
                    $("table tbody").html("")
                    var strHtml = "";
                    $.each(result.loglist, function (i, item) {
                        strHtml += "<tr>";
                        strHtml += "<td>" + item.ID + "</td>";
                        strHtml += "<td>" + item.MType + "</td>";
                        strHtml += "<td>" + item.MNo + "</td>";
                        strHtml += "<td>" + item.IMEI + "</td>";
                        strHtml += "<td>" + item.Remarks + "</td>";
                        strHtml += "<td>" + item.AddTime + "</td>";
                        strHtml += "</tr>";
                    })
                    $("table tbody").html(strHtml)
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus)
                },
                dataType: "json"
            });
            
        }
    </script>
    
    <!-- END JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <!-- END JAVASCRIPT CODES -->
</asp:Content>
