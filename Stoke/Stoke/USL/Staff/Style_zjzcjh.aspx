<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Style_zjzcjh.aspx.cs" Inherits="Stoke.USL.Staff.Style_zjzcjh" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Style_zjzcjh</title>
		<meta name="vs_showGrid" content="False">
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
						align="center"><asp:dropdownlist id="a" Runat="server" Enabled="False"></asp:dropdownlist>部门<asp:dropdownlist id="b" Runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist>年<asp:dropdownlist id="c" Runat="server" Enabled="False" AutoPostBack="True">
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
						</asp:dropdownlist>月资金支出计划表
					</TD>
				</TR>
				<tr>
					<td height="10">
						<table id="tableAddNewDetail" runat="server" border="1" style="WIDTH: 100%; TEXT-ALIGN: center">
							<tr>
								<td width="15%">产品名称或项目</td>
								<td colSpan="2" width="25%"><asp:dropdownlist id="ddlXm" Runat="server" Width="90%"></asp:dropdownlist></td>
								<td width="8%">业务名称</td>
								<td width="17%"><asp:textbox id="txtYwmc" Runat="server" Width="90%"></asp:textbox></td>
								<td>收款单位</td>
								<td><asp:textbox id="txtSkdw" Runat="server" Width="90%"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:literal id="d" Runat="server" Text="7月资金支出计划"></asp:literal></td>
								<td width="7%">人民币</td>
								<td width="18%"><asp:textbox id="firstRmb" Runat="server" Width="90%"></asp:textbox></td>
								<td width="7%">美元</td>
								<td width="18%"><asp:textbox id="firstUsd" Runat="server" Width="90%"></asp:textbox></td>
								<td width="7%">欧元</td>
								<td width="18%"><asp:textbox id="firstEur" Runat="server" Width="90%"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:literal id="e" Runat="server" Text="8月资金支出计划"></asp:literal></td>
								<td>人民币</td>
								<td><asp:textbox id="secondRmb" Runat="server" Width="90%"></asp:textbox></td>
								<td>美元</td>
								<td><asp:textbox id="secondUsd" Runat="server" Width="90%"></asp:textbox></td>
								<td>欧元</td>
								<td><asp:textbox id="secondEur" Runat="server" Width="90%"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:literal id="f" Runat="server" Text="9月资金支出计划"></asp:literal></td>
								<td>人民币</td>
								<td><asp:textbox id="thirdRmb" Runat="server" Width="90%"></asp:textbox></td>
								<td>美元</td>
								<td><asp:textbox id="thirdUsd" Runat="server" Width="90%"></asp:textbox></td>
								<td>欧元</td>
								<td><asp:textbox id="thirdEur" Runat="server" Width="90%"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:literal id="ggg" Runat="server" Text="经办人"></asp:literal></td>
								<td colspan="2"><asp:textbox id="jbrXmTxt" Runat="server" Width="90%"></asp:textbox></td>
								<td colspan="4" align="center"><asp:button id="btnAddItem" Runat="server" Text="添加"></asp:button>
									<asp:button id="Button1" Runat="server" Text="重置"></asp:button></td>
							</tr>
							<tr>
								<td colSpan="7"><FONT face="宋体"></FONT></td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<td align="center"><asp:datagrid id="zjzcDatagrid" Runat="server" Width="100%" PageSize="15" AllowPaging="True" AutoGenerateColumns="False"
							ShowHeader="true" ShowFooter="True" OnItemDataBound="zjzcDatagrid_ItemDataBound">
							<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<PagerStyle Position="TopAndBottom" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<FooterStyle HorizontalAlign="Center"></FooterStyle>
							<Columns>
								<asp:TemplateColumn ItemStyle-Width="5%">
									<ItemTemplate>
										<%#Container.ItemIndex + 1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="xm_mc" ReadOnly="True" ItemStyle-Width="12%"></asp:BoundColumn>
								<asp:BoundColumn DataField="content" ReadOnly="True" ItemStyle-Width="12%"></asp:BoundColumn>
								<asp:BoundColumn DataField="skdw" ReadOnly="True" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstRmb" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstUsd" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="firstEur" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondRmb" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondUsd" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="secondEur" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdRmb" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdUsd" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="thirdEur" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="jbrXm" ReadOnly="True" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" ItemStyle-Width="3%" CancelText="取消" EditText="修改" UpdateText="确定"></asp:EditCommandColumn>
								<asp:ButtonColumn ButtonType="LinkButton" ItemStyle-Width="3%" CommandName="delete" Text="删除"></asp:ButtonColumn>
								<asp:BoundColumn DataField="ID" Visible="True" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="modifyStatus" Visible="True" ReadOnly="True"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</TR>
				<tr>
					<td>
						<table id="Table2" width="100%">
							<tbody>
								<tr>
									<td>制表人</td>
									<td><asp:TextBox ID="h" Runat="server" ReadOnly="True"></asp:TextBox></td>
									<td>日期</td>
									<td><asp:TextBox ID="i" Runat="server" ReadOnly="True" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></td>
									<td width="50"></td>
									<td>部门负责人</td>
									<td><asp:TextBox ID="j" Runat="server" ReadOnly="True"></asp:TextBox></td>
									<td>日期</td>
									<td><asp:TextBox ID="k" Runat="server" ReadOnly="True" onfocus="WdatePicker({skin:'simple'})"></asp:TextBox></td>
								</tr>
							</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center">
						<table id="modifyAdvice" width="100%" runat="server">
							<tr>
								<td align="center">修改意见</td>
							</tr>
							<tr>
								<td align="center"><asp:datagrid id="maDatagrid" Runat="server" Width="100%" PageSize="15" AllowPaging="True" AutoGenerateColumns="False">
										<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle Width="5%"></ItemStyle>
												<ItemTemplate>
													<%#Container.ItemIndex + 1%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="xm_mc" ReadOnly="True">
												<ItemStyle Width="12%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ywnr" ReadOnly="True">
												<ItemStyle Width="12%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="skdw" ReadOnly="True">
												<ItemStyle Width="10%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="firstRmb">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="firstUsd">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="firstEur">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="secondRmb">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="secondUsd">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="secondEur">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="thirdRmb">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="thirdUsd">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="thirdEur">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="5%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="modifyStatus">
												<ItemStyle Width="6%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="modifyTime">
												<ItemStyle Width="10%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="True" DataField="ID" ReadOnly="True"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Right" Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:button id="btnSubmit" Runat="server" Text="提交"></asp:button>
						<asp:Button id="btnReturn" runat="server" Text="退回部门" Visible="False"></asp:Button>
						<asp:Button id="btnBack" runat="server" Text="返回" Visible="False"></asp:Button></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
