<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Work_RoleSet.aspx.cs" Inherits="Stoke.USL.Workflow.Work_RoleSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Work_RoleSet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 10px; border-collapse:collapse;" cellSpacing="0"
				cellPadding="0" width="300" border="1">
				<TR>
					<TD style="HEIGHT: 244px">
						<TABLE id="Table1" style="WIDTH: 800px; HEIGHT: 23px; border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="800"
							border="1">
							<TR>
								<TD style="WIDTH: 100px" align="center"><FONT face="宋体">部门</FONT></TD>
								<TD style="WIDTH: 160px" align="center"><asp:dropdownlist id="DepDdl" Runat="server" Width="140px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 100px" align="center"><FONT face="宋体">类别</FONT></TD>
								<TD style="WIDTH: 140px" align="center"><asp:dropdownlist id="DropDownList1" runat="server" Width="120px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 100px" align="center"><FONT face="宋体">工作流</FONT></TD>
								<TD style="WIDTH: 220px" align="center"><asp:dropdownlist id="DropDownList2" runat="server" Width="200px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" style="WIDTH: 800px; HEIGHT: 70px; border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="800"
							border="1">
							<TR>
								<TD style="WIDTH: 100px" align="center">工作流步骤</TD>
								<TD style="WIDTH: 704px" align="center"><FONT face="宋体"><asp:radiobuttonlist id="RadioButtonList1" runat="server" Width="680" AutoPostBack="True" RepeatColumns="3"></asp:radiobuttonlist></FONT></TD>
							</TR>
						</TABLE>
						<TABLE id="Table6" style="WIDTH: 800px; HEIGHT: 129px; border-collapse:collapse;" cellSpacing="0" cellPadding="0"
							width="800" border="1">
							<TR>
								<TD style="WIDTH: 100px" align="center"><asp:checkbox id="CheckBox4" runat="server" AutoPostBack="True" Text="全选"></asp:checkbox></TD>
								<TD style="WIDTH: 704px" align="center"><FONT face="宋体"><asp:checkboxlist id="CheckBoxList1" runat="server" Width="680px" RepeatColumns="6"></asp:checkboxlist></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				<TR>
					<TD>
						<TABLE id="Table3" style="WIDTH: 792px; HEIGHT: 21px; border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="792"
							border="0">
							<TR>
								<TD align="center"><asp:button id="Button2" runat="server" Width="89px" Text="修改" CssClass="input4"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<TABLE style="display:none; HEIGHT: 24px" borderColor="#111111" height="24" cellSpacing="0" cellPadding="0"
				width="800" border="0">
				<TR height="30">
					<TD class="GbText" align="right" width="20" background='bgColor="#c0d9e6"'><IMG src="../../images/icon/277.GIF"></TD>
					<TD class="GbText" style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						vAlign="middle" align="center" width="800" background="../../Images/treetopbg.jpg"
						bgColor="#e8f4ff">工作流人员设置</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
