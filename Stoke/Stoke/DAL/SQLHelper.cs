//===============================================================================
// This file is based on the Microsoft Data Access Application Block for .NET
// For more information please go to 
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//===============================================================================

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Stoke.DAL
{
	/// <summary>
	/// The SqlHelper class is intended to encapsulate high performance, 
	/// scalable best practices for common uses of SqlClient.
	/// </summary>
	public abstract class SQLHelper
	{

		//DSOC.Components.Database connection strings
		//public static readonly string CONN_STRING_NON_DTC = ConfigurationSettings.AppSettings["SQLConnString"];
		//public static readonly string CONN_STRING_DTC_INV = ConfigurationSettings.AppSettings["SQLConnString"];
		//public static  string CONN_STRING = ConfigurationSettings.AppSettings["ConnectionString"];//ConnectionInfo.DecryptDBConnectionString(ConfigurationSettings.AppSettings["SQLConnString3"]);
		//public static string CONN_STRING = "Server=(local);DSOC.Components.Database=dsoc;User ID=sa;Password=sa;Connection Timeout=30;";

		public static string CONN_STRING =  ConfigurationSettings.AppSettings["ConnectionString"].ToString();

        private static Hashtable myCache = Hashtable.Synchronized(new Hashtable());
        private static SqlConnection _connection;
     
		// Hashtable to store cached parameters
		private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against the DSOC.Components.Database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>


		public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{

			SqlCommand cmd = new SqlCommand();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				int val = cmd.ExecuteNonQuery();
				cmd.Parameters.Clear();
				return val;
			}
		}


		/// <summary>
		/// ͨ������Ĳ���ִ�в��룬������ʶ����ֵ
		/// </summary>
		/// <param name="connString"></param>
		/// <param name="cmdType"></param>
		/// <param name="cmdText"></param>
		/// <param name="cmdParms"></param>
		/// <returns></returns>
		public static int ExecuteReturnIdentity(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{
			SqlCommand cmd = new SqlCommand();

			PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
			int val = cmd.ExecuteNonQuery();
			if (val > 0)
				return (int)cmd.Parameters["@Identify"].Value;
			else
				return 0;

		}
		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against an existing DSOC.Components.Database connection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="conn">an existing DSOC.Components.Database connection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{

			SqlCommand cmd = new SqlCommand();

			PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
			int val = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return val;
		}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="trans">an existing sql transaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{
			SqlCommand cmd = new SqlCommand();
			PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
			int val = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return val;
		}

        public static int ExecuteNonQuery(SqlParameter ireturn, string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                ireturn.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ireturn);
                int val = cmd.ExecuteNonQuery();
                int returnValue = (int)cmd.Parameters[ireturn.ParameterName].Value;
                cmd.Parameters.Clear();
                return returnValue;
            }
        }

		/// <summary>
		/// Execute a SqlCommand that returns a resultset against the DSOC.Components.Database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>A SqlDataReader containing the results</returns>
		public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{
			SqlCommand cmd = new SqlCommand();
			SqlConnection conn = new SqlConnection(connString);

			// we use a try/catch here because if the method throws an exception we want to 
			// close the connection throw code, because no datareader will exist, hence the 
			// commandBehaviour.CloseConnection will not work
			try
			{
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Parameters.Clear();
				return rdr;
			}
			catch (Exception e)
			{
				conn.Close();
				throw e;
			}
		}

		/// <summary>
		/// Execute a SqlCommand that returns the first column of the first record against the DSOC.Components.Database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
		public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{
			SqlCommand cmd = new SqlCommand();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				object val = cmd.ExecuteScalar();
				cmd.Parameters.Clear();
				return val;
			}
		}

		/// <summary>
		/// Execute a SqlCommand that returns the first column of the first record against an existing DSOC.Components.Database connection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  Object obj = ExecuteScalar(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="conn">an existing DSOC.Components.Database connection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
		public static object ExecuteScalar(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{

			SqlCommand cmd = new SqlCommand();

			PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
			object val = cmd.ExecuteScalar();
			cmd.Parameters.Clear();
			return val;
		}

		/// <summary>
		/// add parameter array to the cache
		/// </summary>
		/// <param name="cacheKey">Key to the parameter cache</param>
		/// <param name="cmdParms">an array of SqlParamters to be cached</param>
		public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParms)
		{
			parmCache[cacheKey] = cmdParms;
		}

		/// <summary>
		/// Retrieve cached parameters
		/// </summary>
		/// <param name="cacheKey">key used to lookup parameters</param>
		/// <returns>Cached SqlParamters array</returns>
		public static SqlParameter[] GetCachedParameters(string cacheKey)
		{
			SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

			if (cachedParms == null)
				return null;

			SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

			for (int i = 0, j = cachedParms.Length; i < j; i++)
				clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

			return clonedParms;
		}

		/// <summary>
		/// Prepare a command for execution
		/// </summary>
		/// <param name="cmd">SqlCommand object</param>
		/// <param name="conn">SqlConnection object</param>
		/// <param name="trans">SqlTransaction object</param>
		/// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
		/// <param name="cmdText">Command text, e.g. Select * from Products</param>
		/// <param name="cmdParms">SqlParameters to use in the command</param>
		private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{

			if (conn.State != ConnectionState.Open)
				conn.Open();

			cmd.Connection = conn;
			cmd.CommandText = cmdText;

			if (trans != null)
				cmd.Transaction = trans;

			cmd.CommandType = cmdType;

			if (cmdParms != null)
			{
				foreach (SqlParameter parm in cmdParms)
					cmd.Parameters.Add(parm);
			}
		}

		/// <summary>
		/// �ֶ���ӵķ���
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="cmdType"></param>
		/// <param name="cmdText"></param>
		/// <param name="cmdParms"></param>
		/// <returns></returns>
		public static DataSet ExecuteDataSet(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{
			SqlCommand cmd = new SqlCommand();
			PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter();
			da.SelectCommand = cmd;

			da.Fill(ds);

			cmd.Parameters.Clear();
			return ds;
		}

		public static DataTable ExecuteDataTable(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
		{
			SqlCommand cmd = new SqlCommand();
			PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter();
			da.SelectCommand = cmd;

			da.Fill(dt);

			cmd.Parameters.Clear();
			return dt;
		}

        public static DataTable ExecuteDataTable(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();
                return dt;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="ParamName">�洢��������</param>
        /// <param name="DbType">��������</param></param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// ���뷵��ֵ����
        /// </summary>
        /// <param name="ParamName">�洢��������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// ���뷵��ֵ����
        /// </summary>
        /// <param name="ParamName">�洢��������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeReturnParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
        }

        /// <summary>
        /// ���ɴ洢���̲���
        /// </summary>
        /// <param name="ParamName">�洢��������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Direction">��������</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        /// <summary>
        /// ִ���޷���ֵ�Ĵ洢����
        /// ע�����ֵ��˳������洢���̲���˳��һ��
        /// </summary>		
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues">����ֵ</param>
        /// <returns>ִ�н��</returns>
        public static int ExecuteNonQuery(string spName, bool hasReturns, params object[] parameterValues)
        {
            //����в���ֵ, �ȸ�����ֵ��ִ��
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //��ȡ�洢���̲���
                SqlParameter[] commandParameters = GetSpParameters(spName, hasReturns);

                //Ϊ�洢���̲����趨����ֵ
                AssignParameterValues(commandParameters, parameterValues);

                //����ִ�д�����ֵ�Ĵ洢���̷���
                return ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, spName, commandParameters);
            }
            //��������
            else
            {
                return ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// ��ȡ�洢���̲���
        /// </summary>
        /// <param name="spName">�洢������</param>
        /// <param name="hasReturn">�Ƿ��������ֵ</param>
        /// <returns>���ز�������</returns>
        public static SqlParameter[] GetSpParameters(string spName, bool hasReturn)
        {
            //����HashTable������
            string cacheKey = spName + (hasReturn ? ":hasReturn" : "");
            //��Hachtable�л�ȡ����
            SqlParameter[] cachedParameters = (SqlParameter[])myCache[cacheKey];
            if (cachedParameters == null)
            {
                //���Hachtable��û�У����û�ȡ�洢���̲������鷽��
                cachedParameters = (SqlParameter[])(myCache[cacheKey] = GetSpParameterSet(spName, hasReturn));
            }

            return CloneParameters(cachedParameters);
        }

        /// <summary>
        /// ������ֵ���и�ֵ����Ӧ�Ĳ�������
        /// </summary>
        /// <param name="commandParameters">����ֵ�Ĳ�������</param>
        /// <param name="parameterValues">����ֵ����</param>
        private static bool AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            bool ret = true;

            if ((commandParameters == null) || (parameterValues == null))
            {
                //������Ϊnull������
                return ret;
            }

            // �������鳤�������ֵ���鳤����ƥ��
            if (commandParameters.Length != parameterValues.Length)
            {
                ret = false;
                //Trace.Write("AssignParameterValues","Error","���������Ͳ���ֵ������ƥ��.");
                return ret;
            }

            //ѭ��Ϊ������ֵ
            //ע�⣬���������ֵ�ڸ��Ե�������λ��Ӧ����Ӧ
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }

            return ret;
        }

        /// <summary>
        /// ��ȡ�洢���̲�������
        /// </summary>
        /// <param name="spName">�洢������</param>
        /// <param name="hasReturn">�Ƿ�����������͵Ĳ���</param>
        /// <returns>��������</returns>
        private static SqlParameter[] GetSpParameterSet(string spName, bool hasReturn)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //Ϊ����ָ������
                _connection = new SqlConnection(CONN_STRING);
                cmd.Connection = _connection;

                //�����������δ����������
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                //ָ��CommandTextΪ�洢������
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                //�Ӵ洢�����м�����������䵽Parameters��
                try
                {
                    SqlCommandBuilder.DeriveParameters(cmd);
                }
                catch (Exception e)
                {
                    //ִ��ʧ��
                    //���쳣�л�ȡʧ����Ϣ
                    string msg = e.Message;
                    //����д��־����
                    //Trace.Write("DeriveParameters","Error",spName+"|"+msg) ;
                }

                //����з���ֵ
                if (!hasReturn)
                {
                    cmd.Parameters.RemoveAt(0);
                }

                //��Parameters���еĲ������Ƶ���������
                SqlParameter[] para = new SqlParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(para, 0);

                _connection.Close();

                return para;
            }
        }

        /// <summary>
        /// ��������еĲ�������
        /// </summary>
        /// <param name="originalParameters">Դ��������</param>
        /// <returns>������Ĳ�������</returns>
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            //��������еĲ�������
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        /// <summary>
        /// ִ�з���DataTable�Ĵ洢����
        /// </summary>		
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues">����ֵ����</param>
        /// <returns>��ѯ���DataTable</returns>
        public static DataTable ExecuteDataTable(string spName, params object[] parameterValues)
        {
            //����в���ֵ, �ȸ�����ֵ��ִ��
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //��ȡ�洢���̲���
                SqlParameter[] commandParameters = GetSpParameters(spName, false);

                //Ϊ�洢���̲����趨����ֵ
                AssignParameterValues(commandParameters, parameterValues);

                //����ִ�д���ֵ�Ĵ洢���̷���
                return ExecuteDataTable(CONN_STRING, CommandType.StoredProcedure, spName, commandParameters);
            }
            //���ò��������ķ���
            else
            {
                return ExecuteDataTable(CONN_STRING, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// ִ�м��������Ĵ洢����
        /// </summary>
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues">�洢���̲���ֵ����</param>
        /// <returns>�������</returns>
        public static object ExecuteScalar(string spName, params object[] parameterValues)
        {
            //����в���ֵ, �ȸ�����ֵ��ִ��
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //��ȡ�洢���̲���
                SqlParameter[] commandParameters = GetSpParameters(spName, false);
                //����ֵ
                AssignParameterValues(commandParameters, parameterValues);

                //���ô�������ִ�з���
                return SQLHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure,spName, commandParameters);
            }
            //���ò���������ִ�з���
            else
            {
                return SQLHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, spName);
            }
        }	
	}
}
