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

namespace Stoke.USL.Message
{
    public partial class MsgView : System.Web.UI.Page
    {
        int msgid = 0;
        protected string msend = "";
        protected string mtitle = "";
        protected string minfo = "";
        protected string mdate = "";
        protected string FileName = "";
        protected string FileAddr = "";
        protected int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                msgid = Convert.ToInt32(Request.QueryString["ID"].ToString());
                flag = Convert.ToInt32(Request.QueryString["flag"].ToString());
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    DataTable dt = SystemUM.GetMessageByID(msgid);
                    msend = dt.Rows[0]["MsgSend"].ToString();
                    mtitle = dt.Rows[0]["MsgTitle"].ToString();
                    minfo = dt.Rows[0]["Message"].ToString();
                    mdate = dt.Rows[0]["SendDate"].ToString();
                    FileName = dt.Rows[0]["FileName"].ToString();
                    FileAddr = dt.Rows[0]["FileRealName"].ToString();
                    if (FileName == "") {
                        fujianlb.Visible = false;
                        fujianimg.Visible = false;
                    }
                }
            }
        }
    }
}
