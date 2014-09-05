<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_jxkhjx1.aspx.cs" Inherits="Stoke.USL.Staff.style_jxkhjx1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML xmlns:o>
	<HEAD>
		<title>style_jxkhjx</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="800" border="0" style="border-collapse: collapse;">
				<tr>
					<TD>
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="296" border="0">
							<TR>
								<TD style="WIDTH: 91px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          ><asp:linkbutton id="zp" runat="server" ForeColor="White" CssClass="Newbutton">自我评价意见表</asp:linkbutton></TD>
								<TD style="WIDTH: 60px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          ><asp:linkbutton id="zq" runat="server" ForeColor="White" CssClass="Newbutton">工作小结</asp:linkbutton></TD>
								<TD style="WIDTH: 69px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>.gif' 
          ><asp:linkbutton id="zdp" runat="server" ForeColor="White" CssClass="Newbutton">绩效评估表</asp:linkbutton></TD>
								<TD style="WIDTH: 65px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>.gif' 
          ><asp:linkbutton id="zs" runat="server" ForeColor="White" CssClass="Newbutton">转正审批表</asp:linkbutton></TD>
							</TR>
						</TABLE>
						</FONT></TD>
				</tr>
				<TR>
					<TD style="HEIGHT: 23px" vAlign="middle" align="center"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><FONT size="4">见习、<SPAN style="mso-bidi-font-weight: bold">试用期员工自我评估表</SPAN></FONT></SPAN></B></SPAN></B></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px" vAlign="middle" align="center"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">（转正评估自我评价意见表）
						</SPAN>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 6px" vAlign="middle" align="left"><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</STRONG>
							<STRONG><FONT size="3">基本信息</FONT></STRONG></SPAN></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 47px">
						<TABLE id="Table2" style="WIDTH: 808px; HEIGHT: 28px" cellSpacing="0" cellPadding="0" width="752"
							border="1">
							<TR>
								<TD style="WIDTH: 54px" align="left" colSpan="9"><B><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 新宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><FONT size="2">&nbsp;&nbsp;<FONT face="宋体"><SPAN lang="EN-US">姓名<FONT style="COLOR: red" face="宋体">*</FONT></SPAN></FONT></FONT></SPAN></B></TD>
								<TD style="WIDTH: 132px" align="left"><asp:textbox id="xm" runat="server" Width="138px"></asp:textbox></TD>
								<TD style="WIDTH: 68px" align="left"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2"><STRONG>工号<FONT style="COLOR: red" face="宋体">*</FONT></STRONG></FONT></FONT></TD>
								<TD style="WIDTH: 176px" align="left"><asp:textbox id="zgbh" runat="server" Width="138px"></asp:textbox></TD>
								<TD style="WIDTH: 76px" align="left"><FONT face="宋体" size="2"><STRONG>部门<FONT style="COLOR: red" face="宋体">*</FONT></STRONG></FONT></TD>
								<TD align="left"><asp:dropdownlist id="bm" runat="server" Width="154px"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td align="left">
						<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="1">
						</TABLE>
						<FONT face="宋体">
							<P><FONT face="宋体"></FONT></P>
						</FONT>
						<P><FONT face="宋体" size="2"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										评价内容</FONT></STRONG></FONT></P>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="Table4" style="WIDTH: 808px; HEIGHT: 304px; border-collapse: collapse;" cellSpacing="0" cellPadding="0"
							width="808" border="1">
							<TR>
								<TD style="WIDTH: 30px"><FONT face="宋体" size="2">自我评价</FONT></TD>
								<TD vAlign="top">
									<TABLE id="Table5" style="WIDTH: 680px; HEIGHT: 278px" cellSpacing="0" cellPadding="0"
										width="680" border="0">
										<TR>
											<TD style="WIDTH: 268px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><FONT size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;对公司企业文化、价值观的态度</FONT></SPAN></TD>
											<TD><asp:radiobuttonlist id="td" runat="server" Width="216px" RepeatDirection="Horizontal">
													<asp:ListItem Value="认同" Selected="True">认同</asp:ListItem>
													<asp:ListItem Value="勉强认同">勉强认同</asp:ListItem>
													<asp:ListItem Value="不认同">不认同</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 268px">
												<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><SPAN style="FONT-FAMILY: 宋体"><FONT size="2">对于自己在试用期内的表现感到<SPAN lang="EN-US">
																<o:p></o:p></SPAN></FONT></SPAN></P>
											</TD>
											<TD><FONT face="宋体"><asp:radiobuttonlist id="bx" runat="server" Width="216px" RepeatDirection="Horizontal">
														<asp:ListItem Value="很满意" Selected="True">很满意</asp:ListItem>
														<asp:ListItem Value="还可以">还可以</asp:ListItem>
														<asp:ListItem Value="不满意">不满意</asp:ListItem>
													</asp:radiobuttonlist></FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 268px">
												<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><SPAN style="FONT-FAMILY: 宋体">对自己与同事及领导的关系感到<SPAN lang="EN-US">
															<o:p></o:p></SPAN></SPAN></P>
											</TD>
											<TD><FONT face="宋体"><asp:radiobuttonlist id="gx" runat="server" Width="216px" RepeatDirection="Horizontal">
														<asp:ListItem Value="很满意" Selected="True">很满意</asp:ListItem>
														<asp:ListItem Value="还可以">还可以</asp:ListItem>
														<asp:ListItem Value="不满意">不满意</asp:ListItem>
													</asp:radiobuttonlist></FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 268px">
												<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><SPAN style="FONT-FAMILY: 宋体"><FONT size="2">对于目前工作感到<SPAN lang="EN-US">
																<o:p></o:p></SPAN></FONT></SPAN></P>
											</TD>
											<TD><FONT face="宋体"><asp:radiobuttonlist id="gz" runat="server" Width="328px" RepeatDirection="Horizontal">
														<asp:ListItem Value="还能担当更困难的工作" Selected="True">还能担当更困难的工作</asp:ListItem>
														<asp:ListItem Value="正适合本身能力">正适合本身能力</asp:ListItem>
														<asp:ListItem Value="有些吃力">有些吃力</asp:ListItem>
													</asp:radiobuttonlist></FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 268px">
												<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><SPAN style="FONT-FAMILY: 宋体"><FONT size="2">对目前的工作量感到<SPAN lang="EN-US">
																<o:p></o:p></SPAN></FONT></SPAN></P>
											</TD>
											<TD><FONT face="宋体"><asp:radiobuttonlist id="gzl" runat="server" Width="224px" RepeatDirection="Horizontal">
														<asp:ListItem Value="太大" Selected="True">太大</asp:ListItem>
														<asp:ListItem Value="适中">适中</asp:ListItem>
														<asp:ListItem Value="太小">太小</asp:ListItem>
													</asp:radiobuttonlist></FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 268px">
												<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><SPAN style="FONT-FAMILY: 宋体"><FONT size="2">对目前工作环境感到<SPAN lang="EN-US">
																<o:p></o:p></SPAN></FONT></SPAN></P>
											</TD>
											<TD><FONT face="宋体"><asp:radiobuttonlist id="gzhj" runat="server" Width="216px" RepeatDirection="Horizontal">
														<asp:ListItem Value="很满意" Selected="True">很满意</asp:ListItem>
														<asp:ListItem Value="还可以">还可以</asp:ListItem>
														<asp:ListItem Value="不满意">不满意</asp:ListItem>
													</asp:radiobuttonlist></FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 268px">
												<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><SPAN style="FONT-FAMILY: 宋体"><FONT size="2">对目前工作时间感到<SPAN lang="EN-US">
																<o:p></o:p></SPAN></FONT></SPAN></P>
											</TD>
											<TD><FONT face="宋体"><asp:radiobuttonlist id="gzsj" runat="server" Width="232px" RepeatDirection="Horizontal" Height="6px">
														<asp:ListItem Value="太长" Selected="True">太长</asp:ListItem>
														<asp:ListItem Value="稍长">稍长</asp:ListItem>
														<asp:ListItem Value="刚好">刚好</asp:ListItem>
													</asp:radiobuttonlist></FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD vAlign="middle" align="left">
						<TABLE id="Table7" style="WIDTH: 808px; HEIGHT: 235px; border-collapse: collapse;" cellSpacing="0" cellPadding="0"
							width="808" border="1">
							<TR>
								<TD style="WIDTH: 133px; HEIGHT: 53px"><FONT face="宋体" size="2"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><FONT size="2">对直接主管的建议</FONT></SPAN></FONT></TD>
								<TD style="HEIGHT: 53px"><asp:textbox id="jy" runat="server" Width="576px" Height="50px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px; HEIGHT: 40px"><FONT face="宋体" size="2">在试用期间遇到的问题</FONT></TD>
								<TD style="HEIGHT: 40px"><FONT face="宋体"><asp:textbox id="wt" runat="server" Width="576px" Height="56px" TextMode="MultiLine"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px; HEIGHT: 33px"><FONT face="宋体" size="2">自我评价意见</FONT></TD>
								<TD style="HEIGHT: 33px"><asp:textbox id="yj" runat="server" Width="576px" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 133px"><FONT face="宋体" size="2"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><FONT size="2">得分（</FONT><FONT size="2"><SPAN lang="EN-US">0-100</SPAN>分)（</FONT><FONT size="2">占考核比重10</FONT><SPAN lang="EN-US">%<FONT size="2">)<FONT style="COLOR: red" face="宋体">*</FONT></FONT></SPAN></SPAN></FONT></TD>
								<TD><asp:textbox id="fs" runat="server" Width="138px"></asp:textbox><FONT face="宋体">&nbsp;
										<SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">
											A</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">杰出（<SPAN lang="EN-US">95-100</SPAN>）；<SPAN lang="EN-US">B</SPAN>良好（<SPAN lang="EN-US">90-94</SPAN>）；<SPAN lang="EN-US">C</SPAN>正常（<SPAN lang="EN-US">80-89</SPAN>）；<SPAN lang="EN-US">D</SPAN>需改进（<SPAN lang="EN-US">79-60</SPAN>）</SPAN></FONT></TD>
							</TR>
						</TABLE>
						<FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</FONT>
						<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ValidationExpression="^[0-9]*$"
							ControlToValidate="fs" ErrorMessage="数值型"></asp:regularexpressionvalidator></TD>
				</TR>
				<TR>
					<td vAlign="middle" align="center"><asp:button id="btnSave" runat="server" CssClass="input4" Text="保存"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button>&nbsp;&nbsp;
						<asp:button id="reset" runat="server" CssClass="input4" Text="重填" Visible="False"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
