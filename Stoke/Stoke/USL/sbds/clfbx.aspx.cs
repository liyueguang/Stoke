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
    public partial class clfbx : System.Web.UI.Page
    {
        private int step_id = 0;
        private int doc_id = 0;
        protected string _zgbh;
        protected string UserName;
        private string UserDept;
        private int flow_id = 48;
        private int FieldNum = 0;
        private bool bEditMode = false;
        DataTable dt_step_field;

        private string UserZw;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            this.c16.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.c17.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.d16.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.d17.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.e16.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.e17.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.f16.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.f17.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.g16.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.g17.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.h16.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.h17.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月dd日'})");
            this.i11.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.i12.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.j11.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.j12.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.k11.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.k12.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.l11.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.l12.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.m11.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.m12.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.n11.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");
            this.n12.Attributes.Add("onfocus", "WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})");

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
                //取得员工姓名
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
                UserName = dt_xm_bm.Rows[0][0].ToString();
                UserDept = dt_xm_bm.Rows[0][1].ToString();
                UserZw = dt_xm_bm.Rows[0][2].ToString();

                if (doc_id > 0)
                {
                    Step_Handle_Data();//根据doc_id取得当前document中已有数据
                    BindEmergency();
                }
                else
                {
                    //自动填写编号和日期
                    this.b.Text = System.DateTime.Now.ToLongDateString();
                }

                this.storeBtn.Visible = false;
                this.Button1.Enabled = false;
                this.Button2.Enabled = false;

                if (step_id == 1)
                    this.EmergencySelector1.Enabled = true;

                switch (step_id)
                {
                    case 0:
                        this.submitBtn.Enabled = false;
                        this.storeBtn.Enabled = false;
                        this.cancelBtn.Enabled = false;
                        this.k.Enabled = true;
                        break;
                    case 1:
                        this.a.Text = "Stoke-Money-" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
                        this.b.Text = System.DateTime.Now.ToLongDateString();
                        this.c11.Text = UserDept;
                        this.c12.Text = UserName;
                        this.c13.Text = UserZw;
                        this.Button1.Enabled = true;
                        this.storeBtn.Visible = true;
                        this.cancelBtn.Text = "删  除";
                        break;
                    case 4:
                        this.c1.Enabled = true;
                        this.c1.Text = UserName + "：无异议";
                        break;
                    case 5:
                        this.o1.Text = UserName + "：无异议";
                        break;
                    case 2:
                        this.d1.Enabled = true;
                        this.d1.Text = UserName + "：无异议";
                        break;
                    case 3:
                        this.b1.Enabled = true;
                        this.b1.Text = UserName + "：无异议";
                        break;
                    case 6:
                        this.a1.Text = UserName + "：无异议！";
                        break;
                    case 7:
                        this.b1.Text = UserName;
                        break;
                    case 8:
                        this.c1.Text = UserName;
                        break;
                    default:
                        this.storeBtn.Visible = true;
                        break;
                }
            }
        }


        private void Bind()
        {
            string[] temp1 = this.c.Text.ToString().Split('~');
            string[] temp2 = this.d.Text.ToString().Split('~');
            string[] temp3 = this.e.Text.ToString().Split('~');
            string[] temp4 = this.f.Text.ToString().Split('~');
            string[] temp5 = this.g.Text.ToString().Split('~');
            string[] temp6 = this.h.Text.ToString().Split('~');
            string[] temp7 = this.i.Text.ToString().Split('~');
            string[] temp8 = this.j.Text.ToString().Split('~');
            string[] temp9 = this.k.Text.ToString().Split('~');
            string[] temp10 = this.l.Text.ToString().Split('~');
            string[] temp11 = this.m.Text.ToString().Split('~');
            string[] temp12 = this.n.Text.ToString().Split('~');

            this.c11.Text = temp1[0];
            this.c12.Text = temp1[1];
            this.c13.Text = temp1[2];
            this.c14.Text = temp1[3];
            this.c15.Text = temp1[4];
            this.c16.Text = temp1[5];
            this.c17.Text = temp1[6];
            this.c18.Text = temp1[7];

            this.d11.Text = temp2[0];
            this.d12.Text = temp2[1];
            this.d13.Text = temp2[2];
            this.d14.Text = temp2[3];
            this.d15.Text = temp2[4];
            this.d16.Text = temp2[5];
            this.d17.Text = temp2[6];
            this.d18.Text = temp2[7];

            this.e11.Text = temp3[0];
            this.e12.Text = temp3[1];
            this.e13.Text = temp3[2];
            this.e14.Text = temp3[3];
            this.e15.Text = temp3[4];
            this.e16.Text = temp3[5];
            this.e17.Text = temp3[6];
            this.e18.Text = temp3[7];


            this.f11.Text = temp4[0];
            this.f12.Text = temp4[1];
            this.f13.Text = temp4[2];
            this.f14.Text = temp4[3];
            this.f15.Text = temp4[4];
            this.f16.Text = temp4[5];
            this.f17.Text = temp4[6];
            this.f18.Text = temp4[7];

            this.g11.Text = temp5[0];
            this.g12.Text = temp5[1];
            this.g13.Text = temp5[2];
            this.g14.Text = temp5[3];
            this.g15.Text = temp5[4];
            this.g16.Text = temp5[5];
            this.g17.Text = temp5[6];
            this.g18.Text = temp5[7];

            this.h11.Text = temp6[0];
            this.h12.Text = temp6[1];
            this.h13.Text = temp6[2];
            this.h14.Text = temp6[3];
            this.h15.Text = temp6[4];
            this.h16.Text = temp6[5];
            this.h17.Text = temp6[6];
            this.h18.Text = temp6[7];

            this.i11.Text = temp7[0];
            this.i12.Text = temp7[1];
            this.i13.Text = temp7[2];
            this.i14.Text = temp7[3];
            this.i15.Text = temp7[4];
            this.i16.Text = temp7[5];
            this.i17.Text = temp7[6];
            this.i18.Text = temp7[7];
            this.i19.Text = temp7[8];


            this.j11.Text = temp8[0];
            this.j12.Text = temp8[1];
            this.j13.Text = temp8[2];
            this.j14.Text = temp8[3];
            this.j15.Text = temp8[4];
            this.j16.Text = temp8[5];
            this.j17.Text = temp8[6];
            this.j18.Text = temp8[7];
            this.j19.Text = temp8[8];

            this.k11.Text = temp9[0];
            this.k12.Text = temp9[1];
            this.k13.Text = temp9[2];
            this.k14.Text = temp9[3];
            this.k15.Text = temp9[4];
            this.k16.Text = temp9[5];
            this.k17.Text = temp9[6];
            this.k18.Text = temp9[7];
            this.k19.Text = temp9[8];

            this.l11.Text = temp10[0];
            this.l12.Text = temp10[1];
            this.l13.Text = temp10[2];
            this.l14.Text = temp10[3];
            this.l15.Text = temp10[4];
            this.l16.Text = temp10[5];
            this.l17.Text = temp10[6];
            this.l18.Text = temp10[7];
            this.l19.Text = temp10[8];

            this.m11.Text = temp11[0];
            this.m12.Text = temp11[1];
            this.m13.Text = temp11[2];
            this.m14.Text = temp11[3];
            this.m15.Text = temp11[4];
            this.m16.Text = temp11[5];
            this.m17.Text = temp11[6];
            this.m18.Text = temp11[7];
            this.m19.Text = temp11[8];

            this.n11.Text = temp12[0];
            this.n12.Text = temp12[1];
            this.n13.Text = temp12[2];
            this.n14.Text = temp12[3];
            this.n15.Text = temp12[4];
            this.n16.Text = temp12[5];
            this.n17.Text = temp12[6];
            this.n18.Text = temp12[7];
            this.n19.Text = temp12[8];
        }

        /// <summary>
        /// 按步骤绑定数据
        /// </summary>
        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.Ycsq.Select_Data_by_DocID(doc_id);
            this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
            this.b.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
            this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
            this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
            this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
            this.m.Text = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : null;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            this.s.Text = dt_style_data.Rows[0]["s"].ToString() != null ? dt_style_data.Rows[0]["s"].ToString() : null;
            this.t.Text = dt_style_data.Rows[0]["t"].ToString() != null ? dt_style_data.Rows[0]["t"].ToString() : null;
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.p.Text = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : null;
            this.r.Text = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.w.Text = dt_style_data.Rows[0]["w"].ToString() != null ? dt_style_data.Rows[0]["w"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;
            this.z.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;
            this.a1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
            this.b1.Text = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : null;
            this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
            this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;
            this.g1.Text = dt_style_data.Rows[0]["g1"].ToString() != null ? dt_style_data.Rows[0]["g1"].ToString() : null;
            this.h1.Text = dt_style_data.Rows[0]["h1"].ToString() != null ? dt_style_data.Rows[0]["h1"].ToString() : null;
            this.i1.Text = dt_style_data.Rows[0]["i1"].ToString() != null ? dt_style_data.Rows[0]["i1"].ToString() : null;
            this.j1.Text = dt_style_data.Rows[0]["j1"].ToString() != null ? dt_style_data.Rows[0]["j1"].ToString() : null;
            this.o1.Text = dt_style_data.Rows[0]["o1"].ToString() != null ? dt_style_data.Rows[0]["o1"].ToString() : null;
            this.d1.Text = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : null;
            Bind();
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
            this.c17.TextChanged += new System.EventHandler(this.c17_TextChanged);
            this.d17.TextChanged += new System.EventHandler(this.d17_TextChanged);
            this.e17.TextChanged += new System.EventHandler(this.e17_TextChanged);
            this.f17.TextChanged += new System.EventHandler(this.f17_TextChanged);
            this.g17.TextChanged += new System.EventHandler(this.g17_TextChanged);
            this.h17.TextChanged += new System.EventHandler(this.h17_TextChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.w.TextChanged += new System.EventHandler(this.w_TextChanged);
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            this.storeBtn.Click += new System.EventHandler(this.storeBtn_Click);
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion



        private void Button1_Click(object sender, System.EventArgs e)
        {
            if ((this.i15.Text.ToString() != string.Empty) || (this.i16.Text.ToString() != string.Empty) || (this.i17.Text.ToString() != string.Empty) || (this.i18.Text.ToString() != string.Empty))
                if (JudgeMoney(this.i15) && JudgeMoney(this.i16) && JudgeMoney(this.i17) && JudgeMoney(this.i18))
                {
                    float result11 = (this.i18.Text.ToString() != string.Empty ? float.Parse(this.i18.Text.ToString()) : 0) + (this.i17.Text.ToString() != string.Empty ? float.Parse(this.i17.Text.ToString()) : 0) + (this.i16.Text.ToString() != string.Empty ? float.Parse(this.i16.Text.ToString()) : 0) + (this.i15.Text.ToString() != string.Empty ? float.Parse(this.i15.Text.ToString()) : 0);
                    this.i19.Text = result11.ToString("0.00");
                }
                else
                {
                    Response.Write("<script>alert('请保证借款金额必须为整数或类如100.00的浮点数！');</script>");
                    return;
                }

            if ((this.j15.Text.ToString() != string.Empty) || (this.j16.Text.ToString() != string.Empty) || (this.j17.Text.ToString() != string.Empty) || (this.j18.Text.ToString() != string.Empty))
                if (JudgeMoney(this.j15) && JudgeMoney(this.j16) && JudgeMoney(this.j17) && JudgeMoney(this.j18))
                {
                    float result12 = (this.j18.Text.ToString() != string.Empty ? float.Parse(this.j18.Text.ToString()) : 0) + (this.j17.Text.ToString() != string.Empty ? float.Parse(this.j17.Text.ToString()) : 0) + (this.j16.Text.ToString() != string.Empty ? float.Parse(this.j16.Text.ToString()) : 0) + (this.j15.Text.ToString() != string.Empty ? float.Parse(this.j15.Text.ToString()) : 0);
                    this.j19.Text = result12.ToString("0.00");
                }
                else
                {
                    Response.Write("<script>alert('请保证借款金额必须为整数或类如100.00的浮点数！');</script>");
                    return;
                }

            if ((this.k15.Text.ToString() != string.Empty) || (this.k16.Text.ToString() != string.Empty) || (this.k17.Text.ToString() != string.Empty) || (this.k18.Text.ToString() != string.Empty))
                if (JudgeMoney(this.k15) && JudgeMoney(this.k16) && JudgeMoney(this.k17) && JudgeMoney(this.k18))
                {
                    float result13 = (this.k18.Text.ToString() != string.Empty ? float.Parse(this.k18.Text.ToString()) : 0) + (this.k17.Text.ToString() != string.Empty ? float.Parse(this.k17.Text.ToString()) : 0) + (this.k16.Text.ToString() != string.Empty ? float.Parse(this.k16.Text.ToString()) : 0) + (this.k15.Text.ToString() != string.Empty ? float.Parse(this.k15.Text.ToString()) : 0);
                    this.k19.Text = result13.ToString("0.00");
                }
                else
                {
                    Response.Write("<script>alert('请保证借款金额必须为整数或类如100.00的浮点数！');</script>");
                    return;
                }

            if ((this.l15.Text.ToString() != string.Empty) || (this.l16.Text.ToString() != string.Empty) || (this.l17.Text.ToString() != string.Empty) || (this.l18.Text.ToString() != string.Empty))
                if (JudgeMoney(this.l15) && JudgeMoney(this.l16) && JudgeMoney(this.l17) && JudgeMoney(this.l18))
                {
                    float result14 = (this.l18.Text.ToString() != string.Empty ? float.Parse(this.l18.Text.ToString()) : 0) + (this.l17.Text.ToString() != string.Empty ? float.Parse(this.l17.Text.ToString()) : 0) + (this.l16.Text.ToString() != string.Empty ? float.Parse(this.l16.Text.ToString()) : 0) + (this.l15.Text.ToString() != string.Empty ? float.Parse(this.l15.Text.ToString()) : 0);
                    this.l19.Text = result14.ToString("0.00");
                }
                else
                {
                    Response.Write("<script>alert('请保证借款金额必须为整数或类如100.00的浮点数！');</script>");
                    return;
                }

            if ((this.m15.Text.ToString() != string.Empty) || (this.m16.Text.ToString() != string.Empty) || (this.m17.Text.ToString() != string.Empty) || (this.m18.Text.ToString() != string.Empty))
                if (JudgeMoney(this.m15) && JudgeMoney(this.m16) && JudgeMoney(this.m17) && JudgeMoney(this.m18))
                {
                    float result15 = (this.m18.Text.ToString() != string.Empty ? float.Parse(this.m18.Text.ToString()) : 0) + (this.m17.Text.ToString() != string.Empty ? float.Parse(this.m17.Text.ToString()) : 0) + (this.m16.Text.ToString() != string.Empty ? float.Parse(this.m16.Text.ToString()) : 0) + (this.m15.Text.ToString() != string.Empty ? float.Parse(this.m15.Text.ToString()) : 0);
                    this.m19.Text = result15.ToString("0.00");
                }
                else
                {
                    Response.Write("<script>alert('请保证借款金额必须为整数或类如100.00的浮点数！');</script>");
                    return;
                }


            if ((this.n15.Text.ToString() != string.Empty) || (this.n16.Text.ToString() != string.Empty) || (this.n17.Text.ToString() != string.Empty) || (this.n18.Text.ToString() != string.Empty))
                if (JudgeMoney(this.n15) && JudgeMoney(this.n16) && JudgeMoney(this.n17) && JudgeMoney(this.n18))
                {
                    float result16 = (this.n18.Text.ToString() != string.Empty ? float.Parse(this.n18.Text.ToString()) : 0) + (this.n17.Text.ToString() != string.Empty ? float.Parse(this.n17.Text.ToString()) : 0) + (this.n16.Text.ToString() != string.Empty ? float.Parse(this.n16.Text.ToString()) : 0) + (this.n15.Text.ToString() != string.Empty ? float.Parse(this.n15.Text.ToString()) : 0);
                    this.n19.Text = result16.ToString("0.00");
                }
                else
                {
                    Response.Write("<script>alert('请保证借款金额必须为整数或类如100.00的浮点数！');</script>");
                    return;
                }




            float result1 = (this.i15.Text.ToString() != string.Empty ? float.Parse(this.i15.Text.ToString()) : 0) + (this.j15.Text.ToString() != string.Empty ? float.Parse(this.j15.Text.ToString()) : 0) + (this.k15.Text.ToString() != string.Empty ? float.Parse(this.k15.Text.ToString()) : 0) + (this.l15.Text.ToString() != string.Empty ? float.Parse(this.l15.Text.ToString()) : 0) + (this.m15.Text.ToString() != string.Empty ? float.Parse(this.m15.Text.ToString()) : 0) + (this.n15.Text.ToString() != string.Empty ? float.Parse(this.n15.Text.ToString()) : 0);
            this.f1.Text = result1.ToString("0.00");

            float result2 = (this.i16.Text.ToString() != string.Empty ? float.Parse(this.i16.Text.ToString()) : 0) + (this.j16.Text.ToString() != string.Empty ? float.Parse(this.j16.Text.ToString()) : 0) + (this.k16.Text.ToString() != string.Empty ? float.Parse(this.k16.Text.ToString()) : 0) + (this.l16.Text.ToString() != string.Empty ? float.Parse(this.l16.Text.ToString()) : 0) + (this.m16.Text.ToString() != string.Empty ? float.Parse(this.m16.Text.ToString()) : 0) + (this.n16.Text.ToString() != string.Empty ? float.Parse(this.n16.Text.ToString()) : 0);
            this.g1.Text = result2.ToString("0.00");

            float result3 = (this.i17.Text.ToString() != string.Empty ? float.Parse(this.i17.Text.ToString()) : 0) + (this.j17.Text.ToString() != string.Empty ? float.Parse(this.j17.Text.ToString()) : 0) + (this.k17.Text.ToString() != string.Empty ? float.Parse(this.k17.Text.ToString()) : 0) + (this.l17.Text.ToString() != string.Empty ? float.Parse(this.l17.Text.ToString()) : 0) + (this.m17.Text.ToString() != string.Empty ? float.Parse(this.m17.Text.ToString()) : 0) + (this.n17.Text.ToString() != string.Empty ? float.Parse(this.n17.Text.ToString()) : 0);
            this.h1.Text = result3.ToString("0.00");


            float result4 = (this.i18.Text.ToString() != string.Empty ? float.Parse(this.i18.Text.ToString()) : 0) + (this.j18.Text.ToString() != string.Empty ? float.Parse(this.j18.Text.ToString()) : 0) + (this.k18.Text.ToString() != string.Empty ? float.Parse(this.k18.Text.ToString()) : 0) + (this.l18.Text.ToString() != string.Empty ? float.Parse(this.l18.Text.ToString()) : 0) + (this.m18.Text.ToString() != string.Empty ? float.Parse(this.m18.Text.ToString()) : 0) + (this.n18.Text.ToString() != string.Empty ? float.Parse(this.n18.Text.ToString()) : 0);
            this.i1.Text = result4.ToString("0.00");

            float result5 = (this.i19.Text.ToString() != string.Empty ? float.Parse(this.i19.Text.ToString()) : 0) + (this.j19.Text.ToString() != string.Empty ? float.Parse(this.j19.Text.ToString()) : 0) + (this.k19.Text.ToString() != string.Empty ? float.Parse(this.k19.Text.ToString()) : 0) + (this.l19.Text.ToString() != string.Empty ? float.Parse(this.l19.Text.ToString()) : 0) + (this.m19.Text.ToString() != string.Empty ? float.Parse(this.m19.Text.ToString()) : 0) + (this.n19.Text.ToString() != string.Empty ? float.Parse(this.n19.Text.ToString()) : 0);
            this.j1.Text = result5.ToString("0.00");
        }


        private void Button2_Click(object sender, System.EventArgs e)
        {
            //判断金额格式是否正确
            JudgeMoney(this.o);
            JudgeMoney(this.p);
            JudgeMoney(this.q);
            JudgeMoney(this.r);
            JudgeMoney(this.s);
            JudgeMoney(this.t);
            float result = (this.o.Text.ToString() != string.Empty ? float.Parse(this.o.Text.ToString()) : 0) + (this.p.Text.ToString() != string.Empty ? float.Parse(this.p.Text.ToString()) : 0) + (this.q.Text.ToString() != string.Empty ? float.Parse(this.q.Text.ToString()) : 0) + (this.r.Text.ToString() != string.Empty ? float.Parse(this.r.Text.ToString()) : 0) + (this.s.Text.ToString() != string.Empty ? float.Parse(this.s.Text.ToString()) : 0) + (this.t.Text.ToString() != string.Empty ? float.Parse(this.t.Text.ToString()) : 0);
            this.u.Text = result.ToString() + ".00";
            if (this.w.Text != string.Empty)
            {
                float yuanjie = float.Parse(this.w.Text.ToString());
                float zj = float.Parse(this.u.Text.ToString());
                float yt = yuanjie - zj;
                this.x.Text = yt.ToString("0.00");
            }
            this.v.Text = CmycurD(decimal.Parse(this.u.Text.ToString()));
        }

        /// <summary>  
        /// 转换人民币大小金额  
        /// </summary>  
        /// <param name="num">金额</param>  
        /// <returns>返回大写形式</returns>  
        public static string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字  
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字  
            string str3 = "";    //从原num值中取出的值  
            string str4 = "";    //数字的字符串形式  
            string str5 = "";  //人民币大写金额形式  
            int i;    //循环变量  
            int j;    //num的值乘以100的字符串长度  
            string ch1 = "";    //数字的汉语读法  
            string ch2 = "";    //数字位的汉字读法  
            int nzero = 0;  //用来计算连续的零值是几个  
            int temp;            //从原num值中取出的值  

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数  
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式  
            j = str4.Length;      //找出最高位  
            if (j >= 11) { return "数值太大，请检查是否输入错误！"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分  

            //循环取出每一位需要转换的值  
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值  
                temp = Convert.ToInt32(str3);      //转换为数字  
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时  
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位  
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上  
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”  
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        private bool JudgeMoney(System.Web.UI.WebControls.TextBox tb)
        {
            //判断合同具体金额格式是否正确
            if (tb.Text != string.Empty)
            {
                string moneyRexStr = @"^[0-9]*[1-9][0-9]*$";
                Regex moneyReg = new Regex(moneyRexStr);
                if (moneyReg.IsMatch(tb.Text.ToString()))
                {
                    tb.Text += ".00";
                    return true;
                }
                else
                {
                    string moneyRexStr2 = @"^[0-9]\d*\.\d*|0\.\d*[0-9]\d*$";
                    moneyReg = new Regex(moneyRexStr2);
                    if (!moneyReg.IsMatch(tb.Text.ToString()))
                    {
                        return false;
                    }
                    else
                        return true;
                }
            }
            else
                return true;
        }

        private void c17_TextChanged(object sender, System.EventArgs e)
        {
            if (this.c16.Text != string.Empty && this.c17.Text != string.Empty)
            {
                DateTime start = DateTime.Parse(this.c16.Text.ToString());
                DateTime end = DateTime.Parse(this.c17.Text.ToString());
                int num = end.DayOfYear - start.DayOfYear;
                this.c18.Text = num.ToString() + "天";
            }
            else
            {
                Response.Write("<script>alert('请保证往返日期都不能为空！');</script>");
                return;
            }
        }

        private void d17_TextChanged(object sender, System.EventArgs e)
        {
            if (this.d16.Text != string.Empty && this.d17.Text != string.Empty)
            {
                DateTime start = DateTime.Parse(this.d16.Text.ToString());
                DateTime end = DateTime.Parse(this.d17.Text.ToString());
                int num = end.DayOfYear - start.DayOfYear;
                this.d18.Text = num.ToString() + "天";
            }
            else
            {
                Response.Write("<script>alert('请保证往返日期都不能为空！');</script>");
                return;
            }
        }

        private void e17_TextChanged(object sender, System.EventArgs e)
        {
            if (this.e16.Text != string.Empty && this.e17.Text != string.Empty)
            {
                DateTime start = DateTime.Parse(this.e16.Text.ToString());
                DateTime end = DateTime.Parse(this.e17.Text.ToString());
                int num = end.DayOfYear - start.DayOfYear;
                this.e18.Text = num.ToString() + "天";
            }
            else
            {
                Response.Write("<script>alert('请保证往返日期都不能为空！');</script>");
                return;
            }
        }

        private void f17_TextChanged(object sender, System.EventArgs e)
        {
            if (this.f16.Text != string.Empty && this.f17.Text != string.Empty)
            {
                DateTime start = DateTime.Parse(this.f16.Text.ToString());
                DateTime end = DateTime.Parse(this.f17.Text.ToString());
                int num = end.DayOfYear - start.DayOfYear;
                this.f18.Text = num.ToString() + "天";
            }
            else
            {
                Response.Write("<script>alert('请保证往返日期都不能为空！');</script>");
                return;
            }
        }

        private void g17_TextChanged(object sender, System.EventArgs e)
        {
            if (this.g16.Text != string.Empty && this.g17.Text != string.Empty)
            {
                DateTime start = DateTime.Parse(this.g16.Text.ToString());
                DateTime end = DateTime.Parse(this.g17.Text.ToString());
                int num = end.DayOfYear - start.DayOfYear;
                this.g18.Text = num.ToString() + "天";
            }
            else
            {
                Response.Write("<script>alert('请保证往返日期都不能为空！');</script>");
                return;
            }
        }

        private void h17_TextChanged(object sender, System.EventArgs e)
        {
            if (this.h16.Text != string.Empty && this.h17.Text != string.Empty)
            {
                DateTime start = DateTime.Parse(this.h16.Text.ToString());
                DateTime end = DateTime.Parse(this.h17.Text.ToString());
                int num = end.DayOfYear - start.DayOfYear;
                this.h18.Text = num.ToString() + "天";
            }
            else
            {
                Response.Write("<script>alert('请保证往返日期都不能为空！');</script>");
                return;
            }
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

        private void submitBtn_Click(object sender, System.EventArgs e)
        {
            if (this.j1.Text == string.Empty && this.step_id == 1)
            {
                Response.Write("<script>alert('请在提交前进行累计计算！!')</script>");
                return;
            }

            //if (this.step_id == 1 && this.w.Text == string.Empty)
            //{
            //    Response.Write("<script>alert('请保证原借金额不能为空！!')</script>");
            //    return;
            //}

            //if (this.step_id == 4 && this.v.Text == string.Empty)
            //{
            //    Response.Write("<script>alert('请在提交前进行累计计算！!')</script>");
            //    return;
            //}
            //保存数据
            SaveData();

            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=48&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
            Response.Redirect(_URL);
        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Stoke.BLL.Utility.GetEmergencyByDocid(doc_id);
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
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.c12.Text.ToString() + "出差报销申请!");
                df = null;
                if (step_id == 1)
                    Stoke.BLL.Utility.SetEmergencyWithDocid(doc_id, this.EmergencySelector1.SelectedValue);
            }
            else
            {
                //更新
                mySql = GetStyleUpdateData(doc_id);
                df.UpdateDocument(mySql);
                df = null;
            }
        }

        public void UpdataZt()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string title = this.c12.Text.ToString() + "出差报销申请!";
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
            if (this.step_id == 1)
            {
                this.c.Text = this.c11.Text + "~" + this.c12.Text + "~" + this.c13.Text + "~" + this.c14.Text + "~" + this.c15.Text + "~" + this.c16.Text + "~" + this.c17.Text + "~" + this.c18.Text;
                this.d.Text = this.d11.Text + "~" + this.d12.Text + "~" + this.d13.Text + "~" + this.d14.Text + "~" + this.d15.Text + "~" + this.d16.Text + "~" + this.d17.Text + "~" + this.d18.Text;
                this.e.Text = this.e11.Text + "~" + this.e12.Text + "~" + this.e13.Text + "~" + this.e14.Text + "~" + this.e15.Text + "~" + this.e16.Text + "~" + this.e17.Text + "~" + this.e18.Text;
                this.f.Text = this.f11.Text + "~" + this.f12.Text + "~" + this.f13.Text + "~" + this.f14.Text + "~" + this.f15.Text + "~" + this.f16.Text + "~" + this.f17.Text + "~" + this.f18.Text;
                this.g.Text = this.g11.Text + "~" + this.g12.Text + "~" + this.g13.Text + "~" + this.g14.Text + "~" + this.g15.Text + "~" + this.g16.Text + "~" + this.g17.Text + "~" + this.g18.Text;
                this.h.Text = this.h11.Text + "~" + this.h12.Text + "~" + this.h13.Text + "~" + this.h14.Text + "~" + this.h15.Text + "~" + this.h16.Text + "~" + this.h17.Text + "~" + this.h18.Text;
                this.i.Text = this.i11.Text + "~" + this.i12.Text + "~" + this.i13.Text + "~" + this.i14.Text + "~" + this.i15.Text + "~" + this.i16.Text + "~" + this.i17.Text + "~" + this.i18.Text + "~" + this.i19.Text;
                this.j.Text = this.j11.Text + "~" + this.j12.Text + "~" + this.j13.Text + "~" + this.j14.Text + "~" + this.j15.Text + "~" + this.j16.Text + "~" + this.j17.Text + "~" + this.j18.Text + "~" + this.j19.Text;
                this.k.Text = this.k11.Text + "~" + this.k12.Text + "~" + this.k13.Text + "~" + this.k14.Text + "~" + this.k15.Text + "~" + this.k16.Text + "~" + this.k17.Text + "~" + this.k18.Text + "~" + this.k19.Text;
                this.l.Text = this.l11.Text + "~" + this.l12.Text + "~" + this.l13.Text + "~" + this.l14.Text + "~" + this.l15.Text + "~" + this.l16.Text + "~" + this.l17.Text + "~" + this.l18.Text + "~" + this.l19.Text;
                this.m.Text = this.m11.Text + "~" + this.m12.Text + "~" + this.m13.Text + "~" + this.m14.Text + "~" + this.m15.Text + "~" + this.m16.Text + "~" + this.m17.Text + "~" + this.m18.Text + "~" + this.m19.Text;
                this.n.Text = this.n11.Text + "~" + this.n12.Text + "~" + this.n13.Text + "~" + this.n14.Text + "~" + this.n15.Text + "~" + this.n16.Text + "~" + this.n17.Text + "~" + this.n18.Text + "~" + this.n19.Text;
            }

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
            if (this.step_id == 1)
            {
                this.c.Text = this.c11.Text + "~" + this.c12.Text + "~" + this.c13.Text + "~" + this.c14.Text + "~" + this.c15.Text + "~" + this.c16.Text + "~" + this.c17.Text + "~" + this.c18.Text;
                this.d.Text = this.d11.Text + "~" + this.d12.Text + "~" + this.d13.Text + "~" + this.d14.Text + "~" + this.d15.Text + "~" + this.d16.Text + "~" + this.d17.Text + "~" + this.d18.Text;
                this.e.Text = this.e11.Text + "~" + this.e12.Text + "~" + this.e13.Text + "~" + this.e14.Text + "~" + this.e15.Text + "~" + this.e16.Text + "~" + this.e17.Text + "~" + this.e18.Text;
                this.f.Text = this.f11.Text + "~" + this.f12.Text + "~" + this.f13.Text + "~" + this.f14.Text + "~" + this.f15.Text + "~" + this.f16.Text + "~" + this.f17.Text + "~" + this.f18.Text;
                this.g.Text = this.g11.Text + "~" + this.g12.Text + "~" + this.g13.Text + "~" + this.g14.Text + "~" + this.g15.Text + "~" + this.g16.Text + "~" + this.g17.Text + "~" + this.g18.Text;
                this.h.Text = this.h11.Text + "~" + this.h12.Text + "~" + this.h13.Text + "~" + this.h14.Text + "~" + this.h15.Text + "~" + this.h16.Text + "~" + this.h17.Text + "~" + this.h18.Text;
                this.i.Text = this.i11.Text + "~" + this.i12.Text + "~" + this.i13.Text + "~" + this.i14.Text + "~" + this.i15.Text + "~" + this.i16.Text + "~" + this.i17.Text + "~" + this.i18.Text + "~" + this.i19.Text;
                this.j.Text = this.j11.Text + "~" + this.j12.Text + "~" + this.j13.Text + "~" + this.j14.Text + "~" + this.j15.Text + "~" + this.j16.Text + "~" + this.j17.Text + "~" + this.j18.Text + "~" + this.j19.Text;
                this.k.Text = this.k11.Text + "~" + this.k12.Text + "~" + this.k13.Text + "~" + this.k14.Text + "~" + this.k15.Text + "~" + this.k16.Text + "~" + this.k17.Text + "~" + this.k18.Text + "~" + this.k19.Text;
                this.l.Text = this.l11.Text + "~" + this.l12.Text + "~" + this.l13.Text + "~" + this.l14.Text + "~" + this.l15.Text + "~" + this.l16.Text + "~" + this.l17.Text + "~" + this.l18.Text + "~" + this.l19.Text;
                this.m.Text = this.m11.Text + "~" + this.m12.Text + "~" + this.m13.Text + "~" + this.m14.Text + "~" + this.m15.Text + "~" + this.m16.Text + "~" + this.m17.Text + "~" + this.m18.Text + "~" + this.m19.Text;
                this.n.Text = this.n11.Text + "~" + this.n12.Text + "~" + this.n13.Text + "~" + this.n14.Text + "~" + this.n15.Text + "~" + this.n16.Text + "~" + this.n17.Text + "~" + this.n18.Text + "~" + this.n19.Text;
            }
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
        /// <summary>
        /// 根据控件获得对应值 
        /// </summary>
        /// <param name="field_name">控件名</param>
        /// <returns></returns>
        private string GetControlText(string field_name)
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
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

        private void storeBtn_Click(object sender, System.EventArgs e)
        {
            SaveData();
            UpdataZt();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void w_TextChanged(object sender, System.EventArgs e)
        {
            JudgeMoney(w);
        }
    }
}
