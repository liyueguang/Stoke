using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Stoke.BLL;

namespace Stoke.USL.SysManager
{
    public partial class SystemRoleManager : System.Web.UI.Page
    {
        public static string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                id = Request.QueryString["ID"].ToString();

                //显示权限树
                BindTreeView();

                //绑定角色信息
                BindRoleInfo(id);

                TreeView1.Attributes.Add("onClick", "OnCheckEvent()");
            }
        }
        /// <summary?
        /// 显示权限列表
        /// </summary>
        public void BindTreeView()
        {
            //显示权限树状列表
            DataTable firstTabel = SystemUM.GetPermissionsByLevel("1", "");//获取第一级权限
            int firstCount = firstTabel.Rows.Count;

            //第一级权限处理
            for (int first = 0; first < firstCount; first++)
            {
                TreeNode root1 = new TreeNode();
                root1.Text = firstTabel.Rows[first]["PermissionName"].ToString();
                root1.Value = firstTabel.Rows[first]["PermissionCode"].ToString();
                this.TreeView1.Nodes.Add(root1);
                root1.SelectAction = TreeNodeSelectAction.None;//节点不能点击，但可以点击前面的复选框

                //第二级权限列表
                DataTable secondTabel = SystemUM.GetPermissionsByLevel("2", root1.Value.Substring(0, 2));
                int secondCount = secondTabel.Rows.Count;

                //第二级权限处理
                for (int second = 0; second < secondCount; second++)
                {
                    TreeNode root2 = new TreeNode();
                    root2.Text = secondTabel.Rows[second]["PermissionName"].ToString();
                    root2.Value = secondTabel.Rows[second]["PermissionCode"].ToString();
                    root1.ChildNodes.Add(root2);
                    root2.SelectAction = TreeNodeSelectAction.None;

                    //第三级权限列表
                    DataTable thirdTabel = SystemUM.GetPermissionsByLevel("3", root2.Value.Substring(0, 4));
                    int thirdCount = thirdTabel.Rows.Count;

                    //第三级权限处理
                    for (int third = 0; third < thirdCount; third++)
                    {
                        TreeNode root3 = new TreeNode();
                        root3.Text = thirdTabel.Rows[third]["PermissionName"].ToString();
                        root3.Value = thirdTabel.Rows[third]["PermissionCode"].ToString();
                        root2.ChildNodes.Add(root3);
                        root3.SelectAction = TreeNodeSelectAction.None;
                    }
                }
            }
        }

        /// <summary>
        /// 根据编号绑定角色信息
        /// </summary>
        /// <param name="id">角色编号</param>
        public void BindRoleInfo(string id)
        {
            if (Convert.ToInt32(id) == -1)
            {
                this.addBtn.Text = "添 加";
                return;
            }
            else
            {
                this.CompareValidator2.Enabled = false;
            }

            DataTable dt = SystemUM.GetRolesPermissitionByID(Convert.ToInt32(id));
            this.roleNameTbx.Text = dt.Rows[0]["RoleName"].ToString();
            //系统管理员的名称及级别不可修改，仅能修改描述
            if (this.roleNameTbx.Text.ToString() == "系统管理员")
            {
                this.roleNameTbx.Enabled = false;

            }

            this.despTbx.Text = dt.Rows[0]["RoleDescription"].ToString();
            string list = dt.Rows[0]["PermissionRange"].ToString();

            foreach (TreeNode node1 in TreeView1.Nodes)
            {
                if (list.IndexOf(node1.Value.ToString()) > -1)
                    node1.Checked = true;
                else
                    node1.Checked = false;
                foreach (TreeNode node2 in node1.ChildNodes)
                {
                    if (list.IndexOf(node2.Value.ToString()) > -1)
                        node2.Checked = true;
                    else
                        node2.Checked = false;
                    foreach (TreeNode node3 in node2.ChildNodes)
                    {
                        if (list.IndexOf(node3.Value.ToString()) > -1)
                            node3.Checked = true;
                        else
                            node3.Checked = false;
                    }
                }
            }

        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemRole.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string roleName = this.roleNameTbx.Text.ToString().Trim();
            string roleDesc = this.despTbx.Text.ToString().Trim();
            DateTime CreateTime = DateTime.Now;
            string rolecode = Convert.ToString(CreateTime);

            if (rolecode == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('角色编号生成失败，请与上级管理员联系！');</script>");
                return;
            }
            string list = string.Empty;
            foreach (TreeNode node1 in TreeView1.Nodes)
            {
                if (node1.Checked)
                    list += node1.Value.ToString().Trim() + ",";
                foreach (TreeNode node2 in node1.ChildNodes)
                {
                    if (node2.Checked)
                        list += node2.Value.ToString().Trim() + ",";
                    foreach (TreeNode node3 in node2.ChildNodes)
                    {
                        if (node3.Checked)
                            list += node3.Value.ToString().Trim() + ",";
                    }
                }
            }

            if (list != string.Empty)
                list = list.Remove(list.Length - 1);
            int ACount = 0;
            if (Convert.ToInt32(id) == -1)
            {
                ACount = SystemUM.GetRolesByName(roleName, "0").Rows.Count;
                if (ACount > 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('新增的该级别角色名称已存在，请重新输入！');</script>");
                    return;
                }
                if (SystemUM.addRoleInfo(roleName, rolecode, roleDesc, list, CreateTime))
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('角色信息添加失败，请与管理员联系！');</script>");
                //Uti.ShowDialog("角色信息添加失败，请与管理员联系！", this.Page);
                else
                    Uti.ShowDialog("角色信息添加成功！", "SystemRole.aspx", this.Page);
            }
            else
            {
                ACount = SystemUM.CheckRoleNamebyIRL(Convert.ToInt32(id), roleName);

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + ACount + "');</script>");
                if (ACount >= 0)
                {
                    if (ACount >= 1)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('修改的角色名称已存在，请重新输入！');</script>");
                        return;
                    }
                    else
                    {
                        if (SystemUM.updateRoleInfo(Convert.ToInt32(id), roleName,roleDesc, list, CreateTime))
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('角色信息修改失败，请与管理员联系！');</script>");
                            //Uti.ShowDialog("角色信息修改失败，请与管理员联系！", this.Page);
                        }
                        else
                        {
                            Uti.ShowDialog("角色信息修改成功！", "SystemRole.aspx", this.Page);
                        }
                    }
                }
                else
                {
                    ACount = SystemUM.CheckRoleNamebyIRL(Convert.ToInt32(id), roleName);
                    if (ACount >= 0)
                    {
                        if (ACount >= 1)
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('修改的角色名称已存在，请重新输入！');</script>");
                            return;
                        }
                        else
                        {
                            if (SystemUM.updateRoleInfo(Convert.ToInt32(id), roleName,roleDesc, list, CreateTime))
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('角色信息修改失败，请与管理员联系！');</script>");
                                //Uti.ShowDialog("角色信息修改失败，请与管理员联系！", this.Page);
                            }
                            else
                            {
                                Uti.ShowDialog("角色信息修改成功！", "SystemRole.aspx", this.Page);
                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('该角色已被其他用户删除，请重新创建！');location.href='SystemRole.aspx';</script>");
                    }
                }
            }
        }
    }
}
