using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Stoke.BLL
{
    public class Uti
    {
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="page"></param>
        public static void ShowDialog(string message, System.Web.UI.Page page)
        {
            System.Web.HttpResponse Response = page.Response;
            Response.Write("<script>alert('" + message + "');</script>");
        }

        /// <summary>
        /// 弹出消息框并转入另外一页面
        /// </summary>
        /// <param name="message">消息提示</param>
        /// <param name="nextPage">另一页面</param>
        /// <param name="page"></param>
        public static void ShowDialog(string message, string nextPage, System.Web.UI.Page page)
        {
            System.Web.HttpResponse Response = page.Response;
            Response.Write("<script>alert('" + message + "');location.href='" + nextPage + "';</script>");
        }

        public static void ShowDialog_JS(string message, System.Web.UI.Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script type='text/javascript'>alert('" + message + "');</script>");
        }
    }
}
