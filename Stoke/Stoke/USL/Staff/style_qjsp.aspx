<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_qjsp.aspx.cs" Inherits="Stoke.USL.Staff.style_qjsp" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>style_qjsp</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
		<script language="javascript">
		function onLoad()
		{
			alert('fdsfadfs');
			if(document.getElementById('TextBox1').value == '')
			{
				alert("fsdf");
				document.getElementById('TextBox1').value = 1;
				document.Form1.submit();
			}
		}
		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="95%" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						vAlign="middle" align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff"
						colSpan="6" height="3%">请假审批单
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center" colSpan="6" height="3%"><asp:label id="i1" runat="server" Visible="False"></asp:label>(综合管理部存档)
					</TD>
				</TR>
				<tr>
					<td colSpan="6">
						<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD width="15%">姓名<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD width="15%"><asp:textbox id="a" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD width="15%">部门<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD width="15%"><asp:dropdownlist id="b" runat="server" BackColor="WhiteSmoke" Width="154px" Enabled="False"></asp:dropdownlist></TD>
								<TD width="15%">职务</TD>
								<TD width="20%"><asp:dropdownlist id="c" runat="server" BackColor="WhiteSmoke" Width="154px" Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>出生时间</TD>
								<TD><asp:textbox id="d" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD><FONT face="宋体">参加工作时间</FONT></TD>
								<TD><FONT face="宋体"><asp:textbox id="j1" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
											BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD>进本公司时间</TD>
								<TD><FONT face="宋体"><asp:textbox id="e" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
											BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD>请假类别<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="f" runat="server" BackColor="WhiteSmoke" Width="154px" Enabled="False">
											<asp:ListItem Value="-请选择-">---请选择---</asp:ListItem>
											<asp:ListItem Value="有薪事假">有薪事假</asp:ListItem>
											<asp:ListItem Value="无薪事假">无薪事假</asp:ListItem>
											<asp:ListItem Value="病假">病假</asp:ListItem>
											<asp:ListItem Value="婚假">婚假</asp:ListItem>
											<asp:ListItem Value="产假">产假</asp:ListItem>
											<asp:ListItem Value="丧假">丧假</asp:ListItem>
											<asp:ListItem Value="护理假">护理假</asp:ListItem>
											<asp:ListItem Value="年假">年假</asp:ListItem>
											<asp:ListItem Value="培训假">培训假</asp:ListItem>
											<asp:ListItem Value="公干">公干</asp:ListItem>
											<asp:ListItem Value="其他假">其他假</asp:ListItem>
										</asp:dropdownlist></FONT></TD>
								<TD><FONT face="宋体"><FONT face="宋体" color="#000000">请假说明</FONT></FONT><FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD colSpan="3"><asp:textbox id="k" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"
										Width="440px"></asp:textbox><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">请假开始时间<FONT style="COLOR: red" face="宋体">*</FONT></FONT></TD>
								<TD><asp:textbox id="g" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH'})" runat="server"
										CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True" AutoPostBack="True"></asp:textbox></TD>
								<TD>请假结束时间<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD><asp:textbox id="h" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH'})" runat="server"
										CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True" AutoPostBack="True"></asp:textbox></TD>
								<TD colSpan="2">共
									<asp:textbox id="i" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"
										Width="32px"></asp:textbox>天，工作日
									<asp:textbox id="j" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"
										Width="32px"></asp:textbox>天</TD>
							</TR>
							<TR>
								<td style="HEIGHT: 27px">工作代理人</td>
								<TD style="HEIGHT: 27px"><FONT face="宋体"><asp:textbox id="l" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD style="HEIGHT: 27px" colSpan="4"><FONT face="宋体"></FONT><FONT face="宋体">（部门或项目组负责人填写）&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="请填写数字" ControlToValidate="i"
											ValidationExpression="(\d+[.])*\d+"></asp:regularexpressionvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="请填写数字" ControlToValidate="j"
											ValidationExpression="(\d+[.])*\d+"></asp:regularexpressionvalidator></FONT></TD>
							</TR>
							<TR id="tishi" runat="server">
								<TD style="HEIGHT: 27px"><FONT face="宋体"></FONT></TD>
								<TD style="HEIGHT: 27px"></TD>
								<TD style="HEIGHT: 27px" colSpan="4">
									<TABLE id="Table3" style="WIDTH: 160px; HEIGHT: 53px" cellSpacing="1" cellPadding="1" width="160"
										border="1">
										<TR>
											<TD style="HEIGHT: 23px" align="center" colSpan="2"><FONT face="宋体"></FONT><FONT face="宋体">请假时间重复，是否提交？</FONT></TD>
										</TR>
										<TR>
											<TD align="center"><FONT face="宋体"><asp:button id="btn_y" runat="server" CssClass="input4" Text="确定"></asp:button></FONT></TD>
											<TD align="center"><asp:button id="btn_n" runat="server" CssClass="input4" Text="取消"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="6">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
										<TR>
											<TD align="center" width="50%" colSpan="4"><FONT face="宋体">(年休假/出差/事假/病假离岗超过<FONT style="COLOR: red" face="宋体">3</FONT>个工作日期间)工作委托/授权书</FONT></TD>
										</TR>
										<TR id="tr1" runat="server">
											<TD align="center" width="50%">该员工离岗期间预计主要工作内容</TD>
											<TD align="center" width="15%">被委托/被授权人</TD>
											<TD align="center" width="25%">备注</TD>
											<TD align="center" width="10%"></TD>
										</TR>
										<TR id="tr2" runat="server">
											<TD align="center" width="50%"><asp:textbox id="txt_gznr" runat="server" CssClass="textbox" Width="100%"></asp:textbox></TD>
											<TD width="15%"><asp:textbox id="txt_bwtr" runat="server" CssClass="textbox" Width="100%"></asp:textbox></TD>
											<TD align="center"><FONT face="宋体"><asp:textbox id="txt_bz" runat="server" CssClass="textbox" Width="100%"></asp:textbox></FONT></TD>
											<TD align="center" width="10%"><asp:button id="btn_add" runat="server" CssClass="input4" Text="添加"></asp:button></TD>
										</TR>
										<TR>
											<TD colSpan="4"><FONT face="宋体"><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="5"
														AllowPaging="True">
														<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
														<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="编号">
																<ItemTemplate>
																	<%#Container.ItemIndex+1%>
																</ItemTemplate>
																<HeaderStyle Width="5%"></HeaderStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="wtsp_id" HeaderText="序号"></asp:BoundColumn>
															<asp:BoundColumn DataField="wtsp_ggnr" HeaderText="该员工离岗期间预计主要工作内容">
																<HeaderStyle Width="45%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wtsp_bwtr" HeaderText="被委托/被授权人">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="wtsp_bz" HeaderText="备注"></asp:BoundColumn>
															<asp:ButtonColumn Text="删除" CommandName="Delete">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:ButtonColumn>
														</Columns>
														<PagerStyle VerticalAlign="Middle" HorizontalAlign="Right" BackColor="#F3F5FA" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<td>假期联系电话</td>
								<td><asp:textbox id="a1" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
								<TD>请假人签名</TD>
								<TD><asp:textbox id="m" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>日期</TD>
								<TD><asp:textbox id="n" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>考勤责任人意见</TD>
								<TD><asp:textbox id="o" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>日期</TD>
								<TD colSpan="3"><asp:textbox id="p" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">岗位经理意见</FONT></TD>
								<TD>
									<asp:textbox id="k1" runat="server" ReadOnly="True" BackColor="WhiteSmoke" CssClass="textbox"></asp:textbox></TD>
								<TD>日期</TD>
								<TD colspan="3">
									<asp:textbox id="l1" onfocus="WdatePicker({skin:'simple'})" runat="server" ReadOnly="True" BackColor="WhiteSmoke"
										CssClass="textbox"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>部门负责人意见</TD>
								<TD><asp:textbox id="q" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>日期</TD>
								<TD colSpan="3"><asp:textbox id="r" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6">综合管理部审核</TD>
							</TR>
							<tr>
								<td colSpan="4">若是休年假，本年度计划
									<asp:textbox id="s" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"
										Width="32px"></asp:textbox>天，已休
									<asp:textbox id="t" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"
										Width="32px"></asp:textbox>天，本次可休
									<asp:textbox id="u" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"
										Width="32px"></asp:textbox>天
									<asp:Button id="njModifyBtn" runat="server" Visible="False" Text="修改年假信息"></asp:Button></td>
								<td>其他&nbsp;</td>
								<td><asp:textbox id="b1" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
							</tr>
							<TR>
								<TD colSpan="3">综合管理部经办人</TD>
								<TD><asp:textbox id="c1" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>日期</TD>
								<TD><asp:textbox id="d1" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="3">公司主管领导审批（请假2天以上/管理干部1天以上）</TD>
								<TD><asp:textbox id="e1" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>日期</TD>
								<TD><asp:textbox id="f1" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="3">总经理审批（部门及项目负责人以上）</TD>
								<TD><asp:textbox id="g1" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>日期</TD>
								<TD><asp:textbox id="h1" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<tr>
								<td vAlign="middle" align="center" colSpan="6"><asp:button id="btnSave" runat="server" CssClass="input4" Text="处理"></asp:button><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
