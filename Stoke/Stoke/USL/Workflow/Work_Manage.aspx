<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Work_Manage.aspx.cs" Inherits="Stoke.USL.Workflow.Work_Manage" %>

<%@ Register TagPrefix="uc1" TagName="favorite_doc" Src="../../COMMON/favorite_doc.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Work_Manage</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/css.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>

    <script language="javascript" id="Back"> </script>

</head>
<body class="body1" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr style="display: none;">
                <td style="width: 100%" valign="top">
                    <table style="width: 100%" bordercolor="#111111" cellspacing="0" cellpadding="0"
                        width="100%" border="0">
                        <tr>
                            <td class="GbText" align="right" width="20" background="#c0d9e6">
                                <img src="../../images/icon/233.GIF"></td>
                            <td class="GbText" style="font-weight: bold; font-size: larger; color: blue; font-family: 幼圆;
                                font-variant: normal" valign="middle" align="center" background="../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff">
                                &nbsp;待办工作</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" valign="bottom" align="center">
                    <table border="0" style="border-collapse: collapse;" cellpadding="1" cellspacing="1" width="100%">
                        <tr>
                            <td>主题</td>
                            <td><asp:TextBox ID="topicTxt" runat="server" Width="150px"></asp:TextBox></td>
                            <td>流程类别</td>
                            <td><asp:DropDownList ID="classDdl" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="classDdl_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>流程名称</td>
                            <td><asp:DropDownList ID="flowDdl" runat="server" Width="150px"></asp:DropDownList></td>
                            <td>经办人</td>
                            <td><asp:TextBox ID="ryTxt" runat="server" Width="150px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>经办部门</td>
                            <td><asp:DropDownList ID="bmDdl" runat="server" Width="150px"></asp:DropDownList></td>
                            <td>开始时间</td>
                            <td><asp:TextBox ID="startTxt" runat="server" Width="150px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                            <td>结束时间</td>
                            <td><asp:TextBox ID="endTxt" runat="server" Width="150px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                            <td colspan="2" style="text-align: center;"><asp:Button ID="searchBtn" runat="server" Text="搜索" Width="100px" OnClick="searchBtn_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%" valign="bottom" align="center">
                    <asp:GridView ID="DataGrid1" runat="server" Width="100%" PageSize="20" AutoGenerateColumns="False"
                        AllowPaging="True" OnRowCommand="DataGrid1_RowCommand" OnRowDataBound="DataGrid1_RowDataBound">
                        <AlternatingRowStyle Wrap="False" HorizontalAlign="Center" BackColor="white"></AlternatingRowStyle>
                        <RowStyle Wrap="False" HorizontalAlign="Center" BackColor="#EFF3FB"></RowStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="white" Font-Bold="true" HorizontalAlign="Center"
                            CssClass="title4"></HeaderStyle>
                        <FooterStyle></FooterStyle>
                        <PagerSettings Visible="false" />
                        <Columns>
                            <asp:BoundField Visible="False" DataField="doc_id" HeaderText="doc_id"></asp:BoundField>
                            <asp:BoundField Visible="False" DataField="flow_id" HeaderText="flow_id"></asp:BoundField>
                            <asp:BoundField DataField="doc_title" HeaderText="主题" FooterText="d">
                                <HeaderStyle Width="26%"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Flow_Name" HeaderText="流程名称">
                                <HeaderStyle Width="12%"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="class_name" HeaderText="流程类别">
                                <HeaderStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField Visible="False" DataField="step_id" HeaderText="步骤号"></asp:BoundField>
                            <asp:BoundField DataField="step_name" HeaderText="步骤名称">
                                <HeaderStyle Width="15%"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ry_xm" HeaderText="创建者">
                                <HeaderStyle Width="6%"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="doc_added_date" HeaderText="创建日期" DataFormatString="{0:d}">
                                <HeaderStyle Width="10%"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="emergency_name" HeaderText="紧急程度">
                                <HeaderStyle Width="6%"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="流程图" Visible="false">
                                <HeaderStyle Width="6%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="work_lct" CommandArgument='<%# Eval("flow_id") %>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="流转过程">
                                <HeaderStyle Width="7%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="proc" CommandArgument='<%# Eval("doc_id") %>'>流转过程</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="4%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="dispose" CommandArgument='<%# Eval("doc_id") + ":" + Eval("flow_id") + ":" + Eval("step_id") %>'>处理</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 5px" valign="middle" align="right" bgcolor="#ffffff">
                    <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="8pt">转至第</asp:Label><asp:DropDownList
                        ID="pageDdl" runat="server" AutoPostBack="True" Width="46px" Font-Names="Verdana"
                        Font-Size="8pt" OnSelectedIndexChanged="pageDdl_SelectedIndexChanged1">
                    </asp:DropDownList><asp:Label ID="lb1" runat="server" Font-Names="Verdana" Font-Size="8pt">页</asp:Label><asp:Label
                        ID="lblPageCount" runat="server" Font-Names="Verdana" Font-Size="8pt"></asp:Label><asp:Label
                            ID="lblCurrentIndex" runat="server" Font-Names="Verdana" Font-Size="8pt"></asp:Label><asp:LinkButton
                                ID="btnFirst" OnClick="PagerButtonClick" runat="server" CommandArgument="0" ForeColor="navy"
                                Font-Size="8pt" Font-Name="verdana"></asp:LinkButton><asp:LinkButton ID="btnPrev"
                                    OnClick="PagerButtonClick" runat="server" CommandArgument="prev" ForeColor="navy"
                                    Font-Size="8pt" Font-Name="verdana"></asp:LinkButton><asp:LinkButton ID="btnNext"
                                        OnClick="PagerButtonClick" runat="server" CommandArgument="next" ForeColor="navy"
                                        Font-Size="8pt" Font-Name="verdana"></asp:LinkButton><asp:LinkButton ID="btnLast"
                                            OnClick="PagerButtonClick" runat="server" CommandArgument="last" ForeColor="navy"
                                            Font-Size="8pt" Font-Name="verdana"></asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 100%; height: 5px" valign="middle" align="center" bgcolor="#ffffff">
                    <font face="宋体">
                        <fieldset id="fieldset1" style="width: 729px; height: 16px" runat="server">
                            <legend>条件查询(支持模糊查找)</legend>
                            <table id="Table3" style="width: 100%; height: 120px" cellspacing="0" cellpadding="0"
                                width="798" border="0">
                                <tr>
                                    <td style="width: 205px; height: 24px" nowrap align="center">
                                        主题(关键字)</td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="Tittle" runat="server" Width="200px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 205px; height: 24px" nowrap align="center">
                                        公文编号</td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="docIDTbx" runat="server" Width="198px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 205px" nowrap align="center">
                                        <font face="宋体">经办人</font></td>
                                    <td>
                                        <asp:TextBox ID="Jbr" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 205px; height: 15px" align="center">
                                        经办部门</td>
                                    <td style="height: 15px">
                                        <asp:DropDownList ID="ee" runat="server" Width="150px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 205px; height: 23px" align="center">
                                        流程名称</td>
                                    <td style="height: 23px">
                                        <asp:TextBox ID="docTypeTbx" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 205px; height: 9px" align="center">
                                        起止时间</td>
                                    <td style="height: 9px">
                                        <asp:TextBox ID="TimeFrom" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm'})"
                                            runat="server" Width="140px" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;至&nbsp;
                                        <asp:TextBox ID="TimeTo" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm'})"
                                            runat="server" Width="140px" ReadOnly="True"></asp:TextBox>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 205px">
                                    </td>
                                    <td>
                                        <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </font>
                                        <asp:Button ID="Button1" runat="server" CssClass="input4 " Width="40px" CausesValidation="False"
                                            Text="搜索" OnClick="Button1_Click1"></asp:Button></td>
                                </tr>
                            </table>
                        </fieldset>
                    </font>
                </td>
            </tr>
        </table>
        <table style="display: none;" class="gbtext" id="Table2" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr>
                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>old.gif'>
                    <asp:LinkButton ID="xsqb" runat="server" CssClass="Newbutton" OnClick="xsqb_Click1">显示全部</asp:LinkButton></td>
                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>old.gif'>
                    <asp:LinkButton ID="gwgl" runat="server" CssClass="Newbutton" OnClick="gwgl_Click1">公文事务</asp:LinkButton></td>
                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>old.gif'>
                    <asp:LinkButton ID="rsgl" runat="server" CssClass="Newbutton" OnClick="rsgl_Click1">人事事务</asp:LinkButton></td>
                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>old.gif'>
                    <asp:LinkButton ID="xzgl" runat="server" CssClass="Newbutton" OnClick="xzgl_Click1">行政事务</asp:LinkButton></td>
                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,4));%>old.gif'>
                    <asp:LinkButton ID="czgl" runat="server" CssClass="Newbutton" OnClick="czgl_Click1">财务事务</asp:LinkButton></td>
                <td style="height: 22px" valign="middle" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,8));%>old.gif'>
                    <asp:LinkButton ID="licenseLbtn" runat="server" CssClass="Newbutton" OnClick="licenseLbtn_Click1">合同事务</asp:LinkButton></td>
                <td style="height: 22px" valign="middle" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,5));%>old.gif'>
                    <asp:LinkButton ID="tjcx" runat="server" CssClass="Newbutton" OnClick="tjcx_Click1">条件查询</asp:LinkButton></td>
                <td style="height: 22px" valign="middle" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,6));%>old.gif'>
                    <asp:LinkButton ID="scwd" runat="server" CssClass="Newbutton" OnClick="scwd_Click1">收藏文档</asp:LinkButton></td>
                <td style="height: 22px" valign="middle" align="right">
                    <font face="宋体">
                        <asp:Label ID="Label2" runat="server">收藏夹名：</asp:Label><asp:DropDownList ID="favFolderListDdl"
                            runat="server" Enabled="False" AutoPostBack="True">
                        </asp:DropDownList></font></td>
            </tr>
        </table>
        <div style="display: none; z-index: 101; left: 560px; width: 119px; position: absolute;
            top: 80px; height: 94px" ms_positioning="FlowLayout">
            <table id="Table4" style="width: 119px; height: 75px" cellspacing="1" cellpadding="1"
                bgcolor="#99ccff" border="1" runat="server">
                <tr>
                    <td valign="bottom" align="center" colspan="2">
                        <font face="宋体">
                            <uc1:favorite_doc ID="Favorite_doc1" runat="server"></uc1:favorite_doc>
                        </font>
                    </td>
                </tr>
                <tr>
                    <td align="center" width="23%" colspan="2">
                        <font face="宋体">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.baidu.com">文档收藏夹管理</asp:HyperLink></font></td>
                </tr>
                <tr>
                    <td align="center">
                        <font face="宋体">
                            <asp:ImageButton ID="addDocIbtn" runat="server" ImageUrl="../../images/addDoc.jpg"
                                OnClick="addDocIbtn_Click1"></asp:ImageButton></font></td>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../../images/return.jpg"
                            OnClick="ImageButton3_Click1"></asp:ImageButton></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
