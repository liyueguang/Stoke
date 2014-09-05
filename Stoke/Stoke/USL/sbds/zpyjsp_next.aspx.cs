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
using Stoke.BLL;
using Stoke.DAL;
using Stoke.COMMON;

namespace Stoke.USL.sbds
{
    public partial class zpyjsp_next : System.Web.UI.Page
    {
        protected string obj_zgbh;
        protected string _next_step;
        protected string _flow_id;
        protected string _step_id;
        protected string _doc_id;
        protected string _zgbh;
        protected string _step_remark;
        protected string _remark;
        protected int count = 0;
        private string UserDept;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (Session["zgbh"] != null)//09/08/09 wy
                _zgbh = Request["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");//

            _flow_id = Request["flow_id"].ToString();
            _step_id = Request["step_id"].ToString();
            _doc_id = Request["doc_id"].ToString();
            obj_zgbh = this.labObjZgbh.Text;
            Stoke.Components.Staff _staff = new Stoke.Components.Staff();
            DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
            UserDept = dt_xm_bm.Rows[0][1].ToString().Trim();

            if (!IsPostBack)
            {
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                string sqlStr = "select * from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int _remark = 0;
                if (dr.Read())
                    _remark = Convert.ToInt32(dr["step_remark"]);
                dr.Close();
                conn.Close();
                if (_remark == 1) // huiqian
                {
                    sqlStr = "select Obj_ID,IsRunning,Obj_Type from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
                    cmd = new SqlCommand(sqlStr, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    string _obj_id = null;
                    int _isrunning = 0;
                    string _obj_type = null;
                    if (dr.Read())
                    {
                        _obj_id = dr["Obj_ID"].ToString();
                        _isrunning = Convert.ToInt32(dr["IsRunning"]);
                        _obj_type = dr["Obj_Type"].ToString();
                    }
                    dr.Close();
                    conn.Close();
                    _isrunning--;
                    if (_isrunning != 0)
                    {
                        int position = _obj_id.IndexOf(_zgbh.Trim());
                        string temp = null;
                        if (position + 4 != _obj_id.Length)
                            temp = _obj_id.Substring(0, position) + _obj_id.Substring(position + 5);
                        else
                            temp = _obj_id.Substring(0, position - 1);
                        sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = '" + _isrunning + "', Obj_ID = '" + temp + "' where Doc_ID = '" + _doc_id + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        sqlStr = "select Step_Next from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        string _sn = null;
                        _sn = cmd.ExecuteScalar().ToString();
                        conn.Close();
                        sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = 0,Step_ID = '" + _sn + "',Obj_ID = '" + _obj_type + "',Obj_Type = null where Doc_ID = '" + _doc_id + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    SaveProc();
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }
                else
                {
                    conn.Open();
                    sqlStr = "select * from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
                    cmd = new SqlCommand(sqlStr, conn);
                    dr = cmd.ExecuteReader();
                    string _step_next = null;
                    if (dr.Read())
                        _step_next = dr["Step_Next"].ToString();
                    dr.Close();
                    conn.Close();
                    if (_step_next.Length != 0)
                    {
                        string temp = null;
                        for (int i = 0; i < _step_next.Length; i++)
                        {
                            if (_step_next[i] != ';')
                                temp += _step_next[i];
                            else
                            {
                                if (temp == "-1")
                                {
                                    ListItem tmplist = new ListItem("����", "-1");
                                    RadioButtonList1.Items.Add(tmplist);
                                }
                                else
                                {
                                    oper(temp);

                                }
                                temp = null;//20090606 wy �󶨲�������
                            }
                        }
                        if (temp != null)
                        {
                            if (temp == "-1")
                            {
                                ListItem tmplist = new ListItem("����", "-1");
                                RadioButtonList1.Items.Add(tmplist);
                            }
                            else
                                oper(temp);
                        }


                    }
                }

                if (this._step_id == "2")//������������2�򣬲��Ÿ����˸������ѡ��ֹ��쵼��������񲿳�����
                {
                    this.RadioButtonList1.Items.Clear();
                    ListItem item = new ListItem("�˻ؾ�����", "1");//���ؾ�����hhw20101105
                    if (JudgeMoney() == 0 && JudgeYsqr())//���ʽ��С��2�򣬾���Ԥ��ȷ��,hh20101106
                    {
                        this.RadioButtonList1.Items.Add(item);
                        item = new ListItem("�ֹ��쵼����", "4");
                        this.RadioButtonList1.Items.Add(item);
                        item = new ListItem("���񲿳�����", "5");
                        this.RadioButtonList1.Items.Add(item);
                    }
                    else //Ԥ��ȷ��
                    {
                        this.RadioButtonList1.Items.Add(item);
                        item = new ListItem("Ԥ��ȷ��", "3");//Ԥ��ȷ��
                        this.RadioButtonList1.Items.Add(item);
                    }
                }

                if (this._step_id == "3" && JudgeMoney() == 0)//������������2����Ԥ��ȷ�Ϻ���뷵�ظ����Ÿ����ˣ������˻ز��Ÿ�����
                {
                    this.RadioButtonList1.Items.Clear();
                    ListItem item = new ListItem("�˻ؾ�����", "1");//�˻ز��Ÿ�����hhw20101110
                    this.RadioButtonList1.Items.Add(item);
                    item = new ListItem("���ز���\\��Ŀ������", "2");
                    this.RadioButtonList1.Items.Add(item);
                    //					this.RadioButtonList1.Items[0].Selected=true; //�����˻ص����Ÿ�����,���ز��Ÿ����˲���Ĭ�ϵ�hhw20101110
                    //					SetInit(); //ע�͵��������˻ص����Ÿ����ˣ����ز��Ÿ����˲���Ĭ�ϵ�hhw20101110
                }

                if (this._step_id == "3" && JudgeMoney() != 0)//�������ʴ���2����Ԥ��ȷ�Ϻ�ֱ��ת���ֹ��쵼
                {
                    this.RadioButtonList1.Items.Clear();
                    //���ز��Ÿ�����hhw20101105
                    ListItem item = new ListItem("�˻ز��Ÿ�����", "2");
                    this.RadioButtonList1.Items.Add(item);
                    item = new ListItem("�ֹ��쵼����", "4");
                    this.RadioButtonList1.Items.Add(item);
                }

                //�����ж���������С��2�򣬾�Ԥ��ȷ�Ϻ��ɷֹ��쵼ֱ��ת�����񲿳�hhw20101030
                if (this._step_id == "4" && JudgeMoney() == 0)//��������С��2����Ԥ��ȷ�Ϻ�ֱ��ת���ֹ��쵼���ֹ��쵼��ת�����񲿳�
                {
                    this.RadioButtonList1.Items.Clear();
                    //�ֹ��쵼���Է��ز��Ÿ�����hhw20101105
                    ListItem item = new ListItem("�˻ز��Ÿ�����", "2");
                    this.RadioButtonList1.Items.Add(item);
                    //					SetInit2();
                    //					return;
                    //ת�����񲿳�
                    item = new ListItem("���񲿳�����", "5");
                    this.RadioButtonList1.Items.Add(item);
                    this.obj_zgbh = "0012";
                    this.labObjZgbh.Text = "0012";
                    this.obj.Text = "���ø�";
                    this.fieldset2.Visible = false;
                }


                //�������ʴ���2����Ԥ��ȷ�Ϻ�ת�ֹ��쵼���ֹ��쵼ת������hhw20101030
                if (this._step_id == "4" && JudgeMoney() > 0)//�������ʴ���2����Ԥ��ȷ�Ϻ�ֱ��ת���ֹ��쵼���ֹ��쵼��ת��������
                {
                    this.RadioButtonList1.Items.Clear();
                    //���ز��Ÿ�����hhw20101105
                    ListItem item = new ListItem("�˻ز��Ÿ�����", "2");
                    this.RadioButtonList1.Items.Add(item);
                    item = new ListItem("����������", "6");
                    this.RadioButtonList1.Items.Add(item);
                    //					this.obj_zgbh="0012";//hhw20101030
                    //					this.labObjZgbh.Text="0012";//hhw20101030
                    //					this.obj.Text="���ø�";//hhw20101030
                    //					this.fieldset2.Visible=false;//ѡ����һ����Աhhw20101030
                }

                //����񲿳�ת�����ɣ������˻ز��Ÿ�����
                if (this._step_id == "5")
                {
                    this.RadioButtonList1.Items.Clear();
                    ListItem item = new ListItem("�˻ز��Ÿ�����", "2");
                    this.RadioButtonList1.Items.Add(item);
                    item = new ListItem("���ɰ�����", "8");
                    this.RadioButtonList1.Items.Add(item);
                }
                //���������2��С��10�����ɲ�����ת���񲿳�������ע��hhw20101030
                //				if(this._step_id=="5"&&JudgeMoney()==1)//��������2��С��10������񲿳���ֱ��ת������
                //				{
                //					this.RadioButtonList1.Items.Clear();
                //					ListItem item=new ListItem("����������","6");
                //					this.RadioButtonList1.Items.Add(item);
                //				}

                //����ע��hhw20101030
                //				if(this._step_id=="5"&&JudgeMoney()==2)//��������10�����ɲ��񲿳�ת��������hhw20101030
                //				{
                //					this.RadioButtonList1.Items.Clear();
                //					ListItem item=new ListItem("����������","6");
                //					this.RadioButtonList1.Items.Add(item);
                //				}
                //���������� hhw20101106
                if (this._step_id == "6")
                {
                    this.RadioButtonList1.Items.Clear();
                    //���ز��Ÿ�����hhw20101106
                    ListItem item = new ListItem("�˻ز��Ÿ�����", "2");
                    this.RadioButtonList1.Items.Add(item);
                    if (JudgeMoney() == 2) //��������10�����ɲ�����ת���ܾ������� hhw20101030
                    {
                        item = new ListItem("�ܾ�������", "7");
                        this.RadioButtonList1.Items.Add(item);
                        this.obj_zgbh = "1001";
                        this.labObjZgbh.Text = "1001";
                        this.obj.Text = "Ҧ����";
                        this.fieldset2.Visible = false;
                    }
                    else //��������£�ֱ���ɲ�����ת���񲿳�����
                    {
                        item = new ListItem("���񲿳�����", "5");
                        this.RadioButtonList1.Items.Add(item);
                        this.obj_zgbh = "0012";
                        this.labObjZgbh.Text = "0012";
                        this.obj.Text = "���ø�";
                        this.fieldset2.Visible = false;
                    }
                }
                //�ܾ�������
                if (this._step_id == "7")
                {
                    this.RadioButtonList1.Items.Clear();
                    //���ز��Ÿ�����hhw20101106
                    ListItem item = new ListItem("�˻ز��Ÿ�����", "2");
                    this.RadioButtonList1.Items.Add(item);
                    item = new ListItem("���񲿳�����", "5");
                    this.RadioButtonList1.Items.Add(item);
                    this.obj_zgbh = "0012";
                    this.labObjZgbh.Text = "0012";
                    this.obj.Text = "���ø�";
                    this.fieldset2.Visible = false;
                }
            }
        }


        /// <summary>
        /// �ж��Ƿ񾭹�Ԥ��ȷ�ϲ���
        /// </summary>
        /// <returns></returns>
        private bool JudgeYsqr()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "select c1 from dsoc_flow_style_data where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            object result = cmd.ExecuteScalar();
            if (result.ToString() != string.Empty)
                return true;
            else
                return false;
        }


