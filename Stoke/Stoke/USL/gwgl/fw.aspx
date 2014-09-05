<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fw.aspx.cs" Inherits="Stoke.USL.gwgl.fw" %>
<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Fw</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table7" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 776px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
					cellSpacing="1" cellPadding="1" width="776" align="center" border="0">
					<TR>
						<TD style="HEIGHT: 32px">
							<P align="center"><asp:label id="Label2" runat="server" Width="481px" Font-Size="Large" Height="16px">公司发文稿纸</asp:label></P>
						</TD>
					</TR>
					<TR style="display:none;">
						<TD>
							<P align="center"><asp:label id="Label3" runat="server" Font-Size="X-Small" Font-Bold="True">Dalian Shipbuilding Industry Offshore Co.,Ltd.</asp:label></P>
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 784px; POSITION: absolute; TOP: 64px; HEIGHT: 475px"
					cellSpacing="1" cellPadding="1" width="784" border="1">
					<TBODY>
						<TR>
							<TD style="HEIGHT: 13px">
								<TABLE id="Table2" style="WIDTH: 768px; HEIGHT: 64px" cellSpacing="1" cellPadding="0" width="768"
									border="0">
									<TR>
										<TD style="WIDTH: 81px; HEIGHT: 30px" noWrap align="center">主办部门</TD>
										<TD style="WIDTH: 117px; HEIGHT: 30px" noWrap><asp:dropdownlist id="e" runat="server" Width="100px" Enabled="False"></asp:dropdownlist></TD>
										<TD style="WIDTH: 73px; HEIGHT: 30px" noWrap align="center">拟稿人</TD>
										<TD style="WIDTH: 101px; HEIGHT: 30px" noWrap><asp:textbox id="f" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										<TD style="WIDTH: 99px; HEIGHT: 30px" noWrap align="center">主管</TD>
										<TD style="WIDTH: 103px; HEIGHT: 30px" noWrap><asp:textbox id="i" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										<TD style="WIDTH: 86px; HEIGHT: 30px" noWrap align="center">
											<P>部门总监</P>
										</TD>
										<TD style="HEIGHT: 30px" noWrap><asp:textbox id="d" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 81px" noWrap align="center">文件号</TD>
										<TD style="WIDTH: 117px" noWrap><asp:textbox id="m" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										<TD style="WIDTH: 73px" noWrap align="center">密级</TD>
										<TD style="WIDTH: 101px" noWrap align="center"><asp:dropdownlist id="j" runat="server" Width="100px" Enabled="False">
												<asp:ListItem Value="一般" Selected="True">一般</asp:ListItem>
												<asp:ListItem Value="秘密">秘密</asp:ListItem>
												<asp:ListItem Value="机密">机密</asp:ListItem>
												<asp:ListItem Value="绝密">绝密</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD style="WIDTH: 99px" noWrap align="center">份数</TD>
										<TD style="WIDTH: 103px" noWrap align="center"><asp:textbox id="p" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										<TD noWrap></TD>
										<td></td>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 153px">
								<TABLE id="Table3" style="WIDTH: 776px; HEIGHT: 96px" cellSpacing="1" cellPadding="1" width="776"
									align="center" border="0">
									<TR>
										<TD style="WIDTH: 79px" align="center">主送</TD>
										<TD><asp:textbox id="a" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 79px" align="center">抄报</TD>
										<TD><asp:textbox id="b" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 79px" align="center">抄送</TD>
										<TD><asp:textbox id="c" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
								</TABLE>
								<TABLE id="Table6" style="WIDTH: 776px; HEIGHT: 73px" cellSpacing="1" cellPadding="1" width="776"
									border="0">
									<TR>
										<TD style="WIDTH: 80px; HEIGHT: 3px" align="center">部门会签</TD>
										<TD style="HEIGHT: 3px"><asp:textbox id="n" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 80px; HEIGHT: 3px" align="center">助理总裁审批</TD>
										<TD style="HEIGHT: 3px"><asp:textbox id="t" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 80px; HEIGHT: 3px" align="center">高层领导会签</TD>
										<TD style="HEIGHT: 3px"><asp:textbox id="x" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 80px" align="center">总经理签发</TD>
										<TD><asp:textbox id="k" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 80px" align="center">紧急程度</TD>
										<TD><uc1:EmergencySelector runat="server" ID="EmergencySelector1" Enabled="false" /></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 22px">
								<TABLE id="Table4" style="WIDTH: 776px; HEIGHT: 52px" cellSpacing="1" cellPadding="1" width="776"
									border="0">
									<TBODY>
										<TR>
											<TD style="WIDTH: 80px; HEIGHT: 21px" align="center">标题</TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="w" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 80px; HEIGHT: 2px" align="center">主题词</TD>
											<TD style="HEIGHT: 2px"><asp:textbox id="s" runat="server" Width="680px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 80px; HEIGHT: 2px" align="center">反馈单</TD>
											<TD style="HEIGHT: 2px"><asp:datagrid id="DataGrid1" runat="server" Width="687px" Height="52px" AutoGenerateColumns="False"
													PageSize="4">
													<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#F3F5FA"></AlternatingItemStyle>
													<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="White"></ItemStyle>
													<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="Doc_id" HeaderText="doc_id"></asp:BoundColumn>
														<asp:BoundColumn DataField="Yjr" HeaderText="反馈人">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Step_name" HeaderText="反馈步骤">
															<HeaderStyle Width="20%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Sj" HeaderText="反馈时间">
															<HeaderStyle Width="20%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Yj" HeaderText="反馈信息">
															<HeaderStyle Width="50%"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD id="TD1" style="WIDTH: 80px; HEIGHT: 2px" align="center" runat="server"><asp:label id="Label1" runat="server">上传附件</asp:label></TD>
											<TD id="TD2" style="HEIGHT: 2px" runat="server"><INPUT class="input1" id="File1" style="WIDTH: 203px; HEIGHT: 22px" type="file" size="14"
													name="File1" runat="server">&nbsp;附件名
												<asp:textbox id="TextBox2" runat="server"></asp:textbox><asp:button id="btn_upload" runat="server" Width="60px" CssClass="input4" Text="上传"></asp:button></TD>
										</TR>
										<TR>
											<TD id="TD3" style="WIDTH: 80px; HEIGHT: 72px" align="center" runat="server"></TD>
											<TD id="TD4" style="HEIGHT: 72px" runat="server"><asp:datalist id="FileList" runat="server" Width="432px" Height="72px">
													<ItemTemplate>
														<FONT face="宋体">
															<asp:Label id=txt_filename0 runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FileName0").ToString () %>' Visible="False">
															</asp:Label>
															<asp:Label id=txt_filename runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FileName").ToString () %>'>
															</asp:Label>&nbsp;
															<asp:ImageButton id=btn_delete runat="server" ImageUrl="../../images/dele.bmp" CommandArgument='<%# DataBinder.Eval (Container.DataItem, "FileName").ToString () %>' CommandName="delete">
															</asp:ImageButton></FONT>
													</ItemTemplate>
												</asp:datalist></TD>
										</TR>
										<TR>
											<TD id="TD5" style="WIDTH: 80px; HEIGHT: 2px" align="center" runat="server"><asp:label id="Label17" runat="server">点击下载附件</asp:label></TD>
											<TD id="TD6" style="HEIGHT: 2px" runat="server"><asp:datalist id="DBFileList" runat="server" Width="434px">
													<ItemTemplate>
														<asp:HyperLink id=link_id Text='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>' Visible="False" Runat="server">
														</asp:HyperLink>
														<asp:HyperLink id=link_download Text='<%# DataBinder.Eval (Container.DataItem, "CategoryName").ToString () %>' Runat="server">
														</asp:HyperLink>
														<asp:HyperLink id=link_description Text='<%# DataBinder.Eval (Container.DataItem, "Description").ToString () %>' Visible="False" Runat="server">
														</asp:HyperLink><FONT face="宋体">&nbsp;&nbsp;</FONT>
														<asp:ImageButton id=btn_delete1 runat="server" CommandName="delete" CommandArgument='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>' ImageUrl="../../images/dele.bmp">
														</asp:ImageButton>
													</ItemTemplate>
												</asp:datalist></TD>
										</TR>
									</TBODY>
								</TABLE>
								<font color="#ff0000">*提示：如需修改文件，请下载并删除原文件，修改后重新上传</font>
							</TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 22px">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 78px" align="center">打字</TD>
										<TD style="WIDTH: 170px" align="center"><asp:textbox id="g" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										<TD style="WIDTH: 81px" align="center">校对</TD>
										<TD align="center"><asp:textbox id="h" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox></TD>
										<TD align="center"><asp:textbox id="o" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:textbox>封发</TD>
									</TR>
								</TABLE>
								<FIELDSET id="fieldset1" style="WIDTH: 768px; HEIGHT: 67px" runat="server">
									<TABLE id="Table10" style="WIDTH: 717px; HEIGHT: 19px" cellSpacing="0" cellPadding="0"
										width="717" border="0">
										<TR>
											<TD style="WIDTH: 133px" vAlign="middle" align="center" colSpan="1" rowSpan="1"><asp:label id="yj" runat="server">填写意见</asp:label></TD>
											<TD><asp:textbox id="tsyj" runat="server" Width="608px" Font-Size="X-Small" Height="42px" BackColor="White"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
								</FIELDSET>
							</TD>
						</TR>
						<TR>
							<TD>
								<TABLE id="Table8" style="WIDTH: 776px; HEIGHT: 2px" cellSpacing="1" cellPadding="1" width="776"
									border="0">
									<TR>
										<TD style="WIDTH: 181px"></TD>
										<TD style="WIDTH: 125px" align="center"><asp:button id="BtnTj" runat="server" Width="100px" CssClass="input4" Text="处理"></asp:button></TD>
										<TD style="WIDTH: 138px" align="center"><asp:button id="BtnSave" runat="server" Width="100px" CssClass="input4" Text="保存"></asp:button></TD>
										<TD style="WIDTH: 142px" align="center"><asp:button id="BtnQx" runat="server" Width="104px" Height="23px" CssClass="input4" Text="取消"></asp:button></TD>
										<TD></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
		</form>
		</FONT>
	</body>
</HTML>
