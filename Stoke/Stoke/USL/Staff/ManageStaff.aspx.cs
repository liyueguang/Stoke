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
using Stoke.Components;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Stoke.USL.Staff
{
    public partial class ManageStaff : System.Web.UI.Page
    {
        public int DisplayType;
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                else
                    DisplayType = 0;
            }
            else
                DisplayType = 0;



            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");

            //------------------------tonzoc-1.21-----------------------------
            if (DisplayType == 1)
            {
                this.dbStaffList.Columns[9].Visible = true;
                this.dbStaffList.Columns[10].Visible = false;
            }
            else
            {
                this.dbStaffList.Columns[9].Visible = false;
                Stoke.Components.xtqx _xtqx = new Stoke.Components.xtqx();
                int _is_rs_wx_oper = _xtqx.Isqx(_zgbh, "职工基本信息管理", "操作权");

                if (_is_rs_wx_oper != 1)
                {
                    this.dbStaffList.Columns[10].Visible = false;
                }
                else
                {
                    this.dbStaffList.Columns[10].Visible = true;
                }
            }
            //--------------------------------------------------------------------

            if (!Page.IsPostBack)
            {
                Stoke.Components.xtqx _xtqx = new Stoke.Components.xtqx();
                int _is_rs_wx_oper = _xtqx.Isqx(_zgbh, "职工基本信息管理", "操作权");
                //				Session["_is_rs_wx_oper"] = _is_rs_wx_oper;

                if (_is_rs_wx_oper != 1)
                {
                    this.btn_ry_photo.Visible = false;
                    this.cmdNewStaff.Visible = true;
                }

                BindBm();
                //				if(Session["text1"]!=null)
                //					this.txtCondition1.Text = Session["text1"].ToString();
                //				else
                //					this.txtCondition1.Text = "";
                //				if(Session["text2"]!=null)
                //					this.txtCondition2.Text = Session["text2"].ToString();
                //				else
                //					this.txtCondition2.Text = "";
                //				if(Session["text3"]!=null)
                //					this.txtCondition3.Text = Session["text3"].ToString();
                //				else
                //					this.txtCondition3.Text = "";
                //
                //				if(Session["condition0"]!=null)
                //					this.ddlCondition0.SelectedValue = Session["condition0"].ToString();
                //				else
                //					this.ddlCondition0.SelectedValue = "-请选择-";
                //				if(Session["condition1"]!=null)
                //					this.ddlCondition1.SelectedValue = Session["condition1"].ToString();
                //				else
                //					this.ddlCondition1.SelectedValue = "-请选择-";
                //				if(Session["condition2"]!=null)
                //					this.ddlCondition2.SelectedValue = Session["condition2"].ToString();
                //				else
                //					this.ddlCondition2.SelectedValue = "-请选择-";
                //				if(Session["condition3"]!=null)
                //					this.ddlCondition3.SelectedValue = Session["condition3"].ToString();
                //				else
                //					this.ddlCondition3.SelectedValue = "-请选择-";
                Session["text1"] = "";
                Session["text2"] = "";
                Session["text3"] = "";
                Session["condition0"] = "-请选择-";
                Session["condition1"] = "-请选择-";
                Session["condition2"] = "-请选择-";
                Session["condition3"] = "-请选择-";

                BindGridByCondition();
            }
            //			cmdDimission.Attributes.Add("OnClick","return confirm('是否离职？');");
            //			cmdChangePosition.Attributes.Add("OnClick","return confirm('是否调职？');");

            //-----------------------------------tonzoc-1.21-----------------------------------
            for (int i = 0; i < this.dbStaffList.Items.Count; i++)
            {
                //string test = this.dbStaffList.Items[i].Cells[2].Text.ToString();
                if (this.dbStaffList.Items[i].Cells[2].Text.ToString() == "&nbsp;")
                {
                    this.dbStaffList.Items[i].Cells[10].Text = "&nbsp;";
                }
            }
            //---------------------------------------------------------------------------------
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
            this.ddlCondition1.SelectedIndexChanged += new System.EventHandler(this.ddlCondition1_SelectedIndexChanged);
            this.ddlZylb.SelectedIndexChanged += new System.EventHandler(this.ddlZylb_SelectedIndexChanged);
            this.ddlCondition2.SelectedIndexChanged += new System.EventHandler(this.ddlCondition2_SelectedIndexChanged);
            this.ddlZylb1.SelectedIndexChanged += new System.EventHandler(this.ddlZylb1_SelectedIndexChanged);
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
            this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.cmdNewStaff.Click += new System.EventHandler(this.cmdNewStaff_Click);
            this.btn_ry_photo.Click += new System.EventHandler(this.btn_ry_photo_Click);
            this.dbStaffList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbStaffList_ItemCommand);
            this.dbStaffList.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbStaffList_ItemDataBound);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        private void BindBm()
        {
            DataTable dt_bm = Stoke.BLL.Department.GetAll();
            this.ddlCondition0.DataSource = dt_bm;
            this.ddlCondition0.DataTextField = "bm_mc";
            this.ddlCondition0.DataValueField = "bm_mc";
            this.ddlCondition0.DataBind();
            this.ddlCondition0.Items.Insert(0, "-请选择-");
            this.ddlCondition0.SelectedIndex = 0;
        }

        //条件绑定员工
        private void BindGridByCondition()
        {

            //			Session["condition0"] = this.ddlCondition0.SelectedValue;
            //			Session["condition1"] = this.ddlCondition1.SelectedValue;
            //			Session["condition2"] = this.ddlCondition2.SelectedValue;
            //			Session["condition3"] = this.ddlCondition3.SelectedValue;
            //			Session["text1"] = this.txtCondition1.Text;
            //			Session["text2"] = this.txtCondition2.Text;
            //			Session["text3"] = this.txtCondition3.Text;

            string condition0;
            string condition1;
            string condition2;
            string condition3;
            string _condition3;

            string condition0_lz;
            string condition1_lz;
            string condition2_lz;
            string condition3_lz;
            string _condition3_lz;


            //			string text0 = this.ddlCondition0.SelectedValue.Trim();
            //			string text1 = this.txtCondition1.Text;
            //			string text2 = this.txtCondition2.Text;
            //			string text3 = this.txtCondition3.Text;

            string text0 = "-请选择-";
            string text1 = "";
            string text2 = "";
            string text3 = "";


            if (Session["condition0"] != null)
                text0 = Session["condition0"].ToString();

            if (Session["text1"] != null)
                text1 = Session["text1"].ToString();
            if (Session["text2"] != null)
                text2 = Session["text2"].ToString();
            if (Session["text3"] != null)
                text3 = Session["text3"].ToString();


            string[] rq = new string[3];
            char[] seprator = new char[1];
            seprator[0] = '-';
            //			if(this.ddlCondition0.SelectedIndex!=0)
            if (text0 != "-请选择-")
            {
                condition0 = "dsoc_ry.ry_bm";
                condition0_lz = "dsoc_ry_lz.ry_bm";
            }
            else
            {
                condition0 = "";
                condition0_lz = "";
            }

            //			if(this.ddlCondition1.SelectedIndex!=0&&this.txtCondition1.Text!="")
            if (Session["condition1"].ToString() != "-请选择-" && text1 != "")
            {
                //				condition1 = this.ddlCondition1.SelectedValue.Trim();
                condition1 = Session["condition1"].ToString();
                condition1_lz = Session["condition1"].ToString();

                if (condition1 == "ry_zw")
                    condition1 = "dsoc_ry." + condition1;
                else
                    condition1 = "rs_staff." + condition1;

                if (condition1_lz == "ry_zw")
                    condition1_lz = "dsoc_ry_lz." + condition1_lz;
                else
                    condition1_lz = "rs_staff." + condition1_lz;
            }
            else
            {
                condition1 = "";
                condition1_lz = "";
            }

            //			if(this.ddlCondition2.SelectedIndex!=0&&this.txtCondition2.Text!="")
            if (Session["condition2"].ToString() != "-请选择-" && text2 != "")
            {
                //				condition2 = this.ddlCondition2.SelectedValue.Trim();
                condition2 = Session["condition2"].ToString();
                condition2_lz = Session["condition2"].ToString();
                if (condition2 == "ry_zw")
                    condition2 = "dsoc_ry." + condition2;
                else
                    condition2 = "rs_staff." + condition2;

                if (condition2_lz == "ry_zw")
                    condition2_lz = "dsoc_ry_lz." + condition2_lz;
                else
                    condition2_lz = "rs_staff." + condition2_lz;
            }
            else
            {
                condition2 = "";
                condition2_lz = "";
            }

            //			if(this.ddlCondition3.SelectedIndex!=0&&this.txtCondition3.Text!="")
            if (Session["condition3"].ToString() != "-请选择-" && text3 != "")
            //				condition3 = "rs_staff." + this.ddlCondition3.SelectedValue.Trim();
            {
                condition3 = "rs_staff." + Session["condition3"].ToString();
                condition3_lz = "rs_staff." + Session["condition3"].ToString();
            }

            else
            {
                condition3 = "";
                condition3_lz = "";
            }


            string _connString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection _conn = new SqlConnection(_connString);
            _conn.Open();
            string _sql = "SELECT distinct rs_staff.*,Case Sex When 1 Then '男' Else '女' End AS SexName FROM rs_staff,dsoc_ry where rs_staff.Dimission=" + DisplayType;
            string _sql_lz = "SELECT distinct rs_staff.*,Case Sex When 1 Then '男' Else '女' End AS SexName FROM rs_staff,dsoc_ry_lz where rs_staff.Dimission=" + DisplayType;

            if (condition0 != "")
                _sql = _sql + " and " + condition0 + " = '" + text0 + "'";
            if (condition0_lz != "")
                _sql_lz = _sql_lz + " and " + condition0_lz + " = '" + text0 + "'";

            if (condition1 != "")
            {
                if (condition1 == "rs_staff.pylx" || condition1 == "rs_staff.Age")
                    _sql = _sql + " and " + condition1 + " = '" + text1 + "'";
                else
                    _sql = _sql + " and " + condition1 + " like '%" + text1 + "%'";
            }

            if (condition1_lz != "")
            {
                if (condition1_lz == "rs_staff.pylx" || condition1_lz == "rs_staff.Age")
                    _sql_lz = _sql_lz + " and " + condition1_lz + " = '" + text1 + "'";
                else
                    _sql_lz = _sql_lz + " and " + condition1_lz + " like '%" + text1 + "%'";
            }
            if (condition2 != "")
                _sql = _sql + " and " + condition2 + " like '%" + text2 + "%'";
            if (condition2_lz != "")
                _sql_lz = _sql_lz + " and " + condition2_lz + " like '%" + text2 + "%'";

            if (condition3 != "")
            {
                rq = text3.Split(seprator[0]);
                _condition3 = " and year(" + condition3 + ")= '" + rq[0] + "'";
                if (rq.Length == 2)
                {
                    _condition3 = " and year(" + condition3 + ")= '" + rq[0] + "'";
                    _condition3 = _condition3 + " and month(" + condition3 + ")= '" + rq[1] + "'";
                }
                else if (rq.Length == 3)
                {
                    _condition3 = " and year(" + condition3 + ")= '" + rq[0] + "'";
                    _condition3 = _condition3 + " and month(" + condition3 + ")= '" + rq[1] + "'";
                    _condition3 = _condition3 + " and day(" + condition3 + ")= '" + rq[2] + "'";
                }
                _sql = _sql + _condition3;
            }

            if (condition3_lz != "")
            {
                rq = text3.Split(seprator[0]);
                _condition3_lz = " and year(" + condition3_lz + ")= '" + rq[0] + "'";
                if (rq.Length == 2)
                {
                    _condition3_lz = " and year(" + condition3_lz + ")= '" + rq[0] + "'";
                    _condition3_lz = _condition3_lz + " and month(" + condition3 + ")= '" + rq[1] + "'";
                }
                else if (rq.Length == 3)
                {
                    _condition3_lz = " and year(" + condition3_lz + ")= '" + rq[0] + "'";
                    _condition3_lz = _condition3_lz + " and month(" + condition3_lz + ")= '" + rq[1] + "'";
                    _condition3_lz = _condition3_lz + " and day(" + condition3_lz + ")= '" + rq[2] + "'";
                }
                _sql_lz = _sql_lz + _condition3_lz;
            }
            _sql = _sql + " and rs_staff.ry_zgbh=dsoc_ry.ry_zgbh";
            _sql_lz = _sql_lz + " and rs_staff.ry_zgbh=dsoc_ry_lz.ry_zgbh";
            //			if(condition0=="" && condition1=="" && condition2=="" && condition3=="")
            //				_sql = _sql + " and 1=0";
            _sql = _sql + " order by rs_staff.ry_order_select, rs_staff.ry_zgbh";
            _sql_lz = _sql_lz + " order by rs_staff.ry_order_select, rs_staff.ry_zgbh";
            string _sql1 = "";
            if (DisplayType == 0)
            {
                _sql1 = _sql;
            }
            else
                _sql1 = _sql_lz;
            SqlCommand _cmd = new SqlCommand(_sql1, _conn);
            SqlDataAdapter _da = new SqlDataAdapter(_cmd);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            _conn.Close();

            int dt_count = _dt.Rows.Count;
            //			this.lab_result.Text = "统计人数:" + dt_count;

            this.dbStaffList.DataSource = _dt;
            this.dbStaffList.DataBind();
            int count = dbStaffList.PageSize * dbStaffList.PageCount - _dt.Rows.Count;
            for (int i = 0; i < count; i++)
                _dt.Rows.Add(_dt.NewRow());

            this.dbStaffList.DataBind();

            //-----------------------------------tonzoc-1.21-----------------------------------
            for (int i = 0; i < this.dbStaffList.Items.Count; i++)
            {
                //string test = this.dbStaffList.Items[i].Cells[2].Text.ToString();
                if (this.dbStaffList.Items[i].Cells[2].Text.ToString() == "&nbsp;")
                {
                    this.dbStaffList.Items[i].Cells[10].Text = "&nbsp;";
                }
            }
            //---------------------------------------------------------------------------------

            for (int i = 0; i < dt_count; i++)
            {
                string connstr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                conn = new SqlConnection(connstr);
                if (DisplayType == 0)
                    cmd = new SqlCommand("sp_Rs_GetBmZwbyZgbh", conn);
                else
                    cmd = new SqlCommand("sp_Rs_GetBmZwbyZgbh_lz", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ry_zgbh", SqlDbType.VarChar, 10);

                try
                {
                    cmd.Parameters["@ry_zgbh"].Value = this.dbStaffList.Items[i].Cells[2].Text.ToString();

                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    adapter1.Fill(ds1);
                    DataTable table = ds1.Tables[0];
                    string position = "";
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        position += table.Rows[j][0].ToString() + " / ";
                    }
                    this.dbStaffList.Items[i].Cells[8].Text = position.ToString().Substring(0, position.LastIndexOf('/'));
                }
                catch
                {
                }

            }

        }


        #region 翻页事件
        public void DataGrid_PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            dbStaffList.CurrentPageIndex = e.NewPageIndex;
            //			BindGrid();
            BindGridByCondition();
        }
        #endregion
        private void lbOnline_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("ManageStaff.aspx?DisplayType=0&condition0=" + this.ddlCondition0.SelectedValue + "&condition1=" + this.ddlCondition1.SelectedValue + "&condition2=" + this.ddlCondition2.SelectedValue + "&condition3=" + this.ddlCondition3.SelectedValue + "&text1=" + this.txtCondition1.Text + "&text2=" + this.txtCondition2.Text + "&text3=" + this.txtCondition3.Text);
        }

        private void lbOffLine_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("ManageStaff.aspx?DisplayType=1&condition0=" + this.ddlCondition0.SelectedValue + "&condition1=" + this.ddlCondition1.SelectedValue + "&condition2=" + this.ddlCondition2.SelectedValue + "&condition3=" + this.ddlCondition3.SelectedValue + "&text1=" + this.txtCondition1.Text + "&text2=" + this.txtCondition2.Text + "&text3=" + this.txtCondition3.Text);
        }

        private void dbStaffList_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }


        private string GetSelectedItemID(string controlID)
        {
            string selectedID;
            selectedID = "";
            //遍历DataGrid获得checked的ID
            foreach (DataGridItem item in dbStaffList.Items)
            {
                if (((CheckBox)item.FindControl(controlID)).Checked == true)
                    selectedID += dbStaffList.DataKeys[item.ItemIndex] + ",";
            }
            if (selectedID.Length > 0)
                selectedID = selectedID.Substring(0, selectedID.Length - 1);
            return selectedID;
        }


        private void cmdNewStaff_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("NewStaff.aspx?ReturnPage=2");
        }






        #region 好像没有触发

        private void BindGrid()
        {
            SqlDataReader dr; //存放人物的数据
            SqlParameter[] prams = {
									   Stoke.DAL.SQLHelper.MakeInParam("@StaffType",SqlDbType.Bit,1,DisplayType)
								   };
            dr = Stoke.DAL.SQLHelper.ExecuteReader(Stoke.DAL.SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_Rs_GetAllStaff");
            //db.RunProc("sp_Rs_GetAllStaff", prams, out dr);
            DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

            //			dbStaffList.DataSource = dt.DefaultView;
            //			dbStaffList.DataBind();

            this.dbStaffList.DataSource = dt.DefaultView;
            this.dbStaffList.DataBind();
            int count = dbStaffList.PageSize * dbStaffList.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());

            this.dbStaffList.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string connstr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                conn = new SqlConnection(connstr);
                cmd = new SqlCommand("sp_Rs_GetBmZwbyZgbh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ry_zgbh", SqlDbType.VarChar, 10);

                try
                {
                    cmd.Parameters["@ry_zgbh"].Value = this.dbStaffList.Items[i].Cells[2].Text.ToString();

                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    adapter1.Fill(ds1);
                    DataTable table = ds1.Tables[0];
                    string position = "";
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        position += table.Rows[j][0].ToString() + " / ";
                    }
                    this.dbStaffList.Items[i].Cells[8].Text = position.ToString().Substring(0, position.LastIndexOf('/'));
                }
                catch
                {
                }
            }
            dr.Close();

        }

        //离职,复职通知
        private void sms_all(int i)
        {
            string strStaffID = this.GetSelectedItemID("chkStaff_ID");
            SqlDataReader dr_this;//被选择人员
            Stoke.Components.Staff sta = new Stoke.Components.Staff();
            dr_this = sta.GetStaffInfo(strStaffID);
            //处理短信提醒
            while (dr_this.Read())
            {
                string Position_name = dr_this["Position_name"].ToString();
                SqlDataReader dr_isok;//所有在职人员
                dr_isok = sta.GetAllStaffs();
                while (dr_isok.Read())
                {
                    string Staff_name = dr_isok["Staff_name"].ToString();
                    //					if(i==0)
                    //						sm.SendMsg(Username,Staff_name,Position_name+" 处员工:"+dr_this["RealName"].ToString()+",已经离职,特此通知.",1,DateTime.Now,"",0,0);
                    //					else
                    //						sm.SendMsg(Username,dr_isok["Staff_name"].ToString(),dr_this["Position_name"].ToString()+" 处员工:"+dr_this["RealName"].ToString()+",已经恢复原职,特此通知.",1,DateTime.Now,"",0,0);
                }
                dr_isok.Close();
                dr_isok = null;
            }
            dr_this.Close();
            dr_this = null;
        }

        private void cmdDimission_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("ygdlsp_list.aspx");
        }
        private void cmdRehab_Click(object sender, System.EventArgs e)
        {
            string strStaffID = this.GetSelectedItemID("chkStaff_ID");
            if (strStaffID != "")
            {
                Stoke.Components.Staff person = new Stoke.Components.Staff();
                if (person.Rehab(strStaffID) == true)
                {
                    BindGrid();
                }
                person = null;
            }
            else
                Response.Write("<script language=javascript>alert('请选择要复职的人员！');</script>");
        }


        private void cmdChangePosition_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("ygddsp_list.aspx");
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("StaffStatistics.aspx");
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("StaffStatPerMonth.aspx");
        }

        #endregion
        private void btn_Search_Click(object sender, System.EventArgs e)
        {
            this.dbStaffList.CurrentPageIndex = 0;

            Session["condition0"] = this.ddlCondition0.SelectedValue;
            Session["condition1"] = this.ddlCondition1.SelectedValue;
            Session["condition2"] = this.ddlCondition2.SelectedValue;
            Session["condition3"] = this.ddlCondition3.SelectedValue;
            Session["text1"] = this.txtCondition1.Text;
            Session["text2"] = this.txtCondition2.Text;
            Session["text3"] = this.txtCondition3.Text;
            BindGridByCondition();
        }



        private void btn_ry_photo_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("ry_photo.aspx");
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



            //防止DataGrid进行了分页，此处将其设置为false，再输出

            this.dbStaffList.AllowPaging = false;
            BindGridByCondition();
            this.dbStaffList.RenderControl(hw);



            Response.Write(tw.ToString());
            Response.End();
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            this.dbStaffList.Columns[10].Visible = false;
            this.ExportDataGrid("application/ms-word", "职工信息表" + ".xls");
        }

        private void ddlCondition1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlCondition1.SelectedValue.ToString().Trim() == "zylb")
            {
                ddlZylb.Visible = true;
                ddlZylb.SelectedValue = "-请选择-";
                txtCondition1.Visible = false;
                txtCondition1.Text = string.Empty;
            }
            else
            {
                ddlZylb.Visible = false;
                txtCondition1.Visible = true;
                txtCondition1.Text = string.Empty;
            }
        }

        private void ddlZylb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlZylb.SelectedValue.ToString().Trim() != "-请选择-")
            {
                txtCondition1.Text = ddlZylb.SelectedValue.ToString().Trim();
            }
            else
            {
                txtCondition1.Text = string.Empty;
            }
        }

        private void ddlZylb1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlZylb1.SelectedValue.ToString().Trim() != "-请选择-")
            {
                txtCondition2.Text = ddlZylb1.SelectedValue.ToString().Trim();
            }
            else
            {
                txtCondition2.Text = string.Empty;
            }
        }

        private void ddlCondition2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlCondition2.SelectedValue.ToString().Trim() == "zylb")
            {
                ddlZylb1.Visible = true;
                ddlZylb1.SelectedValue = "-请选择-";
                txtCondition2.Visible = false;
                txtCondition2.Text = string.Empty;
            }
            else
            {
                ddlZylb1.Visible = false;
                txtCondition2.Visible = true;
                txtCondition2.Text = string.Empty;
            }
        }

        private void dbStaffList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "delete")
            {
                string _ry_zgbh = e.Item.Cells[2].Text.ToString();

                Stoke.BLL.Staff.DeleteRy1(_ry_zgbh);

                Response.Write("<script>alert('该员工已成功离职！')</script>");
                BindGridByCondition();
            }

        }

        private void dbStaffList_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btn = (LinkButton)e.Item.Cells[4].FindControl("LinkButton2");
                btn.Attributes.Add("onclick", "javascript:return window.confirm('确定离职?离职后无法恢复!');");
            }

            //----------------------------------tonzoc-0305-------------------------------
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Cells[3].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            }
            //----------------------------------------------------------------------------
        }
    }
}
