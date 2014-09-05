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
using System.Data.SqlClient;

namespace Stoke.USL.Staff
{
    public partial class style_xjsp : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id = 1;         ///////////////////////////////////////////////
        private int doc_id = 0;          //////////////////////////////////////////////
        private int flow_id = 5;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        
        protected string _zgxm;

        protected int qjsp_id = 0; //////////////////////////////////////////////////

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            //			_zgbh = "0079";
            //			step_id = 1;

            if (step_id == 1 && doc_id == 0)
            {
                if (Request.QueryString["qjsp_id"] != null)
                    qjsp_id = Convert.ToInt32(Request.QueryString["qjsp_id"].ToString());
                else
                {
                    Response.Write("<script language='javascript'>alert('请重新销假');</script>");
                    Response.Redirect("qj_xj_list_new.aspx");
                }
            }

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
                _zgxm = dt_xm_bm.Rows[0][0].ToString();
                if (step_id == 0)
                    this.btnSave.Visible = false;
                else if (step_id == 1)
                {
                    this.a.Text = _zgxm;
                    this.b1.Text = _zgbh;
                    this.b.DataSource = dt_xm_bm;
                    this.b.DataValueField = "ry_bm";
                    this.b.DataTextField = "ry_bm";
                    this.b.DataBind();
                    this.c.DataSource = dt_xm_bm;
                    this.c.DataValueField = "ry_zw";
                    this.c.DataTextField = "ry_zw";
                    this.c.DataBind();
                    this.n.Text = _zgxm;
                    this.o.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                    if (qjsp_id > 0)
                    {
                        this.c1.Text = Convert.ToString(qjsp_id);
                        DataTable dt = Stoke.Components.Staff.SelectQjspById(qjsp_id);
                        if (dt != null)
                            if (dt.Rows.Count > 0)
                            {
                                this.d.SelectedValue = dt.Rows[0][7].ToString();
                                this.e.Text = dt.Rows[0][8].ToString();
                                this.f.Text = dt.Rows[0][9].ToString();
                                this.f1.Text = dt.Rows[0][12].ToString();
                                this.d.Enabled = false;
                                this.e.Enabled = false;
                                this.f.Enabled = false;
                                this.f1.Enabled = false;

                                //8.15dxq
                                this.h.Text = dt.Rows[0][8].ToString();
                                this.i.Text = dt.Rows[0][9].ToString();

                            }
                    }

                }

