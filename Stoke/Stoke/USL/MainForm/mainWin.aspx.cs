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
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using Stoke.DAL;

namespace Stoke.USL.MainForm
{
    public partial class mainWin : System.Web.UI.Page
    {
        protected DataTable dt = null;
        protected DataTable dtp = null;
        protected DataTable dtt = null;
        protected string unread = "0";
        protected string mailall = "0";
        protected string worktodo = "0";
        protected string workall = "0";
        protected string allnum = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usernum"] != null)
            {
                GetMessage();
                GetWorkNum();
                xtsza.Attributes["href"] = "../SysManager/SystemUserInfo.aspx?ID=" + Session["userid"].ToString();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "<script>alert('请先登录，在进行操作！');top.location.href='../login.aspx'</script>");
            }
        }

        protected void GetMessage()
        {
            dt = SystemUM.GetMessageByCount(Session["usernum"].ToString(), "5", "", "");
            DLMsg.DataSource = dt;
            DLMsg.DataBind();

            DataTable dtunread = SystemUM.GetUnreadMessage(Session["usernum"].ToString());
            unread = dtunread.Rows[0][0].ToString();
            mailall = dtunread.Rows[1][0].ToString();

            dtp = SystemUM.GetRepByCount("5");
            DLRep.DataSource = dtp;
            DLRep.DataBind();
        }

        protected void GetWorkNum()
        {
            int a, b, c;
            DataTable dt = Stoke.DAL.SQLHelper.ExecuteDataTable(Stoke.DAL.SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_getWorkToDoNum", new SqlParameter("@ry_zgbh", Session["zgbh"].ToString()));
            a = Convert.ToInt32(dt.Rows[0][0]);
            dt = Stoke.DAL.SQLHelper.ExecuteDataTable(Stoke.DAL.SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_getAllWorkNum", new SqlParameter("@ry_zgbh", Session["zgbh"].ToString()));
            b = Convert.ToInt32(dt.Rows[0][0]);
            c = a + b;
            worktodo = a.ToString();
            workall = b.ToString();
            allnum = c.ToString();

            dtt = Stoke.DAL.SQLHelper.ExecuteDataTable(Stoke.DAL.SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_getWorkToDo", new SqlParameter("@ry_zgbh", Session["zgbh"].ToString()));
            DataList1.DataSource = dtt;
            DataList1.DataBind();
        }


        private int[] arrCurrentDays, arrPreDays, arrNextDays; //三个变量分别是当前月，前一月，和下一个月
        private int intCurrentMonth, intPreMonth, intNextMonth; //三个整型数组存放相对月份写有blog的日期
        protected void Calendar1_PreRender(object sender, EventArgs e)
        {
            Thread threadCurrent = Thread.CurrentThread;
            CultureInfo ciNew = (CultureInfo)threadCurrent.CurrentCulture.Clone();
            ciNew.DateTimeFormat.DayNames = new string[] { "日", "一", "二", "三", "四", "五", "六" };
            ciNew.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            threadCurrent.CurrentCulture = ciNew;
        }
        protected void Calendar1_DayRender1(object sender, DayRenderEventArgs e)
        {
            //该控件在创建每一天时发生。  
            CalendarDay d = ((DayRenderEventArgs)e).Day;
            TableCell c = ((DayRenderEventArgs)e).Cell;
            // 初始化当前月有Blog的日期数组
            if (intPreMonth == 0)
            {
                intPreMonth = d.Date.Month; // 注意：日历控件初始化时我们得到的第一个月并不是当前月，而是前一个月的月份
                // Response.Write(d.Date.Month.ToString());
                intCurrentMonth = intPreMonth + 1;
                if (intCurrentMonth > 12)
                    intCurrentMonth = 1;
                intNextMonth = intCurrentMonth + 1;
                if (intNextMonth > 12)
                    intNextMonth = 1;
                arrPreDays = getArrayDay(d.Date.Year, intPreMonth); //得到前一个月有blog的日期数组
                arrCurrentDays = getArrayDay(d.Date.Year, intCurrentMonth);//得到当月有blog的日期数组
                arrNextDays = getArrayDay(d.Date.Year, intNextMonth);//得到下个月有blog的日期数组
            }
            int j = 0;

            if (d.Date.Month.Equals(intPreMonth))
            {
                while (!arrPreDays[j].Equals(0))
                {
                    if (d.Date.Day.Equals(arrPreDays[j]))
                    {
                        c.Controls.Clear();
                        c.Controls.Add(new LiteralControl("<a href=http://www.google.com.hk/search?q=" + d.Date.Year + "-" +
                         d.Date.Month + "-" + d.Date.Day + " style='text-decoration:underline;'>" + d.Date.Day + "</a>"));
                    }
                    j++;
                }
            }
            else if (d.Date.Month.Equals(intCurrentMonth))
            {
                while (!arrCurrentDays[j].Equals(0))
                {
                    if (d.Date.Day.Equals(arrCurrentDays[j]))
                    {
                        c.Controls.Clear();
                        c.Controls.Add(new LiteralControl("<a href=http://www.google.com.hk/search?q=" + d.Date.Year + "-" +
                         d.Date.Month + "-" + d.Date.Day + " title='" + d.Date.Year + '/' + d.Date.Month + '/' + d.Date.Day +
    "' style='text-decoration:underline;'>" + d.Date.Day + "</a>"));
                    }
                    j++;
                }
            }
            else if (d.Date.Month.Equals(intNextMonth))
            {
                while (!arrNextDays[j].Equals(0))
                {
                    if (d.Date.Day.Equals(arrNextDays[j]))
                    {
                        c.Controls.Clear();
                        c.Controls.Add(new LiteralControl("<a href=http://www.google.com.hk/search?q=" + d.Date.Year + "-" +
                        d.Date.Month + "-" + d.Date.Day + " style='text-decoration:underline;'>" + d.Date.Day + "</a>"));
                    }
                    j++;
                }
            }
        }
        private int[] getArrayDay(int intYear, int intMonth)
        {
            int i = 0;
            int[] intArray = new int[31];
            //从数据库里选取符合要求的记录，将日期存入数组
            string mySelectQuery = "select * from stoke_Message where year(SendDate)=" + intYear +
             " and month(SendDate)=" + intMonth;
            SqlConnection myConnection = new SqlConnection(SQLHelper.CONN_STRING);
            SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader();
            while (dr.Read())
            {
                if (i == 0)
                {
                    intArray[i] = Convert.ToDateTime(dr["SendDate"]).Day;
                    i++;
                }
                else if (Convert.ToDateTime(dr["SendDate"]).Day != intArray[i - 1])
                {
                    intArray[i] = Convert.ToDateTime(dr["SendDate"]).Day;
                    i++;
                }
            }
            dr.Close();
            myConnection.Close();
            return intArray;
        }
    }
}
