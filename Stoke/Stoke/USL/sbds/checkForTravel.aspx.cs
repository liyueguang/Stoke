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
using Stoke.COMMON;
using System.Data.SqlClient;
using Stoke.Components;
using Stoke.DAL;

namespace Stoke.USL.sbds
{
    public partial class checkForTravel : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            string address = Request.QueryString["address"].ToString();
            string zgbh = Session["zgbh"].ToString().Trim();
            string msg = GetMsg(zgbh, address);
            Response.Write(msg);
        }

        private string GetMsg(string zgbh, string address)
        {
            //��ʼ�������ַ���
            string str = SQLHelper.CONN_STRING;
            SqlConnection con = new SqlConnection(str);

            //�����к�ͬ�����б�ؼ�
            int zw_flag = Int32.Parse(SQLHelper.ExecuteScalar(con, System.Data.CommandType.Text, "select zw_flag from dsoc_zw a,dsoc_ry b where b.ry_zgbh like '%" + zgbh + "%' and b.ry_zw like rtrim(a.zw_mc)", null).ToString());
            double[] money ={ 600.00, 500.00, 400.00, 200.00, 150.00 };
            double money_value = 0.00;
            switch (zw_flag)
            {
                case 1:
                    money_value = money[0];
                    break;
                case 2:
                    money_value = money[1];
                    break;
                case 3:
                    money_value = money[2];
                    break;
                case 4:
                case 5:
                case 6:
                    money_value = money[3];
                    break;
                case 7:
                    money_value = money[4];
                    break;
                default: break;
            }
            if (address == "����" || address == "�Ϻ�" || address == "����" || address == "����")
                money_value = money_value * 1.2;
            return money_value.ToString();
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
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
    }
}
