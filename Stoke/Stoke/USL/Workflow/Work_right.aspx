<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Work_right.aspx.cs" Inherits="Stoke.USL.Workflow.Work_right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Work_right</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 896px; HEIGHT: 588px; LEFT: 0px; border-collapse:collapse;"
				cellSpacing="0" cellPadding="0" width="896" border="1">
				<TR>
					<TD style="HEIGHT: 40px" vAlign="bottom" align="center">
						<TABLE id="Table1" style="WIDTH: 896px; HEIGHT: 26px; border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="896"
							border="1">
							<TR>
								<TD style="WIDTH: 133px" align="center"><FONT face="宋体">部门</FONT></TD>
								<TD style="WIDTH: 171px" align="center"><asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True" Width="155px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 181px" align="center"><FONT face="宋体">人员</FONT></TD>
								<TD style="WIDTH: 221px" align="center"><asp:dropdownlist id="DropDownList2" runat="server" AutoPostBack="True" Width="160px"></asp:dropdownlist></TD>
								<TD align="center"><asp:button id="Button1" runat="server" Width="89px" CssClass="input4" Text="确认"></asp:button></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" style="WIDTH: 896px; HEIGHT: 14px;  border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="896"
							border="1">
							<TR>
								<TD style="WIDTH: 133px" align="center">当前操作对象</TD>
								<TD style="WIDTH: 172px" align="center">姓名</TD>
								<TD style="WIDTH: 180px" align="center"><asp:label id="lbl_name" runat="server"></asp:label></TD>
								<TD style="WIDTH: 126px" align="center">职工编号</TD>
								<TD align="center"><asp:label id="lbl_zgbh" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">
							<TABLE id="Table2" style="WIDTH: 890px; HEIGHT: 100%; border-collapse:collapse;" cellSpacing="0" cellPadding="0" width="890"
								align="center" border="1">
								<TR>
									<TD style="WIDTH: 165px; HEIGHT: 18px"><asp:checkbox id="CheckBoxGW" runat="server" AutoPostBack="True" Text="公文管理" Font-Bold="True"
											Font-Size="Larger"></asp:checkbox></TD>
									<TD style="WIDTH: 250px; HEIGHT: 18px"><asp:checkbox id="CheckBoxRS" runat="server" AutoPostBack="True" Text="人事管理" Font-Bold="True"
											Font-Size="Larger"></asp:checkbox></TD>
									<TD style="WIDTH: 236px; HEIGHT: 18px"><asp:checkbox id="CheckBoxXZ" runat="server" AutoPostBack="True" Text="行政管理" Font-Bold="True"
											Font-Size="Larger"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px; HEIGHT: 25px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox1" runat="server" Text="收文" Enabled="False"></asp:checkbox></TD>
									<TD style="WIDTH: 250px; HEIGHT: 25px">&nbsp;&nbsp;
										<asp:checkbox id="CheckBox11" runat="server" Text="请假条" Enabled="False" /></TD>
									<TD style="WIDTH: 236px; HEIGHT: 25px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox26" runat="server" Text="综合信息发布申请" Enabled="False"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox2" runat="server" Text="发文" Enabled="False"></asp:checkbox>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox12" runat="server" Text="加班申请单" Enabled="False" /></TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox14" runat="server" Text="公车请单" Enabled="False" /></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox3" runat="server" Text="公文撤销(废止)" Enabled="False"></asp:checkbox></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox13" runat="server" Text="工作日志" Enabled="False" /></TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox48" runat="server" Text="出差申请单" Enabled="False"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px; HEIGHT: 22px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox18" runat="server" Text="普通公文" Enabled="False"></asp:checkbox></TD>
									<TD style="WIDTH: 250px; HEIGHT: 22px">&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBox15" runat="server" Text="绩效考核" Enabled="False" /></TD>
									<TD style="WIDTH: 236px; HEIGHT: 22px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px; HEIGHT: 19px"></TD>
									<TD style="WIDTH: 250px; HEIGHT: 19px">&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 236px; HEIGHT: 19px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px" align="left">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 251px">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 181px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 165px"></TD>
									<TD style="WIDTH: 250px">&nbsp;&nbsp;
										</TD>
									<TD style="WIDTH: 236px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
                                <tr>
                                    <td style="width: 165px">
                                    </td>
                                    <td style="width: 250px">
                                        &nbsp;&nbsp;
					</td>
                                    <td style="width: 236px">
                                    </td>
                                </tr>
								<TR>
									<TD style="WIDTH: 165px; HEIGHT: 23px"></TD>
									<TD style="WIDTH: 250px; HEIGHT: 23px">
                                        &nbsp;&nbsp;
					</TD>
									<TD style="WIDTH: 236px; HEIGHT: 23px">&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD><FONT face="宋体"></FONT><div style="display:none;">
                        &nbsp; &nbsp;&nbsp;
					<asp:checkbox id="CheckBox16" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox17" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox19" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox20" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox21" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox22" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox23" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox24" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox25" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox27" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox28" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox29" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox30" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox31" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox46" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox47" runat="server" Text="收文" Enabled="False" />
					<asp:checkbox id="CheckBox50" runat="server" Text="收文" Enabled="False" />
										<asp:checkbox id="CheckBox4" runat="server" Width="48px" Text="请假" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox5" runat="server" Text="销假" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox6" runat="server" Text="调离" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox7" runat="server" Text="调动" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox8" runat="server" Text="入职" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox9" runat="server" Text="增员指标" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox10" runat="server" Text="求职录用" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBoxCW" runat="server" AutoPostBack="True" Text="财务管理" Font-Bold="True"
											Font-Size="Larger"></asp:checkbox>
                        <asp:checkbox id="CheckBox32" runat="server" Text="支票预借审批" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox33" runat="server" Text="出差审批" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox34" runat="server" Text="资金支出审批" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox45" runat="server" Text="出差申请" Enabled="False"></asp:checkbox>&nbsp;
                        <asp:checkbox id="CheckBox49" runat="server" Text="现金预借" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox41" runat="server" Text="部门资金滚动计划" Enabled="False"></asp:checkbox>
										<asp:checkbox id="CheckBox42" runat="server" Text="公司资金计划汇总" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox35" runat="server" Text="人事通知单" Enabled="False"></asp:checkbox>
                        <asp:checkbox id="CheckBox36" runat="server" Text="管理技术类绩效考核" Enabled="False"></asp:checkbox>
										<asp:checkbox id="CheckBox37" runat="server" Text="操作类绩效考核" Enabled="False"></asp:checkbox>
										<asp:checkbox id="CheckBox38" runat="server" Text="见习、试用期员工绩效考核" Enabled="False"></asp:checkbox>
										<asp:checkbox id="CheckBox39" runat="server" Text="管理技术类绩效考核" Enabled="False"></asp:checkbox>
										<asp:checkbox id="CheckBox40" runat="server" Text="绩效考核汇总" Enabled="False"></asp:checkbox>
										<asp:checkbox id="CheckBox43" runat="server" Text="部门绩效考核年度汇总" Enabled="False"></asp:checkbox>
										<asp:checkbox id="CheckBox44" runat="server" Text="公司绩效考核年度汇总" Enabled="False"></asp:checkbox></div></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" style="WIDTH: 792px; HEIGHT: 21px" cellSpacing="0" cellPadding="0" width="792"
							border="0">
							<TR>
								<TD align="center"><asp:button id="Button2" runat="server" Width="89px" CssClass="input4" Text="修改"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<TABLE style="WIDTH: 896px; HEIGHT: 32px; display:none;" borderColor="#111111" height="32" cellSpacing="0"
				cellPadding="0" width="896" border="0">
				<TR height="30">
					<TD class="GbText" align="right" width="20" background='bgColor="#c0d9e6"'><IMG src="../../images/icon/277.GIF"></TD>
					<TD class="GbText" style="FONT-VARIANT: normal; WIDTH: 784px; FONT-FAMILY: 幼圆; COLOR: blue; FONT-SIZE: larger; FONT-WEIGHT: bold"
						vAlign="middle" align="center" width="784" background="../../Images/treetopbg.jpg"
						bgColor="#e8f4ff">个人权限设置</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
