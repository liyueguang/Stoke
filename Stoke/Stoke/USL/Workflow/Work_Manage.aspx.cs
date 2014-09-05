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
using Stoke.DAL;
using Stoke.COMMON;
using Stoke.Components;

namespace Stoke.USL.Workflow
{
    public partial class Work_Manage : System.Web.UI.Page
    {
        protected string _flow_id;
        protected string _zgbh;
        protected int DisplayType = 0;
        protected string _doc_id;
        protected Stoke.COMMON.favorite_doc Favorite_doc1;
        protected string _step_id;
        protected int docID;//所选文档编号

        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            //获得员工编号
            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");
            //获得文档号
            if (Session["docID"] != null)
                docID = Int32.Parse(Session["docID"].ToString().Split(';')[0]);
            else
                docID = 0;
            DisplayType = Convert.ToInt32(Request["DisplayType"]);
            if (!IsPostBack)
            {
                //if (this.DataGrid1.Attributes["SortExpression"] == null) //这里DataGrid1为datagrid   ID
                //{
                //    this.DataGrid1.Attributes["SortExpression"] = "doc_added_date";  //这里给datagrid增加一个排序属性，且默认排序表达式为doc_added_date;
                //    DataGrid1.Attributes["SortDirection"] = "DESC"; //这里给datagrid增加一个排序方向属性,且默认为升序排列;
                //}

                this.Table4.Visible = false;
                fieldset1.Visible = false;
                DataGrid1.Visible = true;

                BindDdl();

                //分页处理
                btnFirst.Text = "最首页";
                btnPrev.Text = "前一页";
                btnNext.Text = "下一页";
                btnLast.Text = "最后页";

                BindGrid(); //绑定函数,下面介绍
                JudgeEnable();
                ShowStats();

            }
        }

        protected void BindDdl()
        {
            SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING);
            string sql = "select * from dsoc_bm";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            bmDdl.DataSource = dr;
            bmDdl.DataTextField = "bm_mc";
            bmDdl.DataValueField = "bm_mc";
            bmDdl.DataBind();
            this.bmDdl.Items.Insert(0, "--请选择--");
            dr.Close();
            conn.Close();

            DataTable dt = Stoke.BLL.Utility.GetFlowClass();
            this.classDdl.DataSource = dt;
            this.classDdl.DataTextField = "class_name";
            this.classDdl.DataValueField = "class_id";
            this.classDdl.DataBind();
            this.classDdl.Items.Insert(0, "--请选择--");

