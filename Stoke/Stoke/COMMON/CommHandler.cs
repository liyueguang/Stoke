using System;
using System.Data;
using System.Web;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Stoke.DAL;

namespace Stoke.COMMON
{
    /// <summary>
    /// CommHandler类包含本解决方案通用的方法 
    /// </summary>
    public class CommHandler
    {

        #region 字符串转换方法

        /// <summary>
        /// 从前台获取的带空格字符串的处理
        /// </summary>
        /// <param name="s">待处理字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string FormatNullString(string s)
        {
            s = s.Replace("&nbsp;", " ");
            return s.Trim();
        }

        /// <summary>
        /// 将字符串转换为整数
        /// </summary>
        /// <param name="str">待转换的字符串</param>
        /// <returns>转换后的整数</returns>
        public static int StringToInt(string str)
        {
            int ret = 0;
            try
            {
                ret = int.Parse(str);
            }
            catch
            {
            }

            return ret;
        }

        /// <summary>
        /// 将字符串转换为浮点数
        /// </summary>
        /// <param name="str">待转换的字符串</param>
        /// <returns>转换后的浮点数</returns>
        public static double StringToDouble(string str)
        {
            double ret = 0.0;

            try
            {
                ret = double.Parse(str);
            }
            catch
            { }

            return ret;
        }

        /// <summary>
        /// 将字符串转换为日期格式
        /// </summary>
        /// <param name="val">待转换的字符串</param>
        /// <returns>转换后的日期</returns>
        public static DateTime StringToDateTime(string val)
        {
            //若字符串为空，返回最小日期
            if (val == string.Empty || val == null)
                return System.DateTime.MinValue;

            try
            {
                System.DateTime dt = System.DateTime.Parse(val);
                return dt;
            }
            catch
            {
                return System.DateTime.MinValue;
            }
        }

        public static string Today()
        {
            return DateTimeToString(System.DateTime.Today);
        }

        public static string DateTimeToString(DateTime d)
        {
            string ret = "";

            try
            {
                ret = d.ToString("yyyy-MM-dd");
            }
            catch
            { }

            if (ret == "0001-01-01")
            {
                ret = "";
            }

            return ret;
        }


        #endregion

        #region 执行前台脚本相关

        /// <summary>
        /// 整个页面重定向到指定的URL
        /// </summary>
        /// <param name="pg">页面</param>
        /// <param name="url">URL</param>
        public static void ReDirURL(System.Web.UI.Page pg, string url)
        {
            string cmd = "<script for=document event=onreadystatechange language=javascript>\n"
                + "top.main.window.location='"
                + url
                + "'</script> ";
            pg.Response.Write(cmd);
        }

        /// <summary>
        /// 页面重定向到登录页
        /// </summary>
        /// <param name="pg">页面</param>
        public static void ReDirURL(System.Web.UI.Page pg)
        {
            string url = "Login.aspx";
            ReDirURL(pg, url);
        }

        /// <summary>
        /// 为按钮添加确认信息
        /// </summary>
        /// <param name="btn">按钮</param>
        /// <param name="msg">确认信息内容</param>
        public static void AddConfirm(Button btn, string msg)
        {
            //为按钮添加确认信息
            btn.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="pg">页面</param>
        /// <param name="msg">提示信息</param>
        public static void Alert(Page pg, string msg)
        {
            //由于前后台处理特殊字符的方式不一致，需要转换

            //处理\\
            string p = @"(\\)";
            Regex r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\\\");

            //处理\n
            p = @"(\n)";
            r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\n");

            //处理\t
            p = @"(\t)";
            r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\t");

            //处理\r
            p = @"(\r)";
            r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\r");

            ////处理\\[和\\\
            msg = msg.Replace("'", "\\[");
            msg = msg.Replace("\"", "\\\"");

            //要向前台输出的提示命令
            string cmd = "<script language=javascript for=document event=onreadystatechange>"
                + "alert('"
                + msg + "');"
                + "</script>";

            //输出前台脚本
            pg.Response.Write(cmd);
        }

        /// <summary>
        /// 用IFRAME方式弹出模态对话框
        /// </summary>
        /// <param name="pg">页面</param>
        /// <param name="url">弹出页面的URL</param>
        public static void IFrame_PopUp(Page pg, string url)
        {
            string cmd = @"<script language=javascript for=window event=onload>
				var w=screen.width;
				var h=screen.height;
				var iw=parseInt(w*0.7);
				var ih=parseInt(h*0.5);
				
				var style='dialogWidth:' + iw + 'px;dialogHeight:' +ih +'px;center:yes;scroll:no;status:no;help:no' ;
					
				var ret=window.showModalDialog(
					'Frame.aspx?url=" + pg.Server.UrlEncode(url) +
                @"',window,style);
				if((ret)&&(ret!=''))
				{
					window.location=ret;
				}</script>";

            pg.RegisterClientScriptBlock("pop", cmd);
        }

        /// <summary>
        /// 用IFRAME方式弹出模态对话框,指定对话框大小
        /// </summary>
        /// <param name="Page">页面</param>
        /// <param name="url">弹出页面的URL</param>
        /// <param name="width">对话框宽度</param>
        /// <param name="height">对话框高度</param>
        public static void IFrame_PopUp(Page pg, string url, string width, string height)
        {
            string cmd = @"<script language=javascript for=window event=onload>
				var iw=" + width + @";
				var ih=" + height + @";
				
				var style='dialogWidth:' + iw + 'px;dialogHeight:' +ih +'px;center:yes;scroll:no;status:no;help:no' ;
					
				var ret=window.showModalDialog(
					'Frame.aspx?url=" + pg.Server.UrlEncode(url) +
                @"',window,style);
				
				if((ret)&&(ret!=''))
				{
					window.location=ret;
				}</script>";
            pg.RegisterClientScriptBlock("pop", cmd);
        }

        /// <summary>
        /// 需返回到后台的确认框
        /// </summary>
        /// <param name="pg">页面</param>
        /// <param name="msg">确认信息</param>
        /// <param name="CtlID">接收确认返回值的后台文本框ID</param>
        public static void ConfirmReturnServer(Page pg, string msg, string textbox)
        {
            string cmd = "var val=confirm('" + msg + "');"
                + "var txt=document.getElementById('" + textbox + "');"
                + "txt.value=val;"
                + "__doPostBack('" + textbox + "','')";
            cmd = "<script>" + cmd + "</script>";
            pg.RegisterStartupScript("con", cmd);
        }

        #endregion

        /// <summary>
        /// 文本框设置为只读
        /// </summary>
        /// <param name="tb">文本框</param>
        /// <param name="flag">true：只读</param>
        public static void TextBoxReadOnly(TextBox tb, bool flag)
        {
            if (flag)
            {
                tb.ReadOnly = true;
                tb.BackColor = Color.Gray;
            }
            else
            {
                tb.ReadOnly = false;
                tb.BackColor = Color.White;
            }
        }

        public static void BindGrid(DataGrid dg, DataTable dt)
        {
            if (dt == null)
                dt = new DataTable();

            dg.DataSource = dt;
            dg.DataBind();
        }
    }
}
