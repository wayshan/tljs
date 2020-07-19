<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="ProductStat.aspx.cs" Inherits="Mx.Web.adm.ProductStat" %>

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
                <li><a href="OrdersList.aspx">订单统计</a> <span class="icon-angle-right"></span></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12">
        <div class="social-box">
            
            <div class="header">               
                
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
                            <asp:DropDownList ID="ddlDateTime" runat="server" style=" width:auto"> 
                                <asp:ListItem Value="创建时间" Text="创建时间"></asp:ListItem>  
                                <asp:ListItem Value="结算时间" Text="结算时间"></asp:ListItem>                               
                            </asp:DropDownList>
                            <asp:TextBox ID="txtDateStart" Width="150" class="laydate-icon" runat="server"></asp:TextBox> —
                            <asp:TextBox ID="txtDateEnd" Width="150" class="laydate-icon" runat="server"></asp:TextBox>                                                                               
                           
                          
                            推广位：<asp:DropDownList ID="ddlAppKeyID" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>
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
                                全部佣金
                            </th>                            
                            <th data-sort-ignore="true" data-hide="phone"> 
                                有效佣金
                            </th> 

                             <th data-sort-ignore="true" data-hide="phone"> 
                                礼金
                            </th> 
                             <th data-sort-ignore="true" data-hide="phone"> 
                                实际收益
                            </th> 

                            <th data-sort-ignore="true" data-hide="phone"> 
                                全部订单
                            </th>                                          
                            <th data-sort-ignore="true" data-hide="phone"> 
                                有效订单
                            </th>   
                            <th data-sort-ignore="true" data-hide="phone"> 
                                退款订单
                            </th> 
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="width:100px">
                                       <img src="<%#Eval("pic")%>" style="width:100px;height:100px;" onerror="this.src='/assets/img/nopic.jpg'" />  
                                    </td>
                                    <td style="width:40%">
                                        <a href="https://detail.tmall.com/item.htm?id=<%#Eval("ProductID")%>" target="_blank" style="width:100px;height:100px;"  >
                                        商品名称：<%#Eval("ProductName")%></a><br /> 
                                        店铺名称：<%#Eval("OwnedShop")%>                                        
                                    </td>  
                                    <td>
                                         <%#Eval("totalEffect")%>
                                    </td>                                     
                                    <td>
                                        <%#Eval("totalValidEffect")%>

                                    </td> 
                                    <td>
                                        <%#Eval("totalLijin")%>

                                    </td> 
                                    <td>
                                        <%#Eval("totalRealshouru")%>

                                    </td>                                                                                     
                                    <td>
                                        <%#Eval("totalOrderNums")%>
                                    </td>
                                    <td>
                                        <%#Eval("totalValidOrderNums")%>
                                    </td>
                                    <td>  
                                        <%#Eval("totalReturnOrderNums")%>                           
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>       
                                <asp:PlaceHolder ID="phEmptyData" runat="server" Visible='<%#bool.Parse((rpData.Items.Count==0).ToString())%>'>
                                    <tr>
                                    <td style=" text-align:center" colspan="9">
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
                            <td colspan="8">
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
