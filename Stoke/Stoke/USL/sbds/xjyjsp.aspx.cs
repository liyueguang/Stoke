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
        DataTable dt_step_field;//��ǰ���̵ĵ�ǰ����󶨵�field��
        private int step_id = 0;//��ǰ���̲����
        protected string _zgbh;//��¼Ա����Ӧְ����
        protected string UserName;//��¼Ա������
        private string UserDept;//��¼Ա����������
        private int doc_id = 0;//���ĵ���Ӧ�ĵ���
        private static int flow_id = 49;//���ĵ��������̺�
        private int FieldNum = 0;
        private bool bEditMode = false;

        protected string wordUrl = "";//��¼word·��

        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            this.b.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.g.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.k.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.o.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.s.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.e1.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");

            //����doc_id�ж�ִ�б����ݵĲ����������²���
            if (doc_id > 0)
                bEditMode = true;

            //��ȡ��ǰ���̵ĵ�ǰ����󶨵�field
            dt_step_field = Stoke.Components.Ycsq.Select_Field_by_Step(flow_id, step_id);

            //��ȡ��ǰ���̵ĵ�ǰ����󶨵�field������
            FieldNum = dt_step_field.Rows.Count;

            if (!Page.IsPostBack)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                //ȡ��Ա������
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
                    Step_Handle_Data();//����doc_idȡ�õ�ǰdocument����������
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
                        this.cancelBtn.Text = "ɾ  ��";
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
                        //���ɿ�����д֧Ʊ����hhw20101030
                        this.e.ReadOnly = false;
                        this.i.ReadOnly = false;
                        this.m.ReadOnly = false;
                        this.q.ReadOnly = false;
                        break;
                    case 9:
                        this.f1.Text = UserName;
                        this.e1.ReadOnly = false;
                        this.f1.ReadOnly = false;
                        //						this.e.ReadOnly=false;//��д֧Ʊ����hhw20101030
                        this.f.ReadOnly = false;
                        this.g.ReadOnly = false;
                        //						this.i.ReadOnly=false;//��д֧Ʊ����hhw20101030
                        this.j.ReadOnly = false;
                        this.k.ReadOnly = false;
                        //						this.m.ReadOnly=false;//��д֧Ʊ����hhw20101030
                        this.n.ReadOnly = false;
                        this.o.ReadOnly = false;
                        //						this.q.ReadOnly=false;//��д֧Ʊ����hhw20101030
                        this.r.ReadOnly = false;
                        this.s.ReadOnly = false;
                        if (UserName.Trim() == this.t.Text.ToString().Trim())//�û����;�������ͬһ��������Ϊ�����û�������������˹��� //hhw20101029
                        {
                            this.submitBtn.Enabled = false; //�ύ���ܽ���hhw20101029
                            this.storeBtn.Enabled = false; //���湦�ܽ���hhw20101029
                            this.f1.Text = null;//������Ϊ��
                        }
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// �����������
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


        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
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

            // ��ӡ
            //////////////////////////////////////////////////////////////
            this.Btn_print.Attributes.Add("onclick", "print_xjyj()");
            wordUrl = "http://" + Request.ServerVariables["SERVER_NAME"].ToString() + "/dsoc/USL/sbds/word/xjyj.doc";
            //////////////////////////////////////////////////////////////

            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void submitBtn_Click(object sender, System.EventArgs e)
        {
            //��������
            if (step_id == 8 && this.e.Text == string.Empty)//֧Ʊ��Ϊ��hhw20101030
            {
                Response.Write("<script>alert('����д֧Ʊ��ƾ֤�����룡')</script>");
                return;
            }
            if (step_id == 9 && this.e1.Text == string.Empty)
            {
                Response.Write("<script>alert('����д����Ļ������ڣ�')</script>");
                return;
            }
            SaveData();

            string _URL = "../sbds/zpyjsp_next.aspx?flow_id=49&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
            Response.Redirect(_URL);
        }

        /// <summary>
        /// ���ݲ�ͬ�������������
        /// </summary>
        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            if (bEditMode == false)
            {
                //���
                mySql = GetStyleInsertData();
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.a.SelectedItem.Text.ToString().Trim() + "�ֽ�Ԥ��������");//ɾ����̾��hhw20101103
                df = null;
            }
            else
            {
                //����
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
        /// ���ݲ�ͬ״̬��ȡ����ťִ�в�ͬ�Ĳ���
        /// </summary>
        protected void Delete()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            df.DeleteDocument(doc_id);
            Response.Redirect("../sbds/zpyjsp_next.aspx.aspx");
        }

        /// <summary>
        /// ��ò������ݶ�Ӧ��SQL���
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
        /// ��ø������ݶ�Ӧ��SQL���
        /// </summary>
        /// <param name="DocID">Ҫ���и��µ��ĵ���</param>
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
        /// ���ݿؼ���ö�Ӧֵ 
        /// </summary>
        /// <param name="field_name">�ؼ���</param>
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
            //�жϺ�ͬ�������ʽ�Ƿ���ȷ
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
                        Response.Write("<script>alert('�뱣֤��������Ϊ����������100.00�ĸ�������');</script>");
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
