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

namespace Stoke.USL.Workflow
{
    public partial class Work_Proc : System.Web.UI.Page
    {
        protected int _doc_id;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            _doc_id = Convert.ToInt32(Request.QueryString["doc_id"]);
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }
        void Bind()
        {
            Table tt = new Table();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            tt.Style.Add("font-size", "10pt");
            tt.Width = Unit.Percentage(100);
            tt.HorizontalAlign = HorizontalAlign.Center;

            string _flow_name = null;
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sql = "select distinct Flow_Name from dbo.Dsoc_Flow_Path,dbo.Dsoc_Flow where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Path.Flow_ID = dbo.Dsoc_Flow.Flow_ID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            _flow_name = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();

            AddRow(tt, _flow_name, Color.FromArgb(250, 250, 250));

            sql = "select distinct dbo.Dsoc_Flow_Path.Flow_ID,dbo.Dsoc_Flow_Path.Step_ID,Step_Name,dbo.Dsoc_Flow_Path.Staff_ID,ry_xm,Order_ID,Operator_Time,Dsoc_Flow_Path.StepName as Step,InvoledPerson from dbo.Dsoc_Flow_Path,dbo.Dsoc_Flow_Step,dbo.dsoc_ry where dbo.Dsoc_Flow_Path.Flow_ID = dbo.Dsoc_Flow_Step.Flow_ID and dbo.Dsoc_Flow_Path.Step_ID = dbo.Dsoc_Flow_Step.Step_ID and dbo.Dsoc_Flow_Path.Staff_ID = dbo.dsoc_ry.ry_zgbh and Doc_ID = '" + _doc_id + "' order by Order_ID";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            adapter.Fill(ds, "dt");
            DataTable dt = ds.Tables["dt"];
            conn.Close();


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                AddStep(tt, dt.Rows[i], i + 1);
                AddRow(tt, "<span lang='EN-US' style='font-size: 10.5pt; font-family: Wingdings'>��</span>", Color.FromArgb(250, 250, 250));

            }
            //Button btn1 = new Button();
            //btn1.Click += new EventHandler(btn1_Click);
            //btn1.Text = "����";
            //TableRow tr1 = new TableRow();
            //TableCell td1 = new TableCell();
            //td1.Controls.Add(btn1);
            //tr1.Cells.Add(td1);
            //tt.Rows.Add(tr1);
            //td1.HorizontalAlign = HorizontalAlign.Center;
            //td1.BackColor = Color.FromArgb(250, 250, 250);
            //AddRow(tt, "<a href='#' onclick='history.back();'>����</a>", Color.FromArgb(250, 250, 250));
            Page.Controls.AddAt(0, tt);
        }

        //void btn1_Click(object sender, EventArgs e)
        //{
        //    if (Request.QueryString["flag"] == "1")
        //        Response.Redirect("Work_Manage.aspx");
        //    else
        //        Response.Redirect("Work_Record.aspx");
        //}

        void AddRow(Table tab, string Label, string Caption)
        {

            TableRow tr = new TableRow();
            TableCell td1 = new TableCell();
            TableCell td2 = new TableCell();

            td1.Text = Label;
            td1.HorizontalAlign = HorizontalAlign.Right;
            td1.BackColor = Color.FromArgb(240, 240, 240);
            td1.Style.Add("width", "100px");
            td2.Text = Caption;
            td2.HorizontalAlign = HorizontalAlign.Left;
            td2.Style.Add("width", "300px");

            tr.Cells.Add(td1);
            tr.Cells.Add(td2);

            tab.Rows.Add(tr);

        }

        void AddRow(Table tab, string Label, string Caption, Color BackColor)
        {

            TableRow tr = new TableRow();
            TableCell td1 = new TableCell();
            TableCell td2 = new TableCell();

            td1.Text = Label;
            td1.HorizontalAlign = HorizontalAlign.Right;
            td1.BackColor = BackColor;

            td2.Text = Caption;
            td2.HorizontalAlign = HorizontalAlign.Left;
            td2.BackColor = BackColor;

            td1.Style.Add("width", "100px");
            td2.Style.Add("width", "300px");


            tr.Cells.Add(td1);
            tr.Cells.Add(td2);

            tab.Rows.Add(tr);

        }

        void AddRow(Table tab, string Label, Color BackColor)
        {

            TableRow tr = new TableRow();
            TableCell td = new TableCell();

            td.Text = Label;
            td.HorizontalAlign = HorizontalAlign.Center;
            //td.BackColor = BackColor;

            tr.Cells.Add(td);

            tab.Rows.Add(tr);

        }

        void AddStep(Table tab, DataRow dd, int Step)
        {
            Table tt = new Table();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            long top = 300 + 500 * Step;

            tt.HorizontalAlign = HorizontalAlign.Center;
            tt.Style.Add("left", "100px");
            tt.Style.Add("top", top.ToString() + "px");
            //tt.Style.Add("BORDER-COLLAPSE","collapse");
            tt.Style.Add("width", "400px");
            tt.Style.Add("font-size", "10pt");

            tt.BorderColor = Color.FromArgb(0, 0, 0);
            tt.BorderWidth = 1;

            AddRow(tt, "��" + Step.ToString() + "��", dd["Step_Name"].ToString(), Color.FromArgb(00, 255, 255));
            AddRow(tt, "������Ա", dd["ry_xm"].ToString(), Color.FromArgb(00, 255, 255));
            AddRow(tt, "����ʱ��", dd["Operator_Time"].ToString(), Color.FromArgb(00, 255, 255));
            AddRow(tt, "�²�����", dd["Step"].ToString(), Color.FromArgb(00, 255, 255));
            AddRow(tt, "�²��漰������Ա", dd["InvoledPerson"].ToString(), Color.FromArgb(00, 255, 255));
            tc.Controls.Add(tt);
            tr.Cells.Add(tc);
            tab.Rows.Add(tr);

        }

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            //this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        protected void btn1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["flag"] == "1")
                Response.Redirect("Work_Manage.aspx");
            else
                Response.Redirect("Work_Record.aspx");
        }
    }
}
