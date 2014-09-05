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
using System.IO;
using Stoke.BLL;
using Stoke.DAL;
using Stoke.COMMON;

namespace Stoke.USL.gwgl
{
    public partial class Cxfz : System.Web.UI.Page
    {
        protected string _zgbh;//ְ�����
        protected string _zgxm;//ְ������
        protected int step_id;//���̲���
        protected int doc_id;//�ĵ����
        protected int flow_id = 3;
        protected DataTable dt_step_field;
        protected int FieldNum;

        //����ӵ�
        protected string gwwh;
        protected string type;
        protected string filename;
        protected string fileid;

        private void Page_Load(object sender, System.EventArgs e)
        {
            Initializ();//���������ʼ������
            if (!IsPostBack)
            {
                this.cx_attach_row.Visible = false;
                this.yx_attach_row.Visible = false;
                AttachList1.DataSource = "0��ͨ�ļ�";
                AttachList1.DataBind();
                AttachList2.DataSource = "0��ͨ�ļ�";
                AttachList2.DataBind();

                if (step_id == 1)
                {
                    BindDepartment(_zgbh); //�󶨲���
                }
                if (doc_id > 0)
                {
                    Step_Handle_Data();//�����ݳ�ʼ��
                    //tonzoc-�󶨸�����������
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string sql = "select * from cxfz_yj where doc_id = '" + doc_id + "' order by yj_time";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    if (dt.Rows.Count > 0)
                    {
                        this.DataGrid1.DataSource = dt.DefaultView;
                        this.DataGrid1.DataBind();
                    }
                    BindEmergency();
                }
                if (step_id == -9)
                {
                    //tonzoc-20110808�ı乫������
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string sql = "update gw_doc set doc_mj = '�ѷ�ֹ�ļ�' where doc_fileid = " + y.Text;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    sql = "select id from gw_doc where doc_fileid = '" + y.Text + "'";
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt_iod = new DataTable();
                    da.Fill(dt_iod);
                    conn.Close();
                    for (int i = 0; i < dt_iod.Rows.Count; i++)
                    {
                        SqlConnection conn1 = new SqlConnection(StokeGlobals.Connectiondsoc);
                        string sql1 = "insert into doc_ht(qx_bh, qx_bz, qx_bg) values('" + dt_iod.Rows[i][0].ToString() + "', '2', '��־�'); insert into doc_ht(qx_bh, qx_bz, qx_bg) values('" + dt_iod.Rows[i][0].ToString() + "', '2', '" + GetName(_zgbh) + "')";
                        //							"insert into doc_ht(qx_bh, qx_bz, qx_bg)" 
                        //							+" select distinct c.y, '2', b.ry_xm  "
                        //							+" from dsoc_flow_style_data as c left join (dsoc_flow_path as a left join dsoc_ry as b on a.staff_id = b.ry_zgbh) on c.doc_id = a.doc_id "
                        //							+" where a.flow_id = '3' and a.doc_id = '"+doc_id+"' and a.step_id in ('1', '2', '3')";
                        conn1.Open();
                        SqlCommand cmd1 = new SqlCommand(sql1, conn1);
                        cmd1.ExecuteNonQuery();
                        conn1.Close();
                    }
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }
                if (step_id != 0)
                {
                    BindZd();//���ֶ�Ȩ��
                    if (type != null)
                    {
                        if (type == "1")
                        {
                            a.Text = gwwh;
                            w.Text = filename;
                            y.Text = fileid;
                        }
                        else if (type == "2")
                        {
                            u.Text = gwwh;
                            x.Text = filename;
                            z.Text = fileid;
                        }
                    }
                }

                Bussiness();//ҵ���߼���ʼ��

            }
            //			if (w.Text != string.Empty)
            //				HyperLink1.NavigateUrl = "../filetosql/Download_fj.aspx?id="+y.Text+"&filename="+FileToMSSQL.Util.EncryptFilename(w.Text);
            //			if (x.Text != string .Empty)
            //				HyperLink2.NavigateUrl = "../filetosql/Download_fj.aspx?id="+z.Text+"&filename="+FileToMSSQL.Util.EncryptFilename(x.Text);

        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Stoke.BLL.Utility.GetEmergencyByDocid(doc_id);
        }


        #region ���������ʼ������
        private void Initializ()
        {
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            gwwh = Request.QueryString["gwwh"];
            type = Request.QueryString["type"];
            filename = Request.QueryString["filename"];
            fileid = Request.QueryString["fileid"];

            if (step_id != 1)
            {
                cxwh_Btn.Enabled = false;
                yxwh_Btn.Enabled = false;
            }

            if (step_id == 1)
                this.EmergencySelector1.Enabled = true;
        }
        #endregion

