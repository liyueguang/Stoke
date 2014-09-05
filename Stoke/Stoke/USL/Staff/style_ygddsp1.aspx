<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_ygddsp1.aspx.cs" Inherits="Stoke.USL.Staff.style_ygddsp1" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_ygddsp</title>
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
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0" style="border-collapse: collapse;">
				<tr>
					<TD>
						<TABLE class="gbtext" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          height=24><asp:linkbutton id="zm" runat="server" CssClass="Newbutton" ForeColor="White">正面</asp:linkbutton></TD>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          height=24><asp:linkbutton id="bm" runat="server" CssClass="Newbutton" ForeColor="White">背面</asp:linkbutton></TD>
								<TD align="right">&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<TR style="display: none;">
					<TD vAlign="middle" align="center"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">大连船舶重工海洋工程有限公司</SPAN></B></TD>
				</TR>
				<TR style="display: none;">
					<TD vAlign="middle" align="center"><B><SPAN lang="EN-US" style="FONT-SIZE: 9pt; FONT-FAMILY: 'Times New Roman'; mso-bidi-font-size: 12.0pt; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-fareast-font-family: 宋体">DALIAN 
								SHIPBUILDING OFFSHORE CO.,LTD</SPAN></B></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center"><FONT face="宋体">
							<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><B><SPAN style="FONT-SIZE: 16pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-font-kerning: 0pt">员工调动审批表</SPAN></B></P>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left"><B><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">一、调动审批表</SPAN></B></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD><FONT face="宋体"><asp:button id="btn_ry" runat="server" Text="选择人员" Width="60px" CssClass="input4" Enabled="False"></asp:button></FONT></TD>
								<TD><asp:textbox id="a" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><FONT face="宋体">现所在部门</FONT></TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="b" runat="server" Width="120px" Enabled="False" BackColor="WhiteSmoke"></asp:dropdownlist></FONT></TD>
								<TD><FONT face="宋体">现岗位</FONT></TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="c" runat="server" Width="120px" Enabled="False" BackColor="WhiteSmoke"></asp:dropdownlist></FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 号</FONT></TD>
								<TD><asp:textbox id="d" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><FONT face="宋体">参加工作时间</FONT></TD>
								<TD><asp:textbox id="e" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
								<TD><FONT face="宋体">到现岗位任职时间</FONT></TD>
								<TD><FONT face="宋体"><asp:textbox id="f" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
											ReadOnly="true"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD colSpan="2"><FONT face="宋体">调动类型</FONT></TD>
								<TD><FONT face="宋体">调动详情</FONT></TD>
								<TD>从</TD>
								<TD>到</TD>
								<TD>备注</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="right" colSpan="2"><asp:checkbox id="g" runat="server" Text="部门调动" Enabled="False" BackColor="WhiteSmoke" AutoPostBack="True"></asp:checkbox></TD>
								<TD><FONT face="宋体">部门</FONT></TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="h" runat="server" Width="120px" Enabled="False" BackColor="WhiteSmoke"></asp:dropdownlist></FONT></TD>
								<TD><asp:dropdownlist id="i" runat="server" Width="120px" Enabled="False" BackColor="WhiteSmoke"></asp:dropdownlist></TD>
								<TD><asp:textbox id="j" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="right" colSpan="2">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="166" bgColor="#ffffff" border="1"
										runat="server">
										<TR>
											<TD>
												<uc1:slctmember id="SlctMember1" runat="server"></uc1:slctmember></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 0px" align="center">
												<asp:button id="btnBack" runat="server" CssClass="input4" Width="66px" Text="确定"></asp:button>
												<asp:button id="Button3" runat="server" CssClass="input4" Width="66px" Text="关闭"></asp:button></TD>
										</TR>
									</TABLE>
									<asp:checkbox id="k" runat="server" Text="部内调岗" Enabled="False" BackColor="WhiteSmoke" AutoPostBack="True"></asp:checkbox></TD>
								<TD><FONT face="宋体"><FONT face="宋体">岗位/职务</FONT></FONT></TD>
								<TD><asp:dropdownlist id="l" runat="server" Width="120px" Enabled="False" BackColor="WhiteSmoke"></asp:dropdownlist></TD>
								<TD><asp:dropdownlist id="m" runat="server" Width="120px" Enabled="False" BackColor="WhiteSmoke"></asp:dropdownlist></TD>
								<TD><asp:textbox id="n" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR id="tr_gz" runat="server">
								<TD vAlign="middle" align="right" colSpan="2"><asp:checkbox id="o" runat="server" Text="岗内调薪" Enabled="False" BackColor="WhiteSmoke" AutoPostBack="True"></asp:checkbox></TD>
								<TD><FONT face="宋体">工资</FONT></TD>
								<TD><asp:textbox id="p" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="q" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="r" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="right" colSpan="2"><asp:checkbox id="s" runat="server" Text="其它" Enabled="False" BackColor="WhiteSmoke"></asp:checkbox><FONT face="宋体">&nbsp;</FONT>&nbsp;<FONT face="宋体">&nbsp;</FONT>&nbsp;<FONT face="宋体">&nbsp;
									</FONT>
								</TD>
								<TD><FONT face="宋体">申请调动起始时间</FONT></TD>
								<TD><asp:textbox id="t" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
								<TD colSpan="2"><asp:textbox id="u" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2"><FONT face="宋体">请调原因</FONT></TD>
								<TD colSpan="4"><asp:textbox id="a1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD width="50%" colSpan="3">现所在部门意见</TD>
								<TD width="50%" colSpan="3">现所在部门公司领导意见</TD>
							</TR>
							<TR>
								<TD colSpan="3"><asp:textbox id="b1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
								<TD colSpan="3"><asp:textbox id="c1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>签名</TD>
								<TD><asp:textbox id="d1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="e1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
								<TD>签名</TD>
								<TD><asp:textbox id="f1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="g1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="50%" colSpan="3">拟调往部门意见</TD>
								<TD width="50%" colSpan="3">拟调往部门公司领导意见</TD>
							</TR>
							<TR>
								<TD colSpan="3"><asp:textbox id="h1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
								<TD colSpan="3"><asp:textbox id="i1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>签名</TD>
								<TD><asp:textbox id="j1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="k1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
								<TD>签名</TD>
								<TD><asp:textbox id="l1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="m1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="50%" colSpan="3">现所在部门主管副总意见</TD>
								<TD width="50%" colSpan="3">拟调往部门主管副总意见</TD>
							</TR>
							<TR>
								<TD colSpan="3"><asp:textbox id="t1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
								<TD colSpan="3"><asp:textbox id="u1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>签名</TD>
								<TD><asp:textbox id="w1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="y1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
								<TD>签名</TD>
								<TD><asp:textbox id="z1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="a2" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="50%" colSpan="3">综合管理部意见</TD>
								<TD width="50%" colSpan="3">公司人事主管领导意见</TD>
							</TR>
							<TR>
								<TD colSpan="3"><asp:textbox id="n1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
								<TD colSpan="3"><asp:textbox id="o1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="true" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>签名</TD>
								<TD><asp:textbox id="p1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="q1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
								<TD>签名</TD>
								<TD><asp:textbox id="r1" runat="server" Width="120px" BackColor="WhiteSmoke" ReadOnly="true"></asp:textbox></TD>
								<TD><asp:textbox id="s1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="120px" BackColor="WhiteSmoke"
										ReadOnly="true"></asp:textbox></TD>
							</TR>
                            <tr>
                                <td colspan="2">
                                    紧急程度</td>
                                <td colspan="4">
                                    <uc2:EmergencySelector ID="EmergencySelector1" runat="server" Enabled="false" />
                                </td>
                            </tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>注：属于跨部门调动的，需分别由调出部门和调入部门的主管领导签署意见。</td>
				</tr>
				<TR>
					<td vAlign="middle" align="center" colSpan="6"><asp:button id="btnSave" runat="server" Text="提交" CssClass="input4"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="btnCancel" runat="server" Text="返回" CssClass="input4"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
