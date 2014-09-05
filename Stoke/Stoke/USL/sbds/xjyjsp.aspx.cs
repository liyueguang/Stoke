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
using Stoke.Components;
using System.Text;
using System.Data.SqlClient;
using Stoke.Components;
using System.Text.RegularExpressions;

namespace Stoke.USL.sbds
{
    public partial class xjyjsp : System.Web.UI.Page
    {
        DataTable dt_step_field;//当前流程的当前步骤绑定的field表
        private int step_id = 0;//当前流程步骤号
        protected string _zgbh;//登录员工对应职工号
        protected string UserName;//登录员工姓名
        private string UserDept;//登录员工所属部门
        private int doc_id = 0;//该文档对应文档号
        private static int flow_id = 49;//该文档所属流程号
        private int FieldNum = 0;
        private bool bEditMode = false;

        protected string wordUrl = "";//记录word路径

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            this.b.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.g.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.k.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.o.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.s.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.e1.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");

            //根据doc_id判断执行表单数据的插入操作或更新操作
            if (doc_id > 0)
                bEditMode = true;

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.Ycsq.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            if (!Page.IsPostBack)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                UserName = dt_xm_bm.Rows[0][0].ToString();
                UserDept = dt_xm_bm.Rows[0][1].ToString();
                this.a.DataSource = dt_xm_bm;
                this.a.DataTextField = "ry_bm";
                this.a.DataValueField = "ry_bm";
                this.a.DataBind();

                this.storeBtn.Visible = false;
                if (doc_id > 0)
                    Step_Handle_Data();//根据doc_id取得当前document中已有数据
                switch (step_id)
                {
                    case 0:
                        this.submitBtn.Enabled = false;
                        this.storeBtn.Enabled = false;
                        this.cancelBtn.Enabled = false;
                        break;
                    case 1:
                        this.b.ReadOnly = false;
                        this.c.ReadOnly = false;
                        this.d.ReadOnly = false;
                        this.h.ReadOnly = false;
                        this.l.ReadOnly = false;
                        this.p.ReadOnly = false;
                        this.u.ReadOnly = false;
                        this.t.Text = UserName;
                        this.b.Enabled = true;
                        this.storeBtn.Visible = true;
                        this.cancelBtn.Text = "删  除";
                        break;
                    case 2:
                        this.v.Text = UserName;
                        this.v.ReadOnly = false;
                        break;
                    case 3:
                        this.c1.Text = UserName;
                        this.c1.ReadOnly = false;
                        break;
                    case 4:
                        this.w.Text = UserName;
                        this.w.ReadOnly = false;
                        break;
                    case 5:
                        this.x.Text = UserName;
                        this.x.ReadOnly = false;
                        break;
                    case 6:
                        this.y.Text = UserName;
                        this.y.ReadOnly = false;
                        break;
                    case 7:
                        this.z.Text = UserName;
                        this.z.ReadOnly = false;
                        break;
                    case 8:
                        this.d1.Text = UserName;
                        this.d1.ReadOnly = false;
                        //出纳可以填写支票号码hhw20101030
                        this.e.ReadOnly = false;
                        this.i.ReadOnly = false;
                        this.m.ReadOnly = false;
                        this.q.ReadOnly = false;
                        break;
                    case 9:
                        this.f1.Text = UserName;
                        this.e1.ReadOnly = false;
                        this.f1.ReadOnly = false;
                        //						this.e.ReadOnly=false;//填写支票号码hhw20101030
                        this.f.ReadOnly = false;
                        this.g.ReadOnly = false;
                        //						this.i.ReadOnly=false;//填写支票号码hhw20101030
                        this.j.ReadOnly = false;
                        this.k.ReadOnly = false;
                        //						this.m.ReadOnly=false;//填写支票号码hhw20101030
                        this.n.ReadOnly = false;
                        this.o.ReadOnly = false;
                        //						this.q.ReadOnly=false;//填写支票号码hhw20101030
                        this.r.ReadOnly = false;
                        this.s.ReadOnly = false;
                        if (UserName.Trim() == this.t.Text.ToString().Trim())//用户名和经办人是同一姓名，则为提醒用户还款，不具有销账功能 //hhw20101029
                        {
                            this.submitBtn.Enabled = false; //提交功能禁用hhw20101029
                            this.storeBtn.Enabled = false; //保存功能禁用hhw20101029
                            this.f1.Text = null;//销账名为空
                        }
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 按步骤绑定数据
        /// </summary>
        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.Ycsq.Select_Data_by_DocID(doc_id);
            this.a.DataSource = dt_style_data;
            this.a.DataTextField = "a";
            this.a.DataValueField = "a";
            this.a.DataBind();
            this.b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
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
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;
            this.z.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;

            this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
            this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
            this.e1.Text = dt_style_data.Rows[0]["e1"].ToString() != null ? dt_style_data.Rows[0]["e1"].ToString() : null;
            this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;


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
            this.d.TextChanged += new System.EventHandler(this.d_TextChanged);
            this.f.TextChanged += new System.EventHandler(this.f_TextChanged);
            this.h.TextChanged += new System.EventHandler(this.h_TextChanged);
            this.j.TextChanged += new System.EventHandler(this.j_TextChanged);
            this.l.TextChanged += new System.EventHandler(this.l_TextChanged);
            this.n.TextChanged += new System.EventHandler(this.n_TextChanged);
            this.p.TextChanged += new System.EventHandler(this.p_TextChanged);
            this.r.TextChanged += new System.EventHandler(this.r_TextChanged);
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            this.storeBtn.Click += new System.EventHandler(this.storeBtn_Click);
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);

