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
    public partial class SystemRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetRoleInfo(0);
            }
        }

        /// <summary>
        /// ��ý�ɫ��Ϣ�б�
        /// </summary>
        private void GetRoleInfo(int tag)
        {
            string RoleCode = "", RoleDescription = "";
            int flagD = 0;
            if (this.role_tbtext.Text.Trim() != string.Empty)
            {
                RoleCode = this.role_tbtext.Text.Trim();
            }
            if (this.descTbx.Text.Trim().ToString() != string.Empty)
            {
                flagD = 1;
                RoleDescription = this.descTbx.Text.Trim().ToString();
            }

            DataTable dt = new DataTable();
            dt = SystemUM.GetRoleInfoByRoleND(RoleCode, RoleDescription, flagD);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

            if (dt.Rows.Count <= 0 && tag == 1)
            {
                creatHeader();
            }
            this.PageInfoLbl.Text = "��ǰ��" + (GridView1.PageIndex + 1).ToString() + "ҳ������" + GridView1.PageCount.ToString() + "ҳ����������" + dt.Rows.Count + "��";
        }

        protected void sel_Button_Click(object sender, EventArgs e)
        {
            TextBox tb = this.GridView1.BottomPagerRow.FindControl("page_TextBox") as TextBox;
            this.GridView1.PageIndex = Convert.ToInt32(tb.Text.Trim()) - 1;
            GetRoleInfo(0);
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            GetRoleInfo(1);
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
            GetRoleInfo(0);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            GetRoleInfo(0);
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
            DataTable dt = SystemUM.GetRolesPermissitionByID(Convert.ToInt32(id));
            string RoleName = dt.Rows[0]["RoleName"].ToString();
            if (RoleName == "ϵͳ����Ա")
            {
                Uti.ShowDialog("�Բ�������Ȩɾ��ϵͳ����Ա��ɫ��", "SystemRole.aspx", this.Page);
            }
            else
            {
                if (SystemUM.deleteRoleInfoByID(Convert.ToInt32(id)))
                {
                    Uti.ShowDialog("ɾ��ʧ�ܣ�����ϵͳ����Ա��ϵ��", "SystemRole.aspx", this.Page);
                }
                else
                    Uti.ShowDialog("ɾ���ɹ������������������", "SystemRole.aspx", this.Page);
            }
            GetRoleInfo(0);
        }

        #region �޼�¼ʱ��ʾgridview��ͷ��������һ����ʾ��û�м�¼��

        private void creatHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RoleID");
            dt.Columns.Add("RoleCode");
            dt.Columns.Add("RoleLevel");
            dt.Columns.Add("RoleName");
            dt.Columns.Add("RoleDescription");
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
