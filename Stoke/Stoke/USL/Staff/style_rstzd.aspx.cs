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
using System.Text;
using System.IO;
using Stoke.COMMON;
using Stoke.Components;

namespace Stoke.USL.Staff
{
    public partial class style_rstzd : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id = 1;
        private int doc_id = 0;
        private int flow_id = 35;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;
        private int sum_zz = 0;
        private int rstzd_id = 0;



        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            //根据doc_id判断执行表单数据的插入操作或更新操作
            if (doc_id > 0)
                bEditMode = true;

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            if (!Page.IsPostBack)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString(); //20090622
                this.Table3.Visible = false;
                this.Table4.Visible = false;
                this.Table5.Visible = false;
                this.Table6.Visible = false;
                this.Table7.Visible = false;
                this.Table8.Visible = false;
                this.Table9.Visible = false;
                this.Button1.Visible = false;

                BindBm();
                //				BindZw();
                ddlDdxm.Items.Clear();
                ddlDdxm.Items.Insert(0, "-请选择-");
                ddlDdxm.SelectedIndex = 0;
                ddlDdzh.Items.Clear();
                ddlDdzh.Items.Insert(0, "-请选择-");
                ddlDdzh.SelectedIndex = 0;
                this.ddlZzgx.Items.Clear();
                this.ddlZzgx.Items.Insert(0, "-请选择-");
                this.ddlZzgx.SelectedIndex = 0;

                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                    Step_Handle_Data();

                if (this.b.SelectedValue == "入职" || this.b.SelectedValue == "离职")
                    this.Table4.Visible = true;
                else if (this.b.SelectedValue == "调职")
                    this.Table3.Visible = true;
                else if (this.b.SelectedValue == "退休")
                    this.Table5.Visible = true;

                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString();
                if (step_id == 0)
                {
                    this.btnSave.Visible = false;
                    this.btnPrint.Visible = true;

                }
                else if (step_id == 1)
                {
                    this.f.Text = _zgxm;
                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                    else if (doc_id == 0)
                        DeleteRymdTemp();
                    this.Table7.Visible = true;
                    this.Button1.Visible = true;
                    this.btnCancel.Text = "删除";
                }
                else if (step_id == 2)
                    this.g.Text = _zgxm;
                else if (step_id == 3)
                    this.h.Text = _zgxm;
                else if (step_id == 4)
                {
                    this.i.Text = _zgxm;
                    this.j.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }

