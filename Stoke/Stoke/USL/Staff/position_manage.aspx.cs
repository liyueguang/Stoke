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
    public partial class position_manage : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindZwjb();
                BindGrid();
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
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            this.dbZw.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbZw_ItemCommand);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindZwjb()
        {
            DataTable dt = Stoke.Components.Staff.GetZwJB();
            this.ddlFlag.DataSource = dt;
            this.ddlFlag.DataTextField = "zwjbmc";
            this.ddlFlag.DataValueField = "zwjb";
            this.ddlFlag.DataBind();
            this.ddlFlag.Items.Insert(0, "-��ѡ��-");
            this.ddlFlag.SelectedIndex = 0;
        }

        private void BindGrid()
        {
            DataTable dt = Stoke.Components.Staff.GetZwAll();

            this.dbZw.DataSource = dt;
            this.dbZw.DataBind();
            int count = dbZw.PageSize * dbZw.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            this.dbZw.DataBind();

            for (int i = 0; i < dbZw.Items.Count; i++)
            {
                if (dbZw.Items[i].Cells[0].Text == "&nbsp;")
                {
                    LinkButton btn1 = new LinkButton();
                    btn1 = (LinkButton)dbZw.Items[i].FindControl("LinkButton1");
                    btn1.Visible = false;
                    LinkButton btn2 = new LinkButton();
                    btn2 = (LinkButton)dbZw.Items[i].FindControl("LinkButton2");
                    btn2.Visible = false;
                }
            }
        }

        private void btn_add_Click(object sender, System.EventArgs e)
        {
            if (this.txt_zw.Text == "" || this.txt_zw.Text == "ְλ����")
                Response.Write("<script>alert('����дְλ���ƣ�')</script>");
            else if (this.ddlFlag.SelectedIndex == 0)
                Response.Write("<script>alert('��ѡ��ְλ����')</script>");
            else
            {
                int ret = Stoke.Components.Staff.InsertZw(this.txt_zw.Text, this.txt_js.Text, this.ddlFlag.SelectedValue);
                if (ret != -1)
                    Response.Write("<script>alert('���ְλ�ɹ���')</script>");
                this.txt_zw.Text = null;
                this.txt_js.Text = null;
                BindGrid();
            }
        }

        public void dbZw_PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            dbZw.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void dbZw_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "sc")
            {
                DataTable dt = Stoke.Components.Staff.GetRyNumByZw(e.Item.Cells[1].Text.Trim());
                int num = 0;
                if (dt != null)
                    if (dt.Rows.Count != 0)
                        num = int.Parse(dt.Rows[0][0].ToString());
                if (num == 0)
                {
                    int ret = Stoke.Components.Staff.DeleteZw(int.Parse(e.Item.Cells[0].Text));
                    if (ret != -1)
                        Response.Write("<script>alert('ɾ��ְλ�ɹ���')</script>");
                    dbZw.CurrentPageIndex = 0;
                    BindGrid();
                }
                else
                    Response.Write("<script>alert('�����޸Ĵ�ְλ��Ӧ����Աְλ��')</script>");
            }
            else if (e.CommandName == "xg")
            {
                Response.Redirect("zw_xg.aspx?zw_bh=" + e.Item.Cells[0].Text);
            }
        }
    }
}
