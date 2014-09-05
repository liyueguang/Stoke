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
    public partial class qj_xj_list_new : System.Web.UI.Page
    {

        public int DisplayType;
        protected string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");
            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                else
                    DisplayType = 0;
            }
            else
                DisplayType = 0;

            //若没有重复销假，则去掉提示属性
            for (int i = 0; i < dbQjspList.Items.Count; i++)
            {
                if (dbQjspList.Items[i].Cells[1].Text != "&nbsp;")
                {
                    int qjsp_id = Convert.ToInt32(dbQjspList.Items[i].Cells[0].Text);
                    int flag = judge_xj(qjsp_id);
                    if (flag == 0)
                    {
                        LinkButton btn1 = new LinkButton();
                        btn1 = (LinkButton)dbQjspList.Items[i].Cells[6].Controls[0];
                        btn1.Attributes.Clear();
                        return;
                    }

                }
            }


            if (!Page.IsPostBack)
            {
                BindGrid();
                //判断是否在rs_flow_xj_judge存在,若存在，则提示是否重复销假
                for (int i = 0; i < dbQjspList.Items.Count; i++)
                {
                    if (dbQjspList.Items[i].Cells[1].Text != "&nbsp;")
                    {
                        int qjsp_id = Convert.ToInt32(dbQjspList.Items[i].Cells[0].Text);
                        int flag = judge_xj(qjsp_id);
                        if (flag > 0)
                        {
                            LinkButton btn1 = new LinkButton();
                            btn1 = (LinkButton)dbQjspList.Items[i].Cells[6].Controls[0];
                            btn1.Attributes.Add("onclick", "return confirm('销假在流程过程中没有结束，确定要重复销假吗？/如果待办中已存在，请在待办中完成!')");
                            return;
                        }

                    }
                }
            }
        }

        private void BindGrid()
        {
            DataTable dt_qj_xj = new DataTable();
            if (DisplayType == 2)
            {
                dt_qj_xj = Stoke.Components.Staff.SelectQjspByZgbhFlagNew(_zgbh, DisplayType);

                this.dbXjspList.DataSource = dt_qj_xj;
                this.dbXjspList.DataBind();
                int count = dbXjspList.PageSize * dbXjspList.PageCount - dt_qj_xj.Rows.Count;
                for (int i = 0; i < count; i++)
                    dt_qj_xj.Rows.Add(dt_qj_xj.NewRow());
                this.dbXjspList.DataBind();

                for (int i = 0; i < dbXjspList.Items.Count; i++)
                {
                    if (dbXjspList.Items[i].Cells[0].Text == "&nbsp;")
                        dbXjspList.Items[i].Cells[6].Controls[0].Visible = false;
                }
            }
            else
            {
                dt_qj_xj = Stoke.Components.Staff.SelectQjspByZgbhFlagNew(_zgbh, DisplayType);

                this.dbQjspList.DataSource = dt_qj_xj;
                this.dbQjspList.DataBind();
                int count = dbQjspList.PageSize * dbQjspList.PageCount - dt_qj_xj.Rows.Count;
                for (int i = 0; i < count; i++)
                    dt_qj_xj.Rows.Add(dt_qj_xj.NewRow());
                this.dbQjspList.DataBind();

                for (int i = 0; i < dbQjspList.Items.Count; i++)
                {
                    if (dbQjspList.Items[i].Cells[0].Text == "&nbsp;")
                        dbQjspList.Items[i].Cells[6].Controls[0].Visible = false;
                }
            }
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        public void dbQjspList_PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            dbQjspList.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        public void dbXjspList_PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            dbXjspList.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
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
            this.lbWxqjd.Click += new System.EventHandler(this.lbWxqjd_Click);
            this.lbYxqjd.Click += new System.EventHandler(this.lbYxqjd_Click);
            this.lbXjd.Click += new System.EventHandler(this.lbXjd_Click);
            this.dbQjspList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbQjspList_ItemCommand);
            this.dbQjspList.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbQjspList_ItemDataBound);
            this.dbXjspList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dbXjspList_ItemCommand);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void lbWxqjd_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("qj_xj_list_new.aspx?DisplayType=0");
        }

        private void lbYxqjd_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("qj_xj_list_new.aspx?DisplayType=1");
        }

        private void lbXjd_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("qj_xj_list_new.aspx?DisplayType=2");
        }

        private void dbQjspList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "xj")
            {
                int qjsp_id = Convert.ToInt32(e.Item.Cells[0].Text);
                //				Session["qjsp_id"]=qjsp_id;
                //				Response.Redirect("../Workflow/ListFlow.aspx");
                Response.Redirect("style_xjsp.aspx?step_id=1&doc_id=0&zgbh=" + _zgbh + "&qjsp_id=" + qjsp_id);
            }
        }

        private int judge_xj(int qjid)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str1 = "select count(id) from rs_flow_xj_judge where qjsp_id= '" + qjid + "'";
            SqlCommand cmd = new SqlCommand(str1, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            string num1 = "";
            if (dr.Read())
            {

                if (dr.GetValue(0).ToString() != "")
                    num1 = dr.GetValue(0).ToString();
            }
            dr.Close();
            conn.Close();
            int num = Convert.ToInt32(num1);
            return num;
        }

        private void dbQjspList_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (DisplayType == 1)
                e.Item.Cells[6].Visible = false;
        }

        private void dbXjspList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "proc")
            {
                string _doc_id = e.Item.Cells[7].Text.ToString();
                string _URL = "../Workflow/Work_Proc.aspx?doc_id=" + _doc_id + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
        }

    }
}
