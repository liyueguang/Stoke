<%@ Page Language="C#" AutoEventWireup="true" Codebehind="wdk_xz_select.aspx.cs"
    Inherits="Stoke.USL.gwgl.wdk_xz_select" %>

<%@ Register TagPrefix="uc1" TagName="attachList" Src="attachList.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>wdk_xz</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style>BODY { FONT-SIZE: 9pt }
	A:unknown { FONT-SIZE: 9pt; COLOR: blue; FONT-FAMILY: Courier New; TEXT-DECORATION: none }
	A:link { FONT-SIZE: 9pt; COLOR: blue; FONT-FAMILY: Courier New; TEXT-DECORATION: none }
	A:visited { FONT-SIZE: 9pt; COLOR: blue; FONT-FAMILY: Courier New; TEXT-DECORATION: none }
	A:hover { FONT-SIZE: 9pt; COLOR: blue; FONT-FAMILY: Courier New; TEXT-DECORATION: underline }
		</style>
    <style type="text/css">.STYLE1 { BORDER-RIGHT: #aaaaaa 0px dashed; BORDER-TOP: #aaaaaa 0px dashed; FONT-WEIGHT: bold; FONT-SIZE: 12px; BORDER-LEFT: #aaaaaa 0px dashed; COLOR: #4b82b4; BORDER-BOTTOM: #aaaaaa 2px dashed; HEIGHT: 26px; BACKGROUND-COLOR: #f3f5fa; TEXT-ALIGN: center }
		</style>
    <style type="text/css">
        #report { FONT-SIZE: 9pt; WIDTH: 100%; BORDER-COLLAPSE: collapse }
        #report H4 { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px }
        #report IMG { FLOAT: right }
        #report UL { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px }
        #report LI { LIST-STYLE-TYPE: none }
        #report TH { PADDING-RIGHT: 7px; PADDING-LEFT: 7px; FONT-SIZE: 11pt; BACKGROUND: #7cb8e2 no-repeat left center; PADDING-BOTTOM: 3px; COLOR: #fff; PADDING-TOP: 3px; TEXT-ALIGN: center }
        #report TD { PADDING-RIGHT: 7px; PADDING-LEFT: 7px; BACKGROUND: #c7ddee repeat-x left center; PADDING-BOTTOM: 3px; COLOR: #000; PADDING-TOP: 3px; TEXT-ALIGN: center }
        #report TR.odd TD { BACKGROUND: url(row_bkg.png) #fff repeat-x left center; CURSOR: pointer }
        #report TR.notOdd TD { TEXT-ALIGN: left }
        #report DIV.arrow { DISPLAY: block; BACKGROUND: url(arrows.png) no-repeat 0px -16px; WIDTH: 16px; HEIGHT: 10px }
        #report DIV.up { BACKGROUND-POSITION: 0px 0px }
		</style>

    <script src="../../js/jquery-1.6.1.js" type="text/javascript"></script>

    <script type="text/javascript">  
        $(document).ready(function(){
            $("#report tr:odd").addClass("odd");
            $("#report tr:not(.odd)").addClass("notOdd");
            $("#report tr:not(.odd)").hide();
            $("#report tr:first-child").show();
            
            $("#report tr.odd").click(function(){
                $(this).next("tr").toggle();
                $(this).find(".arrow").toggleClass("up");
            });
            //$("#report").jExpand();
        });
    </script>

    <script language="javascript">
		
		document.write("<div id=meizzCalendarLayer style='position: absolute; z-index: 9999; width: 144; height: 193; display: none'>"); 
document.write("<iframe name=meizzCalendarIframe scrolling=no frameborder=0 width=100% height=100%></iframe></div>"); 
function writeIframe() 
{ 
    var strIframe = "<html><head><meta http-equiv='Content-Type' content='text/html;charset=gb2312'><style>"+ 
    "*{font-size: 12px; font-family: 宋体}"+ 
    ".bg{  color: "+ WebCalendar.lightColor +"; cursor: default; background-color: "+ WebCalendar.darkColor +";}"+ 
    "table#tableMain{ width: 142; height: 180;}"+ 
    "table#tableWeek td{ color: "+ WebCalendar.lightColor +";}"+ 
    "table#tableDay  td{ font-weight: bold;}"+ 
    "td#meizzYearHead, td#meizzYearMonth{color: "+ WebCalendar.wordColor +"}"+ 
    ".out { text-align: center; border-top: 1px solid "+ WebCalendar.DarkBorder +"; border-left: 1px solid "+ WebCalendar.DarkBorder +";"+ 
    "border-right: 1px solid "+ WebCalendar.lightColor +"; border-bottom: 1px solid "+ WebCalendar.lightColor +";}"+ 
    ".over{ text-align: center; border-top: 1px solid #FFFFFF; border-left: 1px solid #FFFFFF;"+ 
    "border-bottom: 1px solid "+ WebCalendar.DarkBorder +"; border-right: 1px solid "+ WebCalendar.DarkBorder +"}"+ 
    "input{ border: 1px solid "+ WebCalendar.darkColor +"; padding-top: 1px; height: 18; cursor: hand;"+ 
    "       color:"+ WebCalendar.wordColor +"; background-color: "+ WebCalendar.btnBgColor +"}"+ 
    "</style></head><body onselectstart='return false' style='margin: 0px' oncontextmenu='return false'><form name=meizz>"; 
    if (WebCalendar.drag){ strIframe += "<scr"+"ipt language=javascript>"+ 
    "var drag=false, cx=0, cy=0, o = parent.WebCalendar.calendar; function document.onmousemove(){"+ 
    "if(parent.WebCalendar.drag && drag){if(o.style.left=='')o.style.left=0; if(o.style.top=='')o.style.top=0;"+ 
    "o.style.left = parseInt(o.style.left) + window.event.clientX-cx;"+ 
    "o.style.top  = parseInt(o.style.top)  + window.event.clientY-cy;}}"+ 
    "function document.onkeydown(){ switch(window.event.keyCode){  case 27 : alert('123');parent.hiddenCalendar(); break;"+ 
    "case 37 : parent.prevM(); break; case 38 : parent.prevY(); break; case 39 : parent.nextM(); break; case 40 : parent.nextY(); break;"+ 
//    "case 84 : document.forms[0].today.click(); break; case 88 : parent.clearDate(); break; } window.event.keyCode = 0; window.event.returnValue= false;}"+ 
    "case 84 : parent.returnDate(new Date().getDate() +'/'+ (new Date().getMonth() +1) +'/'+ new Date().getFullYear()); break; case 88 : parent.clearDate(); break; } window.event.keyCode = 0; window.event.returnValue= false;}"+ 
    "function dragStart(){cx=window.event.clientX; cy=window.event.clientY; drag=true;}</scr"+"ipt>"} 

    strIframe += "<select name=tmpYearSelect  onblur='parent.hiddenSelect(this)' style='z-index:1;position:absolute;top:3;left:18;display:none'"+ 
    " onchange='parent.WebCalendar.thisYear =this.value; parent.hiddenSelect(this); parent.writeCalendar();'></select>"+ 
    "<select name=tmpMonthSelect onblur='parent.hiddenSelect(this)' style='z-index:1; position:absolute;top:3;left:74;display:none'"+ 
    " onchange='parent.WebCalendar.thisMonth=this.value; parent.hiddenSelect(this); parent.writeCalendar();'></select>"+ 

    "<table id=tableMain class=bg border=0 cellspacing=2 cellpadding=0>"+ 
    "<tr><td width=140 height=19 bgcolor='"+ WebCalendar.lightColor +"'>"+ 
    "    <table width=140 id=tableHead border=0 cellspacing=1 cellpadding=0><tr align=center>"+ 
    "    <td width=15 height=19 class=bg title='向前翻 1 月&#13;快捷键：←' style='cursor: hand' onclick='parent.prevM()'><b>&lt;</b></td>"+ 
    "    <td width=60 id=meizzYearHead  title='点击此处选择年份' onclick='parent.funYearSelect(parseInt(this.innerText, 10))'"+ 
    "        onmouseover='this.bgColor=parent.WebCalendar.darkColor; this.style.color=parent.WebCalendar.lightColor'"+ 
    "        onmouseout='this.bgColor=parent.WebCalendar.lightColor; this.style.color=parent.WebCalendar.wordColor'></td>"+ 
    "    <td width=50 id=meizzYearMonth title='点击此处选择月份' onclick='parent.funMonthSelect(parseInt(this.innerText, 10))'"+ 
    "        onmouseover='this.bgColor=parent.WebCalendar.darkColor; this.style.color=parent.WebCalendar.lightColor'"+ 
    "        onmouseout='this.bgColor=parent.WebCalendar.lightColor; this.style.color=parent.WebCalendar.wordColor'></td>"+ 
    "    <td width=15 class=bg title='向后翻 1 月&#13;快捷键：→' onclick='parent.nextM()' style='cursor: hand'><b>&gt;</b></td></tr></table>"+ 
    "</td></tr><tr><td height=20><table id=tableWeek border=1 width=140 cellpadding=0 cellspacing=0 "; 
    if(WebCalendar.drag){strIframe += "onmousedown='dragStart()' onmouseup='drag=false' onmouseout='drag=false'";} 
    strIframe += " borderColorLight='"+ WebCalendar.darkColor +"' borderColorDark='"+ WebCalendar.lightColor +"'>"+ 
    "    <tr align=center><td height=20>日</td><td>一</td><td>二</td><td>三</td><td>四</td><td>五</td><td>六</td></tr></table>"+ 
    "</td></tr><tr><td valign=top width=140 bgcolor='"+ WebCalendar.lightColor +"'>"+ 
    "    <table id=tableDay height=120 width=140 border=0 cellspacing=1 cellpadding=0>"; 
         for(var x=0; x<5; x++){ strIframe += "<tr>"; 
         for(var y=0; y<7; y++)  strIframe += "<td class=out id='meizzDay"+ (x*7+y) +"'></td>"; strIframe += "</tr>";} 
         strIframe += "<tr>"; 
         for(var x=35; x<39; x++) strIframe += "<td class=out id='meizzDay"+ x +"'></td>"; 
         strIframe +="<td colspan=3 class=out title='"+ WebCalendar.regInfo +"'><input style=' background-color: "+ 
         WebCalendar.btnBgColor +";cursor: hand; padding-top: 4px; width: 100%; height: 100%; border: 0' onfocus='this.blur()'"+ 
         " type=button value='&nbsp; &nbsp; 关闭' onclick='parent.hiddenCalendar()'></td></tr></table>"+ 
    "</td></tr><tr><td height=20 width=140 bgcolor='"+ WebCalendar.lightColor +"'>"+ 
    "    <table border=0 cellpadding=1 cellspacing=0 width=140>"+ 
    "    <tr><td><input name=prevYear title='向前翻 1 年&#13;快捷键：↑' onclick='parent.prevY()' type=button value='&lt;&lt;'"+ 
    "    onfocus='this.blur()' style='meizz:expression(this.disabled=parent.WebCalendar.thisYear==1000)'><input"+ 
    "    onfocus='this.blur()' name=prevMonth title='向前翻 1 月&#13;快捷键：←' onclick='parent.prevM()' type=button value='&lt;&nbsp;'>"+ 
    "    </td><td align=center><input name=today type=button value='今天' onfocus='this.blur()' style='width: 30' title='当前日期&#13;快捷键：T'"+ 
    "    onclick=\"parent.returnDate(new Date().getDate() +'/'+ (new Date().getMonth() +1) +'/'+ new Date().getFullYear())\">"+ 
    "    </td><td align=center><input name=today type=button value='清空' onfocus='this.blur()' style='width: 30' title='清空日期&#13;快捷键：X'"+
    "    onclick='parent.clearDate()'>"+
    "    </td><td align=right><input title='向后翻 1 月&#13;快捷键：`' name=nextMonth onclick='parent.nextM()' type=button value='&nbsp;&gt;'"+ 
    "    onfocus='this.blur()'><input name=nextYear title='向后翻 1 年&#13;快捷键：↓' onclick='parent.nextY()' type=button value='&gt;&gt;'"+ 
    "    onfocus='this.blur()' style='meizz:expression(this.disabled=parent.WebCalendar.thisYear==9999)'></td></tr></table>"+ 
    "</td></tr><table></form></body></html>"; 
    with(WebCalendar.iframe) 
    { 
        document.writeln(strIframe); document.close(); 
        for(var i=0; i<39; i++) 
        { 
            WebCalendar.dayObj[i] = eval("meizzDay"+ i); 
            WebCalendar.dayObj[i].onmouseover = dayMouseOver; 
            WebCalendar.dayObj[i].onmouseout  = dayMouseOut; 
            WebCalendar.dayObj[i].onclick     = returnDate; 
        } 
    } 
} 
function TWebCalendar() //初始化日历的设置 
{ 
    //this.regInfo    = "WEB Calendar ver 3.0&#13;作者：meizz(梅花雪疏影横斜)&#13;网站：&#13;关闭的快捷键：[Esc]"; 
    //this.regInfo   += "&#13;&#13;Ver 2.0：walkingpoison(水晶龙)&#13;Ver 1.0：meizz(梅花雪疏影横斜)"; //&#13;快捷键：[Esc]";
    this.regInfo    = "关闭";
    this.daysMonth  = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31); 
    this.day        = new Array(39);            //定义日历展示用的数组 
    this.dayObj     = new Array(39);            //定义日期展示控件数组 
    this.dateStyle  = null;                     //保存格式化后日期数组 
    this.objExport  = null;                     //日历回传的显示控件 
    this.eventSrc   = null;                     //日历显示的触发控件 
    this.inputDate  = null;                     //转化外的输入的日期(d/m/yyyy) 
    this.thisYear   = new Date().getFullYear(); //定义年的变量的初始值 
    this.thisMonth  = new Date().getMonth()+ 1; //定义月的变量的初始值 
    this.thisDay    = new Date().getDate();     //定义日的变量的初始值 
    this.today      = this.thisDay +"/"+ this.thisMonth +"/"+ this.thisYear;   //今天(d/m/yyyy) 
    this.iframe     = window.frames("meizzCalendarIframe"); //日历的 iframe 载体 
    this.calendar   = getObjectById("meizzCalendarLayer");  //日历的层 
    this.dateReg    = "";           //日历格式验证的正则式 

    this.yearFall   = 50;           //定义年下拉框的年差值 
    this.format     = "yyyy-mm-dd"; //回传日期的格式 
    this.timeShow   = false;        //是否返回时间
    this.drag       = true;         //是否允许拖动 
    this.darkColor  = "#0000D0";    //控件的暗色 
    this.lightColor = "#FFFFFF";    //控件的亮色 
    this.btnBgColor = "#FFFFF5";    //控件的按钮背景色 
    this.wordColor  = "#000080";    //控件的文字颜色 
    this.wordDark   = "#DCDCDC";    //控件的暗文字颜色 
    this.dayBgColor = "#E6E6FA";    //日期数字背景色 
    this.todayColor = "#FF0000";    //今天在日历上的标示背景色 
    this.DarkBorder = "#D4D0C8";    //日期显示的立体表达色 
}   var WebCalendar = new TWebCalendar(); 

