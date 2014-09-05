<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="header.aspx.cs" Inherits="Stoke.header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<TITLE>哈尔滨工程大学软件与理论研究所</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<META content="MSHTML 6.00.2900.3268" name="GENERATOR">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY class="body1" leftMargin="0" topMargin="0" onLoad="clockon()" MS_POSITIONING="GridLayout">
		<TABLE height="190" cellSpacing="0" cellPadding="0" width="100%" border="0" ms_2d_layout="TRUE">
			<TR>
				<TD width="3" height="0"></TD>
				<TD width="100%" height="0"></TD>
			</TR>
			<TR vAlign="top">
				<TD colSpan="2" height="170">
					<P><!--------------------------------------------------->
						<SCRIPT language="javascript">
		  function OpenHelp()
		  {
		      window.open("/SFJD_OA/help/index.htm");
		  }
						</SCRIPT>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<TD>
										<TABLE height="39" cellSpacing="0" cellPadding="0" width="100%" bgcolor=#1c5b85
											border="0">
											<TBODY>
												<TR>
													<TD width="572"><IMG height="70" src="images/newTop.gif" width="600"></TD>
													<TD>
														<TABLE cellSpacing="0" cellPadding="0" align="right" border="0">
															<TBODY>
																<TR>
																	<TD><IMG height="31" src="images/Top5.gif" width="171"><IMG onMouseOver="this.style.cursor='hand'"  onClick="if(confirm('确定要注销吗?')){window.top.close();};target:content" height="31"
																			src="images/zx.jpg"><IMG onMouseOver="this.style.cursor='hand'" onClick="parent.document.location.reload()" height="31"
																			src="images/fhzy.jpg"><IMG onMouseOver="this.style.cursor='hand'"  onClick="window.open('./USL/help/help.aspx','rightMain')" height="31" src="images/zxbz.jpg"></TD>
																</TR>
																<TR>
																	<TD align="right" background="images/top6.gif" height="39">
																		<TABLE cellSpacing="0" cellPadding="0" align="right" border="0">
																			<TBODY>
																				<TR>
																					<TD align="center">
																						<DIV id="clock" align="right"><FONT color="#c0c277"></FONT>&nbsp;</DIV>
																					</TD>
																					<TD width="10">&nbsp;</TD>
																				</TR>
																			</TBODY>
																		</TABLE>
																	</TD>
																</TR>
															</TBODY>
														</TABLE>
													</TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
								</TR>
							</TBODY>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="54">
							<TBODY>
								<TR>
									<TD width="272" background="images/top7.gif">
										<TABLE cellSpacing="0" cellPadding="0" width="272" border="0" height="40">
											<TBODY>
												<TR>
													<TD width="30">&nbsp;</TD>
													<TD width="187"><FONT><SPAN id="Oa_hearder1_Label1"></SPAN><SPAN id="Oa_hearder1_WelcomeMessage"><FONT color="red"><B id="B1" runat="server">
																		您好！
																		<asp:Label id="Label1" runat="server">Label</asp:Label></B></FONT></SPAN></FONT></TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
									<TD width="100%" background="images/menu_bg.gif">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
											<TBODY >
												<TR >
													<TD width="0%"><FONT>&nbsp;</FONT></TD>
													<TD width="100%"><MARQUEE behavior="alternate" scrollAmount="10" scrollDelay="200" direction="right"><FONT size="4" color="#0000cd" face="华文新魏" filter:glow( color=#33ff00)><b>欢迎登录大连船舶重工集团海洋工程有限公司办公系统！</b></FONT></MARQUEE></TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
								</TR>
							</TBODY>
						</TABLE>
					</P>
				</TD>
			</TR>
			<TR vAlign="top">
				<TD height="20"></TD>
				<TD>
					<DIV><SPAN id="Oa_hearder1_Label_Script">
							<SCRIPT>function ResetHighLight(){}</SCRIPT>
						</SPAN></FONT>
						<SCRIPT src="js/fun.js"></SCRIPT>
						<SCRIPT language="javaScript">
			function clockon() {
				thistime= new Date()
				var hours=thistime.getHours()
				var minutes=thistime.getMinutes()
				var seconds=thistime.getSeconds()
				if (eval(hours) <10) {hours="0"+hours}
				if (eval(minutes) < 10) {minutes="0"+minutes}
				if (seconds < 10) {seconds="0"+seconds}
				var weekday="";
				switch(thistime.getDay())
				{
					case 0:
					weekday="星期日 ";
					break;
					case 1:
					weekday="星期一 ";
					break;
					case 2:
					weekday="星期二 ";
					break;
					case 3:
					weekday="星期三 ";
					break;
					case 4:
					weekday="星期四 ";
					break;
					case 5:
					weekday="星期五 ";
					break;
					case 6:
					weekday="星期六 ";
					break;
				}
				var _month;
				_month=thistime.getMonth()+1;
				thistime = "今天是"+thistime.getFullYear()+"年"+
							_month+"月"+
							thistime.getDate()+"日 "+
							weekday+
							hours+":"+minutes+":"+seconds

				clock.innerHTML="<font color='#c0c2e7'>"+thistime+"</font>";

				var timer=setTimeout("clockon()",200)
				
			}
						</SCRIPT>
						<P></P>
					</DIV>
				</TD>
			</TR>
		</TABLE>
	</BODY>
</HTML>