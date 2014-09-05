<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style_jxkhhz.aspx.cs" Inherits="Stoke.USL.Staff.style_jxkhhz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>style_jxkhhz</title>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR style="display: none;">
					<TD align="center" colSpan="6"><B style="mso-bidi-font-weight: normal"><SPAN style="FONT-SIZE: 15pt; FONT-FAMILY: 宋体; mso-bidi-font-size: 12.0pt; mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt">大连船舶重工海洋工程公司</SPAN></B></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="6"><B style="mso-bidi-font-weight: normal"><SPAN lang="EN-US" style="FONT-SIZE: 16pt; FONT-FAMILY: 仿宋_GB2312; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt"><asp:dropdownlist id="a" runat="server" Width="55px" Enabled="False" BackColor="Control"></asp:dropdownlist>年
								<asp:dropdownlist id="b" runat="server" Width="48px" Enabled="False" BackColor="Control">
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
								</asp:dropdownlist>月
								<asp:dropdownlist id="c" runat="server" Width="120px" Enabled="False" BackColor="Control" Visible="False"
									AutoPostBack="True"></asp:dropdownlist>绩效考核汇总表</SPAN></B></TD>
				</TR>
				<tr>
					<td colSpan="6">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR id="tr1" runat="server">
								<TD width="100" style="HEIGHT: 4px">选择级别</TD>
								<TD style="HEIGHT: 4px" width="150"><asp:dropdownlist id="h" runat="server" Width="120px" AutoPostBack="True">
										<asp:ListItem Value="0">-请选择-</asp:ListItem>
										<asp:ListItem Value="1">部长级及以上</asp:ListItem>
										<asp:ListItem Value="2">部长级以下</asp:ListItem>
									</asp:dropdownlist></TD>
								<td style="HEIGHT: 4px" colSpan="4"><FONT face="宋体"><asp:button id="btnSearch" runat="server" Text="查询" CssClass="input4"></asp:button></FONT></td>
							</TR>
							<TR id="tr2" runat="server">
								<TD align="left" width="100">职工姓名</TD>
								<TD align="left" width="150">
									<asp:DropDownList id="ddlXm" runat="server" Width="120px" AutoPostBack="True" Enabled="False"></asp:DropDownList></TD>
								<TD>职工编号</TD>
								<TD><asp:textbox id="txtZgbh" runat="server" Width="120px" Enabled="False" ReadOnly="True"></asp:textbox>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="数字" ControlToValidate="txtZgbh"
										ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator></TD>
								<TD colSpan="2"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR id="tr3" runat="server">
								<TD width="100">自评分数<FONT style="COLOR: red">(选填)</FONT></TD>
								<TD width="150"><asp:textbox id="txtZp" onblur="testisNum(this)" runat="server" Width="120px"></asp:textbox></FONT></TD>
								<TD width="100">复核分数</TD>
								<TD width="150"><FONT face="宋体"><asp:textbox id="txtFh" onblur="testisNum(this)" runat="server" Width="120px"></asp:textbox></FONT></TD>
								<TD align="left" colSpan="2"><asp:button id="btnAdd" runat="server" Text="添加" CssClass="input4"></asp:button></TD>
							</TR>
							<TR id="tr4" runat="server">
								<TD width="100">排序方式</TD>
								<TD width="150"><asp:dropdownlist id="ddlPxfs" runat="server" Width="120px" AutoPostBack="True">
										<asp:ListItem Value="1">职工编号</asp:ListItem>
										<asp:ListItem Value="2">绩效系数</asp:ListItem>
										<asp:ListItem Value="3">聘用类型</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD><FONT face="宋体"></FONT></TD>
								<TD><FONT face="宋体"></FONT></TD>
								<TD align="left" colSpan="2"><FONT face="宋体"></FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<td colSpan="6">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colSpan="2"><FONT face="宋体"><asp:label id="labUnfound" runat="server"></asp:label></FONT></td>
							</tr>
							<TR>
								<TD colSpan="2"><asp:label id="labPer" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<TD vAlign="top" align="center"><asp:datagrid id="dgJxkh" runat="server" Width="100%" PageSize="12" AutoGenerateColumns="False">
										<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="编号">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemTemplate>
													<%#Container.ItemIndex+1%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="jxkh_id" ReadOnly="True" HeaderText="编号"></asp:BoundColumn>
											<asp:BoundColumn DataField="jxkh_zgbh" ReadOnly="True" HeaderText="职号"></asp:BoundColumn>
											<asp:BoundColumn DataField="jxkh_xm" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
											<asp:BoundColumn DataField="jxkh_pylx" ReadOnly="True" HeaderText="聘用类型"></asp:BoundColumn>
											<asp:BoundColumn DataField="jxkh_zp" ReadOnly="True" HeaderText="自评分数"></asp:BoundColumn>
											<asp:BoundColumn DataField="jxkh_zf" ReadOnly="True" HeaderText="复核分数"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="jxkh_xs" ReadOnly="True" HeaderText="绩效系数"></asp:BoundColumn>
											<asp:BoundColumn DataField="jxkh_zf" HeaderText="部门复核/审定"></asp:BoundColumn>
											<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="确定" HeaderText="操作" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
											<asp:BoundColumn Visible="False" DataField="docid" ReadOnly="True"></asp:BoundColumn>
										</Columns>
										<PagerStyle VerticalAlign="Middle" Visible="False" HorizontalAlign="Right" BackColor="#F3F5FA"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
								<TD align="center"><asp:datagrid id="dgJxxs" runat="server" Width="100%" PageSize="12" AutoGenerateColumns="False">
										<AlternatingItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="jxkh_id" ReadOnly="True" HeaderText="编号"></asp:BoundColumn>
											<asp:BoundColumn DataField="jxkh_xs" ReadOnly="True" HeaderText="绩效系数"></asp:BoundColumn>
										</Columns>
										<PagerStyle VerticalAlign="Middle" HorizontalAlign="Right" BackColor="#F3F5FA" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</tr>
						</TABLE>
					</td>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" align="left" colSpan="6"><FONT style="FONT-SIZE: x-small; COLOR: red" face="宋体">其中：在职人员绩效系数总和为
							<asp:label id="i" runat="server" Enabled="False"></asp:label>，聘管类员工绩效系数总和为
							<asp:label id="j" runat="server" Enabled="False"></asp:label>，聘工类员工绩效系数总和为
							<asp:label id="k" runat="server" Enabled="False"></asp:label>，总计
							<asp:label id="l" runat="server" Enabled="False"></asp:label>。</FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center">制表时间</TD>
					<TD style="WIDTH: 92px; HEIGHT: 21px" align="center"><asp:textbox id="d" runat="server" Width="130px" Enabled="False" BackColor="Control"></asp:textbox></TD>
					<TD style="HEIGHT: 21px" align="center">考核责任者</TD>
					<TD style="WIDTH: 105px; HEIGHT: 21px" align="center"><asp:textbox id="e" runat="server" Width="130px" Enabled="False" BackColor="Control"></asp:textbox></TD>
					<TD style="HEIGHT: 21px" align="center">考核审定者</TD>
					<TD style="HEIGHT: 21px" align="center"><asp:textbox id="f" runat="server" Width="130px" Enabled="False" BackColor="Control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center" colSpan="8"><asp:button id="btnSave" runat="server" Text="提交" CssClass="input4"></asp:button><FONT face="宋体">&nbsp;</FONT>
						<asp:button id="btnCancel" runat="server" Text="返回" CssClass="input4"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
