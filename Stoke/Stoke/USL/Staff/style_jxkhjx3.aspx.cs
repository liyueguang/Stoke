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
    public partial class style_jxkhjx3 : System.Web.UI.Page
    {

        DataTable dt_step_field;
        private int step_id = 2;
        private int doc_id = 0;
        private int flow_id = 38;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;
        private float sum1;
        private float sum2;
        protected int DisplayType = 0;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
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

            //根据doc_id判断执行表单数据的插入操作或更新操作
            if (doc_id > 0)
                bEditMode = true;
            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;



            if (step_id == 2)
            {
                //				this.we1.Enabled=false;
                this.we2.Enabled = false;
                //				this.we3.Enabled=false;
                this.we4.Enabled = false;
                //				this.we5.Enabled=false;
                this.we6.Enabled = false;
                //				this.we7.Enabled=false;
                this.we8.Enabled = false;
                //				this.we9.Enabled=false;
                this.we10.Enabled = false;
                //				this.we11.Enabled=false;
                this.we12.Enabled = false;
                //				this.we13.Enabled=false;
                this.we14.Enabled = false;
                //				this.we15.Enabled=false;
                this.we16.Enabled = false;
                //				this.we17.Enabled=false;
                this.we18.Enabled = false;
                this.te1.Enabled = false;
                this.te2.Enabled = false;
                this.te3.Enabled = false;
                this.te4.Enabled = false;
                this.te5.Enabled = false;
                this.te6.Enabled = false;
                this.te7.Enabled = false;
                this.te8.Enabled = false;
                this.te9.Enabled = false;
            }
            if (!Page.IsPostBack)
            {
                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                    Step_Handle_Data();


                if (step_id == 2 || step_id == 3)//防止step_id=4时进入此页面也绑定
                {
                    //绑定当前流程当前步骤的field
                    Field_Bind(dt_step_field);
                    //使得总分只读
                    this.a1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.a1.ReadOnly = true;
                    this.b1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.b1.ReadOnly = true;
                }

                //取得登陆人姓名（指导老师或部长）
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString();

                if (step_id == 2)
                {
                    this.f.Text = _zgxm;
                    this.btnSave.Visible = true;
                }

                if (step_id == 3)
                {
                    this.c1.Text = _zgxm;
                    this.btnSave.Visible = true;
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
            this.zp.Click += new System.EventHandler(this.zp_Click);
            this.zq.Click += new System.EventHandler(this.zq_Click);
            this.zdp.Click += new System.EventHandler(this.zdp_Click);
            this.zs.Click += new System.EventHandler(this.zs_Click);
            this.g.SelectedIndexChanged += new System.EventHandler(this.g_SelectedIndexChanged);
            this.p.TextChanged += new System.EventHandler(this.Textbox13_TextChanged);
            this.t.TextChanged += new System.EventHandler(this.Textbox9_TextChanged);
            this.b1.TextChanged += new System.EventHandler(this.Textbox1_TextChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion



        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);

            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;

            //			部门
            this.g.DataSource = dt_style_data;
            this.g.DataValueField = "g";
            this.g.DataTextField = "g";
            this.g.DataBind();
            //			职位 
            this.h.DataSource = dt_style_data;
            this.h.DataValueField = "h";
            this.h.DataTextField = "h";
            this.h.DataBind();
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
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
            this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
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
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)StyleControl).Enabled = true;
                    ((DropDownList)StyleControl).BackColor = Color.White;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.Label")
                {
                    ((Label)StyleControl).Enabled = true;
                    ((Label)StyleControl).BackColor = Color.White;
                }
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (step_id == 0)
                Response.Redirect("../Workflow/Work_Record.aspx");
            //				Response.Redirect(ViewState["retu"].ToString());
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveData();
            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=38&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, e.Text.ToString().Trim() + "见习、试用期绩效考核评估");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                df = null;
                //				if(step_id==6)
                //					SaveToQjsp();

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
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text.ToString();
                default:
                    return "";
            }
        }

        //		private void y_TextChanged(object sender, System.EventArgs e)
        //		{
        //			int a=(Int32.Parse(this.i.Text.ToString())+Int32.Parse(this.k.Text.ToString())+Int32.Parse(this.m.Text.ToString())+
        //				Int32.Parse(this.o.Text.ToString())+Int32.Parse(this.q.Text.ToString())+Int32.Parse(this.s.Text.ToString())+
        //				Int32.Parse(this.u.Text.ToString())+Int32.Parse(this.w.Text.ToString())+Int32.Parse(this.y.Text.ToString()));
        //			this.a1.Text=a.ToString();
        //		}
        //
        //		private void b1_TextChanged(object sender, System.EventArgs e)
        //		{
        //			int a=(Int32.Parse(this.j.Text.ToString())+Int32.Parse(this.l.Text.ToString())+Int32.Parse(this.n.Text.ToString())+
        //				Int32.Parse(this.v.Text.ToString())+Int32.Parse(this.x.Text.ToString())+Int32.Parse(this.z.Text.ToString())+
        //				Int32.Parse(this.p.Text.ToString())+Int32.Parse(this.r.Text.ToString())+Int32.Parse(this.t.Text.ToString()));
        //			this.b1.Text=a.ToString();
        //		}

        private void zp_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_jxkhjx1.aspx?DisplayType=0&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void zq_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_jxkhjx2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void zdp_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_jxkhjx3.aspx?DisplayType=2&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void zs_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1 || step_id == 2 || step_id == 3)
            {
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

        private int GetValue(string s)//接收数据
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                return 0;
            }
        }

        private void ValueChanged(object sender, System.EventArgs e)
        {
            sum1 = GetValue(this.i.Text) + GetValue(this.k.Text) + GetValue(this.m.Text) +
               GetValue(this.o.Text) + GetValue(this.q.Text) + GetValue(this.s.Text) + GetValue(this.u.Text) +
               GetValue(this.w.Text) + GetValue(this.y.Text);
            //			a1.Text=String.Format("{0:F2}%",sum1/sum*100);
            this.a1.Text = sum1.ToString();
        }

        private void ValueChanged1(object sender, System.EventArgs e)
        {
            sum2 = GetValue(this.j.Text) + GetValue(this.l.Text) + GetValue(this.n.Text) +
               GetValue(this.p.Text) + GetValue(this.r.Text) + GetValue(this.t.Text) + GetValue(this.v.Text) +
               GetValue(this.x.Text) + GetValue(this.z.Text);
            //			a1.Text=String.Format("{0:F2}%",sum1/sum*100);
            this.b1.Text = sum2.ToString();
        }

        private void g_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void Textbox13_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void Textbox9_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void Textbox1_TextChanged(object sender, System.EventArgs e)
        {

        }

    }
}
