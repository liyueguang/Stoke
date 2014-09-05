<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance.aspx.cs" Inherits="Stoke.USL.Disclosure.Finance" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>金融知识</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
        var DOM = (document.getElementById) ? 1 : 0; 
        var NS4 = (document.layers) ? 1 : 0; 
        var IE4 = 0; 
        if (document.all) 
        { 
             IE4 = 1; 
             DOM = 0; 
        }
        var win = window;    
        var n    = 0;

        function findIt() {
             var ssgjz = document.getElementById("Guanjianzi").value;
             if (ssgjz != ""){
                 findInPage(ssgjz);
             }else{
                alert("搜索关键字不能为空！");
                return false;
             }
        }

        function findInPage(str) { 
            var txt, i, found;

            if (str == "")
                 return false;

            if (DOM) 
            { 
                 win.find(str, false, true); 
                 return true; 
            }

            if (NS4) { 
                 if (!win.find(str)) 
                     while(win.find(str, false, true)) 
                         n++; 
                 else 
                     n++;

                 if (n == 0) 
                     alert("未找到指定内容."); 
            }

            if (IE4) { 
                 txt = win.document.body.createTextRange();
                 for (i = 0; i <= n && (found = txt.findText(str)) != false; i++) { 
                     txt.moveStart("character", 1); 
                     txt.moveEnd("textedit"); 
                 }

            if (found) { 
                 txt.moveStart("character", -1); 
                 txt.findText(str); 
                 txt.select(); 
                 txt.scrollIntoView(); 
                 n++; 
            } 
            else { 
                 if (n > 0) { 
                     n = 0; 
                     findInPage(str); 
                 } 
                 else 
                     alert("未找到指定内容."); 
                 } 
            }
            return false; 
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
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
                                                                        金融知识</td>
                                                                    <td width="120">
                                                                        <img height="16" src="../../images/ico_04.gif" width="17" align="absmiddle"><a href="EditFinance.aspx?ID=1">
                                                                            编辑金融知识</a>
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
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td style="width: 15%; height: 25px; text-align: right;">
                                                                                    查询条件：</td>
                                                                                <td style="width: 15%; height: 25px; text-align: right;">
                                                                                    关键字</td>
                                                                                <td style="width: 6px; height: 25px; text-align: right">
                                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="../../images/L4.gif"></asp:Image></td>
                                                                                <td style="width: 35%; height: 25px;">
                                                                                    <asp:TextBox ID="Guanjianzi" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="Guanjianzi_TextChanged"></asp:TextBox></td>
                                                                                <td style="height: 25px;" align=center>
                                                                                  <input type="button" id="SearchBtn" value="页内查找" onclick="return findIt();" class="btn12"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" style="height: 25px; text-align: left">
                                                                                    <hr />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" style="padding:10px;">
                                                                                    <%=stext %>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        </ContentTemplate>
                                                                        </asp:UpdatePanel>
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
    </div>
    </form>
</body>
</html>
