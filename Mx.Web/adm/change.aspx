<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="change.aspx.cs" Inherits="Mx.Web.adm.change" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentNav" runat="server">
    <div class="row-fluid" >
        <div class="span12">
            <%--<h3 class="page-title">
                            Form validation
                        </h3>--%>
            <!-- BEGIN BREADCRUMBS -->
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="#">首页</a> <span class="icon-angle-right"></span>
                </li>
                <li><a href="TljList.aspx">直接转口令</a> <span class="icon-angle-right"></span></li>
            </ul>
            <!-- END BREADCRUMBS -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12" >
        <div class="social-box">
            <div class="header">
                <h4>
                    直接转口令</h4>
            </div>
            <div class="body">
                <fieldset class="span8 offset2">                                    
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            所属帐号</label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlAppKeyID" runat="server">                                                   
                            </asp:DropDownList>
                            
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            需转产品：</label>
                        <div class="controls">
                            <asp:TextBox ID="goods_link" ClientIDMode="Static" class="input-block-level span9" runat="server" placeholder="可输入淘宝商品ID，淘宝商品链接或许口令"></asp:TextBox>
                            <span class="help-inline">
                                <button class="btn getGoodsInfo" type="button" data-loading-text="loading stuff...">转连接</button>
                            </span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            优惠券链接(选填)</label>
                        <div class="controls">
                            <asp:TextBox ID="txtquan_link" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="优惠券链接"></asp:TextBox>
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            商品ID</label>
                        <div class="controls">
                            <asp:TextBox ID="txtitem_id" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="商品ID"></asp:TextBox>                            
                            <img id="item_pic" width="50px" height="50" src="/assets/img/nopic.jpg" style="width:50px;height:50px;"/>
                            <asp:HiddenField ID="txtitem_pic" ClientIDMode=Static runat="server" />
                        </div>
                    </div>
                     <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            商品名称</label>
                        <div class="controls">
                            <asp:TextBox ID="txtgoodsname" ClientIDMode="Static" class="input-block-level span10" runat="server" placeholder="商品名称"></asp:TextBox>
                        </div>
                    </div>
                    
            

                    <div class="control-group">
                        <label class="control-label">
                            佣金比例</label>
                        <div class="controls">
                            <asp:TextBox ID="txtcommission_bili" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="佣金比例"></asp:TextBox>
                        </div>
                    </div>

                     <div class="control-group" >
                        <label class="control-label">
                            优惠券金额</label>
                        <div class="controls">
                            <asp:TextBox ID="txtquanPrice" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="优惠券金额"></asp:TextBox> 此处只是读取默认券的金额
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            券后价</label>
                        <div class="controls">
                             <asp:TextBox ID="txtpagePrice" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="券后价格"></asp:TextBox> 元
                     
                        </div>
                    </div>
                   <div class="control-group">
                        <label class="control-label">
                            口令</label>
                        <div class="controls" style="font-size:xx-large">
                             <asp:TextBox ID="txtkouling" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="口令"   style="font-size:xx-large;height:50px;"></asp:TextBox> 
                          
                        </div>
                    </div>

                
                    
                </fieldset>
               
               
                <div class="clearfix">
                </div>
                <div class="form-actions" style="display:none">
                    <div class="span6 offset2">
   
                    </div>
                </div>
            </div>
        </div>
    </div>


<div id="item_pic2" class="hide" style="width: 720px; height: 540px;">  
    <img src="" style="max-width: 100%;">  
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

     <script src="../assets/plugins/layer/layer.js" type="text/javascript"></script>
    <script src="../assets/plugins/laydate/laydate.js"></script>


    <script>
        var rulesOpts = {};
        $(".getGoodsInfo").click(function(){
            var gid = $("#goods_link").val();
            var appkeyid = $("#ContentPage_ddlAppKeyID").val();
            var activityid = $("#txtquan_link").val();
     
            if(gid=="")
            {
                layer.msg('请输入淘宝商品ID或淘宝商品链接');                
            }
            $.ajax({
                    url: '../Ajax/OtherHandler.ashx',
                    type: 'GET',
                    async: false,
                    data: {
                        act: 'getgoodsinfo',
                        id: gid,
                        activityid: activityid,
                        appkeyid: appkeyid
                    },
                    dataType: 'text',
                    beforeSend: function (xhr) {
                        $(".getGoodsInfo").text("读取中..")
                    },
                    success: function (data, textStatus, jqXHR) {
                       var objJson = JSON.parse(data);
                       var goods = JSON.parse(objJson.Message);
                       console.log(goods)
                       $("#txtitem_id").val(goods.goodsid);
                       $("#txtgoodsname").val(goods.title);
                       $("#txtcommission_bili").val(goods.bili);
                       $("#txtquanPrice").val(goods.quanPrice);                       
                       $("#txtpagePrice").val(goods.pageprice);
                       $("#txtkouling").val(goods.kouling2);
                       $("#item_pic").attr("src",goods.pic);
                       $("#txtitem_pic").val(goods.pic);                       
                       $("#item_pic2>img").attr("src",goods.pic);

                       $(".getGoodsInfo").text("读取数据");
                    }
                })
         })

         <%= initJs%>


         
        $(function () {            
            FormValidation.init();
        });
    </script>
    <!-- END JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <!-- END JAVASCRIPT CODES -->
</asp:Content>
