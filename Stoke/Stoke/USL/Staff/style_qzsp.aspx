<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_qzsp.aspx.cs" Inherits="Stoke.USL.Staff.style_qzsp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_qzsp</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" style="border-collapse: collapse;">
				<tr>
					<TD style="height: 43px">
						<TABLE class="gbtext" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' style="height: 24px"><asp:linkbutton id="zm" runat="server" ForeColor="White" CssClass="Newbutton">正面</asp:linkbutton></TD>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' style="height: 24px"><asp:linkbutton id="bm" runat="server" ForeColor="White" CssClass="Newbutton">背面</asp:linkbutton></TD>
								<TD align="right" style="height: 24px">&nbsp;&nbsp;&nbsp;</TD>
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
							<P class="MsoNormal" style="TEXT-ALIGN: center" align="center"><B><SPAN style="FONT-SIZE: 16pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-font-kerning: 0pt">求职录用审批表</SPAN></B></P>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left"><B><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">一、求职简历
								<asp:dropdownlist id="b" runat="server" Width="90px" BackColor="WhiteSmoke" Enabled="False" Visible="False"></asp:dropdownlist>&nbsp;
								<asp:TextBox id="txt_doc" runat="server" Visible="False" Width="52px"></asp:TextBox></SPAN></B></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD align="left" colSpan="9"><B><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 新宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">申请职位<SPAN lang="EN-US">
												(1)
												<asp:dropdownlist id="a" runat="server" Width="184px" BackColor="WhiteSmoke" Enabled="False"></asp:dropdownlist>&nbsp;</SPAN>可到岗日期
											<asp:textbox id="c" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
												ReadOnly="True"></asp:textbox>期望待遇
											<asp:textbox id="d" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox>&nbsp;<INPUT id="upFile" style="WIDTH: 150px; HEIGHT: 22px" type="file" name="upFile" runat="server">
											<asp:Button id="uploadBtn" runat="server" Text="上传照片"></asp:Button></SPAN></B></TD>
							</TR>
							<TR>
								<TD width="8%">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名</TD>
								<TD><asp:textbox id="e" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 别</TD>
								<TD><asp:dropdownlist id="f" runat="server" Width="100%" BackColor="WhiteSmoke" Enabled="False">
										<asp:ListItem Value="男">男</asp:ListItem>
										<asp:ListItem Value="女">女</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="WIDTH: 49px">民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;族</TD>
								<TD><asp:textbox id="g" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 134px">出生日期</TD>
								<TD><asp:textbox id="h" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></TD>
								<TD vAlign="middle" align="center" width="13%" rowSpan="5">&nbsp;
									<asp:image id="Image1" runat="server"></asp:image></TD>
							</TR>
							<TR>
								<TD width="8%">籍&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 贯</TD>
								<TD><asp:textbox id="i" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>政治面貌</TD>
								<TD><asp:textbox id="j" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 49px">技术职称</TD>
								<TD><asp:textbox id="k" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 134px">外语水平/特长</TD>
								<TD><asp:textbox id="l" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>最高学历</TD>
								<TD><asp:dropdownlist id="m" runat="server" Width="90px" BackColor="WhiteSmoke" Enabled="False">
										<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
										<asp:ListItem Value="博士">博士</asp:ListItem>
										<asp:ListItem Value="研究生（硕士）">研究生（硕士）</asp:ListItem>
										<asp:ListItem Value="研究生（双学位）">研究生（双学位）</asp:ListItem>
										<asp:ListItem Value="研究生（学历）">研究生（学历）</asp:ListItem>
										<asp:ListItem Value="本科">本科</asp:ListItem>
										<asp:ListItem Value="大专">大专</asp:ListItem>
										<asp:ListItem Value="中专">中专</asp:ListItem>
										<asp:ListItem Value="技校（职高）">技校（职高）</asp:ListItem>
										<asp:ListItem Value="高中">高中</asp:ListItem>
										<asp:ListItem Value="初中">初中</asp:ListItem>
										<asp:ListItem Value="小学">小学</asp:ListItem>
										<asp:ListItem Value="其它">其它</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>毕业院校</TD>
								<TD style="WIDTH: 130px"><asp:textbox id="n" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<td>所学专业</td>
								<TD><asp:textbox id="o" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 134px">毕业时间</TD>
								<TD><asp:textbox id="p" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2">劳动保险起及最后缴费时间</TD>
								<TD><asp:textbox id="q" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="80px" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></TD>
								<td><asp:textbox id="r" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="100%" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></td>
								<TD style="WIDTH: 174px" colSpan="2">住房公积金起及最后缴费时间</TD>
								<TD><asp:textbox id="s" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="100%" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></TD>
								<TD><asp:textbox id="t" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2">参加工作时间(人事档案记载)</TD>
								<TD><asp:textbox id="u" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="80px" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></TD>
								<TD>人事档案所在单位</TD>
								<TD style="WIDTH: 174px" colSpan="2"><asp:textbox id="a1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox>
								<TD style="WIDTH: 134px"><FONT face="宋体">目前工作状态</FONT></TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="b1" runat="server" Width="90px" BackColor="WhiteSmoke" Enabled="False">
											<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
											<asp:ListItem Value="在职">在职</asp:ListItem>
											<asp:ListItem Value="失业">失业</asp:ListItem>
											<asp:ListItem Value="在校">在校</asp:ListItem>
											<asp:ListItem Value="待业">待业</asp:ListItem>
											<asp:ListItem Value="退休">退休</asp:ListItem>
										</asp:dropdownlist></FONT></TD>
							</TR>
							<TR>
								<TD>健康状况</TD>
								<TD><asp:textbox id="c1" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD>婚姻状况</TD>
								<TD><asp:dropdownlist id="d1" runat="server" Width="100%" BackColor="WhiteSmoke" Enabled="False">
										<asp:ListItem Value="已婚">已婚</asp:ListItem>
										<asp:ListItem Value="未婚">未婚</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="WIDTH: 49px">私家车及驾照</TD>
								<TD style="WIDTH: 130px"><asp:textbox id="e1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD colSpan="3">联系电话 宅<asp:textbox id="f1" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;&nbsp;移动<asp:textbox id="g1" runat="server" Width="90px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2">身份证号码</TD>
								<TD colSpan="2"><asp:textbox id="h1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 49px" rowSpan="2"><FONT face="宋体">在连详细住址</FONT></TD>
								<TD colSpan="4" rowSpan="2"><FONT face="宋体"><asp:textbox id="v" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True" TextMode="MultiLine"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD colSpan="2">户口所在地</TD>
								<TD colSpan="2"><asp:textbox id="i1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="1" style="border-collapse: collapse;">
							<TR>
								<TD align="center" width="3%" rowSpan="3">在校教育及进修情况</TD>
								<TD align="center" width="25%">起止年月</TD>
								<TD align="center" width="25%">学校或机构(中学起)</TD>
								<TD align="center">学习专业或培训内容</TD>
								<TD align="center">学习形式</TD>
								<TD align="center">获得证书</TD>
								<td align="center"></td>
							</TR>
							<TR>
								<TD align="center"><FONT face="宋体"><asp:textbox id="j1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
											ReadOnly="True"></asp:textbox>~
										<asp:textbox id="k1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
											ReadOnly="True"></asp:textbox></FONT></TD>
								<TD align="center"><FONT face="宋体"><asp:textbox id="l1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD align="center"><asp:textbox id="m1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="n1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="o1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<td align="center" width="5%"><asp:button id="btn_add_jyjl" runat="server" CssClass="input4" Text="添加"></asp:button></td>
							</TR>
							<tr>
								<td colSpan="6"><asp:datagrid id="DataGrid1" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False">
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="qzsp_id" HeaderText="ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jy_kssj" HeaderText="起始时间">
												<HeaderStyle Width="13%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jy_jssj" HeaderText="截止时间">
												<HeaderStyle Width="12.5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jy_xx" HeaderText="学校或机构">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jy_zy" HeaderText="学习专业或培训内容"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jy_xxxs" HeaderText="学习形式"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jy_hdzs" HeaderText="获得证书"></asp:BoundColumn>
											<asp:ButtonColumn Text="删除" CommandName="Delete">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="1" style="border-collapse: collapse;">
							<TR>
								<TD align="center" width="3%" rowSpan="5">工作简历</TD>
								<TD align="center" width="25%">起止年月</TD>
								<TD align="center" width="25%">工作单位</TD>
								<TD align="center">联系电话</TD>
								<TD align="center">部门及职务</TD>
								<TD align="center">收入情况</TD>
								<TD align="center">离职原因</TD>
								<td align="center"></td>
							</TR>
							<TR>
								<TD align="center"><FONT face="宋体"><asp:textbox id="p1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
											ReadOnly="True"></asp:textbox>~
										<asp:textbox id="q1" onfocus="WdatePicker({skin:'simple'})" runat="server" Width="90px" BackColor="WhiteSmoke"
											ReadOnly="True"></asp:textbox></FONT></TD>
								<TD align="center"><FONT face="宋体"><asp:textbox id="r1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD align="center"><asp:textbox id="s1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="t1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="u1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="v1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<td align="center" width="5%"><asp:button id="btn_add_gzjl" runat="server" CssClass="input4" Text="添加"></asp:button></td>
							</TR>
							<tr>
								<td colSpan="7"><asp:datagrid id="DataGrid2" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False">
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="qzsp_id"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_gz_kssj" HeaderText="起始时间">
												<HeaderStyle Width="13%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_gz_jssj" HeaderText="截止时间">
												<HeaderStyle Width="12.5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_gz_gzdw" HeaderText="工作单位">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_gz_lxdh" HeaderText="联系电话"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_gz_bm_zw" HeaderText="部门及职务"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_gz_srqk" HeaderText="收入情况"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_gz_lzyy" HeaderText="离职原因"></asp:BoundColumn>
											<asp:ButtonColumn Text="删除" CommandName="Delete">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="1" style="border-collapse: collapse;">
							<TR>
								<TD align="center" width="3%" rowSpan="3">家庭成员</TD>
								<TD align="center" width="10%">姓名</TD>
								<TD align="center" width="5%">年龄</TD>
								<TD align="center" width="10%">关系</TD>
								<TD align="center">工作或学习单位/职务</TD>
								<TD align="center" width="5%"></TD>
							</TR>
							<TR>
								<TD align="center" width="10%"><asp:textbox id="w1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center" width="5%"><asp:textbox id="x1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center" width="10%"><asp:textbox id="y1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="z1" runat="server" Width="100%" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></TD>
								<TD align="center" width="5%"><asp:button id="btn_add_jtgx" runat="server" CssClass="input4" Text="添加"></asp:button></TD>
							</TR>
							<tr>
								<td colSpan="5"><asp:datagrid id="DataGrid3" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False">
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="qzsp_id"></asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jt_xm" HeaderText="姓名">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jt_nl" HeaderText="年龄">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jt_gx" HeaderText="关系">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="qzsp_jt_dw_zw" HeaderText="工作或学习单位/职务"></asp:BoundColumn>
											<asp:ButtonColumn Text="删除" CommandName="Delete">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>以前是否有大病、重病史或犯罪记录?
						<asp:checkbox id="a2" runat="server" BackColor="WhiteSmoke" Enabled="False" Text="无"></asp:checkbox><asp:checkbox id="b2" runat="server" BackColor="WhiteSmoke" Enabled="False" Text="有"></asp:checkbox>(描述简况)
						<asp:textbox id="c2" runat="server" Width="376px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr>
					<td><span style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold">&nbsp; 
							本人承诺以上资料真实准确<span lang="EN-US">,</span>所提交证件无伪<span lang="EN-US">,</span>如有任何虚假<span lang="EN-US">,</span>公司可无条件解除合同并可追究本人责任。</span></td>
				</tr>
				<tr>
					<td align="center"><span style="FONT-SIZE: 12pt; FONT-FAMILY: 黑体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold; mso-hansi-font-family: 新宋体"><asp:textbox id="z2" runat="server" Width="25px" BackColor="WhiteSmoke" Visible="False" ReadOnly="True"></asp:textbox>经办人签名：
							<asp:textbox id="d2" runat="server" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;<SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 黑体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold; mso-hansi-font-family: 新宋体"><SPAN style="mso-spacerun: yes">&nbsp;</SPAN>经办日期：
								<asp:textbox id="e2" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="WhiteSmoke"
									ReadOnly="True"></asp:textbox></SPAN></span></td>
				</tr>
				<TR>
					<td vAlign="middle" align="center"><asp:button id="btnSave" runat="server" CssClass="input4" Text="提交"></asp:button><FONT face="宋体"><asp:button id="Button1" runat="server" CssClass="input4" Text="保存"></asp:button></FONT><asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
