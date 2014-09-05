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

namespace Stoke.USL.Staff
{
    public partial class department_list : System.Web.UI.Page
    {
        public int DisplayType;
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

        private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
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
            this.lbBm.Click += new System.EventHandler(this.lbBm_Click);
            this.lbXmz.Click += new System.EventHandler(this.lbXmz_Click);
            this.btn_add_zw.Click += new System.EventHandler(this.btn_add_zw_Click);
            this.btn_add_ry.Click += new System.EventHandler(this.btn_add_ry_Click);
            this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
            this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "delete")
            {
                Response.Redirect("scxmz.aspx?bm_bh=" + e.Item.Cells[0].Text + "&bm_mc=" + e.Item.Cells[2].Text);
                //				int _bm_bh = Convert.ToInt32(e.Item.Cells[0].Text);
                //				Department.DeleteBm(_bm_bh);
                //				int lastEditedPage;
                //				lastEditedPage=DataGrid1.CurrentPageIndex;
                //				if((DataGrid1.PageCount-DataGrid1.CurrentPageIndex)==1&&DataGrid1.Items.Count==1)
                //				{ 
                //					if(DataGrid1.PageCount>1)
                //						lastEditedPage--;
                //					else
                //						lastEditedPage=0;
                //				}
                //				DataGrid1.CurrentPageIndex=lastEditedPage;
                //				DataTable dt = Stoke.Components.Staff.GetBmXmz(DisplayType);
                //				DataGrid1.DataSource = dt;
                //				if(dt.Rows.Count <= DataGrid1.PageSize)
                //					for(int i= dt.Rows.Count;i<DataGrid1.PageSize;i++)
                //						dt.Rows.Add(dt.NewRow());
                //				else if(DataGrid1.PageCount>1)
                //				{
                //					int temp = DataGrid1.PageSize*DataGrid1.PageCount - dt.Rows.Count;
                //					for(int i=0;i<temp;i++)
                //						dt.Rows.Add(dt.NewRow());
                //				}
                //				DataGrid1.DataBind();
                //				for(int i=0;i<DataGrid1.Items.Count;i++)
                //				{
                //					if(DataGrid1.Items[i].Cells[0].Text == "&nbsp;")
                //					{
                //						LinkButton btn1 = new LinkButton();
                //						btn1 = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton1");
                //						btn1.Visible = false;
                //						LinkButton btn2 = new LinkButton();
                //						btn2 = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton2");
                //						btn2.Visible = false;
                //					}
                //				}
            }

            if (e.CommandName.ToString() == "update")
            {
                int _bm_bh = Convert.ToInt32(e.Item.Cells[0].Text);
                Session["bm_lx"] = "update";
                Session["bm_bh"] = _bm_bh;
                Response.Redirect("Depart_Manage.aspx");
            }
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Session["bm_lx"] = "new";
            Response.Redirect("Depart_Manage.aspx");
        }

        private void lbBm_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("department_list.aspx?DisplayType=0");
        }

        private void lbXmz_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("department_list.aspx?DisplayType=1");
        }

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (DisplayType == 0)
                    e.Item.Cells[5].Text = "部门缩写";
                else if (DisplayType == 1)
                    e.Item.Cells[5].Text = "开工命令号";
            }
        }

        private void btn_add_zw_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("org/editOrg.asp");
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            Session["bm_lx"] = "new";
            Response.Redirect("Depart_Manage.aspx");
        }

        private void btn_add_ry_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("xzxmz.aspx");
        }
    }
}
