namespace Stoke.COMMON
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient;
    using Stoke.DAL;

    /// <summary>
    ///		SlctDepartment 的摘要说明。
    /// </summary>
    public class SlctDepartment : System.Web.UI.UserControl
    {
        protected System.Web.UI.WebControls.ListBox LB_All;
        protected System.Web.UI.WebControls.Button Btn1;
        protected System.Web.UI.WebControls.ListBox LB_Select;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Button Btn2;
        public string[] Send
        {
            get
            {
                string[] send = new string[3];
                send[0] = "";
                send[1] = "";
                int count = LB_Select.Items.Count;
                send[2] = count.ToString();
                if (0 != count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (0 == i)
                        {
                            send[0] += LB_Select.Items[i].Text.Trim();
                            send[1] += LB_Select.Items[i].Value.Trim();
                        }
                        else
                        {
                            send[0] += "," + LB_Select.Items[i].Text.Trim();
                            send[1] += "," + LB_Select.Items[i].Value.Trim();
                        }
                    }
                }
                return send;
            }
            set
            {
                string[] send = new string[2];
                send = value;
                char[] seprator = new char[1];
                seprator[0] = ',';
                string[] Send = send[0].Split(seprator, 10);
                string[] SendID = send[1].Split(seprator, 10);
                int count = Send.Length;
                for (int i = 0; i < count; i++)
                {
                    LB_Select.Items.Add(new ListItem(Send[i], SendID[i]));
                }
            }
        }
        private void Page_Load(object sender, System.EventArgs e)
        {



            // 在此处放置用户代码以初始化页面
            if (!IsPostBack)
            {
                string cmdText = "select * from dsoc_bm ";
                SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, cmdText);
                LB_All.DataSource = dr;
                LB_All.DataTextField = "bm_mc";
                LB_All.DataValueField = "bm_bh";
                LB_All.DataBind();
                dr.Close();
            }

        }

        protected void Btn1_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < LB_All.Items.Count; i++)
            {
                if (LB_All.Items[i].Selected == true)
                {
                    LB_Select.Items.Add(LB_All.Items[i]);
                    LB_All.Items.Remove(LB_All.Items[i]);
                    i--;
                }
            }
        }

        protected void Btn2_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < LB_Select.Items.Count; i++)
            {
                if (LB_Select.Items[i].Selected == true)
                {
                    LB_All.Items.Add(LB_Select.Items[i]);
                    LB_Select.Items.Remove(LB_Select.Items[i]);
                    i--;
                }
            }
        }

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }

    }
}
