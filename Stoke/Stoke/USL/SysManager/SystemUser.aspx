﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemUser.aspx.cs" Inherits="Stoke.USL.SysManager.SystemUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
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
                                    <td valign="top" height="23"></td>
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
                                                                        用户列表</td>
                                                                    <td width="120">
                                                                        <%--<img height="16" src="../../images/ico_04.gif" width="17" align="absmiddle"><a href="SystemUserManager.aspx?ID=-1">
                                                                            添加新用户账号</a>--%></td>
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
                                                                    <td class="aa05" valign="top">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td style="width: 25%; height: 24px; text-align: right;">
                                                                                    查询条件：&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;角色</td>
                                                                                <td style="width: 8px; height: 24px; text-align: right">
                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../../images/L4.gif"></asp:Image></td>
                                                                                <td style="width: 20%; height: 24px; text-align: left;">
                                                                                    <asp:DropDownList ID="roleDdl" runat="server" Width="88%">
                                                                                    </asp:DropDownList></td>
                                                                                <td style="width: 10%; height: 24px; text-align: right;">
                                                                                    姓名</td>
                                                                                <td style="width: 8px; height: 24px; text-align: right">
                                                                                    <asp:Image ID="Image2" runat="server" ImageUrl="../../images/L4.gif"></asp:Image></td>
                                                                                <td style="width: 20%; height: 24px; text-align: left;">
                                                                                    &nbsp;<asp:TextBox ID="nameTbx" runat="server" Width="85%"></asp:TextBox></td>
                                                                                <td style="width: 5%; height: 24px; text-align: right;">
                                                                                    <asp:Label ID="depLbl" runat="server" Text="职务"></asp:Label></td>
                                                                                <td style="width: 8px; height: 24px; text-align: right">
                                                                                </td>
                                                                                <td style="width: 15%; height: 24px; text-align: left;">
                                                                                    &nbsp;<asp:DropDownList ID="deptDdl" runat="server" Width="95%">
                                                                                    </asp:DropDownList></td>
                                                                                <td style="height: 24px; text-align: left;">
                                                                                    <asp:Button ID="SearchBtn" runat="server" Text="查 询" OnClick="SearchBtn_Click" CssClass="btn12">
                                                                                    </asp:Button></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="10" style="height: 25px; text-align: left">
                                                                                    <hr />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 15px" colspan="10" align="right">
                                                                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                        AutoGenerateColumns="False" PageSize="12" Width="100%" CellPadding="4" ForeColor="#333333"
                                                                                        GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
                                                                                        DataKeyNames="UserID" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                                                                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="UserNumber" HeaderText="用户编号">
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="UserName" HeaderText="用户姓名">
                                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Sex" HeaderText="性别">
                                                                                                <ItemStyle Width="10%" />
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="CompanyName" HeaderText="所属部门">
                                                                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                                <FooterStyle HorizontalAlign="Center" />
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="PositionName" HeaderText="职务">
                                                                                                <ItemStyle Width="14%" />
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="MobilePhone1" HeaderText="电话">
                                                                                                <ItemStyle Width="13%" />
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="操作">
                                                                                                <ItemTemplate>
                                                                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "SystemUserUpdate.aspx?ID="+Eval("UserID") %>'
                                                                                                        Text='修改'></asp:HyperLink>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="8%" />
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="删除">
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/delete.png"
                                                                                                        CommandName="Delete" OnClientClick="return confirm('您确定要删除此信息?')" CausesValidation="False"
                                                                                                        CommandArgument='<%# Eval("UserID") %>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="8%" />
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="UserID" SortExpression="UserID" Visible="False" />
                                                                                        </Columns>
                                                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
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
                                                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                        <EditRowStyle BackColor="#2461BF" />
                                                                                        <AlternatingRowStyle BackColor="White" />
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
