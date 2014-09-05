<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Work_rights.aspx.cs" Inherits="Stoke.USL.Workflow.Work_rights" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Work_rights</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 104; LEFT: 0px; POSITION: absolute; border-collapse:collapse;" cellSpacing="0"
				cellPadding="0" width="300" border="0">
				<TR>
					<TD style="HEIGHT: 19px">
						<FIELDSET id="fieldset2" style="WIDTH: 729px; " runat="server"><LEGEND>多人权限设置</LEGEND>
							<TABLE id="Table4" style="WIDTH: 792px; HEIGHT: 173px; border-collapse:collapse;" cellSpacing="0" cellPadding="0"
								width="792" border="0">
								<TR>
									<TD align="left">
										<TABLE id="Table5" style="WIDTH: 792px; HEIGHT: 154px" cellSpacing="0" cellPadding="0"
											width="792" border="0">
											<TR>
												<TD style="HEIGHT: 6px" align="center">
													<asp:label id="Label1" runat="server">请选择操作对象</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 6px" align="center">
													<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100" border="1">
														<TR>
															<TD>
																<uc1:SlctMember id="SlctMember1" runat="server"></uc1:SlctMember></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:button id="Button1" runat="server" CssClass="input4" Width="100px" Text="确定"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center">
													<TABLE id="Table6" style="WIDTH: 797px; HEIGHT: 23px; border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="797"
														border="1">
														<TR>
															<TD style="WIDTH: 133px" align="center"><FONT face="宋体">已选人员:</FONT></TD>
															<TD align="left">
																<P>
																	<asp:label id="obj" runat="server">无</asp:label></P>
																<P>&nbsp;</P>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">
							<TABLE id="Table1" style="WIDTH: 800px; border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="800"
								border="1">
								<TR>
									<TD style="WIDTH: 133px" align="center"><FONT face="宋体">权限类别</FONT></TD>
									<TD style="WIDTH: 145px" align="center">
										<asp:DropDownList id="DropDownList1" runat="server" AutoPostBack="True" Width="106px">
											<asp:ListItem Value="公文管理">公文管理</asp:ListItem>
											<asp:ListItem Value="人事管理">人事管理</asp:ListItem>
											<asp:ListItem Value="行政管理">行政管理</asp:ListItem>
										</asp:DropDownList></TD>
									<TD align="center"><FONT face="宋体">权限名称</FONT></TD>
									<TD style="WIDTH: 149px" align="center">
										<asp:DropDownList id="DropDownList2" runat="server" Width="115px"></asp:DropDownList></TD>
									<TD align="center"><FONT face="宋体">权限修改</FONT></TD>
									<TD align="center">
										<asp:DropDownList id="DropDownList3" runat="server" Width="110px">
											<asp:ListItem Value="1">可用</asp:ListItem>
											<asp:ListItem Value="0">不可用</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" style="WIDTH: 800px; HEIGHT: 21px" cellSpacing="0" cellPadding="0" width="800"
							border="0">
							<TR>
								<TD align="center">
									<P>&nbsp;</P>
									<P>
										<asp:Button id="Button2" runat="server" CssClass="input4" Width="89px" Text="修改"></asp:Button></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<TABLE style=" display:none; HEIGHT: 24px" borderColor="#111111" height="24" cellSpacing="0" cellPadding="0"
				width="800" border="0">
				<TR height="30">
					<TD class="GbText" align="right" width="20" background='bgColor="#c0d9e6"'><IMG src="../../images/icon/277.GIF"></TD>
					<TD class="GbText" style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						vAlign="middle" align="center" width="800" background="../../Images/treetopbg.jpg"
						bgColor="#e8f4ff">多人权限设置</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
