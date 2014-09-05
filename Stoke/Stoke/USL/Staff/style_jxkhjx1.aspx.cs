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
using Stoke.COMMON;

namespace Stoke.USL.Staff
{
    public partial class style_jxkhjx1 : System.Web.UI.Page
    {
        protected int DisplayType = 0;

        private int step_id = 1;         ///////////////////////////////////////////////
        private int doc_id = 0;			 //////////////////////////////////////////////

        private static string _zgbh;
        private string _zgxm;
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Request["doc_id"] != null)
                doc_id = Convert.ToInt32(Request["doc_id"]);
            if (Request["zgbh"] != null)
                _zgbh = Request["zgbh"].ToString();
            if (Request["step_id"] != null)
                step_id = Convert.ToInt32(Request["step_id"]);
            if (Request["doc_id"] != null)
                doc_id = Convert.ToInt32(Request["doc_id"]);

            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                else
                    DisplayType = 0;
            }
            else
                DisplayType = 0;
            // 在此处放置用户代码以初始化页面		
            if (!Page.IsPostBack)
            {
                //				ViewState["retu"]=Request.UrlReferrer.ToString(); //20090622
                if (step_id == 1)
                {

                    //基本信息
                    BindData_jbxx();

                    if (doc_id > 0)
                    {
                        this.btnCancel.Text = "删除";
                        BindData_byid(doc_id);
                    }

                    else
                    {
                        this.reset.Visible = true;
                        //评价信息,由职工编号绑定自创的表
                        BindData_bybh(_zgbh);
                    }


                }
                else
                {

                    //由doc_id绑定rs_flow_jxjx_zp
                    BindData_byid(doc_id);
                    setTextBoxReadOnly(Page);
                    this.btnSave.Visible = false;

                }


            }//postback
        }//pageload

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
            this.zp.Click += new System.EventHandler(this.zp_Click);
            this.zq.Click += new System.EventHandler(this.zq_Click);
            this.zdp.Click += new System.EventHandler(this.zdp_Click);
            this.zs.Click += new System.EventHandler(this.zs_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.reset.Click += new System.EventHandler(this.reset_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindData_jbxx()
        {
            //用zghh取得员工姓名
            Stoke.Components.Staff _staff = new Stoke.Components.Staff();
            DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
            _zgxm = dt_xm_bm.Rows[0][0].ToString();
            this.xm.Text = _zgxm;
            this.zgbh.Text = _zgbh; ;
            this.bm.DataSource = dt_xm_bm;
            this.bm.DataValueField = "ry_bm";
            this.bm.DataTextField = "ry_bm";
            this.bm.DataBind();
        }
        private void BindData_bybh(string zgbh)
        {
            int id = 0;
            DataTable dt_pjnr = Stoke.Components.Staff.GetInfo_jxjx(zgbh, id);
            if (dt_pjnr.Rows.Count != 0)
            {
                this.td.SelectedValue = dt_pjnr.Rows[0]["jxjx_td"].ToString();
                this.bx.SelectedValue = dt_pjnr.Rows[0]["jxjx_bx"].ToString();
                this.gx.SelectedValue = dt_pjnr.Rows[0]["jxjx_gx"].ToString();
                this.gz.SelectedValue = dt_pjnr.Rows[0]["jxjx_gz"].ToString();
                this.gzl.SelectedValue = dt_pjnr.Rows[0]["jxjx_gzl"].ToString();
                this.gzhj.SelectedValue = dt_pjnr.Rows[0]["jxjx_gzhj"].ToString();
                this.gzsj.SelectedValue = dt_pjnr.Rows[0]["jxjx_gzsj"].ToString();
                this.jy.Text = dt_pjnr.Rows[0]["jxjx_jy"].ToString() != null ? dt_pjnr.Rows[0]["jxjx_jy"].ToString() : null;
                this.wt.Text = dt_pjnr.Rows[0]["jxjx_wt"].ToString() != null ? dt_pjnr.Rows[0]["jxjx_wt"].ToString() : null;
                this.yj.Text = dt_pjnr.Rows[0]["jxjx_yj"].ToString() != null ? dt_pjnr.Rows[0]["jxjx_yj"].ToString() : null;
                this.fs.Text = dt_pjnr.Rows[0]["jxjx_fs"].ToString() != null ? dt_pjnr.Rows[0]["jxjx_fs"].ToString() : null;
            }

        }

        public void setTextBoxReadOnly(System.Web.UI.Control page)
        {
            int nPageControls = page.Controls.Count;
            for (int i = 0; i < nPageControls; i++)
            {
                foreach (System.Web.UI.Control control in page.Controls[i].Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as TextBox).Enabled = false;
                    }
                    else if (control is DropDownList)
                    {
                        (control as DropDownList).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as DropDownList).Enabled = false;
                    }
                    else if (control is RadioButton)
                    {
                        (control as RadioButton).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as RadioButton).Enabled = false;
                    }
                    else if (control is RadioButtonList)
                    {
                        (control as RadioButtonList).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as RadioButtonList).Enabled = false;
                    }

                }
            }
        }

        private void BindData_byid(int id)
        {
            string zgbh = "";
            DataTable dt_style_data = Stoke.Components.Staff.GetInfo_jxjx(zgbh, id);
            if (dt_style_data.Rows.Count != 0)
            {
                this.xm.Text = dt_style_data.Rows[0]["jxjx_xm"].ToString() != null ? dt_style_data.Rows[0]["jxjx_xm"].ToString() : null;
                this.zgbh.Text = dt_style_data.Rows[0]["jxjx_zgbh"].ToString() != null ? dt_style_data.Rows[0]["jxjx_zgbh"].ToString() : null;
                //			this.bm.SelectedValue = dt_style_data.Rows[0]["jxjx_bm"].ToString();
                this.bm.DataSource = dt_style_data;
                this.bm.DataTextField = "jxjx_bm";
                this.bm.DataValueField = "jxjx_bm";
                this.bm.DataBind();
                this.td.SelectedValue = dt_style_data.Rows[0]["jxjx_td"].ToString();
                this.bx.SelectedValue = dt_style_data.Rows[0]["jxjx_bx"].ToString();
                this.gx.SelectedValue = dt_style_data.Rows[0]["jxjx_gx"].ToString();
                this.gz.SelectedValue = dt_style_data.Rows[0]["jxjx_gz"].ToString();
                this.gzl.SelectedValue = dt_style_data.Rows[0]["jxjx_gzl"].ToString();
                this.gzhj.SelectedValue = dt_style_data.Rows[0]["jxjx_gzhj"].ToString();
                this.gzsj.SelectedValue = dt_style_data.Rows[0]["jxjx_gzsj"].ToString();
                this.jy.Text = dt_style_data.Rows[0]["jxjx_jy"].ToString() != null ? dt_style_data.Rows[0]["jxjx_jy"].ToString() : null;
                this.wt.Text = dt_style_data.Rows[0]["jxjx_wt"].ToString() != null ? dt_style_data.Rows[0]["jxjx_wt"].ToString() : null;
                this.yj.Text = dt_style_data.Rows[0]["jxjx_yj"].ToString() != null ? dt_style_data.Rows[0]["jxjx_yj"].ToString() : null;
                this.fs.Text = dt_style_data.Rows[0]["jxjx_fs"].ToString() != null ? dt_style_data.Rows[0]["jxjx_fs"].ToString() : null;
            }

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1 && doc_id > 0)
            {

                Stoke.Components.Staff.DeleteJxjx(doc_id);
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
                Response.Redirect("../Workflow/Work_Record.aspx");
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (fs.Text == "" || bm.SelectedValue == "" || xm.Text == "" || zgbh.Text == "")
            {
                Response.Write("<script>alert('请填写带*的项！')</script>");
                return;
            }
            SavetoJxjx_zp();

        }
        private void SavetoJxjx_zp()
        {
            string xm = this.xm.Text;
            string zgbh = this.zgbh.Text;
            string bm = this.bm.SelectedValue;
            string td = this.td.SelectedValue;
            string bx = this.bx.SelectedValue;
            string gx = this.gx.SelectedValue;
            string gz = this.gz.SelectedValue;
            string gzl = this.gzl.SelectedValue;
            string gzhj = this.gzhj.SelectedValue;
            string gzsj = this.gzsj.SelectedValue;
            string jy = this.jy.Text;
            string wt = this.wt.Text;
            string yj = this.yj.Text;
            int fs = Int32.Parse(this.fs.Text.ToString());
            //			int fs=Convert.ToInt32(this.fs.Text.ToString());
            //			int ret = Stoke.Components.Staff.InsertJxjx(xm,zgbh,bm,td,bx,gx,gz,gzl,gzhj,gzsj,jy,wt,yj,fs);
            if (doc_id > 0)
                Stoke.Components.Staff.UpdateJxjx_byid(xm, zgbh, bm, td, bx, gx, gz, gzl, gzhj, gzsj, jy, wt, yj, fs, doc_id);
            else
                Stoke.Components.Staff.InsertJxjx(xm, zgbh, bm, td, bx, gx, gz, gzl, gzhj, gzsj, jy, wt, yj, fs);
        }

        private void reset_Click(object sender, System.EventArgs e)
        {
            //删掉库存
            //			Stoke.Components.Staff.DeleteJxjx(_zgbh);
            clear();
            //基本信息
            BindData_jbxx();
        }



        private void clear()
        {
            this.td.SelectedIndex = 0;
            this.bx.SelectedIndex = 0;
            this.gz.SelectedIndex = 0;
            this.gx.SelectedIndex = 0;
            this.gzhj.SelectedIndex = 0;
            this.gzsj.SelectedIndex = 0;
            this.gzl.SelectedIndex = 0;
            this.jy.Text = string.Empty;
            this.wt.Text = string.Empty;
            this.yj.Text = string.Empty;
            this.fs.Text = string.Empty;
        }

        private void zp_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_jxkhjx1.aspx?DisplayType=0&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void zq_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1)
            {
                if (doc_id == 0)
                {
                    int id = 0;
                    DataTable dt_pjnr = Stoke.Components.Staff.GetInfo_jxjx(_zgbh, id);
                    if (dt_pjnr.Rows.Count == 0)
                        //				if(this.fs.Text==""||this.xm.Text==""||this.zgbh.Text=="")
                        /////////////////////////////////////////////////
                        //还要判断保存没有
                        ////////////////////////////////////////////////
                        Response.Write("<script>alert('请填写带*的项并保存！')</script>");
                    else
                        Response.Redirect("style_jxkhjx2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
                }
                else
                    Response.Redirect("style_jxkhjx2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
            }

            else
                Response.Redirect("style_jxkhjx2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void zdp_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1)
            {
                //				 if(this.fs.Text==""||this.xm.Text==""||this.zgbh.Text=="")
                //					Response.Write("<script>alert('请填写带*的项！')</script>");
                //				else
                //					Response.Redirect("style_jxkhjx3.aspx?DisplayType=2&zgbh="+_zgbh+"&step_id="+step_id+"&doc_id="+doc_id);
                Response.Write("<script>alert('请按流程顺序执行！')</script>");
            }
            else
                Response.Redirect("style_jxkhjx3.aspx?DisplayType=2&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void zs_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1 || step_id == 2 || step_id == 3)
            {
                //				 if(this.fs.Text==""||this.xm.Text==""||this.zgbh.Text=="")
                //					Response.Write("<script>alert('请填写带*的项！')</script>");
                //				else
                //					Response.Redirect("style_jxkhjx4.aspx?DisplayType=3&zgbh="+_zgbh+"&step_id="+step_id+"&doc_id="+doc_id);
                Response.Write("<script>alert('请按流程顺序执行！')</script>");
            }
            else
                Response.Redirect("style_jxkhjx4.aspx?DisplayType=3&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        private void gz_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
