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
                RepID = "公告编号:" + dt.Rows[0]["RepID"].ToString();
                ShareID = "股份代码:" + dt.Rows[0]["ShareID"].ToString();
                ShareName = "股份简称:" + dt.Rows[0]["ShareName"].ToString();
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
            string fileName = RepName + ".doc";  //取word名称 
            string filePath = Server.MapPath("html/" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc");//路径
            try
            {
                if (File.Exists(filePath))
                {
                    XiaZai(fileName, filePath);
                }
                else
                {
                    Function.WriteHtml(RepID, ShareID, ShareName, Company, Author, RepName, RepContent, RepDate, RepDesc);  //生成word文档
                    XiaZai(fileName, filePath);
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Word导出失败，请稍后再试！');</script>");
            }
        }

        protected void PDF_Click(object sender, EventArgs e)
        {
            string wordpath = Server.MapPath("html");
            string fileName = RepName + ".pdf";  //取pdf名称 
            string filePath = Server.MapPath("html/" + RepName + DateTime.Now.ToString("yyyyMM") + ".pdf");//路径
            string filePathWord = Server.MapPath("html/" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc");//Word路径
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
                        ConvertToPDF.DOCConvertToPDF(wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc", wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".pdf");  //将word文档转化为PDF文档
                        XiaZai(fileName, filePath);
                    }
                    else
                    {
                        Function.WriteHtml(RepID, ShareID, ShareName, Company, Author, RepName, RepContent, RepDate, RepDesc);  //生成word文档
                        ConvertToPDF.DOCConvertToPDF(wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".doc", wordpath + "\\" + RepName + DateTime.Now.ToString("yyyyMM") + ".pdf");  //将word文档转化为PDF文档
                        XiaZai(fileName, filePath);
                    }
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('PDF导出失败，请稍后再试！');</script>");
            }
        }

        protected void XiaZai(string fileName, string filePath)   //下载生成好的文件
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
