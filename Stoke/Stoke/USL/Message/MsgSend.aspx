<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Codebehind="MsgSend.aspx.cs"
    Inherits="Stoke.USL.Message.MsgSend" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送信息</title>
    <style type="text/css">
        body{
            
        }
    </style>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/ckeditor/ckeditor.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table cellspacing="0" cellpadding="0" width="100%" border="0" style="margin: auto;">
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
                                                                        发送消息</td>
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
                                                                    <td class="aa05" valign="top">
                                                                        <table style="margin: auto; width: 90%;">
                                                                            <tr>
                                                                                <td class="aa03">
                                                                                    主&nbsp;题：
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;<asp:TextBox ID="zhuti" runat="server" Width="60%" Height="20px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="aa03" height="30px">
                                                                                    类&nbsp;型：
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;<asp:DropDownList ID="xxlx" runat="server" Width="20%" Height="20px">
                                                                                        <asp:ListItem Value="">请选择</asp:ListItem>
                                                                                        <asp:ListItem Value="通知">通知</asp:ListItem>
                                                                                        <asp:ListItem Value="公告">公告</asp:ListItem>
                                                                                        <asp:ListItem Value="会议纪要">会议纪要</asp:ListItem>
                                                                                    </asp:DropDownList><span style="padding-left: 50px;"><font color="red">*请选择消息类型</font></span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="60px" class="aa03">
                                                                                    发&nbsp;给：
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <%--<asp:TextBox ID="sgr" runat="server" Width="60%" Height="20px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font
                                                                                                color="red">*请写用户编号，若发给多人，请以“,”隔开</font>--%>
                                                                                            <div class="ManageLine">
                                                                                                <span class="ManageLineInput" style="width: 207px"><span class="ManageLineDesc" style="color: red">
                                                                                                    已选发给用户</span>&nbsp;<br />
                                                                                                    <asp:ListBox ID="roleLbx" runat="server" Height="200px" Width="180px" SelectionMode="Multiple">
                                                                                                    </asp:ListBox>
                                                                                                </span><span class="ManageLineInput" style="width: 115px">
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    <span class="ManageLineDesc" style="color: red">添加发给用户</span><br />
                                                                                                    &nbsp;&nbsp;<asp:Button ID="roleAddBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                                                                                        Text="<<    <<" OnClick="roleAddBtn_Click" />
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    &nbsp;&nbsp;<asp:Button ID="roleDelBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                                                                                        Text=">>    >>" OnClick="roleDelBtn_Click" />
                                                                                                    <br />
                                                                                                    <span class="ManageLineDesc" style="color: red">删除发给用户</span><br />
                                                                                                </span><span class="ManageLineInput" style="color: red"><span class="ManageLineDesc"
                                                                                                    style="color: red">候选发给用户</span>&nbsp;<br />
                                                                                                    <asp:ListBox ID="CandidateRoleLbx" runat="server" Height="200px" Width="180px" SelectionMode="Multiple">
                                                                                                    </asp:ListBox>
                                                                                                </span>
                                                                                            </div>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="aa03">
                                                                                    内&nbsp;容：
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;<asp:TextBox ID="message" runat="server" Height="180px" Width="420px" TextMode="MultiLine"
                                                                                        CssClass="ckeditor"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="aa03">
                                                                                    附&nbsp;件：
                                                                                </td>
                                                                                <td>
                                                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" Height="23px" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" align="center">
                                                                                    <br />
                                                                                    <asp:Button ID="fs" runat="server" CssClass="btn12" Text="发送" OnClick="fs_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    <asp:Button ID="qx" runat="server" CssClass="btn12" Text="取消" OnClick="qx_Click"></asp:Button>
                                                                                </td>
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
