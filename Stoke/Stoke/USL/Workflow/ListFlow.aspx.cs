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
    public partial class ListFlow : System.Web.UI.Page
    {
        protected int DisplayType = 0;
        protected string _flow_id;
        protected string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            //_zgbh = Session["zgbh"].ToString();
            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");
            DisplayType = Convert.ToInt32(Request["DisplayType"]);


            if (!Page.IsPostBack)
            {
                btnFirst.Text = "最首页";
                btnPrev.Text = "前一页";
                btnNext.Text = "下一页";
                btnLast.Text = "最后页";

                BindGrid();
                JudgeEnable();
                ShowStats();
            }
        }


        /// <summary>
        /// 绑定数据列表控件
        /// </summary>
        public void BindGrid()
        {
            DataTable dt = Flow.GetFlow(DisplayType);
            int count = dt.Rows.Count;
            string _right = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _right = "r" + dt.Rows[i][0].ToString();
                string connString = SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select " + _right + " from dbo.Dsoc_Flow_Right where ry_id = '" + _zgbh + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                {
                    dt.Rows[i].Delete();
                    count--;
                }
                conn.Close();
            }

            DataGrid1.DataSource = dt;
            if (count == 0)
            {
                for (int i = 0; i < 15; i++)
                    dt.Rows.Add(dt.NewRow());
                this.pageDdl.Enabled = false;
            }
            else
            {
                this.pageDdl.Enabled = true;
                if ((count % DataGrid1.PageSize) != 0)
                    for (int i = count % DataGrid1.PageSize; i < DataGrid1.PageSize; i++)
                        dt.Rows.Add(dt.NewRow());
            }
            DataGrid1.DataBind();
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if (DataGrid1.Rows[i].Cells[1].Text == "&nbsp;")
                {
                    LinkButton btn = new LinkButton();
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton1");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton2");
                    btn.Visible = false;
                }
            }

            pageDdl.Items.Clear();
            for (int i = 0; i < DataGrid1.PageCount; i++)
                pageDdl.Items.Add((i + 1).ToString());
        }

        /// <summary>
        /// 判断分页列表中按钮是否可用
        /// </summary>
        public void JudgeEnable()
        {
            if (this.DataGrid1.PageIndex == 0)
            {
                if (this.DataGrid1.PageCount == 1)
                {
                    this.btnFirst.Enabled = false;
                    this.btnPrev.Enabled = false;
                    this.btnLast.Enabled = false;
                    this.btnNext.Enabled = false;
                }
                else
                {
                    this.btnFirst.Enabled = false;
                    this.btnPrev.Enabled = false;
                    this.btnLast.Enabled = true;
                    this.btnNext.Enabled = true;
                }
            }
            else
            {
                if (this.DataGrid1.PageIndex == this.DataGrid1.PageCount - 1)
                {
                    this.btnFirst.Enabled = true;
                    this.btnPrev.Enabled = true;
                    this.btnLast.Enabled = false;
                    this.btnNext.Enabled = false;

                }
                else
                {
                    this.btnFirst.Enabled = true;
                    this.btnPrev.Enabled = true;
                    this.btnLast.Enabled = true;
                    this.btnNext.Enabled = true;
                }
            }
        }


        /// <summary>
        /// 分页列表中按钮对应的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PagerButtonClick(object sender, EventArgs e)
        {
            string arg = ((LinkButton)sender).CommandArgument.ToString();
            switch (arg)
            {
                case "next":
                    DataGrid1.PageIndex += 1; break;
                case "prev":
                    DataGrid1.PageIndex -= 1; break;
                case "last":
                    DataGrid1.PageIndex = (DataGrid1.PageCount - 1); break;
                default:
                    DataGrid1.PageIndex = System.Convert.ToInt32(arg); break;
            }
            BindGrid();
            JudgeEnable();
            ShowStats();
        }

        /// <summary>
        /// 根据当前DataGrid页码设定分页列表中部分控件的数据
        /// </summary>
        private void ShowStats()
        {
            lblCurrentIndex.Text = "第 " + (DataGrid1.PageIndex + 1).ToString() + " 页";
            lblPageCount.Text = "总共 " + DataGrid1.PageCount.ToString() + " 页";
            this.pageDdl.SelectedIndex = this.DataGrid1.PageIndex;
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
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
            this.pageDdl.SelectedIndexChanged += new System.EventHandler(this.pageDdl_SelectedIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        protected void gwgl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFlow.aspx?DisplayType=1&zgbh=" + _zgbh);
        }

        protected void rsgl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFlow.aspx?DisplayType=2&zgbh=" + _zgbh);
        }

        protected void xzgl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFlow.aspx?DisplayType=3&zgbh=" + _zgbh);
        }

        protected void czgl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFlow.aspx?DisplayType=4&zgbh=" + _zgbh);
        }


        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "new")
            {
                _flow_id = e.Item.Cells[0].Text.ToString();
                string _URL = null;
                string connString = SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select * from Dsoc_Flow,Dsoc_Flow_Style where Dsoc_Flow.Style_ID = Dsoc_Flow_Style.Style_ID and Dsoc_Flow.Flow_ID = '" + _flow_id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    _URL = dr["Style_Remark"].ToString();
                dr.Close();
                conn.Close();
                _URL += "?step_id=1&doc_id=0&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
            if (e.CommandName.ToString() == "work_lct")
            {
                _flow_id = e.Item.Cells[0].Text.ToString();
                string _URL = "Work_lct.aspx?flow_id=" + _flow_id + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
        }

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                //e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#95b8ff'");
                //e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
            }
            if (e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#95b8ff'");
                //e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#F5F3FA'");
            }
        }



        protected void licenseLbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFlow.aspx?DisplayType=5&zgbh=" + _zgbh);
        }

        protected void DataGrid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "new")
            {
                _flow_id = e.CommandArgument.ToString();// e.Item.Cells[0].Text.ToString();
                string _URL = null;
                string connString = SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select * from Dsoc_Flow,Dsoc_Flow_Style where Dsoc_Flow.Style_ID = Dsoc_Flow_Style.Style_ID and Dsoc_Flow.Flow_ID = '" + _flow_id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    _URL = dr["Style_Remark"].ToString();
                dr.Close();
                conn.Close();
                _URL += "?step_id=1&doc_id=0&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
            if (e.CommandName.ToString() == "work_lct")
            {
                _flow_id = e.CommandArgument.ToString();//.Item.Cells[0].Text.ToString();
                string _URL = "Work_lct.aspx?flow_id=" + _flow_id + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#95B8FF'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }

        protected void xsqb_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFlow.aspx?zgbh=" + _zgbh);
        }

        protected void pageDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataGrid1.PageIndex = Int32.Parse(this.pageDdl.SelectedItem.ToString()) - 1;
            BindGrid();
            JudgeEnable();
            ShowStats();
        }

    }
}
