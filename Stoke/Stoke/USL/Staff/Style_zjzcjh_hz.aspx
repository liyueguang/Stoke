<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Style_zjzcjh_hz.aspx.cs" Inherits="Stoke.USL.Staff.Style_zjzcjh_hz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_zjzcjh_hz</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../css/css.css">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR style="display: none;">
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: black; FONT-FAMILY: 幼圆; HEIGHT: 27px; FONT-VARIANT: normal"
						bgColor="#e8f4ff" height="27" vAlign="middle" background="../../images/treetopbg.jpg"
						align="center">大连船舶重工集团海洋工程有限公司
					</TD>
				</TR>
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: black; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						bgColor="#e8f4ff" height="3%" vAlign="middle" background="../../images/treetopbg.jpg"
						align="center"><asp:dropdownlist id="b" AutoPostBack="True" Enabled="False" Runat="server"></asp:dropdownlist>年<asp:dropdownlist id="c" AutoPostBack="True" Enabled="False" Runat="server">
							<asp:ListItem Value="01">1-3</asp:ListItem>
							<asp:ListItem Value="02">2-4</asp:ListItem>
							<asp:ListItem Value="03">3-5</asp:ListItem>
							<asp:ListItem Value="04">4-6</asp:ListItem>
							<asp:ListItem Value="05">5-7</asp:ListItem>
							<asp:ListItem Value="06">6-8</asp:ListItem>
							<asp:ListItem Value="07">7-9</asp:ListItem>
							<asp:ListItem Value="08">8-10</asp:ListItem>
							<asp:ListItem Value="09">9-11</asp:ListItem>
							<asp:ListItem Value="10">10-12</asp:ListItem>
							<asp:ListItem Value="11">11-1</asp:ListItem>
							<asp:ListItem Value="12">12-2</asp:ListItem>
						</asp:dropdownlist>月资金支出计划汇总表
					</TD>
				</TR>
				<tr>
					<td height="10">已完成资金支出计划部门列表</td>
				</tr>
				<tr>
					<td height="10"><FONT face="宋体"><asp:datagrid id="submitDatagrid" runat="server" AutoGenerateColumns="false" Width="100%">
								<Columns>
									<asp:TemplateColumn HeaderText="序号">
										<ItemTemplate>
											<%#Container.ItemIndex + 1%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="bm_mc" HeaderText="部门名称"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></FONT></td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<TR>
					<td align="center"><asp:datagrid id="zjzcDatagrid" Runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="true"
							ShowHeader="true" AllowPaging="True" PageSize="15">
							<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<PagerStyle Position="TopAndBottom" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<FooterStyle HorizontalAlign="Center"></FooterStyle>
							<Columns>
								<asp:TemplateColumn ItemStyle-Width="7%">
									<ItemTemplate>
										<%#Container.ItemIndex + 1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="xm_mc" ReadOnly="True" ItemStyle-Width="15%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstRmb" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstUsd" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstEur" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondRmb" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondUsd" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondEur" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdRmb" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdUsd" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdEur" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:ButtonColumn ButtonType="LinkButton" ItemStyle-Width="15%" CommandName="detail" Text="查看详情"></asp:ButtonColumn>
								<asp:BoundColumn DataField="doc_id" Visible="True"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</TR>
				<tr>
					<td height="10" align="center"><FONT face="宋体"></FONT></td>
				</tr>
				<TR style="DISPLAY: none">
					<td align="center"><asp:datagrid id="zjzcDatagrid1" Runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="true"
							ShowHeader="true" AllowPaging="True" PageSize="15">
							<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<PagerStyle Position="TopAndBottom" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<FooterStyle HorizontalAlign="Center"></FooterStyle>
							<Columns>
								<asp:TemplateColumn ItemStyle-Width="7%">
									<ItemTemplate>
										<%#Container.ItemIndex + 1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="xm_mc" ReadOnly="True" ItemStyle-Width="15%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstRmb" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstUsd" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstEur" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondRmb" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondUsd" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondEur" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdRmb" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdUsd" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdEur" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:ButtonColumn ButtonType="LinkButton" ItemStyle-Width="15%" CommandName="detail" Text="查看分布情况"></asp:ButtonColumn>
								<asp:BoundColumn DataField="doc_id" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="xm_bh" Visible="False"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</TR>
				<tr>
					<td>
						<table id="Table2" width="100%">
							<tbody>
								<tr>
									<td>制表人</td>
									<td><asp:TextBox ID="d" Runat="server" ReadOnly="True"></asp:TextBox></td>
									<td>日期</td>
									<td><asp:TextBox ID="e" Runat="server" ReadOnly="True" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></td>
									<td width="50"></td>
									<td>财务部长</td>
									<td><asp:TextBox ID="f" Runat="server" ReadOnly="True"></asp:TextBox></td>
									<td>日期</td>
									<td><asp:TextBox ID="g" Runat="server" ReadOnly="True" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></td>
								</tr>
								<tr>
									<td>主管副总</td>
									<td><asp:TextBox ID="h" Runat="server" ReadOnly="True"></asp:TextBox></td>
									<td>日期</td>
									<td><asp:TextBox ID="i" Runat="server" ReadOnly="True" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></td>
									<td width="50"></td>
									<td>总经理</td>
									<td><asp:TextBox ID="j" Runat="server" ReadOnly="True"></asp:TextBox></td>
									<td>日期</td>
									<td><asp:TextBox ID="k" Runat="server" ReadOnly="True" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></td>
								</tr>
							</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><FONT face="宋体"></FONT></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="btnSubmit" Runat="server" Text="提交"></asp:button></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
