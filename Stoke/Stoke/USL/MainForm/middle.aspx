<%@ Page Language="C#" AutoEventWireup="true" Codebehind="middle.aspx.cs" Inherits="Stoke.USL.MainForm.middle" %>
<%if(browser=="IE"){ %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%} %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
    <!--
    html{
            height:100%;
        }
    body {
	    margin-left: 0px;
	    margin-top: 0px;
	    margin-right: 0px;
	    margin-bottom: 0px;
	    height:100%;
    }
    -->
    </style>
    <style type="text/css"> 
        .navPoint { 
            COLOR: white; CURSOR: pointer; FONT-FAMILY: Webdings; FONT-SIZE: 9pt;
        } 
    </style>

    <script language="javascript">
        function switchSysBar(){ 
            var locate=location.href.replace('middle.aspx','');
            var ssrc=document.all("img1").src.replace(locate,'');
            if (ssrc.indexOf("images/middle02.jpg")>0)
            {
                document.all("img1").src="../../images/middle03.jpg";
                document.all("frmTitle").style.display="none";
            } 
            else
            {  
                document.all("img1").src="../../images/middle02.jpg";
                document.all("frmTitle").style.display="block";
            } 
        } 
    </script>
    <style type="text/css">
		#popupcontent,#popupcontent1,#popupcontent2,#popupcontent3,#popupcontent4,#popupcontent5,#popupcontent6,#popupcontent7,#popupcontent8,#popupcontent9,#popupcontent10,#popupcontent11,#popupcontent12,#popupcontent13,#popupcontent14,#popupcontent15,#popupcontent16,#popupcontent17,#popupcontent18,#popupcontent19{
			position: absolute;
			display: none;
			overflow: hidden;
			border:1px solid #CCC;
			background-color:#F9F9F9;
			z-index: 1001;
			background:url("../../images/pop.png");
		}
		#statusbar{
			cursor:pointer;
			font-family:隶书;
			font-size:20px;
			text-align:right;
			color:#ff5d00;
			height:40px;
		}
		
		#shadow{
			display: none;
        	background-color: #77887E;
        	height: 100%;
        	left: 0%;
        	right: 0%;
        	width: 100%;
        	position: absolute;
        	z-index: 1000;
        }
	</style>

	<script type="text/javascript">
		var baseText = null;
		function showPopup(w,h){
			document.body.style.margin=0;
			var shadowdiv = document.getElementById("shadow");
			shadowdiv.style.display="block";
		    //实现透明遮盖，如果不需要透明，不需要设置此属性
		    shadowdiv.style.filter="alpha(opacity=30)";
			shadowdiv.style.opacity = 0.3;
			shadowdiv.style.MozOpacity = 0.3;  
			
			var popUp = document.getElementById("popupcontent");    
			popUp.style.top = document.body.clientHeight/2-h/1.8;  
			popUp.style.left = document.body.clientWidth/2-w/2;
			popUp.style.width = w + "px";
			popUp.style.height = h + "px";
			if (baseText == null)
				baseText = popUp.innerHTML;
			popUp.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent',0);\"></div>";
			//var sbar = document.getElementById("statusbar");
			//sbar.style.marginTop = (parseInt(h)-40) + "px";
			popUp.style.display = "block";
			
			var count = "<%=scnt %>";
			
			if(count > 1){
			    baseText = null;
    			
			    var popUp1 = document.getElementById("popupcontent1");    
			    popUp1.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp1.style.left = document.body.clientWidth/2-w/2;
			    popUp1.style.width = w + "px";
			    popUp1.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp1.innerHTML;
			    popUp1.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent1',1);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp1.style.display = "block";
			}
			if(count > 2){
			    baseText = null;
    			
			    var popUp2 = document.getElementById("popupcontent2");    
			    popUp2.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp2.style.left = document.body.clientWidth/2-w/2;
			    popUp2.style.width = w + "px";
			    popUp2.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp2.innerHTML;
			    popUp2.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent2',2);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp2.style.display = "block";
			}
			if(count > 3){
			    baseText = null;
    			
			    var popUp3 = document.getElementById("popupcontent3");    
			    popUp3.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp3.style.left = document.body.clientWidth/2-w/2;
			    popUp3.style.width = w + "px";
			    popUp3.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp3.innerHTML;
			    popUp3.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent3',3);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp3.style.display = "block";
			
            }
			if(count > 4){
			    baseText = null;
    			
			    var popUp4 = document.getElementById("popupcontent4");    
			    popUp4.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp4.style.left = document.body.clientWidth/2-w/2;
			    popUp4.style.width = w + "px";
			    popUp4.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp4.innerHTML;
			    popUp4.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent4',4);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp4.style.display = "block";
			
			}
			if(count > 5){
			    baseText = null;
    			
			    var popUp5 = document.getElementById("popupcontent5");    
			    popUp5.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp5.style.left = document.body.clientWidth/2-w/2;
			    popUp5.style.width = w + "px";
			    popUp5.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp5.innerHTML;
			    popUp5.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent5',5);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp5.style.display = "block";
			
			}
			if(count > 6){
			    baseText = null;
    			
			    var popUp6 = document.getElementById("popupcontent6");    
			    popUp6.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp6.style.left = document.body.clientWidth/2-w/2;
			    popUp6.style.width = w + "px";
			    popUp6.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp6.innerHTML;
			    popUp6.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent6',6);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp6.style.display = "block";
			
			}
			if(count > 7){
			    baseText = null;
    			
			    var popUp7 = document.getElementById("popupcontent7");    
			    popUp7.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp7.style.left = document.body.clientWidth/2-w/2;
			    popUp7.style.width = w + "px";
			    popUp7.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp7.innerHTML;
			    popUp7.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent7',7);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp7.style.display = "block";
			
			}
			if(count > 8){
			    baseText = null;
    			
			    var popUp8 = document.getElementById("popupcontent8");    
			    popUp8.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp8.style.left = document.body.clientWidth/2-w/2;
			    popUp8.style.width = w + "px";
			    popUp8.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp8.innerHTML;
			    popUp8.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent8',8);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp8.style.display = "block";
			
			}
			if(count > 9){
			    baseText = null;
    			
			    var popUp9 = document.getElementById("popupcontent9");    
			    popUp9.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp9.style.left = document.body.clientWidth/2-w/2;
			    popUp9.style.width = w + "px";
			    popUp9.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp9.innerHTML;
			    popUp9.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent9',9);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp9.style.display = "block";
			
			}
			if(count > 10){
			    baseText = null;
    			
			    var popUp10 = document.getElementById("popupcontent10");    
			    popUp10.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp10.style.left = document.body.clientWidth/2-w/2;
			    popUp10.style.width = w + "px";
			    popUp10.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp10.innerHTML;
			    popUp10.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent10',10);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp10.style.display = "block";
			
			}
			if(count > 11){
			    baseText = null;
    			
			    var popUp11 = document.getElementById("popupcontent11");    
			    popUp11.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp11.style.left = document.body.clientWidth/2-w/2;
			    popUp11.style.width = w + "px";
			    popUp11.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp11.innerHTML;
			    popUp11.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent11',11);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp11.style.display = "block";
			
			}
			if(count > 12){
			    baseText = null;
    			
			    var popUp12 = document.getElementById("popupcontent12");    
			    popUp12.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp12.style.left = document.body.clientWidth/2-w/2;
			    popUp12.style.width = w + "px";
			    popUp12.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp12.innerHTML;
			    popUp12.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent12',12);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp12.style.display = "block";
			
			}
			if(count > 13){
			    baseText = null;
    			
			    var popUp13 = document.getElementById("popupcontent13");    
			    popUp13.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp13.style.left = document.body.clientWidth/2-w/2;
			    popUp13.style.width = w + "px";
			    popUp13.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp13.innerHTML;
			    popUp13.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent13',13);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp13.style.display = "block";
			}
			if(count > 14){
			    baseText = null;
    			
			    var popUp14 = document.getElementById("popupcontent14");    
			    popUp14.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp14.style.left = document.body.clientWidth/2-w/2;
			    popUp14.style.width = w + "px";
			    popUp14.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp14.innerHTML;
			    popUp14.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent14',14);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp14.style.display = "block";
			}
			if(count > 15){
			    baseText = null;
    			
			    var popUp15 = document.getElementById("popupcontent15");    
			    popUp15.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp15.style.left = document.body.clientWidth/2-w/2;
			    popUp15.style.width = w + "px";
			    popUp15.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp15.innerHTML;
			    popUp15.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent15',15);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp15.style.display = "block";
			}
			if(count > 16){
			    baseText = null;
    			
			    var popUp16 = document.getElementById("popupcontent16");    
			    popUp16.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp16.style.left = document.body.clientWidth/2-w/2;
			    popUp16.style.width = w + "px";
			    popUp16.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp16.innerHTML;
			    popUp16.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent16',16);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp16.style.display = "block";
			}
			if(count > 17){
			    baseText = null;
    			
			    var popUp17 = document.getElementById("popupcontent17");    
			    popUp17.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp17.style.left = document.body.clientWidth/2-w/2;
			    popUp17.style.width = w + "px";
			    popUp17.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp17.innerHTML;
			    popUp17.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent17',17);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp17.style.display = "block";
			}
			if(count > 18){
			    baseText = null;
    			
			    var popUp18 = document.getElementById("popupcontent18");    
			    popUp18.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp18.style.left = document.body.clientWidth/2-w/2;
			    popUp18.style.width = w + "px";
			    popUp18.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp18.innerHTML;
			    popUp18.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent18',18);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp18.style.display = "block";
			}
			if(count > 19){
			    baseText = null;
    			
			    var popUp19 = document.getElementById("popupcontent19");    
			    popUp19.style.top = document.body.clientHeight/2-h/1.8;  
			    popUp19.style.left = document.body.clientWidth/2-w/2;
			    popUp19.style.width = w + "px";
			    popUp19.style.height = h + "px";
			    if (baseText == null)
				    baseText = popUp19.innerHTML;
			    popUp19.innerHTML = baseText + "<div id=\"statusbar\" onclick=\"hidePopup('popupcontent19',19);\"></div>";
			    //var sbar = document.getElementById("statusbar");
			    //sbar.style.marginTop = (parseInt(h)-40) + "px";
			    popUp19.style.display = "block";
			}
		}
		
		function hidePopup(nc,cnt){
			var popUp = document.getElementById(nc); 
			popUp.style.display = "none";

			if(cnt == 0){
			    document.getElementById("shadow").style.display="none";
			    document.body.style.margin="";
			}
		} 
		
	</script>
