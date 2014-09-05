<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_xjsp.aspx.cs" Inherits="Stoke.USL.Staff.style_xjsp" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>style_xjsp</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="95%" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TR>
					<TD style="FONT-VARIANT: normal; FONT-FAMILY: 幼圆; COLOR: blue; FONT-SIZE: larger; FONT-WEIGHT: bold"
						vAlign="middle" align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff">销假单</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD style="WIDTH: 169px"><FONT face="宋体">请假人姓名
										<asp:label id="b1" runat="server" Visible="False"></asp:label><asp:label id="c1" runat="server" Visible="False"></asp:label></FONT></TD>
								<TD style="WIDTH: 319px"><FONT face="宋体"><asp:textbox id="a" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 157px"><FONT face="宋体">任职部门</FONT></TD>
								<TD><asp:dropdownlist id="b" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="152px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 169px"><FONT face="宋体">职务(岗位)</FONT></TD>
								<TD style="WIDTH: 319px"><FONT face="宋体"><asp:dropdownlist id="c" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="151px"></asp:dropdownlist></FONT></TD>
								<TD style="WIDTH: 157px"><FONT face="宋体">请假类别</FONT></TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="d" runat="server" BackColor="WhiteSmoke" Enabled="False" Width="152px">
											<asp:ListItem Value="---请选择---">---请选择---</asp:ListItem>
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
							</TR>
							<TR>
								<TD colSpan="4"><FONT face="宋体">
										<P style="FONT-WEIGHT: bold">原请假时间</P>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 169px"><FONT face="宋体">起始时间</FONT></TD>
								<TD style="WIDTH: 319px"><asp:textbox id="e" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 157px"><FONT face="宋体">结束时间</FONT></TD>
								<TD><asp:textbox id="f" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 169px"><FONT face="宋体">请假事由</FONT></TD>
								<TD colspan="3"><FONT face="宋体">
										<asp:TextBox id="f1" runat="server" Width="632px" TextMode="MultiLine" Enabled="False"></asp:TextBox></FONT></TD>
							</TR>
							<TR>
								<TD colSpan="4"><FONT face="宋体">
										<P style="FONT-WEIGHT: bold">实际休假时间(共
											<asp:textbox id="g" runat="server" BackColor="WhiteSmoke" ReadOnly="True" Width="24px" BorderStyle="None"></asp:textbox>天)
											<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="数值型" ControlToValidate="g"
												ValidationExpression="^[0-9]*$"></asp:regularexpressionvalidator></P>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 169px"><FONT face="宋体">起始时间<FONT style="COLOR: red" face="宋体">*</FONT></FONT></TD>
								<TD style="WIDTH: 319px"><asp:textbox id="h" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH'})" runat="server"
										CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 157px"><FONT face="宋体">结束时间<FONT style="COLOR: red" face="宋体">*</FONT></FONT></TD>
								<TD><asp:textbox id="i" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH'})" runat="server"
										CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 169px"><FONT face="宋体"><FONT face="宋体">销假上班时间<FONT style="COLOR: red" face="宋体">*</FONT></FONT></FONT></TD>
								<TD style="WIDTH: 319px"><asp:textbox id="j" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH'})" runat="server"
										CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 157px">超出所请假期天数
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="数值型" ControlToValidate="l"
										ValidationExpression="^[0-9]*$"></asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="l" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 169px">超出所请假期原因</TD>
								<TD colSpan="3"><asp:textbox id="m" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"
										Width="304px"></asp:textbox><FONT face="宋体" color="red">注：若超假必须填写原因</FONT></TD>
							</TR>
							<TR>
								<TD>请假人签字</TD>
								<TD style="WIDTH: 319px"><asp:textbox id="n" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 157px">日期</TD>
								<TD><asp:textbox id="o" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 28px"><FONT face="宋体">考勤责任人</FONT></TD>
								<TD style="WIDTH: 319px; HEIGHT: 28px"><asp:textbox id="v" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox><FONT face="宋体" color="red">注：若超假提交部门负责人</FONT></TD>
								<TD style="WIDTH: 157px; HEIGHT: 28px"><FONT face="宋体">日期</FONT></TD>
								<TD style="HEIGHT: 28px"><asp:textbox id="w" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">部门负责人</FONT></TD>
								<TD style="WIDTH: 319px"><FONT face="宋体"><asp:textbox id="d1" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 157px"><FONT face="宋体">日期</FONT></TD>
								<TD><asp:textbox id="e1" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
										BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px" colSpan="4">
									<P><FONT face="宋体">综合部管理意见</FONT></P>
									<FONT face="宋体">
										<P>
											<TABLE id="Table3" style="WIDTH: 360px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="360"
												border="0">
												<TR>
													<TD></TD>
													<TD></TD>
													<TD style="WIDTH: 79px"></TD>
													<TD style="WIDTH: 53px">所休假期</TD>
													<TD style="WIDTH: 71px"><asp:dropdownlist id="p" runat="server" BackColor="WhiteSmoke" Enabled="False">
															<asp:ListItem Value="1">符合</asp:ListItem>
															<asp:ListItem Value="0">不符合</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD>相关规定</TD>
												</TR>
											</TABLE>
										</P>
										<P>&nbsp;</P>
										<P>
											<TABLE id="Table7" style="WIDTH: 702px; HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="702"
												border="0">
												<TR>
													<TD></TD>
													<TD style="WIDTH: 211px"></TD>
													<TD>综合管理部经办人</TD>
													<TD><asp:textbox id="q" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
													<TD><asp:textbox id="r" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
															BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
												</TR>
											</TABLE>
										</P>
										<P>
									</FONT></P></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px" colSpan="4">
									<P><FONT face="宋体">综合管理部备案</FONT></P>
									<P>
										<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="300" border="0">
											<TR>
												<TD><FONT face="宋体">1.假期超期处理意见</FONT></TD>
												<TD><asp:textbox id="s" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><FONT face="宋体">2.其他</FONT></TD>
												<TD><asp:textbox id="t" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</P>
									<P><FONT face="宋体"></FONT>&nbsp;</P>
									<P>
										<TABLE id="Table9" style="WIDTH: 702px; HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="702"
											border="0">
											<TR>
												<TD></TD>
												<TD style="WIDTH: 211px"></TD>
												<TD style="WIDTH: 112px">负责人</TD>
												<TD><asp:textbox id="u" runat="server" CssClass="textbox" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
												<TD><asp:textbox id="a1" onfocus="WdatePicker({skin:'simple'})" runat="server" CssClass="textbox"
														BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</P>
									<P><FONT face="宋体"></FONT>&nbsp;</P>
									<P><FONT face="宋体"></FONT>&nbsp;</P>
								</TD>
							</TR>
							<TR>
								<td vAlign="middle" align="center" colSpan="6"><asp:button id="btnSave" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
