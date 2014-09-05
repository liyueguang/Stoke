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
    public partial class Work_Next_Step : System.Web.UI.Page
    {
        protected string obj_zgbh;
        protected string _next_step;
        protected string _flow_id;
        protected string _step_id;
        protected string _doc_id;
        protected string _zgbh;
        protected string _step_remark;
        protected int count = 0;
        protected string _remark;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["zgbh"] != null)//09/08/09 wy
                _zgbh = Request["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");//

            _flow_id = Request["flow_id"].ToString();
            _step_id = Request["step_id"].ToString();
            _doc_id = Request["doc_id"].ToString();
            obj_zgbh = this.labObjZgbh.Text;

            if (!IsPostBack)
            {
                this.returnTr.Visible = false;
                string connString = SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                string sqlStr = "select * from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int _remark = 0;
                if (dr.Read())
                    _remark = Convert.ToInt32(dr["step_remark"]);
                dr.Close();
                conn.Close();
                if (_remark == 1 || _remark == 3) //添加部门自动绑定的会签处理问题-------ws/20100712
                {
                    sqlStr = "select Obj_ID,IsRunning,Obj_Type from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
                    cmd = new SqlCommand(sqlStr, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    string _obj_id = null;
                    int _isrunning = 0;
                    string _obj_type = null;
                    if (dr.Read())
                    {
                        _obj_id = dr["Obj_ID"].ToString();
                        _isrunning = Convert.ToInt32(dr["IsRunning"]);
                        _obj_type = dr["Obj_Type"].ToString();
                    }
                    dr.Close();
                    conn.Close();
                    _isrunning--;
                    if (_isrunning != 0)
                    {
                        int position = _obj_id.IndexOf(_zgbh.Trim());
                        string temp = null;
                        if (position + 4 != _obj_id.Length)
                            temp = _obj_id.Substring(0, position) + _obj_id.Substring(position + 5);
                        else
                            temp = _obj_id.Substring(0, position - 1);
                        sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = '" + _isrunning + "', Obj_ID = '" + temp + "' where Doc_ID = '" + _doc_id + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        sqlStr = "select Step_Next from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        string _sn = null;
                        _sn = cmd.ExecuteScalar().ToString();
                        conn.Close();
                        sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = 0,Step_ID = '" + _sn + "',Obj_ID = '" + _obj_type + "',Obj_Type = null where Doc_ID = '" + _doc_id + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    SaveProc();
                    Response.Redirect("Work_Manage.aspx?zgbh=" + _zgbh);
                }
                else
                {
                    conn.Open();
                    sqlStr = "select * from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
                    cmd = new SqlCommand(sqlStr, conn);
                    dr = cmd.ExecuteReader();
                    string _step_next = null;
                    if (dr.Read())
                        _step_next = dr["Step_Next"].ToString();
                    dr.Close();
                    conn.Close();
                    if (_step_next.Length != 0)
                    {
                        string temp = null;
                        for (int i = 0; i < _step_next.Length; i++)
                        {
                            if (_step_next[i] != ';')
                                temp += _step_next[i];
                            else
                            {
                                if (temp == "-1")
                                {
                                    ListItem tmplist = new ListItem("结束", "-1");
                                    RadioButtonList1.Items.Add(tmplist);
                                }
                                else
                                {
                                    oper(temp);

                                }
                                temp = null;//20090606 wy 绑定步骤后清空
                            }
                        }
                        if (temp != null)
                        {
                            if (temp == "-1")
                            {
                                ListItem tmplist = new ListItem("结束", "-1");
                                RadioButtonList1.Items.Add(tmplist);
                            }
                            else
                                oper(temp);
                        }


                    }
                }
            }
        }

        protected void oper(string temp)
        {
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "select Step_Name from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + temp + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string _next_step_name = null;
            if (dr.Read())
                _next_step_name = dr["Step_Name"].ToString();
            if (Convert.ToInt32(temp) < Convert.ToInt32(_step_id))
                _next_step_name = "退回" + _next_step_name;
            dr.Close();
            conn.Close();
            ListItem tmplist = new ListItem(_next_step_name, temp);
            RadioButtonList1.Items.Add(tmplist);
        }

        private void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {


        }

        private void Button2_Click(object sender, System.EventArgs e)
        {

        }

        private void Button1_Click(object sender, System.EventArgs e)
        {

        }

        #region 校验
        protected bool verify(string _temp)
        {
            for (int i = 0; i < _temp.Split(',').Length; i++)
            {
                for (int j = i + 1; j < _temp.Split(',').Length; j++)
                {
                    if (_temp.Split(',')[i] == _temp.Split(',')[j])
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region 处理签收
        protected void sign()
        {
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select Obj_ID,IsRunning,Obj_Type from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string _obj_id = null;
            int _isrunning = 0;
            if (dr.Read())
            {
                _obj_id = dr["Obj_ID"].ToString();
                _isrunning = Convert.ToInt32(dr["IsRunning"]);
            }

            _obj_id += ","; //09/08/09 

            dr.Close();
            conn.Close();
            _isrunning--;
            if (_isrunning != 0)
            {
                //				int position = _obj_id.IndexOf(_zgbh);
                string temp = null;

                //09/08/09
                temp = _obj_id.Replace(_zgbh.Trim() + ",", string.Empty);
                if (temp.Length > 0)
                    temp = temp.Remove(temp.Length - 1, 1);
                //

                //				if(position+4 != _obj_id.Length)
                //					temp = _obj_id.Substring(0,position)+_obj_id.Substring(position+5);
                //				else
                //					temp = _obj_id.Substring(0,position-1);
                sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = '" + _isrunning + "', Obj_ID = '" + temp + "' where Doc_ID = '" + _doc_id + "'";
                cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = 0,Step_ID = -1,Obj_ID = null,Doc_Status = 1 where Doc_ID = '" + _doc_id + "'";
                cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
        #endregion

        #region 处理
        protected void js()
        {
            _next_step = RadioButtonList1.SelectedItem.Value.ToString();
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select * from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                _remark = dr["step_remark"].ToString();
            dr.Close();
            conn.Close();
            sqlStr = "select Step_Remark from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _next_step + "' ";
            cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            _step_remark = cmd.ExecuteScalar().ToString();
            conn.Close();

        }
        #endregion

        private void SaveProc()
        {
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string involedPerson = this.obj.Text.Trim();
            string step_name = "会签处理";
            if (this.RadioButtonList1.Items.Count != 0)
                step_name = this.RadioButtonList1.SelectedItem.Text.ToString().Trim();
            string sqlStr = "select count(Order_ID) from dbo.Dsoc_Flow_Path where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar());
            temp++;
            sqlStr = "insert into Dsoc_Flow_Path values ('" + _doc_id + "', '" + _flow_id + "','" + _step_id + "','" + _zgbh + "','" + temp + "','" + System.DateTime.Now.ToString() + "','" + step_name + "','" + involedPerson + "')";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //解决选人时静态变量问题 09/5/4   wy
            js();
            /*------------satrt-------------ws/20100704/出差申请根据部门进行相应部门负责人会签-------------------------------start-------------------*/
            if (_step_remark == "0" || _step_remark == "3" || _step_remark == "4")
            {
                if (this.LB_All.Visible == false)//解决绩效考核选人添加 09/5/22  wy
                {
                    obj.Text = SlctMember1.Send[0].ToString();
                    //				obj_zgbh = SlctMember1.Send[1].ToString();
                    this.labObjZgbh.Text = SlctMember1.Send[1].ToString();
                    count = Convert.ToInt32(SlctMember1.Send[2]);
                }
                else
                {
                    obj.Text = string.Empty;
                    this.labObjZgbh.Text = string.Empty;//防治为空时候添加错误的职工编号
                    for (int i = 0; i < this.LB_All.Items.Count; i++)
                        if (this.LB_All.Items[i].Selected)
                        {

                            obj.Text += LB_All.Items[i].Text.ToString().Trim() + ",";
                            this.labObjZgbh.Text += LB_All.Items[i].Value.ToString() + ",";
                        }
                    obj.Text = obj.Text.ToString().Substring(0, obj.Text.ToString().Length - 1);
                    this.labObjZgbh.Text = this.labObjZgbh.Text.ToString().Substring(0, this.labObjZgbh.Text.ToString().Length - 1);
                }
            }
            /*------------end-------------ws/20100704/出差申请根据部门进行相应部门负责人会签-------------------------------end-------------------*/
            else
            {
                obj.Text = SlctMember1.Send[0].ToString();
                //				obj_zgbh = SlctMember1.Send[1].ToString();
                this.labObjZgbh.Text = SlctMember1.Send[1].ToString();
                count = Convert.ToInt32(SlctMember1.Send[2]);
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == -1)
            {
                CommHandler.Alert(Page, "请选择下一步骤！"); //Response.Write("<script type='text/javascript'>alert('请选择下一步骤！')</script>");
                return;
            }
                //

            _next_step = RadioButtonList1.SelectedItem.Value.ToString();
            if (this.labObjZgbh.Text == "无" && this.obj.Text == "无" && this.obj_zgbh == "无" && this._next_step != "-1")
            {
                Response.Write("<script>alert('请选择下一步人员！');</script>");
                return;
            }

            
            js();
            if (_step_remark == "0")
            {
                if (_next_step != "-1")
                {
                    if (obj.Text != "无" && obj.Text != string.Empty)
                    {
                        string connString = SQLHelper.CONN_STRING;
                        SqlConnection conn = new SqlConnection(connString);
                        conn.Open();

                        string sqlStr;
                        if (Convert.ToInt32(_flow_id) == 45 && Convert.ToInt32(_step_id) == 6)//出差申请及借款hhw20101101
                        {
                            sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = '" + obj_zgbh + "' where Doc_ID = '" + _doc_id + "' AND doc_builder_id!=obj_id";
                        }
                        else
                        {
                            sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = '" + obj_zgbh + "' where Doc_ID = '" + _doc_id + "'";
                        }
                        SqlCommand cmd = new SqlCommand(sqlStr, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        SaveProc();
                        Response.Redirect("Work_Manage.aspx?zgbh=" + _zgbh);
                    }
                    else
                        CommHandler.Alert(Page, "请选择下一步人员");
                }
                else
                {
                    if (_remark == "2")
                        sign();
                    else
                    {
                        string connString = SQLHelper.CONN_STRING;
                        SqlConnection conn = new SqlConnection(connString);
                        conn.Open();
                        string sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = null,Doc_status = 1 where Doc_ID = '" + _doc_id + "'";
                        SqlCommand cmd = new SqlCommand(sqlStr, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    SaveProc();
                    if (_next_step == "-1")
                    {
                        Stoke.BLL.Utility.FinishStaff(_doc_id, _flow_id);
                    }
                    //wyw 王永伟，流程跳转本页面，留待改进
                    if (_flow_id == "4")
                        Response.Redirect("../Staff/style_qjsp.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "5")
                        Response.Redirect("../Staff/style_xjsp.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "6")
                        Response.Redirect("../Staff/style_ygdlsp.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "7")
                        Response.Redirect("../Staff/style_ygddsp2.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "8")
                        Response.Redirect("../Staff/style_rzsx.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "9")
                        Response.Redirect("../Staff/style_zyzbsp.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "10")
                        Response.Redirect("../Staff/style_qzsp2.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "35")
                        Response.Redirect("../Staff/style_rstzd.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "36")
                        Response.Redirect("../Staff/style_gljsljxkh.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "37")
                        Response.Redirect("../Staff/style_jxkhcz.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "39")
                        Response.Redirect("../Staff/style_gljsljxkh1.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    else if (_flow_id == "41")		//王旭添加，资金支出计划
                    {
                        Response.Redirect("../Staff/style_zjzcjh.aspx?zgbh=" + _zgbh + "&doc_id=" + _doc_id + "&step_id=" + _next_step);
                    }
                    else if (_flow_id == "18")
                    {
                        if (Stoke.BLL.Utility.GetItemChoice(Convert.ToInt32(_doc_id)) != 0)
                            Response.Redirect("../Disclosure/NewReport.aspx?doc_id=" + _doc_id);
                        else
                        {
                            Response.Redirect("Work_Manage.aspx?zgbh=" + _zgbh);
                        }
                    }
                    else
                        Response.Redirect("Work_Manage.aspx?zgbh=" + _zgbh);
                }
            }
            else if (_step_remark == "2")
            {
                if (_next_step != "-1")
                {
                    string _obj_zgbh = SlctMember1.Send[1].ToString();
                    if (obj.Text.ToString() == "无")
                        Response.Write("<script>alert('请选择人员!')</script>");
                    else
                    {
                        if (_remark == "0")
                        {
                            int _count_temp = _obj_zgbh.Split(',').Length;
                            string connString = SQLHelper.CONN_STRING;
                            SqlConnection conn = new SqlConnection(connString);
                            conn.Open();
                            string sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',IsRunning = '" + _count_temp + "',Obj_ID = '" + obj_zgbh + "' where Doc_ID = '" + _doc_id + "'";
                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        else if (_remark == "2")
                        {
                            string connString = SQLHelper.CONN_STRING;
                            SqlConnection conn = new SqlConnection(connString);
                            string sqlStr = "select Obj_ID,IsRunning from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            string _obj_id = null;
                            int _count_temp = 0;
                            if (dr.Read())
                            {
                                _obj_id = dr["Obj_ID"].ToString();
                                _count_temp = Convert.ToInt32(dr["IsRunning"]);
                            }
                            dr.Close();
                            conn.Close();
                            _obj_id += "," + _obj_zgbh;
                            _count_temp += _obj_zgbh.Split(',').Length;
                            sqlStr = "update dbo.Dsoc_Flow_Document set Step_id = '" + _next_step + "',Obj_ID = '" + _obj_id + "',IsRunning = '" + _count_temp + "' where Doc_ID =  '" + _doc_id + "'";
                            cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            sign();
                        }
                        SaveProc();
                        Response.Redirect("Work_Manage.aspx?zgbh=" + _zgbh);
                    }
                }
                else
                {
                    string connString = SQLHelper.CONN_STRING;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + _next_step + "',Obj_ID = null,Doc_status = 1 where Doc_ID = '" + _doc_id + "'";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    SaveProc();
                    if (_next_step == "-1")
                    {
                        Stoke.BLL.Utility.FinishStaff(_doc_id, _flow_id);
                    }
                    Response.Redirect("Work_Manage.aspx?zgbh=" + _zgbh);
                }
            }
            else
            {
                int count = 0;
                if (_step_remark == "3")//hhw20101103,解决生产管理部多个部门和项目负责人会签，如果没有全部选择会签人则出现不能返回到会签发起人的问题
                    count = Convert.ToInt32(this.labObjZgbh.Text.ToString().Split(',').GetLength(0));
                else
                {
                    if (_step_remark == "1")
                        count = Convert.ToInt32(SlctMember1.Send[2]);
                    else
                        count = this.LB_All.Items.Count;
                }
                string connString = SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string _obj_type = _zgbh;
                string sqlStr = "update dbo.Dsoc_Flow_Document set Step_ID = '" + _next_step + "',IsRunning = '" + count + "',Obj_ID='" + obj_zgbh + "',Obj_Type = '" + _obj_type + "' where Doc_ID = '" + _doc_id + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                SaveProc();
                if (_next_step == "-1")
                {
                    Stoke.BLL.Utility.FinishStaff(_doc_id, _flow_id);
                }
                Response.Redirect("Work_Manage.aspx?zgbh=" + _zgbh);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            _next_step = RadioButtonList1.SelectedItem.Value.ToString();
            obj.Text = "无";
            if (_next_step != "-1")
            {
                if (fieldset2.Visible == false)
                    fieldset2.Visible = true;
                string connString = SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                string sqlStr = "select Step_Remark from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _next_step + "' ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                _step_remark = cmd.ExecuteScalar().ToString();
                conn.Close();
                if (_next_step == "1")
                {
                    if (SlctMember1.Visible == true)
                    {
                        SlctMember1.Visible = false;
                        LB_All.Visible = true;
                    }
                    SlctMember1.Visible = false;
                    LB_All.Visible = true;
                    connString = SQLHelper.CONN_STRING;
                    conn = new SqlConnection(connString);
                    conn.Open();
                    sqlStr = "select distinct dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                    cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    LB_All.DataSource = dr;
                    LB_All.DataTextField = "ry_xm";
                    LB_All.DataValueField = "Doc_Builder_ID";
                    LB_All.DataBind();
                    LB_All.SelectedIndex = 0;
                    dr.Close();
                    conn.Close();
                }
                else
                {
                    if (_step_remark == "0")
                    {
                        if (SlctMember1.Visible == true)
                        {
                            SlctMember1.Visible = false;
                            LB_All.Visible = true;
                        }
                        sqlStr = "select Dsoc_Flow_Member_Bind.Obj_ID from Dsoc_Flow_Member_Bind where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "'";
                        cmd = new SqlCommand(sqlStr, conn);
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        string _reyuan = null;
                        if (dr.Read())
                            _reyuan = dr["Obj_ID"].ToString();
                        dr.Close();
                        conn.Close();
                        if (_reyuan == "builder")
                        {
                            sqlStr = "select distinct dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                            cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            dr = cmd.ExecuteReader();
                            LB_All.DataSource = dr;
                            LB_All.DataTextField = "ry_xm";
                            LB_All.DataValueField = "Doc_Builder_ID";
                            LB_All.DataBind();
                            LB_All.SelectedIndex = 0;
                            dr.Close();
                            conn.Close();
                        }
                        else if (_reyuan == "selector")//绩效考核选人09.5.22
                        {
                            if (SlctMember1.Visible == false)
                            {
                                SlctMember1.Visible = true;
                                LB_All.Visible = false;
                            }

                        }
                        else
                        {
                            sqlStr = "select dbo.Dsoc_Flow_Step.Flow_Rule from dbo.Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _next_step + "'";
                            cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            dr = cmd.ExecuteReader();
                            string _rule = null;
                            if (dr.Read())
                                _rule = dr["Flow_Rule"].ToString();
                            dr.Close();
                            conn.Close();
                            if (_rule == "1")
                            {
                                //通用流程退回时选择拟稿人的部门负责人 09/5/21
                                string _step_text = RadioButtonList1.SelectedItem.Text.ToString().Trim().Substring(0, 2);
                                if (_step_text == "退回")
                                {
                                    sqlStr = "select distinct dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                                    cmd = new SqlCommand(sqlStr, conn);
                                    conn.Open();
                                    string _builder = cmd.ExecuteScalar().ToString();
                                    conn.Close();

                                    sqlStr = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh and ry_bm in (select ry_bm from dbo.dsoc_ry where ry_zgbh = '" + _builder + "' )";
                                    cmd = new SqlCommand(sqlStr, conn);
                                    conn.Open();
                                    dr = cmd.ExecuteReader();
                                    LB_All.DataSource = dr;
                                    LB_All.DataTextField = "ry_xm";
                                    LB_All.DataValueField = "Obj_ID";
                                    LB_All.DataBind();
                                    LB_All.SelectedIndex = 0;
                                    dr.Close();
                                    conn.Close();

                                }
                                else
                                {


                                    //解决员工部门两个以上的人员选择部门长问题  09/5/4
                                    sqlStr = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh and ry_bm in (select ry_bm from dbo.dsoc_ry where ry_zgbh = '" + _zgbh + "' )";
                                    cmd = new SqlCommand(sqlStr, conn);
                                    conn.Open();
                                    dr = cmd.ExecuteReader();
                                    LB_All.DataSource = dr;
                                    LB_All.DataTextField = "ry_xm";
                                    LB_All.DataValueField = "Obj_ID";
                                    LB_All.DataBind();
                                    LB_All.SelectedIndex = 0;
                                    dr.Close();
                                    conn.Close();
                                }

                                //								sqlStr = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '"+_flow_id+"' and Dsoc_Flow_Member_Bind.Step_ID = '"+_next_step+"' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh and ry_bm in (select ry_bm from dbo.dsoc_ry where ry_zgbh = '"+_zgbh+"' )";
                                //								cmd = new SqlCommand(sqlStr, conn); 
                                //								conn.Open();
                                //								dr = cmd.ExecuteReader(); 
                                //								LB_All.DataSource = dr; 
                                //								LB_All.DataTextField = "ry_xm"; 
                                //								LB_All.DataValueField = "Obj_ID"; 
                                //								LB_All.DataBind();
                                //								LB_All.SelectedIndex = 0;
                                //								dr.Close();
                                //								conn.Close();
                            }
                            else
                            {
                                sqlStr = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh";
                                cmd = new SqlCommand(sqlStr, conn);
                                conn.Open();
                                dr = cmd.ExecuteReader();
                                LB_All.DataSource = dr;
                                LB_All.DataTextField = "ry_xm";
                                LB_All.DataValueField = "Obj_ID";
                                LB_All.DataBind();
                                LB_All.SelectedIndex = 0;
                                dr.Close();
                                conn.Close();
                            }
                        }
                    }
                    /*---------------start-----------------------ws/20100703/处理出差申请流程中涉及部门负责人会签自动绑定问题----------------------------------start-------------------*/
                    else if (_step_remark == "1" || _step_remark == "2")
                    {
                        if (SlctMember1.Visible == false)
                        {
                            SlctMember1.Visible = true;
                            LB_All.Visible = false;
                        }
                    }
                    else if (_step_remark == "3")
                    {
                        this.LB_All.SelectionMode = ListSelectionMode.Multiple;
                        connString = SQLHelper.CONN_STRING;
                        conn = new SqlConnection(connString);
                        conn.Open();
                        sqlStr = "select r from dsoc_flow_style_data where Doc_ID = '" + _doc_id + "'";
                        string result = SQLHelper.ExecuteScalar(connString, CommandType.Text, sqlStr, null).ToString();
                        string[] bmList = result.Split(';');
                        sqlStr = "select ry_xm,ry_zgbh,zw_flag from dsoc_ry,dsoc_zw where (ry_zw like '%部长%' or ry_zw like '%主持工作%' or ry_zw like '%项目经理%') and (zw_flag=3) and dsoc_zw.zw_mc=dsoc_ry.ry_zw and ry_bm in('" + bmList[0] + "'";
                        for (int i = 1; i < bmList.Length; i++)
                            sqlStr += ",'" + bmList[i] + "'";
                        sqlStr += ")";
                        LB_All.DataSource = SQLHelper.ExecuteReader(connString, CommandType.Text, sqlStr, null);
                        LB_All.DataTextField = "ry_xm";
                        LB_All.DataValueField = "ry_zgbh";
                        LB_All.DataBind();
                        if (result.IndexOf("基建") >= 0)
                        {
                            ListItem temp = new ListItem("黄兆秋", "0058");
                            this.LB_All.Items.Add(temp);
                        }
                        for (int i = 0; i < this.LB_All.Items.Count; i++)
                            this.LB_All.Items[i].Selected = true;
                    }
                    else if (_step_remark == "4")
                    {
                        connString = SQLHelper.CONN_STRING;
                        conn = new SqlConnection(connString);
                        conn.Open();
                        sqlStr = "select ry_zw from dsoc_ry a,dsoc_flow_style_data b where rtrim(a.ry_zgbh)=rtrim(b.e) and b.Doc_ID='" + _doc_id + "'";
                        string result = SQLHelper.ExecuteScalar(connString, CommandType.Text, sqlStr, null).ToString().Trim();
                        sqlStr = "select ry_xm,ry_zgbh from dsoc_ry where rtrim(ry_zw)=";
                        if (result == "部长" || result == "副总经理" || result == "总经理")
                            sqlStr += " '总经理'";
                        else
                            sqlStr += " '总经理' or rtrim(ry_zw)='副总经理'";
                        sqlStr += " order by ry_zgbh";
                        LB_All.DataSource = SQLHelper.ExecuteReader(connString, CommandType.Text, sqlStr, null);
                        LB_All.DataTextField = "ry_xm";
                        LB_All.DataValueField = "ry_zgbh";
                        LB_All.DataBind();
                    }
                    /*---------------end-----------------------ws/20100703/处理出差申请流程中涉及部门负责人会签自动绑定问题----------------------------------end-------------------*/
                }
            }
            else
            {
                if (fieldset2.Visible == true)
                    fieldset2.Visible = false;
            }
        }
    }
}
