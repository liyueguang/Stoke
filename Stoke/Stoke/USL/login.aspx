<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Stoke.USL.login" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>挂牌企业专用金融管理系统</title>
    <link type="text/css" rel="stylesheet" href="../css/login.css" />

    <script language="javascript">
        function freset(){
            document.getElementById("uname").value = "";
            document.getElementById("passwd").setAttribute("value","");
            return false;
        }
        
        function verify(){
            var uname = document.getElementById("uname").value;
            if(uname=="")
            {
                alert("请填写用户名！");
                return false;
            }
            
            var passwd = document.getElementById("passwd").value;
            if(passwd=="")
            {
                alert("请填写密码！");
                return false;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="maindiv" runat="server">
            <div id="header">
            </div>
            <div id="main">
                <table id="ltb">
                    <tr>
                        <td width="73px" height="30px">
                            <span class="ustyle"><font face="隶书">用户名</font></span>
                        </td>
                        <td>
                            <asp:TextBox ID="uname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="50px">
                            <span class="ustyle"><font face="隶书">密&nbsp;&nbsp;码</font></span>
                        </td>
                        <td>
                            <asp:TextBox ID="passwd" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="35px">
                        </td>
                        <td>
                            <asp:CheckBox ID="keeppwd" runat="server" Text="记住我的密码" Font-Size="15px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="40px">
                        </td>
                        <td>
                            <asp:ImageButton ID="login1" runat="server" ImageUrl="../images/login.jpg" OnClientClick="return verify();"
                                OnClick="login_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="clear" runat="server" ImageUrl="../images/clear.jpg" OnClientClick="return freset();" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" height="90px" style="padding-top:17px;">
                            <span class="zstyle">注意：</span>
                        </td>
                        <td>
                            <span class="zstyle">1.&nbsp;&nbsp;不要在公共场合保存登录信息。<br />
                                2.&nbsp;&nbsp;尽量避免多人使用同一账号。<br />
                                3.&nbsp;&nbsp;为保障您的账号安全，退出系统时请注销登录。</span>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="footer">
                 <span class="fstyle">版权所有 Copyright&copy; 2013-2014&nbsp;&nbsp;清大益讯（北京）投资管理有限公司</span>
            </div>
        </div>
    </form>
</body>
</html>
