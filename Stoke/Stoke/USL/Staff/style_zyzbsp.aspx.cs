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
    public partial class style_zyzbsp : System.Web.UI.Page
    {
        
        DataTable dt_step_field;
        private int step_id = 1;         ///////////////////////////////////////////////
        private int doc_id = 0;          //////////////////////////////////////////////
        private int flow_id = 9;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm; //////////////////////////////////////////////////

        private void Page_Load(object sender, System.EventArgs e)
        {
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            //根据doc_id判断执行表单数据的插入操作或更新操作
            if (doc_id > 0)
                bEditMode = true;

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            if (!Page.IsPostBack)
            {

                ViewState["retu"] = Request.UrlReferrer.ToString(); //20090622
                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                    Step_Handle_Data();

                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString().Trim();
                if (step_id == 0)
                    this.btnSave.Visible = false;
                else if (step_id == 1)
                {
                    this.a.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    this.b.DataSource = dt_xm_bm;
                    this.b.DataValueField = "ry_bm";
                    this.b.DataTextField = "ry_bm";
                    this.b.DataBind();
                    this.s.Text = _zgxm;
                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                }
                else if (step_id == 2)
                    this.u.Text = _zgxm;
                else if (step_id == 3)
                    this.a1.Text = _zgxm;
                else if (step_id == 4)
                    this.b1.Text = _zgxm;

                else if (step_id == -1)
                {
                    SavetoZyzbsp();
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }
            }
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
            this.b.DataSource = dt_style_data;
            this.b.DataValueField = "b";
            this.b.DataTextField = "b";
            this.b.DataBind();
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.e.Checked = dt_style_data.Rows[0]["e"].ToString() != "False" ? true : false;
            this.f.Checked = dt_style_data.Rows[0]["f"].ToString() != "False" ? true : false;
            this.g.Checked = dt_style_data.Rows[0]["g"].ToString() != "False" ? true : false;
            this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
            this.l.Checked = dt_style_data.Rows[0]["l"].ToString() != "False" ? true : false;
            this.m.Checked = dt_style_data.Rows[0]["m"].ToString() != "False" ? true : false;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
            this.p.SelectedValue = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : "--请选择--";
            this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
            this.r.Text = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
            this.s.Text = dt_style_data.Rows[0]["s"].ToString() != null ? dt_style_data.Rows[0]["s"].ToString() : null;
            this.t.Text = dt_style_data.Rows[0]["t"].ToString() != null ? dt_style_data.Rows[0]["t"].ToString() : null;
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;
            this.z.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;
            this.a1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
            this.b1.Text = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : null;
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
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)StyleControl).BackColor = Color.White;
                    ((TextBox)StyleControl).ReadOnly = false;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.Label")
                {
                    ((Label)StyleControl).BackColor = Color.White;
                    ((Label)StyleControl).Enabled = true;
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

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveData();
            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=9&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, b.SelectedValue.Trim() + "增员指标申请");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                df = null;

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
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                case "System.Web.UI.WebControls.CheckBox":
                    return ((CheckBox)StyleControl).Checked.ToString();
                default:
                    return null;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                Stoke.Components.Staff.DeleteDocument(doc_id);
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
                //Response.Redirect("../Workflow/Work_Record.aspx");
                Response.Redirect(ViewState["retu"].ToString());
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void SavetoZyzbsp()
        {
            string zyzb_tbsj = this.a.Text;
            string zyzb_sqbm = this.b.SelectedValue;
            string zyzb_xqgw = this.c.Text;
            string zyzb_xqrs = this.d.Text;
            string zyzb_xqlx = "";
            if (this.e.Checked)
                zyzb_xqlx = zyzb_xqlx + this.e.Text + ",";
            if (this.f.Checked)
                zyzb_xqlx = zyzb_xqlx + this.f.Text + ",";
            if (this.g.Checked)
                zyzb_xqlx = zyzb_xqlx + this.g.Text;
            string zyzb_xjfl = this.h.Text;
            string zyzb_ddsj = this.i.Text;
            string zyzb_gwzr = this.v.Text;
            string zyzb_zg_hymc_nx = this.j.Text;
            string zyzb_zg_xl_zy = this.k.Text;
            string zyzb_zg_jyxs = "";
            if (this.l.Checked)
                zyzb_zg_jyxs = this.l.Text;
            else if (this.m.Checked)
                zyzb_zg_jyxs = this.m.Text;
            string zyzb_zg_zc_wy_jsj = this.n.Text;
            string zyzb_zg_nl_xb_tz = this.o.Text;
            string zyzb_zg_xwly = this.p.SelectedValue;
            string zyzb_zg_xwly_fpq = this.q.Text;
            string zyzb_zg_zgjy_jy = this.w.Text;
            string zyzb_tbr = this.s.Text;
            string zyzb_zg = this.t.Text;
            string zyzb_yrbmfzr_yj = this.x.Text;
            string zyzb_yrbmfzr = this.u.Text;
            string zyzb_rlzy_yj = this.y.Text;
            string zyzb_rlzy_qm = "";
            string zyzb_zjlsp = this.r.Text;
            string zyzb_zjlqm = "";
            string zyzb_bz = this.z.Text;
            int ret = Stoke.Components.Staff.InsertZyzbsp(zyzb_tbsj,
                zyzb_sqbm,
                zyzb_xqgw,
                zyzb_xqrs,
                zyzb_xqlx,
                zyzb_xjfl,
                zyzb_ddsj,
                zyzb_gwzr,
                zyzb_zg_hymc_nx,
                zyzb_zg_xl_zy,
                zyzb_zg_jyxs,
                zyzb_zg_zc_wy_jsj,
                zyzb_zg_nl_xb_tz,
                zyzb_zg_xwly,
                zyzb_zg_xwly_fpq,
                zyzb_zg_zgjy_jy,
                zyzb_tbr,
                zyzb_zg,
                zyzb_yrbmfzr_yj,
                zyzb_yrbmfzr,
                zyzb_rlzy_yj,
                zyzb_rlzy_qm,
                zyzb_zjlsp,
                zyzb_zjlqm,
                zyzb_bz);
            if (ret != -1)
                Response.Write("<script>alert('存档成功！')</script>");
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
