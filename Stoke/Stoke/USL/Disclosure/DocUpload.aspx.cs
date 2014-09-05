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
using Stoke.BLL;

namespace Stoke.USL.Disclosure
{
    public partial class DocUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string sharename = DocName.Text.Trim();
            string repdesc = DocDesc.Text.Trim();
            string doctype = "doc/pdf";
            string author = Session["usernum"].ToString();
            string realtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //上传附件--------------------------------------------------------------------------
            string ScfileName = "";
            string ScName = "";
            try
            {
                HttpFileCollection fileList = HttpContext.Current.Request.Files;
                HttpPostedFile hPostedFile = fileList[0];

                ///获取上载文件的文件名称
                ScfileName = Path.GetFileName(hPostedFile.FileName);
                ScName = ScfileName;
                //大小KB
                int Size = int.Parse(fileList[0].ContentLength.ToString()) / 1024;

                if (!"".Equals(ScfileName) && ScfileName != null)
                {
                    ///CheckUser.UserID   保存附件
                    ScfileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ScfileName;
                    hPostedFile.SaveAs(MapPath("../../DocInfo/") + ScfileName);
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('附件上传失败！请重新尝试')</script>");
                return;
            }

            try
            {
                SystemUM.addDocInfo(sharename, ScfileName, repdesc, doctype, author, realtime);
                Uti.ShowDialog("模板信息添加成功！", "DocLoad.aspx", this.Page);
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('模板添加失败，请与管理员联系！');</script>");
            }
        }


        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocLoad.aspx");
        }
    }
}
