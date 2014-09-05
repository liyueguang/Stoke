<%@ Control Language="c#" AutoEventWireup="false" Codebehind="favorite_doc.ascx.cs" Inherits="Stoke.COMMON.favorite_doc" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P><FONT face="宋体"><FONT face="宋体">
			<TABLE id="Table4" style="WIDTH: 248px; HEIGHT: 88px" cellSpacing="1" cellPadding="1" border="0">
				<TR>
					<TD style="HEIGHT: 18px" colSpan="2">
						<asp:Label id="Label2" runat="server" Font-Bold="True" Font-Size="X-Small">请选择该文档的目的收藏夹：</asp:Label></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center" colSpan="2">
						<asp:CheckBoxList id="folderListCbl" runat="server" Font-Size="X-Small" RepeatColumns="2"></asp:CheckBoxList></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:Label id="Label3" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></TD>
				</TR>
			</TABLE>
		</FONT></FONT>
</P>
