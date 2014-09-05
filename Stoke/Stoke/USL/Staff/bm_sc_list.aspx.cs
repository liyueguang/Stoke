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
    public partial class bm_sc_list : System.Web.UI.Page
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
            this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindGrid()
        {
            DataTable dt = Stoke.Components.Staff.GetBmXmzSc(DisplayType);
            DataGrid1.DataSource = dt;

            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
            int count = DataGrid1.PageSize * DataGrid1.PageCount - dt.Rows.Count;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            this.DataGrid1.DataBind();
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        private void lbBm_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("bm_sc_list.aspx?DisplayType=0");
        }

        private void lbXmz_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("bm_sc_list.aspx?DisplayType=1");
        }

        private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("bm_list.aspx");
        }
    }
}
