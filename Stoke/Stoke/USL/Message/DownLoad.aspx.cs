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
using System.IO;

namespace Stoke.USL.Message
{
    public partial class DownLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Request.QueryString["nameaddr"];
            string filePath = Server.MapPath(path);//����ע����,���ָ��Ҫ�����ļ���·��.
            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //�����������
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(Request.QueryString["name"])); //��������ļ�������    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else 
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('�����Ѿ���ɾ��������ϵ�����Ա');history.go(-1);</script>");
            }
        }
    }
}
