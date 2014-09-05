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
    public partial class Work_Record : System.Web.UI.Page
    {
        protected int flag = 0;
        protected string _zgbh;

        protected int docID;//所选文档编号

        private void Page_Load(object sender, System.EventArgs e)
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
            flag = Convert.ToInt32(Request["flag"]);
            if (!IsPostBack)
            {
                this.Table4.Visible = false;

                BindDdl();

                //分页处理
                btnFirst.Text = "最首页";
                btnPrev.Text = "前一页";
                btnNext.Text = "下一页";
                btnLast.Text = "最后页";

                fieldset1.Visible = false;
                DataGrid1.Visible = true;

                BindGrid(flag);
                JudgeEnable();
                ShowStats();
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

            BindGrid(0);
            JudgeEnable();
            ShowStats();
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
            this.licenseLbtn.Click += new System.EventHandler(this.licenseLbtn_Click);
            this.tjcx.Click += new System.EventHandler(this.tjcx_Click);
            this.scwd.Click += new System.EventHandler(this.scwd_Click);
            this.favFolderListDdl.SelectedIndexChanged += new System.EventHandler(this.favFolderListDdl_SelectedIndexChanged);
            this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
            this.pageDdl.SelectedIndexChanged += new System.EventHandler(this.pageDdl_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);

        }
        #endregion

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }


        /// <summary>
        /// 判断分页列表中按钮是否可用
        /// </summary>
        public void JudgeEnable()
        {
            if (this.DataGrid1.CurrentPageIndex == 0)
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
                if (this.DataGrid1.CurrentPageIndex == this.DataGrid1.PageCount - 1)
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
        /// 根据当前DataGrid页码设定分页列表中部分控件的数据
        /// </summary>
        private void ShowStats()
        {
            lblCurrentIndex.Text = "第 " + (DataGrid1.CurrentPageIndex + 1).ToString() + " 页";
            lblPageCount.Text = "总共 " + DataGrid1.PageCount.ToString() + " 页";
            if (this.DataGrid1.Items.Count == 0)
                this.pageDdl.Enabled = false;
            else
            {
                this.pageDdl.Enabled = true;
                this.pageDdl.SelectedIndex = this.DataGrid1.CurrentPageIndex;
            }
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
                    tempStr = "select distinct dbo.Dsoc_Flow_Document.Doc_ID,dbo.Dsoc_Flow_Document.Flow_ID,Doc_Title,Flow_Name,dbo.Dsoc_Flow_Document.Step_ID,Step_Name,ry_xm,Convert(varchar(20),Doc_Added_Date,111) as Doc_Added_Date from dbo.Dsoc_Flow_Document,dbo.Dsoc_Flow,dbo.dsoc_ry,dbo.Dsoc_Flow_Step where dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow.Flow_ID and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh and  dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow_Step.Flow_ID and  dbo.Dsoc_Flow_Document.Step_ID = dbo.Dsoc_Flow_Step.Step_ID and (Dsoc_Flow_Document.Doc_ID = " + Int32.Parse(docIDList[i]) + ") and obj_id!='" + _zgbh + "'";
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
            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                if (DataGrid1.Items[i].Cells[1].Text == "&nbsp;")
                {
                    LinkButton btn = new LinkButton();
                    btn = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton1");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton3");
                    btn.Visible = false;
                }
            }
            pageDdl.Items.Clear();
            for (int i = 0; i < DataGrid1.PageCount; i++)
                pageDdl.Items.Add((i + 1).ToString());
            this.DataGrid1.Columns[10].Visible = false;
        }

        private void BindGrid(int _flag)
        {
            ControlDataBind();
            string _class = string.Empty;
            switch (_flag)
            {
                case 0:
                    //按用户最近处理时间排序hhw20101119
                    //					_class = " order by Doc_Added_Date desc";
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
                    _class += " order by operator_time desc";
                    TempFun(_class);
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 8:
                    if (_flag == 8)
                        _flag = 5;
                    //按用户最近处理时间排序hhw20101119
                    //					_class = " and Class_ID =" + _flag.ToString()+" order by Doc_Added_Date desc";
                    _class = " and Class_ID =" + _flag.ToString() + " order by operator_time desc";
                    TempFun(_class);
                    break;
                case 5:
                    DataGrid1.Visible = false;
                    fieldset1.Visible = true;
                    this.Label1.Visible = false;
                    this.lb1.Visible = false;
                    this.pageDdl.Visible = false;
                    this.lblCurrentIndex.Visible = false;
                    this.lblPageCount.Visible = false;
                    this.btnFirst.Visible = false;
                    this.btnPrev.Visible = false;
                    this.btnNext.Visible = false;
                    this.btnLast.Visible = false;
                    DepartmentBind();
                    Session["title"] = null;
                    Session["document"] = null;
                    Session["index"] = null;
                    Session["ryxm"] = null;
                    Session["startTime"] = null;
                    Session["endTime"] = null;
                    Session["docType"] = null;
                    break;
                case 6:
                    this.favFolderListDdl.Enabled = true;
                    BindFavoriteDocDg("");
                    break;
                case 7:
                    if (Session["title"] != null)
                    {
                        _class += " and Doc_Title like '%" + Session["title"].ToString().Trim() + "%'";
                    }
                    if (Session["documentID"] != null)
                    {
                        _class += " and h like '%" + Session["documentID"].ToString().Trim() + "%'";
                    }
                    if (Session["ryxm"] != null)
                    {
                        _class += " and Doc_Builder_ID = ry_zgbh and ry_xm like '%" + Session["ryxm"].ToString().Trim() + "%'";
                    }
                    if (Session["index"] != null && Session["index"].ToString() != "-请选择经办部门-")
                    {
                        _class += " and ry_bm like '%" + Session["index"].ToString().Trim() + "%'";
                    }
                    if (Session["docType"] != null)
                    {
                        _class += " and Flow_Name like '%" + Session["docType"].ToString().Trim() + "%'";
                    }
                    if (Session["startTime"] != null && Session["endTime"] != null)
                    {
                        _class += " and Doc_Added_Date between '" + Convert.ToDateTime(Session["startTime"].ToString().Trim()) + "' and '" + Convert.ToDateTime(Session["endTime"].ToString().Trim()) + "'";
                    }
                    //按用户最近处理时间排序hhw20101119
                    //					_class+="  order by Doc_Added_Date desc";
                    _class += "  order by operator_time desc";
                    TempFun(_class);
                    break;
            }
        }


        /// <summary>
        ///临时方法
        /// </summary>
        /// <param name="exp">条件</param>
        private void TempFun(string exp)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);

            //工作查看按用户最近操作的时间排序,小于7天hhw20101119
            //			string sqlStr1 = "select distinct Doc_Title,dbo.Dsoc_Flow_Document.Flow_ID,dbo.Dsoc_Flow_Document.Step_ID,Flow_Name,Step_Name,Doc_Added_Date,ry_xm,dbo.Dsoc_Flow_Document.Doc_ID from dbo.Dsoc_Flow_Document,dbo.Dsoc_Flow,dbo.Dsoc_Flow_Step,dbo.Dsoc_Flow_Path,dbo.dsoc_ry,dsoc_flow_style_data where dsoc_flow_document.doc_id=dsoc_flow_style_data.doc_id and dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow.Flow_ID and dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow_Step.Flow_ID and dbo.Dsoc_Flow_Document.Step_ID = dbo.Dsoc_Flow_Step.Step_ID and Staff_ID = '"+_zgbh+"' and dbo.Dsoc_Flow_Path.Doc_ID = dbo.Dsoc_Flow_Document.Doc_ID and Doc_Builder_ID = ry_zgbh and datediff(day,Dsoc_Flow_Document.Doc_Added_Date,getdate())<=7" + exp;

            //			string sqlStr1 = "select a.Doc_Title,a.Flow_ID,a.Step_ID,Flow_Name,Step_Name,Doc_Added_Date,operator_time,ry_xm,a.Doc_ID "+
            //							"from (((dsoc_flow_document as a left join (select doc_id, staff_id, max(Convert(datetime,operator_time)) as operator_time from dsoc_flow_path group by doc_id, staff_id having staff_id = '"+_zgbh+"') as b on a.doc_id = b.doc_id)  "+
            //							"left join dsoc_flow as c on a.flow_id = c.flow_id) left join dsoc_flow_step as d on a.step_id = d.step_id and a.flow_id = d.flow_id) left join (select distinct ry_zgbh, ry_xm from dsoc_ry) as e on a.doc_builder_id = e.ry_zgbh "+
            //							"where  datediff(day,operator_time,getdate())<=7 "+ exp;
            //tonzoc由于条件查询需要连接dsoc_flow_style_data以及ry_bm字段，故更改如下
            string sqlStr1 = "select distinct a.Doc_Title,a.Flow_ID,a.Step_ID,Flow_Name,Step_Name,Doc_Added_Date,operator_time,ry_xm,a.Doc_ID, dbo.f_getClassName(class_id) as class_name " +
                "from ((((dsoc_flow_document as a " +
                "left join (select doc_id, staff_id, max(Convert(datetime,operator_time)) as operator_time from dsoc_flow_path group by doc_id, staff_id having staff_id = '" + this._zgbh + "') as b on a.doc_id = b.doc_id)  " +
                "left join dsoc_flow as c on a.flow_id = c.flow_id) " +
                "left join dsoc_flow_step as d on a.step_id = d.step_id and a.flow_id = d.flow_id) " +
                "left join (select distinct ry_zgbh, ry_xm, ry_bm from dsoc_ry) as e on a.doc_builder_id = e.ry_zgbh) " +
                "left join dsoc_flow_style_data as f on a.doc_id = f.doc_id " +
                "where  datediff(day,operator_time,getdate())<=7 " + exp;
            ////							"order by operator_time desc";

            SqlCommand cmd = new SqlCommand(sqlStr1, conn);
            cmd = new SqlCommand(sqlStr1, conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            adapter.Fill(ds, "result1");
            DataTable dt1 = ds.Tables["result1"];
            //工作查看按用户最近操作的时间排序,大于7天且流程没有结束hhw20101119
            //string sqlStr2="select distinct Doc_Title,dbo.Dsoc_Flow_Document.Flow_ID,dbo.Dsoc_Flow_Document.Step_ID,Flow_Name,Step_Name,Doc_Added_Date,ry_xm,dbo.Dsoc_Flow_Document.Doc_ID from dbo.Dsoc_Flow_Document,dbo.Dsoc_Flow,dbo.Dsoc_Flow_Step,dbo.Dsoc_Flow_Path,dbo.dsoc_ry,dsoc_flow_style_data where dsoc_flow_document.doc_id=dsoc_flow_style_data.doc_id and dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow.Flow_ID and dbo.Dsoc_Flow_Document.Flow_ID = dbo.Dsoc_Flow_Step.Flow_ID and dbo.Dsoc_Flow_Document.Step_ID = dbo.Dsoc_Flow_Step.Step_ID and Staff_ID = '"+_zgbh+"' and dbo.Dsoc_Flow_Path.Doc_ID = dbo.Dsoc_Flow_Document.Doc_ID and Doc_Builder_ID = ry_zgbh and  Dsoc_Flow_Document.Step_ID!=-1 and datediff(day,Dsoc_Flow_Document.Doc_Added_Date,getdate())>7" + exp;

            //			string sqlStr2 = "select a.Doc_Title,a.Flow_ID,a.Step_ID,Flow_Name,Step_Name,Doc_Added_Date,operator_time,ry_xm,a.Doc_ID "+
            //							 "from (((dsoc_flow_document as a left join (select doc_id, staff_id, max(Convert(datetime,operator_time)) as operator_time from dsoc_flow_path group by doc_id, staff_id having staff_id = '"+_zgbh+"') as b on a.doc_id = b.doc_id) "+
            //							  "left join dsoc_flow as c on a.flow_id = c.flow_id) left join dsoc_flow_step as d on a.step_id = d.step_id and a.flow_id = d.flow_id) left join (select distinct ry_zgbh, ry_xm from dsoc_ry) as e on a.doc_builder_id = e.ry_zgbh "+
            //							  "where a.step_id <> '-1' and datediff(day,operator_time,getdate())>7 "+ exp;
            ////							  "order by operator_time desc";

            string sqlStr2 = "select distinct a.Doc_Title,a.Flow_ID,a.Step_ID,Flow_Name,Step_Name,Doc_Added_Date,operator_time,ry_xm,a.Doc_ID, dbo.f_getClassName(class_id) as class_name " +
"from ((((dsoc_flow_document as a left join (select doc_id, staff_id, max(Convert(datetime,operator_time)) as operator_time from dsoc_flow_path group by doc_id, staff_id having staff_id = '" + this._zgbh + "') as b on a.doc_id = b.doc_id) " +
"left join dsoc_flow as c on a.flow_id = c.flow_id) " +
"left join dsoc_flow_step as d on a.step_id = d.step_id and a.flow_id = d.flow_id) " +
"left join (select distinct ry_zgbh, ry_xm, ry_bm from dsoc_ry) as e on a.doc_builder_id = e.ry_zgbh) " +
"left join dsoc_flow_style_data as f on a.doc_id = f.doc_id " +
"where a.step_id <> '-1' and datediff(day,operator_time,getdate())>7  " + exp;

            cmd.CommandText = sqlStr2;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "result2");
            DataTable dt = ds.Tables["result2"];
            conn.Close();
            conn.Dispose();
            for (int i = 0; i < dt1.Rows.Count; i++)
                dt.ImportRow(dt1.Rows[i]);
            DataView dv = dt.DefaultView;
            //按用户最近处理时间排序hhw20101119
            //			dv.Sort="Doc_Added_Date desc";
            dv.Sort = "operator_time desc";
            dt = dv.Table;
            DataGrid1.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                for (int i = 0; i < 15; i++)
                    dt.Rows.Add(dt.NewRow());
                this.pageDdl.Enabled = false;
                this.DataGrid1.DataBind();
            }
            else
            {
                this.pageDdl.Enabled = true;
                if ((dt.Rows.Count % DataGrid1.PageSize) != 0)
                    for (int i = dt.Rows.Count % DataGrid1.PageSize; i < DataGrid1.PageSize; i++)
                        dt.Rows.Add(dt.NewRow());
                DataGrid1.DataBind();
            }
            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                if (DataGrid1.Items[i].Cells[0].Text == "&nbsp;")
                {
                    LinkButton btn = new LinkButton();
                    btn = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton1");
                    btn.Visible = false;
                    btn = (LinkButton)DataGrid1.Items[i].FindControl("LinkButton3");
                    btn.Visible = false;
                }
            }

            pageDdl.Items.Clear();
            for (int i = 0; i < DataGrid1.PageCount; i++)
                pageDdl.Items.Add((i + 1).ToString());
        }
        protected void DepartmentBind()//绑定条件查询中的部门选择
        {
            string connString = StokeGlobals.Connectiondsoc;
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

        private void xsqb_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=0");
        }

        private void gwgl_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=1");
        }

        private void rsgl_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=2");
        }

        private void xzgl_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=3");
        }

        private void czgl_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=4");
        }

        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "detail")
            {
                string _flow_id_temp = e.Item.Cells[1].Text.ToString().Trim();
                string _doc_id_temp = e.Item.Cells[0].Text.ToString().Trim();
                string _URL = null;
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select * from Dsoc_Flow,Dsoc_Flow_Style where Dsoc_Flow.Style_ID = Dsoc_Flow_Style.Style_ID and Dsoc_Flow.Flow_ID = '" + _flow_id_temp + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    _URL = dr["Style_Remark"].ToString();
                dr.Close();
                conn.Close();
                _URL += "?step_id=0&doc_id=" + _doc_id_temp + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
            if (e.CommandName.ToString() == "proc")
            {
                string _doc_id = null;
                _doc_id = e.Item.Cells[0].Text.ToString();
                string _URL = "Work_Proc.aspx?doc_id=" + _doc_id + "&zgbh=" + _zgbh;
                Response.Redirect(_URL);
            }
            if (e.CommandName.ToString() == "favorite")
            {
                string _doc_id = null;
                _doc_id = e.Item.Cells[0].Text.ToString();

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
                Session["docID"] = e.Item.Cells[0].Text.ToString().Trim() + ";" + e.Item.Cells[1].Text.ToString().Trim();
                Label lb = new Label();
                lb = (Label)this.Favorite_doc1.FindControl("Label2");
                lb.Text = "请选择文档《" + Session["docID"].ToString().Split(';')[1].ToString().Trim() + "》的目的收藏夹：";
                this.Table4.Visible = true;
            }
        }

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#95B8FF'");
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                e.Item.Attributes["style"] = "Cursor:hand";
            }
        }

        private void pageDdl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.DataGrid1.CurrentPageIndex = Int32.Parse(this.pageDdl.SelectedItem.ToString()) - 1;
            BindGrid(flag);
            JudgeEnable();
            ShowStats();
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
                    DataGrid1.CurrentPageIndex += 1; break;
                case "prev":
                    DataGrid1.CurrentPageIndex -= 1; break;
                case "last":
                    DataGrid1.CurrentPageIndex = (DataGrid1.PageCount - 1); break;
                default:
                    DataGrid1.CurrentPageIndex = System.Convert.ToInt32(arg); break;
            }
            BindGrid(flag);
            JudgeEnable();
            ShowStats();
        }

        private void Button1_Click(object sender, System.EventArgs e)
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
            string _URL = "Work_Record.aspx?flag=7";
            Response.Redirect(_URL);
        }

        private void tjcx_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=5");
        }

        private void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Label lb = new Label();
            lb = (Label)this.Favorite_doc1.FindControl("Label3");
            lb.Visible = false;
            this.Table4.Visible = false;
        }

        private void addDocIbtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

        private void scwd_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=6");
        }

        private void favFolderListDdl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.favFolderListDdl.SelectedIndex != 0)
                BindFavoriteDocDg(" and FolderName='" + this.favFolderListDdl.SelectedItem.Text.ToString() + "'");
        }

        private void licenseLbtn_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Record.aspx?flag=8");
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
