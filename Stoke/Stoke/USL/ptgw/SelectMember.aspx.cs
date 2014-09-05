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

namespace Stoke.USL.gwgl
{
    public partial class SelectMember : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (!Page.IsPostBack)
            {
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select * from dsoc_bm order by bm_bh";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                listDept.DataSource = dr;
                listDept.DataTextField = "bm_mc";
                listDept.DataValueField = "bm_bh";
                listDept.DataBind();
                dr.Close();
                conn.Close();
                conn.Dispose();
                sql = "select * from dsoc_zw";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                listZw.DataSource = dr;
                listZw.DataTextField = "zw_mc";
                listZw.DataValueField = "zw_mc";
                listZw.DataBind();
                dr.Close();
                conn.Close();
                conn.Dispose();
                listDept.Items.Insert(0, "-��ѡ��-");
                listZw.Items.Insert(0, "-��ѡ��-");
            }
        }

        protected void Done()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select distinct * from dsoc_ry where ry_bm = '" + listDept.SelectedItem.Text.ToString().Trim() + "' and ry_zw = '" + listZw.SelectedItem.Text.ToString().Trim() + "'order by ry_zgbh asc";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            listAccount.DataSource = dr;
            listAccount.DataTextField = "ry_xm";
            listAccount.DataValueField = "ry_zgbh";
            listAccount.DataBind();
            dr.Close();
            conn.Close();
            conn.Dispose();

        }

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.listDept.SelectedIndexChanged += new System.EventHandler(this.listDept_SelectedIndexChanged);
            this.listZw.SelectedIndexChanged += new System.EventHandler(this.listZw_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        public void listDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Done();
        }

        private void listZw_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Done();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Response.Write("<script>window.opener.location.reload();</script>");
            Response.Write("<script>window.close();</script>");
        }
    }
}