                else if (step_id == -1)
                {
                    SaveToRstzd(doc_id);
                    //8.28dxq
                    //存入一个每月记录表，第一次是插入表，以后是更新。此时RstzdRymd,Rstzd有变动情况
                    //先读出当前的各部门个聘用类型的人数，再结合变动情况，共同存入每月记录表
                    //(直接把统计页面的datagrid绑定来行不？)
                    this.InitdgStatPerMonth();
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }

            }
        }

        //绑定dgStatPerMonth
        private void InitdgStatPerMonth()
        {

            Stoke.Components.StaffStatisticsDAL stat = new Stoke.Components.StaffStatisticsDAL();
            DataTable dt_staff_sum = stat.GetStaffSum();
            sum_zz = Int32.Parse(dt_staff_sum.Rows[0][0].ToString());

            Stoke.Components.StaffStatisticsBLL staffBLL = new Stoke.Components.StaffStatisticsBLL();
            DataTable dt = staffBLL.getStaffStatisticsPerMonth();
            this.dgStatPerMonth.DataSource = dt;
            this.dgStatPerMonth.DataBind();


            //补齐以前记录

            #region 获得最近记录的年和月
            string max_nf = "";
            string max_yf = "";
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //			string str = "select max(rstj_nf),max(rstj_yf) from rs_tj";
            string str = "select rstj_nf,rstj_yf from rs_tj where rstj_id = (select max(rstj_id) from rs_tj)";
            SqlCommand cmd = new SqlCommand(str, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetValue(0).ToString() != "")
                    max_nf = dr.GetValue(0).ToString();
                if (dr.GetValue(1).ToString() != "")
                    max_yf = dr.GetValue(1).ToString();

            }
            dr.Close();
            conn.Close();
            #endregion



            #region 获得当前年月
            string nf = "";
            string yf = "";
            string rq = "";
            if (j.Text.ToString() != "")
            {
                nf = this.j.Text.Substring(0, 4);
                yf = this.j.Text.Substring(5, 2);
                rq = this.j.Text.ToString();
            }
            else
            {
                yf = Convert.ToString(System.DateTime.Now.Month.ToString("00"));
                nf = Convert.ToString(System.DateTime.Now.Year);
                rq = DateTime.Now.ToString("yyyy-MM-dd");
            }
            #endregion

            #region 获得历史最近记录
            //如果有缺少的记录
            string _bm = "";
            int _num = 0;
            int _M_num = 0;
            int _PM_num = 0;
            int _FP_num = 0;
            int _JY_num = 0;
            int _W_num = 0;
            int _PZ_num = 0;

            int _syhj_num = 0;
            int _bdrs_num = 0;
            string _bdxq = "入职:0 离职:0 调入:0 调出:0";
            string _rq = "";
            string _bz = "";

            conn.Open();
            string sqlStr1 = "select * from rs_tj where rstj_nf='" + max_nf + "' and rstj_yf='" + max_yf + "'";
            cmd = new SqlCommand(sqlStr1, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            conn.Close();
            #endregion

            if (max_nf != "")
            {
                #region 补齐以其月份

                //同年的情况
                if (max_nf == nf && (Int32.Parse(yf) - Int32.Parse(max_yf) > 1))
                {
                    //读出max_nf,max_yf的数据，逐条插入缺的月份

                    for (int old_yf = Convert.ToInt32(max_yf) + 1; old_yf < (Int32.Parse(yf)); old_yf++)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            _bm = dt1.Rows[i]["rstj_bm"].ToString();
                            _num = Convert.ToInt32(dt1.Rows[i]["rstj_byhj"].ToString());
                            _M_num = Convert.ToInt32(dt1.Rows[i]["rstj_m"].ToString());
                            _PM_num = Convert.ToInt32(dt1.Rows[i]["rstj_pm"].ToString());
                            _FP_num = Convert.ToInt32(dt1.Rows[i]["rstj_fp"].ToString());
                            _JY_num = Convert.ToInt32(dt1.Rows[i]["rstj_jy"].ToString());
                            _W_num = Convert.ToInt32(dt1.Rows[i]["rstj_w"].ToString());
                            _PZ_num = Convert.ToInt32(dt1.Rows[i]["rstj_pz"].ToString());

                            _syhj_num = Convert.ToInt32(dt1.Rows[i]["rstj_byhj"].ToString());
                            string b_yf = old_yf.ToString();//补齐的月份
                            if (old_yf.ToString().Length < 2)
                                b_yf = "0" + old_yf.ToString();

                            _bz = dt1.Rows[i]["rstj_bz"].ToString();
                            //插入rs_tj表,补齐记录
                            SaveToRstj(_bm, _num, _M_num, _PM_num, _FP_num, _JY_num, _W_num, _PZ_num, _syhj_num, _bdrs_num, _bdxq, nf, b_yf, _rq, _bz);
                        }
                    }
                }
                else if (nf != max_nf)//跨年的情况
                {
                    for (int old_yf = Convert.ToInt32(max_yf) + 1; old_yf < 13; old_yf++)//先补齐第一年
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            _bm = dt1.Rows[i]["rstj_bm"].ToString();
                            _num = Convert.ToInt32(dt1.Rows[i]["rstj_byhj"].ToString());
                            _M_num = Convert.ToInt32(dt1.Rows[i]["rstj_m"].ToString());
                            _PM_num = Convert.ToInt32(dt1.Rows[i]["rstj_pm"].ToString());
                            _FP_num = Convert.ToInt32(dt1.Rows[i]["rstj_fp"].ToString());
                            _JY_num = Convert.ToInt32(dt1.Rows[i]["rstj_jy"].ToString());
                            _W_num = Convert.ToInt32(dt1.Rows[i]["rstj_w"].ToString());
                            _PZ_num = Convert.ToInt32(dt1.Rows[i]["rstj_pz"].ToString());

                            _syhj_num = Convert.ToInt32(dt1.Rows[i]["rstj_byhj"].ToString());
                            string b_yf = old_yf.ToString();//补齐的月份
                            if (old_yf.ToString().Length < 2)
                                b_yf = "0" + old_yf.ToString();

                            _bz = dt1.Rows[i]["rstj_bz"].ToString();
                            //插入rs_tj表,补齐记录
                            SaveToRstj(_bm, _num, _M_num, _PM_num, _FP_num, _JY_num, _W_num, _PZ_num, _syhj_num, _bdrs_num, _bdxq, max_nf, b_yf, _rq, _bz);
                        }
                    }
                    for (int old_yf = 1; old_yf < Int32.Parse(yf); old_yf++)//补齐第二年
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            _bm = dt1.Rows[i]["rstj_bm"].ToString();
                            _num = Convert.ToInt32(dt1.Rows[i]["rstj_byhj"].ToString());
                            _M_num = Convert.ToInt32(dt1.Rows[i]["rstj_m"].ToString());
                            _PM_num = Convert.ToInt32(dt1.Rows[i]["rstj_pm"].ToString());
                            _FP_num = Convert.ToInt32(dt1.Rows[i]["rstj_fp"].ToString());
                            _JY_num = Convert.ToInt32(dt1.Rows[i]["rstj_jy"].ToString());
                            _W_num = Convert.ToInt32(dt1.Rows[i]["rstj_w"].ToString());
                            _PZ_num = Convert.ToInt32(dt1.Rows[i]["rstj_pz"].ToString());

                            _syhj_num = Convert.ToInt32(dt1.Rows[i]["rstj_byhj"].ToString());
                            string b_yf = old_yf.ToString();//补齐的月份
                            if (old_yf.ToString().Length < 2)
                                b_yf = "0" + old_yf.ToString();
                            _bz = dt1.Rows[i]["rstj_bz"].ToString();
                            //插入rs_tj表,补齐记录
                            SaveToRstj(_bm, _num, _M_num, _PM_num, _FP_num, _JY_num, _W_num, _PZ_num, _syhj_num, _bdrs_num, _bdxq, nf, b_yf, _rq, _bz);
                        }
                    }

                }
                #endregion
            }




            #region 本月统计入库

            string bm = "";
            int num = 0;
            int M_num = 0;
            int PM_num = 0;
            int FP_num = 0;
            int JY_num = 0;
            int W_num = 0;
            int PZ_num = 0;

            int syhj_num = 0;
            int bdrs_num = 0;
            string bdxq = "";
            string bz = "";

            //获得本月最新统计
            for (int i = 0; i < dt.Rows.Count; i++)
            {



                #region 不能用dt,因为dgStatPerMonth_ItemDataBound已经改变了一个人多部门情况的人数
                //				bm=dt.Rows[i]["ry_bm"].ToString();
                //				if(dt.Rows[i]["num"].ToString()!="")
                //					num=Convert.ToInt32(dt.Rows[i]["num"].ToString());
                //				if(dt.Rows[i]["M_num"].ToString()!="")
                //					M_num=Convert.ToInt32(dt.Rows[i]["M_num"].ToString());
                //				if(dt.Rows[i]["PM_num"].ToString()!="")
                //					PM_num=Convert.ToInt32(dt.Rows[i]["PM_num"].ToString());
                //				if(dt.Rows[i]["FP_num"].ToString()!="")
                //					FP_num=Convert.ToInt32(dt.Rows[i]["FP_num"].ToString());
                //				if(dt.Rows[i]["JY_num"].ToString()!="")
                //					JY_num=Convert.ToInt32(dt.Rows[i]["JY_num"].ToString());
                //				if(dt.Rows[i]["W_num"].ToString()!="")
                //					W_num=Convert.ToInt32(dt.Rows[i]["W_num"].ToString());
                //				if(dt.Rows[i]["PZ_num"].ToString()!="")
                //					PZ_num=Convert.ToInt32(dt.Rows[i]["PZ_num"].ToString());
                #endregion
                bm = this.dgStatPerMonth.Items[i].Cells[1].Text;
                num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[2].Text);
                M_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[3].Text);
                PM_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[4].Text);
                FP_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[5].Text);
                JY_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[6].Text);
                W_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[7].Text);
                PZ_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[8].Text);


                syhj_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[9].Text);
                bdrs_num = Int32.Parse(this.dgStatPerMonth.Items[i].Cells[10].Text);
                bdxq = this.dgStatPerMonth.Items[i].Cells[11].Text;
                bz = this.lab_bz.Text;


                //插入rs_tj表，若以前插入过该月记录，则更新。
                SaveToRstj(bm, num, M_num, PM_num, FP_num, JY_num, W_num, PZ_num, syhj_num, bdrs_num, bdxq, nf, yf, rq, bz);

            }
            #endregion

        }

        private void SaveToRstj(string bm, int num, int M_num, int PM_num, int FP_num,
            int JY_num, int W_num, int PZ_num, int syhj_num, int bdrs_num, string bdxq, string nf, string yf, string rq, string bz)
        {
            int ret = Stoke.Components.Staff.InsertRstj(bm, num, M_num, PM_num, FP_num, JY_num, W_num, PZ_num, syhj_num, bdrs_num, bdxq, nf, yf, rq, bz);
        }


        private void DeleteRymdTemp()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "delete from dbo.rs_rstzd_rymd_temp";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void BindBm()
        {
            DataTable dt_bm = Stoke.BLL.Department.GetAll();

            this.ddlDdbm.DataSource = dt_bm;
            this.ddlDdbm.DataTextField = "bm_mc";
            this.ddlDdbm.DataValueField = "bm_mc";
            this.ddlDdbm.DataBind();
            this.ddlDdbm.Items.Insert(0, "-请选择-");
            this.ddlDdbm.SelectedIndex = 0;

            this.ddlDdybm.DataSource = dt_bm;
            this.ddlDdybm.DataTextField = "bm_mc";
            this.ddlDdybm.DataValueField = "bm_mc";
            this.ddlDdybm.DataBind();
            this.ddlDdybm.Items.Insert(0, "-请选择-");
            this.ddlDdybm.SelectedIndex = 0;

            DataTable dt_xmz = Stoke.Components.Staff.GetBmXmz2(1);
            this.ddlXmz.DataSource = dt_xmz;
            this.ddlXmz.DataTextField = "bm_mc";
            this.ddlXmz.DataValueField = "bm_mc";
            this.ddlXmz.DataBind();
            this.ddlXmz.Items.Insert(0, "-请选择-");
            this.ddlXmz.SelectedIndex = 0;

        }

        //		private void BindZw()
        //		{
        //			DataTable dt_zw = dsoc.BLL.Place.GetAll();
        //					
        //			this.ddlDdyzw.DataSource = dt_zw;
        //			this.ddlDdyzw.DataTextField = "zw_mc";
        //			this.ddlDdyzw.DataValueField = "zw_mc";
        //			this.ddlDdyzw.DataBind();
        //			this.ddlDdyzw.Items.Insert(0,"-请选择-");
        //			this.ddlDdyzw.SelectedIndex = 0;
        //
        //			this.ddlDdxzw.DataSource = dt_zw;
        //			this.ddlDdxzw.DataTextField = "zw_mc";
        //			this.ddlDdxzw.DataValueField = "zw_mc";
        //			this.ddlDdxzw.DataBind();
        //			this.ddlDdxzw.Items.Insert(0,"-请选择-");
        //			this.ddlDdxzw.SelectedIndex = 0;
        //		}

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            if (dt_style_data != null)
                if (dt_style_data.Rows.Count != 0)
                {
                    this.b.DataSource = dt_style_data;
                    this.b.DataValueField = "b";
                    this.b.DataTextField = "b";
                    this.b.DataBind();
                    this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
                    this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
                    this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
                    this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
                    this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
                    this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
                    this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
                    this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;


                }
            BindGrid();
        }

        private void BindGrid()
        {
            DataTable dt_rymd = Stoke.Components.Staff.SelectRstzdRymdById(doc_id);

            if (this.b.SelectedValue == "入职" || this.b.SelectedValue == "离职")
            {
                this.dbBd.DataSource = dt_rymd;
                this.dbBd.DataBind();
            }
            else if (this.b.SelectedValue == "调职")
            {
                this.dbDd.DataSource = dt_rymd;
                this.dbDd.DataBind();
            }
            else if (this.b.SelectedValue == "退休")
            {
                this.dbTx.DataSource = dt_rymd;
                this.dbTx.DataBind();
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
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            this.btnZwBack.Click += new System.EventHandler(this.btnZwBack_Click);
            this.btnZwClose.Click += new System.EventHandler(this.btnZwClose_Click);
            this.btnZwBack2.Click += new System.EventHandler(this.btnZwBack2_Click);
            this.btnZwClose2.Click += new System.EventHandler(this.btnZwClose2_Click);
            this.b.SelectedIndexChanged += new System.EventHandler(this.b_SelectedIndexChanged);
            this.e.TextChanged += new System.EventHandler(this.e_TextChanged);
            this.ddlDdbm.SelectedIndexChanged += new System.EventHandler(this.ddlDdbm_SelectedIndexChanged);
            this.ddlXmz.SelectedIndexChanged += new System.EventHandler(this.ddlXmz_SelectedIndexChanged);
            this.ddlDdxm.SelectedIndexChanged += new System.EventHandler(this.ddlDdxm_SelectedIndexChanged);
            this.btnXgw.Click += new System.EventHandler(this.btnXgw_Click);
            this.btnYgw.Click += new System.EventHandler(this.btnYgw_Click);
            this.btn_dd_add.Click += new System.EventHandler(this.btn_dd_add_Click);
            this.dbDd.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbDd_CancelCommand);
            this.dbDd.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbDd_EditCommand);
            this.dbDd.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbDd_UpdateCommand);
            this.dbDd.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbDd_DeleteCommand);
            this.dbDd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbDd_ItemDataBound);
            this.dbDd.SelectedIndexChanged += new System.EventHandler(this.dbDd_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.dbBd.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbBd_CancelCommand);
            this.dbBd.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbBd_EditCommand);
            this.dbBd.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbBd_UpdateCommand);
            this.dbBd.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbBd_DeleteCommand);
            this.dbBd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbBd_ItemDataBound);
            this.btn_txry.Click += new System.EventHandler(this.btn_txry_Click);
            this.dbTx.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbTx_CancelCommand);
            this.dbTx.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbTx_EditCommand);
            this.dbTx.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbTx_UpdateCommand);
            this.dbTx.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbTx_DeleteCommand);
            this.dbTx.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbTx_ItemDataBound);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.dgStatPerMonth.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgStatPerMonth_ItemDataBound);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1)
            {
                if (b.SelectedValue == "0" || c.Text == "" || d.Text == "" || this.e.Text == "")
                {
                    Response.Write("<script>alert('请填写带*的项！')</script>");
                    return;
                }
                SaveData();
                int ret = Stoke.Components.Staff.InsertFlowRstzdRymd(doc_id);
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=35&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
            }
            else
            {
                SaveData();
                //				if(step_id==4)
                //					SaveToRstzd(doc_id);
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=35&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, c.Text.ToString() + "人事通知单");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                df = null;
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
                    return ((DropDownList)StyleControl).SelectedItem.Text.ToString();
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text.ToString();
                default:
                    return "";
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
                //Response.Redirect("../Workflow/Work_Record.aspx");
                Response.Redirect(ViewState["retu"].ToString());
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void b_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DeleteRymdTemp();
            this.Table6.Visible = false;
            if (b.SelectedValue == "0")
            {
                this.Table3.Visible = false;
                this.Table4.Visible = false;
                this.Table5.Visible = false;
            }
            else if (b.SelectedValue == "1")
            {
                this.Table3.Visible = false;
                this.Table4.Visible = true;
                this.Table5.Visible = false;
            }
            else if (b.SelectedValue == "2")
            {
                this.Table3.Visible = false;
                this.Table4.Visible = true;
                this.Table5.Visible = false;
            }
            else if (b.SelectedValue == "3")
            {
                this.Table3.Visible = true;
                this.Table4.Visible = false;
                this.Table5.Visible = false;
            }
            else if (b.SelectedValue == "4")
            {
                this.Table3.Visible = false;
                this.Table4.Visible = false;
                this.Table5.Visible = true;
            }
        }


        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = false;
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            string ry_xm_list = SlctMember1.Send[0].ToString().Trim();
            string ry_zgbh_list = SlctMember1.Send[1].ToString().Trim();
            string _xm = "";
            string _zgbh = "";
            string _bm = "";
            string _zw = "";
            string sqlStr = "";
            DateTime _htqssj = new DateTime();
            DateTime _htjzsj = new DateTime();
            DateTime _cjgzsj = new DateTime();
            for (int i = 0; i < ry_xm_list.Split(',').Length; i++)
            {
                _xm = ry_xm_list.Split(',')[i].ToString().Trim();
                _zgbh = ry_zgbh_list.Split(',')[i].ToString().Trim();
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                sqlStr = "select ry_bm,ry_zw,htqssj,htzzsj,cjgzsj,pylx from rs_staff,dsoc_ry,dsoc_bm where rs_staff.ry_zgbh='" + _zgbh + "' and rs_staff.ry_zgbh=dsoc_ry.ry_zgbh and rtrim(ry_bm)=rtrim(bm_mc)";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                try
                {
                    _bm = dt.Rows[0][0].ToString();
                    _zw = "";
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        _zw += dt.Rows[j][0].ToString() + "-" + dt.Rows[j][1].ToString() + " / ";
                    }
                    _zw = _zw.Substring(0, _zw.LastIndexOf('/'));
                    _htqssj = Convert.ToDateTime(dt.Rows[0][2].ToString());
                    _htjzsj = Convert.ToDateTime(dt.Rows[0][3].ToString());
                    _cjgzsj = Convert.ToDateTime(dt.Rows[0][4].ToString());
                    _zgbh = dt.Rows[0][5].ToString() + _zgbh;
                }
                catch
                {
                    _htqssj = Convert.ToDateTime("1900-1-1 0:00:00");
                    _htjzsj = Convert.ToDateTime("1900-1-1 0:00:00");
                    _cjgzsj = Convert.ToDateTime("1900-1-1 0:00:00");
                }

                //				connString=System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                //				conn=new SqlConnection(connString);
                //				cmd=new SqlCommand("sp_Rs_GetBmZwbyZgbh",conn);
                //				cmd.CommandType=CommandType.StoredProcedure;
                //				cmd.Parameters.Add("@ry_zgbh",SqlDbType.VarChar,10);
                //
                //				try
                //				{
                //					cmd.Parameters["@ry_zgbh"].Value=_zgbh;
                //					SqlDataAdapter adapter1=new SqlDataAdapter(cmd);
                //					DataSet ds1=new DataSet();
                //					adapter1.Fill(ds1);
                //					DataTable table=ds1.Tables[0];
                //					string position="";
                //					for(int j=0;j<table.Rows.Count;j++)
                //					{
                //						position+=table.Rows[j][0].ToString()+" / ";
                //					}
                //					position=position.ToString().Substring(0,position.LastIndexOf('/'));
                //				}
                //				catch
                //				{
                //				}
                //				conn.Close();


                connString = StokeGlobals.Connectiondsoc;
                conn = new SqlConnection(connString);
                conn.Open();
                if (doc_id > 0)
                {
                    if (this.Table4.Visible == true)
                        sqlStr = "declare @rstzd_zzgx int;select @rstzd_zzgx = bm_bh from dsoc_bm where rtrim(bm_mc) = '" + _bm.Trim() + "';insert into dbo.rs_rstzd_rymd(doc_id,rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_gw,rstzd_htkssj,rstzd_htjzsj,rstzd_zzgx) values ('" + doc_id + "','" + _bm + "','" + _xm + "','" + _zgbh + "','" + _zw + "','" + _htqssj + "','" + _htjzsj + "', @rstzd_zzgx)";
                    else if (this.Table5.Visible == true)
                        //						sqlStr = "insert into dbo.rs_rstzd_rymd(doc_id,rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_gw,rstzd_htkssj) values ('"+doc_id+"','"+_bm+"','"+_xm +"','"+_zgbh+"','"+_zw+"','"+_htqssj +"')";
                        sqlStr = "declare @rstzd_zzgx int;select @rstzd_zzgx = bm_bh from dsoc_bm where rtrim(bm_mc) = '" + _bm.Trim() + "';insert into dbo.rs_rstzd_rymd(doc_id,rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_gw,rstzd_htkssj,rstzd_zzgx) values ('" + doc_id + "','" + _bm + "','" + _xm + "','" + _zgbh + "','" + _zw + "','" + _cjgzsj + "', @rstzd_zzgx)"; // 2009/09/03  绑定参加工作时间
                }
                else
                {
                    if (this.Table4.Visible == true)
                        sqlStr = "declare @rstzd_zzgx int;select @rstzd_zzgx = bm_bh from dsoc_bm where rtrim(bm_mc) = '" + _bm.Trim() + "';insert into dbo.rs_rstzd_rymd_temp(rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_gw,rstzd_htkssj,rstzd_htjzsj,rstzd_zzgx) values ('" + _bm + "','" + _xm + "','" + _zgbh + "','" + _zw + "','" + _htqssj + "','" + _htjzsj + "', @rstzd_zzgx)";
                    //					else if(this.Table5.Visible==true)
                    //						sqlStr = "insert into dbo.rs_rstzd_rymd_temp(rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_gw,rstzd_htkssj) values ('"+_bm+"','"+_xm +"','"+_zgbh+"','"+_zw+"','"+_htqssj +"')";
                    else if (this.Table5.Visible == true)
                        sqlStr = "declare @rstzd_zzgx int;select @rstzd_zzgx = bm_bh from dsoc_bm where rtrim(bm_mc) = '" + _bm.Trim() + "';insert into dbo.rs_rstzd_rymd_temp(rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_gw,rstzd_htkssj,rstzd_zzgx) values ('" + _bm + "','" + _xm + "','" + _zgbh + "','" + _zw + "','" + _cjgzsj + "', @rstzd_zzgx)";  // 2009/09/03  绑定参加工作时间
                }
                cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            if (this.Table4.Visible == true)
                MyDataBind(this.dbBd);
            else if (this.Table5.Visible == true)
                MyDataBind(this.dbTx);
            this.SlctMember1.Clear();
            this.Table6.Visible = false;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = true;
        }

        public void MyDataBind(DataGrid dbgrid)
        {
            string sqlstring = "";
            if (doc_id > 0)
                sqlstring = "select *, rtrim(bm_mc) as rstzd_zzgx_str from rs_rstzd_rymd left join dsoc_bm on rstzd_zzgx = bm_bh where doc_id= '" + doc_id + "' order by rstzd_id";
            else
                sqlstring = "select *, rtrim(bm_mc) as rstzd_zzgx_str from rs_rstzd_rymd_temp left join dsoc_bm on rstzd_zzgx = bm_bh order by rstzd_id";
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlstring, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dbgrid.DataSource = dt;
            dbgrid.DataBind();
        }

        private void dbBd_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.Cells[11].Text == "1900-01-01")
                e.Item.Cells[11].Text = "";
            if (e.Item.Cells[12].Text == "1900-01-01")
                e.Item.Cells[12].Text = "无固定";
            if (step_id != 1)
            {
                e.Item.Cells[14].Visible = false;
                e.Item.Cells[15].Visible = false;
            }
            if (step_id == 5)
            {
                e.Item.Cells[6].Visible = false;
                e.Item.Cells[7].Visible = false;
                e.Item.Cells[8].Visible = false;
                e.Item.Cells[9].Visible = false;
                e.Item.Cells[10].Visible = false;
            }
            if (step_id == 0 && _zgbh == Zgbh_laststep())
            {
                e.Item.Cells[6].Visible = false;
                e.Item.Cells[7].Visible = false;
                e.Item.Cells[8].Visible = false;
                e.Item.Cells[9].Visible = false;
                e.Item.Cells[10].Visible = false;
            }
        }

        private void dbBd_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            this.dbBd.EditItemIndex = i;
            rstzd_id = Convert.ToInt32(this.dbBd.Items[i].Cells[0].Text);
            MyDataBind(dbBd);
            TextBox txt_bm = (TextBox)this.dbBd.Items[i].Cells[2].Controls[0];
            TextBox txt_gwdj = (TextBox)this.dbBd.Items[i].Cells[6].Controls[0];
            TextBox txt_jbgz = (TextBox)this.dbBd.Items[i].Cells[7].Controls[0];
            TextBox txt_gdgz = (TextBox)this.dbBd.Items[i].Cells[8].Controls[0];
            TextBox txt_qtgz = (TextBox)this.dbBd.Items[i].Cells[9].Controls[0];
            TextBox txt_fxbzj = (TextBox)this.dbBd.Items[i].Cells[10].Controls[0];
            txt_bm.Width = Unit.Pixel(150);
            txt_gwdj.Width = Unit.Pixel(55);
            txt_jbgz.Width = Unit.Pixel(55);
            txt_gdgz.Width = Unit.Pixel(55);
            txt_qtgz.Width = Unit.Pixel(55);
            txt_fxbzj.Width = Unit.Pixel(55);

            BindData4();
            DropDownList drop4 = (DropDownList)dbBd.Items[e.Item.ItemIndex].FindControl("drop3");
            string drop3_selectedValue = drop4.SelectedValue;
            string _zgbh = dbBd.Items[e.Item.ItemIndex].Cells[4].Text.Trim();
            _zgbh = _zgbh.Substring(_zgbh.Length - 4, 4);

            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            DataTable dt = new DataTable();
            string sqlStr = "select rtrim(A.bm_mc) as rstzd_zzgx_str, A.bm_bh as rstzd_zzgx from dsoc_bm A right join dsoc_ry B on rtrim(A.bm_mc) = rtrim(B.ry_bm) where A.bm_xmz = '0' and B.ry_zgbh = '" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            drop4.Items.Clear();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                drop4.Items.Add(new ListItem(dt.Rows[j][0].ToString().Trim(), dt.Rows[j][1].ToString().Trim()));
            }
            //			drop3.DataSource = dt;
            //			drop3.DataValueField = "rstzd_zzgx";
            //			drop3.DataTextField = "rstzd_zzgx_str";
            //			drop3.DataBind();
            drop4.SelectedValue = drop3_selectedValue;
        }

        private void dbBd_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            int zdbh = Convert.ToInt32(this.dbBd.Items[i].Cells[0].Text);
            TextBox txt_bm = (TextBox)this.dbBd.Items[i].Cells[2].Controls[0];
            TextBox txt_gwdj = (TextBox)this.dbBd.Items[i].Cells[6].Controls[0];
            TextBox txt_jbgz = (TextBox)this.dbBd.Items[i].Cells[7].Controls[0];
            TextBox txt_gdgz = (TextBox)this.dbBd.Items[i].Cells[8].Controls[0];
            TextBox txt_qtgz = (TextBox)this.dbBd.Items[i].Cells[9].Controls[0];
            TextBox txt_fxbzj = (TextBox)this.dbBd.Items[i].Cells[10].Controls[0];
            string bm = txt_bm.Text;
            string gwdj = txt_gwdj.Text;
            string jbgz = txt_jbgz.Text;
            string gdgz = txt_gdgz.Text;
            string qtgz = txt_qtgz.Text;
            string fxbzj = txt_fxbzj.Text;
            int rstzd_zzgx = Convert.ToInt32(((DropDownList)this.dbBd.Items[e.Item.ItemIndex].FindControl("drop3")).SelectedValue);
            if (doc_id > 0)
                Stoke.Components.Staff.UpdateRstzdRymd(zdbh, gwdj, jbgz, gdgz, qtgz, fxbzj, bm, rstzd_zzgx);
            else
                Stoke.Components.Staff.UpdateRstzdRymdTemp(zdbh, gwdj, jbgz, gdgz, qtgz, fxbzj, bm, rstzd_zzgx);
            this.dbBd.EditItemIndex = -1;
            MyDataBind(dbBd);
        }

        private void dbBd_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            this.dbBd.EditItemIndex = -1;
            MyDataBind(dbBd);
        }

        private void dbBd_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (doc_id > 0)
                Stoke.Components.Staff.DeleteRstzdRymdByZdbh2(Int32.Parse(e.Item.Cells[0].Text));
            else
                Stoke.Components.Staff.DeleteRstzdRymdTempByZdbh2(Int32.Parse(e.Item.Cells[0].Text));
            MyDataBind(dbBd);
        }

        private void ddlDdbm_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string bm = this.ddlDdbm.SelectedItem.Text.Trim();
            if (bm != "-请选择-")
            {
                if (this.ddlXmz.SelectedIndex == 0)
                {
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    //dxq 9.9增加distinct
                    string sqlStr = "select  distinct ry_xm,ry_zgbh  from dsoc_ry where rtrim(ry_bm) = '" + bm + "' order by ry_zgbh asc";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlDdxm.DataSource = dr;
                    ddlDdxm.DataTextField = "ry_xm";
                    ddlDdxm.DataValueField = "ry_xm";
                    ddlDdxm.DataBind();
                    ddlDdxm.Items.Insert(0, "-请选择-");
                    ddlDdxm.SelectedIndex = 0;
                    ddlDdzh.Items.Clear();
                    ddlDdzh.Items.Insert(0, "-请选择-");
                    ddlDdzh.SelectedIndex = 0;
                    dr.Close();
                    conn.Close();
                }
                else
                {
                    string xmz = this.ddlXmz.SelectedValue.Trim();
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string sqlStr = "select ry_xm from dsoc_ry where ry_zgbh in (select distinct ry_zgbh from dsoc_ry where rtrim(ry_bm) = '" + bm + "') and rtrim(ry_bm)='" + xmz + "' order by ry_zgbh asc";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlDdxm.DataSource = dr;
                    ddlDdxm.DataTextField = "ry_xm";
                    ddlDdxm.DataValueField = "ry_xm";
                    ddlDdxm.DataBind();
                    ddlDdxm.Items.Insert(0, "-请选择-");
                    ddlDdxm.SelectedIndex = 0;
                    ddlDdzh.Items.Clear();
                    ddlDdzh.Items.Insert(0, "-请选择-");
                    ddlDdzh.SelectedIndex = 0;
                    dr.Close();
                    conn.Close();
                }
            }
            else
            {
                ddlDdxm.Items.Clear();
                ddlDdxm.Items.Insert(0, "-请选择-");
                ddlDdxm.SelectedIndex = 0;
                ddlDdzh.Items.Clear();
                ddlDdzh.Items.Insert(0, "-请选择-");
                ddlDdzh.SelectedIndex = 0;
            }
        }

        private void ddlDdxm_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string xm = this.ddlDdxm.SelectedItem.Text.Trim();
            if (xm != "-请选择-")
            {
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sqlStr = "select ry_zgbh from dsoc_ry where rtrim(ry_bm) = '" + this.ddlDdbm.SelectedValue + "' and rtrim(ry_xm) = '" + xm + "'  order by ry_zgbh asc";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                ddlDdzh.DataSource = dt;
                ddlDdzh.DataTextField = "ry_zgbh";
                ddlDdzh.DataValueField = "ry_zgbh";
                ddlDdzh.DataBind();
                string ry_zgbh = dt.Rows[0]["ry_zgbh"].ToString().Trim();
                dt = new DataTable();
                sqlStr = "select rtrim(A.bm_mc) as bm_mc, A.bm_bh from dsoc_bm A right join dsoc_ry B on rtrim(A.bm_mc) = rtrim(B.ry_bm) where A.bm_xmz = '0' and B.ry_zgbh = '" + ry_zgbh + "'";
                cmd = new SqlCommand(sqlStr, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                this.ddlZzgx.DataSource = dt;
                this.ddlZzgx.DataValueField = "bm_bh";
                this.ddlZzgx.DataTextField = "bm_mc";
                this.ddlZzgx.DataBind();
                this.ddlZzgx.Items.Insert(0, "-请选择-");
                this.ddlZzgx.SelectedIndex = 0;
                conn.Close();
                this.ddlBmdd.SelectedIndex = 0;
            }
            else
            {
                ddlDdzh.Items.Clear();
                ddlDdzh.Items.Insert(0, "-请选择-");
                ddlDdzh.SelectedIndex = 0;
                ddlZzgx.Items.Clear();
                this.ddlBmdd.SelectedIndex = 0;
            }
        }

        private void btn_dd_add_Click(object sender, System.EventArgs e)
        {
            if (this.ddlDdbm.SelectedValue == "-请选择-" || this.ddlDdxm.SelectedValue == "-请选择-" || this.ddlDdzh.SelectedValue == "-请选择-" || this.ddlBmdd.SelectedValue == "-请选择-" || this.ddlZzgx.SelectedValue.Trim() == "-请选择-")
            {
                Response.Write("<script>alert('请填写带*的项！')</script>");
                return;
            }
            string _bm = this.ddlDdbm.SelectedValue.Trim();
            string _xm = this.ddlDdxm.SelectedValue.Trim();
            string _zgbh = this.ddlDdzh.SelectedValue.Trim();
            //9.11dxq,插入部门调动判断，是或者否
            string bmdd = this.ddlBmdd.SelectedValue.Trim();
            string _ybm = "";
            string _ygw = "";
            string _gw = "";
            if (this.ddlDdybm.SelectedIndex != 0)
                _ybm = this.ddlDdybm.SelectedValue.Trim();
            //			if(this.ddlDdybm.SelectedIndex!=0)
            //				_ygw = this.ddlDdyzw.SelectedValue.Trim();
            //			if(this.ddlDdybm.SelectedIndex!=0)
            //				_gw = this.ddlDdxzw.SelectedValue.Trim();
            _ygw = this.txtDdyzw.Text;
            _gw = this.txtDdxzw.Text;
            string pylx = "";
            Stoke.Components.Staff person = new Stoke.Components.Staff();
            SqlDataReader dr = person.GetStaffInfo(_zgbh);
            if (dr.Read())
            {
                pylx = dr["pylx"].ToString();
            }
            _zgbh = pylx + _zgbh;

            string sqlStr = "";
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            //9.10dxq插入标准位，判断是否是部门调动，而非项目组.返回1是部门之间
            int rstzd_flag = 1;
            if (_ybm != "" && _bm != "")
                rstzd_flag = Judge(_ybm, _bm);

            string zzgx = this.ddlZzgx.SelectedValue.Trim();

            if (this.Table3.Visible == true)
            {
                if (doc_id > 0)
                    sqlStr = "insert into dbo.rs_rstzd_rymd(doc_id,rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_ybm,rstzd_ygw,rstzd_gw,rstzd_flag,rstzd_bmdd,rstzd_zzgx) values ('" + doc_id + "','" + _bm + "','" + _xm + "','" + _zgbh + "','" + _ybm + "','" + _ygw + "','" + _gw + "','" + rstzd_flag + "','" + bmdd + "','" + zzgx + "')";
                else
                    sqlStr = "insert into dbo.rs_rstzd_rymd_temp(rstzd_bm,rstzd_xm,rstzd_zgbh,rstzd_ybm,rstzd_ygw,rstzd_gw,rstzd_flag,rstzd_bmdd,rstzd_zzgx) values ('" + _bm + "','" + _xm + "','" + _zgbh + "','" + _ybm + "','" + _ygw + "','" + _gw + "','" + rstzd_flag + "','" + bmdd + "','" + zzgx + "')";
            }
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (this.Table3.Visible == true)
                MyDataBind(this.dbDd);
        }

        private int Judge(string ybm, string bm)
        {

            int bm_xmz1 = Get_bm_xmz(ybm);
            int bm_xmz2 = Get_bm_xmz(bm);
            if (bm_xmz1 == 1 || bm_xmz2 == 1)//有一个是项目组
                return 0;
            else return 1;


        }
        private int Get_bm_xmz(string bm)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //			string sqlStr = "select bm_xmz from dsoc_bm where bm_mc like '%"+bm+"%'";
            string sqlStr = "select bm_xmz from dsoc_bm where bm_mc='" + bm + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            int bm_xmz = 0;
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][0].ToString() != "")
                    bm_xmz = int.Parse(dt.Rows[0][0].ToString());
            }

            return bm_xmz;
        }

        private void dbDd_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            this.dbDd.EditItemIndex = i;
            rstzd_id = Convert.ToInt32(this.dbDd.Items[i].Cells[0].Text);
            MyDataBind(dbDd);
            TextBox txt_bm = (TextBox)this.dbDd.Items[i].Cells[2].Controls[0];
            txt_bm.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
            txt_bm.Width = Unit.Pixel(100);
            txt_bm.Height = Unit.Pixel(50);

            TextBox txt_ybm = (TextBox)this.dbDd.Items[i].Cells[5].Controls[0];
            txt_ybm.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
            txt_ybm.Width = Unit.Pixel(100);
            txt_ybm.Height = Unit.Pixel(50);
            TextBox txt_ygw = (TextBox)this.dbDd.Items[i].Cells[6].Controls[0];
            txt_ygw.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
            txt_ygw.Height = Unit.Pixel(50);
            TextBox txt_xgw = (TextBox)this.dbDd.Items[i].Cells[7].Controls[0];
            txt_xgw.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
            txt_xgw.Height = Unit.Pixel(50);
            TextBox txt_ygwdj = (TextBox)this.dbDd.Items[i].Cells[8].Controls[0];
            TextBox txt_gwdj = (TextBox)this.dbDd.Items[i].Cells[9].Controls[0];
            TextBox txt_jbgz = (TextBox)this.dbDd.Items[i].Cells[10].Controls[0];
            TextBox txt_gdgz = (TextBox)this.dbDd.Items[i].Cells[11].Controls[0];
            TextBox txt_qtgz = (TextBox)this.dbDd.Items[i].Cells[12].Controls[0];
            TextBox txt_yfxbzj = (TextBox)this.dbDd.Items[i].Cells[13].Controls[0];
            TextBox txt_fxbzj = (TextBox)this.dbDd.Items[i].Cells[14].Controls[0];
            txt_ygwdj.Width = Unit.Pixel(55);
            txt_gwdj.Width = Unit.Pixel(55);
            txt_jbgz.Width = Unit.Pixel(55);
            txt_gdgz.Width = Unit.Pixel(55);
            txt_qtgz.Width = Unit.Pixel(55);
            txt_yfxbzj.Width = Unit.Pixel(55);
            txt_fxbzj.Width = Unit.Pixel(55);

            BindData2();
            DropDownList drop2 = (DropDownList)dbDd.Items[e.Item.ItemIndex].FindControl("drop1");
            //			if(drop2.SelectedValue=="是")
            //				drop2.Items.Add("否");
            //			else
            //				drop2.Items.Add("是");
            if (drop2.SelectedValue == "是")
            {
                drop2.Items.Clear();
                drop2.Items.Add("是");
                drop2.Items.Add("否");
                drop2.SelectedValue = "是";
            }
            else
            {
                drop2.Items.Clear();
                drop2.Items.Add("是");
                drop2.Items.Add("否");
                drop2.SelectedValue = "否";
            }

            BindData3();
            DropDownList drop3 = (DropDownList)dbDd.Items[e.Item.ItemIndex].FindControl("drop2");
            string drop2_selectedValue = drop3.SelectedValue;
            string _zgbh = dbDd.Items[e.Item.ItemIndex].Cells[4].Text.Trim();
            _zgbh = _zgbh.Substring(_zgbh.Length - 4, 4);

            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            DataTable dt = new DataTable();
            string sqlStr = "select rtrim(A.bm_mc) as rstzd_zzgx_str, A.bm_bh as rstzd_zzgx from dsoc_bm A right join dsoc_ry B on rtrim(A.bm_mc) = rtrim(B.ry_bm) where A.bm_xmz = '0' and B.ry_zgbh = '" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            drop3.Items.Clear();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                drop3.Items.Add(new ListItem(dt.Rows[j][0].ToString().Trim(), dt.Rows[j][1].ToString().Trim()));
            }
            //			drop3.DataSource = dt;
            //			drop3.DataValueField = "rstzd_zzgx";
            //			drop3.DataTextField = "rstzd_zzgx_str";
            //			drop3.DataBind();
            drop3.SelectedValue = drop2_selectedValue;


        }

        private void dbDd_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            int zdbh = Convert.ToInt32(this.dbDd.Items[i].Cells[0].Text);
            TextBox txt_ybm = (TextBox)this.dbDd.Items[i].Cells[5].Controls[0];
            TextBox txt_ygw = (TextBox)this.dbDd.Items[i].Cells[6].Controls[0];
            TextBox txt_xgw = (TextBox)this.dbDd.Items[i].Cells[7].Controls[0];
            TextBox txt_ygwdj = (TextBox)this.dbDd.Items[i].Cells[8].Controls[0];
            TextBox txt_gwdj = (TextBox)this.dbDd.Items[i].Cells[9].Controls[0];
            TextBox txt_jbgz = (TextBox)this.dbDd.Items[i].Cells[10].Controls[0];
            TextBox txt_gdgz = (TextBox)this.dbDd.Items[i].Cells[11].Controls[0];
            TextBox txt_qtgz = (TextBox)this.dbDd.Items[i].Cells[12].Controls[0];
            TextBox txt_yfxbzj = (TextBox)this.dbDd.Items[i].Cells[13].Controls[0];
            TextBox txt_fxbzj = (TextBox)this.dbDd.Items[i].Cells[14].Controls[0];
            TextBox txt_bm = (TextBox)this.dbDd.Items[i].Cells[2].Controls[0];
            string ybm = txt_ybm.Text;
            string ygw = txt_ygw.Text;
            string xgw = txt_xgw.Text;
            string ygwdj = txt_ygwdj.Text;
            string gwdj = txt_gwdj.Text;
            string jbgz = txt_jbgz.Text;
            string gdgz = txt_gdgz.Text;
            string qtgz = txt_qtgz.Text;
            string yfxbzj = txt_yfxbzj.Text;
            string fxbzj = txt_fxbzj.Text;
            string bm = txt_bm.Text;
            int zzgx = Convert.ToInt32(((DropDownList)dbDd.Items[e.Item.ItemIndex].FindControl("drop2")).SelectedValue);


            string bmdd = ((DropDownList)dbDd.Items[e.Item.ItemIndex].FindControl("drop1")).SelectedValue;


            int rstzd_flag = 1;
            if (ybm != "" && bm != "")
                rstzd_flag = Judge(ybm, bm);

            if (doc_id > 0)
                Stoke.Components.Staff.UpdateRstzdRymd2(zdbh, ybm, ygw, xgw, ygwdj, gwdj, jbgz, gdgz, qtgz, yfxbzj, fxbzj, bm, rstzd_flag, bmdd, zzgx);
            else
                Stoke.Components.Staff.UpdateRstzdRymdTemp2(zdbh, ybm, ygw, xgw, ygwdj, gwdj, jbgz, gdgz, qtgz, yfxbzj, fxbzj, bm, rstzd_flag, bmdd, zzgx);
            this.dbDd.EditItemIndex = -1;
            MyDataBind(dbDd);
        }

        private void dbDd_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            this.dbDd.EditItemIndex = -1;
            MyDataBind(dbDd);
        }


        private string Zgbh_laststep()
        {
            string bh = "";
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str1 = "select obj_id from Dsoc_Flow_Member_Bind where flow_id= '" + 35 + "' and step_id='" + 5 + "'";
            SqlCommand cmd = new SqlCommand(str1, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetValue(0).ToString() != "")
                    bh = dr.GetValue(0).ToString();

            }
            dr.Close();
            conn.Close();
            return bh;
        }

        private void dbDd_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (step_id != 1)
            {
                e.Item.Cells[17].Visible = false;
                e.Item.Cells[18].Visible = false;
            }
            //12.5dxq 最后一步和工作查看中，人事员不能看到工资信息
            if (step_id == 5)
            {
                e.Item.Cells[8].Visible = false;
                e.Item.Cells[9].Visible = false;
                e.Item.Cells[10].Visible = false;
                e.Item.Cells[11].Visible = false;
                e.Item.Cells[12].Visible = false;
                e.Item.Cells[13].Visible = false;
                e.Item.Cells[14].Visible = false;
            }

            if (step_id == 0 && _zgbh == Zgbh_laststep())
            {
                e.Item.Cells[8].Visible = false;
                e.Item.Cells[9].Visible = false;
                e.Item.Cells[10].Visible = false;
                e.Item.Cells[11].Visible = false;
                e.Item.Cells[12].Visible = false;
                e.Item.Cells[13].Visible = false;
                e.Item.Cells[14].Visible = false;
            }

        }

        private void dbDd_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (doc_id > 0)
                Stoke.Components.Staff.DeleteRstzdRymdByZdbh2(Int32.Parse(e.Item.Cells[0].Text));
            else
                Stoke.Components.Staff.DeleteRstzdRymdTempByZdbh2(Int32.Parse(e.Item.Cells[0].Text));
            MyDataBind(dbDd);
        }

        private void SaveToRstzd(int doc_id)
        {
            int rstzd_fblx = 0;
            if (b.SelectedValue == "入职")
                rstzd_fblx = 1;
            else if (b.SelectedValue == "离职")
                rstzd_fblx = 2;
            else if (b.SelectedValue == "调职")
                rstzd_fblx = 3;
            else if (b.SelectedValue == "退休")
                rstzd_fblx = 4;
            string rstzd_bh = this.c.Text;
            string rstzd_sy = this.d.Text;
            string rstzd_nr = this.e.Text;
            string rstzd_jbr = this.f.Text;
            string rstzd_bmfzr = this.g.Text;
            string rstzd_zgfz = this.h.Text;
            string rstzd_zjl = this.i.Text;
            string rstzd_rq = this.j.Text;
            int ret = Stoke.Components.Staff.InsertRstzd(doc_id, rstzd_fblx, rstzd_bh, rstzd_sy, rstzd_nr, rstzd_jbr, rstzd_bmfzr, rstzd_zgfz, rstzd_zjl, rstzd_rq);
        }

        private void btn_txry_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = true;
        }

        private void dbTx_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            this.dbTx.EditItemIndex = i;
            MyDataBind(dbTx);
            TextBox txt_bm = (TextBox)this.dbTx.Items[i].Cells[2].Controls[0];
            TextBox txt_txsj = (TextBox)this.dbTx.Items[i].Cells[7].Controls[0];
            TextBox txt_txylj = (TextBox)this.dbTx.Items[i].Cells[8].Controls[0];
            txt_bm.Width = Unit.Pixel(120);
            txt_txsj.Width = Unit.Pixel(120);
            txt_txylj.Width = Unit.Pixel(80);
        }

        private void dbTx_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            int zdbh = Convert.ToInt32(this.dbTx.Items[i].Cells[0].Text);
            TextBox txt_bm = (TextBox)this.dbTx.Items[i].Cells[2].Controls[0];
            TextBox txt_txsj = (TextBox)this.dbTx.Items[i].Cells[7].Controls[0];
            TextBox txt_txylj = (TextBox)this.dbTx.Items[i].Cells[8].Controls[0];
            string txsj = txt_txsj.Text;
            string txylj = txt_txylj.Text;
            string bm = txt_bm.Text;
            int ret = -1;
            if (doc_id > 0)
                ret = Stoke.Components.Staff.UpdateRstzdRymd3(zdbh, txsj, txylj, bm);
            else
                ret = Stoke.Components.Staff.UpdateRstzdRymdTemp3(zdbh, txsj, txylj, bm);
            if (ret == -1)
                Response.Write("<script>alert('请正确填写退休时间！')</script>");
            this.dbTx.EditItemIndex = -1;
            MyDataBind(dbTx);
        }

        private void dbTx_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            this.dbTx.EditItemIndex = -1;
            MyDataBind(dbTx);
        }

        private void dbTx_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (doc_id > 0)
                Stoke.Components.Staff.DeleteRstzdRymdByZdbh2(Int32.Parse(e.Item.Cells[0].Text));
            else
                Stoke.Components.Staff.DeleteRstzdRymdTempByZdbh2(Int32.Parse(e.Item.Cells[0].Text));
            MyDataBind(dbTx);
        }

        private void dbTx_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.Cells[6].Text == "1900-01-01")
                e.Item.Cells[6].Text = "";
            if (step_id != 1)
            {
                e.Item.Cells[9].Visible = false;
                e.Item.Cells[10].Visible = false;
            }
            if (step_id == 5)
                e.Item.Cells[8].Visible = false;
            if (step_id == 0 && _zgbh == Zgbh_laststep())
                e.Item.Cells[8].Visible = false;

        }

        private void btnZwBack_Click(object sender, System.EventArgs e)
        {
            string _zw = SlctPosition1.Send[0].ToString().Trim();
            this.txtDdyzw.Text = _zw;
            this.SlctPosition1.Clear();
            this.Table8.Visible = false;
        }

        private void btnZwClose_Click(object sender, System.EventArgs e)
        {
            this.Table8.Visible = false;
        }

        private void btnZwBack2_Click(object sender, System.EventArgs e)
        {
            string _zw = SlctPosition2.Send[0].ToString().Trim();
            this.txtDdxzw.Text = _zw;
            this.SlctPosition2.Clear();
            this.Table9.Visible = false;
        }

        private void btnZwClose2_Click(object sender, System.EventArgs e)
        {
            this.Table9.Visible = false;
        }

        private void btnYgw_Click(object sender, System.EventArgs e)
        {
            this.Table8.Visible = true;
        }

        private void btnXgw_Click(object sender, System.EventArgs e)
        {
            this.Table9.Visible = true;
        }

        private void ddlXmz_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ddlDdbm.SelectedIndex != 0)
            {
                string bm = this.ddlDdbm.SelectedItem.Text.Trim();
                string xmz = "";
                string sqlStr = "";
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                if (this.ddlXmz.SelectedIndex != 0)
                {
                    xmz = this.ddlXmz.SelectedValue.Trim();
                    conn.Open();
                    sqlStr = "select  ry_xm from dsoc_ry where ry_zgbh in (select distinct ry_zgbh from dsoc_ry where rtrim(ry_bm) = '" + bm + "') and rtrim(ry_bm)='" + xmz + "' order by ry_zgbh asc";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlDdxm.DataSource = dr;
                    ddlDdxm.DataTextField = "ry_xm";
                    ddlDdxm.DataValueField = "ry_xm";
                    ddlDdxm.DataBind();
                    ddlDdxm.Items.Insert(0, "-请选择-");
                    ddlDdxm.SelectedIndex = 0;
                    ddlDdzh.Items.Clear();
                    ddlDdzh.Items.Insert(0, "-请选择-");
                    ddlDdzh.SelectedIndex = 0;
                    dr.Close();
                    conn.Close();
                }
                else
                {
                    conn.Open();
                    sqlStr = "select ry_xm from dsoc_ry where rtrim(ry_bm) = '" + bm + "' order by ry_zgbh asc";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlDdxm.DataSource = dr;
                    ddlDdxm.DataTextField = "ry_xm";
                    ddlDdxm.DataValueField = "ry_xm";
                    ddlDdxm.DataBind();
                    ddlDdxm.Items.Insert(0, "-请选择-");
                    ddlDdxm.SelectedIndex = 0;
                    this.ddlDdzh.Items.Clear();
                    ddlDdzh.Items.Insert(0, "-请选择-");
                    ddlDdzh.SelectedIndex = 0;
                    dr.Close();
                    conn.Close();
                }
            }
            else
                Response.Write("<script>alert('请先选择部门！')</script>");
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            this.Label1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + this.Label1.Text + "<br>";
            this.Label2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + this.Label2.Text + "<br>";
            this.Label3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + this.Label3.Text + "<br>";
            this.Label4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + this.c.Text + "<br>";
            this.Label5.Text = this.d.Text + "<br>";
            this.Label6.Text = this.e.Text + "<br>";
            this.Label7.Text = "<br>" + this.labJbr1.Text + "：" + this.f.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            this.Label8.Text = this.labZgfzr1.Text + "：" + this.g.Text + "<br>";
            if (this.h.Text == string.Empty)
                this.Label9.Text = this.labZgfz1.Text + "：" + this.h.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            else
                this.Label9.Text = this.labZgfz1.Text + "：" + this.h.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            this.Label10.Text = this.labZjl1.Text + "：" + this.i.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            this.Label11.Text = this.labRq1.Text + "：" + this.j.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp";

            this.ExportDataGrid("application/ms-word", "海工公司人事通知单" + ".doc");
        }

        //输出到word
        private void ExportDataGrid(string FileType, string FileName)
        {
            Response.Charset = "GB2312";
            //			Response.ContentEncoding=System.Text.Encoding.GetEncoding("GB2312");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AppendHeader("Content-Disposition", "attachment;filename="
                + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            Response.ContentType = FileType;

            this.EnableViewState = false;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            this.Label1.RenderControl(hw);
            this.Label2.RenderControl(hw);
            this.Label3.RenderControl(hw);
            this.Label4.RenderControl(hw);
            this.Label5.RenderControl(hw);
            this.Label6.RenderControl(hw);
            //防止DataGrid进行了分页，此处将其设置为false，再输出
            //			this.dbDd.AllowPaging=false;
            this.BindGrid();
            if (this.b.SelectedValue == "入职" || this.b.SelectedValue == "离职")
                this.dbBd.RenderControl(hw);
            else if (this.b.SelectedValue == "调职")
                this.dbDd.RenderControl(hw);
            else if (this.b.SelectedValue == "退休")
                this.dbTx.RenderControl(hw);

            this.Label7.RenderControl(hw);
            this.Label8.RenderControl(hw);
            this.Label9.RenderControl(hw);
            this.Label10.RenderControl(hw);
            this.Label11.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }

        private void dgStatPerMonth_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {

            #region if
            if (e.Item.ItemIndex >= 0)
            {
                if (e.Item.Cells[3].Text == "&nbsp;")
                    e.Item.Cells[3].Text = "0";
                if (e.Item.Cells[4].Text == "&nbsp;")
                    e.Item.Cells[4].Text = "0";
                if (e.Item.Cells[5].Text == "&nbsp;")
                    e.Item.Cells[5].Text = "0";
                if (e.Item.Cells[6].Text == "&nbsp;")
                    e.Item.Cells[6].Text = "0";
                if (e.Item.Cells[7].Text == "&nbsp;")
                    e.Item.Cells[7].Text = "0";
                if (e.Item.Cells[8].Text == "&nbsp;")
                    e.Item.Cells[8].Text = "0";


                string nf = "";
                string yf = "";
                if (j.Text.ToString() != "")
                {
                    nf = this.j.Text.Substring(0, 4);
                    yf = this.j.Text.Substring(5, 2);
                }
                else
                {
                    yf = Convert.ToString(System.DateTime.Now.Month.ToString("00"));
                    nf = Convert.ToString(System.DateTime.Now.Year);
                }


                int num_rz = Stoke.Components.Staff.ReportYgddRz(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                //				DataTable dt_rz_ry = Stoke.Components.Staff.ReportYgddRzRy(int.Parse(nf),int.Parse(yf),e.Item.Cells[1].Text.ToString().Trim());
                DataTable dt_rz_ry = Stoke.Components.Staff.ReportYgddRzRy1(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                string str_bd = " 入职:" + num_rz.ToString();
                if (dt_rz_ry != null)
                    if (dt_rz_ry.Rows.Count != 0)
                    {
                        str_bd += "( ";
                        for (int i = 0; i < dt_rz_ry.Rows.Count; i++)
                        {
                            str_bd += dt_rz_ry.Rows[i][1].ToString().Trim();
                            str_bd += " ";
                        }
                        str_bd += ")";
                    }

                int num_lz = Stoke.Components.Staff.ReportYgddLz(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                //				DataTable dt_lz_ry = Stoke.Components.Staff.ReportYgddLzRy(int.Parse(nf),int.Parse(yf),e.Item.Cells[1].Text.ToString().Trim());
                DataTable dt_lz_ry = Stoke.Components.Staff.ReportYgddLzRy1(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                str_bd += " 离职:" + num_lz.ToString();
                if (dt_lz_ry != null)
                    if (dt_lz_ry.Rows.Count != 0)
                    {
                        str_bd += "( ";
                        for (int i = 0; i < dt_lz_ry.Rows.Count; i++)
                        {
                            str_bd += dt_lz_ry.Rows[i][1].ToString().Trim();
                            str_bd += " ";
                        }
                        str_bd += ")";
                    }


                //				int num_dr = Stoke.Components.Staff.ReportYgddDr(int.Parse(this.ddlNf.SelectedValue),int.Parse(this.ddlYf.SelectedValue),e.Item.Cells[1].Text.ToString().Trim());
                //				DataTable dt_dr_ry = Stoke.Components.Staff.ReportYgddDrRy(int.Parse(this.ddlNf.SelectedValue),int.Parse(this.ddlYf.SelectedValue),e.Item.Cells[1].Text.ToString().Trim());

                int num_dr = Stoke.Components.Staff.ReportYgddDr1(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                DataTable dt_dr_ry = Stoke.Components.Staff.ReportYgddDrRy1(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                str_bd += " 调入:" + num_dr.ToString();
                if (dt_dr_ry != null)
                    if (dt_dr_ry.Rows.Count != 0)
                    {
                        str_bd += "( ";
                        for (int i = 0; i < dt_dr_ry.Rows.Count; i++)
                        {
                            str_bd += dt_dr_ry.Rows[i][1].ToString().Trim();
                            str_bd += " ";
                        }
                        str_bd += ")";
                    }

                //				int num_dl = Stoke.Components.Staff.ReportYgddDl(int.Parse(this.ddlNf.SelectedValue),int.Parse(this.ddlYf.SelectedValue),e.Item.Cells[1].Text.ToString().Trim());
                //				DataTable dt_dl_ry = Stoke.Components.Staff.ReportYgddDlRy(int.Parse(this.ddlNf.SelectedValue),int.Parse(this.ddlYf.SelectedValue),e.Item.Cells[1].Text.ToString().Trim());
                int num_dl = Stoke.Components.Staff.ReportYgddDl1(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                DataTable dt_dl_ry = Stoke.Components.Staff.ReportYgddDlRy1(int.Parse(nf), int.Parse(yf), e.Item.Cells[1].Text.ToString().Trim());
                str_bd += " 调出:" + num_dl.ToString();
                if (dt_dl_ry != null)
                    if (dt_dl_ry.Rows.Count != 0)
                    {
                        str_bd += "( ";
                        for (int i = 0; i < dt_dl_ry.Rows.Count; i++)
                        {
                            str_bd += dt_dl_ry.Rows[i][1].ToString().Trim();
                            str_bd += " ";
                        }
                        str_bd += ")";
                    }



                e.Item.Cells[11].Text = str_bd;
                int num_bd = num_rz - num_lz + num_dr - num_dl;
                e.Item.Cells[9].Text = Convert.ToString(Int32.Parse(e.Item.Cells[2].Text) - num_bd);
                e.Item.Cells[10].Text = num_bd.ToString();
            }
            #endregion

            #region 页脚
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                string bz = "";
                DataTable _dt = Stoke.Components.Staff.GetRyTwoBm();//ry_zgbh
                if (_dt != null)
                    if (_dt.Rows.Count != 0)
                    {
                        bz = "其中:";
                        for (int i = 0; i < _dt.Rows.Count; i++)
                        {
                            DataTable _dt1 = Stoke.Components.Staff.GetRyTwoBm2(_dt.Rows[i][0].ToString().Trim());//ry_xm,ry_bm
                            bz = bz + _dt1.Rows[0][0].ToString().Trim() + "分别属于";
                            for (int j = 0; j < _dt1.Rows.Count; j++)
                            {
                                bz = bz + _dt1.Rows[j][1].ToString() + ",";
                                if (j > 0)
                                    for (int k = 0; k < this.dgStatPerMonth.Items.Count; k++)
                                    {
                                        if (this.dgStatPerMonth.Items[k].Cells[1].Text.Trim() == _dt1.Rows[j][1].ToString().Trim())
                                        {
                                            this.dgStatPerMonth.Items[k].Cells[2].Text = (int.Parse(this.dgStatPerMonth.Items[k].Cells[2].Text) - 1).ToString();
                                            //											sum_syhj = sum_syhj - 1;
                                        }
                                    }
                            }
                            //							Stoke.Components.Staff person = new Stoke.Components.Staff();
                            //							SqlDataReader dr = person.GetStaffInfo(_dt.Rows[i][0].ToString());
                            //							if(dr.Read ())
                            //							{
                            //								switch(dr["pylx"].ToString())
                            //								{
                            //									case "M":
                            //									{
                            //										sum_m--;
                            //										break;
                            //									}
                            //									case "PM":
                            //									{
                            //										sum_pm--;
                            //										break;
                            //									}
                            //									case "FP":
                            //									{
                            //										sum_fp--;
                            //										break;
                            //									}
                            //									case "PW":
                            //									{
                            //										sum_w--;
                            //										break;
                            //									}
                            //								}
                            //							}
                            //							dr.Close();

                            ///////////////////////////////////////
                            //判断是否是项目组
                            ///////////////////////////////////////

                            string bm_xmz = "";
                            for (int m = 0; m < _dt1.Rows.Count; m++)
                            {
                                bm_xmz = _dt1.Rows[m][1].ToString();
                                int flag = Get_bm_xmz(bm_xmz);
                                if (flag == 0)
                                    break;

                            }

                            //							bz = bz + "计入" + _dt1.Rows[0][1].ToString();
                            bz = bz + "计入" + bm_xmz;


                            bz += "<br>";
                            bz += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

                            //							e.Item.Cells[2].Text=(sum - _dt1.Rows.Count + 1).ToString();
                            //							sum = int.Parse(e.Item.Cells[2].Text);
                        }

                    }
                this.lab_bz.Text = bz;//备注:其中陈钢分别属于生产管理部和调试工程部

                //				e.Item.Cells[1].Text="在职人数：" + sum_zz.ToString();
                //				e.Item.Cells[1].Text="合计：" ;
                //				
                //				e.Item.Cells[3].Text=sum_m.ToString();
                //				e.Item.Cells[4].Text=sum_pm.ToString();
                //				e.Item.Cells[5].Text=sum_fp.ToString();
                //				e.Item.Cells[6].Text=sum_jy.ToString();
                //				e.Item.Cells[7].Text=sum_w.ToString();
                //				e.Item.Cells[8].Text=sum_pz.ToString();
                //				e.Item.Cells[9].Text=sum_syhj.ToString();
                //				e.Item.Cells[10].Text=sum_bdrs.ToString();
                //				e.Item.Cells[11].Text="变动人数："+sum_bd.ToString();

            }
            #endregion

        }

        private void Button2_Click(object sender, System.EventArgs e)
        {

            if (c.Text == "" || b.SelectedValue == "0")
                Response.Write("<script>alert('请填写带*的项！')</script>");
            else
            {
                SaveData();
                int ret = Stoke.Components.Staff.InsertFlowRstzdRymd(doc_id);
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }

        }

        private void dbDd_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        public SqlDataReader BindData2()
        {

            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "";
            if (doc_id > 0)
                str = "select rstzd_bmdd  from rs_rstzd_rymd where rstzd_id='" + rstzd_id + "'";
            else
                str = "select rstzd_bmdd  from rs_rstzd_rymd_temp where rstzd_id='" + rstzd_id + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }

        public SqlDataReader BindData3()
        {

            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "";
            if (doc_id > 0)
                str = "select rstzd_zzgx, rtrim(bm_mc) as rstzd_zzgx_str from rs_rstzd_rymd, dsoc_bm where rstzd_id='" + rstzd_id + "' and rstzd_zzgx = bm_bh";
            else
                str = "select rstzd_zzgx, rtrim(bm_mc) as rstzd_zzgx_str from rs_rstzd_rymd_temp, dsoc_bm where rstzd_id='" + rstzd_id + "' and rstzd_zzgx = bm_bh";
            SqlCommand cmd = new SqlCommand(str, conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }
        public SqlDataReader BindData4()
        {

            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "";
            if (doc_id > 0)
                str = "select rstzd_zzgx, rtrim(bm_mc) as rstzd_zzgx_str from rs_rstzd_rymd, dsoc_bm where rstzd_id='" + rstzd_id + "' and rstzd_zzgx = bm_bh";
            else
                str = "select rstzd_zzgx, rtrim(bm_mc) as rstzd_zzgx_str from rs_rstzd_rymd_temp, dsoc_bm where rstzd_id='" + rstzd_id + "' and rstzd_zzgx = bm_bh";
            SqlCommand cmd = new SqlCommand(str, conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }

        private void e_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
