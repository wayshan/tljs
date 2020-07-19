<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Mx.Web.adm.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
<script>    window.jQuery || document.write('<script src="../assets/plugins/jquery/jquery.min.js"><\/script>')</script>

 <script src="../assets/js/dayjs.min.js" type="text/javascript"></script>



    <form id="form1" runat="server">
    <div>
    <button class="btn btn-small btnDate" type="button">近7天</button>
    </div>
    </form>



    <script>
        var sa;
        var now;

        sa = dayjs("2020-06-06", "YYYY-MM-DD");
        //alert(moment())
        $(".btnDate").click(function () {
            
            
//            sa = moment("20111031", "YYYYMMDD")
//            var now = '2014-02-27 10:00:00';

//            var testDate = moment().add(7, 'days')



//            console.log(testDate)

//            console.log(testDate)
//            var aa = moment.parseZone(now)
//           var ss = aa.add(7, 'd');
//            console.log(ss)
//            console.log(typeof ss)

            //var ss = moment.add(7, 'd');
            
        })
</script>
</body>
</html>
