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
using System.IO;

namespace Stoke.USL.Disclosure
{
    public partial class ReportView : System.Web.UI.Page
    {
        string id = "4";
        protected string RepID = "";
        protected string ShareID = "";
        protected string ShareName = "";
        protected string Company = "";
        protected string Author = "";
        protected string RepName = "";
        protected string RepContent = "";
        protected string RepDate = "";
        protected string RepDesc = "";
        protected string flag = "2";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
                flag = Request.QueryString["flag"].ToString();
                DataTable dt = SystemUM.GetRepInfo("", "", "", id, "1");
                RepID = "������:" + dt.Rows[0]["RepID"].ToString();
                ShareID = "�ɷݴ���:" + dt.Rows[0]["ShareID"].ToString();
                ShareName = "�ɷݼ��:" + dt.Rows[0]["ShareName"].ToString();
                Company = dt.Rows[0]["Company"].ToString();
                Author = dt.Rows[0]["Author"].ToString();
                RepName = dt.Rows[0]["RepName"].ToString().Trim();
                RepContent = dt.Rows[0]["RepContent"].ToString();
                RepDate = dt.Rows[0]["RepDate"].ToString();
                RepDesc = dt.Rows[0]["RepDesc"].ToString();
            }
        }

        protected void Word_Click(object sender, EventArgs e)
        {
            string fileName = RepName + ".doc";  //ȡword���� 
            string filePath = Server.MapPath("html/" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc");//·��
            try
            {
                if (File.Exists(filePath))
                {
                    XiaZai(fileName, filePath);
                }
                else
                {
                    Function.WriteHtml(RepID, ShareID, ShareName, Company, Author, RepName, RepContent, RepDate, RepDesc);  //����word�ĵ�
                    XiaZai(fileName, filePath);
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Word����ʧ�ܣ����Ժ����ԣ�');</script>");
            }
        }

        protected void PDF_Click(object sender, EventArgs e)
        {
            string wordpath = Server.MapPath("html");
            string fileName = RepName + ".pdf";  //ȡpdf���� 
            string filePath = Server.MapPath("html/" + RepName + DateTime.Now.ToString("yyyyMM") + ".pdf");//·��
            string filePathWord = Server.MapPath("html/" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc");//Word·��
            try
            {
                if (File.Exists(filePath))
                {
                    XiaZai(fileName, filePath);
                }
                else
                {
                    if (File.Exists(filePathWord))
                    {
                        ConvertToPDF.DOCConvertToPDF(wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc", wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".pdf");  //��word�ĵ�ת��ΪPDF�ĵ�
                        XiaZai(fileName, filePath);
                    }
                    else
                    {
                        Function.WriteHtml(RepID, ShareID, ShareName, Company, Author, RepName, RepContent, RepDate, RepDesc);  //����word�ĵ�
                        ConvertToPDF.DOCConvertToPDF(wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc", wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".pdf");  //��word�ĵ�ת��ΪPDF�ĵ�
                        XiaZai(fileName, filePath);
                    }
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('PDF����ʧ�ܣ����Ժ����ԣ�');</script>");
            }
        }

        protected void XiaZai(string fileName, string filePath)   //�������ɺõ��ļ�
        {
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(fileName));
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }

    }
}
