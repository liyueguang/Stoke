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
using System.Data.SqlClient;
using Stoke.BLL;
using Stoke.DAL;
using Stoke.COMMON;

namespace Stoke.USL.Staff
{
    public partial class Depart_Manage : System.Web.UI.Page
    {
        protected string _bm_lx;
        protected string _bm_bh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _bm_lx = Session["bm_lx"].ToString();
            if (!IsPostBack)
            {
                if (_bm_lx == "new")
                {
                    Label3.Text = "新建部门/项目组";
                    this.txtName.Enabled = true;
                }
                else if (_bm_lx == "update")
                {
                    Label3.Text = "部门/项目组管理";
                    int _bm_bh = Convert.ToInt32(Session["bm_bh"]);
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string sqlStr = "select * from dsoc_bm where bm_bh = '" + _bm_bh + "'";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtName.Text = dr.IsDBNull(1) ? null : dr["bm_mc"].ToString();
                        txtIntro.Text = dr.IsDBNull(2) ? null : dr["bm_js"].ToString();
                        this.DropDownList1.SelectedValue = dr.IsDBNull(3) ? "0" : dr["bm_xmz"].ToString();
                        this.txt_bmjc.Text = dr.IsDBNull(4) ? null : dr["bm_jc"].ToString();
                        kgmlh.Text = dr.IsDBNull(5) ? null : dr["bm_kgmlh"].ToString();
                    }
                    dr.Close();
                    conn.Close();
                }
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
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Department dpt = new Department();
            if (_bm_lx == "new")
            {
                if (this.txt_bmjc.Text == "")
                {
                    Response.Write("<script>alert('请填写部门简称！')</script>");
                }
                else
                {
                    dpt.Bm_mc = txtName.Text.ToString();
                    dpt.Bm_js = txtIntro.Text.ToString();
                    dpt.Bm_xmz = DropDownList1.SelectedValue.ToString();
                    dpt.Bm_jc = this.txt_bmjc.Text;
                    dpt.Bm_kgmlh = kgmlh.Text.ToString();
                    Department.InsertBm(dpt);
                }
            }
            else if (_bm_lx == "update")
            {
                if (this.txt_bmjc.Text == "")
                {
                    Response.Write("<script>alert('请填写部门简称！')</script>");
                }
                else
                {
                    dpt.Bm_bh = Convert.ToInt32(Session["bm_bh"]);
                    dpt.Bm_mc = txtName.Text.ToString();
                    dpt.Bm_js = txtIntro.Text.ToString();
                    dpt.Bm_xmz = DropDownList1.SelectedValue.ToString();
                    dpt.Bm_jc = this.txt_bmjc.Text;
                    dpt.Bm_kgmlh = kgmlh.Text.ToString();
                    Department.UpdateBm(dpt);
                }
            }
            Response.Redirect("bm_list.aspx");
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("bm_list.aspx");
        }
    }
}
