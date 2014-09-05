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

namespace Stoke.USL.Disclosure
{
    public partial class Finance : System.Web.UI.Page
    {
        protected static string stext = "";
        protected static string stextreplace = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = SystemUM.GetFinanceInfo("", "", "", "1", "1");
                stext = dt.Rows[0]["Finance"].ToString();
                stextreplace = dt.Rows[0]["Finance"].ToString();
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            stext = stextreplace;
            if (Guanjianzi.Text.Trim() != "" && stext.IndexOf(Guanjianzi.Text.Trim()) >= 0)
            {
                stext = stext.Replace(Guanjianzi.Text.Trim(), "<span style='background-color:yellow;'>" + Guanjianzi.Text.Trim() + "</span>");
            }
        }

        protected void Guanjianzi_TextChanged(object sender, EventArgs e)
        {
            SearchBtn_Click(null, null);
        }
    }
}