        /// <summary>
        /// ���ò��Ÿ�����
        /// </summary>
        private void SetInit()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "select v,ry_zgbh from dsoc_flow_style_data,dsoc_ry where Doc_ID = '" + _doc_id + "' and ry_xm like rtrim(v)";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.obj_zgbh = dr["ry_zgbh"].ToString();
                this.labObjZgbh.Text = dr["ry_zgbh"].ToString();
                this.obj.Text = dr["v"].ToString();
            }
            this.fieldset2.Visible = false;
            return;
        }

        private void SetInit2()
        {
            if (Judge4())
            {
                this.obj_zgbh = "0058";
                this.labObjZgbh.Text = "0058";
                this.obj.Text = "������";
            }
            else
            {
                //����������������ţ���ѡ���ų��������ֹ��� ��Ϊ�����˵ĸ�����hhw20101214
                //���������������Ŀ����ѡ����Ŀ���� ��Ϊ�����˵ĸ�����hhw201012114
                //-----start-----
                string flag = null; //��־λ����־������Ŀ���߲���
                string connStr = StokeGlobals.Connectiondsoc;
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                string sql = "select bm_xmz from dsoc_bm,dsoc_flow_style_data where dsoc_flow_style_data.Doc_ID ='" + this._doc_id + "' and rtrim(dsoc_bm.bm_mc) like rtrim(dsoc_flow_style_data.a)";
                SqlCommand scmd = new SqlCommand(sql, con);
                SqlDataReader dReader = scmd.ExecuteReader();
                if (dReader.Read())
                {
                    flag = dReader["bm_xmz"].ToString();
                }
                dReader.Close();
                scmd.Dispose();
                con.Close();
                con.Dispose();
                //-----end-----

                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                //				string sqlStr = "select ry_xm,ry_zgbh,zw_flag from dsoc_ry,dsoc_zw,dsoc_flow_style_data where ry_bm like rtrim(a) and (ry_zw like '%����%' or ry_zw like '%���ֹ���%' or ry_zw like '%��Ŀ����%') and (zw_flag=3) and dsoc_zw.zw_mc=dsoc_ry.ry_zw and doc_id='"+this._doc_id+"'";
                //���������������ֻ��һ�������˵�����hhw20101207
                string sqlStr = null;
                if (flag == "0")
                {
                    sqlStr = "select ry_zgbh,ry_xm,dsoc_zw.zw_flag from dsoc_flow_style_data,dsoc_ry,dsoc_zw where Doc_ID ='" + this._doc_id + "' and rtrim(ry_bm) like rtrim(a) and (ry_zw like '����%' or ry_zw like '%���ֹ���%' ) and dsoc_zw.zw_mc=dsoc_ry.ry_zw and zw_flag=3 ";
                }
                else if (flag == "1")
                {
                    sqlStr = "select ry_zgbh,ry_xm,dsoc_zw.zw_flag from dsoc_flow_style_data,dsoc_ry,dsoc_zw where Doc_ID ='" + this._doc_id + "' and rtrim(ry_bm) like rtrim(a) and (ry_zw = '��Ŀ����' ) and dsoc_zw.zw_mc=dsoc_ry.ry_zw and zw_flag=3 ";
                }
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.obj_zgbh = dr["ry_zgbh"].ToString();
                    this.labObjZgbh.Text = dr["ry_zgbh"].ToString();
                    this.obj.Text = dr["ry_xm"].ToString();
                }
            }
            this.fieldset2.Visible = false;
            return;
        }

        private bool Judge4()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "select a from dsoc_flow_style_data where doc_id='" + this._doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            string result = cmd.ExecuteScalar().ToString().Trim();
            if (result == "����")
                return true;
            else
                return false;
        }

        protected void oper(string temp)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "select Step_Name from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + temp + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string _next_step_name = null;
            if (dr.Read())
                _next_step_name = dr["Step_Name"].ToString();
            if (Convert.ToInt32(temp) < Convert.ToInt32(_step_id))
                _next_step_name = "�˻�" + _next_step_name;
            dr.Close();
            conn.Close();
            ListItem tmplist = new ListItem(_next_step_name, temp);
            RadioButtonList1.Items.Add(tmplist);
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
            this.RadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        //ѡ����һ���谴ťhhw20101104
        private void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this._step_id == "1")
            {
                SetInit2();
                return;
            }
            _next_step = RadioButtonList1.SelectedItem.Value.ToString();
            //			//�ֹ��쵼�˻ز��Ÿ�����hhw20101104
            //			if(this._step_id=="4"&&_next_step=="2")
            //			{
            //				SetInit2();
            //				return;
            //			}
            if (_next_step == "5")
            {
                this.obj_zgbh = "0012";
                this.labObjZgbh.Text = "0012";
                this.obj.Text = "���ø�";
                this.fieldset2.Visible = false;
                return;
            }
            if (_next_step == "7")
            {
                this.obj_zgbh = "1001";
                this.labObjZgbh.Text = "1001";
                this.obj.Text = "Ҧ����";
                this.fieldset2.Visible = false;
                return;
            }
            //���ɲ��裬���������ͽ���hhw20101104
            if (_next_step == "8")
            {
                this.obj_zgbh = "0076,0100"; //����,����
                this.labObjZgbh.Text = "0076,0100";
                this.obj.Text = "����,����";
                this.fieldset2.Visible = false;
                return;
            }
            //���˲��裬���������ͽ��� hhw20101104
            if (_next_step == "9")
            {
                this.obj_zgbh = "0076,0100"; //����,����
                this.labObjZgbh.Text = "0076,0100";
                this.obj.Text = "����,����";
                this.fieldset2.Visible = false;
                return;
            }
            if (_next_step == "2")
            {
                SetInit();
                return;
            }

            obj.Text = "��";
            if (_next_step != "-1")
            {
                if (fieldset2.Visible == false)
                    fieldset2.Visible = true;
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                string sqlStr = "select Step_Remark from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _next_step + "' ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                _step_remark = cmd.ExecuteScalar().ToString();
                conn.Close();
                if (_next_step == "1")
                {
                    if (SlctMember1.Visible == true)
                    {
                        SlctMember1.Visible = false;
                        LB_All.Visible = true;
                    }
                    SlctMember1.Visible = false;
                    LB_All.Visible = true;
                    connString = StokeGlobals.Connectiondsoc;
                    conn = new SqlConnection(connString);
                    conn.Open();
                    sqlStr = "select distinct dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                    cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    LB_All.DataSource = dr;
                    LB_All.DataTextField = "ry_xm";
                    LB_All.DataValueField = "Doc_Builder_ID";
                    LB_All.DataBind();
                    LB_All.SelectedIndex = 0;
                    dr.Close();
                    conn.Close();
                }
                else
                {
                    if (_step_remark == "0")
                    {
                        if (SlctMember1.Visible == true)
                        {
                            SlctMember1.Visible = false;
                            LB_All.Visible = true;
                        }
                        sqlStr = "select Dsoc_Flow_Member_Bind.Obj_ID from Dsoc_Flow_Member_Bind where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        string _reyuan = null;
                        if (dr.Read())
                            _reyuan = dr["Obj_ID"].ToString();
                        dr.Close();
                        conn.Close();
                        if (_reyuan == "builder")
                        {
                            sqlStr = "select distinct dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                            cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            dr = cmd.ExecuteReader();
                            LB_All.DataSource = dr;
                            LB_All.DataTextField = "ry_xm";
                            LB_All.DataValueField = "Doc_Builder_ID";
                            LB_All.DataBind();
                            LB_All.SelectedIndex = 0;
                            dr.Close();
                            conn.Close();
                        }
                        else if (_reyuan == "selector")//��Ч����ѡ��09.5.22
                        {
                            if (SlctMember1.Visible == false)
                            {
                                SlctMember1.Visible = true;
                                LB_All.Visible = false;
                            }

                        }
                        else
                        {
                            sqlStr = "select dbo.Dsoc_Flow_Step.Flow_Rule from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _next_step + "'";
                            cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            dr = cmd.ExecuteReader();
                            string _rule = null;
                            if (dr.Read())
                                _rule = dr["Flow_Rule"].ToString();
                            dr.Close();
                            conn.Close();
                            if (_rule == "1")
                            {
                                //ͨ�������˻�ʱѡ������˵Ĳ��Ÿ����� 09/5/21
                                string _step_text = RadioButtonList1.SelectedItem.Text.ToString().Trim().Substring(0, 2);
                                if (_step_text == "�˻�")
                                {
                                    sqlStr = "select distinct dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                                    cmd = new SqlCommand(sqlStr, conn);
                                    conn.Open();
                                    string _builder = cmd.ExecuteScalar().ToString();
                                    conn.Close();

                                    sqlStr = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh and ry_bm in (select ry_bm from dbo.dsoc_ry where ry_zgbh = '" + _builder + "' )";
                                    cmd = new SqlCommand(sqlStr, conn);
                                    conn.Open();
                                    dr = cmd.ExecuteReader();
                                    LB_All.DataSource = dr;
                                    LB_All.DataTextField = "ry_xm";
                                    LB_All.DataValueField = "Obj_ID";
                                    LB_All.DataBind();
                                    LB_All.SelectedIndex = 0;
                                    dr.Close();
                                    conn.Close();

                                }
                                else
                                {


                                    //���Ա�������������ϵ���Աѡ���ų�����  09/5/4
                                    sqlStr = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh and ry_bm in (select ry_bm from dbo.dsoc_ry where ry_zgbh = '" + _zgbh + "' )";
                                    cmd = new SqlCommand(sqlStr, conn);
                                    conn.Open();
                                    dr = cmd.ExecuteReader();
                                    LB_All.DataSource = dr;
                                    LB_All.DataTextField = "ry_xm";
                                    LB_All.DataValueField = "Obj_ID";
                                    LB_All.DataBind();
                                    LB_All.SelectedIndex = 0;
                                    dr.Close();
                                    conn.Close();
                                }
                            }
                            else
                            {
                                sqlStr = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh";
                                cmd = new SqlCommand(sqlStr, conn);
                                conn.Open();
                                dr = cmd.ExecuteReader();
                                LB_All.DataSource = dr;
                                LB_All.DataTextField = "ry_xm";
                                LB_All.DataValueField = "Obj_ID";
                                LB_All.DataBind();
                                LB_All.SelectedIndex = 0;
                                dr.Close();
                                conn.Close();
                            }
                        }
                    }
                    else
                    {
                        if (SlctMember1.Visible == false)
                        {
                            SlctMember1.Visible = true;
                            LB_All.Visible = false;
                        }
                    }
                }
            }
            else
            {
                if (fieldset2.Visible == true)
                    fieldset2.Visible = false;
            }
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            //���ѡ��ʱ��̬�������� 09/5/4   wy
            js();
            if (_step_remark == "0")
            {
                if (this.LB_All.Visible == false)//�����Ч����ѡ����� 09/5/22  wy
                {
                    obj.Text = SlctMember1.Send[0].ToString();
                    //				obj_zgbh = SlctMember1.Send[1].ToString();
                    this.labObjZgbh.Text = SlctMember1.Send[1].ToString();
                    count = Convert.ToInt32(SlctMember1.Send[2]);
                }
                else
                {
                    obj.Text = LB_All.SelectedItem.Text.ToString().Trim();
                    //				obj_zgbh = LB_All.SelectedItem.Value.ToString();
                    this.labObjZgbh.Text = LB_All.SelectedItem.Value.ToString();
                }
            }
            else
            {
                obj.Text = SlctMember1.Send[0].ToString();
                //				obj_zgbh = SlctMember1.Send[1].ToString();
                this.labObjZgbh.Text = SlctMember1.Send[1].ToString();
                count = Convert.ToInt32(SlctMember1.Send[2]);
            }
        }

        protected bool verify(string _temp)
        {
            for (int i = 0; i < _temp.Split(',').Length; i++)
            {
                for (int j = i + 1; j < _temp.Split(',').Length; j++)
                {
                    if (_temp.Split(',')[i] == _temp.Split(',')[j])
                        return true;
                }
            }
            return false;
        }

        protected void sign()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select Obj_ID,IsRunning,Obj_Type from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string _obj_id = null;
            int _isrunning = 0;
            if (dr.Read())
            {
                _obj_id = dr["Obj_ID"].ToString();
                _isrunning = Convert.ToInt32(dr["IsRunning"]);
            }

            _obj_id += ","; //09/08/09 

            dr.Close();
            conn.Close();
            _isrunning--;
            if (_isrunning != 0)
            {
                string temp = null;

                //09/08/09
                temp = _obj_id.Replace(_zgbh.Trim() + ",", string.Empty);
                if (temp.Length > 0)
                    temp = temp.Remove(temp.Length - 1, 1);
                sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = '" + _isrunning + "', Obj_ID = '" + temp + "' where Doc_ID = '" + _doc_id + "'";
                cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = 0,Step_ID = -1,Obj_ID = null,Doc_Status = 1 where Doc_ID = '" + _doc_id + "'";
                cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        protected void js()
        {
            _next_step = RadioButtonList1.SelectedItem.Value.ToString();
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select * from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                _remark = dr["step_remark"].ToString();
            dr.Close();
            conn.Close();
            sqlStr = "select Step_Remark from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _next_step + "' ";
            cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            _step_remark = cmd.ExecuteScalar().ToString();
            conn.Close();

        }

        //���湤������ת���� hhw20101029
        private void SaveProc()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string involedPerson = this.obj.Text.Trim();
            string step_name = "��ǩ����";
            if (this.RadioButtonList1.Items.Count != 0)
                step_name = this.RadioButtonList1.SelectedItem.Text.ToString().Trim();
            string sqlStr = "select count(Order_ID) from dbo.Dsoc_Flow_Path where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar());
            temp++;
            sqlStr = "insert into Dsoc_Flow_Path values ('" + _doc_id + "', '" + _flow_id + "','" + _step_id + "','" + _zgbh + "','" + temp + "','" + System.DateTime.Now.ToString() + "','" + step_name + "','" + involedPerson + "')";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        private int JudgeMoney()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select d,h,l,p from dbo.Dsoc_Flow_Style_Data where doc_id='" + this._doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            float money1 = 0, money2 = 0, money3 = 0, money4 = 0;
            object obj1, obj2, obj3, obj4;
            if (dr.Read())
            {
                obj1 = dr["d"];
                obj2 = dr["h"];
                obj3 = dr["l"];
                obj4 = dr["p"];
                if (obj1.ToString() != string.Empty)
                    money1 = float.Parse(obj1.ToString());
                if (obj2.ToString() != string.Empty)
                    money2 = float.Parse(obj2.ToString());
                if (obj3.ToString() != string.Empty)
                    money3 = float.Parse(obj3.ToString());
                if (obj4.ToString() != string.Empty)
                    money4 = float.Parse(obj4.ToString());
            }
            dr.Close();
            conn.Close();
            if ((money1 - 1) < 0 && (money2 - 1) < 0 && (money3 - 1) < 0 && (money4 - 1) < 0)
                return -1;
            else if ((money1 - 1) < 20000 && (money2 - 1) < 20000 && (money3 - 1) < 20000 && (money4 - 1) < 20000)
                return 0;
            else if (((money1 + 1) > 20000 && (money1 + 1) < 100000) || ((money2 + 1) > 20000 && (money2 + 1) < 100000) || ((money3 + 1) > 20000 && (money3 + 1) < 100000) || ((money4 + 1) > 20000 && (money4 + 1) < 100000))
                return 1;
            else if (((money1 + 1) > 100000) || ((money2 + 1) > 100000) || ((money2 + 1) > 100000) || ((money2 + 1) > 100000))
                return 2;
            else return -2;
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == -1)
                CommHandler.Alert(Page, "��ѡ����һ���裡");
            else
            {
                js();
                _next_step = RadioButtonList1.SelectedItem.Value.ToString();
                if (_step_remark == "0")
                {
                    if (_next_step != "-1")
                    {
                        if (obj.Text != "��" && obj.Text != string.Empty)
                        {
                            string connString = StokeGlobals.Connectiondsoc;
                            SqlConnection conn = new SqlConnection(connString);
                            conn.Open();
                            string sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = '" + obj_zgbh + "' where Doc_ID = '" + _doc_id + "'";
                            if (Convert.ToInt32(_flow_id) == 32 && Convert.ToInt32(_step_id) == 8) //֧ƱԤ�����̣�����֧Ʊ��hhw20101028
                            {
                                sqlStr = sqlStr + "  insert into Dsoc_Flow_Document select Doc_ID,Doc_Builder_ID,Doc_Added_Date,Doc_Status,Flow_ID,Step_ID,IsRunning,Doc_Builder_ID,Obj_Type,Doc_Title,Doc_a,Doc_b,Doc_c From dsoc_flow_document WHERE Doc_ID= '" + _doc_id + "'";	//��dsoc_flow_document���в���һ��ͬ�������ݣ���obj_id��Ϊdoc_builder_id��ʵ�ֶԾ����˵����ѹ��ܣ����ڴ����У�hhw20101029
                            }
                            if (Convert.ToInt32(_flow_id) == 49 && Convert.ToInt32(_step_id) == 8) //�ֽ�Ԥ�����̣������ֽ�hhw20101030
                            {
                                sqlStr = sqlStr + "  insert into Dsoc_Flow_Document select Doc_ID,Doc_Builder_ID,Doc_Added_Date,Doc_Status,Flow_ID,Step_ID,IsRunning,Doc_Builder_ID,Obj_Type,Doc_Title,Doc_a,Doc_b,Doc_c From dsoc_flow_document WHERE Doc_ID= '" + _doc_id + "'";	//��dsoc_flow_document���в���һ��ͬ�������ݣ���obj_id��Ϊdoc_builder_id��ʵ�ֶԾ����˵����ѹ��ܣ����ڴ����У�hhw20101030
                            }
                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            SaveProc();
                            Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                        }
                        else
                            CommHandler.Alert(Page, "��ѡ����һ����Ա");
                    }
                    else
                    {
                        if (_remark == "2")
                            sign();
                        else
                        {
                            string connString = StokeGlobals.Connectiondsoc;
                            SqlConnection conn = new SqlConnection(connString);
                            conn.Open();
                            string sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = null,Doc_status = 1 where Doc_ID = '" + _doc_id + "'";

                            if (Convert.ToInt32(_flow_id) == 32 && Convert.ToInt32(_step_id) == 9) //֧ƱԤ�����̣�������˲�hhw20101028
                            {
                                sqlStr = "delete From dsoc_flow_document WHERE Doc_ID= '" + _doc_id + "' AND Doc_Builder_ID=Obj_ID  " + "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = null,Doc_status = 1 where Doc_ID = '" + _doc_id + "'";//֧ƱԤ�����̣���������ʱ��ת�����һ����ɾ�����Ѿ����˻����������doc_builder_id=obj_id��һ��������Ա��hhw20101029
                            }

                            if (Convert.ToInt32(_flow_id) == 49 && Convert.ToInt32(_step_id) == 9) //�ֽ�Ԥ�����̣�������˲�hhw20101030
                            {
                                sqlStr = "delete From dsoc_flow_document WHERE Doc_ID= '" + _doc_id + "' AND Doc_Builder_ID=Obj_ID  " + "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = null,Doc_status = 1 where Doc_ID = '" + _doc_id + "'";//֧ƱԤ�����̣���������ʱ��ת�����һ����ɾ�����Ѿ����˻����������doc_builder_id=obj_id��һ��������Ա��hhw20101030
                            }
                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        SaveProc(); //���湤������ת���� hhw20101029
                        //wyw ����ΰ��������ת��ҳ�棬�����Ľ�
                        //hhw20101110,���������̣�ֱ����ת����ע����������
                        //						if(_flow_id=="4")
                        //							Response.Redirect("../Staff/style_qjsp.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="5")
                        //							Response.Redirect("../Staff/style_xjsp.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="6")
                        //							Response.Redirect("../Staff/style_ygdlsp.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="7")
                        //							Response.Redirect("../Staff/style_ygddsp2.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="8")
                        //							Response.Redirect("../Staff/style_rzsx.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="9")
                        //							Response.Redirect("../Staff/style_zyzbsp.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="10")
                        //							Response.Redirect("../Staff/style_qzsp2.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="35")
                        //							Response.Redirect("../Staff/style_rstzd.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="36")
                        //							Response.Redirect("../Staff/style_gljsljxkh.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="37")
                        //							Response.Redirect("../Staff/style_jxkhcz.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else if(_flow_id=="39")
                        //							Response.Redirect("../Staff/style_gljsljxkh1.aspx?zgbh="+_zgbh+"&doc_id="+_doc_id+"&step_id="+_next_step);
                        //						else
                        Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                    }
                }
                else if (_step_remark == "2")
                {
                    if (_next_step != "-1")
                    {
                        string _obj_zgbh = SlctMember1.Send[1].ToString();
                        if (obj.Text.ToString() == "��")
                            Response.Write("<script>alert('��ѡ����Ա!')</script>");
                        else
                        {
                            if (_remark == "0")
                            {
                                int _count_temp = _obj_zgbh.Split(',').Length;
                                string connString = StokeGlobals.Connectiondsoc;
                                SqlConnection conn = new SqlConnection(connString);
                                conn.Open();
                                string sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',IsRunning = '" + _count_temp + "',Obj_ID = '" + obj_zgbh + "' where Doc_ID = '" + _doc_id + "'";
                                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            else if (_remark == "2")
                            {
                                string connString = StokeGlobals.Connectiondsoc;
                                SqlConnection conn = new SqlConnection(connString);
                                string sqlStr = "select Obj_ID,IsRunning from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
                                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                                conn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                string _obj_id = null;
                                int _count_temp = 0;
                                if (dr.Read())
                                {
                                    _obj_id = dr["Obj_ID"].ToString();
                                    _count_temp = Convert.ToInt32(dr["IsRunning"]);
                                }
                                dr.Close();
                                conn.Close();
                                _obj_id += "," + _obj_zgbh;
                                _count_temp += _obj_zgbh.Split(',').Length;
                                sqlStr = "update dbo.Dsoc_Flow_Document set Step_id = '" + _next_step + "',Obj_ID = '" + _obj_id + "',IsRunning = '" + _count_temp + "' where Doc_ID =  '" + _doc_id + "'";
                                cmd = new SqlCommand(sqlStr, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                sign();
                            }
                            SaveProc();
                            Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                        }
                    }
                    else
                    {
                        string connString = StokeGlobals.Connectiondsoc;
                        SqlConnection conn = new SqlConnection(connString);
                        conn.Open();
                        string sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = null,Doc_status = 1 where Doc_ID = '" + _doc_id + "'";
                        SqlCommand cmd = new SqlCommand(sqlStr, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        SaveProc();
                        Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                    }
                }
                else
                {
                    int count = Convert.ToInt32(SlctMember1.Send[2]);
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string _obj_type = _zgbh;
                    string sqlStr = "update dbo.Dsoc_Flow_Document set Step_ID = '" + _next_step + "',IsRunning = '" + count + "',Obj_ID='" + obj_zgbh + "',Obj_Type = '" + _obj_type + "' where Doc_ID = '" + _doc_id + "'";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    SaveProc();
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }
            }
        }
    }
}
