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
using Stoke.BLL;
using Stoke.DAL;
using Stoke.COMMON;

namespace Stoke.USL.Workflow
{
    public partial class Work_right : System.Web.UI.Page
    {
        protected string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _zgbh = Session["zgbh"].ToString();
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                string sql = "select * from dsoc_bm";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DropDownList1.DataSource = dr;
                DropDownList1.DataTextField = "bm_mc";
                DropDownList1.DataValueField = "bm_mc";
                DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, "--请选择--");
                this.DropDownList2.Items.Insert(0, "--请选择--");
                dr.Close();
                conn.Close();
                //  string _flag="true";
                sql = "select Flow_ID from dbo.Dsoc_Flow where Remark = 1";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //				DataSet ds = new DataSet();
                //				ds.Clear();
                //				adapter.Fill(ds, "dt");
                //				DataTable dt = ds.Tables["dt"];
                conn.Close();
                string _right = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _right = "CheckBox" + dt.Rows[i][0].ToString();
                    //					this.Label1.Text=dt.Rows[i][0].ToString().Trim();
                    ((CheckBox)this.Page.FindControl(_right)).Enabled = true;
                    //					((CheckBox)this.FindControl("CheckBox"+dt.Rows[i][0].ToString().Trim())).Checked = true;


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
            this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.CheckBoxGW.CheckedChanged += new System.EventHandler(this.CheckBoxGW_CheckedChanged);
            this.CheckBoxRS.CheckedChanged += new System.EventHandler(this.CheckBoxRS_CheckedChanged);
            this.CheckBoxXZ.CheckedChanged += new System.EventHandler(this.CheckBoxXZ_CheckedChanged);
            this.CheckBoxCW.CheckedChanged += new System.EventHandler(this.CheckBoxCW_CheckedChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void CheckBoxGW_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckBoxGW.Checked == true)
            {
                string _cb = "CheckBox";
                for (int i = 1; i < 4; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = true;
                }
            }
            else
            {
                string _cb = "CheckBox";
                for (int i = 1; i < 4; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = false;
                }
            }
        }

        private void CheckBoxRS_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckBoxRS.Checked == true)
            {
                string _cb = "CheckBox";
                for (int i = 4; i < 13; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = true;
                }
                if (CheckBox37.Enabled == true)
                    CheckBox37.Checked = true;
                if (CheckBox35.Enabled == true)
                    CheckBox35.Checked = true;
                if (CheckBox36.Enabled == true)
                    CheckBox36.Checked = true;
                if (CheckBox38.Enabled == true)
                    CheckBox38.Checked = true;
                if (CheckBox39.Enabled == true)
                    CheckBox39.Checked = true;
                if (CheckBox40.Enabled == true)
                    CheckBox40.Checked = true;
                if (CheckBox43.Enabled == true)
                    CheckBox43.Checked = true;
                if (CheckBox44.Enabled == true)
                    CheckBox44.Checked = true;
            }
            else
            {
                string _cb = "CheckBox";
                for (int i = 4; i < 13; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = false;
                }
                if (CheckBox37.Enabled == true)
                    CheckBox37.Checked = false;
                if (CheckBox35.Enabled == true)
                    CheckBox35.Checked = false;
                if (CheckBox36.Enabled == true)
                    CheckBox36.Checked = false;
                if (CheckBox38.Enabled == true)
                    CheckBox38.Checked = false;
                if (CheckBox39.Enabled == true)
                    CheckBox39.Checked = false;
                if (CheckBox40.Enabled == true)
                    CheckBox40.Checked = false;
                if (CheckBox43.Enabled == true)
                    CheckBox43.Checked = false;
                if (CheckBox44.Enabled == true)
                    CheckBox44.Checked = false;
            }
        }

        private void CheckBoxXZ_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckBoxXZ.Checked == true)
            {
                string _cb = "CheckBox";
                for (int i = 13; i < 31; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = true;
                }
            }
            else
            {
                string _cb = "CheckBox";
                for (int i = 13; i < 31; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = false;
                }
            }

        }

        private void CheckBoxCW_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckBoxCW.Checked == true)
            {
                string _cb = "CheckBox";
                for (int i = 32; i < 35; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = true;
                }
                if (CheckBox41.Enabled == true)
                    CheckBox41.Checked = true;
                if (CheckBox42.Enabled == true)
                    CheckBox42.Checked = true;
                if (CheckBox45.Enabled == true)
                    CheckBox45.Checked = true;
                if (CheckBox48.Enabled == true)
                    CheckBox48.Checked = true;
                if (CheckBox49.Enabled == true)
                    CheckBox49.Checked = true;
            }
            else
            {
                string _cb = "CheckBox";
                for (int i = 32; i < 35; i++)
                {
                    if (((CheckBox)this.Page.FindControl(_cb + i.ToString())).Enabled == true)
                        ((CheckBox)this.Page.FindControl(_cb + i.ToString())).Checked = false;
                }
                if (CheckBox41.Enabled == true)
                    CheckBox41.Checked = false;
                if (CheckBox42.Enabled == true)
                    CheckBox42.Checked = false;
                if (CheckBox45.Enabled == true)
                    CheckBox45.Checked = false;
                if (CheckBox48.Enabled == true)
                    CheckBox48.Checked = false;
                if (CheckBox49.Enabled == true)
                    CheckBox49.Checked = false;
            }
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (this.DropDownList2.SelectedIndex == 0)
            {
                Response.Write("<script>alert('请选择具体的操作对象！')</script>");
                return;
            }
            lbl_name.Text = DropDownList2.SelectedItem.Text.ToString();
            lbl_zgbh.Text = DropDownList2.SelectedItem.Value.ToString();
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            string sql = "select * from dbo.Dsoc_Flow_Right where ry_id = '" + lbl_zgbh.Text.ToString().Trim() + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                for (int i = 1; i < 51; i++)
                {
                    ((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked = false;
                    if (Convert.ToInt32(dr["r" + i.ToString()].ToString().Trim()) == 1)
                        //					string ce=dr["r"+i.ToString()].ToString().Trim();

                        ((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked = true;
                }
            }
            else
            {
                for (int i = 1; i < 51; i++)
                    ((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked = false;
            }
            dr.Close();
            conn.Close();
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (lbl_zgbh.Text == string.Empty)
                Response.Write("<script> alert('请选择操作对象！') </script>");
            else
            {
                SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                string sql = "select count(*) from dbo.Dsoc_Flow_Right where ry_id = '" + lbl_zgbh.Text.ToString().Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                {
                    conn.Close();
                    sql = "update dbo.Dsoc_Flow_Right set  ";
                    for (int i = 1; i < 51; i++)
                    {
                        if (((CheckBox)this.Page.FindControl("CheckBox" + i.ToString())).Checked == true)
                            sql += "r" + i.ToString() + "=1,";
                        else
                            sql += "r" + i.ToString() + "=0,";
                    }
                    sql = sql.Substring(0, sql.Length - 1) + "  where ry_id = '" + lbl_zgbh.Text.ToString().Trim() + "'";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script> alert('人员权限修改成功！') </script>");
                }
                else
                {
                    conn.Close();
                    sql = "insert into dbo.Dsoc_Flow_Right values('" + lbl_zgbh.Text.ToString().Trim() + "', ";
                    for (int i = 1; i < 51; i++)
                    {
                        if (((CheckBox)this.Page.FindControl("CheckBox" + i.ToString())).Checked == true)
                            sql += "1,";
                        else
                            sql += "0,";
                    }
                    sql = sql.Substring(0, sql.Length - 1) + ")";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script> alert('新人员权限修改成功！') </script>");
                }

            }
            for (int i = 1; i < 51; i++)
                ((CheckBox)this.FindControl("CheckBox" + i.ToString())).Checked = false;
            this.CheckBoxCW.Checked = false;
            this.CheckBoxGW.Checked = false;
            this.CheckBoxRS.Checked = false;
        }

        private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.DropDownList2.Items.Clear();
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            string sql = "select distinct ry_xm,ry_zgbh from dbo.dsoc_ry where ry_bm = '" + DropDownList1.SelectedItem.Text.ToString() + "' order by ry_zgbh";
            SqlDataAdapter dr = new SqlDataAdapter(sql, conn);
            conn.Open();
            DataSet ds = new DataSet();
            dr.Fill(ds, "result");
            DropDownList2.DataSource = ds.Tables["result"].DefaultView;
            DropDownList2.DataTextField = "ry_xm";
            DropDownList2.DataValueField = "ry_zgbh";
            DropDownList2.DataBind();
            this.DropDownList2.Items.Insert(0, "--请选择--");
            conn.Close();
            conn.Dispose();
            dr.Dispose();
        }

        private void CheckboxHT_CheckedChanged(object sender, System.EventArgs e)
        {
            
        }
    }
}
