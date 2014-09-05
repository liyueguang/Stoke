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
            // �ڴ˴������û������Գ�ʼ��ҳ��
            //_zgbh = Session["zgbh"].ToString();
            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");
            DisplayType = Convert.ToInt32(Request["DisplayType"]);


            if (!Page.IsPostBack)
            {
                btnFirst.Text = "����ҳ";
                btnPrev.Text = "ǰһҳ";
                btnNext.Text = "��һҳ";
                btnLast.Text = "���ҳ";

                BindGrid();
                JudgeEnable();
                ShowStats();
            }
        }


        /// <summary>
        /// �������б�ؼ�
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
        /// �жϷ�ҳ�б��а�ť�Ƿ����
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
        /// ��ҳ�б��а�ť��Ӧ���¼�
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
        /// ���ݵ�ǰDataGridҳ���趨��ҳ�б��в��ֿؼ�������
        /// </summary>
        private void ShowStats()
        {
            lblCurrentIndex.Text = "�� " + (DataGrid1.PageIndex + 1).ToString() + " ҳ";
            lblPageCount.Text = "�ܹ� " + DataGrid1.PageCount.ToString() + " ҳ";
            this.pageDdl.SelectedIndex = this.DataGrid1.PageIndex;
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
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
