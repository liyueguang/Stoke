using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Configuration;
using Stoke.DAL;

namespace Stoke.Components
{
	/// <summary>
	/// zjzc 的摘要说明。
	/// </summary>
	public class zjzc
	{
		public zjzc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static DataTable getAllXmz()
		{
			string spName = "sp_getAllXmz";
			object [] paras = new object[] {};
			return SQLHelper.ExecuteDataTable(spName,paras);
		}

		public static DataTable getZjzcDetailByMonthAndBmAndDocid(string month, string bm_mc, int doc_id)
		{
			string spName = "sp_getZjzcDetailByMonthAndBmAndDocid";
			object [] paras = new object[] { month, bm_mc, doc_id };
			return SQLHelper.ExecuteDataTable(spName, paras);
		}

		public static bool insertNewZjzcDetail(string bm_mc, string month, string xm_mc, string ywnr, string skdw, decimal firstRmb, decimal firstUsd, decimal firstEur, decimal secondRmb, decimal secondUsd, decimal secondEur, decimal thirdRmb, decimal thirdUsd, decimal thirdEur, string jbrXm, int doc_id)
		{
			string spName = "sp_insertNewZjzcDetail";
			object [] paras = new object[] { bm_mc, month, xm_mc, ywnr, skdw, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, jbrXm, doc_id };
			try
			{
				SQLHelper.ExecuteNonQuery(spName, false, paras);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public static bool updateZjzcDetailByID(int ID, decimal firstRmb, decimal firstUsd, decimal firstEur, decimal secondRmb, decimal secondUsd, decimal secondEur, decimal thirdRmb, decimal thirdUsd, decimal thirdEur, string jbrZgbh)
		{
			string spName = "sp_updateZjzcDetailByID";
			object [] paras = new object[] { ID, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, jbrZgbh };
			try
			{
				SQLHelper.ExecuteNonQuery(spName, false, paras);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public static bool deleteZjzcDetailByID(int ID)
		{
			string spName = "sp_deleteZjzcDetailByID";
			object [] paras = new object[] { ID };
			try
			{
				SQLHelper.ExecuteNonQuery(spName, false, paras);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public static bool annotateZjzcDetailByID(int ID, int status, decimal firstRmb, decimal firstUsd, decimal firstEur, decimal secondRmb, decimal secondUsd, decimal secondEur, decimal thirdRmb, decimal thirdUsd, decimal thirdEur, string modifierZgbh)
		{
			string spName = "sp_annotateZjzcDetailByID";
			object [] paras = new object[] { ID, status, firstRmb, firstUsd, firstEur, secondRmb, secondUsd, secondEur, thirdRmb, thirdUsd, thirdEur, modifierZgbh };
			try
			{
				SQLHelper.ExecuteNonQuery(spName, false, paras);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public static DataTable getZjzcModifyDetail(int doc_id)
		{
			string spName = "sp_getZjzcModifyDetail";
			object [] paras = new object[] { doc_id };
			return SQLHelper.ExecuteDataTable(spName, paras);
		}

		public static DataTable getAllZjzcDetailByMonth(string month)
		{
			string spName = "sp_getAllZjzcDetailByMonth";
			object [] paras = new object[] { month };
			return SQLHelper.ExecuteDataTable(spName, paras);
		}

		public static DataTable getAllZjzcDetailByMonth1(string month)
		{
			string spName = "sp_getAllZjzcDetailByMonth1";
			object [] paras = new object[] { month };
			return SQLHelper.ExecuteDataTable(spName, paras);
		}

		public static bool insertZjzcSubmit(string month, string bm_mc, int doc_id, int flag)
		{
			string spName = "sp_insertZjzcSubmit";
			object [] paras = new object[] { month, bm_mc, doc_id, flag };
			try
			{
				SQLHelper.ExecuteNonQuery(spName, false, paras);
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;
		}

		public static bool updateZjzcSubmitFlag(int doc_id, int flag)
		{
			string spName = "sp_updateZjzcSubmitFlag";
			object [] paras = new object[] { doc_id, flag };
			try
			{
				SQLHelper.ExecuteNonQuery(spName, false, paras);
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;
		}

		public static DataTable getSubmitedBmByMonth(string month)
		{
			string spName = "sp_getSubmitedBmByMonth";
			object [] paras = new object[] { month };
			return SQLHelper.ExecuteDataTable(spName, paras);
		}

		public static DataTable GetZjzcDetailByMonthAndXm(string month, int xm_bh)
		{
			string spName = "sp_getZjzcDetailByMonthAndXm";
			object [] paras = new object[] { month, xm_bh };
			return SQLHelper.ExecuteDataTable(spName, paras);
		}

		public static DataTable zjzcCheckSubmit(string zjzc_month, string bm_mc)
		{
			string spName = "sp_zjzcCheckSubmit";
			object [] paras = new object[] { zjzc_month, bm_mc };
			return SQLHelper.ExecuteDataTable(spName, paras);
		}
	}
}
