<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemRoleManager.aspx.cs"
    Inherits="Stoke.USL.SysManager.SystemRoleManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理</title>
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript">

    //checkbox点击事件

    function OnCheckEvent()

    {

        var objNode = event.srcElement;

        if(objNode.tagName != "INPUT" || objNode.type != "checkbox")

            return;

        //获得当前树结点

        var ck_ID = objNode.getAttribute("ID");

        var node_ID = ck_ID.substring(0,ck_ID.indexOf("CheckBox")) + "Nodes";

        var curTreeNode = document.getElementById(node_ID);

        //级联选择

        SetChildCheckBox(curTreeNode,objNode.checked);

        SetParentCheckBox(objNode);

    }

    

    //子结点字符串

    var childIds = "";

    //获取子结点ID数组

    function GetChildIdArray(parentNode)

    {

        if (parentNode == null)

            return;

        var childNodes = parentNode.children;

        var count = childNodes.length;

        for(var i = 0;i < count;i ++)

        {

            var tmpNode = childNodes[i];

            if(tmpNode.tagName == "INPUT" && tmpNode.type == "checkbox")

            {

                childIds = tmpNode.id + ":" + childIds;

            }

            GetChildIdArray(tmpNode);

        }

    }

    

    //设置子结点的checkbox

    function SetChildCheckBox(parentNode,checked)

    {

        if(parentNode == null)

            return;

        var childNodes = parentNode.children;

        var count = childNodes.length;

        for(var i = 0;i < count;i ++)

        {

            var tmpNode = childNodes[i];

            if(tmpNode.tagName == "INPUT" && tmpNode.type == "checkbox")

            {

                tmpNode.checked = checked;

            }

            SetChildCheckBox(tmpNode,checked);

        }

    }

    

    //设置父结点的checkbox

    function SetParentCheckBox(childNode)

    {

        if(childNode == null)

            return;

        var parent = childNode.parentNode;

        if(parent == null || parent == "undefined")

            return;

        do 

        {

        parent = parent.parentNode;

        }

        while (parent && parent.tagName != "DIV");

        if(parent == "undefined" || parent == null)

            return;

        var parentId = parent.getAttribute("ID");

        var objParent = document.getElementById(parentId);

        childIds = "";

        GetChildIdArray(objParent);

        //判断子结点状态

        childIds = childIds.substring(0,childIds.length - 1);

        var aryChild = childIds.split(":");

        var result = false;

        //当子结点的checkbox状态有一个为true，其父结点checkbox状态即为true,否则为false

        for(var i in aryChild)

        {

            var childCk = document.getElementById(aryChild[i]);

            if(childCk.checked)

                result = true;

        }

        parentId = parentId.replace("Nodes","CheckBox");

        var parentCk = document.getElementById(parentId);

        if(parentCk == null)

            return;

        if(result)

            parentCk.checked = true;

        else

            parentCk.checked = false;

        SetParentCheckBox(parentCk);

    }

    </script>

</head>
<body>
    <form id="form1" runat="server">
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
                                                                        角色管理</td>
                                                                    <td width="120">
                                                                        <img height="16" src="../../images/ico_04.gif" width="17" align="absmiddle"><a href="SystemRole.aspx">返回角色列表</a></td>
                                                                    <td valign="top" width="14">
                                                                        <img height="28" alt="" src="../../images/main_30.gif" width="14"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" width="100%" style="padding:10px;">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="aa05" valign="top" style="height: 159px">
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">角色名称：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="roleNameTbx" runat="server" Text='' Width="220px" MaxLength="32"></asp:TextBox></span><span
                                                                                    class="ManageLineDesc"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="roleNameTbx"
                                                                                        Display="Dynamic" ErrorMessage="角色名称必须填写!" SetFocusOnError="True"></asp:RequiredFieldValidator><asp:CompareValidator
                                                                                            ID="CompareValidator2" runat="server" ErrorMessage='"系统管理员"为专用角色名称,请重新填写!' ControlToValidate="roleNameTbx"
                                                                                            Display="Dynamic" Operator="NotEqual" ValueToCompare="系统管理员"></asp:CompareValidator>请填写角色名称,32个汉字以内。</span><div
                                                                                                class="clear">
                                                                                            </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">角色描述：</span><span class="ManageLineInput">
                                                                                <asp:TextBox ID="despTbx" runat="server" Text='' Width="220px" MaxLength="100" Height="91px"
                                                                                    TextMode="MultiLine"></asp:TextBox></span><span class="ManageLineDesc"><asp:Label
                                                                                        ID="Label3" runat="server" ForeColor="Snow" Text="*"></asp:Label>
                                                                                        请填写该角色有关情况说明,100个汉字以内。</span><div class="clear">
                                                                                        </div>
                                                                        </div>
                                                                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                                                                            <span class="ManageLineTitle">
                                                                                <asp:Label ID="Label2" runat="server" Text="权限设置："></asp:Label></span><span class="ManageLineInput">
                                                                                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" ShowCheckBoxes="All"
                                                                                        ShowLines="True" ExpandDepth="0">
                                                                                        <ParentNodeStyle Font-Bold="False" />
                                                                                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                                                                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                                                                            VerticalPadding="0px" />
                                                                                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                                                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                                                    </asp:TreeView>
                                                                                </span><span class="ManageLineDesc">
                                                                                    <asp:Label ID="Label5" runat="server" ForeColor="Snow" Text="*"></asp:Label>
                                                                                    <asp:Label ID="Label6" runat="server" Text="请选择该角色具有的权限。"></asp:Label></span><div
                                                                                        class="clear">
                                                                                    </div>
                                                                        </div>
                                                                        <div class="ManageSub">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp;
                                                                            <asp:Button ID="addBtn" runat="server" CausesValidation="True" CssClass="btn12" Text="更 新"
                                                                                OnClick="addBtn_Click"></asp:Button>
                                                                            &nbsp; &nbsp; &nbsp;&nbsp;
                                                                            <asp:Button ID="cancelBtn" runat="server" CausesValidation="False" CssClass="btn12"
                                                                                Text="取 消" OnClick="cancelBtn_Click"></asp:Button>
                                                                            <asp:Label ID="IDLB" runat="server" Text="" Visible="false"></asp:Label><br />
                                                                        </div>
                                                                    </td>
                                                                    <td valign="top" width="4" bgcolor="#f0f0f0" style="height: 159px">
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
                                                                    <td valign="top" width="14" style="height: 16px">
                                                                        <img height="14" alt="" src="../../images/main_39.gif" width="14"></td>
                                                                    <td valign="top" width="100%" style="height: 16px">
                                                                        &nbsp;</td>
                                                                    <td valign="top" width="15" style="height: 16px">
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
