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
using Stoke.BLL;

namespace Stoke.USL.Disclosure
{
    public partial class DocLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetRoleInfo();
            }
        }

        /// <summary>
        /// ���ģ���б�
        /// </summary>
        private void GetRoleInfo()
        {
            string DocName = "", DocDesc = "";

            if (this.DocName.Text.Trim() != string.Empty)
            {
                DocName = this.DocName.Text.Trim();
            }
            if (this.DocDesc.Text.Trim().ToString() != string.Empty)
            {
                DocDesc = this.DocDesc.Text.Trim().ToString();
            }

            DataTable dt = new DataTable();
            dt = SystemUM.GetDocInfo(DocName, DocDesc, "", "0");
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

            if (dt.Rows.Count <= 0)
            {
                creatHeader();
            }
            this.PageInfoLbl.Text = "��ǰ��" + (GridView1.PageIndex + 1).ToString() + "ҳ������" + GridView1.PageCount.ToString() + "ҳ����������" + dt.Rows.Count + "��";
        }

        protected void sel_Button_Click(object sender, EventArgs e)
        {
            TextBox tb = this.GridView1.BottomPagerRow.FindControl("page_TextBox") as TextBox;
            this.GridView1.PageIndex = Convert.ToInt32(tb.Text.Trim()) - 1;
            GetRoleInfo();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            GetRoleInfo();
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression.ToString();
            string sortDirection = "ASC";
            if (sortExpression == this.GridView1.Attributes["SortExpression"])
            {
                //�����һ�ε�����״̬
                sortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
            }
            this.GridView1.Attributes["SortExpression"] = sortExpression;
            this.GridView1.Attributes["SortDirection"] = sortDirection;
            GetRoleInfo();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            GetRoleInfo();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#95B8FF'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();

            //ϵͳ����Ա����ɾ��xl

            if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010000") >= 0)
            {
                DataTable ddd = SystemUM.GetDocInfo("", "", id, "2");
                if (ddd.Rows[0][0].ToString() == "0")
                {
                    Uti.ShowDialog("ɾ��ʧ�ܣ�����ϵͳ����Ա��ϵ��", "DocLoad.aspx", this.Page);
                }
                else
                    Uti.ShowDialog("ɾ���ɹ������������������", "DocLoad.aspx", this.Page);
            }
            else
            {
                Uti.ShowDialog("�Բ�������Ȩɾ������ģ�壡", "DocLoad.aspx", this.Page);
            }
            GetRoleInfo();
        }

        #region �޼�¼ʱ��ʾgridview��ͷ��������һ����ʾ��û�м�¼��

        private void creatHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("DocName");
            dt.Columns.Add("DocDesc");
            dt.Columns.Add("DocDate");
            dt.Columns.Add("DocRealName");
            dt.Columns.Add("ItemTemplate1");
            dt.Columns.Add("ItemTemplate2");

            dt.Rows.Add(dt.NewRow());
            GridView1.DataSourceID = "";//���֮ǰ�󶨵���SqlDataSource�ؼ�,������д�� 
            GridView1.DataSource = dt;
            GridView1.DataBind();
            int columnCount = dt.Columns.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
            GridView1.Rows[0].Cells[0].Text = "û�м�¼��ʾ";
            GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
        }
        #endregion
    }
}
