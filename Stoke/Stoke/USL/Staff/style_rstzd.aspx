<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_rstzd.aspx.cs" Inherits="Stoke.USL.Staff.style_rstzd" %>
<%@ Register TagPrefix="uc1" TagName="SlctPosition" Src="../../COMMON/SlctPosition.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>style_rstzd</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" style="LEFT: 304px; POSITION: absolute; TOP: 160px; border-collapse: collapse;" cellSpacing="0"
				cellPadding="0" width="166" bgColor="#ffffff" border="1" runat="server">
				<TR>
					<TD style="HEIGHT: 58px"><uc1:SlctMember id="SlctMember1" runat="server"></uc1:SlctMember></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 0px" align="center"><asp:button id="btnBack" runat="server" Width="66px" CssClass="input4" Text="确定"></asp:button><asp:button id="Button3" runat="server" Width="66px" CssClass="input4" Text="关闭"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table8" style="LEFT: 296px; POSITION: absolute; TOP: 8px; border-collapse: collapse;" cellSpacing="0" cellPadding="0"
				width="166" bgColor="#ffffff" border="1" runat="server">
				<TR>
					<TD style="HEIGHT: 58px"><uc1:SlctPosition id="SlctPosition1" runat="server"></uc1:SlctPosition></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 0px" align="center"><asp:button id="btnZwBack" runat="server" Width="66px" CssClass="input4" Text="确定"></asp:button><asp:button id="btnZwClose" runat="server" Width="66px" CssClass="input4" Text="关闭"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table9" style="LEFT: 296px; POSITION: absolute; TOP: 8px; border-collapse: collapse;" cellSpacing="0" cellPadding="0"
				width="166" bgColor="#ffffff" border="1" runat="server">
				<TR>
					<TD style="HEIGHT: 58px"><uc1:SlctPosition id="SlctPosition2" runat="server"></uc1:SlctPosition></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 0px" align="center"><asp:button id="btnZwBack2" runat="server" Width="66px" CssClass="input4" Text="确定"></asp:button><asp:button id="btnZwClose2" runat="server" Width="66px" CssClass="input4" Text="关闭"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" style="border-collapse: collapse;">
				<tr style="display:none;">
					<td align="center" colSpan="6"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><asp:label id="Label1" runat="server">大连船舶重工集团海洋工程有限公司</asp:label></SPAN></td>
				</tr>
				<tr style="display: none;">
					<td align="center" colSpan="6"><SPAN lang="EN-US" style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-fareast-font-family: 宋体"><asp:label id="Label2" runat="server">DALIAN SHIPBUILDING OFFSHORE CO.,LTD</asp:label></SPAN></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 14px" width="17%" height="14">通知分类<FONT style="COLOR: red" face="宋体">*</FONT></TD>
					<TD style="HEIGHT: 14px" width="17%" height="14"><asp:dropdownlist id="b" runat="server" Width="100px" AutoPostBack="True" BackColor="WhiteSmoke">
							<asp:ListItem Value="0">-请选择-</asp:ListItem>
							<asp:ListItem Value="1">入职</asp:ListItem>
							<asp:ListItem Value="2">离职</asp:ListItem>
							<asp:ListItem Value="4">退休</asp:ListItem>
							<asp:ListItem Value="3">调职</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 14px" width="17%" height="14"><FONT style="COLOR: red" face="宋体"></FONT></TD>
					<TD style="HEIGHT: 14px" width="17%" height="14"><FONT face="宋体"></FONT></TD>
					<TD style="HEIGHT: 14px" width="17%"><FONT face="宋体"></FONT></TD>
					<td style="HEIGHT: 14px"><FONT face="宋体"></FONT></td>
				</TR>
				<tr>
					<td vAlign="middle" align="center" colSpan="6">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" style="border-collapse: collapse;">
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: large" vAlign="middle" align="center" colSpan="6"><asp:label id="Label3" runat="server">人 事 通 知</asp:label></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="6"><FONT style="COLOR: red" face="宋体"></FONT><FONT style="COLOR: red" face="宋体"><asp:label id="Label4" runat="server"></asp:label>*</FONT><asp:textbox id="c" runat="server" Width="250px" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="6"><FONT face="宋体">事由<FONT style="COLOR: red" face="宋体">*</FONT>
										<asp:textbox id="d" runat="server" Width="500px" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox><asp:label id="Label5" runat="server"></asp:label><asp:label id="Label6" runat="server"></asp:label></FONT></TD>
							</TR>
							<tr>
								<td colSpan="6"><asp:textbox id="e" runat="server" Width="100%" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="true"
										TextMode="MultiLine" Height="200px"></asp:textbox></td>
							</tr>
							<tr>
								<td colSpan="6">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" style="border-collapse: collapse;">
										<tr>
											<td>
												<table id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
													<TR>
														<td style="HEIGHT: 18px" align="center" width="8%">部门<FONT style="COLOR: red" face="宋体">*</FONT></td>
														<td style="HEIGHT: 18px" width="22%"><asp:dropdownlist id="ddlDdbm" runat="server" Width="170px" AutoPostBack="True"></asp:dropdownlist></td>
														<td align="center" width="8%">项目组</td>
														<td width="22%"><asp:dropdownlist id="ddlXmz" runat="server" Width="150px" AutoPostBack="True"></asp:dropdownlist></td>
														<TD style="HEIGHT: 18px" align="center" width="8%"><FONT face="宋体">姓名<FONT style="COLOR: red" face="宋体">*</FONT></FONT></TD>
														<TD style="HEIGHT: 18px" width="8%"><asp:dropdownlist id="ddlDdxm" runat="server" Width="100px" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 18px" align="center" width="8%"><FONT face="宋体">职号<FONT style="COLOR: red" face="宋体">*</FONT></FONT></TD>
														<TD style="HEIGHT: 18px" width="8%"><asp:dropdownlist id="ddlDdzh" runat="server" Width="100px"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<td style="HEIGHT: 18px" align="center" rowSpan="2">原部门</td>
														<td style="HEIGHT: 18px" rowSpan="2"><asp:dropdownlist id="ddlDdybm" runat="server" Width="170px"></asp:dropdownlist></td>
														<TD style="HEIGHT: 18px" align="center"><asp:button id="btnXgw" runat="server" CssClass="input4" Text="现岗位"></asp:button></TD>
														<TD style="HEIGHT: 18px" align="left" colSpan="5"><FONT face="宋体"><asp:textbox id="txtDdxzw" runat="server" Width="313px"></asp:textbox>部门调动(不包含项目组)<FONT style="COLOR: red" face="宋体">*
																	<asp:dropdownlist id="ddlBmdd" runat="server" Width="72px">
																		<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
																		<asp:ListItem Value="是">是</asp:ListItem>
																		<asp:ListItem Value="否">否</asp:ListItem>
																	</asp:dropdownlist></FONT></FONT></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 18px" align="center"><asp:button id="btnYgw" runat="server" CssClass="input4" Text="原岗位"></asp:button></TD>
														<TD style="HEIGHT: 18px" colSpan="6"><FONT face="宋体"><asp:textbox id="txtDdyzw" runat="server" Width="312px"></asp:textbox>组织关系归属<FONT style="COLOR: red" face="宋体">*
																	<asp:dropdownlist id="ddlZzgx" runat="server" Width="136px"></asp:dropdownlist></FONT></FONT></FONT></TD>
														<td><asp:button id="btn_dd_add" runat="server" CssClass="input4" Text="添加"></asp:button></td>
													</TR>
												</table>
											</td>
										</tr>
										<TR>
											<TD align="center" colSpan="9"><asp:datagrid id="dbDd" runat="server" Width="100%" AutoGenerateColumns="False">
													<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
													<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="rstzd_id" ReadOnly="True"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="序号">
															<ItemTemplate>
																<%#Container.ItemIndex+1%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="rstzd_bm" HeaderText="部门"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_xm" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_zgbh" ReadOnly="True" HeaderText="职号"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_ybm" HeaderText="原部门"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_ygw" HeaderText="原岗位"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_gw" HeaderText="现岗位"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_ygwdj" HeaderText="原岗位等级"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_gwdj" HeaderText="现岗位等级"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_jbgz" HeaderText="基本工资"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_gwgdgz" HeaderText="岗位固定工资"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_qtgz" HeaderText="其他工资"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_yfxbzj" HeaderText="原风险保证金"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_fxbzj" HeaderText="现风险保证金"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="部门调动">
															<ItemTemplate>
																<%# DataBinder.Eval(Container,"DataItem.rstzd_bmdd") %>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList id=drop1 runat="server" DataValueField="rstzd_bmdd" DataTextField="rstzd_bmdd" DataSource="<%#BindData2()%>">
																</asp:DropDownList>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="组织关系">
															<ItemTemplate>
																<%# DataBinder.Eval(Container,"DataItem.rstzd_zzgx_str") %>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList id="drop2" runat="server" DataValueField="rstzd_zzgx" DataTextField="rstzd_zzgx_str" DataSource="<%#BindData3()%>">
																</asp:DropDownList>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="确定" CancelText="取消" EditText="填写工资信息"></asp:EditCommandColumn>
														<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD colSpan="6">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" style="border-collapse: collapse;">
										<TR>
											<td align="right"><asp:button id="Button1" runat="server" CssClass="input4" Text="添加人员"></asp:button></td>
										</TR>
										<tr>
											<td align="center"><asp:datagrid id="dbBd" runat="server" Width="100%" AutoGenerateColumns="False">
													<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
													<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="rstzd_id" ReadOnly="True"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="序号">
															<ItemTemplate>
																<%#Container.ItemIndex+1%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="rstzd_bm" HeaderText="部门"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_xm" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_zgbh" ReadOnly="True" HeaderText="职号"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_gw" ReadOnly="True" HeaderText="岗位"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_gwdj" HeaderText="岗位等级"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_jbgz" HeaderText="基本工资"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_gwgdgz" HeaderText="岗位固定工资"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_qtgz" HeaderText="其他工资"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_fxbzj" HeaderText="风险保证金"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_htkssj" ReadOnly="True" HeaderText="合同起始时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_htjzsj" ReadOnly="True" HeaderText="合同结束时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="组织关系">
															<ItemTemplate>
																<%# DataBinder.Eval(Container,"DataItem.rstzd_zzgx_str") %>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList id="drop3" runat="server" DataValueField="rstzd_zzgx" DataTextField="rstzd_zzgx_str" DataSource="<%#BindData4()%>">
																</asp:DropDownList>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="确定" CancelText="取消" EditText="填写工资信息"></asp:EditCommandColumn>
														<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="6">
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" style="border-collapse: collapse;">
										<TR>
											<td align="right"><asp:button id="btn_txry" runat="server" CssClass="input4" Text="添加人员"></asp:button></td>
										</TR>
										<tr>
											<td align="center"><asp:datagrid id="dbTx" runat="server" Width="100%" AutoGenerateColumns="False">
													<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
													<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="rstzd_id" ReadOnly="True"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="序号">
															<ItemTemplate>
																<%#Container.ItemIndex+1%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="rstzd_bm" HeaderText="部门"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_xm" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_zgbh" ReadOnly="True" HeaderText="职号"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_gw" ReadOnly="True" HeaderText="岗位"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_htkssj" ReadOnly="True" HeaderText="参加工作时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_htjzsj" HeaderText="退休时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
														<asp:BoundColumn DataField="rstzd_qtgz" HeaderText="退休养老金合计"></asp:BoundColumn>
														<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="确定" CancelText="取消" EditText="填写退休信息"></asp:EditCommandColumn>
														<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<td width="12%"><asp:label id="labJbr1" runat="server">经办人</asp:label></td>
								<td><asp:textbox id="f" runat="server" Width="130px" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></td>
								<td><FONT face="宋体"><asp:label id="labZgfzr1" runat="server" Width="111px">经办部门主管负责人</asp:label></FONT></td>
								<td><asp:textbox id="g" runat="server" Width="150px" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></td>
								<td colSpan="2"></td>
							</tr>
							<tr>
								<td style="WIDTH: 194px"><asp:label id="labZgfz1" runat="server">公司主管副总</asp:label></td>
								<td><asp:textbox id="h" runat="server" Width="130px" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></td>
								<td><FONT face="宋体"><asp:label id="labZjl1" runat="server">总经理</asp:label></FONT></td>
								<td><asp:textbox id="i" runat="server" Width="150px" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></td>
								<td style="WIDTH: 30px"><FONT face="宋体"><asp:label id="labRq1" runat="server">日期</asp:label></FONT></td>
								<td><asp:textbox id="j" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="130px" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="6"><asp:button id="btnSave" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="Button2" runat="server" CssClass="input4" Text="保存"></asp:button><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="btnPrint" runat="server" Width="80px" CssClass="input4" Text="打印到Word" Visible="False"></asp:button></td>
							</tr>
							<TR>
								<TD align="left" colSpan="6"><FONT face="宋体"><asp:label id="Label7" runat="server"></asp:label><asp:label id="Label8" runat="server"></asp:label><asp:label id="Label9" runat="server"></asp:label><asp:label id="Label10" runat="server"></asp:label><asp:label id="Label11" runat="server"></asp:label></FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD vAlign="middle" align="center" colSpan="6"><asp:datagrid id="dgStatPerMonth" runat="server" Width="100%" AutoGenerateColumns="False" ShowFooter="True">
							<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
							<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="编号">
									<ItemTemplate>
										<%#Container.ItemIndex+1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ry_bm" ReadOnly="True" HeaderText="部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="num" ReadOnly="True" HeaderText="本月合计"></asp:BoundColumn>
								<asp:BoundColumn DataField="M_num" ReadOnly="True" HeaderText="合同制"></asp:BoundColumn>
								<asp:BoundColumn DataField="PM_num" ReadOnly="True" HeaderText="聘管"></asp:BoundColumn>
								<asp:BoundColumn DataField="FP_num" ReadOnly="True" HeaderText="返聘"></asp:BoundColumn>
								<asp:BoundColumn DataField="JY_num" ReadOnly="True" HeaderText="借用"></asp:BoundColumn>
								<asp:BoundColumn DataField="W_num" ReadOnly="True" HeaderText="聘工"></asp:BoundColumn>
								<asp:BoundColumn DataField="PZ_num" ReadOnly="True" HeaderText="公司派驻"></asp:BoundColumn>
								<asp:BoundColumn ReadOnly="True" HeaderText="上月合计"></asp:BoundColumn>
								<asp:BoundColumn ReadOnly="True" HeaderText="本月变动"></asp:BoundColumn>
								<asp:BoundColumn ReadOnly="True" HeaderText="变动说明"></asp:BoundColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#F3F5FA"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD vAlign="middle" colSpan="6"><asp:label id="lab_bz" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
