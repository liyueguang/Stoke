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
    public partial class style_ygddsp2 : System.Web.UI.Page
    {
        protected static int DisplayType = 0;
        DataTable dt_step_field;
        private int step_id = 15;         ///////////////////////////////////////////////
        private int doc_id = 0;          //////////////////////////////////////////////
        private int flow_id = 7;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh; //////////////////////////////////////////////////
        protected string _zgxm; //////////////////////////////////////////////////

        private void Page_Load(object sender, System.EventArgs e)
        {
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            //根据doc_id判断执行表单数据的插入操作或更新操作
            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                else
                    DisplayType = 0;
            }
            else
                DisplayType = 0;
            if (doc_id > 0)
                bEditMode = true;

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            if (!Page.IsPostBack)
            {

                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                    Step_Handle_Data();

                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString();
                if (step_id == 0)
                    this.btnSave.Visible = false;
                else if (step_id > 0 && step_id < 15)
                {
                    this.btnSave.Visible = false;
                    this.btnCancel.Visible = false;
                }

                else if (step_id == 15)
                {
                    this.t1.Text = _zgxm;
                }

                else if (step_id == 16)
                {
                    this.b2.Text = _zgxm;
                    this.c2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 17)
                {
                    this.i2.Text = _zgxm;
                    this.j2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 18)
                {
                    this.l2.Text = _zgxm;
                    this.m2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (step_id == -1)
                {
                    UpdateYgddsp();
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }
            }
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            //			this.w.Text = dt_style_data.Rows[0]["w"].ToString()!=null ? dt_style_data.Rows[0]["w"].ToString():null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;
            this.t1.Text = dt_style_data.Rows[0]["t1"].ToString() != null ? dt_style_data.Rows[0]["t1"].ToString() : null;
            //			this.u1.Text = dt_style_data.Rows[0]["u1"].ToString()!=null ? dt_style_data.Rows[0]["u1"].ToString():null;
            this.a2.SelectedValue = dt_style_data.Rows[0]["a2"] != DBNull.Value ? dt_style_data.Rows[0]["a2"].ToString() : "1";
            this.b2.Text = dt_style_data.Rows[0]["b2"].ToString() != null ? dt_style_data.Rows[0]["b2"].ToString() : null;
            this.c2.Text = dt_style_data.Rows[0]["c2"].ToString() != null ? dt_style_data.Rows[0]["c2"].ToString() : null;
            this.d2.SelectedValue = dt_style_data.Rows[0]["d2"] != DBNull.Value ? dt_style_data.Rows[0]["d2"].ToString() : "1";
            this.e2.Text = dt_style_data.Rows[0]["e2"].ToString() != null ? dt_style_data.Rows[0]["e2"].ToString() : null;
            this.f2.Text = dt_style_data.Rows[0]["f2"].ToString() != null ? dt_style_data.Rows[0]["f2"].ToString() : null;
            this.g2.Text = dt_style_data.Rows[0]["g2"].ToString() != null ? dt_style_data.Rows[0]["g2"].ToString() : null;
            this.h2.Text = dt_style_data.Rows[0]["h2"].ToString() != null ? dt_style_data.Rows[0]["h2"].ToString() : null;
            this.i2.Text = dt_style_data.Rows[0]["i2"].ToString() != null ? dt_style_data.Rows[0]["i2"].ToString() : null;
            this.j2.Text = dt_style_data.Rows[0]["j2"].ToString() != null ? dt_style_data.Rows[0]["j2"].ToString() : null;
            this.k2.Text = dt_style_data.Rows[0]["k2"].ToString() != null ? dt_style_data.Rows[0]["k2"].ToString() : null;
            this.l2.Text = dt_style_data.Rows[0]["l2"].ToString() != null ? dt_style_data.Rows[0]["l2"].ToString() : null;
            this.m2.Text = dt_style_data.Rows[0]["m2"].ToString() != null ? dt_style_data.Rows[0]["m2"].ToString() : null;
        }

        private void Field_Bind(DataTable dt)
        {
            string name = null;
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i][0].ToString();
                StyleControl = FrmNewDocument.FindControl(name);
                if (StyleControl != null)
                {
                    if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                    {
                        ((TextBox)StyleControl).BackColor = Color.White;
                        ((TextBox)StyleControl).ReadOnly = false;
                    }
                    if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                    {
                        ((DropDownList)StyleControl).Enabled = true;
                        ((DropDownList)StyleControl).BackColor = Color.White;
                    }
                    if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.CheckBox")
                    {
                        ((CheckBox)StyleControl).Enabled = true;
                        ((CheckBox)StyleControl).BackColor = Color.White;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveData();
            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=7&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
            Response.Redirect(_URL);
        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            //Response.Write(this.a.Text);

            if (bEditMode == false)
            {
                mySql = GetStyleInsertData();
                //拟稿
                //				doc_id = df.AddDocument(_zgbh,flow_id,mySql,d.Text.ToString()+"员工调动审批");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                df = null;
                //				if(step_id == 15)
                //				{
                //					UpdateYgddsp();
                //				}
            }

        }
        private string GetStyleInsertData()
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            mySql += "insert into DSOC_Flow_Style_Data (";
            for (int i = 0; i < FieldNum; i++)
            {
                mySql += dt_step_field.Rows[i][0].ToString() + ",";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ") values(";
            for (int i = 0; i < FieldNum; i++)
            {
                string field_name = dt_step_field.Rows[i][0].ToString();
                string field_text = GetControlText(field_name);
                mySql += "'" + field_text.Replace("'", "''") + "',";
            }


            mySql = mySql.Substring(0, mySql.Length - 1) + ")";
            return mySql;
        }

        private string GetStyleUpdateData(int DocID)
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            if (FieldNum > 0)
            {
                mySql += "update DSOC_Flow_Style_Data set ";
                for (int i = 0; i < FieldNum; i++)
                {
                    string field_name = dt_step_field.Rows[i][0].ToString();
                    string field_text = GetControlText(field_name);
                    if (field_text == null)
                        break;
                    mySql += field_name + "=" + "'" + field_text.Replace("'", "''") + "'";
                    if (i != (FieldNum - 1))
                        mySql += ",";
                }
                mySql += " where Doc_ID = " + DocID.ToString();

                return mySql;
            }
            else
            {
                return "Select 1";
            }
        }

        private string GetControlText(string field_name)
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            StyleControl = FrmNewDocument.FindControl(field_name);
            switch (StyleControl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                case "System.Web.UI.WebControls.CheckBox":
                    return ((CheckBox)StyleControl).Checked.ToString();
                default:
                    return "";
            }
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (step_id == 0)
                Response.Redirect("../Workflow/Work_Record.aspx");
            //				Response.Redirect(ViewState["retu"].ToString());
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
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
            this.zm.Click += new System.EventHandler(this.zm_Click);
            this.bm.Click += new System.EventHandler(this.bm_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void zm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_ygddsp1.aspx?DisplayType=0&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void bm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_ygddsp2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void UpdateYgddsp()
        {
            int ygddsp_id = doc_id;
            string ygddsp_ybmjj = this.v.Text;
            string ygddsp_ybmsjr = this.t1.Text;
            //			string ygddsp_dbmjj = this.w.Text ;
            //			string ygddsp_dbmsjr = this.u1.Text ;
            string ygddsp_dbmjj = "";
            string ygddsp_dbmsjr = "";
            string ygddsp_sfzgpx = this.a2.SelectedValue;
            string ygddsp_yy = this.x.Text;
            string ygddsp_bmfzr = this.b2.Text;
            string ygddsp_bmfzr_rq = this.c2.Text;
            string ygddsp_sfappx = this.d2.SelectedValue;
            string ygddsp_pxnr = this.e2.Text;
            string ygddsp_pxfs = this.f2.Text;
            string ygddsp_pxkssj = this.g2.Text;
            string ygddsp_pxjssj = this.h2.Text;
            string ygddsp_zhglbpxfzr = this.i2.Text;
            string ygddsp_zhglbpxfzrrq = this.j2.Text;
            string ygddsp_gsldpxyj = this.k2.Text;
            string ygddsp_gsldpxqz = this.l2.Text;
            string ygddsp_gsldpxqzrq = this.m2.Text;
            int ret = Stoke.Components.Staff.UpdateYgddsp(ygddsp_id,
                ygddsp_ybmjj,
                ygddsp_ybmsjr,
                ygddsp_dbmjj,
                ygddsp_dbmsjr,
                ygddsp_sfzgpx,
                ygddsp_yy,
                ygddsp_bmfzr,
                ygddsp_bmfzr_rq,
                ygddsp_sfappx,
                ygddsp_pxnr,
                ygddsp_pxfs,
                ygddsp_pxkssj,
                ygddsp_pxjssj,
                ygddsp_zhglbpxfzr,
                ygddsp_zhglbpxfzrrq,
                ygddsp_gsldpxyj,
                ygddsp_gsldpxqz,
                ygddsp_gsldpxqzrq);
        }
    }
}
