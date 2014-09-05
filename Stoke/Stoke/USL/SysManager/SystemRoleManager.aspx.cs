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

                //��ʾȨ����
                BindTreeView();

                //�󶨽�ɫ��Ϣ
                BindRoleInfo(id);

                TreeView1.Attributes.Add("onClick", "OnCheckEvent()");
            }
        }
        /// <summary?
        /// ��ʾȨ���б�
        /// </summary>
        public void BindTreeView()
        {
            //��ʾȨ����״�б�
            DataTable firstTabel = SystemUM.GetPermissionsByLevel("1", "");//��ȡ��һ��Ȩ��
            int firstCount = firstTabel.Rows.Count;

            //��һ��Ȩ�޴���
            for (int first = 0; first < firstCount; first++)
            {
                TreeNode root1 = new TreeNode();
                root1.Text = firstTabel.Rows[first]["PermissionName"].ToString();
                root1.Value = firstTabel.Rows[first]["PermissionCode"].ToString();
                this.TreeView1.Nodes.Add(root1);
                root1.SelectAction = TreeNodeSelectAction.None;//�ڵ㲻�ܵ���������Ե��ǰ��ĸ�ѡ��

                //�ڶ���Ȩ���б�
                DataTable secondTabel = SystemUM.GetPermissionsByLevel("2", root1.Value.Substring(0, 2));
                int secondCount = secondTabel.Rows.Count;

                //�ڶ���Ȩ�޴���
                for (int second = 0; second < secondCount; second++)
                {
                    TreeNode root2 = new TreeNode();
                    root2.Text = secondTabel.Rows[second]["PermissionName"].ToString();
                    root2.Value = secondTabel.Rows[second]["PermissionCode"].ToString();
                    root1.ChildNodes.Add(root2);
                    root2.SelectAction = TreeNodeSelectAction.None;

                    //������Ȩ���б�
                    DataTable thirdTabel = SystemUM.GetPermissionsByLevel("3", root2.Value.Substring(0, 4));
                    int thirdCount = thirdTabel.Rows.Count;

                    //������Ȩ�޴���
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
        /// ���ݱ�Ű󶨽�ɫ��Ϣ
        /// </summary>
        /// <param name="id">��ɫ���</param>
        public void BindRoleInfo(string id)
        {
            if (Convert.ToInt32(id) == -1)
            {
                this.addBtn.Text = "�� ��";
                return;
            }
            else
            {
                this.CompareValidator2.Enabled = false;
            }

            DataTable dt = SystemUM.GetRolesPermissitionByID(Convert.ToInt32(id));
            this.roleNameTbx.Text = dt.Rows[0]["RoleName"].ToString();
            //ϵͳ����Ա�����Ƽ����𲻿��޸ģ������޸�����
            if (this.roleNameTbx.Text.ToString() == "ϵͳ����Ա")
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ɫ�������ʧ�ܣ������ϼ�����Ա��ϵ��');</script>");
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
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�����ĸü����ɫ�����Ѵ��ڣ����������룡');</script>");
                    return;
                }
                if (SystemUM.addRoleInfo(roleName, rolecode, roleDesc, list, CreateTime))
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ɫ��Ϣ���ʧ�ܣ��������Ա��ϵ��');</script>");
                //Uti.ShowDialog("��ɫ��Ϣ���ʧ�ܣ��������Ա��ϵ��", this.Page);
                else
                    Uti.ShowDialog("��ɫ��Ϣ��ӳɹ���", "SystemRole.aspx", this.Page);
            }
            else
            {
                ACount = SystemUM.CheckRoleNamebyIRL(Convert.ToInt32(id), roleName);

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + ACount + "');</script>");
                if (ACount >= 0)
                {
                    if (ACount >= 1)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�޸ĵĽ�ɫ�����Ѵ��ڣ����������룡');</script>");
                        return;
                    }
                    else
                    {
                        if (SystemUM.updateRoleInfo(Convert.ToInt32(id), roleName,roleDesc, list, CreateTime))
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ɫ��Ϣ�޸�ʧ�ܣ��������Ա��ϵ��');</script>");
                            //Uti.ShowDialog("��ɫ��Ϣ�޸�ʧ�ܣ��������Ա��ϵ��", this.Page);
                        }
                        else
                        {
                            Uti.ShowDialog("��ɫ��Ϣ�޸ĳɹ���", "SystemRole.aspx", this.Page);
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
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�޸ĵĽ�ɫ�����Ѵ��ڣ����������룡');</script>");
                            return;
                        }
                        else
                        {
                            if (SystemUM.updateRoleInfo(Convert.ToInt32(id), roleName,roleDesc, list, CreateTime))
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ɫ��Ϣ�޸�ʧ�ܣ��������Ա��ϵ��');</script>");
                                //Uti.ShowDialog("��ɫ��Ϣ�޸�ʧ�ܣ��������Ա��ϵ��", this.Page);
                            }
                            else
                            {
                                Uti.ShowDialog("��ɫ��Ϣ�޸ĳɹ���", "SystemRole.aspx", this.Page);
                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�ý�ɫ�ѱ������û�ɾ���������´�����');location.href='SystemRole.aspx';</script>");
                    }
                }
            }
        }
    }
}
