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
using Stoke.Components;
using Stoke.COMMON;

namespace Stoke.USL.Staff
{
    public partial class Style_zjzcjh : System.Web.UI.Page
    {
        private DataTable dt_step_field;
        private int FieldNum = 0;
        private int flow_id = 41;
        private int step_id = 1;
        private int doc_id = 0;
        private bool editMode = false;
        private DataTable dt_temp;


        private int mCreatePageTimes = 0;
        private int maCreatePageTimes = 0;


        //-------------------------------测试用-----------------------------------------
        private string ry_zgbh;
        private string ry_xm = "";
        //------------------------------------------------------------------------------

        private void Page_Load(object sender, System.EventArgs e)
        {
            ry_zgbh = Request.QueryString["zgbh"].ToString();
            doc_id = Convert.ToInt32(Request.QueryString["doc_id"]);
            step_id = Convert.ToInt32(Request.QueryString["step_id"]);

            if (doc_id > 0)
                editMode = true;

            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);
            FieldNum = dt_step_field.Rows.Count;

            if (!Page.IsPostBack)
                dt_temp_initialize();

            dt_temp = (DataTable)Session["dt_temp"];

            if (!Page.IsPostBack)
            {
                tableAddNewDetail.Visible = false;
                bindFormTop();
                bindFormMiddle();

                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(ry_zgbh);
                if (dt_xm_bm.Rows.Count != 0)
                    ry_xm = dt_xm_bm.Rows[0][0].ToString();

                if (editMode == true)
                {
                    Step_Handle_Data();
                }
                BindDataGrid();

                if (editMode == true)
                {
                    bindModifyDataGrid();
                }

                if (step_id == 1)
                {
                    this.h.Text = ry_xm;
                    this.i.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    tableAddNewDetail.Visible = true;
                    modifyAdvice.Visible = false;
                    if (editMode == true)
                    {
                        modifyAdvice.Visible = true;
                    }
                }
                if (step_id == 2)
                {
                    this.j.Text = ry_xm;
                    this.k.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (step_id == 0)
                {
                    this.btnSubmit.Visible = false;
                    this.zjzcDatagrid.Columns[14].Visible = false;
                    this.zjzcDatagrid.Columns[15].Visible = false;
                }

                if (step_id == -1)
                {
                    string month = this.b.SelectedValue + "-" + this.c.SelectedValue;
                    Stoke.Components.zjzc.insertZjzcSubmit(month, a.SelectedItem.Text, doc_id, 0);
                    Response.Redirect("../Workflow/Work_Manage.aspx?zgbh=" + ry_zgbh);
                }

                if (step_id == -2)
                {
                    this.tableAddNewDetail.Visible = false;
                    btnSubmit.Visible = false;
                    btnBack.Visible = true;
                    int returnFlag = Convert.ToInt32(Request.QueryString["returnFlag"]);
                    if (returnFlag == 1)
                        btnReturn.Visible = true;
                }

                ViewState["zjzcdetaibackUrl"] = Request.UrlReferrer.ToString();
            }

            Field_Bind(dt_step_field);
        }

        private void dt_temp_initialize()
        {
            dt_temp = Stoke.Components.zjzc.getZjzcDetailByMonthAndBmAndDocid(string.Empty, string.Empty, doc_id);
            Session["dt_temp"] = dt_temp;
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            if (dt_style_data != null)
            {
                if (dt_style_data.Rows.Count != 0)
                {
                    this.a.Items.Clear();
                    this.a.Items.Add(dt_style_data.Rows[0]["a"].ToString());
                    //					this.a.DataBind();
                    //					string str = dt_style_data.Rows[0]["a"].ToString();
                    this.b.Items.Clear();
                    this.b.Items.Add(dt_style_data.Rows[0]["b"].ToString());
                    //					this.b.DataBind();
                    this.c.Items.Clear();
                    int month = Convert.ToInt32(dt_style_data.Rows[0]["c"]);
                    this.c.Items.Add(new ListItem(month.ToString() + "-" + Convert.ToString((month + 2) > 12 ? month - 10 : month + 2), dt_style_data.Rows[0]["c"].ToString()));
                    //					this.c.DataBind();
                    this.d.Text = month + "月资金支出计划";
                    this.e.Text = Convert.ToString((month + 1) > 12 ? month - 10 : month + 1) + "月资金支出计划";
                    this.f.Text = Convert.ToString((month + 2) > 12 ? month - 10 : month + 2) + "月资金支出计划";
                    this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
                    this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
                    this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
                    this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
                }
            }
        }

