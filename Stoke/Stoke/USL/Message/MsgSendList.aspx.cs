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

namespace Stoke.USL.Message
{
    public partial class MsgSendList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetModuleInfo();
        }

        /// <summary>
        /// 获得模块信息列表
        /// </summary>
        private void GetModuleInfo()
        {
            string msgtitle = fasongren.Text.Trim();
            string message = descTbx.Text.Trim();

            DataTable dt = SystemUM.GetMessageByNum(Session["usernum"].ToString(),msgtitle,message,0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = System.Text.RegularExpressions.Regex.Replace(dt.Rows[i]["message"].ToString(), "<[^>]*>", "");
                str = str.Replace("\r\n", "");
                str = str.Replace("&nbsp;", "");
                str = str.Replace("&#39;", " ");
                if (str.Length > 45)
                    str = str.Substring(0, 45) + "...";
                dt.Rows[i]["message"] = str;

                dt.Rows[i]["MsgReceive"] = (SystemUM.GetMessageUserList(dt.Rows[i]["MsgReceive"].ToString())).Rows[0]["UserList"].ToString();
            }

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            if (dt.Rows.Count <= 0)
            {
                creatHeader();
            }
            this.PageInfoLbl.Text = "当前第" + (GridView1.PageIndex + 1).ToString() + "页，共" + GridView1.PageCount.ToString() + "页，共有数据" + dt.Rows.Count + "条";
        }

        protected void sel_Button_Click(object sender, EventArgs e)
        {
            TextBox tb = this.GridView1.BottomPagerRow.FindControl("page_TextBox") as TextBox;
            this.GridView1.PageIndex = Convert.ToInt32(tb.Text.Trim()) - 1;
            GetModuleInfo();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            GetModuleInfo();
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression.ToString();
            string sortDirection = "ASC";
            if (sortExpression == this.GridView1.Attributes["SortExpression"])
            {
                //获得下一次的排序状态
                sortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
            }
            this.GridView1.Attributes["SortExpression"] = sortExpression;
            this.GridView1.Attributes["SortDirection"] = sortDirection;
            GetModuleInfo();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            GetModuleInfo();
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

        #region 无记录时显示gridview表头，并增加一行显示“没有记录”

        private void creatHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MsgType");
            dt.Columns.Add("MsgReceive");
            dt.Columns.Add("MsgTitle");
            dt.Columns.Add("Message");
            dt.Columns.Add("SendDate");
            dt.Columns.Add("ID");
            dt.Columns.Add("ItemTemplate");

            dt.Rows.Add(dt.NewRow());
            GridView1.DataSourceID = "";//如果之前绑定的是SqlDataSource控件,这句必须写上 
            GridView1.DataSource = dt;
            GridView1.DataBind();
            int columnCount = dt.Columns.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
            GridView1.Rows[0].Cells[0].Text = "没有记录显示";
            GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
        }
        #endregion
    }
}
