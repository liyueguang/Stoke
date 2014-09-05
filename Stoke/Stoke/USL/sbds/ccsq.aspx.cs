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
        private string UserDept; //部门
        private int flow_id = 45;
        private int FieldNum = 0;
        private bool bEditMode = false;

        //打印 记录WORD路径
        protected string wordUrl = "";
        protected string Word_ra;

        DataTable dt_step_field;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            //获得员工编号
            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();

            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);

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
                this.Table16.Visible = false;
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                UserName = dt_xm_bm.Rows[0][0].ToString();
                UserDept = dt_xm_bm.Rows[0][1].ToString();
                this.c.DataSource = dt_xm_bm;
                this.c.DataTextField = "ry_bm";
                this.c.DataValueField = "ry_bm";
                this.c.DataBind();

                LoadAllBm();//加载部门
                BindTravel();
                if (doc_id > 0)
                    Step_Handle_Data();//根据doc_id取得当前document中已有数据
                else
                {
                    //自动填写编号和日期
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
                        //超标工具及申请超标工具原因hhw20101031
                        //						this.s.ReadOnly=false;
                        //						this.t.ReadOnly=false;
                        this.TD2.Visible = true;
                        this.storeBtn.Visible = true;
                        this.personBtn.Enabled = true;
                        this.k.Enabled = true;
                        this.r.Enabled = true;
                        this.v.ReadOnly = false;//电话 hhw20101031
                        break;
                    case 2:
                        this.f.Text = UserName;
                        this.f.ReadOnly = false;//部门负责人 hhw20101031
                        break;
                    case 3:
                        if (this.u.Text == string.Empty)
                            this.u.Text = UserName;
                        else
                            this.u.Text += "," + UserName;
                        this.u.BackColor = System.Drawing.Color.White;
                        this.u.ReadOnly = true;//部门会签时，只能填名字
                        break;
                    case 4:
                        this.m.Text = UserName;
                        this.m.ReadOnly = false;
                        break;
                    case 5:
                        this.n.ReadOnly = false;//财务部核实金额数hhw20101031
                        this.o.Text = UserName;//财务部长审批hhw20101031
                        this.o.ReadOnly = false;
                        break;
                    //出纳hhw20101031
                    case 6:
                        this.p.ReadOnly = false;//凭证号码
                        this.y.Text = UserName;//出纳
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
                        //提醒借款经办人及时还款，如果是经办人查看，则禁用保存和处理按钮，只能返回hhw20101101
                        if (UserName.Trim() == this.d.Text.ToString().Trim())//用户名和经办人是同一姓名，则为提醒用户还款，不具有销账功能 //hhw20101029
                        {
                            this.submitBtn.Enabled = false; //提交功能禁用hhw20101029
                            this.storeBtn.Enabled = false; //保存功能禁用hhw20101029
                            this.cancelBtn.Enabled = true;//返回功能hhw20101101
                            this.y.Text = null;//出纳名为空							
                        }
                        break;
                    //销账hhw20101031
                    case 7:
                        this.x.Text = UserName;//销账确认
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
                        //						//提醒借款经办人及时还款，如果是经办人查看，则禁用保存和处理按钮，只能返回hhw20101101
                        //						if(	UserName.Trim()==this.d.Text.ToString().Trim())//用户名和经办人是同一姓名，则为提醒用户还款，不具有销账功能 //hhw20101029
                        //						{
                        //							this.submitBtn.Enabled = false; //提交功能禁用hhw20101029
                        //							this.storeBtn.Enabled = false; //保存功能禁用hhw20101029
                        //							this.cancelBtn.Enabled = true;//返回功能hhw20101101
                        //							this.x.Text=null;//销账名为空							
                        //						}
                        break;
                    case 8:
                        this.z.Text = UserName;//预算登记
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
        /// 按步骤绑定数据
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
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;//职工编号hhw20101031
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;//部门负责人审核hhw20101031
            this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
            this.h.Value = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
            this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
            this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
            this.m.Text = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : null;
            this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            //超标工具及申请超标工具原因hhw20101031
            //			this.s.Text = dt_style_data.Rows[0]["s"].ToString()!=null ? dt_style_data.Rows[0]["s"].ToString():null;
            //			this.t.Text = dt_style_data.Rows[0]["t"].ToString()!=null ? dt_style_data.Rows[0]["t"].ToString():null;
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.p.Text = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : null;//凭证编号
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;//出纳
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;//销账确认
            this.z.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;//预算登记
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
            this.BtnSD.Click += new System.EventHandler(this.BtnSD_Click);
            this.Button6.Click += new System.EventHandler(this.Button6_Click);
            this.personBtn.Click += new System.EventHandler(this.personBtn_Click);
            this.j.TextChanged += new System.EventHandler(this.j_TextChanged);
            this.n.TextChanged += new System.EventHandler(this.n_TextChanged);//财务部核实数
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
            //不再填写超标工具及申请超标工具原因，直接在下拉列表中选择hhw20101031
            //			if(this.s.Text!=string.Empty&&this.t.Text==string.Empty)
            //			{
            //				Response.Write("<script>alert('如果选择超标交通工具，则请填写申请原因！!')</script>");
            //				return;
            //			}
            //必须选择出差的交通工具hhw20101101
            if (step_id < 2 && this.i.SelectedItem.Text.ToString() == "-请选择-")
            {
                Response.Write("<script>alert('请选择出差预乘坐交通工具!')</script>");
                return;
            }

            //判断预借金额有效性
            float money = float.Parse(this.j.Text.ToString());
            if (!ValidateMoney(money))
            {
                Response.Write("<script>alert('对不起，预借金额无效!')</script>");
                return;
            }
            //			//会鉴人处理后,跳转到待办hhw20101105
            //			if(step_id==3)
            //			{
            //				
            //			}

            //生成人事请假单
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
                //hhw20101116 "有事薪假"改成"公干"
                for (int i = 0; i < list.Length; i++)
                    if (!GetLeaveTable(list[i], "公干", this.k.Text.ToString(), Int32.Parse(this.l.Text.ToString()), this.g.Text, this.m.Text.ToString(), System.DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        Response.Write("<script>alert('对不起，生成人事请假单有误，请与系统管理员联系!')</script>");
                        return;
                    }
            }
            //财务部必须填写财务核实数 hhw20101031
            if (step_id == 5 && this.n.Text == string.Empty)
            {
                Response.Write("<script>alert('请填写财务部核实金额数')</script>");
                return;
            }
            //出纳必须填写凭证号码 hhw20101031
            if (step_id == 6 && this.p.Text == string.Empty)
            {
                Response.Write("<script>alert('请填写凭证号码')</script>");
                return;
            }
            //不再生成现金预借单hhw20101031
            //			//生成现金预借单
            //			if(step_id==6)
            //			{
            //				if((money-1>0)&&(!GetZpyjTable(money)))
            //				{
            //
            //					Response.Write("<script>alert('对不起，生成现金预借单有误，请与系统管理员联系!')</script>");
            //					return;
            //				}
            //			}
            //保存数据
            SaveData();

            //提醒出差申请及借款人还款hhw20101101
            if (step_id == 6)
            {
                //出差申请及借款提醒hhw20101101
                remendRepay();
            }
            //借款人还款后,消除提醒hhw20101101
            if (step_id == 7)
            {
                //出差还款后，消除提醒hhw20101101
                delRemendRepay();
            }
            //			string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=45&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
            string _URL = "ccsq_Next_Step.aspx?flow_id=45&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
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
                //出差报销申请改为出差申请及借款hhw20101031
                //				doc_id = df.AddDocument(_zgbh,flow_id,mySql,this.d.Text.ToString()+"到"+this.h.Value.ToString()+"出差报销申请");//hhw20101031
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.d.Text.ToString().Trim() + "到" + this.h.Value.ToString() + "出差申请及借款审批");//截取名字空格hhw20101109
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

        //出差申请及借款提醒hhw20101101
        private void remendRepay()
        {
            string connString = StokeGlobals.Connectiondsoc;//连接
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            doc_id = Convert.ToInt32(Request["doc_id"]);
            //在dsoc_flow_document表中插入一条数据，obj_id=doc_builder_id，以此提醒借款人及时还款
            string str = "INSERT INTO dsoc_flow_document SELECT Doc_ID,Doc_Builder_ID,Doc_Added_Date,Doc_Status,Flow_ID,Step_ID,IsRunning,Doc_Builder_ID,Obj_Type,Doc_Title,Doc_a,Doc_b,Doc_c FROM dsoc_flow_document WHERE Doc_ID=" + doc_id;
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();//执行
            conn.Close();
            conn.Dispose();
        }

        //出差还款后，消除提醒hhw20101101
        private void delRemendRepay()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //在dsoc_flow_document中删除出纳时插入的一条数据，删除提醒
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
            //出差报销申请改为出差申请及借款hhw20101031
            //			string title=this.d.Text.ToString()+"到"+this.h.Value.ToString()+"出差报销申请!";//hhw20101031
            string title = this.d.Text.ToString() + "到" + this.h.Value.ToString() + "出差申请及借款审批";
            string str = "update dbo.Dsoc_Flow_Document set Doc_Title='" + title + "' where Doc_ID='" + doc_id + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
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
        /// 读取ERP接口判断预借金额的有效性
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        private bool ValidateMoney(float money)
        {
            return true;
        }

        /// <summary>
        /// 生成人事请假单
        /// </summary>
        /// <param name="paraList">人事请假单所需参数列表</param>
        /// <param name="n">参数个数</param>
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
        /// 生成支票预借单
        /// </summary>
        /// <returns></returns>
        private bool GetZpyjTable(float money)
        {
            string sqlStr = "insert into DSOC_Flow_Style_Data (a,b,c,d,t) "
                + "values('" + this.c.SelectedItem.Text.ToString() + "','" + System.DateTime.Now.ToString() + "','出差'," + money + ",'" + this.d.Text + "')";

            string obj_id = GetZgbh(this.d.Text.ToString());

            string spName = "sp_Flow_AddDocumentByStepID";
            string zgbh = GetZgbh(this.d.Text.ToString().Trim());
            object[] para = new object[] { obj_id, 49, 1, sqlStr, obj_id, this.d.Text.ToString().Trim() + "出差相关的现金预借申请" };
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
        /// 加载部门
        /// </summary>
        private void LoadAllBm()
        {
            //初始化连接字符串
            string str = SQLHelper.CONN_STRING;
            SqlConnection con = new SqlConnection(str);

            //绑定已有合同类型列表控件
            DataTable bmListTable = new DataTable();
            bmListTable = SQLHelper.ExecuteDataTable(con, System.Data.CommandType.Text, "select bm_bh,bm_mc from dsoc_bm order by bm_bh", null);
            this.r.DataSource = bmListTable;
            this.r.DataTextField = "bm_mc";
            this.r.DataValueField = "bm_bh";
            this.r.DataBind();
        }

        /// <summary>
        /// 根据员工职位绑定交通工具
        /// </summary>
        private void BindTravel()
        {
            //初始化连接字符串
            this.i.Items.Clear();
            string str = SQLHelper.CONN_STRING;
            SqlConnection con = new SqlConnection(str);

            //绑定已有合同类型列表控件
            string zw = SQLHelper.ExecuteScalar(con, System.Data.CommandType.Text, "select ry_zw from dsoc_ry where ry_zgbh like '%" + _zgbh.ToString().Trim() + "%'", null).ToString().Trim();
            //以下选项根据财务部要求，直接选择，不再写超标工具，超标原因，如果领导批了即能坐hhw20101031
            this.i.Items.Insert(0, "其他");
            this.i.Items.Insert(0, "飞机普通舱");
            this.i.Items.Insert(0, "轮船二等舱");//hhw20101031
            this.i.Items.Insert(0, "轮船三等舱");
            this.i.Items.Insert(0, "火车软席");//hhw20101031
            this.i.Items.Insert(0, "火车硬席");
            this.i.Items.Insert(0, "动车");//hhw20101031
            //以下注释表示不再根据职位选择出差工具，而是由申请人选择hhw2011031
            //			switch(zw)
            //			{
            //				case "总经理":
            //				case "副总经理":
            //				case "总经理助理":
            //					this.i.Items.Insert(0,"火车软席");
            //					this.i.Items.Insert(0,"轮船二等舱");
            //					this.i.Items.Insert(0,"飞机普通舱");
            //					break;
            //				case "部门经理":
            //				case "部门副经理":
            //				case "各级主管人员":
            //					this.i.Items.Remove("飞机普通舱");
            //					break;
            //				default: break;
            //			}
            this.i.Items.Insert(0, "-请选择-");
        }

        private void j_TextChanged(object sender, System.EventArgs e)
        {
            //判断合同具体金额格式是否正确
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
                    Response.Write("<script>alert('请保证预借差旅费金额必须为整数或类如100.00的浮点数！');</script>");
                    return;
                }
            }
        }

        //检验财务部核实额数的格式是否正确hhw20101031
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
                    Response.Write("<script>alert('财务部核实金额数必须为整数或类如100.00的格式！');</script>");
                    return;
                }
            }
        }
        /// <summary>
        /// 获得人员列表中同一部门的人员
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