        private void Field_Bind(DataTable dt)
        {
            string name = null;
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i][0].ToString();
                StyleControl = FrmNewDocument.FindControl(name);
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)StyleControl).BackColor = Color.White;
                    ((TextBox)StyleControl).ReadOnly = false;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)StyleControl).Enabled = true;
                    ((DropDownList)StyleControl).BackColor = Color.White;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.Label")
                {
                    ((Label)StyleControl).Enabled = true;
                    ((Label)StyleControl).BackColor = Color.White;
                }
            }
        }

        private void bindFormTop()
        {
            Stoke.Components.Staff _staff = new Stoke.Components.Staff();
            DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(ry_zgbh);
            this.a.DataSource = dt_xm_bm;
            this.a.DataTextField = "ry_bm";
            this.a.DataValueField = "ry_bm";
            this.a.DataBind();

            int year = DateTime.Now.Year;
            this.b.Items.Add(Convert.ToString(year - 1));
            this.b.Items.Add(year.ToString());
            this.b.Items.Add(Convert.ToString(year + 1));
            this.b.SelectedValue = year.ToString();

            this.c.SelectedValue = DateTime.Now.Month.ToString("00");

            int month = DateTime.Now.Month;
            this.d.Text = month + "月资金支出计划";
            this.e.Text = Convert.ToString((month + 1) > 12 ? month - 10 : month + 1) + "月资金支出计划";
            this.f.Text = Convert.ToString((month + 2) > 12 ? month - 10 : month + 2) + "月资金支出计划";

        }

        private void bindFormMiddle()
        {
            this.ddlXm.DataSource = Stoke.Components.zjzc.getAllXmz();// Stoke.Components.zjzc.getAllXmz();
            this.ddlXm.DataTextField = "xmz_mc";
            this.ddlXm.DataValueField = "bm_bh";
            this.ddlXm.DataBind();

            this.ddlXm.Items.Insert(0, new ListItem(this.a.SelectedValue.Trim(), "0"));
        }

        private void BindDataGrid()
        {
            //			string cmdText = @"select 1 as ID, rtrim(C.bm_mc) as xm_mc, B.[content] as [content], A.skdw, A.firstRmb, A.firstUsd, A.firstEur, A.secondRmb, A.secondUsd, A.secondEur, A.thirdRmb, A.thirdUsd, A.thirdEur, rtrim(D.ry_xm) as jbrXm
            //								from zjzc_detail as A left join zjzc_item as B on A.itemID = B.ID left join dsoc_bm as C on B.xm_bh = C.bm_bh, dsoc_ry D
            //								where A.jbrZgbh = D.ry_zgbh";
            //			string connString = DSOC.Help.DataAccess.ConnectionString;
            //			
            //			SqlConnection conn = new SqlConnection(connString);
            //			SqlCommand cmd = new SqlCommand(cmdText, conn);
            //			DataTable dt = new DataTable();
            //			SqlDataAdapter da = new SqlDataAdapter(cmd);
            //			conn.Open();
            //			da.Fill(dt);
            //			conn.Close();

            dt_temp = (DataTable)Session["dt_temp"];
            DataTable dt = dt_temp.Clone();
            if (step_id == 1 && editMode == false)
            {
                foreach (DataRow row in dt_temp.Rows)
                {
                    dt.BeginInit();
                    dt.ImportRow(row);
                    dt.EndInit();
                }
            }
            else if (step_id == -2)
            {
                string bm_mc = Request.QueryString["bm_mc"].ToString();
                dt = Stoke.Components.zjzc.getZjzcDetailByMonthAndBmAndDocid(this.b.SelectedValue + "-" + this.c.SelectedValue, a.SelectedValue.Trim(), doc_id);
            }
            else
            {
                dt = Stoke.Components.zjzc.getZjzcDetailByMonthAndBmAndDocid(this.b.SelectedValue + "-" + this.c.SelectedValue, a.SelectedValue.Trim(), doc_id);
            }

            int rowCount = this.zjzcDatagrid.PageSize;
            if (dt.Rows.Count != 0)
            {
                rowCount = this.zjzcDatagrid.PageSize - (dt.Rows.Count + this.zjzcDatagrid.PageSize) % this.zjzcDatagrid.PageSize;
            }

            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
            }

            this.zjzcDatagrid.DataSource = dt;
            this.zjzcDatagrid.DataBind();

            //绑定footer值
            foreach (DataGridItem item in this.zjzcDatagrid.Controls[0].Controls)
            {
                if (item.ItemType == ListItemType.Footer)
                {
                    item.Cells[1].Text = "合计";
                    item.Cells[2].Text = "--";
                    item.Cells[3].Text = "--";
                    item.Cells[4].Text = dt.Compute("sum([firstRmb])", "1>0").ToString();
                    item.Cells[5].Text = dt.Compute("sum([firstUsd])", "1>0").ToString();
                    item.Cells[6].Text = dt.Compute("sum([firstEur])", "1>0").ToString();
                    item.Cells[7].Text = dt.Compute("sum([secondRmb])", "1>0").ToString();
                    item.Cells[8].Text = dt.Compute("sum([secondUsd])", "1>0").ToString();
                    item.Cells[9].Text = dt.Compute("sum([secondEur])", "1>0").ToString();
                    item.Cells[10].Text = dt.Compute("sum([thirdRmb])", "1>0").ToString();
                    item.Cells[11].Text = dt.Compute("sum([thirdUsd])", "1>0").ToString();
                    item.Cells[12].Text = dt.Compute("sum([thirdEur])", "1>0").ToString();
                    item.Cells[13].Text = "--";
                }
                else if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    if (item.Cells[1].Text == "&nbsp;")
                    {
                        item.Cells[0].Text = "&nbsp;";
                        item.Cells[14].Text = "&nbsp;";
                        item.Cells[15].Text = "&nbsp;";
                    }
                }
            }

            //修改及删除的条目变色
            if (step_id != 1 || editMode == true)
            {
                for (int i = 0; i < this.zjzcDatagrid.Items.Count; i++)
                {
                    if (this.zjzcDatagrid.Items[i].Cells[1].Text.Trim() != "&nbsp;")
                    {
                        if (Convert.ToInt32(this.zjzcDatagrid.Items[i].Cells[17].Text.Trim()) == 1)
                        {
                            this.zjzcDatagrid.Items[i].BackColor = System.Drawing.Color.Yellow;
                        }
                        else if (Convert.ToInt32(this.zjzcDatagrid.Items[i].Cells[17].Text.Trim()) == 2)
                        {
                            this.zjzcDatagrid.Items[i].BackColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }

        }

        private void bindModifyDataGrid()
        {
            DataTable dt = Stoke.Components.zjzc.getZjzcModifyDetail(doc_id);
            int rowCount = this.maDatagrid.PageSize;
            if (dt.Rows.Count != 0)
            {
                rowCount = this.zjzcDatagrid.PageSize - (dt.Rows.Count + this.zjzcDatagrid.PageSize) % this.zjzcDatagrid.PageSize;
            }

            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
            }

            this.maDatagrid.DataSource = dt;
            this.maDatagrid.DataBind();

            for (int i = 0; i < this.maDatagrid.Items.Count; i++)
            {
                if (this.maDatagrid.Items[i].Cells[1].Text == "&nbsp;")
                {
                    this.maDatagrid.Items[i].Cells[0].Text = "&nbsp;";
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
            this.b.SelectedIndexChanged += new System.EventHandler(this.b_SelectedIndexChanged);
            this.c.SelectedIndexChanged += new System.EventHandler(this.c_SelectedIndexChanged);
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.zjzcDatagrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.zjzcDatagrid_ItemCreated);
            this.zjzcDatagrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_ItemCommand);
            this.zjzcDatagrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.zjzcDatagrid_PageIndexChanged_1);
            this.zjzcDatagrid.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_CancelCommand);
            this.zjzcDatagrid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_EditCommand);
            this.zjzcDatagrid.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_UpdateCommand);
            this.zjzcDatagrid.SelectedIndexChanged += new System.EventHandler(this.zjzcDatagrid_SelectedIndexChanged);
            this.maDatagrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.maDatagrid_ItemCreated);
            this.maDatagrid.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_CancelCommand);
            this.maDatagrid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_EditCommand);
            this.maDatagrid.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_UpdateCommand);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void zjzcDatagrid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Pager:
                    {
                        if (this.mCreatePageTimes == 0)
                        {
                            DataGridItem row = (DataGridItem)e.Item;
                            row.Cells.Clear();

                            row.HorizontalAlign = HorizontalAlign.Center;

                            TableCell cell0 = new TableCell();
                            cell0.RowSpan = 2;
                            cell0.ColumnSpan = 1;
                            cell0.Text = "序号";
                            cell0.Width = Unit.Percentage(0.05);

                            TableCell cell1 = new TableCell();
                            cell1.RowSpan = 2;
                            cell1.ColumnSpan = 1;
                            cell1.Text = "产品名称或项目";
                            cell1.Width = Unit.Percentage(0.12);

                            TableCell cell2 = new TableCell();
                            cell2.RowSpan = 2;
                            cell2.ColumnSpan = 1;
                            cell2.Text = "设备/材料名称或业务内容";
                            cell2.Width = Unit.Percentage(0.12);

                            TableCell cell3 = new TableCell();
                            cell3.RowSpan = 2;
                            cell3.ColumnSpan = 1;
                            cell3.Text = "收款单位";
                            cell3.Width = Unit.Percentage(0.1);

                            int firstMonth = Convert.ToInt32(this.c.SelectedValue);
                            int secondMonth = (firstMonth + 1) > 12 ? firstMonth - 11 : firstMonth + 1;
                            int thirdMonth = (firstMonth + 2) > 12 ? firstMonth - 10 : firstMonth + 2;

                            TableCell cell4 = new TableCell();
                            cell4.ColumnSpan = 3;
                            cell4.Text = firstMonth + "月";
                            cell4.Width = Unit.Percentage(0.15);

                            TableCell cell5 = new TableCell();
                            cell5.ColumnSpan = 3;
                            cell5.Text = secondMonth + "月";
                            cell5.Width = Unit.Percentage(0.15);

                            TableCell cell6 = new TableCell();
                            cell6.ColumnSpan = 3;
                            cell6.Text = thirdMonth + "月";
                            cell6.Width = Unit.Percentage(0.15);

                            TableCell cell7 = new TableCell();
                            cell7.RowSpan = 2;
                            cell7.ColumnSpan = 1;
                            cell7.Text = "经办人";
                            cell7.Width = Unit.Percentage(0.1);

                            TableCell cell8 = new TableCell();
                            cell8.ColumnSpan = 2;
                            cell8.RowSpan = 2;
                            cell8.Text = "操作";
                            cell8.Width = Unit.Percentage(0.06);


                            row.Cells.Add(cell0);
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);
                            row.Cells.Add(cell4);
                            row.Cells.Add(cell5);
                            row.Cells.Add(cell6);
                            row.Cells.Add(cell7);
                            if (step_id != 0)
                                row.Cells.Add(cell8);

                        }

                        this.mCreatePageTimes = 1 - this.mCreatePageTimes;

                        break;
                    }
                case ListItemType.Header:
                    {
                        DataGridItem head = (DataGridItem)e.Item;
                        head.Cells.Clear();

                        head.HorizontalAlign = HorizontalAlign.Center;

                        TableCell cell01 = new TableCell();
                        cell01.Text = "人民币";
                        cell01.Width = Unit.Percentage(0.05);

                        TableCell cell02 = new TableCell();
                        cell02.Text = "美元";
                        cell02.Width = Unit.Percentage(0.05);

                        TableCell cell03 = new TableCell();
                        cell03.Text = "欧元";
                        cell03.Width = Unit.Percentage(0.05);

                        TableCell cell04 = new TableCell();
                        cell04.Text = "人民币";
                        cell04.Width = Unit.Percentage(0.05);

                        TableCell cell05 = new TableCell();
                        cell05.Text = "美元";
                        cell05.Width = Unit.Percentage(0.05);

                        TableCell cell06 = new TableCell();
                        cell06.Text = "欧元";
                        cell06.Width = Unit.Percentage(0.05);

                        TableCell cell07 = new TableCell();
                        cell07.Text = "人民币";
                        cell07.Width = Unit.Percentage(0.05);

                        TableCell cell08 = new TableCell();
                        cell08.Text = "美元";
                        cell08.Width = Unit.Percentage(0.05);

                        TableCell cell09 = new TableCell();
                        cell09.Text = "欧元";
                        cell09.Width = Unit.Percentage(0.05);

                        head.Cells.Add(cell01);
                        head.Cells.Add(cell02);
                        head.Cells.Add(cell03);
                        head.Cells.Add(cell04);
                        head.Cells.Add(cell05);
                        head.Cells.Add(cell06);
                        head.Cells.Add(cell07);
                        head.Cells.Add(cell08);
                        head.Cells.Add(cell09);

                        break;
                    }
                default:
                    e.Item.Cells[16].Visible = false;
                    e.Item.Cells[17].Visible = false;
                    break;
            }
        }

        private void zjzcDatagrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            this.zjzcDatagrid.EditItemIndex = index;
            this.BindDataGrid();

            TextBox tb1 = (TextBox)this.zjzcDatagrid.Items[index].Cells[4].Controls[0];
            tb1.Width = Unit.Pixel(80);
            TextBox tb2 = (TextBox)this.zjzcDatagrid.Items[index].Cells[5].Controls[0];
            tb2.Width = Unit.Pixel(80);
            TextBox tb3 = (TextBox)this.zjzcDatagrid.Items[index].Cells[6].Controls[0];
            tb3.Width = Unit.Pixel(80);
            TextBox tb4 = (TextBox)this.zjzcDatagrid.Items[index].Cells[7].Controls[0];
            tb4.Width = Unit.Pixel(80);
            TextBox tb5 = (TextBox)this.zjzcDatagrid.Items[index].Cells[8].Controls[0];
            tb5.Width = Unit.Pixel(80);
            TextBox tb6 = (TextBox)this.zjzcDatagrid.Items[index].Cells[9].Controls[0];
            tb6.Width = Unit.Pixel(80);
            TextBox tb7 = (TextBox)this.zjzcDatagrid.Items[index].Cells[10].Controls[0];
            tb7.Width = Unit.Pixel(80);
            TextBox tb8 = (TextBox)this.zjzcDatagrid.Items[index].Cells[11].Controls[0];
            tb8.Width = Unit.Pixel(80);
            TextBox tb9 = (TextBox)this.zjzcDatagrid.Items[index].Cells[12].Controls[0];
            tb9.Width = Unit.Pixel(80);

            //			TextBox txtCell1 = (TextBox)this.zjzcDatagrid.Items[index].Cells[1].Controls[0];
            //			TextBox txtCell2 = (TextBox)this.zjzcDatagrid.Items[index].Cells[2].Controls[0];
            //			TextBox txtCell3 = (TextBox)this.zjzcDatagrid.Items[index].Cells[3].Controls[0];
            //
            //			txtCell1.Enabled = false;
            //			txtCell2.Enabled = false;
            //			txtCell3.Enabled = false;
        }


        private void zjzcDatagrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.zjzcDatagrid.CurrentPageIndex = e.NewPageIndex;
        }

        private void zjzcDatagrid_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void c_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            foreach (DataGridItem item in this.zjzcDatagrid.Controls[0].Controls)
            {
                switch (item.ItemType)
                {
                    case ListItemType.Pager:
                        {
                            if (this.mCreatePageTimes == 0)
                            {
                                DataGridItem row = (DataGridItem)item;
                                row.Cells.Clear();

                                row.HorizontalAlign = HorizontalAlign.Center;

                                TableCell cell0 = new TableCell();
                                cell0.RowSpan = 2;
                                cell0.ColumnSpan = 1;
                                cell0.Text = "序号";
                                cell0.Width = Unit.Percentage(0.05);

                                TableCell cell1 = new TableCell();
                                cell1.RowSpan = 2;
                                cell1.ColumnSpan = 1;
                                cell1.Text = "产品名称或项目";
                                cell1.Width = Unit.Percentage(0.12);

                                TableCell cell2 = new TableCell();
                                cell2.RowSpan = 2;
                                cell2.ColumnSpan = 1;
                                cell2.Text = "设备/材料名称或业务内容";
                                cell2.Width = Unit.Percentage(0.12);

                                TableCell cell3 = new TableCell();
                                cell3.RowSpan = 2;
                                cell3.ColumnSpan = 1;
                                cell3.Text = "收款单位";
                                cell3.Width = Unit.Percentage(0.1);

                                int firstMonth = Convert.ToInt32(this.c.SelectedValue);
                                int secondMonth = (firstMonth + 1) > 12 ? firstMonth - 11 : firstMonth + 1;
                                int thirdMonth = (firstMonth + 2) > 12 ? firstMonth - 10 : firstMonth + 2;

                                this.d.Text = firstMonth + "月资金支出计划";
                                this.e.Text = secondMonth + "月资金支出计划";
                                this.f.Text = thirdMonth + "月资金支出计划";

                                TableCell cell4 = new TableCell();
                                cell4.ColumnSpan = 3;
                                cell4.Text = firstMonth + "月";
                                cell4.Width = Unit.Percentage(0.15);

                                TableCell cell5 = new TableCell();
                                cell5.ColumnSpan = 3;
                                cell5.Text = secondMonth + "月";
                                cell5.Width = Unit.Percentage(0.15);

                                TableCell cell6 = new TableCell();
                                cell6.ColumnSpan = 3;
                                cell6.Text = thirdMonth + "月";
                                cell6.Width = Unit.Percentage(0.15);

                                TableCell cell7 = new TableCell();
                                cell7.RowSpan = 2;
                                cell7.ColumnSpan = 1;
                                cell7.Text = "经办人";
                                cell7.Width = Unit.Percentage(0.1);

                                TableCell cell8 = new TableCell();
                                cell8.ColumnSpan = 2;
                                cell8.RowSpan = 2;
                                cell8.Text = "操作";
                                cell8.Width = Unit.Percentage(0.06);


                                row.Cells.Add(cell0);
                                row.Cells.Add(cell1);
                                row.Cells.Add(cell2);
                                row.Cells.Add(cell3);
                                row.Cells.Add(cell4);
                                row.Cells.Add(cell5);
                                row.Cells.Add(cell6);
                                row.Cells.Add(cell7);
                                row.Cells.Add(cell8);

                            }

                            this.mCreatePageTimes = 1 - this.mCreatePageTimes;
                            break;
                        }
                    case ListItemType.Header:
                        {
                            DataGridItem head = (DataGridItem)item;
                            head.Cells.Clear();

                            head.HorizontalAlign = HorizontalAlign.Center;

                            TableCell cell01 = new TableCell();
                            cell01.Text = "人民币";
                            cell01.Width = Unit.Percentage(0.05);

                            TableCell cell02 = new TableCell();
                            cell02.Text = "美元";
                            cell02.Width = Unit.Percentage(0.05);

                            TableCell cell03 = new TableCell();
                            cell03.Text = "欧元";
                            cell03.Width = Unit.Percentage(0.05);

                            TableCell cell04 = new TableCell();
                            cell04.Text = "人民币";
                            cell04.Width = Unit.Percentage(0.05);

                            TableCell cell05 = new TableCell();
                            cell05.Text = "美元";
                            cell05.Width = Unit.Percentage(0.05);

                            TableCell cell06 = new TableCell();
                            cell06.Text = "欧元";
                            cell06.Width = Unit.Percentage(0.05);

                            TableCell cell07 = new TableCell();
                            cell07.Text = "人民币";
                            cell07.Width = Unit.Percentage(0.05);

                            TableCell cell08 = new TableCell();
                            cell08.Text = "美元";
                            cell08.Width = Unit.Percentage(0.05);

                            TableCell cell09 = new TableCell();
                            cell09.Text = "欧元";
                            cell09.Width = Unit.Percentage(0.05);

                            head.Cells.Add(cell01);
                            head.Cells.Add(cell02);
                            head.Cells.Add(cell03);
                            head.Cells.Add(cell04);
                            head.Cells.Add(cell05);
                            head.Cells.Add(cell06);
                            head.Cells.Add(cell07);
                            head.Cells.Add(cell08);
                            head.Cells.Add(cell09);
                            break;
                        }
                }
            }
            BindDataGrid();
        }

        private void btnAddItem_Click(object sender, System.EventArgs e)
        {
            string bm_mc = this.a.SelectedValue.Trim();
            string month = this.b.SelectedValue + "-" + this.c.SelectedValue;
            string xm_mc = this.ddlXm.SelectedValue.Trim() == "0" ? bm_mc : this.ddlXm.SelectedItem.Text.Trim();
            string ywnr = this.txtYwmc.Text.Trim();
            string skdw = this.txtSkdw.Text.Trim();

            decimal firstRmb;
            decimal firstUsd;
            decimal firstEur;
            decimal secondRmb;
            decimal secondUsd;
            decimal secondEur;
            decimal thirdRmb;
            decimal thirdUsd;
            decimal thirdEur;
            string jbrZgbh = ry_zgbh;

            try
            {
                firstRmb = this.firstRmb.Text == string.Empty ? 0 : Convert.ToDecimal(this.firstRmb.Text.Trim());
                firstUsd = this.firstUsd.Text == string.Empty ? 0 : Convert.ToDecimal(this.firstUsd.Text.Trim());
                firstEur = this.firstEur.Text == string.Empty ? 0 : Convert.ToDecimal(this.firstEur.Text.Trim());
                secondRmb = this.secondRmb.Text == string.Empty ? 0 : Convert.ToDecimal(this.secondRmb.Text.Trim());
                secondUsd = this.secondUsd.Text == string.Empty ? 0 : Convert.ToDecimal(this.secondUsd.Text.Trim());
                secondEur = this.secondEur.Text == string.Empty ? 0 : Convert.ToDecimal(this.secondEur.Text.Trim());
                thirdRmb = this.thirdRmb.Text == string.Empty ? 0 : Convert.ToDecimal(this.thirdRmb.Text.Trim());
                thirdUsd = this.thirdUsd.Text == string.Empty ? 0 : Convert.ToDecimal(this.thirdUsd.Text.Trim());
                thirdEur = this.thirdEur.Text == string.Empty ? 0 : Convert.ToDecimal(this.thirdEur.Text.Trim());
            }
            catch
            {
                Response.Write("<script>alert('请检查您的输入！')</script>");
                this.BindDataGrid();
                return;
            }
            string jbrXm = this.jbrXmTxt.Text.Trim();

            if (jbrXm == string.Empty)
            {
                Response.Write("<script>alert('经办人不能为空！')</script>");
                this.BindDataGrid();
                return;
            }

            if (step_id == 1 && editMode == false)
            {
                dt_temp = (DataTable)Session["dt_temp"];
                DataRow row = dt_temp.NewRow();
                row["ID"] = dt_temp.Rows.Count + 1;
                row["xm_mc"] = xm_mc;
                row["content"] = ywnr;
                row["skdw"] = skdw;
                row["firstRmb"] = firstRmb;
                row["firstUsd"] = firstUsd;
                row["firstEur"] = firstEur;
                row["secondRmb"] = secondRmb;
                row["secondUsd"] = secondUsd;
                row["secondEur"] = secondEur;
                row["thirdRmb"] = thirdRmb;
                row["thirdUsd"] = thirdUsd;
                row["thirdEur"] = thirdEur;
                row["jbrXm"] = jbrXm;

                dt_temp.Rows.Add(row);
                Session["dt_temp"] = dt_temp;

            }
            else if (step_id == 1 && editMode == true)
            {
                Stoke.Components.zjzc.insertNewZjzcDetail(bm_mc, month, xm_mc, ywnr, skdw, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, jbrXm, doc_id);
            }
            //Stoke.Components.zjzc.insertNewZjzcDetail(bm_mc, month, xm_mc, ywnr, skdw, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, jbrZgbh);
            this.BindDataGrid();
        }

        private void b_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.BindDataGrid();
        }

        private void zjzcDatagrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            this.zjzcDatagrid.EditItemIndex = -1;
            this.BindDataGrid();
        }

        private void zjzcDatagrid_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {

            int index = e.Item.ItemIndex;
            //			for (int i = 0; i < 17; i++)
            //			{
            //				string temp = this.zjzcDatagrid.Items[index].Cells[i].Text.Trim();
            //			}
            int ID = Convert.ToInt32(this.zjzcDatagrid.Items[index].Cells[16].Text.Trim());

            TextBox cell4 = (TextBox)this.zjzcDatagrid.Items[index].Cells[4].Controls[0];
            TextBox cell5 = (TextBox)this.zjzcDatagrid.Items[index].Cells[5].Controls[0];
            TextBox cell6 = (TextBox)this.zjzcDatagrid.Items[index].Cells[6].Controls[0];
            TextBox cell7 = (TextBox)this.zjzcDatagrid.Items[index].Cells[7].Controls[0];
            TextBox cell8 = (TextBox)this.zjzcDatagrid.Items[index].Cells[8].Controls[0];
            TextBox cell9 = (TextBox)this.zjzcDatagrid.Items[index].Cells[9].Controls[0];
            TextBox cell10 = (TextBox)this.zjzcDatagrid.Items[index].Cells[10].Controls[0];
            TextBox cell11 = (TextBox)this.zjzcDatagrid.Items[index].Cells[11].Controls[0];
            TextBox cell12 = (TextBox)this.zjzcDatagrid.Items[index].Cells[12].Controls[0];

            decimal firstRmb = Convert.ToDecimal(cell4.Text.Trim());
            decimal firstUsd = Convert.ToDecimal(cell5.Text.Trim());
            decimal firstEur = Convert.ToDecimal(cell6.Text.Trim());
            decimal secondRmb = Convert.ToDecimal(cell7.Text.Trim());
            decimal secondUsd = Convert.ToDecimal(cell8.Text.Trim());
            decimal secondEur = Convert.ToDecimal(cell9.Text.Trim());
            decimal thirdRmb = Convert.ToDecimal(cell10.Text.Trim());
            decimal thirdUsd = Convert.ToDecimal(cell11.Text.Trim());
            decimal thirdEur = Convert.ToDecimal(cell12.Text.Trim());

            if (editMode == false)
            {
                //				Stoke.Components.zjzc.updateZjzcDetailByID(ID, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, ry_zgbh);
                dt_temp = (DataTable)Session["dt_temp"];
                for (int i = 0; i < dt_temp.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt_temp.Rows[i]["ID"]) == ID)
                    {
                        dt_temp.Rows[i]["firstRmb"] = firstRmb;
                        dt_temp.Rows[i]["firstUsd"] = firstUsd;
                        dt_temp.Rows[i]["firstEur"] = firstEur;
                        dt_temp.Rows[i]["secondRmb"] = secondRmb;
                        dt_temp.Rows[i]["secondUsd"] = secondUsd;
                        dt_temp.Rows[i]["secondEur"] = secondEur;
                        dt_temp.Rows[i]["thirdRmb"] = thirdRmb;
                        dt_temp.Rows[i]["thirdUsd"] = thirdUsd;
                        dt_temp.Rows[i]["thirdEur"] = thirdEur;
                    }
                }
                Session["dt_temp"] = dt_temp;
                this.zjzcDatagrid.EditItemIndex = -1;
                this.BindDataGrid();
            }
            else if (editMode == true && step_id == 1)
            {
                Stoke.Components.zjzc.updateZjzcDetailByID(ID, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, ry_zgbh);
                this.zjzcDatagrid.EditItemIndex = -1;
                this.BindDataGrid();
            }
            else
            {
                Stoke.Components.zjzc.annotateZjzcDetailByID(ID, 1, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, ry_zgbh);
                this.zjzcDatagrid.EditItemIndex = -1;
                this.BindDataGrid();
                this.bindModifyDataGrid();
            }

        }

        private void zjzcDatagrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            if (e.CommandName == "delete")
            {
                int ID = Convert.ToInt32(this.zjzcDatagrid.Items[index].Cells[16].Text.Trim());

                decimal firstRmb = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[4].Text.Trim());
                decimal firstUsd = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[5].Text.Trim());
                decimal firstEur = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[6].Text.Trim());
                decimal secondRmb = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[7].Text.Trim());
                decimal secondUsd = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[8].Text.Trim());
                decimal secondEur = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[9].Text.Trim());
                decimal thirdRmb = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[10].Text.Trim());
                decimal thirdUsd = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[11].Text.Trim());
                decimal thirdEur = Convert.ToDecimal(this.zjzcDatagrid.Items[index].Cells[12].Text.Trim());

                if (editMode == false)
                {
                    //					Stoke.Components.zjzc.deleteZjzcDetailByID(ID);
                    dt_temp = (DataTable)Session["dt_temp"];
                    for (int i = 0; i < dt_temp.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt_temp.Rows[i]["ID"]) == ID)
                        {
                            dt_temp.Rows.RemoveAt(i);
                        }
                    }
                    Session["dt_temp"] = dt_temp;

                    this.BindDataGrid();
                }
                else if (editMode == true && step_id == 1)
                {
                    Stoke.Components.zjzc.deleteZjzcDetailByID(ID);
                    this.BindDataGrid();
                }
                else
                {
                    Stoke.Components.zjzc.annotateZjzcDetailByID(ID, 2, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, ry_zgbh);
                    this.BindDataGrid();
                    this.bindModifyDataGrid();
                }
            }
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            int flag = 0;
            string zjzc_month = this.b.SelectedValue + "-" + this.c.SelectedValue;
            string bm_mc = a.SelectedValue.Trim();
            DataTable dt = Stoke.Components.zjzc.zjzcCheckSubmit(zjzc_month, bm_mc);
            flag = Convert.ToInt32(dt.Rows[0]["flag"]);
            if (flag > 0)
            {
                Response.Write("<script>alert('" + bm_mc + zjzc_month + "月资金支出计划已提交，不可重复提交！')</script>");
                this.BindDataGrid();
                this.bindModifyDataGrid();
                return;
            }
            SaveData();
            SaveZjzcDetail();
            string redirectUrl = "../Workflow/Work_Next_Step.aspx?flow_id=41&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + ry_zgbh.ToString();
            Response.Redirect(redirectUrl);
        }

        private void SaveZjzcDetail()
        {
            if (editMode == false)
            {
                dt_temp = (DataTable)Session["dt_temp"];
                for (int i = 0; i < dt_temp.Rows.Count; i++)
                {
                    string bm_mc = this.a.SelectedValue.Trim();
                    string month = this.b.SelectedValue + "-" + this.c.SelectedValue;
                    string xm_mc = dt_temp.Rows[i]["xm_mc"].ToString();
                    string ywnr = dt_temp.Rows[i]["content"].ToString();
                    string skdw = dt_temp.Rows[i]["skdw"].ToString();
                    decimal firstRmb = Convert.ToDecimal(dt_temp.Rows[i]["firstRmb"]);
                    decimal firstUsd = Convert.ToDecimal(dt_temp.Rows[i]["firstUsd"]);
                    decimal firstEur = Convert.ToDecimal(dt_temp.Rows[i]["firstEur"]);
                    decimal secondRmb = Convert.ToDecimal(dt_temp.Rows[i]["secondRmb"]);
                    decimal secondUsd = Convert.ToDecimal(dt_temp.Rows[i]["secondUsd"]);
                    decimal secondEur = Convert.ToDecimal(dt_temp.Rows[i]["secondEur"]);
                    decimal thirdRmb = Convert.ToDecimal(dt_temp.Rows[i]["thirdRmb"]);
                    decimal thirdUsd = Convert.ToDecimal(dt_temp.Rows[i]["thirdUsd"]);
                    decimal thirdEur = Convert.ToDecimal(dt_temp.Rows[i]["thirdEur"]);
                    string jbrZgbh = ry_zgbh;
                    string jbrXm = dt_temp.Rows[i]["jbrXm"].ToString().Trim();

                    Stoke.Components.zjzc.insertNewZjzcDetail(bm_mc, month, xm_mc, ywnr, skdw, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, jbrXm, doc_id);
                }
            }
            else
            {
                dt_temp = (DataTable)Session["dt_temp"];
                for (int i = 0; i < dt_temp.Rows.Count; i++)
                {
                    int ID = Convert.ToInt32(dt_temp.Rows[i]["ID"]);
                    decimal firstRmb = Convert.ToDecimal(dt_temp.Rows[i]["firstRmb"]);
                    decimal firstUsd = Convert.ToDecimal(dt_temp.Rows[i]["firstUsd"]);
                    decimal firstEur = Convert.ToDecimal(dt_temp.Rows[i]["firstEur"]);
                    decimal secondRmb = Convert.ToDecimal(dt_temp.Rows[i]["secondRmb"]);
                    decimal secondUsd = Convert.ToDecimal(dt_temp.Rows[i]["secondUsd"]);
                    decimal secondEur = Convert.ToDecimal(dt_temp.Rows[i]["secondEur"]);
                    decimal thirdRmb = Convert.ToDecimal(dt_temp.Rows[i]["thirdRmb"]);
                    decimal thirdUsd = Convert.ToDecimal(dt_temp.Rows[i]["thirdUsd"]);
                    decimal thirdEur = Convert.ToDecimal(dt_temp.Rows[i]["thirdEur"]);
                    string jbrZgbh = ry_zgbh;

                    Stoke.Components.zjzc.updateZjzcDetailByID(ID, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, ry_zgbh);//(bm_mc, month, xm_mc, ywnr, skdw, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, jbrZgbh, doc_id);
                }
            }
        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;

            if (editMode == false)
            {
                mySql = GetStyleInsertData();

                doc_id = df.AddDocument(ry_zgbh, flow_id, mySql, a.SelectedValue.Trim() + this.b.SelectedValue + "-" + this.c.SelectedValue + "资金支出计划");
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                df.UpdateDocument(mySql);
                df = null;
            }

        }
        private string GetStyleInsertData()
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            mySql += "insert into DSOC_Flow_Style_Data (";
            for (int i = 0; i < FieldNum; i++)
            {
                mySql += dt_step_field.Rows[i][0].ToString() + ",";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ") values(";
            for (int i = 0; i < FieldNum; i++)
            {
                string field_name = dt_step_field.Rows[i][0].ToString();
                string field_text = GetControlText(field_name);
                mySql += "'" + field_text.Replace("'", "''") + "',";
            }

            mySql = mySql.Substring(0, mySql.Length - 1) + ")";
            return mySql;
        }

        private string GetStyleUpdateData(int DocID)
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            if (FieldNum > 0)
            {
                mySql += "update DSOC_Flow_Style_Data set ";
                for (int i = 0; i < FieldNum; i++)
                {
                    string field_name = dt_step_field.Rows[i][0].ToString();
                    string field_text = GetControlText(field_name);
                    mySql += field_name + "=" + "'" + field_text.Replace("'", "''") + "'";
                    if (i != (FieldNum - 1))
                        mySql += ",";
                }
                mySql += " where Doc_ID = " + DocID.ToString();

                return mySql;
            }
            else
            {
                return "Select 1";
            }
        }

        private string GetControlText(string field_name)
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            StyleControl = FrmNewDocument.FindControl(field_name);
            switch (StyleControl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text.ToString();
                default:
                    return "";
            }
        }

        private void maDatagrid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Pager:
                    {
                        if (this.maCreatePageTimes == 0)
                        {
                            DataGridItem row = (DataGridItem)e.Item;
                            row.Cells.Clear();

                            row.HorizontalAlign = HorizontalAlign.Center;

                            TableCell cell0 = new TableCell();
                            cell0.RowSpan = 2;
                            cell0.Text = "序号";
                            cell0.Width = Unit.Percentage(0.05);

                            TableCell cell1 = new TableCell();
                            cell1.RowSpan = 2;
                            cell1.Text = "产品名称或项目";
                            cell1.Width = Unit.Percentage(0.12);

                            TableCell cell2 = new TableCell();
                            cell2.RowSpan = 2;
                            cell2.Text = "设备/材料名称或业务内容";
                            cell2.Width = Unit.Percentage(0.12);

                            TableCell cell3 = new TableCell();
                            cell3.RowSpan = 2;
                            cell3.Text = "收款单位";
                            cell3.Width = Unit.Percentage(0.1);

                            int firstMonth = Convert.ToInt32(this.c.SelectedValue);
                            int secondMonth = (firstMonth + 1) > 12 ? firstMonth - 11 : firstMonth + 1;
                            int thirdMonth = (firstMonth + 2) > 12 ? firstMonth - 10 : firstMonth + 2;

                            TableCell cell4 = new TableCell();
                            cell4.ColumnSpan = 3;
                            cell4.Text = firstMonth + "月";
                            cell4.Width = Unit.Percentage(0.15);

                            TableCell cell5 = new TableCell();
                            cell5.ColumnSpan = 3;
                            cell5.Text = secondMonth + "月";
                            cell5.Width = Unit.Percentage(0.15);

                            TableCell cell6 = new TableCell();
                            cell6.ColumnSpan = 3;
                            cell6.Text = thirdMonth + "月";
                            cell6.Width = Unit.Percentage(0.15);

                            TableCell cell7 = new TableCell();
                            cell7.RowSpan = 2;
                            cell7.Text = "类型";
                            cell7.Width = Unit.Percentage(0.06);

                            TableCell cell8 = new TableCell();
                            cell8.RowSpan = 2;
                            cell8.Text = "批示时间";
                            cell8.Width = Unit.Percentage(0.1);


                            row.Cells.Add(cell0);
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);
                            row.Cells.Add(cell4);
                            row.Cells.Add(cell5);
                            row.Cells.Add(cell6);
                            row.Cells.Add(cell7);
                            row.Cells.Add(cell8);

                        }

                        this.maCreatePageTimes = 1 - this.maCreatePageTimes;

                        break;
                    }
                case ListItemType.Header:
                    {
                        DataGridItem head = (DataGridItem)e.Item;
                        head.Cells.Clear();

                        head.HorizontalAlign = HorizontalAlign.Center;

                        TableCell cell01 = new TableCell();
                        cell01.Text = "人民币";
                        cell01.Width = Unit.Percentage(0.05);

                        TableCell cell02 = new TableCell();
                        cell02.Text = "美元";
                        cell02.Width = Unit.Percentage(0.05);

                        TableCell cell03 = new TableCell();
                        cell03.Text = "欧元";
                        cell03.Width = Unit.Percentage(0.05);

                        TableCell cell04 = new TableCell();
                        cell04.Text = "人民币";
                        cell04.Width = Unit.Percentage(0.05);

                        TableCell cell05 = new TableCell();
                        cell05.Text = "美元";
                        cell05.Width = Unit.Percentage(0.05);

                        TableCell cell06 = new TableCell();
                        cell06.Text = "欧元";
                        cell06.Width = Unit.Percentage(0.05);

                        TableCell cell07 = new TableCell();
                        cell07.Text = "人民币";
                        cell07.Width = Unit.Percentage(0.05);

                        TableCell cell08 = new TableCell();
                        cell08.Text = "美元";
                        cell08.Width = Unit.Percentage(0.05);

                        TableCell cell09 = new TableCell();
                        cell09.Text = "欧元";
                        cell09.Width = Unit.Percentage(0.05);

                        head.Cells.Add(cell01);
                        head.Cells.Add(cell02);
                        head.Cells.Add(cell03);
                        head.Cells.Add(cell04);
                        head.Cells.Add(cell05);
                        head.Cells.Add(cell06);
                        head.Cells.Add(cell07);
                        head.Cells.Add(cell08);
                        head.Cells.Add(cell09);

                        break;
                    }
                default:
                    e.Item.Cells[15].Visible = false;
                    break;
            }
        }

        private void btnReturn_Click(object sender, System.EventArgs e)
        {
            Stoke.Components.zjzc.updateZjzcSubmitFlag(doc_id, 1);
            string cmdText = "update dsoc_flow_document set Doc_Status = '0', step_id='1', Obj_ID = Doc_Builder_ID where doc_id = " + doc_id;
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect(ViewState["zjzcdetaibackUrl"].ToString());
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            //			Response.Redirect(ViewState["zjzcdetaibackUrl"].ToString());
            string returnDocID = Request.QueryString["returnDocID"];
            string returnStepID = Request.QueryString["returnStepID"];
            string returnZgbh = Request.QueryString["returnZgbh"];
            Response.Redirect("Style_zjzcjh_hz.aspx?step_id=" + returnStepID + "&doc_id=" + returnDocID + "&zgbh=" + returnZgbh);
        }

        private void zjzcDatagrid_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.zjzcDatagrid.CurrentPageIndex = e.NewPageIndex;
            this.BindDataGrid();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.ddlXm.SelectedIndex = 0;
            this.txtYwmc.Text = string.Empty;
            this.txtSkdw.Text = string.Empty;
            this.jbrXmTxt.Text = string.Empty;
            this.firstRmb.Text = string.Empty;
            this.firstUsd.Text = string.Empty;
            this.firstEur.Text = string.Empty;
            this.secondRmb.Text = string.Empty;
            this.secondUsd.Text = string.Empty;
            this.secondEur.Text = string.Empty;
            this.thirdRmb.Text = string.Empty;
            this.thirdUsd.Text = string.Empty;
            this.thirdEur.Text = string.Empty;

            this.BindDataGrid();
            this.bindModifyDataGrid();
        }

        protected void zjzcDatagrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            //zjzcDatagrid.Columns[16].Visible = false;
            //zjzcDatagrid.Columns[17].Visible = false;
        }
    }
}
