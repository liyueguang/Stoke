<%@ Page Language="C#" AutoEventWireup="true" Codebehind="mainWin.aspx.cs" Inherits="Stoke.USL.MainForm.mainWin" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ҳ</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .cp{
	        text-indent:10px;
	        border-bottom-width:2px;
	        border-bottom-style:dashed;
	        border-bottom-color:#CCCCCC;
            color:Gray;
            vertical-align:bottom;
            font-size:15px;
        }
        .cpp{
	        text-indent:10px;
	        border-bottom-width:1px;
	        border-bottom-style:dashed;
	        border-bottom-color:#CCCCCC;
            color:Gray;
            vertical-align:bottom;
            font-size:12px;
        }
        
        .caltitle{
            border-width:0px 0px 3px 0px;
            border-style:solid;
            border-color:black;
        }
    </style>
    <style type="text/css">
        #cal{width:300px;font-size:11px;margin:0px 0 0 5px;}
        #cal #top{height:21px;line-height:22px;background:#e7eef8;color:#003784;padding-left:10px;}
        #cal #top select{font-size:11px;}
        #cal #top input{padding:0;}
        #cal ul#wk{margin:0;padding:0;height:18px;}
        #cal ul#wk li{float:left;width:42px;text-align:center;line-height:18px;list-style:none;}
        #cal ul#wk li b{font-weight:normal;color:#c60b02;}
        #cal #cm{clear:left;border-top:1px solid #ddd;position:relative;}
        #cal #cm .cell{position:absolute;width:38px;height:30px;text-align:center;margin:0 0 0 3px;}
        #cal #cm .cell .so{font:bold 14px arial;}
        #cal #fd{display:none;position:absolute;border:1px solid #dddddf;background:#feffcd;padding:10px;line-height:21px;width:150px;}
        #cal #fd b{font-weight:normal;color:#c60a00;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" height="100%" border="0" width="100%">
            <tbody>
                <tr>
                    <td valign="top" width="64%" height="34%">
                        <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                            <tbody>
                                <tr>
                                    <td valign="top" height="10px">
                                       </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td width="7px" height="35px" background="../../images/mainWin01.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin09.jpg">
                                                        <div style="width: 196px; height: 35px; background-image: url('../../images/mainWin07.jpg');">
                                                            <table cellspacing="0" cellpadding="0" style="height:100%;">
                                                                <tr>
                                                                    <td width="50px"></td>
                                                                    <td>
                                                                        <img src="../../images/mainWin10.png" width="18px" height="18px" />&nbsp;</td>
                                                                    <td style="font-size: 15px; font-family: ����; font-weight: bold; color: White;">
                                                                        ��������
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td background="../../images/mainWin09.jpg" align="right">
                                                         <a href='../Message/MsgReceiveList.aspx'><img class="aa04" alt="�鿴������Ϣ" src="../../images/main_29.gif" border="0"></a>
                                                    </td>
                                                    <td width="7px" background="../../images/mainWin08.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="100%" background="../../images/mainWin02.jpg">
                                                    </td>
                                                    <td valign="top" align="center" colspan="2">
                                                        <table width="100%" height="100%" style="margin-top:20px;">
                                                            <tr>
                                                                <td width="20%" valign="top" align="right">
                                                                    <img src="../../images/mainWin26.png" />&nbsp;
                                                                </td>
                                                                <td width="30%" align="left" valign="top" style="font-size:14px; font-family:΢���ź�; line-height:27px; padding-top:20px;">
                                                                    ������<span style="width:25px; text-align:center;display: inline-block;"><%=allnum%></span>��<font color="#085faf">����</font><br/>
                                                                    <span style="padding-left:14px;">����<span style="width:25px; text-align:center;display: inline-block;"><%=worktodo%></span>��</span><font color="#085faf"><a href="../Workflow/Work_Manage.aspx">���칤��</a></font><br/>
                                                                    <span style="padding-left:14px;">����<span style="width:25px; text-align:center;display: inline-block;"><%=workall %></span>��</span><font color="#085faf"><a href="../Workflow/Work_Record.aspx">�Ѱ칤��</a></font><br/>
                                                                </td>
                                                                <td width="20%" valign="top" align="right">
                                                                    <img src="../../images/mainWin27.png" />&nbsp;
                                                                </td>
                                                                <td align="left" valign="top" style="font-size:14px; font-family:΢���ź�; line-height:27px; padding-top:20px;">
                                                                    �ռ��䣨<%=mailall%>&nbsp;�⣩<br/>
                                                                    ����<span style="width:25px; text-align:center;display: inline-block;"><%=unread %></span>��<font color="#085faf"><a href="../Message/MsgReceiveList.aspx">δ���ʼ�</a></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td background="../../images/mainWin06.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="7px" background="../../images/mainWin03.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin04.jpg" colspan="2">
                                                    </td>
                                                    <td background="../../images/mainWin05.jpg">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="16px">
                        &nbsp;</td>
                    <td valign="top" width="34%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                            <tbody>
                                <tr>
                                    <td valign="top" style="height: 10px">
                                       </td>
                                </tr>
                                <tr>
                                    <td valign="top" width="100%">
                                        <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td width="6px" height="30px" background="../../images/mainWin13.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin21.jpg">
                                                        <div style="width: 137px; height: 30px; background-image: url('../../images/mainWin14.jpg');">
                                                            <table cellspacing="0" cellpadding="0" style="height:100%;">
                                                                <tr>
                                                                    <td width="6px"></td>
                                                                    <td>
                                                                        <img src="../../images/mainWin24.png" width="14px" height="17px" />&nbsp;</td>
                                                                    <td style="font-size: 14px; font-family: ����; font-weight: bold; color: #0091d3;">
                                                                        �����ճ�
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td width="14px" background="../../images/mainWin15.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="100%" background="../../images/mainWin16.jpg">
                                                    </td>
                                                    <td valign="top" align="center">
                                                        <asp:Calendar ID="Calendar1" Width="95%" Height="100%" runat="server" SelectionMode="None" onprerender="Calendar1_PreRender" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="FullMonth">
                                                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                            <TodayDayStyle BackColor="#CCCCCC" />
                                                            <OtherMonthDayStyle ForeColor="#999999" />
                                                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                            <TitleStyle BackColor="White" CssClass="caltitle" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                        </asp:Calendar>
                                                        <%--<div id="cal"><div id="top">��Ԫ&nbsp;<select></select>&nbsp;��&nbsp;<select></select>&nbsp;��&nbsp;&nbsp;ũ��<span></span>��&nbsp;[<span></span>��]<input type="button" value="�ص�����" title="�������ת�ؽ���" style="padding:0px; display:none;"></div><ul id="wk"><li>һ</li><li>��</li><li>��</li><li>��</li><li>��</li><li><b>��</b></li><li><b>��</b></li></ul><div id="cm"></div><div id="bm" style=" display:none;"><a target="_blank" onMouseDown="return c({'fm':'alop','title':this.innerHTML,'url':this.href,'p1':al_c(this),'p2':1})" href="javascript:void(0)">��ʷ�ϵĽ���</a></div></div>
                                                        <script type="text/javascript" src="../../js/bdcalendar.js"></script>--%>
                                                    </td>
                                                    <td background="../../images/mainWin20.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="13px" background="../../images/mainWin17.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin18.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin19.jpg">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="15px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" width="64%" height="33%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                            <tbody>
                                <tr>
                                    <td valign="top" height="10px">
                                        </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td width="7px" height="35px" background="../../images/mainWin01.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin09.jpg">
                                                        <div style="width: 196px; height: 35px; background-image: url('../../images/mainWin07.jpg');">
                                                            <table cellspacing="0" cellpadding="0" style="height:100%;">
                                                                <tr>
                                                                    <td width="50px"></td>
                                                                    <td>
                                                                        <img src="../../images/mainWin12.png" width="18px" height="18px" />&nbsp;</td>
                                                                    <td style="font-size: 15px; font-family: ����; font-weight: bold; color: White;">
                                                                        ����֪ͨ
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td background="../../images/mainWin09.jpg" align="right">
                                                         <a href='../Message/MsgReceiveList.aspx'><img class="aa04" alt="�鿴������Ϣ" src="../../images/main_29.gif" border="0"></a>
                                                    </td>
                                                    <td width="7px" background="../../images/mainWin08.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="100%" background="../../images/mainWin02.jpg">
                                                    </td>
                                                    <td valign="top" align="center" colspan="2">
                                                        <%if(dt!=null&&dt.Rows.Count>0){ %>
                                                        <asp:DataList ID="DLMsg" runat="server" Width="95%">
                                                            <HeaderTemplate>
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td height="28px" align="left" class="cp">
                                                                        <img src="../../images/mainWin25.png">
                                                                        <a href="../Message/MsgView.aspx?flag=2&ID=<%#Eval("ID")%>" title="<%#Eval("MsgTitle")%>"><font face="����" size="4"><%#Eval("title")%></font></a>
                                                                    </td>
                                                                    <td width="70px" class="cp">
                                                                        [<%#Eval("gydate")%>]
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:DataList>
                                                        <%}else{ %>
                                                              ��ʱû�������Ϣ
                                                        <%} %>
                                                    </td>
                                                    <td background="../../images/mainWin06.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="7px" background="../../images/mainWin03.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin04.jpg" colspan="2">
                                                    </td>
                                                    <td background="../../images/mainWin05.jpg">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="16px">
                        &nbsp;</td>
                    <td valign="top" width="34%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                            <tbody>
                                <tr>
                                    <td valign="top" style="height: 10px;">
                                        </td>
                                </tr>
                                <tr>
                                    <td valign="top" width="100%">
                                        <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td width="6px" height="30px" background="../../images/mainWin13.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin21.jpg">
                                                        <div style="width: 137px; height: 30px; background-image: url('../../images/mainWin14.jpg');">
                                                            <table cellspacing="0" cellpadding="0" style="height:100%;">
                                                                <tr>
                                                                    <td width="6px"></td>
                                                                    <td>
                                                                        <img src="../../images/mainWin22.png" width="18px" height="18px" />&nbsp;</td>
                                                                    <td style="font-size: 14px; font-family: ����; font-weight: bold; color: #0091d3;">
                                                                         ��Ϣ��¶
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td background="../../images/mainWin21.jpg" align="right">
                                                         <a href='../Disclosure/ReportList.aspx'><img class="aa04" alt="�鿴������Ϣ" src="../../images/main_29.gif" border="0"></a>
                                                    </td>
                                                    <td width="14px" background="../../images/mainWin15.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="100%" background="../../images/mainWin16.jpg">
                                                    </td>
                                                    <td valign="top" align="center" colspan="2">
                                                        <%if(dtp!=null&&dtp.Rows.Count>0){ %>
                                                        <asp:DataList ID="DLRep" runat="server" Width="95%">
                                                            <HeaderTemplate>
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td height="28px" align="left" class="cpp">
                                                                        <img src="../../images/mainWin25.png">
                                                                        <a href="../Disclosure/ReportView.aspx?flag=2&id=<%#Eval("ID")%>" title="<%#Eval("RepName")%>"><font face="����" size="3"><%#Eval("reptitle")%></font></a>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:DataList>
                                                        <%}else{ %>
                                                              ��ʱû�������Ϣ
                                                        <%} %>
                                                    </td>
                                                    <td background="../../images/mainWin20.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="13px" background="../../images/mainWin17.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin18.jpg" colspan="2">
                                                    </td>
                                                    <td background="../../images/mainWin19.jpg">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="15px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" width="64%" height="33%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                            <tbody>
                                <tr>
                                    <td valign="top" height="10px">
                                        </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td width="7px" height="35px" background="../../images/mainWin01.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin09.jpg">
                                                        <div style="width: 196px; height: 35px; background-image: url('../../images/mainWin07.jpg');">
                                                            <table cellspacing="0" cellpadding="0" style="height:100%;">
                                                                <tr>
                                                                    <td width="50px"></td>
                                                                    <td>
                                                                        <img src="../../images/mainWin11.png" width="18px" height="18px" />&nbsp;</td>
                                                                    <td style="font-size: 15px; font-family: ����; font-weight: bold; color: White;">
                                                                        ��������
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td background="../../images/mainWin09.jpg" align="right">
                                                         <a href='../Workflow/Work_Manage.aspx'><img class="aa04" alt="�鿴������Ϣ" src="../../images/main_29.gif" border="0"></a>
                                                    </td>
                                                    <td width="7px" background="../../images/mainWin08.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="100%" background="../../images/mainWin02.jpg">
                                                    </td>
                                                    <td valign="top" align="center" colspan="2">
                                                        <%if(dtt!=null&&dtt.Rows.Count>0){ %>
                                                        <asp:DataList ID="DataList1" runat="server" Width="95%">
                                                            <HeaderTemplate>
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td height="28px" align="left" class="cp">
                                                                        <img src="../../images/mainWin25.png">
                                                                        <a href="<%#Eval("style_remark") %>?step_id=<%#Eval("step_id")%>&doc_id=<%#Eval("doc_id") %>&zgbh=<%#Eval("ry_zgbh") %>" title="<%#Eval("doc_title")%>"><font face="����" size="4"><%#Eval("doc_title")%></font></a>
                                                                    </td>
                                                                    <td width="70px" class="cp">
                                                                        [<%#Eval("doc_added_date")%>]
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:DataList>
                                                        <%}else{ %>
                                                              ��ʱû�������Ϣ
                                                        <%} %>
                                                    </td>
                                                    <td background="../../images/mainWin06.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="7px" background="../../images/mainWin03.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin04.jpg" colspan="2">
                                                    </td>
                                                    <td background="../../images/mainWin05.jpg">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="16px">
                        &nbsp;</td>
                    <td valign="top" width="34%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                            <tbody>
                                <tr>
                                    <td valign="top" style="height: 10px">
                                        </td>
                                </tr>
                                <tr>
                                    <td valign="top" width="100%">
                                        <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td width="6px" height="30px" background="../../images/mainWin13.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin21.jpg">
                                                        <div style="width: 137px; height: 30px; background-image: url('../../images/mainWin14.jpg');">
                                                            <table cellspacing="0" cellpadding="0" style="height:100%;">
                                                                <tr>
                                                                    <td width="6px"></td>
                                                                    <td>
                                                                        <img src="../../images/mainWin23.png" width="15px" height="15px" />&nbsp;</td>
                                                                    <td style="font-size: 14px; font-family: ����; font-weight: bold; color: #0091d3;">
                                                                        ���ù���
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td width="14px" background="../../images/mainWin15.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="100%" background="../../images/mainWin16.jpg">
                                                    </td>
                                                    <td valign="top" align="center">
                                                        <table width="100%" height="100%">
                                                            <tr>
                                                                <td align="center" width="35%">
                                                                   <a href="../Workflow/Listflow.aspx" title="�½�����">
                                                                        <img src="../../images/mainWin28.png"/><br />
                                                                        <span style="margin-top:3px; font-family:΢���ź�; font-size:14px;">�½�����</span>
                                                                   </a> 
                                                                </td>
                                                                <td align="center" width="30%">
                                                                    <a href="../Workflow/Work_Record.aspx" title="���Ĺ���">
                                                                        <img src="../../images/mainWin29.png"/><br />
                                                                        <span style="margin-top:3px; font-family:΢���ź�; font-size:14px;">���Ĺ���</span>
                                                                   </a> 
                                                                </td>
                                                                <td align="center" width="35%">
                                                                    <a href="../Disclosure/DocLoad.aspx" title="��������">
                                                                        <img src="../../images/mainWin30.png"/><br />
                                                                        <span style="margin-top:3px; font-family:΢���ź�; font-size:14px;">��������</span>
                                                                   </a> 
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" width="35%">
                                                                    <a href="../Disclosure/Finance.aspx" title="����֪ʶ">
                                                                        <img src="../../images/mainWin33.png"/><br />
                                                                        <span style="margin-top:3px; font-family:΢���ź�; font-size:14px;">����֪ʶ</span>
                                                                   </a> 
                                                                </td>
                                                                <td align="center" width="30%">
                                                                    <a href="../zhxxgl/contact.aspx" title="ͨѶ¼">
                                                                        <img src="../../images/mainWin32.png"/><br />
                                                                        <span style="margin-top:3px; font-family:΢���ź�; font-size:14px;">ͨѶ¼</span>
                                                                   </a> 
                                                                </td>
                                                                <td align="center" width="35%">
                                                                    <a href="#" runat="server" id="xtsza" title="ϵͳ����">
                                                                        <img src="../../images/mainWin31.png"/><br />
                                                                        <span style="margin-top:3px; font-family:΢���ź�; font-size:14px;">��������</span>
                                                                   </a> 
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td background="../../images/mainWin20.jpg">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="13px" background="../../images/mainWin17.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin18.jpg">
                                                    </td>
                                                    <td background="../../images/mainWin19.jpg">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="15px">
                        &nbsp;</td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
