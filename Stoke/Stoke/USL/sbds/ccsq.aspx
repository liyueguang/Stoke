<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ccsq.aspx.cs" Inherits="Stoke.USL.sbds.ccsq" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>ccsq</title>
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../My97DatePicker/WdatePicker.js"></SCRIPT>
		<SCRIPT language="JavaScript" src="../../js/check.js"></SCRIPT>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		////////////////////////////////////////////////////////打印到word 
		function print_ccsq()
		{
		var w = new ActiveXObject("Word.Application");   
		w.Application.Visible = true;
		var docs = w.Application.Documents;
		var doc = docs.open(fm1.wordurl.value);//打开开word文档    //未获得值
		
		w.Selection.movedown(unit=5,count=4);
		w.Selection.movedown(unit=4,count=-2);
		w.Selection.typetext(fm1.aa.value);//申请单号
			
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.ca.value);//申请部门
		
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.da.value);//出差经办人
		
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.ba.value);//日期
		
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=5);
		w.Selection.typetext(fm1.ea.value);//职工姓名

		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.va.value);//联系电话
	
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=6);
		w.Selection.typetext(fm1.qa.value);//同行人员

		w.Selection.movedown(unit=5,count=1);
		w.Selection.typetext(fm1.ra.value);//出差涉及部门
		
		w.Selection.movedown(unit=5,count=1);
		w.Selection.typetext(fm1.ga.value);//出差事由
		
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=9);
		w.Selection.typetext(fm1.h.value );//出差地点
		
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.ka.value);//出差时间
		
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.la.value);//预计天数
		
		
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=10);
		w.Selection.typetext(fm1.ia.value);//拟乘交通工具
		
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.ja.value);//预借金额
		
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=11);
		w.Selection.typetext(fm1.fa.value);//部门负责人
		
			
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=12);
		w.Selection.typetext(fm1.ua.value);//会签
		
		w.Selection.movedown(unit=5,count=1);
		w.Selection.typetext(fm1.ma.value);//公司领导批准
		
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=14);
		w.Selection.typetext(fm1.oa.value);//财务部
		
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.na.value);//财务部核实
		
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=15);
		w.Selection.typetext(fm1.ya.value);//预算登计

		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.pa.value);//任证号码
		
		w.Selection.homekey(6);
		w.Selection.movedown(unit=5,count=16);
		w.Selection.typetext(fm1.xa.value);//销账确认
		
		w.Selection.movedown(unit=4,count=2);
		w.Selection.typetext(fm1.za.value);//预算登记
		}
		</script>
	</HEAD>
	<body class="body1" leftMargin="0" MS_POSITIONING="GridLayout">
		<form id="fm1" name="fm1" method="post" runat="server">
			<input type=hidden value="<%=wordUrl%>" name=wordurl><!---word路径-->
			<input type=hidden value="<%=a.Text%>" name=aa><!---word路径-->
			<input type=hidden value="<%=b.Text%>" name=ba><!---word路径-->
			<input type=hidden value="<%=c.SelectedItem.Text %>" name=ca><!---word路径-->
			<input type=hidden value="<%=d.Text%>" name=da><!---word路径-->
			<input type=hidden value="<%=e.Text%>" name=ea><!---word路径-->
			<input type=hidden value="<%=f.Text%>" name=fa><!---word路径-->
			<input type=hidden value="<%=g.Text%>" name=ga><!---word路径-->
			<input type=hidden value="<%=i.SelectedItem.Text%>" name=ia><!---word路径-->
			<input type=hidden value="<%=j.Text%>" name=ja><!---word路径-->
			<input type=hidden value="<%=k.Text%>" name=ka><!---word路径-->
			<input type=hidden value="<%=l.Text%>" name=la><!---word路径-->
			<input type=hidden value="<%=m.Text%>" name=ma><!---word路径-->
			<input type=hidden value="<%=n.Text%>" name=na><!---word路径-->
			<input type=hidden value="<%=o.Text%>" name=oa><!---word路径-->
			<input type=hidden value="<%=p.Text%>" name=pa><!---word路径-->
			<input type=hidden value="<%=q.Text%>" name=qa><!---word路径-->
			<input type=hidden value="<%=Word_ra%>" name=ra><!---word路径-->
			<input type=hidden value="<%=u.Text%>" name=ua><!---word路径-->
			<input type=hidden value="<%=v.Text%>" name=va><!---word路径-->
			<input type=hidden value="<%=x.Text%>" name=xa><!---word路径-->
			<input type=hidden value="<%=y.Text%>" name=ya><!---word路径-->
			<input type=hidden value="<%=z.Text%>" name=za><!---word路径-->
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" height="118"
					cellSpacing="1" cellPadding="1" width="95%" border="0">
					<TR>
						<TD align="center" colSpan="2" height="5"><FONT face="宋体"></FONT></TD>
					</TR>
					<TR style="display: none;">
						<TD align="center" colSpan="2"><asp:label id="Label" runat="server" Font-Size="Large" Width="399px" Height="24px">大连船舶重工集团海洋工程有限公司</asp:label></TD>
					</TR>
					<TR style="display: none;">
						<TD align="center" colSpan="2"><asp:label id="Label3" runat="server" Font-Size="X-Small" Font-Bold="True">Dalian Shipbuilding Offshore CO.,LTD.</asp:label></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="Label5" runat="server" Font-Size="Small" Font-Bold="True">出差申请及借款审批单</asp:label></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label1" runat="server">申请单号:</asp:label><asp:textbox id="a" runat="server" Width="186px" CssClass="myline" BackColor="Transparent" ReadOnly="True"></asp:textbox></TD>
						<TD align="right"><asp:label id="Label2" runat="server">日期:</asp:label><asp:textbox id="b" runat="server" Width="100px" CssClass="myline" BackColor="Transparent" ReadOnly="True"></asp:textbox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table16" style="Z-INDEX: 103; LEFT: 472px; WIDTH: 144px; POSITION: absolute; TOP: 208px; HEIGHT: 97px"
					height="97" cellSpacing="0" cellPadding="0" width="144" bgColor="white" border="1"
					runat="server">
					<TR>
						<TD height="1"><uc1:slctmember id="SlctMember1" runat="server"></uc1:slctmember></TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="BtnSD" runat="server" Width="66px" CssClass="input4" CausesValidation="False"
								Text="选择"></asp:button><asp:button id="Button6" runat="server" Width="66px" CssClass="input4" CausesValidation="False"
								Text="返回"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 128px" cellSpacing="0"
					cellPadding="0" width="95%" border="0">
					<TR>
						<TD class="Tborder">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="Tborder_2" colSpan="8"><FONT face="宋体">
											<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR height="35">
													<TD align="right" width="14%">申请部门
														<asp:image id="Image1" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
													<TD style="WIDTH: 156px" align="left"><asp:dropdownlist id="c" runat="server" Width="120"></asp:dropdownlist></TD>
													<TD align="right" width="16%">出差经办人
														<asp:image id="Image2" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
													<TD align="left" width="30%"><asp:textbox id="d" runat="server" Width="80" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
													<TD width="10%"></TD>
													<TD width="10%"></TD>
												</TR>
											</TABLE>
										</FONT>
									</TD>
								</TR>
								<TR>
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="35">
												<TD align="right" width="14%"><FONT face="宋体">职工编号
														<asp:image id="Image4" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD><asp:textbox id="e" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right" width="12%">联系电话
													<asp:image id="Image9" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD align="left" width="15%"><asp:textbox id="v" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right" width="16%"><FONT face="宋体"><asp:button id="personBtn" runat="server" CssClass="input4" CausesValidation="False" Text="同行人员"
															Enabled="False"></asp:button><asp:image id="Image14" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD align="left" width="30%"><asp:textbox id="q" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="35">
												<TD vAlign="middle" align="right" width="10%"><FONT face="宋体">出差涉及部门</FONT></TD>
												<td width="4">
													<asp:image id="Image21" runat="server" ImageUrl="../../images/L41.gif"></asp:image></td>
												<TD vAlign="bottom" align="left"><asp:checkboxlist id="r" runat="server" Width="100%" Enabled="False" RepeatColumns="5"></asp:checkboxlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR height="35">
									<TD class="Tborder_2" colSpan="8"><FONT face="宋体">
											<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR height="35">
													<TD valign="middle" align="right" width="10%">出差事由</TD>
													<td width="4">
														<asp:image id="Image5" runat="server" ImageUrl="../../images/L41.gif"></asp:image></td>
													<TD vAlign="top" align="left"><asp:textbox id="g" runat="server" Width="100%" Height="122px" ReadOnly="True" TextMode="MultiLine"
															BorderStyle="Ridge"></asp:textbox></TD>
												</TR>
											</TABLE>
										</FONT>
									</TD>
								</TR>
								<TR>
									<TD class="Tborder_2" colSpan="8"><FONT face="宋体">
											<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR height="35">
													<TD align="right" width="14%">出差地点
														<asp:image id="Image6" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
													<TD align="left" width="80"><INPUT class="myline" id="h" onblur="callserver()" size="10" name="h" runat="server"></TD>
													<TD style="WIDTH: 402px">
														<DIV id="msgDiv" style="WIDTH: 408px; HEIGHT: 19px" align="left">（注意：填写出差地点后，系统会自动提示相应住宿标准！）</DIV>
													</TD>
													<TD style="WIDTH: 108px" align="left" width="108"><FONT face="宋体">拟乘交通工具
															<asp:image id="Image19" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
													<TD align="left"><asp:dropdownlist id="i" runat="server" Width="90"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</FONT>
									</TD>
								</TR>
								<TR>
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="35">
												<TD align="right" width="14%"><FONT face="宋体"><FONT face="宋体">预借差旅费金额
															<asp:image id="Image15" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></FONT></TD>
												<TD vAlign="bottom" colSpan="2"><asp:textbox id="j" runat="server" Width="95%" CssClass="myline" ReadOnly="True" AutoPostBack="True"></asp:textbox>
													<DIV id="div1" align="left"><FONT face="宋体"></FONT></DIV>
												</TD>
												<TD align="right" width="15%"><FONT face="宋体"><FONT face="宋体">出差时间
															<asp:image id="Image16" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></FONT></TD>
												<TD align="left" width="15%"><FONT face="宋体"><asp:textbox class="Wdate" id="k" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" runat="server"
															Width="100%" CssClass="myline" ReadOnly="True" Enabled="False"></asp:textbox></FONT></TD>
												<TD align="right" width="16%"><FONT face="宋体">预计出差天数
														<asp:image id="Image17" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD align="left" width="30%"><asp:textbox id="l" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="35">
												<TD align="right" width="14%"><FONT face="宋体">部门负责人
														<asp:image id="Image8" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD width="86%"><FONT face="宋体"><asp:textbox id="f" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<tr>
									<td class="Tborder_2" colspan="8">
										<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr height="35">
												<TD align="right" width="14%"><FONT face="宋体">相关部门会签
														<asp:image id="Image20" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD width="86%"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><asp:textbox id="u" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</tr>
										</TABLE>
									</td>
								</tr>
								<TR height="35">
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="35">
												<TD align="right" width="14%"><FONT face="宋体">公司领导批准
														<asp:image id="Image13" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD><FONT face="宋体"><asp:textbox id="m" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></TD>
												<TD align="right" width="16%"><FONT face="宋体">财务部长核实金额数
														<asp:image id="Image12" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD width="30%"><FONT face="宋体"><FONT face="宋体"><asp:textbox id="n" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></FONT></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR height="35">
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table50" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="35">
												<TD align="right" width="14%"><FONT face="宋体">财务部审批
														<asp:image id="Image11" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD><FONT face="宋体"><asp:textbox id="o" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></TD>
												<TD align="right" width="16%"><FONT face="宋体">凭证号码
														<asp:image id="Image10" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD align="left" width="30%"><FONT face="宋体"><asp:textbox id="p" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR height="35">
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table60" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="35">
												<TD align="right" width="14%"><FONT face="宋体">出纳
														<asp:image id="Image3" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD style="WIDTH: 186px"><FONT face="宋体"><asp:textbox id="y" runat="server" Width="177px" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></TD>
												<TD align="right" width="12%"><FONT face="宋体">销账确认
														<asp:image id="Image7" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD style="WIDTH: 168px" align="left" width="168"><FONT face="宋体"><asp:textbox id="x" runat="server" Width="160px" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></TD>
												<TD align="right" width="12%"><FONT face="宋体">预算登记
														<asp:image id="Image18" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
												<TD align="left" width="18%"><FONT face="宋体"><asp:textbox id="z" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></FONT></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR height="35">
									<TD class="Tborder_2" colSpan="8">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="Tborder_2" id="TD1" align="center" colSpan="8"><FONT face="宋体"><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="出差事由不能为空！" Display="None"
												ControlToValidate="g"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="出差地点不能为空！" Display="None"
												ControlToValidate="h"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="预借差旅费不能为空！" Display="None"
												ControlToValidate="j"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="出差时间不能为空！" Display="None"
												ControlToValidate="k"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="预计出差天数不能为空！" Display="None"
												ControlToValidate="l"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="预借差旅费必须填写数字！" Display="None"
												ControlToValidate="j" ValidationExpression="^[0-9]\d*\.\d*|0\.\d*[0-9]\d*$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="R2" runat="server" ErrorMessage="预计出差天数必须是数字！" Display="None" ControlToValidate="l"
												ValidationExpression="^[1-9]\d*$"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ErrorMessage="联系电话不能为空！" Display="None"
												ControlToValidate="v"></asp:requiredfieldvalidator></FONT></TD>
								</TR>
								<TR>
									<TD class="Tborder_2" id="TD2" align="center" colSpan="8" runat="server"><asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary></TD>
								</TR>
								<TR class="Tborder_2">
									<TD colSpan="8"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR height="40">
													<TD width="38%"></TD>
													<TD align="center" width="8%"><asp:button id="submitBtn" runat="server" CssClass="input4" Text="处  理"></asp:button></TD>
													<TD align="center" width="8%"><asp:button id="storeBtn" runat="server" CssClass="input4" CausesValidation="False" Text="保  存"></asp:button></TD>
													<TD align="center" width="8%"><asp:button id="Btn_print" runat="server" CssClass="input4" CausesValidation="False" Text="打  印"></asp:button></TD>
													<TD align="center" width="8%"><asp:button id="cancelBtn" runat="server" CssClass="input4" CausesValidation="False" Text="返  回"></asp:button></TD>
													<TD width="38%"></TD>
												</TR>
											</TABLE>
										</FONT>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
