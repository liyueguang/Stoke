<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_jxkhcz.aspx.cs" Inherits="Stoke.USL.Staff.style_jxkhcz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_jxkhcz</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="715" align="center" border="0" style="border-collapse: collapse;">
				<TR style="display: none;">
					<TD align="center" colSpan="6"><FONT face="宋体"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">大连船舶重工海洋工程有限公司</SPAN></B></FONT></TD>
				</TR>
				<TR style="display: none;">
					<TD align="center" colSpan="6"><FONT face="宋体"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><B><SPAN lang="EN-US" style="FONT-SIZE: 9pt; FONT-FAMILY: 'Times New Roman'; mso-bidi-font-size: 12.0pt; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-fareast-font-family: 宋体">DALIAN 
											SHIPBUILDING OFFSHORE CO.,LTD</SPAN></B></SPAN></B></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" align="center" colSpan="6"><FONT face="宋体"><SPAN lang="EN-US" style="FONT-SIZE: 18pt; mso-bidi-font-size: 12.0pt; mso-fareast-font-family: 黑体"><o:p><FONT face="黑体"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'"><STRONG><B><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'">（</SPAN></B>操作类）员工
												<asp:TextBox id="o" runat="server" Width="35px" ReadOnly="True" CssClass="myline"></asp:TextBox>年
												<asp:TextBox id="p" runat="server" Width="15px" ReadOnly="True" CssClass="myline"></asp:TextBox>月绩效考核表</STRONG></SPAN></FONT></o:p></SPAN></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" align="left"><FONT face="宋体" size="2"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'">基础信息</SPAN></B></FONT></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="6">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="768" border="1" style="WIDTH: 768px; HEIGHT: 806px">
							<TR>
								<TD style="WIDTH: 28px; HEIGHT: 25px"><FONT face="宋体"><STRONG>姓名</STRONG></FONT></TD>
								<TD style="WIDTH: 96px; HEIGHT: 25px"><asp:textbox id="a" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 29px; HEIGHT: 25px"><FONT face="宋体"><STRONG>编号</STRONG></FONT></TD>
								<TD style="WIDTH: 115px; HEIGHT: 25px"><asp:textbox id="b" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="120px"></asp:textbox></TD>
								<TD style="WIDTH: 28px; HEIGHT: 25px"><FONT face="宋体"><STRONG>岗位</STRONG></FONT></TD>
								<TD style="WIDTH: 1px; HEIGHT: 25px"><FONT face="宋体"><asp:dropdownlist id="c" runat="server" BackColor="WhiteSmoke" Width="120px" Enabled="False"></asp:dropdownlist></FONT></TD>
								<TD style="WIDTH: 27px; HEIGHT: 25px"><FONT face="宋体"><STRONG>部门</STRONG> </FONT>
								</TD>
								<TD style="HEIGHT: 25px"><FONT face="宋体"><asp:dropdownlist id="d" runat="server" BackColor="WhiteSmoke" Width="120px" Enabled="False"></asp:dropdownlist></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 65px; HEIGHT: 21px" colSpan="8"><FONT face="宋体"><FONT face="宋体" size="2"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'"><FONT size="2"><asp:label id="Label1" runat="server" Width="128px">一、个人总结与自评</asp:label></FONT></SPAN></B></FONT></FONT></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 18px" colSpan="8"><asp:label id="Label2" runat="server" Width="688px">根据所在岗位的岗位职责描述，叙述考核期内个人在工作质量、工作效率、工作勤勉、工作独立性方面的绩效：</asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 48px" colSpan="8"><FONT face="宋体"><asp:textbox id="e" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="672px" TextMode="MultiLine"
											Height="72px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 26px" colSpan="8"><asp:label id="Label3" runat="server" Width="288px">发掘自己在工作的不足和长处：</asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 18px" colSpan="8"><FONT face="宋体"><asp:textbox id="f" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="672px" TextMode="MultiLine"
											Height="72px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 16px" colSpan="8"><asp:label id="Label4" runat="server" Width="392px">关键事件描述：（能体现绩效成绩和不足的重要工作事件）</asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 16px" colSpan="8"><FONT face="宋体"><asp:textbox id="g" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="672px" TextMode="MultiLine"
											Height="72px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 16px" colSpan="8"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'"><FONT size="2"><asp:label id="Label5" runat="server">二、考核者评价打分</asp:label></FONT></SPAN></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 192px" colSpan="8"><FONT face="宋体">
										<TABLE id="Table3" style="WIDTH: 804px; HEIGHT: 178px" cellSpacing="0" cellPadding="0"
											width="804" border="1">
											<TR>
												<TD style="WIDTH: 118px"><FONT size="2"><STRONG>考核评价意见</STRONG></FONT></TD>
												<TD vAlign="top">
													<TABLE id="Table4" style="WIDTH: 648px; HEIGHT: 142px" cellSpacing="1" cellPadding="1"
														width="648" border="0">
														<TR>
															<TD style="WIDTH: 301px"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'"><FONT size="2"><STRONG>根据岗位职责要求（结合任职资格、工作态度、劳动纪律等情况），该员工考核期内工作表现的综合评价：</STRONG></FONT></SPAN></TD>
															<TD><asp:textbox id="h" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="264px" TextMode="MultiLine"
																	Height="89px"></asp:textbox><FONT size="2"></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 301px"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'"><FONT size="2"><STRONG>综合评价分数(满分100分)</STRONG></FONT></SPAN></TD>
															<TD><asp:textbox id="i" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="数值型" ControlToValidate="i"
																	ValidationExpression="^[0-9]*$"></asp:regularexpressionvalidator>
																<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="i" ErrorMessage="不能为空"></asp:RequiredFieldValidator><FONT size="2"></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 301px"><FONT size="2"><STRONG>考核者签名</STRONG></FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:textbox id="j" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
															<TD>&nbsp;&nbsp;&nbsp;&nbsp;<STRONG><FONT size="2">日期</FONT></STRONG>&nbsp;<STRONG><FONT size="2">
																	</FONT></STRONG>&nbsp;
																<asp:textbox id="k" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'})" runat="server"
																	BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox>&nbsp;</TD>
														</TR>
													</TABLE>
													&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											</TR>
										</TABLE>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 20px" colSpan="8"><FONT face="宋体"><asp:label id="Label6" runat="server" Width="264px">三、考核复核者的综合评价和工作期望：</asp:label></FONT></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ; WIDTH: 183px; HEIGHT: 16px" colSpan="8">
									<TABLE id="Table5" style="WIDTH: 802px; HEIGHT: 170px; border-collapse: collapse;" cellSpacing="1" cellPadding="1"
										width="802" border="1">
										<TR>
											<TD style="WIDTH: 118px">
												<P><FONT size="2"><STRONG>复核者意见</STRONG></FONT></P>
											</TD>
											<TD>
												<TABLE id="Table6" style="WIDTH: 648px; HEIGHT: 142px" cellSpacing="1" cellPadding="1"
													width="648" border="0">
													<TR>
														<TD style="WIDTH: 301px"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-hansi-font-family: 'Times New Roman'; mso-ascii-font-family: 'Times New Roman'"><FONT size="2"><STRONG>鉴定和审核意见</STRONG></FONT></SPAN></TD>
														<TD><asp:textbox id="l" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="264px" TextMode="MultiLine"
																Height="89px"></asp:textbox><FONT size="2"></FONT></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 301px"><FONT size="2"><STRONG>考核复核者签名</STRONG></FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:textbox id="m" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
														<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG><FONT size="2">&nbsp;日期</FONT></STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:textbox id="n" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'})" runat="server"
																BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox>&nbsp;</TD>
													</TR>
												</TABLE>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 438px" vAlign="middle" align="center" colSpan="8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnSave" runat="server" Text="提交" CssClass="input4" CausesValidation="False"></asp:button><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="btnCancel" runat="server" Text="返回" CssClass="input4" CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
