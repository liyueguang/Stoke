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

namespace Stoke.UserControls
{
    public partial class EmergencySelector : System.Web.UI.UserControl
    {
        private int doc_id;
        public int Doc_id
        {
            get
            {
                return doc_id;
            }
            set
            {
                this.doc_id = value;
            }
        }

        private int selectedValue;
        public int SelectedValue
        {
            get
            {
                for (int i = 0; i < this.RadioButtonList1.Items.Count; ++i)
                {
                    if (this.RadioButtonList1.Items[i].Selected == true)
                    {
                        return Convert.ToInt32(this.RadioButtonList1.Items[i].Value);
                    }
                }
                return -1;
            }
            set
            {
                for (int i = 0; i < this.RadioButtonList1.Items.Count; ++i)
                {
                    if (Convert.ToInt32(this.RadioButtonList1.Items[i].Value) == value)
                    {
                        this.RadioButtonList1.Items[i].Selected = true;
                    }
                }
            }
        }

        public bool Enabled
        {
            set
            {
                this.RadioButtonList1.Enabled = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}