</head>
<body style="overflow: hidden" onload="showPopup(550,350);">
    <div id="shadow" runat="server">
    </div>
    <div id="popupcontent" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[0] %></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[0]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[0]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[0]%></div>
                </td>
            </tr>
        </table>
    </div>
    <div id="popupcontent1" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[1]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[1]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[1]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[1]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent2" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[2]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[2]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[2]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[2]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent3" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[3]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[3]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[3]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[3]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent4" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[4]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[4]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[4]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[4]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent5" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[5]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[5]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[5]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[5]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent6" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[6]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[6]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[6]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[6]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent7" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[7]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[7]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[7]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[7]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent8" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[8]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[8]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[8]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[8]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent9" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[9]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[9]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[9]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[9]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent10" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[10]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[10]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[10]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[10]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent11" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[11]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[11]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[11]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[11]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent12" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[12]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[12]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[12]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[12]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent13" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[13]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[13]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[13]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[13]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent14" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[14]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[14]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[14]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[14]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent15" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[15]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[15]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[15]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[15]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent16" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[16]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[16]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[16]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[16]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent17" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[17]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[17]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[17]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[17]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent18" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[18]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[18]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[18]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[18]%></div>
                </td>
            </tr>
        </table>
    </div>
        <div id="popupcontent19" runat="server">
        <table style="margin-top: 30px; margin-left: 20px; width: 500px; height: 280px;">
            <tr>
                <td colspan="2" height="28px" align="center">
                    <font size="4" face="黑体" color="green"><%=stitle[19]%></font>
                </td>
            </tr>
            <tr>
                <td height="30px" align="center" width="250px">
                    &nbsp; &nbsp; &nbsp;<font size="3" color="red" face="隶书">作者：<%=sauthor[19]%></font>
                </td>
                <td align="center">
                    <font size="3" color="red" face="隶书">时间：<%=sdate[19]%></font> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                
            </tr>
            <tr>
                <td colspan="2" valign="top" style="text-indent: 2em; line-height: 18px; height:212px;">
                    <div style="overflow:hidden; height:215px;"><%=scontent[19]%></div>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout: fixed;">
        <tr>
            <td width="197px" height="100%" id="frmTitle" align="center" valign="top">
                <table width="197px" height="7px" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="7px" width="197px" background="../../images/left02.jpg">
                        </td>
                    </tr>
                </table>
                <table width="190px" height="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout: fixed;">
                    <tr>
                        <td background="../../images/middle01.jpg" width="5px">
                            &nbsp;</td>
                        <td width="192px" height="100%">
                            <iframe name="I1" height="100%" width="100%" src="left.aspx" frameborder="0" scrolling="no">
                                浏览器不支持嵌入式框架，或被配置为不显示嵌入式框架。</iframe>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="12px" valign="middle" bgcolor="#f2f6ff" onclick="switchSysBar()">
                <span class="navPoint" id="switchPoint" title="关闭/打开左栏">
                    <img src="../../images/middle02.jpg" name="img1" width="12px" height="498px" id="img1" /></span></td>
            <td width="100%" height="100%" align="center" valign="top">
                <div id="man_zone" style="width: 100%; height: 100%;">
                    <iframe name="maintabs" src='MainTabs.aspx' height="100%" width="100%" frameborder="0">
                    </iframe>
                </div>
            </td>
            <td width="6px" bgcolor="#5bb2f7">
                &nbsp;</td>
        </tr>
    </table>
</body>
</html>
