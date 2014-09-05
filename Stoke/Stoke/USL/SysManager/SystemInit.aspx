<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemInit.aspx.cs" Inherits="Stoke.USL.SysManager.SystemInit" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告信息初始化</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                                                        公告信息初始化</td>
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
                                                                        <fieldset>
                                                                            <legend>公告信息初始化设置</legend>
                                                                            <br />
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">企业股份代码：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="shareID" runat="server" Text='' Width="220px"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="shareID"
                                                                                            Display="Dynamic" ErrorMessage="企业股份代码必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                            请填写企业股份代码。</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">企业股份简称：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="shareName" runat="server" Text='' Width="220px"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="shareName"
                                                                                            Display="Dynamic" ErrorMessage="企业股份简称必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                            请填写企业股份简称。</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">企业（公司）名称：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="company" runat="server" Text='' Width="220px"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="company"
                                                                                            Display="Dynamic" ErrorMessage="企业（公司）名称必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                            请填写企业（公司）名称。</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">公告发布作者：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="author" runat="server" Text='' Width="220px"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="author"
                                                                                            Display="Dynamic" ErrorMessage="公告发布作者必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                            请填写公告发布作者。</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">企业（公司）声明：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="repDesc" runat="server" Text='' Width="450px" Height="120px" TextMode="MultiLine"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc" style="margin-left:200px;"><asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="repDesc"
                                                                                            Display="Dynamic" ErrorMessage="企业（公司）声明必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                            请填写企业（公司）声明。</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                        </fieldset>
                                                                        <div class="ManageSub">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                            <asp:Button ID="addBtn" runat="server" CausesValidation="true" CssClass="btn12" Text="提 交"
                                                                                OnClick="addBtn_Click"></asp:Button>
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button
                                                                                ID="cancelBtn" runat="server" CausesValidation="False" CssClass="btn12" Text="取 消"
                                                                                OnClick="cancelBtn_Click"></asp:Button></div>
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
