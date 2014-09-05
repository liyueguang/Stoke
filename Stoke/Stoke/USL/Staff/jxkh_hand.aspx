<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jxkh_hand.aspx.cs" Inherits="Stoke.USL.Staff.jxkh_hand" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>jxkh_hand</title>
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
		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" style="LEFT: 272px; POSITION: absolute; TOP: 168px" cellSpacing="0"
				cellPadding="0" width="166" bgColor="#ffffff" border="1" runat="server">
				<tr>
					<td>
						<uc1:SlctMember id="SlctMember1" runat="server"></uc1:SlctMember></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 0px" align="center"><asp:button id="btnBack" runat="server" Width="66px" Text="确定" CssClass="input4"></asp:button><asp:button id="Button3" runat="server" Width="66px" Text="关闭" CssClass="input4"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 32px" align="center"><B style="mso-bidi-font-weight: normal"><SPAN lang="EN-US" style="FONT-SIZE: 16pt; FONT-FAMILY: 仿宋_GB2312; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt">绩效考核手工录入</SPAN></B></TD>
				</TR>
				<tr>
					<td align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="600" border="0">
							<TR>
								<TD width="20%">选择部门</TD>
								<TD style="WIDTH: 152px; HEIGHT: 12px" width="152"><asp:dropdownlist id="ddlBm" runat="server" Width="120px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 12px" align="center" width="100">考核日期</TD>
								<TD style="HEIGHT: 12px" align="left" width="150"><asp:dropdownlist id="ddlNf" runat="server" Width="55px"></asp:dropdownlist><FONT face="宋体">&nbsp;
									</FONT>
									<asp:dropdownlist id="ddlYf" runat="server" Width="55px">
										<asp:ListItem Value="月份">月份</asp:ListItem>
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
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 12px" colSpan="2"><FONT face="宋体"><asp:button id="btnSearch" runat="server" Text="查询" CssClass="input4"></asp:button></FONT></TD>
							</TR>
							<TR id="tr2" runat="server">
								<TD align="left" width="100">职工姓名</TD>
								<TD align="left" width="150">
									<asp:DropDownList id="ddlXm" runat="server" Width="120px" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD>
								<TD align="center" width="100">职工编号</TD>
								<TD style="WIDTH: 152px"><asp:textbox id="txtZgbh" runat="server" Width="120px" ReadOnly="True" Enabled="False"></asp:textbox>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="数字" ControlToValidate="txtZgbh"
										ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator></TD>
								<TD colSpan="2"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR id="tr3" runat="server">
								<TD>自评分数<FONT style="COLOR: red">(选填)</FONT></TD>
								<TD style="WIDTH: 152px"><asp:textbox id="txtZp" onblur="testisNum(this)" runat="server" Width="120px"></asp:textbox></FONT></TD>
								<TD align="center">复核分数</TD>
								<TD><FONT face="宋体"><asp:textbox id="txtFh" onblur="testisNum(this)" runat="server" Width="120px"></asp:textbox></FONT></TD>
								<TD align="left" colSpan="2"><asp:button id="btnAdd" runat="server" Text="添加" CssClass="input4"></asp:button></TD>
							</TR>
							<TR>
								<TD height="25">批量添加</TD>
								<TD height="25" style="WIDTH: 152px"><asp:linkbutton id="lbtnAdd" runat="server">选择人员</asp:linkbutton></TD>
								<TD align="center" height="25"></TD>
								<TD height="25"></TD>
								<TD align="left" colSpan="2" height="25"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<td><asp:datagrid id="dgJxkh" runat="server" Width="100%" PageSize="14" AutoGenerateColumns="False">
							<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="jxkh_id" ReadOnly="True" HeaderText="编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_zgbh" ReadOnly="True" HeaderText="职号"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_xm" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_zp" ReadOnly="True" HeaderText="自评分数"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_zf" HeaderText="复核分数"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_xs" ReadOnly="True" HeaderText="绩效系数"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_tjzt" ReadOnly="True" HeaderText="提交状态"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="确定" HeaderText="修改" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Visible="False" HorizontalAlign="Right" BackColor="#F3F5FA"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<TR>
					<TD vAlign="middle" align="center"><asp:button id="btnSave" runat="server" Text="提交" CssClass="input4"></asp:button></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left"><FONT style="COLOR: red" face="宋体">注：提交之后，员工绩效考核结果将不可以修改！</FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
