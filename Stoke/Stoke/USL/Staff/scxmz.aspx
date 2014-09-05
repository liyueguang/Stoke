<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scxmz.aspx.cs" Inherits="Stoke.USL.Staff.scxmz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>scxmz</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/css.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<FONT face="宋体">
			<FORM id="Form1" method="post" runat="server">
				<FONT face="宋体">
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TBODY>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
									align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff">删除部门/项目组人员</TD>
							</TR>
							<TR>
								<TD borderColor="#000033">
									<P align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
											<TBODY>
												<TR>
													<TD vAlign="middle" align="center" width="30%" height="30">&nbsp; 部门/项目组</TD>
													<TD vAlign="middle" align="center" height="30"><asp:dropdownlist id="drop_bm" runat="server" Width="150px" Enabled="False"></asp:dropdownlist></TD>
													<TD vAlign="middle" align="center" width="30%" height="28">&nbsp;
														<asp:button id="Button1" runat="server" CssClass="input4" Text="删除部门/项目组人员" Width="120px"></asp:button></TD>
												</TR>
												<TR>
													<TD vAlign="middle" align="left" colSpan="3">&nbsp;<asp:datagrid id="dgRy" runat="server" Height="356px" AllowPaging="True" PageSize="12" width="100%"
															AutoGenerateColumns="False">
															<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F5F3FA"></AlternatingItemStyle>
															<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4"></HeaderStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="ry_id"></asp:BoundColumn>
																<asp:BoundColumn DataField="ry_zw" HeaderText="对应职位"></asp:BoundColumn>
																<asp:BoundColumn DataField="ry_zgbh" HeaderText="职工编号"></asp:BoundColumn>
																<asp:BoundColumn DataField="ry_xm" HeaderText="职工姓名"></asp:BoundColumn>
																<asp:TemplateColumn HeaderText="操作">
																	<HeaderStyle Width="15%"></HeaderStyle>
																	<ItemTemplate>
																		<asp:LinkButton id="lbtnZwxx" runat="server" CommandName="zwxx">职位信息</asp:LinkButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 28px" vAlign="middle" align="center" colSpan="3" height="28">
														<asp:button id="Button2" runat="server" CssClass="input4" Text="返回" Width="66px"></asp:button></TD>
												</TR>
											</TBODY>
										</TABLE>
									</P>
								</TD>
							</TR>
						</TBODY>
					</TABLE>
				</FONT>
			</FORM>
		</FONT>
	</body>
</HTML>
