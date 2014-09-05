<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_ygddsp2.aspx.cs" Inherits="Stoke.USL.Staff.style_ygddsp2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_ygddsp2</title>
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0" style="border-collapse: collapse;">
				<tr>
					<TD>
						<TABLE class="gbtext" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0" style="border-collapse: collapse;">
							<TR>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          height=24><asp:linkbutton id="zm" runat="server" CssClass="Newbutton" ForeColor="White">正面</asp:linkbutton></TD>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          height=24><asp:linkbutton id="bm" runat="server" CssClass="Newbutton" ForeColor="White">背面</asp:linkbutton></TD>
								<TD align="right">&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<TR>
					<TD align="center"><B><SPAN style="FONT-SIZE: 16pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">员工调动审批表<SPAN lang="EN-US">(</SPAN>背面<SPAN lang="EN-US">)</SPAN></SPAN></B></TD>
				</TR>
				<TR>
					<TD>
						<P class="MsoNormal"><B><SPAN style="FONT-SIZE: 16pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-font-kerning: 0pt">二、工作交接记录</SPAN></B></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD width="22%">原部门交接事项或物项</TD>
								<TD width="50%" rowspan="4">
									<asp:TextBox id="v" runat="server" BackColor="WhiteSmoke" ReadOnly="True" TextMode="MultiLine"
										Width="100%" Height="80px"></asp:TextBox></TD>
								<TD width="8%" rowspan="4">部门负责人</TD>
								<TD width="20%" rowspan="4">
									<asp:TextBox id="t1" runat="server" BackColor="WhiteSmoke" ReadOnly="true" Width="100%"></asp:TextBox></TD>
							</TR>
							<tr>
								<td>1.电脑及办公用品情况</td>
							</tr>
							<tr>
								<td>2.工作资料交接情况</td>
							</tr>
							<tr>
								<td>3.未完工作交接情况</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<P class="MsoNormal"><B><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-font-kerning: 0pt">三、新聘岗位员工培训审批表</SPAN></B></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD align="center" colspan="4"><FONT face="宋体"><B><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">聘任部门意见</SPAN></B></FONT></TD>
							</TR>
							<TR>
								<TD width="20%">是否需要转岗培训</TD>
								<TD colspan="3">
									<asp:DropDownList id="a2" runat="server" Width="64px" BackColor="WhiteSmoke" Enabled="False">
										<asp:ListItem Value="1">需要</asp:ListItem>
										<asp:ListItem Value="0">不需要</asp:ListItem>
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD width="20%">理由阐述</TD>
								<TD colspan="3">
									<asp:TextBox id="x" runat="server" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"
										Width="100%"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="20%">部门负责人签字</TD>
								<TD colspan="3">
									<asp:TextBox id="b2" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:TextBox><FONT face="宋体">&nbsp;
										<asp:TextBox id="c2" runat="server" onfocus="WdatePicker({skin:'simple'})" BackColor="WhiteSmoke"
											ReadOnly="true"></asp:TextBox></FONT></TD>
							</TR>
							<TR>
								<TD align="center" colspan="4"><B><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">人力资源管理部门意见</SPAN></B></TD>
							</TR>
							<TR>
								<TD width="20%" style="HEIGHT: 17px">是否同意转岗培训</TD>
								<TD colspan="3" style="HEIGHT: 17px">
									<asp:DropDownList id="d2" runat="server" BackColor="WhiteSmoke" Width="64px" Enabled="False">
										<asp:ListItem Value="1">同意</asp:ListItem>
										<asp:ListItem Value="0">不同意</asp:ListItem>
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD width="20%">培训内容</TD>
								<TD colspan="3">
									<asp:TextBox id="y" runat="server" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"
										Width="100%"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">培训方式</FONT></TD>
								<TD>
									<asp:TextBox id="e2" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:TextBox></TD>
								<TD>培训地点</TD>
								<TD>
									<asp:TextBox id="f2" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="20%">培训时间</TD>
								<TD colspan="3">
									<asp:TextBox id="g2" runat="server" BackColor="WhiteSmoke" ReadOnly="true" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox><FONT face="宋体">至</FONT>
									<asp:TextBox id="h2" runat="server" BackColor="WhiteSmoke" ReadOnly="true" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="20%">综合管理部人事岗位经理审核</TD>
								<TD colspan="3">
									<asp:TextBox id="i2" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:TextBox><FONT face="宋体">&nbsp;
										<asp:TextBox id="j2" runat="server" BackColor="WhiteSmoke" ReadOnly="true" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></FONT></TD>
							</TR>
							<TR>
								<TD width="20%">综合管理部人事主管领导意见</TD>
								<TD colspan="3">
									<asp:TextBox id="k2" runat="server" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"
										Width="100%"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="20%">综合管理部人事主管领导签字</TD>
								<TD colspan="3">
									<asp:TextBox id="l2" runat="server" BackColor="WhiteSmoke" ReadOnly="true"></asp:TextBox><FONT face="宋体">&nbsp;
										<asp:TextBox id="m2" runat="server" BackColor="WhiteSmoke" ReadOnly="true" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<td vAlign="middle" align="center" colSpan="6"><asp:button id="btnSave" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
