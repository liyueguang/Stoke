<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_qzsp2.aspx.cs" Inherits="Stoke.USL.Staff.style_qzsp2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_qzsp2</title>
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
				<tr>
					<TD>
						<TABLE class="gbtext" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
				<TR>
					<TD vAlign="middle" align="center"><FONT face="宋体">
							<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><B><SPAN style="FONT-SIZE: 16pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-font-kerning: 0pt">求职录用审批表(背面)</SPAN></B></P>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD>
						<P class="MsoNormal" style="MARGIN: 6pt 0cm; LAYOUT-GRID-MODE: char; mso-para-margin-top: .5gd; mso-para-margin-right: 0cm; mso-para-margin-bottom: .5gd; mso-para-margin-left: 0cm"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体">二、面试考核测评表</SPAN></B></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD><B><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">测评部门</SPAN></B></TD>
								<TD colSpan="3"><B><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">人力资源管理部门</SPAN></B></TD>
								<TD colSpan="4"><B><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">用人部门
											<asp:TextBox id="y2" runat="server" Visible="False"></asp:TextBox></SPAN></B></TD>
							</TR>
							<TR>
								<TD><B><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 新宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-size: 12.0pt">面试内容</SPAN></B></TD>
								<TD colSpan="3">外观、谈吐、性格倾向、工作经验描述、求职动机、职业规划</TD>
								<TD colSpan="4">任职资格：（工作年限、专业对口程度、主要业绩描述、学历及职称）</TD>
							</TR>
							<TR>
								<TD><B><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 新宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-size: 12.0pt">评价</SPAN></B></TD>
								<TD colSpan="3"><asp:textbox id="w" runat="server" Width="100%" TextMode="MultiLine" Height="64px" ReadOnly="True"
										BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD colSpan="4"><asp:textbox id="x" runat="server" Width="100%" TextMode="MultiLine" Height="64px" ReadOnly="True"
										BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>证件审核</TD>
								<TD><asp:textbox id="f2" runat="server" Width="130px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD>基本知识测试成绩</TD>
								<TD><asp:textbox id="g2" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD>专业英语测试成绩</TD>
								<TD><asp:textbox id="h2" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD>业务技能测试成绩</TD>
								<TD><asp:textbox id="i2" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>意向岗位</TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="j2" runat="server" Width="130px" BackColor="WhiteSmoke" Enabled="False"></asp:dropdownlist></FONT></TD>
								<TD>人力资源评判人</TD>
								<TD><FONT face="宋体"><asp:textbox id="k2" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></FONT></TD>
								<TD>用人部门评判人</TD>
								<TD colSpan="3"><FONT face="宋体"><asp:textbox id="l2" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">三、招聘、录用审批表</SPAN></B>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD>拟聘岗位</TD>
								<TD><asp:dropdownlist id="m2" runat="server" Width="120px" BackColor="WhiteSmoke" Enabled="False">
										<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>上岗时间</TD>
								<TD><asp:textbox id="n2" runat="server" Width="90px" onfocus="WdatePicker({skin:'simple'})" ReadOnly="True"
										BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD>合同期限</TD>
								<TD><asp:textbox id="o2" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD>试用期</TD>
								<TD><asp:textbox id="p2" runat="server" Width="90px" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>用人部门负责人</TD>
								<TD colSpan="3"><asp:textbox id="q2" runat="server" Width="100%" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD>综合管理部HR负责人</TD>
								<TD colSpan="3"><asp:textbox id="r2" runat="server" Width="100%" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>人力资源主管领导审核</TD>
								<TD colSpan="3"><asp:textbox id="s2" runat="server" Width="100%" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD>总经理审批</TD>
								<TD colSpan="3"><asp:textbox id="t2" runat="server" Width="100%" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></TD>
							</TR>
							<tr>
								<td colspan="8"><FONT face="宋体">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
											<TR>
												<TD rowSpan="3">备注</TD>
												<TD colSpan="2">薪酬待遇确定</TD>
												<td colSpan="5"><asp:textbox id="u2" runat="server" Width="100%" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></td>
											</TR>
											<TR>
												<TD colSpan="2">其他</TD>
												<td colSpan="5"><asp:textbox id="v2" runat="server" Width="100%" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></td>
											</TR>
											<TR>
												<TD colSpan="2"><FONT face="宋体"></FONT></TD>
												<td align="center" colSpan="5">负责人
													<asp:textbox id="w2" runat="server" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox>&nbsp;日期
													<asp:TextBox id="x2" runat="server" onfocus="WdatePicker({skin:'simple'})" ReadOnly="True" BackColor="WhiteSmoke"></asp:TextBox></td>
											</TR>
										</TABLE>
									</FONT>
								</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<td vAlign="middle" align="center"><asp:button id="btnSave" runat="server" CssClass="input4" Text="处理" Width="63px"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回" Width="66px"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
