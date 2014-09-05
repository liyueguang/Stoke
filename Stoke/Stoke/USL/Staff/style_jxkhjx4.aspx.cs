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
    public partial class style_jxkhjx4 : System.Web.UI.Page
    {

        DataTable dt_step_field;
        private int step_id = 4;
        private int doc_id = 0;
        private int flow_id = 38;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;
        private int fs1;
        private double fs2;
        private int fs3;
        private double fs4;
        private int zpfs1;
        private double zf;
        private string dsxm;
        private string bzxm;
        private double zpfs2;
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


            if (!Page.IsPostBack)
            {

                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                    Step_Handle_Data();

                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);

                //使得意见汇总不能编辑
                if (step_id == 4)
                {
                    this.l1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.l1.ReadOnly = true;
                    this.m1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.m1.ReadOnly = true;
                    this.n1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.n1.ReadOnly = true;
                    this.o1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.o1.ReadOnly = true;
                    this.p1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.p1.ReadOnly = true;
                    this.q1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.q1.ReadOnly = true;
                    this.r1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.r1.ReadOnly = true;
                    this.s1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.s1.ReadOnly = true;
                    this.t1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.t1.ReadOnly = true;
                    this.u1.BackColor = System.Drawing.Color.WhiteSmoke;
                    this.u1.ReadOnly = true;
                }



                //访问dsoc_ry取得登录人姓名（有4类）,部门，职位
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString();

                if (step_id == 4)
                {
                    this.d1.Text = _zgbh;
                    this.e1.Text = _zgxm;
                    this.h1.DataSource = dt_xm_bm;
                    this.h1.DataValueField = "ry_bm";
                    this.h1.DataTextField = "ry_bm";
                    this.h1.DataBind();
                    this.i1.DataSource = dt_xm_bm;
                    this.i1.DataValueField = "ry_zw";
                    this.i1.DataTextField = "ry_zw";
                    this.i1.DataBind();

                    //访问rs_staff取得拟稿人学历，毕业学校，进本单位时间
                    DataTable dt_zgxl_byxx_jbdwsj = Stoke.Components.Staff.GetInfo_jxjx_staff(_zgbh);
                    this.f1.Text = dt_zgxl_byxx_jbdwsj.Rows[0][0].ToString();
                    this.j1.Text = dt_zgxl_byxx_jbdwsj.Rows[0][1].ToString();
                    //					this.g1.Text=dt_zgxl_byxx_jbdwsj.Rows[0][2].ToString();
                    this.g1.Text = ((dt_zgxl_byxx_jbdwsj.Rows[0][2] == DBNull.Value) || (DateTime.Parse(dt_zgxl_byxx_jbdwsj.Rows[0][2].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dt_zgxl_byxx_jbdwsj.Rows[0][2].ToString()).ToString("yyyy-MM-dd");

                    //意见汇总

                    this.l1.Text = _zgxm;
                    //从rs_flow_jxjx_zp表读出员工自评分
                    //					string zgbh=_zgbh;
                    //					int id=0;
                    string zgbh = "";
                    int id = doc_id;
                    DataTable dt = Stoke.Components.Staff.GetInfo_jxjx(zgbh, id);
                    zpfs1 = Int32.Parse(dt.Rows[0]["jxjx_fs"].ToString());
                    zpfs2 = zpfs1 * 0.1;
                    this.m1.Text = zpfs1.ToString();
                    this.n1.Text = zpfs2.ToString();


                    DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);

                    //从前三个表读出的评价,   流程表单中：指导分a1,部长分b1,指导名f,部长名c1
                    this.o1.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
                    dsxm = dt_style_data.Rows[0]["f"].ToString();
                    this.p1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
                    if (this.p1.Text != "")
                    {
                        fs1 = Int32.Parse(this.p1.Text.ToString());
                        fs2 = fs1 * 0.5;
                        this.q1.Text = fs2.ToString();
                    }


                    this.r1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
                    bzxm = dt_style_data.Rows[0]["c1"].ToString();
                    this.s1.Text = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : null;
                    if (this.s1.Text != "")
                    {
                        fs3 = Int32.Parse(this.s1.Text.ToString());
                        fs4 = fs3 * 0.4;
                        this.t1.Text = fs4.ToString();
                    }
                    zf = zpfs2 + fs2 + fs4;
                    this.u1.Text = zf.ToString();
                }
                else if (step_id == 5)
                {
                    DataTable dt_zw = Stoke.BLL.Place.GetAll();
                    this.w1.DataSource = dt_zw;
                    this.w1.DataTextField = "zw_mc";
                    this.w1.DataValueField = "zw_mc";
                    this.w1.DataBind();
                    this.w1.Items.Insert(0, "-请选择-");
                    this.w1.SelectedIndex = 0;
                    this.x1.Text = _zgxm;
                    this.y1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    float fs = float.Parse(this.u1.Text.ToString());
                    if (80 <= fs)
                        this.i2.SelectedValue = "A";
                    else if (fs >= 60)
                    {
                        this.i2.SelectedValue = "B";
                        this.j2.SelectedIndex = 0;
                    }

                    else
                        this.i2.SelectedValue = "C";
                }
                else if (step_id == 6)
                {
                    DataTable dt_zw = Stoke.BLL.Place.GetAll();
                    this.c2.DataSource = dt_zw;
                    this.c2.DataTextField = "zw_mc";
                    this.c2.DataValueField = "zw_mc";
                    this.c2.DataBind();
                    this.c2.Items.Insert(0, "-请选择-");
                    this.c2.SelectedIndex = 0;
                    this.e2.Text = _zgxm;
                    this.f2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (step_id == 7)
                {
                    this.g2.Text = _zgxm;
                    this.h2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (step_id == -1)
                {
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
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
            this.i2.SelectedIndexChanged += new System.EventHandler(this.i2_SelectedIndexChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
            this.e1.Text = dt_style_data.Rows[0]["e1"].ToString() != null ? dt_style_data.Rows[0]["e1"].ToString() : null;
            this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;
            this.g1.Text = dt_style_data.Rows[0]["g1"].ToString() != null ? dt_style_data.Rows[0]["g1"].ToString() : null;
            //			部门
            this.h1.DataSource = dt_style_data;
            this.h1.DataValueField = "h1";
            this.h1.DataTextField = "h1";
            this.h1.DataBind();

            //			职务
            this.i1.DataSource = dt_style_data;
            this.i1.DataValueField = "i1";
            this.i1.DataTextField = "i1";
            this.i1.DataBind();
            //试一下只用this.bm.SelectedValue = dt_style_data.Rows[0]["bm"].ToString();

            this.j1.Text = dt_style_data.Rows[0]["j1"].ToString() != null ? dt_style_data.Rows[0]["j1"].ToString() : null;

            if (dt_style_data.Rows[0]["k1"].ToString() != "")
                this.k1.SelectedValue = dt_style_data.Rows[0]["k1"].ToString();
            else
                this.k1.SelectedIndex = 0;
            //			this.k1.SelectedValue = dt_style_data.Rows[0]["k1"].ToString()!=null ? dt_style_data.Rows[0]["k1"].ToString():null;
            this.l1.Text = dt_style_data.Rows[0]["l1"].ToString() != null ? dt_style_data.Rows[0]["l1"].ToString() : null;
            this.m1.Text = dt_style_data.Rows[0]["m1"].ToString() != null ? dt_style_data.Rows[0]["m1"].ToString() : null;
            this.n1.Text = dt_style_data.Rows[0]["n1"].ToString() != null ? dt_style_data.Rows[0]["n1"].ToString() : null;
            this.o1.Text = dt_style_data.Rows[0]["o1"].ToString() != null ? dt_style_data.Rows[0]["o1"].ToString() : null;
            this.p1.Text = dt_style_data.Rows[0]["p1"].ToString() != null ? dt_style_data.Rows[0]["p1"].ToString() : null;
            this.q1.Text = dt_style_data.Rows[0]["q1"].ToString() != null ? dt_style_data.Rows[0]["q1"].ToString() : null;
            this.r1.Text = dt_style_data.Rows[0]["r1"].ToString() != null ? dt_style_data.Rows[0]["r1"].ToString() : null;
            this.s1.Text = dt_style_data.Rows[0]["s1"].ToString() != null ? dt_style_data.Rows[0]["s1"].ToString() : null;
            this.t1.Text = dt_style_data.Rows[0]["t1"].ToString() != null ? dt_style_data.Rows[0]["t1"].ToString() : null;
            this.u1.Text = dt_style_data.Rows[0]["u1"].ToString() != null ? dt_style_data.Rows[0]["u1"].ToString() : null;
            this.v1.Text = dt_style_data.Rows[0]["v1"].ToString() != null ? dt_style_data.Rows[0]["v1"].ToString() : null;
            //			职务
            this.w1.DataSource = dt_style_data;
            this.w1.DataValueField = "w1";
            this.w1.DataTextField = "w1";
            this.w1.DataBind();
            this.x1.Text = dt_style_data.Rows[0]["x1"].ToString() != null ? dt_style_data.Rows[0]["x1"].ToString() : null;
            this.y1.Text = dt_style_data.Rows[0]["y1"].ToString() != null ? dt_style_data.Rows[0]["y1"].ToString() : null;
            this.z1.Text = dt_style_data.Rows[0]["z1"].ToString() != null ? dt_style_data.Rows[0]["z1"].ToString() : null;
            this.a2.Text = dt_style_data.Rows[0]["a2"].ToString() != null ? dt_style_data.Rows[0]["a2"].ToString() : null;
            this.b2.Text = dt_style_data.Rows[0]["b2"].ToString() != null ? dt_style_data.Rows[0]["b2"].ToString() : null;
            this.c2.DataSource = dt_style_data;
            this.c2.DataValueField = "c2";
            this.c2.DataTextField = "c2";
            this.c2.DataBind();
            this.d2.Text = dt_style_data.Rows[0]["d2"].ToString() != null ? dt_style_data.Rows[0]["d2"].ToString() : null;
            this.e2.Text = dt_style_data.Rows[0]["e2"].ToString() != null ? dt_style_data.Rows[0]["e2"].ToString() : null;
            this.f2.Text = dt_style_data.Rows[0]["f2"].ToString() != null ? dt_style_data.Rows[0]["f2"].ToString() : null;
            this.g2.Text = dt_style_data.Rows[0]["g2"].ToString() != null ? dt_style_data.Rows[0]["g2"].ToString() : null;
            this.h2.Text = dt_style_data.Rows[0]["h2"].ToString() != null ? dt_style_data.Rows[0]["h2"].ToString() : null;
            if (dt_style_data.Rows[0]["i2"].ToString() != "")
                this.i2.SelectedValue = dt_style_data.Rows[0]["i2"].ToString();
            else
                this.i2.SelectedIndex = -1;
            if (dt_style_data.Rows[0]["j2"].ToString() != "")
                this.j2.SelectedValue = dt_style_data.Rows[0]["j2"].ToString();
            else
                this.j2.SelectedIndex = -1;
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
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.RadioButtonList")
                {
                    ((RadioButtonList)StyleControl).Enabled = true;
                    ((RadioButtonList)StyleControl).BackColor = Color.White;
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {

            SaveData();
            //意见汇总没有写入步骤-控件绑定表，因为不能修改，这里单独入库
            //			if(step_id==4)
            //			{
            //				Stoke.Components.Staff.Insert_Flow_Rs_jxjx_yjhz(doc_id,_zgxm,zpfs1,zpfs2,dsxm,fs1,fs2,bzxm,fs3,fs4,zf);
            //			}

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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, e1.Text.ToString().Trim() + "见习、试用期员工转正申请");
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
                case "System.Web.UI.WebControls.RadioButtonList":
                    return ((RadioButtonList)StyleControl).SelectedValue.ToString();
                default:
                    return "";
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
        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

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
            Response.Redirect("style_jxkhjx4.aspx?DisplayType=3&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void i2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (i2.SelectedValue != "B")
            {
                this.j2.Enabled = false;
                this.j2.SelectedIndex = -1;
            }
            else
                this.j2.Enabled = true;
        }
    }
}
