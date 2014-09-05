<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Depart_Manage.aspx.cs" Inherits="Stoke.USL.Staff.Depart_Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Depart_Manage</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.STYLE1 { BORDER-RIGHT: #aaaaaa 0px dashed; BORDER-TOP: #aaaaaa 0px dashed; FONT-WEIGHT: bold; FONT-SIZE: 14px; BORDER-LEFT: #aaaaaa 0px dashed; COLOR: #4b82b4; BORDER-BOTTOM: #aaaaaa 2px dashed; HEIGHT: 30px; BACKGROUND-COLOR: #f3f5fa; TEXT-ALIGN: center }
		</style>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 815px; POSITION: absolute; TOP: 30px; HEIGHT: 280px"
				cellSpacing="0" cellPadding="0" width="815px" border="0">
				<TR>
					<TD style="WIDTH: 260px; HEIGHT: 33px" vAlign="middle" align="center"><asp:label id="Label1" runat="server">部门/项目组名称</asp:label><FONT style="COLOR: red" face="宋体">*</FONT></TD>
					<TD style="HEIGHT: 33px" vAlign="middle" align="left" colSpan="1" rowSpan="1"><asp:textbox id="txtName" runat="server" Width="300px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 260px; HEIGHT: 60px" vAlign="middle" align="center"><asp:label id="Label2" runat="server">部门/项目组介绍</asp:label></TD>
					<TD vAlign="middle" align="left"><asp:textbox id="txtIntro" runat="server" Width="300px" Height="60px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 260px" vAlign="middle" align="center"><asp:label id="Label4" runat="server">部门/项目组简称</asp:label><FONT style="COLOR: red" face="宋体">*</FONT></TD>
					<TD vAlign="middle" align="left"><FONT face="宋体"><asp:textbox id="txt_bmjc" runat="server" Width="300px"></asp:textbox></FONT></TD>
				</TR>
				<TR style="display: none;">
					<TD style="WIDTH: 260px" vAlign="middle" align="center"><asp:label id="Label8" runat="server">部门缩写</asp:label><FONT face="宋体">/开工命令号</FONT><FONT style="COLOR: red" face="宋体">*</FONT></TD>
					<TD vAlign="middle" align="left"><asp:textbox id="kgmlh" runat="server" Width="300px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 260px" vAlign="middle" align="center"><asp:label id="Label7" runat="server">是否项目组</asp:label><FONT style="COLOR: red" face="宋体">*</FONT></TD>
					<TD vAlign="middle" align="left"><asp:dropdownlist id="DropDownList1" runat="server" Width="100px">
							<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
							<asp:ListItem Value="1">是</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:button id="Button1" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="Button2" runat="server" Text="返回" CssClass="input4"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="WIDTH: 815px;HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="815px"
				border="0">
				<TR>
					<TD align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff" style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"><asp:label id="Label3" runat="server" Font-Size="Medium"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
