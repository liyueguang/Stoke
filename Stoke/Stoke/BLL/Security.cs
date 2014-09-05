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
        /// 利用系统自带的加密方法进行MD5加密
        /// </summary>
        /// <param name="strSource">要进行加密的字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public static string GetMd5Code(string strSource)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strSource, "MD5");
        }
    }
}
