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
using System.Collections.Generic;
using System.Data.SqlClient;
using Stoke.BLL;

namespace Stoke.USL.Workflow
{
    public partial class Default_rights_set : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void Bind()
        {
            DataTable dt = Utility.GetDefaultRights();
            CheckBoxList1.DataTextField = "flow_name";
            CheckBoxList1.DataValueField = "right_id";
            this.CheckBoxList1.DataSource = dt.DefaultView;
            CheckBoxList1.DataBind();

            Dictionary<int, int> rights = new Dictionary<int, int>();

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (Convert.ToInt32(dt.Rows[i]["flag"]) == 1)
                {
                    rights.Add(Convert.ToInt32(dt.Rows[i]["right_id"]), 1);
                }
            }

            for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
            {
                if (rights.ContainsKey(Convert.ToInt32(CheckBoxList1.Items[i].Value)))
                {
                    CheckBoxList1.Items[i].Selected = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int right_id = 1;
            int flag = 0;
            for (int i = 0; i < CheckBoxList1.Items.Count; ++i)
            {
                right_id = Convert.ToInt32(CheckBoxList1.Items[i].Value);
                flag = CheckBoxList1.Items[i].Selected == true ? 1 : 0;
                Utility.ModifyDefaultRight(right_id, flag);
            }

            Bind();

            Response.Write("<script type=text/javascript>alert('ÐÞ¸Ä³É¹¦£¡')</script>");
        }
    }
}
