<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_rzsx.aspx.cs" Inherits="Stoke.USL.Staff.style_rzsx" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>
<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML xmlns:o>
	<HEAD>
		<title>style_rzsx</title>
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
			<TABLE id="Table6" style="LEFT: 264px; POSITION: absolute; TOP: 160px; border-collapse: collapse;" cellSpacing="0"
				cellPadding="0" width="166" bgColor="#ffffff" border="1" runat="server">
				<tr>
					<td><uc1:slctmember id="SlctMember1" runat="server"></uc1:slctmember></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 0px" align="center"><asp:button id="btnBack" runat="server" Width="66px" CssClass="input4" Text="确定"></asp:button><asp:button id="Button3" runat="server" Width="66px" CssClass="input4" Text="关闭"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="810" align="center" border="0" style="border-collapse: collapse;">
				<TR style="display: none;">
					<TD style="HEIGHT: 26px" align="center"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">大连船舶重工海洋工程有限公司</SPAN></B></SPAN></B></TD>
				</TR>
				<TR style="display: none;">
					<TD style="HEIGHT: 25px" align="center"><FONT face="宋体">
							<P class="MsoNormal" style="LAYOUT-GRID-MODE: char; TEXT-ALIGN: center" align="center"><B><SPAN lang="EN-US" style="FONT-SIZE: 9pt; mso-bidi-font-size: 12.0pt">DALIAN 
										SHIPBUILDING OFFSHORE CO.,LTD</SPAN></B><SPAN lang="EN-US" style="FONT-SIZE: 9pt; mso-bidi-font-size: 12.0pt; mso-fareast-font-family: 黑体">
									<o:p></o:p></SPAN></P>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" align="center"><FONT face="宋体">
							<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><B><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman'">人员入职手续登记表</SPAN></B>
							</P>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD align="right"><FONT face="宋体">
							<asp:textbox id="a" runat="server" Width="100px" BackColor="WhiteSmoke" ReadOnly="true" onfocus="WdatePicker({skin:'simple'})"
								BorderStyle="None"></asp:textbox></FONT></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
								<TR>
									<TD style="FONT-WEIGHT: bold; " width="15%">
										<asp:button id="btn_ry" runat="server" Width="55px" CssClass="input4" Text="入职人员"></asp:button></TD>
									<TD width="25%"><asp:textbox id="b" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Enabled="False"></asp:textbox></TD>
									<TD style="FONT-WEIGHT: bold; " align="center" width="12%">部&nbsp;&nbsp;&nbsp;门</TD>
									<TD align="center" width="25%"><asp:dropdownlist id="c" runat="server" BackColor="WhiteSmoke" Width="157px" Enabled="False"></asp:dropdownlist></TD>
									<TD style="FONT-WEIGHT: bold; " align="center">入职时间</TD>
									<TD><asp:textbox id="d" runat="server" ReadOnly="true" BackColor="WhiteSmoke" onfocus="WdatePicker({skin:'simple'})"
											CssClass="textbox" Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; ">职工编号</TD>
									<TD><asp:textbox id="e" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Enabled="False"></asp:textbox></TD>
									<TD style="FONT-WEIGHT: bold; " align="center" width="10%">工作岗位</TD>
									<TD align="center" width="25%"><asp:dropdownlist id="f" runat="server" BackColor="WhiteSmoke" Width="157px" Enabled="False"></asp:dropdownlist></TD>
									<TD style="FONT-WEIGHT: bold; " align="center" width="20%">聘用形式</TD>
									<TD><asp:dropdownlist id="g" runat="server" BackColor="WhiteSmoke" Width="120px" Enabled="False">
											<asp:ListItem Value="0">---请选择---</asp:ListItem>
											<asp:ListItem Value="M">管理人员</asp:ListItem>
											<asp:ListItem Value="PM">聘管人员</asp:ListItem>
											<asp:ListItem Value="PW">聘工人员</asp:ListItem>
											<asp:ListItem Value="FP">返聘人员</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; " colSpan="1">经办部门</SPAN></B></TD>
									<TD style="FONT-WEIGHT: bold; " align="center" colSpan="2">领取公物或处理事项</TD>
									<TD style="FONT-WEIGHT: bold; ; HEIGHT: 18px" align="center" colSpan="2">具体明细</SPAN></B></TD>
									<TD style="FONT-WEIGHT: bold; ; HEIGHT: 18px" align="center" colSpan="1">负责人签字</SPAN></B></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; " align="left" colSpan="1" rowSpan="2">安技环保部</TD>
									<TD align="center" colSpan="2">安全教育卡</SPAN></TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="v" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="h" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">劳保护具</SPAN></TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="w" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="i" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; " align="left" colSpan="1" rowSpan="4">综合管理部</SPAN></B></TD>
									<TD style="HEIGHT: 18px" align="center" colSpan="2">
										<P>1.人事</P>
										<P>1.1 分配职工编号、职工入职1寸取照</P>
										<P>1.2 体检情况、入职培训记录</P>
									</TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="x" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="j" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<P>2.总务</P>
										<P>2.1 海工卡</SPAN><SPAN lang="EN-US" style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-fareast-font-family: 宋体">(</SPAN>
											餐卡</SPAN><SPAN lang="EN-US" style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-fareast-font-family: 宋体">)</SPAN>
											、私家车登记</P>
										<P>2.2 换衣箱、办公桌椅等及相关</P>
									</TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="y" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="k" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<P>3.安保</P>
										<P>门禁权限设置</P>
									</TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="z" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></SPAN></SPAN></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="l" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR id="tr_del" runat="server">
									<TD align="center" colSpan="2" id="TD1" runat="server">
										<P>1.人事</P>
										换衣箱、办公桌椅等</TD>
									<TD style="HEIGHT: 46px" colSpan="2"><asp:textbox id="v1" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 46px" colSpan="1"><asp:textbox id="m" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<P>4.IT</P>
										<P>办公电脑及其它IT软硬件</P>
										</SPAN></TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="w1" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="n" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; " align="left" colSpan="1">财务部</SPAN></B></SPAN></B></TD>
									<TD align="center" colSpan="2">工资存折帐户登记</SPAN></SPAN></TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="y1" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="p" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; " colSpan="1">其它部门</SPAN></B></TD>
									<TD colSpan="2" align="center"><asp:textbox id="q" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="2"><asp:textbox id="z1" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="350px" TextMode="MultiLine"
											CssClass="textbox" Height="50px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px" colSpan="1"><asp:textbox id="r" runat="server" ReadOnly="true" BackColor="WhiteSmoke" CssClass="textbox"
											Width="120px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; " colSpan="1">备注
									</TD>
									<TD style="HEIGHT: 18px" colSpan="5"><asp:textbox id="s" runat="server" ReadOnly="true" BackColor="WhiteSmoke" Width="700px" TextMode="MultiLine"
											CssClass="textbox"></asp:textbox></TD>
								</TR>
								<tr>
								    <td>紧急程度</td>
								    <td colspan="5"><uc2:EmergencySelector runat="server" ID="EmergencySelector1" Enabled="false" /></td>
								</tr>
								<TR>
									<td vAlign="middle" align="center" colSpan="6"><asp:button id="btnSave" runat="server" Text="提交" CssClass="input4"></asp:button><FONT face="宋体">&nbsp;</FONT>
										<asp:button id="btnCancel" runat="server" Text="返回" CssClass="input4"></asp:button></td>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
