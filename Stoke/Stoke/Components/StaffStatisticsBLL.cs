using System;
using System.Data;
using System.Data.SqlClient;

namespace Stoke.Components
{
    /// <summary>
    /// StaffStatisticsBLL 的摘要说明。
    /// </summary>
    public class StaffStatisticsBLL
    {

        public DataTable getStaffStatisticsPerMonth()
        {
            DataSet ds = new DataSet();
            StaffStatisticsDAL staffStatDAL = new StaffStatisticsDAL();

            DataTable table = staffStatDAL.GetStatByDepartment();
            DataTable tableM = staffStatDAL.GetStatByDepartmentAndZhihaoM();
            int count = tableM.Rows.Count;
            DataTable tablePM = staffStatDAL.GetStatByDepartmentAndZhihaoPM();
            DataTable tableW = staffStatDAL.GetStatByDepartmentAndZhihaoW();
            DataTable tableJY = staffStatDAL.GetStatByDepartmentAndZhihaoJY();
            DataTable tableFP = staffStatDAL.GetStatByDepartmentAndZhihaoFP();
            DataTable tablePZ = staffStatDAL.GetStatByDepartmentAndZhihaoPZ();
            //			DataTable tableSYTJ=staffStatDAL.GetStatByDepartmentAndSYTJ();

            DataTable dt1 = MergeDataTable(table, tableM, "ry_bm");
            DataTable dt2 = this.MergeDataTable(dt1, tablePM, "ry_bm");
            DataTable dt3 = this.MergeDataTable(dt2, tableW, "ry_bm");
            DataTable dt4 = this.MergeDataTable(dt3, tableJY, "ry_bm");
            DataTable dt5 = this.MergeDataTable(dt4, tableFP, "ry_bm");
            DataTable dt6 = this.MergeDataTable(dt5, tablePZ, "ry_bm");
            //			DataTable dt7=this.MergeDataTable(dt6,tableSYTJ,"ry_bm");
            //			return dt7;
            return dt6;
        }

        /// <summary>
        /// 合并两个表DataTable
        /// </summary>
        /// <param name="dt1">要合并的表一</param>
        /// <param name="dt2">要合并的表二</param>
        /// <param name="keyColName">dt1和dt2联系的关键列名</param>
        /// <returns></returns>
        private DataTable MergeDataTable(DataTable dt1, DataTable dt2, string keyColName)
        {
            DataTable dtReturn = new DataTable();
            int i = 0;
            int j = 0;
            int k = 0;
            int colKey1 = 0;
            int colKey2 = 0;

            dtReturn.TableName = dt1.TableName;

            for (i = 0; i < dt1.Columns.Count; i++)
            {
                if (dt1.Columns[i].ColumnName == keyColName)
                {
                    colKey1 = i;
                }
                //将表一的列添加到表中
                dtReturn.Columns.Add(dt1.Columns[i].ColumnName);
            }

            for (j = 0; j < dt2.Columns.Count; j++)
            {
                if (dt2.Columns[j].ColumnName == keyColName)
                {
                    colKey2 = j;
                    continue;
                }
                //将表二的列添加到表中
                dtReturn.Columns.Add(dt2.Columns[j].ColumnName);
            }

            //建立表的空间
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr;
                dr = dtReturn.NewRow();
                dtReturn.Rows.Add(dr);
            }

            //将表1和表2的数据写入到dtReturn中
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                int m = -1;
                //将表1的第i行数据拷贝到dtReturn中去
                for (j = 0; j < dt1.Columns.Count; j++)
                {
                    dtReturn.Rows[i][j] = dt1.Rows[i][j].ToString();
                }
                //查找dt2中keyColName的数据，与dt1相同的行（即两个表中的id相同的行）
                for (k = 0; k < dt2.Rows.Count; k++)
                {
                    if (dt1.Rows[i][colKey1].ToString().Trim() == dt2.Rows[k][colKey2].ToString().Trim())
                        m = k;
                }
                //表dt2中的第m行数据拷贝到dtReturn中去，且不要keyColName(ID)列
                if (m != -1)
                {
                    for (k = 0; k < dt2.Columns.Count; k++)
                    {
                        if (k == colKey2)
                        {
                            continue;
                        }
                        dtReturn.Rows[i][j] = dt2.Rows[m][k].ToString();
                        j++;
                    }
                }
            }
            return dtReturn;

        }

    }
}
