<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocUpload.aspx.cs" Inherits="Stoke.USL.Disclosure.DocUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>模板上传</title>
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
                                                                        模板上传</td>
                                                                    <td width="120">
                                                                        <img height="16" src="../../images/ico_04.gif" width="17" align="absmiddle"><a href="DocLoad.aspx">返回模板列表</a></td>
                                                                    <td valign="top" width="14">
                                                                        <img height="28" alt="" src="../../images/main_30.gif" width="14"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" width="100%" style="padding:10px;">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="aa05" valign="top" style="height: 159px">
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">模板名称：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="DocName" runat="server" Text='' Width="220px" MaxLength="32"></asp:TextBox></span><span
                                                                                    class="ManageLineDesc"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DocName"
                                                                                        Display="Dynamic" ErrorMessage="模板名称必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>请填写模板名称。</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">模板描述：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="DocDesc" runat="server" Text='' Width="450px" Height="100px"
                                                                                    TextMode="MultiLine"></asp:TextBox></span><span class="ManageLineDesc" style="margin-left:200px;"><asp:Label
                                                                                        ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        请填写模板描述。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">模板上传：</span><span class="ManageLineInput" style="width:85%;">
                                                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" Height="23px" />
                                                                                </span><div class="clear"></div>
                                                                        </div>
                                                                        <div class="ManageSub" style="text-align:center;">
                                                                            <asp:Button ID="addBtn" runat="server" CausesValidation="True" CssClass="btn12" Text="添 加"
                                                                                OnClick="addBtn_Click"></asp:Button>
                                                                            &nbsp; &nbsp; &nbsp;&nbsp;
                                                                            <asp:Button ID="cancelBtn" runat="server" CausesValidation="False" CssClass="btn12"
                                                                                Text="取 消" OnClick="cancelBtn_Click"></asp:Button>
                                                                            <asp:Label ID="IDLB" runat="server" Text="" Visible="false"></asp:Label><br />
                                                                        </div>
                                                                    </td>
                                                                    <td valign="top" width="4" bgcolor="#f0f0f0" style="height: 159px">
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
                                                                    <td valign="top" width="14" style="height: 16px">
                                                                        <img height="14" alt="" src="../../images/main_39.gif" width="14"></td>
                                                                    <td valign="top" width="100%" style="height: 16px">
                                                                        &nbsp;</td>
                                                                    <td valign="top" width="15" style="height: 16px">
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
