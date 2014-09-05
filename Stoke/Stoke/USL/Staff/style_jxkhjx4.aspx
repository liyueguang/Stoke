<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_jxkhjx4.aspx.cs" Inherits="Stoke.USL.Staff.style_jxkhjx4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML xmlns:o>
	<HEAD>
		<title>style_jxkhjx4</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="815" align="center" border="0">
				<tr>
					<TD>
						<TABLE id="Table8" style="WIDTH: 296px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD style="WIDTH: 91px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          ><asp:linkbutton id="zp" runat="server" ForeColor="White" CssClass="Newbutton">自我评价意见表</asp:linkbutton></TD>
								<TD style="WIDTH: 60px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          ><asp:linkbutton id="zq" runat="server" ForeColor="White" CssClass="Newbutton">工作小结</asp:linkbutton></TD>
								<TD style="WIDTH: 69px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>.gif' 
          ><asp:linkbutton id="zdp" runat="server" ForeColor="White" CssClass="Newbutton">绩效评估表</asp:linkbutton></TD>
								<TD style="WIDTH: 65px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>.gif' 
          ><asp:linkbutton id="zs" runat="server" ForeColor="White" CssClass="Newbutton">转正审批表</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<TR style="display: none;">
					<TD style="HEIGHT: 23px; display:none;" vAlign="middle" align="center"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman'"><FONT size="5">大连船舶重工海洋工程有限公司</FONT></SPAN></SPAN></B></SPAN></B></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 13px" vAlign="middle" align="center"><FONT face="宋体"><SPAN style="mso-bidi-font-weight: bold">
								<P class="MsoNormal" style="MARGIN-BOTTOM: 6pt; TEXT-ALIGN: center; mso-para-margin-bottom: .5gd"
									align="center"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt"><STRONG><FONT size="3">（见习、试用期）员工绩效考核转正审批表<SPAN lang="EN-US">
													<o:p></o:p></SPAN></FONT></STRONG></SPAN></P>
							</SPAN></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px" vAlign="middle" align="center"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">（评估意见汇总表)</SPAN>
						</SPAN>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 6px" vAlign="middle" align="left"><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</STRONG><STRONG><FONT size="3">员工基本信息</FONT></STRONG></SPAN></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="815" border="1">
							<TR>
								<TD style="WIDTH: 26px; HEIGHT: 26px"><FONT face="宋体">工号</FONT></TD>
								<TD style="WIDTH: 139px; HEIGHT: 26px"><asp:textbox id="d1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="HEIGHT: 26px"><FONT face="宋体">姓名</FONT></TD>
								<TD style="WIDTH: 136px; HEIGHT: 26px"><asp:textbox id="e1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 53px; HEIGHT: 26px"><FONT face="宋体">学历</FONT></TD>
								<TD style="WIDTH: 137px; HEIGHT: 26px"><asp:textbox id="f1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 50px; HEIGHT: 26px"><FONT face="宋体">报到日期</FONT></TD>
								<TD style="HEIGHT: 26px"><asp:textbox id="g1" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
										Width="138px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 26px; HEIGHT: 33px"><FONT face="宋体">部门</FONT></TD>
								<TD style="WIDTH: 139px; HEIGHT: 33px"><asp:dropdownlist id="h1" runat="server" BackColor="WhiteSmoke" Width="138px" Enabled="False"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 33px"><FONT face="宋体">岗位</FONT></TD>
								<TD style="WIDTH: 136px; HEIGHT: 33px"><FONT face="宋体"><asp:dropdownlist id="i1" runat="server" BackColor="WhiteSmoke" Width="138px" Enabled="False"></asp:dropdownlist></FONT></TD>
								<TD style="WIDTH: 53px; HEIGHT: 33px"><FONT face="宋体"><FONT face="宋体">毕业院校</FONT></FONT></TD>
								<TD style="WIDTH: 137px; HEIGHT: 33px"><FONT face="宋体"><asp:textbox id="j1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 50px; HEIGHT: 33px"><FONT face="宋体">员工来源</FONT></TD>
								<TD style="HEIGHT: 33px"><FONT face="宋体"><asp:radiobuttonlist id="k1" runat="server" BackColor="WhiteSmoke" Width="161px" RepeatDirection="Horizontal"
											Height="24px">
											<asp:ListItem Value="社会招聘" Selected="True">社会招聘</asp:ListItem>
											<asp:ListItem Value="毕业生分配">毕业生分配</asp:ListItem>
										</asp:radiobuttonlist></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td style="HEIGHT: 14px" align="center">
						<P><FONT face="宋体" size="2"><STRONG><FONT size="3"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">转正评价意见汇总栏</SPAN></B></FONT></STRONG></FONT></P>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="815" border="1">
							<TR>
								<TD style="WIDTH: 116px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">评价项目</SPAN></B></TD>
								<TD style="WIDTH: 161px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">评价人</SPAN></B></TD>
								<TD style="WIDTH: 148px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">评价结果意见</SPAN></B></TD>
								<TD style="WIDTH: 111px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">所占比例</SPAN></B></TD>
								<TD><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">得分</SPAN></B></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">自我评价意见汇总</SPAN></TD>
								<TD style="WIDTH: 161px"><asp:textbox id="l1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 148px"><asp:textbox id="m1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 111px">10%</TD>
								<TD><asp:textbox id="n1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">导师评价意见汇总</SPAN></TD>
								<TD style="WIDTH: 161px"><asp:textbox id="o1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 148px"><asp:textbox id="p1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 111px">50%</TD>
								<TD><asp:textbox id="q1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">部长评价意见汇总</SPAN></TD>
								<TD style="WIDTH: 161px"><asp:textbox id="r1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 148px"><asp:textbox id="s1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 111px">40%</TD>
								<TD><asp:textbox id="t1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 116px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">合计得分</SPAN></B></TD>
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 148px"></TD>
								<TD style="WIDTH: 111px">100%</TD>
								<TD><asp:textbox id="u1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD align="center"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">转正评估结论</SPAN></B></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="815" border="1">
							<TR>
								<TD style="WIDTH: 153px; HEIGHT: 77px" rowspan="3"><STRONG><FONT size="2">部、室意见</FONT></STRONG></TD>
								<TD style="WIDTH: 70px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">等级</SPAN></B></TD>
								<TD style="WIDTH: 233px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">评价得分</SPAN></B></TD>
								<TD><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">评价结果</SPAN></B></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 70px"><asp:radiobuttonlist id="i2" runat="server" Height="80px" Enabled="False" AutoPostBack="True">
										<asp:ListItem Value="A">A</asp:ListItem>
										<asp:ListItem Value="B">B</asp:ListItem>
										<asp:ListItem Value="C">C</asp:ListItem>
									</asp:radiobuttonlist></TD>
								<TD style="WIDTH: 233px">
									<TABLE id="Table12" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD height="22">80～100分</TD>
										</TR>
										<TR>
											<TD height="22">60～80分</TD>
										</TR>
										<TR>
											<TD height="22">60分以下</TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table13" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD colSpan="2">予以转正</TD>
										</TR>
										<TR>
											<TD>延期</TD>
											<td><asp:radiobuttonlist id="j2" runat="server" Width="216px" RepeatDirection="Horizontal" Enabled="False">
													<asp:ListItem Value="1个月；">1个月；</asp:ListItem>
													<asp:ListItem Value="2个月；">2个月；</asp:ListItem>
													<asp:ListItem Value="3个月；">3个月；</asp:ListItem>
												</asp:radiobuttonlist></td>
										</TR>
										<TR>
											<TD colSpan="2">终止试用，解除合同。</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colspan="3">
									<TABLE id="Table9" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD style="WIDTH: 90px; HEIGHT: 21px">转正日期</TD>
											<TD style="HEIGHT: 21px" colSpan="3"><asp:textbox id="v1" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
													Width="138px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 90px; HEIGHT: 21px">确定岗位</TD>
											<TD style="HEIGHT: 21px" colSpan="3"><asp:dropdownlist id="w1" runat="server" BackColor="WhiteSmoke" Width="138px" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 90px">签&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 字</TD>
											<TD style="WIDTH: 176px"><asp:textbox id="x1" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 61px">日期</TD>
											<TD><asp:textbox id="y1" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
													Width="138px" ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="815" border="1">
							<TR>
								<TD colspan="180px"><STRONG>综合管理部HR意见</STRONG></TD>
								<TD>
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD style="WIDTH: 90px; HEIGHT: 28px">聘用日期</TD>
											<TD style="HEIGHT: 28px" colSpan="3"><asp:textbox id="z1" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
													Width="138px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 90px">转正日期</TD>
											<TD colSpan="3"><asp:textbox id="a2" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
													Width="138px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 90px">转正定级</TD>
											<TD style="WIDTH: 176px"><asp:textbox id="b2" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox>级</TD>
											<TD style="WIDTH: 61px">岗位</TD>
											<TD><asp:dropdownlist id="c2" runat="server" BackColor="WhiteSmoke" Width="138px" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 90px">其&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 他</TD>
											<TD style="WIDTH: 176px" colSpan="3"><asp:textbox id="d2" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 90px">签&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 字</TD>
											<TD style="WIDTH: 176px"><asp:textbox id="e2" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 61px">日期</TD>
											<TD><asp:textbox id="f2" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
													Width="138px" ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><STRONG>主管领导审批</STRONG></TD>
								<TD>
									<TABLE id="Table14" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD style="WIDTH: 90px">签&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 字</TD>
											<TD style="WIDTH: 176px"><asp:textbox id="g2" runat="server" BackColor="WhiteSmoke" Width="138px" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 61px">日期</TD>
											<TD><asp:textbox id="h2" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
													Width="138px" ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnSave" runat="server" CssClass="input4" Text="提交" Width="65px"></asp:button>&nbsp;
							<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回" Width="72px"></asp:button></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
