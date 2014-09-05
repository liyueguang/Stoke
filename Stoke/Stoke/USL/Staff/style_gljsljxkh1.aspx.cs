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
using System.Text.RegularExpressions;

namespace Stoke.USL.Staff
{
    public partial class style_gljsljxkh1 : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id = 1;
        private int doc_id = 0;
        private int flow_id = 39;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;
        private double score = 100;
        private double score_of_part1 = 80;
        private double score_of_part2 = 10;
        private double score_of_part3 = 10;
        private int lastEditedPage;

        private double sum_bkr = 0;
        private double sum_khr = 0;
        private double sum_khr1 = 0;
        private double sum_fhr = 0;
        private int zwjb;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            if ((doc_id == 0) && (this.txt_doc.Text != string.Empty))
                doc_id = int.Parse(this.txt_doc.Text);
            //根据doc_id判断执行表单数据的插入操作或更新操作
            if (doc_id > 0)
                bEditMode = true;

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            if (step_id == 8 || step_id == 9)
            {
                for (int i = 0; i < dgrd1.Items.Count; i++)
                {
                    //					if((this.dgrd1.Items[i].Cells[1].Text!="&nbsp;")&&(this.dgrd1.Items[i].Cells[5].Text!="&nbsp;"))
                    if ((((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() != "") && ((((TextBox)dgrd1.Items[i].FindControl("txtkhr")).Text.ToString() != "")))
                    {

                        this.btnSubmit.Attributes.Clear();
                        //						this.btnSubmit.Attributes.Add("onclick");
                        return;

                    }
                }

            }

            if (!Page.IsPostBack)
            {

                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                {
                    Step_Handle_Data();
                }

                #region 获得职位级别
                //获得员工职位级别，如果是总经理级别，级别为1
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string str = "select zwjb  from v_dsoc_ry_zwjb where ry_zgbh= '" + _zgbh + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetValue(0).ToString() != "")
                        zwjb = Convert.ToInt32(dr.GetValue(0).ToString());

                }
                dr.Close();
                conn.Close();
                #endregion

                BindData();//必须放在Step_Handle_Data()后面，因为当Step_Handle_Data()没有读出总分时，是BindData()读出来的


                //如果是副总，则自动读取自评分
                if (zwjb == 1 && step_id == 8)
                    bind_fzkh();


                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);
                //取得员工姓名(只是部门，不包括项目组)
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh1(_zgbh);
                _zgxm = dt_xm_bm.Rows[0][0].ToString().Trim();



                if ((step_id != 1) && (step_id != 3) && (step_id != 4) && (step_id != 5))
                {
                    this.Table4.Rows[2].Visible = false;

                }
                if (step_id == 2 || step_id == 7)
                {
                    this.Table4.Rows[2].Visible = false;
                    this.Table4.Rows[3].Visible = false;
                }

                if (step_id == 0)
                {

                    this.btnSave.Visible = false;
                    this.btnSubmit.Visible = false;
                }

                else if (step_id == 1)
                {
                    //年份
                    if (doc_id == 0)
                    {
                        this.f.Items.Add(System.DateTime.Now.AddYears(-1).Year.ToString());
                        this.f.Items.Add(System.DateTime.Now.Year.ToString());
                        this.f.Items.Add(System.DateTime.Now.AddYears(1).Year.ToString());
                        this.f.Items.Insert(0, "年份");
                        this.f.SelectedIndex = 0;
                    }



                    this.b.Text = _zgxm;
                    this.c.Text = _zgbh;
                    this.d.DataSource = dt_xm_bm;
                    this.d.DataValueField = "ry_bm";
                    this.d.DataTextField = "ry_bm";
                    this.d.DataBind();
                    this.e.DataSource = dt_xm_bm;
                    this.e.DataValueField = "ry_zw";
                    this.e.DataTextField = "ry_zw";
                    this.e.DataBind();
                    this.g1.Text = _zgxm;
                    this.h1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                    //获得部门和项目组的岗位
                    DataTable dt_zw = _staff.GetXmBmZwByZdbh(_zgbh);
                    string bmzw = "";
                    for (int i = 0; i < dt_zw.Rows.Count; i++)
                    {
                        string bm = dt_zw.Rows[i]["ry_bm"].ToString().Trim();
                        string zw = dt_zw.Rows[i]["ry_zw"].ToString().Trim();
                        bmzw += bm + "-" + zw + "/";
                    }
                    bmzw = bmzw.Substring(0, bmzw.Length - 1);
                    this.q1.Text = bmzw;


                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                }

                else if (step_id == 3)
                    this.i1.Text = _zgxm;
                else if (step_id == 4)
                    this.j1.Text = _zgxm;
                else if (step_id == 5)
                    this.k1.Text = _zgxm;
                else if (step_id == 6)
                    this.l1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                else if (step_id == 8)
                {
                    DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
                    if (dt_style_data.Rows[0]["e1"].ToString() == null || dt_style_data.Rows[0]["e1"].ToString() == "")
                        this.e1.Text = this.d1.Text;//wyw
                    this.m1.Text = _zgxm;

                }
                else if (step_id == 9)
                    this.n1.Text = _zgxm;
                else if (step_id == 10)
                {
                    this.o1.Text = _zgxm;
                    DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);

