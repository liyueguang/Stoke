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
using System.Text.RegularExpressions;

namespace Stoke.USL.Staff
{
    public partial class style_jxkhhz : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id = 1;
        private int doc_id = 0;
        private int flow_id = 40;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;

        protected string _zgxm;

        private void Page_Load(object sender, System.EventArgs e)
        {
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            //Response.Write("<script language='javascript'>alert('" + doc_id.ToString() + "');</script>");
            //����doc_id�ж�ִ�б����ݵĲ����������²���
            if (doc_id > 0)
                bEditMode = true;

            //��ȡ��ǰ���̵ĵ�ǰ����󶨵�field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //��ȡ��ǰ���̵ĵ�ǰ����󶨵�field������
            FieldNum = dt_step_field.Rows.Count;

            //			Page.SmartNavigation = true;

            if (!Page.IsPostBack)
            {
                this.tr1.Visible = false;
                this.tr2.Visible = false;
                this.tr3.Visible = false;

                //�󶨵�ǰ���̵�ǰ�����field
                Field_Bind(dt_step_field);
                //ȡ��Ա������
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString().Trim();
                this.a.Items.Add(System.DateTime.Now.AddYears(-1).Year.ToString());
                this.a.Items.Add(System.DateTime.Now.Year.ToString());
                this.a.Items.Add(System.DateTime.Now.AddYears(1).Year.ToString());
                this.a.Items.Insert(0, "���");
                //				this.a.SelectedIndex = 2;
                //				this.b.SelectedValue = (System.DateTime.Now.Month - 1).ToString();

                //����doc_idȡ�õ�ǰdocument����������
                if (doc_id > 0)
                    Step_Handle_Data();

                if (step_id == 0)
                    this.btnSave.Visible = false;
                else if (step_id == 1)
                {
                    if (doc_id == 0)
                    {
                        this.c.DataSource = dt_xm_bm;
                        this.c.DataValueField = "ry_bm";
                        this.c.DataTextField = "ry_bm";
                        this.c.DataBind();
                        this.c.Items.Insert(0, "-��ѡ��-");
                        this.c.SelectedIndex = 0;
                        this.d.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                        this.e.Text = _zgxm;
                        BindNullGrid();
                    }
                    else if (doc_id > 0)
                        this.btnCancel.Text = "ɾ��";

                    this.tr1.Visible = true;
                }
                else if (step_id == 2)
                    this.f.Text = _zgxm;

                if (h.SelectedValue == "2")
                    CalSumPer();
            }
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
            this.c.SelectedIndexChanged += new System.EventHandler(this.c_SelectedIndexChanged);
            this.h.SelectedIndexChanged += new System.EventHandler(this.ddlRyjb_SelectedIndexChanged);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.ddlXm.SelectedIndexChanged += new System.EventHandler(this.ddlXm_SelectedIndexChanged);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.ddlPxfs.SelectedIndexChanged += new System.EventHandler(this.ddlPxfs_SelectedIndexChanged);
            this.dgJxkh.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgJxkh_PageIndexChanged);
            this.dgJxkh.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgJxkh_CancelCommand);
            this.dgJxkh.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgJxkh_EditCommand);
            this.dgJxkh.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgJxkh_UpdateCommand);
            this.dgJxkh.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgJxkh_ItemDataBound);
            this.dgJxxs.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgJxxs_PageIndexChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindNullGrid()
        {
            DataTable dt = Stoke.Components.Staff.SelectNullJxkh();
            this.dgJxkh.DataSource = dt;
            this.dgJxkh.DataBind();
            for (int i = 0; i < 12; i++)
                dt.Rows.Add(dt.NewRow());
            this.dgJxkh.DataBind();
            for (int i = 0; i < dgJxkh.Items.Count; i++)
            {
                if (dgJxkh.Items[i].Cells[1].Text == "&nbsp;")
                {
                    this.dgJxkh.Items[i].Cells[0].Text = "";
                    this.dgJxkh.Items[i].Cells[9].Controls[0].Visible = false;
                }
            }

            this.dgJxxs.DataSource = dt;
            this.dgJxxs.DataBind();
        }

        private void CalSumPer()
        {
            int jxkh_num_bm90 = Stoke.Components.Staff.JxkhBmFhPercent(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim());
            int jxkh_num_bm = Stoke.Components.Staff.JxkhBmFhNum(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim());
            double per = Convert.ToDouble(jxkh_num_bm90) / Convert.ToDouble(jxkh_num_bm);
            this.labPer.Text = "���У���Ч����������Ϊ" + jxkh_num_bm.ToString() + "�ˣ���Чϵ������1.0���ϵ�����Ϊ" + jxkh_num_bm90.ToString() + "�ˣ�ռ" + (per * 100).ToString("0.00") + "%";
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            this.a.SelectedValue = dt_style_data.Rows[0]["a"].ToString() != "" ? dt_style_data.Rows[0]["a"].ToString() : "���";
            this.b.SelectedValue = dt_style_data.Rows[0]["b"].ToString() != "" ? dt_style_data.Rows[0]["b"].ToString() : "�·�";
            if (step_id == 1)
            {
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                this.c.DataSource = dt_xm_bm;
                this.c.DataValueField = "ry_bm";
                this.c.DataTextField = "ry_bm";
                this.c.DataBind();
                this.c.Items.Insert(0, "-��ѡ��-");
                this.c.SelectedValue = dt_style_data.Rows[0]["c"].ToString() != "" ? dt_style_data.Rows[0]["c"].ToString() : "-��ѡ��-";
            }
            else
            {
                this.c.DataSource = dt_style_data;
                this.c.DataValueField = "c";
                this.c.DataTextField = "c";
                this.c.DataBind();
            }
            this.h.SelectedValue = dt_style_data.Rows[0]["h"].ToString() != "" ? dt_style_data.Rows[0]["h"].ToString() : "0";
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
            //			this.g.Text = dt_style_data.Rows[0]["g"].ToString()!=null ? dt_style_data.Rows[0]["g"].ToString():null;
            MyDataBind(h.SelectedValue);
            if (h.SelectedValue == "2")
            {
                this.c.Visible = true;
                if (step_id == 1)
                {
                    this.tr2.Visible = true;
                    this.tr3.Visible = true;
                }
            }
            //			this.i.Text = dt_style_data.Rows[0]["i"].ToString()!=null ? dt_style_data.Rows[0]["i"].ToString():null;
            //			this.j.Text = dt_style_data.Rows[0]["j"].ToString()!=null ? dt_style_data.Rows[0]["j"].ToString():null;
            //			this.k.Text = dt_style_data.Rows[0]["k"].ToString()!=null ? dt_style_data.Rows[0]["k"].ToString():null;
            //			this.l.Text = dt_style_data.Rows[0]["l"].ToString()!=null ? dt_style_data.Rows[0]["l"].ToString():null;
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
                    ((TextBox)StyleControl).Enabled = true;
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
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                case "System.Web.UI.WebControls.CheckBox":
                    return ((CheckBox)StyleControl).Checked.ToString();
                default:
                    return "";
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1)
            {
                if (this.labUnfound.Text != string.Empty)
                    Response.Write("<script language='javascript'>alert('���ȵȴ�δ��ɵļ�Ч���˻����ֹ�¼������༨Ч���˽����');</script>");
                else
                {
                    if (h.SelectedValue == "2")
                    {
                        Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                        DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                        string bm = dt_xm_bm.Rows[0][1].ToString().Trim();
                        int jxkh_num_bm90 = 0;
                        string warning = "";
                        if (bm != "�����Ʋ�")
                        {
                            jxkh_num_bm90 = Stoke.Components.Staff.JxkhBmFhPercent(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim());
                            int jxkh_num_bm = Stoke.Components.Staff.JxkhBmFhNum(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim());
                            double per_rule = 0.2;
                            int jxkh_num_cal = Convert.ToInt16(Math.Round(jxkh_num_bm * per_rule, 0));
                            double per = Convert.ToDouble(jxkh_num_bm90) / Convert.ToDouble(jxkh_num_bm);
                            warning = "���ż�Ч����ϵ������1.0�ı�����" + (per * 100).ToString("0.00") + "%," + "��" + jxkh_num_bm90.ToString() + "�ˣ������涨" + jxkh_num_cal.ToString() + "�ˣ��������";
                            if (jxkh_num_bm90 > jxkh_num_cal)
                            {
                                Response.Write("<script language='javascript'>alert('" + warning + "');</script>");
                                return;
                            }
                        }
                        else
                        {
                            jxkh_num_bm90 = Stoke.Components.Staff.JxkhBmFhPercent(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim());
                            if (jxkh_num_bm90 > 2)
                            {
                                Response.Write("<script language='javascript'>alert('��Ч����ϵ������1.0����������������2�ˣ�');</script>");
                                return;
                            }
                        }
                    }
                    SaveData();
                    string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=40&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                    Response.Redirect(_URL);
                }
            }
            else
            {
                SaveData();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=40&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
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
                Response.Redirect("../Workflow/Work_Record.aspx");
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            if (bEditMode == false)
            {
                mySql = GetStyleInsertData();
                //���
                if (h.SelectedValue == "2")
                    doc_id = df.AddDocument(_zgbh, flow_id, mySql, a.SelectedValue + "��" + b.SelectedValue + "��" + c.SelectedValue.Trim() + "��Ч���˻���");
                else if (h.SelectedValue == "1")
                    doc_id = df.AddDocument(_zgbh, flow_id, mySql, a.SelectedValue + "��" + b.SelectedValue + "��" + "����������Ա��" + "��Ч���˻���");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                df.UpdateDocument(mySql);
                df = null;
            }

        }

        private void ddlRyjb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.h.SelectedValue == "1")
            {

                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                string bm = dt_xm_bm.Rows[0][1].ToString().Trim();
                if (bm == "�ۺϹ���")
                {
                    this.c.Visible = false;
                    this.tr2.Visible = false;
                    this.tr3.Visible = false;
                    if (a.SelectedValue == "���" || b.SelectedValue == "�·�")
                    {
                        Response.Write("<script language='javascript'>alert('����ѡ����ݺ��·ݣ�');</script>");
                        this.h.SelectedIndex = 0;
                    }
                    else
                    {
                        this.dgJxkh.CurrentPageIndex = 0;
                        MyDataBind("1");
                        this.labUnfound.Text = "";
                        GetUnfoundJxkh("1");
                    }
                }
                else
                {
                    this.c.Visible = true;
                    this.tr2.Visible = false;
                    this.tr3.Visible = false;
                    Response.Write("<script language='javascript'>alert('��ѡ�񲿳������¼���');</script>");
                }
            }
            else if (this.h.SelectedValue == "2")
            {
                this.c.Visible = true;
                this.tr2.Visible = true;
                this.tr3.Visible = true;
                if (a.SelectedValue == "���" || b.SelectedValue == "�·�")
                    Response.Write("<script language='javascript'>alert('��ѡ����ݺ��·�');</script>");
                else
                {
                    this.dgJxkh.CurrentPageIndex = 0;
                    MyDataBind("2");
                    this.labUnfound.Text = "";
                    GetUnfoundJxkh("2");
                }
            }
            else
            {
                this.c.Visible = false;
                this.tr2.Visible = false;
                this.tr3.Visible = false;
            }
        }

        private void c_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (c.SelectedValue == "-��ѡ��-")
                Response.Write("<script language='javascript'>alert('��ѡ����');</script>");
            else
            {
                if (a.SelectedValue == "���" || b.SelectedValue == "�·�")
                    Response.Write("<script language='javascript'>alert('��ѡ����ݺ��·�');</script>");
                else
                {
                    MyDataBind("2");
                    this.labUnfound.Text = "";
                    GetUnfoundJxkh("2");
                }
            }

            //------------------------------------tonzoc------------------------//
            if (c.SelectedIndex != 0)
            {
                string cmdText = "select distinct ry_zgbh, ry_xm from dsoc_ry where rtrim(ry_bm) = '" + c.SelectedValue.ToString().Trim() + "' order by ry_zgbh";
                string connString = Stoke.DAL.SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    ddlXm.Enabled = true;
                    ddlXm.DataSource = dt;
                    ddlXm.DataTextField = "ry_xm";
                    ddlXm.DataValueField = "ry_zgbh";
                    ddlXm.DataBind();
                    ddlXm.Items.Insert(0, "-��ѡ��-");
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            else
            {
                txtZgbh.Text = string.Empty;
                ddlXm.SelectedIndex = 0;
                ddlXm.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (c.SelectedValue == "-��ѡ��-")
                Response.Write("<script language='javascript'>alert('��ѡ����');</script>");
            else
            {
                if (a.SelectedValue == "���" || b.SelectedValue == "�·�")
                    Response.Write("<script language='javascript'>alert('��ѡ����ݺ��·�');</script>");
                else
                {
                    if (this.txtZgbh.Text == string.Empty)
                    {
                        Response.Write("<script language='javascript'>alert('����дְ�����');</script>");
                        return;
                    }
                    if (this.ddlXm.SelectedIndex == 0)
                    {
                        Response.Write("<script language='javascript'>alert('����дְ������');</script>");
                        return;
                    }
                    if (this.txtFh.Text == string.Empty)
                    {
                        Response.Write("<script language='javascript'>alert('����д���˷���');</script>");
                        return;
                    }
                    string jxkh_zgbh = this.txtZgbh.Text.Trim();
                    string jxkh_xm = this.ddlXm.SelectedItem.Text.Trim();//.ToString().Trim();
                    float jxkh_zp = 0;
                    if (this.txtZp.Text != string.Empty)
                        jxkh_zp = Convert.ToSingle(this.txtZp.Text);
                    else
                        jxkh_zp = 0;
                    float jxkh_fh = Convert.ToSingle(this.txtFh.Text);
                    double jxkh_xs = 0;
                    if (jxkh_fh <= 90)
                        jxkh_xs = Convert.ToDouble(Math.Round(jxkh_fh / 90, 2));
                    else
                        jxkh_xs = Convert.ToDouble(Math.Round(1 + (jxkh_fh - 90) * 0.02, 2));

                    string pylx = "";
                    Stoke.Components.Staff person = new Stoke.Components.Staff();
                    SqlDataReader dr = person.GetStaffInfo(jxkh_zgbh);
                    if (dr.Read())
                    {
                        pylx = dr["pylx"].ToString();
                    }
                    Stoke.Components.Staff.InsertGljslJxkh(jxkh_zgbh, jxkh_xm, this.c.SelectedValue.Trim(), "", Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), jxkh_zp, 0, 0, jxkh_fh, pylx, jxkh_xs, doc_id);
                    MyDataBind("2");
                    this.labUnfound.Text = "";
                    GetUnfoundJxkh("2");
                }
            }
        }

        private void GetUnfoundJxkh(string flag)//1���쵼��2�����쵼
        {
            DataTable dt = new DataTable();
            if (flag == "1")
                dt = Stoke.Components.Staff.SelectUnfoundLdjxkh(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue));
            else if (flag == "2")
                dt = Stoke.Components.Staff.SelectUnfoundFldjxkh(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim());
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    string unfound_warning = "���У�";
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                        unfound_warning = unfound_warning + dt.Rows[i][1].ToString() + "��";
                    unfound_warning += dt.Rows[dt.Rows.Count - 1][1].ToString();
                    unfound_warning += "δ���м�Ч���˻����ֹ�¼�룡";
                    this.labUnfound.Text = unfound_warning;
                }
            }
        }

        private void MyDataBind(string flag)//1���쵼��2�����쵼
        {
            DataTable dt = new DataTable();
            if (flag == "1")
                dt = Stoke.Components.Staff.SelectLdjxkhByNfYf(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.ddlPxfs.SelectedValue);
            else if (flag == "2")
                dt = Stoke.Components.Staff.SelectFldjxkhByNfYf(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim(), this.ddlPxfs.SelectedValue);
            this.dgJxkh.DataSource = dt;
            this.dgJxkh.DataBind();
            if (dt != null)
                if (dt.Rows.Count == 0)
                {
                    for (int i = 0; i < 12; i++)
                        dt.Rows.Add(dt.NewRow());
                    this.dgJxkh.DataBind();

                    for (int i = 0; i < dgJxkh.Items.Count; i++)
                    {
                        if (dgJxkh.Items[i].Cells[1].Text == "&nbsp;")
                        {
                            this.dgJxkh.Items[i].Cells[0].Text = "";
                            this.dgJxkh.Items[i].Cells[9].Controls[0].Visible = false;
                        }
                    }
                }

            //			int count = dgJxkh.PageSize*dgJxkh.PageCount-dt.Rows.Count;
            //			for(int i=0;i<count;i++)
            //				dt.Rows.Add(dt.NewRow());
            //			this.dgJxkh.DataBind();

            this.dgJxxs.DataSource = dt;
            this.dgJxxs.DataBind();


            float jxxs_m = 0;//M�༨Ч��ϵ����
            float jxxs_pm = 0;//PM�༨Чϵ����
            float jxxs_pw = 0;//PW�༨Чϵ����
            DataTable dt_jxxs = Stoke.Components.Staff.StatisticsJxkh(Convert.ToInt16(this.a.SelectedValue), Convert.ToInt16(this.b.SelectedValue), this.c.SelectedValue.Trim(), flag);
            if (dt_jxxs != null)
                if (dt_jxxs.Rows.Count != 0)
                {
                    for (int j = 0; j < dt_jxxs.Rows.Count; j++)
                    {
                        if (dt_jxxs.Rows[j][0].ToString() == "M")
                            jxxs_m += Convert.ToSingle(dt_jxxs.Rows[j][1].ToString());
                        else if (dt_jxxs.Rows[j][0].ToString() == "PM")
                            jxxs_pm += Convert.ToSingle(dt_jxxs.Rows[j][1].ToString());
                        else if (dt_jxxs.Rows[j][0].ToString() == "PW")
                            jxxs_pw += Convert.ToSingle(dt_jxxs.Rows[j][1].ToString());
                    }
                    this.i.Text = jxxs_m.ToString();
                    this.j.Text = jxxs_pm.ToString();
                    this.k.Text = jxxs_pw.ToString();
                    this.l.Text = (jxxs_m + jxxs_pm + jxxs_pw).ToString();
                }

            if (h.SelectedValue == "2")
                CalSumPer();
        }

        private static bool IsNumeric(string itemValue)
        {
            return (IsRegEx("^(-?[0-9]*[.]*[0-9]{0,3})$", itemValue));
        }

        private static bool IsRegEx(string regExValue, string itemValue)
        {

            try
            {
                Regex regex = new System.Text.RegularExpressions.Regex(regExValue);
                if (regex.IsMatch(itemValue)) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
            }
        }


        private void dgJxkh_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            this.dgJxkh.EditItemIndex = i;
            MyDataBind(h.SelectedValue);
            this.dgJxkh.SelectedIndex = i;
            TextBox txt_fh = (TextBox)this.dgJxkh.Items[i].Cells[8].Controls[0];
            txt_fh.Width = Unit.Pixel(80);
        }

        private void dgJxkh_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (((TextBox)e.Item.Cells[8].Controls[0]).Text.ToString() != "")
            {
                string jxkh_fh = ((TextBox)e.Item.Cells[8].Controls[0]).Text.ToString();
                float fh = 0;
                double xs = 0;
                if (IsNumeric(jxkh_fh))
                {
                    fh = float.Parse(jxkh_fh);
                    int i = e.Item.ItemIndex;
                    int zdbh = Convert.ToInt32(this.dgJxkh.Items[i].Cells[1].Text);
                    if (fh <= 90)
                        xs = Convert.ToDouble(Math.Round(fh / 90, 2));
                    else
                        xs = Convert.ToDouble(Math.Round(1 + (fh - 90) * 0.02, 2));

                    int docid = Convert.ToInt32(this.dgJxkh.Items[i].Cells[10].Text);
                    Stoke.Components.Staff.UpdateJxkhFhById(zdbh, fh, xs, docid);
                    this.dgJxkh.EditItemIndex = -1;
                    MyDataBind(h.SelectedValue);
                }
                else
                {
                    Response.Write("<script>alert('��������ֵ�ͣ�')</script>");
                    return;
                }

            }

        }

        private void dgJxkh_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            this.dgJxkh.EditItemIndex = -1;
            MyDataBind(h.SelectedValue);
        }

        private void dgJxkh_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (step_id == 1 || step_id == 2)
                e.Item.Cells[9].Visible = true;
            else
                e.Item.Cells[9].Visible = false;
        }

        private void dgJxkh_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.dgJxkh.CurrentPageIndex = e.NewPageIndex;
            this.MyDataBind(h.SelectedValue);
        }

        private void dgJxxs_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.dgJxxs.CurrentPageIndex = e.NewPageIndex;
            this.dgJxkh.CurrentPageIndex = e.NewPageIndex;
            this.MyDataBind(h.SelectedValue);
        }

        private void ddlPxfs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.h.SelectedValue != "0")
                this.MyDataBind(h.SelectedValue);
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (this.h.SelectedValue == "1")
            {

                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                string bm = dt_xm_bm.Rows[0][1].ToString().Trim();
                if (bm == "�ۺϹ���")
                {
                    this.c.Visible = false;
                    this.tr2.Visible = false;
                    this.tr3.Visible = false;
                    if (a.SelectedValue == "���" || b.SelectedValue == "�·�")
                    {
                        Response.Write("<script language='javascript'>alert('����ѡ����ݺ��·ݣ�');</script>");
                        this.h.SelectedIndex = 0;
                    }
                    else
                    {
                        this.dgJxkh.CurrentPageIndex = 0;
                        MyDataBind("1");
                        this.labUnfound.Text = "";
                        GetUnfoundJxkh("1");
                    }
                }
                else
                {
                    this.c.Visible = true;
                    this.tr2.Visible = false;
                    this.tr3.Visible = false;
                    Response.Write("<script language='javascript'>alert('��ѡ�񲿳������¼���');</script>");
                }
            }
            else if (this.h.SelectedValue == "2")
            {
                this.c.Visible = true;
                this.tr2.Visible = true;
                this.tr3.Visible = true;
                if (a.SelectedValue == "���" || b.SelectedValue == "�·�")
                    Response.Write("<script language='javascript'>alert('��ѡ����ݺ��·�');</script>");
                else
                {
                    if (c.SelectedValue == "-��ѡ��-")
                        Response.Write("<script language='javascript'>alert('��ѡ����');</script>");
                    else
                    {
                        this.dgJxkh.CurrentPageIndex = 0;
                        MyDataBind("2");
                        this.labUnfound.Text = "";
                        GetUnfoundJxkh("2");
                    }
                }
            }
            else
            {
                this.c.Visible = false;
                this.tr2.Visible = false;
                this.tr3.Visible = false;
                Response.Write("<script language='javascript'>alert('��ѡ�񼶱�');</script>");
            }
        }

        private void ddlXm_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlXm.SelectedIndex != 0)
                txtZgbh.Text = ddlXm.SelectedValue.ToString().Trim();
            else
                txtZgbh.Text = string.Empty;
        }

    }
}