                else if (step_id == 2)
                {
                    this.v.Text = _zgxm;
                    this.w.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 3)
                {
                    this.d1.Text = _zgxm;
                    this.e1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 4)
                {
                    this.q.Text = _zgxm;
                    this.r.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == 5)
                {
                    this.u.Text = _zgxm;
                    this.a1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == -1)
                {
                    SaveToXjsp();
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
            this.c.DataSource = dt_style_data;
            this.c.DataValueField = "c";
            this.c.DataTextField = "c";
            this.c.DataBind();
            //this.b.SelectedItem.Text = dt_style_data.Rows[0]["b"].ToString()!=null ? dt_style_data.Rows[0]["b"].ToString():null;
            //this.c.SelectedItem.Text = dt_style_data.Rows[0]["c"].ToString()!=null ? dt_style_data.Rows[0]["c"].ToString():null;
            this.d.SelectedValue = dt_style_data.Rows[0]["d"].ToString();
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
            this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
            this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            //			this.k.SelectedValue = dt_style_data.Rows[0]["k"].ToString()!=null ? dt_style_data.Rows[0]["k"].ToString():"1";
            this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
            this.m.Text = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : null;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
            this.p.SelectedValue = dt_style_data.Rows[0]["p"] != DBNull.Value ? dt_style_data.Rows[0]["p"].ToString() : "1";
            this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
            this.r.Text = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
            this.s.Text = dt_style_data.Rows[0]["s"].ToString() != null ? dt_style_data.Rows[0]["s"].ToString() : null;
            this.t.Text = dt_style_data.Rows[0]["t"].ToString() != null ? dt_style_data.Rows[0]["t"].ToString() : null;
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.a1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
            this.b1.Text = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : null;
            this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;

            this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
            this.e1.Text = dt_style_data.Rows[0]["e1"].ToString() != null ? dt_style_data.Rows[0]["e1"].ToString() : null;
            this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;
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
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)StyleControl).Enabled = true;
                    ((DropDownList)StyleControl).BackColor = Color.White;
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //			if(step_id == 1)
            //			{
            //				if(h.Text==""||i.Text ==""||j.Text =="")
            //				{
            //					Response.Write("<script>alert('请填写带*的项！')</script>");
            //					return;
            //				}
            //				SaveData();
            //				string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=5&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
            //				Response.Redirect(_URL);
            //			}
            //			else
            //			{
            //				SaveData();
            //				string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=5&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
            //				Response.Redirect(_URL);
            //			}



            //8.15dxq
            if (step_id == 1)
            {
                if (h.Text == "" || i.Text == "" || j.Text == "")
                {
                    Response.Write("<script>alert('请填写带*的项！')</script>");
                    return;
                }
                if ((this.e.Text != this.h.Text || this.f.Text != this.i.Text) && (m.Text.Equals("")))
                {
                    Response.Write("<script>alert('请填写超假原因！')</script>");
                    return;
                }

                //9.7dxq
                //将qjsp_id和step_id存入表中，如果销假流程没结束，则重复销假会有提示
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string str = "insert into rs_flow_xj_judge values('" + qjsp_id + "','" + step_id + "')";
                SqlCommand myCommand = new SqlCommand(str, conn);
                myCommand.ExecuteNonQuery();
                conn.Close();

                SaveData();
                //tonzoc--20101106
                conn.Open();
                str = "insert into qj_xj_map values('" + qjsp_id + "','" + doc_id + "')";
                SqlCommand myCommand1 = new SqlCommand(str, conn);
                myCommand1.ExecuteNonQuery();
                conn.Close();

                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=5&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
            }

            else
            {

                SaveData();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=5&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
            }

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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, a.Text.ToString().Trim() + "销假申请");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                df = null;
                //				if(step_id==3)
                //					SaveToXjsp();

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
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text;
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                default:
                    return "";
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

        public void SaveToXjsp()
        {
            string xjsp_zgbh = this.b1.Text;
            string xjsp_xm = this.a.Text;
            string xjsp_bm = this.b.SelectedValue;
            string xjsp_zw = this.c.SelectedValue;
            string xjsp_qjlb = this.d.SelectedValue;
            string xjsp_ykssj = this.e.Text;
            string xjsp_yjssj = this.f.Text;
            string xjsp_sjkssj = this.h.Text;
            string xjsp_sjjjsj = this.i.Text;
            string xjsp_sjts = this.g.Text;
            string xjsp_sbsj = this.j.Text;
            string xjsp_sfxj = "1";
            string xjsp_ccts = this.l.Text;
            string xjsp_ccyy = this.m.Text;
            string xjsp_rq = this.o.Text;
            string xjsp_sffhgd = this.p.SelectedValue;
            string xjsp_zhglbjbr = this.q.Text;
            string xjsp_zhglbrq = this.r.Text;
            string xjsp_cjqyj = this.s.Text;
            string xjsp_qt = this.t.Text;
            string xjsp_fzr = this.u.Text;
            string xjsp_fzrrq = this.a1.Text;

            string xjsp_bmfzr = this.d1.Text;
            string xjsp_bmfzrrq = this.e1.Text;
            Response.Write("<script language='javascript'>alert('" + this.c1.Text + "');</script>");
            qjsp_id = Convert.ToInt32(this.c1.Text);
            int ret = Stoke.Components.Staff.InsertXjsp(xjsp_zgbh,
                xjsp_xm,
                xjsp_bm,
                xjsp_zw,
                xjsp_qjlb,
                xjsp_ykssj,
                xjsp_yjssj,
                xjsp_sjkssj,
                xjsp_sjjjsj,
                xjsp_sjts,
                xjsp_sbsj,
                xjsp_sfxj,
                xjsp_ccts,
                xjsp_ccyy,
                xjsp_rq,
                xjsp_sffhgd,
                xjsp_zhglbjbr,
                xjsp_zhglbrq,
                xjsp_cjqyj,
                xjsp_qt,
                xjsp_fzr,
                xjsp_fzrrq,
                qjsp_id,
                xjsp_bmfzr,
                xjsp_bmfzrrq);
            //			if(ret != -1)
            //				Response.Write("<script>alert('存档成功！')</script>");
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
