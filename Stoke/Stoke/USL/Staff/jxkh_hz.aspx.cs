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
    public partial class jxkh_hz : System.Web.UI.Page
    {
        public int DisplayType;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                else
                    DisplayType = 0;
            }
            else
                DisplayType = 0;

            if (!Page.IsPostBack)
            {
                try
                {
                    this.ddlNf.SelectedValue = System.DateTime.Now.Year.ToString();
                }
                catch
                {
                    this.ddlNf.Items.Add(System.DateTime.Now.Month.ToString());
                    this.ddlNf.SelectedValue = System.DateTime.Now.Year.ToString();
                }
                this.ddlYf.SelectedValue = System.DateTime.Now.Month.ToString();
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
            this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
            this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        private void BindGrid()
        {
            string pylx = this.ddlPylx.SelectedValue.Trim();
            int nf = 0;
            int yf = 0;
            if (this.ddlNf.SelectedValue != "���")
                nf = Convert.ToInt16(this.ddlNf.SelectedValue);
            if (this.ddlYf.SelectedValue != "�·�")
                yf = Convert.ToInt16(this.ddlYf.SelectedValue);
            DataTable dt = Stoke.Components.Staff.SelectJxkhByPylx(nf, yf, pylx);

            float jxkh_zf = 0;
            float jxkh_xs = 0;
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jxkh_zf += Convert.ToSingle(dt.Rows[i][9].ToString());
                    jxkh_xs += Convert.ToSingle(dt.Rows[i][10].ToString());
                    this.labStat.Text = "��Ч�����ܼƣ�" + jxkh_zf.ToString() + "����Чϵ���ܼƣ�" + jxkh_xs.ToString("0.00");
                }
            }

            this.dgJxkh.DataSource = dt;
            this.dgJxkh.DataBind();
            if (dt != null)
                if (dt.Rows.Count < 17)
                {
                    for (int i = 0; i < 17; i++)
                        dt.Rows.Add(dt.NewRow());
                    this.dgJxkh.DataBind();

                    for (int i = 0; i < dgJxkh.Items.Count; i++)
                    {
                        if (dgJxkh.Items[i].Cells[1].Text == "&nbsp;")
                            this.dgJxkh.Items[i].Cells[0].Text = "";
                    }
                }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (this.ddlPylx.SelectedValue == "-��ѡ��-")
                Response.Write("<script language='javascript'>alert('��ѡ���������');</script>");
            else
            {
                if (this.ddlNf.SelectedValue == "���" || this.ddlYf.SelectedValue == "�·�")
                    Response.Write("<script language='javascript'>alert('��ѡ����ݺ��·�');</script>");
                else
                {
                    this.labStat.Text = "";
                    this.dgJxkh.SelectedIndex = 0;
                    BindGrid();
                }
            }
        }

        private void lbOnline_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("jxkh_hz.aspx?DisplayType=0");
        }

        private void lbOffLine_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("jxkh_hz_bm_ry.aspx?DisplayType=1");
        }
    }
}