        #region �����ݳ�ʼ��
        private void Step_Handle_Data()
        {
            string name = null;
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            DataTable dt_Description_data = Stoke.Components.StyleRef.Select_Description_DocID(flow_id);
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            for (int i = 0; i < dt_Description_data.Rows.Count; i++)
            {
                name = dt_Description_data.Rows[i][0].ToString();
                StyleControl = FrmNewDocument.FindControl(name);
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)StyleControl).Text = dt_style_data.Rows[0][name].ToString();
                }
                else if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.Label")
                {
                    ((Label)StyleControl).Text = Server.HtmlDecode(dt_style_data.Rows[0][name].ToString());
                }
                else if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    if (step_id == 1)
                    {
                        for (int j = 0; j < ((DropDownList)StyleControl).Items.Count; j++)
                        {
                            if (((DropDownList)StyleControl).Items[j].Text.ToString().Trim() == dt_style_data.Rows[0][name].ToString())
                            {
                                ((DropDownList)StyleControl).SelectedIndex = j;
                                break;
                            }
                        }
                    }
                    else
                        ((DropDownList)StyleControl).Items.Insert(0, dt_style_data.Rows[0][name].ToString());

                }
            }
        }
        #endregion

        #region ���ֶ�Ȩ��
        private void BindZd()
        {
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);//��ȡ��ǰ���̵ĵ�ǰ����󶨵�field
            if (dt_step_field.Rows.Count > 0)
            {
                FieldNum = dt_step_field.Rows[0][0].ToString().Split(';').Length;//��ȡ��ǰ���̵ĵ�ǰ����󶨵�field������
                Field_Bind(dt_step_field);//�󶨵�ǰ���̵�ǰ�����field
            }
        }

        private void Field_Bind(DataTable dt)
        {
            string name = null;
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            string _field_bind = dt.Rows[0][0].ToString();
            for (int i = 0; i < _field_bind.Split(';').Length; i++)
            {
                name = _field_bind.Split(';')[i].ToString();
                StyleControl = FrmNewDocument.FindControl(name);
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)StyleControl).BackColor = Color.White;
                    if (name == "p" || name == "a" || name == "b" || name == "c" || name == "w" || name == "s" || name == "t" || name == "g" || name == "h" || name == "k" || name == "u" || name == "v" || name == "w"
                        || name == "x" || name == "y" || name == "z")
                        ((TextBox)StyleControl).ReadOnly = false;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)StyleControl).Enabled = true;
                    ((DropDownList)StyleControl).BackColor = Color.White;
                }
            }
        }
        #endregion

        #region ҵ���߼���ʼ��
        private void Bussiness()
        {
            _zgxm = GetName(_zgbh);
            switch (step_id)
            {
                case 0:
                    BtnTj.Text = "��ӡ��WORD";
                    BtnTj.Visible = false;
                    BtnSave.Visible = false;
                    break;
                case 1:
                    f.Text = _zgxm;
                    BtnQx.Text = "ɾ��";
                    BtnTj.Text = "�ύ";
                    break;
                case 2:
                    i.Text = _zgxm;
                    break;
                case 3:
                    d.Text = _zgxm;
                    break;
                case 4:
                    Textbox1.Visible = true;
                    break;
                //				case 6:
                //					k.Text = _zgxm;
                //					break;
            }
        }

        protected string GetName(string _zgbh)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select * from dsoc_ry where ry_zgbh = '" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                _zgxm = dr.IsDBNull(1) ? null : dr["ry_xm"].ToString();
            dr.Close();
            conn.Close();
            return (_zgxm.Trim());
        }

        protected void BindDepartment(string _zgbh)
        {

            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sql = "select  distinct ry_bm from dsoc_ry where ry_zgbh = '" + _zgbh + "'";//2010.02.25
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            this.e.DataSource = dr;
            this.e.DataTextField = "ry_bm";
            this.e.DataValueField = "ry_bm";
            this.e.DataBind();
            this.e.Items.Insert(0, "-��ѡ��-");
            this.e.SelectedIndex = 0;
            dr.Close();
            conn.Close();
            conn.Dispose();

            //tonzoc-20110819--���ķ�ֹ��������Ϊ�ۺϹ�������
            e.Items.Clear();
            this.e.Items.Insert(0, "�ۺϹ���");
        }

        protected void Delete()
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
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        public void UpdataTitle()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "update dbo.Dsoc_Flow_Document set Doc_Title='�йس���:" + a.Text.ToString() + "�Ź��ĵ�����' where Doc_ID='" + doc_id + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        #endregion

        #region �����ύ
        private void Manage()
        {
            switch (step_id)
            {
                case 0:
                    break;
                case 1:
                    {
                        if (a.Text == string.Empty)
                            Response.Write("<script>alert('����д���⣡')</script>");
                        else
                        {
                            SaveData();
                            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=3&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                            Response.Redirect(_URL);
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        SaveData();
                        string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=3&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                        Response.Redirect(_URL);
                        break;
                    }
            }
        }
        #endregion

        #region ��������
        private void SaveData()
        {
            //���������������
            if (step_id == 4 && Textbox1.Text.Trim() != string.Empty)
            {
                string cmdText = "insert into cxfz_yj values('" + doc_id + "', '" + _zgbh + "', '" + GetName(_zgbh) + "', '" + Textbox1.Text.Trim() + "', convert(varchar(20), getdate(), 120))";
                SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING);
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);//��ȡ��ǰ���̵ĵ�ǰ����󶨵�field
            if (dt_step_field.Rows.Count > 0)
            {
                FieldNum = dt_step_field.Rows[0][0].ToString().Split(';').Length;//��ȡ��ǰ���̵ĵ�ǰ����󶨵�field������
                Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
                string mySql;
                if (doc_id == 0)
                {
                    mySql = GetStyleInsertData();
                    //���
                    doc_id = df.AddDocument(_zgbh, flow_id, mySql, "�йس���:" + a.Text.ToString() + "�Ź��ĵ�����");
                    df = null;
                }
                else
                {
                    mySql = GetStyleUpdateData(doc_id);
                    df.UpdateDocument(mySql);
                    df = null;
                }
                UpdataTitle();
                if (step_id == 1)
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
                mySql += dt_step_field.Rows[0][0].ToString().Split(';')[i] + ",";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ") values(";
            for (int i = 0; i < FieldNum; i++)
            {
                string field_name = dt_step_field.Rows[0][0].ToString().Split(';')[i];
                string field_text = (field_name == "s" ? Server.HtmlEncode(GetControlText(field_name) + Textbox1.Text + "<br />") : GetControlText(field_name));
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
                    string field_name = dt_step_field.Rows[0][0].ToString().Split(';')[i];
                    string field_text = (field_name == "s" ? Server.HtmlEncode(GetControlText(field_name) + "<br />" + Textbox1.Text) : GetControlText(field_name));
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
                    return ((TextBox)StyleControl).Text.Trim();
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text.Trim();
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedItem.Text.ToString().Trim();
                default:
                    return null;
            }
        }
        #endregion

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
            this.cxwh_Btn.Click += new System.EventHandler(this.cxwh_Btn_Click);
            this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
            this.yxwh_Btn.Click += new System.EventHandler(this.yxwh_Btn_Click);
            this.LinkButton2.Click += new System.EventHandler(this.LinkButton2_Click);
            this.BtnTj.Click += new System.EventHandler(this.BtnTj_Click);
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnQx.Click += new System.EventHandler(this.BtnQx_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BtnTj_Click(object sender, System.EventArgs e)
        {
            Manage();//�����ύ
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            SaveData();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void BtnQx_Click(object sender, System.EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                Delete();
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
            {
                Response.Redirect("../Workflow/Work_Record.aspx");
            }
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void cxwh_Btn_Click(object sender, System.EventArgs e)
        {
            SaveData();
            Response.Redirect("wdk_xz_select.aspx?type=1&doc_id=" + doc_id);
        }

        private void yxwh_Btn_Click(object sender, System.EventArgs e)
        {
            SaveData();
            Response.Redirect("wdk_xz_select.aspx?type=2&doc_id=" + doc_id);
        }

        private void LinkButton1_Click(object sender, System.EventArgs e)
        {
            if (y.Text.Trim() == string.Empty)
            {
                return;
            }
            if (LinkButton1.Text == "�鿴����")
            {
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select dbo.f_getGwAttach('" + y.Text + "') from gw_doc where doc_fileid = " + y.Text;
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                AttachList1.DataSource = dt.Rows[0][0].ToString() + "0��ͨ�ļ�";
                AttachList1.DataBind();
                LinkButton1.Text = "���𸽼��б�";
                cx_attach_row.Visible = true;
                conn.Close();
            }
            else
            {
                LinkButton1.Text = "�鿴����";
                cx_attach_row.Visible = false;
            }
        }

        private void LinkButton2_Click(object sender, System.EventArgs e)
        {
            if (z.Text.Trim() == string.Empty)
            {
                return;
            }
            if (LinkButton2.Text == "�鿴����")
            {
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select dbo.f_getGwAttach('" + z.Text + "') from gw_doc where doc_fileid = " + z.Text;
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                AttachList2.DataSource = dt.Rows[0][0].ToString() + "0��ͨ�ļ�";
                AttachList2.DataBind();
                LinkButton2.Text = "���𸽼��б�";
                yx_attach_row.Visible = true;
                conn.Close();
            }
            else
            {
                LinkButton2.Text = "�鿴����";
                yx_attach_row.Visible = false;
            }
        }
    }
}
