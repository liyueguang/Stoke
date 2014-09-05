<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sw.aspx.cs" Inherits="Stoke.USL.gwgl.sw" %>
<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Sw</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../My97DatePicker/WdatePicker.js"></SCRIPT>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table7" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 776px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
				cellSpacing="1" cellPadding="1" width="776" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 32px">
						<P align="center"><asp:label id="Label2" runat="server" Width="529px" Font-Size="Large" Height="16px">公司来文处理用笺</asp:label></P>
					</TD>
				</TR>
				<TR style="display:none;">
					<TD>
						<P align="center"><asp:label id="Label3" runat="server" Font-Size="X-Small" Font-Bold="True">Dalian Shipbuilding Industry Offshore Co.,Ltd.</asp:label></P>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 777px; POSITION: absolute; TOP: 64px; HEIGHT: 272px"
				cellSpacing="1" cellPadding="1" width="777" border="1">
				<TR>
					<TD style="HEIGHT: 11px">
						<TABLE id="Table2" style="WIDTH: 768px; HEIGHT: 2px" cellSpacing="1" cellPadding="1" width="768"
							border="0">
							<TR>
								<TD style="WIDTH: 100px" align="center">
									<asp:Label id="Label1" runat="server">收文字号</asp:Label></TD>
								<TD style="WIDTH: 126px" align="center">
									<asp:TextBox id="h" runat="server" Width="104px" BackColor="Control" ReadOnly="True"></asp:TextBox></TD>
								<TD style="WIDTH: 76px" align="center">
									<asp:Label id="Label5" runat="server">类别</asp:Label></TD>
								<TD style="WIDTH: 182px" align="center" colSpan="1" rowSpan="1">
									<asp:DropDownList id="j" runat="server" Width="145px" Enabled="False">
										<asp:ListItem Value="集团文件" Selected="True">公司文件</asp:ListItem>
										<asp:ListItem Value="集团通知及其他">公司通知及其他</asp:ListItem>
										<asp:ListItem Value="外来文函">外来文函</asp:ListItem>
									</asp:DropDownList></TD>
								<TD style="WIDTH: 143px" align="center" colSpan="2" rowSpan="1"><FONT face="宋体">日期&nbsp;&nbsp;</FONT><asp:TextBox id="g" runat="server" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'});" Width="100px" BackColor="Control" ReadOnly="True"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100px" align="center">来文机关</TD>
								<TD style="WIDTH: 126px" align="center">
									<asp:TextBox id="a" runat="server" Width="108px" ReadOnly="True" BackColor="Control"></asp:TextBox></TD>
								<TD style="WIDTH: 76px" align="center">来文份数</TD>
								<TD style="WIDTH: 182px" align="center">
									<asp:TextBox id="b" runat="server" Width="146px" ReadOnly="True" BackColor="Control"></asp:TextBox></TD>
								<TD style="WIDTH: 138px" align="center">
									<asp:TextBox id="c" runat="server" Width="100px" ReadOnly="True" BackColor="Control"></asp:TextBox>号</TD>
								<TD align="center">
									<asp:TextBox id="d" runat="server" Width="95px" ReadOnly="True" BackColor="Control"></asp:TextBox>印发</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table3" style="WIDTH: 768px; HEIGHT: 112px" cellSpacing="1" cellPadding="1"
							width="768" border="0">
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 2px" align="center">文件题目</TD>
								<TD style="HEIGHT: 2px">
									<asp:TextBox id="w" runat="server" Width="656px" ReadOnly="True" BackColor="Control"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 2px" align="center"><FONT face="宋体">文秘审核</FONT></TD>
								<TD style="HEIGHT: 2px">
									<asp:TextBox id="x" runat="server" Width="656px" ReadOnly="True" BackColor="Control"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 2px" align="center"><FONT face="宋体">综合部分转意见</FONT></TD>
								<TD style="HEIGHT: 2px">
									<asp:TextBox id="i" runat="server" Width="656px" ReadOnly="True" BackColor="Control"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 2px" align="center"><FONT face="宋体">审批领导</FONT></TD>
								<TD style="HEIGHT: 2px">
									<asp:TextBox id="f" runat="server" Width="656px" ReadOnly="True" BackColor="Control"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 132px" align="center" colSpan="1" rowSpan="1">领导批示</TD>
								<TD style="HEIGHT: 132px"><FONT face="宋体">
										<asp:TextBox id="s" runat="server" Height="132px" Width="656px" TextMode="MultiLine" ReadOnly="True"
											BackColor="Control"></asp:TextBox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px; HEIGHT: 4px" align="center" colSpan="1" rowSpan="1">拟办意见</TD>
								<TD style="HEIGHT: 4px"><FONT face="宋体">
										<asp:datagrid id="DataGrid1" runat="server" Height="52px" Width="653px" AutoGenerateColumns="False"
											PageSize="4">
											<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#F3F5FA"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="Doc_id" HeaderText="doc_id"></asp:BoundColumn>
												<asp:BoundColumn DataField="Yjr" HeaderText="人员">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Step_name" HeaderText="反馈步骤">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Sj" HeaderText="时间">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Yj" HeaderText="拟办意见">
													<HeaderStyle Width="50%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"></PagerStyle>
										</asp:datagrid></FONT></TD>
							</TR>
							<TR>
								<TD id="TD1" runat="server" style="WIDTH: 150px" align="center">
									<asp:label id="Label4" runat="server">上传附件</asp:label></TD>
								<TD id="TD2" runat="server"><INPUT class="input1" id="File1" style="WIDTH: 203px; HEIGHT: 22px" type="file" size="14"
										name="File1" runat="server"><FONT face="宋体">&nbsp;附件名 </FONT>
									<asp:textbox id="TextBox2" runat="server"></asp:textbox><FONT face="宋体">&nbsp;</FONT>
									<asp:button id="btn_upload" runat="server" Width="60px" CssClass="input4" Text="上传"></asp:button></TD>
							</TR>
							<TR>
								<TD id="TD3" runat="server" style="WIDTH: 150px" align="center"></TD>
								<TD id="TD4" runat="server">
									<asp:datalist id="FileList" runat="server" Height="72px" Width="432px">
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
								<TD id="TD5" runat="server" style="WIDTH: 150px" align="center">
									<asp:label id="Label17" runat="server">点击下载附件</asp:label></TD>
								<TD id="TD6" runat="server">
									<asp:datalist id="DBFileList" runat="server" Width="434px">
										<ItemTemplate>
											<asp:HyperLink id=link_id Text='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>' Visible="False" Runat="server">
											</asp:HyperLink>
											<asp:HyperLink id=link_download Text='<%# DataBinder.Eval (Container.DataItem, "CategoryName").ToString () %>' Runat="server">
											</asp:HyperLink>
											<asp:HyperLink id=link_description Text='<%# DataBinder.Eval (Container.DataItem, "Description").ToString () %>' Visible="False" Runat="server">
											</asp:HyperLink><FONT face="宋体">&nbsp;&nbsp;</FONT>
											<asp:ImageButton id=btn_delete1 runat="server" Visible="False" CommandName="delete" CommandArgument='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>' ImageUrl="../../images/dele.bmp">
											</asp:ImageButton>
										</ItemTemplate>
									</asp:datalist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px" align="center">
									紧急程度</TD>
								<TD ><uc1:EmergencySelector runat="server" ID="EmergencySelector1" Enabled="false" />
									</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><FONT face="宋体"> </FONT>
						<FIELDSET id="fieldset1" runat="server" style="WIDTH: 768px; HEIGHT: 67px">
							<TABLE id="Table10" style="WIDTH: 717px; HEIGHT: 19px" cellSpacing="0" cellPadding="0"
								width="717" border="0">
								<TR>
									<TD style="WIDTH: 133px" vAlign="middle" align="center" colSpan="1" rowSpan="1">
										<asp:label id="yj" runat="server">拟办意见</asp:label></TD>
									<TD><asp:textbox id="tsyj" runat="server" Height="42px" Font-Size="X-Small" Width="608px" BackColor="White"
											TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
						<TABLE id="Table8" style="WIDTH: 768px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="768"
							border="0">
							<TR>
								<TD style="WIDTH: 175px"></TD>
								<TD style="WIDTH: 151px" align="center">
									<asp:Button id="BtnTj" runat="server" Width="100px" Text="处理" CssClass="input4"></asp:Button></TD>
								<TD style="WIDTH: 155px" align="center">
									<asp:Button id="BtnSave" runat="server" Width="100px" Text="保存" CssClass="input4"></asp:Button></TD>
								<TD style="WIDTH: 121px" align="center">
									<asp:Button id="BtnQx" runat="server" Width="104px" Text="取消" CssClass="input4"></asp:Button></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:TextBox id="t" style="Z-INDEX: 107; LEFT: 800px; POSITION: absolute; TOP: 32px" runat="server"
				Width="16px" Visible="False"></asp:TextBox>
		</form>
	</body>
</HTML>
