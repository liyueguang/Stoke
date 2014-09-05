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
using Stoke.DAL;
using System.Text.RegularExpressions;

namespace Stoke.USL.sbds
{
    public partial class ccsq : System.Web.UI.Page
    {
        private int step_id = 0;
        private int doc_id = 0;
        protected string _zgbh;
        protected string UserName;
        private string UserDept; //����
        private int flow_id = 45;
        private int FieldNum = 0;
        private bool bEditMode = false;

        //��ӡ ��¼WORD·��
        protected string wordUrl = "";
        protected string Word_ra;

        DataTable dt_step_field;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            //���Ա�����
            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();

            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);

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
                this.Table16.Visible = false;
                //ȡ��Ա������
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                UserName = dt_xm_bm.Rows[0][0].ToString();
                UserDept = dt_xm_bm.Rows[0][1].ToString();
                this.c.DataSource = dt_xm_bm;
                this.c.DataTextField = "ry_bm";
                this.c.DataValueField = "ry_bm";
                this.c.DataBind();

                LoadAllBm();//���ز���
                BindTravel();
                if (doc_id > 0)
                    Step_Handle_Data();//����doc_idȡ�õ�ǰdocument����������
                else
                {
                    //�Զ���д��ź�����
                    this.b.Text = System.DateTime.Now.ToLongDateString();
                }

