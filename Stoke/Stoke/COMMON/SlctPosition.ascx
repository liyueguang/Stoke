<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SlctPosition.ascx.cs" Inherits="Stoke.COMMON.SlctPosition" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<LINK href="../css/css.css" type="text/css" rel="stylesheet">
<TABLE id="Table1" style="WIDTH: 446px; HEIGHT: 304px" cellSpacing="0" cellPadding="0"
	width="446" align="center" border="0">
	<TR>
		<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; HEIGHT: 30px; FONT-VARIANT: normal"
			colSpan="3" rowSpan="1" background="../images/treetopbg.jpg" bgColor="#e8f4ff">选择岗位</TD>
	</TR>
	<TR>
		<TD align="center" colSpan="3" height="30"><FONT style="FONT-SIZE: small" face="宋体"></FONT>
			<asp:dropdownlist id="ddlBm" runat="server" Width="200px" AutoPostBack="True" CssClass="input4"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD align="center"><FONT face="宋体"><asp:listbox id="LB_All" Width="200px" runat="server" Height="260px" SelectionMode="Multiple"></asp:listbox></FONT></TD>
		<TD align="center">
			<P><FONT face="宋体"><asp:button id="btnAdd" Width="40px" runat="server" CssClass="input4" Text=">>"></asp:button></FONT></P>
			<P><FONT face="宋体"></FONT>
				<asp:button id="btnDelete" CssClass="input4" runat="server" Width="40px" Text="<<"></asp:button></P>
		</TD>
		<TD align="center"><asp:listbox id="LB_Select" Width="200px" runat="server" Height="260px" SelectionMode="Multiple"></asp:listbox></TD>
	</TR>
</TABLE>
