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
using System.Configuration;
using Stoke.COMMON;

namespace Stoke.USL.Staff
{
    public partial class style_qzsp2 : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id = 2;         ///////////////////////////////////////////////
        private int doc_id = 0;          //////////////////////////////////////////////
        private int flow_id = 10;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;
        protected string _zgbm;
        protected int DisplayType = 0;

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

                this.Table4.Visible = false;//薪酬待遇

                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                if (dt_xm_bm.Rows.Count != 0)
                {
                    _zgxm = dt_xm_bm.Rows[0][0].ToString();
                    _zgbm = dt_xm_bm.Rows[0][1].ToString();
                }
                //				if(step_id==0)
                //				{
                ////					if(_zgbh==this.y.Text||_zgbh==this.z.Text)
                ////						this.Table4.Visible = true;
                //					this.btnSave.Visible = false;
                //				}
                if (step_id == 1)
                {
                    this.btnSave.Visible = false;
                    this.btnCancel.Visible = false;
                }
                else if (step_id == -2 || step_id == 0 || step_id == 9)//从求职审批列表页面跳转时设置step_id=-2
                {
                    if (Session["zgbh"] != null)
                        _zgbh = Session["zgbh"].ToString();
                    else
                        Response.Redirect("../error.aspx");

                    Stoke.Components.xtqx _xtqx = new Stoke.Components.xtqx();
                    int _is_rs_qzsp_xzllq = _xtqx.Isqx(_zgbh, "求职审批管理", "浏览权");

                    if (_is_rs_qzsp_xzllq != 1)
                        this.Table4.Visible = false;
                    else
                        this.Table4.Visible = true;
                    if (step_id != 9)
                        this.btnSave.Visible = false;

                }
                else if (step_id == 2)
                {
                    this.k2.Text = _zgxm;
                    DataTable dt_zw = Stoke.BLL.Place.GetAll();
                    this.j2.DataSource = dt_zw;
                    this.j2.DataTextField = "zw_mc";
                    this.j2.DataValueField = "zw_mc";
                    this.j2.DataBind();
                    this.j2.Items.Insert(0, "-请选择-");
                    this.j2.SelectedIndex = 0;
                    //					DataTable dt_zw = dsoc.BLL.Place.GetAll();
                    this.m2.DataSource = dt_zw;
                    this.m2.DataTextField = "zw_mc";
                    this.m2.DataValueField = "zw_mc";
                    this.m2.DataBind();
                    this.m2.Items.Insert(0, "-请选择-");
                    this.m2.SelectedIndex = 0;
                }
                else if (step_id == 3)
                {
                    this.l2.Text = _zgxm;
                    this.y2.Text = _zgbm;
                }

