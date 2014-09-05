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
using System.IO;
using System.Text;
using Stoke.Components;
using Stoke.COMMON;
using Stoke.DAL;
using Stoke.BLL;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;

namespace Stoke.USL.Staff
{
    public partial class NewStaff : System.Web.UI.Page
    {
        protected string Username;
        protected int qzsp_id = 0;
        protected string org_id = "01";
        public string PositionID;
        private string StaffID = "";
        private int sex = 1;
        private static int EditStatus = 0;
        public int ReturnPage = 0;
        private string bm = "";
        private string zw = "";
        private int _is_rs_wx_oper = -1;
        private string _zgbh = "";
        protected string ImageUrl;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (Request.QueryString["qzsp_id"] != null)
            {
                qzsp_id = Int32.Parse(Request.QueryString["qzsp_id"].ToString());//求职审批未注册列表，传求职审批编号
            }
            if (!Page.IsPostBack)
            {
                init_image();
                BindDdl();
                BindRangeSelector();

                this.htzzsj.Attributes.Add("onchange", "htzzsjChange()");
                this.htlb.Attributes.Add("onchange", "htlbChange()");

                #region 没用

                //绑定职位
                //				BindPosition();		
                //				BindDepartment();

                //				BindXmz();
                //修改于2003-10-8日 目的：改正生日103岁问题
                //txtBirthday.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //				this.Table10.Visible = false;
                #endregion
                if (Request.QueryString["PositionID"] != null)
                {
                    PositionID = Request.QueryString["PositionID"].ToString();
                }
                else
                    PositionID = "0";

                if (Request.QueryString["ReturnPage"] != null)
                {
                    ReturnPage = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
                    if (ReturnPage == 5)
                        this.btn_xg.Visible = false;
                }
                else
                    ReturnPage = 0;


                //职工信息管理，点击姓名超链接，传来职工编号
                //可能是编辑部门职位职位后，传回来职号
                if (Request.QueryString["StaffID"] != null)
                {
                    this.pwdTr.Visible = false;
                    this.roleTr.Visible = false;
                    StaffID = Request.QueryString["StaffID"].ToString();
                    this.Image1.ImageUrl = "read_photo.aspx?zgbh=" + StaffID;
                    GetStaffInfo(StaffID);
                    #region 没用
                    //					if(Request.QueryString["EditStatus"]!=null)//ry_bm_zw.aspx返回时判断
                    //					{
                    //						if(int.Parse(Request.QueryString["EditStatus"].ToString())==0)
                    //						{
                    //							EditStatus = 0;	
                    //							sex = 1;
                    //							this.btn_xg.Visible = false;
                    //						}
                    //						else
                    //						{
                    //							EditStatus = 1;
                    //							setTextBoxReadOnly(Page);
                    //						}
                    //					}
                    //					else
                    //					{
                    //						EditStatus = 1;
                    //						setTextBoxReadOnly(Page);
                    //					}
                    # endregion
                    EditStatus = 1;//可编辑
                    setTextBoxReadOnly(Page);

                }
                else
                {
                    EditStatus = 0;
                    sex = 1;
                    this.btn_xg.Visible = false;
                    this.Button1.Enabled = true;
                }

                //可能是编辑部门职位职位后，传回来姓名
                if (Request["ry_xm"] != null)
                    this.txtRealName.Text = Request["ry_xm"].ToString();

                //求职审批中点击注册，传回来求职审批编号
                if (Request.QueryString["qzsp_id"] != null)
                {
                    qzsp_id = Int32.Parse(Request.QueryString["qzsp_id"].ToString());
                    DataTable dt_new_staff = Stoke.Components.Staff.SelectQzspById(qzsp_id);
                    if (dt_new_staff != null)
                    {
                        this.txtRealName.Text = dt_new_staff.Rows[0][5].ToString();
                        if (dt_new_staff.Rows[0][6].ToString() == "男")
                            this.rb_male.Checked = true;
                        else
                            this.rb_female.Checked = true;
                        this.mz.Text = dt_new_staff.Rows[0][7].ToString();
                        this.txtBirthday.Text = dt_new_staff.Rows[0][8].ToString();
                        this.jg.Text = dt_new_staff.Rows[0][9].ToString();
                        this.zzmm.Text = dt_new_staff.Rows[0][10].ToString();
                        this.zc.Text = dt_new_staff.Rows[0][11].ToString();
                        this.wysp.Text = dt_new_staff.Rows[0][12].ToString();
                        this.ddlZgxl.SelectedValue = dt_new_staff.Rows[0][13].ToString();
                        this.byxx.Text = dt_new_staff.Rows[0][14].ToString();
                        this.sxzy.Text = dt_new_staff.Rows[0][15].ToString();
                        this.bysj.Text = dt_new_staff.Rows[0][16].ToString();
                        this.cjgzsj.Text = dt_new_staff.Rows[0][21].ToString();
                        this.jkqk.Text = dt_new_staff.Rows[0][24].ToString();
                        this.hyzk.Text = dt_new_staff.Rows[0][25].ToString();
                        this.txtPhone.Text = dt_new_staff.Rows[0][27].ToString();
                        this.txtMobile.Text = dt_new_staff.Rows[0][28].ToString();
                        this.sfzh.Text = dt_new_staff.Rows[0][29].ToString();
                        this.hkszd.Text = dt_new_staff.Rows[0][30].ToString();
                        this.jtzz.Text = dt_new_staff.Rows[0][31].ToString();
                        this.txt_bm.Text = dt_new_staff.Rows[0][58].ToString();
                        this.txt_zw.Text = dt_new_staff.Rows[0][45].ToString();
                        this.Image1.ImageUrl = "read_qzsp_photo.aspx?qzsp_id=" + qzsp_id;
                    }

                }

                //登陆人的职工编号
                if (Session["zgbh"] != null)
                {
                    _zgbh = Session["zgbh"].ToString();
                    Stoke.Components.xtqx _xtqx = new Stoke.Components.xtqx();
                    _is_rs_wx_oper = 1;
                    if (_is_rs_wx_oper == 1)
                    {
                        this.btn_bm_zw.Visible = false;
                        if (EditStatus == 0)
                            this.btn_xg.Visible = false;
                        else
                            this.btn_xg.Visible = true;
                        this.cmdSubmit.Visible = true;
                    }
                    else
                    {
                        this.btn_bm_zw.Visible = false;
                        this.btn_xg.Visible = false;
                        this.cmdSubmit.Visible = true;
                    }
                }
                else
                    Response.Redirect("../error.aspx");

            }

