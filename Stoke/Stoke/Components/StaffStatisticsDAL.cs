using System;
using System.Data;
using System.Data.SqlClient;
using Stoke.DAL;

namespace Stoke.Components
{
    /// <summary>
    /// StaffStatisticsDAL ��ժҪ˵����ʵ��Ա��ͳ��
    /// </summary>
    public class StaffStatisticsDAL
    {

        /// <summary>
        /// ��ȡ��ְԱ��������
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
        /// �����Ž���ͳ��rs_staff_statistics_by_department
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
        /// ��ְλ����ͳ��
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
                    //ִ��ʧ��
                    //���쳣�л�ȡʧ����Ϣ
                    string msg = e.Message;
                }
            }
            return table;
        }

        /// <summary>
        /// ��ȡ����ְ�����
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
                    //ִ��ʧ��
                    //���쳣�л�ȡʧ����Ϣ
                    string msg = e.Message;
                }
            }
            return table;
        }

        /// <summary>
        /// ����ְ�����ͳ���Ƿ����ɲ�
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
                    //ִ��ʧ��
                    //���쳣�л�ȡʧ����Ϣ
                    string msg = e.Message;
                }
            }
            return table;
        }


        /// <summary>
        /// ��ѧ������ͳ��
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
        /// ���������ͳ��
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
        /// ��ְ�ƽ���ͳ��
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
        /// ��רҵ����ͳ��
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
        /// ���μӹ���ʱ�����ͳ��
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
        /// �����ź͹�˾������ԱM����ͳ��
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
                    //ִ��ʧ��
                    //���쳣�л�ȡʧ����Ϣ
                    string msg = e.Message;
                }
            }
            return table;
        }

        /// <summary>
        /// �����ź͹�˾Ƹ����ԱPM����ͳ��
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
        /// �����ź͹�˾ְ����ԱW����ͳ��
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
        /// �����ź͹�˾ְ����ԱJY����ͳ��
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
        /// �����ź͹�˾��Ƹ��ԱFP����ͳ��
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
        /// �����ź͹�˾��פ��ԱPZ����ͳ��
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
        /// �õ���������������ͳ��
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
        /// ���Ա����ͳ��
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
        /// ��Ƹ�����ͽ���ͳ��
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
        /// ��������λʱ�����ͳ��
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
        /// ��רҵ������ͳ��
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
        /// ��ְ�Ƽ������ͳ��
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
