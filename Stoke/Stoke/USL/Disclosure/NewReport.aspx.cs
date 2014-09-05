using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Stoke.BLL;

namespace Stoke.USL.Disclosure
{
    public partial class NewReport : System.Web.UI.Page
    {
        string id = "";
        string docid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] str = { "��", "һ", "��", "��", "��", "��", "��", "��", "��", "��", "ʮ", "ʮһ", "ʮ��", "ʮ��", "ʮ��", "ʮ��", "ʮ��", "ʮ��", "ʮ��", "ʮ��", "��ʮ", "��ʮһ", "��ʮ��", "��ʮ��", "��ʮ��", "��ʮ��", "��ʮ��", "��ʮ��", "��ʮ��", "��ʮ��", "��ʮ", "��ʮһ"};
            if (Request.QueryString["ID"] != null)
            {
                id = Request.QueryString["ID"].ToString();
            }

            if (Request.QueryString["doc_id"] != null)
            {
                docid = Request.QueryString["doc_id"].ToString();
            }
            if (!IsPostBack)
            {
                if (id == "")
                {
                    RepID.Text = DateTime.Now.ToString("yyyy-MM");
                    
                    string dd = DateTime.Now.ToString("yyyyMMdd");
                    string dtext = "";
                    for (int i = 0; i < dd.Length; i++)
                    {
                        if (i < 4)
                        {
                            dtext += str[Convert.ToInt32(dd.Substring(i, 1))];
                            if (i == 3)
                            {
                                dtext += "��";
                            }
                        }
                        if (i == 5)
                        {
                            dtext += str[Convert.ToInt32(dd.Substring(i - 1, 2))];
                            dtext += "��";
                        }
                        if (i == 7)
                        {
                            dtext += str[Convert.ToInt32(dd.Substring(i - 1, 2))];
                            dtext += "��";
                        }
                    }
                    RepDate.Text = dtext;
                    

                    DataTable dtt = SystemUM.GetInitInfo();
                    if (dtt.Rows.Count > 0)
                    {
                        if (dtt.Rows[0]["ShareID"].ToString() != "")
                        {
                            ShareID.Text = dtt.Rows[0]["ShareID"].ToString();
                        }
                        if (dtt.Rows[0]["ShareName"].ToString() != "")
                        {
                            ShareName.Text = dtt.Rows[0]["ShareName"].ToString();
                        }
                        if (dtt.Rows[0]["Company"].ToString() != "")
                        {
                            Company.Text = dtt.Rows[0]["Company"].ToString();
                        }
                        if (dtt.Rows[0]["Author"].ToString() != "")
                        {
                            Author.Text = dtt.Rows[0]["Author"].ToString();
                        }
                        else
                        {
                            Author.Text = "���»�";
                        }
                        if (dtt.Rows[0]["RepDesc"].ToString() != "")
                        {
                            RepDesc.Text = dtt.Rows[0]["RepDesc"].ToString();
                        }
                        else
                        {
                            RepDesc.Text = "����˾�����»�ȫ���Ա��֤���������ݲ������κ���ټ��ء����Գ��������ش���©�����������ݵ���ʵ�ԡ�׼ȷ�Ժ������Գе������������Ρ�";
                        }
                    }
                    else 
                    {
                        Author.Text = "���»�";
                        RepDesc.Text = "����˾�����»�ȫ���Ա��֤���������ݲ������κ���ټ��ء����Գ��������ش���©�����������ݵ���ʵ�ԡ�׼ȷ�Ժ������Գе������������Ρ�";
                    }


                    if (docid != "")
                    {
                        DataTable dtt1 = SystemUM.GetDocInfoByDocID(docid);
                        if (dtt1.Rows.Count > 0)
                        {
                            RepName.Text = dtt1.Rows[0]["w"].ToString();
                            RepContent.Text = dtt1.Rows[0]["x"].ToString();
                        }
                    }
                }
                else {
                    DataTable dt = SystemUM.GetRepInfo("","","",id,"1");
                    RepID.Text = dt.Rows[0]["RepID"].ToString();
                    ShareID.Text = dt.Rows[0]["ShareID"].ToString();
                    ShareName.Text = dt.Rows[0]["ShareName"].ToString();
                    Company.Text = dt.Rows[0]["Company"].ToString();
                    Author.Text = dt.Rows[0]["Author"].ToString();
                    RepName.Text = dt.Rows[0]["RepName"].ToString();
                    RepContent.Text = dt.Rows[0]["RepContent"].ToString();
                    RepDate.Text = dt.Rows[0]["RepDate"].ToString();
                    RepDesc.Text = dt.Rows[0]["RepDesc"].ToString();
                    addBtn.Text = "�޸�";
                }
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string repid = RepID.Text.Trim();
            string shareid = ShareID.Text.Trim();
            string sharename = ShareName.Text.Trim();
            string company = Company.Text.Trim();
            string author = Author.Text.Trim();
            string repname = RepName.Text.Trim();
            string repcontent = RepContent.Text.Trim();
            string repdate = RepDate.Text.Trim();
            string repdesc = RepDesc.Text.Trim();
            string realtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (id == "")
            {
                if (SystemUM.editReportInfo("", repid, shareid, sharename, company, author, repname, repcontent, repdate, repdesc,realtime, "0"))
                    Uti.ShowDialog("������Ϣ��ӳɹ���", "ReportList.aspx", this.Page);
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�������ʧ�ܣ��������Ա��ϵ��');</script>");
            }
            else if (id != "") {
                if (SystemUM.editReportInfo(id, repid, shareid, sharename, company, author, repname, repcontent, repdate, repdesc, realtime, "1"))
                    Uti.ShowDialog("������Ϣ�޸ĳɹ���", "ReportList.aspx", this.Page);
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('�����޸�ʧ�ܣ��������Ա��ϵ��');</script>");
            }
        }


        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportList.aspx");
        }
    }
}