            if (Request.QueryString["ReturnPage"] != null)
            {
                ReturnPage = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
                if (ReturnPage == 5)
                    this.btn_xg.Visible = false;
            }
            else
                ReturnPage = 0;

            if (Request.QueryString["org_id"] != null)
            {
                org_id = Request.QueryString["org_id"].ToString();
            }

            //if(PositionID!="0")
            //myposition.Visible = false;
            BindImage();
        }

        protected void init_image()
        {
            ImageUrl = Session["imagefilename"] == null ? "sago.jpg" : "../../Attachments/" + Session["imagefilename"].ToString();
        }

        protected void BindImage()
        {
            string url = Utility.GetUserImage(zh.Text.Trim());
            if (url != "0")
            {
                Image1.Visible = true;
                Image1.ImageUrl = url;
            }

            if (Session["CurrentImageUrl"] != null)
            {
                Image1.Visible = true;
                Image1.ImageUrl = Session["CurrentImageUrl"].ToString();
            }
        }

        private void BindRangeSelector()
        {
            this.CandidateRoleLbx.SelectionMode = ListSelectionMode.Multiple;
            this.roleLbx.SelectionMode = ListSelectionMode.Multiple;

            DataTable dtrole = SystemUM.GetRolesByLevel();
            this.CandidateRoleLbx.DataSource = dtrole;
            this.CandidateRoleLbx.DataTextField = "roleName";
            this.CandidateRoleLbx.DataValueField = "RoleCode";
            this.CandidateRoleLbx.DataBind();
        }


        private void BindDdl()
        {
            DataTable dt_bm = Stoke.BLL.Department.GetAll();
            this.DropDownList1.DataSource = dt_bm;
            this.DropDownList1.DataTextField = "bm_mc";
            this.DropDownList1.DataValueField = "bm_mc";
            this.DropDownList1.DataBind();
            this.DropDownList1.Items.Insert(0, "-请选择-");
            this.DropDownList1.SelectedIndex = 0;

            DataTable dt_zw = Stoke.BLL.Place.GetAll();
            this.DropDownList2.DataSource = dt_zw;
            this.DropDownList2.DataTextField = "zw_mc";
            this.DropDownList2.DataValueField = "zw_mc";
            this.DropDownList2.DataBind();
            this.DropDownList2.Items.Insert(0, "-请选择-");
            this.DropDownList2.SelectedIndex = 0;
        }


        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
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
            this.btn_xg.Click += new System.EventHandler(this.btn_xg_Click);
            this.zh.TextChanged += new System.EventHandler(this.zh_TextChanged);
            this.btn_bm_zw.Click += new System.EventHandler(this.btn_bm_zw_Click);
            this.BtnZwChange.Click += new System.EventHandler(this.BtnZwChange_Click);
            this.txtBirthday.TextChanged += new System.EventHandler(this.txtBirthday_TextChanged);
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            //this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


        #region 没用到

        //		private void BindPosition()
        //		{
        //			Stoke.Components.Database db = new Stoke.Components.Database();
        //			SqlDataReader dr_position = null;
        //			db.RunProc("sp_Rs_GetAllPosition",out dr_position);
        //			cboPosition.DataSource = dr_position;
        //			cboPosition.DataTextField = "zw_mc";
        //			cboPosition.DataValueField = "zw_bh";			
        //			cboPosition.DataBind();
        //			cboPosition.Items.Insert(0, "-请选择-"); 
        //			cboPosition.SelectedIndex = 0; 
        //		}
        //		private void BindDepartment()
        //		{
        //			Stoke.Components.Database db = new Stoke.Components.Database();
        //			SqlDataReader dr_department = null;
        //			db.RunProc("RS_GetAllDepartment",out dr_department);
        //			cboDepartment.DataSource = dr_department;
        //			cboDepartment.DataTextField = "bm_mc";
        //			cboDepartment.DataValueField = "bm_bh";			
        //			cboDepartment.DataBind();
        //			cboDepartment.Items.Insert(0, "-请选择-"); 
        //			cboDepartment.SelectedIndex = 0; 
        //		}
        //		private void BindXmz()
        //		{
        //			Stoke.Components.Database db = new Stoke.Components.Database();
        //			SqlDataReader dr_xmz = null;
        //			db.RunProc("RS_GetAllXmz",out dr_xmz);
        //			cboXmz.DataSource = dr_xmz;
        //			cboXmz.DataTextField = "bm_mc";
        //			cboXmz.DataValueField = "bm_bh";			
        //			cboXmz.DataBind();
        //			cboXmz.Items.Insert(0, "-请选择-"); 
        //			cboXmz.SelectedIndex = 0; 
        //		}
        #endregion

