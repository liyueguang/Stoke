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
    /// CommHandler��������������ͨ�õķ��� 
    /// </summary>
    public class CommHandler
    {

        #region �ַ���ת������

        /// <summary>
        /// ��ǰ̨��ȡ�Ĵ��ո��ַ����Ĵ���
        /// </summary>
        /// <param name="s">�������ַ���</param>
        /// <returns>�������ַ���</returns>
        public static string FormatNullString(string s)
        {
            s = s.Replace("&nbsp;", " ");
            return s.Trim();
        }

        /// <summary>
        /// ���ַ���ת��Ϊ����
        /// </summary>
        /// <param name="str">��ת�����ַ���</param>
        /// <returns>ת���������</returns>
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
        /// ���ַ���ת��Ϊ������
        /// </summary>
        /// <param name="str">��ת�����ַ���</param>
        /// <returns>ת����ĸ�����</returns>
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
        /// ���ַ���ת��Ϊ���ڸ�ʽ
        /// </summary>
        /// <param name="val">��ת�����ַ���</param>
        /// <returns>ת���������</returns>
        public static DateTime StringToDateTime(string val)
        {
            //���ַ���Ϊ�գ�������С����
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

        #region ִ��ǰ̨�ű����

        /// <summary>
        /// ����ҳ���ض���ָ����URL
        /// </summary>
        /// <param name="pg">ҳ��</param>
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
        /// ҳ���ض��򵽵�¼ҳ
        /// </summary>
        /// <param name="pg">ҳ��</param>
        public static void ReDirURL(System.Web.UI.Page pg)
        {
            string url = "Login.aspx";
            ReDirURL(pg, url);
        }

        /// <summary>
        /// Ϊ��ť���ȷ����Ϣ
        /// </summary>
        /// <param name="btn">��ť</param>
        /// <param name="msg">ȷ����Ϣ����</param>
        public static void AddConfirm(Button btn, string msg)
        {
            //Ϊ��ť���ȷ����Ϣ
            btn.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// ������ʾ��
        /// </summary>
        /// <param name="pg">ҳ��</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Alert(Page pg, string msg)
        {
            //����ǰ��̨���������ַ��ķ�ʽ��һ�£���Ҫת��

            //����\\
            string p = @"(\\)";
            Regex r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\\\");

            //����\n
            p = @"(\n)";
            r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\n");

            //����\t
            p = @"(\t)";
            r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\t");

            //����\r
            p = @"(\r)";
            r = new Regex(p, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            msg = r.Replace(msg, "\\r");

            ////����\\[��\\\
            msg = msg.Replace("'", "\\[");
            msg = msg.Replace("\"", "\\\"");

            //Ҫ��ǰ̨�������ʾ����
            string cmd = "<script language=javascript for=document event=onreadystatechange>"
                + "alert('"
                + msg + "');"
                + "</script>";

            //���ǰ̨�ű�
            pg.Response.Write(cmd);
        }

        /// <summary>
        /// ��IFRAME��ʽ����ģ̬�Ի���
        /// </summary>
        /// <param name="pg">ҳ��</param>
        /// <param name="url">����ҳ���URL</param>
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
        /// ��IFRAME��ʽ����ģ̬�Ի���,ָ���Ի����С
        /// </summary>
        /// <param name="Page">ҳ��</param>
        /// <param name="url">����ҳ���URL</param>
        /// <param name="width">�Ի�����</param>
        /// <param name="height">�Ի���߶�</param>
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
        /// �践�ص���̨��ȷ�Ͽ�
        /// </summary>
        /// <param name="pg">ҳ��</param>
        /// <param name="msg">ȷ����Ϣ</param>
        /// <param name="CtlID">����ȷ�Ϸ���ֵ�ĺ�̨�ı���ID</param>
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
        /// �ı�������Ϊֻ��
        /// </summary>
        /// <param name="tb">�ı���</param>
        /// <param name="flag">true��ֻ��</param>
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
