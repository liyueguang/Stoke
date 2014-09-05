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

namespace Stoke.USL.Workflow
{
    public partial class Work_lct : System.Web.UI.Page
    {
        protected static string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            int flow_id = Convert.ToInt32(Request.QueryString["flow_id"]);
            _zgbh = Request["zgbh"].ToString();

            switch (flow_id)
            {
                case 17:
                    bt.Text = "预算公文";
                    Image1.ImageUrl = "../lct/ysgw.jpg";
                    break;
                case 18:
                    bt.Text = "普通公文";
                    Image1.ImageUrl = "../lct/ptgw.jpg";
                    break;
                case 19:
                    bt.Text = "成本公文";
                    Image1.ImageUrl = "../lct/cbgw.jpg";
                    break;
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
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx");
        }
    }
}
