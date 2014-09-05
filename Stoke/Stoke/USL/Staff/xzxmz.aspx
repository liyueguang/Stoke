<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xzxmz.aspx.cs" Inherits="Stoke.USL.Staff.xzxmz" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>xzxmz</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/css.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<FONT face="宋体">
			<FORM id="Form1" method="post" runat="server">
				<FONT face="宋体">
					<TABLE id="Table4" style="LEFT: 296px; POSITION: absolute; TOP: 152px" cellSpacing="0"
						cellPadding="0" width="166" bgColor="white" border="1" runat="server">
						<TR>
							<TD style="HEIGHT: 58px"><uc1:slctmember id="SlctMember1" runat="server"></uc1:slctmember></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 0px" align="center"><asp:button id="btnBack" runat="server" CssClass="input4" Text="确定" Width="66px"></asp:button>
								<asp:button id="Button3" runat="server" Width="66px" Text="关闭" CssClass="input4"></asp:button></TD>
						</TR>
					</TABLE>
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TBODY>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
									align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff">新增部门/项目组人员</TD>
							</TR>
							<TR>
								<TD borderColor="#000033">
									<P align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
											<TBODY>
												<TR>
													<TD vAlign="middle" align="left" width="20%" height="30">&nbsp; 部门/项目组</TD>
													<TD style="WIDTH: 251px" vAlign="middle" align="center" width="251" height="30"><asp:dropdownlist id="drop_bm" runat="server" Width="150px"></asp:dropdownlist></TD>
													<TD vAlign="middle" align="center" width="20%">职位</TD>
													<TD vAlign="middle" align="center" width="30%" height="30"><FONT face="宋体"><asp:dropdownlist id="drop_zw" runat="server" Width="150px"></asp:dropdownlist></FONT></TD>
													<TD style="WIDTH: 404px; HEIGHT: 28px" vAlign="middle" align="center" width="404" height="28">&nbsp;
														<asp:button id="Button1" runat="server" CssClass="input4" Text="添加人员" Width="66px"></asp:button></TD>
												</TR>
												<TR>
													<TD vAlign="middle" align="left" colSpan="5">&nbsp;<asp:datagrid id="dgRy" runat="server" Height="356px" AllowPaging="True" PageSize="12" width="100%"
															AutoGenerateColumns="False">
															<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F5F3FA"></AlternatingItemStyle>
															<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4"></HeaderStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="ry_id"></asp:BoundColumn>
																<asp:BoundColumn DataField="ry_zgbh" HeaderText="职工编号"></asp:BoundColumn>
																<asp:BoundColumn DataField="ry_xm" HeaderText="姓名"></asp:BoundColumn>
																<asp:BoundColumn DataField="ry_bm" HeaderText="部门"></asp:BoundColumn>
																<asp:BoundColumn DataField="ry_zw" HeaderText="职位"></asp:BoundColumn>
																<asp:TemplateColumn HeaderText="操作">
																	<ItemTemplate>
																		<asp:LinkButton id="lbtnUpdate" runat="server" CommandName="Update">职位信息</asp:LinkButton>&nbsp;
																		<asp:LinkButton id="lbtnDelete" runat="server" CommandName="Delete">删除</asp:LinkButton>
																	</ItemTemplate>
																	<HeaderStyle Width="20%"></HeaderStyle>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 28px" vAlign="middle" align="center" colSpan="5" height="28">
														<asp:button id="Button2" runat="server" CssClass="input4" Text="确定" Width="66px"></asp:button>&nbsp;&nbsp;&nbsp;
														<asp:button id="cmdBack" runat="server" Width="60px" Text="返回" CssClass="input4" Height="20px"
															CausesValidation="False"></asp:button></TD>
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