function calendar() //主调函数 
{   
    var e = window.event.srcElement;   
	writeIframe(); 
    var o = WebCalendar.calendar.style; 
		WebCalendar.eventSrc = e; 
	if (arguments.length == 0) 
		WebCalendar.objExport = e; 
    else 
		WebCalendar.objExport = eval(arguments[0]); 
    WebCalendar.iframe.tableWeek.style.cursor = WebCalendar.drag ? "move" : "default";
	
	var t = e.offsetTop;
    var h = e.clientHeight;
    var l = e.offsetLeft;
    var p = e.type; 
	while (e = e.offsetParent)
	{
		t += e.offsetTop; l += e.offsetLeft;
	}
	
    o.display = ""; 
    WebCalendar.iframe.document.body.focus();
	
    var cw = WebCalendar.calendar.clientWidth;
    var ch = WebCalendar.calendar.clientHeight; 
    var dw = document.body.clientWidth;
    var dl = document.body.scrollLeft;
    var dt = document.body.scrollTop; 

 //	if (document.body.clientHeight + dt - t - h >= ch) 
//		o.top = (p=="image")? t + h : t + h + 6; 
//	else 
//	{
//		o.top  = (t - dt < ch) ? ((p=="image")? t + h : t + h + 6) : t - ch;
		o.top = ((event.clientY  - h - ch) <0 )?(event.clientY  + h ):(event.clientY  - h- ch) ;
//	}
	
    if (dw + dl - l >= cw) 
		o.left = l; 
	else 
		o.left = (dw >= cw) ? dw - cw + dl : dl; 

    if  (!WebCalendar.timeShow) WebCalendar.dateReg = /^(\d{1,4})(-|\/|.)(\d{1,2})\2(\d{1,2})$/; 
    else WebCalendar.dateReg = /^(\d{1,4})(-|\/|.)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/; 

    try{ 
        if (WebCalendar.objExport.value.trim() != ""){ 
            WebCalendar.dateStyle = WebCalendar.objExport.value.trim().match(WebCalendar.dateReg); 
            if (WebCalendar.dateStyle == null) 
            { 
                WebCalendar.thisYear   = new Date().getFullYear(); 
                WebCalendar.thisMonth  = new Date().getMonth()+ 1; 
                WebCalendar.thisDay    = new Date().getDate(); 
                alert("原文本框里的日期有错误！\n可能与你定义的显示时分秒有冲突！"); 
                writeCalendar(); return false; 
            } 
            else 
            { 
                WebCalendar.thisYear   = parseInt(WebCalendar.dateStyle[1], 10); 
                WebCalendar.thisMonth  = parseInt(WebCalendar.dateStyle[3], 10); 
                WebCalendar.thisDay    = parseInt(WebCalendar.dateStyle[4], 10); 
                WebCalendar.inputDate  = parseInt(WebCalendar.thisDay, 10) +"/"+ parseInt(WebCalendar.thisMonth, 10) +"/"+ 
                parseInt(WebCalendar.thisYear, 10); writeCalendar(); 
            } 
        }  else writeCalendar(); 
    }  catch(e){writeCalendar();} 
} 
function funMonthSelect() //月份的下拉框 
{ 
    var m = isNaN(parseInt(WebCalendar.thisMonth, 10)) ? new Date().getMonth() + 1 : parseInt(WebCalendar.thisMonth); 
    var e = WebCalendar.iframe.document.forms[0].tmpMonthSelect; 
    for (var i=1; i<13; i++) e.options.add(new Option(i +"月", i)); 
    e.style.display = ""; e.value = m; e.focus(); window.status = e.style.top; 
} 
function funYearSelect() //年份的下拉框 
{ 
    var n = WebCalendar.yearFall; 
    var e = WebCalendar.iframe.document.forms[0].tmpYearSelect; 
    var y = isNaN(parseInt(WebCalendar.thisYear, 10)) ? new Date().getFullYear() : parseInt(WebCalendar.thisYear); 
        y = (y <= 1000)? 1000 : ((y >= 9999)? 9999 : y); 
    var min = (y - n >= 1000) ? y - n : 1000; 
    var max = (y + n <= 9999) ? y + n : 9999; 
        min = (max == 9999) ? max-n*2 : min; 
        max = (min == 1000) ? min+n*2 : max; 
    for (var i=min; i<=max; i++) 
    { 
      //alert(e.options.length); 
      e.options[e.options.length] = new Option(i +"年", i+"", true, true);//e.options.add(new Option(i +"年", i)); 
    } 
    e.style.display = ""; 
    e.value = y; e.focus(); 
} 
function prevM()  //往前翻月份 
{ 
    WebCalendar.thisDay = 1; 
    if (WebCalendar.thisMonth==1) 
    { 
        WebCalendar.thisYear--; 
        WebCalendar.thisMonth=13; 
    } 
    WebCalendar.thisMonth--; writeCalendar(); 
} 
function nextM()  //往后翻月份 
{ 
    WebCalendar.thisDay = 1; 
    if (WebCalendar.thisMonth==12) 
    { 
        WebCalendar.thisYear++; 
        WebCalendar.thisMonth=0; 
    } 
    WebCalendar.thisMonth++; writeCalendar(); 
} 
function prevY(){WebCalendar.thisDay = 1; WebCalendar.thisYear--; writeCalendar();}//往前翻 Year 
function nextY(){WebCalendar.thisDay = 1; WebCalendar.thisYear++; writeCalendar();}//往后翻 Year 
function hiddenSelect(e){for(var i=e.options.length; i>-1; i--)e.options.remove(i); e.style.display="none";} 
function getObjectById(id){ if(document.all) return(eval("document.all."+ id)); return(eval(id)); } 
function hiddenCalendar(){getObjectById("meizzCalendarLayer").style.display = "none";}; 
function appendZero(n){return(("00"+ n).substr(("00"+ n).length-2));}//日期自动补零程序 
//function String.prototype.trim(){return this.replace(/(^\s*)|(\s*$)/g,"");} 
function dayMouseOver() 
{ 
    this.className = "over"; 
    this.style.backgroundColor = WebCalendar.darkColor; 
    if(WebCalendar.day[this.id.substr(8)].split("/")[1] == WebCalendar.thisMonth) 
    this.style.color = WebCalendar.lightColor; 
} 
function dayMouseOut() 
{ 
    this.className = "out"; var d = WebCalendar.day[this.id.substr(8)], a = d.split("/"); 
    this.style.removeAttribute('backgroundColor'); 
    if(a[1] == WebCalendar.thisMonth && d != WebCalendar.today) 
    { 
        if(WebCalendar.dateStyle && a[0] == parseInt(WebCalendar.dateStyle[4], 10)) 
        this.style.color = WebCalendar.lightColor; 
        this.style.color = WebCalendar.wordColor; 
    } 
} 
function writeCalendar() //对日历显示的数据的处理程序 
{ 
    var y = WebCalendar.thisYear; 
    var m = WebCalendar.thisMonth; 
    var d = WebCalendar.thisDay; 
    WebCalendar.daysMonth[1] = (0==y%4 && (y%100!=0 || y%400==0)) ? 29 : 28; 
    if (!(y<=9999 && y >= 1000 && parseInt(m, 10)>0 && parseInt(m, 10)<13 && parseInt(d, 10)>0)){ 
        alert("对不起，你输入了错误的日期！"); 
        WebCalendar.thisYear   = new Date().getFullYear(); 
        WebCalendar.thisMonth  = new Date().getMonth()+ 1; 
        WebCalendar.thisDay    = new Date().getDate(); } 
    y = WebCalendar.thisYear; 
    m = WebCalendar.thisMonth; 
    d = WebCalendar.thisDay; 
    WebCalendar.iframe.meizzYearHead.innerText  = y +" 年"; 
    WebCalendar.iframe.meizzYearMonth.innerText = parseInt(m, 10) +" 月"; 
    WebCalendar.daysMonth[1] = (0==y%4 && (y%100!=0 || y%400==0)) ? 29 : 28; //闰年二月为29天 
    var w = new Date(y, m-1, 1).getDay(); 
    var prevDays = m==1  ? WebCalendar.daysMonth[11] : WebCalendar.daysMonth[m-2]; 
    for(var i=(w-1); i>=0; i--) //这三个 for 循环为日历赋数据源（数组 WebCalendar.day）格式是 d/m/yyyy 
    { 
        WebCalendar.day[i] = prevDays +"/"+ (parseInt(m, 10)-1) +"/"+ y; 
        if(m==1) WebCalendar.day[i] = prevDays +"/"+ 12 +"/"+ (parseInt(y, 10)-1); 
        prevDays--; 
    } 
    for(var i=1; i<=WebCalendar.daysMonth[m-1]; i++) WebCalendar.day[i+w-1] = i +"/"+ m +"/"+ y; 
    for(var i=1; i<39-w-WebCalendar.daysMonth[m-1]+1; i++) 
    { 
        WebCalendar.day[WebCalendar.daysMonth[m-1]+w-1+i] = i +"/"+ (parseInt(m, 10)+1) +"/"+ y; 
        if(m==12) WebCalendar.day[WebCalendar.daysMonth[m-1]+w-1+i] = i +"/"+ 1 +"/"+ (parseInt(y, 10)+1); 
    } 
    for(var i=0; i<39; i++)    //这个循环是根据源数组写到日历里显示 
    { 
        var a = WebCalendar.day[i].split("/"); 
        WebCalendar.dayObj[i].innerText    = a[0]; 
        WebCalendar.dayObj[i].title        = a[2] +"-"+ appendZero(a[1]) +"-"+ appendZero(a[0]); 
        WebCalendar.dayObj[i].bgColor      = WebCalendar.dayBgColor; 
        WebCalendar.dayObj[i].style.color  = WebCalendar.wordColor; 
        if ((i<10 && parseInt(WebCalendar.day[i], 10)>20) || (i>27 && parseInt(WebCalendar.day[i], 10)<12)) 
            WebCalendar.dayObj[i].style.color = WebCalendar.wordDark; 
        if (WebCalendar.inputDate==WebCalendar.day[i])    //设置输入框里的日期在日历上的颜色 
        {WebCalendar.dayObj[i].bgColor = WebCalendar.darkColor; WebCalendar.dayObj[i].style.color = WebCalendar.lightColor;} 
        if (WebCalendar.day[i] == WebCalendar.today)      //设置今天在日历上反应出来的颜色 
        {WebCalendar.dayObj[i].bgColor = WebCalendar.todayColor; WebCalendar.dayObj[i].style.color = WebCalendar.lightColor;} 
    } 
} 
function returnDate() //根据日期格式等返回用户选定的日期 
{ 
    if(WebCalendar.objExport) 
    { 
        var returnValue; 
        var a = (arguments.length==0) ? WebCalendar.day[this.id.substr(8)].split("/") : arguments[0].split("/"); 
        var d = WebCalendar.format.match(/^(\w{4})(-|\/|.|)(\w{1,2})\2(\w{1,2})$/); 
        if(d==null){alert("你设定的日期输出格式不对！\r\n\r\n请重新定义 WebCalendar.format ！"); return false;} 
        var flag = d[3].length==2 || d[4].length==2; //判断返回的日期格式是否要补零 
        returnValue = flag ? a[2] +d[2]+ appendZero(a[1]) +d[2]+ appendZero(a[0]) : a[2] +d[2]+ a[1] +d[2]+ a[0]; 
        if(WebCalendar.timeShow) 
        { 
            var h = new Date().getHours(), m = new Date().getMinutes(), s = new Date().getSeconds(); 
            returnValue += flag ? " "+ appendZero(h) +":"+ appendZero(m) +":"+ appendZero(s) : " "+  h  +":"+ m +":"+ s; 
        } 
        WebCalendar.objExport.value = returnValue; 
        hiddenCalendar(); 
    } 
} 
function document.onclick() 
{ 
    if(WebCalendar.eventSrc != window.event.srcElement) hiddenCalendar(); 
} 
function clearDate() //清空日期 
{ 
    WebCalendar.objExport.value = ""; 
    hiddenCalendar(); 
} 

    </script>

