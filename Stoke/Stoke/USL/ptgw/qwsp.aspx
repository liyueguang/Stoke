<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qwsp.aspx.cs" Inherits="Stoke.USL.ptgw.qwsp" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SlctDepartment" Src="../../COMMON/SlctDepartment.ascx" %>
<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>flow_qwsq0</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
		<script id="Back" language="javascript"> </script>
		<script type="text/javascript">
			function show()
			{
			    document.getElementById("doing").style.display = "";
                document.getElementById("topwindow").style.display = "";
            }
            function unshow()
            {
                document.getElementById("doing").style.display = "none";
                document.getElementById("topwindow").style.display = "none";
            }
			</script>
		<script language="javascript">
          function keepsession()
          {
             document.all["Back"].src="../SessionKeeper.asp?RandStr="+Math.random();
             //这里的RandStr=Math.random只是为了让每次back.src的值不同，防止同一地址刷新无效的情况
             window.setTimeout("keepsession()",1500000); //每隔1500秒调用一下本身
           }
             keepsession();
		</script>
		<script language="javascript">
////////////////////////////////////////////////////////
function jiandu(){
   var w = new ActiveXObject("Word.Application");   
   w.Application.Visible = true;
   var docs = w.Application.Documents;

   var doc = docs.open(Form1.wordurl.value);//打开word文档
     
   
   if( Form1.h_dylb.value=="0")
    {
		
		w.Selection.homekey(6)
		w.Selection.movedown(unit=5,count=10)
		w.Selection.typetext(document.Form1.h_zwfj.value)//正文及附件h_zwfj
		
	     
		w.Selection.homekey(6)
		w.Selection.movedown(unit=5,count=8)
		w.Selection.typetext(document.Form1.h_zt.value)//主题
	   
		w.Selection.homekey(6)
		w.Selection.movedown(unit=5,count=6)
		
		if(document.Form1.imgUrl71.value!="")
		{
			w.Selection.typetext("   "+document.Form1.h_ldpsyj1.value+"\n") //<!---领导批示-->
			w.Selection.typetext("                                              ")
			w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl71.value,false,true);//<!---签字图片路径:领导批示-->
			w.Selection.typetext("    "+document.Form1.h_ldpsrq1.value) //<!---领导批示日期-->
		}
		
		if(document.Form1.imgUrl72.value!="")
		{
			w.Selection.typetext("\n"+"   "+document.Form1.h_ldpsyj2.value+"\n") //<!---领导批示-->
			w.Selection.typetext("                                              ")
			w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl72.value,false,true);//<!---签字图片路径:领导批示-->
			w.Selection.typetext("    "+document.Form1.h_ldpsrq2.value) //<!---领导批示日期-->
		}
		
		if(document.Form1.imgUrl73.value!="")
		{
			w.Selection.typetext("\n"+"   "+document.Form1.h_ldpsyj3.value+"\n") //<!---领导批示-->
			w.Selection.typetext("                                              ")
			w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl73.value,false,true);//<!---签字图片路径:领导批示-->
			w.Selection.typetext("    "+document.Form1.h_ldpsrq3.value) //<!---领导批示日期-->
		}
		
		if(document.Form1.imgUrl74.value!="")
		{
			w.Selection.typetext("\n"+"   "+document.Form1.h_ldpsyj4.value+"\n") //<!---领导批示-->
			w.Selection.typetext("                                              ")
			w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl74.value,false,true);//<!---签字图片路径:领导批示-->
			w.Selection.typetext("    "+document.Form1.h_ldpsrq4.value) //<!---领导批示日期-->
		}
		
		if(document.Form1.imgUrl75.value!="")
		{
			w.Selection.typetext("\n"+"   "+document.Form1.h_ldpsyj5.value+"\n") //<!---领导批示-->
			w.Selection.typetext("                                              ")
			w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl75.value,false,true);//<!---签字图片路径:领导批示-->
			w.Selection.typetext("    "+document.Form1.h_ldpsrq5.value) //<!---领导批示日期-->
		}
		
		
    }
    else
    {
        w.Selection.homekey(6)
		w.Selection.movedown(unit=5,count=9)
		w.Selection.typetext(document.Form1.h_zwfj.value)//正文及附件h_zwfj
		
	     
		w.Selection.homekey(6)
		w.Selection.movedown(unit=5,count=7)
		w.Selection.typetext(document.Form1.h_zt.value)//主题
      
    }
    
      
     
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=5)
        w.Selection.movedown(unit=4,count=6)
        if(document.Form1.imgUrl4.value!="")
              w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl4.value,false,true);//打印签字图片，签发
        else
              w.Selection.typetext((document.Form1.h_qfr.value))//签发
       
    
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=5)
        w.Selection.movedown(unit=4,count=3)
        if(document.Form1.imgUrl5.value!="")
              w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl5.value,false,true);//打印签字图片，主管领导
        else
              w.Selection.typetext((document.Form1.h_zgld.value))//主管领导
        
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=5)
        w.Selection.typetext(document.Form1.h_hq.value)//会签h_hq
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=4)
        w.Selection.movedown(unit=4,count=9)
        if(document.Form1.imgUrl6.value!="")
              w.Selection.InlineShapes.AddPicture(document.Form1.imgUrl6.value,false,true);//打印签字图片，部门负责人
        else
              w.Selection.typetext((document.Form1.h_bmfzr.value))//部门负责人
        
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=4)
        w.Selection.movedown(unit=4,count=6)
        w.Selection.typetext(document.Form1.h_ywzg.value)//业务主管
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=4)
        w.Selection.movedown(unit=4,count=3)
        w.Selection.typetext(document.Form1.h_jbr.value)//经办人
    
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=4)
        w.Selection.typetext(document.Form1.h_blbm.value)//办理部门
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=3)
        w.Selection.movedown(unit=4,count=7)
        w.Selection.typetext(document.Form1.h_rq.value)//日期h_rq
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=3)
        w.Selection.movedown(unit=4,count=3)
        w.Selection.typetext(document.Form1.h_cs.value)//抄送
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=3)
        w.Selection.typetext(document.Form1.h_cb.value)//抄报
        
         w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=2)
        w.Selection.movedown(unit=4,count=6)
        w.Selection.typetext(document.Form1.h_bh.value)//编号h_bh
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=2)
        w.Selection.movedown(unit=4,count=3)
        w.Selection.typetext(document.Form1.h_sjr.value)//收件人
        
        w.Selection.homekey(6)
        w.Selection.movedown(unit=5,count=2)
        w.Selection.typetext(document.Form1.h_fwdw.value)//发往单位   
        
      
   }
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
function dialwinprocess()
{
	var newdialoguewin = window.showModalDialog("SelectMember.aspx",window,"dialogWidth:600px;DialogHeight=490px;status:no");
}

		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" encType="multipart/form-data" runat="server">
			<input type=hidden value="<%=wordUrl%>" name=wordurl><!---word存储路径-->
			<input type=hidden value="<%=dylb%>" name=h_dylb><!---类型-->
			<input type=hidden value="<%=imgUrl_qfr%>" name=imgUrl4><!---签字图片路径-->
			<input type=hidden value="<%=imgUrl_zgld%>" name=imgUrl5><!---签字图片路径-->
			<input type=hidden value="<%=imgUrl_bmfzr%>" name=imgUrl6><!---签字图片路径-->
			<input type=hidden value="<%=bianhao%>" name=h_bianhao><!---我的编号-->
			<input type=hidden value="<%=fwdw%>" name=h_fwdw> <!--- 发往单位:--><input 
