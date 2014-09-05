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
    public partial class SystemUserManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CandidateRoleLbx.SelectionMode = ListSelectionMode.Multiple;
                this.roleLbx.SelectionMode = ListSelectionMode.Multiple;

                DataTable dtrole = SystemUM.GetRolesByLevel();
                this.CandidateRoleLbx.DataSource = dtrole;
                this.CandidateRoleLbx.DataTextField = "roleName";
                this.CandidateRoleLbx.DataValueField = "RoleCode";
                this.CandidateRoleLbx.DataBind();

                DataTable dtbm = Department.GetAll();
                this.CompanyName.DataSource = dtbm;
                this.CompanyName.DataTextField = "bm_mc";
                this.CompanyName.DataValueField = "bm_mc";
                this.CompanyName.DataBind();

                DataTable dtzw = Place.GetAll();
                this.posiDdl.DataSource = dtzw;
                this.posiDdl.DataTextField = "zw_mc";
                this.posiDdl.DataValueField = "zw_mc";
                this.posiDdl.DataBind();

                this.addBtn.Text = "添 加";
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemUser.aspx");
        }
        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (pwdTbx.Text == "" || verifyPwdTbx.Text == "") {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('用户密码不能为空！');</script>");
                return;
            }
            if (pwdTbx.Text.Trim() !=verifyPwdTbx.Text.Trim())
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('两次输入密码不一致！');</script>");
                return;
            }

            string UserNumber, UserName, PositionName, CompanyName, PositionRank, FixedPhone, MobilePhone1, MobilePhone2, Email, Sex, LoginPassword;
            UserNumber = this.loginNameTbx.Text.Trim().ToString();
            UserName = this.nameTbx.Text.Trim().ToString();
            LoginPassword = Security.GetMd5Code(this.pwdTbx.Text.Trim().ToString());
            Sex = this.sexMaleRbtn.Checked ? "男" : "女";
            CompanyName = this.CompanyName.SelectedValue.ToString().Trim();
            PositionName = this.posiDdl.SelectedValue.ToString().Trim();
            PositionRank = "";
            FixedPhone = this.FixedPhoneTbx.Text.Trim().ToString();
            MobilePhone1 = this.Mobile1Tbx.Text.Trim().ToString();
            MobilePhone2 = this.Mobile2Tbx.Text.Trim().ToString();
            Email = this.EmailTbx.Text.Trim().ToString();
            DateTime CreateTime = DateTime.Now;
            string UserRange = "";
            foreach (ListItem li in this.roleLbx.Items)
            {
                UserRange = UserRange + li.Value.ToString() + ",";
            }
            if (SystemUM.GetUserCountByNum(UserNumber) != 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('该用户名已存在，请重新输入！');</script>");
                return;
            }
            if (UserRange == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请为该用户选择角色！');</script>");
                return;
            }
            if (SystemUM.addUserInfo(UserNumber, LoginPassword, UserName, Sex, FixedPhone, MobilePhone1, MobilePhone2, CompanyName, PositionName, Email, CreateTime, UserRange))
                Uti.ShowDialog("用户信息添加失败，请与管理员联系！", "SystemUser.aspx", this.Page);
            else
                Uti.ShowDialog("用户信息添加成功！", "SystemUser.aspx", this.Page);
        }
        protected void roleAddBtn_Click(object sender, EventArgs e)
        {
            pwdTbx.Attributes["value"] = pwdTbx.Text.Trim();
            verifyPwdTbx.Attributes["value"] = verifyPwdTbx.Text.Trim();
            int listboxcount = this.CandidateRoleLbx.Items.Count;
            int count = 0;
            foreach (ListItem li in this.CandidateRoleLbx.Items)
            {
                if (li.Selected)
                {
                    this.roleLbx.Items.Add(li);
                    this.CandidateRoleLbx.Items.Remove(li);
                    count++;
                }
                if (this.CandidateRoleLbx.Items.Count <= 0 || this.CandidateRoleLbx.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个角色！');</script>");
        }

        protected void roleDelBtn_Click(object sender, EventArgs e)
        {
            int listboxcount = this.roleLbx.Items.Count;
            int count = 0;
            foreach (ListItem li in this.roleLbx.Items)
            {
                if (li.Selected)
                {
                    this.CandidateRoleLbx.Items.Add(li);
                    this.roleLbx.Items.Remove(li);
                    count++;
                }
                if (this.roleLbx.Items.Count <= 0 || this.roleLbx.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个角色！');</script>");
        }
    }
}
