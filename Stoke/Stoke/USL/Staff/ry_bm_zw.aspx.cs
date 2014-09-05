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
using Stoke.Components;
using Stoke.COMMON;
using Stoke.DAL;

namespace Stoke.USL.Staff
{
    public partial class ry_bm_zw : System.Web.UI.Page
    {
        protected int ReturnPage = 0;
        protected static string bm_mc;
        protected int EditStatus = 0;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Request.QueryString["EditStatus"] != null)
                if (Request.QueryString["EditStatus"].ToString() != "")
                    EditStatus = Int32.Parse(Request.QueryString["EditStatus"].ToString());
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ry_zgbh"] != null)
                    if (Request.QueryString["ry_zgbh"].ToString() != "")
                        this.txt_zgbh.Text = Request.QueryString["ry_zgbh"].ToString();
                if (Request.QueryString["ry_xm"] != null)
                    if (Request.QueryString["ry_xm"].ToString() != "")
                        this.txt_xm.Text = Request.QueryString["ry_xm"].ToString();
                if (Request.QueryString["bm_mc"] != null)
                    if (Request.QueryString["bm_mc"].ToString() != "")
                        bm_mc = Request.QueryString["bm_mc"].ToString();
                if (Request.QueryString["ReturnPage"] != null)
                {
                    if (Request.QueryString["ReturnPage"].ToString() != "")
                    {
                        ReturnPage = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
                    }
                    else
                        ReturnPage = 0;
                }
                else
                    ReturnPage = 0;

                BindPosition();
                BindDepartment();
                BindGrid();
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
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            this.dbRyBmZw.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbRyBmZw_ItemCommand);
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindPosition()
        {
            SqlDataReader dr_position = null;
            dr_position = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_Rs_GetAllPosition");
            cboPosition.DataSource = dr_position;
            cboPosition.DataTextField = "zw_mc";
            cboPosition.DataValueField = "zw_mc";
            cboPosition.DataBind();
            cboPosition.Items.Insert(0, "-请选择-");
            cboPosition.SelectedIndex = 0;
            dr_position.Close();
        }
        private void BindDepartment()
        {
            SqlDataReader dr_department = null;
            dr_department = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.StoredProcedure, "RS_GetAllDepartment");
            cboDepartment.DataSource = dr_department;
            cboDepartment.DataTextField = "bm_mc";
            cboDepartment.DataValueField = "bm_mc";
            cboDepartment.DataBind();
            cboDepartment.Items.Insert(0, "-请选择-");
            cboDepartment.SelectedIndex = 0;
            dr_department.Close();
        }


        private void BindGrid()
        {
            DataTable dt = new DataTable();
            if (judge_zz(this.txt_zgbh.Text) == true)
                dt = Stoke.Components.Staff.SelectRyByZgbh(this.txt_zgbh.Text.Trim());
            else dt = Stoke.Components.Staff.SelectRyByZgbh_lz(this.txt_zgbh.Text.Trim());
            this.dbRyBmZw.DataSource = dt;
            this.dbRyBmZw.DataBind();
            int count = dbRyBmZw.PageSize * dbRyBmZw.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            this.dbRyBmZw.DataBind();

            for (int i = 0; i < dbRyBmZw.Items.Count; i++)
            {
                if (dbRyBmZw.Items[i].Cells[0].Text == "&nbsp;")
                {
                    LinkButton btn1 = new LinkButton();
                    btn1 = (LinkButton)dbRyBmZw.Items[i].FindControl("LinkButton1");
                    btn1.Visible = false;
                    LinkButton btn2 = new LinkButton();
                    btn2 = (LinkButton)dbRyBmZw.Items[i].FindControl("LinkButton2");
                    btn2.Visible = false;
                }
            }
        }

        private void dbRyBmZw_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "sc")
            {
                int ret = -1;
                if (judge_zz(this.txt_zgbh.Text) == true)
                {
                    if (judge_onlyonepositon(this.txt_zgbh.Text) == false)
                        ret = Stoke.Components.Staff.DeleteDsocRyByID(int.Parse(e.Item.Cells[0].Text));
                    else
                    {
                        Response.Write("<script>alert('请先添加新职位，然后进行删除操作！')</script>");
                        return;
                    }
                }
                else
                    ret = Stoke.Components.Staff.DeleteDsocRyByID_lz(int.Parse(e.Item.Cells[0].Text));
                if (ret != -1)
                    Response.Write("<script>alert('删除成功！')</script>");
                this.dbRyBmZw.CurrentPageIndex = 0;
                this.BindGrid();
            }
            else if (e.CommandName == "add")
            {
                Stoke.Components.Staff.addGwbd(e.Item.Cells[1].Text.Trim(), e.Item.Cells[2].Text.Trim(), e.Item.Cells[3].Text.Trim(), e.Item.Cells[4].Text.Trim());
            }
        }

        private void btn_add_Click(object sender, System.EventArgs e)
        {
            if (this.txt_zgbh.Text == "" || this.txt_xm.Text == "" || this.cboDepartment.SelectedIndex == 0 || this.cboPosition.SelectedIndex == 0)
            {
                Response.Write("<script>alert('请填写带*的项！')</script>");
                return;
            }
            int ret = -1;
            if (judge_zz(this.txt_zgbh.Text) == true)
                ret = Stoke.Components.Staff.InsertDscoRy(this.txt_zgbh.Text, this.txt_xm.Text, this.cboDepartment.SelectedValue.Trim(), this.cboPosition.SelectedValue.Trim());
            else
                ret = Stoke.Components.Staff.InsertDscoRy_lz(this.txt_zgbh.Text, this.txt_xm.Text, this.cboDepartment.SelectedValue.Trim(), this.cboPosition.SelectedValue.Trim());
            if (ret != -1)
                Response.Write("<script>alert('添加成功！')</script>");
            this.dbRyBmZw.CurrentPageIndex = 0;
            this.BindGrid();
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

        private void cmdBack_Click(object sender, System.EventArgs e)
        {
            if (ReturnPage == 0)
                Server.Transfer("NewStaff.aspx?ReturnPage=1&StaffID=" + this.txt_zgbh.Text + "&ry_xm=" + this.txt_xm.Text + "&EditStatus=" + EditStatus);
            else if (ReturnPage == 1)
                Response.Redirect("scxmz.aspx?bm_mc=" + bm_mc);
            else if (ReturnPage == 2)
                Response.Redirect("xzxmz.aspx?bm_mc=" + bm_mc);
        }

        //tonzoc 判断是否只有唯一的职位，也即dsoc_ry中是否只有一条记录
        private bool judge_onlyonepositon(string zgbh)
        {
            int num = 0;
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str1 = "select ry_id from dsoc_ry where ry_zgbh= '" + zgbh + "'";
            SqlCommand cmd = new SqlCommand(str1, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                num++;
            }
            dr.Close();
            conn.Close();
            if (num == 1)
                return true;
            else
                return false;
        }
    }
}
