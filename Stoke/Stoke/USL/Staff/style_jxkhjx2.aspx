<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_jxkhjx2.aspx.cs" Inherits="Stoke.USL.Staff.style_jxkhjx2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_jxkhjx2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="815" align="center" border="0" style="border-collapse: collapse;">
				<tr>
					<TD colspan="2">
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
          ><asp:linkbutton id="zs" runat="server" ForeColor="White" CssClass="Newbutton" Height="16px" Width="64px">转正审批表</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<TR>
					<TD style="HEIGHT: 23px" vAlign="middle" colspan="2" align="center"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><FONT size="4">
											见习、<SPAN style="mso-bidi-font-weight: bold">试用期员工自我评估表</SPAN></FONT></SPAN></B></SPAN></B></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px" vAlign="middle" colspan="2" align="center"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">（见习、试用期工作小结）</SPAN>
						</SPAN>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 6px" vAlign="middle" colspan="2" align="center"><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><STRONG></STRONG>
							<STRONG><FONT size="3"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">
											试用期工作详细总结</SPAN></B></FONT></STRONG></SPAN></TD>
				</TR>
				<tr>
					<TD style="HEIGHT: 7px"><FONT face="宋体">1、试用期主要工作内容</FONT>
					</TD>
					<td style="HEIGHT: 60px"><FONT face="宋体"><asp:textbox id="a" runat="server" Height="56px" Width="456px" TextMode="MultiLine" ReadOnly="true"
								BackColor="WhiteSmoke"></asp:textbox></FONT></td>
				</tr>
				<TR>
					<td style="HEIGHT: 24px">
						<FONT face="宋体">2、试用期的主要工作业绩</FONT>
					</td>
					<TD style="HEIGHT: 8px" vAlign="middle"><FONT face="宋体"><asp:textbox id="b" runat="server" Height="56px" Width="456px" TextMode="MultiLine" ReadOnly="true"
								BackColor="WhiteSmoke"></asp:textbox></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" vAlign="middle"><FONT face="宋体">3、试用期中存在的问题</FONT></TD>
					<TD style="HEIGHT: 28px" vAlign="middle"><asp:textbox id="c" runat="server" Height="56px" Width="456px" TextMode="MultiLine" ReadOnly="true"
							BackColor="WhiteSmoke"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" vAlign="middle"><FONT face="宋体">4、工作改进建议</FONT></TD>
					<TD style="HEIGHT: 28px" vAlign="middle"><asp:textbox id="d" runat="server" Height="56px" Width="456px" TextMode="MultiLine" ReadOnly="true"
							BackColor="WhiteSmoke"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="middle" colspan="2" align="center" height="80">员工签名
						<asp:textbox id="e" runat="server" Width="138px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;指导老师确认
						<asp:textbox id="f" runat="server" Width="138px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox>&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<td style="HEIGHT: 23px" vAlign="middle" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnSave" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></td>
				</TR>
				<TR>
					<TD vAlign="middle" colspan="2"><asp:dropdownlist id="g" runat="server" Width="154px" BackColor="WhiteSmoke" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="h" runat="server" Width="154px" BackColor="WhiteSmoke" Visible="False" Enabled="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="middle" colspan="2"><asp:textbox id="i" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="k" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="m" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="o" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="q" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="s" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="u" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="w" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="y" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox><asp:textbox id="a1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="56px" ReadOnly="True"
							BackColor="WhiteSmoke" Visible="False"></asp:textbox></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
