<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SlctMember.ascx.cs" Inherits="Stoke.COMMON.SlctMember" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<LINK href="../css/css.css" type="text/css" rel="stylesheet">
<P><FONT id="FONT1" face="宋体" runat="server">
		<TABLE id="Table1" style="WIDTH: 311px; HEIGHT: 8px" cellSpacing="0" cellPadding="0" width="311"
			align="center" bgColor="inactivecaption" border="0">
			<TR>
				<TD vAlign="top" align="center">
					<TABLE id="Table5" style="WIDTH: 261px" cellSpacing="0" cellPadding="0" width="261" border="0">
						<TR>
							<TD align="right"><asp:label id="Label4" runat="server" Font-Size="10pt">是否使用收藏夹:</asp:label>&nbsp;</TD>
							<TD style="WIDTH: 52px"><asp:radiobutton id="RadioButton1" runat="server" Font-Size="10pt" AutoPostBack="True" GroupName="1"
									Text="是" OnCheckedChanged="RadioButton1_CheckedChanged"></asp:radiobutton></TD>
							<TD><asp:radiobutton id="RadioButton2" runat="server" Font-Size="10pt" AutoPostBack="True" GroupName="1"
									Text="否"></asp:radiobutton></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD vAlign="top" align="center">
					<TABLE id="Table3" style="HEIGHT: 128px" cellSpacing="0" cellPadding="0" width="310" border="0"
						runat="server">
						<TR>
							<TD style="WIDTH: 167px" vAlign="top" align="left"><asp:listbox id="FolderLb" runat="server" Font-Size="X-Small" AutoPostBack="True" Width="160px"
									Height="120px" OnSelectedIndexChanged="FolderLb_SelectedIndexChanged1"></asp:listbox></TD>
							<TD vAlign="top" align="right">
								<TABLE id="Table4" style="WIDTH: 131px" cellSpacing="0" cellPadding="0" width="131" border="0">
									<TR>
										<TD vAlign="top"><asp:listbox id="ContainRyLb" runat="server" Font-Size="X-Small" Width="132px" Height="88px"
												SelectionMode="Multiple"></asp:listbox></TD>
									</TR>
									<TR>
										<TD>
											<P align="center"><asp:button id="submitBtn" runat="server" Text="选择" Width="49px" CssClass="input4 " CausesValidation="False" OnClick="submitBtn_Click1"></asp:button>&nbsp;&nbsp;
												<asp:button id="cancelBtn" runat="server" Text="取消" Width="50px" CssClass="input4 " CausesValidation="False" OnClick="cancelBtn_Click"></asp:button></P>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD vAlign="top"><FONT face="宋体"><FONT face="宋体">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="310" align="center" border="0">
								<TR>
									<TD align="center" width="100%" colSpan="3"><asp:label id="Label3" runat="server" Font-Size="10pt">姓名:</asp:label><asp:textbox id="TextBox1" runat="server"></asp:textbox>&nbsp;&nbsp;
										<asp:button id="Button1" runat="server" Text="模糊查询" CssClass="input4 " CausesValidation="False" OnClick="Button1_Click1"></asp:button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 149px; HEIGHT: 2px" align="center"><asp:dropdownlist id="DropDownList1" runat="server" Font-Size="X-Small" AutoPostBack="True" Width="132px"
											CssClass="input4" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1"></asp:dropdownlist></TD>
									<TD style="WIDTH: 42px; HEIGHT: 2px" align="center"><FONT face="宋体"></FONT></TD>
									<TD style="HEIGHT: 2px" align="center"><asp:dropdownlist id="DropDownList2" runat="server" Font-Size="X-Small" AutoPostBack="True" Width="132px"
											CssClass="input4" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 149px; HEIGHT: 121px" align="center"><FONT face="宋体"><asp:listbox id="LB_All" runat="server" Font-Size="X-Small" Width="132px" Height="120px" SelectionMode="Multiple"></asp:listbox></FONT></TD>
									<TD style="WIDTH: 42px; HEIGHT: 121px" align="center">
										<P><FONT face="宋体"><asp:button id="Button4" runat="server" Text=">>" Width="40px" CssClass="input4" CausesValidation="False" OnClick="Button4_Click1"></asp:button></FONT></P>
										<P><FONT face="宋体"></FONT><asp:button id="Button5" runat="server" Text="<<" Width="40px" CssClass="input4" CausesValidation="False" OnClick="Button5_Click1"></asp:button></P>
									</TD>
									<TD style="HEIGHT: 121px" align="center"><asp:listbox id="LB_Select" runat="server" Font-Size="X-Small" Width="132px" Height="120px" SelectionMode="Multiple"></asp:listbox></TD>
								</TR>
							</TABLE>
						</FONT></FONT>
				</TD>
			</TR>
		</TABLE>
	</FONT>
</P>
