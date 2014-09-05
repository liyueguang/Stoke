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
    public partial class EditFinance : System.Web.UI.Page
    {
        string msgid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                msgid = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    DataTable dt = SystemUM.GetFinanceInfo("", "", "", msgid, "1");
                    name.Text = dt.Rows[0]["Title"].ToString();
                    finance.Text = dt.Rows[0]["Finance"].ToString();
                }
            }
        }

        protected void fs_Click(object sender, EventArgs e)
        {
            string sname = name.Text.Trim();
            if (sname == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('请将信息填写完整，再点击提交');</script>");
                return;
            }
            string sfinance = finance.Text.Trim();
            sfinance = sfinance.Replace("'","‘");
            string sdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                SystemUM.GetFinanceInfo(sname,sfinance, sdate, msgid, "0");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('修改成功');location.href='Finance.aspx'</script>");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('修改失败')</script>");
            }
        }

        protected void qx_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>location.href='Finance.aspx'</script>");
        }
    }
}
