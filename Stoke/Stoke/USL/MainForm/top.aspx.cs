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

namespace Stoke.USL.MainForm
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void zhuye_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>top.location.href='index.aspx'</script>");
        }

        protected void zhuxiao_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["username"] != null)
            {
                Session.Clear();
                Session.Abandon();//强制取消当前会话，关键所在！
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>top.location.href='../login.aspx'</script>");
        }
    }
}
