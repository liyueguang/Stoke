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
    public partial class SystemModuleManage : System.Web.UI.Page
    {
        public static string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                id = Request.QueryString["ID"].ToString();

                BindModuleInfo(id);
            }
        }

        /// <summary>
        /// ���ݱ�Ű�Ȩ����Ϣ
        /// </summary>
        /// <param name="id">Ȩ�ޱ��</param>
        public void BindModuleInfo(string id)
        {
            if (Convert.ToInt32(id) == -1)
            {
                this.addBtn.Text = "�� ��";
                return;
            }
            DataTable dt = SystemUM.GetPermissions(Convert.ToInt32(id));
            this.moduleNameTbx.Text = dt.Rows[0]["PermissionName"].ToString();
            this.despTbx.Text = dt.Rows[0]["PermissionDescription"].ToString();
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemModule.aspx");
        }
        protected void addBtn_Click(object sender, EventArgs e)
        {
            string moduleName = this.moduleNameTbx.Text.ToString();
            string moduleDesc = this.despTbx.Text.ToString();
            string moduleUrl = "";
            DateTime time = DateTime.Now;
            string moduleCode = time.ToString();
            if (moduleCode == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ɫ�������ʧ�ܣ������ϼ�����Ա��ϵ��');</script>");
                return;
            }
            if (Convert.ToInt32(id) == -1)
            {
                if (SystemUM.addPermissionInfo(moduleCode, moduleName, moduleDesc, moduleUrl, time))
                    Uti.ShowDialog("Ȩ����Ϣ���ʧ�ܣ��������Ա��ϵ��", this.Page);
                else
                    Uti.ShowDialog("Ȩ����Ϣ��ӳɹ���", "SystemModule.aspx", this.Page);
            }
            else
            {
                int UCount = 0;
                DataTable dt = SystemUM.GetPermissions(Convert.ToInt32(id));
                if (dt.Rows.Count > 0)
                {
                    string PermissionCode = dt.Rows[0]["PermissionCode"].ToString();
                    UCount = SystemUM.GetPermissionsByNameID(moduleName, PermissionCode).Rows.Count;
                }

                if (UCount > 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('����Ȩ�������Ѵ��ڣ����������룡');</script>");
                    return;
                }
                if (SystemUM.updatePermissionInfo(Convert.ToInt32(id), moduleName, moduleDesc, time))
                    Uti.ShowDialog("Ȩ����Ϣ�޸�ʧ�ܣ��������Ա��ϵ��", this.Page);
                else
                    Uti.ShowDialog("Ȩ����Ϣ�޸ĳɹ���", "SystemModule.aspx", this.Page);
            }
        }
    }
}
