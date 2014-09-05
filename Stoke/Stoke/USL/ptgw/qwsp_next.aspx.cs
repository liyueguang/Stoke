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

namespace Stoke.USL.ptgw
{
    public partial class qwsp_next : System.Web.UI.Page
    {
        protected int _flow_id;
        protected int _step_id;
        protected string _step_name = "会签处理";
        protected int _doc_id;
        protected string _zgbh;
        protected string _obj_zgbh;
        protected int count;


        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            //_zgbh = Request["zgbh"].ToString();

            if (Session["zgbh"] != null)//09/08/09 wy
                _zgbh = Request["zgbh"].ToString();
            else
                Response.Redirect("../CustomerError.aspx");

            _flow_id = 18;
            _step_id = Convert.ToInt32(Request["step_id"]);
            _doc_id = Convert.ToInt32(Request["doc_id"]);
            if (!IsPostBack)
            {
                fieldset2.Visible = false;
                fieldset3.Visible = false;
                if (_step_id == 5)
                {
                    countersign();
                }
                if (_step_id == 8)
                {
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                }
                if (_step_id == 12)   //  2009/09/11  考虑第15部是否容许副总填写意见
                {
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                }
                BindStep();
            }
        }

        #region 绑定步骤
        protected void BindStep()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select Step_Next from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            string _step_next = null;
            _step_next = cmd.ExecuteScalar().ToString();
            conn.Close();
            conn.Dispose();
            //高层领导之间发送公文 2009.5.30 wy
            if ((_zgbh == "0027" || _zgbh == "0008" || _zgbh == "0006" || _zgbh == "0007" || _zgbh == "0009" || _zgbh == "0183" || _zgbh == "0026") && _step_id == 1)
            {
                ListItem tmplist6 = new ListItem();
                tmplist6.Text = "报主管副总";
                tmplist6.Value = "15";
                RadioButtonList1.Items.Add(tmplist6);
                ListItem tmplist7 = new ListItem();
                tmplist7.Text = "报总经理";
                tmplist7.Value = "16";
                RadioButtonList1.Items.Add(tmplist7);
            }
            //			else if((_zgbh =="0002"||_zgbh =="0003"||_zgbh =="0004"||_zgbh =="0005")&&_step_id==1)//wy 2009/06/07 解决副总给总经理发送公文
            //			{
            //				
            //				ListItem tmplist7=new ListItem();
            //				tmplist7.Text = "报总经理";
            //				tmplist7.Value = "16";
            //				RadioButtonList1.Items.Add(tmplist7);
            //			
            //			}
            else
            {
                for (int i = 0; i < _step_next.Split(';').Length; i++) //循环插入nextstep名称 wy
                    oprt(Convert.ToInt32(_step_next.Split(';')[i]));
            }
        }

        protected void oprt(int i)//这里的i具体指nextstep中的单项值 wy
        {

            ListItem tmplist = new ListItem();
            if (i == -1) //非正常步骤判断(jieshu/houlaibuzhou) wy
            {
                ListItem tmplist2 = new ListItem();
                if (_zgbh == "1001")//殷总特殊处理 wy
                {
                    ListItem tmplist3 = new ListItem();
                    tmplist3.Text = "退回";
                    tmplist3.Value = "10";
                    //tmplist3.Value = "1";
                    RadioButtonList1.Items.Add(tmplist3);
                    ListItem tmplist4 = new ListItem();
                    tmplist4.Text = "批准";
                    tmplist4.Value = "11";
                    RadioButtonList1.Items.Add(tmplist4);
                }
                if (_zgbh == "1001" || _zgbh == "0002" || _zgbh == "0003" || _zgbh == "0004" || _zgbh == "0005" || _zgbh == "0008" || _zgbh == "0009" || _zgbh == "0183")
                    tmplist2.Text = "批转";
                else
                    tmplist2.Text = "转发";
                tmplist2.Value = "9";
                RadioButtonList1.Items.Add(tmplist2);
                tmplist.Text = "签收";
                tmplist.Value = "-1";
            }
            else
            {
                if (_step_id == 2)//各步骤具体添加分管领导步骤、进行排序 20090607 wy
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "退回经办人"; break;
                        case 3:
                            tmplist.Text = "部门副部长签字"; break;
                        case 4:
                            tmplist.Text = "部门负责人签字"; break;
                    }
                }
                else if (_step_id == 3)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "退回经办人"; break;
                        case 2:
                            tmplist.Text = "退回岗位经理"; break;
                        case 4:
                            tmplist.Text = "部门负责人签字"; break;
                    }
                }
                else if (_step_id == 4)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "退回经办人"; break;
                        case 2:
                            tmplist.Text = "退回岗位经理"; break;
                        case 3:
                            tmplist.Text = "退回部门副部长"; break;
                        case 5:
                            tmplist.Text = "会签"; break;
                        case 13:
                            tmplist.Text = "分管领导审批"; break;
                        case 6:
                            tmplist.Text = "主管副总审批"; break;
                        case 7:
                            tmplist.Text = "报转总经理"; break;
                        case 8:
                            tmplist.Text = "签发"; break;  //相当于签收
                        //						case 12:
                        //							tmplist.Text = "转发布人";break;
                    }
                }
                else if (_step_id == 6)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "退回经办人"; break;
                        case 4:
                            tmplist.Text = "退回部门负责人"; break;
                        case 13:
                            tmplist.Text = "退回分管领导审批"; break;
                        case 7:
                            tmplist.Text = "报转总经理"; break;
                        case 8:
                            tmplist.Text = "签发(可批转)"; break;
                        //						case 12:
                        //							tmplist.Text = "转发布人";break;

                    }
                }
                else if (_step_id == 7)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "退回经办人"; break;
                        case 4:
                            tmplist.Text = "退回部门负责人"; break;
                        case 13:
                            tmplist.Text = "退回分管领导"; break;
                        case 6:
                            tmplist.Text = "退回主管副总"; break;
                        case 8:
                            tmplist.Text = "签发(可批转)"; break;
                        //						case 12:
                        //							tmplist.Text = "转发布人";break;

                    }
                }
                else if (_step_id == 13)
                {
                    switch (i)
                    {

                        case 4:
                            tmplist.Text = "退回部门负责人"; break;
                        case 6:
                            tmplist.Text = "主管副总审批"; break;
                        case 7:
                            tmplist.Text = "报转总经理"; break;
                        case 8:
                            tmplist.Text = "签发(可批转)"; break;

                    }
                }
                else if (_step_id == 15) //15,16 主要用于高层领导之间发送公文 2009/06/07 wy
                {
                    switch (i)
                    {

                        case 14:
                            tmplist.Text = "退回分管领导"; break;
                        case 16:
                            tmplist.Text = "报总经理审批"; break;
                        case 7:
                            tmplist.Text = "报转总经理"; break;
                        case 8:
                            tmplist.Text = "签发(可批转)"; break;

                    }
                }
                else if (_step_id == 16)
                {
                    switch (i)
                    {

                        case 14:
                            tmplist.Text = "退回分管领导"; break;
                        case 15:
                            tmplist.Text = "退回主管副总"; break;
                        case 7:
                            tmplist.Text = "报转总经理"; break;
                        case 8:
                            tmplist.Text = "签发(可批转)"; break;


                    }

                    ListItem tmplist4 = new ListItem();
                    tmplist4.Text = "批准";
                    tmplist4.Value = "11";
                    RadioButtonList1.Items.Add(tmplist4);


                }
                else
                {
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    string sqlStr = "select Step_Name from Dsoc_Flow_Step where Flow_ID = 18 and Step_ID = '" + i + "'";
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    conn.Open();
                    string _next_step_name = null;
                    _next_step_name = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    tmplist.Text = _next_step_name;
                }
                tmplist.Value = i.ToString();
            }

            if (_step_id == 12)
            {
                tmplist.Text = "签收并以公告形式发布";
                tmplist.Value = "-1";
            }

            RadioButtonList1.Items.Add(tmplist);
        }
        #endregion

        #region 绑定人员
        private void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int _next_step = Convert.ToInt32(RadioButtonList1.SelectedItem.Value);
            //条件框显示 wy 2009/05/29  next_step zhi wei an niu de zhi
            if ((_zgbh == "0001" && _next_step != -1) || (_next_step == 4 && _step_id == 13) || (_next_step == 13 && (_step_id == 6 || _step_id == 7)) || (_next_step < _step_id && _next_step != -1 && _step_id != 13) || (_step_id == 8 && _next_step != -1))
            {
                yj.Visible = true;
                tsyj.Visible = true;
            }
            else
            {
                yj.Visible = false;
                tsyj.Visible = false;
            }
            switch (_next_step)
            {
                case 1:
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "退回经办人";
                        tsyj.Text = "不同意";
                        yj.Text = "当前操作人填写批示";
                    }
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    string sql = "select dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "Doc_Builder_ID";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 2:
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and e = ry_bm and (ry_zw like '岗位经理%') order by ry_zgbh";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 3:
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and e = ry_bm and (ry_zw = '副部长' or ry_zw = '部长助理' or ry_zw = '项目副经理') order by ry_zgbh";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 4:
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "退回部门负责人";
                        tsyj.Text = "不同意";
                        yj.Text = "当前操作人填写批示";
                    }
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);//从填写的部门字段绑定部门负责人 09/06/07 wy
                    //					sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '"+_doc_id+"' and e = ry_bm and (ry_zw = '部长' or ry_zw = '项目经理' or ry_zw like '%主持工作%') order by ry_zgbh";
                    sql = "declare @ry_bm varchar(50);select @ry_bm = rtrim(e) from dsoc_flow_style_data where doc_id = '" + _doc_id + "';if (@ry_bm <> '道桥项目组') select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and e = ry_bm and (ry_zw = '部长' or ry_zw = '项目经理' or ry_zw like '%主持工作%') order by ry_zgbh;else select '孟祥发' as ry_xm, '0051' as ry_zgbh";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 5:
                    Label1.Text = "请选择会签人员";
                    fieldset1.Visible = false;
                    fieldset2.Visible = true;
                    fieldset3.Visible = false;
                    break;
                case 6:
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "退回公司主管副总";
                        tsyj.Text = "不同意";
                        yj.Text = "当前操作人填写批示";
                        conn = new SqlConnection(StokeGlobals.Connectiondsoc);//从签字的人员中绑定公司领导
                        sql = "select j,ry_zgbh from dbo.DSOC_Flow_Style_Data,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and ry_xm = j";
                        cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        dr = cmd.ExecuteReader();
                        DropDownList1.DataSource = dr;
                        DropDownList1.DataTextField = "j";
                        DropDownList1.DataValueField = "ry_zgbh";
                        DropDownList1.DataBind();
                        dr.Close();
                        conn.Close();
                        conn.Dispose();
                        break;
                    }

                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and ( ry_zw like '副总经理%') order by ry_zgbh";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 7:
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and ry_zw = '总经理' order by ry_zgbh";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 8:
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "签发公文";
                        if (tsyj.Text != string.Empty)
                            tsyj.Text = string.Empty;
                        yj.Text = "当前操作人填写批示";
                    }
                    if (_zgbh == "0001" || _zgbh == "0002" || _zgbh == "0003" || _zgbh == "0004" || _zgbh == "0005" || _zgbh == "0008" || _zgbh == "0009" || _zgbh == "0183")
                    {
                        CheckBox1.Checked = true;
                        ms.Text = "徐颜";
                        Label2.Text = "请选择批转人员(非必须环节)";
                    }
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = true;
                    hz.Text = string.Empty;
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    sql = "select b,c,d,f from dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "'";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        sjr.Text = dr["b"].ToString() == string.Empty ? "无" : dr["b"].ToString();
                        cb.Text = dr["c"].ToString() == string.Empty ? "无" : dr["c"].ToString();
                        cs.Text = dr["d"].ToString() == string.Empty ? "无" : dr["d"].ToString();
                    }
                    string _temp = obj2.Text + "," + sjr.Text + "," + cb.Text + "," + cs.Text + "," + ms.Text;
                    for (int i = 0; i < _temp.Split(',').Length; i++)
                    {
                        if (_temp.Split(',')[i].ToString() == "无")
                            continue;
                        else
                        {
                            if (hz.Text != string.Empty)
                                hz.Text += ",";
                            hz.Text += _temp.Split(',')[i].ToString();
                        }
                    }
                    if (hz.Text == string.Empty)
                    {
                        ts.Visible = true;
                        hz.Text = dr["f"].ToString();
                    }
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 9:
                    if (_zgbh == "0001" || _zgbh == "0002" || _zgbh == "0003" || _zgbh == "0004" || _zgbh == "0005" || _zgbh == "0008" || _zgbh == "0009" || _zgbh == "0183")
                        Label1.Text = "请选择批转人员(非必须环节)";
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "同意并批转公文";
                        tsyj.Text = "同意";
                        yj.Text = "当前操作人填写批示";
                    }
                    fieldset1.Visible = false;
                    fieldset2.Visible = true;
                    fieldset3.Visible = false;
                    break;
                case 10:
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "退回公文";
                        tsyj.Text = "不同意";
                        yj.Text = "当前操作人填写批示";
                    }
                    fieldset1.Visible = true;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);  //  wy 09/08/12
                    sql = "select dbo.Dsoc_Flow_Document.Doc_Builder_ID,dbo.dsoc_ry.ry_xm from dbo.Dsoc_Flow_Document,dbo.dsoc_ry where Doc_ID = '" + _doc_id + "' and dbo.Dsoc_Flow_Document.Doc_Builder_ID = dbo.dsoc_ry.ry_zgbh";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "Doc_Builder_ID";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 11:
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "同意公文";
                        tsyj.Text = "同意";
                        yj.Text = "当前操作人填写批示";
                    }
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                    break;
                case -1:
                    if (_zgbh == "0001")
                        Button2.Text = "签收公文";
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                    break;
                case 12:  //转发布人 20090510 wy 
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    sql = "select distinct Dsoc_Flow_Member_Bind.Obj_ID,dsoc_ry.ry_xm,dsoc_ry.ry_zgbh from Dsoc_Flow_Member_Bind,dsoc_ry where Dsoc_Flow_Member_Bind.Flow_ID = '" + _flow_id + "' and Dsoc_Flow_Member_Bind.Step_ID = '" + _next_step + "' and Dsoc_Flow_Member_Bind.Obj_ID = dsoc_ry.ry_zgbh and ry_bm in (select ry_bm from dbo.dsoc_ry where ry_zgbh = '" + _zgbh + "' )";
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                //13 wy 2009.05.29
                case 13:
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "退回分管领导";
                        tsyj.Text = "不同意";
                        yj.Text = "当前操作人填写批示";
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    if (_step_id == 6 || _step_id == 7) //解决退回时绑定分管领导 wy 2009/05/29
                    {
                        sql = "select distinct ry_xm,ry_zgbh,staff_id from Dsoc_Flow_Path,dsoc_ry where flow_id=18 and step_id=13 and doc_id = '" + _doc_id + "' and ry_zgbh=staff_id  ";
                    }
                    else //解决如退回部门负责人时可以重新选择部门领导 wy 2009/05/29
                    {
                        sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and (ry_zw like '工会%' or  ry_zw like '总工艺师%' or ry_zw like '副总工程师%' or ry_zw like '总经理助理%'or ry_zw like '营销总监%') order by ry_zgbh";
                    }
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 14:
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);

                    //解决如退回部门负责人时可以重新选择部门领导 wy 2009/05/29

                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and (ry_zw like '工会%' or  ry_zw like '总工艺师%' or ry_zw like '副总工程师%' or ry_zw like '总经理助理%'or ry_zw like '营销总监%') order by ry_zgbh";

                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 15:     // 09/07/06 zhijiebangding fuzong
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);

                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and (ry_zw like '副总经理') order by ry_zgbh";

                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
                case 16:
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);

                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and ( ry_zw like '总经理') order by ry_zgbh";

                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList1.DataSource = dr;
                    DropDownList1.DataTextField = "ry_xm";
                    DropDownList1.DataValueField = "ry_zgbh";
                    DropDownList1.DataBind();
                    dr.Close();
                    conn.Close();
                    conn.Dispose();
                    break;
            }
        }
        #endregion

        #region 记录过程
        private void SaveProc()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlStr = "select count(Doc_ID) from dbo.Dsoc_Flow_Path where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar());
            temp++;
            string involedPerson = string.Empty;
            if (_step_id == 5)
            {
                involedPerson = "无";
            }
            else
                switch (this.RadioButtonList1.SelectedItem.Text.ToString().Trim())
                {
                    case "会签":
                    case "批转":
                    case "转发":
                        involedPerson = this.obj.Text.ToString().Trim(); break; // 2009/07/18
                    case "签发":
                    case "签发(可批转)":

                        //involedPerson=this.obj2.Text.ToString().Trim();break;  2009/08/24  仅记录当前的步骤人员
                        involedPerson = this.hz.Text.ToString().Trim(); break;
                    case "签收":
                        involedPerson = "无"; break;
                    case "退回":
                    case "批准":                                             //2009/08/09
                        involedPerson = "无"; break;
                    default:
                        involedPerson = this.DropDownList1.SelectedItem.Text.ToString().Trim(); break;
                }
            sqlStr = "insert into Dsoc_Flow_Path values ('" + _doc_id + "', '" + _flow_id + "','" + _step_id + "','" + _zgbh + "','" + temp + "','" + System.DateTime.Now.ToString() + "','" + _step_name + "','" + involedPerson + "')";
            cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        #endregion

        #region 处理会签
        protected void countersign()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select Obj_ID,IsRunning,Obj_Type from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string _obj_id = null;
            int _isrunning = 0;
            string _obj_type = null;
            if (dr.Read())
            {
                _obj_id = dr["Obj_ID"].ToString();
                _isrunning = Convert.ToInt32(dr["IsRunning"]);
                _obj_type = dr["Obj_Type"].ToString();
            }
            conn.Close();
            _isrunning--;
            if (_isrunning != 0)
            {
                int position = _obj_id.IndexOf(_zgbh);
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
            dr.Close();

            conn.Dispose();
            SaveProc();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }
        #endregion

        #region 处理签收
        protected void sign()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select Obj_ID,IsRunning,Obj_Type from dbo.Dsoc_Flow_Document where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string _obj_id = null;
            int _isrunning = 0;
            if (dr.Read())
            {
                _obj_id = dr["Obj_ID"].ToString().Trim();// 09/08/6
                _isrunning = Convert.ToInt32(dr["IsRunning"]);
            }


            _obj_id += ","; //09/08/09 

            conn.Close();
            _isrunning--;
            if (_isrunning != 0)
            {
                //				int position = _obj_id.IndexOf(_zgbh.Trim());// 09/08/6
                string temp = null;
                //				if(position+4 != _obj_id.Length)
                //					temp = _obj_id.Substring(0,position)+_obj_id.Substring(position+5);
                //				else
                //					temp = _obj_id.Substring(0,position-1);

                //09/08/09
                temp = _obj_id.Replace(_zgbh.Trim() + ",", string.Empty);
                if (temp.Length > 0)
                    temp = temp.Remove(temp.Length - 1, 1);
                //
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
                sqlStr = "update dbo.Dsoc_Flow_Document set IsRunning = 0,Step_ID = '" + _sn + "',Obj_ID = null,Doc_Status = 1 where Doc_ID = '" + _doc_id + "'";
                cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            dr.Close();
            SaveProc();
            //
            //			if(_zgbh=="0001")//  09/08/09
            //				SaveYj();

            Response.Redirect("../Workflow/Work_Manage.aspx");
        }
        #endregion

        #region 绑定秘书
        protected void Bindms()
        {
            if (_zgbh == "0001" || _zgbh == "0002" || _zgbh == "0003" || _zgbh == "0004" || _zgbh == "0005" || _zgbh == "0008" || _zgbh == "0009" || _zgbh == "0183")
                ms.Text = "徐颜";
            else if (_zgbh == "0025")
                ms.Text = "姜楠";
            else if (_zgbh == "0013")
                ms.Text = "孙玉翠";
            else if (_zgbh == "0018")
                ms.Text = "沈大军";
            else if (_zgbh == "0010")
                ms.Text = "杨婧涵";
            else if (_zgbh == "0011")
                ms.Text = "周晓娜";
        }
        #endregion

        #region 存储意见
        protected void SaveYj()
        {
            string Sj = System.DateTime.Now.ToString();
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string Yjnr = tsyj.Text.ToString().Trim();
            string _zgxm = GetName(_zgbh);
            string sql = "insert into Dsoc_Flow_Gwyj values('" + _flow_id + "','" + _doc_id + "','" + _step_id + "','" + _zgxm + "','" + Yjnr + "','" + Sj + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        #endregion

        #region 取得职工姓名
        protected string GetName(string _zgbh)
        {
            string _zgxm = null;
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select * from dsoc_ry where ry_zgbh = '" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                _zgxm = dr.IsDBNull(1) ? null : dr["ry_xm"].ToString();
            dr.Close();
            conn.Close();
            conn.Dispose();
            return (_zgxm);
        }
        #endregion

        #region 取得公文标题
        protected string GetTitle()
        {
            string _title = null;
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select w from dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            _title = cmd.ExecuteScalar().ToString().Trim();
            conn.Close();
            conn.Dispose();
            return (_title);
        }
        #endregion

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

        #region 删除意见
        protected void DeleteYj()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sql = "delete from dbo.Dsoc_Flow_Gwyj where Doc_ID = '" + _doc_id + "' and Step_ID = '" + _step_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        #endregion

        #region 删除签发前所有意见
        protected void DeleteYjAll()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sql = "delete from dbo.Dsoc_Flow_Gwyj where Doc_ID = '" + _doc_id + "' and Step_ID < '8' and Step_ID <> '-1'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        #endregion

        #region 生成编号
        protected void CreateBh()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            string sqlStr = "select e from dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            string _bm = cmd.ExecuteScalar().ToString().Trim();
            conn.Close();
            string _bh = "DSOC-";
            int _lsh = 0;
            sqlStr = "select * from dsoc_bm where bm_mc = '" + _bm + "'";
            cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                _bh += (dr["bm_kgmlh"] + "-");
            int year = System.DateTime.Now.Year;
            _bh += year.ToString().Substring(2, 2);
            dr.Close();
            conn.Close();
            sqlStr = "select * from dsoc_lsh where nf = '" + _bm + "'";
            cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
                _lsh = Convert.ToInt32(dr["kgmlh"]);
            dr.Close();
            conn.Close();
            int _lsh_temp = _lsh + 1;
            sqlStr = "update dsoc_lsh set kgmlh = '" + _lsh_temp + "' where nf = '" + _bm + "'";
            cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            if (_lsh < 10)
            {
                _bh += "0000" + Convert.ToString(_lsh);
            }
            else if (_lsh < 100)
            {
                _bh += "000" + Convert.ToString(_lsh);
            }
            else if (_lsh < 1000)
            {
                _bh += "00" + Convert.ToString(_lsh);
            }
            else if (_lsh < 10000)
            {
                _bh += "0" + Convert.ToString(_lsh);
            }
            else if (_lsh < 100000)
            {
                _bh += Convert.ToString(_lsh);
            }
            sqlStr = "update dbo.DSOC_Flow_Style_Data set h = '" + _bh + "' where Doc_ID = '" + _doc_id + "'";
            cmd = new SqlCommand(sqlStr, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        #endregion

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
            this.RadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region 转交下一步操作

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == -1)
                Response.Write("<script>alert('请选择下一步骤!')</script>");
            else
            {
                _step_name = this.RadioButtonList1.SelectedItem.Text.ToString();
                if (tsyj.Visible == true && _zgbh != "0001" && _zgbh != "0002" && _zgbh != "0003" && _zgbh != "0004" && _zgbh != "0005" && _zgbh != "0008" && _zgbh != "0009" && _zgbh != "0183" && tsyj.Text == string.Empty && _step_id != 8)
                    Response.Write("<script>alert('回退必须填写意见!')</script>");
                else
                {
                    if (_step_id < 8)
                        DeleteYj();
                    //对下一步操作的主要处理依据  wy 20090529
                    int _slct_rlist = Convert.ToInt32(RadioButtonList1.SelectedValue);
                    //添加步骤13与步骤4和6做同样的处理 wy 20090529  15/16 
                    if (_slct_rlist == 1 || _slct_rlist == 2 || _slct_rlist == 3 || _slct_rlist == 4 || _slct_rlist == 6 || _slct_rlist == 7 || _slct_rlist == 13 || _slct_rlist == 14 || _slct_rlist == 15)// wy 09/08/12
                    {
                        if ((_step_id == 4 && _slct_rlist == 6) || (_step_id == 6 && _slct_rlist == 7))
                        {
                            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                            string sqlStr = "select b from dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "'";
                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            string _temp = cmd.ExecuteScalar().ToString();
                            conn.Close();

                            if (_temp.IndexOf(DropDownList1.SelectedItem.Text.ToString().Trim()) != -1)
                                Response.Write("<script>alert('签发前不能转交收件人!')</script>");
                            else
                            {
                                sqlStr = "update Dsoc_Flow_Document set Step_ID = '" + RadioButtonList1.SelectedItem.Value.ToString() + "',Obj_ID = '" + DropDownList1.SelectedItem.Value.ToString() + "' where Doc_ID = '" + _doc_id + "'";
                                conn.Open();
                                cmd = new SqlCommand(sqlStr, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();

                                if (tsyj.Visible == true && tsyj.Text != string.Empty)
                                    SaveYj();
                                SaveProc();
                                //Msg _msg = new Msg();
                                //string _url = "http://192.168.201.26/dsoc/USL/ptgw/qwsp.aspx?step_id=" + _slct_rlist.ToString() + "&doc_id=" + _doc_id.ToString();
                                //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "您有新公文", GetTitle(), _url);
                                Response.Redirect("../Workflow/Work_Manage.aspx");
                            }
                        }
                        else
                        {
                            SqlConnection conn2 = new SqlConnection(StokeGlobals.Connectiondsoc);
                            string sqlStr2 = "update Dsoc_Flow_Document set Step_ID = '" + RadioButtonList1.SelectedItem.Value.ToString() + "',Obj_ID = '" + DropDownList1.SelectedItem.Value.ToString() + "' where Doc_ID = '" + _doc_id + "'";
                            conn2.Open();
                            SqlCommand cmd2 = new SqlCommand(sqlStr2, conn2);
                            cmd2.ExecuteNonQuery();
                            conn2.Close();
                            conn2.Dispose();
                            SaveProc();
                            if (tsyj.Visible == true && tsyj.Text != string.Empty)
                                SaveYj();
                            //Msg _msg = new Msg();
                            //string _url = "http://192.168.201.26/dsoc/USL/ptgw/qwsp.aspx?step_id=" + _slct_rlist.ToString() + "&doc_id=" + _doc_id.ToString();
                            //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "您有新公文", GetTitle(), _url);
                            Response.Redirect("../Workflow/Work_Manage.aspx");
                        }
                    }
                    else if (_slct_rlist == 5) // huiqian
                    {
                        _obj_zgbh = SlctMember1.Send[1].ToString();
                        if (obj.Text == "无")
                            Response.Write("<script>alert('请选择会签人员')</script>");
                        else
                        {
                            string connString = StokeGlobals.Connectiondsoc;
                            SqlConnection conn = new SqlConnection(connString);
                            conn.Open();
                            string sqlStr = "update dbo.Dsoc_Flow_Document set Step_ID = '" + _slct_rlist + "',IsRunning = '" + _obj_zgbh.Split(',').Length + "',Obj_ID='" + _obj_zgbh + "',Obj_Type = '" + _zgbh + "' where Doc_ID = '" + _doc_id + "'";
                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            conn.Dispose();
                            SaveProc();
                            if (tsyj.Visible == true && tsyj.Text != string.Empty)
                                SaveYj();
                            //Msg _msg = new Msg();
                            //string _url = "http://192.168.201.26/dsoc/USL/ptgw/qwsp.aspx?step_id=" + _slct_rlist.ToString() + "&doc_id=" + _doc_id.ToString();
                            //_msg.InsertMsg(_obj_zgbh.Trim(), "您有新公文", GetTitle(), _url);
                            Response.Redirect("../Workflow/Work_Manage.aspx");
                        }
                    }
                    else if (_slct_rlist == 8)  //qianfa pizhuan
                    {
                        //tonzoc-20110922
                        //删除签发前产生的相关意见
                        DeleteYjAll();

                        _obj_zgbh = string.Empty;
                        string _temp = hz.Text.ToString();
                        if (verify(_temp) == true)
                            Response.Write("<script>alert('接收人员名单有重复!')</script>");
                        else
                        {
                            //签发生成编号
                            CreateBh();
                            for (int i = 0; i < _temp.Split(',').Length; i++)
                            {
                                string connString = StokeGlobals.Connectiondsoc;
                                SqlConnection conn = new SqlConnection(connString);
                                string sqlStr = "select distinct ry_zgbh from dbo.dsoc_ry where ry_xm = '" + _temp.Split(',')[i] + "'";
                                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                                conn.Open();
                                if (_obj_zgbh != string.Empty)
                                    _obj_zgbh += ",";
                                string _temp_zgbh = cmd.ExecuteScalar().ToString().Trim();
                                _obj_zgbh += _temp_zgbh;
                                conn.Close();

                                sqlStr = "insert into dbo.Dsoc_Flow_Qsjl (Doc_id,Yjr) values ('" + _doc_id + "','" + _temp_zgbh + "')";
                                cmd = new SqlCommand(sqlStr, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                conn.Dispose();
                            }
                            SqlConnection conn2 = new SqlConnection(StokeGlobals.Connectiondsoc);
                            string sqlStr2 = "update dbo.Dsoc_Flow_Document set Step_ID = '" + _slct_rlist + "',IsRunning = '" + _obj_zgbh.Split(',').Length + "',Obj_ID='" + _obj_zgbh + "' where Doc_ID = '" + _doc_id + "'";
                            SqlCommand cmd2 = new SqlCommand(sqlStr2, conn2);
                            conn2.Open();
                            cmd2.ExecuteNonQuery();
                            conn2.Close();
                            conn2.Dispose();
                            SaveProc();
                            if (tsyj.Visible == true && tsyj.Text != string.Empty)
                                SaveYj();
                            //Msg _msg = new Msg();
                            //string _url = "http://192.168.201.26/dsoc/USL/ptgw/qwsp.aspx?step_id=" + _slct_rlist.ToString() + "&doc_id=" + _doc_id.ToString();
                            //_msg.InsertMsg(_obj_zgbh.Trim(), "您有新公文", GetTitle(), _url);
                            Response.Redirect("../Workflow/Work_Manage.aspx");
                        }
                    }
                    else if (_slct_rlist == 9) // zhuanfa 批转
                    {
                        _obj_zgbh = SlctMember1.Send[1].ToString();

                        if (obj.Text == "无")
                            Response.Write("<script>alert('请选择人员!')</script>");
                        else
                        {
                            string connString = StokeGlobals.Connectiondsoc;
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

                            for (int i = 0; i < _obj_zgbh.Split(',').Length; i++)// insert yj
                            {
                                sqlStr = "insert into dbo.Dsoc_Flow_Qsjl (Doc_id,Yjr) values ('" + _doc_id + "','" + _obj_zgbh.Split(',')[i] + "')";
                                cmd = new SqlCommand(sqlStr, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();

                            }
                            _obj_id += "," + _obj_zgbh;
                            _count_temp += _obj_zgbh.Split(',').Length;

                            if (_step_id == 16)             // 2009/09/10 保证殷总操作批转后步骤名称转为签收保持一致
                            {
                                sqlStr = "update dbo.Dsoc_Flow_Document set Obj_ID = '" + _obj_id + "',IsRunning = '" + _count_temp + "' ,step_id=8 where Doc_ID =  '" + _doc_id + "'";
                            }
                            else
                            {
                                sqlStr = "update dbo.Dsoc_Flow_Document set Obj_ID = '" + _obj_id + "',IsRunning = '" + _count_temp + "' where Doc_ID =  '" + _doc_id + "'";
                            }
                            cmd = new SqlCommand(sqlStr, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            conn.Dispose();
                            if (tsyj.Visible == true && tsyj.Text != string.Empty)
                                SaveYj();
                            sign();
                        }
                    }
                    else if (_slct_rlist == 10) // wy 09/08/12
                    {
                        SqlConnection conn12 = new SqlConnection(StokeGlobals.Connectiondsoc);
                        string sqlStr2 = "update Dsoc_Flow_Document set Step_ID = 1,Obj_ID = '" + DropDownList1.SelectedItem.Value.ToString() + "',IsRunning =0 where Doc_ID = '" + _doc_id + "'";
                        conn12.Open();
                        SqlCommand cmd2 = new SqlCommand(sqlStr2, conn12);
                        cmd2.ExecuteNonQuery();
                        conn12.Close();
                        conn12.Dispose();
                        SaveProc();
                        if (tsyj.Visible == true && tsyj.Text != string.Empty)
                            SaveYj();
                        Response.Redirect("../Workflow/Work_Manage.aspx");

                    }
                    else if (_slct_rlist == 11 || (_slct_rlist == -1 && _step_id != 12))
                    {
                        if (tsyj.Visible == true && tsyj.Text != string.Empty) //  wy 09/08/12
                            SaveYj();
                        sign();
                    }
                    else if (_slct_rlist == 12)
                    {
                        SqlConnection conn12 = new SqlConnection(StokeGlobals.Connectiondsoc);
                        string sqlStr2 = "update Dsoc_Flow_Document set Step_ID = '" + RadioButtonList1.SelectedItem.Value.ToString() + "',Obj_ID = '" + DropDownList1.SelectedItem.Value.ToString() + "' where Doc_ID = '" + _doc_id + "'";
                        conn12.Open();
                        SqlCommand cmd2 = new SqlCommand(sqlStr2, conn12);
                        cmd2.ExecuteNonQuery();
                        conn12.Close();
                        conn12.Dispose();
                        SaveProc();
                        if (tsyj.Visible == true && tsyj.Text != string.Empty)
                            SaveYj();
                        //						sign();
                        //Msg _msg = new Msg();
                        //string _url = "http://192.168.201.26/dsoc/USL/ptgw/qwsp.aspx?step_id=" + _slct_rlist.ToString() + "&doc_id=" + _doc_id.ToString();
                        //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "您有新公文", GetTitle(), _url);
                        Response.Redirect("../Workflow/Work_Manage.aspx");

                    }
                    else if (_slct_rlist == -1 && _step_id == 12)
                    {
                        SqlConnection conn12 = new SqlConnection(StokeGlobals.Connectiondsoc);
                        string sqlStr = "select Step_Next from Dsoc_Flow_Step where Flow_ID = '" + _flow_id + "' and Step_ID = '" + _step_id + "'";
                        SqlCommand cmd = new SqlCommand(sqlStr, conn12);
                        conn12.Open();
                        string _sn = null;
                        _sn = cmd.ExecuteScalar().ToString();
                        conn12.Close();
                        //SqlConnection conn12 = new SqlConnection(StokeGlobals.Connectiondsoc);
                        string sqlStr2 = "update dbo.Dsoc_Flow_Document set IsRunning = 0,Step_ID = '" + _sn + "',Obj_ID = null,Doc_Status = 1 where Doc_ID = '" + _doc_id + "'";
                        conn12.Open();
                        SqlCommand cmd2 = new SqlCommand(sqlStr2, conn12);
                        cmd2.ExecuteNonQuery();
                        conn12.Close();
                        conn12.Dispose();
                        SaveProc();
                        if (tsyj.Visible == true && tsyj.Text != string.Empty)
                            SaveYj();

                        Response.Redirect("../Workflow/Work_Manage.aspx");
                    }
                    else if (_slct_rlist == 16)  //  2009/09/10     新添加对第16部进行操作
                    {
                        SqlConnection conn2 = new SqlConnection(StokeGlobals.Connectiondsoc);
                        string sqlStr2 = "update Dsoc_Flow_Document set Step_ID = '" + RadioButtonList1.SelectedItem.Value.ToString() + "',Obj_ID = '" + DropDownList1.SelectedItem.Value.ToString() + "',IsRunning = 1  where Doc_ID = '" + _doc_id + "'";
                        conn2.Open();
                        SqlCommand cmd2 = new SqlCommand(sqlStr2, conn2);
                        cmd2.ExecuteNonQuery();
                        conn2.Close();
                        conn2.Dispose();
                        SaveProc();
                        if (tsyj.Visible == true && tsyj.Text != string.Empty)
                            SaveYj();
                        //Msg _msg = new Msg();
                        //string _url = "http://192.168.201.26/dsoc/USL/ptgw/qwsp.aspx?step_id=" + _slct_rlist.ToString() + "&doc_id=" + _doc_id.ToString();
                        //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "您有新公文", GetTitle(), _url);
                        Response.Redirect("../Workflow/Work_Manage.aspx");
                    }
                }
            }
        }

        #endregion
        #region 选择人员
        private void Button1_Click(object sender, System.EventArgs e)
        {
            obj.Text = SlctMember1.Send[0].ToString();
            if (obj.Text == string.Empty)
                obj.Text = "无";
            _obj_zgbh = SlctMember1.Send[1].ToString();
            count = Convert.ToInt32(SlctMember1.Send[2]);
        }
        #endregion
        #region 选择收件人
        private void Button3_Click(object sender, System.EventArgs e)
        {
            obj2.Text = SlctMember2.Send[0].ToString();
            if (obj2.Text == string.Empty)
                obj2.Text = "无";
            string _temp = obj2.Text + "," + sjr.Text + "," + cb.Text + "," + cs.Text + "," + ms.Text;
            hz.Text = string.Empty;
            for (int i = 0; i < _temp.Split(',').Length; i++)
            {
                if (_temp.Split(',')[i].ToString() == "无")
                    continue;
                else
                {
                    if (hz.Text != string.Empty)
                        hz.Text += ",";
                    hz.Text += _temp.Split(',')[i].ToString();
                }
            }
            ts.Visible = false;
            if (hz.Text == string.Empty)
            {
                ts.Visible = true;
                SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                string sql = "select f from dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                hz.Text = cmd.ExecuteScalar().ToString();
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion
        private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckBox1.Checked == true)
                Bindms();
            else
                ms.Text = "无";
            hz.Text = string.Empty;
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            string sql = "select b,c,d,f from dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sjr.Text = dr["b"].ToString() == string.Empty ? "无" : dr["b"].ToString();
                cb.Text = dr["c"].ToString() == string.Empty ? "无" : dr["c"].ToString();
                cs.Text = dr["d"].ToString() == string.Empty ? "无" : dr["d"].ToString();
            }
            string _temp = obj2.Text + "," + sjr.Text + "," + cb.Text + "," + cs.Text + "," + ms.Text;
            for (int i = 0; i < _temp.Split(',').Length; i++)
            {
                if (_temp.Split(',')[i].ToString() == "无")
                    continue;
                else
                {
                    if (hz.Text != string.Empty)
                        hz.Text += ",";
                    hz.Text += _temp.Split(',')[i].ToString();
                }
            }
            if (hz.Text == string.Empty)
            {
                ts.Visible = true;
                hz.Text = dr["f"].ToString();
            }
            dr.Close();
            conn.Close();
            conn.Dispose();
        }

        private void Button4_Click(object sender, System.EventArgs e)
        {
            string _URL = "qwsp.aspx?doc_id=" + _doc_id + "&step_id=" + _step_id + "&zgbh=" + _zgbh;
            Response.Redirect(_URL);
        }	
    }
}
