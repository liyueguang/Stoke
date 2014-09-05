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
    public partial class Work_RoleSet : System.Web.UI.Page
    {
        protected string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            _zgbh = Session["zgbh"].ToString();
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                conn.Open();
                string sql = "select class_name,class_id from dbo.dsoc_flow_class";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DropDownList1.DataSource = dr;
                DropDownList1.DataTextField = "class_name";
                DropDownList1.DataValueField = "class_id";
                DropDownList1.DataBind();
                dr.Close();

                //部门下拉列表数据绑定
                sql = "select bm_mc,bm_bh from dbo.dsoc_bm";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                DepDdl.DataSource = dr;
                DepDdl.DataTextField = "bm_mc";
                DepDdl.DataValueField = "bm_bh";
                DepDdl.DataBind();

                this.DropDownList1.Items.Insert(0, "--请选择--");
                this.DropDownList2.Items.Insert(0, "--请选择--");
                this.DepDdl.Items.Insert(0, "--请选择--");
                dr.Close();
                conn.Close();

                //工作流数据绑定
                sql = "select Flow_ID from dbo.Dsoc_Flow where Remark = 1";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                conn.Close();
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
            this.DepDdl.SelectedIndexChanged += new System.EventHandler(this.DepDdl_SelectedIndexChanged);
            this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
            this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
            this.RadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.CheckBox4.CheckedChanged += new System.EventHandler(this.CheckBox4_CheckedChanged);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


        //修改按钮触发的事件
        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (this.RadioButtonList1.SelectedValue == string.Empty)//部门为空
                Response.Write("<script> alert('请选择操作对象！') </script>");
            else
            {
                if (this.DepDdl.SelectedIndex == 0)
                    Response.Write("<script> alert('请选择操作对象！') </script>"); //步骤为空
                else
                {
                    foreach (ListItem li in CheckBoxList1.Items)//遍历复选框中的人员，删除dsoc_flow_member_bind表中所有复选框中人员的数据（条件是flow_id,step_id,obj_id都相等）；
                    {
                        SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                        conn.Open();
                        string sql = "delete from dbo.Dsoc_Flow_Member_Bind where Flow_ID='" + this.DropDownList2.SelectedItem.Value.ToString() + "' and step_id='" + this.RadioButtonList1.SelectedItem.Value.ToString() + "' and obj_id='" + li.Value.ToString() + "'";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (li.Selected == true)//判断复选框中选中的人员，如果选中则插入一条新的数据
                        {
                            string staff = li.Value.ToString();
                            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                            conn.Open();
                            string sql = "insert into dbo.Dsoc_Flow_Member_Bind (flow_id,step_id,obj_id) values ('" + this.DropDownList2.SelectedItem.Value.ToString() + "','" + this.RadioButtonList1.SelectedItem.Value.ToString() + "','" + li.Value + "')";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();// wy 20100721 修改后显示变色
                            li.Text = li.Text.IndexOf("font") == -1 ? "<font color=’red’>" + li.Text + "</font>" : li.Text.Replace("Black", "Red");
                        }

                    }
                    Response.Write("<script> alert('修改成功！')</script>");

                }
            }
        }


        //类别下拉列表框值改变触发事件
        private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.DropDownList2.Items.Clear();
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            conn.Open();
            if (this.DepDdl.SelectedIndex > 0)//判断部门（人员）是否选定
            {
                string sql = "select distinct ry_xm,ry_zgbh  from dbo.dsoc_ry where ry_bm ='" + DepDdl.SelectedItem.Text.ToString() + "' order by ry_zgbh";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                CheckBoxList1.DataSource = dr;
                CheckBoxList1.DataTextField = "ry_xm";
                CheckBoxList1.DataValueField = "ry_zgbh";
                CheckBoxList1.DataBind();
                dr.Close();
            }

            if (this.DropDownList1.SelectedIndex > 0)//如果不是“请选择”
            {
                // wy 20100717 不能对普通公文预算公文成本公文进行操作
                string sql2 = "select flow_id,flow_name from dbo.dsoc_flow where Remark = 1 and  class_id = '" + DropDownList1.SelectedItem.Value.ToString() +"'";
                SqlDataAdapter dr2 = new SqlDataAdapter(sql2, conn);
                DataSet ds = new DataSet();
                dr2.Fill(ds, "result");
                DropDownList2.DataSource = ds.Tables["result"].DefaultView;
                DropDownList2.DataTextField = "flow_name";
                DropDownList2.DataValueField = "flow_id";
                DropDownList2.DataBind();
                dr2.Dispose();
                this.DropDownList2.Items.Insert(0, "--请选择--");
            }
            else//如果点击“请选择时”，工作流列表插入"--请选择--"'
            {
                this.DropDownList2.Items.Insert(0, "--请选择--");
            }

            //步骤按钮列表框清空
            RadioButtonList1.DataSource = "";
            RadioButtonList1.DataTextField = "";
            RadioButtonList1.DataBind();
            conn.Close();

            //全选/全不选复选框清空
            CheckBox4.Checked = false;
        }


        //工作流下拉列表触发事件代码
        private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            conn.Open();
            //选择每个工作的步骤，并将步骤绑定到RadioButtonList1控件

            if (this.DepDdl.SelectedIndex > 0)//判断部门（人员）是否选定
            {
                string sql = "select distinct ry_xm,ry_zgbh  from dbo.dsoc_ry where ry_bm ='" + DepDdl.SelectedItem.Text.ToString() + "' order by ry_zgbh";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                CheckBoxList1.DataSource = dr;
                CheckBoxList1.DataTextField = "ry_xm";
                CheckBoxList1.DataValueField = "ry_zgbh";
                CheckBoxList1.DataBind();
                dr.Close();
            }

            if (this.DropDownList2.SelectedIndex > 0)
            {
                //wy 不能操作第一步　20100717
                string sql2 = "select step_id, step_name from dbo.dsoc_flow_step as st,dbo.dsoc_flow as f where f.flow_id = '" + DropDownList2.SelectedItem.Value.ToString() + "' and st.flow_id = f.flow_id and step_Id !=  '-1'and step_id !=1  order by step_id";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                RadioButtonList1.DataSource = dr2;
                RadioButtonList1.DataTextField = "step_name";
                RadioButtonList1.DataValueField = "step_id";
                RadioButtonList1.DataBind();
                dr2.Close();
            }
            else
            {//工作流下拉列表重新选择“请选择”项时，步骤清空；
                RadioButtonList1.DataSource = "";
                RadioButtonList1.DataTextField = "";
                RadioButtonList1.DataBind();
            }
            conn.Close();
            //全选/全不选复选框清空
            CheckBox4.Checked = false;
        }


        //选择步骤按钮触发事件
        private void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.CheckBoxList1.Visible = true;
            //部门人员的绑定；
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            conn.Open();
            string sql = "select distinct ry_xm,ry_zgbh  from dbo.dsoc_ry where ry_bm ='" + DepDdl.SelectedItem.Text.ToString() + "' order by ry_zgbh";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            CheckBoxList1.DataSource = dr;
            CheckBoxList1.DataTextField = "ry_xm";
            CheckBoxList1.DataValueField = "ry_zgbh";
            CheckBoxList1.DataBind();
            dr.Close();

            sql = "select obj_id from [dbo].[Dsoc_Flow_Member_Bind] as mb where mb.flow_id = '" + DropDownList2.SelectedItem.Value.ToString() + "' and mb.step_id='" + this.RadioButtonList1.SelectedItem.Value.ToString() + "' and step_Id !=  '-1'";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            int isxz = 0;
            while (dr.Read())
            {
                //判断人员是否在复选框中，如果在，则复选框做上标记
                foreach (ListItem li in this.CheckBoxList1.Items)
                {
                    if (dr.GetValue(0).ToString().Replace(" ", "") == li.Value.ToString().Replace(" ", ""))//去掉ry_id字符串中的空格
                    {
                        li.Selected = true;
                        isxz++;
                        li.Text = li.Text.IndexOf("font") == -1 ? "<font color=’red’>" + li.Text + "</font>" : li.Text.Replace("Black", "Red");
                    }
                }
            }
            //			if(isxz==0) // wy 20100721 无相关人员不能进行操作
            //			{
            //				this.CheckBoxList1.Visible=false;
            //				Response.Write("<script> alert('无可操作人员！')</script>");
            //				return;
            //			}
            dr.Close();
            conn.Close();

            //全选/全不选复选框清空
            CheckBox4.Checked = false;
        }


        // 全选/全不选
        private void CheckBox4_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.CheckBox4.Checked == true)
            {
                foreach (ListItem li in CheckBoxList1.Items)
                {
                    li.Selected = true;
                }
            }
            else
            {
                foreach (ListItem li in CheckBoxList1.Items)
                {
                    li.Selected = false;
                }
            }
        }



        //部门下拉列表触发事件
        private void DepDdl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string dept = DepDdl.SelectedItem.Text.ToString();
            //部门人员的绑定；
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            conn.Open();
            string sql = "select distinct ry_xm,ry_zgbh  from dbo.dsoc_ry where ry_bm ='" + dept + "' order by ry_zgbh";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            CheckBoxList1.DataSource = dr;
            CheckBoxList1.DataTextField = "ry_xm";
            CheckBoxList1.DataValueField = "ry_zgbh";
            CheckBoxList1.DataBind();
            dr.Close();

            if (this.RadioButtonList1.SelectedIndex >= 0)//判断具体步骤是否已经选中
            {
                sql = "select obj_id from [dbo].[Dsoc_Flow_Member_Bind] as mb where mb.flow_id = '" + DropDownList2.SelectedItem.Value.ToString() + "' and mb.step_id='" + this.RadioButtonList1.SelectedItem.Value.ToString() + "' and step_Id !=  '-1'";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //判断人员是否在复选框中，如果在，则复选框做上标记
                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (dr.GetValue(0).ToString().Replace(" ", "") == li.Value.ToString().Replace(" ", ""))//去掉obj_id字符串的空格
                            li.Selected = true;
                        if (li.Selected == true)
                            li.Text = li.Text.IndexOf("font") == -1 ? "<font color=’red’>" + li.Text + "</font>" : li.Text.Replace("Black", "Red"); 　　　　// wy 选中变颜色
                        if (li.Selected != true && dr.GetValue(0).ToString().Replace(" ", "") == li.Value.ToString().Replace(" ", ""))
                            li.Text = li.Text.IndexOf("font") == -1 ? "<font color=’Black’>" + li.Text + "</font>" : li.Text.Replace("red", "Black");
                    }

                }
                dr.Close();
            }
            conn.Close();
            //全选/全不选复选框清空
            CheckBox4.Checked = false;
        }
    }
}