</head>
<body class="body1" background="../../images/body1_bg.jpg" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <font face="宋体"></font>
        <table id="Table3" style="left: 0px; width: 776px; position: absolute; top: 0px;
            height: 419px" cellspacing="1" cellpadding="1" width="776" border="1">
            <tr height="30">
                <td class="GbText" style="font-weight: bold; font-size: larger; color: blue; font-family: 幼圆;
                    font-variant: normal" valign="middle" align="center" width="100%" background="../../Images/treetopbg.jpg"
                    bgcolor="#e8f4ff" colspan="2">
                    公司文件查阅</td>
            </tr>
            <tr>
                <td style="height: 32px" valign="top" align="left" height="32">
                    <table id="Table2" style="width: 884px; height: 32px" height="32" cellspacing="1"
                        cellpadding="1" width="884" border="1">
                        <tr width="100%">
                            <td style="width: 81px" height="32">
                                文件名称：</td>
                            <td style="width: 105px" height="32">
                                <asp:TextBox ID="Txt_wjm" runat="server" Width="93px"></asp:TextBox></td>
                            <td style="width: 82px" height="32">
                                文件种类：</td>
                            <td style="width: 135px" height="32">
                                <asp:DropDownList ID="Drop_wjzl" runat="server" Width="136px">
                                    <asp:ListItem Value="请选择文件种类">请选择文件种类</asp:ListItem>
                                    <asp:ListItem Value="公司文件">公司文件</asp:ListItem>
                                    <asp:ListItem Value="集团文件">集团文件</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 82px" height="32">
                                拟稿部门：</td>
                            <td style="width: 135px" height="32">
                                <asp:DropDownList ID="Drop_ssbm" runat="server" Width="136px">
                                </asp:DropDownList></td>
                            <td style="width: 51px" height="32">
                                时间：</td>
                            <td style="width: 112px" height="32">
                                <asp:TextBox ID="Txt_sj" onfocus="calendar()" runat="server" Width="94px"></asp:TextBox></td>
                            <td valign="middle" align="center" height="32">
                                <asp:LinkButton ID="LinkButton1" runat="server">查询</asp:LinkButton></td>
                        </tr>
                    </table>
                    <asp:Label ID="Label1" runat="server" Width="339px" Font-Size="X-Small" ForeColor="red">提示：文件类型为受控文件的请注意保密</asp:Label></td>
            </tr>
            <tr style="display: none">
                <td valign="top" align="center" width="754" colspan="2" height="265">
                    <font face="宋体"></font>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table id="report">
                        <asp:Repeater ID="data_Repeater" runat="server">
                            <HeaderTemplate>
                                <tr>
                                    <th>
                                        文件编号</th>
                                    <th>
                                        文件名称</th>
                                    <th>
                                        文件类型</th>
                                    <th>
                                        拟稿部门</th>
                                    <th>
                                        上传时间</th>
                                    <th>
                                        操作</th>
                                    <th>
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 133px;">
                                        <asp:TextBox runat="server" ID="fileid" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "doc_fileid")%>'>
                                        </asp:TextBox>
                                        <asp:TextBox runat="server" ID="filename" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "doc_filename")%>'>
                                        </asp:TextBox>
                                        <asp:TextBox runat="server" ID="bh" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "doc_bh")%>'>
                                        </asp:TextBox>
                                        <asp:TextBox runat="server" ID="mj" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "doc_mj")%>'>
                                        </asp:TextBox><%# DataBinder.Eval(Container.DataItem, "doc_bh")%></td>
                                    <td style="width: 400px;">
                                        <%# DataBinder.Eval(Container.DataItem, "doc_filename")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "doc_mj")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "doc_bm")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "doc_time")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandName="sel" runat="server" ID="Linkbutton1">选择</asp:LinkButton>
                                    </td>
                                    <td>
                                        <div class="arrow">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7" style="color: Red; padding-left: 50px;">
                                        <uc1:attachList ID="AttachList1" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "attachList")%>'>
                                        </uc1:attachList>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr style="background: #fff repeat-x left center">
                            <th colspan="7" style="padding-right: 20px; font-size: x-small; text-align: right">
                                <asp:LinkButton ID="preBtn" runat="server">上一页</asp:LinkButton>
                                <asp:LinkButton ID="nextBtn" runat="server">下一页</asp:LinkButton>
                                <asp:Label ID="pageLabel" runat="server"></asp:Label></th>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
