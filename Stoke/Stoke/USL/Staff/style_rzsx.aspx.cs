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

namespace Stoke.USL.Staff
{
    public partial class style_rzsx : System.Web.UI.Page
    {
        protected string _zgxm; //////////////////////////////////////////////////
        DataTable dt_step_field;
        private int step_id = 1;         ///////////////////////////////////////////////
        private int doc_id = 0;          //////////////////////////////////////////////
        private int flow_id = 8;
        private int FieldNum = 0;
        private bool bEditMode = false;

        protected string _zgbh;

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
                this.Table6.Visible = false;
                tr_del.Visible = false;

                ViewState["retu"] = Request.UrlReferrer.ToString(); //20090622
                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                {
                    Step_Handle_Data();
                    BindEmergency();
                }

                if (step_id == 1)
                {
                    this.EmergencySelector1.Enabled = true;
                }

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
                    this.d.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                    else
                    {
                        BindBm();
                        BindZw();
                    }
                }
                else if (step_id == 2)
                {
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
                            //							if(field=="h"||field=="i"||field=="j"||field=="k"||field=="l"||field=="m"||field=="n"||field=="o"||field=="p"||field=="r")
                            //								((TextBox)StyleControl).Text = _zgxm;
                        }
                    if (q.Text == "")
                    {
                        q.ReadOnly = false;
                        z1.ReadOnly = false;
                        r.ReadOnly = false;
                        q.BackColor = System.Drawing.Color.Transparent;
                        z1.BackColor = System.Drawing.Color.Transparent;
                        r.BackColor = System.Drawing.Color.Transparent;
                    }
                }
                else if (step_id == -1)
                {
                    SavetoRzdj();
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
            this.c.DataSource = dt_bm;
            this.c.DataTextField = "bm_mc";
            this.c.DataValueField = "bm_mc";
            this.c.DataBind();
            this.c.Items.Insert(0, "-请选择-");
            this.c.SelectedIndex = 0;
        }

        private void BindZw()
        {
            DataTable dt_zw = Stoke.BLL.Place.GetAll();
            this.f.DataSource = dt_zw;
            this.f.DataTextField = "zw_mc";
            this.f.DataValueField = "zw_mc";
            this.f.DataBind();
            this.f.Items.Insert(0, "-请选择-");
            this.f.SelectedIndex = 0;
        }


        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
            this.b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
            this.c.DataSource = dt_style_data;
            this.c.DataValueField = "c";
            this.c.DataTextField = "c";
            this.c.DataBind();
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
            this.f.DataSource = dt_style_data;
            this.f.DataValueField = "f";
            this.f.DataTextField = "f";
            this.f.DataBind();
            this.g.SelectedValue = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : "0";
            this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
            this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
            this.m.Text = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : null;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            //			this.o.Text = dt_style_data.Rows[0]["o"].ToString()!=null ? dt_style_data.Rows[0]["o"].ToString():null;
            this.p.Text = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : null;
            this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
            this.r.Text = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
            this.s.Text = dt_style_data.Rows[0]["s"].ToString() != null ? dt_style_data.Rows[0]["s"].ToString() : null;
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;
            this.z.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;
            this.v1.Text = dt_style_data.Rows[0]["v1"].ToString() != null ? dt_style_data.Rows[0]["v1"].ToString() : null;
            this.w1.Text = dt_style_data.Rows[0]["w1"].ToString() != null ? dt_style_data.Rows[0]["w1"].ToString() : null;
            //			this.x1.Text = dt_style_data.Rows[0]["x1"].ToString()!=null ? dt_style_data.Rows[0]["x1"].ToString():null;
            this.y1.Text = dt_style_data.Rows[0]["y1"].ToString() != null ? dt_style_data.Rows[0]["y1"].ToString() : null;
            this.z1.Text = dt_style_data.Rows[0]["z1"].ToString() != null ? dt_style_data.Rows[0]["z1"].ToString() : null;
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
            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=8&step_id=" + step_id.ToString().Trim() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, b.Text.ToString() + "入职手续");
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

        private void SavetoRzdj()
        {
            string rzdj_rq = this.a.Text;
            string rzdj_xm = this.b.Text;
            string rzdj_bm = this.c.SelectedValue;
            string rzdj_rzsj = this.d.Text;
            string rzdj_zgbh = this.e.Text;
            string rzdj_gw = this.f.SelectedValue;
            string rzdj_pyxs = this.g.SelectedValue;
            string rzdj_ajhbb_ajk = this.v.Text;
            string rzdj_ajhbb_ajk_fzr = this.h.Text;
            string rzdj_ajhbb_lbhj = this.w.Text;
            string rzdj_ajhbb_lbhj_fzr = this.i.Text;
            string rzdj_zhglb_tjqk = this.x.Text;
            string rzdj_zhglb_tjqk_fzr = this.j.Text;
            string rzdj_zhglb_hgk = this.y.Text;
            string rzdj_zhglb_hgk_fzr = this.k.Text;
            string rzdj_zhglb_kq = this.z.Text;
            string rzdj_zhglb_kq_fzr = this.l.Text;
            string rzdj_zhglb_bg = this.v1.Text;
            string rzdj_zhglb_bg_fzr = this.m.Text;
            string rzdj_zhglb_sjc = this.w1.Text;
            string rzdj_zhglb_sjc_fzr = this.n.Text;
            string rzdj_zhglb_bgdn = "";
            string rzdj_zhglb_bgdn_fzr = "";
            //			string rzdj_zhglb_bgdn  =this.x1.Text;
            //			string rzdj_zhglb_bgdn_fzr  =this.o.Text;
            string rzdj_cwb_gzk = this.y1.Text;
            string rzdj_cwb_gzk_fzr = this.p.Text;
            string rzdj_qtbm_clsx = this.z1.Text;
            string rzdj_qtbm_clsx_jtmx = this.q.Text;
            string rzdj_qtbm_clsx_fzr = this.r.Text;
            string rzdj_bz = this.s.Text;
            int ret = Stoke.Components.Staff.InsertRzdj(rzdj_rq,
                                                        rzdj_xm,
                                                        rzdj_bm,
                                                        rzdj_rzsj,
                                                        rzdj_zgbh,
                                                        rzdj_gw,
                                                        rzdj_pyxs,
                                                        rzdj_ajhbb_ajk,
                                                        rzdj_ajhbb_ajk_fzr,
                                                        rzdj_ajhbb_lbhj,
                                                        rzdj_ajhbb_lbhj_fzr,
                                                        rzdj_zhglb_tjqk,
                                                        rzdj_zhglb_tjqk_fzr,
                                                        rzdj_zhglb_hgk,
                                                        rzdj_zhglb_hgk_fzr,
                                                        rzdj_zhglb_kq,
                                                        rzdj_zhglb_kq_fzr,
                                                        rzdj_zhglb_bg,
                                                        rzdj_zhglb_bg_fzr,
                                                        rzdj_zhglb_sjc,
                                                        rzdj_zhglb_sjc_fzr,
                                                        rzdj_zhglb_bgdn,
                                                        rzdj_zhglb_bgdn_fzr,
                                                        rzdj_cwb_gzk,
                                                        rzdj_cwb_gzk_fzr,
                                                        rzdj_qtbm_clsx,
                                                        rzdj_qtbm_clsx_jtmx,
                                                        rzdj_qtbm_clsx_fzr,
                                                        rzdj_bz);
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
                this.e.Text = ry_zgbh_list.Split(',')[0].Trim();
                this.SlctMember1.Clear();
                this.Table6.Visible = false;
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(this.e.Text);
                this.c.Items.Clear();
                this.c.DataSource = dt_xm_bm;
                this.c.DataValueField = "ry_bm";
                this.c.DataTextField = "ry_bm";
                this.c.DataBind();
                this.f.Items.Clear();
                this.f.DataSource = dt_xm_bm;
                this.f.DataValueField = "ry_zw";
                this.f.DataTextField = "ry_zw";
                this.f.DataBind();
                Stoke.Components.Staff person = new Stoke.Components.Staff();
                SqlDataReader dr = person.GetStaffInfo(this.e.Text);
                if (dr.Read())
                {
                    g.SelectedValue = dr["pylx"].ToString();
                    //					f1.Text = ((dr["jbdwsj"]==DBNull.Value) || (DateTime.Parse(dr["jbdwsj"].ToString()).Date==DateTime.Parse("1900-1-1").Date))?"":DateTime.Parse(dr["jbdwsj"].ToString()).ToString("yyyy-MM-dd");
                }
                d.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = false;
        }
    }
}
