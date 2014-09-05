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
    public partial class jxkh_hz_bm_ry : System.Web.UI.Page
    {
        public int DisplayType;

        private void Page_Load(object sender, System.EventArgs e)
        {
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
                this.Table6.Visible = false;
                this.txtQsNf.Text = System.DateTime.Now.Year.ToString();
                this.txtQsYf.Text = System.DateTime.Now.Month.ToString();
                this.txtJzNf.Text = System.DateTime.Now.Year.ToString();
                this.txtJzYf.Text = System.DateTime.Now.Month.ToString();
                BindBm();
                BindGrid(0);
            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
            this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
            this.btnStatBm.Click += new System.EventHandler(this.btnStatBm_Click);
            this.lbtnRy.Click += new System.EventHandler(this.lbtnRy_Click);
            this.btnStatRy.Click += new System.EventHandler(this.btnStatRy_Click);
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

        private void BindBm()
        {
            DataTable dt = Stoke.Components.Staff.GetBmXmz(0);
            ddlBm.DataSource = dt;
            ddlBm.DataTextField = "bm_mc";
            ddlBm.DataValueField = "bm_mc";
            ddlBm.DataBind();
            ddlBm.Items.Insert(0, "-请选择-");
            ddlBm.SelectedIndex = 0;
        }

        private void BindGrid(int flag)//0：根据部门统计，1：根据人员统计
        {
            string bm_or_ry = "";
            if (flag == 0)
                bm_or_ry = this.ddlBm.SelectedValue.Trim();
            else
                bm_or_ry = this.txtZgbh.Text;
            int qs_nf = Convert.ToInt16(this.txtQsNf.Text);
            int qs_yf = Convert.ToInt16(this.txtQsYf.Text);
            int jz_nf = Convert.ToInt16(this.txtJzNf.Text);
            int jz_yf = Convert.ToInt16(this.txtJzYf.Text);
            DataTable dt = Stoke.Components.Staff.SelectJxkhByBmRy(qs_nf, qs_yf, jz_nf, jz_yf, bm_or_ry, flag);

            float jxkh_zf = 0;
            float jxkh_xs = 0;
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jxkh_zf += Convert.ToSingle(dt.Rows[i][2].ToString());
                    jxkh_xs += Convert.ToSingle(dt.Rows[i][3].ToString());
                    this.labStat.Text = bm_or_ry + "绩效考核总计：" + jxkh_zf.ToString() + "，绩效系数总计：" + jxkh_xs.ToString("0.00");
                }
            }

            this.dgJxkh.DataSource = dt;
            this.dgJxkh.DataBind();

            if (dt != null)
                if (dt.Rows.Count < 15)
                {
                    for (int i = 0; i < 15; i++)
                        dt.Rows.Add(dt.NewRow());
                    this.dgJxkh.DataBind();

                    for (int i = 0; i < dgJxkh.Items.Count; i++)
                    {
                        if (dgJxkh.Items[i].Cells[1].Text == "&nbsp;")
                            this.dgJxkh.Items[i].Cells[0].Text = "";
                    }
                }
        }

        private void btnStatBm_Click(object sender, System.EventArgs e)
        {
            if (this.txtQsNf.Text == string.Empty || this.txtQsYf.Text == string.Empty || this.txtJzNf.Text == string.Empty || this.txtJzYf.Text == string.Empty)
                Response.Write("<script language='javascript'>alert('请选择起始时间和截止时间');</script>");
            else
            {
                int qs_nf = Convert.ToInt16(this.txtQsNf.Text);
                int qs_yf = Convert.ToInt16(this.txtQsYf.Text);
                int jz_nf = Convert.ToInt16(this.txtJzNf.Text);
                int jz_yf = Convert.ToInt16(this.txtJzYf.Text);
                if (qs_nf > jz_nf)
                    Response.Write("<script language='javascript'>alert('起始时间大于截止时间');</script>");
                else
                {
                    if (qs_nf == jz_nf)
                        if (qs_yf > jz_yf)
                        {
                            Response.Write("<script language='javascript'>alert('起始时间大于截止时间');</script>");
                            return;
                        }

                    if (this.ddlBm.SelectedValue == "-请选择-")
                        Response.Write("<script language='javascript'>alert('请选择部门');</script>");
                    else
                        BindGrid(0);
                }
            }
        }

        private void btnStatRy_Click(object sender, System.EventArgs e)
        {
            this.ddlBm.SelectedIndex = 0;
            if (this.txtQsNf.Text == string.Empty || this.txtQsYf.Text == string.Empty || this.txtJzNf.Text == string.Empty || this.txtJzYf.Text == string.Empty)
                Response.Write("<script language='javascript'>alert('请选择起始时间和截止时间');</script>");
            else
            {
                int qs_nf = Convert.ToInt16(this.txtQsNf.Text);
                int qs_yf = Convert.ToInt16(this.txtQsYf.Text);
                int jz_nf = Convert.ToInt16(this.txtJzNf.Text);
                int jz_yf = Convert.ToInt16(this.txtJzYf.Text);
                if (qs_nf > jz_nf)
                    Response.Write("<script language='javascript'>alert('起始时间大于截止时间');</script>");
                else
                {
                    if (qs_nf == jz_nf)
                        if (qs_yf > jz_yf)
                        {
                            Response.Write("<script language='javascript'>alert('起始时间大于截止时间');</script>");
                            return;
                        }

                    if (this.txtZgbh.Text == string.Empty)
                        Response.Write("<script language='javascript'>alert('请选择人员');</script>");
                    else
                        BindGrid(1);
                }
            }
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            string ry_xm_list = SlctMember1.Send[0].ToString().Trim();
            string ry_zgbh_list = SlctMember1.Send[1].ToString().Trim();
            if (ry_xm_list.Split(',').Length > 1)
                Response.Write("<script>alert('请选择1人！')</script>");
            else if (ry_xm_list.Split(',')[0] == "")
                Response.Write("<script>alert('请选择人员！')</script>");
            else if (ry_xm_list.Split(',').Length == 1)
            {
                this.txtXm.Text = ry_xm_list.Split(',')[0].Trim();
                this.txtZgbh.Text = ry_zgbh_list.Split(',')[0].Trim();
                this.SlctMember1.Clear();
                this.Table6.Visible = false;
            }
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = false;
        }

        private void lbtnRy_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = true;
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
