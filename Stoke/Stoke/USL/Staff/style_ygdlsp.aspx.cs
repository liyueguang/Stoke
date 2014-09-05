using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Stoke.COMMON;

namespace Stoke.USL.Staff
{
    public partial class style_ygdlsp : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id = 1;         ///////////////////////////////////////////////
        private int doc_id = 0;          //////////////////////////////////////////////
        private int flow_id = 6;
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
                BindBm();
                this.Table6.Visible = false;
                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                {
                    Step_Handle_Data();
                    BindEmergency();
                }

                if (step_id == 1)
                    this.EmergencySelector1.Enabled = true;

                if (step_id != 2)
                    //绑定当前流程当前步骤的field
                    Field_Bind(dt_step_field);
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString();
                if (step_id == 0)
                    this.btnSave.Visible = false;
                else if (step_id == 1)
                {
                    this.a.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    this.e.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                    this.btn_ry.Enabled = true;
                }
                else if (step_id == 2)
                {
                    this.btn_ry.Enabled = false;
                    DataTable dt_role_field = _staff.GetControlByZgbh(_zgbh, flow_id, step_id);
                    HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
                    System.Web.UI.Control StyleControl = new Control();
                    if (dt_role_field != null)
                        for (int i = 0; i < dt_role_field.Rows.Count; i++)
                        {
                            string field = dt_role_field.Rows[i][0].ToString();
                            StyleControl = FrmNewDocument.FindControl(field);
                            if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                            {
                                ((TextBox)StyleControl).BackColor = Color.White;
                                ((TextBox)StyleControl).ReadOnly = false;
                            }
                            //hhw20101226,修改员工调离时负责人签字列的自动绑定问题
                            //							if(field=="h"||field=="k"||field=="n"||field=="q"||field=="t"||field=="w"||field=="c1")
                            //								((TextBox)StyleControl).Text = _zgxm;
                        }
                    if (f.Text == "")
                    {
                        f.ReadOnly = false;
                        g.ReadOnly = false;

                        f.BackColor = System.Drawing.Color.Transparent;
                        g.BackColor = System.Drawing.Color.Transparent;

                    }
                    if (h.Text == "")
                    {
                        h.ReadOnly = false;
                        h.BackColor = System.Drawing.Color.Transparent;
                    }

                }
                else if (step_id == -1)
                {
                    this.btn_ry.Enabled = false;
                    SavetoYgdlsp();
                    int ygdlsp_id = doc_id;
                    string ry_zgbh = this.e1.Text;
                    int ret = Stoke.Components.Staff.UpdateYgdlspFlagAndStaffDismissionById(ygdlsp_id, ry_zgbh);//更新ygdlsp标志位和rs_staff标志位，未处理dsoc_ry中信息
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }
            }
        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Stoke.BLL.Utility.GetEmergencyByDocid(doc_id);
        }

        private void BindBm()
        {
            DataTable dt_bm = Stoke.BLL.Department.GetAll();
            this.d.DataSource = dt_bm;
            this.d.DataTextField = "bm_mc";
            this.d.DataValueField = "bm_mc";
            this.d.DataBind();
            this.d.Items.Insert(0, "-请选择-");
            this.d.SelectedIndex = 0;
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            if (dt_style_data.Rows.Count != 0)
            {
                this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
                this.b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
                this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
                this.d.DataSource = dt_style_data;
                this.d.DataValueField = "d";
                this.d.DataTextField = "d";
                this.d.DataBind();
                this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
                this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
                this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
                this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
                this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
                this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
                this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
                this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
                this.m.Text = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : null;
                this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
                this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
                this.p.Text = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : null;
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
                this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
                this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
                this.e1.Text = dt_style_data.Rows[0]["e1"].ToString() != null ? dt_style_data.Rows[0]["e1"].ToString() : null;
                this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;
            }
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
            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=6&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, b.Text.Trim() + "员工调离审批");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                df = null;

            }
            if (step_id == 1)
                Stoke.BLL.Utility.SetEmergencyWithDocid(doc_id, this.EmergencySelector1.SelectedValue);

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

        private void SavetoYgdlsp()
        {
            string ygdl_rq = this.a.Text;
            string ygdl_zgbh = this.e1.Text;
            string ygdl_xm = this.b.Text;
            string ygdl_bm = this.d.SelectedValue.Trim();
            string ygdl_dlsj = this.e.Text;
            string ygdl_bbm_yj = this.f.Text;
            string ygdl_bbm_wj = this.g.Text;
            string ygdl_bbm_jbr = this.h.Text;
            string ygdl_ajhbb_yj = this.i.Text;
            string ygdl_ajhbb_wj = this.j.Text;
            string ygdl_ajhbb_jbr = this.k.Text;
            string ygdl_zhglb_hgk_yj = this.l.Text;
            string ygdl_zhglb_hgk_wj = this.m.Text;
            string ygdl_zhglb_hgk_jbr = this.n.Text;
            string ygdl_zhglb_it_yj = this.o.Text;
            string ygdl_zhglb_it_wj = this.p.Text;
            string ygdl_zhglb_it_jbr = this.q.Text;
            string ygdl_zhglb_lw_yj = this.r.Text;
            string ygdl_zhglb_lw_wj = this.s.Text;
            string ygdl_zhglb_lw_jbr = this.t.Text;
            string ygdl_wzcbb_yj = this.u.Text;
            string ygdl_wzcbb_wj = this.v.Text;
            string ygdl_wzcbb_jbr = this.w.Text;
            string ygdl_qtbm_yj = this.x.Text;
            string ygdl_qtbm_wj = this.y.Text;
            string ygdl_qtbm_jbr = this.z.Text;
            string ygdl_cwb_yj = this.a1.Text;
            string ygdl_cwb_wj = this.b1.Text;
            string ygdl_cwb_jbr = this.c1.Text;
            string ygdl_bz = this.d1.Text;
            int ret = Stoke.Components.Staff.InsertYgdlsp(
                doc_id,
                ygdl_rq,
                ygdl_zgbh,
                ygdl_xm,
                ygdl_bm,
                ygdl_dlsj,
                ygdl_bbm_yj,
                ygdl_bbm_wj,
                ygdl_bbm_jbr,
                ygdl_ajhbb_yj,
                ygdl_ajhbb_wj,
                ygdl_ajhbb_jbr,
                ygdl_zhglb_hgk_yj,
                ygdl_zhglb_hgk_wj,
                ygdl_zhglb_hgk_jbr,
                ygdl_zhglb_it_yj,
                ygdl_zhglb_it_wj,
                ygdl_zhglb_it_jbr,
                ygdl_zhglb_lw_yj,
                ygdl_zhglb_lw_wj,
                ygdl_zhglb_lw_jbr,
                ygdl_wzcbb_yj,
                ygdl_wzcbb_wj,
                ygdl_wzcbb_jbr,
                ygdl_qtbm_yj,
                ygdl_qtbm_wj,
                ygdl_qtbm_jbr,
                ygdl_cwb_yj,
                ygdl_cwb_wj,
                ygdl_cwb_jbr,
                ygdl_bz,
                0);
            //			if(ret != -1)
            //				Response.Write("<script>alert('存档成功！')</script>");
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
                        if ((control as TextBox).Text != "")
                        {
                            (control as TextBox).BackColor = System.Drawing.Color.WhiteSmoke;
                            (control as TextBox).Enabled = false;
                        }
                    }
                    if (control is DropDownList)
                    {
                        (control as DropDownList).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as DropDownList).Enabled = false;
                    }
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
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            this.btn_ry.Click += new System.EventHandler(this.btn_ry_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void btn_ry_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = true;
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
                this.b.Text = ry_xm_list.Split(',')[0].Trim();
                this.e1.Text = ry_zgbh_list.Split(',')[0].Trim();
                this.SlctMember1.Clear();
                this.Table6.Visible = false;
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(e1.Text);
                this.d.Items.Clear();
                this.d.DataSource = dt_xm_bm;
                this.d.DataValueField = "ry_bm";
                this.d.DataTextField = "ry_bm";
                this.d.DataBind();
                Stoke.Components.Staff person = new Stoke.Components.Staff();
                SqlDataReader dr = person.GetStaffInfo(e1.Text);
                if (dr.Read())
                {
                    c.Text = dr["Mobile"].ToString();
                    f1.Text = ((dr["jbdwsj"] == DBNull.Value) || (DateTime.Parse(dr["jbdwsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["jbdwsj"].ToString()).ToString("yyyy-MM-dd");
                }
            }
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = false;
        }
    }
}
