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
using System.IO;

namespace Stoke.USL.Message
{
    public partial class MsgSend : System.Web.UI.Page
    {
        int msgid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                msgid = Convert.ToInt32(Request.QueryString["ID"].ToString());
            }
            if (!IsPostBack)
            {
                DataTable dtt = null;
                if (Request.QueryString["ID"] != null)
                {
                    DataTable dt = SystemUM.GetMessageByID(msgid);
                    //sgr.Text = dt.Rows[0]["MsgReceive"].ToString();
                    zhuti.Text = dt.Rows[0]["MsgTitle"].ToString();
                    message.Text = dt.Rows[0]["Message"].ToString();
                    xxlx.SelectedValue = dt.Rows[0]["MsgType"].ToString();
                    fs.Text = "�޸�";

                    dtt = SystemUM.GetMessageUser(msgid);
                    this.roleLbx.DataSource = dtt;
                    this.roleLbx.DataTextField = "UserNN";
                    this.roleLbx.DataValueField = "UserNum";
                    this.roleLbx.DataBind();
                }

                dtt = SystemUM.GetUserInfoByNRPC("", "", "", "");
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    ListItem lii = new ListItem(dtt.Rows[i]["UserNumber"].ToString() + " " + dtt.Rows[i]["UserName"].ToString(), dtt.Rows[i]["UserNumber"].ToString());
                    if (!roleLbx.Items.Contains(lii))
                    {
                        this.CandidateRoleLbx.Items.Add(lii);
                    }
                }
            }
        }

        protected void fs_Click(object sender, EventArgs e)
        {
            //string ssgr = sgr.Text.Trim();
            string ssgr = "";
            foreach (ListItem li in this.roleLbx.Items)
            {
                ssgr = ssgr + li.Value.ToString() + ",";
            }

            string szhuti = zhuti.Text.Trim();
            string sxxlx = xxlx.SelectedValue.ToString();
            if (szhuti == "" || ssgr == "" || sxxlx == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('�뽫��Ϣ��д�������ٵ���ύ');</script>");
                return;
            }
            if (!ssgr.EndsWith(",")) 
            {
                ssgr = ssgr + ",";
            }
            string smessage = message.Text.Trim();
            string sfsr = Session["usernum"].ToString();
            string sdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //�ϴ�����--------------------------------------------------------------------------
            string ScfileName = "";
            string ScName = "";
            try
            {
                HttpFileCollection fileList = HttpContext.Current.Request.Files;
                HttpPostedFile hPostedFile = fileList[0];

                ///��ȡ�����ļ����ļ�����
                ScfileName = Path.GetFileName(hPostedFile.FileName);
                ScName = ScfileName;
                //��СKB
                int Size = int.Parse(fileList[0].ContentLength.ToString()) / 1024;

                if (!"".Equals(ScfileName) && ScfileName != null)
                {
                    ///CheckUser.UserID   ���渽��
                    ScfileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ScfileName;
                    hPostedFile.SaveAs(MapPath("../../UploadFile/") + ScfileName);
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('�����ϴ�ʧ�ܣ������³���')</script>");
                return;
            }

            if (msgid == 0)
            {
                try
                {
                    SystemUM.addMessage(sfsr, ssgr, sxxlx, szhuti, smessage, sdate, ScName, "../../UploadFile/" + ScfileName);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('���ͳɹ�');location.href='MsgSendList.aspx'</script>");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('����ʧ��')</script>");
                }
            }
            else
            {
                try
                {
                    SystemUM.EditMessageByID(msgid, ssgr, sxxlx, szhuti, smessage, sdate, ScName, "../../UploadFile/" + ScfileName);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('�޸ĳɹ�');location.href='MsgSendList.aspx'</script>");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('�޸�ʧ��')</script>");
                }
            }
        }

        protected void qx_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>location.href='MsgSendList.aspx'</script>");
        }

        protected void roleAddBtn_Click(object sender, EventArgs e)
        {
            int listboxcount = this.CandidateRoleLbx.Items.Count;
            int count = 0;
            foreach (ListItem li in this.CandidateRoleLbx.Items)
            {
                if (li.Selected)
                {
                    this.roleLbx.Items.Add(li);
                    this.CandidateRoleLbx.Items.Remove(li);
                    count++;
                }
                if (this.CandidateRoleLbx.Items.Count <= 0 || this.CandidateRoleLbx.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ѡ��һ�������û���');</script>");
            }
        }

        protected void roleDelBtn_Click(object sender, EventArgs e)
        {
            int listboxcount = this.roleLbx.Items.Count;
            int count = 0;
            foreach (ListItem li in this.roleLbx.Items)
            {
                if (li.Selected)
                {
                    this.CandidateRoleLbx.Items.Add(li);
                    this.roleLbx.Items.Remove(li);
                    count++;
                }
                if (this.roleLbx.Items.Count <= 0 || this.roleLbx.Items.Count != listboxcount)
                    return;
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('��ѡ��һ�������û���');</script>");
            }
        }
    }
}
