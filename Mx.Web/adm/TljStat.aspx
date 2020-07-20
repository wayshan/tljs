<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminBaseMaster.Master" AutoEventWireup="true"
    CodeBehind="TljStat.aspx.cs" Inherits="Mx.Web.adm.TljStat" %>

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
                <li><a href="TljStat.aspx">淘礼金统计</a> <span class="icon-angle-right"></span></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPage" runat="server">
    <div class="span12">
        <div class="social-box">
            <div class="header">
                <div class="tools">
                    <asp:HiddenField ID="txtDateTimeNow" ClientIDMode="Static" runat="server" />
                    <asp:LinkButton ID="btnExcel" OnClick="btnExcel_Click" runat="server" CssClass="btn btn-success">
                    <i class="icon-arrow-down"></i>
                        导出Excel
                    </asp:LinkButton>
                </div>
            </div>
            <div class="body">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="dataTables_search" style="margin-bottom: 5px">                            
                            <button class="btn btn-small btnDate" value="7" type="button">近7天</button>
                            <button class="btn btn-small btnDate" value="30" type="button">近30天</button>
                            
                            日期：<asp:TextBox ID="txtDateStart" Width="150" class="laydate-icon" runat="server"></asp:TextBox>
                            —
                            <asp:TextBox ID="txtDateEnd" Width="150" class="laydate-icon" runat="server"></asp:TextBox>
                           帐号：<asp:DropDownList ID="ddlAccount" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>                                
                                                           
                            </asp:DropDownList> 
                           
                           推广位：<asp:DropDownList ID="ddlAppKeyID" runat="server" style=" width:auto">
                                <asp:ListItem Value="" Text="全部"></asp:ListItem>                                
                                                           
                            </asp:DropDownList> 

                            <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-warning">                       
                                查询
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>


                <div id="chartContent" class="row-fluid">
                   
                   <div class="ChartSrc span12">
                       <ul>
                       <li style="background-image: url(&quot;/assets/img/1.jpg&quot;);"> <p class="Title">预估佣金（元）</p> <p class="Number"><%=totalyj%></p></li>
                       <li style="background-image: url(&quot;/assets/img/2.jpg&quot;);"> <p class="Title">预估到手佣金（元）</p> <p class="Number"><%=totalyjds%></p></li>
                       <li style="background-image: url(&quot;/assets/img/3.jpg&quot;);"> <p class="Title">总淘礼金支出（元）</p> <p class="Number"><%=totaluse_amount%></p></li>
                       <li style="background-image: url(&quot;/assets/img/5.jpg&quot;);"> <p class="Title">免单金额（元）</p> <p class="Number"><%=totalmd_amount%><span style="font-size:14px">[<%=totalmd_count%>单]</span></p></li>
                       <li style="background-image: url(&quot;/assets/img/4.jpg&quot;);"> <p class="Title">盈亏情况（元）</p> <p class="Number"><%=totalykresult%></p></li>
                       </ul> 
                   </div>
                   
                    <div class="span12">
                        <div id="chartmain" style="width:100%; height: 400px;"></div>
                    </div>
                </div>
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
    <script src="../assets/plugins/echart/echarts.min.js" type="text/javascript"></script>
    <%--<script src="../assets/plugins/echart/echarts.all.js" type="text/javascript"></script>--%>
    <script src="../assets/js/dayjs.min.js" type="text/javascript"></script>
    
    <script>
        laydate.skin('danlan');
        var start = {
            elem: '#<%=txtDateStart.ClientID %>',
            //festival: true,
            format: 'YYYY-MM-DD',            
            choose: function (datas) {
                end.min = datas;
                end.start = datas;
            }
        };
        var end = {
            elem: '#<%=txtDateEnd.ClientID %>',
            //festival: true,
            format: 'YYYY-MM-DD',            
            choose: function (datas) {
                start.max = datas;
            }
        };
        laydate(start);
        laydate(end); 
    </script>
    <script>
        $(function () {
            
        });

        $(".btnDate").click(function () {
            var days =parseInt($(this).val())*-1;
            var now = $("#<%=txtDateTimeNow.ClientID %>").val();
            var dayObj = dayjs(now, "YYYY-MM-DD")
            var startDate = dayObj.add(days, 'd').format("YYYY-MM-DD");
            var endDate = dayObj.add(-1, 'd').format("YYYY-MM-DD");
            $("#<%=txtDateStart.ClientID %>").val(startDate);
            $("#<%=txtDateEnd.ClientID %>").val(endDate);
            document.getElementById("<%=btnSearch.ClientID %>").click()
            console.log($("#<%=btnSearch.ClientID %>").html())
        })

       

        //指定图标的配置和数据
        var option = {           
            tooltip: {
                  trigger: 'axis',
                  axisPointer: {
                    type: 'cross',
                    label: {
                      backgroundColor: '#6a7985'
                    }
                  }
                },
            grid: {
                left: '2%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            legend: {
                data: ['盈亏情况', '预估到手佣金', '预估佣金', '总淘礼金支出','免单金额'],
                left: '3%',
                top: '3%'
            },
            xAxis: [
            {
                type: 'category',
                boundaryGap: false,
                data: <%=xAxis_arr %>
            }],
            yAxis: [
            {
                type: 'value',
                max: 'dataMax',
                min: 'dataMin',
                splitNumber: 10
            }
          ],
        series: [
            {
              name: '盈亏情况',
              type: 'line',              
              symbolSize: 8,
              itemStyle: {
                color: 'rgba(255, 74, 78, 1)'
              },
              data: <%=ykresult_arr %>
            },
            {
              name: '预估到手佣金',
              type: 'line',              
              symbolSize: 8,
              itemStyle: {
                color: 'rgba(20, 188, 94, 1)'
              },
              data: <%=yjds_arr %>
            },
            {
              name: '预估佣金',
              type: 'line',              
              symbolSize: 8,
              itemStyle: {
                color: 'rgba(87, 148, 252, 1)'
              },
              data: <%=yj_arr %>
            },
            {
              name: '总淘礼金支出',
              type: 'line',              
              symbolSize: 8,
              itemStyle: {
                color: 'rgba(255, 135, 54, 1)'
              },
              data: <%=use_amount_arr %>
            },
            {
              name: '免单金额',
              type: 'line',              
              symbolSize: 8,
              itemStyle: {
                color: 'rgba(189,22,204, 1)'
              },
              data: <%=md_amount_arr %>
            }    
        ]
    };
        //初始化echarts实例
        var myChart = echarts.init(document.getElementById('chartmain'));

        //使用制定的配置项和数据显示图表
        myChart.setOption(option);



       
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