type=hidden value="<%=sjr%>" name=h_sjr><!--- 收件人：-->
			<input type=hidden value="<%=cb%>" name=h_cb> <!--- 抄报--><input 
type=hidden value="<%=cs%>" name=h_cs><!--- 抄送：-->
			<input type=hidden value="<%=ywzg%>" name=h_ywzg> <!--- 业务主管--><input 
type=hidden value="<%=blbm%>" name=h_blbm> <!--- 办理部门->
			<input type=hidden value="<%=MYfjmc%>" name=h_myfj> <!--- 附件名称->
			
			<input type=hidden value="<%=myPS%>" name=h_myPs><!--- 领导批示2--><input 
type=hidden value="<%=h.Text%>" name=h_bh> <!--- 编号--><input 
type=hidden value="<%=f.Text%>" name=h_jbr><!--- 经办人-->
			<input type=hidden value="<%=g.Text%>" name=h_rq><!--- 日期-->
			<input type=hidden value="<%=i.Text%>" name=h_bmfzr><!--- 部门负责人-->
			<input type=hidden value="<%=j.Text%>" name=h_zgld><!--- 主管领导-->
			<input type=hidden value="<%=n.Text%>" name=h_hq><!---会签-->
			<input type=hidden value="<%=k.Text%>" name=h_qfr><!---签发人-->
			<input type=hidden value="<%=w.Text%>" name=h_zt><!---主题-->
			<input type=hidden value="<%=Server.HtmlEncode(x.Text)%>" name=h_zw><!---正文-->
			<input type=hidden value="<%=Server.HtmlEncode(zwjfj)%>" name=h_zwfj><!---正文-->
			<input type=hidden value="<%=imgUrl_ldps[0].Trim()%>" name=imgUrl71><!---签字图片路径:领导批示-->
			<input type=hidden value="<%=imgUrl_ldps[1].Trim()%>" name=imgUrl72><!---签字图片路径:领导批示-->
			<input type=hidden value="<%=imgUrl_ldps[2].Trim()%>" name=imgUrl73><!---签字图片路径:领导批示-->
			<input type=hidden value="<%=imgUrl_ldps[3].Trim()%>" name=imgUrl74><!---签字图片路径:领导批示-->
			<input type=hidden value="<%=imgUrl_ldps[4].Trim()%>" name=imgUrl75><!---签字图片路径:领导批示-->
			<input type=hidden value="<%=ldps_yj[0].Trim()%>" name=h_ldpsyj1> <!--- 领导批示意见:--><input 
