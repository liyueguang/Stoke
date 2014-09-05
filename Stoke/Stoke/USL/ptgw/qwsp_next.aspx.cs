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
        protected string _step_name = "��ǩ����";
        protected int _doc_id;
        protected string _zgbh;
        protected string _obj_zgbh;
        protected int count;


        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
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
                if (_step_id == 12)   //  2009/09/11  ���ǵ�15���Ƿ���������д���
                {
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                }
                BindStep();
            }
        }

        #region �󶨲���
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
            //�߲��쵼֮�䷢�͹��� 2009.5.30 wy
            if ((_zgbh == "0027" || _zgbh == "0008" || _zgbh == "0006" || _zgbh == "0007" || _zgbh == "0009" || _zgbh == "0183" || _zgbh == "0026") && _step_id == 1)
            {
                ListItem tmplist6 = new ListItem();
                tmplist6.Text = "�����ܸ���";
                tmplist6.Value = "15";
                RadioButtonList1.Items.Add(tmplist6);
                ListItem tmplist7 = new ListItem();
                tmplist7.Text = "���ܾ���";
                tmplist7.Value = "16";
                RadioButtonList1.Items.Add(tmplist7);
            }
            //			else if((_zgbh =="0002"||_zgbh =="0003"||_zgbh =="0004"||_zgbh =="0005")&&_step_id==1)//wy 2009/06/07 ������ܸ��ܾ����͹���
            //			{
            //				
            //				ListItem tmplist7=new ListItem();
            //				tmplist7.Text = "���ܾ���";
            //				tmplist7.Value = "16";
            //				RadioButtonList1.Items.Add(tmplist7);
            //			
            //			}
            else
            {
                for (int i = 0; i < _step_next.Split(';').Length; i++) //ѭ������nextstep���� wy
                    oprt(Convert.ToInt32(_step_next.Split(';')[i]));
            }
        }

        protected void oprt(int i)//�����i����ָnextstep�еĵ���ֵ wy
        {

            ListItem tmplist = new ListItem();
            if (i == -1) //�����������ж�(jieshu/houlaibuzhou) wy
            {
                ListItem tmplist2 = new ListItem();
                if (_zgbh == "1001")//�������⴦�� wy
                {
                    ListItem tmplist3 = new ListItem();
                    tmplist3.Text = "�˻�";
                    tmplist3.Value = "10";
                    //tmplist3.Value = "1";
                    RadioButtonList1.Items.Add(tmplist3);
                    ListItem tmplist4 = new ListItem();
                    tmplist4.Text = "��׼";
                    tmplist4.Value = "11";
                    RadioButtonList1.Items.Add(tmplist4);
                }
                if (_zgbh == "1001" || _zgbh == "0002" || _zgbh == "0003" || _zgbh == "0004" || _zgbh == "0005" || _zgbh == "0008" || _zgbh == "0009" || _zgbh == "0183")
                    tmplist2.Text = "��ת";
                else
                    tmplist2.Text = "ת��";
                tmplist2.Value = "9";
                RadioButtonList1.Items.Add(tmplist2);
                tmplist.Text = "ǩ��";
                tmplist.Value = "-1";
            }
            else
            {
                if (_step_id == 2)//�����������ӷֹ��쵼���衢�������� 20090607 wy
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "�˻ؾ�����"; break;
                        case 3:
                            tmplist.Text = "���Ÿ�����ǩ��"; break;
                        case 4:
                            tmplist.Text = "���Ÿ�����ǩ��"; break;
                    }
                }
                else if (_step_id == 3)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "�˻ؾ�����"; break;
                        case 2:
                            tmplist.Text = "�˻ظ�λ����"; break;
                        case 4:
                            tmplist.Text = "���Ÿ�����ǩ��"; break;
                    }
                }
                else if (_step_id == 4)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "�˻ؾ�����"; break;
                        case 2:
                            tmplist.Text = "�˻ظ�λ����"; break;
                        case 3:
                            tmplist.Text = "�˻ز��Ÿ�����"; break;
                        case 5:
                            tmplist.Text = "��ǩ"; break;
                        case 13:
                            tmplist.Text = "�ֹ��쵼����"; break;
                        case 6:
                            tmplist.Text = "���ܸ�������"; break;
                        case 7:
                            tmplist.Text = "��ת�ܾ���"; break;
                        case 8:
                            tmplist.Text = "ǩ��"; break;  //�൱��ǩ��
                        //						case 12:
                        //							tmplist.Text = "ת������";break;
                    }
                }
                else if (_step_id == 6)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "�˻ؾ�����"; break;
                        case 4:
                            tmplist.Text = "�˻ز��Ÿ�����"; break;
                        case 13:
                            tmplist.Text = "�˻طֹ��쵼����"; break;
                        case 7:
                            tmplist.Text = "��ת�ܾ���"; break;
                        case 8:
                            tmplist.Text = "ǩ��(����ת)"; break;
                        //						case 12:
                        //							tmplist.Text = "ת������";break;

                    }
                }
                else if (_step_id == 7)
                {
                    switch (i)
                    {
                        case 1:
                            tmplist.Text = "�˻ؾ�����"; break;
                        case 4:
                            tmplist.Text = "�˻ز��Ÿ�����"; break;
                        case 13:
                            tmplist.Text = "�˻طֹ��쵼"; break;
                        case 6:
                            tmplist.Text = "�˻����ܸ���"; break;
                        case 8:
                            tmplist.Text = "ǩ��(����ת)"; break;
                        //						case 12:
                        //							tmplist.Text = "ת������";break;

                    }
                }
                else if (_step_id == 13)
                {
                    switch (i)
                    {

                        case 4:
                            tmplist.Text = "�˻ز��Ÿ�����"; break;
                        case 6:
                            tmplist.Text = "���ܸ�������"; break;
                        case 7:
                            tmplist.Text = "��ת�ܾ���"; break;
                        case 8:
                            tmplist.Text = "ǩ��(����ת)"; break;

                    }
                }
                else if (_step_id == 15) //15,16 ��Ҫ���ڸ߲��쵼֮�䷢�͹��� 2009/06/07 wy
                {
                    switch (i)
                    {

                        case 14:
                            tmplist.Text = "�˻طֹ��쵼"; break;
                        case 16:
                            tmplist.Text = "���ܾ�������"; break;
                        case 7:
                            tmplist.Text = "��ת�ܾ���"; break;
                        case 8:
                            tmplist.Text = "ǩ��(����ת)"; break;

                    }
                }
                else if (_step_id == 16)
                {
                    switch (i)
                    {

                        case 14:
                            tmplist.Text = "�˻طֹ��쵼"; break;
                        case 15:
                            tmplist.Text = "�˻����ܸ���"; break;
                        case 7:
                            tmplist.Text = "��ת�ܾ���"; break;
                        case 8:
                            tmplist.Text = "ǩ��(����ת)"; break;


                    }

                    ListItem tmplist4 = new ListItem();
                    tmplist4.Text = "��׼";
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
                tmplist.Text = "ǩ�ղ��Թ�����ʽ����";
                tmplist.Value = "-1";
            }

            RadioButtonList1.Items.Add(tmplist);
        }
        #endregion

        #region ����Ա
        private void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int _next_step = Convert.ToInt32(RadioButtonList1.SelectedItem.Value);
            //��������ʾ wy 2009/05/29  next_step zhi wei an niu de zhi
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
                        Button2.Text = "�˻ؾ�����";
                        tsyj.Text = "��ͬ��";
                        yj.Text = "��ǰ��������д��ʾ";
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
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and e = ry_bm and (ry_zw like '��λ����%') order by ry_zgbh";
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
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and e = ry_bm and (ry_zw = '������' or ry_zw = '��������' or ry_zw = '��Ŀ������') order by ry_zgbh";
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
                        Button2.Text = "�˻ز��Ÿ�����";
                        tsyj.Text = "��ͬ��";
                        yj.Text = "��ǰ��������д��ʾ";
                    }
                    if (fieldset2.Visible == true || fieldset3.Visible == true)
                    {
                        fieldset3.Visible = false;
                        fieldset2.Visible = false;
                        fieldset1.Visible = true;
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);//����д�Ĳ����ֶΰ󶨲��Ÿ����� 09/06/07 wy
                    //					sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '"+_doc_id+"' and e = ry_bm and (ry_zw = '����' or ry_zw = '��Ŀ����' or ry_zw like '%���ֹ���%') order by ry_zgbh";
                    sql = "declare @ry_bm varchar(50);select @ry_bm = rtrim(e) from dsoc_flow_style_data where doc_id = '" + _doc_id + "';if (@ry_bm <> '������Ŀ��') select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and e = ry_bm and (ry_zw = '����' or ry_zw = '��Ŀ����' or ry_zw like '%���ֹ���%') order by ry_zgbh;else select '���鷢' as ry_xm, '0051' as ry_zgbh";
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
                    Label1.Text = "��ѡ���ǩ��Ա";
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
                        Button2.Text = "�˻ع�˾���ܸ���";
                        tsyj.Text = "��ͬ��";
                        yj.Text = "��ǰ��������д��ʾ";
                        conn = new SqlConnection(StokeGlobals.Connectiondsoc);//��ǩ�ֵ���Ա�а󶨹�˾�쵼
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
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and ( ry_zw like '���ܾ���%') order by ry_zgbh";
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
                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and ry_zw = '�ܾ���' order by ry_zgbh";
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
                        Button2.Text = "ǩ������";
                        if (tsyj.Text != string.Empty)
                            tsyj.Text = string.Empty;
                        yj.Text = "��ǰ��������д��ʾ";
                    }
                    if (_zgbh == "0001" || _zgbh == "0002" || _zgbh == "0003" || _zgbh == "0004" || _zgbh == "0005" || _zgbh == "0008" || _zgbh == "0009" || _zgbh == "0183")
                    {
                        CheckBox1.Checked = true;
                        ms.Text = "����";
                        Label2.Text = "��ѡ����ת��Ա(�Ǳ��뻷��)";
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
                        sjr.Text = dr["b"].ToString() == string.Empty ? "��" : dr["b"].ToString();
                        cb.Text = dr["c"].ToString() == string.Empty ? "��" : dr["c"].ToString();
                        cs.Text = dr["d"].ToString() == string.Empty ? "��" : dr["d"].ToString();
                    }
                    string _temp = obj2.Text + "," + sjr.Text + "," + cb.Text + "," + cs.Text + "," + ms.Text;
                    for (int i = 0; i < _temp.Split(',').Length; i++)
                    {
                        if (_temp.Split(',')[i].ToString() == "��")
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
                        Label1.Text = "��ѡ����ת��Ա(�Ǳ��뻷��)";
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "ͬ�Ⲣ��ת����";
                        tsyj.Text = "ͬ��";
                        yj.Text = "��ǰ��������д��ʾ";
                    }
                    fieldset1.Visible = false;
                    fieldset2.Visible = true;
                    fieldset3.Visible = false;
                    break;
                case 10:
                    if (_zgbh == "0001")
                    {
                        Button2.Text = "�˻ع���";
                        tsyj.Text = "��ͬ��";
                        yj.Text = "��ǰ��������д��ʾ";
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
                        Button2.Text = "ͬ�⹫��";
                        tsyj.Text = "ͬ��";
                        yj.Text = "��ǰ��������д��ʾ";
                    }
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                    break;
                case -1:
                    if (_zgbh == "0001")
                        Button2.Text = "ǩ�չ���";
                    fieldset1.Visible = false;
                    fieldset2.Visible = false;
                    fieldset3.Visible = false;
                    break;
                case 12:  //ת������ 20090510 wy 
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
                        Button2.Text = "�˻طֹ��쵼";
                        tsyj.Text = "��ͬ��";
                        yj.Text = "��ǰ��������д��ʾ";
                    }
                    conn = new SqlConnection(StokeGlobals.Connectiondsoc);
                    if (_step_id == 6 || _step_id == 7) //����˻�ʱ�󶨷ֹ��쵼 wy 2009/05/29
                    {
                        sql = "select distinct ry_xm,ry_zgbh,staff_id from Dsoc_Flow_Path,dsoc_ry where flow_id=18 and step_id=13 and doc_id = '" + _doc_id + "' and ry_zgbh=staff_id  ";
                    }
                    else //������˻ز��Ÿ�����ʱ��������ѡ�����쵼 wy 2009/05/29
                    {
                        sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and (ry_zw like '����%' or  ry_zw like '�ܹ���ʦ%' or ry_zw like '���ܹ���ʦ%' or ry_zw like '�ܾ�������%'or ry_zw like 'Ӫ���ܼ�%') order by ry_zgbh";
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

                    //������˻ز��Ÿ�����ʱ��������ѡ�����쵼 wy 2009/05/29

                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and (ry_zw like '����%' or  ry_zw like '�ܹ���ʦ%' or ry_zw like '���ܹ���ʦ%' or ry_zw like '�ܾ�������%'or ry_zw like 'Ӫ���ܼ�%') order by ry_zgbh";

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

                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and (ry_zw like '���ܾ���') order by ry_zgbh";

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

                    sql = "select ry_xm,ry_zgbh from dbo.dsoc_ry,dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "' and ( ry_zw like '�ܾ���') order by ry_zgbh";

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

        #region ��¼����
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
                involedPerson = "��";
            }
            else
                switch (this.RadioButtonList1.SelectedItem.Text.ToString().Trim())
                {
                    case "��ǩ":
                    case "��ת":
                    case "ת��":
                        involedPerson = this.obj.Text.ToString().Trim(); break; // 2009/07/18
                    case "ǩ��":
                    case "ǩ��(����ת)":

                        //involedPerson=this.obj2.Text.ToString().Trim();break;  2009/08/24  ����¼��ǰ�Ĳ�����Ա
                        involedPerson = this.hz.Text.ToString().Trim(); break;
                    case "ǩ��":
                        involedPerson = "��"; break;
                    case "�˻�":
                    case "��׼":                                             //2009/08/09
                        involedPerson = "��"; break;
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

        #region �����ǩ
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

        #region ����ǩ��
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

        #region ������
        protected void Bindms()
        {
            if (_zgbh == "0001" || _zgbh == "0002" || _zgbh == "0003" || _zgbh == "0004" || _zgbh == "0005" || _zgbh == "0008" || _zgbh == "0009" || _zgbh == "0183")
                ms.Text = "����";
            else if (_zgbh == "0025")
                ms.Text = "���";
            else if (_zgbh == "0013")
                ms.Text = "�����";
            else if (_zgbh == "0018")
                ms.Text = "����";
            else if (_zgbh == "0010")
                ms.Text = "��溺�";
            else if (_zgbh == "0011")
                ms.Text = "������";
        }
        #endregion

        #region �洢���
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

        #region ȡ��ְ������
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

        #region ȡ�ù��ı���
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

        #region У��
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

        #region ɾ�����
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

        #region ɾ��ǩ��ǰ�������
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

        #region ���ɱ��
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
            this.RadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region ת����һ������

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == -1)
                Response.Write("<script>alert('��ѡ����һ����!')</script>");
            else
            {
                _step_name = this.RadioButtonList1.SelectedItem.Text.ToString();
                if (tsyj.Visible == true && _zgbh != "0001" && _zgbh != "0002" && _zgbh != "0003" && _zgbh != "0004" && _zgbh != "0005" && _zgbh != "0008" && _zgbh != "0009" && _zgbh != "0183" && tsyj.Text == string.Empty && _step_id != 8)
                    Response.Write("<script>alert('���˱�����д���!')</script>");
                else
                {
                    if (_step_id < 8)
                        DeleteYj();
                    //����һ����������Ҫ��������  wy 20090529
                    int _slct_rlist = Convert.ToInt32(RadioButtonList1.SelectedValue);
                    //��Ӳ���13�벽��4��6��ͬ���Ĵ��� wy 20090529  15/16 
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
                                Response.Write("<script>alert('ǩ��ǰ����ת���ռ���!')</script>");
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
                                //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "�����¹���", GetTitle(), _url);
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
                            //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "�����¹���", GetTitle(), _url);
                            Response.Redirect("../Workflow/Work_Manage.aspx");
                        }
                    }
                    else if (_slct_rlist == 5) // huiqian
                    {
                        _obj_zgbh = SlctMember1.Send[1].ToString();
                        if (obj.Text == "��")
                            Response.Write("<script>alert('��ѡ���ǩ��Ա')</script>");
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
                            //_msg.InsertMsg(_obj_zgbh.Trim(), "�����¹���", GetTitle(), _url);
                            Response.Redirect("../Workflow/Work_Manage.aspx");
                        }
                    }
                    else if (_slct_rlist == 8)  //qianfa pizhuan
                    {
                        //tonzoc-20110922
                        //ɾ��ǩ��ǰ������������
                        DeleteYjAll();

                        _obj_zgbh = string.Empty;
                        string _temp = hz.Text.ToString();
                        if (verify(_temp) == true)
                            Response.Write("<script>alert('������Ա�������ظ�!')</script>");
                        else
                        {
                            //ǩ�����ɱ��
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
                            //_msg.InsertMsg(_obj_zgbh.Trim(), "�����¹���", GetTitle(), _url);
                            Response.Redirect("../Workflow/Work_Manage.aspx");
                        }
                    }
                    else if (_slct_rlist == 9) // zhuanfa ��ת
                    {
                        _obj_zgbh = SlctMember1.Send[1].ToString();

                        if (obj.Text == "��")
                            Response.Write("<script>alert('��ѡ����Ա!')</script>");
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

                            if (_step_id == 16)             // 2009/09/10 ��֤���ܲ�����ת��������תΪǩ�ձ���һ��
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
                        //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "�����¹���", GetTitle(), _url);
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
                    else if (_slct_rlist == 16)  //  2009/09/10     ����ӶԵ�16�����в���
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
                        //_msg.InsertMsg(DropDownList1.SelectedItem.Value.ToString().Trim(), "�����¹���", GetTitle(), _url);
                        Response.Redirect("../Workflow/Work_Manage.aspx");
                    }
                }
            }
        }

        #endregion
        #region ѡ����Ա
        private void Button1_Click(object sender, System.EventArgs e)
        {
            obj.Text = SlctMember1.Send[0].ToString();
            if (obj.Text == string.Empty)
                obj.Text = "��";
            _obj_zgbh = SlctMember1.Send[1].ToString();
            count = Convert.ToInt32(SlctMember1.Send[2]);
        }
        #endregion
        #region ѡ���ռ���
        private void Button3_Click(object sender, System.EventArgs e)
        {
            obj2.Text = SlctMember2.Send[0].ToString();
            if (obj2.Text == string.Empty)
                obj2.Text = "��";
            string _temp = obj2.Text + "," + sjr.Text + "," + cb.Text + "," + cs.Text + "," + ms.Text;
            hz.Text = string.Empty;
            for (int i = 0; i < _temp.Split(',').Length; i++)
            {
                if (_temp.Split(',')[i].ToString() == "��")
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
                ms.Text = "��";
            hz.Text = string.Empty;
            SqlConnection conn = new SqlConnection(StokeGlobals.Connectiondsoc);
            string sql = "select b,c,d,f from dbo.DSOC_Flow_Style_Data where Doc_ID = '" + _doc_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sjr.Text = dr["b"].ToString() == string.Empty ? "��" : dr["b"].ToString();
                cb.Text = dr["c"].ToString() == string.Empty ? "��" : dr["c"].ToString();
                cs.Text = dr["d"].ToString() == string.Empty ? "��" : dr["d"].ToString();
            }
            string _temp = obj2.Text + "," + sjr.Text + "," + cb.Text + "," + cs.Text + "," + ms.Text;
            for (int i = 0; i < _temp.Split(',').Length; i++)
            {
                if (_temp.Split(',')[i].ToString() == "��")
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
