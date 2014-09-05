<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_jxkhjx3.aspx.cs" Inherits="Stoke.USL.Staff.style_jxkhjx3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_jxkhjx3</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
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
		function NumAndSum(object)//导师填写考核结果时验证
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
				
			var s12 =document.getElementById("k").value;
			if(s12!="")
				s1 = parseFloat(s1) + parseFloat(s12);

			var s13 =document.getElementById("m").value;
			if(s13!="")
				s1 = parseFloat(s1) + parseFloat(s13);

			var s14 =document.getElementById("o").value;
			if(s14!="")
				s1 = parseFloat(s1) + parseFloat(s14);

			var s15 =document.getElementById("q").value;
			if(s15!="")
				s1 = parseFloat(s1) + parseFloat(s15);

			var s16 =document.getElementById("s").value;
			if(s16!="")
				s1 = parseFloat(s1) + parseFloat(s16);

			var s17 =document.getElementById("u").value;
			if(s17!="")
				s1 = parseFloat(s1) + parseFloat(s17);

			var s18 =document.getElementById("w").value;
			if(s18!="")
				s1 = parseFloat(s1) + parseFloat(s18);

			var s19 =document.getElementById("y").value;
			if(s19!="")
				s1 = parseFloat(s1) + parseFloat(s19);

			
			document.getElementById("a1").value = s1;			
		}
		
		function NumAndSum2(object)//部长填写考核结果时验证
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
				
			var s12 =document.getElementById("l").value;
			if(s12!="")
				s1 = parseFloat(s1) + parseFloat(s12);

			var s13 =document.getElementById("n").value;
			if(s13!="")
				s1 = parseFloat(s1) + parseFloat(s13);

			var s14 =document.getElementById("p").value;
			if(s14!="")
				s1 = parseFloat(s1) + parseFloat(s14);

			var s15 =document.getElementById("r").value;
			if(s15!="")
				s1 = parseFloat(s1) + parseFloat(s15);

			var s16 =document.getElementById("t").value;
			if(s16!="")
				s1 = parseFloat(s1) + parseFloat(s16);

			var s17 =document.getElementById("v").value;
			if(s17!="")
				s1 = parseFloat(s1) + parseFloat(s17);

			var s18 =document.getElementById("x").value;
			if(s18!="")
				s1 = parseFloat(s1) + parseFloat(s18);

			var s19 =document.getElementById("z").value;
			if(s19!="")
				s1 = parseFloat(s1) + parseFloat(s19);

			
			document.getElementById("b1").value = s1;			
		}
		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="815" align="center" border="0" style="border-collapse: collapse;">
				<tr>
					<TD>
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="296" border="0">
							<TR>
								<TD style="WIDTH: 91px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          ><asp:linkbutton id="zp" runat="server" ForeColor="White" CssClass="Newbutton" CausesValidation="False">自我评价意见表</asp:linkbutton></TD>
								<TD style="WIDTH: 60px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          ><asp:linkbutton id="zq" runat="server" ForeColor="White" CssClass="Newbutton" CausesValidation="False">工作小结</asp:linkbutton></TD>
								<TD style="WIDTH: 69px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>.gif' 
          ><asp:linkbutton id="zdp" runat="server" ForeColor="White" CssClass="Newbutton" CausesValidation="False">绩效评估表</asp:linkbutton></TD>
								<TD style="WIDTH: 65px" 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>.gif' 
          ><asp:linkbutton id="zs" runat="server" ForeColor="White" CssClass="Newbutton">转正审批表</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<TR>
					<TD style="WIDTH: 771px; HEIGHT: 23px" vAlign="middle" align="center"><B><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="mso-bidi-font-weight: bold"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 18pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><FONT size="4">见习、<SPAN style="mso-bidi-font-weight: bold">试用期员工绩效评估表</SPAN></FONT></SPAN></B></SPAN></SPAN></B></SPAN></B></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 771px; HEIGHT: 23px" vAlign="middle" align="center"><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">&nbsp;<SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">（</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-bidi-font-weight: bold">指导老师和部长评价时均用此表</SPAN><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">）</SPAN>
						</SPAN>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 771px; HEIGHT: 6px" vAlign="middle" align="left"><SPAN style="FONT-SIZE: 14pt; FONT-FAMILY: 宋体; mso-bidi-font-family: 宋体; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</STRONG>
							<STRONG><FONT size="3">评价对象</FONT></STRONG></SPAN></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD style="FONT-SIZE: 10.5pt; WIDTH: 65px" align="left" colSpan="9">被评价人</TD>
								<TD style="WIDTH: 113px" align="left"><asp:textbox id="e" runat="server" ReadOnly="True" Width="138px" BackColor="WhiteSmoke"></asp:textbox></TD>
								<TD style="FONT-SIZE: 10.5pt; WIDTH: 127px" align="left">部门（项目组）</TD>
								<TD style="WIDTH: 160px" align="left"><asp:dropdownlist id="g" runat="server" Width="154px" BackColor="WhiteSmoke" Enabled="False"></asp:dropdownlist></TD>
								<TD style="FONT-SIZE: 10.5pt; WIDTH: 62px" align="left">岗位</TD>
								<TD align="left"><FONT face="宋体"><asp:dropdownlist id="h" runat="server" Width="154px" BackColor="WhiteSmoke" Enabled="False"></asp:dropdownlist></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<P><FONT face="宋体" size="2"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<FONT size="3">评价内容</FONT></STRONG></FONT></P>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="1" style="border-collapse: collapse;">
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 25px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">评价类别</SPAN></B></TD>
								<TD style="WIDTH: 320px; HEIGHT: 25px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">评价要点</SPAN></B></TD>
								<TD style="WIDTH: 30px; HEIGHT: 25px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">分值</SPAN></B></TD>
								<TD style="WIDTH: 150px; HEIGHT: 25px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">分数（指导老师评）</SPAN></B></TD>
								<TD style="HEIGHT: 25px"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">分数（部长评）</SPAN></B></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 66px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">1</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">价值观态度</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 66px" colSpan="2"><TABLE id="Table17" cellSpacing="0" cellPadding="0" width="432" border="0">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">完全认同公司文化及其倡导的主流价值观，并能付诸实践；</SPAN></TD>
											<TD>10-15</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">基本认同公司文化及其倡导的主流价值观，偶尔会有偏差；</SPAN></TD>
											<TD>5-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">不认同公司文化、价值观，并有明显抵制心理</SPAN></TD>
											<TD>0-5</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 66px" align="center"><asp:textbox id="i" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"></asp:textbox><asp:requiredfieldvalidator id="re2" runat="server" Width="64px" ControlToValidate="i" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se1" runat="server" ControlToValidate="i" ErrorMessage="范围在0-15" Type="Integer"
										MaximumValue="15" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 66px"><asp:textbox id="j" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we2" runat="server" Width="48px" ControlToValidate="j" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te1" runat="server" ControlToValidate="j" ErrorMessage="范围在0-15" Type="Integer"
										MaximumValue="15" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 51px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">2</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">工作业绩</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 51px" colSpan="2"><TABLE id="Table18" cellSpacing="0" cellPadding="0" width="432" border="0">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">能够较好地完成试用期工作任务并达到期望目标，极少出错；</SPAN></SPAN></TD>
											<TD>10-15</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">尚能努力使工作达到目标要求，偶尔出错</SPAN></SPAN></TD>
											<TD>5-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">因个人原因导致工作有重大失误</SPAN></SPAN></TD>
											<TD>0-5</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 51px"><asp:textbox id="k" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"></asp:textbox><asp:requiredfieldvalidator id="re4" runat="server" Width="64px" ControlToValidate="k" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se2" runat="server" ControlToValidate="k" ErrorMessage="范围在0-15" Type="Integer"
										MaximumValue="15" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 51px"><asp:textbox id="l" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we4" runat="server" Width="49px" ControlToValidate="l" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te2" runat="server" ControlToValidate="l" ErrorMessage="范围在0-15" Type="Integer"
										MaximumValue="15" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 60px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">3</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">工作能力</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 60px" colSpan="2"><TABLE id="Table19" cellSpacing="0" cellPadding="0" width="432" border="0">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">高效率、高质量地完成试用期工作任务，可独立承担完成工作</SPAN></SPAN></SPAN></TD>
											<TD>5-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">工作效率一般，需要经常指导和帮助</SPAN></SPAN></SPAN></TD>
											<TD>2-6</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">工作效率差，难以承担并完成所授予的工作</SPAN></TD>
											<TD>0-2</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 60px"><asp:textbox id="m" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"></asp:textbox><asp:requiredfieldvalidator id="re6" runat="server" Width="64px" ControlToValidate="m" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se3" runat="server" ControlToValidate="m" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 60px"><asp:textbox id="n" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we6" runat="server" Width="48px" ControlToValidate="n" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te3" runat="server" ControlToValidate="n" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 64px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">4</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">专业知识</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 64px" colSpan="2"><TABLE id="Table20" cellSpacing="0" cellPadding="0" width="432" border="0" style="border-collapse: collapse;">
										<TR>
											<TD style="WIDTH: 389px; HEIGHT: 4px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">有丰富专业知识并能充分发挥和灵活运用到实际工作中</SPAN></SPAN></SPAN></SPAN></TD>
											<TD style="HEIGHT: 4px">6-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">有一般的专业知识，能符合工作需要</SPAN></SPAN></SPAN></SPAN></TD>
											<TD>2-6</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">专业知识不足，影响工作进展</SPAN></SPAN></TD>
											<TD>0-2</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 64px"><asp:textbox id="o" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="re8" runat="server" Width="64px" ControlToValidate="o" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se4" runat="server" ControlToValidate="o" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 64px"><asp:textbox id="p" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we8" runat="server" Width="49px" ControlToValidate="p" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te4" runat="server" ControlToValidate="p" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 53px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">5</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">学习能力</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 53px" colSpan="2"><TABLE id="Table21" cellSpacing="0" cellPadding="0" width="432" border="0">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">对新的任务上手速度快并能不断创新</SPAN>作</SPAN></SPAN></SPAN></TD>
											<TD>6-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">针对工作偶尔能够提出建设性意见</SPAN></SPAN></SPAN></SPAN></TD>
											<TD>2-6</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">提出其欠缺后改进速度慢</SPAN></SPAN></TD>
											<TD>0-2</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 53px"><asp:textbox id="q" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="re10" runat="server" Width="64px" ControlToValidate="q" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se5" runat="server" ControlToValidate="q" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 53px"><asp:textbox id="r" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we10" runat="server" Width="49px" ControlToValidate="r" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te5" runat="server" ControlToValidate="r" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 58px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">6</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">创新能力</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 58px" colSpan="2"><TABLE id="Table22" cellSpacing="0" cellPadding="0" width="432" border="0">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">思路清晰，对工作任务可提出周密的策划方案并卓有成效</SPAN></SPAN></SPAN></SPAN></TD>
											<TD>6-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">有一定思路，能提出创新见解</SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>2-6</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">只能按照既定程序开展工作，缺乏创新思路</SPAN></SPAN></SPAN></TD>
											<TD>0-2</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 58px"><asp:textbox id="s" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="re12" runat="server" Width="64px" ControlToValidate="s" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se6" runat="server" ControlToValidate="s" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 58px"><asp:textbox id="t" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we12" runat="server" Width="49px" ControlToValidate="t" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te6" runat="server" ControlToValidate="t" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 77px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">7</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">合作精神</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 77px" colSpan="2"><TABLE id="Table23" cellSpacing="0" cellPadding="0" width="432" border="0" style="border-collapse: collapse;">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">善于合作和帮助他人并积极协助配合他人实现工作目标</SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>6-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">具备与他人交往的能力，能维持一般合作关系</SPAN></SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>2-6</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">缺乏合作精神，不能协同好个人目标和整体目标</SPAN></SPAN></SPAN></SPAN></TD>
											<TD>0-2</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 77px"><asp:textbox id="u" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="re14" runat="server" Width="64px" ControlToValidate="u" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se7" runat="server" ControlToValidate="u" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 77px"><asp:textbox id="v" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we14" runat="server" Width="48px" ControlToValidate="v" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te7" runat="server" ControlToValidate="v" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 55px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">8</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">工作态度</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 55px" colSpan="2"><TABLE id="Table24" cellSpacing="0" cellPadding="0" width="432" border="0" style="border-collapse: collapse;">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">对工作积极主动，富有激情，有进取精神</SPAN></SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>6-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px; HEIGHT: 6px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">安心本职工作，只做好份内任务</SPAN></SPAN></SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD style="HEIGHT: 6px">2-6</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">缺乏热情，得过且过</SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>0-2</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 55px"><asp:textbox id="w" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="re16" runat="server" Width="64px" ControlToValidate="w" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se8" runat="server" ControlToValidate="w" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 55px"><asp:textbox id="x" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we16" runat="server" Width="48px" ControlToValidate="x" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te8" runat="server" ControlToValidate="x" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 80px; HEIGHT: 70px"><SPAN lang="EN-US" style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">9</SPAN><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">工作纪律</SPAN></TD>
								<TD style="WIDTH: 380px; HEIGHT: 70px" colSpan="2"><TABLE id="Table25" cellSpacing="0" cellPadding="0" width="432" border="0" style="border-collapse: collapse;">
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">严格要求自己，能自觉遵守公司各项规章制度、无迟到早退</SPAN></SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>6-10</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">有时违反公司纪律，但能及时纠正</SPAN></SPAN></SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>2-6</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 389px"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"><SPAN style="FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA">经常违反公司纪律、工作制度，造成恶劣影响</SPAN></SPAN></SPAN></SPAN></SPAN></TD>
											<TD>0-2</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 126px; HEIGHT: 70px"><asp:textbox id="y" onblur="NumAndSum(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="re18" runat="server" Width="64px" ControlToValidate="y" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="se9" runat="server" ControlToValidate="y" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
								<TD style="HEIGHT: 70px"><asp:textbox id="z" onblur="NumAndSum2(this)" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke"
										AutoPostBack="False"></asp:textbox><asp:requiredfieldvalidator id="we18" runat="server" Width="49px" ControlToValidate="z" ErrorMessage="不能为空"></asp:requiredfieldvalidator><asp:rangevalidator id="te9" runat="server" ControlToValidate="z" ErrorMessage="范围在0-10" Type="Integer"
										MaximumValue="10" MinimumValue="0"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bolder; FONT-SIZE: 10.5pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-bidi-font-family: 'Times New Roman'; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA"
									align="center" colSpan="3">综合得分</TD>
								<TD style="WIDTH: 126px"><asp:textbox id="a1" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke" AutoPostBack="False"></asp:textbox></TD>
								<TD><asp:textbox id="b1" runat="server" ReadOnly="True" Width="56px" BackColor="WhiteSmoke" AutoPostBack="False"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="776" border="0" style="border-collapse: collapse;">
							<TR>
								<TD><FONT face="宋体"><FONT face="宋体">评价人：&nbsp; 指导老师
											<asp:textbox id="f" runat="server" ReadOnly="True" Width="104px" BackColor="WhiteSmoke"></asp:textbox>部长
											<asp:textbox id="c1" runat="server" ReadOnly="True" Width="104px" BackColor="WhiteSmoke"></asp:textbox></FONT></FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</FONT>
									<asp:button id="btnSave" runat="server" CssClass="input4" Text="提交" Visible="False"></asp:button><FONT face="宋体">&nbsp;&nbsp;
									</FONT>
									<asp:button id="btnCancel" runat="server" CssClass="input4" Text="返回"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
