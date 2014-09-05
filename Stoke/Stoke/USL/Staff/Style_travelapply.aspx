<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Style_travelapply.aspx.cs"
    Inherits="Stoke.USL.Staff.Style_travelapply" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>
<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>style_travelapply</title>
    <meta content="False" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/css.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>

</head>
<body class="body1">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td colspan="6" align="center" style="font-weight: bold; font-size: larger; color: blue;
                        font-family: 幼圆; font-variant: normal; height: 25px;" valign="middle" background="../../images/treetopbg.jpg"
                        bgcolor="#e8f4ff">
                        出差申请单
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;" width="10%">
                        <asp:Button runat="server" ID="selectorBtn" Text="申请人" OnClick="selectorBtn_Click" Enabled="false" /></td>
                    <td colspan="5">
                        <asp:Label runat="server" ID="a" Enabled="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        事由</td>
                    <td colspan="5">
                        <asp:TextBox runat="server" ID="b" TextMode="MultiLine" Width="95%" Height="70px"
                            Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center;" rowspan="4">
                        去程</td>
                    <td style="text-align: center;">
                        日期</td>
                    <td>
                        <asp:TextBox runat="server" ID="c" Enabled="false" Width="150px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                    <td style="text-align: center;" rowspan="4" width="10%">
                        返程</td>
                    <td style="text-align: center;">
                        日期</td>
                    <td>
                        <asp:TextBox runat="server" ID="g" Enabled="false" Width="150px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center;" rowspan="3">
                        班次</td>
                    <td>
                        飞机&nbsp;<asp:TextBox runat="server" ID="d" Enabled="false"></asp:TextBox></td>
                    <td style="text-align: center;" rowspan="3">
                        班次</td>
                    <td>
                        飞机&nbsp;<asp:TextBox runat="server" ID="h" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        火车&nbsp;<asp:TextBox runat="server" ID="e" Enabled="false"></asp:TextBox></td>
                    <td>
                        火车&nbsp;<asp:TextBox runat="server" ID="i" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        其他&nbsp;<asp:TextBox runat="server" ID="f" Enabled="false"></asp:TextBox></td>
                    <td>
                        其他&nbsp;<asp:TextBox runat="server" ID="j" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        附件</td>
                    <td colspan="5">
                        <asp:FileUpload ID="FileUpload1" runat="server" Enabled="False" />
                        附件名称
                        <asp:TextBox ID="attachname" runat="server" Enabled="False"></asp:TextBox>&nbsp;<asp:Button
                            ID="uploadBtn" runat="server" Text="上传" Enabled="False" OnClick="uploadBtn_Click" /></td>
                </tr>
                <tr runat="server" id="attachment" visible="false">
                    <td style="text-align: center">
                    </td>
                    <td colspan="5">
                        <asp:DataList ID="FileList" runat="server" Width="432px" Height="72px" OnItemCommand="FileList_ItemCommand">
                            <ItemTemplate>
                                <font face="宋体">
                                    <asp:HyperLink ID="txt_filename" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "fileurl") %>'
                                        Text='<%# DataBinder.Eval (Container.DataItem, "filename").ToString () %>'>
                                    </asp:HyperLink>&nbsp;
                                    <asp:ImageButton ID="btn_delete" runat="server" ImageUrl="../../images/dele.bmp"
                                        CommandArgument='<%# DataBinder.Eval (Container.DataItem, "id").ToString () %>'
                                        CommandName="delete"></asp:ImageButton></font>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        部门总监</td>
                    <td colspan="5">
                        <asp:TextBox ID="k" runat="server" Enabled="False" Width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        助理总裁</td>
                    <td colspan="5">
                        <asp:TextBox ID="l" runat="server" Enabled="False" Width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        总经理</td>
                    <td colspan="5">
                        <asp:TextBox ID="m" runat="server" Enabled="False" Width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        紧急程度
                    </td>
                    <td colspan="5">
                        <uc1:EmergencySelector ID="EmergencySelector1" Enabled="false" runat="server"></uc1:EmergencySelector>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <asp:Button ID="submitBtn" runat="server" Text="处理" OnClick="submitBtn_Click" />
            <asp:Button ID="saveBtn" runat="server" Text="保存" OnClick="saveBtn_Click" />
            <asp:Button ID="backBtn" runat="server" Text="返回" OnClick="backBtn_Click" /></div>
            
            <div id="doing" runat="server" visible="false" style="z-index:12000; left:0px; width:100%; cursor:wait; position:absolute; top:0px; height:600px; background-color:#f9fff6; filter:alpha(Opacity=75); opacity:0.8;"></div>
			<div id="topwindow" runat="server" visible="false" style=" position:absolute; width:900px; height:auto; text-align:center; vertical-align:middle; left:30px; top:80px; z-index:15000; ">
			    <div style="padding:3px 15px 3px 15px; text-align:left; vertical-align:middle;">
                    <uc1:slctmember id="SlctMember1" runat="server"></uc1:slctmember>
			    </div>
			    <div style="text-align: center;"><asp:button id="BtnSD" runat="server" Width="66px" Text="选择" CssClass="input4" OnClick="BtnSD_Click"></asp:button>
						<asp:button id="Button6" runat="server" Width="66px" Text="返回" CssClass="input4" OnClick="Button6_Click"></asp:button></div>
			</div>
    </form>
</body>
</html>
