<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Stoke.USL.MainForm.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
    <!--
    body {
	    margin-left: 0px;
	    margin-top: 0px;
	    margin-right: 0px;
	    margin-bottom: 0px;
    }
    .STYLE1 {
	    font-size: 13px;
	    color: #FFFFFF;
	    font-weight:bold;
    }
    .STYLE2 {
        font-size: 12px;
    }
    .STYLE3 {
	    color: #033d61;
	    font-size: 12px;
    }
    -->
    </style>
    <script language="javascript" type="text/javascript">
        function changepage(src) {
            if (src != "") {
                window.top.frames['mainFrame'].document.getElementById('man_zone').innerHTML = "<iframe src='" + src + "' height='100%' width='100%' frameborder='0'></iframe> ";
            }
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="70px" background="../../images/top01.jpg">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="1000px" height="70px" background="../../images/top02.jpg">
                            &nbsp;</td>
                        <td valign="bottom">
                            <table width="100%" height="30px" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td nowrap="nowrap">
                                        <div align="right">
                                            <span class="STYLE1"><span class="STYLE2">■</span>
                                             <script language="javascript" type="text/javascript">
                                                <!--
                                                function Year_Month(){ 
                                                    var now = new Date(); 
                                                    var yy = now.getFullYear(); 
                                                    var mm = now.getMonth(); 
                                                    var mmm=new Array();
                                                    mmm[0]="1";
                                                    mmm[1]="2";
                                                    mmm[2]="3";
                                                    mmm[3]="4";
                                                    mmm[4]="5";
                                                    mmm[5]="6";
                                                    mmm[6]="7";
                                                    mmm[7]="8";
                                                    mmm[8]="9";
                                                    mmm[9]="10";
                                                    mmm[10]="11";
                                                    mmm[11]="12";
                                                    mm=mmm[mm];
                                                    return(mm ); }
                                                 
                                                 function thisYear(){ 
                                                    var now = new Date(); 
                                                    var yy = now.getFullYear(); 
                                                    return(yy ); }
                                                    
                                                 function Date_of_Today(){ 
                                                    var now = new Date(); 
                                                    return(now.getDate() ); }
                                                    
                                                 function CurentTime(){ 
                                                    var now = new Date(); 
                                                    var hh = now.getHours(); 
                                                    var mm = now.getMinutes(); 
                                                    var ss = now.getTime() % 60000; 
                                                    ss = (ss - (ss % 1000)) / 1000; 
                                                    var clock = hh+':'; 
                                                    if (mm < 10) clock += '0'; 
                                                    clock += mm+':'; 
                                                    if (ss < 10) clock += '0'; 
                                                    clock += ss; 
                                                    return(clock); } 
                                                  
                                                 function thisWeek(){ 
                                                    var now = new Date(); 
                                                    var ww = now.getDay(); 
                                                    var mmm=new Array();
                                                    mmm[1]="星期一";
                                                    mmm[2]="星期二";
                                                    mmm[3]="星期三";
                                                    mmm[4]="星期四";
                                                    mmm[5]="星期五";
                                                    mmm[6]="星期六";
                                                    mmm[0]="星期日";
                                                    return(mmm[ww]); }
                                                    
                                                function refreshCalendarClock(){ 
                                                    document.all.calendarClock1.innerHTML = Year_Month()+"月"; 
                                                    document.all.calendarClock2.innerHTML = Date_of_Today()+"日"; 
                                                    document.all.calendarClock3.innerHTML =thisYear()+"年"; 
                                                    document.all.calendarClock4.innerHTML = "&nbsp;"+CurentTime(); 
                                                    document.all.calendarClock5.innerHTML = "&nbsp;&nbsp;"+thisWeek(); 
                                                }
                                                
                                                document.write('<font id="calendarClock3" > </font>');
                                                document.write('<font id="calendarClock1" > </font>');
                                                document.write('<font id="calendarClock2" > </font>');
                                                document.write('<font id="calendarClock4" > </font>');
                                                document.write('<font id="calendarClock5" > </font>');
                                                setInterval('refreshCalendarClock()',1000);
                                                //-->
                                            </script>
                                            </span>
                                        </div>
                                        <div align="right" style="padding-top:10px;padding-bottom:5px;">
                                            <asp:ImageButton ID="zhuye" runat="server"  ImageUrl="~/images/zhuye.png" Width="20px" ToolTip="主页" OnClick="zhuye_Click"/>&nbsp;&nbsp;
                                            <asp:ImageButton ID="shuaxin" runat="server" ImageUrl="~/images/shuaxin.png" Width="20px" ToolTip="刷新" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="help" runat="server"  ImageUrl="~/images/help.png" Width="20px" ToolTip="帮助"/>&nbsp;&nbsp;
                                            <asp:ImageButton ID="zhuxiao" runat="server"  ImageUrl="~/images/zhuxiao.png" Width="20px" ToolTip="注销" OnClick="zhuxiao_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="21px">
                            <!--<img src="images/main_11.gif" width="21" height="38">-->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
    </table>
    </form>
</body>
</html>
