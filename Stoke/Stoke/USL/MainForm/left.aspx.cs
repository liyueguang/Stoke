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

namespace Stoke.USL.MainForm
{
    public partial class left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                yh.Text = Session["username"].ToString();
                string iurl = Utility.GetUserImage(Session["usernum"].ToString());
                if (iurl != "0")
                {
                    this.touxiang.ImageUrl = iurl;
                }
            }
            else {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('请先登录，在进行操作！');top.location.href='../login.aspx'</script>");
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Session.Clear();
                Session.Abandon();//强制取消当前会话，关键所在！
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "close", "<script>window.top.open('','_top',''); window.top.close(); </script>");
        }

        protected void Logoff(object sender, EventArgs e)
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
