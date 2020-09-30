<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="ActiveCodeList.aspx.cs" Inherits="Mx.Web.adm.ActiveCodeList" %>

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
                <li><a href="ActiveCodeList.aspx">活动编码管理</a> <span class="icon-angle-right"></span></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12">
        <div class="social-box">
            
            
                    
            <div class="body">
               
                <table class="table table-bordered table-striped table-hover" id="footable">
                    <thead>
                        <tr>  
                            <th data-hide="phone" data-sort-ignore="true">
                                活动编码
                            </th> 
                            <th data-hide="phone" data-sort-ignore="true">
                                商品名称
                            </th> 
                            <th data-hide="phone" data-sort-ignore="true">
                                item_id
                            </th>   
                            <th data-hide="phone" data-sort-ignore="true">
                               图片
                            </th> 
                             <th data-hide="phone" data-sort-ignore="true">
                               剩余数量
                            </th>                          
                            <th data-sort-ignore="true" data-hide="phone"> 
                                通用链接
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
                                       <img src="<%#Eval("item_pic")%>" style="width:100px;height:100px;" onerror="this.src='/assets/img/nopic.jpg'"/>  
                                    </td>  
                                    <td>
                                         <%#Eval("ActiveCode")%>
                                    </td> 
                                    <td>
                                         <%#Eval("goodsname")%>
                                    </td> 
                                    <td>
                                        <a href="https://detail.tmall.com/item.htm?id=<%#Eval("item_id")%>" target="_blank" > 
                                        <%#Eval("item_id")%>
                                        </a>
                                    </td>                                                                     
                                    <td >
                                         <%# Eval("count")%>
                                    </td>
                                    <td>  
                                        <%#Eval("Link")%>  
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                       <button class="btn btnCopy"  type="button" data-clipboard-text="<%#Eval("Link")%> ">
                                            复制
                                        </button>
                                    </td>
                                    <td >  
                                        <a href="<%#Eval("qunLink")%>" target="_blank">
                                        查看各群详情
                                        </a>                                             
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>       
                                <asp:PlaceHolder ID="phEmptyData" runat="server" Visible='<%#bool.Parse((rpData.Items.Count==0).ToString())%>'>
                                    <tr>
                                    <td style=" text-align:center" colspan="7">
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
                            <td colspan="7">
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
