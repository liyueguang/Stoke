<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsgReceiveList.aspx.cs" Inherits="Stoke.USL.Message.MsgReceiveList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>接收消息列表</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td valign="top">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td valign="top" height="23">
                                    &nbsp;</td>
                                <td rowspan="3" valign="top" width="10">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top" width="100%">
                                                    <table cellspacing="0" cellpadding="0" width="100%" background="../../images/main_28.gif"
                                                        border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top" width="10">
                                                                    <img height="28" alt="" src="../../images/main_27.gif" width="10"></td>
                                                                <td width="16">
                                                                    <img height="16" src="../../images/ico_02.gif" width="16"></td>
                                                                <td class="aa03">
                                                                    接收消息列表</td>
                                                                <td width="120">
                                                                </td>
                                                                <td valign="top" width="14">
                                                                    <img height="28" alt="" src="../../images/main_30.gif" width="14"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" width="100%">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td  class="aa05" valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td style="width: 25%; height: 25px; text-align: right;">
                                                                                查询条件： &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;发送人</td>
                                                                            <td style="width: 8px; height: 25px; text-align: right">
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/L4.gif"></asp:Image></td>
                                                                            <td style="width: 25%; height: 25px; text-align: left;">
                                                                                &nbsp;<asp:TextBox ID="fasongren" runat="server" Width="90%"></asp:TextBox></td>
                                                                            <td colspan="4" style="height: 25px; text-align: right; width: 15%">
                                                                                消息内容</td>
                                                                            <td style="width: 8px; height: 25px; text-align: right">
                                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/L4.gif"></asp:Image></td>
                                                                            <td style="width: 25%; height: 25px; text-align: left;">
                                                                                &nbsp;<asp:TextBox ID="descTbx" runat="server" Width="90%"></asp:TextBox></td>
                                                                            <td colspan="4" style="height: 25px; text-align: left; width: 15%">
                                                                                <asp:Button ID="SearchBtn" runat="server" Text="查 询" OnClick="SearchBtn_Click" CssClass="btn12">
                                                                                </asp:Button></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="13" style="height: 25px; text-align: left">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 15px" colspan="13" align="right">
                                                                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                    AutoGenerateColumns="False" PageSize="12" UseAccessibleHeader="False" Width="100%"
                                                                                    CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                                    OnSorting="GridView1_Sorting" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                                                                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="MsgType" HeaderText="类型">
                                                                                            <ItemStyle Width="6%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="UserName" HeaderText="发送人">
                                                                                            <ItemStyle Width="10%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="MsgTitle" HeaderText="主题">
                                                                                            <ItemStyle Width="20%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Message" HeaderText="内容">
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="SendDate" HeaderText="时间">
                                                                                            <ItemStyle Width="12%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="IsRead" HeaderText="读取">
                                                                                            <ItemStyle Width="5%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="ID" HeaderText="编号" Visible="False">
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="操作">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="button1" runat="server" CommandName="Delete" OnClientClick="return confirm('您确定要接收此信息?')"
                                                                                                        CommandArgument='<%# Eval("ID") %>' Text='接收'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="5%" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="查看">
                                                                                            <ItemTemplate>
                                                                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "MsgView.aspx?flag=1&ID="+Eval("ID") %>'
                                                                                                    Text='查看'></asp:HyperLink>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="5%" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <PagerTemplate>
                                                                                        <asp:LinkButton ID="first" runat="server" Text="首页" CommandArgument="First" CommandName="Page"
                                                                                            ForeColor="white"></asp:LinkButton>
                                                                                        <asp:LinkButton ID="pre" runat="server" Text="上一页" CommandArgument="Prev" CommandName="Page"
                                                                                            ForeColor="White" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" />
                                                                                        <asp:LinkButton ID="sel" runat="server" Text="跳转至" ForeColor="White" OnClick="sel_Button_Click"></asp:LinkButton>
                                                                                        <asp:TextBox ID="page_TextBox" runat="server" Width="30px" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>">"></asp:TextBox>页
                                                                                        <asp:LinkButton ID="next" runat="server" Text="下一页" CommandArgument="Next" CommandName="Page"
                                                                                            ForeColor="white" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>"></asp:LinkButton>
                                                                                        <asp:LinkButton ID="last" runat="server" Text="末页" CommandArgument="Last" CommandName="Page"
                                                                                            ForeColor="White"></asp:LinkButton>
                                                                                    </PagerTemplate>
                                                                                </asp:GridView>
                                                                                <asp:Label ID="PageInfoLbl" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" width="4" bgcolor="#f0f0f0">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" width="100%">
                                                    <table cellspacing="0" cellpadding="0" width="100%" background="../../images/main_40.gif"
                                                        border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top" width="14">
                                                                    <img height="14" alt="" src="../../images/main_39.gif" width="14"></td>
                                                                <td valign="top" width="100%">
                                                                    &nbsp;</td>
                                                                <td valign="top" width="15">
                                                                    <img height="14" alt="" src="../../images/main_41.gif" width="15"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="23">
                                    &nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
