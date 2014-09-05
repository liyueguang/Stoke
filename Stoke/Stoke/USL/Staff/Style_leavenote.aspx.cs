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
using Stoke.DAL;
using Stoke.BLL;

namespace Stoke.USL.Staff
{
    public partial class Style_leavenote : System.Web.UI.Page
    {
        int doc_id = 0;
        string zgbh = "";
        string xm = "";
        int flow_id = 11;
        int step_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            init();
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void Bind()
        {
            if (doc_id > 0)
            {
                BindField();
                BindAttachments();
                BindEmergency();
            }
        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Utility.GetEmergencyByDocid(doc_id);
        }

        protected void init()
        {
            zgbh = Session["zgbh"].ToString();
            xm = Utility.GetRyxmByZgbh(zgbh);
            flow_id = 11;
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);

            if (step_id == 1)
                this.backBtn.Text = "删除";

            if (step_id == 0)
                submitBtn.Visible = false;
            else if (step_id == 1 && doc_id == 0)
            {
                b.Text = xm;
            }

            DataTable dtd = Utility.GetDepartmentByZgbh(zgbh);
            DataTable dtp = Utility.GetPositionByZgbh(zgbh);

            c.DataSource = dtd;
            d.DataSource = dtp;

            c.DataTextField = "ry_bm";
            c.DataValueField = "ry_bm";
            d.DataTextField = "ry_zw";
            d.DataValueField = "ry_zw";

            c.DataBind();
            d.DataBind();

            EnableField();

        }

        protected void EnableField()
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl;

