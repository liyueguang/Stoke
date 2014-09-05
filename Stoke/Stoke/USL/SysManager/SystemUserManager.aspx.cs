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

                this.addBtn.Text = "�� ��";
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemUser.aspx");
        }
        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (pwdTbx.Text == "" || verifyPwdTbx.Text == "") {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�û����벻��Ϊ�գ�');</script>");
                return;
            }
            if (pwdTbx.Text.Trim() !=verifyPwdTbx.Text.Trim())
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�����������벻һ�£�');</script>");
                return;
            }

            string UserNumber, UserName, PositionName, CompanyName, PositionRank, FixedPhone, MobilePhone1, MobilePhone2, Email, Sex, LoginPassword;
            UserNumber = this.loginNameTbx.Text.Trim().ToString();
            UserName = this.nameTbx.Text.Trim().ToString();
            LoginPassword = Security.GetMd5Code(this.pwdTbx.Text.Trim().ToString());
            Sex = this.sexMaleRbtn.Checked ? "��" : "Ů";
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('���û����Ѵ��ڣ����������룡');</script>");
                return;
            }
            if (UserRange == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��Ϊ���û�ѡ���ɫ��');</script>");
                return;
            }
            if (SystemUM.addUserInfo(UserNumber, LoginPassword, UserName, Sex, FixedPhone, MobilePhone1, MobilePhone2, CompanyName, PositionName, Email, CreateTime, UserRange))
                Uti.ShowDialog("�û���Ϣ���ʧ�ܣ��������Ա��ϵ��", "SystemUser.aspx", this.Page);
            else
                Uti.ShowDialog("�û���Ϣ��ӳɹ���", "SystemUser.aspx", this.Page);
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ѡ��һ��������ɫ��');</script>");
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ѡ��һ��������ɫ��');</script>");
        }
    }
}
