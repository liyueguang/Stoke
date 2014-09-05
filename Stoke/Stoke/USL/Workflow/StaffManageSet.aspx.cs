using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Stoke.BLL;
using Stoke.DAL;

namespace Stoke.USL.Workflow
{
    public partial class StaffManageSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                init();
                Bind();
            }
        }

        protected void Bind()
        {
            if (bmList.SelectedIndex != 0)
            {
                DataTable dt = Utility.GetStaffSetByBm(bmList.SelectedValue.Trim());
                for (int i = 0; i < ryList.Items.Count; ++i)
                {
                    for (int j = 0; j < dt.Rows.Count; ++j)
                    {
                        if (ryList.Items[i].Value == dt.Rows[j]["ry_zgbh"].ToString())
                        {
                            ryList.Items[i].Selected = (Convert.ToInt32(dt.Rows[j]["flag"]) == 1 ? true : false);
                            break;
                        }
                    }
                }
            }
        }

        protected void init()
        {
            SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING);
            string sql = "select * from dsoc_bm";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            bmList.DataSource = dr;
            bmList.DataTextField = "bm_mc";
            bmList.DataValueField = "bm_mc";
            bmList.DataBind();
            this.bmList.Items.Insert(0, "--请选择--");
            dr.Close();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ry_zgbh = string.Empty;
            int flag = 0;

            for (int i = 0; i < ryList.Items.Count; ++i)
            {
                ry_zgbh = ryList.Items[i].Value.Trim();
                flag = ryList.Items[i].Selected == true ? 1 : 0;
                Utility.ModifyStaffSet(ry_zgbh, flag);
            }

            Bind();

            Response.Write("<script type=text/javascript>alert('修改成功！')</script>");
        }

        protected void bmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING);
            conn.Open();
            if (this.bmList.SelectedIndex > 0)
            {
                string sql = "select distinct ry_xm,rtrim(ry_zgbh) as ry_zgbh  from dbo.dsoc_ry where rtrim(ry_bm) ='" + bmList.SelectedItem.Text.Trim() + "' order by ry_zgbh";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                ryList.DataSource = dr;
                ryList.DataTextField = "ry_xm";
                ryList.DataValueField = "ry_zgbh";
                ryList.DataBind();
                dr.Close();
            }
            conn.Close();

            Bind();
        }
    }
}
