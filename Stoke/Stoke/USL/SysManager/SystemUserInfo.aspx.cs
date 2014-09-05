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
    public partial class SystemUserInfo : System.Web.UI.Page
    {
        public static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('请先登录，在进行操作！');top.location.href='../login.aspx'</script>");
                }

                id = Convert.ToInt32(Session["userid"].ToString());

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

                roleid.Visible = false;
                loginNameTbx.Enabled = false;
                nameTbx.Enabled = false;
                posiDdl.Enabled = false;
                CompanyName.Enabled = false;

                BindUserInfo(id);
            }
        }

        /// <summary>
        /// 根据编号绑定用户信息
        /// </summary>
        /// <param name="id">用户编号</param>
        public void BindUserInfo(int id)
        {
            //填充候选角色列表
            DataTable dtrole = SystemUM.GetRolesByLevel();
            this.CandidateRoleLbx.DataSource = dtrole;
            this.CandidateRoleLbx.DataTextField = "roleName";
            this.CandidateRoleLbx.DataValueField = "RoleCode";
            this.CandidateRoleLbx.DataBind();

            DataTable dt = SystemUM.GetUserInfoByID(id);
            this.loginNameTbx.Text = dt.Rows[0]["UserNumber"].ToString();
            this.TextBox1.Text = dt.Rows[0]["UserNumber"].ToString();
            this.nameTbx.Text = dt.Rows[0]["UserName"].ToString();
            this.sexMaleRbtn.Checked = dt.Rows[0]["Sex"].ToString() == "男" ? true : false;
            this.sexFemaleRbtn.Checked = !this.sexMaleRbtn.Checked;
            this.CompanyName.SelectedValue = dt.Rows[0]["CompanyName"].ToString().Trim();
            this.posiDdl.SelectedValue = dt.Rows[0]["PositionName"].ToString().Trim();
            this.FixedPhoneTbx.Text = dt.Rows[0]["FixedPhone"].ToString();
            this.Mobile1Tbx.Text = dt.Rows[0]["MobilePhone1"].ToString();
            this.Mobile2Tbx.Text = dt.Rows[0]["MobilePhone2"].ToString();
            this.EmailTbx.Text = dt.Rows[0]["Email"].ToString();

            //填充用户已选角色
            DataTable dtr = SystemUM.GetUserRoleByNum(dt.Rows[0]["UserNumber"].ToString());
            this.roleLbx.DataSource = dtr;
            this.roleLbx.DataTextField = "roleName";
            this.roleLbx.DataValueField = "RoleCode";
            this.roleLbx.DataBind();
            //候选角色中删除已选角色
            foreach (ListItem li in this.roleLbx.Items)
            {
                this.CandidateRoleLbx.Items.Remove(li);
                if (this.CandidateRoleLbx.Items.Count <= 0)
                    return;
            }
        }

        #region 更新用户基本信息
        protected void updBtn_Click(object sender, EventArgs e)
        {
            //获取未修改前的用户编号
            DataTable dt = SystemUM.GetUserInfoByID(id);
            string OUserNumber = dt.Rows[0]["UserNumber"].ToString().Trim();

            string UserNumber, UserName, PositionName, CompanyName, FixedPhone, MobilePhone1, MobilePhone2, Email, Sex;
            UserNumber = this.loginNameTbx.Text.Trim().ToString();

            UserName = this.nameTbx.Text.Trim().ToString();
            Sex = this.sexMaleRbtn.Checked ? "男" : "女";
            CompanyName = this.CompanyName.SelectedValue.ToString().Trim();
            PositionName = this.posiDdl.SelectedValue.ToString().Trim();
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
            if (UserNumber != OUserNumber)
            {
                if (SystemUM.GetUserCountByNum(UserNumber) != 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('该用户名已存在，请重新输入！');</script>");
                    return;
                }
            }
            if (UserRange == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请为该用户选择角色！');</script>");
                return;
            }
            if (SystemUM.updateUserInfo(OUserNumber, UserNumber, UserName, Sex, FixedPhone, MobilePhone1, MobilePhone2, CompanyName, PositionName, Email, CreateTime, UserRange))
                Uti.ShowDialog("用户信息修改失败，请与管理员联系！", this.Page);
            else
                Uti.ShowDialog("用户信息修改成功！", "SystemUserInfo.aspx", this.Page);

        }
        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemUserInfo.aspx");
        }

        #endregion

        #region 角色列表处理
        protected void roleAddBtn_Click(object sender, EventArgs e)
        {
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

        #endregion

        #region 修改密码
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserNumber = this.TextBox1.Text.ToString().Trim();
            
            string Password = Security.GetMd5Code(this.pwdTbx.Text.ToString().Trim());


            if (SystemUM.UpdeateUserPwd(UserNumber, Password))
                Uti.ShowDialog("用户密码修改成功！", "SystemUserInfo.aspx", this.Page);
            else
                Uti.ShowDialog("用户密码修改失败，请与管理员联系！", this.Page);

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemUserInfo.aspx");
        }
        #endregion
    }
}
