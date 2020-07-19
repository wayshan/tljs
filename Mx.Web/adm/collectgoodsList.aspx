<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="collectgoodsList.aspx.cs" Inherits="Mx.Web.adm.collectgoodsList" %>

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
                <li><a href="collectgoodsList.aspx">同行信息采集</a> <span class="icon-angle-right"></span></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12">
        <div class="social-box">
            
            <div class="header">
                <div class="tools">                    
                    
                </div>                
            </div>
                    
            <div class="body">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="dataTables_search" style=" margin-bottom:5px">                                                   
                            商品名称：<asp:TextBox ID="txtgoodsname" runat="server"></asp:TextBox> 
                            店铺名称：<asp:TextBox ID="txtshopname" runat="server"></asp:TextBox> 
                            渠道：<asp:TextBox ID="txtqudao" runat="server"></asp:TextBox> 
                            状态：<asp:DropDownList ID="ddlifok" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>                                
                                <asp:ListItem Value="1" Text="有效"></asp:ListItem>
                                <asp:ListItem Value="0" Text="无效"></asp:ListItem>                            
                            </asp:DropDownList>                           
                            数量：<asp:DropDownList ID="ddltotalNum" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>                                
                                <asp:ListItem Value="1" Text=">=10"></asp:ListItem>
                                <asp:ListItem Value="0" Text="<10"></asp:ListItem>                            
                            </asp:DropDownList>  
                            信息类型：
                            <asp:DropDownList ID="ddlType" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>                                
                                <asp:ListItem Value="1" Text="淘礼金"></asp:ListItem>
                                <asp:ListItem Value="0" Text="肉单"></asp:ListItem>                            
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
                                商品信息
                            </th>
                            <th data-hide="phone" data-sort-ignore="true">
                                基础信息
                            </th> 
                            <th data-hide="phone" data-sort-ignore="true">
                                价格/佣金等属性
                            </th>                            
                            <th data-sort-ignore="true" data-hide="phone"> 
                                渠道
                            </th> 
                            <th data-hide="phone" data-sort-ignore="true">
                                付款价格
                            </th>                             
                            <th data-sort-ignore="true" data-hide="phone"> 
                                礼金面单
                            </th>                                                    
                            <th data-sort-ignore="true" data-hide="phone">
                               计划类型
                            </th>
                             <th data-sort-ignore="true" >
                               状态
                            </th>
                             <th data-sort-ignore="true" data-hide="phone">
                               时间
                            </th>
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
                                       <img src="<%#Eval("goodspic")%>" style="width:100px;height:100px;" onerror="this.src='/assets/img/nopic.jpg'"/>  
                                    </td>                               
                                    <td style="width:300px">
                                        商品Id：<%#Eval("goodsid")%> <br />
                                        <a href="https://detail.tmall.com/item.htm?id=<%#Eval("goodsid")%>" target="_blank" style="width:100px;height:100px;"  >
                                        商品名称：<%#Eval("goodsname")%></a><br />
                                        店铺名：<%#Eval("shopname")%><br />
                                        淘礼金名称：<%#Eval("name")%>
                                    </td>  
                                    <td style="width:120px">
                                         券后价：<%#Eval("postCouponPrice")%><br />
                                         佣金：<%#Eval("fanliAmount")%><br />
                                         佣金比例：<%#Eval("maxCommissionRate")%>%<br />
                                         数量：<%#Eval("totalNum")%><br />
                                         利润：
                                         <%#Math.Round((Eval("fanliAmount") != null ? Convert.ToDecimal(Eval("fanliAmount")) : 0.00m) * 0.88m - (Eval("perFace") != null ? Convert.ToDecimal(Eval("perFace")) : 0.00m), 2, MidpointRounding.AwayFromZero)%>
                                                                                
                                    </td>                                     
                                    <td>
                                        <%# Eval("qudao")%>
                                    </td>                                                                                            
                                    <td>
                                        <%# Eval("paymoney")%>
                                    </td>
                                    <td>
                                        <%#Eval("perFace")%>
                                    </td>
                                    <td>
                                        <%#Eval("campaigntype") != null && Eval("campaigntype").ToString() == "MKT" ? "" : Eval("campaigntype").ToString()%>
                                    </td>                                    
                                    <td>  
                                        <%#Eval("ifok").ToString()=="1"?"有效":"无效"%>                           
                                    </td>
                                    <td>  
                                        录入时间：<%#Eval("creationTime")%><br />
                                        预计生成时间：<%#Eval("planCreatetljTime")%>                           
                                    </td>
                                    <td> 
                                        <a href="javascript:;" gid="<%#Eval("goodsid")%>" lj="<%#Eval("perFace")%>" ql="<%#Eval("coupon")%>" ct="<%#Eval("campaigntype")%>" class="btn btnChoose">
                                            <i class="icon-search"></i> 
                                            采用（淘礼金）</a> 
                                            
                                       <a href="javascript:;" gid="<%#Eval("goodsid")%>" lj="<%#Eval("perFace")%>" ql="<%#Eval("coupon")%>" ct="<%#Eval("campaigntype")%>" class="btn btnChange">
                                            <i class="icon-search"></i> 
                                            采用</a>                    
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>       
                                <asp:PlaceHolder ID="phEmptyData" runat="server" Visible='<%#bool.Parse((rpData.Items.Count==0).ToString())%>'>
                                    <tr>
                                    <td style=" text-align:center" colspan="10">
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
                            <td colspan="9">
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

        $(".btnChoose").click(function () {
            var gid = $(this).attr("gid");
            var lj = $(this).attr("lj");
            var ql = $(this).attr("ql");
            var ct = $(this).attr("ct");
            location.href = 'TljDo.aspx?gid=' + gid + '&lj=' + lj + '&ql=' + encodeURIComponent(ql) + '&ct='+ct;
        })

        $(".btnChange").click(function () {
            var gid = $(this).attr("gid");
            var lj = $(this).attr("lj");
            var ql = $(this).attr("ql");
            location.href = 'change.aspx?gid=' + gid + '&lj=' + lj + '&ql=' + encodeURIComponent(ql);
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
