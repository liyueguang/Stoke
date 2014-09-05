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
		/// 通过传入的参数执行插入，并返标识符的值
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
		/// 手动添加的方法
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
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeReturnParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
        }

        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
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
        /// 执行无返回值的存储过程
        /// 注意参数值的顺序需与存储过程参数顺序一致
        /// </summary>		
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">参数值</param>
        /// <returns>执行结果</returns>
        public static int ExecuteNonQuery(string spName, bool hasReturns, params object[] parameterValues)
        {
            //如果有参数值, 先赋参数值再执行
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //获取存储过程参数
                SqlParameter[] commandParameters = GetSpParameters(spName, hasReturns);

                //为存储过程参数设定参数值
                AssignParameterValues(commandParameters, parameterValues);

                //调用执行带参数值的存储过程方法
                return ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, spName, commandParameters);
            }
            //不带参数
            else
            {
                return ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 获取存储过程参数
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="hasReturn">是否包含返回值</param>
        /// <returns>返回参数序列</returns>
        public static SqlParameter[] GetSpParameters(string spName, bool hasReturn)
        {
            //缓存HashTable的主键
            string cacheKey = spName + (hasReturn ? ":hasReturn" : "");
            //从Hachtable中获取参数
            SqlParameter[] cachedParameters = (SqlParameter[])myCache[cacheKey];
            if (cachedParameters == null)
            {
                //如果Hachtable中没有，调用获取存储过程参数数组方法
                cachedParameters = (SqlParameter[])(myCache[cacheKey] = GetSpParameterSet(spName, hasReturn));
            }

            return CloneParameters(cachedParameters);
        }

        /// <summary>
        /// 将参数值序列赋值给对应的参数序列
        /// </summary>
        /// <param name="commandParameters">待赋值的参数序列</param>
        /// <param name="parameterValues">参数值序列</param>
        private static bool AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            bool ret = true;

            if ((commandParameters == null) || (parameterValues == null))
            {
                //若参数为null，返回
                return ret;
            }

            // 参数数组长度与参数值数组长度需匹配
            if (commandParameters.Length != parameterValues.Length)
            {
                ret = false;
                //Trace.Write("AssignParameterValues","Error","参数个数和参数值个数不匹配.");
                return ret;
            }

            //循环为参数赋值
            //注意，参数与参数值在各自的序列中位置应当对应
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }

            return ret;
        }

        /// <summary>
        /// 获取存储过程参数数组
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="hasReturn">是否包含返回类型的参数</param>
        /// <returns>参数数组</returns>
        private static SqlParameter[] GetSpParameterSet(string spName, bool hasReturn)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //为命令指定连接
                _connection = new SqlConnection(CONN_STRING);
                cmd.Connection = _connection;

                //如果数据连接未开启，打开它
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                //指定CommandText为存储过程名
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                //从存储过程中检索参数，填充到Parameters集
                try
                {
                    SqlCommandBuilder.DeriveParameters(cmd);
                }
                catch (Exception e)
                {
                    //执行失败
                    //从异常中获取失败信息
                    string msg = e.Message;
                    //调用写日志方法
                    //Trace.Write("DeriveParameters","Error",spName+"|"+msg) ;
                }

                //如果有返回值
                if (!hasReturn)
                {
                    cmd.Parameters.RemoveAt(0);
                }

                //将Parameters集中的参数复制到参数数组
                SqlParameter[] para = new SqlParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(para, 0);

                _connection.Close();

                return para;
            }
        }

        /// <summary>
        /// 深拷贝缓存中的参数序列
        /// </summary>
        /// <param name="originalParameters">源参数序列</param>
        /// <returns>拷贝后的参数序列</returns>
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            //深拷贝缓存中的参数序列
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        /// <summary>
        /// 执行返回DataTable的存储过程
        /// </summary>		
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">参数值序列</param>
        /// <returns>查询结果DataTable</returns>
        public static DataTable ExecuteDataTable(string spName, params object[] parameterValues)
        {
            //如果有参数值, 先赋参数值再执行
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //获取存储过程参数
                SqlParameter[] commandParameters = GetSpParameters(spName, false);

                //为存储过程参数设定参数值
                AssignParameterValues(commandParameters, parameterValues);

                //调用执行带数值的存储过程方法
                return ExecuteDataTable(CONN_STRING, CommandType.StoredProcedure, spName, commandParameters);
            }
            //调用不带参数的方法
            else
            {
                return ExecuteDataTable(CONN_STRING, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行检索标量的存储过程
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">存储过程参数值序列</param>
        /// <returns>检索结果</returns>
        public static object ExecuteScalar(string spName, params object[] parameterValues)
        {
            //如果有参数值, 先赋参数值再执行
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //获取存储过程参数
                SqlParameter[] commandParameters = GetSpParameters(spName, false);
                //参数值
                AssignParameterValues(commandParameters, parameterValues);

                //调用带参数的执行方法
                return SQLHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure,spName, commandParameters);
            }
            //调用不带参数的执行方法
            else
            {
                return SQLHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, spName);
            }
        }	
	}
}