                    if (dt_style_data.Rows[0]["f1"].ToString() == null || dt_style_data.Rows[0]["f1"].ToString() == "")
                    {
                        this.f1.Text = this.e1.Text;
                        this.p1.Text = this.f1.Text;
                    }

                }
                else if (step_id == -1)
                {
                    SaveToJxkh();
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + _zgbh);
                }

                if (step_id == 8 || step_id == 9)
                {
                    for (int i = 0; i < dgrd1.Items.Count; i++)
                    {
                        //						if((this.dgrd1.Items[i].Cells[1].Text!="&nbsp;")&&(this.dgrd1.Items[i].Cells[5].Text=="&nbsp;"))
                        if ((((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() != "") && ((((TextBox)dgrd1.Items[i].FindControl("txtkhr")).Text.ToString() == "")))
                        {

                            this.btnSubmit.Attributes.Add("onclick", "return confirm('绩效分数填写不完整，确定要提交吗？')");
                            return;

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
            this.add.Click += new System.EventHandler(this.add_Click);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.dgrd1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrd1_ItemCommand);
            this.dgrd1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd1_PageIndexChanged);
            this.dgrd1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrd1_CancelCommand);
            this.dgrd1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrd1_EditCommand);
            this.dgrd1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrd1_UpdateCommand);
            this.dgrd1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgrd1_ItemDataBound);
            this.dgrd1.SelectedIndexChanged += new System.EventHandler(this.dgrd1_SelectedIndexChanged);
            this.f1.TextChanged += new System.EventHandler(this.f1_TextChanged);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void bind_fzkh()
        {
            string nr = "";
            string sj = "";
            string qz = "";
            string bkr = "";
            string khr = "";
            string fhr = "";

            int bh = 0;
            for (int i = 0; i < dgrd1.Items.Count; i++)
            {

                if (((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() != "")
                {


                    bh = Convert.ToInt32(dgrd1.DataKeys[i].ToString());
                    nr = ((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString();
                    sj = ((TextBox)dgrd1.Items[i].FindControl("txtsj")).Text.ToString();

                    if (((TextBox)dgrd1.Items[i].FindControl("txtbkr")).Text.ToString() != "")
                    {
                        string b = ((TextBox)dgrd1.Items[i].FindControl("txtbkr")).Text.ToString();
                        khr = b;
                    }


                    Stoke.Components.Staff.Update_Jx_gljsl(nr, sj, qz, bkr, khr, fhr, bh);
                }
            }

            this.j.Text = this.i.Text;
            this.p.Text = this.o.Text;
            this.v.Text = this.u.Text;
            this.b1.Text = this.a1.Text;

            DataTable dt = Stoke.Components.Staff.GetAll_gljsl_jh(doc_id);
            this.dgrd1.DataSource = dt;
            this.dgrd1.DataBind();



            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["gljh_khr"].ToString() != "")
                    sum_khr1 += Convert.ToDouble(dt.Rows[i]["gljh_khr"].ToString());

            }

            this.lbl2.Text = sum_khr1.ToString();




            if (j.Text != string.Empty)
                sum_khr1 += Convert.ToDouble(this.j.Text.ToString());
            if (p.Text != string.Empty)
                sum_khr1 += Convert.ToDouble(this.p.Text.ToString());
            if (v.Text != string.Empty)
                sum_khr1 += Convert.ToDouble(this.v.Text.ToString());
            if (b1.Text != string.Empty)
                sum_khr1 += Convert.ToDouble(this.b1.Text.ToString());
            this.e1.Text = sum_khr.ToString();//no use

            if (sum_khr1 != 0)
                this.e1.Text = sum_khr1.ToString();


        }

        private void BindData()
        {
            DataTable dt = Stoke.Components.Staff.GetAll_gljsl_jh(doc_id);
            this.dgrd1.DataSource = dt;
            this.dgrd1.DataBind();


            #region 方法4，遍历datatable,求第一部分总分
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["gljh_bkr"].ToString() != "")
                    sum_bkr += Convert.ToDouble(dt.Rows[i]["gljh_bkr"].ToString());
                if (dt.Rows[i]["gljh_khr"].ToString() != "")
                    sum_khr += Convert.ToDouble(dt.Rows[i]["gljh_khr"].ToString());
                if (dt.Rows[i]["gljh_fhr"].ToString() != "")
                    sum_fhr += Convert.ToDouble(dt.Rows[i]["gljh_fhr"].ToString());
            }
            this.lbl1.Text = sum_bkr.ToString();
            this.lbl2.Text = sum_khr.ToString();
            this.lbl3.Text = sum_fhr.ToString();

            //8.15dxq

            if (this.i.Text != string.Empty)
                sum_bkr += Convert.ToDouble(this.i.Text.ToString());
            if (o.Text != string.Empty)
                sum_bkr += Convert.ToDouble(this.o.Text.ToString());
            if (u.Text != string.Empty)
                sum_bkr += Convert.ToDouble(this.u.Text.ToString());
            if (a1.Text != string.Empty)
                sum_bkr += Convert.ToDouble(this.a1.Text.ToString());
            //			this.d1.Text=sum_bkr.ToString();


            if (j.Text != string.Empty)
                sum_khr += Convert.ToDouble(this.j.Text.ToString());
            if (p.Text != string.Empty)
                sum_khr += Convert.ToDouble(this.p.Text.ToString());
            if (v.Text != string.Empty)
                sum_khr += Convert.ToDouble(this.v.Text.ToString());
            if (b1.Text != string.Empty)
                sum_khr += Convert.ToDouble(this.b1.Text.ToString());
            //			this.e1.Text=sum_khr.ToString();


            if (k.Text != string.Empty)
                sum_fhr += Convert.ToDouble(this.k.Text.ToString());
            if (q.Text != string.Empty)
                sum_fhr += Convert.ToDouble(this.q.Text.ToString());
            if (w.Text != string.Empty)
                sum_fhr += Convert.ToDouble(this.w.Text.ToString());
            if (c1.Text != string.Empty)
                sum_fhr += Convert.ToDouble(this.c1.Text.ToString());
            //			this.f1.Text=sum_fhr.ToString();

            //考核阶段
            if (sum_bkr != 0)
                this.d1.Text = sum_bkr.ToString();
            if (sum_khr != 0)
                this.e1.Text = sum_khr.ToString();
            if (sum_fhr != 0)
                this.f1.Text = sum_fhr.ToString();
            #endregion

            int count = dgrd1.PageSize * dgrd1.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            this.dgrd1.DataBind();
            lastEditedPage = dgrd1.CurrentPageIndex;


            for (int i = 0; i < dgrd1.Items.Count; i++)
            {

                if ((((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() == ""))
                {
                    dgrd1.Items[i].Cells[7].Controls[0].Visible = false;
                    dgrd1.Items[i].Cells[0].Text = "&nbsp;";

                }
                else if (this.dgrd1.Items[i].Cells[9].Text == "1")//计划阶段，领导新增加的工作变色
                    this.dgrd1.Items[i].BackColor = System.Drawing.Color.FromName("#95b8ff");

                //				//考核阶段不能删除计划
                //				if((step_id!=1)&&(step_id!=3)&&(step_id!=4)&&(step_id!=5))
                //				{
                //					this.dgrd1.Items[i].Cells[8].Visible = false;
                //				}
                //				//文秘步骤不能操作
                //				if((step_id==2)||(step_id==7))
                //				{
                //					this.dgrd1.Items[i].Cells[7].Visible = false;
                //					this.dgrd1.Items[i].Cells[8].Visible = false;
                //				}


            }
            #region 求和方法1，遍历dgrd,但是只能遍历当前页
            //			for(int i=0;i<this.dgrd1.Items.Count;i++)
            //			{
            //				if((this.dgrd1.Items[i].Cells[4].Text!="&nbsp;")&&(this.dgrd1.Items[i].Cells[4].Text!=""))
            //					sum_bkr+=Convert.ToDouble(this.dgrd1.Items[i].Cells[4].Text);
            //				if((this.dgrd1.Items[i].Cells[5].Text!="&nbsp;")&&(this.dgrd1.Items[i].Cells[5].Text!=""))
            //					sum_khr+=Convert.ToDouble(this.dgrd1.Items[i].Cells[5].Text);
            //				if((this.dgrd1.Items[i].Cells[6].Text!="&nbsp;")&&(this.dgrd1.Items[i].Cells[6].Text!=""))
            //					sum_fhr+=Convert.ToDouble(this.dgrd1.Items[i].Cells[6].Text);
            //
            //			}
            //
            //			this.lbl1.Text=sum_bkr.ToString();
            //			this.lbl2.Text=sum_khr.ToString();
            //			this.lbl3.Text=sum_fhr.ToString();
            //			//考核阶段
            //			if(sum_bkr!=0)
            //				this.d1.Text=sum_bkr.ToString();
            //			if(sum_khr!=0)
            //				this.e1.Text=lbl2.Text;
            //			if(sum_fhr!=0)
            //				this.f1.Text=lbl3.Text;
            #endregion
            #region 求和方法2，直接读取数据库，此法可用，注意从0开始
            //			string connString = dsocGlobals.Connectiondsoc; 
            //			SqlConnection conn = new SqlConnection(connString);
            //			conn.Open();
            //			string str1 = "select sum(gljh_bkr) from rs_flow_jx_gljsl where gljh_docid= '"+ doc_id+"'";
            //			SqlCommand cmd = new SqlCommand(str1, conn);
            //			SqlDataReader dr = cmd.ExecuteReader();
            //			if(dr.Read())
            //			{
            //				this.lbl1.Text = dr.IsDBNull(0)? null : dr.GetValue(0).ToString();
            //				
            //			}
            //			dr.Close();
            //			conn.Close();
            #endregion

            #region 方法3，调用datatable的compute函数


            if (dt.Compute("Sum(gljh_bkr)", "true").ToString() != "")
            {
                double a = Convert.ToDouble(dt.Compute("Sum(gljh_bkr)", "true"));
            }

            #endregion


        }


        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);

            this.b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;

            if (step_id == 1)
            {
                this.f.Items.Add(System.DateTime.Now.AddYears(-1).Year.ToString());
                this.f.Items.Add(System.DateTime.Now.Year.ToString());
                this.f.Items.Add(System.DateTime.Now.AddYears(1).Year.ToString());
                this.f.Items.Insert(0, "年份");
                this.f.SelectedValue = dt_style_data.Rows[0]["f"].ToString() != "" ? dt_style_data.Rows[0]["f"].ToString() : "0";
                this.a.SelectedValue = dt_style_data.Rows[0]["a"].ToString() != "" ? dt_style_data.Rows[0]["a"].ToString() : "0";
            }
            else
            {
                this.a.DataSource = dt_style_data;
                this.a.DataValueField = "a";
                this.a.DataTextField = "a";
                this.a.DataBind();
                this.f.DataSource = dt_style_data;
                this.f.DataValueField = "f";
                this.f.DataTextField = "f";
                this.f.DataBind();
            }


            this.d.DataSource = dt_style_data;
            this.d.DataValueField = "d";
            this.d.DataTextField = "d";
            this.d.DataBind();
            this.e.DataSource = dt_style_data;
            this.e.DataValueField = "e";
            this.e.DataTextField = "e";
            this.e.DataBind();

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
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;
            this.z.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;
            this.a1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
            this.b1.Text = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : null;
            this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
            this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
            this.e1.Text = dt_style_data.Rows[0]["e1"].ToString() != null ? dt_style_data.Rows[0]["e1"].ToString() : null;
            this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;
            this.g1.Text = dt_style_data.Rows[0]["g1"].ToString() != null ? dt_style_data.Rows[0]["g1"].ToString() : null;
            this.h1.Text = dt_style_data.Rows[0]["h1"].ToString() != null ? dt_style_data.Rows[0]["h1"].ToString() : null;
            this.i1.Text = dt_style_data.Rows[0]["i1"].ToString() != null ? dt_style_data.Rows[0]["i1"].ToString() : null;
            this.j1.Text = dt_style_data.Rows[0]["j1"].ToString() != null ? dt_style_data.Rows[0]["j1"].ToString() : null;
            this.k1.Text = dt_style_data.Rows[0]["k1"].ToString() != null ? dt_style_data.Rows[0]["k1"].ToString() : null;
            this.l1.Text = dt_style_data.Rows[0]["l1"].ToString() != null ? dt_style_data.Rows[0]["l1"].ToString() : null;
            this.m1.Text = dt_style_data.Rows[0]["m1"].ToString() != null ? dt_style_data.Rows[0]["m1"].ToString() : null;
            this.n1.Text = dt_style_data.Rows[0]["n1"].ToString() != null ? dt_style_data.Rows[0]["n1"].ToString() : null;
            this.o1.Text = dt_style_data.Rows[0]["o1"].ToString() != null ? dt_style_data.Rows[0]["o1"].ToString() : null;
            this.p1.Text = dt_style_data.Rows[0]["p1"].ToString() != null ? dt_style_data.Rows[0]["p1"].ToString() : null;
            this.q1.Text = dt_style_data.Rows[0]["q1"].ToString() != null ? dt_style_data.Rows[0]["q1"].ToString() : null;
            this.r1.Text = dt_style_data.Rows[0]["r1"].ToString() != null ? dt_style_data.Rows[0]["r1"].ToString() : null;
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
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.CheckBox")
                {
                    ((CheckBox)StyleControl).Enabled = true;
                    ((CheckBox)StyleControl).BackColor = Color.White;
                }
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
                    return null;
            }
        }



        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            if (step_id == 1)
            {
                if (f.SelectedItem.Text == "年份" || a.SelectedValue == "月份")
                {
                    Response.Write("<script>alert('请填写年份和月份')</script>");
                    return;
                }

            }
            //dgrd1没有填写分数报错
            for (int i = 0; i < dgrd1.Items.Count; i++)
            {
                if (step_id == 1 || step_id == 3 || step_id == 4 || step_id == 5)
                {
                    if ((((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() != "") && ((((TextBox)dgrd1.Items[i].FindControl("txtqz")).Text.ToString() == "")))
                    {
                        Response.Write("<script>alert('请完整填写考核结第一部分并保存')</script>");
                        return;
                    }
                }
                if (step_id == 6)
                {
                    if ((((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() != "") && ((((TextBox)dgrd1.Items[i].FindControl("txtbkr")).Text.ToString() == "")))
                    {
                        Response.Write("<script>alert('请完整填写考核结第一部分并保存')</script>");
                        return;
                    }
                }
                //				if(step_id==8||step_id==9)
                //				{
                //					if((this.dgrd1.Items[i].Cells[1].Text!="&nbsp;")&&(this.dgrd1.Items[i].Cells[5].Text=="&nbsp;"))
                //					{
                ////						Response.Write("<script>alert('请完整填写考核结第一部分')</script>");
                ////						return;	
                //						
                //					}
                //					
                //				}

            }

            //防止填写分数但是没有保存，还能提交下一步.即判断是否有编辑状态
            for (int i = 0; i < dgrd1.Items.Count; i++)
            {

                if (step_id == 6)
                {
                    TextBox txtbkr = (TextBox)dgrd1.Items[i].FindControl("txtbkr");
                    if (txtbkr.ReadOnly == false)
                    {
                        Response.Write("<script>alert('请完整填写考核结第一部分并保存')</script>");
                        return;
                    }


                }
                if (step_id == 8 || step_id == 9)
                {
                    TextBox txtkhr = (TextBox)dgrd1.Items[i].FindControl("txtkhr");
                    if (txtkhr.ReadOnly == false)
                    {
                        Response.Write("<script>alert('请完整填写考核结第一部分并保存')</script>");
                        return;
                    }
                }
                if (step_id == 10)
                {
                    TextBox txtfhr = (TextBox)dgrd1.Items[i].FindControl("txtfhr");
                    if (txtfhr.ReadOnly == false)
                    {
                        Response.Write("<script>alert('请完整填写考核结第一部分并保存')</script>");
                        return;
                    }
                }



            }
            #region 统计分数,判断是否出错
            if (step_id == 1 || step_id == 3 || step_id == 4 || step_id == 5)//月初计划第一部分
            {
                double s1 = 0;


                //				string connString = dsocGlobals.Connectiondsoc; 
                //				SqlConnection conn = new SqlConnection(connString);
                //				conn.Open();
                //				string str1 = "select sum(gljh_qz) from rs_flow_jx_gljsl where gljh_docid= '"+ doc_id+"'";
                //				SqlCommand myCommand = new SqlCommand(str1, conn);
                //				s1=Double.Parse(myCommand.ExecuteScalar().ToString());
                //				conn.Close();

                //				doc_id=Int32.Parse(this.txt_doc.Text);
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string str1 = "select sum(gljh_qz) from rs_flow_jx_gljsl where gljh_docid= '" + doc_id + "'";
                SqlCommand cmd = new SqlCommand(str1, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetValue(0).ToString() != "")
                        s1 = Convert.ToDouble(dr.GetValue(0).ToString());

                }
                dr.Close();
                conn.Close();

                if (s1 != score_of_part1)
                {
                    Response.Write("<script>alert('工作计划第一部分不满足80分')</script>");
                    return;
                }

                if (s1 == 0)
                {
                    Response.Write("<script>alert('请填写工作计划第一部分分数并保存')</script>");
                    return;
                }
            }
            else if (step_id == 6)
            {
                double s3 = 0, s4 = 0, s5 = 0;//月末考核，被考核人
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string str1 = "select sum(gljh_bkr) from rs_flow_jx_gljsl where gljh_docid= '" + doc_id + "'";
                SqlCommand cmd = new SqlCommand(str1, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetValue(0).ToString() != "")
                        s3 = Convert.ToDouble(dr.GetValue(0).ToString());

                }
                dr.Close();
                conn.Close();
                if (s3 > score_of_part1)
                {
                    Response.Write("<script>alert('考核结果第一部分超出80分')</script>");
                    return;
                }

                else if (s3 == 0)
                {
                    Response.Write("<script>alert('请填写考核结果第一部分分数并保存')</script>");
                    return;
                }

                if (this.o.Text != string.Empty)
                    s4 += Convert.ToDouble(this.o.Text);
                if (this.u.Text != string.Empty)
                    s4 += Convert.ToDouble(this.u.Text);
                if (this.a1.Text != string.Empty)
                    s4 += Convert.ToDouble(this.a1.Text);

                if (s4 > score_of_part3)
                {
                    Response.Write("<script>alert('考核结果第三部分超出10分')</script>");
                    return;
                }

                if (this.i.Text != string.Empty)
                {
                    s5 = Convert.ToDouble(this.i.Text);
                    if (s5 > score_of_part2)
                    {
                        Response.Write("<script>alert('考核结果第二部分超出10分')</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写考核结果第二部分分数')</script>");
                    return;
                }

            }
            else if (step_id == 8 || step_id == 9)
            {
                double s6 = 0, s7 = 0, s8 = 0;//月末考核第一部分和第二部分，考核人1和考核人2
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string str1 = "select sum(gljh_khr) from rs_flow_jx_gljsl where gljh_docid= '" + doc_id + "'";
                SqlCommand cmd = new SqlCommand(str1, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetValue(0).ToString() != "")
                        s6 = Convert.ToDouble(dr.GetValue(0).ToString());

                }
                dr.Close();
                conn.Close();

                if (s6 > score_of_part1)
                {
                    Response.Write("<script>alert('考核结果第一部分超出80分')</script>");
                    return;
                }
                //				else if(s6==0)
                //				{
                //					Response.Write("<script>alert('请填写考核结果第一部分分数')</script>");
                //					return;
                //				}

                if (this.p.Text != string.Empty)
                    s7 += Convert.ToDouble(this.p.Text);
                if (this.v.Text != string.Empty)
                    s7 += Convert.ToDouble(this.v.Text);
                if (this.b1.Text != string.Empty)
                    s7 += Convert.ToDouble(this.b1.Text);
                if (s7 > score_of_part3)
                {
                    Response.Write("<script>alert('考核结果第三部分超出10分')</script>");
                    return;
                }

                if (this.j.Text != string.Empty)
                {
                    s8 = Convert.ToDouble(this.j.Text);
                    if (s8 > score_of_part2)
                    {
                        Response.Write("<script>alert('考核结果第二部分超出10分')</script>");
                        return;
                    }
                }
                //				else
                //				{
                //					Response.Write("<script>alert('请考核结果第二部分分数')</script>");
                //					return;
                //				}

                if (this.e1.Text != string.Empty)
                {
                    if (Convert.ToDouble(this.e1.Text) > score)
                    {
                        Response.Write("<script>alert('考核结果超出100分')</script>");
                        return;
                    }
                }
                //				else
                //				{
                //					Response.Write("<script>alert('请填写考核结果')</script>");
                //					return;
                //				}

            }
            else if (step_id == 10)
            {
                if (this.f1.Text != string.Empty)
                {
                    if (Convert.ToDouble(this.f1.Text) > score)
                    {
                        Response.Write("<script>alert('考核结果超出100分')</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写考核结果')</script>");
                    return;
                }

                if (this.p1.Text != string.Empty)
                {
                    if (Convert.ToDouble(this.p1.Text) > score)
                    {
                        Response.Write("<script>alert('考核结果超出100分')</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写考核结果')</script>");
                    return;
                }
            }
            #endregion





            SaveData();
            string _URL1 = "../Workflow/Work_Next_Step.aspx?flow_id=39&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
            Response.Redirect(_URL1);
        }

        private void add_Click(object sender, System.EventArgs e)
        {
            if (txt1.Text.Equals("") || txt2.Text == "" || txt3.Text == string.Empty)
            {
                Response.Write("<script>alert('请完整填写考核内容')</script>");
                return;
            }

            //产生流程，生成docid,并写入自创正式表
            SaveData();


            if (doc_id != 0)
            {
                /////////////////
                ////保存doc_id,因为点击提交时，会重新加载页面，使docid为零
                ////////////////
                this.txt_doc.Text = doc_id.ToString();


                if (a.SelectedItem.Text.Trim() != "月份")
                {
                    string nr = this.txt1.Text.ToString();
                    string sj = this.txt2.Text.ToString();
                    float qz = float.Parse(this.txt3.Text.ToString());
                    int flag = 0; ;
                    if (step_id == 3 || step_id == 4 || step_id == 5)
                        flag = 1;
                    Stoke.Components.Staff.InsertJx_gljsl(nr, sj, qz, doc_id, flag);

                    BindData();
                    this.txt1.Text = "";
                    this.txt2.Text = "";
                    this.txt3.Text = "";
                }

            }


        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            if (bEditMode == false)
            {
                //拟稿
                if (a.SelectedItem.Text.Trim().Equals("月份") || f.SelectedItem.Text.Trim().Equals("年份"))
                {
                    Response.Write("<script>alert('请填写年份和月份')</script>");
                    return;
                }
                mySql = GetStyleInsertData();
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, b.Text.Trim() + a.SelectedItem.Text.Trim() + "月份" + "绩效计划与考核");
                df = null;
            }
            else
            {
                /////////////////////////////////////////////////////////////
                ////这里可以修改Dsoc_Flow_Document的标题，如果月份发生变化时
                ///////////////////////////////////////////////////////////
                if (a.SelectedItem.Text.Trim() != "月份")
                {
                    string title = b.Text.Trim() + a.SelectedItem.Text.Trim() + "月份" + "绩效计划与考核";
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string str = "update  Dsoc_Flow_Document set Doc_Title='" + title + "'where Doc_ID= '" + doc_id + "'";
                    SqlCommand myCommand = new SqlCommand(str, conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    Response.Write("<script>alert('请填写年份和月份')</script>");
                    return;
                }


                mySql = GetStyleUpdateData(doc_id);
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

        private void dgrd1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            this.dgrd1.EditItemIndex = e.Item.ItemIndex;
            BindData();
            int i = e.Item.ItemIndex;


            #region 6.7duan 已不用
            //			if(step_id==1||step_id==3||step_id==4||step_id==5)
            //			{
            //				TextBox txt1 = (TextBox)this.dgrd1.Items[i].Cells[1].Controls[0];
            //				txt1.Width = Unit.Pixel(275);
            //				TextBox txt2 = (TextBox)this.dgrd1.Items[i].Cells[2].Controls[0];
            //				txt2.Width = Unit.Pixel(82);
            //				TextBox txt3 = (TextBox)this.dgrd1.Items[i].Cells[3].Controls[0];
            //				txt3.Width = Unit.Pixel(55);
            //			}
            //			if(step_id==6)
            //			{
            //				
            //				TextBox txt4 = (TextBox)this.dgrd1.Items[i].Cells[4].Controls[0];
            //				txt4.Width = Unit.Pixel(52);
            //			}
            //			//考核人
            //			if(step_id==8||step_id==9)
            //			{
            //				TextBox txt5 = (TextBox)this.dgrd1.Items[i].Cells[5].Controls[0];
            //				txt5.Width = Unit.Pixel(52);
            //			}
            //			if(step_id==10)
            //			{
            //				TextBox txt6 = (TextBox)this.dgrd1.Items[i].Cells[6].Controls[0];
            //				txt6.Width = Unit.Pixel(52);
            //			}
            #endregion

            #region 控制宽度和不同步骤可编辑的列，已不用
            TextBox txt1 = (TextBox)this.dgrd1.Items[i].Cells[1].Controls[0];
            txt1.Width = Unit.Pixel(275);
            TextBox txt2 = (TextBox)this.dgrd1.Items[i].Cells[2].Controls[0];
            txt2.Width = Unit.Pixel(82);
            TextBox txt3 = (TextBox)this.dgrd1.Items[i].Cells[3].Controls[0];
            txt3.Width = Unit.Pixel(55);
            TextBox txt4 = (TextBox)this.dgrd1.Items[i].Cells[4].Controls[0];
            txt4.Width = Unit.Pixel(52);
            TextBox txt5 = (TextBox)this.dgrd1.Items[i].Cells[5].Controls[0];
            txt5.Width = Unit.Pixel(52);
            TextBox txt6 = (TextBox)this.dgrd1.Items[i].Cells[6].Controls[0];
            txt6.Width = Unit.Pixel(52);
            //计划阶段
            if (step_id == 1 || step_id == 3 || step_id == 4 || step_id == 5)
            {
                txt4.Visible = false;
                txt5.Visible = false;
                txt6.Visible = false;
            }
            //被考核人
            if (step_id == 6)
            {
                //				txt1.Visible=false;
                //				txt2.Visible=false;
                //				txt3.Visible=false;
                //				txt5.Visible=false;
                //				txt6.Visible=false;

                txt1.ReadOnly = true;
                txt2.ReadOnly = true;
                txt3.ReadOnly = true;
                txt5.Visible = false;
                txt6.Visible = false;
            }
            //考核人
            if (step_id == 8 || step_id == 9)
            {
                txt1.ReadOnly = true;
                txt2.ReadOnly = true;
                txt3.ReadOnly = true;
                txt4.ReadOnly = true;
                txt6.Visible = false;
            }
            if (step_id == 10)
            {
                txt1.ReadOnly = true;
                txt2.ReadOnly = true;
                txt3.ReadOnly = true;
                txt4.ReadOnly = true;
                txt5.ReadOnly = true;
            }
            #endregion




        }

        private void dgrd1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (dgrd1.EditItemIndex == e.Item.ItemIndex)
            {

                //				float qz=0;
                //				float bkr=0;
                //				float khr=0;
                //				float fhr=0;
                string qz = "";
                string bkr = "";
                string khr = "";
                string fhr = "";
                int bh = Convert.ToInt32(dgrd1.DataKeys[e.Item.ItemIndex].ToString());
                string nr = ((TextBox)e.Item.Cells[1].Controls[0]).Text.ToString();
                string sj = ((TextBox)e.Item.Cells[2].Controls[0]).Text.ToString();

                if (((TextBox)e.Item.Cells[3].Controls[0]).Text.ToString() != "")
                {
                    string a = ((TextBox)e.Item.Cells[3].Controls[0]).Text.ToString();
                    if (IsNumeric(a))
                        //						qz=float.Parse(a);
                        qz = a;
                    else
                    {
                        Response.Write("<script>alert('请输入数字')</script>");
                        dgrd1.EditItemIndex = -1;
                        BindData();

                        ////////////////////
                        //return;如果不保存数字前的有效修改，则使用
                        /////////////////
                    }

                }
                if (((TextBox)e.Item.Cells[4].Controls[0]).Text.ToString() != "")
                {
                    string b = ((TextBox)e.Item.Cells[4].Controls[0]).Text.ToString();
                    if (IsNumeric(b))
                        //						bkr=float.Parse(b);
                        bkr = b;
                    else
                    {
                        Response.Write("<script>alert('请输入数字')</script>");
                        dgrd1.EditItemIndex = -1;
                        BindData();

                        ////////////////////
                        //return;如果不保存数字前的有效修改，则使用
                        /////////////////
                    }
                }
                if (((TextBox)e.Item.Cells[5].Controls[0]).Text.ToString() != "")
                {
                    string c = ((TextBox)e.Item.Cells[5].Controls[0]).Text.ToString();
                    if (IsNumeric(c))
                        //						khr=float.Parse(c);
                        khr = c;
                    else
                    {
                        Response.Write("<script>alert('请输入数字')</script>");
                        dgrd1.EditItemIndex = -1;
                        BindData();

                        ////////////////////
                        //return;如果不保存数字前的有效修改，则使用
                        /////////////////
                    }
                }
                if (((TextBox)e.Item.Cells[6].Controls[0]).Text.ToString() != "")
                {
                    string d = ((TextBox)e.Item.Cells[6].Controls[0]).Text.ToString();
                    if (IsNumeric(d))
                        //						fhr=float.Parse(d);
                        fhr = d;
                    else
                    {
                        Response.Write("<script>alert('请输入数字')</script>");
                        dgrd1.EditItemIndex = -1;
                        BindData();

                        ////////////////////
                        //return;如果不保存数字左边几个字符串字段的有效修改，则使用
                        /////////////////
                    }
                }

                //若分数为0，则不更新
                Stoke.Components.Staff.Update_Jx_gljsl(nr, sj, qz, bkr, khr, fhr, bh);
                dgrd1.EditItemIndex = -1;
                BindData();
            }
            else
            {
                dgrd1.EditItemIndex = e.Item.ItemIndex;
                BindData();
            }
        }

        private void dgrd1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            dgrd1.EditItemIndex = -1;
            BindData();
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


        private void dgrd1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {

                dgrd1.EditItemIndex = -1;
                int bh = Convert.ToInt32(dgrd1.DataKeys[e.Item.ItemIndex].ToString());
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string str = "delete from rs_flow_jx_gljsl  where gljh_id= '" + bh + "'";
                SqlCommand myCommand = new SqlCommand(str, conn);
                myCommand.ExecuteNonQuery();
                conn.Close();

                if ((dgrd1.PageCount - dgrd1.CurrentPageIndex) == 1 && dgrd1.Items.Count == 1)
                {
                    if (dgrd1.PageCount > 1)
                    {
                        lastEditedPage = lastEditedPage - 1;
                    }
                    else
                    {
                        lastEditedPage = 0;
                    }
                }
                dgrd1.CurrentPageIndex = lastEditedPage;
                BindData();
            }
        }

        private void f1_TextChanged(object sender, System.EventArgs e)
        {
            int _flagXmz = Stoke.Components.Staff.GetXmzFlag(this.c.Text.Trim());
            if (_flagXmz == 0)
                this.p1.Text = this.f1.Text;
            else
            {
                int _flagWZYX = Stoke.Components.Staff.GetWZYXFlag(this.c.Text.Trim());
                if (_flagWZYX == 0)
                {
                    this.p1.Text = Convert.ToString(Convert.ToDouble(this.e1.Text) * 0.7 + Convert.ToDouble(this.f1.Text) * 0.3);
                }
                else
                {
                    this.p1.Text = Convert.ToString(Convert.ToDouble(this.e1.Text) * 0.3 + Convert.ToDouble(this.f1.Text) * 0.7);
                }
            }
        }

        private void SaveToJxkh()
        {
            string zgbh = this.c.Text;
            string xm = this.b.Text;
            string bm = this.d.SelectedValue;
            string gw = this.e.SelectedValue;
            int nf = 0;
            int yf = 0;
            float zp = 0;
            float kh = 0;
            float fh = 0;
            float zf = 0;
            double xs = 0;
            float f = 0;
            //获取聘用类型
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "select pylx from rs_staff  where ry_zgbh= '" + zgbh + "'";
            SqlCommand myCommand = new SqlCommand(str, conn);
            string pylx = Convert.ToString(myCommand.ExecuteScalar());
            conn.Close();

            if (this.p1.Text != "")
                f = Convert.ToSingle(this.p1.Text);
            else
                f = Convert.ToSingle(this.e1.Text);
            if (f <= 90)
                xs = Convert.ToDouble(Math.Round(f / 90, 2));
            else
                xs = Convert.ToDouble(Math.Round(1 + (f - 90) * 0.02, 2));
            try
            {
                nf = int.Parse(this.f.SelectedItem.Text);
                yf = int.Parse(this.a.SelectedItem.Text);
                zp = float.Parse(this.d1.Text);
                kh = float.Parse(this.e1.Text);
                if (this.f1.Text != string.Empty)
                    fh = float.Parse(this.f1.Text);
                if (this.p1.Text != string.Empty)
                    zf = float.Parse(this.p1.Text);
                else
                    zf = float.Parse(this.e1.Text);
            }
            catch
            {
            }

            Stoke.Components.Staff.InsertGljslJxkh(zgbh, xm, bm, gw, nf, yf, zp, kh, fh, zf, pylx, xs, doc_id);

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveData();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            //			if(doc_id>0&&step_id==1)
            //			{
            //				Stoke.Components.Staff.DeleteDocument_jx(doc_id);
            //				Response.Redirect("../Workflow/Work_Manage.aspx");
            //			}
            //			else if(step_id==0)
            //				Response.Redirect("../Workflow/Work_Record.aspx");
            //			else
            //				Response.Redirect("../Workflow/Work_Manage.aspx");
            //--------------tonzoc-20101105----------------------
            int returnSearch = 0;
            if (Request.QueryString["returnSearch"] != string.Empty)
                returnSearch = Convert.ToInt32(Request.QueryString["returnSearch"]);
            if (doc_id > 0 && step_id == 1)
            {
                Stoke.Components.Staff.DeleteDocument_jx(doc_id);
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0 && returnSearch == 1)
            {
                Response.Redirect("jx_search.aspx");
            }
            else if (step_id == 0 && returnSearch != 1)
                Response.Redirect("../Workflow/Work_Record.aspx");
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
            //---------------------------------------------------
        }

        private void dgrd1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.dgrd1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        private void dgrd1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            //文秘步骤不能操作
            if ((step_id == 2) || (step_id == 7))
            {
                e.Item.Cells[7].Visible = false;

            }

            //考核阶段不能删除计划
            if ((step_id != 1) && (step_id != 3) && (step_id != 4) && (step_id != 5))
            {
                e.Item.Cells[7].Visible = false;
            }
            if (step_id == 0)
                e.Item.Cells[7].Visible = false;




        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < dgrd1.Items.Count; i++)
            {
                if (((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() != "")
                {
                    if (step_id == 1 || step_id == 3 || step_id == 4 || step_id == 5)
                    {
                        TextBox txtnr = (TextBox)dgrd1.Items[i].FindControl("txtnr");
                        txtnr.ReadOnly = false;
                        TextBox txtsj = (TextBox)dgrd1.Items[i].FindControl("txtsj");
                        txtsj.ReadOnly = false;
                        TextBox txtqz = (TextBox)dgrd1.Items[i].FindControl("txtqz");
                        txtqz.ReadOnly = false;
                    }
                    if (step_id == 6)
                    {
                        TextBox txtbkr = (TextBox)dgrd1.Items[i].FindControl("txtbkr");
                        txtbkr.ReadOnly = false;
                    }
                    if (step_id == 8 || step_id == 9)
                    {
                        TextBox txtkhr = (TextBox)dgrd1.Items[i].FindControl("txtkhr");
                        txtkhr.ReadOnly = false;
                    }
                    if (step_id == 10)
                    {
                        TextBox txtfhr = (TextBox)dgrd1.Items[i].FindControl("txtfhr");
                        txtfhr.ReadOnly = false;
                    }


                }
            }

        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            string nr = "";
            string sj = "";
            //			float qz=0;
            //			float bkr=0;
            //			float khr=0;
            //			float fhr=0;
            string qz = "";
            string bkr = "";
            string khr = "";
            string fhr = "";

            int bh = 0;
            for (int i = 0; i < dgrd1.Items.Count; i++)
            {

                if (((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString() != "")
                {


                    bh = Convert.ToInt32(dgrd1.DataKeys[i].ToString());
                    nr = ((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString();
                    sj = ((TextBox)dgrd1.Items[i].FindControl("txtsj")).Text.ToString();
                    //					nr=((TextBox)dgrd1.Items[i].FindControl("txtnr")).Text.ToString().Replace("'","''");
                    //					sj=((TextBox)dgrd1.Items[i].FindControl("txtsj")).Text.ToString().Replace("'","''");


                    if (((TextBox)dgrd1.Items[i].FindControl("txtqz")).Text.ToString() != "")
                    {
                        string a = ((TextBox)dgrd1.Items[i].FindControl("txtqz")).Text.ToString();

                        if (IsNumeric(a))
                            //	qz=float.Parse(a);
                            qz = a;
                        else
                        {
                            Response.Write("<script>alert('请输入数字')</script>");
                            dgrd1.EditItemIndex = -1;
                            BindData();

                            ////////////////////
                            //return;如果不保存数字前的有效修改，则使用
                            /////////////////
                        }




                    }
                    else
                        qz = "";

                    if (((TextBox)dgrd1.Items[i].FindControl("txtbkr")).Text.ToString() != "")
                    {
                        string b = ((TextBox)dgrd1.Items[i].FindControl("txtbkr")).Text.ToString();
                        if (IsNumeric(b))
                            //							bkr=float.Parse(a);
                            bkr = b;
                        else
                        {
                            Response.Write("<script>alert('请输入数字')</script>");
                            dgrd1.EditItemIndex = -1;
                            BindData();

                            ////////////////////
                            //return;如果不保存数字前的有效修改，则使用
                            /////////////////
                        }

                    }
                    else bkr = "";

                    if (((TextBox)dgrd1.Items[i].FindControl("txtkhr")).Text.ToString() != "")
                    {
                        string c = ((TextBox)dgrd1.Items[i].FindControl("txtkhr")).Text.ToString();
                        if (IsNumeric(c))
                            //							khr=float.Parse(a);
                            khr = c;
                        else
                        {
                            Response.Write("<script>alert('请输入数字')</script>");
                            dgrd1.EditItemIndex = -1;
                            BindData();

                            ////////////////////
                            //return;如果不保存数字前的有效修改，则使用
                            /////////////////
                        }

                    }
                    else
                        khr = "";
                    if (((TextBox)dgrd1.Items[i].FindControl("txtfhr")).Text.ToString() != "")
                    {
                        string d = ((TextBox)dgrd1.Items[i].FindControl("txtfhr")).Text.ToString();
                        if (IsNumeric(d))
                            //							fhr=float.Parse(d);
                            fhr = d;
                        else
                        {
                            Response.Write("<script>alert('请输入数字')</script>");
                            dgrd1.EditItemIndex = -1;
                            BindData();

                            ////////////////////
                            //return;如果不保存数字前的有效修改，则使用
                            /////////////////
                        }

                    }
                    else
                        fhr = "";



                    Stoke.Components.Staff.Update_Jx_gljsl(nr, sj, qz, bkr, khr, fhr, bh);
                }
            }


            dgrd1.EditItemIndex = -1;
            BindData();
        }

        private void dgrd1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
