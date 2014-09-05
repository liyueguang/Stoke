<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Work_Record.aspx.cs" Inherits="Stoke.USL.Workflow.Work_Record" %>

<%@ Register TagPrefix="uc1" TagName="favorite_doc" Src="../../COMMON/favorite_doc.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Work_Record</title>
    <meta content="False" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/css.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>

</head>
<body class="body1" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="height: 272px" cellspacing="0" cellpadding="0" width="100%"
            border="0">
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
                    <font face="宋体">
                        <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="20" Width="100%">
                            <HeaderStyle BackColor="#507CD1" ForeColor="white" Font-Bold="true" HorizontalAlign="Center"
                                CssClass="title4" />
                            <AlternatingItemStyle HorizontalAlign="Center" BackColor="White"></AlternatingItemStyle>
                            <ItemStyle HorizontalAlign="Center" BackColor="#EFF3FB"></ItemStyle>
                            <FooterStyle></FooterStyle>
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="Doc_ID" HeaderText="doc_ID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Flow_ID" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Doc_Title" HeaderText="主题">
                                    <HeaderStyle Width="26%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Flow_Name" HeaderText="流程名称">
                                    <HeaderStyle Width="12%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="class_name" HeaderText="流程类别">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Step_ID" HeaderText="Step_ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Step_Name" HeaderText="当前环节">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ry_xm" HeaderText="创建者">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Doc_Added_Date" HeaderText="创建日期" DataFormatString="{0:g}">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="operator_time" HeaderText="处理时间" DataFormatString="{0:g}">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="流转过程">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="proc">流转过程</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="查看">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="detail">查看</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Visible="False" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
                                Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid></font></td>
            </tr>
            <tr>
                <td style="width: 100%" valign="bottom" align="right" bgcolor="#ffffff">
                    <font face="宋体">
                        <asp:Label ID="Label1" runat="server" Font-Size="8pt" Font-Names="Verdana">转至第</asp:Label><asp:DropDownList
                            ID="pageDdl" runat="server" AutoPostBack="True" Width="46px" Font-Size="8pt"
                            Font-Names="Verdana">
                        </asp:DropDownList><asp:Label ID="lb1" runat="server" Font-Size="8pt" Font-Names="Verdana">页</asp:Label><asp:Label
                            ID="lblPageCount" runat="server" Font-Size="8pt" Font-Names="Verdana"></asp:Label><asp:Label
                                ID="lblCurrentIndex" runat="server" Font-Size="8pt" Font-Names="Verdana"></asp:Label><asp:LinkButton
                                    ID="btnFirst" OnClick="PagerButtonClick" runat="server" Font-Name="verdana" Font-Size="8pt"
                                    ForeColor="navy" CommandArgument="0"></asp:LinkButton><asp:LinkButton ID="btnPrev"
                                        OnClick="PagerButtonClick" runat="server" Font-Name="verdana" Font-Size="8pt"
                                        ForeColor="navy" CommandArgument="prev"></asp:LinkButton><asp:LinkButton ID="btnNext"
                                            OnClick="PagerButtonClick" runat="server" Font-Name="verdana" Font-Size="8pt"
                                            ForeColor="navy" CommandArgument="next"></asp:LinkButton><asp:LinkButton ID="btnLast"
                                                OnClick="PagerButtonClick" runat="server" Font-Name="verdana" Font-Size="8pt"
                                                ForeColor="navy" CommandArgument="last"></asp:LinkButton></font></td>
            </tr>
            <tr style="display: none;">
                <td style="width: 100%" valign="top" height="23">
                    <table style="height: 24px" bordercolor="#111111" height="24" cellspacing="0" cellpadding="0"
                        width="100%" border="0">
                        <tr height="30">
                            <td class="GbText" align="right" width="20" background='bgColor="#c0d9e6"'>
                                <img src="../../images/icon/277.GIF"></td>
                            <td class="GbText" style="font-weight: bold; font-size: larger; color: blue; font-family: 幼圆;
                                font-variant: normal" valign="middle" align="center" width="100%" background="../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff">
                                工作查看</td>
                        </tr>
                    </table>
                    <font face="宋体" color="#ff0000">*提示：工作查看保存的文件为未结束的工作以及一周之内完成的工作 (其余已经完成的文件请到文档库模块查看)</font>
                </td>
            </tr>
            <tr style="display: none;">
                <td style="width: 100%" valign="top" align="center" bgcolor="#ffffff">
                    <fieldset id="fieldset1" style="width: 729px; height: 16px" runat="server" designtimedragdrop="76">
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
                                    <font face="宋体">公文编号</font></td>
                                <td style="height: 24px">
                                    <asp:TextBox ID="docIDTbx" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 205px" nowrap align="center">
                                    <font face="宋体">经办人</font></td>
                                <td>
                                    <asp:TextBox ID="Jbr" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 205px; height: 24px" align="center">
                                    经办部门</td>
                                <td style="height: 23px">
                                    <asp:DropDownList ID="ee" runat="server" Width="150px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 205px; height: 23px" align="center">
                                    <font face="宋体">流程名称</font></td>
                                <td style="height: 23px">
                                    <asp:TextBox ID="docTypeTbx" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 205px; height: 9px" align="center">
                                    起止时间</td>
                                <td style="height: 9px">
                                    <asp:TextBox ID="TimeFrom" runat="server" Width="140px" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TimeTo" runat="server" Width="140px" ReadOnly="True"></asp:TextBox>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 205px">
                                </td>
                                <td>
                                    <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </font>
                                    <asp:Button ID="Button1" runat="server" CssClass="input4 " Width="40px" Text="搜索"
                                        CausesValidation="False"></asp:Button></td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr style="display: none;">
                <td style="width: 100%; height: 5px" valign="middle" align="left">
                    <table class="gbtext" id="Table2" style="width: 100%; height: 16px" height="16" cellspacing="0"
                        cellpadding="0" width="100%" border="0">
                        <tr>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,0));%>old.gif'>
                                <asp:LinkButton ID="xsqb" runat="server" CssClass="Newbutton">显示全部</asp:LinkButton></td>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,1));%>old.gif'>
                                <asp:LinkButton ID="gwgl" runat="server" CssClass="Newbutton">公文事务</asp:LinkButton></td>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,2));%>old.gif'>
                                <asp:LinkButton ID="rsgl" runat="server" CssClass="Newbutton">人事事务</asp:LinkButton></td>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,3));%>old.gif'>
                                <asp:LinkButton ID="xzgl" runat="server" CssClass="Newbutton">行政事务</asp:LinkButton></td>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,4));%>old.gif'>
                                <asp:LinkButton ID="czgl" runat="server" CssClass="Newbutton">财务事务</asp:LinkButton></td>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,8));%>old.gif'>
                                <asp:LinkButton ID="licenseLbtn" runat="server" CssClass="Newbutton">合同事务</asp:LinkButton></td>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,5));%>old.gif'>
                                <asp:LinkButton ID="tjcx" runat="server" CssClass="Newbutton">条件查询</asp:LinkButton></td>
                            <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",flag,6));%>old.gif'>
                                <asp:LinkButton ID="scwd" runat="server" CssClass="Newbutton">收藏文档</asp:LinkButton>&nbsp;</td>
                            <td style="height: 22px" align="right">
                                <font face="宋体">
                                    <asp:Label ID="Label2" runat="server">收藏夹名：</asp:Label></font><asp:DropDownList ID="favFolderListDdl"
                                        runat="server" Enabled="False" AutoPostBack="True">
                                    </asp:DropDownList></FONT></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div style="display: none; z-index: 101; left: 440px; width: 119px; position: absolute;
            top: 96px; height: 94px" ms_positioning="FlowLayout">
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
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="favoriteDocManage.aspx">文档收藏夹管理</asp:HyperLink></font></td>
                </tr>
                <tr>
                    <td align="center">
                        <font face="宋体">
                            <asp:ImageButton ID="addDocIbtn" runat="server" ImageUrl="../../images/addDoc.jpg"></asp:ImageButton></font></td>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../../images/return.jpg">
                        </asp:ImageButton></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
