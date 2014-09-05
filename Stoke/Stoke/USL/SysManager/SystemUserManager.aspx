﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemUserManager.aspx.cs"
    Inherits="Stoke.USL.SysManager.SystemUserManager" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
    <script>
        function addVerify() {
            if (!pattern1.test(loginName)) {  
                alert("用户编号是长度为4位的数字"); 
                return false;  
            }
            if (!pattern.test(email)) {  
                alert("请输入正确的邮箱地址"); 
                return false;  
            }
    </script>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
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
                                                                        用户管理</td>
                                                                    <td width="120">
                                                                        <img height="16" src="../../images/ico_04.gif" width="17" align="absmiddle"><a href="SystemUser.aspx">返回用户列表</a></td>
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
                                                                            <legend>用户基本信息</legend>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">用户编号：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="loginNameTbx" runat="server" Text='' Width="180px" MaxLength="4"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="loginNameTbx"
                                                                                            Display="Dynamic" ErrorMessage="用户编号必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="loginNameTbx"
                                                                                            Display="Dynamic" ErrorMessage="请输入4位数字!" ValidationExpression="^\d{4}$"></asp:RegularExpressionValidator>请填写用户编号,长度4位。</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">真实姓名：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="nameTbx" runat="server" Text='' Width="180px" MaxLength="15"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="nameTbx"
                                                                                            Display="Dynamic" ErrorMessage="真实姓名必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>请填写真实姓名。</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">&nbsp; &nbsp; &nbsp; &nbsp; 性别：</span><span class="ManageLineInput"><asp:RadioButton
                                                                                    ID="sexMaleRbtn" runat="server" Checked="True" GroupName="1" Text="男" />
                                                                                    &nbsp;&nbsp;
                                                                                    <asp:RadioButton ID="sexFemaleRbtn" runat="server" GroupName="1" Text="女" /></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        请选择性别。</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">职务名称：</span><span class="ManageLineInput">
                                                                                    <asp:DropDownList ID="posiDdl" runat="server" Width="185px">
                                                                                    </asp:DropDownList></span><span class="ManageLineDesc"><asp:Label ID="Label11" runat="server"
                                                                                    ForeColor="Red" Text="*"></asp:Label>
                                                                                    请填写用户现任职务。</span><div class="clear">
                                                                                    </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">部门名称：</span><span class="ManageLineInput">
                                                                                    <asp:DropDownList ID="CompanyName" runat="server" Width="185px">
                                                                                    </asp:DropDownList>
                                                                                </span><span class="ManageLineDesc"><asp:Label ID="Label5" runat="server"
                                                                                    ForeColor="Red" Text="*"></asp:Label>
                                                                                    请填写用户所在部门。</span><div class="clear">
                                                                                    </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">固定电话：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="FixedPhoneTbx" runat="server" Text='' Width="180px" MaxLength="20"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label13" runat="server" ForeColor="White" Text="*"></asp:Label>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入正确的固定电话格式。"
                                                                                            ValidationExpression="(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$" ControlToValidate="FixedPhoneTbx"
                                                                                            Display="Dynamic"></asp:RegularExpressionValidator>电话格式如010-68631111或0451-82521111
                                                                                    </span>
                                                                                <div class="clear">
                                                                                </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">移动电话1：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="Mobile1Tbx" runat="server" Text='' Width="180px" MaxLength="11"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label4" runat="server" ForeColor="WhiteSmoke"
                                                                                            Text="*"></asp:Label>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mobile1Tbx"
                                                                                            Display="Dynamic" ErrorMessage="请输入正确的手机号" ValidationExpression="^(13[0-9]|15[0-3,5-9]|18[0,5-9]|147)\d{8}$"></asp:RegularExpressionValidator>请填写当前常用手机号。</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">移动电话2：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="Mobile2Tbx" runat="server" Text='' Width="180px" MaxLength="11"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label14" runat="server" ForeColor="WhiteSmoke"
                                                                                            Text="*"></asp:Label>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Mobile2Tbx"
                                                                                            Display="Dynamic" ErrorMessage="请输入正确的手机号" ValidationExpression="^(13[0-9]|15[0-3,5-9]|18[0,5-9]|147)\d{8}$"></asp:RegularExpressionValidator></span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">
                                                                                    <asp:Label ID="Label8" runat="server" Text="登录密码："></asp:Label></span><span class="ManageLineInput">
                                                                                        <asp:TextBox ID="pwdTbx" runat="server" Text='' Width="180px" MaxLength="25" TextMode="Password"></asp:TextBox></span><span
                                                                                            class="ManageLineDesc"><asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pwdTbx"
                                                                                                Display="Dynamic" ErrorMessage="登录密码必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="pwdTbx"
                                                                                                Display="Dynamic" ErrorMessage="密码长度在6-25之间!" ValidationExpression="^[0-9a-zA-Z_]\w{5,24}$"></asp:RegularExpressionValidator>由字母和汉字组成,长度为6-25位。</span><div
                                                                                                    class="clear">
                                                                                                </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">
                                                                                    <asp:Label ID="Label9" runat="server" Text="确认密码："></asp:Label></span><span class="ManageLineInput">
                                                                                        <asp:TextBox ID="verifyPwdTbx" runat="server" Text='' Width="180px" MaxLength="25"
                                                                                            TextMode="Password"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                                ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="verifyPwdTbx"
                                                                                                    Display="Dynamic" ErrorMessage="确认密码不能为空!"></asp:RequiredFieldValidator>
                                                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="确认密码与登录密码不一致!"
                                                                                                    ControlToCompare="pwdTbx" ControlToValidate="verifyPwdTbx" Display="Dynamic"></asp:CompareValidator>
                                                                                                请再次填写用户登录密码以确认。</span><div class="clear">
                                                                                                </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">电子邮箱：</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="EmailTbx" runat="server" Text='' Width="180px" MaxLength="50"></asp:TextBox></span>
                                                                                <span class="ManageLineDesc">
                                                                                    <asp:Label ID="Label12" runat="server" ForeColor="White" Text="*"></asp:Label>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTbx"
                                                                                        ErrorMessage="请输入正确格式的邮箱地址" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                                                                    请填写用户常用电子邮箱。</span>
                                                                                <div class="clear">
                                                                                </div>
                                                                            </div>
                                                                        </fieldset>
                                                                        <fieldset>
                                                                            <legend>用户角色</legend>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <br />
                                                                                <span class="ManageLineTitle">用户角色：</span><span class="ManageLineInput" style="width: 207px">
                                                                                    <span class="ManageLineDesc" style="color: red">用户已选角色</span>&nbsp;<br />
                                                                                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                                                        <contenttemplate>
                                                                            <asp:ListBox ID="roleLbx" runat="server" Height="200px" Width="180px"></asp:ListBox>
</contenttemplate>
                                                                                    </asp:UpdatePanel></span><span class="ManageLineInput" style="width: 115px"><br />
                                                                                        <br />
                                                                                        <span class="ManageLineDesc" style="color: red">为用户添加角色</span><br />
                                                                                        &nbsp; &nbsp;&nbsp;&nbsp;
                                                                                        <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                                                                            <contenttemplate>
&nbsp; &nbsp;
                                                                                <asp:Button ID="roleAddBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                                                                    OnClick="roleAddBtn_Click" Text="<<    <<" />
</contenttemplate>
                                                                                        </asp:UpdatePanel><br />
                                                                                        <br />
                                                                                        <br />
                                                                                        <br />
                                                                                        &nbsp; &nbsp;&nbsp;&nbsp;
                                                                                        <asp:UpdatePanel id="UpdatePanel4" runat="server">
                                                                                            <contenttemplate>
&nbsp; &nbsp;
                                                                                <asp:Button ID="roleDelBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                                                                    OnClick="roleDelBtn_Click" Text=">>    >>" />
</contenttemplate>
                                                                                        </asp:UpdatePanel><br />
                                                                                        <span class="ManageLineDesc" style="color: red">删除已选角色</span><br />
                                                                                    </span><span class="ManageLineInput" style="color: red"><span class="ManageLineDesc"
                                                                                        style="color: red">候选角色</span>&nbsp;<br />
                                                                                        <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                                                                            <contenttemplate>
                                                                                <asp:ListBox ID="CandidateRoleLbx" runat="server" Height="200px" Width="180px"></asp:ListBox>
</contenttemplate>
                                                                                        </asp:UpdatePanel></span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                        </fieldset>
                                                                        <div class="ManageSub">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                            <asp:Button ID="addBtn" runat="server" CausesValidation="True" CssClass="btn12" Text="添 加"
                                                                                OnClick="addBtn_Click" OnClientClick="return addVerify()"></asp:Button>
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