                this.TD2.Visible = false;
                this.storeBtn.Visible = false;
                switch (step_id)
                {
                    case 0:
                        this.submitBtn.Enabled = false;
                        this.storeBtn.Enabled = false;
                        this.cancelBtn.Enabled = false;
                        this.k.Enabled = true;
                        break;
                    case 1:
                        this.a.Text = "Stoke-Travel-" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
                        this.b.Text = System.DateTime.Now.ToLongDateString();
                        this.d.Text = UserName;
                        this.e.Text = _zgbh;
                        this.g.ReadOnly = false;
                        this.j.ReadOnly = false;
                        this.k.ReadOnly = false;
                        this.l.ReadOnly = false;
                        //���깤�߼����볬�깤��ԭ��hhw20101031
                        //						this.s.ReadOnly=false;
                        //						this.t.ReadOnly=false;
                        this.TD2.Visible = true;
                        this.storeBtn.Visible = true;
                        this.personBtn.Enabled = true;
                        this.k.Enabled = true;
                        this.r.Enabled = true;
                        this.v.ReadOnly = false;//�绰 hhw20101031
                        break;
                    case 2:
                        this.f.Text = UserName;
                        this.f.ReadOnly = false;//���Ÿ����� hhw20101031
                        break;
                    case 3:
                        if (this.u.Text == string.Empty)
                            this.u.Text = UserName;
                        else
                            this.u.Text += "," + UserName;
                        this.u.BackColor = System.Drawing.Color.White;
                        this.u.ReadOnly = true;//���Ż�ǩʱ��ֻ��������
                        break;
                    case 4:
                        this.m.Text = UserName;
                        this.m.ReadOnly = false;
                        break;
                    case 5:
                        this.n.ReadOnly = false;//���񲿺�ʵ�����hhw20101031
                        this.o.Text = UserName;//���񲿳�����hhw20101031
                        this.o.ReadOnly = false;
                        break;
                    //����hhw20101031
                    case 6:
                        this.p.ReadOnly = false;//ƾ֤����
                        this.y.Text = UserName;//����
                        this.y.ReadOnly = false;
                        this.submitBtn.Enabled = true;
                        this.RequiredFieldValidator1.Enabled = false;
                        this.RequiredFieldValidator2.Enabled = false;
                        this.RequiredFieldValidator3.Enabled = false;
                        this.RequiredFieldValidator4.Enabled = false;
                        this.RequiredFieldValidator5.Enabled = false;
                        this.RegularExpressionValidator1.Enabled = false;
                        this.R2.Enabled = false;
                        this.RequiredFieldValidator6.Enabled = false;
                        //���ѽ����˼�ʱ�������Ǿ����˲鿴������ñ���ʹ���ť��ֻ�ܷ���hhw20101101
                        if (UserName.Trim() == this.d.Text.ToString().Trim())//�û����;�������ͬһ��������Ϊ�����û�������������˹��� //hhw20101029
                        {
                            this.submitBtn.Enabled = false; //�ύ���ܽ���hhw20101029
                            this.storeBtn.Enabled = false; //���湦�ܽ���hhw20101029
                            this.cancelBtn.Enabled = true;//���ع���hhw20101101
                            this.y.Text = null;//������Ϊ��							
                        }
                        break;
                    //����hhw20101031
                    case 7:
                        this.x.Text = UserName;//����ȷ��
                        this.x.ReadOnly = false;
                        this.submitBtn.Enabled = true;
                        this.RequiredFieldValidator1.Enabled = false;
                        this.RequiredFieldValidator2.Enabled = false;
                        this.RequiredFieldValidator3.Enabled = false;
                        this.RequiredFieldValidator4.Enabled = false;
                        this.RequiredFieldValidator5.Enabled = false;
                        this.RegularExpressionValidator1.Enabled = false;
                        this.R2.Enabled = false;
                        this.RequiredFieldValidator6.Enabled = false;
                        //						//���ѽ����˼�ʱ�������Ǿ����˲鿴������ñ���ʹ���ť��ֻ�ܷ���hhw20101101
                        //						if(	UserName.Trim()==this.d.Text.ToString().Trim())//�û����;�������ͬһ��������Ϊ�����û�������������˹��� //hhw20101029
                        //						{
                        //							this.submitBtn.Enabled = false; //�ύ���ܽ���hhw20101029
                        //							this.storeBtn.Enabled = false; //���湦�ܽ���hhw20101029
                        //							this.cancelBtn.Enabled = true;//���ع���hhw20101101
                        //							this.x.Text=null;//������Ϊ��							
                        //						}
                        break;
                    case 8:
                        this.z.Text = UserName;//Ԥ��Ǽ�
                        this.z.ReadOnly = false;
                        this.RequiredFieldValidator1.Enabled = false;
                        this.RequiredFieldValidator2.Enabled = false;
                        this.RequiredFieldValidator3.Enabled = false;
                        this.RequiredFieldValidator4.Enabled = false;
                        this.RequiredFieldValidator5.Enabled = false;
                        this.RegularExpressionValidator1.Enabled = false;
                        this.R2.Enabled = false;
                        this.RequiredFieldValidator6.Enabled = false;
                        break;
                    default:
                        this.storeBtn.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.Ycsq.Select_Data_by_DocID(doc_id);
            this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
            this.b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
            this.c.DataSource = dt_style_data;
            this.c.DataTextField = "c";
            this.c.DataValueField = "c";
            this.c.DataBind();
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;//ְ�����hhw20101031
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;//���Ÿ��������hhw20101031
            this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
            this.h.Value = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
            this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
            this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
            this.m.Text = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : null;
            this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            //���깤�߼����볬�깤��ԭ��hhw20101031
            //			this.s.Text = dt_style_data.Rows[0]["s"].ToString()!=null ? dt_style_data.Rows[0]["s"].ToString():null;
            //			this.t.Text = dt_style_data.Rows[0]["t"].ToString()!=null ? dt_style_data.Rows[0]["t"].ToString():null;
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.p.Text = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : null;//ƾ֤���
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;//����
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;//����ȷ��
            this.z.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;//Ԥ��Ǽ�
            this.Word_ra = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
            if (this.step_id == 1)
            {
                BindTravel();
                for (int i = 0; i < this.i.Items.Count; i++)
                    if (this.i.Items[i].Text.ToString().Trim() == dt_style_data.Rows[0]["i"].ToString().Trim())
                    {
                        this.i.Items[i].Selected = true;
                        break;
                    }
            }
            else
            {
                this.i.DataSource = dt_style_data;
                this.i.DataValueField = "i";
                this.i.DataTextField = "i";
                this.i.DataBind();
            }

            if (this.step_id != 1)
            {
                string bmList = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
                if (bmList == string.Empty)
                {
                    this.r.DataSource = null;
                    this.r.DataBind();
                }
                else
                {
                    string[] list = bmList.Split(';');
                    this.r.DataSource = list;
                    this.r.DataTextField = string.Empty;
                    this.r.DataValueField = string.Empty;
                    this.r.DataBind();
                    for (int i = 0; i < list.Length; i++)
                        this.r.Items[i].Selected = true;
                }
            }
            else
            {
                LoadAllBm();
                string bmList = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
                if (bmList == string.Empty)
                {
                    this.r.DataSource = null;
                    this.r.DataBind();
                }
                else
                {
                    string[] list = bmList.Split(';');
                    for (int i = 0; i < list.Length; i++)
                        for (int j = 0; j < this.r.Items.Count; j++)
                        {
                            if (this.r.Items[j].Text.ToString().Trim() == list[i].Trim())
                            {
                                this.r.Items[j].Selected = true;
                                break;
                            }
                        }
                }
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
            this.BtnSD.Click += new System.EventHandler(this.BtnSD_Click);
            this.Button6.Click += new System.EventHandler(this.Button6_Click);
            this.personBtn.Click += new System.EventHandler(this.personBtn_Click);
            this.j.TextChanged += new System.EventHandler(this.j_TextChanged);
            this.n.TextChanged += new System.EventHandler(this.n_TextChanged);//���񲿺�ʵ��
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            this.storeBtn.Click += new System.EventHandler(this.storeBtn_Click);
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            //////////////////////////////////////////////////////////////
            this.Btn_print.Attributes.Add("onclick", "print_ccsq()");
            wordUrl = "http://" + Request.ServerVariables["SERVER_NAME"].ToString() + "/dsoc/USL/sbds/word/ccsq.doc";
            //////////////////////////////////////////////////////////////
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            string url = ViewState["UrlReferrer"].ToString();
            Response.Redirect(url);
        }

        private void submitBtn_Click(object sender, System.EventArgs e)
        {
            //������д���깤�߼����볬�깤��ԭ��ֱ���������б���ѡ��hhw20101031
            //			if(this.s.Text!=string.Empty&&this.t.Text==string.Empty)
            //			{
            //				Response.Write("<script>alert('���ѡ�񳬱꽻ͨ���ߣ�������д����ԭ��!')</script>");
            //				return;
            //			}
            //����ѡ�����Ľ�ͨ����hhw20101101
            if (step_id < 2 && this.i.SelectedItem.Text.ToString() == "-��ѡ��-")
            {
                Response.Write("<script>alert('��ѡ�����Ԥ������ͨ����!')</script>");
                return;
            }

            //�ж�Ԥ������Ч��
            float money = float.Parse(this.j.Text.ToString());
            if (!ValidateMoney(money))
            {
                Response.Write("<script>alert('�Բ���Ԥ������Ч!')</script>");
                return;
            }
            //			//����˴����,��ת������hhw20101105
            //			if(step_id==3)
            //			{
            //				
            //			}

            //����������ٵ�
            if (step_id == 4)
            {
                string zgbh1 = GetZgbh(this.d.Text.ToString().Trim()).Trim();
                if (this.q.Text != string.Empty)
                {
                    string ryxm = this.q.Text.ToString();
                    string[] list11 = ryxm.Split(',');
                    for (int i = 0; i < list11.Length; i++)
                        zgbh1 += "," + GetZgbh(list11[i]).Trim();
                }
                string[] list = zgbh1.Split(',');
                //hhw20101116 "����н��"�ĳ�"����"
                for (int i = 0; i < list.Length; i++)
                    if (!GetLeaveTable(list[i], "����", this.k.Text.ToString(), Int32.Parse(this.l.Text.ToString()), this.g.Text, this.m.Text.ToString(), System.DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        Response.Write("<script>alert('�Բ�������������ٵ���������ϵͳ����Ա��ϵ!')</script>");
                        return;
                    }
            }
            //���񲿱�����д�����ʵ�� hhw20101031
            if (step_id == 5 && this.n.Text == string.Empty)
            {
                Response.Write("<script>alert('����д���񲿺�ʵ�����')</script>");
                return;
            }
            //���ɱ�����дƾ֤���� hhw20101031
            if (step_id == 6 && this.p.Text == string.Empty)
            {
                Response.Write("<script>alert('����дƾ֤����')</script>");
                return;
            }
            //���������ֽ�Ԥ�赥hhw20101031
            //			//�����ֽ�Ԥ�赥
            //			if(step_id==6)
            //			{
            //				if((money-1>0)&&(!GetZpyjTable(money)))
            //				{
            //
            //					Response.Write("<script>alert('�Բ��������ֽ�Ԥ�赥��������ϵͳ����Ա��ϵ!')</script>");
            //					return;
            //				}
            //			}
            //��������
            SaveData();

            //���ѳ������뼰����˻���hhw20101101
            if (step_id == 6)
            {
                //�������뼰�������hhw20101101
                remendRepay();
            }
            //����˻����,��������hhw20101101
            if (step_id == 7)
            {
                //��������������hhw20101101
                delRemendRepay();
            }
            //			string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=45&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
            string _URL = "ccsq_Next_Step.aspx?flow_id=45&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
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
                //����������Ϊ�������뼰���hhw20101031
                //				doc_id = df.AddDocument(_zgbh,flow_id,mySql,this.d.Text.ToString()+"��"+this.h.Value.ToString()+"���������");//hhw20101031
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.d.Text.ToString().Trim() + "��" + this.h.Value.ToString() + "�������뼰�������");//��ȡ���ֿո�hhw20101109
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

        //�������뼰�������hhw20101101
        private void remendRepay()
        {
            string connString = StokeGlobals.Connectiondsoc;//����
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            doc_id = Convert.ToInt32(Request["doc_id"]);
            //��dsoc_flow_document���в���һ�����ݣ�obj_id=doc_builder_id���Դ����ѽ���˼�ʱ����
            string str = "INSERT INTO dsoc_flow_document SELECT Doc_ID,Doc_Builder_ID,Doc_Added_Date,Doc_Status,Flow_ID,Step_ID,IsRunning,Doc_Builder_ID,Obj_Type,Doc_Title,Doc_a,Doc_b,Doc_c FROM dsoc_flow_document WHERE Doc_ID=" + doc_id;
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();//ִ��
            conn.Close();
            conn.Dispose();
        }

        //��������������hhw20101101
        private void delRemendRepay()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //��dsoc_flow_document��ɾ������ʱ�����һ�����ݣ�ɾ������
            doc_id = Convert.ToInt32(Request["doc_id"]);
            string str = "delete From dsoc_flow_document WHERE Doc_ID= '" + doc_id + "' AND Doc_Builder_ID=Obj_ID ";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();//
            conn.Close();
            conn.Dispose();
        }

        public void UpdataZt()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //����������Ϊ�������뼰���hhw20101031
            //			string title=this.d.Text.ToString()+"��"+this.h.Value.ToString()+"���������!";//hhw20101031
            string title = this.d.Text.ToString() + "��" + this.h.Value.ToString() + "�������뼰�������";
            string str = "update dbo.Dsoc_Flow_Document set Doc_Title='" + title + "' where Doc_ID='" + doc_id + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
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
                case "System.Web.UI.HtmlControls.HtmlInputText":
                    return ((HtmlInputText)StyleControl).Value.ToString();
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text.Trim();
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedItem.Text.ToString().Trim();
                case "System.Web.UI.WebControls.RadioButton":
                    return ((RadioButton)StyleControl).Checked.ToString();
                case "System.Web.UI.WebControls.CheckBoxList":
                    StringBuilder result = new StringBuilder("");
                    CheckBoxList temp = (CheckBoxList)StyleControl;
                    for (int i = 0; i < temp.Items.Count; i++)
                        if (temp.Items[i].Selected)
                            result.Append(temp.Items[i].ToString() + ";");
                    if (result.ToString() != string.Empty)
                        return result.ToString().Substring(0, result.ToString().Length - 1);
                    else
                        return result.ToString();
                default:
                    return null;
            }
        }

        /// <summary>
        /// ��ȡERP�ӿ��ж�Ԥ�������Ч��
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        private bool ValidateMoney(float money)
        {
            return true;
        }

        /// <summary>
        /// ����������ٵ�
        /// </summary>
        /// <param name="paraList">������ٵ���������б�</param>
        /// <param name="n">��������</param>
        /// <returns></returns>
        private bool GetLeaveTable(string zgbh, string type, string date, int dayNum, string reason, string leader, string leadertime)
        {
            int workNum = dayNum;
            if (dayNum < 7)
                for (int i = 1; i <= dayNum; i++)
                {
                    if (((int)(DateTime.Parse(date).DayOfWeek) + i) % 7 == 6 || ((int)(DateTime.Parse(date).DayOfWeek) + i) % 7 == 0)
                        workNum--;
                }
            else
            {
                workNum = dayNum - dayNum / 7 * 2;
                for (int i = 1; i <= dayNum % 7; i++)
                {
                    if (((int)(DateTime.Parse(date).DayOfWeek) + i) % 7 == 6 || ((int)(DateTime.Parse(date).DayOfWeek) + i) % 7 == 0)
                        workNum--;
                }
            }
            try
            {
                Stoke.Components.Staff.insertNewQjFlow(zgbh, type, date, dayNum, workNum, reason, leader, leadertime);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// ����֧ƱԤ�赥
        /// </summary>
        /// <returns></returns>
        private bool GetZpyjTable(float money)
        {
            string sqlStr = "insert into DSOC_Flow_Style_Data (a,b,c,d,t) "
                + "values('" + this.c.SelectedItem.Text.ToString() + "','" + System.DateTime.Now.ToString() + "','����'," + money + ",'" + this.d.Text + "')";

            string obj_id = GetZgbh(this.d.Text.ToString());

            string spName = "sp_Flow_AddDocumentByStepID";
            string zgbh = GetZgbh(this.d.Text.ToString().Trim());
            object[] para = new object[] { obj_id, 49, 1, sqlStr, obj_id, this.d.Text.ToString().Trim() + "������ص��ֽ�Ԥ������" };
            Stoke.DAL.SQLHelper.ExecuteDataTable(spName, para);
            return true;
        }


        private string GetZgbh(string name)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "select ry_zgbh from dsoc_ry where ry_xm like '%" + name.ToString().Trim() + "%'";
            SqlCommand cmd = new SqlCommand(str, conn);
            string result = cmd.ExecuteScalar().ToString();
            conn.Close();
            conn.Dispose();
            return result;
        }

        private void storeBtn_Click(object sender, System.EventArgs e)
        {
            SaveData();
            UpdataZt();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void personBtn_Click(object sender, System.EventArgs e)
        {
            this.Table16.Visible = true;
        }

        private void Button6_Click(object sender, System.EventArgs e)
        {
            this.Table16.Visible = false;
        }

        private void BtnSD_Click(object sender, System.EventArgs e)
        {
            this.q.Text = this.SlctMember1.Send[0].ToString();
            this.Table16.Visible = false;
        }

        /// <summary>
        /// ���ز���
        /// </summary>
        private void LoadAllBm()
        {
            //��ʼ�������ַ���
            string str = SQLHelper.CONN_STRING;
            SqlConnection con = new SqlConnection(str);

            //�����к�ͬ�����б�ؼ�
            DataTable bmListTable = new DataTable();
            bmListTable = SQLHelper.ExecuteDataTable(con, System.Data.CommandType.Text, "select bm_bh,bm_mc from dsoc_bm order by bm_bh", null);
            this.r.DataSource = bmListTable;
            this.r.DataTextField = "bm_mc";
            this.r.DataValueField = "bm_bh";
            this.r.DataBind();
        }

        /// <summary>
        /// ����Ա��ְλ�󶨽�ͨ����
        /// </summary>
        private void BindTravel()
        {
            //��ʼ�������ַ���
            this.i.Items.Clear();
            string str = SQLHelper.CONN_STRING;
            SqlConnection con = new SqlConnection(str);

            //�����к�ͬ�����б�ؼ�
            string zw = SQLHelper.ExecuteScalar(con, System.Data.CommandType.Text, "select ry_zw from dsoc_ry where ry_zgbh like '%" + _zgbh.ToString().Trim() + "%'", null).ToString().Trim();
            //����ѡ����ݲ���Ҫ��ֱ��ѡ�񣬲���д���깤�ߣ�����ԭ������쵼���˼�����hhw20101031
            this.i.Items.Insert(0, "����");
            this.i.Items.Insert(0, "�ɻ���ͨ��");
            this.i.Items.Insert(0, "�ִ����Ȳ�");//hhw20101031
            this.i.Items.Insert(0, "�ִ����Ȳ�");
            this.i.Items.Insert(0, "����ϯ");//hhw20101031
            this.i.Items.Insert(0, "��Ӳϯ");
            this.i.Items.Insert(0, "����");//hhw20101031
            //����ע�ͱ�ʾ���ٸ���ְλѡ�����ߣ�������������ѡ��hhw2011031
            //			switch(zw)
            //			{
            //				case "�ܾ���":
            //				case "���ܾ���":
            //				case "�ܾ�������":
            //					this.i.Items.Insert(0,"����ϯ");
            //					this.i.Items.Insert(0,"�ִ����Ȳ�");
            //					this.i.Items.Insert(0,"�ɻ���ͨ��");
            //					break;
            //				case "���ž���":
            //				case "���Ÿ�����":
            //				case "����������Ա":
            //					this.i.Items.Remove("�ɻ���ͨ��");
            //					break;
            //				default: break;
            //			}
            this.i.Items.Insert(0, "-��ѡ��-");
        }

        private void j_TextChanged(object sender, System.EventArgs e)
        {
            //�жϺ�ͬ�������ʽ�Ƿ���ȷ
            string moneyRexStr = @"^[0-9]*[0-9][0-9]*$";
            Regex moneyReg = new Regex(moneyRexStr);
            if (moneyReg.IsMatch(this.j.Text.ToString()))
            {
                this.j.Text += ".00";
                return;
            }
            else
            {
                string moneyRexStr2 = @"^[0-9]\d*\.\d*|0\.\d*[0-9]\d*$";
                moneyReg = new Regex(moneyRexStr2);
                if (!moneyReg.IsMatch(this.j.Text.ToString()))
                {
                    Response.Write("<script>alert('�뱣֤Ԥ����÷ѽ�����Ϊ����������100.00�ĸ�������');</script>");
                    return;
                }
            }
        }

        //������񲿺�ʵ�����ĸ�ʽ�Ƿ���ȷhhw20101031
        private void n_TextChanged(object sender, System.EventArgs e)
        {
            string moneyRexStr = @"^[0-9]*[0-9][0-9]*$";
            Regex moneyReg = new Regex(moneyRexStr);
            if (moneyReg.IsMatch(this.n.Text.ToString()))
            {
                this.n.Text += ".00";
                return;
            }
            else
            {
                string moneyRexStr2 = @"^[0-9]\d*\.\d*|0\.\d*[0-9]\d*$";
                moneyReg = new Regex(moneyRexStr2);
                if (!moneyReg.IsMatch(this.n.Text.ToString()))
                {
                    Response.Write("<script>alert('���񲿺�ʵ���������Ϊ����������100.00�ĸ�ʽ��');</script>");
                    return;
                }
            }
        }
        /// <summary>
        /// �����Ա�б���ͬһ���ŵ���Ա
        /// </summary>
        /// <param name="zgbh"></param>
        public void GetBmList(string zgbh)
        {
            string[] zgbhList = zgbh.Split(',');
            string bm = string.Empty;
            Stoke.Components.Staff _staff = new Stoke.Components.Staff();
            System.Web.UI.WebControls.DropDownList temp = new DropDownList();
            for (int i = 0; i < zgbhList.Length; i++)
            {
                ListItem tempItem = new ListItem(zgbhList[i], _staff.GetXmBmZwByZdbh(zgbhList[i]).Rows[0][1].ToString());
                temp.Items.Add(tempItem);
            }
            while (temp.Items.Count > 0)
            {
                string zgbh_1 = temp.Items[0].Text.ToString();
                string bmTemp = temp.Items[0].Value.ToString();
                temp.Items.Remove(temp.Items[0]);
                while (temp.Items.FindByValue(bmTemp) != null)
                {
                    ListItem fff = temp.Items.FindByValue(bmTemp);
                    zgbh_1 += "," + fff.Text;
                    temp.Items.Remove(fff);
                }
            }
        }
    }
}
