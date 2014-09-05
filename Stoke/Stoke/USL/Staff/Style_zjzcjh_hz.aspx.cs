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
    public partial class Style_zjzcjh_hz : System.Web.UI.Page
    {
        private DataTable dt_step_field;
        private int FieldNum = 0;
        private int flow_id = 42;
        private int step_id = 1;
        private int doc_id = 0;
        private bool editMode = false;
        private int mCreatePageTimes = 0;
        private int maCreatePageTimes = 0;
        private string ry_zgbh;
        private string ry_xm = "";


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
            {
                Stoke.Components.Staff _staff = new Stoke.Components.Staff();
                DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(ry_zgbh);
                if (dt_xm_bm.Rows.Count != 0)
                    ry_xm = dt_xm_bm.Rows[0][0].ToString();

                bindFormTop();

                if (editMode == true)
                {
                    Step_Handle_Data();
                }
                if (step_id == 1)
                {
                    this.d.Text = ry_xm;
                    this.e.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (step_id == 2)
                {
                    this.f.Text = ry_xm;
                    this.g.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (step_id == 3)
                {
                    this.h.Text = ry_xm;
                    this.i.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (step_id == 4)
                {
                    this.j.Text = ry_xm;
                    this.k.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }

                bindSubmitDatagrid();
                BindDataGrid();
                BindDataGrid1();
            }

            Field_Bind(dt_step_field);
        }

        private void bindFormTop()
        {
            int year = DateTime.Now.Year;
            this.b.Items.Add(Convert.ToString(year - 1));
            this.b.Items.Add(year.ToString());
            this.b.Items.Add(Convert.ToString(year + 1));
            this.b.SelectedValue = year.ToString();

            this.c.SelectedValue = DateTime.Now.Month.ToString("00");
        }

        private void bindSubmitDatagrid()
        {
            string month = b.SelectedValue + "-" + c.SelectedValue;
            DataTable dt = Stoke.Components.zjzc.getSubmitedBmByMonth(month);
            this.submitDatagrid.DataSource = dt;
            this.submitDatagrid.DataBind();
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            if (dt_style_data != null)
            {
                if (dt_style_data.Rows.Count != 0)
                {
                    this.b.Items.Clear();
                    this.b.Items.Add(dt_style_data.Rows[0]["b"].ToString());
                    this.b.DataBind();
                    this.c.Items.Clear();
                    int month = Convert.ToInt32(dt_style_data.Rows[0]["c"]);
                    this.c.Items.Add(new ListItem(month.ToString() + "-" + Convert.ToString((month + 2) > 12 ? month - 10 : month + 2), dt_style_data.Rows[0]["c"].ToString()));
                    this.c.DataBind();

                    this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
                    this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
                    this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
                    this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
                    this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
                    this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
                    this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
                    this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
                }
            }
        }

        private void BindDataGrid()
        {
            string month = this.b.SelectedValue + "-" + this.c.SelectedValue;
            DataTable dt = Stoke.Components.zjzc.getAllZjzcDetailByMonth(month);
            zjzcDatagrid.DataSource = dt;
            zjzcDatagrid.DataBind();

            foreach (DataGridItem item in this.zjzcDatagrid.Controls[0].Controls)
            {
                if (item.ItemType == ListItemType.Footer)
                {
                    item.Cells[1].Text = "合计";
                    item.Cells[2].Text = dt.Compute("sum([firstRmb])", "1>0").ToString();
                    item.Cells[3].Text = dt.Compute("sum([firstUsd])", "1>0").ToString();
                    item.Cells[4].Text = dt.Compute("sum([firstEur])", "1>0").ToString();
                    item.Cells[5].Text = dt.Compute("sum([secondRmb])", "1>0").ToString();
                    item.Cells[6].Text = dt.Compute("sum([secondUsd])", "1>0").ToString();
                    item.Cells[7].Text = dt.Compute("sum([secondEur])", "1>0").ToString();
                    item.Cells[8].Text = dt.Compute("sum([thirdRmb])", "1>0").ToString();
                    item.Cells[9].Text = dt.Compute("sum([thirdUsd])", "1>0").ToString();
                    item.Cells[10].Text = dt.Compute("sum([thirdEur])", "1>0").ToString();
                }
            }
        }

        private void BindDataGrid1()
        {
            string month = this.b.SelectedValue + "-" + this.c.SelectedValue;
            DataTable dt = Stoke.Components.zjzc.getAllZjzcDetailByMonth1(month);
            this.zjzcDatagrid1.DataSource = dt;
            this.zjzcDatagrid1.DataBind();

            foreach (DataGridItem item in this.zjzcDatagrid1.Controls[0].Controls)
            {
                if (item.ItemType == ListItemType.Footer)
                {
                    item.Cells[1].Text = "合计";
                    item.Cells[2].Text = dt.Compute("sum([firstRmb])", "1>0").ToString();
                    item.Cells[3].Text = dt.Compute("sum([firstUsd])", "1>0").ToString();
                    item.Cells[4].Text = dt.Compute("sum([firstEur])", "1>0").ToString();
                    item.Cells[5].Text = dt.Compute("sum([secondRmb])", "1>0").ToString();
                    item.Cells[6].Text = dt.Compute("sum([secondUsd])", "1>0").ToString();
                    item.Cells[7].Text = dt.Compute("sum([secondEur])", "1>0").ToString();
                    item.Cells[8].Text = dt.Compute("sum([thirdRmb])", "1>0").ToString();
                    item.Cells[9].Text = dt.Compute("sum([thirdUsd])", "1>0").ToString();
                    item.Cells[10].Text = dt.Compute("sum([thirdEur])", "1>0").ToString();
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
            this.zjzcDatagrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.zjzcDatagrid_ItemCreated);
            this.zjzcDatagrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_ItemCommand);
            this.zjzcDatagrid.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid_ItemCommand);
            this.zjzcDatagrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.zjzcDatagrid1_ItemCreated);
            this.zjzcDatagrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.zjzcDatagrid1_ItemCommand);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void b_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.BindDataGrid();
            this.BindDataGrid1();
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
                                cell0.Text = "序号";
                                cell0.Width = Unit.Percentage(0.07);

                                TableCell cell1 = new TableCell();
                                cell1.RowSpan = 2;
                                cell1.Text = "用款部门或项目组";
                                cell1.Width = Unit.Percentage(0.15);

                                int firstMonth = Convert.ToInt32(this.c.SelectedValue);
                                int secondMonth = (firstMonth + 1) > 12 ? firstMonth - 11 : firstMonth + 1;
                                int thirdMonth = (firstMonth + 2) > 12 ? firstMonth - 10 : firstMonth + 2;

                                TableCell cell4 = new TableCell();
                                cell4.ColumnSpan = 3;
                                cell4.Text = firstMonth + "月";
                                cell4.Width = Unit.Percentage(0.21);

                                TableCell cell5 = new TableCell();
                                cell5.ColumnSpan = 3;
                                cell5.Text = secondMonth + "月";
                                cell5.Width = Unit.Percentage(0.21);

                                TableCell cell6 = new TableCell();
                                cell6.ColumnSpan = 3;
                                cell6.Text = thirdMonth + "月";
                                cell6.Width = Unit.Percentage(0.21);

                                TableCell cell8 = new TableCell();
                                cell8.RowSpan = 2;
                                cell8.Text = "查看详情";
                                cell8.Width = Unit.Percentage(0.15);


                                row.Cells.Add(cell0);
                                row.Cells.Add(cell1);
                                row.Cells.Add(cell4);
                                row.Cells.Add(cell5);
                                row.Cells.Add(cell6);
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

            foreach (DataGridItem item in this.zjzcDatagrid1.Controls[0].Controls)
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
                                cell0.Text = "序号";
                                cell0.Width = Unit.Percentage(0.07);

                                TableCell cell1 = new TableCell();
                                cell1.RowSpan = 2;
                                cell1.Text = "产品名称或项目";
                                cell1.Width = Unit.Percentage(0.15);

                                int firstMonth = Convert.ToInt32(this.c.SelectedValue);
                                int secondMonth = (firstMonth + 1) > 12 ? firstMonth - 11 : firstMonth + 1;
                                int thirdMonth = (firstMonth + 2) > 12 ? firstMonth - 10 : firstMonth + 2;

                                TableCell cell4 = new TableCell();
                                cell4.ColumnSpan = 3;
                                cell4.Text = firstMonth + "月";
                                cell4.Width = Unit.Percentage(0.21);

                                TableCell cell5 = new TableCell();
                                cell5.ColumnSpan = 3;
                                cell5.Text = secondMonth + "月";
                                cell5.Width = Unit.Percentage(0.21);

                                TableCell cell6 = new TableCell();
                                cell6.ColumnSpan = 3;
                                cell6.Text = thirdMonth + "月";
                                cell6.Width = Unit.Percentage(0.21);

                                TableCell cell8 = new TableCell();
                                cell8.RowSpan = 2;
                                cell8.Text = "查看详情";
                                cell8.Width = Unit.Percentage(0.15);


                                row.Cells.Add(cell0);
                                row.Cells.Add(cell1);
                                row.Cells.Add(cell4);
                                row.Cells.Add(cell5);
                                row.Cells.Add(cell6);
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
            BindDataGrid1();
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
                            cell0.Text = "序号";
                            cell0.Width = Unit.Percentage(0.07);

                            TableCell cell1 = new TableCell();
                            cell1.RowSpan = 2;
                            cell1.Text = "用款部门或项目组";
                            cell1.Width = Unit.Percentage(0.15);

                            int firstMonth = Convert.ToInt32(this.c.SelectedValue);
                            int secondMonth = (firstMonth + 1) > 12 ? firstMonth - 11 : firstMonth + 1;
                            int thirdMonth = (firstMonth + 2) > 12 ? firstMonth - 10 : firstMonth + 2;

                            TableCell cell4 = new TableCell();
                            cell4.ColumnSpan = 3;
                            cell4.Text = firstMonth + "月";
                            cell4.Width = Unit.Percentage(0.21);

                            TableCell cell5 = new TableCell();
                            cell5.ColumnSpan = 3;
                            cell5.Text = secondMonth + "月";
                            cell5.Width = Unit.Percentage(0.21);

                            TableCell cell6 = new TableCell();
                            cell6.ColumnSpan = 3;
                            cell6.Text = thirdMonth + "月";
                            cell6.Width = Unit.Percentage(0.21);

                            TableCell cell8 = new TableCell();
                            cell8.RowSpan = 2;
                            cell8.Text = "查看详情";
                            cell8.Width = Unit.Percentage(0.15);


                            row.Cells.Add(cell0);
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell4);
                            row.Cells.Add(cell5);
                            row.Cells.Add(cell6);
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
                    e.Item.Cells[12].Visible = false;
                    break;
            }
        }

        private void zjzcDatagrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            if (e.CommandName == "detail")
            {
                string bm_mc = this.zjzcDatagrid.Items[index].Cells[1].Text.Trim();
                int doc_id = Convert.ToInt32(this.zjzcDatagrid.Items[index].Cells[12].Text.Trim());
                int returnFlag = 0;
                if (step_id == 1)
                    returnFlag = 1;

                string returnDocID = this.doc_id.ToString();
                string returnStepID = step_id.ToString();
                string returnZgbh = ry_zgbh;
                Response.Redirect("Style_zjzcjh.aspx?bm_mc=" + bm_mc + "&doc_id=" + doc_id + "&zgbh=" + ry_zgbh + "&step_id=-2&returnFlag=" + returnFlag.ToString() + "&returnDocID=" + returnDocID + "&returnStepID=" + returnStepID + "&returnZgbh=" + returnZgbh);
            }
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            SaveData();
            string redirectUrl = "../Workflow/Work_Next_Step.aspx?flow_id=42&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + ry_zgbh.ToString();
            Response.Redirect(redirectUrl);
        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;

            if (editMode == false)
            {
                mySql = GetStyleInsertData();

                doc_id = df.AddDocument(ry_zgbh, flow_id, mySql, this.b.SelectedValue + "-" + this.c.SelectedValue + "公司资金支出计划汇总");
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

        private void zjzcDatagrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
                            cell0.Width = Unit.Percentage(0.07);

                            TableCell cell1 = new TableCell();
                            cell1.RowSpan = 2;
                            cell1.Text = "产品名称或项目";
                            cell1.Width = Unit.Percentage(0.15);

                            int firstMonth = Convert.ToInt32(this.c.SelectedValue);
                            int secondMonth = (firstMonth + 1) > 12 ? firstMonth - 11 : firstMonth + 1;
                            int thirdMonth = (firstMonth + 2) > 12 ? firstMonth - 10 : firstMonth + 2;

                            TableCell cell4 = new TableCell();
                            cell4.ColumnSpan = 3;
                            cell4.Text = firstMonth + "月";
                            cell4.Width = Unit.Percentage(0.21);

                            TableCell cell5 = new TableCell();
                            cell5.ColumnSpan = 3;
                            cell5.Text = secondMonth + "月";
                            cell5.Width = Unit.Percentage(0.21);

                            TableCell cell6 = new TableCell();
                            cell6.ColumnSpan = 3;
                            cell6.Text = thirdMonth + "月";
                            cell6.Width = Unit.Percentage(0.21);

                            TableCell cell8 = new TableCell();
                            cell8.RowSpan = 2;
                            cell8.Text = "查看详情";
                            cell8.Width = Unit.Percentage(0.15);


                            row.Cells.Add(cell0);
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell4);
                            row.Cells.Add(cell5);
                            row.Cells.Add(cell6);
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
            }
        }

        private void zjzcDatagrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            if (e.CommandName == "detail")
            {
                string xm_mc = this.zjzcDatagrid1.Items[index].Cells[1].Text.Trim();
                string xm_bh = this.zjzcDatagrid1.Items[index].Cells[13].Text.Trim();
                string month = b.SelectedValue + "-" + c.SelectedValue;
                //int doc_id = Convert.ToInt32(this.zjzcDatagrid1.Items[index].Cells[12].Text.Trim());
                //int returnFlag = 0;
                //				if (step_id == 1)
                //					returnFlag = 1;
                Response.Redirect("Style_zjzcjh_xm_detail.aspx?xm_mc=" + xm_mc + "&xm_bh=" + xm_bh + "&month=" + month + "&step_id=" + step_id.ToString());// + month + "&zgbh=" + ry_zgbh + "&step_id=-2&returnFlag=" + returnFlag.ToString());
            }
        }
    }
}