            // 打印
            //////////////////////////////////////////////////////////////
            this.Btn_print.Attributes.Add("onclick", "print_xjyj()");
            wordUrl = "http://" + Request.ServerVariables["SERVER_NAME"].ToString() + "/dsoc/USL/sbds/word/xjyj.doc";
            //////////////////////////////////////////////////////////////

            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void submitBtn_Click(object sender, System.EventArgs e)
        {
            //保存数据
            if (step_id == 8 && this.e.Text == string.Empty)//支票号为空hhw20101030
            {
                Response.Write("<script>alert('请填写支票（凭证）号码！')</script>");
                return;
            }
            if (step_id == 9 && this.e1.Text == string.Empty)
            {
                Response.Write("<script>alert('请填写具体的还款日期！')</script>");
                return;
            }
            SaveData();

            string _URL = "../sbds/zpyjsp_next.aspx?flow_id=49&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
            Response.Redirect(_URL);
        }

        /// <summary>
        /// 根据不同的情况保存数据
        /// </summary>
        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            if (bEditMode == false)
            {
                //拟稿
                mySql = GetStyleInsertData();
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.a.SelectedItem.Text.ToString().Trim() + "现金预借审批单");//删除感叹号hhw20101103
                df = null;
            }
            else
            {
                //更新
                mySql = GetStyleUpdateData(doc_id);
                df.UpdateDocument(mySql);
                df = null;
            }
        }

        private void storeBtn_Click(object sender, System.EventArgs e)
        {
            SaveData();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                delete();
            }
            else
            {
                string url = ViewState["UrlReferrer"].ToString();
                Response.Redirect(url);
            }
        }

        private void delete()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "delete from  Dsoc_Flow_Gwyj where Doc_id='" + doc_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            sql = "delete from Dsoc_Flow_Document where Doc_ID='" + doc_id + "'";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            sql = "delete from DSOC_Flow_Style_Data where Doc_ID='" + doc_id + "'";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        /// <summary>
        /// 根据不同状态，取消按钮执行不同的操作
        /// </summary>
        protected void Delete()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            df.DeleteDocument(doc_id);
            Response.Redirect("../sbds/zpyjsp_next.aspx.aspx");
        }

        /// <summary>
        /// 获得插入数据对应的SQL语句
        /// </summary>
        /// <returns></returns>
        private string GetStyleInsertData()
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Fm1");

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


        /// <summary>
        /// 获得更新数据对应的SQL语句
        /// </summary>
        /// <param name="DocID">要进行更新的文档号</param>
        /// <returns></returns>
        private string GetStyleUpdateData(int DocID)
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Fm1");

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

        /// <summary>
        /// 根据控件获得对应值 
        /// </summary>
        /// <param name="field_name">控件名</param>
        /// <returns></returns>
        private string GetControlText(string field_name)
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Fm1");
            System.Web.UI.Control StyleControl = new Control();
            StyleControl = FrmNewDocument.FindControl(field_name);
            switch (StyleControl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text.Trim();
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedItem.Text.ToString().Trim();
                case "System.Web.UI.WebControls.RadioButton":
                    return ((RadioButton)StyleControl).Checked.ToString();
                default:
                    return null;
            }
        }

        private void d_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(this.d);
        }

        private void JudgeMoney(System.Web.UI.WebControls.TextBox tb)
        {
            //判断合同具体金额格式是否正确
            if (tb.Text != string.Empty)
            {
                string moneyRexStr = @"^[0-9]*[1-9][0-9]*$";
                Regex moneyReg = new Regex(moneyRexStr);
                if (moneyReg.IsMatch(tb.Text.ToString()))
                {
                    tb.Text += ".00";
                    return;
                }
                else
                {
                    string moneyRexStr2 = @"^[0-9]\d*\.\d*|0\.\d*[1-9]\d*$";
                    moneyReg = new Regex(moneyRexStr2);
                    if (!moneyReg.IsMatch(tb.Text.ToString()))
                    {
                        Response.Write("<script>alert('请保证借款金额必须为整数或类如100.00的浮点数！');</script>");
                        return;
                    }
                }
            }
        }

        private void h_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(h);
        }

        private void l_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(l);
        }

        private void p_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(p);
        }

        private void f_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(f);
        }

        private void j_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(j);
        }

        private void n_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(n);
        }

        private void r_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(r);
        }

        private void m_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
