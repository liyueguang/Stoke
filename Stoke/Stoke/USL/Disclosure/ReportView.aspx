<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ReportView.aspx.cs" Inherits="Stoke.USL.Disclosure.ReportView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告浏览</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .wordstyle{
             font-size:22px;
             font-family:宋体;
             height:70px;
             line-height:40px;
        }
        
        .wordstyle1{
             font-size:16px;
             font-family:宋体;
             font-weight:bold;   
             text-indent:3em;
             line-height:25px;
             height:80px;
        }
    </style>
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
                                                        公告详情</td>
                                                    <td style="height: 28px;" width="250px" valign="middle">
                                                        <img height="16px" src="../../images/ico_04.gif" width="17px">
                                                        <%if (flag == "2")
                                                      { %>
                                                        <a href="../MainForm/mainWin.aspx">返回上一级</a>
                                                        <%}
                                                      else if (flag == "1")
                                                      { %>
                                                        <a href="ReportList.aspx">返回上一级</a>
                                                      <%}%>
                                                        <img src="../../images/L4.gif"  style="vertical-align:middle;"/>
                                                        <asp:LinkButton ID="Word" runat="server" OnClick="Word_Click">导出Word</asp:LinkButton><img src="../../images/L4.gif" style="vertical-align:middle;"/>
                                                        <asp:LinkButton ID="PDF" runat="server" OnClick="PDF_Click">导出PDF</asp:LinkButton>
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
                                                    <td class="aa05" valign="top" align="center">
                                                        <table width="90%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td width="33.3%" align="center" class="wordstyle">
                                                                    <%=ShareName %>
                                                                </td>
                                                                <td width="33.3%" align="center" class="wordstyle">
                                                                    <%=ShareID %>
                                                                </td>
                                                                <td align="center" class="wordstyle">
                                                                    <%=RepID %>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center" class="wordstyle" valign="bottom">
                                                                    <%=Company %>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" class="wordstyle" align="center" valign="top" style="font-weight:bold;">
                                                                    <%=RepName %>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" class="wordstyle1" align="left">
                                                                    <%=RepDesc %>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" class="wordstyle" align="left">
                                                                    <%=RepContent.Replace("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", "&nbsp;&nbsp;&nbsp;")%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="right" style="padding-top:30px;">
                                                                    <table>
                                                                        <tr>
                                                                            <td class="wordstyle" align="center">
                                                                                <%=Company %><br/>
                                                                                <%=Author %><br/>
                                                                                <%=RepDate %>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    
                                                                </td>
                                                            </tr>
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
