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
using Stoke.DAL;

namespace Stoke
{
    public partial class header : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _zgbh = Session["zgbh"].ToString();
            if (!IsPostBack)
            {
                //string connString = @"server=222.27.253.130;database=dsoc;User=sa;Password=jsw;";
                //SqlConnection conn = new SqlConnection(connString);
                //conn.Open();
                //string sql = "select * from dsoc_ry where ry_zgbh = '" + _zgbh + "'";
                //SqlCommand cmd = new SqlCommand(sql, conn);
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{
                //    this.Label1.Text = dr["ry_xm"].ToString();
                //    //blbm.Text = dr["ry_bm"].ToString();
                //}
                //dr.Close();
                //conn.Close();
                //conn.Dispose();

                string cmdText = "SELECT * FROM dsoc_ry WHERE ry_zgbh = '" + _zgbh + "'";
                SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, cmdText);

                if (dr.Read())
                {
                    this.Label1.Text = dr["ry_xm"].ToString();
                    //blbm.Text = dr["ry_bm"].ToString();
                }
                dr.Close();
            }
        }
    }
}
