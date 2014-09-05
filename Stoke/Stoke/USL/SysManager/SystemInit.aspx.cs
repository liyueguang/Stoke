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

namespace Stoke.USL.SysManager
{
    public partial class SystemInit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DataTable dtt = SystemUM.GetInitInfo();
                if (dtt.Rows.Count > 0)
                {
                    shareID.Text = dtt.Rows[0]["ShareID"].ToString();
                    shareName.Text = dtt.Rows[0]["ShareName"].ToString();
                    company.Text = dtt.Rows[0]["Company"].ToString();
                    author.Text = dtt.Rows[0]["Author"].ToString();
                    repDesc.Text = dtt.Rows[0]["RepDesc"].ToString();
                }
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../MainForm/mainWin.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (shareID.Text == "" || shareName.Text == "" || company.Text == "" || author.Text == "" || repDesc.Text == "")
            {
                Uti.ShowDialog("�뽫�����ʼ����Ϣ���������", this.Page);
                return;
            }

            string shareid = shareID.Text;
            string sharename = shareName.Text;
            string scompany = company.Text;
            string sauthor = author.Text;
            string repdesc = repDesc.Text;

            try
            {
                SystemUM.UpdateInitInfo(shareid, sharename, scompany, sauthor, repdesc);
                Uti.ShowDialog("�����ʼ����Ϣ�޸ĳɹ���", "../MainForm/mainWin.aspx", this.Page);
            }
            catch(Exception)
            {
                Uti.ShowDialog("�����ʼ����Ϣ�޸�ʧ�ܣ��������Ա��ϵ��", this.Page);
            }
        }
    }
}