                else if (step_id == 4)
                {
                    this.q2.Text = _zgxm;

                }
                else if (step_id == 5)
                {
                    this.r2.Text = _zgxm;
                    this.Table4.Visible = true;
                }
                else if (step_id == 6)
                    this.s2.Text = _zgxm;
                else if (step_id == 7)
                {
                    this.t2.Text = _zgxm;
                    this.Table4.Visible = true;
                }
                else if (step_id == -1)
                {
                    UpdateQzsp();
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }
            }
            if (doc_id != 0)
            {
                //				this.lab_qzjlxz.Visible = true;
                //				this.HyperLink1.Visible = true;
                //				this.lab_qzjl.Visible = true;
                //				this.upFile.Visible = true;
                ShowAffix();
            }
            else
            {
                //				this.lab_qzjlxz.Visible = false;
                //				this.HyperLink1.Visible = false;
                //				this.lab_qzjl.Visible = true;
                //				this.upFile.Visible = true;
            }
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
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

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            if (dt_style_data != null)
            {
                this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;
                this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
                this.f2.Text = dt_style_data.Rows[0]["f2"].ToString() != null ? dt_style_data.Rows[0]["f2"].ToString() : null;
                this.g2.Text = dt_style_data.Rows[0]["g2"].ToString() != null ? dt_style_data.Rows[0]["g2"].ToString() : null;
                this.h2.Text = dt_style_data.Rows[0]["h2"].ToString() != null ? dt_style_data.Rows[0]["h2"].ToString() : null;
                this.i2.Text = dt_style_data.Rows[0]["i2"].ToString() != null ? dt_style_data.Rows[0]["i2"].ToString() : null;
                this.j2.DataSource = dt_style_data;
                this.j2.DataValueField = "j2";
                this.j2.DataTextField = "j2";
                this.j2.DataBind();
                this.k2.Text = dt_style_data.Rows[0]["k2"].ToString() != null ? dt_style_data.Rows[0]["k2"].ToString() : null;
                this.l2.Text = dt_style_data.Rows[0]["l2"].ToString() != null ? dt_style_data.Rows[0]["l2"].ToString() : null;
                this.m2.DataSource = dt_style_data;
                this.m2.DataValueField = "m2";
                this.m2.DataTextField = "m2";
                this.m2.DataBind();
                this.n2.Text = dt_style_data.Rows[0]["n2"].ToString() != null ? dt_style_data.Rows[0]["n2"].ToString() : null;
                this.o2.Text = dt_style_data.Rows[0]["o2"].ToString() != null ? dt_style_data.Rows[0]["o2"].ToString() : null;
                this.p2.Text = dt_style_data.Rows[0]["p2"].ToString() != null ? dt_style_data.Rows[0]["p2"].ToString() : null;
                this.q2.Text = dt_style_data.Rows[0]["q2"].ToString() != null ? dt_style_data.Rows[0]["q2"].ToString() : null;
                this.r2.Text = dt_style_data.Rows[0]["r2"].ToString() != null ? dt_style_data.Rows[0]["r2"].ToString() : null;
                this.s2.Text = dt_style_data.Rows[0]["s2"].ToString() != null ? dt_style_data.Rows[0]["s2"].ToString() : null;
                this.t2.Text = dt_style_data.Rows[0]["t2"].ToString() != null ? dt_style_data.Rows[0]["t2"].ToString() : null;
                this.u2.Text = dt_style_data.Rows[0]["u2"].ToString() != null ? dt_style_data.Rows[0]["u2"].ToString() : null;
                this.v2.Text = dt_style_data.Rows[0]["v2"].ToString() != null ? dt_style_data.Rows[0]["v2"].ToString() : null;
                this.w2.Text = dt_style_data.Rows[0]["w2"].ToString() != null ? dt_style_data.Rows[0]["w2"].ToString() : null;
                this.x2.Text = dt_style_data.Rows[0]["x2"].ToString() != null ? dt_style_data.Rows[0]["x2"].ToString() : null;
                this.y2.Text = dt_style_data.Rows[0]["y2"].ToString() != null ? dt_style_data.Rows[0]["y2"].ToString() : null;
                //				this.y.Text = dt_style_data.Rows[0]["y"].ToString()!=null ? dt_style_data.Rows[0]["y"].ToString():null;
                //				this.z.Text = dt_style_data.Rows[0]["z"].ToString()!=null ? dt_style_data.Rows[0]["z"].ToString():null;
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
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveData();
            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=10&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
            Response.Redirect(_URL);

        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            //Response.Write(this.a.Text);

            if (bEditMode == false)
            {
                //				if(this.upFile.PostedFile.ContentLength>0&&this.upFile.Value!="")
                //				{
                mySql = GetStyleInsertData();
                //拟稿
                //					doc_id = df.AddDocument(_zgbh,flow_id,mySql,d.Text.ToString()+"求职审批"); 
                df = null;

                //					UPaffixFiles();
                //					this.lab_qzjlxz.Visible = true;
                //					this.HyperLink1.Visible = true;
                //					this.lab_qzjl.Visible = true;
                //					this.upFile.Visible = true;
                //					ShowAffix();
                //				}
                //				else
                //					Response.Write("<script> alert('请上传简历') </script>");
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                df = null;
                //				if(step_id==7)
                //					UpdateQzsp();

                //				if(this.upFile.PostedFile.ContentLength>0&&this.upFile.Value!="")
                //				{
                //					GxaffixFiles();
                //					this.lab_qzjlxz.Visible = true;
                //					this.HyperLink1.Visible = true;
                //					this.lab_qzjl.Visible = true;
                //					this.upFile.Visible = true;
                //					ShowAffix();
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
                default:
                    return null;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (step_id == 0)
                Response.Redirect("../Workflow/Work_Record.aspx");
            //				Response.Redirect(ViewState["retu"].ToString());
            else if (step_id == -2)//父页面qzsp_list.aspx
                Response.Redirect("qzsp_list.aspx");
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        public void UPaffixFiles()
        {
            try
            {
                //				if(this.upFile.PostedFile.ContentLength>0&&this.upFile.Value!="")
                //				{
                //					string myfielURL="";
                //					string fileUrl=this.upFile.PostedFile.FileName;//获取初始文件路径
                //					
                //					int j=fileUrl.LastIndexOf("\\");
                //					string fileName=fileUrl.Substring(j+1);//获取文件名
                //					string fileName_rq=System.DateTime.Now.Ticks.ToString()+"@_@"+fileName;
                //					this.upFile.PostedFile.SaveAs(Server.MapPath("Upfile\\")+fileName_rq);
                //					
                //					myfielURL="http://"+Request.ServerVariables["SERVER_NAME"].ToString()+"/dsoc/USL/Staff/Upfile/"+fileName_rq;//记录图片路径
                //					
                //					string connString = dsocGlobals.Connectiondsoc; 
                //					SqlConnection conn = new SqlConnection(connString);  
                //
                //					string str="insert into dsoc_scfj values('"+doc_id.ToString()+"','"+flow_id.ToString()+"','"+myfielURL.ToString()+"','','')";
                //					SqlCommand cmd=new SqlCommand(str,conn);
                //					conn.Open();
                //					SqlDataReader dr = cmd.ExecuteReader();
                //					conn.Close();
                //				}
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        public void GxaffixFiles()
        {
            try
            {
                //				if(this.upFile.PostedFile.ContentLength>0&&this.upFile.Value!="")
                //				{
                //					string myfielURL="";
                //					string fileUrl=this.upFile.PostedFile.FileName;//获取初始文件路径
                //					
                //					int j=fileUrl.LastIndexOf("\\");
                //					string fileName=fileUrl.Substring(j+1);//获取文件名
                //					string fileName_rq=System.DateTime.Now.Ticks.ToString()+"@_@"+fileName;
                //					this.upFile.PostedFile.SaveAs(Server.MapPath("Upfile\\")+fileName_rq);
                //					
                //					myfielURL="http://"+Request.ServerVariables["SERVER_NAME"].ToString()+"/dsoc/USL/Staff/Upfile/"+fileName_rq;//记录图片路径
                //					
                //					string connString = dsocGlobals.Connectiondsoc; 
                //					SqlConnection conn = new SqlConnection(connString);  
                //
                //					string str="update dsoc_scfj set Scfj_Fj1='"+myfielURL.ToString()+"' where Scfj_DocId='"+doc_id.ToString()+"' and Scfj_FlowId='"+flow_id.ToString()+"'";
                //					SqlCommand cmd=new SqlCommand(str,conn);
                //					conn.Open();
                //					SqlDataReader dr = cmd.ExecuteReader();
                //					conn.Close();
                //				}
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        public void ShowAffix()
        {
            //			string sqlstr="select * from dsoc_scfj where Scfj_DocId='"+doc_id+"' and Scfj_FlowId='"+flow_id+"'";
            //			string str_conn = dsocGlobals.Connectiondsoc ;
            //			SqlConnection _conn = new SqlConnection(str_conn);
            //			SqlCommand _command = new SqlCommand(sqlstr,_conn);
            //			_conn.Open();
            //			SqlDataReader dr = _command.ExecuteReader();
            //			while(dr.Read())
            //			{		 
            //				HyperLink1.Visible= true;
            //				HyperLink1.Text= GetAffixFilename(dr["Scfj_Fj1"].ToString());
            //				HyperLink1.NavigateUrl=dr["Scfj_Fj1"].ToString(); 
            //			}
            //			dr.Close();
            //			_conn.Close();

        }

        public string GetAffixFilename(string _name)
        {
            string affixName = "";
            int j = _name.LastIndexOf("@_@");
            affixName = _name.Substring(j + 3);//获取文件名
            return affixName;

        }

        public void UpdateQzsp()
        {
            string qzsp_rlzypj = this.w.Text;
            string qzsp_yrbmpj = this.x.Text;
            string qzsp_zjsh = this.f2.Text;
            string qzsp_jbzscs = this.g2.Text;
            string qzsp_yxgw = this.j2.SelectedValue.Trim();
            string qzsp_rlzyppr = this.k2.Text;
            string qzsp_zyyycs = this.h2.Text;
            string qzsp_ywjncs = this.i2.Text;
            string qzsp_ynbmppr = this.l2.Text;
            string qzsp_zpgw = this.m2.SelectedValue.Trim();
            string qzsp_sgsj = this.n2.Text;
            string qzsp_htqx = this.o2.Text;
            string qzsp_syq = this.p2.Text;
            string qzsp_yrbmfzr = this.q2.Text;
            string qzsp_rlzyfzr = this.r2.Text;
            string qzsp_rlzyld = this.s2.Text;
            string qzsp_zjlsp = this.t2.Text;
            string qzsp_xzdy = this.u2.Text;
            string qzsp_qt = this.v2.Text;
            string qzsp_fzr = this.w2.Text;
            string qzsp_rq = this.x2.Text;
            string qzsp_yrbm = this.y2.Text;
            int ret = Stoke.Components.Staff.UpdateQzsp(doc_id,
                qzsp_rlzypj,
                qzsp_yrbmpj,
                qzsp_zjsh,
                qzsp_jbzscs,
                qzsp_yxgw,
                qzsp_rlzyppr,
                qzsp_zyyycs,
                qzsp_ywjncs,
                qzsp_ynbmppr,
                qzsp_zpgw,
                qzsp_sgsj,
                qzsp_htqx,
                qzsp_syq,
                qzsp_yrbmfzr,
                qzsp_rlzyfzr,
                qzsp_rlzyld,
                qzsp_zjlsp,
                qzsp_xzdy,
                qzsp_qt,
                qzsp_fzr,
                qzsp_rq,
                qzsp_yrbm);
        }

        private void zm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_qzsp.aspx?DisplayType=0&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void bm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_qzsp2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }
    }
}
