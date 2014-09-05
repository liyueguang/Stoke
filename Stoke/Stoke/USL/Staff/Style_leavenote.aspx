<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Style_leavenote.aspx.cs"
    Inherits="Stoke.USL.Staff.Style_leavenote" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>style_qjsp</title>
    <meta content="False" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/css.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function parseDate(str)
        {
            return new Date(Date.parse(str.replace(/-/g, "/")));
        }
        function computeDiff()
        {
            var str1 = document.getElementById("<%= g.ClientID %>").value;
            var str2 = document.getElementById("<%= h.ClientID %>").value;
            if (str1 != "" && str2 != "")
            {
                var date1 = parseDate(str1);
                var date2 = parseDate(str2);
                if (date1 > date2)
                {
                    alert("开始时间大于结束时间！");
                    document.getElementById("<%= h.ClientID %>").value = "";
                    return;
                }
                else
                {
                    var diff = date2.getTime() - date1.getTime();
                    var days = parseInt(diff / (1000 * 60 * 60 * 24));
                    diff = diff % (1000 * 60 * 60 * 24);
                    var minutes = parseInt(diff / (1000 * 60 * 60));
                    diff = diff % (1000 * 60 * 60);
                    var seconds = parseInt(diff / (1000 * 60));
                    document.getElementById("<%= i.ClientID %>").value = "" + days;
                    document.getElementById("<%= j.ClientID %>").value = "" + minutes;
                    document.getElementById("<%= k.ClientID %>").value = "" + seconds;
                }
            }
        }
    </script>
</head>
<body class="body1">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td colspan="6" align="center" style="font-weight: bold; font-size: larger; color: blue;
                        font-family: 幼圆; font-variant: normal; height: 25px;" valign="middle" background="../../images/treetopbg.jpg"
                        bgcolor="#e8f4ff">
                        请假条
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" width="10%">
                        填写时间：</td>
                    <td width="22%">
                        <asp:TextBox ID="a" runat="server" Width="80%" Enabled="False" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'})"></asp:TextBox></td>
                    <td style="text-align: center" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td width="10%" style="text-align: center">
                        姓名</td>
                    <td width="22%">
                        <asp:TextBox runat="server" ID="b" ReadOnly="True" Enabled="False" width="80%"></asp:TextBox></td>
                    <td width="10%" style="text-align: center">
                        部门</td>
                    <td width="24%">
                        <asp:DropDownList runat="server" ID="c" Enabled="False" width="80%">
                        </asp:DropDownList></td>
                    <td width="10%" style="text-align: center">
                        职务</td>
                    <td width="24%">
                        <asp:DropDownList runat="server" ID="d" Enabled="False" width="80%">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        1、请假类别</td>
                    <td colspan="5">
                        <asp:CheckBoxList ID="e" runat="server" RepeatDirection="Horizontal" Enabled="False">
                            <asp:ListItem Value="0">事假</asp:ListItem>
                            <asp:ListItem Value="1">病假</asp:ListItem>
                            <asp:ListItem Value="2">年假</asp:ListItem>
                            <asp:ListItem Value="3">探亲假</asp:ListItem>
                            <asp:ListItem Value="4">婚假</asp:ListItem>
                            <asp:ListItem Value="5">丧假</asp:ListItem>
                            <asp:ListItem Value="6">工伤</asp:ListItem>
                            <asp:ListItem Value="7">产假</asp:ListItem>
                            <asp:ListItem Value="8">其他</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        2、请假事由</td>
                    <td colspan="5">
                        <asp:TextBox ID="f" runat="server" TextMode="MultiLine" Enabled="False" width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        3、请假时间</td>
                    <td colspan="5">
                        自
                        <asp:TextBox ID="g" runat="server" Enabled="False" width="150px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm:ss'})" onchange="computeDiff()"></asp:TextBox>
                        至
                        <asp:TextBox ID="h" runat="server" Enabled="False" width="150px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm:ss'})" onchange="computeDiff()"></asp:TextBox>&nbsp; 共计：
                        <asp:TextBox ID="i" runat="server" Width="100px" Enabled="False"></asp:TextBox>天
                        <asp:TextBox ID="j" runat="server" Width="100px" Enabled="False"></asp:TextBox>时
                        <asp:TextBox ID="k" runat="server" Width="100px" Enabled="False"></asp:TextBox>分
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        附件</td>
                    <td colspan="5">
                        <asp:FileUpload ID="FileUpload1" runat="server" Enabled="False" />
                        附件名称
                        <asp:TextBox ID="attachname" runat="server" Enabled="False"></asp:TextBox>&nbsp;<asp:Button ID="uploadBtn"
                            runat="server" Text="上传" Enabled="False" OnClick="uploadBtn_Click" /></td>
                </tr>
                <tr runat="server" id="attachment" visible="false">
                    <td style="text-align: center">
                    </td>
                    <td colspan="5">
                        <asp:DataList ID="FileList" runat="server" Width="432px" Height="72px" OnItemCommand="FileList_ItemCommand">
                            <ItemTemplate>
                                <font face="宋体">
                                    <asp:HyperLink ID="txt_filename" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "fileurl") %>' Text='<%# DataBinder.Eval (Container.DataItem, "filename").ToString () %>'>
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
                                    <asp:TextBox ID="l" runat="server" Enabled="False" width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        助理总裁</td>
                    <td colspan="5">
                                    <asp:TextBox ID="m" runat="server" Enabled="False" width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                                    总经理</td>
                    <td colspan="5">
                                    <asp:TextBox ID="n" runat="server" Enabled="False" width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        紧急程度
                    </td>
                    <td colspan="5">
                        <uc1:EmergencySelector id="EmergencySelector1" Enabled="false" runat="server">
                        </uc1:EmergencySelector></td>
                </tr>
                <tr>
                    <td colspan="6">
                        注：1、病假须出具医院证明。 2、本表交由人事处存档。</td>
                </tr>
            </table>
        </div>
        <div align="center">
            <asp:Button ID="submitBtn" runat="server" Text="处理" OnClick="submitBtn_Click" />
            <asp:Button ID="saveBtn" runat="server" Text="保存" OnClick="saveBtn_Click" />
            <asp:Button ID="backBtn" runat="server" Text="返回" OnClick="backBtn_Click" /></div>
    </form>
</body>
</html>
