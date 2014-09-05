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

namespace Stoke.USL
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request.Cookies["name"] != null)
                {
                    HttpCookie cname = Request.Cookies["name"];
                    if (cname.Values["uname"].ToString() != "")
                    {
                        uname.Text = cname.Values["uname"].ToString();
                        passwd.Attributes["value"] = cname.Values["passwd"].ToString();
                        login1.Focus();
                    }
                    else
                    {
                        uname.Focus();
                    }
                }
                else
                {
                    uname.Focus();
                }
            }
        }

        protected void login_Click(object sender, ImageClickEventArgs e)
        {
            string suname = uname.Text.Trim();
            string spasswd = passwd.Text.Trim();

            //判断用户名和密码是否正确
            DataTable dt = SystemUM.checkUserByNum(suname);
            if (dt.Rows.Count <= 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('用户编号不存在！')</script>");
                return;
            }
            string passwd1 = dt.Rows[0]["LoginPassword"].ToString();

            if (passwd1 == Security.GetMd5Code(spasswd))
            {
                //如果用户名和密码都正确，则记录用户名 密码 权限
                Session["username"] = dt.Rows[0]["UserName"].ToString();
                Session["usernum"] = dt.Rows[0]["UserNumber"].ToString();
                Session["zgbh"] = dt.Rows[0]["UserNumber"].ToString();
                Session["permrange"] = dt.Rows[0]["PermRange"].ToString();
                Session["userid"] = dt.Rows[0]["UserID"].ToString();
                if (keeppwd.Checked == true)
                {
                    HttpCookie cookie = new HttpCookie("name");
                    cookie.Values.Add("uname", suname);
                    cookie.Values.Add("passwd", spasswd);
                    cookie.Expires = DateTime.Now + new TimeSpan(20, 0, 0, 0);
                    Response.AppendCookie(cookie);
                }
                Response.Redirect("MainForm/index.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('用户密码错误！')</script>");
                return;
            }

            //if (Request.Cookies["name"] != null)
            //{
            //    HttpCookie cname = Request.Cookies["name"];
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('" + cname.Values["uname"].ToString() + "')</script>");
            //}
        }
        //protected void uname_TextChanged(object sender, EventArgs e)
        //{
        //    if (Request.Cookies["name"] != null)
        //    {
        //        HttpCookie cname = Request.Cookies["name"];
        //        if (cname.Values["uname"].ToString() == uname.Text.Trim())
        //        {
        //            passwd.Attributes["value"] = cname.Values["passwd"].ToString();
        //        }
        //        else
        //        {
        //            passwd.Attributes["value"] = "";
        //        }
        //    }
        //    passwd.Focus();
        //}
    }
}
