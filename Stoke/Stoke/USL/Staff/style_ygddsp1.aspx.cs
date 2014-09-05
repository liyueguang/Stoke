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
    public partial class style_ygddsp1 : System.Web.UI.Page
    {
        protected static int DisplayType = 0;
        DataTable dt_step_field;
        private int step_id = 1;         ///////////////////////////////////////////////
        private int doc_id = 0;          //////////////////////////////////////////////
        private int flow_id = 7;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;

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
                {
                    Step_Handle_Data();
                    BindEmergency();
                }

                this.Table6.Visible = false;

                if (step_id == 1)
                    this.EmergencySelector1.Enabled = true;

                //				this.tr_gz.Visible = false;//隐藏工资调动

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
                    if (doc_id > 0)
                    {
                        this.btnCancel.Text = "删除";
                    }
                    this.btn_ry.Enabled = true;

                    DataTable dt_bm = Stoke.BLL.Department.GetAll();
                    this.i.DataSource = dt_bm;
                    this.i.DataTextField = "bm_mc";
                    this.i.DataValueField = "bm_mc";
                    this.i.DataBind();
                    this.i.Items.Insert(0, "-请选择-");
                    this.i.SelectedIndex = 0;
                    DataTable dt_zw = Stoke.BLL.Place.GetAll();
                    this.m.DataSource = dt_zw;
                    this.m.DataTextField = "zw_mc";
                    this.m.DataValueField = "zw_mc";
                    this.m.DataBind();
                    this.m.Items.Insert(0, "-请选择-");
                    this.m.SelectedIndex = 0;
                }

                else if (step_id == 2)
                {
                    this.d1.Text = _zgxm;
                    this.e1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 4)
                {
                    this.f1.Text = _zgxm;
                    this.g1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 6)
                {
                    this.w1.Text = _zgxm;
                    this.y1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 8)
                {
                    this.j1.Text = _zgxm;
                    this.k1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 10)
                {
                    this.l1.Text = _zgxm;
                    this.m1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 12)
                {
                    this.z1.Text = _zgxm;
                    this.a2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 13)
                {
                    this.p1.Text = _zgxm;
                    this.q1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    //					this.tr_gz.Visible = true;
                }

                else if (step_id == 14)
                {
                    this.r1.Text = _zgxm;
                    this.s1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    //					this.tr_gz.Visible = true;
                }
                else if (step_id > 14)
                {
                    this.btnSave.Visible = false;
                    this.btnCancel.Visible = false;
                }
            }
        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Stoke.BLL.Utility.GetEmergencyByDocid(doc_id);
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
            this.btn_ry.Click += new System.EventHandler(this.btn_ry_Click);
            this.g.CheckedChanged += new System.EventHandler(this.g_CheckedChanged);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            this.k.CheckedChanged += new System.EventHandler(this.k_CheckedChanged);
            this.o.CheckedChanged += new System.EventHandler(this.o_CheckedChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Step_Handle_Data()
        {
            //if(step_id != 1)
            {
                DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
                this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
                this.b.DataSource = dt_style_data;
                this.b.DataValueField = "b";
                this.b.DataTextField = "b";
                this.b.DataBind();
                this.c.DataSource = dt_style_data;
                this.c.DataValueField = "c";
                this.c.DataTextField = "c";
                this.c.DataBind();
                this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
                this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
                this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
                this.g.Checked = dt_style_data.Rows[0]["g"].ToString() != "False" ? true : false;
                this.h.DataSource = dt_style_data;
                this.h.DataValueField = "h";
                this.h.DataTextField = "h";
                this.h.DataBind();
                this.i.DataSource = dt_style_data;
                this.i.DataValueField = "i";
                this.i.DataTextField = "i";
                this.i.DataBind();
                this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
                this.k.Checked = dt_style_data.Rows[0]["k"].ToString() != "False" ? true : false;
                this.l.DataSource = dt_style_data;
                this.l.DataValueField = "l";
                this.l.DataTextField = "l";
                this.l.DataBind();
                this.m.DataSource = dt_style_data;
                this.m.DataValueField = "m";
                this.m.DataTextField = "m";
                this.m.DataBind();
                this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
                this.o.Checked = dt_style_data.Rows[0]["o"].ToString() != "False" ? true : false;
                this.p.Text = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : null;
                this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
                this.r.Text = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
                this.s.Checked = dt_style_data.Rows[0]["s"].ToString() != "False" ? true : false;
                this.t.Text = dt_style_data.Rows[0]["t"].ToString() != null ? dt_style_data.Rows[0]["t"].ToString() : null;
                this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
                this.a1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
                this.b1.Text = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : null;
                this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
                this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
                this.e1.Text = dt_style_data.Rows[0]["e1"].ToString() != null ? dt_style_data.Rows[0]["e1"].ToString() : null;
                this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;
                this.g1.Text = dt_style_data.Rows[0]["g1"].ToString() != null ? dt_style_data.Rows[0]["g1"].ToString() : null;
                this.h1.Text = dt_style_data.Rows[0]["h1"].ToString() != null ? dt_style_data.Rows[0]["h1"].ToString() : null;
                this.i1.Text = dt_style_data.Rows[0]["i1"].ToString() != null ? dt_style_data.Rows[0]["i1"].ToString() : null;
                this.j1.Text = dt_style_data.Rows[0]["j1"].ToString() != null ? dt_style_data.Rows[0]["j1"].ToString() : null;
                this.k1.Text = dt_style_data.Rows[0]["k1"].ToString() != null ? dt_style_data.Rows[0]["k1"].ToString() : null;
                this.l1.Text = dt_style_data.Rows[0]["l1"].ToString() != null ? dt_style_data.Rows[0]["l1"].ToString() : null;
                this.m1.Text = dt_style_data.Rows[0]["m1"].ToString() != null ? dt_style_data.Rows[0]["m1"].ToString() : null;
                this.n1.Text = dt_style_data.Rows[0]["n1"].ToString() != null ? dt_style_data.Rows[0]["n1"].ToString() : null;
                this.o1.Text = dt_style_data.Rows[0]["o1"].ToString() != null ? dt_style_data.Rows[0]["o1"].ToString() : null;
                this.p1.Text = dt_style_data.Rows[0]["p1"].ToString() != null ? dt_style_data.Rows[0]["p1"].ToString() : null;
                this.q1.Text = dt_style_data.Rows[0]["q1"].ToString() != null ? dt_style_data.Rows[0]["q1"].ToString() : null;
                this.r1.Text = dt_style_data.Rows[0]["r1"].ToString() != null ? dt_style_data.Rows[0]["r1"].ToString() : null;
                this.s1.Text = dt_style_data.Rows[0]["s1"].ToString() != null ? dt_style_data.Rows[0]["s1"].ToString() : null;
                this.t1.Text = dt_style_data.Rows[0]["t1"].ToString() != null ? dt_style_data.Rows[0]["t1"].ToString() : null;
                this.w1.Text = dt_style_data.Rows[0]["w1"].ToString() != null ? dt_style_data.Rows[0]["w1"].ToString() : null;
                this.y1.Text = dt_style_data.Rows[0]["y1"].ToString() != null ? dt_style_data.Rows[0]["y1"].ToString() : null;
                this.u1.Text = dt_style_data.Rows[0]["u1"].ToString() != null ? dt_style_data.Rows[0]["u1"].ToString() : null;
                this.z1.Text = dt_style_data.Rows[0]["z1"].ToString() != null ? dt_style_data.Rows[0]["z1"].ToString() : null;
                this.a2.Text = dt_style_data.Rows[0]["a2"].ToString() != null ? dt_style_data.Rows[0]["a2"].ToString() : null;
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
            if (step_id == 1)
            {
                if (g.Checked == true)
                {
                    //					if(h.SelectedIndex==0||i.SelectedIndex==0)
                    if (h.SelectedValue == "-请选择-" || i.SelectedIndex == 0)
                    {
                        Response.Write("<script>alert('请填写调动原部门和新部门！')</script>");
                        return;
                    }
                    //					if((l.SelectedIndex==0&&m.SelectedIndex!=0)||(l.SelectedIndex!=0&&m.SelectedIndex==0))
                    if ((l.SelectedValue == "-请选择-" && m.SelectedIndex != 0) || (l.SelectedValue != "-请选择-" && m.SelectedIndex == 0))
                    {
                        Response.Write("<script>alert('请填写调动原岗位和新岗位！')</script>");
                        return;
                    }
                }
                else if (k.Checked == true)
                {
                    //					if(l.SelectedIndex==0||m.SelectedIndex==0)
                    if ((l.SelectedValue == "-请选择-" && m.SelectedIndex != 0))
                    {
                        Response.Write("<script>alert('请填写调动原岗位和新岗位！')</script>");
                        return;
                    }
                }

                if (g.Checked == false && k.Checked == false && o.Checked == false)
                {
                    Response.Write("<script>alert('请选择调动类型！')</script>");
                    return;
                }
                else
                    SaveData();
            }
            else if (step_id == 14)
            {
                SavetoYgddsp();
                int ygddsp_id = doc_id;
                string zgbh = d.Text;
                string ybm = b.SelectedValue.Trim();
                string xbm = "";
                string yzw = c.SelectedValue.Trim();
                string xzw = "";
                if (g.Checked == true)
                {
                    ybm = h.SelectedValue.Trim();
                    xbm = i.SelectedValue.Trim();
                    if (l.SelectedValue != "-请选择-")
                        yzw = l.SelectedValue.Trim();
                    if (m.SelectedValue != "-请选择-")
                        xzw = m.SelectedValue.Trim();
                }
                else if (k.Checked == true)
                {
                    yzw = l.SelectedValue.Trim();
                    xzw = m.SelectedValue.Trim();
                }
                SaveData();
                //dxq9.16 部门到部门，更新。部门到项目组，插入。项目组到项目组，更新。项目组到部门，删除项目组
                int xmz_y = Get_bm_xmz(ybm);
                int xmz_x = Get_bm_xmz(xbm);
                string xm = this.a.Text.ToString();
                int ret = Stoke.Components.Staff.UpdateYgddspFlagById(ygddsp_id, zgbh, ybm, xbm, yzw, xzw, xmz_y, xmz_x, xm);//更新ygddsp标志位和dsoc_ry部门、职位



            }
            else
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, a.Text.ToString().Trim() + "员工调动审批");
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
            {
                Stoke.BLL.Utility.SetEmergencyWithDocid(doc_id, this.EmergencySelector1.SelectedValue);
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
            if (StyleControl != null)
            {
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
            else
                return "";
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
            if (doc_id > 0 && step_id == 1)
            {
                Stoke.Components.Staff.DeleteDocument(doc_id);
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
                Response.Redirect("../Workflow/Work_Record.aspx");
            //				Response.Redirect(ViewState["retu"].ToString());
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void zm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_ygddsp1.aspx?DisplayType=0&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void bm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_ygddsp2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void SavetoYgddsp()
        {
            int ygddsp_id = doc_id;
            string ygddsp_xm = this.a.Text;
            string ygddsp_xbm = this.b.SelectedValue;
            string ygddsp_xgw = this.c.SelectedValue;
            string ygddsp_zgbh = this.d.Text;
            string ygddsp_cjggsj = this.e.Text;
            string ygddsp_xgwsj = this.f.Text;
            string ygddsp_ddlx = "";
            string ygddsp_yddxq = "";
            string ygddsp_dddxq = "";
            string ygddsp_ddbz = "";
            string ygddsp_yddxq1 = "";
            string ygddsp_dddxq1 = "";
            string ygddsp_ddbz1 = "";
            string ygddsp_yddxq2 = "";
            string ygddsp_dddxq2 = "";
            string ygddsp_ddbz2 = "";
            if (this.g.Checked)
            {
                ygddsp_ddlx = this.g.Text;
                ygddsp_yddxq = this.h.SelectedValue;
                ygddsp_dddxq = this.i.SelectedValue;
                ygddsp_ddbz = this.j.Text;
                ygddsp_yddxq1 = this.l.SelectedValue;
                ygddsp_dddxq1 = this.m.SelectedValue;
                ygddsp_ddbz1 = this.n.Text;
                ygddsp_yddxq2 = this.p.Text;
                ygddsp_dddxq2 = this.q.Text;
                ygddsp_ddbz2 = this.r.Text;
            }
            else if (this.k.Checked)
            {
                ygddsp_ddlx = this.k.Text;
                ygddsp_yddxq1 = this.l.SelectedValue;
                ygddsp_dddxq1 = this.m.SelectedValue;
                ygddsp_ddbz = this.n.Text;
                ygddsp_yddxq2 = this.p.Text;
                ygddsp_dddxq2 = this.q.Text;
                ygddsp_ddbz2 = this.r.Text;
            }
            else if (this.o.Checked)
            {
                ygddsp_ddlx = this.o.Text;
                ygddsp_yddxq2 = this.p.Text;
                ygddsp_dddxq2 = this.q.Text;
                ygddsp_ddbz = this.r.Text;
            }

            string ygddsp_kssj = this.t.Text;
            string ygddsp_jssj = this.u.Text;
            string ygddsp_ddyy = this.a1.Text;
            string ygddsp_xbmyj = this.b1.Text;
            string ygddsp_xbmqm = this.c1.Text;
            string ygddsp_xbmrq = this.d1.Text;
            string ygddsp_xbmldyj = this.e1.Text;
            string ygddsp_xbmldqm = this.f1.Text;
            string ygddsp_xbmldrq = this.g1.Text;
            string ygddsp_dwbmyj = this.h1.Text;
            string ygddsp_dwbmqm = this.i1.Text;
            string ygddsp_dwbmrq = this.j1.Text;
            string ygddsp_dwbmldyj = this.k1.Text;
            string ygddsp_dwbmldqm = this.l1.Text;
            string ygddsp_dwbmldrq = this.m1.Text;
            string ygddsp_zhglbyj = this.n1.Text;
            string ygddsp_zhglbqm = this.o1.Text;
            string ygddsp_zhglbrq = this.p1.Text;
            string ygddsp_gsldyj = this.q1.Text;
            string ygddsp_gsldqm = this.r1.Text;
            string ygddsp_gsldrq = this.s1.Text;

            //8.27dxq  判断是否是部门之间的调度，而非项目组。

            int ygddsp_flag = Judge(ygddsp_yddxq, ygddsp_dddxq);


            int ret = Stoke.Components.Staff.InsertYgddsp(ygddsp_id,
                ygddsp_xm,
                ygddsp_xbm,
                ygddsp_xgw,
                ygddsp_zgbh,
                ygddsp_cjggsj,
                ygddsp_xgwsj,
                ygddsp_ddlx,
                ygddsp_yddxq,
                ygddsp_dddxq,
                ygddsp_ddbz,
                ygddsp_yddxq1,
                ygddsp_dddxq1,
                ygddsp_ddbz1,
                ygddsp_yddxq2,
                ygddsp_dddxq2,
                ygddsp_ddbz2,
                ygddsp_kssj,
                ygddsp_jssj,
                ygddsp_ddyy,
                ygddsp_xbmyj,
                ygddsp_xbmqm,
                ygddsp_xbmrq,
                ygddsp_xbmldyj,
                ygddsp_xbmldqm,
                ygddsp_xbmldrq,
                ygddsp_dwbmyj,
                ygddsp_dwbmqm,
                ygddsp_dwbmrq,
                ygddsp_dwbmldyj,
                ygddsp_dwbmldqm,
                ygddsp_dwbmldrq,
                ygddsp_zhglbyj,
                ygddsp_zhglbqm,
                ygddsp_zhglbrq,
                ygddsp_gsldyj,
                ygddsp_gsldqm,
                ygddsp_gsldrq,
                ygddsp_flag
                );
            //			string ygddsp_ybmjj ;
            //			string ygddsp_ybmsjr ;
            //			string ygddsp_dbmjj ;
            //			string ygddsp_dbmsjr ;
            //			string ygddsp_sfzgpx ;
            //			string ygddsp_yy ;
            //			string ygddsp_bmfzr ;
            //			string ygddsp_bmfzr_rq ;
            //			string ygddsp_sfappx ;
            //			string ygddsp_pxnr ;
            //			string ygddsp_pxfs ;
            //			string ygddsp_pxkssj ;
            //			string ygddsp_pxjssj ;
            //			string ygddsp_zhglbpxfzr ;
            //			string ygddsp_zhglbpxfzrrq ;
            //			string ygddsp_gsldpxyj ;
            //			string ygddsp_gsldpxqz ;
            //			string ygddsp_gsldpxqzrq ;
        }

        private int Judge(string yddxq, string dddxq)
        {

            int bm_xmz1 = Get_bm_xmz(yddxq);
            int bm_xmz2 = Get_bm_xmz(dddxq);
            if (bm_xmz1 == 0 && bm_xmz2 == 0)//部门之间的调动
                return 1;
            else return 0;


        }
        private int Get_bm_xmz(string bm)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "select bm_xmz from dsoc_bm where bm_mc='" + bm + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            int bm_xmz = 2;//如果为空，则为2.部门0，项目组1
            if (dt.Rows.Count != 0)
                bm_xmz = int.Parse(dt.Rows[0][0].ToString());
            return bm_xmz;
        }

        private void g_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.g.Checked == true)
            {
                this.k.Checked = false;
                this.o.Checked = false;
                this.k.Enabled = false;
                this.o.Enabled = false;
            }
            else
            {
                this.k.Enabled = true;
                this.o.Enabled = true;
            }
        }

        private void k_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.k.Checked == true)
            {
                this.g.Checked = false;
                this.o.Checked = false;
                this.g.Enabled = false;
                this.o.Enabled = false;
                //				this.h.Enabled = false;
                //				this.i.Enabled = false;
                //				this.j.Enabled = false;
            }
            else
            {
                this.g.Enabled = true;
                this.o.Enabled = true;
                //				this.h.Enabled = true;
                //				this.i.Enabled = true;
                //				this.j.Enabled = true;
            }
        }

        private void o_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.o.Checked == true)
            {
                this.g.Checked = false;
                this.k.Checked = false;
                this.g.Enabled = false;
                this.k.Enabled = false;
                this.h.Enabled = false;
                this.i.Enabled = false;
                this.j.Enabled = false;
                this.l.Enabled = false;
                this.m.Enabled = false;
                this.n.Enabled = false;
            }
            else
            {
                this.g.Enabled = true;
                this.k.Enabled = true;
                this.h.Enabled = true;
                this.i.Enabled = true;
                this.j.Enabled = true;
                this.l.Enabled = true;
                this.m.Enabled = true;
                this.n.Enabled = true;
            }
        }

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
                this.a.Text = ry_xm_list.Split(',')[0].Trim();
                this.d.Text = ry_zgbh_list.Split(',')[0].Trim();
                this.SlctMember1.Clear();
                this.Table6.Visible = false;
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(d.Text);
                this.b.Items.Clear();
                this.b.DataSource = dt_xm_bm;
                this.b.DataValueField = "ry_bm";
                this.b.DataTextField = "ry_bm";
                this.b.DataBind();
                this.c.DataSource = dt_xm_bm;
                this.c.DataValueField = "ry_zw";
                this.c.DataTextField = "ry_zw";
                this.c.DataBind();
                this.h.DataSource = dt_xm_bm;
                this.h.DataTextField = "ry_bm";
                this.h.DataValueField = "ry_bm";
                this.h.DataBind();
                this.h.Items.Insert(0, "-请选择-");
                this.h.SelectedIndex = 0;
                this.l.DataSource = dt_xm_bm;
                this.l.DataTextField = "ry_zw";
                this.l.DataValueField = "ry_zw";
                this.l.DataBind();
                this.l.Items.Insert(0, "-请选择-");
                this.l.SelectedIndex = 0;
                Stoke.Components.Staff person = new Stoke.Components.Staff();
                SqlDataReader dr = person.GetStaffInfo(d.Text);
                if (dr.Read())
                {
                    this.e.Text = ((dr["cjgzsj"] == DBNull.Value) || (DateTime.Parse(dr["cjgzsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["cjgzsj"].ToString()).ToString("yyyy-MM-dd");
                    //					f1.Text = ((dr["jbdwsj"]==DBNull.Value) || (DateTime.Parse(dr["jbdwsj"].ToString()).Date==DateTime.Parse("1900-1-1").Date))?"":DateTime.Parse(dr["jbdwsj"].ToString()).ToString("yyyy-MM-dd");
                }
            }
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = false;
        }
    }
}
