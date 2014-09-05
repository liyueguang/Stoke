using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Stoke.COMMON;

namespace Stoke.USL.gwgl
{
    public partial class wdk_xz_select : System.Web.UI.Page
    {
        protected string _zgbh;
        protected string type;
        protected string doc_id;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _zgbh = Session["zgbh"].ToString();

            //tonzoc-20110808
            type = Request.QueryString["type"];
            doc_id = Request.QueryString["doc_id"];

            BindData_tonzoc();

            if (!this.IsPostBack)
            {
                SqlDataReader dr = null;
                Stoke.Components.zhxx zhxxggl = new Stoke.Components.zhxx();
                dr = zhxxggl.GetLb();
                Drop_ssbm.DataSource = dr;
                Drop_ssbm.DataTextField = "bm_mc";
                Drop_ssbm.DataValueField = "bm_mc";
                Drop_ssbm.DataBind();
                dr.Close();
                Drop_ssbm.Items.Insert(0, "-请选择部门-");
                Drop_ssbm.SelectedIndex = 0;

                if (Session["Txt_wjm_xz_select"] != null)
                {
                    this.Txt_wjm.Text = Session["Txt_wjm_xz_select"].ToString();
                }
                if (Session["Drop_ssbm_xz_select"] != null)
                {
                    this.Drop_ssbm.SelectedValue = Session["Drop_ssbm_xz_select"].ToString();
                }
                if (Session["Txt_sj_xz_select"] != null)
                {
                    this.Txt_sj.Text = Session["Txt_sj_xz_select"].ToString();
                }



            }




        }

        protected void BindData_tonzoc()
        {
            SqlConnection conn = new SqlConnection(Stoke.DAL.SQLHelper.CONN_STRING);

            string _sql = "select distinct doc_fileid, doc_bh, doc_filename, doc_mj, doc_bm, doc_time, dbo.f_getGwAttach(doc_fileid) + isnull(convert(varchar(20), b.qx_bz), '0') + a.doc_mj as attachList, b.qx_bz from gw_doc as a left join (select distinct qx_bz, qx_bh from doc_ht where qx_bz = '2' and qx_bg = (select distinct ry_xm from dsoc_ry where ry_zgbh = '" + _zgbh + "')) as b on a.id = b.qx_bh" +
                "  where  ( a.flag='0'or a.id in (select qx_bh  from doc_ht where  qx_bg in(select ry_bm from dsoc_ry where ry_zgbh='" + _zgbh + "') or qx_bg=(select distinct ry_xm from dsoc_ry where ry_zgbh='" + _zgbh + "' ) ) ) and doc_id=1 and doc_zl='公司文件'";

            if (Session["Txt_wjm_xz_select"] != null)
            {
                _sql += "and a.doc_filename  like '%" + Session["Txt_wjm_xz_select"].ToString() + "%'";
            }

            if (Session["Drop_ssbm_xz_select"] != null)
            {
                _sql += "and a.doc_bm='" + Session["Drop_ssbm_xz_select"].ToString().Trim() + "'";
            }
            if (Session["Txt_sj_xz_select"] != null)
            {
                _sql += "and a.doc_time='" + Session["Txt_sj_xz_select"].ToString() + "'";
            }

            _sql += "order by doc_time desc ";
            SqlCommand cmd = new SqlCommand(_sql, conn);
            conn.Open();
            System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            for (int i = dt.Rows.Count + 1; i <= 15; ++i)
            {
                dt.Rows.Add(dt.NewRow());
            }

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 15;

            int pageIndex = 0;
            if (Session["pageIndex_wdk_xz_select"] != null)
            {
                pageIndex = Convert.ToInt32(Session["pageIndex_wdk_xz_select"]);
            }

            if (pageIndex <= 0)
            {
                pageIndex = 0;
                this.preBtn.Visible = false;
            }
            else
            {
                this.preBtn.Visible = true;
            }
            if (pageIndex >= pds.PageCount - 1)
            {
                pageIndex = pds.PageCount - 1;
                this.nextBtn.Visible = false;
            }
            else
            {
                this.nextBtn.Visible = true;
            }

            pds.CurrentPageIndex = pageIndex;
            Session["pageIndex_wdk_xz_select"] = pageIndex;

            this.pageLabel.Text = " 当前页： 第" + (pageIndex + 1) + "/" + pds.PageCount + "页 ";


            //------------------tonzoc-20110818---------------------------------------------------
            this.data_Repeater.DataSource = pds;
            this.data_Repeater.DataBind();
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
            this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
            this.data_Repeater.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.data_Repeater_ItemDataBound);
            this.data_Repeater.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.data_Repeater_ItemCommand);
            this.preBtn.Click += new System.EventHandler(this.preBtn_Click);
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion



        private void data_Repeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int fileid = Convert.ToInt32((e.Item.FindControl("fileid") as TextBox).Text.Trim());
            if (e.CommandName.ToString() == "sel")
            {
                TextBox tb1 = e.Item.FindControl("fileid") as TextBox;
                TextBox tb2 = e.Item.FindControl("filename") as TextBox;
                TextBox tb3 = e.Item.FindControl("bh") as TextBox;

                string url = "CxFz.aspx?filename=" + tb2.Text + "&fileid=" + tb1.Text
                    + "&step_id=1&doc_id=" + doc_id + "&type=" + type + "&gwwh=" + tb3.Text + "&zgbh=" + _zgbh;
                Response.Redirect(url);
            }
        }





        private void LinkButton1_Click(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Stoke.DAL.SQLHelper.CONN_STRING);

            if (this.Txt_wjm.Text != "")
            {
                Session["Txt_wjm_xz_select"] = this.Txt_wjm.Text.Trim();
            }
            else
            {
                Session.Remove("Txt_wjm");
            }

            if (this.Drop_ssbm.SelectedIndex != 0)
            {
                Session["Drop_ssbm_xz_select"] = this.Drop_ssbm.SelectedItem.Text;
            }
            else
            {
                Session.Remove("Drop_ssbm");
            }

            if (this.Txt_sj.Text != "")
            {
                Session["Txt_sj_xz_select"] = this.Txt_sj.Text.Trim();
            }
            else
            {
                Session.Remove("Txt_sj");
            }
            Session["pageIndex_wdk_xz_select"] = 0;
            Response.Redirect("wdk_xz_select.aspx");


        }



        private void preBtn_Click(object sender, System.EventArgs e)
        {
            Session["pageIndex_wdk_xz_select"] = Convert.ToInt32(Session["pageIndex_wdk_xz_select"]) - 1;
            Response.Redirect("wdk_xz_select.aspx");
        }

        private void nextBtn_Click(object sender, System.EventArgs e)
        {
            Session["pageIndex_wdk_xz_select"] = Convert.ToInt32(Session["pageIndex_wdk_xz_select"]) + 1;
            Response.Redirect("wdk_xz_select.aspx");
        }

        private void data_Repeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton link1 = e.Item.FindControl("Linkbutton1") as LinkButton;
                TextBox tb1 = e.Item.FindControl("mj") as TextBox;
                if (tb1.Text.Trim() == "已废止文件")
                {
                    link1.Enabled = false;
                }
                if (tb1.Text.Trim() == "")
                {
                    link1.Visible = false;
                }
            }
        }
    }
}
