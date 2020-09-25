<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="TljDo.aspx.cs" Inherits="Mx.Web.adm.TljDo" %>

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
                <li><a href="TljList.aspx">转换记录</a> <span class="icon-angle-right"></span></li>
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
                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            推广位</label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlAppKeyID" runat="server">                                                   
                            </asp:DropDownList>
                            
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
                            佣金计划类型</label>
                        <div class="controls controls-row">
                            <asp:DropDownList ID="ddlCampaignType" ClientIDMode="Static" runat="server"> 
                             <asp:ListItem Value="MKT" Text="营销" ></asp:ListItem>
                             <asp:ListItem Value="DX" Text="定向" ></asp:ListItem>      
                            </asp:DropDownList>
                            <span class="ifokplan" style="color:Red;"></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">
                            活动编码</label>
                        <div class="controls">
                            <asp:TextBox ID="txtActiveCode" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="活动编码"></asp:TextBox>                                                       
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

                    <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            佣金比例</label>
                        <div class="controls">
                            <asp:TextBox ID="txtcommission_bili" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="佣金比例"></asp:TextBox>
                        </div>
                    </div>

                     <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            优惠券金额</label>
                        <div class="controls">
                            <asp:TextBox ID="txtquanPrice" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="优惠券金额"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            券后价</label>
                        <div class="controls">
                             <asp:TextBox ID="txtpagePrice" ClientIDMode="Static" class="input-block-level span6" runat="server" placeholder="券后价格"></asp:TextBox> 元
                     
                        </div>
                    </div>

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            淘礼金名称</label>
                        <div class="controls">
                           
                            <asp:DropDownList ID="ddlname" runat="server"> 
                            <asp:ListItem Value="会员福利！" Text="会员福利！"></asp:ListItem>
                            <asp:ListItem Value="福利！！！" Text="福利！！！"></asp:ListItem>                                                  
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="control-group" <%=xianshi%> >
                        <label class="control-label">
                            优惠券链接(选填)</label>
                        <div class="controls">
                            <asp:TextBox ID="txtquan_link" ClientIDMode="Static" class="input-block-level" runat="server" placeholder="优惠券链接"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            批次</label>
                        <div class="controls">
                            <asp:TextBox ID="txtbatch" ClientIDMode="Static" class="input-block-level span2" runat="server" placeholder="整数"></asp:TextBox>
                            个
                        </div>
                    </div>

                     <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            总个数</label>
                        <div class="controls">
                            <asp:TextBox ID="txttotal_num" ClientIDMode="Static" class="input-block-level span2" runat="server" placeholder="总个数"></asp:TextBox>
                            个
                        </div>
                    </div>

                      <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            礼金面额</label>
                        <div class="controls controls-row">
                            <asp:TextBox ID="txtper_face" ClientIDMode="Static" class="input-block-level span2" runat="server" placeholder="0.00"></asp:TextBox>
                            <span class="help-inline">元</span>
                            <span class="yjyl" style="color:Red; font-size:20px"></span>
                        </div>
                    </div>

                      <!-- Text input-->
                    <div class="control-group">
                        <label class="control-label">
                            单用户可领取次数</label>
                        <div class="controls">
                            <asp:TextBox ID="txtuser_total_win_num_limit" ClientIDMode="Static" class="input-block-level span2" runat="server" placeholder="整数" Text="1"></asp:TextBox>
                        </div>
                    </div>

                      <!-- Text input-->
                    <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            领取时间</label>
                        <div class="controls controls-row">
                            <asp:TextBox ID="txtsend_start_time" ClientIDMode="Static" class="input-block-level span5" runat="server" placeholder="开始时间"></asp:TextBox>

                            <asp:TextBox ID="txtsend_end_time" ClientIDMode="Static" class="input-block-level span5" runat="server" placeholder="结束时间"></asp:TextBox>
                            <span class="help-inline">
                                <button class="btn getTomTime" type="button">明天零时</button>
                            </span>
                            
                        </div>
                    </div>


                    <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            使用时间</label>
                        <div class="controls">
                            <asp:TextBox ID="txtuse_end_time" ClientIDMode="Static" class="input-block-level span3" runat="server" Text="1" placeholder="使用时间"></asp:TextBox>
                            <span class="help-inline">天</span>
                        </div>
                    </div>

                    <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            淘礼金创建时间</label>
                        <div class="controls controls-row">
                            <asp:TextBox ID="txtcreatetime" ClientIDMode="Static" class="input-block-level span5" runat="server" placeholder="开始时间"></asp:TextBox>  
                        </div>
                    </div>

                    <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            创建优先级别</label>
                        <div class="controls">
                            <asp:DropDownList ID="ddliftop" runat="server"> 
                                 <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                 <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                 <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                 <asp:ListItem Value="3" Text="3"></asp:ListItem>                                             
                            </asp:DropDownList>                            
                        </div>
                    </div>

                    <div class="control-group" <%=xianshi%>>
                        <label class="control-label">
                            备注</label>
                        <div class="controls controls-row">
                            <asp:TextBox ID="txtRemark" ClientIDMode="Static" TextMode="MultiLine" class="input-block-level span6" runat="server" placeholder="备注"></asp:TextBox>  
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
        laydate.skin('danlan');
        var start = {
            elem: '#<%=txtsend_start_time.ClientID %>',
            //festival: true,
            format: 'YYYY-MM-DD hh:mm:ss',
            istime: true,
            choose: function (datas) {
                end.min = datas;
                end.start = datas;
            }
        };
        var end = {
            elem: '#<%=txtsend_end_time.ClientID %>',
            //festival: true,
            format: 'YYYY-MM-DD hh:mm:ss',
            istime: true,
            choose: function (datas) {
                start.max = datas;
            }
        };
        var create = {
            elem: '#<%=txtcreatetime.ClientID %>',           
            format: 'YYYY-MM-DD hh:mm:ss',
            istime: true
            
        };
        

        laydate(start);
        laydate(end);
        laydate(create); 
    </script>

    <script>
        var isDx = false;
        var rulesOpts = {
            <%=txtitem_id.UniqueID %>: {
                required: true
            },
            <%=txtgoodsname.UniqueID %>: {
                required: true
            },
            <%=ddlname.UniqueID %>: {
                required: true
            },
            <%=txtbatch.UniqueID %>: {
                required: true,
                digits:true,
                min:1
            },   
            <%=txttotal_num.UniqueID %>: {
                required: true,
                digits:true,
                min:1,
                ActCode:"#txtActiveCode"
            },
            <%=txtper_face.UniqueID %>: {
                required: true,
            },
            <%=txtuser_total_win_num_limit.UniqueID %>: {
                required: true,
                digits:true,
                min:1
            },           

             <%=txtsend_start_time.UniqueID %>: {
                required: true
            },
            <%=txtsend_end_time.UniqueID %>: {
                required: true
            },
            <%=txtuse_end_time.UniqueID %>: {
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
                       $("#txtsend_start_time").val(objJson.stime);
                       $("#txtsend_end_time").val(objJson.etime);
                       $("#txtcreatetime").val(objJson.stime);
                       $(".getTomTime").text("明天零时");
                    }
                })

        })
        $("#ContentPage_ddlAppKeyID").change(function(){
            $('.getGoodsInfo').click();
        });
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
                           $(".ifokplan").text('已通过定向');
                           $(".ifokplan").css("color","#ff910e");                           
                       }
                       else if(goods.campaignType=='MKT')
                       {
                           $("#ddlCampaignType").val('MKT');
                           $(".ifokplan").text('未通过的定向，请注意！！！');
                           $(".ifokplan").css("color","#f70404");
                       }
                       else{
                           $("#ddlCampaignType").val('MKT');
                       }
                       $("#txtper_face").keyup();
                       $(".getGoodsInfo").text("读取数据");
                    }
                })
         })

         $("#txtper_face").keyup(function(){
            var bili = parseFloat($("#txtcommission_bili").val());
            var pagePrice = parseFloat($("#txtpagePrice").val());
            var per_face = parseFloat($(this).val());
            if(isNaN(bili)||isNaN(pagePrice)||isNaN(per_face))
            {
                $(".yjyl").text('');
                return;
            }

            
            $(".yjyl").text('预计盈利：'+ Math.round(((pagePrice * (bili/100))*0.88 - per_face)*100)/100+'元')

         });


         <%= initJs%>

         
        $(function () {            
            FormValidation.init();

            jQuery.validator.addMethod("ActCode", function(value, element, param) {
                if($(param).val()!="")
                {
                    return value==1;
                }
                return true;
            }, $.validator.format("录入活动编码，总个数必须是1!"));
        });




      



    </script>
    <!-- END JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <!-- END JAVASCRIPT CODES -->
</asp:Content>