type=hidden value="<%=ldps_yj[1].Trim()%>" name=h_ldpsyj2> <!--- 领导批示意见:--><input 
type=hidden value="<%=ldps_yj[2].Trim()%>" name=h_ldpsyj3> <!--- 领导批示意见:--><input 
type=hidden value="<%=ldps_yj[3].Trim()%>" name=h_ldpsyj4> <!--- 领导批示意见:--><input 
type=hidden value="<%=ldps_yj[4].Trim()%>" name=h_ldpsyj5> <!--- 领导批示意见:--><input 
type=hidden value="<%=ldps_sj[0].Trim()%>" name=h_ldpsrq1><!---领导批示日期:-->
			<input type=hidden value="<%=ldps_sj[1].Trim()%>" name=h_ldpsrq2><!---领导批示日期:-->
			<input type=hidden value="<%=ldps_sj[2].Trim()%>" name=h_ldpsrq3><!---领导批示日期:-->
			<input type=hidden value="<%=ldps_sj[3].Trim()%>" name=h_ldpsrq4><!---领导批示日期:-->
			<input type=hidden value="<%=ldps_sj[4].Trim()%>" name=h_ldpsrq5><!---领导批示日期:-->
			<TABLE id="Table5" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 776px; POSITION: absolute; TOP: 64px; HEIGHT: 23px"
				cellSpacing="1" cellPadding="1" width="776" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="WIDTH: 64px" vAlign="middle" align="center"><asp:label id="Label17" runat="server">类别</asp:label></TD>
						<TD style="WIDTH: 283px">&nbsp;
							<asp:dropdownlist id="m" runat="server" BackColor="Control" Enabled="False" Height="24px" Width="100px">
								<asp:ListItem Value="-1" Selected="True">-请选择-</asp:ListItem>
								<asp:ListItem Value="0">请示</asp:ListItem>
								<asp:ListItem Value="1">报告</asp:ListItem>
								<asp:ListItem Value="2">通报</asp:ListItem>
								<asp:ListItem Value="3">函</asp:ListItem>
								<asp:ListItem Value="4">发送资料</asp:ListItem>
								<asp:ListItem Value="5">会议纪要</asp:ListItem>
								<asp:ListItem Value="6">批复</asp:ListItem>
								<asp:ListItem Value="7">回复</asp:ListItem>
								<asp:ListItem Value="8">意见</asp:ListItem>
								<asp:ListItem Value="9">通知</asp:ListItem>
								<asp:ListItem Value="10">其它</asp:ListItem>
							</asp:dropdownlist></FONT></TD>
							<td align="right"><span style="color: Red;">发文时请点击右侧按钮进行事项选择操作：</span><input type="button" value="事项选择" onclick="show()" /></td>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 776px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
				cellSpacing="1" cellPadding="1" width="776" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 32px">
						<P align="center"><asp:label id="Label2" runat="server" Height="16px" Width="384px" Font-Size="Large">普通公文</asp:label></P>
					</TD>
				</TR>
				<TR style="display:none;">
					<TD>
						<P align="center"><asp:label id="Label3" runat="server" Font-Bold="True">Dalian Shipbuilding Industry Offshore Co.,Ltd.</asp:label></P>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table6" style="Z-INDEX: 103; LEFT: 7px; WIDTH: 776px; POSITION: absolute; TOP: 97px; HEIGHT: 812px"
				cellSpacing="1" cellPadding="1" width="776" align="center" border="1">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 157px" align="left">
							<TABLE id="Table2" style="WIDTH: 764px; HEIGHT: 197px" cellSpacing="1" cellPadding="1"
								width="764" border="0">
								<TBODY>
								    <tr>
								        <td style="WIDTH: 70px; HEIGHT: 32px" vAlign="middle" align="center">事项</td>
								        <td colspan="7"><asp:Label runat="server" ID="item_name"></asp:Label></td>
								    </tr>
									<tr>
										<TD style="WIDTH: 70px; HEIGHT: 32px" vAlign="middle" align="center"><asp:label id="Label13" runat="server">发往单位</asp:label><asp:button id="Btna" runat="server" Width="66px" Visible="False" CssClass="input4" Text="发往单位"></asp:button></TD>
										<TD style="WIDTH: 272px; HEIGHT: 32px" vAlign="middle" align="center" colSpan="3"><asp:textbox id="a" runat="server" BackColor="Control" Height="24px" Width="312px"
												AutoPostBack="True" ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 63px; HEIGHT: 32px" vAlign="middle" noWrap align="center"><asp:label id="Label14" runat="server">收件人</asp:label><asp:button id="Btnb" runat="server" Width="66px" Visible="False" CssClass="input4" Text="收件人"></asp:button></TD>
										<TD style="WIDTH: 120px; HEIGHT: 32px" vAlign="middle" align="center" colSpan="3" rowSpan="1"><asp:textbox id="b" runat="server" BackColor="Control" Height="24px" Width="263px" 
												ReadOnly="True"></asp:textbox></TD>
									</tr>
									<TR>
										<TD style="WIDTH: 70px; HEIGHT: 28px" vAlign="middle" align="center"><FONT face="宋体">外部单位</FONT></TD>
										<TD style="WIDTH: 272px; HEIGHT: 28px" vAlign="middle" align="center" colSpan="3"><asp:textbox id="a1" runat="server" BackColor="Control" Height="24px" Width="312px" ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 63px; HEIGHT: 28px" vAlign="middle" align="center"><FONT face="宋体">外部收件人</FONT></TD>
										<TD style="WIDTH: 120px; HEIGHT: 28px" vAlign="middle" align="center" colSpan="3"><asp:textbox id="b1" runat="server" BackColor="Control" Width="263px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 70px; HEIGHT: 28px" vAlign="middle" align="center"><asp:label id="Label21" runat="server">抄报</asp:label><asp:button id="Btnc" runat="server" Width="66px" Visible="False" CssClass="input4" Text="抄报"></asp:button></TD>
										<TD style="WIDTH: 272px; HEIGHT: 28px" vAlign="middle" align="center" colSpan="3" rowSpan="1"><asp:textbox id="c" runat="server" BackColor="Control" Height="24px" Width="312px" 
												AutoPostBack="True" ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 63px; HEIGHT: 28px" vAlign="middle" align="center"><asp:label id="Label22" runat="server">抄送</asp:label><asp:button id="Btnd" runat="server" Width="66px" Visible="False" CssClass="input4" Text="抄送"></asp:button><FONT face="宋体" color="#ff0066"></FONT></TD>
										<TD style="WIDTH: 120px; HEIGHT: 28px" vAlign="middle" align="center" colSpan="3" rowSpan="1"><asp:textbox id="d" runat="server" BackColor="Control" Height="24px" Width="263px" 
												ReadOnly="True"></asp:textbox></TD>
									<TR>
										<TD style="WIDTH: 70px; HEIGHT: 27px" vAlign="middle" align="center"><FONT face="宋体">外单位抄报</FONT></TD>
										<TD style="WIDTH: 272px; HEIGHT: 27px" vAlign="middle" align="center" colSpan="3"><FONT face="宋体"></FONT><asp:textbox id="c1" runat="server" BackColor="Control" Height="24px" Width="312px" ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 63px; HEIGHT: 27px" vAlign="middle" align="center"><FONT face="宋体">外单位抄送</FONT></TD>
										<TD style="WIDTH: 120px; HEIGHT: 27px" vAlign="middle" align="center" colSpan="3"><FONT face="宋体"></FONT><asp:textbox id="d1" runat="server" BackColor="Control" Height="24px" Width="263px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 70px; HEIGHT: 26px" vAlign="middle" align="center"><asp:label id="Label1" runat="server">办理部门</asp:label></FONT></TD>
										<TD style="WIDTH: 103px; HEIGHT: 26px" vAlign="middle" align="center" colSpan="1" rowSpan="1"><FONT face="宋体"><asp:dropdownlist id="e" runat="server" BackColor="Control" Enabled="False" Height="24px" Width="112px"
													></asp:dropdownlist></FONT></TD>
										<TD style="WIDTH: 54px; HEIGHT: 26px" vAlign="middle" noWrap align="center"><asp:label id="Label4" runat="server">经办人</asp:label><FONT face="宋体" color="#ff0066"></FONT></TD>
										<TD style="WIDTH: 105px; HEIGHT: 26px" vAlign="middle" align="center" colSpan="1" rowSpan="1"><asp:textbox id="f" runat="server" BackColor="Control" Height="24px" Width="100px" 
												ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 63px; HEIGHT: 26px" vAlign="middle" align="center"><FONT face="宋体" color="#000000"><asp:label id="Label11" runat="server">部门总监</asp:label></FONT></TD>
										<TD style="WIDTH: 2px; HEIGHT: 26px" vAlign="middle" align="center" colSpan="1" rowSpan="1"><asp:textbox id="l" runat="server" BackColor="Control" Height="24px" Width="100px" 
												ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 60px; HEIGHT: 26px" vAlign="middle" noWrap align="center"><FONT face="宋体">助理总裁</FONT></TD>
										<TD style="HEIGHT: 26px" vAlign="middle" align="left" colSpan="1" rowSpan="1"><asp:textbox id="o" runat="server" BackColor="Control" Height="24px" Width="100px" ReadOnly="True"
												></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 70px; HEIGHT: 24px" vAlign="middle" align="center"><asp:label id="Label7" runat="server">总经理</asp:label></TD>
										<TD style="WIDTH: 103px; HEIGHT: 24px" vAlign="middle" align="center"><asp:textbox id="i" runat="server" BackColor="Control" Height="24px" Width="113px" 
												ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 54px; HEIGHT: 24px" vAlign="middle" align="center"><span style="display:none;"><asp:label id="Label9" runat="server">主管领导</asp:label></span></TD>
										<TD style="WIDTH: 105px; HEIGHT: 24px" vAlign="bottom" align="center"><span style="display:none;"><asp:textbox id="j" runat="server" BackColor="Control" Height="24px" Width="100px" 
												ReadOnly="True"></asp:textbox></span></TD>
										<TD style="WIDTH: 63px; HEIGHT: 24px" vAlign="middle" align="center"><asp:label id="Label8" runat="server">签发人</asp:label></TD>
										<TD style="WIDTH: 2px; HEIGHT: 24px" vAlign="middle" align="center"><asp:textbox id="k" runat="server" BackColor="Control" Height="24px" Width="100px" 
												ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 60px; HEIGHT: 24px" vAlign="middle" align="center"><asp:label id="Label35" runat="server">日期</asp:label></TD>
										<TD style="HEIGHT: 24px" vAlign="middle" align="left"><asp:textbox id="g" runat="server" BackColor="Control" Height="24px" Width="100px" ></asp:textbox></TD>
									</TR>
									<tr>
									    <td style="WIDTH: 60px; HEIGHT: 24px" vAlign="middle" align="center">填写意见</td>
									    <td colspan="7"><asp:TextBox runat="server" ID="tsyj" BackColor="Control" Height="24px" Width="98%" 
											 Enabled="false"></asp:TextBox></td>
									</tr>
									<TR style="display: none;">
										<TD style="WIDTH: 70px" vAlign="middle" align="center"><asp:label id="Label12" runat="server">会签</asp:label></TD>
										<TD style="WIDTH: 367px" vAlign="middle" align="left" colSpan="3"><asp:textbox id="n" runat="server" BackColor="Control" Height="24px" Width="312px" 
												ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 61px" vAlign="middle" align="center"><FONT face="宋体">主管副总</FONT></TD>
										<TD style="WIDTH: 98px" vAlign="middle" align="center"><asp:textbox id="h1" runat="server" BackColor="Control" Height="24px" Width="100px" 
												ReadOnly="True"></asp:textbox></TD>
										<TD style="WIDTH: 61px" vAlign="middle" align="center"><asp:label id="Label5" runat="server">编号</asp:label></TD>
										<TD style="WIDTH: 98px" vAlign="middle" align="center"><asp:textbox id="h" runat="server" BackColor="Control" Height="24px" Width="100px" 
												ReadOnly="True"></asp:textbox></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE id="Table9" style="WIDTH: 764px; HEIGHT: 65px" cellSpacing="0" cellPadding="0" width="764"
								border="0">
								<TR>
									<TD id="TD1" align="left" width="76" runat="server" style="WIDTH: 76px"><FONT face="宋体">&nbsp;<asp:label id="Label6" runat="server">上传附件</asp:label></FONT></TD>
									<TD id="TD2" align="left" colSpan="5" runat="server"><INPUT class="input1" id="File1" style="WIDTH: 203px; HEIGHT: 22px" type="file" size="14"
											name="File1" runat="server">
										<asp:label id="Label10" runat="server">附件名    </asp:label><asp:textbox id="TextBox2" runat="server"></asp:textbox><asp:button id="btn_upload" runat="server" Width="60px" Text="上传" CssClass="input4"></asp:button></TD>
								</TR>
								<TR>
									<TD id="TD3" align="center" width="76" runat="server" style="WIDTH: 76px"><FONT face="宋体"></FONT></TD>
									<TD id="TD4" align="left" colSpan="5" runat="server"><asp:datalist id="FileList" runat="server" Width="432px" Height="72px">
											<ItemTemplate>
												<FONT face="宋体">
													<asp:Label id=txt_filename0 runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FileName0").ToString () %>' Visible="False">
													</asp:Label>
													<asp:Label id=txt_filename runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FileName").ToString () %>'>
													</asp:Label>&nbsp;
													<asp:ImageButton id=btn_delete runat="server" ImageUrl="../../images/dele.bmp" CommandArgument='<%# DataBinder.Eval (Container.DataItem, "FileName").ToString () %>' CommandName="delete">
													</asp:ImageButton></FONT>
											</ItemTemplate>
										</asp:datalist></TD>
								</TR>
								<TR>
									<TD id="TD5" align="left" width="76" runat="server" style="WIDTH: 76px"><FONT face="宋体">&nbsp;&nbsp;</FONT><asp:label id="Label18" runat="server">下载附件</asp:label></TD>
									<TD id="TD6" align="left" colSpan="5" runat="server"><asp:datalist id="DBFileList" runat="server" Width="434px">
											<ItemTemplate>
												<asp:HyperLink id=link_id Text='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>' Visible="False" Runat="server">
												</asp:HyperLink>
												<asp:HyperLink id=link_download Text='<%# DataBinder.Eval (Container.DataItem, "CategoryName").ToString () %>' Runat="server">
												</asp:HyperLink>
												<asp:HyperLink id=link_description Text='<%# DataBinder.Eval (Container.DataItem, "Description").ToString () %>' Visible="False" Runat="server">
												</asp:HyperLink><FONT face="宋体">&nbsp;&nbsp;</FONT>
												<asp:ImageButton id="btn_delete1" Visible=False runat="server" ImageUrl="../../images/dele.bmp" CommandArgument='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>' CommandName="delete">
												</asp:ImageButton>
											</ItemTemplate>
										</asp:datalist></TD>
								</TR>
								<tr>
								    <td>紧急程度</td>
								    <td><uc2:EmergencySelector runat="server" ID="EmergencySelector1" Enabled="false" /></td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 5px">
							<TABLE id="Table3" style="WIDTH: 764px; HEIGHT: 322px" cellSpacing="1" cellPadding="1"
								width="764" border="0">
								<TR>
									<TD style="WIDTH: 72px; HEIGHT: 33px" vAlign="middle" align="center"><asp:label id="Label15" runat="server">主题</asp:label></TD>
									<TD style="HEIGHT: 33px" vAlign="middle" align="center"><asp:textbox id="w" runat="server" BackColor="Control" Height="24px" Width="687px" 
											ReadOnly="True"></asp:textbox></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 72px" vAlign="middle" align="center"><asp:label id="Label16" runat="server">正文</asp:label></TD>
									<TD vAlign="middle" align="center"><asp:textbox id="x" runat="server" BackColor="Control" Height="298px" Width="682px" 
											ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 72px" vAlign="middle" align="center"></TD>
									<TD vAlign="middle" align="center"><asp:textbox id="y" runat="server" BackColor="Control" Height="47px" Width="682px" 
											Visible="False" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<TABLE id="Table7" style="WIDTH: 767px; HEIGHT: 69px" cellSpacing="1" cellPadding="1" width="767"
								border="1" runat="server">
								<TR>
									<TD style="HEIGHT: 10px" vAlign="top" align="center"><FONT face="宋体">反馈单</FONT></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 137px" vAlign="top" align="center"><asp:datagrid id="DataGrid1" runat="server" Height="52px" Width="751px" AutoGenerateColumns="False"
											PageSize="4">
											<AlternatingItemStyle  HorizontalAlign="Center" BackColor="#F3F5FA"></AlternatingItemStyle>
											<ItemStyle  HorizontalAlign="Center" BackColor="White"></ItemStyle>
											<HeaderStyle  HorizontalAlign="Center" CssClass="title4"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="Doc_id" HeaderText="doc_id"></asp:BoundColumn>
												<asp:BoundColumn DataField="Yjr" HeaderText="反馈人">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Step_name" HeaderText="反馈步骤">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Sj" HeaderText="反馈时间">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Yj" HeaderText="反馈信息">
													<HeaderStyle Width="50%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle  HorizontalAlign="Right" CssClass="title4"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
							<TABLE id="Table10" style="WIDTH: 768px; HEIGHT: 176px" cellSpacing="1" cellPadding="1"
								width="768" border="1" runat="server">
								<TR>
									<TD align="center">签收记录单</TD>
								</TR>
								<TR>
									<TD><asp:datagrid id="Datagrid2" runat="server" Height="52px" Width="749px" AutoGenerateColumns="False"
											PageSize="4">
											<AlternatingItemStyle  HorizontalAlign="Center" BackColor="#F3F5FA"></AlternatingItemStyle>
											<ItemStyle  HorizontalAlign="Center" BackColor="White"></ItemStyle>
											<HeaderStyle  HorizontalAlign="Center" CssClass="title4"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="ry_xm" HeaderText="签收人">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="sj" HeaderText="签收时间">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Zt" HeaderText="签收状态">
													<HeaderStyle Width="70%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle  HorizontalAlign="Right" CssClass="title4"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<TABLE id="Table4" style="WIDTH: 758px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="758"
								border="0" runat="server">
								<TR>
									<TD style="WIDTH: 21.1%" vAlign="middle" align="center"><FONT face="宋体"></FONT></TD>
									<TD style="WIDTH: 23.31%" vAlign="middle" align="center"><asp:button id="BtnTj" runat="server" Width="98px" CssClass="input4" Text="处理" Font-Overline="True"></asp:button><asp:button id="BtnDy" runat="server" Height="21px" Visible="False" CssClass="input4" Text="打印到word"></asp:button></TD>
									<TD style="WIDTH: 12.49%" vAlign="middle" align="center"><asp:button id="BtnSave" runat="server" Width="98px" CssClass="input4" Text="保存"></asp:button></TD>
									<TD style="WIDTH: 23.28%" vAlign="middle" align="center"><asp:button id="BtnQx" runat="server" Width="98px" CssClass="input4" Text="返回"></asp:button></TD>
									<TD vAlign="middle" align="center"><FONT face="宋体"></FONT></TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE>
			<TABLE id="Table14" style="WIDTH: 776px; HEIGHT: 8px" cellSpacing="1" cellPadding="1" width="776"
				border="0">
			</TABLE>
			</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
			<TABLE id="Table8" style="Z-INDEX: 104; LEFT: 281px; WIDTH: 166px; POSITION: absolute; TOP: 192px; HEIGHT: 104px"
				cellSpacing="0" cellPadding="0" width="166" bgColor="white" border="1" runat="server">
				<TR>
					<TD style="HEIGHT: 106px">
						<uc1:slctdepartment id="SlctDepartment2" runat="server" Visible="False"></uc1:slctdepartment>
						<uc1:slctmember id="SlctMember1" runat="server" Visible="False"></uc1:slctmember></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 0px" align="center">
						<asp:button id="BtnSD" runat="server" Width="66px" Text="选择" CssClass="input4" Visible="False"></asp:button>
						<asp:button id="Button6" runat="server" Width="66px" Text="返回" CssClass="input4"></asp:button></TD>
				</TR>
			</TABLE>
			</TR></TBODY></TABLE>
			<div id="doing" style="display:none; z-index:12000; left:0px; width:100%; cursor:wait; position:absolute; top:0px; height:1000px; background-color:#f9fff6; filter:alpha(Opacity=75); opacity:0.8;"></div>
			<div id="topwindow" style="display:none; background-color:White; position:absolute; width:900px; height:auto; text-align:center; vertical-align:middle; left:30px; top:80px; z-index:15000; border-right:lightgrey thin dashed; border-top:lightgrey thin dashed; border-left:lightgrey thin dashed; border-bottom:lightgrey thin dashed;">
			    <div style="padding:3px 15px 3px 15px; text-align:left; vertical-align:middle;">
                    <asp:RadioButtonList ID="CheckBoxList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Enabled="false" AutoPostBack="true">
                        <asp:ListItem Value="0">无</asp:ListItem>
                        <asp:ListItem Value="1">经营方针和经营范围的重大变化，包括新业务、新项目的启动</asp:ListItem>
                        <asp:ListItem Value="2">预计发生或发生重大亏损、重大损失</asp:ListItem>
                        <asp:ListItem Value="3">合并、分立、解散及破产</asp:ListItem>
                        <asp:ListItem Value="4">控股股东或实际控制人发生变更</asp:ListItem>
                        <asp:ListItem Value="5">控股股东或实际控制人发生国籍变更</asp:ListItem>
                        <asp:ListItem Value="6">重大资产购置、出售</asp:ListItem>
                        <asp:ListItem Value="7">重大关联交易（包含买卖和资金拆借）</asp:ListItem>
                        <asp:ListItem Value="8">重大资金借贷及担保、抵押、质押</asp:ListItem>
                        <asp:ListItem Value="9">重大或有事项，包括但不限于重大诉讼、重大仲裁、重大担保</asp:ListItem>
                        <asp:ListItem Value="10">法院裁定禁止有控制权的大股东转让其所持公司股份</asp:ListItem>
                        <asp:ListItem Value="11">董事长或总经理发生变动</asp:ListItem>
                        <asp:ListItem Value="12">其它关键高级管理人员变动（财务总监、董事会秘书、核心技术人员等）</asp:ListItem>
                        <asp:ListItem Value="13">变更会计事务所</asp:ListItem>
                        <asp:ListItem Value="14">主要银行账号被冻结，正常营业活动受影响</asp:ListItem>
                        <asp:ListItem Value="15">涉及公司增资扩股和在境内、外有关资本市场上市或挂牌的有关事项</asp:ListItem>
                        <asp:ListItem Value="16">因涉嫌违反法律法规被有关部门调查或受到行政处罚</asp:ListItem>
                        <asp:ListItem Value="17">涉嫌违反法律法规被有关部门调查或受到行政处罚或与税务部门存在未解决纠纷</asp:ListItem>
                        <asp:ListItem Value="18">股权质押冻结</asp:ListItem>
                        <asp:ListItem Value="19">定期报告更正</asp:ListItem>
                        <asp:ListItem Value="20">延期披露定期报告</asp:ListItem>
                        <asp:ListItem Value="21">董事会召开</asp:ListItem>
                        <asp:ListItem Value="22">股东大会召开</asp:ListItem>
                        <asp:ListItem Value="23">监事会召开</asp:ListItem>
                        <asp:ListItem Value="24">认为可能涉及信息披露的其他事项</asp:ListItem>
                    </asp:RadioButtonList>
			    </div>
			    <div style="padding:3px 3px 3px 15px; text-align:center; vertical-align:middle;">
                    <input type="button" value="确定" onclick="unshow()" />
			    </div>
			</div>
			
			
			</FORM>
			
	</body>
</HTML>
