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
using Stoke.Components;

namespace Stoke.USL.Workflow
{
    public partial class Work_rights : System.Web.UI.Page
    {

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                string sql = "select Flow_ID,Flow_Name from dbo.Dsoc_Flow,dbo.Dsoc_Flow_Class where dbo.Dsoc_Flow.Class_ID = dbo.Dsoc_Flow_Class.Class_ID and Dsoc_Flow_Class.Class_Name = '" + DropDownList1.SelectedItem.Text.ToString() + "' and dbo.Dsoc_Flow.Remark = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DropDownList2.DataSource = dr;
                DropDownList2.DataTextField = "Flow_Name";
                DropDownList2.DataValueField = "Flow_ID";
                DropDownList2.DataBind();
                dr.Close();
                conn.Close();
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
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Button1_Click(object sender, System.EventArgs e)
        {
            obj.Text = SlctMember1.Send[0].ToString();
            if (obj.Text == string.Empty)
                obj.Text = "无";
        }

        private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            string sql = "select Flow_ID,Flow_Name from dbo.Dsoc_Flow,dbo.Dsoc_Flow_Class where dbo.Dsoc_Flow.Class_ID = dbo.Dsoc_Flow_Class.Class_ID and Dsoc_Flow_Class.Class_Name = '" + DropDownList1.SelectedItem.Text.ToString() + "' and dbo.Dsoc_Flow.Remark = 1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DropDownList2.DataSource = dr;
            DropDownList2.DataTextField = "Flow_Name";
            DropDownList2.DataValueField = "Flow_ID";
            DropDownList2.DataBind();
            dr.Close();
            conn.Close();

        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (obj.Text == "无")
                Response.Write("<script> alert('请选择操作对象！') </script>");
            else
            {
                string _obj_zgbh = SlctMember1.Send[1].ToString();
                for (int i = 0; i < _obj_zgbh.Split(',').Length; i++)
                    Right(_obj_zgbh.Split(',')[i].Trim());
                Response.Write("<script> alert('多人权限修改成功！') </script>");
            }
        }

        #region 赋予权限
        protected void Right(string _zgbh)
        {
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            string sql = "select count(*) from dbo.Dsoc_Flow_Right where ry_id = '" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
            {
                conn.Close();
                sql = "update dbo.Dsoc_Flow_Right set r" + DropDownList2.SelectedValue.ToString() + " = " + DropDownList3.SelectedValue.ToString() + " where ry_id = '" + _zgbh.ToString() + "'";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Close();
                sql = "insert into dbo.Dsoc_Flow_Right values('" + _zgbh + "', ";
                for (int i = 1; i < 35; i++)
                {
                    if (DropDownList2.SelectedValue == i.ToString())
                        sql += "1, ";
                    else
                        sql += "0, ";
                }
                sql = sql.Substring(0, sql.Length - 2) + ")";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion
    }
}
