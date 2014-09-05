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

namespace Stoke.USL.zhxxgl
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetUserInfo(0);
            }
        }

        /// <summary>
        /// ����û���Ϣ�б�
        /// </summary>
        private void GetUserInfo(int tag)
        {
            string username = "", phonenumber = "";

            if (this.nameTbx.Text != string.Empty)
            {
                username = this.nameTbx.Text.Trim().ToString();
            }

            if (this.phoneTbx.Text != string.Empty)
            {
                phonenumber = this.phoneTbx.Text.Trim().ToString();
            }

            DataTable dt = Utility.SelectContact(username, phonenumber);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            if (dt.Rows.Count <= 0 && tag == 1)
            {
                creatHeader();
            }
            this.PageInfoLbl.Text = "��ǰ��" + (GridView1.PageIndex + 1).ToString() + "ҳ������" + GridView1.PageCount.ToString() + "ҳ����������" + dt.Rows.Count + "��";
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            GetUserInfo(1);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            GetUserInfo(0);
        }

        protected void sel_Button_Click(object sender, EventArgs e)
        {
            TextBox tb = this.GridView1.BottomPagerRow.FindControl("page_TextBox") as TextBox;
            this.GridView1.PageIndex = Convert.ToInt32(tb.Text.Trim()) - 1;
            GetUserInfo(0);
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


        #region �޼�¼ʱ��ʾgridview��ͷ��������һ����ʾ��û�м�¼��
        private void creatHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("usernumber");
            dt.Columns.Add("username");
            dt.Columns.Add("sex");
            dt.Columns.Add("companyname");
            dt.Columns.Add("positionname");
            dt.Columns.Add("email");
            dt.Columns.Add("fixedphone");
            dt.Columns.Add("mobilephone1");
            dt.Columns.Add("mobilephone2");

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
