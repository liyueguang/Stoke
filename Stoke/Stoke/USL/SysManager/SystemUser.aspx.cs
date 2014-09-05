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

namespace Stoke.USL.SysManager
{
    public partial class SystemUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dtrole = SystemUM.GetRolesByLevel();
                this.roleDdl.DataSource = dtrole;
                this.roleDdl.DataTextField = "roleName";
                this.roleDdl.DataValueField = "RoleCode";
                this.roleDdl.DataBind();
                this.roleDdl.Items.Insert(0, new ListItem("--请选择--", "0"));

                this.GridView1.Attributes.Add("SortExpression", "UserNumber");
                this.GridView1.Attributes.Add("SortDirection", "ASC");

                GetUserInfo(0);

                //隐藏按职务查询
                this.deptDdl.Visible = false;
                this.depLbl.Visible = false;
            }
        }

        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        private void GetUserInfo(int tag)
        {
            string RoleCode = "", PositionName = "", UserName = "", CompanyName = "";
            if (this.roleDdl.SelectedIndex > 0)
            {
                RoleCode = this.roleDdl.SelectedValue.ToString();
            }

            //if (this.deptDdl.SelectedValue != "0")
            //{
            //    PositionName = this.deptDdl.SelectedValue.ToString();
            //    flagPosition = 1;
            //}
            if (this.nameTbx.Text != string.Empty)
            {
                UserName = this.nameTbx.Text.Trim().ToString();
            }
           
            DataTable dt = SystemUM.GetUserInfoByNRPC(RoleCode, CompanyName, PositionName, UserName);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            if (dt.Rows.Count <= 0 && tag == 1)
            {
                creatHeader();
            }
            this.PageInfoLbl.Text = "当前第" + (GridView1.PageIndex + 1).ToString() + "页，共有" + GridView1.PageCount.ToString() + "页，共有数据" + dt.Rows.Count + "条";
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            GetUserInfo(1);
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
            GetUserInfo(0);
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
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            if (Session["usernum"].ToString() == this.GridView1.Rows[e.RowIndex].Cells[0].Text.ToString())
            {
                Uti.ShowDialog("对不起，您无权删除自身信息！", "SystemUser.aspx", this.Page);
            }
            else
            {
                if (SystemUM.deleteUserInfo(Convert.ToInt32(id)))
                {
                    Uti.ShowDialog("删除失败，请与系统管理员联系！", "SystemUser.aspx", this.Page);
                }
                else
                    Uti.ShowDialog("删除成功，请进行其他操作！", "SystemUser.aspx", this.Page);
            }
            GetUserInfo(0);
        }

        #region 无记录时显示gridview表头，并增加一行显示“没有记录”
        private void creatHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID");
            dt.Columns.Add("UserNumber");
            dt.Columns.Add("UserName");
            dt.Columns.Add("Sex");
            dt.Columns.Add("CompanyName");
            dt.Columns.Add("PositionName");
            dt.Columns.Add("MobilePhone1");
            dt.Columns.Add("ItemTemplate1");
            dt.Columns.Add("ItemTemplate2");

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
