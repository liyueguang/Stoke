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
using Stoke.Components;

namespace Stoke.USL.ptgw
{
    public partial class SelectReceiver : System.Web.UI.Page
    {
        public string ClassID, DispType;

        private void Page_Load(object sender, System.EventArgs e)
        {
            ClassID = Request.QueryString["ClassID"].ToString();
            DispType = Request.QueryString["type"].ToString();
            if (!Page.IsPostBack)
            {
                PopulateData();
            }
        }

        #region 初始化下拉列表框
        /// <summary>
        /// 对数据进行初始化
        /// </summary>
        private void PopulateData()
        {
            //Stoke.Components.Staff staff = new Stoke.Components.Staff();
            //listAccount.Items.Clear();
            //if (DispType == "1")
            //    listAccount.DataSource = staff.GetStaffInTeam(Int32.Parse(ClassID));
            //else
            //    listAccount.DataSource = staff.GetAllStaffs();
            //listAccount.DataTextField = "RealName";
            //listAccount.DataValueField = "Staff_Name";
            //listAccount.DataBind();

            //listDept.DataSource = staff.GetPositionList(1);
            //listDept.DataTextField = "Position_Name";
            //listDept.DataValueField = "Position_ID";
            //listDept.DataBind();
            //listDept.Items.Insert(0, new ListItem("公司所有部门", "0"));
            //listDept.SelectedIndex = 0;
            //listDept.Attributes["onclick"] = "SaveValue()";
            //staff = null;
        }
        #endregion

        #region 下拉列表事件
        public void DeptListChange(object sender, System.EventArgs e)
        {
            //Staff staff = new Staff();
            //if (listDept.SelectedItem.Value == "0")
            //    listAccount.DataSource = staff.GetStaffInTeam(Int32.Parse(ClassID));
            //else
            //    listAccount.DataSource = staff.GetStaffByPosition(Int32.Parse(listDept.SelectedItem.Value));
            //listAccount.DataTextField = "RealName";
            //listAccount.DataValueField = "Staff_Name";
            //listAccount.DataBind();

            //staff = null;
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
