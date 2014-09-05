<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ListFlow.aspx.cs" Inherits="Stoke.USL.Workflow.ListFlow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ListFlow</title>
    <link href="../../css/css.css" type="text/css" rel="stylesheet" />
</head>
<body class="body1" MS_POSITIONING="GridLayout">
    <form id="form1" runat="server">
            <table id="Table1" style="height: 272px" cellspacing="0" cellpadding="0" width="100%"
                border="0">
                <tr style="display:none;">
                    <td style="width: 100%" valign="top" height="23">
                        <table style="height: 24px" bordercolor="#111111" height="24" cellspacing="0" cellpadding="0"
                            width="100%" border="0">
                            <tr height="30" >
                                <td class="GbText" align="right" width="20" background="#c0d9e6">
                                    <img src="../../images/icon/274.GIF"></td>
                                <td class="GbText" style="font-weight: bold; font-size: larger; color: blue; font-family: 幼圆;
                                    font-variant: normal" valign="middle" align="center" background="../../Images/treetopbg.jpg"
                                    bgcolor="#e8f4ff">
                                    新建工作</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td style="width: 100%; height: 5px" valign="middle" align="left" colspan="1" rowspan="1">
                        <table class="gbtext" id="Table2" style="width: 100%; height: 16px" cellspacing="0"
                            cellpadding="0" width="100%" border="0">
                            <tr>
                                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>old.gif'>
                                    <asp:LinkButton ID="xsqb" runat="server" CssClass="Newbutton" OnClick="xsqb_Click">显示全部</asp:LinkButton></td>
                                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>old.gif'>
                                    <asp:LinkButton ID="gwgl" runat="server" CssClass="Newbutton" OnClick="gwgl_Click">公文事务</asp:LinkButton></td>
                                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>old.gif'>
                                    <asp:LinkButton ID="rsgl" runat="server" CssClass="Newbutton" OnClick="rsgl_Click">人事事务</asp:LinkButton></td>
                                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>old.gif'>
                                    <asp:LinkButton ID="xzgl" runat="server" CssClass="Newbutton" OnClick="xzgl_Click">行政事务</asp:LinkButton></td>
                                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,4));%>old.gif'>
                                    <asp:LinkButton ID="czgl" runat="server" CssClass="Newbutton" OnClick="czgl_Click">财务事务</asp:LinkButton></td>
                                <td style="height: 22px" align="center" width="80" background='../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,5));%>old.gif'>
                                    <asp:LinkButton ID="licenseLbtn" runat="server" CssClass="Newbutton" OnClick="licenseLbtn_Click">合同事务</asp:LinkButton></td>
                                <td style="height: 22px" align="center">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 234px" valign="bottom" align="center">
                        <font face="宋体">
                            <asp:GridView ID="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="20" Width="100%" OnRowCommand="DataGrid1_RowCommand" OnRowDataBound="DataGrid1_RowDataBound">
                                <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="white" HorizontalAlign="Center" CssClass="title4"></HeaderStyle>
                                <FooterStyle ></FooterStyle>
                                <AlternatingRowStyle BackColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerSettings Visible="false" />
                                <Columns>
                                    <asp:BoundField Visible="False" DataField="Flow_ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Flow_Name" HeaderText="流程名称" />
                                    <asp:BoundField DataField="class_name" HeaderText="流程类别" />
                                    <asp:BoundField DataField="Build_Date" HeaderText="创建日期" DataFormatString="{0:d}">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Builder" HeaderText="创建者">
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="new" CommandArgument='<%#Eval("Flow_ID") %>'>新建</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False" HeaderText="流程图">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="work_lct" CommandArgument='<%#Eval("Flow_ID") %>'>查看</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
<%--                                <PagerStyle Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4" 
                                    Mode="NumericPages"></PagerStyle>--%>
                            </asp:GridView>
                        </font></td>
                </tr>
                <tr>
                    <td style="width: 100%" valign="top" align="right" bgcolor="#ffffff">
                        <font face="宋体">
                            <asp:Label ID="Label1" runat="server" Font-Size="8pt" Font-Names="Verdana">转至第</asp:Label>
                            <asp:DropDownList ID="pageDdl" runat="server" Width="46px" Font-Size="8pt" Font-Names="Verdana"
                                AutoPostBack="True" OnSelectedIndexChanged="pageDdl_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="lb1" runat="server" Font-Size="8pt" Font-Names="Verdana">页</asp:Label>
                            <asp:Label ID="lblPageCount" runat="server" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                            <asp:Label ID="lblCurrentIndex" runat="server" Font-Size="8pt" Font-Names="Verdana"></asp:Label>
                            <asp:LinkButton ID="btnFirst" OnClick="PagerButtonClick" runat="server" CommandArgument="0"
                                ForeColor="navy" Font-Size="8pt" ></asp:LinkButton>
                            <asp:LinkButton ID="btnPrev" OnClick="PagerButtonClick" runat="server" CommandArgument="prev"
                                ForeColor="navy" Font-Size="8pt"></asp:LinkButton>
                            <asp:LinkButton ID="btnNext" OnClick="PagerButtonClick" runat="server" CommandArgument="next"
                                ForeColor="navy" Font-Size="8pt" ></asp:LinkButton>
                            <asp:LinkButton ID="btnLast" OnClick="PagerButtonClick" runat="server" CommandArgument="last"
                                ForeColor="navy" Font-Size="8pt" ></asp:LinkButton></font></td>
                </tr>
            </table> </form>
</body>
</html>
