<%@ Control Language="c#" AutoEventWireup="false" Codebehind="attachList.ascx.cs" Inherits="Stoke.USL.gwgl.attachList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<ul>
	<asp:Repeater id="attachRepeater" Runat="server">
		<ItemTemplate>
			<li>
				附件名称：<a href='<%# DataBinder.Eval(Container.DataItem,"attach_link")%>'><%# DataBinder.Eval(Container.DataItem,"attach_name")%>
					(大小：<%# DataBinder.Eval(Container.DataItem,"attach_size")%>)</a></li>
		</ItemTemplate>
	</asp:Repeater>
</ul>
