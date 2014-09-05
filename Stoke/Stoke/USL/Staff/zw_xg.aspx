<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zw_xg.aspx.cs" Inherits="Stoke.USL.Staff.zw_xg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>zw_xg</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.STYLE1 { BORDER-RIGHT: #aaaaaa 0px dashed; BORDER-TOP: #aaaaaa 0px dashed; FONT-WEIGHT: bold; FONT-SIZE: 14px; BORDER-LEFT: #aaaaaa 0px dashed; COLOR: #4b82b4; BORDER-BOTTOM: #aaaaaa 2px dashed; HEIGHT: 30px; BACKGROUND-COLOR: #f3f5fa; TEXT-ALIGN: center }
		</style>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 815px; POSITION: absolute; TOP: 30px; HEIGHT: 280px"
				cellSpacing="0" cellPadding="0" width="815" border="0">
				<TR>
					<TD style="WIDTH: 260px; HEIGHT: 33px" vAlign="middle" align="center"><FONT face="宋体">职务名称</FONT></TD>
					<TD style="HEIGHT: 33px" vAlign="middle" align="left" colSpan="1" rowSpan="1"><asp:textbox id="txt_zwmc" runat="server" Font-Size="X-Small" Width="300px" Enabled="False"></asp:textbox>
						<asp:textbox id="txt_zwbh" runat="server" Enabled="False" Font-Size="X-Small" Visible="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 260px; HEIGHT: 60px" vAlign="middle" align="center"><FONT face="宋体">职务功能</FONT></TD>
					<TD vAlign="middle" align="left"><asp:textbox id="txt_zwgn" runat="server" Font-Size="X-Small" Width="300px" Height="60px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 260px; HEIGHT: 33px" vAlign="middle" align="center"><FONT face="宋体">职务级别</FONT></TD>
					<TD vAlign="middle" align="left"><FONT face="宋体">
							<asp:DropDownList id="ddlZwjb" runat="server" Width="300px"></asp:DropDownList></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 33px" align="center" colSpan="2"><asp:button id="Button1" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="Button2" runat="server"  Text="返回" CssClass="input4"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="WIDTH: 815px;HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="815"
				border="0">
				<TR>
					<TD align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff" style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"><FONT face="宋体">职位修改</FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
