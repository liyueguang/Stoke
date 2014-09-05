<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemUserInfo.aspx.cs"
    Inherits="Stoke.USL.SysManager.SystemUserInfo" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>������Ϣ����</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />

    <script language="javascript">
        function leileiVerify() {
	        var pwd = document.getElementById("pwdTbx").value;
	        var pwdVerify = document.getElementById("verifyPwdTbx").value;
	        if(pwd == '') {
		        alert('���벻��Ϊ�գ�');
		        return false;
	        }
	        if(pwdVerify == '') {
		        alert('ȷ�����벻��Ϊ�գ�');
		        return false;
	        }
	        var patrn = /^[0-9a-zA-Z_]\w{5,24}$/;
	        if(!patrn.exec(pwd)) {
		        alert('����Ӧ����6-25λ���ֻ���ĸ���ɣ�');
		        return false;
	        }
	        if(pwd != pwdVerify) {
		        alert('�����������벻һ�£�');
		        return false;
	        }
        }
        
        function addVerify() {
            var loginName = document.getElementById("loginNameTbx").value;
            if(loginName == '') {
		        alert('�û���Ų���Ϊ�գ�');
		        return false;
	        }
	        var pattern1 = /^[0-9]{4}$/;  
            if (!pattern1.test(loginName)) {  
                alert("�û�����ǳ���Ϊ4λ������"); 
                return false;  
            }
	        
	        var name = document.getElementById("nameTbx").value;
            if(name == '') {
		        alert('�û���ʵ��������Ϊ�գ�');
		        return false;
	        }
	        
	        var email = document.getElementById("EmailTbx").value;
	        var pattern = /^([\.a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;  
            if (!pattern.test(email)) {  
                alert("��������ȷ�������ַ"); 
                return false;  
            }
                        var mobile1Tbx = document.getElementById("Mobile1Tbx").value;            if(mobile1Tbx != ""&&mobile1Tbx != null){	            var pattern = /^(13[0-9]|15[0-9]|18[0-9]|14[0-9])\d{8}$/;  
                if (!pattern.test(mobile1Tbx)) {  
                    alert("��������ȷ���ֻ�����1"); 
                    return false;  
                }            }                        var mobile2Tbx = document.getElementById("Mobile2Tbx").value;            if(mobile2Tbx != ""&&mobile2Tbx != null){	            var pattern = /^(13[0-9]|15[0-9]|18[0-9]|14[0-9])\d{8}$/;  
                if (!pattern.test(mobile2Tbx)) {  
                    alert("��������ȷ���ֻ�����2"); 
                    return false;  
                }            }
        }
    </script>

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
                                                                        ������Ϣ����</td>
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
                                                                            <legend>�û����˻�����Ϣ</legend>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">�û���ţ�</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="loginNameTbx" runat="server" Text='' Width="180px" MaxLength="4"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="loginNameTbx"
                                                                                            Display="Dynamic" ErrorMessage="�û���ű�����д!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="loginNameTbx"
                                                                                            Display="Dynamic" ErrorMessage="������4λ����!" ValidationExpression="^\d{4}$"></asp:RegularExpressionValidator>����д�û����,����4λ��</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">��ʵ������</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="nameTbx" runat="server" Text='' Width="180px" MaxLength="30"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="nameTbx"
                                                                                            Display="Dynamic" ErrorMessage="��ʵ����������д!" SetFocusOnError="True"></asp:RequiredFieldValidator>����д��ʵ������</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">&nbsp; &nbsp; &nbsp; &nbsp; �Ա�</span><span class="ManageLineInput"><asp:RadioButton
                                                                                    ID="sexMaleRbtn" runat="server" Checked="True" GroupName="1" Text="��" />
                                                                                    &nbsp;&nbsp;
                                                                                    <asp:RadioButton ID="sexFemaleRbtn" runat="server" GroupName="1" Text="Ů" /></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                        ��ѡ���Ա�</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">ְ�����ƣ�</span><span class="ManageLineInput">
                                                                                <asp:DropDownList ID="posiDdl" runat="server" Width="185px">
                                                                                    </asp:DropDownList></span>
                                                                                <span class="ManageLineDesc"><asp:Label ID="Label11" runat="server"
                                                                                    ForeColor="Red" Text="*"></asp:Label>
                                                                                    ����д�û�����ְ��</span><div class="clear">
                                                                                    </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">�������ƣ�</span><span class="ManageLineInput">
                                                                                    <asp:DropDownList ID="CompanyName" runat="server" Width="185px">
                                                                                    </asp:DropDownList>
                                                                                </span><span class="ManageLineDesc"><asp:Label ID="Label5" runat="server"
                                                                                    ForeColor="Red" Text="*"></asp:Label>
                                                                                    ����д�û����ڲ��š�</span><div class="clear">
                                                                                    </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">�̶��绰��</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="FixedPhoneTbx" runat="server" Text='' Width="180px" MaxLength="25"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label13" runat="server" ForeColor="White" Text="*"></asp:Label>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="��������ȷ�Ĺ̶��绰��ʽ��"
                                                                                            ValidationExpression="(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$" ControlToValidate="FixedPhoneTbx"
                                                                                            Display="Dynamic"></asp:RegularExpressionValidator>�绰��ʽ��010-68631111��0451-82521111
                                                                                    </span>
                                                                                <div class="clear">
                                                                                </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">�ƶ��绰1��</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="Mobile1Tbx" runat="server" Text='' Width="180px" MaxLength="11"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label4" runat="server" ForeColor="WhiteSmoke"
                                                                                            Text="*"></asp:Label>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Mobile1Tbx"
                                                                                            Display="Dynamic" ErrorMessage="��������ȷ���ֻ���" ValidationExpression="^(13[0-9]|15[0-3,5-9]|18[0,5-9]|147)\d{8}$"></asp:RegularExpressionValidator>����д��ǰ�����ֻ��š�</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">�ƶ��绰2��</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="Mobile2Tbx" runat="server" Text='' Width="180px" MaxLength="11"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"><asp:Label ID="Label14" runat="server" ForeColor="WhiteSmoke"
                                                                                            Text="*"></asp:Label>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Mobile2Tbx"
                                                                                            Display="Dynamic" ErrorMessage="��������ȷ���ֻ���" ValidationExpression="^(13[0-9]|15[0-3,5-9]|18[0,5-9]|147)\d{8}$"></asp:RegularExpressionValidator></span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">�������䣺</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="EmailTbx" runat="server" Text='' Width="180px" MaxLength="50"></asp:TextBox></span>
                                                                                <span class="ManageLineDesc">
                                                                                    <asp:Label ID="Label12" runat="server" ForeColor="Red" Text="*"></asp:Label>����д�û����õ������䡣</span>
                                                                                <div class="clear">
                                                                                </div>
                                                                            </div>
                                                                        </fieldset>
                                                                        <fieldset id="roleid" runat="server">
                                                                            <legend>�û���ɫ</legend>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <br />
                                                                                <span class="ManageLineTitle">�û���ɫ��</span><span class="ManageLineInput" style="width: 207px">
                                                                                    <span class="ManageLineDesc" style="color: red">�û���ѡ��ɫ</span>&nbsp;<br />
                                                                                    <asp:UpdatePanel id="UpdatePanel8" runat="server">
                                                                                        <contenttemplate>
                                                                            <asp:ListBox ID="roleLbx" runat="server" Height="200px" Width="180px"></asp:ListBox>
</contenttemplate>
                                                                                    </asp:UpdatePanel></span><span class="ManageLineInput" style="width: 115px"><br />
                                                                                        <br />
                                                                                        <span class="ManageLineDesc" style="color: red">Ϊ�û���ӽ�ɫ</span><br />
                                                                                        &nbsp; &nbsp;&nbsp;&nbsp;
                                                                                        <asp:UpdatePanel id="UpdatePanel10" runat="server">
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
                                                                                        <asp:UpdatePanel id="UpdatePanel11" runat="server">
                                                                                            <contenttemplate>
&nbsp;&nbsp;&nbsp; <asp:Button id="roleDelBtn" onclick="roleDelBtn_Click" runat="server" Text=">>    >>" CssClass="btn12" CausesValidation="True"></asp:Button> 
</contenttemplate>
                                                                                        </asp:UpdatePanel><br />
                                                                                        <span class="ManageLineDesc" style="color: red">ɾ����ѡ��ɫ</span><br />
                                                                                    </span><span class="ManageLineInput" style="color: red"><span class="ManageLineDesc"
                                                                                        style="color: red">��ѡ��ɫ</span>&nbsp;<br />
                                                                                        <asp:UpdatePanel id="UpdatePanel9" runat="server">
                                                                                            <contenttemplate>
                                                                                <asp:ListBox ID="CandidateRoleLbx" runat="server" Height="200px" Width="180px"></asp:ListBox>
</contenttemplate>
                                                                                        </asp:UpdatePanel></span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                        </fieldset>
                                                                        <div class="ManageSub">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                            <asp:Button ID="updBtn" runat="server" CausesValidation="True" CssClass="btn12" Text="�� ��"
                                                                                OnClick="updBtn_Click" OnClientClick="return addVerify()"></asp:Button>
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button
                                                                                ID="cancelBtn" runat="server" CausesValidation="False" CssClass="btn12" Text="ȡ ��"
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
                                    <td>
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
                                                                        �û���������</td>
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
                                                                            <legend>���·����û�����</legend>
                                                                            <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                                <span class="ManageLineTitle">�û���ʶ��</span><span class="ManageLineInput">
                                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='' Width="180px" MaxLength="4" Enabled="False"></asp:TextBox></span><span
                                                                                        class="ManageLineDesc"> &nbsp; ��ǰ�û����û���š�</span><div class="clear">
                                                                                        </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseout="this.className='ManageLine'" onmouseover="this.className='ManageLine-hover'">
                                                                                <span class="ManageLineTitle">
                                                                                    <asp:Label ID="Label8" runat="server" Text="��¼���룺"></asp:Label></span><span class="ManageLineInput">
                                                                                        <asp:TextBox ID="pwdTbx" runat="server" MaxLength="25" Text="" TextMode="Password"
                                                                                            Width="180px"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label ID="Label6"
                                                                                                runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                                ����ĸ�ͺ������,����Ϊ6-25λ��</span><div class="clear">
                                                                                                </div>
                                                                            </div>
                                                                            <div class="ManageLine" onmouseout="this.className='ManageLine'" onmouseover="this.className='ManageLine-hover'">
                                                                                <span class="ManageLineTitle">
                                                                                    <asp:Label ID="Label9" runat="server" Text="ȷ�����룺"></asp:Label></span><span class="ManageLineInput">
                                                                                        <asp:TextBox ID="verifyPwdTbx" runat="server" MaxLength="25" Text="" TextMode="Password" 
                                                                                            Width="180px"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label ID="Label7"
                                                                                                runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                                ���ٴ���д�û���¼������ȷ�ϡ�</span>
                                                                                <div class="clear">
                                                                                </div>
                                                                            </div>
                                                                        </fieldset>
                                                                        <div class="ManageSub">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CssClass="btn12"
                                                                                OnClientClick="return leileiVerify()" OnClick="Button1_Click" Text="ȷ ��" />
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button
                                                                                ID="Button2" runat="server" CausesValidation="False" CssClass="btn12" OnClick="Button2_Click"
                                                                                Text="ȡ ��" /></div>
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
