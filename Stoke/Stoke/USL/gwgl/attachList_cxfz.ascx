<%@ Control Language="c#" AutoEventWireup="false" Codebehind="attachList_cxfz.ascx.cs" Inherits="Stoke.USL.gwgl.attachList_cxfz" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<ul>
	<asp:Repeater id="attachRepeater" Runat="server">
		<ItemTemplate>
			<li>
				�������ƣ�<a href='<%# DataBinder.Eval(Container.DataItem,"attach_link")%>'><%# DataBinder.Eval(Container.DataItem,"attach_name")%>
					(��С��<%# DataBinder.Eval(Container.DataItem,"attach_size")%>)</a></li>
		</ItemTemplate>
	</asp:Repeater>
</ul>
