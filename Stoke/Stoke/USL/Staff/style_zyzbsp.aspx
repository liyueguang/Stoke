<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_zyzbsp.aspx.cs" Inherits="Stoke.USL.Staff.style_zyzbsp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML xmlns:o>
	<HEAD>
		<title>style_zyzbsp</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0" style="border-collapse: collapse;">
				<TR style="display: none;">
					<TD align="center" colSpan="6"><FONT face="宋体"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">大连船舶重工海洋工程有限公司</SPAN></B></FONT></TD>
				</TR>
				<TR style="display: none;">
					<TD align="center" colSpan="6"><FONT face="宋体"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><B><SPAN lang="EN-US" style="FONT-SIZE: 9pt; FONT-FAMILY: 'Times New Roman'; mso-bidi-font-size: 12.0pt; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-fareast-font-family: 宋体">DALIAN 
											SHIPBUILDING OFFSHORE CO.,LTD</SPAN></B></SPAN></B></FONT></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><FONT face="宋体"><SPAN lang="EN-US" style="FONT-SIZE: 18pt; mso-bidi-font-size: 12.0pt; mso-fareast-font-family: 黑体"><o:p><FONT face="黑体">增员指标审批表</FONT></o:p></SPAN></FONT></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="6"><FONT face="宋体">填报日期
							<asp:TextBox id="a" runat="server" ReadOnly="True" BorderStyle="None" onfocus="WdatePicker({skin:'simple'})"
								Width="120px"></asp:TextBox></FONT></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="6">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD><FONT style="FONT-WEIGHT: bold; ; HEIGHT: 18px">申请部门</FONT></TD>
								<TD><asp:dropdownlist id="b" runat="server" Width="157px" BackColor="WhiteSmoke" Enabled="False"></asp:dropdownlist></TD>
								<TD><FONT style="FONT-WEIGHT: bold; ; HEIGHT: 18px">需求岗位</FONT></TD>
								<TD><asp:textbox id="c" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><FONT style="FONT-WEIGHT: bold; ; HEIGHT: 18px">需求人数</FONT></TD>
								<TD><asp:textbox id="d" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" style="FONT-WEIGHT: bold; ; HEIGHT: 18px">需求类型</TD>
								<TD><asp:checkbox id="e" runat="server" Text="补空缺" BackColor="WhiteSmoke" Enabled="False"></asp:checkbox></TD>
								<TD><FONT face="宋体"><asp:checkbox id="f" runat="server" Text="计划内新增" BackColor="WhiteSmoke" Enabled="False"></asp:checkbox></FONT></TD>
								<TD colSpan="2"><asp:checkbox id="g" runat="server" Width="88px" Text="计划外新增" BackColor="WhiteSmoke" Enabled="False"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" style="FONT-WEIGHT: bold; ; HEIGHT: 18px">
									拟聘岗位的预算：薪金和福利待遇
								</TD>
								<TD colSpan="2"><FONT face="宋体"><asp:textbox id="h" runat="server" Width="100%" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></FONT></TD>
								<TD><FONT face="宋体">希望到岗时间</FONT></TD>
								<TD></FONT><FONT face="宋体"><asp:textbox id="i" runat="server" ReadOnly="true" BackColor="WhiteSmoke" onfocus="WdatePicker({skin:'simple'})"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD colSpan="2" style="FONT-WEIGHT: bold; ; HEIGHT: 18px">拟聘岗位职责内容说明</TD>
								<TD colSpan="4"><asp:textbox id="v" runat="server" Width="535px" TextMode="MultiLine" ReadOnly="true" BackColor="WhiteSmoke"
										Height="50px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" rowSpan="5" style="FONT-WEIGHT: bold; ; HEIGHT: 18px">拟聘岗位任职资格要求</TD>
								<TD align="left">从事行业名称及年限</TD>
								<TD><asp:textbox id="j" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><FONT face="宋体">学历及专业要求</FONT></TD>
								<TD><asp:textbox id="k" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="1"><FONT face="宋体">教育形式</FONT></TD>
								<TD><FONT face="宋体"><asp:checkbox id="l" runat="server" Text="全日制" BackColor="WhiteSmoke" Enabled="False"></asp:checkbox></FONT></TD>
								<TD colSpan="2"><FONT face="宋体"><asp:checkbox id="m" runat="server" Text="成人教育" BackColor="WhiteSmoke" Enabled="False"></asp:checkbox></FONT></TD>
							</TR>
							<TR>
								<TD colSpan="1"><FONT face="宋体">职称/外语/计算机</FONT></TD>
								<TD><asp:textbox id="n" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><FONT face="宋体">年龄/性别/体质</FONT></TD>
								<TD><asp:textbox id="o" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="1"><FONT face="宋体">希望来源</FONT></TD>
								<TD colSpan="1"><FONT face="宋体"><asp:dropdownlist id="p" runat="server" Width="152px" BackColor="WhiteSmoke" Enabled="False">
											<asp:ListItem Value="--请选择--">--请选择--</asp:ListItem>
											<asp:ListItem Value="内部调配">内部调配</asp:ListItem>
											<asp:ListItem Value="引进社会人才">引进社会人才</asp:ListItem>
											<asp:ListItem Value="返聘退休人员">返聘退休人员</asp:ListItem>
											<asp:ListItem Value="应届大学毕业生">应届大学毕业生</asp:ListItem>
										</asp:dropdownlist></FONT></TD>
								<TD align="left">返聘期(返聘类型填写)</TD>
								<TD><asp:textbox id="q" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2">工作经验及业务技能条件(及其他要求)</TD>
								<TD colSpan="2"><asp:textbox id="w" runat="server" Width="270px" TextMode="MultiLine" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 26px" colSpan="2" align="center">填表人</TD>
								<TD style="HEIGHT: 26px" colSpan="1"><asp:textbox id="s" runat="server" ReadOnly="true" BackColor="WhiteSmoke" BorderStyle="None"
										Width="100px"></asp:textbox></TD>
								<TD style="HEIGHT: 26px" colSpan="1" align="center">岗位经理或业务主管</TD>
								<TD style="HEIGHT: 26px" colSpan="2"><asp:textbox id="t" runat="server" ReadOnly="true" BackColor="WhiteSmoke" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<td colspan="2" align="center">
									<P>用人部门负责人意见(属于计划外增补的，需详细说明理由)</P>
								</td>
								<TD align="center" colSpan="2">
									<asp:textbox id="x" runat="server" TextMode="MultiLine" Height="50px" ReadOnly="true" BackColor="WhiteSmoke"
										Width="260px"></asp:textbox>
								</TD>
								<td colspan="2">
									<asp:textbox id="u" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox>
								</td>
							</TR>
							<TR>
								<TD align="center" colSpan="2">人力资源管理部门意见</TD>
								<TD align="center" colSpan="2"><FONT face="宋体"><asp:textbox id="y" runat="server" TextMode="MultiLine" ReadOnly="true" BackColor="WhiteSmoke"
											Height="50px" Width="260px"></asp:textbox></FONT></TD>
								<td colspan="2">
									<asp:textbox id="a1" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox>
								</td>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><FONT face="宋体"><FONT face="宋体">总经理(或主管副总经理)批示</FONT></FONT></TD>
								<TD align="center" colSpan="2"><FONT face="宋体"><asp:textbox id="r" runat="server" TextMode="MultiLine" ReadOnly="true" BackColor="WhiteSmoke"
											Height="50px" Width="260px"></asp:textbox></FONT></TD>
								<td colspan="2">
									<asp:textbox id="b1" runat="server" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox>
								</td>
							</TR>
							<TR>
								<TD colSpan="2" align="center">备注<FONT face="宋体">(此表作为办理入职手续的依据)</FONT></TD>
								<TD colSpan="4">
									<P><asp:textbox id="z" runat="server" Width="422px" TextMode="MultiLine" Height="48px" ReadOnly="true"
											BackColor="WhiteSmoke"></asp:textbox><FONT face="宋体"></FONT></P>
								</TD>
							</TR>
							<TR>
								<td vAlign="middle" align="center" colSpan="6"><asp:button id="btnSave" runat="server" Text="提交" CssClass="input4"></asp:button><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="btnCancel" runat="server" Text="返回" CssClass="input4"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
