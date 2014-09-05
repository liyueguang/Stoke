using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Stoke.USL.Workflow
{
    public partial class Work_lct : System.Web.UI.Page
    {
        protected static string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            int flow_id = Convert.ToInt32(Request.QueryString["flow_id"]);
            _zgbh = Request["zgbh"].ToString();

            switch (flow_id)
            {
                case 17:
                    bt.Text = "Ԥ�㹫��";
                    Image1.ImageUrl = "../lct/ysgw.jpg";
                    break;
                case 18:
                    bt.Text = "��ͨ����";
                    Image1.ImageUrl = "../lct/ptgw.jpg";
                    break;
                case 19:
                    bt.Text = "�ɱ�����";
                    Image1.ImageUrl = "../lct/cbgw.jpg";
                    break;
            }
        }

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Work_Manage.aspx");
        }
    }
}