            this.flowDdl.Items.Insert(0, "--请选择--");
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
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
            this.addDocIbtn.Click += new System.Web.UI.ImageClickEventHandler(this.addDocIbtn_Click);
            this.ImageButton3.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton3_Click);
            this.xsqb.Click += new System.EventHandler(this.xsqb_Click);
            this.gwgl.Click += new System.EventHandler(this.gwgl_Click);
            this.rsgl.Click += new System.EventHandler(this.rsgl_Click);
            this.xzgl.Click += new System.EventHandler(this.xzgl_Click);
            this.czgl.Click += new System.EventHandler(this.czgl_Click);
            this.tjcx.Click += new System.EventHandler(this.tjcx_Click);
            this.scwd.Click += new System.EventHandler(this.scwd_Click);
            this.favFolderListDdl.SelectedIndexChanged += new System.EventHandler(this.favFolderListDdl_SelectedIndexChanged);
            this.pageDdl.SelectedIndexChanged += new System.EventHandler(this.pageDdl_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.licenseLbtn.Click += new System.EventHandler(this.licenseLbtn_Click);

        }
        #endregion

        private void xsqb_Click(object sender, System.EventArgs e)
        {

        }

        private void gwgl_Click(object sender, System.EventArgs e)
        {

        }

        private void rsgl_Click(object sender, System.EventArgs e)
        {

        }

        private void xzgl_Click(object sender, System.EventArgs e)
        {

        }

        private void czgl_Click(object sender, System.EventArgs e)
        {

        }

        protected void DepartmentBind()//绑定条件查询中的部门选择
        {
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            string sql = "select * from dsoc_bm ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            this.ee.DataSource = dr;
            this.ee.DataTextField = "bm_mc";
            this.ee.DataValueField = "bm_mc";
            this.ee.DataBind();
            this.ee.Items.Insert(0, "-请选择经办部门-");
            dr.Close();
            conn.Close();
        }

        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {

        }

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {

        }

        protected void BindGrid()
        {
            ControlDataBind();

            DataTable dt = Flow.Get_Work(DisplayType, _zgbh);
            DataView dv = dt.DefaultView;  //来自web service的dataset,这里随便一个ds就可以;
            DataGrid1.DataSource = dv; //指定数据源
            if (dt.Rows.Count == 0)
            {
                for (int i = 0; i < 15; i++)
                    dt.Rows.Add(dt.NewRow());
                this.pageDdl.Enabled = false;
            }
            else
            {
                this.pageDdl.Enabled = true;
                if ((dt.Rows.Count % DataGrid1.PageSize) != 0)
                    for (int i = dt.Rows.Count % DataGrid1.PageSize; i < DataGrid1.PageSize; i++)
                        dt.Rows.Add(dt.NewRow());
            }
            DataGrid1.DataBind();
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if (DataGrid1.Rows[i].Cells[2].Text == "&nbsp;")
                {
                    LinkButton btn = new LinkButton();
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton1");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton2");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton3");
                    btn.Visible = false;
                }
            }

            string _class = string.Empty;
            if (Session["title"] != null)
            {
                _class += " and Doc_Title like '%" + Session["title"].ToString().Trim() + "%'";
            }
            if (Session["ryxm"] != null)
            {
                _class += " and Doc_Builder_ID = ry_zgbh and ry_xm like '%" + Session["ryxm"].ToString().Trim() + "%'";
            }
            if (Session["index"] != null && Session["index"].ToString() != "--请选择--")
            {
                _class += " and ry_bm like '%" + Session["index"].ToString().Trim() + "%'";
            }
            if (Session["docType"] != null)
            {
                _class += " and class_id = '" + Session["docType"].ToString() + "'";
            }
            if (Session["flowName"] != null)
            {
                _class += " and Flow_Name like '%" + Session["flowName"].ToString().Trim() + "%'";
            }
            if (Session["startTime"] != null && Session["endTime"] != null)
            {
                _class += " and Doc_Added_Date between '" + Convert.ToDateTime(Session["startTime"].ToString().Trim()) + "' and '" + Convert.ToDateTime(Session["endTime"].ToString().Trim()) + "'";
            }
            _class += "  order by emergency_level desc, Doc_Added_Date desc";
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select distinct case dsoc_flow_document.emergency_level when '1' then '一般' when '2' then '紧急' when '3' then '非常紧急' end as emergency_name, dsoc_flow_document.emergency_level, dbo.Dsoc_Flow_Document.Doc_ID,dbo.Dsoc_Flow_Document.Flow_ID,Doc_Title,Flow_Name,dbo.Dsoc_Flow_Document.Step_ID,Step_Name,ry_xm,Doc_Added_Date, dbo.f_getClassName(class_id) AS class_name from dbo.Dsoc_Flow_Document,dbo.Dsoc_Flow,dbo.dsoc_ry,dbo.Dsoc_Flow_Step,dsoc_flow_style_data where dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow.Flow_ID and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh and  dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow_Step.Flow_ID and  dbo.Dsoc_Flow_Document.Step_ID = dbo.Dsoc_Flow_Step.Step_ID and obj_ID like '%" + _zgbh + "%' and dsoc_flow_style_data.doc_id=dsoc_flow_document.doc_id " + _class;
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            adapter.Fill(ds, "result1");
            DataTable dt1 = ds.Tables["result1"];
            DataGrid1.DataSource = dt1;
            if (dt1.Rows.Count == 0)
            {
                for (int i = 0; i < 15; i++)
                    dt1.Rows.Add(dt1.NewRow());
                this.pageDdl.Enabled = false;
                this.DataGrid1.DataBind();
            }
            else
            {
                this.pageDdl.Enabled = true;
                if ((dt1.Rows.Count % DataGrid1.PageSize) != 0)
                    for (int i = dt1.Rows.Count % DataGrid1.PageSize; i < DataGrid1.PageSize; i++)
                        dt1.Rows.Add(dt1.NewRow());
                DataGrid1.DataBind();
            }
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if (DataGrid1.Rows[i].Cells[2].Text == "&nbsp;")
                {
                    LinkButton btn = new LinkButton();
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton1");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton2");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton3");
                    btn.Visible = false;
                }
            }

            pageDdl.Items.Clear();
            for (int i = 0; i < DataGrid1.PageCount; i++)
                pageDdl.Items.Add((i + 1).ToString());
        }

        /// <summary>
        /// 绑定收藏文件夹列表控件
        /// </summary>
        private void ControlDataBind()
        {
            //初始化数据库连接对象
            string str = SQLHelper.CONN_STRING;
            SqlConnection con = new SqlConnection(str);

            //绑定收藏夹名字列表控件
            DataTable fileListTable = new DataTable();
            fileListTable = SQLHelper.ExecuteDataTable(con, System.Data.CommandType.Text, "select FolderName from dsoc_ry_favorites where zgbh='" + _zgbh + "' and type=1 order by CreatedTime", null);
            this.favFolderListDdl.DataSource = fileListTable;
            this.favFolderListDdl.DataTextField = "FolderName";
            this.favFolderListDdl.DataValueField = "FolderName";
            this.favFolderListDdl.DataBind();
            this.favFolderListDdl.Items.Insert(0, "--请选择--");
        }


        /// <summary>
        /// 判断分页列表中按钮是否可用
        /// </summary>
        public void JudgeEnable()
        {
            if (this.DataGrid1.PageIndex == 0)
            {
                if (this.DataGrid1.PageCount == 1)
                {
                    this.btnFirst.Enabled = false;
                    this.btnPrev.Enabled = false;
                    this.btnLast.Enabled = false;
                    this.btnNext.Enabled = false;
                }
                else
                {
                    this.btnFirst.Enabled = false;
                    this.btnPrev.Enabled = false;
                    this.btnLast.Enabled = true;
                    this.btnNext.Enabled = true;
                }
            }
            else
            {
                if (this.DataGrid1.PageIndex == this.DataGrid1.PageCount - 1)
                {
                    this.btnFirst.Enabled = true;
                    this.btnPrev.Enabled = true;
                    this.btnLast.Enabled = false;
                    this.btnNext.Enabled = false;

                }
                else
                {
                    this.btnFirst.Enabled = true;
                    this.btnPrev.Enabled = true;
                    this.btnLast.Enabled = true;
                    this.btnNext.Enabled = true;
                }
            }
        }


        /// <summary>
        /// 绑定收藏文档列表
        /// </summary>
        protected void BindFavoriteDocDg(string conditionExp)
        {
            //初始化数据库连接对象
            string str = SQLHelper.CONN_STRING;
            SqlConnection con = new SqlConnection(str);

            DataTable docIDTable = new DataTable();
            string strSql = "select ContainRybh from dsoc_ry_favorites where zgbh='" + _zgbh + "' and type=1 " + conditionExp + " order by CreatedTime";
            docIDTable = SQLHelper.ExecuteDataTable(con, System.Data.CommandType.Text, strSql, null);
            string IDList = string.Empty;
            for (int i = 0; i < docIDTable.Rows.Count; i++)
                IDList += docIDTable.Rows[i].ItemArray[0].ToString();
            DataTable favoriteDocList = new DataTable();
            DataColumn dc = new DataColumn("doc_id", System.Type.GetType("System.String"));
            favoriteDocList.Columns.Add(dc);
            favoriteDocList.PrimaryKey = new DataColumn[] { dc };
            dc = new DataColumn("flow_id", System.Type.GetType("System.Int32"));
            favoriteDocList.Columns.Add(dc);
            dc = new DataColumn("doc_title", System.Type.GetType("System.String"));
            favoriteDocList.Columns.Add(dc);
            dc = new DataColumn("flow_name", System.Type.GetType("System.String"));
            favoriteDocList.Columns.Add(dc);
            dc = new DataColumn("step_id", System.Type.GetType("System.Int32"));
            favoriteDocList.Columns.Add(dc);
            dc = new DataColumn("step_name", System.Type.GetType("System.String"));
            favoriteDocList.Columns.Add(dc);
            dc = new DataColumn("ry_xm", System.Type.GetType("System.String"));
            favoriteDocList.Columns.Add(dc);
            dc = new DataColumn("doc_added_date", System.Type.GetType("System.String"));
            favoriteDocList.Columns.Add(dc);
            dc = new DataColumn("style_remark", System.Type.GetType("System.String"));
            favoriteDocList.Columns.Add(dc);
            string[] docIDList = IDList.Split(';');
            int index = 0;
            if (docIDList[docIDList.Length - 1] == "")
                index = docIDList.Length - 1;
            else
                index = docIDList.Length;
            DataTable tempTable = new DataTable();
            string tempStr = string.Empty;
            for (int i = 0; i < index; i++)
            {
                if (!favoriteDocList.Rows.Contains(Int32.Parse(docIDList[i])))
                {
                    tempStr = "select distinct case dsoc_flow_document.emergency_level when '1' then '一般' when '2' then '紧急' when '3' then '非常紧急' end as emergency_name, dsco_flow_document.emergency_level, dbo.Dsoc_Flow_Document.Doc_ID,dbo.Dsoc_Flow_Document.Flow_ID,Doc_Title,Flow_Name,dbo.Dsoc_Flow_Document.Step_ID,Step_Name,ry_xm,Convert(varchar(20),Doc_Added_Date,111) as Doc_Added_Date from dbo.Dsoc_Flow_Document,dbo.Dsoc_Flow,dbo.dsoc_ry,dbo.Dsoc_Flow_Step where dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow.Flow_ID and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh and  dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow_Step.Flow_ID and  dbo.Dsoc_Flow_Document.Step_ID = dbo.Dsoc_Flow_Step.Step_ID and (Dsoc_Flow_Document.Doc_ID = " + Int32.Parse(docIDList[i]) + ") and obj_id='" + _zgbh + "'";
                    tempTable = SQLHelper.ExecuteDataTable(con, System.Data.CommandType.Text, tempStr, null);
                    if (tempTable.Rows.Count != 0)
                        favoriteDocList.ImportRow(tempTable.Rows[0]);
                }
            }
            DataGrid1.DataSource = favoriteDocList;
            if (favoriteDocList.Rows.Count == 0)
            {
                for (int i = 0; i < 15; i++)
                    favoriteDocList.Rows.Add(new object[] { i, null, null, null, null, null, null, null, null });
                this.pageDdl.Enabled = false;
                this.DataGrid1.DataBind();
            }
            else
            {
                this.pageDdl.Enabled = true;
                if ((favoriteDocList.Rows.Count % DataGrid1.PageSize) != 0)
                    for (int i = favoriteDocList.Rows.Count % DataGrid1.PageSize; i < DataGrid1.PageSize; i++)
                        favoriteDocList.Rows.Add(new object[] { i, null, null, null, null, null, null, null, null });
                DataGrid1.DataBind();
            }
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if (DataGrid1.Rows[i].Cells[1].Text == "&nbsp;")
                {
                    LinkButton btn = new LinkButton();
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton1");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton2");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Rows[i].FindControl("LinkButton3");
                    btn.Visible = false;
                }
            }
            pageDdl.Items.Clear();
            for (int i = 0; i < DataGrid1.PageCount; i++)
                pageDdl.Items.Add((i + 1).ToString());
            this.DataGrid1.Columns[11].Visible = false;
        }


        /// <summary>
        /// 根据当前DataGrid页码设定分页列表中部分控件的数据
        /// </summary>
        private void ShowStats()
        {
            lblCurrentIndex.Text = "第 " + (DataGrid1.PageIndex + 1).ToString() + " 页";
            lblPageCount.Text = "总共 " + DataGrid1.PageCount.ToString() + " 页";
            this.pageDdl.SelectedIndex = this.DataGrid1.PageIndex;
        }

        private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
            string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
            string SortDirection = "DESC"; //为排序方向变量赋初值
            if (SortExpression == DataGrid1.Attributes["SortExpression"])  //如果为当前排序列
            {
                SortDirection = (DataGrid1.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态
            }
            DataGrid1.Attributes["SortExpression"] = SortExpression;
            DataGrid1.Attributes["SortDirection"] = SortDirection;
            BindGrid();
        }

        private void pageDdl_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// 分页列表中按钮对应的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PagerButtonClick(object sender, EventArgs e)
        {
            string arg = ((LinkButton)sender).CommandArgument.ToString();
            switch (arg)
            {
                case "next":
                    DataGrid1.PageIndex += 1; break;
                case "prev":
                    DataGrid1.PageIndex -= 1; break;
                case "last":
                    DataGrid1.PageIndex = (DataGrid1.PageCount - 1); break;
                default:
                    DataGrid1.PageIndex = System.Convert.ToInt32(arg); break;
            }
            BindGrid();
            JudgeEnable();
            ShowStats();
        }

        private void tjcx_Click(object sender, System.EventArgs e)
        {

        }

        private void Button1_Click(object sender, System.EventArgs e)
        {

        }

        private void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }

        private void addDocIbtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }

        private void scwd_Click(object sender, System.EventArgs e)
        {

        }

        private void favFolderListDdl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.favFolderListDdl.SelectedIndex != 0)
                BindFavoriteDocDg(" and FolderName='" + this.favFolderListDdl.SelectedItem.Text.ToString() + "'");
        }

        private void licenseLbtn_Click(object sender, System.EventArgs e)
        {

        }

        protected void xsqb_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx");
        }

        protected void gwgl_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx?DisplayType=1");
        }

        protected void rsgl_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx?DisplayType=2");
        }

        protected void xzgl_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx?DisplayType=3");
        }

        protected void czgl_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx?DisplayType=4");
        }

        protected void licenseLbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx?DisplayType=8");
        }

        protected void tjcx_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx?DisplayType=5");
        }

        protected void scwd_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx?DisplayType=6");
        }

        protected void pageDdl_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.DataGrid1.PageIndex = Int32.Parse(this.pageDdl.SelectedItem.ToString()) - 1;
            BindGrid();
            JudgeEnable();
            ShowStats();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (this.ee.SelectedItem.Text.ToString() != "-请选择经办部门-")
                Session["index"] = this.ee.SelectedItem.Text.ToString();
            if (this.docIDTbx.Text != string.Empty)
                Session["documentID"] = docIDTbx.Text.ToString().Trim();
            if (Tittle.Text != string.Empty)
                Session["title"] = Tittle.Text.ToString().Trim();
            if (Jbr.Text != string.Empty)
                Session["ryxm"] = Jbr.Text.ToString().Trim();
            if (docTypeTbx.Text != string.Empty)
                Session["docType"] = docTypeTbx.Text.ToString().Trim();
            if (TimeFrom.Text.ToString() != string.Empty && TimeTo.Text.ToString() != string.Empty)
            {
                Session["startTime"] = TimeFrom.Text.ToString().Trim();
                Session["endTime"] = TimeTo.Text.ToString().Trim();
            }
            string _URL = "Work_Manage.aspx?DisplayType=7";
            Response.Redirect(_URL);
        }

        protected void addDocIbtn_Click1(object sender, ImageClickEventArgs e)
        {
            string[] folderList = this.Favorite_doc1.FolderList.Split(';');
            Label lb = new Label();
            lb = (Label)this.Favorite_doc1.FindControl("Label3");
            if (folderList.Length == 1)
            {
                lb.Visible = true;
                lb.Text = "没有选择目的收藏夹，收藏失败！";
            }
            else
            {
                string str = SQLHelper.CONN_STRING;
                SqlConnection con = new SqlConnection(str);
                string strSql = string.Empty;
                string id = docID.ToString() + ";";
                for (int i = 0; i < folderList.Length; i++)
                {
                    strSql = "update dsoc_ry_favorites set ContainRybh=replace(ContainRybh,'" + id + "','')+'" + id + "' where zgbh='" + _zgbh + "' and FolderName='" + folderList[i] + "' and type=1";
                    SQLHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, strSql);
                }
                lb.Text = "该文档已收藏成功！";
                lb.Visible = true;
            }
        }

        protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
        {
            Label lb = new Label();
            lb = (Label)this.Favorite_doc1.FindControl("Label3");
            lb.Visible = false;
            this.Table4.Visible = false;
        }

        protected void DataGrid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "dispose")
            {
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                _doc_id = e.CommandArgument.ToString().Split(':')[0];// row.Cells[0].Text.ToString();
                _flow_id = e.CommandArgument.ToString().Split(':')[1];// row.Cells[1].Text.ToString();
                _step_id = e.CommandArgument.ToString().Split(':')[2];// row.Cells[4].Text.ToString();
                string _URL = null;
                string connString = SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select dbo.Dsoc_Flow_Style.Style_Remark from dbo.Dsoc_Flow,dbo.Dsoc_Flow_Style where dbo.Dsoc_Flow.Flow_ID = '" + _flow_id + "' and dbo.Dsoc_Flow.Style_ID =dbo.Dsoc_Flow_Style.Style_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    _URL = dr["Style_Remark"].ToString();
                dr.Close();
                conn.Close();
                conn.Dispose();
                _URL += "?step_id=" + _step_id + "&doc_id=" + _doc_id + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
            if (e.CommandName.ToString() == "proc")
            {
                _doc_id = e.CommandArgument.ToString();
                string _URL = "Work_Proc.aspx?flag=1&doc_id=" + _doc_id + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
            if (e.CommandName.ToString() == "work_lct")
            {
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                _flow_id = e.CommandArgument.ToString();
                string _URL = "Work_lct.aspx?flow_id=" + _flow_id + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
            if (e.CommandName.ToString() == "favorite")
            {
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                string _doc_id = null;
                _doc_id = row.Cells[0].Text.ToString();

                //初始化数据库连接对象
                string str = SQLHelper.CONN_STRING;
                SqlConnection con = new SqlConnection(str);

                DataTable docIDTable = new DataTable();
                string strSql = "select FolderName,ContainRybh from dsoc_ry_favorites where zgbh='" + _zgbh + "' and type=1 order by CreatedTime";
                docIDTable = SQLHelper.ExecuteDataTable(con, System.Data.CommandType.Text, strSql, null);
                CheckBoxList cbl = new CheckBoxList();
                cbl = (CheckBoxList)this.Favorite_doc1.FindControl("folderListCbl");
                for (int i = 0; i < docIDTable.Rows.Count; i++)
                {
                    if (docIDTable.Rows[i].ItemArray[1].ToString().IndexOf(_doc_id) == -1)
                        cbl.Items[i].Selected = false;
                    else
                        cbl.Items[i].Selected = true;
                }
                Session["docID"] = row.Cells[0].Text.ToString().Trim() + ";" + row.Cells[2].Text.ToString().Trim();
                Label lb = new Label();
                lb = (Label)this.Favorite_doc1.FindControl("Label2");
                lb.Text = "请选择文档《" + Session["docID"].ToString().Split(';')[1].ToString().Trim() + "》的目的收藏夹：";
                this.Table4.Visible = true;
            }
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#95B8FF'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            if (topicTxt.Text.Trim() != string.Empty)
                Session["title"] = topicTxt.Text.Trim();
            else
                Session.Remove("title");
            if (classDdl.SelectedIndex != 0)
                Session["docType"] = classDdl.SelectedValue.Trim();
            else
                Session.Remove("docType");
            if (flowDdl.SelectedIndex != 0)
                Session["flowName"] = flowDdl.SelectedItem.Text.Trim();
            else
                Session.Remove("flowName");
            if (this.bmDdl.SelectedIndex != 0)
                Session["index"] = this.bmDdl.SelectedValue.Trim();
            else
                Session.Remove("index");
            if (ryTxt.Text.Trim() != string.Empty)
                Session["ryxm"] = ryTxt.Text.Trim();
            else
                Session.Remove("ryxm");
            if (startTxt.Text.Trim() != string.Empty && endTxt.Text.Trim() != string.Empty)
            {
                Session["startTime"] = startTxt.Text.Trim();
                Session["endTime"] = endTxt.Text.Trim();
            }
            else
            {
                Session.Remove("startTime");
                Session.Remove("endTime");
            }

            BindGrid(); 
            JudgeEnable();
            ShowStats();
        }

        protected void classDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.classDdl.SelectedIndex != 0)
            {
                DataTable dt = Stoke.BLL.Utility.GetFlowByClass(Convert.ToInt32(this.classDdl.SelectedValue));
                this.flowDdl.DataSource = dt;
                this.flowDdl.DataTextField = "flow_name";
                this.flowDdl.DataValueField = "flow_id";
                this.flowDdl.DataBind();
                this.flowDdl.Items.Insert(0, "--请选择--");
            }
            else
            {
                this.flowDdl.Items.Clear();
                this.flowDdl.Items.Insert(0, "--请选择--");
            }
        }
    }
}
