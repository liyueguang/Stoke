<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zpyjsp.aspx.cs" Inherits="Stoke.USL.sbds.zpyjsp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>zpyjsp</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="JavaScript" src="../../My97DatePicker/WdatePicker.js"></SCRIPT>
		<LINK rel="stylesheet" type="text/css" href="../../css/css.css">
		<script language="javascript">
				////////////////////////////////////////////////////////打印到word 
		function print_zpyj()
		{
		var w = new ActiveXObject("Word.Application");   
		w.Application.Visible = true;
		var docs = w.Application.Documents;
		var doc = docs.open(fm1.wordurl.value);//打开开word文档    //未获得值
		
		myTable = doc.Tables(1);
		
		myTable.Cell(1, 2).Range.Text = fm1.aa.value;//申请部门
		myTable.Cell(1, 4).Range.Text = fm1.ba.value;//借款日期
		
		myTable.Cell(2, 2).Range.Text = fm1.ca.value;//借款事由
		
		myTable.Cell(4, 1).Range.Text = fm1.j1a.value + fm1.da.value;//借款金额大写
		myTable.Cell(4, 2).Range.Text = fm1.ea.value;//支票号码
		myTable.Cell(4, 3).Range.Text = fm1.fa.value;//报销金额小写
		myTable.Cell(4, 4).Range.Text = fm1.ga.value;//报销日期
		
		myTable.Cell(5, 1).Range.Text = fm1.l1a.value + fm1.ha.value;//借款金额大写
		myTable.Cell(5, 2).Range.Text = fm1.ia.value;//支票号码
		myTable.Cell(5, 3).Range.Text = fm1.ja.value;//报销金额小写
		myTable.Cell(5, 4).Range.Text = fm1.ka.value;//报销日期
		
		myTable.Cell(6, 1).Range.Text = fm1.n1a.value + fm1.la.value;//借款金额大写
		myTable.Cell(6, 2).Range.Text = fm1.ma.value;//支票号码
		myTable.Cell(6, 3).Range.Text = fm1.na.value;//报销金额小写
		myTable.Cell(6, 4).Range.Text = fm1.oa.value;//报销日期
		
		myTable.Cell(7, 1).Range.Text = fm1.p1a.value + fm1.pa.value;//借款金额大写
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
		<form id="fm1" method="post" name="fm1" runat="server">
			<input 
value="<%=wordUrl%>" type=hidden name=wordurl><!---word路径-->
			<input value="<%=a.SelectedItem.Text%>" type=hidden name=aa><!---word路径-->
			<input value="<%=b.Text%>" type=hidden name=ba><!---word路径-->
			<input value="<%=c.Text%>" type=hidden name=ca><!---word路径-->
			<input value="<%=d.Text%>" type=hidden name=da><!---word路径-->
			<input value="<%=e.Text%>" type=hidden name=ea><!---word路径-->
			<input value="<%=f.Text%>" type=hidden name=fa><!---word路径-->
			<input value="<%=g.Text%>" type=hidden name=ga><!---word路径-->
			<input value="<%=h.Text%>" type=hidden name=ha><!---word路径-->
			<input value="<%=i.Text%>" type=hidden name=ia><!---word路径-->
			<input value="<%=j.Text%>" type=hidden name=ja><!---word路径-->
			<input value="<%=k.Text%>" type=hidden name=ka><!---word路径-->
			<input value="<%=l.Text%>" type=hidden name=la><!---word路径-->
			<input value="<%=m.Text%>" type=hidden name=ma><!---word路径-->
			<input value="<%=n.Text%>" type=hidden name=na><!---word路径-->
			<input value="<%=o.Text%>" type=hidden name=oa><!---word路径-->
			<input value="<%=p.Text%>" type=hidden name=pa><!---word路径-->
			<input value="<%=q.Text%>" type=hidden name=qa><!---word路径-->
			<input value="<%=r.Text%>" type=hidden name=ra><!---word路径-->
			<input value="<%=s.Text%>" type=hidden name=sa><!---word路径-->
			<input value="<%=t.Text%>" type=hidden name=ta><!---word路径-->
			<input value="<%=u.Text%>" type=hidden name=ua><!---word路径-->
			<input value="<%=v.Text%>" type=hidden name=va><!---word路径-->
			<input value="<%=w.Text%>" type=hidden name=wa><!---word路径-->
			<input value="<%=x.Text%>" type=hidden name=xa><!---word路径-->
			<input value="<%=y.Text%>" type=hidden name=ya><!---word路径-->
			<input value="<%=z.Text%>" type=hidden name=za><!---word路径-->
			<input value="<%=c1.Text%>" type=hidden name=c1a><!---word路径-->
			<input value="<%=d1.Text%>" type=hidden name=d1a><!---word路径-->
			<input value="<%=e1.Text%>" type=hidden name=e1a><!---word路径-->
			<input value="<%=f1.Text%>" type=hidden name=f1a><!---word路径-->
			<input value="<%=j1.Text%>" type=hidden name=j1a><!---word路径-->
			<input value="<%=l1.Text%>" type=hidden name=l1a><!---word路径-->
			<input value="<%=n1.Text%>" type=hidden name=n1a><!---word路径-->
			<input value="<%=p1.Text%>" type=hidden name=p1a><!---word路径-->
			<input value="<%= h1.Text%>" type=hidden name=q1a><!---word路径-->
			<input value="<%=k1.Text%>" type=hidden name=r1a><!---word路径-->
			<input value="<%=m1.Text%>" type=hidden name=s1a><!---word路径-->
			<input value="<%=o1.Text%>" type=hidden name=t1a><!---word路径-->
			<FONT face="宋体">
				<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" id="Table1" border="0"
					cellSpacing="0" cellPadding="0" width="95%">
					<TR>
						<TD align="center">
							<TABLE style="WIDTH: 776px; HEIGHT: 16px" id="Table7" border="0" cellSpacing="1" cellPadding="1"
								width="776" align="center">
								<TR style="display: none;">
									<TD style="HEIGHT: 7px">
										<P align="center"><asp:label id="Label2" runat="server" Width="639px" Font-Size="Large" Height="16px">大连船舶重工集团海洋工程有限公司</asp:label></P>
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
										<asp:label id="Label5" runat="server" Font-Size="Small" Font-Bold="True">支票预借审批单</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="Tborder_2" align="center">
							<TABLE id="Table2" class="Tborder" border="1" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table11" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD width="15%" align="right">借款部门
													<asp:image id="Image1" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:dropdownlist id="a" runat="server" Width="80%"></asp:dropdownlist></TD>
												<TD width="15%" align="right">借款日期
													<asp:image id="Image2" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%" align="left"><asp:textbox id="b" onfocus="calendar()" runat="server" Width="100%" Enabled="False" ReadOnly="True"
														CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD style="WIDTH: 109px" vAlign="middle" width="109" align="center">支出事由摘要</TD>
												<td width="8"><asp:image id="Image4" runat="server" ImageUrl="../../images/L41.gif"></asp:image></td>
												<TD><asp:textbox id="c" runat="server" Width="100%" Height="122px" ReadOnly="True" BorderColor="Gainsboro"
														BorderStyle="Groove" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table12" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD style="WIDTH: 293px" width="293" colSpan="3" align="center">借款金额（小写）</TD>
												<TD align="center">支票号码</TD>
												<TD width="25%" align="center">报销金额（小写）</TD>
												<TD width="174" align="center">报销日期</TD>
											</TR>
											<TR>
												<TD width="4%" align="right"><asp:checkbox id="h1" Width="100%" Visible="False" Text="限" Runat="server"></asp:checkbox></TD>
												<TD width="1%" align="right"><asp:label id="j1" Width="100%" Visible="True" Runat="server"></asp:label></TD>
												<TD width="20%" align="left"><asp:textbox id="d" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="e" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="f" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="g" onfocus="calendar()" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="4%" align="right"><asp:CheckBox ID="k1" Width="100%" Visible="False" Text="限" Runat="server"></asp:CheckBox></TD>
												<TD width="1%" align="right"><asp:Label ID="l1" Width="100%" Visible="True" Runat="server"></asp:Label></TD>
												<TD width="20%" align="left"><asp:textbox id="h" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="i" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="j" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="k" onfocus="calendar()" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="4%" align="right"><asp:CheckBox ID="m1" Width="100%" Visible="False" Text="限" Runat="server"></asp:CheckBox></TD>
												<td width="1%" align="right"><asp:Label id="n1" Width="100%" Visible="true" Runat="server"></asp:Label></td>
												<TD width="20%" align="left"><asp:textbox id="l" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="m" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="n" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="o" onfocus="calendar()" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right"><asp:CheckBox ID="o1" Width="100%" Visible="False" Text="限" Runat="server"></asp:CheckBox></TD>
												<TD width="1%" align="right"><asp:Label id="p1" Width="100%" Visible="True" Runat="server"></asp:Label></TD>
												<TD width="20%" align="left"><asp:textbox id="p" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="q" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="r" runat="server" Width="95%" ReadOnly="True" CssClass="myline" AutoPostBack="True"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="s" onfocus="calendar()" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD width="15%" align="right">借款经办人
													<asp:image id="Image5" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="t" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD width="15%" align="right">联系电话
													<asp:image id="Image6" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="u" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table15" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD width="15%" align="right">部门负责人审核
													<asp:image id="Image7" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="v" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD width="15%" align="right">预算确认
													<asp:image id="Image8" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="c1" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD width="15%" align="right">分管领导审批
													<asp:image id="Image9" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="w" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD width="15%" align="right">财务部长审核
													<asp:image id="Image10" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="x" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD width="15%" align="right">财务副总审批
													<asp:image id="Image11" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%"><asp:textbox id="y" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD width="15%" align="right">总经理审批
													<asp:image id="Image12" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="35%" colSpan="3"><asp:textbox id="z" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table8" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD width="15%" align="right">出纳
													<asp:image id="Image14" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="20%"><asp:textbox id="d1" runat="server" Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD width="13%" align="right">还款日期
													<asp:image id="Image15" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="20%"><asp:textbox id="e1" class="Wdate" onfocus="calendar({dateFmt:'yyyy-MM-dd HH:mm:ss'})" runat="server"
														Width="95%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
												<TD align="right">销账确认
													<asp:image id="Image13" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD width="16%"><asp:textbox id="f1" runat="server" Width="100%" ReadOnly="True" CssClass="myline"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="14%" colSpan="2" align="right">
										<TABLE id="Table13" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD style="HEIGHT: 19px"><asp:requiredfieldvalidator id="rfv1" runat="server" ErrorMessage="支出事由摘要不能为空！" Display="None" ControlToValidate="c"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="rev2" runat="server" ErrorMessage="借款金额必须为数字！" Display="None" ControlToValidate="d"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev3" runat="server" ErrorMessage="借款金额必须为数字！" Display="None" ControlToValidate="h"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev4" runat="server" ErrorMessage="借款金额必须为数字！" Display="None" ControlToValidate="l"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev5" runat="server" ErrorMessage="借款金额必须为数字！" Display="None" ControlToValidate="p"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev6" runat="server" ErrorMessage="报销金额必须为数字！" Display="None" ControlToValidate="f"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev7" runat="server" ErrorMessage="报销金额必须为数字！" Display="None" ControlToValidate="j"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev8" runat="server" ErrorMessage="报销金额必须为数字！" Display="None" ControlToValidate="n"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="rev9" runat="server" ErrorMessage="报销金额必须为数字！" Display="None" ControlToValidate="r"
														ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="联系电话不能为空！" Display="None"
														ControlToValidate="u"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="至少需要填写一项借款金额！" Display="None"
														ControlToValidate="d"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD align="center"><asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary></TD>
											</TR>
											<TR>
												<TD align="center">
													<TABLE id="Table14" border="0" cellSpacing="0" cellPadding="0" width="100%">
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
