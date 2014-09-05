<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xjyjsp.aspx.cs" Inherits="Stoke.USL.sbds.xjyjsp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>xjyjsp</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="../../My97DatePicker/WdatePicker.js"></SCRIPT>
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		////////////////////////////////////////////////////////打印到word 
		function print_xjyj()
		{
		var w = new ActiveXObject("Word.Application");   
		w.Application.Visible = true;
		var docs = w.Application.Documents;
		var doc = docs.open(fm1.wordurl.value);//打开开word文档    //未获得值
		
		myTable = doc.Tables(1);
		
		myTable.Cell(1, 2).Range.Text = fm1.aa.value;//申请部门
		myTable.Cell(1, 4).Range.Text = fm1.ba.value;//借款日期
		
		myTable.Cell(2, 2).Range.Text = fm1.ca.value;//借款事由
		
		myTable.Cell(4, 1).Range.Text = fm1.da.value;//借款金额大写
		myTable.Cell(4, 2).Range.Text = fm1.ea.value;//支票号码
		myTable.Cell(4, 3).Range.Text = fm1.fa.value;//报销金额小写
		myTable.Cell(4, 4).Range.Text = fm1.ga.value;//报销日期
		
		myTable.Cell(5, 1).Range.Text = fm1.ha.value;//借款金额大写
		myTable.Cell(5, 2).Range.Text = fm1.ia.value;//支票号码
		myTable.Cell(5, 3).Range.Text = fm1.ja.value;//报销金额小写
		myTable.Cell(5, 4).Range.Text = fm1.ka.value;//报销日期
		
		myTable.Cell(6, 1).Range.Text = fm1.la.value;//借款金额大写
		myTable.Cell(6, 2).Range.Text = fm1.ma.value;//支票号码
		myTable.Cell(6, 3).Range.Text = fm1.na.value;//报销金额小写
		myTable.Cell(6, 4).Range.Text = fm1.oa.value;//报销日期
		
		myTable.Cell(7, 1).Range.Text = fm1.pa.value;//借款金额大写
		myTable.Cell(7, 2).Range.Text = fm1.qa.value;//支票号码
		myTable.Cell(7, 3).Range.Text = fm1.ra.value;//报销金额小写
		myTable.Cell(7, 4).Range.Text = fm1.sa.value;//报销日期
		
		myTable.Cell(8, 2).Range.Text = fm1.ta.value;//借款经办人
		myTable.Cell(8, 4).Range.Text = fm1.ua.value;//联系电话
		
		myTable.Cell(9, 2).Range.Text = fm1.va.value;//部门负责人审核
		myTable.Cell(9, 4).Range.Text = fm1.c1a.value;//预算确认
		
		myTable.Cell(10, 2).Range.Text = fm1.wa.value;//分管领导审定
		myTable.Cell(10, 4).Range.Text = fm1.xa.value;//财务部长审核
		
		myTable.Cell(11, 2).Range.Text = fm1.ya.value;//财务副总
		myTable.Cell(11, 4).Range.Text = fm1.za.value;//总经理
		
		myTable.Cell(12, 2).Range.Text = fm1.d1a.value;//出纳人
		myTable.Cell(12, 4).Range.Text = fm1.e1a.value;//还款日期
		myTable.Cell(12, 6).Range.Text = fm1.f1a.value;//销账确认
		
		}
		</script>
	</HEAD>
	<body class="body1" leftMargin="0" MS_POSITIONING="GridLayout">
		<form id="fm1" name="fm1" method="post" runat="server">
			<input type=hidden value="<%=wordUrl%>" name=wordurl><!---word路径-->
			<input type=hidden value="<%=a.SelectedItem.Text%>" name=aa><!---word路径-->
			<input type=hidden value="<%=b.Text%>" name=ba><!---word路径-->
			<input type=hidden value="<%=c.Text%>" name=ca><!---word路径-->
			<input type=hidden value="<%=d.Text%>" name=da><!---word路径-->
			<input type=hidden value="<%=e.Text%>" name=ea><!---word路径-->
			<input type=hidden value="<%=f.Text%>" name=fa><!---word路径-->
			<input type=hidden value="<%=g.Text%>" name=ga><!---word路径-->
			<input type=hidden value="<%=h.Text%>" name=ha><!---word路径-->
			<input type=hidden value="<%=i.Text%>" name=ia><!---word路径-->
			<input type=hidden value="<%=j.Text%>" name=ja><!---word路径-->
			<input type=hidden value="<%=k.Text%>" name=ka><!---word路径-->
			<input type=hidden value="<%=l.Text%>" name=la><!---word路径-->
			<input type=hidden value="<%=m.Text%>" name=ma><!---word路径-->
			<input type=hidden value="<%=n.Text%>" name=na><!---word路径-->
			<input type=hidden value="<%=o.Text%>" name=oa><!---word路径-->
			<input type=hidden value="<%=p.Text%>" name=pa><!---word路径-->
			<input type=hidden value="<%=q.Text%>" name=qa><!---word路径-->
			<input type=hidden value="<%=r.Text%>" name=ra><!---word路径-->
			<input type=hidden value="<%=s.Text%>" name=sa><!---word路径-->
			<input type=hidden value="<%=t.Text%>" name=ta><!---word路径-->
			<input type=hidden value="<%=u.Text%>" name=ua><!---word路径-->
			<input type=hidden value="<%=v.Text%>" name=va><!---word路径-->
			<input type=hidden value="<%=w.Text%>" name=wa><!---word路径-->
			<input type=hidden value="<%=x.Text%>" name=xa><!---word路径-->
			<input type=hidden value="<%=y.Text%>" name=ya><!---word路径-->
			<input type=hidden value="<%=z.Text%>" name=za><!---word路径-->
			<input type=hidden value="<%=c1.Text%>" name=c1a><!---word路径-->
			<input type=hidden value="<%=d1.Text%>" name=d1a><!---word路径-->
			<input type=hidden value="<%=e1.Text%>" name=e1a><!---word路径-->
			<input type=hidden value="<%=f1.Text%>" name=f1a><!---word路径-->
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
					cellPadding="0" width="95%" border="0">
					<TR>
						<TD align="center">
							<TABLE id="Table7" style="WIDTH: 776px; HEIGHT: 16px" cellSpacing="1" cellPadding="1" width="776"
								align="center" border="0">
								<TR style="display: none;">
									<TD style="HEIGHT: 7px">
										<P align="center"><asp:label id="Label2" runat="server" Height="16px" Font-Size="Large" Width="639px">大连船舶重工集团海洋工程有限公司</asp:label></P>
									</TD>
								</TR>
								<TR style="display: none;">
									<TD style="HEIGHT: 1px">
										<P align="center"><asp:label id="Label3" runat="server" Font-Size="X-Small" Font-Bold="True">Dalian Shipbuilding Industry Offshore Co.,Ltd</asp:label></P>
									</TD>
								</TR>
								<TR height="20">
									<TD style="HEIGHT: 2px"><FONT face="宋体"></FONT></TD>
								</TR>
								<TR>
									<TD align="center">&nbsp;&nbsp;&nbsp;
										<asp:label id="Label5" runat="server" Font-Size="Small" Font-Bold="True">现金预借审批单</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="Tborder_2" align="center">
							<TABLE class="Tborder" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="right" width="15%">借款部门
													<asp:image id="Image1" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%">
													<asp:DropDownList id="a" runat="server" Width="80%"></asp:DropDownList></TD>
												<TD align="right" width="15%">借款日期
													<asp:image id="Image2" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD align="left" width="35%"><asp:textbox id="b" onfocus="calendar()" runat="server" Width="100%" AutoPostBack="True" CssClass="myline"
														ReadOnly="True" Enabled="False"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD vAlign="middle" width="109" align="center" style="WIDTH: 109px">支出事由摘要</TD>
												<td width="8">
													<asp:image id="Image4" runat="server" ImageUrl="../../images/L41.gif"></asp:image></td>
												<TD><asp:textbox id="c" runat="server" Height="122px" Width="100%" ReadOnly="True" TextMode="MultiLine"
														BorderStyle="Groove" BorderColor="Gainsboro"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center" width="25%">借款金额（小写）</TD>
												<TD align="center">凭证号码</TD>
												<TD align="center" width="25%">报销金额（小写）</TD>
												<TD align="center" width="174">报销日期</TD>
											</TR>
											<TR>
												<TD align="center"><asp:textbox id="d" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="e" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="f" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="g" onfocus="calendar()" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="center"><asp:textbox id="h" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="i" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="j" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="k" onfocus="calendar()" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="center"><asp:textbox id="l" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="m" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="n" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="o" onfocus="calendar()" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="center"><asp:textbox id="p" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="q" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="r" runat="server" Width="95%" AutoPostBack="True" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="s" onfocus="calendar()" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="right" width="15%">借款经办人
													<asp:image id="Image5" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="t" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right" width="15%">联系电话
													<asp:image id="Image6" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="u" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colspan="2">
										<TABLE id="Table15" cellpadding="0" cellspacing="0" width="100%" border="0">
											<TR>
												<TD align="right" width="166" style="WIDTH: 166px">部门负责人审核
													<asp:image id="Image7" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="v" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right" width="15%">预算确认
													<asp:image id="Image8" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="c1" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="right" width="15%">分管领导审批
													<asp:image id="Image9" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="w" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right" width="15%">财务部长审核
													<asp:image id="Image10" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="x" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="right" width="15%">财务副总审批
													<asp:image id="Image11" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="y" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right" width="15%">总经理审批
													<asp:image id="Image12" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%" colSpan="3"><asp:textbox id="z" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="right" width="15%">出纳&nbsp;
													<asp:image id="Image14" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="20%"><asp:textbox id="d1" runat="server" Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right" width="13%">还款日期
													<asp:image id="Image15" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="20%"><asp:textbox class="Wdate" id="e1" onfocus="calendar({dateFmt:'yyyy-MM-dd HH:mm:ss'})" runat="server"
														Width="95%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
												<TD align="right">销账确认
													<asp:image id="Image13" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="16%"><asp:textbox id="f1" runat="server" Width="100%" CssClass="myline" ReadOnly="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="right" width="14%" colSpan="2">
										<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="HEIGHT: 19px"><asp:requiredfieldvalidator id="rfv1" runat="server" ControlToValidate="c" Display="None" ErrorMessage="支出事由摘要不能为空！"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="rev2" runat="server" ControlToValidate="d" Display="None" ErrorMessage="借款金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev3" runat="server" ControlToValidate="h" Display="None" ErrorMessage="借款金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev4" runat="server" ControlToValidate="l" Display="None" ErrorMessage="借款金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev5" runat="server" ControlToValidate="p" Display="None" ErrorMessage="借款金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev6" runat="server" ControlToValidate="f" Display="None" ErrorMessage="报销金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev7" runat="server" ControlToValidate="j" Display="None" ErrorMessage="报销金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev8" runat="server" ControlToValidate="n" Display="None" ErrorMessage="报销金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev9" runat="server" ControlToValidate="r" Display="None" ErrorMessage="报销金额必须为数字！"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="u" Display="None"
														ErrorMessage="联系电话不能为空！"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="d" Display="None"
														ErrorMessage="至少需要填写一项借款金额！"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD align="center"><asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary></TD>
											</TR>
											<TR>
												<TD align="center">
													<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="32%"></TD>
															<TD align="center"><asp:button id="submitBtn" runat="server" CssClass="input4" Text=" 提  交 "></asp:button></TD>
															<TD align="center"><asp:button id="storeBtn" runat="server" CssClass="input4" Text=" 保  存 " CausesValidation="False"></asp:button></TD>
															<TD align="center"><asp:button id="Btn_print" runat="server" CssClass="input4" Text="打  印 " CausesValidation="False"></asp:button></TD>
															<TD align="center"><asp:button id="cancelBtn" runat="server" CssClass="input4" Text="返  回 " CausesValidation="False"></asp:button></TD>
															<TD width="32%"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="Tborder_2" align="left"><font color="red">备注：单笔额度2万元及以下、2-10万元、10万元及以上的支出分别由财务部长、财务副总和总经理审批</font></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
