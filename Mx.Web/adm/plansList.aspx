<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="plansList.aspx.cs" Inherits="Mx.Web.adm.plansList" %>

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
                <li><a href="plansList.aspx">高佣金计划列表</a> <span class="icon-angle-right"></span></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12">
        <div class="social-box">
            
            <div class="header">
                <div class="btn-group">
                    <a class="btn btn-primary" id="add-row" href="plansDo.aspx"><i class="icon-pencil"></i>
                        添加</a> 
                </div>
                <div class="tools">                    
                    
                </div>                
            </div>
                    
            <div class="body">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="dataTables_search" style=" margin-bottom:5px">                                                   
                            商品名称：<asp:TextBox ID="txtitem_id" runat="server"></asp:TextBox>
                            商品名称：<asp:TextBox ID="txtgoodsname" runat="server"></asp:TextBox> 
                            店铺名称：<asp:TextBox ID="txtshopname" runat="server"></asp:TextBox> 
                           
                            状态：<asp:DropDownList ID="ddlifok" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>                                
                                <asp:ListItem Value="正常" Text="正常"></asp:ListItem>
                                <asp:ListItem Value="失效" Text="失效"></asp:ListItem>                            
                            </asp:DropDownList>                           

                            排序：
                            <asp:DropDownList ID="ddlsort" runat="server" style=" width:auto">                                                                
                                <asp:ListItem Value="1" Text="录入时间"></asp:ListItem>
                                <asp:ListItem Value="2" Text="今日高拥比例"></asp:ListItem>
                                <asp:ListItem Value="3" Text="最新通过定向"></asp:ListItem>                            
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
                            <th data-hide="phone" data-sort-ignore="true">
                                基础信息
                            </th> 
                            <th data-hide="phone" data-sort-ignore="true">
                                付款价格
                            </th>   
                            <th data-hide="phone" data-sort-ignore="true">
                                账号（已过）
                            </th> 
                             <th data-hide="phone" data-sort-ignore="true">
                                账号（申请中）
                            </th>                          
                            <th data-sort-ignore="true" data-hide="phone"> 
                                时间
                            </th>                                 
                            <th data-sort-ignore="true" data-hide="phone"> 
                                优惠券金额
                            </th>  
                            <th data-sort-ignore="true" data-hide="phone">
                                今日佣金比例
                            </th>                                                  
                            <th data-sort-ignore="true" data-hide="phone">
                                定向佣金比例
                            </th>
                             <th data-sort-ignore="true" >
                                营销佣金比例
                            </th>
                            <th>状态</th>

                             <th data-sort-ignore="true" >
                               操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr>                                   
                                    <td style="width:100px">
                                       <img src="<%#Eval("pic")%>" style="width:100px;height:100px;" onerror="this.src='/assets/img/nopic.jpg'"/>  
                                    </td>
                                    <td>
                                        商品Id：<%#Eval("item_id")%> <br />
                                        <a href="https://detail.tmall.com/item.htm?id=<%#Eval("item_id")%>" target="_blank" style="width:100px;height:100px;"  >
                                        商品名称：<%#Eval("goodsname")%></a><br />
                                        店铺名：<%#Eval("shopname")%>
                                    </td>  
                                    <td>
                                         <%#Eval("PayMoney")%>
                                    </td> 
                                    <td>
                                         <%#Eval("zhanghaos_ok")%>                                         
                                    </td> 
                                    <td>                                         
                                         <%#Eval("zhanghaos_doing")%>
                                    </td>                                     
                                    <td>
                                        <%# Eval("zctime")%>
                                    </td>                                                                                            
                                    <td>
                                        <%# Eval("coupon_price")%>
                                    </td>
                                    <td >
                                         <%# Eval("tdRatio")%>%
                                    </td>
                                    <td >
                                         <%# Eval("commission_dx")%>%
                                    </td>
                                    <td >
                                         <%# Eval("commission_MKT")%>%
                                    </td>
                                    <td style="width:40px">  
                                            <%#Eval("ifok")%>                       
                                    </td>
                                    <td >  
                                        <a href="<%#Eval("planlink")%>" target="_blank">
                                        查看计划
                                        </a> 
                                        
                                        <button class="btn btnCopy"  type="button" data-clipboard-text="<%#Eval("planlink") %>">
                                            复制计划
                                        </button>

                                        <button class="btn btnCopy"  type="button" data-clipboard-text="<%#Eval("coupon_url") %>">
                                            复制优惠券链接
                                        </button>
                                                                                                          
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>       
                                <asp:PlaceHolder ID="phEmptyData" runat="server" Visible='<%#bool.Parse((rpData.Items.Count==0).ToString())%>'>
                                    <tr>
                                    <td style=" text-align:center" colspan="12">
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
                            <td colspan="11">
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
        $(function () {
            //$('#footable').footable();

        });



        var clipboard = new Clipboard('.btnCopy');
        clipboard.on('success', function (e) {            
            layer.msg('复制成功', { time: 2000 });
            e.clearSelection();
        });
        clipboard.on('error', function (e) {

        });    
       
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
