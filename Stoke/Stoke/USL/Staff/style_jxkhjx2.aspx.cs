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
    public partial class style_jxkhjx2 : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id = 1;
        private int doc_id = 0;
        private int flow_id = 38;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;

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

                if (step_id == 1 || step_id == 2)//防止部长级别审批时也绑定
                    //绑定当前流程当前步骤的field
                    Field_Bind(dt_step_field);

                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString();

                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                    Step_Handle_Data();
                if (step_id == 1)
                {
                    this.e.Text = _zgxm;
                    this.g.DataSource = dt_xm_bm;
                    this.g.DataValueField = "ry_bm";
                    this.g.DataTextField = "ry_bm";
                    this.g.DataBind();
                    this.h.DataSource = dt_xm_bm;
                    this.h.DataValueField = "ry_zw";
                    this.h.DataTextField = "ry_zw";
                    this.h.DataBind();

                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                }
                else
                {
                    this.btnSave.Visible = false;
                    if (step_id == 2)
                        this.f.Text = _zgxm;
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);

            this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
            this.b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;

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
            //			this.g.SelectedItem.Text = dt_style_data.Rows[0]["g"].ToString()!=null ? dt_style_data.Rows[0]["g"].ToString():null;
            //			this.h.SelectedItem.Text = dt_style_data.Rows[0]["h"].ToString()!=null ? dt_style_data.Rows[0]["h"].ToString():null;
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

        private void btnSave_Click(object sender, System.EventArgs e)
        {

            if (step_id == 1)
            {
                SaveData();
                //				Response.Write("<script>alert('"+doc_id+"');</script>");
                //				Response.Write("<script language='javascript'>alert('" + doc_id + "');</script>");
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=38&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, e.Text.ToString().Trim() + "见习、试用期绩效考核自我评估");
                df = null;

                /////////////////////////////////////////////////////
                //添加拟稿人自评表的doc_id
                ////////////////////////////////////////////////////
                Stoke.Components.Staff.UpdateJxjx_docid_by_zgbh(doc_id, _zgbh);
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

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1)
            {
                if (doc_id > 0)
                {
                    //					Stoke.Components.Staff.DeleteDocument(doc_id);
                    Stoke.Components.Staff.DeleteJxjx(doc_id);
                    Response.Redirect("../Workflow/Work_Manage.aspx");
                }
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
                Response.Redirect("../Workflow/Work_Record.aspx");
            //				Response.Redirect(ViewState["retu"].ToString());
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }
    }
}
