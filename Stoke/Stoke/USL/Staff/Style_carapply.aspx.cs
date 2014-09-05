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
    public partial class Style_carapply : System.Web.UI.Page
    {
        int doc_id = 0;
        string zgbh = "";
        string xm = "";
        int flow_id = 14;
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
                BindEmergency();
            }
        }

        private void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Utility.GetEmergencyByDocid(doc_id);
        }

        protected void init()
        {
            zgbh = Session["zgbh"].ToString();
            xm = Utility.GetRyxmByZgbh(zgbh);
            flow_id = 14;
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);

            if (step_id == 1)
                this.backBtn.Text = "删除";

            if (step_id == 0)
                submitBtn.Visible = false;
            else if (step_id == 1 && doc_id == 0)
            {
                a.Text = xm;
            }

            DataTable dtd = Utility.GetDepartmentByZgbh(zgbh);
            DataTable dtp = Utility.GetPositionByZgbh(zgbh);

            b.DataSource = dtd;
            c.DataSource = dtp;

            b.DataTextField = "ry_bm";
            b.DataValueField = "ry_bm";
            c.DataTextField = "ry_zw";
            c.DataValueField = "ry_zw";

            b.DataBind();
            c.DataBind();

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
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)StyleControl).Enabled = true;
                        break;
                }
            }

            if (step_id == 1)
                this.EmergencySelector1.Enabled = true;
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
                    case "System.Web.UI.WebControls.RadioButtonList":
                        string val1 = dtv.Rows[0][dtt.Rows[i][0].ToString()].ToString();
                        RadioButtonList rbl = (RadioButtonList)StyleControl;
                        for (int j = 0; j < rbl.Items.Count; ++j)
                        {
                            if (val1.IndexOf(rbl.Items[j].Value) != -1)
                            {
                                rbl.Items[j].Selected = true;
                            }
                        }
                        break;
                }
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
                case "System.Web.UI.WebControls.RadioButtonList":
                    string val1 = string.Empty;
                    RadioButtonList rbl = (RadioButtonList)StyleControl;
                    for (int j = 0; j < rbl.Items.Count; ++j)
                    {
                        if (rbl.Items[j].Selected == true)
                        {
                            val1 += rbl.Items[j].Value + ",";
                        }
                    }
                    return val1;
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
                doc_id = df.AddDocument(zgbh, flow_id, cmdText, a.Text.ToString().Trim() + "公车请单");
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
                    Response.Write("<script type=text/javascript>alert('请填写姓名！')</script>");
                    return;
                }
                if (d.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请填写申请日！')</script>");
                    return;
                }
                if (e.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请填写预定出发时间！')</script>");
                    return;
                }
                if (f.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请填写预定返回时间！')</script>");
                    return;
                }
                if (g.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请填写事由！')</script>");
                    return;
                }
                if (h.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请填写出发地！')</script>");
                    return;
                }
                if (i.Text.Trim() == string.Empty)
                {
                    Response.Write("<script type=text/javascript>alert('请填写目的地！')</script>");
                    return;
                }
            }
            if (step_id == 2)
            {
                bool flag = false;
                for (int i = 0; i < j.Items.Count; ++i)
                {
                    if (j.Items[i].Selected == true)
                    {
                        flag = true;
                        if (i == 1 && k.Text.Trim() == string.Empty)
                        {
                            Response.Write("<script type=text/javascript>alert('请填写部门备注！')</script>");
                            return;
                        }
                    }
                }

                if (flag == false)
                {
                    Response.Write("<script type=text/javascript>alert('请填写部门意见！')</script>");
                    return;
                }
            }
            if (step_id == 3 && l.Text.Trim() == string.Empty)
            {
                Response.Write("<script type=text/javascript>alert('请填写审批人意见！')</script>");
                return;
            }

            submit();

            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=14&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + zgbh.ToString();
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

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            submit();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }
    }
}
