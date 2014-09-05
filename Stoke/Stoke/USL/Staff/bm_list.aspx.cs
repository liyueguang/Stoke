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

namespace Stoke.USL.Staff
{
    public partial class bm_list : System.Web.UI.Page
    {
        protected int DisplayType;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                else
                    DisplayType = 0;
            }
            else
                DisplayType = 0;
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = Stoke.Components.Staff.GetBmXmz2(DisplayType);
            DataGrid1.DataSource = dt;

            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
            int count = DataGrid1.PageSize * DataGrid1.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            this.DataGrid1.DataBind();

            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                if (DataGrid1.Items[i].Cells[0].Text == "&nbsp;")
                {
                    LinkButton btn1 = new LinkButton();
                    btn1 = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton1");
                    btn1.Visible = false;
                    LinkButton btn2 = new LinkButton();
                    btn2 = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton2");
                    btn2.Visible = false;
                    LinkButton btn3 = new LinkButton();
                    btn3 = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton3");
                    btn3.Visible = false;
                }
            }
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
            this.lbBm.Click += new System.EventHandler(this.lbBm_Click);
            this.lbXmz.Click += new System.EventHandler(this.lbXmz_Click);
            this.btn_ysc.Click += new System.EventHandler(this.btn_ysc_Click);
            this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
            this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Session["bm_lx"] = "new";
            Response.Redirect("Depart_Manage.aspx");
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "delete")//撤销部门
            {
                int _bm_bh = Convert.ToInt32(e.Item.Cells[0].Text);
                DataTable dt_ry = Stoke.Components.Staff.GetRyZgbhByBmBh(_bm_bh);
                if (dt_ry != null)
                {
                    if (dt_ry.Rows.Count != 0)
                    {
                        Response.Write("<script>alert('请先删除此部门对应人员！')</script>");
                        return;
                    }
                    else
                    {
                        int ret = Stoke.Components.Staff.DeleteBmByBh(_bm_bh);
                        if (ret != -1)
                        {
                            Stoke.Components.Staff.DeleteOrganizeByBm(e.Item.Cells[2].Text.Trim());
                            Response.Write("<script>alert('删除成功！')</script>");
                        }
                        BindGrid();
                    }
                }
            }
            else if (e.CommandName.ToString() == "update")
            {
                int _bm_bh = Convert.ToInt32(e.Item.Cells[0].Text);
                Session["bm_lx"] = "update";
                Session["bm_bh"] = _bm_bh;
                Response.Redirect("Depart_Manage.aspx");
            }
            else if (e.CommandName.ToString() == "sc")//删除部门
            {
                int _bm_bh = Convert.ToInt32(e.Item.Cells[0].Text);
                DataTable dt_ry = Stoke.Components.Staff.GetRyZgbhByBmBh(_bm_bh);
                if (dt_ry != null)
                {
                    if (dt_ry.Rows.Count != 0)
                    {
                        Response.Write("<script>alert('请先删除此部门对应人员！')</script>");
                        return;
                    }
                    else
                    {
                        int ret = Stoke.Components.Staff.ScBmByBh(_bm_bh);
                        if (ret != -1)
                        {
                            Stoke.Components.Staff.DeleteOrganizeByBm(e.Item.Cells[2].Text.Trim());
                            Response.Write("<script>alert('删除成功！')</script>");
                        }
                        BindGrid();
                    }
                }
            }
        }

        private void lbBm_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("bm_list.aspx?DisplayType=0");
        }

        private void lbXmz_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("bm_list.aspx?DisplayType=1");
        }

        private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void btn_ysc_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("bm_sc_list.aspx");
        }

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btn = (LinkButton)e.Item.FindControl("LinkButton3");
                btn.Attributes.Add("onclick", "javascript:return window.confirm('如果撤销部门,请点击撤销!确定删除?');");
            }
        }
    }
}
