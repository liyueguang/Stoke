<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_gljsljxkh1.aspx.cs" Inherits="Stoke.USL.Staff.style_gljsljxkh1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_gljsljxkh</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<!--script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script-->
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js" type="text/javascript">
			function errmsg(message,url,line)
			{
			amsg = "A JavaScript Error has occured.please let us know about it.\n";
			amsg += "Error Message:" + message + "\n";
			amsg += "URL:" + url + "\n";
			amsg += "Line # :" + line;
			alert(amsg);
			return true;
			}
			window.onerror=errmsg;
		</script>
		<script language="javascript">
		function testisNum(object)
		{
			var s =document.getElementById(object.id).value;
			if(s!="")
			{
				if(isNaN(s))
				{
				alert("请输入数字");
				object.value="";
				object.focus();
				}
			}
		}
		function NumAndSum(object)//月末被考核人填写考核结果时验证
		{
			var s =document.getElementById(object.id).value;
			if(s!="")
			{
				if(isNaN(s))
				{
				alert("请输入数字");
				object.value="";
				object.focus();
				}
			}
			var s1 = 0;
			var s11 =document.getElementById("i").value;
			if(s11!="")
				s1 = parseFloat(s1) + parseFloat(s11);
				
			var s12 =document.getElementById("o").value;
			if(s12!="")
				s1 = parseFloat(s1) + parseFloat(s12);

			var s13 =document.getElementById("u").value;
			if(s13!="")
				s1 = parseFloat(s1) + parseFloat(s13);

			var s14 =document.getElementById("a1").value;
			if(s14!="")
				s1 = parseFloat(s1) + parseFloat(s14);

			var s15 =document.getElementById("lbl1").value;
			if(s15!="")
				s1 = parseFloat(s1) + parseFloat(s15);
			
			document.getElementById("d1").value = s1;			
		}
		
		function NumAndSum2(object)//月末考核人填写考核结果时验证
		{
			var s =document.getElementById(object.id).value;
			if(s!="")
			{
				if(isNaN(s))
				{
				alert("请输入数字");
				object.value="";
				object.focus();
				}
			}
			var s1 = 0;
			var s11 =document.getElementById("j").value;
			if(s11!="")
				s1 = parseFloat(s1) + parseFloat(s11);
				
			var s12 =document.getElementById("p").value;
			if(s12!="")
				s1 = parseFloat(s1) + parseFloat(s12);

			var s13 =document.getElementById("v").value;
			if(s13!="")
				s1 = parseFloat(s1) + parseFloat(s13);

			var s14 =document.getElementById("b1").value;
			if(s14!="")
				s1 = parseFloat(s1) + parseFloat(s14);

			var s15 =document.getElementById("lbl2").value;
			if(s15!="")
				s1 = parseFloat(s1) + parseFloat(s15);
	
			if(s1!=0)
				document.getElementById("e1").value = s1;			
		}
		
		function NumAndSum3(object)//月末考核人填写考核结果时验证
		{
			var s =document.getElementById(object.id).value;
			if(s!="")
			{
				if(isNaN(s))
				{
				alert("请输入数字");
				object.value="";
				object.focus();
				}
			}
			var s1 = 0;
			var s11 =document.getElementById("k").value;
			if(s11!="")
				s1 = parseFloat(s1) + parseFloat(s11);
				
			var s12 =document.getElementById("q").value;
			if(s12!="")
				s1 = parseFloat(s1) + parseFloat(s12);

			var s13 =document.getElementById("w").value;
			if(s13!="")
				s1 = parseFloat(s1) + parseFloat(s13);

			var s14 =document.getElementById("c1").value;
			if(s14!="")
				s1 = parseFloat(s1) + parseFloat(s14);

			var s15 =document.getElementById("lbl3").value;
			if(s15!="")
				s1 = parseFloat(s1) + parseFloat(s15);

			if(s1!=0)
				document.getElementById("f1").value = s1;			
		}
		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="95%" cellSpacing="0" cellPadding="0" width="810" align="center"
				border="0" runat="server" style="border-collapse: collapse;">
				<TR style="display: none;">
					<TD align="center" height="30"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt">大连船舶重工海洋工程公司</SPAN></B></TD>
				</TR>
				<TR>
					<TD align="center" height="30"><B style="mso-bidi-font-weight: normal"><SPAN lang="EN-US" style="FONT-SIZE: 16pt; FONT-FAMILY: 仿宋_GB2312; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt">(</SPAN><SPAN style="FONT-SIZE: 16pt; FONT-FAMILY: 仿宋_GB2312; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt">管理技术类<SPAN lang="EN-US">)</SPAN>员工
								<asp:dropdownlist id="f" runat="server"></asp:dropdownlist>年
								<asp:dropdownlist id="a" runat="server">
									<asp:ListItem Value="月份" Selected="True">月份</asp:ListItem>
									<asp:ListItem Value="1">1</asp:ListItem>
									<asp:ListItem Value="2">2</asp:ListItem>
									<asp:ListItem Value="3">3</asp:ListItem>
									<asp:ListItem Value="4">4</asp:ListItem>
									<asp:ListItem Value="5">5</asp:ListItem>
									<asp:ListItem Value="6">6</asp:ListItem>
									<asp:ListItem Value="7">7</asp:ListItem>
									<asp:ListItem Value="8">8</asp:ListItem>
									<asp:ListItem Value="9">9</asp:ListItem>
									<asp:ListItem Value="10">10</asp:ListItem>
									<asp:ListItem Value="11">11</asp:ListItem>
									<asp:ListItem Value="12">12</asp:ListItem>
								</asp:dropdownlist>月份工作目标计划（考核表）</SPAN></B></TD>
				</TR>
				<TR>
					<TD>
						<P class="MsoNormal"><B><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-font-kerning: 0pt">一、基本信息</SPAN></B></P>
					</TD>
				</TR>
				<tr>
					<td>
						<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD style="WIDTH: 53px">姓名<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD style="WIDTH: 103px"><asp:textbox id="b" runat="server" BackColor="Control" BorderStyle="None" CssClass="textbox"
										ReadOnly="True" Width="110px"></asp:textbox></TD>
								<TD style="WIDTH: 31px">编号<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD style="WIDTH: 123px"><asp:textbox id="c" runat="server" BackColor="Control" BorderStyle="None" CssClass="textbox"
										ReadOnly="True" Width="110px"></asp:textbox></TD>
								<TD>部门<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD style="WIDTH: 132px"><asp:dropdownlist id="d" runat="server" BackColor="Control" Width="110px" Enabled="False"></asp:dropdownlist></TD>
								<TD style="WIDTH: 44px">岗位<FONT style="COLOR: red" face="宋体">*</FONT></TD>
								<TD><asp:textbox id="q1" runat="server" BackColor="Control" BorderStyle="None" CssClass="textbox"
										ReadOnly="True" Width="247px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<P class="MsoNormal"><B><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-font-kerning: 0pt">二、考核内容（在“月工作计划内容”栏内要求至少写3项）<asp:textbox id="txt_doc" runat="server" Width="48px" Visible="False"></asp:textbox>
									<asp:dropdownlist id="e" runat="server" BackColor="Control" Width="110px" Enabled="False" Visible="False"></asp:dropdownlist></SPAN></B></P>
					</TD>
				</TR>
				<tr>
					<td>
						<TABLE id="Table4" style="WIDTH: 792px;border-collapse: collapse;" cellSpacing="0" cellPadding="0" width="792" border="1"
							runat="server" >
							<TR>
								<TD style="WIDTH: 25px" align="center">序号</TD>
								<TD style="WIDTH: 563px" align="center"><FONT face="宋体">月工作计划及目标内容(依据"主要岗位职责"细化,由被考核者写)</FONT></TD>
								<TD style="WIDTH: 423px" align="center">完成时间或进度</TD>
								<TD align="center" colSpan="4">考核权重100%</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" align="center"><FONT face="宋体">一</FONT></TD>
								<TD style="WIDTH: 563px" align="center">月工作计划及目标内容</TD>
								<TD style="WIDTH: 423px" align="center"><FONT face="宋体"></FONT></TD>
								<TD align="center" colSpan="4"><FONT face="宋体">80分</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" align="center"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 563px" align="center"><FONT face="宋体"><asp:textbox id="txt1" runat="server" CssClass="textbox" Width="100%"></asp:textbox></FONT></TD>
								<TD style="WIDTH: 423px" align="center"><asp:textbox id="txt2" runat="server" CssClass="textbox" Width="100%"></asp:textbox></TD>
								<TD align="center" colSpan="4"><FONT face="宋体"><asp:textbox id="txt3" onblur="testisNum(this)" runat="server" CssClass="textbox" Width="219px"></asp:textbox><asp:button id="add" runat="server" CssClass="input4" Text="添加"></asp:button></FONT></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 23px" colSpan="7"><FONT face="宋体" color="red">月度工作计划及内容&nbsp;&nbsp;
										<asp:button id="Button1" runat="server" CssClass="input4" Width="88px" Text="修改"></asp:button><asp:button id="Button2" runat="server" CssClass="input4" Width="88px" Text="确定"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：单击“修改”进行修改操作，单击“确定”保存修改。若换页，先保存当前页</FONT></TD>
							</TR>
							<TR>
								<TD vAlign="top" colSpan="7"><FONT face="宋体"><asp:datagrid id="dgrd1" runat="server" Width="100%" DataKeyField="gljh_id" AutoGenerateColumns="False"
											PageSize="15" AllowPaging="True">
											<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemTemplate>
														<%#Container.ItemIndex+1%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="月度工作计划及目标内容">
													<HeaderStyle Width="40%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id=txtnr runat="server" Width="300" ReadOnly="True" Text='<%#DataBinder.Eval(Container.DataItem,"gljh_nr")%>' Height="37px" TextMode="MultiLine">
														</asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="完成时间或进度">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtsj" runat="server" Width=120 ReadOnly="True" Text='<%#DataBinder.Eval(Container.DataItem,"gljh_sj")%>'>
														</asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="考核权重">
													<HeaderStyle Width="8%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtqz" runat="server" Width=75 ReadOnly="True" Text='<%#DataBinder.Eval(Container.DataItem,"gljh_qz")%>'>
														</asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="被考人(80分)">
													<HeaderStyle Width="6%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtbkr" runat="server" Width=75 ReadOnly="True" Text='<%#DataBinder.Eval(Container.DataItem,"gljh_bkr")%>'>
														</asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="考核人(80分)">
													<HeaderStyle Width="6%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtkhr" runat="server" Width=75 ReadOnly="True" Text='<%#DataBinder.Eval(Container.DataItem,"gljh_khr")%>'>
														</asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="复核人(80分)">
													<HeaderStyle Width="6%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtfhr" runat="server" Width=75 ReadOnly="True" Text='<%#DataBinder.Eval(Container.DataItem,"gljh_fhr")%>'>
														</asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:ButtonColumn Text="删除" CommandName="Delete">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:ButtonColumn>
												<asp:BoundColumn Visible="False" DataField="gljh_id" ReadOnly="True" HeaderText="编号"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="flag1"></asp:BoundColumn>
											</Columns>
											<PagerStyle VerticalAlign="Middle" HorizontalAlign="Right" BackColor="#F3F5FA" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></FONT></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1px" colSpan="7"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="h" runat="server" Width="19px" ReadOnly="True" BorderStyle="None" BackColor="Control"
											Visible="False"></asp:textbox>&nbsp;&nbsp; 第一部分考核合计&nbsp;&nbsp;
										<asp:textbox id="lbl1" runat="server" ReadOnly="True" Width="53px"></asp:textbox><asp:textbox id="lbl2" runat="server" ReadOnly="True" Width="53px"></asp:textbox><asp:textbox id="lbl3" runat="server" ReadOnly="True" Width="53px"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px; HEIGHT: 28px" align="center" width="25">二</TD>
								<TD style="WIDTH: 563px; HEIGHT: 28px" align="center" width="563" colSpan="2">综合评价（从任职资格、工作态度、责任心、爱心；企业文化认同度；规章制度、劳动纪律等执行情况综合评价员工的业务能力、执行力、沟通力、实干创新等工作能力提高情况）</TD>
								<TD style="HEIGHT: 28px" align="center" width="10%">考核权重10%</TD>
								<TD style="HEIGHT: 28px" align="center" width="8%">被考人</TD>
								<TD style="HEIGHT: 28px" align="center" width="8%">考核人</TD>
								<TD style="HEIGHT: 28px" align="center" width="8%">复核人</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px; HEIGHT: 34px"></TD>
								<TD style="WIDTH: 563px; HEIGHT: 34px" align="center" colSpan="2">
									<asp:textbox id="g" runat="server" Width="100%" ReadOnly="True" BorderStyle="None" BackColor="Control"
										TextMode="MultiLine" Height="50px"></asp:textbox></TD>
								<TD style="WIDTH: 95px; HEIGHT: 34px" align="center">10分</TD>
								<TD style="HEIGHT: 34px" align="center"><asp:textbox id="i" onblur="NumAndSum(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD style="HEIGHT: 34px" align="center"><asp:textbox id="j" onblur="NumAndSum2(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD style="HEIGHT: 34px" align="center"><asp:textbox id="k" onblur="NumAndSum3(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" align="center"><FONT face="宋体">三</FONT></TD>
								<TD style="WIDTH: 563px" align="center">主管上级临时交办的工作</TD>
								<TD style="WIDTH: 423px" align="center"><FONT face="宋体">完成时间或进度</FONT></TD>
								<TD style="WIDTH: 95px" align="center"><FONT face="宋体">10分</FONT></TD>
								<TD align="center"><FONT face="宋体">被考人</FONT></TD>
								<TD align="center"><FONT face="宋体">考核人</FONT></TD>
								<TD align="center"><FONT face="宋体">复核人</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px; HEIGHT: 22px" align="center">1</TD>
								<TD style="WIDTH: 563px; HEIGHT: 22px" align="center"><asp:textbox id="l" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="355px"></asp:textbox></TD>
								<TD style="WIDTH: 423px; HEIGHT: 22px" align="center"><asp:textbox id="m" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="155px"></asp:textbox></TD>
								<TD style="HEIGHT: 22px" align="center"><asp:textbox id="n" onblur="testisNum(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="72px"></asp:textbox></TD>
								<TD style="HEIGHT: 22px" align="center"><asp:textbox id="o" onblur="NumAndSum(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD style="HEIGHT: 22px" align="center"><asp:textbox id="p" onblur="NumAndSum2(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD style="HEIGHT: 22px" align="center"><asp:textbox id="q" onblur="NumAndSum3(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" align="center">2</TD>
								<TD style="WIDTH: 563px" align="center"><asp:textbox id="r" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="355px"></asp:textbox></TD>
								<TD style="WIDTH: 423px" align="center"><asp:textbox id="s" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="155px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="t" onblur="testisNum(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="72px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="u" onblur="NumAndSum(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="v" onblur="NumAndSum2(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="w" onblur="NumAndSum3(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px" align="center">3</TD>
								<TD style="WIDTH: 563px" align="center"><asp:textbox id="x" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="355px"></asp:textbox></TD>
								<TD style="WIDTH: 423px" align="center"><asp:textbox id="y" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="155px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="z" onblur="testisNum(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="72px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="a1" onblur="NumAndSum(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="b1" onblur="NumAndSum2(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="c1" onblur="NumAndSum3(this)" runat="server" BackColor="Control" BorderStyle="None"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25px"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 563px" align="center"><FONT face="宋体">合计</FONT></TD>
								<TD style="WIDTH: 423px" align="center"><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 95px" align="center">100分</TD>
								<TD align="center"><asp:textbox id="d1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="e1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD align="center"><asp:textbox id="f1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="60px"
										AutoPostBack="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="7">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="1">
										<TR>
											<TD style="WIDTH: 34px" rowSpan="4">被考核者</TD>
											<TD rowSpan="4"><asp:textbox id="g1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="60px"></asp:textbox></TD>
											<TD rowSpan="4">计划阶段</TD>
											<TD style="HEIGHT: 22px"><FONT face="宋体">计划时间</FONT></TD>
											<TD style="HEIGHT: 22px"><asp:textbox id="h1" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="Control"
													BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></TD>
											<TD style="WIDTH: 32px" rowSpan="4">考核阶段</TD>
											<TD style="HEIGHT: 22px">考核时间</TD>
											<TD style="WIDTH: 137px; HEIGHT: 22px"><FONT face="宋体"><asp:textbox id="l1" onfocus="WdatePicker({skin:'simple'})" runat="server" BackColor="Control"
														BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></FONT></TD>
											<TD rowSpan="4">
												<P><FONT color="#ff0000">考核分数</FONT></P>
												<P><FONT color="#ff0000">调整分数</FONT></P>
											</TD>
											<TD rowSpan="4"><FONT color="#ff0000">
													<P><asp:textbox id="p1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="60px"></asp:textbox></P>
													<P><asp:textbox id="r1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="60px"></asp:textbox></P>
												</FONT>
											</TD>
										</TR>
										<TR>
											<TD><FONT face="宋体">计划审核者1</FONT></TD>
											<TD><asp:textbox id="i1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></TD>
											<TD><FONT face="宋体">考核者1</FONT></TD>
											<TD style="WIDTH: 137px"><FONT face="宋体"><asp:textbox id="m1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></FONT></TD>
										</TR>
										<TR>
											<TD>计划审核者2</TD>
											<TD style="WIDTH: 23px"><FONT face="宋体"><asp:textbox id="j1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></FONT></TD>
											<TD>考核者2</TD>
											<TD style="WIDTH: 137px"><FONT face="宋体"><asp:textbox id="n1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></FONT></TD>
										</TR>
										<TR>
											<TD>计划复核者</TD>
											<TD style="WIDTH: 23px"><FONT face="宋体"><asp:textbox id="k1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></FONT></TD>
											<TD>复核者</TD>
											<TD style="WIDTH: 137px"><asp:textbox id="o1" runat="server" BackColor="Control" BorderStyle="None" ReadOnly="True" Width="170px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="10"><FONT style="COLOR: red" face="宋体">注：1.非项目员工只需转交计划审核者1，由计划审核者转交其主管领导复核，月末考核时过程相同；</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="10"><FONT style="COLOR: red" face="宋体">&nbsp;&nbsp;&nbsp; 
													2.若项目组成员分别需要项目业务经理和项目经理审核，请首先转交给计划审核者1(项目业务经理)，由计划审核者1转交计划审核者2(项目经理)，</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="10"><FONT style="COLOR: red" face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
													月末考核时过程相同，考核者2可以直接修改考核者1的考核结果；</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="10"><FONT style="COLOR: red" face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;3.若项目组成员本身岗位为项目业务经理，只需转交计划审核者1(项目经理)，由计划审核者1转交项目组成员所在部门负责人复核；</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="10"><FONT style="COLOR: red" face="宋体">&nbsp;&nbsp;&nbsp; 
													4.请随时保存月工作计划内容，防止页面时间过长导致页面失效。</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="10"><FONT style="COLOR: red" face="宋体">&nbsp;&nbsp;&nbsp; 
													5.如果退回给被考核者，可以在签名框中填写退回意见；</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="10"><FONT style="COLOR: red" face="宋体">&nbsp;&nbsp;&nbsp; 
													6.调整分数：部门长审核部门员工的考核结果汇总时，会根据公司人事规定(部门内部绩效系数超过1.0的比例不超过20%)整体上进行适当调整。</FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD vAlign="middle" align="center" colSpan="7"><asp:button id="btnSubmit" runat="server" CssClass="input4" Text="提交"></asp:button>
						<asp:button id="btnSave" runat="server" CssClass="input4" Text="保存"></asp:button><asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
