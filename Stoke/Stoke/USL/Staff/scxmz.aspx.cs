using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Stoke.USL.Staff
{
    public partial class scxmz : System.Web.UI.Page
    {
        protected int bm_bh;
        protected string bm_mc;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Button1.Attributes.Add("onclick", "javascript:return window.confirm('ȷ��ɾ����һ��ɾ����ɾ���˲��Ŷ�Ӧ��Ա��');");
                if (Request.QueryString["bm_bh"] != null)
                    bm_bh = int.Parse(Request.QueryString["bm_bh"].ToString());
                if (Request.QueryString["bm_mc"] != null)
                    bm_mc = Request.QueryString["bm_mc"].ToString();
                this.drop_bm.Items.Add(bm_mc);
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = Stoke.Components.Staff.GetRyByBm(this.drop_bm.SelectedItem.Text.Trim());
            this.dgRy.DataSource = dt;
            this.dgRy.DataBind();
            int count = dgRy.PageSize * dgRy.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            this.dgRy.DataBind();

            for (int i = 0; i < dgRy.Items.Count; i++)
            {
                if (dgRy.Items[i].Cells[0].Text == "&nbsp;")
                {
                    LinkButton btn1 = new LinkButton();
                    btn1 = (LinkButton)dgRy.Items[i].FindControl("lbtnZwxx");
                    btn1.Visible = false;
                }
            }
        }

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.dgRy.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgRy_ItemCommand);
            this.dgRy.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgRy_PageIndexChanged);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void dgRy_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "zwxx")
                Response.Redirect("ry_bm_zw.aspx?ReturnPage=1&ry_zgbh=" + e.Item.Cells[2].Text + "&ry_xm=" + e.Item.Cells[3].Text + "&bm_mc=" + this.drop_bm.SelectedItem.Text.Trim());
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            DataTable dt = Stoke.Components.Staff.GetRyZgbhByBm(this.drop_bm.SelectedItem.Text.Trim());
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Stoke.Components.Staff.DeleteRyByZgbhBm(dt.Rows[i][0].ToString(), this.drop_bm.SelectedItem.Text.Trim());
                    }
                }
                //				else
                //					Stoke.Components.Staff.DeleteBmByBm(this.drop_bm.SelectedItem.Text.Trim());ɾ���������󻮲���
            }
            //			Stoke.Components.Staff.DeleteBmByBm(this.drop_bm.SelectedItem.Text.Trim());
            DataTable dt1 = Stoke.Components.Staff.GetRyZgbhByBm(this.drop_bm.SelectedItem.Text.Trim());
            if (dt1 != null)
                if (dt1.Rows.Count != 0)
                    Response.Write("<script>alert('������Ա��û��ְλ�����ֶ�ɾ����ְλ�������ְλ��')</script>");

            //			int ret = Stoke.Components.Staff.DeleteRyByBm(this.drop_bm.SelectedItem.Text.Trim());
            int ret = Stoke.Components.Staff.DeleteOrganizeByBm(this.drop_bm.SelectedItem.Text.Trim());

            this.BindGrid();
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("department_list.aspx?ReturnPage=1");
        }

        private void dgRy_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgRy.CurrentPageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}
