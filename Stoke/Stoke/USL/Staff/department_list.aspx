<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="department_list.aspx.cs" Inherits="Stoke.USL.Staff.department_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>msg_list</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/css.css" type="text/css" rel="stylesheet">
		<style type="text/css">.STYLE1 { BORDER-RIGHT: #aaaaaa 0px dashed; BORDER-TOP: #aaaaaa 0px dashed; FONT-WEIGHT: bold; FONT-SIZE: 14px; BORDER-LEFT: #aaaaaa 0px dashed; COLOR: #4b82b4; BORDER-BOTTOM: #aaaaaa 2px dashed; HEIGHT: 26px; BACKGROUND-COLOR: #f3f5fa; TEXT-ALIGN: center }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout" class="body1">
		<SCRIPT language="javascript">
		function ConfirmDel()
		{
			 if(confirm("确定要删除吗？一旦删除将不能恢复！"))
				return true;
			else
				 return false;
		}
		</SCRIPT>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" align="center">
				<tr style="display:none;">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff">部门/项目组列表</td>
				</tr>
				<tr>
					<TD>
						<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align=center width=90 
			background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
			height=24><asp:linkbutton id="lbBm" runat="server" CssClass="Newbutton" ForeColor="White">部门</asp:linkbutton></TD>
								<TD align=center width=90 
			background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
			height=24><asp:linkbutton id="lbXmz" runat="server" CssClass="Newbutton" ForeColor="White">项目组</asp:linkbutton></TD>
								<TD align="right">
									<span style="display:none;"><asp:Button id="btn_add_zw" runat="server" CssClass="input4" Text="组织结构图维护" Width="90px"></asp:Button></span><FONT face="宋体">&nbsp;</FONT>
									<asp:Button id="btn_add_ry" runat="server" CssClass="input4" Text="添加人员"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<TR>
					<TD class="td2" vAlign="baseline" align="center" style="HEIGHT: 330px">
						<asp:datagrid id="DataGrid1" runat="server" PageSize="20" AutoGenerateColumns="False" AllowPaging="True"
							Width="100%">
							<AlternatingItemStyle HorizontalAlign="Center" BackColor="White"></AlternatingItemStyle>
                                <ItemStyle HorizontalAlign="Center" BackColor="#EFF3FB"></ItemStyle>
						<HeaderStyle BackColor="#507CD1" ForeColor="white" Font-Bold="true" HorizontalAlign="Center"
                                    CssClass="title4" />
							<Columns>
								<asp:BoundColumn Visible="False" DataField="bm_bh" HeaderText="部门编号"></asp:BoundColumn>
								<asp:HyperLinkColumn Visible="False" Text="部门名称" DataNavigateUrlField="bm_bh" DataTextField="bm_mc" HeaderText="部门名称">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="bm_mc" HeaderText="部门名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="bm_js" HeaderText="部门介绍">
									<HeaderStyle Width="50%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="bm_jc" HeaderText="部门简称">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="bm_kgmlh" HeaderText="缩写/开工命令号">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="删除人员">
									<ItemTemplate>
										<FONT face="宋体">
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">删除人员</asp:LinkButton></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" CssClass="title4" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center"><FONT face="宋体">&nbsp;</FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
