<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MsgView.aspx.cs" Inherits="Stoke.USL.Message.MsgView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消息查看</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="99.5%">
            <tbody>
                <tr>
                    <td valign="top" style="height: 21px">
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 254px">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td valign="top" width="100%">
                                        <table background="../../images/main_28.gif" border="0" cellpadding="0" cellspacing="0"
                                            width="100%">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 28px" valign="top" width="10px">
                                                        <img alt="" height="28" src="../../images/main_27.gif" width="10" /></td>
                                                    <td style="height: 28px" width="30">
                                                        <img height="16" src="../../images/ico_02.gif" width="16px" /></td>
                                                    <td class="aa03" style="height: 28px">
                                                        通知消息详情</td>
                                                    <td style="height: 28px;" width="100px">
                                                        <img height="16px" src="../../images/ico_04.gif" width="17px" align="absmiddle">
                                                        <%if (flag == 0)
                                                          { %>
                                                        <a href="MsgSendList.aspx">返回上一级</a>
                                                        <%}
                                                          else if (flag == 1)
                                                          { %>
                                                        <a href="MsgReceiveList.aspx">返回上一级</a>
                                                        <%}
                                                          else if (flag == 2)
                                                          { %>
                                                        <a href="../MainForm/mainWin.aspx">返回上一级</a>
                                                        <%}%>
                                                    </td>
                                                    <td style="height: 28px" valign="top" width="14">
                                                        <img alt="" height="28" src="../../images/main_30.gif" width="14" /></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 100%">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td class="aa05" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <div align="center" style="margin-top: 20px">
                                                                            <span style="font-size: 16pt;">
                                                                                <%=mtitle %>
                                                                            </span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div style="border-bottom: solid 1px #33ccff; border-top: solid 1px #33ccff; margin-top: 20px;
                                                                            height: 25px; background-color: #f7fbff" align="center">
                                                                            <div style="margin-top: 5px">
                                                                                <span>作者:&nbsp;<%=msend %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;更新时间:&nbsp;<%=mdate %></span>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div style="margin-top: 40px; text-align: left; margin-bottom: 50px; margin-left: 20px;
                                                                            margin-right: 20px; overflow-x: auto;">
                                                                            <span style="font-size: 14px;">
                                                                                <%=minfo %>
                                                                            </span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="left" style="width: 95%">
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Label ID="fujianlb" runat="server" Text="附件："></asp:Label>
                                                                        <asp:Image ID="fujianimg" runat="server" Height="20" ImageUrl="../../images/xiazai.png"
                                                                            Width="15" Style="vertical-align: middle; border: 0;" />
                                                                        <a href='DownLoad.aspx?nameaddr=<%=FileAddr %>&name=<%=FileName %>'>
                                                                            <%=FileName %>
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td bgcolor="#f0f0f0" valign="top" width="4">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" width="100%">
                                        <table background="../../images/main_40.gif" border="0" cellpadding="0" cellspacing="0"
                                            width="100%">
                                            <tbody>
                                                <tr>
                                                    <td valign="top" width="14">
                                                        <img alt="" height="14" src="../../images/main_39.gif" width="14" /></td>
                                                    <td valign="top" width="100%">
                                                    </td>
                                                    <td valign="top" width="15">
                                                        <img alt="" height="14" src="../../images/main_41.gif" width="15" /></td>
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
                    <td height="14">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    </td>
                </tr>
                <tr>
                    <td height="30" valign="top">
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
