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

namespace Stoke.USL.Disclosure
{
    public partial class DownLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = @"~\DocInfo\" + Request.QueryString["realname"];
            string filePath = Server.MapPath(path);//这里注意了,你得指明要下载文件的路径.
            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('该模板不存在，如需要请联系管理员');window.location.href='DocLoad.aspx'</script>");
            }
        }
    }
}
