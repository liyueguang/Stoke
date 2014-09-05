<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SlctDepartment.ascx.cs" Inherits="Stoke.COMMON.SlctDepartment" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../css/css.css" type="text/css" rel="stylesheet">
<TABLE id="Table1" style="WIDTH: 241px; HEIGHT: 200px" cellSpacing="0" cellPadding="0"
	width="241" align="center" border="1">
	<TR>
		<TD style="WIDTH: 89px; HEIGHT: 28px" noWrap colSpan="3" bgColor="inactivecaption" rowSpan="1"
			align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Label id="Label1" runat="server" Font-Size="X-Small" Width="72px" Font-Bold="True">请选择部门 </asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 89px" noWrap><FONT face="宋体">
				<asp:ListBox id="LB_All" runat="server" Width="96px" Height="168px" SelectionMode="Multiple"></asp:ListBox></FONT></TD>
		<TD style="WIDTH: 49px" noWrap><FONT face="宋体">
				<P>&nbsp;
					<asp:Button id="Btn1" Text=">>" runat="server" Width="40px" CssClass="input4" OnClick="Btn1_Click1"></asp:Button></P>
				<P>&nbsp;
					<asp:Button id="Btn2" Text="<<" runat="server" Width="40px" CssClass="input4" OnClick="Btn2_Click1"></asp:Button></P>
			</FONT>
		</TD>
		<TD noWrap><FONT face="宋体">
				<asp:ListBox id="LB_Select" runat="server" Width="96px" Height="168px" SelectionMode="Multiple"></asp:ListBox></FONT></TD>
	</TR>
</TABLE>
<FONT face="宋体"></FONT>
