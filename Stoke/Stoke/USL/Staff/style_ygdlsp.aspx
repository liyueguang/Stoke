<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_ygdlsp.aspx.cs" Inherits="Stoke.USL.Staff.style_ygdlsp" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_ygdlsp</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>

        <link href="../css/css.css" rel="stylesheet" type="text/css" />
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" style="LEFT: 264px; POSITION: absolute; TOP: 160px;border-collapse: collapse;" cellSpacing="0"
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
					<TD vAlign="middle" align="center"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt; mso-bidi-font-size: 12.0pt">大连船舶重工海洋工程有限公司</SPAN></B></TD>
				</TR>
				<TR style="display: none;">
					<TD vAlign="middle" align="center"><B><SPAN lang="EN-US" style="FONT-SIZE: 9pt; FONT-FAMILY: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt; mso-bidi-font-size: 12.0pt; mso-fareast-font-family: 宋体">DALIAN 
								SHIPBUILDING OFFSHORE CO.,LTD</SPAN></B></TD>
				</TR>
				<TR>
					<TD align="center"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 黑体; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt; mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman'">人员调离手续登记表</SPAN>
					</TD>
				</TR>
				<tr>
					<td align="right"><FONT face="宋体"><asp:textbox id="a" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="100px" BorderWidth="0px"
								BorderStyle="None" ReadOnly="true"></asp:textbox></FONT></td>
				</tr>
				<tr>
					<td>
						<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD style="FONT-WEIGHT: bold; "><asp:button id="btn_ry" runat="server" CssClass="input4" Text="离职人员" Width="55px" Enabled="False"></asp:button></TD>
								<TD><asp:textbox id="b" runat="server" Width="130px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD style="FONT-WEIGHT: bold; "><FONT face="宋体">职工编号</FONT></TD>
								<TD style="FONT-WEIGHT: bold; "><FONT face="宋体">
										<asp:textbox id="e1" runat="server" Width="130px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></FONT></TD>
								<TD style="FONT-WEIGHT: bold; "><FONT face="宋体">入职时间</FONT></TD>
								<TD>
									<asp:textbox id="f1" runat="server" Width="130px" ReadOnly="true" BackColor="WhiteSmoke" onfocus="WdatePicker({skin:'simple'})"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; "><FONT face="宋体">手&nbsp;&nbsp; 机</FONT></TD>
								<TD><FONT face="宋体">
										<asp:textbox id="c" runat="server" Width="130px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></FONT></TD>
								<TD style="FONT-WEIGHT: bold; ">所在部门</TD>
								<TD style="FONT-WEIGHT: bold; "><FONT face="宋体">
										<asp:dropdownlist id="d" runat="server" Width="130px" BackColor="WhiteSmoke" Enabled="False"></asp:dropdownlist></FONT></TD>
								<TD style="FONT-WEIGHT: bold; ">调离时间</TD>
								<TD>
									<asp:textbox id="e" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="130px" ReadOnly="true"
										BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<td>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD style="FONT-WEIGHT: bold;  ">项目</TD>
								<TD style="FONT-WEIGHT: bold;  ">应交回公物和移交事项</TD>
								<TD style="FONT-WEIGHT: bold; ">应交回公物和移交事项情况</TD>
								<TD style="FONT-WEIGHT: bold;  ">经办人签字</TD>
								<TD style="FONT-WEIGHT: bold;  "><FONT face="宋体">负责人签字</FONT></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold;  " rowspan="5">所在部门</TD>
								<TD>
									<P>工作交接、移交手续</P>
								</TD>
								<TD rowspan="5" align="left"><asp:textbox id="f" runat="server" Width="300px" ReadOnly="True" BackColor="WhiteSmoke" TextMode="MultiLine"
										Height="100px"></asp:textbox></TD>
								<TD rowspan="5">
									<asp:textbox id="g" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD rowspan="5"><asp:textbox id="h" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>1.图纸、料(电脑资料)清点交回</TD>
							</TR>
							<TR>
								<TD align="left">2.未完工作交接(受)人</TD>
							</TR>
							<TR>
								<TD align="left">3.电脑、文件柜交接(受)人</TD>
							</TR>
							<TR>
								<TD align="left">4.其他需移交物项(借用等)</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ">安技环保部</TD>
								<TD align="left">劳保护具交回</TD>
								<TD align="left"><asp:textbox id="i" runat="server" Width="300px" ReadOnly="true" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
								<TD>
									<asp:textbox id="j" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><asp:textbox id="k" runat="server" Width="90px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold;   HEIGHT: 142px" rowSpan="4">综合管理部</TD>
								<TD>
									<P align="left">工卡、换衣柜、电话、</P>
									<P align="left">办公柜及桌椅等公物交回(总务)</P>
								</TD>
								<TD><asp:textbox id="l" runat="server" Width="300px" ReadOnly="true" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
								<TD>
									<asp:textbox id="m" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><asp:textbox id="n" runat="server" Width="90px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>电脑及其它IT物项交回(IT)/更改使用人</TD>
								<TD><asp:textbox id="o" runat="server" Width="300px" ReadOnly="true" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
								<TD>
									<asp:textbox id="p" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><asp:textbox id="q" runat="server" Width="90px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 41px">
									<P>相关费用清帐(人事)</P>
								</TD>
								<TD style="HEIGHT: 41px"><asp:textbox id="r" runat="server" Width="300px" ReadOnly="true" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="HEIGHT: 41px">
									<asp:textbox id="s" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD style="HEIGHT: 41px"><asp:textbox id="t" runat="server" Width="90px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>劳动(务)合同处理</TD>
								<TD><asp:textbox id="x" runat="server" Width="300px" ReadOnly="True" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
								<TD>
									<asp:textbox id="y" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><asp:textbox id="z" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ">物资采办部</TD>
								<TD>工具交回</TD>
								<TD><asp:textbox id="u" runat="server" Width="300px" ReadOnly="true" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
								<TD>
									<asp:textbox id="v" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><asp:textbox id="w" runat="server" Width="90px" ReadOnly="true" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; ">财务部</TD>
								<TD>员工借款、欠款、应收、应付账款等清帐</TD>
								<TD><asp:textbox id="a1" runat="server" Width="300px" ReadOnly="true" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
								<TD>
									<asp:textbox id="b1" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD><asp:textbox id="c1" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; " colSpan="2">备注</TD>
								<TD colSpan="4"><asp:textbox id="d1" runat="server" Width="480px" ReadOnly="true" BackColor="WhiteSmoke" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
                            <tr>
                                <td colspan="2" style="font-weight: bold">
                                    紧急程度</td>
                                <td colspan="4">
                                    <uc2:EmergencySelector ID="EmergencySelector1" runat="server" Enabled="false" />
                                </td>
                            </tr>
						</TABLE>
					</td>
				</TR>
				<TR>
					<td vAlign="middle" align="center" colSpan="6"><asp:button id="btnSave" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
