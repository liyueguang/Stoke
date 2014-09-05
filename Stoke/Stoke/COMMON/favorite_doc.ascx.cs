namespace Stoke.COMMON
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient;
    using Stoke.BLL;
    using Stoke.DAL;
    using Stoke.COMMON;
    using Stoke.Components;

    /// <summary>
    ///		favorite_doc 的摘要说明。
    /// </summary>
    public class favorite_doc : System.Web.UI.UserControl
    {
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.CheckBoxList folderListCbl;
        private string zgbh;//登录员工职工编号

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            //从Session中获得职工编号
            if (!Page.IsPostBack)
            {
                if (Session["zgbh"] != null)
                    zgbh = Session["zgbh"].ToString();
                else
                    Response.Redirect("USL/error.aspx");
                //绑定收藏文件夹列表
                string cmdText = "select zgbh,FolderName,ContainRybh from dsoc_ry_favorites where zgbh='" + zgbh + "' and type=1 order by CreatedTime";
                DataTable favoritesResult = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.Text, cmdText);
                this.folderListCbl.DataSource = favoritesResult;
                this.folderListCbl.DataTextField = "FolderName";
                this.folderListCbl.DataValueField = "FolderName";
                this.folderListCbl.DataBind();
                if (favoritesResult.Rows.Count == 0)
                {
                    this.Label3.Visible = true;
                    this.Label3.Text = "不存在收藏夹名称,\r\n请到文档收藏夹管理页面进行添加！";
                }
                else
                    this.Label3.Visible = false;
            }
        }

        /// <summary>
        /// 获得选择的文件夹名列表
        /// </summary>
        public string FolderList
        {
            get
            {
                string folderList = string.Empty;
                foreach (ListItem li in this.folderListCbl.Items)
                    if (li.Selected == true)
                        folderList += li.Text.ToString().Trim() + ";";
                return folderList;
            }
            set
            {
                string folderList = string.Empty;
                folderList = value;
                string[] list = folderList.Split(';');
                foreach (ListItem li in this.folderListCbl.Items)
                    for (int i = 0; i < list.Length; i++)
                        if (li.Text == list[i].Trim())
                            li.Selected = true;
            }
        }
    }
}