        private void GetStaffInfo(string StaffID)
        {
            string _tbm = Stoke.BLL.Utility.GetDepartmentByZgbh(StaffID).Rows[0][1].ToString().Trim();
            string _tzw = Stoke.BLL.Utility.GetPositionByZgbh(StaffID).Rows[0][1].ToString().Trim();

            this.DropDownList1.SelectedValue = _tbm;
            this.DropDownList2.SelectedValue = _tzw;

            SqlDataReader dr;
            DataTable dt_bm_zw;
            Stoke.Components.Staff person = new Stoke.Components.Staff();
            dr = person.GetStaffInfo(StaffID);
            //判断是在职还是离职人员，从不同表获取部门职位
            if (judge_zz(StaffID) == true)
            {
                dt_bm_zw = person.GetXmBmZwByZdbh(StaffID);
                this.zh.Text = StaffID;
                string _bm = "";
                string _zw = "";
                for (int j = 0; j < dt_bm_zw.Rows.Count; j++)
                {
                    _bm += dt_bm_zw.Rows[j][1].ToString().Trim() + ",";
                    _zw += dt_bm_zw.Rows[j][2].ToString().Trim() + ",";
                }
                if (_bm != "")
                    this.txt_bm.Text = _bm.Substring(0, _bm.LastIndexOf(','));
                else
                    this.txt_bm.Text = "";
                if (_zw != "")
                    this.txt_zw.Text = _zw.Substring(0, _zw.LastIndexOf(','));
                else
                    this.txt_zw.Text = "";
            }

            else if (judge_zz(StaffID) == false)
            {
                dt_bm_zw = person.GetXmBmZwByZdbh_lz(StaffID);
                this.zh.Text = StaffID;
                string _bm = "";
                string _zw = "";
                for (int j = 0; j < dt_bm_zw.Rows.Count; j++)
                {
                    _bm += dt_bm_zw.Rows[j][1].ToString().Trim() + ",";
                    _zw += dt_bm_zw.Rows[j][2].ToString().Trim() + ",";
                }
                if (_bm != "")
                    this.txt_bm.Text = _bm.Substring(0, _bm.LastIndexOf(','));
                else
                    this.txt_bm.Text = "";
                if (_zw != "")
                    this.txt_zw.Text = _zw.Substring(0, _zw.LastIndexOf(','));
                else
                    this.txt_zw.Text = "";
            }

            if (dr.Read())
            {
                txtRealName.Text = dr["ry_xm"].ToString();
                if (dr["Sex"].ToString() == "True")
                {
                    rb_male.Checked = true;
                    sex = 1;
                }
                else
                {
                    rb_female.Checked = true;
                    sex = 0;
                }
                if (dr["pylx"].ToString() != "")
                    this.ddlPylx.SelectedValue = dr["pylx"].ToString();

                //修改于2003-10-8日 目的：改正生日103岁问题
                //				if( txtBirthday.Text =="")
                //					txtBirthday.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //				txtBirthday.Text = dr["Birthday"].ToString().IndexOf(" ")>0?dr["Birthday"].ToString().Substring(0,dr["Birthday"].ToString().IndexOf(" ")):dr["Birthday"].ToString() ;

                txtBirthday.Text = ((dr["Birthday"] == DBNull.Value) || (DateTime.Parse(dr["Birthday"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["Birthday"].ToString()).ToString("yyyy-MM-dd");
                txtEmail.Text = dr["Email"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtMobile.Text = dr["Mobile"].ToString();
                zh.Text = dr["ry_zgbh"].ToString();
                this.txtYwm.Text = dr["ywm"].ToString();
                this.txtCym.Text = dr["cym"].ToString();
                try
                {
                    if (dr["rylb"].ToString() != "")
                        this.rylb.SelectedValue = dr["rylb"].ToString();
                }
                catch
                {
                }
                shi.Text = dr["shi"].ToString();
                gwbdsj.Text = ((dr["gwbdsj"] == DBNull.Value) || (DateTime.Parse(dr["gwbdsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["gwbdsj"].ToString()).ToString("yyyy-MM-dd");
                sfzh.Text = dr["sfzh"].ToString();
                if (dr["Age"].ToString() != "0" && dr["Birthday"].ToString() != "1900-1-1 0:00:00")
                    this.txtAge.Text = dr["Age"].ToString();
                else
                    this.txtAge.Text = "";
                mz.Text = dr["mz"].ToString();
                jg.Text = dr["jg"].ToString();
                hkszd.Text = dr["hkszd"].ToString();
                zzmm.Text = dr["zzmm"].ToString();
                rdpsj.Text = ((dr["rdpsj"] == DBNull.Value) || (DateTime.Parse(dr["rdpsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["rdpsj"].ToString()).ToString("yyyy-MM-dd");
                jkqk.Text = dr["jkqk"].ToString();
                hyzk.Text = dr["hyzk"].ToString();
                cjgzsj.Text = ((dr["cjgzsj"] == DBNull.Value) || (DateTime.Parse(dr["cjgzsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["cjgzsj"].ToString()).ToString("yyyy-MM-dd");
                jbdwsj.Text = ((dr["jbdwsj"] == DBNull.Value) || (DateTime.Parse(dr["jbdwsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["jbdwsj"].ToString()).ToString("yyyy-MM-dd");
                zc.Text = dr["zc"].ToString();
                try
                {
                    if (dr["zcjb"].ToString() != "")
                        this.zcjb.SelectedValue = dr["zcjb"].ToString();
                    else
                        this.zcjb.SelectedIndex = 0;
                }
                catch
                {
                }
                zcrdsj.Text = ((dr["zcrdsj"] == DBNull.Value) || (DateTime.Parse(dr["zcrdsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["zcrdsj"].ToString()).ToString("yyyy-MM-dd");
                htqssj.Text = ((dr["htqssj"] == DBNull.Value) || (DateTime.Parse(dr["htqssj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["htqssj"].ToString()).ToString("yyyy-MM-dd");
                htzzsj.Text = ((dr["htzzsj"] == DBNull.Value) || (DateTime.Parse(dr["htzzsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "无固定" : DateTime.Parse(dr["htzzsj"].ToString()).ToString("yyyy-MM-dd");
                try
                {
                    if (dr["zgxl"].ToString() != "")
                        this.ddlZgxl.SelectedValue = dr["zgxl"].ToString();
                    else
                        this.ddlZgxl.SelectedIndex = 0;
                }
                catch
                {
                }
                bysj.Text = ((dr["bysj"] == DBNull.Value) || (DateTime.Parse(dr["bysj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dr["bysj"].ToString()).ToString("yyyy-MM-dd");
                byxx.Text = dr["byxx"].ToString();
                sxzy.Text = dr["sxzy"].ToString();
                xxxs.Text = dr["xxxs"].ToString();
                wyyz.Text = dr["wyyz"].ToString();
                wysp.Text = dr["wysp"].ToString();
                jsjsp.Text = dr["jsjsp"].ToString();
                zzrzmc.Text = dr["zzrzmc"].ToString();
                bdwcjpxmc.Text = dr["bdwcjpxmc"].ToString();
                pxxyyxsj.Text = dr["pxxyyxsj"].ToString();
                //				pxxyyxsj.Text =((dr["pxxyyxsj"]==DBNull.Value) || (DateTime.Parse(dr["pxxyyxsj"].ToString()).Date==DateTime.Parse("1900-1-1").Date))?"":DateTime.Parse(dr["pxxyyxsj"].ToString()).ToString("yyyy-MM-dd");
                jtzz.Text = dr["jtzz"].ToString();
                this.txtYb.Text = dr["yb"].ToString();
                jjlxrxm.Text = dr["jjlxrxm"].ToString();
                jjlxrdh.Text = dr["jjlxrdh"].ToString();
                //				this.dbrsfzh.Text = dr["dbrsfzh"].ToString();

                bz.Text = dr["bz"].ToString();
                try
                {
                    if (dr["htlb"].ToString() != "")
                        this.htlb.SelectedValue = dr["htlb"].ToString();
                    else
                        this.htlb.SelectedIndex = 0;
                }
                catch
                {
                }

                //--------------------------tonzoc-01.20----------------------
                if (dr["zylb"].ToString() != string.Empty)
                {
                    ddlZylb.SelectedValue = dr["zylb"].ToString();
                }
                txtLzyy.Text = dr["lzyy"].ToString();
                txtLzsj.Text = dr["lzsj"].ToString();

                //SelectPosition(Int32.Parse(dr["Position_ID"].ToString()));-----wyw
                //SelectDepartment(dr["ry_bm"].ToString());

            }
            person = null;
            dr.Close();
            dr = null;
        }


        #region 没用
        //		private void SelectPosition(int PositionID)
        //		{
        //			for(int i = 0;i<cboPosition.Items.Count;i++ )
        //			{
        //				if(Int32.Parse(cboPosition.Items[i].Value) == PositionID)
        //					cboPosition.SelectedIndex = i;
        //			}
        //		}
        //		private void SelectDepartment(string DepName)
        //		{
        //			for(int i = 0;i<cboDepartment.Items.Count;i++ )
        //			{
        //				if(cboDepartment.Items[i].Text == DepName)
        //					cboDepartment.SelectedIndex = i;
        //			}
        //		}
        #endregion

        private void save_staff_data()
        {
            this.btn_bm_zw.Enabled = true;
            //			string[] bm_list = this.txt_bm.Text.Split(',');
            //			string[] zw_list = this.txt_zw.Text.Split(',');
            //			if(bm_list.Length != zw_list.Length)
            //			{
            //				Response.Write("<script> alert('请将部门和职务对应') </script>");
            //				return;
            //			}
            if (rb_male.Checked == true)
                sex = 1;
            else
                sex = 0;
            int age = 0;
            if (this.txtBirthday.Text != "")
                age = System.DateTime.Now.Date.Year - Convert.ToDateTime(this.txtBirthday.Text).Year;
            this.txtAge.Text = age.ToString();

            if (EditStatus == 0)
            {
                SqlDataReader dr;

                //				string bm01 = cboDepartment.Items[cboDepartment.SelectedIndex].Text;

                SqlParameter[] prams = {
										   SQLHelper.MakeInParam("@zgbh",SqlDbType.VarChar,10,zh.Text),
										   SQLHelper.MakeInParam("@RealName",SqlDbType.VarChar,50,txtRealName.Text),
										   SQLHelper.MakeInParam("@pylx",SqlDbType.VarChar,20,this.ddlPylx.SelectedValue),
										   SQLHelper.MakeInParam("@Sex",SqlDbType.Int,4,sex),
										   SQLHelper.MakeInParam("@Email",SqlDbType.VarChar,50,txtEmail.Text),
										   SQLHelper.MakeInParam("@Phone",SqlDbType.VarChar,50,txtPhone.Text),
										   SQLHelper.MakeInParam("@Mobile",SqlDbType.VarChar,50,txtMobile.Text),
										   SQLHelper.MakeInParam("@Birthday",SqlDbType.DateTime,8,(txtBirthday.Text.Trim()=="")?"1900-1-1":txtBirthday.Text),
										   SQLHelper.MakeInParam("@Age",SqlDbType.Int,4,Convert.ToInt32(this.txtAge.Text)),
										   SQLHelper.MakeInParam("@ywm",SqlDbType.VarChar,50,this.txtYwm.Text),	
										   SQLHelper.MakeInParam("@cym",SqlDbType.VarChar,50,this.txtCym.Text),	
										   SQLHelper.MakeInParam("@shi",SqlDbType.VarChar,50,shi.Text),	
										   SQLHelper.MakeInParam("@gwbdsj",SqlDbType.DateTime,8,(gwbdsj.Text.Trim()=="")?"1900-1-1":gwbdsj.Text),
										   SQLHelper.MakeInParam("@sfzh",SqlDbType.VarChar,50,sfzh.Text),
										   SQLHelper.MakeInParam("@mz",SqlDbType.VarChar,50,mz.Text),
										   SQLHelper.MakeInParam("@jg",SqlDbType.VarChar,50,jg.Text),
										   SQLHelper.MakeInParam("@hkszd",SqlDbType.VarChar,50,hkszd.Text),
										   SQLHelper.MakeInParam("@zzmm",SqlDbType.VarChar,50,zzmm.Text),
										   SQLHelper.MakeInParam("@rdpsj",SqlDbType.DateTime,8,(rdpsj.Text.Trim()=="")?"1900-1-1":rdpsj.Text),
										   SQLHelper.MakeInParam("@jkqk",SqlDbType.VarChar,50,jkqk.Text),
										   SQLHelper.MakeInParam("@hyzk",SqlDbType.VarChar,50,hyzk.Text),
										   SQLHelper.MakeInParam("@cjgzsj",SqlDbType.DateTime,8,(cjgzsj.Text.Trim()=="")?"1900-1-1":cjgzsj.Text),
										   SQLHelper.MakeInParam("@jbdwsj",SqlDbType.DateTime,8,(jbdwsj.Text.Trim()=="")?"1900-1-1":jbdwsj.Text),
										   SQLHelper.MakeInParam("@zc",SqlDbType.VarChar,50,zc.Text),
										   SQLHelper.MakeInParam("@zcjb",SqlDbType.VarChar,50,zcjb.SelectedValue),
										   SQLHelper.MakeInParam("@zcrdsj",SqlDbType.DateTime,8,(zcrdsj.Text.Trim()=="")?"1900-1-1":zcrdsj.Text),
										   SQLHelper.MakeInParam("@htqssj",SqlDbType.DateTime,8,(htqssj.Text.Trim()=="")?"1900-1-1":htqssj.Text),
										   SQLHelper.MakeInParam("@htzzsj",SqlDbType.DateTime,8,(htzzsj.Text.Trim()=="无固定" || htzzsj.Text.Trim()=="")?"1900-1-1":htzzsj.Text),
										  

										   SQLHelper.MakeInParam("@zgxl",SqlDbType.VarChar,50,this.ddlZgxl.SelectedItem.Text),
										   SQLHelper.MakeInParam("@bysj",SqlDbType.DateTime,8,(bysj.Text.Trim()=="")?"1900-1-1":bysj.Text),
										   SQLHelper.MakeInParam("@byxx",SqlDbType.VarChar,50,byxx.Text),
										   SQLHelper.MakeInParam("@sxzy",SqlDbType.VarChar,50,sxzy.Text),
										   SQLHelper.MakeInParam("@xxxs",SqlDbType.VarChar,50,xxxs.Text),
										   SQLHelper.MakeInParam("@wyyz",SqlDbType.VarChar,50,wyyz.Text),
										   SQLHelper.MakeInParam("@wysp",SqlDbType.VarChar,50,wysp.Text),										   
										   SQLHelper.MakeInParam("@jsjsp",SqlDbType.VarChar,50,jsjsp.Text),
										   SQLHelper.MakeInParam("@zzrzmc",SqlDbType.VarChar,50,zzrzmc.Text),
										   SQLHelper.MakeInParam("@bdwcjpxmc",SqlDbType.VarChar,50,bdwcjpxmc.Text),
										   SQLHelper.MakeInParam("@pxxyyxsj",SqlDbType.VarChar,50,pxxyyxsj.Text),
										   SQLHelper.MakeInParam("@jtzz",SqlDbType.VarChar,100,jtzz.Text),
										   SQLHelper.MakeInParam("@yb",SqlDbType.VarChar,10,this.txtYb.Text),
										   SQLHelper.MakeInParam("@jjlxrxm",SqlDbType.VarChar,50,jjlxrxm.Text),
										   SQLHelper.MakeInParam("@jjlxrdh",SqlDbType.VarChar,50,jjlxrdh.Text),
										   SQLHelper.MakeInParam("@bz",SqlDbType.VarChar,300,bz.Text),
										   SQLHelper.MakeInParam("@qzsp_id",SqlDbType.Int,4,qzsp_id),
//										   SQLHelper.MakeInParam("@dbrsfzh",SqlDbType.VarChar,50,this.dbrsfzh.Text),
										   SQLHelper.MakeInParam("@dbrsfzh",SqlDbType.VarChar,50,""),
											SQLHelper.MakeInParam("@rylb",SqlDbType.VarChar,50,this.rylb.SelectedValue),
											SQLHelper.MakeInParam("@htlb",SqlDbType.VarChar,50,this.htlb.SelectedValue),
											SQLHelper.MakeInParam("@zylb",SqlDbType.VarChar,50,this.ddlZylb.SelectedValue),
											SQLHelper.MakeInParam("@lzyy",SqlDbType.VarChar,200,this.txtLzyy.Text.Trim()),
											SQLHelper.MakeInParam("@lzsj",SqlDbType.VarChar,20,this.txtLzsj.Text.Trim())
									   };
                dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_Rs_AddStaff", prams);

                string UserRange = "";
                foreach (ListItem li in this.roleLbx.Items)
                {
                    UserRange = UserRange + li.Value.ToString() + ",";
                }

                Stoke.BLL.Utility.AddNewStaff(this.zh.Text, this.txtRealName.Text, this.DropDownList1.SelectedItem.Text.Trim(), this.DropDownList2.SelectedItem.Text.Trim());
                Stoke.BLL.SystemUM.addUserInfo(zh.Text, Stoke.BLL.Security.GetMd5Code(password.Text.Trim()), txtRealName.Text.Trim(), rb_male.Checked == true ? "男" : "女", txtPhone.Text.Trim(), txtMobile.Text.Trim(), jjlxrdh.Text.Trim(), DropDownList1.SelectedItem.Text.Trim(), DropDownList2.SelectedItem.Text.Trim(), txtEmail.Text.Trim(), DateTime.Now, UserRange);


                if (dr.Read())//插入后读出来
                {
                    //					for(int i=0;i<bm_list.Length;i++)
                    //						Stoke.Components.Staff.InsertDscoRy(qzsp_id,this.zh.Text,this.txtRealName.Text,bm_list[i],zw_list[i]); 

                    Response.Write("<script> alert('员工档案信息操作成功') </script>");

                    bm = null;
                    zw = null;
                    //					this.txt_bm.Text = "";
                    //					this.txt_zw.Text = "";
                }//uds中判断是否存在相同用户名 wyw
                else
                    Stoke.Components.Staff.DeleteDsocRyByZgbh(this.zh.Text);
                dr.Close();
                dr = null;
            }
            else
            {
                if (this.TD1.Visible == false)
                {
                    Stoke.Components.Staff person = new Stoke.Components.Staff();
                    #region 没用
                    ////					if(this.htzzsj.Text=="无固定")
                    ////						this.htzzsj.Text = "1900-01-01";
                    ////					int ret = person.UpdateInfo(zh.Text,txtRealName.Text,this.ddlPylx.SelectedValue,sex,txtEmail.Text,txtPhone.Text,txtMobile.Text,txtBirthday.Text==""?"1900-01-01":txtBirthday.Text,Int32.Parse(txtAge.Text),txtYwm.Text,txtCym.Text,shi.Text,gwbdsj.Text==""?"1900-01-01":gwbdsj.Text,sfzh.Text,mz.Text,jg.Text,hkszd.Text,zzmm.Text,rdpsj.Text==""?"1900-01-01":rdpsj.Text,jkqk.Text,hyzk.Text,cjgzsj.Text==""?"1900-01-01":cjgzsj.Text,jbdwsj.Text==""?"1900-01-01":jbdwsj.Text,zc.Text,zcjb.SelectedValue,zcrdsj.Text==""?"1900-01-01":zcrdsj.Text,htqssj.Text==""?"1900-01-01":htqssj.Text,htzzsj.Text==""?"1900-01-01":htzzsj.Text,this.ddlZgxl.SelectedItem.Text,bysj.Text==""?"1900-01-01":bysj.Text,byxx.Text,sxzy.Text,xxxs.Text,wyyz.Text,wysp.Text,jsjsp.Text,zzrzmc.Text,bdwcjpxmc.Text,pxxyyxsj.Text,jtzz.Text,txtYb.Text,jjlxrxm.Text,jjlxrdh.Text,bz.Text,dbrsfzh.Text,rylb.SelectedValue,htlb.SelectedValue);
                    //					int ret = person.UpdateInfo(zh.Text,txtRealName.Text,this.ddlPylx.SelectedValue,sex,txtEmail.Text,txtPhone.Text,txtMobile.Text,txtBirthday.Text==""?"1900-01-01":txtBirthday.Text,Int32.Parse(txtAge.Text),txtYwm.Text,txtCym.Text,shi.Text,gwbdsj.Text==""?"1900-01-01":gwbdsj.Text,sfzh.Text,mz.Text,jg.Text,hkszd.Text,zzmm.Text,rdpsj.Text==""?"1900-01-01":rdpsj.Text,jkqk.Text,hyzk.Text,cjgzsj.Text==""?"1900-01-01":cjgzsj.Text,jbdwsj.Text==""?"1900-01-01":jbdwsj.Text,zc.Text,zcjb.SelectedValue,zcrdsj.Text==""?"1900-01-01":zcrdsj.Text,htqssj.Text==""?"1900-01-01":htqssj.Text,(htzzsj.Text==""||htzzsj.Text=="无固定")?"1900-01-01":htzzsj.Text,this.ddlZgxl.SelectedItem.Text,bysj.Text==""?"1900-01-01":bysj.Text,byxx.Text,sxzy.Text,xxxs.Text,wyyz.Text,wysp.Text,jsjsp.Text,zzrzmc.Text,bdwcjpxmc.Text,pxxyyxsj.Text,jtzz.Text,txtYb.Text,jjlxrxm.Text,jjlxrdh.Text,bz.Text,"",rylb.SelectedValue,htlb.SelectedValue);
                    //					GetStaffInfo(zh.Text);
                    //
                    //					//					Stoke.Components.Staff.DeleteDsocRyByZgbh(this.zh.Text);
                    //					//					for(int i=0;i<bm_list.Length;i++)
                    //					//						Stoke.Components.Staff.UpdateDsocRy(this.zh.Text,this.txtRealName.Text,bm_list[i],zw_list[i]);
                    #endregion
                    int ret = -1;
                    try
                    {
                        ret = person.UpdateInfo(zh.Text, txtRealName.Text, this.ddlPylx.SelectedValue, sex, txtEmail.Text, txtPhone.Text, txtMobile.Text, txtBirthday.Text == "" ? "1900-01-01" : txtBirthday.Text, Int32.Parse(txtAge.Text), txtYwm.Text, txtCym.Text, shi.Text, gwbdsj.Text == "" ? "1900-01-01" : gwbdsj.Text, sfzh.Text, mz.Text, jg.Text, hkszd.Text, zzmm.Text, rdpsj.Text == "" ? "1900-01-01" : rdpsj.Text, jkqk.Text, hyzk.Text, cjgzsj.Text == "" ? "1900-01-01" : cjgzsj.Text, jbdwsj.Text == "" ? "1900-01-01" : jbdwsj.Text, zc.Text, zcjb.SelectedValue, zcrdsj.Text == "" ? "1900-01-01" : zcrdsj.Text, htqssj.Text == "" ? "1900-01-01" : htqssj.Text, (htzzsj.Text == "无固定" || htzzsj.Text.Trim() == "") ? "1900-01-01" : htzzsj.Text, this.ddlZgxl.SelectedItem.Text, bysj.Text == "" ? "1900-01-01" : bysj.Text, byxx.Text, sxzy.Text, xxxs.Text, wyyz.Text, wysp.Text, jsjsp.Text, zzrzmc.Text, bdwcjpxmc.Text, pxxyyxsj.Text, jtzz.Text, txtYb.Text, jjlxrxm.Text, jjlxrdh.Text, bz.Text, "", rylb.SelectedValue, htlb.SelectedValue, ddlZylb.SelectedValue, txtLzyy.Text.Trim(), txtLzsj.Text.Trim(), Request.QueryString["staffID"].ToString());
                        Utility.ModifyStaff(this.zh.Text, this.txtRealName.Text, this.DropDownList1.SelectedItem.Text.Trim(), this.DropDownList2.SelectedItem.Text.Trim());
                        Utility.ModifyUserInfo1(zh.Text, txtRealName.Text.Trim(), rb_male.Checked == true ? "男" : "女", txtPhone.Text.Trim(), txtMobile.Text.Trim(), jjlxrdh.Text.Trim(), DropDownList1.SelectedItem.Text.Trim(), DropDownList2.SelectedItem.Text.Trim(), txtEmail.Text.Trim(), DateTime.Now);
                        GetStaffInfo(zh.Text);
                    }
                    catch (Exception e)
                    {
                    }

                    if (ret == 0)
                        Response.Write("<script> alert('员工档案信息操作成功') </script>");
                }
            }
        }


        private void cmdSubmit_Click(object sender, System.EventArgs e)
        {
            string UserRange = "";
            foreach (ListItem li in this.roleLbx.Items)
            {
                UserRange = UserRange + li.Value.ToString() + ",";
            }
            if (this.DropDownList1.SelectedItem.Text == "-请选择-" || this.DropDownList2.SelectedItem.Text == "-请选择-" || this.txtRealName.Text == "" || this.zh.Text == "" || this.txtBirthday.Text == ""
                || this.htlb.SelectedIndex == 0 || this.ddlZgxl.SelectedIndex == 0 || this.ddlZylb.SelectedIndex == 0 || this.ddlPylx.SelectedIndex == 0)
            {
                Response.Write("<script> alert('请填写带*的项') </script>");
                return;
            }
            else if (ReturnPage != 1 && (this.password.Text.Trim() == string.Empty || passwordConfirm.Text.Trim() == string.Empty))
            {
                Response.Write("<script> alert('请输入密码！') </script>");
                return;
            }
            else if (ReturnPage != 1 && password.Text.Trim() != passwordConfirm.Text.Trim())
            {
                Response.Write("<script> alert('两次输入密码不一致，请检查后再次提交！') </script>");
                return;
            }
            else if (ReturnPage != 1 && UserRange == string.Empty)
            {
                Response.Write("<script> alert('请为人员选择相应的角色！') </script>");
                return;
            }
            else if (ReturnPage != 1 && judge_zc(this.zh.Text) == true)
            {
                Response.Write("<script> alert('此员工信息已经注册') </script>");
                return;
            }
            else if (ReturnPage == 3 && judge_zc(this.zh.Text) == true && qzsp_id != 0 && EditStatus == 0)//求职审批注册
            {
                Response.Write("<script> alert('此员工信息已经注册') </script>");
                return;
            }

            else
            {
                //				Response.Write("<script> alert('员工档案信息操作成功') </script>");
                save_staff_data();
                if (Session["CurrentImageUrl"] != null)
                {
                    string url = Session["CurrentImageUrl"].ToString();
                    string ry_zgbh = zh.Text.Trim();

                    Utility.AddUserImage(ry_zgbh, url);
                    Session.Remove("CurrentImageUrl");
                }
                Response.Redirect("ManageStaff.aspx");
            }

        }

        //12.7dxq 判断是否此人已经注册过
        private bool judge_zc(string zgbh)
        {
            int num = 0;
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str1 = "select ry_id from rs_staff where ry_zgbh= '" + zgbh + "'";
            SqlCommand cmd = new SqlCommand(str1, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetValue(0).ToString() != "")
                    num = Convert.ToInt32(dr.GetValue(0));

            }
            dr.Close();
            conn.Close();
            if (num == 0)
                return false;
            else
                return true;
        }

        //dxq 判断是否此人在职
        private bool judge_zz(string zgbh)
        {
            int num = 0;
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str1 = "select ry_id from rs_staff where ry_zgbh= '" + zgbh + "'and Dimission='" + 0 + "'";
            SqlCommand cmd = new SqlCommand(str1, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.GetValue(0).ToString() != "")
                    num = Convert.ToInt32(dr.GetValue(0));

            }
            dr.Close();
            conn.Close();
            if (num == 0)
                return false;
            else
                return true;
        }


        private void txtBirthday_TextChanged(object sender, System.EventArgs e)
        {
            if (this.txtBirthday.Text != "")
            {
                int age = System.DateTime.Now.Date.Year - Convert.ToDateTime(this.txtBirthday.Text).Year;
                this.txtAge.Text = age.ToString();
            }
        }
        #region 没用

        //		private void cboDepartment_SelectedIndexChanged(object sender, System.EventArgs e)
        //		{
        //			if(this.txt_bm.Text!="")
        //				bm=this.txt_bm.Text + ",";
        //			if(this.cboDepartment.SelectedIndex!=0)
        //				bm += this.cboDepartment.SelectedItem.Text.Trim() + ",";
        //			if(bm!="")
        //				this.txt_bm.Text = bm.Substring(0,bm.LastIndexOf(','));
        //		}
        //
        //		private void cboPosition_SelectedIndexChanged(object sender, System.EventArgs e)
        //		{
        //			if(this.txt_zw.Text!="")
        //				zw=this.txt_zw.Text + ",";
        //			if(this.cboPosition.SelectedIndex!=0)
        //				zw += this.cboPosition.SelectedItem.Text.Trim() + ",";
        //			if(zw!="")
        //			this.txt_zw.Text = zw.Substring(0,zw.LastIndexOf(','));
        //		}
        #endregion
        private void cmdBack_Click(object sender, System.EventArgs e)
        {
            if (ReturnPage == 1)
                Response.Redirect("ManageStaff.aspx");
            else if (ReturnPage == 2)
                Response.Redirect("tree_zw.aspx?org_id=" + org_id);//返回时使页面保持原状态
            else if (ReturnPage == 3)
                Response.Redirect("qzsp_list.aspx");
            else if (ReturnPage == 4)
                Response.Redirect("Sch/SearchAll.aspx");
            else if (ReturnPage == 5)
                Response.Redirect("Sch/SearchByBm.aspx");
        }

        private void btn_xg_Click(object sender, System.EventArgs e)
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("NewStaff");
            int nPageControls = FrmNewDocument.Controls.Count;
            for (int i = 0; i < nPageControls; i++)
            {
                foreach (System.Web.UI.Control control in FrmNewDocument.Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).BackColor = System.Drawing.Color.White;
                        (control as TextBox).Enabled = true;
                    }
                    else if (control is DropDownList)
                    {
                        (control as DropDownList).BackColor = System.Drawing.Color.White;
                        (control as DropDownList).Enabled = true;
                    }
                    else if (control is RadioButton)
                    {
                        (control as RadioButton).BackColor = System.Drawing.Color.White;
                        (control as RadioButton).Enabled = true;
                    }
                }
            }
            this.TD1.Visible = false;
            this.txt_bm.Enabled = false;
            this.txt_zw.Enabled = false;
            this.Button1.Enabled = true;
        }

        public void setTextBoxReadOnly(System.Web.UI.Control page)
        {
            int nPageControls = page.Controls.Count;
            for (int i = 0; i < nPageControls; i++)
            {
                foreach (System.Web.UI.Control control in page.Controls[i].Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as TextBox).Enabled = false;
                    }
                    else if (control is DropDownList)
                    {
                        (control as DropDownList).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as DropDownList).Enabled = false;
                    }
                    else if (control is RadioButton)
                    {
                        (control as RadioButton).BackColor = System.Drawing.Color.WhiteSmoke;
                        (control as RadioButton).Enabled = false;
                    }

                }
            }
        }

        private void btn_bm_zw_Click(object sender, System.EventArgs e)
        {


            //			if(ReturnPage==1&&flag_zc==true)//职工管理新员工
            //			{
            //				Response.Write("<script> alert('此员工信息已经注册') </script>");
            //				return;
            //			}
            //			if(ReturnPage==3&&flag_zc==true&&qzsp_id!=0)//求职审批注册
            //			{
            //				Response.Write("<script> alert('此员工信息已经注册') </script>");
            //				return;
            //			}


            if (EditStatus == 0)
            {
                if (this.zh.Text != "" && this.txtRealName.Text != "")
                {

                    string zgbh = this.zh.Text.ToString();
                    string xm = this.txtRealName.Text.ToString();
                    bool flag_zc = judge_zc(zgbh);
                    if (flag_zc == true)
                    {
                        Response.Write("<script> alert('此员工信息已经注册') </script>");
                        return;
                    }


                    save_staff_data();
                    //					if(this.txt_bm.Text!=""&&this.txt_zw.Text!="")
                    //						Stoke.Components.Staff.InsertDscoRy(this.zh.Text,this.txtRealName.Text,this.txt_bm.Text,this.txt_zw.Text);
                    Response.Redirect("ry_bm_zw.aspx?ReturnPage=0&ry_zgbh=" + this.zh.Text + "&ry_xm=" + this.txtRealName.Text);
                }
                else
                    Response.Write("<script> alert('请填写职工编号和职工姓名！') </script>");
            }
            else
            {
                //				save_staff_data();
                Response.Redirect("ry_bm_zw.aspx?ReturnPage=0&ry_zgbh=" + this.zh.Text + "&ry_xm=" + this.txtRealName.Text);
            }
        }

        private void zh_TextChanged(object sender, System.EventArgs e)
        {
            //			string zgbh=this.zh.Text.ToString();
            //			string xm=this.txtRealName.Text.ToString();
            //			bool flag_zc=judge_zc( zgbh,xm);
            //
            //			if(ReturnPage==1&&flag_zc==true)//职工管理新员工
            //			{
            //				Response.Write("<script> alert('此员工信息已经注册') </script>");
            //				return;
            //			}
            //			if(ReturnPage==3&&flag_zc==true&&qzsp_id!=0)//求职审批注册
            //			{
            //				Response.Write("<script> alert('此员工信息已经注册') </script>");
            //				return;
            //			}
        }

        private void BtnZwChange_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("ry_gwbb.aspx?ry_zgbh=" + this.zh.Text + "&ry_xm=" + this.txtRealName.Text);
        }

        protected void roleAddBtn_Click(object sender, EventArgs e)
        {
            int listboxcount = this.CandidateRoleLbx.Items.Count;
            int count = 0;
            foreach (ListItem li in this.CandidateRoleLbx.Items)
            {
                if (li.Selected)
                {
                    this.roleLbx.Items.Add(li);
                    this.CandidateRoleLbx.Items.Remove(li);
                    count++;
                }
                if (this.CandidateRoleLbx.Items.Count <= 0 || this.CandidateRoleLbx.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个角色！');</script>");
        }

        protected void roleDelBtn_Click(object sender, EventArgs e)
        {
            int listboxcount = this.roleLbx.Items.Count;
            int count = 0;
            foreach (ListItem li in this.roleLbx.Items)
            {
                if (li.Selected)
                {
                    this.CandidateRoleLbx.Items.Add(li);
                    this.roleLbx.Items.Remove(li);
                    count++;
                }
                if (this.roleLbx.Items.Count <= 0 || this.roleLbx.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请选择一个或多个角色！');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            topwindow.Visible = true;
            doing.Visible = true;
            init_image();
        }

        protected void closeBtn_Click(object sender, EventArgs e)
        {
            topwindow.Visible = false;
            doing.Visible = false;
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            init_image();
            int h = 0;
            FileStream fs = new FileStream(Server.MapPath(ImageUrl), FileMode.Open, FileAccess.Read);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
            h = image.Height;
            fs.Close();

            string tempurl = "../../Attachments/Refined_" + Session["imagefilename"];
            int startX = int.Parse(x1.Text) * h / 300;
            int startY = int.Parse(y1.Text) * h / 300;
            int width = int.Parse(Iwidth.Text) * h / 300;
            int height = int.Parse(Iheight.Text) * h / 300;
            ImgReduceCutOut(startX, startY, width, height, Server.MapPath(ImageUrl), Server.MapPath(tempurl));
            Session["CurrentImageUrl"] = tempurl;
            Session.Remove("imagefilename");

            topwindow.Visible = false;
            doing.Visible = false;
            BindImage();
        }

        /// <summary>
        /// 缩小裁剪图片
        /// </summary>
        /// <param name="int_Width">要缩小裁剪图片宽度</param>
        /// <param name="int_Height">要缩小裁剪图片长度</param>
        /// <param name="input_ImgUrl">要处理图片路径</param>
        /// <param name="out_ImgUrl">处理完毕图片路径</param>
        public void ImgReduceCutOut(int startX, int startY, int int_Width, int int_Height, string input_ImgUrl, string out_ImgUrl)
        {
            // ＝＝＝上传标准图大小＝＝＝
            int int_Standard_Width = 150;
            int int_Standard_Height = 150;

            int Reduce_Width = 0; // 缩小的宽度
            int Reduce_Height = 0; // 缩小的高度
            int CutOut_Width = 0; // 裁剪的宽度
            int CutOut_Height = 0; // 裁剪的高度
            int level = 100; //缩略图的质量 1-100的范围

            // ＝＝＝获得缩小，裁剪大小＝＝＝
            if (int_Standard_Height * int_Width / int_Standard_Width > int_Height)
            {
                Reduce_Width = int_Width;
                Reduce_Height = int_Standard_Height * int_Width / int_Standard_Width;
                CutOut_Width = int_Width;
                CutOut_Height = int_Height;
            }
            else if (int_Standard_Height * int_Width / int_Standard_Width < int_Height)
            {
                Reduce_Width = int_Standard_Width * int_Height / int_Standard_Height;
                Reduce_Height = int_Height;
                CutOut_Width = int_Width;
                CutOut_Height = int_Height;
            }
            else
            {
                Reduce_Width = int_Width;
                Reduce_Height = int_Height;
                CutOut_Width = int_Width;
                CutOut_Height = int_Height;
            }

            // ＝＝＝通过连接创建Image对象＝＝＝
            System.Drawing.Image oldimage = System.Drawing.Image.FromFile(input_ImgUrl);
            oldimage.Save(Server.MapPath("tepm.jpg"));
            oldimage.Dispose();

            //// ＝＝＝缩小图片＝＝＝
            //System.Drawing.Image thumbnailImage = oldimage.GetThumbnailImage(Reduce_Width, Reduce_Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            Bitmap bm = new Bitmap(Server.MapPath("tepm.jpg"));

            // ＝＝＝处理JPG质量的函数＝＝＝
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == "image/jpeg")
                {
                    ici = codec;
                    break;
                }

            }
            EncoderParameters ep = new EncoderParameters();
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)level);



            // ＝＝＝裁剪图片＝＝＝
            Rectangle cloneRect = new Rectangle(startX, startY, CutOut_Width, CutOut_Height);
            PixelFormat format = bm.PixelFormat;
            Bitmap cloneBitmap = bm.Clone(cloneRect, format);

            // ＝＝＝保存图片＝＝＝
            cloneBitmap.Save(out_ImgUrl, ici, ep);
            bm.Dispose();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                if (FileUpload1.PostedFile.ContentLength < 10485760)
                {
                    try
                    {
                        string fileurl = FileUpload1.PostedFile.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("../../Attachments/" + fileurl));
                        Session["imagefilename"] = fileurl;
                        init_image();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script type=text/javascript>alert('上传失败！')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script type=text/javascript>alert('请确认操作正确且附件名称已填写！')</script>");
            }
        }
    }
}
