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
using Stoke.Components;
using Bestcomy.Web.Controls.Upload;//wyw
using FileToMSSQL;//wyw 
using System.Threading;//wyw

namespace Stoke.USL.ptgw
{
    public partial class qwsp : System.Web.UI.Page
    {
        protected string _zgbh;
        protected string _zgxm;
        protected int step_id;
        protected int doc_id;
        protected int flow_id;
        protected bool bEditMode;
        DataTable dt_step_field;

        protected int FieldNum;
        protected string member;
        protected static int flag;
        //上传附件用的变量
        //private static string fullFilename1="",fullFilename2="",fullFilename3="";
        private static string filename_rq1 = "", filename_rq2 = "", filename_rq3 = "";
        ////////////////////////////////////////////打印变量///////////////////
        public string wordUrl = "";
        public string dylb = "";
        public string imgUrl_qfr = "";
        public string imgUrl_zgld = "";
        public string imgUrl_bmfzr = "";
        public string bianhao = "";
        public string fwdw = "";
        public string sjr = "";
        public string cb = "";
        public string cs = "";
        public string ywzg = "";
        public string blbm = "";
        public string imgUrl = "";
        public string MYfjmc = "";
        public string myPS = "";
        public string zwjfj = "";

        public string[] ldps_yj ={ "", "", "", "", "" };
        public string[] ldps_yjr ={ "", "", "", "", "" };
        public string[] ldps_sj ={ "", "", "", "", "" };
        public string[] imgUrl_ldps ={ "", "", "", "", "" };

        private DataTable dt_file_name = new DataTable();
        private ArrayList attachList = new ArrayList();
        private AttachFile attachFile = new AttachFile();

        private Guid guid;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            this.BtnDy.Attributes.Add("onclick", "jiandu()");
            g.Attributes.Add("ReadOnly", "True");
            //_zgbh = Request["zgbh"].ToString();
            if (Request.QueryString["zgbh"] != null || (Session["zgbh"] != null))// wy 09/08/09
            {
                _zgbh = Request["zgbh"].ToString();
            }
            else
            {

                Response.Redirect("../error.aspx");
            }
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);

            int item_choice = Utility.GetItemChoice(doc_id);
            for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
            {
                if (Convert.ToInt32(CheckBoxList1.Items[i].Value) == item_choice)
                {
                    CheckBoxList1.Items[i].Selected = true;
                    this.item_name.Text = CheckBoxList1.Items[i].Text;
                    break;
                }
            }

                flow_id = 18;
            if (doc_id > 0)
                bEditMode = true;

