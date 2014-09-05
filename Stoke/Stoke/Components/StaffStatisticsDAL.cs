using System;
using System.Data;
using System.Data.SqlClient;
using Stoke.DAL;

namespace Stoke.Components
{
    /// <summary>
    /// StaffStatisticsDAL 的摘要说明。实现员工统计
    /// </summary>
    public class StaffStatisticsDAL
    {

        /// <summary>
        /// 获取在职员工总人数
        /// </summary>
        /// <returns></returns>
        public DataTable GetStaffSum()
        {
            DataTable table = null;
            string sqlstr = "sp_Rs_Select_Staff_Num";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按部门进行统计rs_staff_statistics_by_department
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartment()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_department";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按职位进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByPosition()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_zw";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch (Exception e)
                {
                    //执行失败
                    //从异常中获取失败信息
                    string msg = e.Message;
                }
            }
            return table;
        }

        /// <summary>
        /// 获取所有职工编号
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllZgbh()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_get_all_zgbh";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch (Exception e)
                {
                    //执行失败
                    //从异常中获取失败信息
                    string msg = e.Message;
                }
            }
            return table;
        }

        /// <summary>
        /// 根据职工编号统计是否管理干部
        /// </summary>
        /// <returns></returns>
        public DataTable GetGlgbByZgbh(string ry_zgbh)
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_get_glgb_by_zgbh";
            System.Data.SqlClient.SqlParameter para = new SqlParameter("@ry_zgbh", SqlDbType.VarChar, 10);
            para.Value = ry_zgbh;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, para);
                }
                catch (Exception e)
                {
                    //执行失败
                    //从异常中获取失败信息
                    string msg = e.Message;
                }
            }
            return table;
        }


        /// <summary>
        /// 按学历进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByQualification()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_qualification";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按年龄进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByAge()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_age";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按职称进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByZc()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_zc";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按专业进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByZy()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_zy";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按参加工作时间进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByCjgzsj()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_cjgzsj";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按部门和公司管理人员M进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartmentAndZhihaoM()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_bm_and_m_num";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch (Exception e)
                {
                    //执行失败
                    //从异常中获取失败信息
                    string msg = e.Message;
                }
            }
            return table;
        }

        /// <summary>
        /// 按部门和公司聘管人员PM进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartmentAndZhihaoPM()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_bm_and_pm_num";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按部门和公司职工人员W进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartmentAndZhihaoW()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_bm_and_w_num";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按部门和公司职工人员JY进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartmentAndZhihaoJY()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_bm_and_jy_num";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }
        /// <summary>
        /// 按部门和公司返聘人员FP进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartmentAndZhihaoFP()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_bm_and_fp_num";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按部门和公司派驻人员PZ进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartmentAndZhihaoPZ()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_bm_and_pz_num";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 得到部门人数的上月统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByDepartmentAndSYTJ()
        {
            DataTable table = null;
            string sqlstr = "rs_Staff_stat_month_by_bm_and_month";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        //09-2-24 wyw
        /// <summary>
        /// 按性别进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatBySex()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_sex";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按聘用类型进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByPylx()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_pylx";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }

        /// <summary>
        /// 按进本单位时间进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByJbdwsj()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_jbdwsj";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }
        /// <summary>
        /// 按专业类别进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByZylb()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_zylb";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }
        /// <summary>
        /// 按职称级别进行统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatByZcjb()
        {
            DataTable table = null;
            string sqlstr = "rs_staff_statistics_by_zcjb";
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, sqlstr, null);
                }
                catch
                {
                    return null;
                }
            }
            return table;
        }
    }
}
