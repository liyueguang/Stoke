<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qj_xj_list_new.aspx.cs" Inherits="Stoke.USL.Staff.qj_xj_list_new" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>qj_xj_list_new</title>
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../css/css.css">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td style="FONT-VARIANT: normal; FONT-FAMILY: 幼圆; COLOR: blue; FONT-SIZE: larger; FONT-WEIGHT: bold"
						bgColor="#e8f4ff" background="../../images/treetopbg.jpg" align="center">请假销假管理</td>
				</tr>
				<tr>
					<TD>
						<TABLE id="Table2" class="gbtext" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD height=24 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          width=90 align=center><asp:linkbutton id="lbWxqjd" runat="server" CssClass="Newbutton" ForeColor="White">未销请假单</asp:linkbutton></TD>
								<TD height=24 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          width=90 align=center><asp:linkbutton id="lbYxqjd" runat="server" CssClass="Newbutton" ForeColor="White">已销请假单</asp:linkbutton></TD>
								<TD height=24 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>.gif' 
          width=90 align=center><asp:linkbutton id="lbXjd" runat="server" CssClass="Newbutton" ForeColor="White">处理中的销假单</asp:linkbutton></TD>
								<TD align="right">&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<TR>
					<TD><asp:datagrid id="dbQjspList" runat="server" DataKeyField="qjsp_id" AutoGenerateColumns="False"
							AllowPaging="True" PageSize="17" Width="100%" OnPageIndexChanged="dbQjspList_PageChanged">
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
							<FooterStyle Font-Size="X-Small" HorizontalAlign="Right"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="qjsp_id" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_qjlb" HeaderText="请假类别"></asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_kssj" HeaderText="开始时间">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_jssj" HeaderText="结束时间">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_qjsy" HeaderText="请假说明"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="qjsp_qjrq" HeaderText="申请时间">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="销假" HeaderText="销假" CommandName="xj"></asp:ButtonColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid><asp:datagrid id="dbXjspList" runat="server" DataKeyField="qjsp_id" AutoGenerateColumns="False"
							AllowPaging="True" PageSize="17" Width="100%" OnPageIndexChanged="dbXjspList_PageChanged">
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
							<FooterStyle Font-Size="X-Small" HorizontalAlign="Right"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="qjsp_id" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_qjlb" HeaderText="请假类别"></asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_kssj" HeaderText="开始时间">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_jssj" HeaderText="结束时间">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="qjsp_qjsy" HeaderText="请假说明"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="qjsp_qjrq" HeaderText="申请时间">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="流转过程" HeaderText="流转过程" CommandName="proc"></asp:ButtonColumn>
								<asp:BoundColumn DataField="xjsp_id" Visible="False"></asp:BoundColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
