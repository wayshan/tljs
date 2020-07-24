<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="TljList.aspx.cs" Inherits="Mx.Web.adm.TljList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentNav" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <%--<h3 class="page-title">
                            Font Icon Sidebar
                        </h3>--%>
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="#">首页</a> <span class="icon-angle-right"></span>
                </li>
                <li><a href="TljList.aspx">转换记录</a> <span class="icon-angle-right"></span></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12">
        <div class="social-box">
            
            <div class="header">
               <div class="btn-group">
                    <a class="btn btn-primary" id="add-row" href="TljDo.aspx"><i class="icon-pencil"></i>
                        添加</a> 
                </div>
                
                <div class="tools">                    
                    <asp:LinkButton ID="btnExcel" OnClick="btnExcel_Click" runat="server" CssClass="btn btn-success">
                    <i class="icon-arrow-down"></i>
                        导出Excel
                    </asp:LinkButton>
                </div>                
            </div>
                    
            <div class="body">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="dataTables_search" style=" margin-bottom:5px">                                                   
                            商品名称、商品ID: <asp:TextBox ID="txtKeyWords" runat="server"></asp:TextBox>    
                            日期：<asp:TextBox ID="txtDateStart" Width="150" class="laydate-icon" runat="server"></asp:TextBox> —
                            <asp:TextBox ID="txtDateEnd" Width="150" class="laydate-icon" runat="server"></asp:TextBox>                                                    
                            
                            是否已领：<asp:DropDownList ID="ddlifget" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>                                
                                <asp:ListItem Value="true" Text="已领取"></asp:ListItem>
                                <asp:ListItem Value="false" Text="未领取"></asp:ListItem>                               
                            </asp:DropDownList> 

                            状态：<asp:DropDownList ID="ddlIfok" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部" Selected="True"></asp:ListItem>                                
                                <asp:ListItem Value="已生成" Text="已生成" ></asp:ListItem>
                                <asp:ListItem Value="未创建" Text="未创建"></asp:ListItem> 
                                <asp:ListItem Value="失败" Text="失败"></asp:ListItem> 
                            </asp:DropDownList> 
                            <asp:DropDownList ID="ddlIfsingle" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部" Selected="True"></asp:ListItem>                                
                                <asp:ListItem Value="0" Text="单份" ></asp:ListItem>
                                <asp:ListItem Value="1" Text="非单份"></asp:ListItem> 
                            </asp:DropDownList>

                            <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-warning">                       
                                查询
                            </asp:LinkButton>
                        </div>
                    </div>
                 </div>

                <table class="table table-bordered table-striped table-hover" id="footable">
                    <thead>
                        <tr>  
                            <th data-hide="phone" data-sort-ignore="true">
                                商品
                            </th> 
                            <th data-sort-ignore="true">
                                基础信息
                            </th>  
                            <th data-hide="phone" data-sort-ignore="true">
                                状态
                            </th>                            
                            <th data-sort-ignore="true" data-hide="phone"> 
                                领取情况
                            </th> 
                            <th data-sort-ignore="true" data-hide="phone"> 
                                推广/口令
                            </th>                                          
                                                      
                            <th data-sort-ignore="true">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                       <img src="<%#Eval("item_pic")%>" style="width:100px;height:100px;" />  
                                    </td>
                                    <td>
                                        <a href="https://detail.tmall.com/item.htm?id=<%#Eval("item_id")%>" target="_blank" style=" width:100px;height:100px;"  >
                                        商品名称：<%#Eval("goodsname")%></a><br />
                                        淘礼金名称：<%#Eval("name")%><br />
                                        商品ID：<%#Eval("item_id")%><%#Eval("campaigntype")!=null && Eval("campaigntype").ToString()=="DX"?"<span style='color:Red;font-weight:bold'>（定向计划）</span>":""%><br />
                                        发放个数：<%#Eval("total_num")%><br />
                                        礼金金额：<%#Eval("per_face")%>元　　非礼金券后价<%#Eval("PayMoney")%>元　　盈利：<%#Eval("yjyl")%>元<br />
                                        限领个数：<%#Eval("user_total_win_num_limit")%><br />
                                        创建时间：<%#Eval("createtime")%> 录入时间<%#Eval("zctime")%> <br />
                                        生成时间：<%#Eval("dotime")%> <br />
                                        开始时间：<%#Eval("send_start_time")%> 结束时间：<%#Eval("send_end_time")%><br />
                                        佣金比例：<span id="biliold_<%#Eval("ID")%>"><%#Eval("commission_bili")%></span>%<br />
                                        产品类型：<%#Eval("goodstype")%>
                                    </td>  
                                    <td>
                                        <span class="ifokRemark" href="#" data-placement="bottom" data-toggle="tooltip" title="<%#Eval("remark")%>">
                                            <%#Eval("ifok") %>
                                        </span>
                                    </td>                                     
                                    <td>
                                        <a class="a_detail" style=" cursor:pointer">查看领取明细</a>
                                        <p class="win_detail" style="display:none">
                                        红包领取金额：<%#Eval("win_amount")%><br />		
                                        红包领取个数：<%#Eval("win_num")%>	<br />		
                                        引导成交金额：<%#Eval("alipay_amount")%>	<br />		
                                        预估佣金金额：<%#Eval("pre_commission_amount")%><br />			
                                        红包核销金额：<%#Eval("use_amount")%>	<br />		
                                        红包核销个数：<%#Eval("use_num")%>	<br />		
                                        失效回退金额：<%#Eval("refund_amount")%><br />			
                                        失效回退个数：<%#Eval("refund_num")%>	<br />		
                                        解冻红包个数：<%#Eval("unfreeze_num")%>	<br />		
                                        解冻金额：<%#Eval("unfreeze_amount")%>		
                                        </p>

                                    </td>                                                                                            
                                    <td>
                                        <div style="<%#Eval("ifok").ToString()=="已生成"?"":"display:none" %>">

                                        <p style="padding:5px" class="<%#Eval("ifget") != null && bool.Parse(Eval("ifget").ToString()) ? "badge badge-success" : "badge badge-important"%>">是否已领取：<span id="span_ifget<%#Eval("ID")%>"><%#Eval("ifget") != null && bool.Parse(Eval("ifget").ToString())?"是":"否"%></span></p>
                                        
                                        <p>领取时间:<span id="span_gettime<%#Eval("ID")%>"><%#Eval("gettime")%></span></p>
                                        
                                        <button class="btn btnCopy" value="<%#Eval("ID")%>"  style='<%#Eval("kouling")==null || Eval("kouling").ToString() == "" ? "display:none" : ""%>' type="button" data-clipboard-text="<%#Eval("kouling") %>">
                                            复制口令
                                        </button>
                                        </div>
                                    </td>
                                    <td>  
                                     <button class="btn btnCheck" gid="<%#Eval("item_id")%>" appkeyid="<%#Eval("appkeyid")%>"  value="<%#Eval("ID")%>" type="button" >
                                        <i class="icon-check"></i>佣金检测
                                           </button> 
                                           
                                        <a href="javascript:;" gid="<%#Eval("item_id")%>" lj="<%#Eval("per_face")%>" ql="<%#Eval("quan_link")%>" ct="<%#Eval("campaigntype")%>" class="btn btnChoose">
                                            <i class="icon-search"></i> 
                                            再次采用</a> 
                                                                         
                                       <%-- <asp:LinkButton ID="LbEdit" OnClick="LbEdit_Click" CommandArgument='<%#Eval("ID")%>'
                                            CssClass="btn" runat="server">
                                                        <i class="icon-check"></i>佣金检测
                                        </asp:LinkButton> --%> 
                                        <span style="<%#Eval("ifget").ToString()=="True"?"display:none":"" %>">
                                        <asp:LinkButton ID="LbDel" OnClick="LbDel_Click" OnClientClick="return confirm('确认删除？')"
                                            CommandArgument='<%#Eval("ID")%>' CssClass="btn" runat="server">
                                                        <i class="icon-trash"></i>删除
                                        </asp:LinkButton>  
                                        </span>                                    
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>       
                                <asp:PlaceHolder ID="phEmptyData" runat="server" Visible='<%#bool.Parse((rpData.Items.Count==0).ToString())%>'>
                                    <tr>
                                    <td style=" text-align:center" colspan="6">
                                        <div class="alert alert-info">                                          
                                          <strong>没有符合的数据！</strong> 
                                        </div>
                                    </td>
                                    </tr>
                                </asp:PlaceHolder>       
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>
                            <span>每页数量：</span>
                                <asp:TextBox ID="txtPageSize" Width="40" MaxLength="6" Text="30" runat="server" 
                                     AutoPostBack="True" ontextchanged="txtPageSize_TextChanged"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <webdiyer:AspNetPager ID="ShowPager" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                                    HorizontalAlign="left" ShowCustomInfoSection="Left" CustomInfoClass="pageCustom"
                                    CustomInfoHTML="共有  <b><font color='red'>%RecordCount%</font></b>  条记录 当前页<b><font color='red'>%CurrentPageIndex%</font>/%PageCount%</b>"
                                    meta:resourcekey="AspNetPager1" Style="font-size: 12px" AlwaysShow="True" FirstPageText="<span class='page_l'>首页</span>"
                                    LastPageText="<span class='page_r'>末页</span>" NextPageText="<span class='page_r'>下一页</span>"
                                    PageSize="10" PrevPageText="<span class='page_l'>上一页</span>" NumericButtonCount="8"
                                    ShowInputBox="Never" CssClass="paginator"  CurrentPageButtonClass="cpb" CustomInfoSectionWidth="">
                                </webdiyer:AspNetPager>
                                <%--<div class="pagination pagination-centered">
                                                </div>--%>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>


    <div id="checkyongjin">
        <div class="checking" style="padding:20px; display:none">
            <img src="../assets/img/loading.gif" />佣金检测中，请稍等…
        </div>
        <div class="checkdone" style="padding:20px; display:none">
            <span>检测佣金比例为：<span id="bilinew">0</span>%</span><br /><br />
            <span style=" color:Red">原佣金为：<span id="biliold">0</span>%<span id="bilierror" style="display:none">，检测佣金与实际佣金比例不符，请检查核实</span></span>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentJs" runat="server">
    <!-- Le javascript -->
    <script>        window.jQuery || document.write('<script src="../assets/plugins/jquery/jquery.min.js"><\/script>')</script>
    <script src="../assets/plugins/jquery.ui/jquery-ui-1.10.1.custom.min.js"></script>
    <script src="../assets/plugins/jquery.ui.touch-punch/jquery.ui.touch-punch.js"></script>
    <script src="../assets/plugins/twitter-bootstrap/bootstrap.js"></script>
    <script src="../assets/plugins/jquery.slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../assets/plugins/twitter-bootstrap/bootstrap-tooltip.js"></script>
    
    <script src="../assets/js/extents.js"></script>
    <!-- Iteractivity for the sidebar -->
    <script src="../assets/js/sidebar.js"></script>
    <!-- BEGIN JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <script src="../assets/plugins/jquery.footable/footable.min.js"></script>
    <script src="../assets/plugins/jquery.footable/footable.sort.min.js"></script>
    <script src="../assets/plugins/jquery.footable/footable.paginate.min.js"></script>
    <script src="../assets/js/clipboard.js" type="text/javascript"></script>
    <script src="../assets/plugins/layer/layer.js" type="text/javascript"></script>
    <script src="../assets/plugins/laydate/laydate.js"></script>
    <script>
        laydate.skin('danlan');
        var start = {
            elem: '#<%=txtDateStart.ClientID %>',
            //festival: true,
            format: 'YYYY-MM-DD hh:mm:ss',
            istime: true,
            choose: function (datas) {
                end.min = datas;
                end.start = datas;
            }
        };
        var end = {
            elem: '#<%=txtDateEnd.ClientID %>',
            //festival: true,
            format: 'YYYY-MM-DD hh:mm:ss',
            istime: true,
            choose: function (datas) {
                start.max = datas;
            }
        };
        laydate(start);
        laydate(end); 
    </script>
    <script>
        $(function () {
            //$('#footable').footable();

            $('.ifokRemark').tooltip()
        });


        var clipboard = new Clipboard('.btnCopy');
        clipboard.on('success', function (e) {            
            var id = $(e.trigger).val();
            $.ajax({
                url: '../Ajax/OtherHandler.ashx',
                type: 'GET',
                async: false,
                data: {
                    act: 'upgettime',
                    id: id
                },
                dataType: 'text',
                beforeSend: function (xhr) {

                },
                success: function (data, textStatus, jqXHR) {
                    var objJson = JSON.parse(data);
                    var gettimeObj = JSON.parse(objJson.Message);
                    $("#span_ifget" + id).text(gettimeObj.ifget);
                    $("#span_gettime" + id).text(gettimeObj.gettime);
                    
                }
            })


            layer.msg('复制成功', { time: 2000 });
            e.clearSelection();
        });
        clipboard.on('error', function (e) {

        });

        $(".a_detail").click(function () {
            $(this).next().toggle();
        })

        $(".btnCheck").click(function () {
            var gid = $(this).attr("gid");
            var appkeyid = $(this).attr("appkeyid");
            var id = $(this).val();
            var oldbili = $("#biliold_" + id).text();

            $(".checking").hide();
            $(".checkdone").hide();
            $("#bilierror").hide();
            layer.open({
                type: 1,
                offset: 'auto',
                title: '佣金检测',
                content: $('#checkyongjin'),
                btn: '确定',
                btnAlign: 'c',
                shade: 0,
                yes: function () {
                    layer.closeAll();
                },
                success: function (layero, index) {

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
                            $(".checking").show();
                        },
                        success: function (data, textStatus, jqXHR) {
                            var objJson = JSON.parse(data);
                            var goods = JSON.parse(objJson.Message);

                            $("#bilinew").html(goods.bili);
                            $("#biliold").html(oldbili);

                            if (goods.bili != oldbili) {
                                $("#bilierror").show();
                            }
                            setTimeout(function () {
                                $(".checking").hide();
                                $(".checkdone").show();
                             },400)
                            


                        }
                    })
                }
            });

        })

        $(".btnChoose").click(function () {
            var gid = $(this).attr("gid");
            var lj = $(this).attr("lj");
            var ql = $(this).attr("ql");
            var ct = $(this).attr("ct");
            location.href = 'TljDo.aspx?gid=' + gid + '&lj=' + lj + '&ql=' + encodeURIComponent(ql) + '&ct=' + ct;
        })
       
    </script>
    <!-- END JAVASCRIPT CODES FOR THE CURRENT PAGE -->
    <script>
      /*<![CDATA[*/
      $(function() {
        SideBar.init({shortenOnClickOutside: false});
      });
      /*]]>*/
    </script>
</asp:Content>
