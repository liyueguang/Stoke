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
    public class Security
    {
        /// <summary>
        /// ����ϵͳ�Դ��ļ��ܷ�������MD5����
        /// </summary>
        /// <param name="strSource">Ҫ���м��ܵ��ַ���</param>
        /// <returns>���ؼ��ܺ���ַ���</returns>
        public static string GetMd5Code(string strSource)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strSource, "MD5");
        }
    }
}
