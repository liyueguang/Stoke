using System.Data.SqlClient;
using Stoke.BLL;
using Stoke.DAL;
using Stoke.COMMON;

namespace Stoke.COMMON
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;

    /// <summary>
    ///		SlctMember 的摘要说明。
    /// </summary>
    public class SlctMember : System.Web.UI.UserControl
    {
        protected System.Web.UI.WebControls.Button Button6;
        private string zgbh;
        protected System.Web.UI.HtmlControls.HtmlGenericControl FONT1;
        protected System.Web.UI.WebControls.ListBox LB_Select;
        protected System.Web.UI.WebControls.Button Button5;
        protected System.Web.UI.WebControls.Button Button4;
        protected System.Web.UI.WebControls.ListBox LB_All;
        protected System.Web.UI.WebControls.RadioButton RadioButton2;
        protected System.Web.UI.WebControls.RadioButton RadioButton1;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.DropDownList DropDownList1;
        protected System.Web.UI.WebControls.DropDownList DropDownList2;
        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.TextBox TextBox1;
        protected System.Web.UI.WebControls.ListBox FolderLb;
        protected System.Web.UI.WebControls.ListBox ContainRyLb;
        protected System.Web.UI.WebControls.Button submitBtn;
        protected System.Web.UI.WebControls.Button cancelBtn;
        protected System.Web.UI.HtmlControls.HtmlTable Table3;

        public string[] Send
        {
            get
            {
                string[] send = new string[3];
                send[0] = "";
                send[1] = "";
                int count = LB_Select.Items.Count;
                send[2] = count.ToString();
                if (0 != count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (0 == i)
                        {
                            send[0] += LB_Select.Items[i].Text.Trim();
                            send[1] += LB_Select.Items[i].Value.Trim();
                        }
                        else
                        {
                            send[0] += "," + LB_Select.Items[i].Text.Trim();
                            send[1] += "," + LB_Select.Items[i].Value.Trim();
                        }
                    }
                }
                return send;
            }
            set
            {
                string[] send = new string[2];
                send = value;
                char[] seprator = new char[1];
                seprator[0] = ',';
                string[] Send = send[0].Split(seprator, 10);
                string[] SendID = send[1].Split(seprator, 10);
                int count = Send.Length;
                for (int i = 0; i < count; i++)
                {
                    LB_Select.Items.Add(new ListItem(Send[i], SendID[i]));
                }
            }
        }
        public bool Flage
        {
            get
            {
                return flage;
            }
            set
            {
                flage = value;
            }
        }
        private bool flage;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (this.RadioButton1.Checked == true)
                this.Table3.Visible = true;
            else
                this.Table3.Visible = false;

            zgbh = Session["zgbh"].ToString();//  2009/09/

            if (!IsPostBack)
            {
                string sql = "select * from dsoc_bm";
                SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, sql);
                DropDownList1.DataSource = dr;
                DropDownList1.DataTextField = "bm_mc";
                DropDownList1.DataValueField = "bm_mc";
                DropDownList1.DataBind();
                dr.Close();

                sql = "select * from dsoc_zwjb";
                dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, sql);
                DropDownList2.DataSource = dr;
                DropDownList2.DataTextField = "zwjbmc";
                DropDownList2.DataValueField = "zwjb";
                DropDownList2.DataBind();
                dr.Close();

                sql = "select FolderName from dsoc_ry_favorites where zgbh='" + zgbh + "' and type=0";
                dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, sql);
                FolderLb.DataSource = dr;
                FolderLb.DataTextField = "FolderName";
                FolderLb.DataValueField = "FolderName";
                FolderLb.DataBind();
                this.FolderLb.Items.Insert(0, "--请选择--");
                this.FolderLb.SelectedIndex = 0;

                DropDownList1.Items.Insert(0, "全部");
                DropDownList1.SelectedIndex = 0;
                DropDownList2.Items.Insert(0, "全部");
                DropDownList2.SelectedIndex = 0;

            }

        }


        private void Done()
        {
            string _bm = DropDownList1.SelectedValue.ToString();
            string _zw = DropDownList2.SelectedValue.ToString();
            string sqlStr;
            if (_bm == "全部" && _zw == "全部")
                sqlStr = "select distinct dsoc_ry.ry_xm,dsoc_ry.ry_zgbh,ry_order_select from dsoc_ry,rs_staff where dsoc_ry.ry_zgbh=rs_staff.ry_zgbh order by ry_order_select,dsoc_ry.ry_zgbh asc";
            else if (_bm == "全部")
                sqlStr = "select distinct dsoc_ry.ry_xm,dsoc_ry.ry_zgbh,ry_order_select from dsoc_ry,rs_staff,v_dsoc_ry_zwjb where dsoc_ry.ry_zgbh=rs_staff.ry_zgbh and v_dsoc_ry_zwjb.ry_zgbh=dsoc_ry.ry_zgbh and zwjb = '" + _zw + "' order by ry_order_select,dsoc_ry.ry_zgbh asc";
            else if (_zw == "全部")
                sqlStr = "select distinct dsoc_ry.ry_xm,dsoc_ry.ry_zgbh,ry_order_select from dsoc_ry,rs_staff where dsoc_ry.ry_zgbh=rs_staff.ry_zgbh and ry_bm = '" + _bm + "'order by ry_order_select,dsoc_ry.ry_zgbh asc";
            else
                sqlStr = "select distinct dsoc_ry.ry_xm,dsoc_ry.ry_zgbh,ry_order_select from dsoc_ry,rs_staff,v_dsoc_ry_zwjb where dsoc_ry.ry_zgbh=rs_staff.ry_zgbh and v_dsoc_ry_zwjb.ry_zgbh=dsoc_ry.ry_zgbh and ry_bm = '" + _bm + "'and zwjb = '" + _zw + "' order by ry_order_select,dsoc_ry.ry_zgbh asc";
            SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, sqlStr);
            LB_All.DataSource = dr;
            LB_All.DataTextField = "ry_xm";
            LB_All.DataValueField = "ry_zgbh";
            LB_All.DataBind();
            dr.Close();

            if (LB_All.Items.Count != 0 && LB_Select.Items.Count != 0)
            {
                for (int i = 0; i < LB_All.Items.Count; i++)
                {
                    for (int j = 0; j < LB_Select.Items.Count; j++)
                    {
                        if (LB_All.Items[i].Text.ToString() == LB_Select.Items[j].Text.ToString())
                        {
                            LB_All.Items.Remove(LB_All.Items[i]);
                            i--;
                            break;
                        }
                    }
                }
            }
        }


        public void Clear()
        {
            this.DropDownList1.SelectedIndex = 0;
            this.DropDownList2.SelectedIndex = 0;
            this.LB_All.Items.Clear();
            this.LB_Select.Items.Clear();
            this.TextBox1.Text = string.Empty;

        }


        protected void submitBtn_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < ContainRyLb.Items.Count; i++)
            {
                if (ContainRyLb.Items[i].Selected == true)
                {
                    //选定职工列表为空与否
                    if (LB_Select.Items.Count != 0)
                    {
                        int tag = 0;//职工已存在于选定职工列表标志,0代表不存在，1代表已存在
                        for (int j = 0; j < LB_Select.Items.Count; j++)
                        {
                            if (ContainRyLb.Items[i].Value.Trim() == LB_Select.Items[j].Value.Trim())
                            {
                                tag = 1;
                                ContainRyLb.Items.Remove(ContainRyLb.Items[i]);
                                i--;
                                break;
                            }
                        }
                        if (tag == 0)
                        {
                            LB_Select.Items.Add(ContainRyLb.Items[i]);
                            ContainRyLb.Items.Remove(ContainRyLb.Items[i]);
                            i--;
                        }
                    }
                    else
                    {
                        LB_Select.Items.Add(ContainRyLb.Items[i]);
                        ContainRyLb.Items.Remove(ContainRyLb.Items[i]);
                        i--;
                    }
                }
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sqlStr;
            if (DropDownList1.SelectedItem.Text.ToString() == "全部")
                sqlStr = "select distinct ry_xm,ry_zgbh from dsoc_ry where ry_xm like '%" + this.TextBox1.Text.ToString().Trim() + "%'";
            else
                sqlStr = "select distinct * from dsoc_ry where ry_xm like '%" + this.TextBox1.Text.ToString().Trim() + "%' and ry_bm='" + DropDownList1.SelectedItem.Text.ToString() + "'";

            SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, sqlStr);
            LB_All.DataSource = dr;
            LB_All.DataTextField = "ry_xm";
            LB_All.DataValueField = "ry_zgbh";
            LB_All.DataBind();
            dr.Close();
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < LB_All.Items.Count; i++)
            {
                if (LB_All.Items[i].Selected == true)
                {
                    if (LB_Select.Items.Count != 0)
                    {
                        int tag = 0;
                        for (int j = 0; j < LB_Select.Items.Count; j++)
                        {
                            if (LB_All.Items[i].Value.Trim() == LB_Select.Items[j].Value.Trim())
                            {
                                tag = 1;
                                LB_All.Items.Remove(LB_All.Items[i]);
                                i--;
                                break;
                            }
                        }
                        if (tag == 0)
                        {
                            LB_Select.Items.Add(LB_All.Items[i]);
                            LB_All.Items.Remove(LB_All.Items[i]);
                            i--;
                        }
                    }
                    else
                    {
                        LB_Select.Items.Add(LB_All.Items[i]);
                        LB_All.Items.Remove(LB_All.Items[i]);
                        i--;
                    }
                }
            }
        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < LB_Select.Items.Count; i++)
            {
                if (LB_Select.Items[i].Selected == true)
                {
                    if (LB_All.Items.Count != 0)
                    {
                        int tag = 0;
                        for (int j = 0; j < LB_All.Items.Count; j++)
                        {
                            if (LB_Select.Items[i].Value.Trim() == LB_All.Items[j].Value.Trim())
                            {
                                tag = 1;
                                LB_Select.Items.Remove(LB_Select.Items[i]);
                                i--;
                                break;
                            }
                        }
                        if (tag == 0)
                        {
                            LB_All.Items.Add(LB_Select.Items[i]);
                            LB_Select.Items.Remove(LB_Select.Items[i]);
                            i--;
                        }
                    }
                    else
                    {
                        LB_All.Items.Add(LB_Select.Items[i]);
                        LB_Select.Items.Remove(LB_Select.Items[i]);
                        i--;
                    }
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Done();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Done();
        }

        protected void FolderLb_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string folderName = this.FolderLb.SelectedValue.ToString();
            string resultTemp = "";
            if (folderName == "")
                return;
            else
            {
                string strSql = "select ContainRybh from dsoc_ry_favorites where zgbh='" + zgbh + "' and FolderName='" + folderName + "' and type=0";
                SqlDataReader sdr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, strSql);
                if (sdr.Read())
                {
                    resultTemp = sdr.GetString(0);
                }
                string[] zgbhList = resultTemp.Split(';');
                DataTable result = new DataTable();
                result.Columns.Add("zgbh", typeof(string));
                result.Columns.Add("zgxm", typeof(string));
                for (int i = zgbhList.Length - 2; i >= 0; i--)
                {
                    string ryxm = "";
                    strSql = "select distinct ry_xm from dsoc_ry where ry_zgbh='" + zgbhList[i] + "'";
                    sdr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, strSql);
                    if (sdr.Read())
                    {
                        ryxm = sdr.GetString(0).Trim();
                    }
                    DataRow newRow = result.NewRow();
                    newRow["zgbh"] = zgbhList[i];
                    newRow["zgxm"] = ryxm;
                    result.Rows.Add(newRow);
                }
                ContainRyLb.DataSource = result;
                ContainRyLb.DataTextField = "zgxm";
                ContainRyLb.DataValueField = "zgbh";
                ContainRyLb.DataBind();
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked == true)
            {
                this.Table3.Visible = true;
            }
            else
            {
                this.Table3.Visible = false;
            }
        }

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        		/// <summary>
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}


    }
}
