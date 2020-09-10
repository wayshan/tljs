<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="plansDo.aspx.cs" Inherits="Mx.Web.adm.plansDo" %>

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
                <li><a href="plansDo.aspx">添加定向计划</a> <span class="icon-angle-right"></span></li>
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
                    添加/编辑</h4>
            </div>
            <div class="body">
                <fieldset class="span8 offset2"> 
                    
                     <div class="control-group" >
                        <label class="control-label">
                            计划链接</label>
                        <div class="controls">
                            <asp:TextBox ID="txtplan_link" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="计划链接"></asp:TextBox>
                        </div>
                    </div>  
                    <div class="control-group">
                        <label class="control-label">
                            商品链接：</label>
                        <div class="controls">
                            <asp:TextBox ID="goods_link" ClientIDMode="Static" class="input-block-level span9" runat="server" placeholder="可输入淘宝商品ID或淘宝商品链接"></asp:TextBox>
                            <span class="help-inline">
                                <button class="btn getGoodsInfo" type="button" data-loading-text="loading stuff...">读取数据</button>
                            </span>
                        </div>
                    </div>                   
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
                    <div class="control-group" >
                        <label class="control-label">
                            定向佣金比例</label>
                        <div class="controls">
                            <asp:TextBox ID="txtcommission_dx" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="定向佣金比例"></asp:TextBox>
                        </div>
                    </div> 
                     <div class="control-group" >
                        <label class="control-label">
                            营销佣金比例</label>
                        <div class="controls">
                            <asp:TextBox ID="txtcommission_MKT" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="营销佣金比例"></asp:TextBox>
                        </div>
                    </div>                     
                    <div class="control-group" >
                        <label class="control-label">
                            计划名称</label>
                        <div class="controls">
                            <asp:TextBox ID="txtplan_name" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="计划名称"></asp:TextBox>
                        </div>
                    </div> 
                   <div class="control-group" >
                        <label class="control-label">
                            计划id</label>
                        <div class="controls"> 
                            <asp:TextBox ID="txtcampaignId" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="计划id"></asp:TextBox>
                        </div>
                    </div> 
                    
                   <div class="control-group">
                        <label class="control-label">
                            优惠券链接(选填)</label>
                        <div class="controls">
                            <asp:TextBox ID="txtquan_link" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="优惠券链接"></asp:TextBox>
                        </div>
                    </div>   
                    
                    <div class="control-group">
                        <label class="control-label">
                            付款金额</label>
                        <div class="controls">
                            <asp:TextBox ID="txtPayMoney" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="付款金额"></asp:TextBox>
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
        
    </script>

    <script>
        var isDx = false;
        var rulesOpts = {
            
            <%=txtplan_link.UniqueID %>: {
                required: true
            },
            
        };
        
        $("#item_pic").click(function(){
            layer.open({
              type: 1,
              title: false,
              closeBtn: 0,
              area: ['auto'],
              skin: 'layui-layer-nobg', //没有背景色
              shadeClose: true,
              content: $('#item_pic2')
            });
        })
      
        $(".getTomTime").click(function(){
                $.ajax({
                    url: '../Ajax/OtherHandler.ashx',
                    type: 'GET',
                    async: false,
                    data: {
                        act: 'gettomdate'
                    },
                    dataType: 'text',
                    beforeSend: function (xhr) {
                        $(".getTomTime").text("读取中..")
                    },
                    success: function (data, textStatus, jqXHR) {
                       var objJson = JSON.parse(data);
                       console.log(objJson.stime)                
                       $("#txtcreatetime").val(objJson.stime);
                       $(".getTomTime").text("明天零时");
                    }
                })

        })
        $(".getGoodsInfo").click(function(){
            var gid = $("#goods_link").val();
            var appkeyid = $("#ContentPage_ddlAppKeyID").val();
     
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
                       $("#item_pic").attr("src",goods.pic);
                       $("#txtitem_pic").val(goods.pic);                       
                       $("#item_pic2>img").attr("src",goods.pic);
                       if(isDx==true||goods.campaignType=='DX')
                       {
                            $("#ddlCampaignType").val('DX');
                       }
                       else{
                            $("#ddlCampaignType").val('MKT');
                       }
                       $("#txtper_face").keyup();
                       $(".getGoodsInfo").text("读取数据");
                    }
                })
         })

        
        $(function () {            
            FormValidation.init();
        });




      



    </script>
    <!-- END JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <!-- END JAVASCRIPT CODES -->
</asp:Content>
