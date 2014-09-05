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

namespace Stoke.USL.Staff
{
    public partial class xzxmz : System.Web.UI.Page
    {

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (!Page.IsPostBack)
            {
                DataTable dt_bm = Stoke.BLL.Department.GetAll();

                this.drop_bm.DataSource = dt_bm;
                this.drop_bm.DataTextField = "bm_mc";
                this.drop_bm.DataValueField = "bm_mc";
                this.drop_bm.DataBind();
                this.drop_bm.Items.Insert(0, "-请选择-");
                this.drop_bm.SelectedIndex = 0;
                DataTable dt_zw = Stoke.BLL.Place.GetAll();

                this.drop_zw.DataSource = dt_zw;
                this.drop_zw.DataTextField = "zw_mc";
                this.drop_zw.DataValueField = "zw_mc";
                this.drop_zw.DataBind();
                this.drop_zw.Items.Insert(0, "-请选择-");
                this.drop_zw.SelectedIndex = 0;
                this.Table4.Visible = false;
                if (Request.QueryString["bm_mc"] == null)
                {
                    string sqlstring = "delete from Dsoc_ry_temp";
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstring, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MyDataBind();
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
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.dgRy.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgRy_ItemCommand);
            this.dgRy.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgRy_PageIndexChanged);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion



        private void btnBack_Click(object sender, System.EventArgs e)
        {
            string _ry = SlctMember1.Send[0].ToString().Trim();
            SlctMember1.Clear();
            this.Table4.Visible = false;

            //			Response.Write(_ry.ToString().Trim());  

            string _temp = _ry;
            string _zgbh = "";  //根据姓名反取值
            string _xm = "";
            string _bm = drop_bm.SelectedItem.Text.ToString().Trim();
            string _zw = drop_zw.SelectedItem.Text.ToString().Trim();

            for (int i = 0; i < _temp.Split(',').Length; i++)
            {
                _xm = _temp.Split(',')[i].ToString().Trim();
                //取职工编号

                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sqlStr = "select distinct ry_zgbh from dbo.dsoc_ry where ry_xm = '" + _xm + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                _zgbh = cmd.ExecuteScalar().ToString().Trim();
                conn.Close();

                conn.Open();
                sqlStr = "insert into dbo.Dsoc_ry_temp(ry_zgbh,ry_xm,ry_bm,ry_zw) values ('" + _zgbh + "','" + _xm + "','" + _bm + "','" + _zw + "')";
                SqlCommand cmd3 = new SqlCommand(sqlStr, conn);
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
            MyDataBind();

        }

        public void MyDataBind()
        {
            string sqlstring = "select * from Dsoc_ry_temp";
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlstring, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            this.dgRy.DataSource = dt;
            dgRy.DataBind();
            int count = dgRy.PageSize * dgRy.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            dgRy.DataBind();

            for (int i = 0; i < dgRy.Items.Count; i++)
            {
                if (dgRy.Items[i].Cells[1].Text == "&nbsp;")
                {
                    LinkButton btn = new LinkButton();
                    btn = (LinkButton)dgRy.Items[i].FindControl("lbtnUpdate");
                    btn.Visible = false;
                    LinkButton btn1 = new LinkButton();
                    btn1 = (LinkButton)dgRy.Items[i].FindControl("lbtnDelete");
                    btn1.Visible = false;

                }

            }


        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (this.drop_bm.SelectedIndex == 0 || this.drop_zw.SelectedIndex == 0)
            {
                Response.Write("<script>alert('请先选择部门/项目组和职位！')</script>");
                return;
            }
            else
                this.Table4.Visible = true;
        }


        private void Button2_Click(object sender, System.EventArgs e)
        {
            string sqlStr = "select * from Dsoc_ry_temp";
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                conn.Open();
                string _zgbh = dt.Rows[i][1].ToString().Trim();
                string _xm = dt.Rows[i][2].ToString().Trim();
                string _bm = dt.Rows[i][3].ToString().Trim();
                string _zw = dt.Rows[i][4].ToString().Trim();

                sqlStr = "insert into dbo.Dsoc_ry(ry_zgbh,ry_xm,ry_bm,ry_zw) values ('" + _zgbh + "','" + _xm + "','" + _bm + "','" + _zw + "')";
                cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            conn.Open();
            sqlStr = "delete from  dbo.Dsoc_ry_temp";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MyDataBind();

        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Table4.Visible = false;
        }

        private void dgRy_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Update")
                Response.Redirect("ry_bm_zw.aspx?ReturnPage=2&ry_zgbh=" + e.Item.Cells[1].Text + "&ry_xm=" + e.Item.Cells[2].Text + "&bm_mc=" + this.drop_bm.SelectedItem.Text.Trim());
            else if (e.CommandName == "Delete")
            {
                int ret = Stoke.Components.Staff.DeleteDsocRyTempByID(int.Parse(e.Item.Cells[0].Text));
                if (ret != -1)
                    Response.Write("<script>alert('删除成功！')</script>");
                dgRy.CurrentPageIndex = 0;
                MyDataBind();
            }

        }

        private void dgRy_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgRy.CurrentPageIndex = e.NewPageIndex;
            MyDataBind();
        }

        private void cmdBack_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("department_list.aspx");
        }
    }
}
