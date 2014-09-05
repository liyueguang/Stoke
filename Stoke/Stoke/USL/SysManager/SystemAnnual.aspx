<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemAnnual.aspx.cs" Inherits="Stoke.USL.SysManager.SystemAnnual" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业年报提醒设置</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
    <SCRIPT language="JavaScript" src="../../My97DatePicker/WdatePicker.js"></SCRIPT>
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
                                                                        企业年报提醒设置</td>
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
                                                                    <td class="aa05" valign="top" style="height: 636px">
                                                                        <fieldset>
                                                                            <legend>企业年报设置</legend>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">年报披露日期：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="annualDate" runat="server" Text='' Width="180px" onfocus="WdatePicker({skin:'default',dateFmt:'yyyy-MM-dd'});"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="annualDate"
                                                                                            Display="Dynamic" ErrorMessage="年报披露日期必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>请填写年报披露日期,格式为2012-01-01。<br />
                                                                                        &nbsp;&nbsp;系统会提前一个月提醒客户填写年报，提前10天提醒客户报送年报给推荐机构</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <br />
                                                                                <span class="ManageLineTitle" style="width: 130px;">年报提醒用户：</span><span class="ManageLineInput"
                                                                                    style="width: 207px"> <span class="ManageLineDesc" style="color: red">已选提醒用户</span>&nbsp;<br />
                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:ListBox ID="roleLbx" runat="server" Height="200px" Width="180px" SelectionMode="Multiple">
                                                                                            </asp:ListBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </span><span class="ManageLineInput" style="width: 115px">
                                                                                    <br />
                                                                                    <br />
                                                                                    <span class="ManageLineDesc" style="color: red">添加提醒用户</span><br />
                                                                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                        <ContentTemplate>
                                                                                            &nbsp; &nbsp;<asp:Button ID="roleAddBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                                                                                Text="<<    <<" OnClick="roleAddBtn_Click" />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <br />
                                                                                    <br />
                                                                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                        <ContentTemplate>
                                                                                            &nbsp; &nbsp;<asp:Button ID="roleDelBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                                                                                Text=">>    >>" OnClick="roleDelBtn_Click" />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <br />
                                                                                    <span class="ManageLineDesc" style="color: red">删除提醒用户</span><br />
                                                                                </span><span class="ManageLineInput" style="color: red"><span class="ManageLineDesc"
                                                                                    style="color: red">候选提醒用户</span>&nbsp;<br />
                                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:ListBox ID="CandidateRoleLbx" runat="server" Height="200px" Width="180px" SelectionMode="Multiple">
                                                                                            </asp:ListBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </span>
                                                                                <div class="clear">
                                                                                </div>
                                                                            </div>
                                                                        </fieldset>
                                                                        <br />
                                                                        <br />
                                                                        <fieldset>
                                                                            <legend>企业半年报设置</legend>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">半年报披露日期1：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="halfAnnualDate1" runat="server" Text='' Width="180px" onfocus="WdatePicker({skin:'default',dateFmt:'yyyy-MM-dd'});" ></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="halfAnnualDate1"
                                                                                            Display="Dynamic" ErrorMessage="半年报披露日期必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>请填写半年报披露日期,格式为2012-01-01。</span><div
                                                                                                    class="clear">
                                                                                                </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle" style="width: 130px;">半年报披露日期2：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="halfAnnualDate2" runat="server" Text='' Width="180px" onfocus="WdatePicker({skin:'default',dateFmt:'yyyy-MM-dd'});"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="halfAnnualDate2"
                                                                                            Display="Dynamic" ErrorMessage="半年报披露日期必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>请填写半年报披露日期,格式为2012-01-01。<br />
                                                                                        &nbsp;&nbsp;系统会提前一个月提醒客户填写半年报，提前10天提醒客户报送半年报给推荐机构</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <br />
                                                                                <span class="ManageLineTitle" style="width: 130px;">半年报提醒用户：</span><span class="ManageLineInput"
                                                                                    style="width: 207px"> <span class="ManageLineDesc" style="color: red">已选提醒用户</span>&nbsp;<br />
                                                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:ListBox ID="roleLbx2" runat="server" Height="200px" Width="180px" SelectionMode="Multiple">
                                                                                            </asp:ListBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </span><span class="ManageLineInput" style="width: 115px">
                                                                                    <br />
                                                                                    <br />
                                                                                    <span class="ManageLineDesc" style="color: red">添加提醒用户</span><br />
                                                                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                                                                    <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                                        <ContentTemplate>
                                                                                            &nbsp; &nbsp;<asp:Button ID="roleAddBtn2" runat="server" CausesValidation="True"
                                                                                                CssClass="btn12" Text="<<    <<" OnClick="roleAddBtn2_Click" />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <br />
                                                                                    <br />
                                                                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                                                                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                                        <ContentTemplate>
                                                                                            &nbsp; &nbsp;<asp:Button ID="roleDelBtn2" runat="server" CausesValidation="True"
                                                                                                CssClass="btn12" Text=">>    >>" OnClick="roleDelBtn2_Click" />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <br />
                                                                                    <span class="ManageLineDesc" style="color: red">删除提醒用户</span><br />
                                                                                </span><span class="ManageLineInput" style="color: red"><span class="ManageLineDesc"
                                                                                    style="color: red">候选提醒用户</span>&nbsp;<br />
                                                                                    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:ListBox ID="CandidateRoleLbx2" runat="server" Height="200px" Width="180px" SelectionMode="Multiple">
                                                                                            </asp:ListBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </span>
                                                                                <div class="clear">
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
                                                                    <td valign="top" width="4" bgcolor="#f0f0f0" style="height: 636px">
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