            if (step_id == 1)
                this.EmergencySelector1.Enabled = true;
            else if (step_id > 1)
            {
                this.tsyj.Enabled = true;
                this.tsyj.BackColor = Color.White;
            }

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);
            //隐藏签收记录单
            this.Table10.Visible = false;

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select * from dsoc_ry where ry_zgbh = '" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                _zgxm = dr.IsDBNull(1) ? null : dr["ry_xm"].ToString().Trim();
            }
            dr.Close();
            conn.Close();
            try
            {
                dt_file_name.Columns.Add("FileName0", typeof(string));//wyw
                dt_file_name.Columns.Add("FileName", typeof(string));//wyw
            }
            catch
            {
            }

            if (!IsPostBack)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString(); //20090622

                this.Table8.Visible = false;
                //----------------------------wyw-----------------------//
                if (Session["attachList"] != null)
                    attachList = (ArrayList)Session["attachList"];
                if (Session["dt_file_name"] != null)
                    dt_file_name = (DataTable)Session["dt_file_name"];

                GetAffixFromMSSQL();
                this.TD1.Visible = false;
                this.TD2.Visible = false;
                this.TD3.Visible = false;
                this.TD4.Visible = false;
                this.TD5.Visible = false;
                this.TD6.Visible = false;
                //----------------------------wyw-----------------------//

                if (step_id == 1)//填写申请
                {
                    this.CheckBoxList1.Enabled = true;
                    this.TD1.Visible = true;//wyw
                    this.TD2.Visible = true;
                    this.TD3.Visible = true;
                    this.TD4.Visible = true;
                    if (doc_id > 0)
                    {
                        this.TD5.Visible = true;
                        this.TD6.Visible = true;
                    }
                    this.g.Attributes.Add("onclick", "WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'})");
                    Btna.Visible = true;
                    Btnb.Visible = true;
                    Btnc.Visible = true;
                    Btnd.Visible = true;
                    Label13.Visible = false;
                    Label14.Visible = false;
                    Label21.Visible = false;
                    Label22.Visible = false;
                    BtnTj.Text = "提交";
                    BtnQx.Text = "删除";
                    sql = "select * from dsoc_ry where ry_zgbh = '" + _zgbh + "'";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    this.e.DataSource = dr;
                    this.e.DataTextField = "ry_bm";
                    this.e.DataValueField = "ry_bm";
                    this.e.DataBind();
                    this.e.Items.Insert(0, "-请选择-");
                    this.e.SelectedIndex = 0;
                    dr.Close();
                    conn.Close();
                    f.Text = _zgxm.ToString().Trim();
                    k.Text = string.Empty;
                    if (doc_id == 0)
                    {   //反馈表和签收表差入空行
                        DataTable dt = new DataTable();
                        for (int i = 0; i < DataGrid1.Columns.Count; i++)
                            dt.Columns.Add(((BoundColumn)DataGrid1.Columns[i]).DataField.ToString());
                        int count = DataGrid1.PageSize;
                        for (int i = 0; i < count; i++)
                            dt.Rows.Add(dt.NewRow());
                        DataGrid1.DataSource = dt;
                        DataGrid1.DataBind();

                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < Datagrid2.Columns.Count; i++)
                            dt2.Columns.Add(((BoundColumn)Datagrid2.Columns[i]).DataField.ToString());
                        int count2 = Datagrid2.PageSize;
                        for (int i = 0; i < count; i++)
                            dt2.Rows.Add(dt2.NewRow());
                        Datagrid2.DataSource = dt2;
                        Datagrid2.DataBind();
                    }
                    if (doc_id > 0)
                        Qs_Handle_Data();
                }
                else if (step_id > 1)
                {
                    if (this.DBFileList.Items.Count > 0)//wyw
                    {
                        this.TD5.Visible = true;
                        this.TD6.Visible = true;
                    }
                }
                if (doc_id > 0)
                {
                    Step_Handle_Data();
                    Yj_Handle_Data();
                    BindEmergency();
                }
                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);
                //根据步骤邦定人员的名称 
                if (step_id == 2) //岗位经理签字
                {
                    l.Text = _zgxm.Trim();
                    k.Text = string.Empty;
                }
                if (step_id == 3) //部门副部长签字
                {
                    o.Text = _zgxm.Trim();
                    k.Text = string.Empty;
                }

                if (step_id == 4)//部门负责人签字
                {
                    Btna.Visible = true;                  //2010.04.08
                    Btnb.Visible = true;
                    Btnc.Visible = true;
                    Btnd.Visible = true;
                    i.Text = _zgxm.Trim();
                    k.Text = _zgxm.Trim();
                }
                if (step_id == 5)//会签
                {
                    k.Text = string.Empty;
                    if (n.Text == string.Empty)
                        n.Text += _zgxm.Trim();
                    else
                        n.Text += "," + _zgxm.Trim();
                }
                if (step_id == 6)//副总审批/高层领导
                {
                    h1.Text = _zgxm.Trim();
                    k.Text = _zgxm.Trim();

                }
                if (step_id == 13)//主管领导审批
                {
                    j.Text = _zgxm.Trim();
                    k.Text = _zgxm.Trim();

                }
                if (step_id == 7)//报转
                {
                    k.Text = _zgxm.Trim();
                }
                if (step_id == 8)
                {
                    if (_zgbh == "1001")
                    {
                        this.Table10.Visible = true;
                        Qs_Handle_Data();
                    }
                }

            }
            ////////////////////////////////////////////////////打印的函数////////////////////
            if (step_id == 0)
            {
                if (this.DBFileList.Items.Count > 0)//wyw
                {
                    this.TD5.Visible = true;
                    this.TD6.Visible = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    ldps_yj[i] = "";
                    ldps_yjr[i] = "";
                    ldps_sj[i] = "";
                    imgUrl_ldps[i] = "";
                }
                if (_zgbh == "1001" || _zgxm == f.Text.ToString().Trim() || _zgxm == k.Text.ToString().Trim())
                {
                    this.Table10.Visible = true;
                    Qs_Handle_Data();
                }
                BtnDy.Visible = false;
                BtnTj.Visible = false;
                BtnSave.Visible = false;
                //为打印取出领导批示的意见和时间
                //					sql = "select ry_xm,Sj from dbo.Dsoc_Flow_Qsjl,dbo.dsoc_ry where Yjr<6 and Doc_id=57 and ry_zgbh=Yjr" ;
                //					cmd = new SqlCommand(sql,conn);
                //					conn.Open();
                //					dr = cmd.ExecuteReader();

                //					while(dr.Read())
                //					{
                //						ldps_yjr[i]=dr["ry_xm"].ToString().Trim();
                //						ldps_sj[i]=dr["Sj"].ToString().Trim().Substring(0,10);
                //						i++;
                //					}
                //					conn.Close();

                int q = 0;
                for (int i = 0; i < 5; i++)
                {
                    int j = i + 1;

                    string ld = "000" + j.ToString();

                    sql = "select top 1 Operator_Time,ry_xm from dbo.Dsoc_Flow_Path,dbo.dsoc_ry where Doc_ID='" + doc_id + "' and Staff_ID='" + ld + "' and ry_zgbh=Staff_ID order by Operator_Time desc";
                    SqlCommand cmd1 = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        string sql2 = "select top 1 Yj from dbo.Dsoc_Flow_Gwyj where Yjr='" + dr["ry_xm"] + "' and Doc_ID='" + doc_id + "'  order by Sj desc ";
                        SqlConnection conn2 = new SqlConnection(connString);
                        conn2.Open();
                        SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            ldps_yj[q] = dr2["Yj"].ToString().Trim();

                            ldps_yjr[q] = dr["ry_xm"].ToString().Trim();
                            ldps_sj[q] = dr["Operator_Time"].ToString();
                            q++;
                        }
                        dr2.Close();
                        conn2.Close();
                    }
                    dr.Close();
                    conn.Close();
                }
                for (int r = 0; r < q; r++)
                {
                    for (int s = r + 1; s < q; s++)
                    {
                        if (ldps_sj[r].CompareTo(ldps_sj[s]) > 0)
                        {
                            string yj, xm, sj;
                            yj = ldps_yj[r];
                            xm = ldps_yjr[r];
                            sj = ldps_sj[r];
                            ldps_yj[r] = ldps_yj[s];
                            ldps_yjr[r] = ldps_yjr[s];
                            ldps_sj[r] = ldps_sj[s];
                            ldps_yj[s] = yj;
                            ldps_yjr[s] = xm;
                            ldps_sj[s] = sj;
                        }
                    }
                }
                for (int i = 0; i < q; i++)////////////////
                {
                    if (ldps_sj[i].Length >= 10)
                        ldps_sj[i] = ldps_sj[i].Substring(0, 10);
                }
            }

            if (DBFileList != null)
                for (int i = 0; i < this.DBFileList.Items.Count; i++)
                {
                    HyperLink link = (HyperLink)this.DBFileList.Items[i].FindControl("link_download");
                    MYfjmc += "\n附件" + i.ToString() + "： " + link.Text;
                }


            fwdw = GetUnionString(a1.Text.ToString(), a.Text.ToString());//发往单位
            sjr = GetUnionString(b1.Text.ToString(), b.Text.ToString()); //收件人
            cb = GetUnionString(c1.Text.ToString(), c.Text.ToString()); // 抄报
            cs = GetUnionString(d1.Text.ToString(), d.Text.ToString()); // 抄送
            ywzg = GetUnionString(l.Text.ToString(), o.Text.ToString()); //业务主管
            blbm = this.e.SelectedItem.Text.ToString();
            bianhao = h.Text.ToString();                                       //编号

            zwjfj = x.Text.ToString();
            zwjfj = GetDoubleQuotationMarks(zwjfj);
            if (MYfjmc.ToString() != "")
                zwjfj = zwjfj + "\n" + MYfjmc.ToString();                       //正文及附件			 

            string fileName = "";

            /////////////////////////////////////////////新增///取值////////////////////////////////////////////////////////////////////////////////////


            if (ldps_yjr[0].ToString().Trim() != "")
            {
                dylb = "0";                                                    //打印类别
                fileName = "qwsp1.doc";

            }
            else
            {
                dylb = "1";
                fileName = "qwsp2.doc";
            }
            getWordUrl(fileName);

            try
            {
                string fileName1 = "";

                imgUrl = "http://" + Request.ServerVariables["SERVER_NAME"].ToString() + "/dsoc/USL/signs/";//记录图片路径

                if (k.Text.ToString() != "")
                {
                    fileName1 = GetSignsBig(k.Text.ToString().Trim());
                    if (fileName1 != "")
                    {
                        imgUrl_qfr = imgUrl + fileName1;

                    }
                    else
                        imgUrl_qfr = "";

                }

                if (i.Text.ToString() != "")
                {
                    fileName1 = GetSignsBig(i.Text.ToString().Trim());
                    if (fileName1 != "")
                    {

                        imgUrl_bmfzr = imgUrl + fileName1;

                    }
                    else
                        imgUrl_bmfzr = "";

                }

                if (j.Text.ToString() != "")
                {
                    fileName1 = GetSignsBig(j.Text.ToString().Trim());
                    if (fileName1 != "")
                    {
                        imgUrl_zgld = imgUrl + fileName1;
                    }
                    else
                        imgUrl_zgld = "";
                }


                /////////////////////////////////////////新增///取值imgUrl_ldps/////////////////////////////////////
                for (int i1 = 0; i1 < 5; i1++)
                {
                    if (ldps_yjr[i1].ToString().Trim() != "")
                    {
                        fileName1 = GetSignsBig(ldps_yjr[i1].ToString().Trim());
                        if (fileName1 != "")
                        {
                            imgUrl_ldps[i1] = imgUrl + fileName1;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

                return;
            }
        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Stoke.BLL.Utility.GetEmergencyByDocid(doc_id);
        }

        ////////////////////////////////////////////////////////
        public void getWordUrl(string fileName)
        {

            //if(Request.ServerVariables["SERVER_NAME"] != "localhost")
            wordUrl = "http://" + Request.ServerVariables["SERVER_NAME"] + "/dsoc/USL/ptgw/doc/" + fileName;////找到word存储路径
            //else
            //wordUrl = Server.MapPath("doc")+"\\"+fileName;//

        }

        /// ////////////////////////////////////////////////////////
        public string GetSignsBig(string _name)
        {
            string fileName = "";
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            string sql = "select * from dsoc_ryqm where ryqm_xm = '" + _name + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                fileName = dr.IsDBNull(4) ? null : dr["ryqm_qm2"].ToString();
            dr.Close();
            conn.Close();
            conn.Dispose();
            return fileName;
        }

        /// /////////////////////////////////////////////////////////

        public string GetUnionString(string _str1, string _str2)
        {
            string myUS = "";
            bool flag = false;

            if (_str1 != "")
            {
                myUS += _str1;//外
                flag = true;
            }
            if (_str2 != "")         //内
            {
                if (flag)
                {
                    myUS += "，" + _str2;
                }
                else
                {
                    myUS += _str2;
                }
            }
            return myUS;
        }

        public string GetDoubleQuotationMarks(string _srcStr)
        {
            _srcStr = _srcStr.Replace("\"", "&quot;");
            return _srcStr;
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
            this.Btna.Click += new System.EventHandler(this.Btna_Click);
            this.Btnb.Click += new System.EventHandler(this.Btnb_Click);
            this.Btnc.Click += new System.EventHandler(this.Btnc_Click);
            this.Btnd.Click += new System.EventHandler(this.Btnd_Click);
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            this.FileList.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.FileList_DeleteCommand);
            this.FileList.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.FileList_ItemDataBound);
            this.DBFileList.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DBFileList_DeleteCommand);
            this.DBFileList.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.DBFileList_ItemDataBound);
            this.BtnTj.Click += new System.EventHandler(this.BtnTj_Click);
            this.BtnDy.Click += new System.EventHandler(this.BtnDy_Click);
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnQx.Click += new System.EventHandler(this.BtnQx_Click);
            this.BtnSD.Click += new System.EventHandler(this.BtnSD_Click);
            this.Button6.Click += new System.EventHandler(this.Button6_Click);
            this.Load += new System.EventHandler(this.Page_Load);
            this.CheckBoxList1.SelectedIndexChanged += new EventHandler(CheckBoxList1_SelectedIndexChanged);
        }

        void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    this.item_name.Text = CheckBoxList1.Items[i].Text;
                    break;
                }
            }
        }

        #endregion


        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            if (step_id == 1)
            {
                m.SelectedItem.Text = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : null;
                string blbm = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString().Trim() : null;
                for (int i = 0; i < e.Items.Count; i++)
                {
                    if (e.Items[i].Text.ToString().Trim() == blbm)
                    {
                        this.e.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                m.Items.Clear();
                m.Items.Insert(0, dt_style_data.Rows[0]["m"].ToString());
                this.e.Items.Insert(0, dt_style_data.Rows[0]["e"].ToString());
            }
            a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
            b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            a1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
            b1.Text = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : null;
            this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
            this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
            this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
            this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
            this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
            this.h1.Text = dt_style_data.Rows[0]["h1"].ToString() != null ? dt_style_data.Rows[0]["h1"].ToString() : null;
        }

        private void Yj_Handle_Data()
        {
            DataTable dt_yj_data = Stoke.Components.StyleRef.Select_Gwyj_DocID(doc_id);
            if (dt_yj_data.Rows.Count <= DataGrid1.PageSize)
                for (int i = dt_yj_data.Rows.Count; i < DataGrid1.PageSize; i++)
                    dt_yj_data.Rows.Add(dt_yj_data.NewRow());
            DataGrid1.DataSource = dt_yj_data;
            DataGrid1.DataBind();

        }
        private void Qs_Handle_Data()
        {
            DataTable dt_yj_data = Stoke.Components.StyleRef.Select_Qsyj_DocID(doc_id);
            if (dt_yj_data.Rows.Count <= Datagrid2.PageSize)
                for (int i = dt_yj_data.Rows.Count; i < Datagrid2.PageSize; i++)
                    dt_yj_data.Rows.Add(dt_yj_data.NewRow());
            Datagrid2.DataSource = dt_yj_data;
            Datagrid2.DataBind();

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
                    if (name == "m" || name == "n" || name == "w" || name == "x" || name == "y" || name == "a1" || name == "b1" || name == "c1" || name == "d1")
                        ((TextBox)StyleControl).ReadOnly = false;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)StyleControl).Enabled = true;
                    ((DropDownList)StyleControl).BackColor = Color.White;
                }
            }
        }
        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            if (bEditMode == false)
            {
                mySql = GetStyleInsertData();
                //拟稿
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, w.Text.ToString());

                for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        Utility.AddItemChoice(doc_id, Convert.ToInt32(CheckBoxList1.Items[i].Value));
                        break;
                    }
                }
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                df.UpdateDocument(mySql);

                for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        Utility.AddItemChoice(doc_id, Convert.ToInt32(CheckBoxList1.Items[i].Value));
                        break;
                    }
                }

                df = null;
                if (step_id != 1 && y.Text != string.Empty)
                    SaveYj();

            }

            if (step_id == 1)
                Stoke.BLL.Utility.SetEmergencyWithDocid(doc_id, this.EmergencySelector1.SelectedValue);

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
                    return ((TextBox)StyleControl).Text.Trim();
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedItem.Text.ToString().Trim();
                default:
                    return null;
            }
        }
        //public void SaveYj()
        //{
        //    string Sj = System.DateTime.Now.ToString();
        //    string connString = StokeGlobals.Connectiondsoc;
        //    SqlConnection conn = new SqlConnection(connString);
        //    conn.Open();
        //    string Yjnr = y.Text.ToString().Trim();
        //    string sql = "insert into Dsoc_Flow_Gwyj values('" + flow_id + "','" + doc_id + "','" + step_id + "','" + _zgxm + "','" + Yjnr + "','" + Sj + "')";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //    conn.Dispose();
        //}
        public void SaveQszt()
        {
            string Sj = System.DateTime.Now.ToString();
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string Zt = "已签收";
            string sql = "update Dsoc_Flow_Qsjl set Zt='" + Zt + "',Sj = '" + Sj + "' where Doc_id='" + doc_id + "' and Yjr='" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }



        private void BtnTj_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1)
            {
                bool flag = false;
                for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    Response.Write("<script>alert('请点击事项选择进行选择！')</script>");
                    return;
                }
                if (Session["attachList"] == null && this.FileList.Items.Count != 0)//wyw 3.10
                {
                    Response.Write("<script>alert('操作超时，请重新上传附件！')</script>");
                    this.FileList.DataSource = null;
                    this.FileList.DataBind();
                }
                else
                {
                    if (a.Text == string.Empty && a1.Text == string.Empty)
                        Response.Write("<script>alert('发往单位不能为空！')</script>");
                    else if (b.Text == string.Empty && b1.Text == string.Empty)
                        Response.Write("<script>alert('收件人不能为空！')</script>");
                    else if (this.e.SelectedItem.Text == "-请选择-")
                        Response.Write("<script>alert('办理部门不能为空！')</script>");
                    else if (g.Text == string.Empty)
                        Response.Write("<script>alert('日期不能为空！')</script>");
                    else if (m.SelectedItem.Text == "-请选择-")
                        Response.Write("<script>alert('类别不能为空！')</script>");
                    else if (w.Text == string.Empty)
                        Response.Write("<script>alert('主题不能为空！')</script>");
                    else
                    {
                        SaveData();
                        UpdataZt();
                        ScfjToMSSQL();//wyw
                        string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=18&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                        Response.Redirect(_URL);
                    }
                }

            }
            // tianjia 13/14/15/16 bu 2009/06/07 wy
            if (step_id == 2 || step_id == 3 || step_id == 4 || step_id == 5 || step_id == 6 || step_id == 7 || step_id == 13 || step_id == 14 || step_id == 15 || step_id == 16)
            {
                if (tsyj.Text.Trim() != string.Empty)
                    SaveYj();
                SaveData();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=18&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
            }
            if (step_id == 8)
            {

                SaveData();
                SaveQszt();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=18&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
            }
            if (step_id == 12)
            {

                SaveData();
                //SaveQszt();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=18&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
            }
        }

        private void BtnQx_Click(object sender, System.EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                delete();
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
            {
                // Response.Redirect("../Workflow/Work_Record.aspx");
                Response.Redirect(ViewState["retu"].ToString());
            }
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");

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

        private void BtnSD_Click(object sender, System.EventArgs e)
        {
            if (flag == 1)
            {
                a.Text = SlctDepartment2.Send[0].ToString();
                if (SlctDepartment2.Visible == true)
                {
                    SlctDepartment2.Visible = false;
                    BtnSD.Visible = false;
                }
            }
            else if (flag == 2)
            {
                b.Text = SlctMember1.Send[0].ToString().Trim();
                if (SlctMember1.Visible == true)
                {
                    SlctMember1.Visible = false;
                    BtnSD.Visible = false;
                }
            }
            else if (flag == 3)
            {
                c.Text = SlctMember1.Send[0].ToString().Trim();
                if (SlctMember1.Visible == true)
                {
                    SlctMember1.Visible = false;
                    BtnSD.Visible = false;
                }
            }
            else if (flag == 4)
            {
                d.Text = SlctMember1.Send[0].ToString().Trim();
                if (SlctMember1.Visible == true)
                {
                    SlctMember1.Visible = false;
                    BtnSD.Visible = false;
                }
            }
            SlctMember1.Clear();
            this.Table8.Visible = false;
        }
        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            bool flag = false;
            for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    flag = true;
                    break;
                }
            }

            if (flag == false)
            {
                Response.Write("<script>alert('请点击事项选择进行选择！')</script>");
                return;
            }

            if (Session["attachList"] == null && this.FileList.Items.Count != 0)//wyw 3.10
            {
                Response.Write("<script>alert('操作超时，请重新上传附件！')</script>");
                this.FileList.DataSource = null;
                this.FileList.DataBind();
            }
            else if (this.w.Text.Trim() == string.Empty)
            {
                Response.Write("<script>alert('请填写主题！')</script>");
                return;
            }
            else
            {
                SaveData();
                UpdataZt();
                ScfjToMSSQL();//wyw
                //Response.Write("<script>alert('保存成功！')</script>");
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
        }

        //wyw上传附件
        #region wyw上传附件
        public string GetAffixFilename(string _name)
        {
            string affixName = "";
            int j = _name.LastIndexOf("@_@");
            affixName = _name.Substring(j + 3);//获取文件名
            return affixName;

        }

        private void btn_upload_Click(object sender, System.EventArgs e)
        {
            string filebm = this.TextBox2.Text;
            string fileUrl = this.File1.PostedFile.FileName;//获取初始文件路径
            int fileLength = this.File1.PostedFile.ContentLength;
            if (fileUrl == "")
            {
                Response.Write("<script> alert('请选择附件的上传路径。') </script>");
                return;
            }
            if (filebm == "")
            {
                Response.Write("<script> alert('附件名必须填写。') </script>");
                return;
            }

            if (fileLength > 10 * 1024 * 1024)//判断文件的大小是否大于5M
            {
                Response.Write("<script>alert('上传文件最大为10M。')</script>");
                this.TextBox2.Text = "";
                return;
            }
            if (Session["attachList"] == null && this.FileList.Items.Count != 0)//wyw 3.10
            {
                Response.Write("<script>alert('原上传附件超时，请重新上传原附件！')</script>");
                this.FileList.DataSource = null;
                this.FileList.DataBind();
            }
            if (Session["attachList"] != null)
                attachList = (ArrayList)Session["attachList"];
            string filetype = fileUrl.Substring(fileUrl.LastIndexOf(".") + 1); //获取文件类型
            attachFile.FileLength = fileLength;
            attachFile.FileName = filebm + "." + filetype;
            attachFile.FileNameRq = System.DateTime.Now.Ticks.ToString() + "@_@" + attachFile.FileName;
            attachFile.StreamObject = this.File1.PostedFile.InputStream;
            attachList.Add(attachFile);
            Session["attachList"] = attachList;

            if (Session["dt_file_name"] != null)
                dt_file_name = (DataTable)Session["dt_file_name"];
            DataRow ndr = dt_file_name.NewRow();
            ndr["FileName0"] = Path.GetFileName(@attachFile.FileNameRq);
            ndr["FileName"] = Path.GetFileName(@attachFile.FileName);
            dt_file_name.Rows.Add(ndr);
            Session["dt_file_name"] = dt_file_name;
            FileList.DataSource = dt_file_name.DefaultView;
            FileList.DataBind();
            this.TextBox2.Text = string.Empty;
        }

        private void FileList_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton btn = (ImageButton)e.Item.FindControl("btn_delete");
                btn.Attributes.Add("onclick", "javascript:return window.confirm('确定删除?');");
            }
        }

        private void FileList_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            attachList = (ArrayList)Session["attachList"];
            dt_file_name = (DataTable)Session["dt_file_name"];
            if (Session["attachList"] != null)                //wyw 3.10
            {
                try
                {
                    foreach (AttachFile attachFile in attachList)
                        if (attachFile.FileNameRq == dt_file_name.Rows[e.Item.ItemIndex]["FileName0"].ToString())
                            attachList.Remove(attachFile);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
                Session["attachList"] = attachList;

                dt_file_name.Rows.RemoveAt(e.Item.ItemIndex);
                FileList.DataSource = dt_file_name.DefaultView;
                FileList.DataBind();
            }
            else
            {
                Response.Write("<script>alert('上传附件超时，请重新上传附件！')</script>");
                this.FileList.DataSource = null;
                this.FileList.DataBind();
            }
        }

        public void ScfjToMSSQL()
        {
            guid = Guid.NewGuid();

            attachList = (ArrayList)Session["attachList"];
            long totalLength = 0;
            if (attachList != null)
            {
                foreach (AttachFile attachFile in attachList)
                    totalLength += attachFile.FileLength;
            }

            if (attachList != null)
            {
                if (attachList.Count > 0)
                {
                    //Initialize indicator.
                    Indicator status = new Indicator();
                    status.TotalLength = totalLength;
                    status.TotalCount = attachList.Count;
                    StokeGlobals.ProcessingResults.Add(guid.ToString(), status);

                    ThreadStart ts = new ThreadStart(StartProcessing);
                    Thread _t = new Thread(ts);
                    _t.Start();
                    //				Response.Write("<script>window.open('dsoc/USL/filetosql/IndicatorBar.aspx?id=" + guid.ToString() + "');</script>");
                }
            }
        }

        public void StartProcessing()
        {
            attachList = (ArrayList)Session["attachList"];
            Session["attachList"] = null;
            Session["dt_file_name"] = null;
            foreach (object obj in attachList)
            {
                attachFile = (AttachFile)obj;
                ((Indicator)StokeGlobals.ProcessingResults[guid.ToString()]).CurrentFile = attachFile.FileName;
                int BUFFER_LENGTH = 32768;
                string connStr = StokeGlobals.Connectiondsoc;
                SqlConnection cn = new SqlConnection(connStr);
                string sql = "SET NOCOUNT ON;";
                sql += "declare @idx int;";
                sql += "INSERT INTO Categories(CategoryName,Description,Picture,doc_id) VALUES('" + attachFile.FileName + "','" + attachFile.FileNameRq + "',0x0,'" + doc_id + "')";
                sql += "select @idx=IDENT_CURRENT('Categories');";
                sql += "SELECT @Pointer=TEXTPTR(Picture) FROM Categories WHERE CategoryID=@idx";
                SqlCommand cmdGetPointer = new SqlCommand(sql, cn);
                SqlParameter PointerOutParam = cmdGetPointer.Parameters.Add("@Pointer", SqlDbType.VarBinary, 100);
                PointerOutParam.Direction = ParameterDirection.Output;
                cn.Open();
                cmdGetPointer.ExecuteNonQuery();

                // Set up UPDATETEXT command, parameters, and open BinaryReader.

                SqlCommand cmdUploadBinary = new SqlCommand("UPDATETEXT Categories.Picture @Pointer @Offset @Delete WITH LOG @Bytes", cn);
                SqlParameter PointerParam = cmdUploadBinary.Parameters.Add("@Pointer", SqlDbType.Binary, 16);
                SqlParameter OffsetParam = cmdUploadBinary.Parameters.Add("@Offset", SqlDbType.Int);
                SqlParameter DeleteParam = cmdUploadBinary.Parameters.Add("@Delete", SqlDbType.Int);
                DeleteParam.Value = 1;  // delete 0x0 character
                SqlParameter BytesParam = cmdUploadBinary.Parameters.Add("@Bytes", SqlDbType.Binary, BUFFER_LENGTH);
                //				System.IO.FileStream fs = new System.IO.FileStream(SourceFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader br = new System.IO.BinaryReader(attachFile.StreamObject);

                int Offset = 0;
                OffsetParam.Value = Offset;

                // Read buffer full of data and execute UPDATETEXT statement.

                Byte[] Buffer = br.ReadBytes(BUFFER_LENGTH);
                while (Buffer.Length > 0)
                {
                    PointerParam.Value = PointerOutParam.Value;
                    BytesParam.Value = Buffer;
                    cmdUploadBinary.ExecuteNonQuery();
                    ((Indicator)StokeGlobals.ProcessingResults[guid.ToString()]).UploadedLength += Buffer.Length;
                    DeleteParam.Value = 0; //Do not delete any other data.
                    Offset += Buffer.Length;
                    OffsetParam.Value = Offset;
                    Buffer = br.ReadBytes(BUFFER_LENGTH);
                }

                br.Close();
                //				fs.Close();

                cn.Dispose();

                ((Indicator)StokeGlobals.ProcessingResults[guid.ToString()]).UploadedCount++;
            }
        }

        public void GetAffixFromMSSQL()
        {
            DataTable dt = new DataTable();
            string connStr = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select CategoryID,CategoryName,[Description] from Categories where doc_id='" + doc_id + "'";
            cmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            conn.Open();
            adapter.Fill(dt);
            adapter.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            DBFileList.DataSource = dt.DefaultView;
            DBFileList.DataBind();
        }

        private void DBFileList_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (step_id == 1 && doc_id > 0)
                {
                    ImageButton btn = (ImageButton)e.Item.FindControl("btn_delete1");
                    btn.Visible = true;
                    btn.Attributes.Add("onclick", "javascript:return window.confirm(确定删除?');");
                }
                DataRowView drv = (DataRowView)e.Item.DataItem;
                HyperLink link = (HyperLink)e.Item.FindControl("link_download");
                link.NavigateUrl = "../filetosql/Download.aspx?id=" + drv["CategoryID"].ToString() + "&filename=" + FileToMSSQL.Util.EncryptFilename(drv["CategoryName"].ToString());
            }
        }

        private void DBFileList_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            string id = (string)e.CommandArgument;
            string connStr = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Categories where CategoryID=" + id;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            GetAffixFromMSSQL();
        }

        #endregion

        private void BtnDy_Click(object sender, System.EventArgs e)
        {

        }

        private void Button6_Click(object sender, System.EventArgs e)
        {
            this.Table8.Visible = false;
            SlctDepartment2.Visible = false;
            SlctMember1.Visible = false;

        }

        private void Btna_Click(object sender, System.EventArgs e)
        {
            if (SlctDepartment2.Visible == true)
            {

                SlctDepartment2.Visible = false;
                SlctMember1.Visible = false;
                this.Table8.Visible = false;
                BtnSD.Visible = false;
            }
            else
            {
                if (SlctMember1.Visible == true)
                {
                    SlctMember1.Visible = false;
                    SlctDepartment2.Visible = true;
                    this.Table8.Visible = true;
                    flag = 1;
                }
                else
                {
                    SlctDepartment2.Visible = true;
                    SlctDepartment2.Send[0] = string.Empty;
                    BtnSD.Visible = true;
                    this.Table8.Visible = true;
                    flag = 1;
                }

            }
        }

        private void Btnb_Click(object sender, System.EventArgs e)
        {
            if (SlctMember1.Visible == true)
            {
                if (flag == 2)
                {
                    SlctMember1.Visible = false;
                    this.Table8.Visible = false;
                    BtnSD.Visible = false;
                }
                else
                    flag = 2;
            }
            else
            {
                if (SlctDepartment2.Visible == true)
                {
                    SlctDepartment2.Visible = false;
                    this.Table8.Visible = true;
                    SlctMember1.Visible = true;
                    flag = 2;
                }
                else
                {
                    SlctMember1.Visible = true;
                    this.Table8.Visible = true;
                    BtnSD.Visible = true;
                    flag = 2;
                }
            }
        }

        private void Btnc_Click(object sender, System.EventArgs e)
        {
            if (SlctMember1.Visible == true)
            {
                //				if(flag == 3)
                //				{
                SlctMember1.Visible = false;
                this.Table8.Visible = false;
                BtnSD.Visible = false;
                //				}
                //				else
                flag = 3;
            }
            else
            {
                if (SlctDepartment2.Visible == true)
                {
                    SlctDepartment2.Visible = false;
                    this.Table8.Visible = true;
                    SlctMember1.Visible = true;
                    flag = 3;
                }
                else
                {
                    SlctMember1.Visible = true;
                    this.Table8.Visible = true;
                    BtnSD.Visible = true;
                    flag = 3;
                }
            }
        }

        private void Btnd_Click(object sender, System.EventArgs e)
        {
            if (SlctMember1.Visible == true)
            {
                //				if(flag == 4)
                //				{
                SlctMember1.Visible = false;
                this.Table8.Visible = false;
                BtnSD.Visible = false;
                //				}
                //				else
                flag = 4;
            }
            else
            {
                if (SlctDepartment2.Visible == true)
                {
                    SlctDepartment2.Visible = false;
                    this.Table8.Visible = true;
                    SlctMember1.Visible = true;
                    flag = 4;
                }
                else
                {
                    SlctMember1.Visible = true;
                    this.Table8.Visible = true;
                    BtnSD.Visible = true;
                    flag = 4;
                }
            }
        }
        public void UpdataZt()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            //string str="update dbo.Dsoc_Flow_Document set Doc_Title='"+w.Text.ToString().Trim()+"'where Doc_ID='"+doc_id+"'";修改前
            //修改后
            string wText = w.Text.Replace("'", "&#39;").Trim();
            string str = "update dbo.Dsoc_Flow_Document set Doc_Title='" + wText + "'where Doc_ID='" + doc_id + "'";

            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        protected void SaveYj()
        {
            string Sj = System.DateTime.Now.ToString();
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string Yjnr = tsyj.Text.ToString().Trim();
            //string _zgxm = GetName(_zgbh);
            string sql = "insert into Dsoc_Flow_Gwyj values('" + flow_id + "','" + doc_id + "','" + step_id + "','" + _zgxm + "','" + Yjnr + "','" + Sj + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }
}
