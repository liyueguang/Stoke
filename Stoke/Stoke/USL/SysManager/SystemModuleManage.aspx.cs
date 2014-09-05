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
        /// 根据编号绑定权限信息
        /// </summary>
        /// <param name="id">权限编号</param>
        public void BindModuleInfo(string id)
        {
            if (Convert.ToInt32(id) == -1)
            {
                this.addBtn.Text = "添 加";
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('角色编号生成失败，请与上级管理员联系！');</script>");
                return;
            }
            if (Convert.ToInt32(id) == -1)
            {
                if (SystemUM.addPermissionInfo(moduleCode, moduleName, moduleDesc, moduleUrl, time))
                    Uti.ShowDialog("权限信息添加失败，请与管理员联系！", this.Page);
                else
                    Uti.ShowDialog("权限信息添加成功！", "SystemModule.aspx", this.Page);
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
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('该用权限名称已存在，请重新输入！');</script>");
                    return;
                }
                if (SystemUM.updatePermissionInfo(Convert.ToInt32(id), moduleName, moduleDesc, time))
                    Uti.ShowDialog("权限信息修改失败，请与管理员联系！", this.Page);
                else
                    Uti.ShowDialog("权限信息修改成功！", "SystemModule.aspx", this.Page);
            }
        }
    }
}
