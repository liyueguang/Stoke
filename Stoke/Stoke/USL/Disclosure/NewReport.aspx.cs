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
            string[] str = { "〇", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十", "二十一", "二十二", "二十三", "二十四", "二十五", "二十六", "二十七", "二十八", "二十九", "三十", "三十一"};
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
                                dtext += "年";
                            }
                        }
                        if (i == 5)
                        {
                            dtext += str[Convert.ToInt32(dd.Substring(i - 1, 2))];
                            dtext += "月";
                        }
                        if (i == 7)
                        {
                            dtext += str[Convert.ToInt32(dd.Substring(i - 1, 2))];
                            dtext += "日";
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
                            Author.Text = "董事会";
                        }
                        if (dtt.Rows[0]["RepDesc"].ToString() != "")
                        {
                            RepDesc.Text = dtt.Rows[0]["RepDesc"].ToString();
                        }
                        else
                        {
                            RepDesc.Text = "本公司及董事会全体成员保证本公告内容不存在任何虚假记载、误导性陈述或者重大遗漏，并对其内容的真实性、准确性和完整性承担个别及连带责任。";
                        }
                    }
                    else 
                    {
                        Author.Text = "董事会";
                        RepDesc.Text = "本公司及董事会全体成员保证本公告内容不存在任何虚假记载、误导性陈述或者重大遗漏，并对其内容的真实性、准确性和完整性承担个别及连带责任。";
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
                    addBtn.Text = "修改";
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
                    Uti.ShowDialog("公告信息添加成功！", "ReportList.aspx", this.Page);
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('公告添加失败，请与管理员联系！');</script>");
            }
            else if (id != "") {
                if (SystemUM.editReportInfo(id, repid, shareid, sharename, company, author, repname, repcontent, repdate, repdesc, realtime, "1"))
                    Uti.ShowDialog("公告信息修改成功！", "ReportList.aspx", this.Page);
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('公告修改失败，请与管理员联系！');</script>");
            }
        }


        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportList.aspx");
        }
    }
}
