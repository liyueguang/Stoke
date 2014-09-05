<%@ Page Language="C#" AutoEventWireup="true" validateRequest= "false" CodeBehind="NewReport.aspx.cs" Inherits="Stoke.USL.Disclosure.NewReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新建报告</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/ckeditor/ckeditor.js"></script>
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
                                                                        公告管理</td>
                                                                    <td width="120">
                                                                        <img height="16" src="../../images/ico_04.gif" width="17" align="absmiddle"><a href="ReportList.aspx">返回公告列表</a></td>
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
                                                                            <span class="ManageLineTitle">股份简称：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="ShareName" runat="server" Text='' Width="220px" MaxLength="32"></asp:TextBox></span><span
                                                                                    class="ManageLineDesc"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ShareName"
                                                                                        Display="Dynamic" ErrorMessage="股份简称必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>请填写股份简称。</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">股份代码：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="ShareID" runat="server" Text='' Width="220px" MaxLength="100"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                        ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ShareID"
                                                                                        Display="Dynamic" ErrorMessage="股份代码必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                        请填写股份代码。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">公告编号：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="RepID" runat="server" Text='' Width="220px" MaxLength="100"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                        ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RepID"
                                                                                        Display="Dynamic" ErrorMessage="公告编号必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                        请填写公告编号，例如：2014-01。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">公司名称：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="Company" runat="server" Text='' Width="220px" MaxLength="100"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                        ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Company"
                                                                                        Display="Dynamic" ErrorMessage="公司名称必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                        请填写公司（集团）名称。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">公告标题：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="RepName" runat="server" Text='' Width="220px" MaxLength="100"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                        ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RepName"
                                                                                        Display="Dynamic" ErrorMessage="公告标题必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                        请填写公告标题。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">声明人：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="Author" runat="server" Text='' Width="220px" MaxLength="100"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                        ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Author"
                                                                                        Display="Dynamic" ErrorMessage="声明人必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                        请填写声明人（作者）。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">公告时间：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="RepDate" runat="server" Text='' Width="220px" MaxLength="100"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                        ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        请填写公告时间，例如：二〇一四年三月十二日。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">公司声明：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="RepDesc" runat="server" Text='' Width="450px" Height="120px"
                                                                                    TextMode="MultiLine"></asp:TextBox></span><span class="ManageLineDesc" style="margin-left:200px;"><asp:Label
                                                                                        ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        请填写公司声明。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">内容：</span><span class="ManageLineInput" style="width:85%;">
                                                                                <asp:TextBox ID="RepContent" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
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