            DataTable dt = Utility.GetFieldBind(flow_id, step_id);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                StyleControl = FrmNewDocument.FindControl(dt.Rows[i][0].ToString());
                switch (StyleControl.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.Label":
                        ((Label)StyleControl).Enabled = true;
                        break;
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)StyleControl).Enabled = true;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)StyleControl).Enabled = true;
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)StyleControl).Enabled = true;
                        break;
                }
            }

            if (step_id == 1)
            {
                FileUpload1.Enabled = true;
                uploadBtn.Enabled = true;
                attachname.Enabled = true;
                EmergencySelector1.Enabled = true;
            }
        }

        protected void BindAttachments()
        {
            DataTable dt = Utility.GetAttachmentByDocid(doc_id);
            BindAttachList(dt);
        }

        protected void BindAttachList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                attachment.Visible = true;
            else
                attachment.Visible = false;

            FileList.DataSource = dt;
            FileList.DataBind();
        }

        protected void AddAttachments()
        {
            if (Session["attachments"] != null && doc_id > 0)
            {
                DataTable dt = (DataTable)Session["attachments"];
                Utility.AddAttachments(doc_id, dt);
            }
        }

        protected void BindField()
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl;

            DataTable dtt = Utility.GetFieldDescription(flow_id);
            DataTable dtv = Utility.GetFieldValue(flow_id, doc_id);

            for (int i = 0; i < dtt.Rows.Count; ++i)
            {
                StyleControl = FrmNewDocument.FindControl(dtt.Rows[i][0].ToString());
                switch (StyleControl.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.Label":
                        ((Label)StyleControl).Text = dtv.Rows[0][dtt.Rows[i][0].ToString()].ToString();
                        break;
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)StyleControl).Text = dtv.Rows[0][dtt.Rows[i][0].ToString()].ToString();
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)StyleControl).SelectedValue = dtv.Rows[0][dtt.Rows[i][0].ToString()].ToString();
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        string val = dtv.Rows[0][dtt.Rows[i][0].ToString()].ToString();
                        CheckBoxList cbl = ((CheckBoxList)StyleControl);
                        for (int j = 0; j < cbl.Items.Count; ++j)
                        {
                            if (val.IndexOf(cbl.Items[j].Value) != -1)
                            {
                                cbl.Items[j].Selected = true;
                            }
                        }
                        break;
                }
            }
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true && attachname.Text.Trim() != string.Empty)
            {
                if (FileUpload1.PostedFile.ContentLength < 10485760)
                {
                    try
                    {
                        string fileurl = "../../Attachments/" + attachname.Text.Trim() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(fileurl));
                        DataTable dt;
                        if (doc_id == 0)
                        {
                            int count = 0;
                            if (Session["attachments"] == null)
                            {
                                dt = new DataTable();
                                dt.Columns.Add("id");
                                dt.Columns.Add("filename");
                                dt.Columns.Add("fileurl");
                            }
                            else
                            {
                                dt = (DataTable)Session["attachments"];
                                count = dt.Rows.Count;
                            }
                            DataRow row = dt.NewRow();
                            row["id"] = count + 1;
                            row["filename"] = attachname.Text.Trim();
                            row["fileurl"] = fileurl;
                            dt.Rows.Add(row);
                            BindAttachList(dt);
                            Session["attachments"] = dt;
                        }
                        else
                        {
                            Utility.AddAttachment(doc_id, attachname.Text.Trim(), fileurl);
                            BindAttachments();
                        }
                        attachname.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script type=text/javascript>alert('上传失败！')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script type=text/javascript>alert('请确认操作正确且附件名称已填写！')</script>");
            }
        }

        private string GetStyleInsertData()
        {
            string sqlText = "INSERT INTO dsoc_flow_style_data(";
            DataTable dt = Utility.GetFieldBind(flow_id, step_id);

            if (dt.Rows.Count == 0)
                return string.Empty;

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                sqlText += dt.Rows[i][0].ToString() + (i == dt.Rows.Count - 1 ? ") VALUES(" : ", ");
            }

            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                sqlText += "'" + GetControlText(dt.Rows[i][0].ToString()).Replace("'", "''") + (i == dt.Rows.Count - 1 ? "')" : "', ");
            }

            return sqlText;
        }

        private string GetStyleUpdateData()
        {
            string sqlText = "UPDATE dsoc_flow_style_data SET ";
            DataTable dt = Utility.GetFieldBind(flow_id, step_id);

            if (dt.Rows.Count == 0)
                return string.Empty;

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string name = dt.Rows[i][0].ToString();
                string text = GetControlText(name);
                sqlText += name + " = " + "'" + text.Replace("'", "''") + "'" + (i == dt.Rows.Count - 1 ? " " : ", ");
            }

            sqlText += " WHERE doc_id = " + doc_id.ToString();

            return sqlText;
        }

        private string GetControlText(string field_name)
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            StyleControl = FrmNewDocument.FindControl(field_name);
            switch (StyleControl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.Label":
                    return ((Label)StyleControl).Text;
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                case "System.Web.UI.WebControls.CheckBoxList":
                    string val = string.Empty;
                    CheckBoxList cbl = (CheckBoxList)StyleControl;
                    for (int i = 0; i < cbl.Items.Count; ++i)
                    {
                        if (cbl.Items[i].Selected == true)
                        {
                            val += cbl.Items[i].Value + ",";
                        }
                    }
                    return val;
                default:
                    return "";
            }
        }

        protected void submit()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string cmdText;

            if (step_id == 1 && doc_id == 0)
            {
                cmdText = GetStyleInsertData();
                doc_id = df.AddDocument(zgbh, flow_id, cmdText, b.Text.ToString().Trim() + "请假条");
                AddAttachments();
            }
            else
            {
                cmdText = GetStyleUpdateData();
                df.UpdateDocument(cmdText);
            }
            if (step_id == 1)
                Stoke.BLL.Utility.SetEmergencyWithDocid(doc_id, this.EmergencySelector1.SelectedValue);
        }

        protected void submitBtn_Click(object sender, EventArgs ex)
        {
            if (step_id == 1)
            {
                if (a.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请填写填表时间！')</script>");
                    return;
                }
                bool flag = false;
                for (int i1 = 0; i1 < e.Items.Count; ++i1)
                {
                    if (e.Items[i1].Selected == true)
                    {
                        flag = true;
                        break;
                        //if (i1 == 1 && attachment.Visible == false)
                        //{
                        //    Response.Write("<script type=text/javascript>alert('请附加医院证明！')</script>");
                        //    return;
                        //}
                    }
                }
                if (flag == false)
                {
                    Response.Write("<script type=text/javascript>alert('请选择请假类别！')</script>");
                    return;
                }
                if (g.Text.Trim() == string.Empty || h.Text.Trim() == string.Empty || i.Text.Trim() == string.Empty || j.Text.Trim() == string.Empty || k.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请确认请假时间已填写完整！')</script>");
                    return;
                }
            }
            if (step_id == 2 && l.Text.Trim() == string.Empty)
            {
                Response.Write("<script type=text/javascript>alert('请填写审核意见！')</script>");
                return;
            }
            if (step_id == 3 && m.Text.Trim() == string.Empty)
            {
                Response.Write("<script type=text/javascript>alert('请填写审核意见！')</script>");
                return;
            }
            if (step_id == 4 && n.Text.Trim() == string.Empty)
            {
                Response.Write("<script type=text/javascript>alert('请填写审核意见！')</script>");
                return;
            }

            submit();

            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=11&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + zgbh.ToString();
            Response.Redirect(_URL);
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                Stoke.Components.Staff.DeleteDocument(doc_id);
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
                Response.Redirect("../Workflow/Work_record.aspx");
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        protected void FileList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (step_id == 1 && doc_id == 0)
                {
                    DataTable dt = (DataTable)Session["attachments"];
                    for (int i = dt.Rows.Count - 1; i >= 0; --i)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["id"]) == id)
                        {
                            dt.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    BindAttachList(dt);
                    Session["attachments"] = dt;
                }
                else if (step_id == 1 && doc_id > 0)
                {
                    Utility.DeleteAttachment(id);
                    BindAttachments();
                }
                else
                {
                    Response.Write("<script type=text/javascript>alert('不可删除！')</script>");
                }
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            submit();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }
    }
}
