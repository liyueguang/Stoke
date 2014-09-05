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
    public partial class SystemAnnual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DataTable dtt = SystemUM.GetAnnualUser("1");
                this.roleLbx.DataSource = dtt;
                this.roleLbx.DataTextField = "UserNN";
                this.roleLbx.DataValueField = "UserNum";
                this.roleLbx.DataBind();

                dtt = SystemUM.GetAnnualUser("2");
                this.roleLbx2.DataSource = dtt;
                this.roleLbx2.DataTextField = "UserNN";
                this.roleLbx2.DataValueField = "UserNum";
                this.roleLbx2.DataBind();

                dtt = SystemUM.GetUserInfoByNRPC("", "", "", "");
                for (int i = 0; i < dtt.Rows.Count; i++) {
                    ListItem lii = new ListItem(dtt.Rows[i]["UserNumber"].ToString() + " " + dtt.Rows[i]["UserName"].ToString(), dtt.Rows[i]["UserNumber"].ToString());
                    if (!roleLbx.Items.Contains(lii))
                    {
                        this.CandidateRoleLbx.Items.Add(lii);
                    }
                    if (!roleLbx2.Items.Contains(lii))
                    {
                        this.CandidateRoleLbx2.Items.Add(lii);
                    }
                }

                dtt = SystemUM.GetAnnual();
                annualDate.Text = DateTime.Now.Year+"-"+dtt.Rows[0]["AnnualDate"].ToString();
                halfAnnualDate1.Text = DateTime.Now.Year + "-" + dtt.Rows[0]["HalfAnnualDate1"].ToString();
                halfAnnualDate2.Text = DateTime.Now.Year + "-" + dtt.Rows[0]["HalfAnnualDate2"].ToString();
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MainForm/mainWin.aspx");
        }

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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个用户！');</script>");
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个用户！');</script>");
        }

        protected void roleAddBtn2_Click(object sender, EventArgs e)
        {
            int listboxcount = this.CandidateRoleLbx2.Items.Count;
            int count = 0;
            foreach (ListItem li in this.CandidateRoleLbx2.Items)
            {
                if (li.Selected)
                {
                    this.roleLbx2.Items.Add(li);
                    this.CandidateRoleLbx2.Items.Remove(li);
                    count++;
                }
                if (this.CandidateRoleLbx2.Items.Count <= 0 || this.CandidateRoleLbx2.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个用户！');</script>");
        }

        protected void roleDelBtn2_Click(object sender, EventArgs e)
        {
            int listboxcount = this.roleLbx2.Items.Count;
            int count = 0;
            foreach (ListItem li in this.roleLbx2.Items)
            {
                if (li.Selected)
                {
                    this.CandidateRoleLbx2.Items.Add(li);
                    this.roleLbx2.Items.Remove(li);
                    count++;
                }
                if (this.roleLbx2.Items.Count <= 0 || this.roleLbx2.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个用户！');</script>");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (this.roleLbx.Items.Count == 0 || this.roleLbx2.Items.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个提醒用户！');</script>");
                return;
            }

            string AnnualUser = "";
            foreach (ListItem li in this.roleLbx.Items)
            {
                AnnualUser = AnnualUser + li.Value.ToString() + ",";
            }

            string HalfAnnualUser = "";
            foreach (ListItem li in this.roleLbx2.Items)
            {
                HalfAnnualUser = HalfAnnualUser + li.Value.ToString() + ",";
            }

            string AnnualDate = this.annualDate.Text.Substring(5,5);
            string HalfAnnualDate1 = this.halfAnnualDate1.Text.Substring(5, 5);
            string HalfAnnualDate2 = this.halfAnnualDate2.Text.Substring(5, 5);

            try
            {
                SystemUM.UpdateAnnual(AnnualDate, AnnualUser, HalfAnnualDate1, HalfAnnualDate2, HalfAnnualUser,Session["UserNum"].ToString(),DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Uti.ShowDialog("年报提醒信息修改成功！", "../MainForm/mainWin.aspx", this.Page);
            }
            catch(Exception)
            {
                Uti.ShowDialog("年报提醒信息修改失败，请与管理员联系！", this.Page);
            }
        }
    }
}
