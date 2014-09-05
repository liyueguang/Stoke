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
            // �ڴ˴������û������Գ�ʼ��ҳ��
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

                //���������б����ݰ�
                sql = "select bm_mc,bm_bh from dbo.dsoc_bm";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                DepDdl.DataSource = dr;
                DepDdl.DataTextField = "bm_mc";
                DepDdl.DataValueField = "bm_bh";
                DepDdl.DataBind();

                this.DropDownList1.Items.Insert(0, "--��ѡ��--");
                this.DropDownList2.Items.Insert(0, "--��ѡ��--");
                this.DepDdl.Items.Insert(0, "--��ѡ��--");
                dr.Close();
                conn.Close();

                //���������ݰ�
                sql = "select Flow_ID from dbo.Dsoc_Flow where Remark = 1";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                conn.Close();
            }
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
            this.DepDdl.SelectedIndexChanged += new System.EventHandler(this.DepDdl_SelectedIndexChanged);
            this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
            this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
            this.RadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.CheckBox4.CheckedChanged += new System.EventHandler(this.CheckBox4_CheckedChanged);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


        //�޸İ�ť�������¼�
        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (this.RadioButtonList1.SelectedValue == string.Empty)//����Ϊ��
                Response.Write("<script> alert('��ѡ���������') </script>");
            else
            {
                if (this.DepDdl.SelectedIndex == 0)
                    Response.Write("<script> alert('��ѡ���������') </script>"); //����Ϊ��
                else
                {
                    foreach (ListItem li in CheckBoxList1.Items)//������ѡ���е���Ա��ɾ��dsoc_flow_member_bind�������и�ѡ������Ա�����ݣ�������flow_id,step_id,obj_id����ȣ���
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
                        if (li.Selected == true)//�жϸ�ѡ����ѡ�е���Ա�����ѡ�������һ���µ�����
                        {
                            string staff = li.Value.ToString();
                            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                            conn.Open();
                            string sql = "insert into dbo.Dsoc_Flow_Member_Bind (flow_id,step_id,obj_id) values ('" + this.DropDownList2.SelectedItem.Value.ToString() + "','" + this.RadioButtonList1.SelectedItem.Value.ToString() + "','" + li.Value + "')";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();// wy 20100721 �޸ĺ���ʾ��ɫ
                            li.Text = li.Text.IndexOf("font") == -1 ? "<font color=��red��>" + li.Text + "</font>" : li.Text.Replace("Black", "Red");
                        }

                    }
                    Response.Write("<script> alert('�޸ĳɹ���')</script>");

                }
            }
        }


        //��������б��ֵ�ı䴥���¼�
        private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.DropDownList2.Items.Clear();
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            conn.Open();
            if (this.DepDdl.SelectedIndex > 0)//�жϲ��ţ���Ա���Ƿ�ѡ��
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

            if (this.DropDownList1.SelectedIndex > 0)//������ǡ���ѡ��
            {
                // wy 20100717 ���ܶ���ͨ����Ԥ�㹫�ĳɱ����Ľ��в���
                string sql2 = "select flow_id,flow_name from dbo.dsoc_flow where Remark = 1 and  class_id = '" + DropDownList1.SelectedItem.Value.ToString() +"'";
                SqlDataAdapter dr2 = new SqlDataAdapter(sql2, conn);
                DataSet ds = new DataSet();
                dr2.Fill(ds, "result");
                DropDownList2.DataSource = ds.Tables["result"].DefaultView;
                DropDownList2.DataTextField = "flow_name";
                DropDownList2.DataValueField = "flow_id";
                DropDownList2.DataBind();
                dr2.Dispose();
                this.DropDownList2.Items.Insert(0, "--��ѡ��--");
            }
            else//����������ѡ��ʱ�����������б����"--��ѡ��--"'
            {
                this.DropDownList2.Items.Insert(0, "--��ѡ��--");
            }

            //���谴ť�б�����
            RadioButtonList1.DataSource = "";
            RadioButtonList1.DataTextField = "";
            RadioButtonList1.DataBind();
            conn.Close();

            //ȫѡ/ȫ��ѡ��ѡ�����
            CheckBox4.Checked = false;
        }


        //�����������б����¼�����
        private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            conn.Open();
            //ѡ��ÿ�������Ĳ��裬��������󶨵�RadioButtonList1�ؼ�

            if (this.DepDdl.SelectedIndex > 0)//�жϲ��ţ���Ա���Ƿ�ѡ��
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
                //wy ���ܲ�����һ����20100717
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
            {//�����������б�����ѡ����ѡ����ʱ��������գ�
                RadioButtonList1.DataSource = "";
                RadioButtonList1.DataTextField = "";
                RadioButtonList1.DataBind();
            }
            conn.Close();
            //ȫѡ/ȫ��ѡ��ѡ�����
            CheckBox4.Checked = false;
        }


        //ѡ���谴ť�����¼�
        private void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.CheckBoxList1.Visible = true;
            //������Ա�İ󶨣�
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
                //�ж���Ա�Ƿ��ڸ�ѡ���У�����ڣ���ѡ�����ϱ��
                foreach (ListItem li in this.CheckBoxList1.Items)
                {
                    if (dr.GetValue(0).ToString().Replace(" ", "") == li.Value.ToString().Replace(" ", ""))//ȥ��ry_id�ַ����еĿո�
                    {
                        li.Selected = true;
                        isxz++;
                        li.Text = li.Text.IndexOf("font") == -1 ? "<font color=��red��>" + li.Text + "</font>" : li.Text.Replace("Black", "Red");
                    }
                }
            }
            //			if(isxz==0) // wy 20100721 �������Ա���ܽ��в���
            //			{
            //				this.CheckBoxList1.Visible=false;
            //				Response.Write("<script> alert('�޿ɲ�����Ա��')</script>");
            //				return;
            //			}
            dr.Close();
            conn.Close();

            //ȫѡ/ȫ��ѡ��ѡ�����
            CheckBox4.Checked = false;
        }


        // ȫѡ/ȫ��ѡ
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



        //���������б����¼�
        private void DepDdl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string dept = DepDdl.SelectedItem.Text.ToString();
            //������Ա�İ󶨣�
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

            if (this.RadioButtonList1.SelectedIndex >= 0)//�жϾ��岽���Ƿ��Ѿ�ѡ��
            {
                sql = "select obj_id from [dbo].[Dsoc_Flow_Member_Bind] as mb where mb.flow_id = '" + DropDownList2.SelectedItem.Value.ToString() + "' and mb.step_id='" + this.RadioButtonList1.SelectedItem.Value.ToString() + "' and step_Id !=  '-1'";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //�ж���Ա�Ƿ��ڸ�ѡ���У�����ڣ���ѡ�����ϱ��
                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (dr.GetValue(0).ToString().Replace(" ", "") == li.Value.ToString().Replace(" ", ""))//ȥ��obj_id�ַ����Ŀո�
                            li.Selected = true;
                        if (li.Selected == true)
                            li.Text = li.Text.IndexOf("font") == -1 ? "<font color=��red��>" + li.Text + "</font>" : li.Text.Replace("Black", "Red"); ��������// wy ѡ�б���ɫ
                        if (li.Selected != true && dr.GetValue(0).ToString().Replace(" ", "") == li.Value.ToString().Replace(" ", ""))
                            li.Text = li.Text.IndexOf("font") == -1 ? "<font color=��Black��>" + li.Text + "</font>" : li.Text.Replace("red", "Black");
                    }

                }
                dr.Close();
            }
            conn.Close();
            //ȫѡ/ȫ��ѡ��ѡ�����
            CheckBox4.Checked = false;
        }
    }
}
