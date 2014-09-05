using System;
using System.Data;
using System.Data.SqlClient;

namespace Stoke.Components
{
    /// <summary>
    /// StaffStatisticsBLL ��ժҪ˵����
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
        /// �ϲ�������DataTable
        /// </summary>
        /// <param name="dt1">Ҫ�ϲ��ı�һ</param>
        /// <param name="dt2">Ҫ�ϲ��ı��</param>
        /// <param name="keyColName">dt1��dt2��ϵ�Ĺؼ�����</param>
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
                //����һ������ӵ�����
                dtReturn.Columns.Add(dt1.Columns[i].ColumnName);
            }

            for (j = 0; j < dt2.Columns.Count; j++)
            {
                if (dt2.Columns[j].ColumnName == keyColName)
                {
                    colKey2 = j;
                    continue;
                }
                //�����������ӵ�����
                dtReturn.Columns.Add(dt2.Columns[j].ColumnName);
            }

            //������Ŀռ�
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr;
                dr = dtReturn.NewRow();
                dtReturn.Rows.Add(dr);
            }

            //����1�ͱ�2������д�뵽dtReturn��
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                int m = -1;
                //����1�ĵ�i�����ݿ�����dtReturn��ȥ
                for (j = 0; j < dt1.Columns.Count; j++)
                {
                    dtReturn.Rows[i][j] = dt1.Rows[i][j].ToString();
                }
                //����dt2��keyColName�����ݣ���dt1��ͬ���У����������е�id��ͬ���У�
                for (k = 0; k < dt2.Rows.Count; k++)
                {
                    if (dt1.Rows[i][colKey1].ToString().Trim() == dt2.Rows[k][colKey2].ToString().Trim())
                        m = k;
                }
                //��dt2�еĵ�m�����ݿ�����dtReturn��ȥ���Ҳ�ҪkeyColName(ID)��
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
