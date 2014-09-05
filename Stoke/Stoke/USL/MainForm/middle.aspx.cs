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
    public partial class middle : System.Web.UI.Page
    {
        protected string browser = "";
        protected string[] stitle = new string[20];
        protected string[] sauthor = new string[20];
        protected string[] sdate = new string[20];
        protected string[] scontent = new string[20];
        protected int scnt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            browser = Page.Request.Browser.Browser;
            if (Session["usernum"] != null)
            {
                DataTable dt = SystemUM.GetMessageByCount(Session["usernum"].ToString(), "20", "", DateTime.Now.ToString("yyyy-MM-dd"));
                if (dt.Rows.Count > 0)
                {
                    scnt = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        stitle[i] = dt.Rows[i]["title"].ToString();
                        sauthor[i] = dt.Rows[i]["MsgSend"].ToString();
                        sdate[i] = dt.Rows[i]["SendDate"].ToString().Substring(0, 10);
                        scontent[i] = dt.Rows[i]["Message"].ToString();
                    }
                }
                else {
                    shadow.Visible = false;
                    popupcontent.Visible = false;
                }
            }
            
        }
    }
}
