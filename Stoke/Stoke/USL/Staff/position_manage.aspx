<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="position_manage.aspx.cs" Inherits="Stoke.USL.Staff.position_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
		<title>position_manage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101;POSITION: absolute" cellSpacing="0" cellPadding="0"
				width="100%" border="0">
				<tr style="display:none;">
					<td colspan="4" align="center" class="GbText" style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						background="../../Images/treetopbg.jpg" bgColor="#e8f4ff">公司职位管理</td>
				</tr>
				<tr>
					<td align="center" width="20%">
						<asp:TextBox id="txt_zw" runat="server" Width="120px" onfocus="this.value=''">职位名称</asp:TextBox></td>
					<td align="center" width="55%">
						<asp:TextBox id="txt_js" runat="server" Width="300px" onfocus="this.value=''">职位职能</asp:TextBox></td>
					<td align="center" width="15%">
						<asp:DropDownList id="ddlFlag" runat="server" Width="250px"></asp:DropDownList></td>
					<td width="10%" align="center">
						<asp:Button id="btn_add" runat="server" CssClass="input4" Text="添加"></asp:Button></td>
				</tr>
				<TR>
					<TD colspan="4" align="center">
						<asp:datagrid id="dbZw" runat="server" Width="100%" PageSize="20" AllowPaging="True" AutoGenerateColumns="False"
							OnPageIndexChanged="dbZw_PageChanged">
							<FooterStyle HorizontalAlign="Right"></FooterStyle>
							<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFF3FB"></ItemStyle>
							<HeaderStyle BackColor="#507CD1" ForeColor="white" Font-Bold="true" HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="zw_bh" HeaderText="编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="zw_mc" HeaderText="职位名称">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="zw_js" HeaderText="职位职能">
									<HeaderStyle Width="55%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="zwjbmc" HeaderText="职位级别">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:LinkButton id="LinkButton2" runat="server" CommandName="xg">修改</asp:LinkButton><FONT face="宋体">&nbsp;</FONT>
										<asp:LinkButton id="LinkButton1" runat="server" CommandName="sc">删除</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
