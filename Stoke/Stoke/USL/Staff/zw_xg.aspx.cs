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
    public partial class zw_xg : System.Web.UI.Page
    {
        protected int zw_bh = 0;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["zw_bh"] != null)
                {
                    if (Request.QueryString["zw_bh"].ToString() != "")
                        zw_bh = Int32.Parse(Request.QueryString["zw_bh"].ToString().Trim());
                    else
                        zw_bh = 0;
                }
                this.txt_zwbh.Text = zw_bh.ToString();
                BindZwjb();
                DataTable dt = Stoke.Components.Staff.GetZwByBh(zw_bh);
                if (dt != null)
                    if (dt.Rows.Count != 0)
                    {
                        this.txt_zwmc.Text = dt.Rows[0][1].ToString();
                        this.txt_zwgn.Text = dt.Rows[0][2].ToString();
                        this.ddlZwjb.SelectedValue = dt.Rows[0][3].ToString();
                    }
            }
        }

        private void BindZwjb()
        {
            DataTable dt = Stoke.Components.Staff.GetZwJB();
            this.ddlZwjb.DataSource = dt;
            this.ddlZwjb.DataTextField = "zwjbmc";
            this.ddlZwjb.DataValueField = "zwjb";
            this.ddlZwjb.DataBind();
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
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Button1_Click(object sender, System.EventArgs e)
        {
            int ret = Stoke.Components.Staff.UpdateZw(Convert.ToInt32(this.txt_zwbh.Text), this.txt_zwgn.Text, this.ddlZwjb.SelectedValue.Trim());
            if (ret != 0)
                Response.Write("<script>alert('修改成功！')</script>");
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("position_manage.aspx");
        }
    }
}
