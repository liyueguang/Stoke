<%@ Page Language="C#" AutoEventWireup="true" Codebehind="style_zhxx.aspx.cs" Inherits="Stoke.USL.zhxxgl.style_zhxx" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="SlctDepartment" Src="../../COMMON/SlctDepartment.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>style_zhxx</title>
    <meta content="False" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/css.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>

</head>
<body class="body1" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="z-index: 101; left: 0px; width: 808px; position: absolute;
            top: 8px; height: 56px" cellspacing="1" cellpadding="1" width="808" align="left"
            border="0">
            <tr>
                <td>
                    <p align="center">
                        <asp:Label ID="Label2" runat="server" Height="16px" Width="313px" Font-Size="Large">综合信息发布申请</asp:Label></p>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <p align="center">
                        <asp:Label ID="Label3" runat="server" Font-Size="X-Small" Font-Bold="True">Dalian Shipbuilding Industry Offshore Co.,Ltd.</asp:Label></p>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table id="Table12" style="width: 809px; border-collapse: collapse;" cellspacing="1"
                        cellpadding="1" width="809" align="center" border="1" runat="server">
                        <tr>
                            <td style="height: 850px" align="center" colspan="2" valign="top">
                                <table id="Table21" style="width: 809px" cellspacing="1" cellpadding="1" align="center"
                                    border="1" runat="server">
                                    <tr>
                                        <td width="135px" style="width: 135px; height: 25px" align="center">
                                            拟稿人</td>
                                        <td style="height: 25px" align="left">
                                            <asp:TextBox ID="a" runat="server" Width="130px" BorderStyle="None" BackColor="Control"
                                                ReadOnly="True"></asp:TextBox></td>
                                        <td style="height: 25px" align="center">
                                            &nbsp;发布部门</td>
                                        <td style="width: 160px; height: 25px" align="left" width="160">
                                            <asp:DropDownList ID="z" runat="server" Width="175px" BackColor="Control" Enabled="False">
                                            </asp:DropDownList></td>
                                        <td style="height: 25px" align="center" width="16.7%">
                                            申请日期</td>
                                        <td style="height: 25px" align="left" width="16.7%">
                                            <asp:TextBox ID="c" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm'})"
                                                runat="server" Width="130px" BackColor="Control" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 135px" align="center">
                                            稿件分类</td>
                                        <td align="left">
                                            <asp:DropDownList ID="d" runat="server" BackColor="Control" Width="130" Enabled="False">
                                                <asp:ListItem Value="-请选择-" Selected="True">-请选择-</asp:ListItem>
                                                <asp:ListItem Value="公告">公告</asp:ListItem>
                                                <asp:ListItem Value="通知">通知</asp:ListItem>
                                                <asp:ListItem Value="周报">周报</asp:ListItem>
                                                <asp:ListItem Value="月报">月报</asp:ListItem>
                                                <asp:ListItem Value="计划">计划</asp:ListItem>
                                                <asp:ListItem Value="会议纪要">会议纪要</asp:ListItem>
                                                <asp:ListItem Value="专题纪要">专题纪要</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td align="center">
                                            主题词</td>
                                        <td style="width: 160px" align="left" width="160">
                                            <asp:TextBox ID="f" runat="server" Width="177" BackColor="Control" ReadOnly="True"></asp:TextBox></td>
                                        <td align="center">
                                            <font face="宋体" visible="false"></font>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="b" runat="server" Visible="false" BackColor="Control" AutoPostBack="True"
                                                Width="177" Enabled="False">
                                                <asp:ListItem Value="2">选定部门</asp:ListItem>
                                                <asp:ListItem Value="3">选定人员</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 135px; height: 25px" align="center">
                                            &nbsp;标题</td>
                                        <td style="height: 25px" align="center" colspan="5">
                                            <asp:TextBox ID="e" runat="server" Width="100%" BackColor="Control" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td id="TD20" style="width: 135px; height: 25px" align="center" runat="server">
                                            <asp:Button ID="Btn_bm" runat="server" Width="100px" CssClass="input4" Text="选择部门"
                                                OnClick="Btn_bm_Click1"></asp:Button></td>
                                        <td id="TD21" style="height: 25px" align="center" colspan="5" runat="server">
                                            <asp:TextBox ID="j" runat="server" Width="100%" BorderStyle="None" BackColor="Control"
                                                ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td id="TD22" style="width: 135px; height: 25px" align="center" runat="server">
                                            <asp:Button ID="Btn_ry" runat="server" Width="100px" CssClass="input4" Text="选择人员"
                                                OnClick="Btn_ry_Click1"></asp:Button></td>
                                        <td id="TD24" style="height: 25px" align="center" colspan="5" runat="server">
                                            <asp:TextBox ID="k" runat="server" Width="100%" BorderStyle="None" BackColor="Control"
                                                ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 135px; height: 180px" align="center">
                                            &nbsp;信息内容</td>
                                        <td style="height: 180px" align="center" colspan="5">
                                            <asp:TextBox ID="x" runat="server" Width="100%" Height="180px" BackColor="Control"
                                                ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td id="TD1" style="width: 135px" align="center" runat="server">
                                            <font face="宋体">
                                                <asp:Label ID="Label4" runat="server" Width="135px">上传附件</asp:Label></font></td>
                                        <td id="TD2" align="left" bgcolor="ghostwhite" colspan="5" runat="server">
                                            <input class="input1" id="File1" style="width: 336px; height: 22px" type="file" size="36"
                                                name="File1" runat="server">
                                            <asp:Label ID="Label6" runat="server">附件名    </asp:Label>
                                            <asp:TextBox ID="TextBox2" runat="server" Width="224px"></asp:TextBox>
                                            <asp:Button ID="btn_upload" runat="server" Width="60px" CssClass="input4" Text="上传"
                                                OnClick="btn_upload_Click1"></asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td id="TD3" style="width: 135px" align="center" runat="server">
                                            <font face="宋体"></font>
                                        </td>
                                        <td id="TD4" align="left" colspan="5" runat="server">
                                            <asp:DataList ID="FileList" runat="server" Width="432px" Height="72px">
                                                <ItemTemplate>
                                                    <font face="宋体">
                                                        <asp:Label ID="txt_filename0" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FileName0").ToString () %>'
                                                            Visible="False">
                                                        </asp:Label>
                                                        <asp:Label ID="txt_filename" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FileName").ToString () %>'>
                                                        </asp:Label>&nbsp;
                                                        <asp:ImageButton ID="btn_delete" runat="server" ImageUrl="../../images/dele.bmp"
                                                            CommandArgument='<%# DataBinder.Eval (Container.DataItem, "FileName").ToString () %>'
                                                            CommandName="delete"></asp:ImageButton></font>
                                                </ItemTemplate>
                                            </asp:DataList></td>
                                    </tr>
                                    <tr>
                                        <td id="TD5" style="width: 135px" align="center" runat="server">
                                            <asp:Label ID="Label5" runat="server" Width="135px">点击下载附件</asp:Label></td>
                                        <td id="TD6" align="left" colspan="5" runat="server">
                                            <asp:DataList ID="DBFileList" runat="server" Width="434px">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="link_id" Text='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>'
                                                        Visible="False" runat="server">
                                                    </asp:HyperLink>
                                                    <asp:HyperLink ID="link_download" Text='<%# DataBinder.Eval (Container.DataItem, "CategoryName").ToString () %>'
                                                        runat="server">
                                                    </asp:HyperLink>
                                                    <asp:HyperLink ID="link_description" Text='<%# DataBinder.Eval (Container.DataItem, "Description").ToString () %>'
                                                        Visible="False" runat="server">
                                                    </asp:HyperLink><font face="宋体">&nbsp;&nbsp;</font>
                                                    <asp:ImageButton ID="btn_delete1" Visible="False" runat="server" ImageUrl="../../images/dele.bmp"
                                                        CommandArgument='<%# DataBinder.Eval (Container.DataItem, "CategoryID").ToString () %>'
                                                        CommandName="delete"></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:DataList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 135px" align="center" height="84">
                                            部门总监审批&nbsp;</td>
                                        <td align="center" colspan="5">
                                            <asp:TextBox ID="h" runat="server" Width="100%" Height="84px" BackColor="Control"
                                                ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 135px; height: 80px" align="center">
                                            &nbsp;综合管理部备案</td>
                                        <td style="height: 10px" align="center" colspan="5">
                                            <asp:TextBox ID="g" runat="server" Width="100%" Height="80px" BackColor="Control"
                                                ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 135px" align="center" height="80">
                                            &nbsp;备注</td>
                                        <td align="center" colspan="5">
                                            <asp:TextBox ID="y" runat="server" Width="100%" Height="80px" BackColor="Control"
                                                ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td id="TD7" style="width: 135px; height: 10px" align="center" runat="server">
                                            &nbsp;公司领导意见</td>
                                        <td id="TD8" style="height: 10px" width="100%" colspan="5" rowspan="1">
                                            <asp:GridView ID="DataGrid1" runat="server" Width="100%" Height="134px" PageSize="5"
                                                AutoGenerateColumns="False">
                                                <SelectedRowStyle HorizontalAlign="Center"></SelectedRowStyle>
                                                <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                                                <AlternatingRowStyle HorizontalAlign="Center" BackColor="#F3F5FA"></AlternatingRowStyle>
                                                <RowStyle HorizontalAlign="Center"></RowStyle>
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#F3F5FA"></HeaderStyle>
                                                <Columns>
                                                    <asp:BoundField Visible="False" DataField="id"></asp:BoundField>
                                                    <asp:BoundField DataField="yj_zgbh" HeaderText="姓名">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="yj_time" HeaderText="时间">
                                                        <HeaderStyle Width="20%"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="yj_nr" HeaderText="内容"></asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="TD9" style="width: 135px" align="center" height="80" runat="server">
                                            填写意见</td>
                                        <td align="center" colspan="5">
                                            <asp:TextBox ID="Txt_yj" runat="server" Width="100%" Height="80px" 
                                                Enabled="False" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td style="width: 135px; height: 25px" align="center">
                                            <asp:Button ID="Btn_sy" runat="server" Width="100px" Enabled="False" CssClass="input4"
                                                Text="选择查看意见人员"></asp:Button></td>
                                        <td style="height: 25px" align="center" colspan="5">
                                            <asp:TextBox ID="Txt_sy" runat="server" Width="100%" 
                                                ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td id="Td10" runat="server" align="center" style="width: 135px">
                                            紧急程度
                                        </td>
                                        <td align="center" colspan="5" style="text-align: left">
                                            <uc2:EmergencySelector ID="EmergencySelector1" runat="server" Enabled="false" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="input2" align="center" colspan="2" valign="top">
                                <asp:Button ID="btnSave" runat="server" Width="98px" CssClass="input4" Text="处理"
                                    OnClick="btnSave_Click1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp; &nbsp;
                                <asp:Button ID="Button1" runat="server" Width="98px" CssClass="input4" Text="保存"
                                    OnClick="Button1_Click1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnBack" runat="server" Width="98px" CssClass="input4" Text="删除"
                                    Visible="False" OnClick="btnBack_Click1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table id="Table18" style="z-index: 102; left: 816px; width: 166px; position: absolute;
            top: 152px; height: 128px; border-collapse: collapse;" cellspacing="0" cellpadding="0"
            width="166" bgcolor="white" border="1" runat="server">
            <tr>
                <td>
                    <uc1:SlctDepartment ID="SlctDepartment1" runat="server"></uc1:SlctDepartment>
                    <uc1:SlctMember ID="SlctMember1" runat="server"></uc1:SlctMember>
                </td>
            </tr>
            <tr>
                <td style="height: 0px" align="center">
                    <asp:Button ID="BtnSD" runat="server" Width="66px" Text="选择" CssClass="input4" Visible="False"
                        OnClick="BtnSD_Click1"></asp:Button><asp:Button ID="Btn_fh" runat="server" Width="66px"
                            Text="返回" CssClass="input4" Visible="False" OnClick="Btn_fh_Click1"></asp:Button></td>
            </tr>
        </table>
    </form>
</body>
</html>
