using System;
using System.IO ;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Caching ;
using System.Configuration;
//using 车辆管理.comon;
using System.Collections.Specialized ;

namespace Stoke.Help
{
	/// <summary>
	/// DAL 的摘要说明。
	/// </summary>
	public class DataAccess
	{
		private static SqlConnection _connection  ;
		private static SqlCommand _command  ;
		private static SqlDataAdapter _adapter ;
		//		private static SqlCommand _command_ds  ;
		//		private static SqlCommand _command_sl  ;

		//创建自己的Hashtable
		private static Hashtable myCache = Hashtable.Synchronized(new Hashtable());
		public static string ConnectionString 
		{
			get 
			{
				NameValueCollection nvc = (NameValueCollection)
					ConfigurationSettings.GetConfig("appSettings");
				return nvc[ "connectiondsoc" ];
			} 
		}

		#region 初始化
		/// <summary>
		/// 初始化数据连接
		/// </summary>
		/// <returns>true:成功  false:失败</returns>
		public static bool InitConn()
		{
			bool ret = true ;

			//获取web.config中配置的数据连接字串
			string str_conn = ConnectionString;
			if(str_conn != "")
				//初始化数据连接
				_connection = new SqlConnection(str_conn) ;
			else
			{
				ret = false ;
				return ret ;
			}

			//初始化命令
			_command = new SqlCommand() ;

			//为命令设置数据连接
			_command.Connection = _connection ;		

			//初始化数据适配器
			_adapter = new SqlDataAdapter() ;
						
			return ret ;
		}
		#endregion

		#region 参数赋值
		/// <summary>
		/// 将SQL参数队列值赋给SQL命令（SQL语句或存储过程）
		/// </summary>
		/// <param name="commandParameters">待指定给SQL命令的参数队列</param>
		private static void AttachParameters(SqlParameter[] commandParameters)
		{
			foreach (SqlParameter p in commandParameters)
			{
				//给为null的输出参数赋值
				if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
				{
					p.Value = DBNull.Value;
				}
				
				_command.Parameters.Add(p);
			}
		}

		/// <summary>
		/// 将参数值序列赋值给对应的参数序列
		/// </summary>
		/// <param name="commandParameters">待赋值的参数序列</param>
		/// <param name="parameterValues">参数值序列</param>
		private static bool AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			bool ret = true ;

			if ((commandParameters == null) || (parameterValues == null)) 
			{
				//若参数为null，返回
				return ret;
			}

			// 参数数组长度与参数值数组长度需匹配
			if (commandParameters.Length != parameterValues.Length)
			{
				ret = false ;
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
		/// 为给定的SQL命令（SQL语句或存储过程）打开数据连接，设置事务、命令名称、命令类型等等
		/// 并为命令的参数赋值
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="commandText">存储过程名或SQL语句</param>
		/// <param name="commandParameters">参数序列</param>
		private static void PrepareCommand(string commandText, SqlParameter[] commandParameters)
		{
			//若数据连接未打开，打开连接
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}			

			//设置command text (存储过程名或其他SQL语句)
			_command.CommandText = commandText;			

			//指定命令类型（存储过程或者其他SQL语句）
			_command.CommandType = CommandType.StoredProcedure;

			//为参数赋值
			if (commandParameters != null)
			{
				AttachParameters(commandParameters);
			}

			return;
		}
		#endregion

		#region 执行无查询存储过程
		/// <summary>
		/// 执行无查询存储过程
		/// </summary>
		/// <param name="commandText">存储过程名</param>
		/// <param name="HasReturn">是否有返回值</param>
		/// <param name="commandParameters">参数值</param>
		/// <returns>返回执行结果</returns>
		public static int ExecuteNonQuery_in(string commandText,bool HasReturn, params SqlParameter[] commandParameters)
		{
			int result = -1 ;
			//创建并打开数据连接			
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}		
			
			_command.Connection = _connection ;
			PrepareCommand(commandText, commandParameters);

			//调用执行函数
			//执行命令
			try
			{
				result = _command.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				//执行失败
				//从异常中获取失败信息
				string msg = e.Message ;
				//调用写日志方法
				//Trace.Write("ExecuteNonQuery","Error",commandText+"|"+msg) ;
			}
			if(HasReturn)
			{
				result = (int)_command.Parameters["@RETURN_VALUE"].Value ;
			}				
			
			//清除参数
			_command.Parameters.Clear();

			//执行完毕后关闭连接
			_connection.Close() ;

			return result ;
		}
		
		/// <summary>
		/// 执行无返回值的存储过程
		/// 注意参数值的顺序需与存储过程参数顺序一致
		/// </summary>		
		/// <param name="spName">存储过程名</param>
		/// <param name="parameterValues">参数值</param>
		/// <returns>执行结果</returns>
		public static int ExecuteNonQuery(string spName,bool hasReturns,params object[] parameterValues)
		{
			//如果有参数值, 先赋参数值再执行
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//获取存储过程参数
				SqlParameter[] commandParameters = GetSpParameters(spName,hasReturns);

				//为存储过程参数设定参数值
				AssignParameterValues(commandParameters, parameterValues);

				//调用执行带参数值的存储过程方法
				return ExecuteNonQuery_in(spName,hasReturns, commandParameters);
			}
				//不带参数
			else 
			{
				return ExecuteNonQuery_in(spName,hasReturns);
			}
		}
		#endregion

		#region 获取存储过程参数
		/// <summary>
		/// 获取存储过程参数数组
		/// </summary>
		/// <param name="spName">存储过程名</param>
		/// <param name="hasReturn">是否包含返回类型的参数</param>
		/// <returns>参数数组</returns>
		private static SqlParameter[] GetSpParameterSet(string spName,bool hasReturn)
		{			
			using(SqlCommand cmd = new SqlCommand() )
			{
				//为命令指定连接
				InitConn();
				cmd.Connection = _connection ;

				//如果数据连接未开启，打开它
				if(_connection.State != ConnectionState.Open)
				{
					_connection.Open() ;
				}
				//指定CommandText为存储过程名
				cmd.CommandText = spName ;
				cmd.CommandType = CommandType.StoredProcedure ;
				//从存储过程中检索参数，填充到Parameters集
				try
				{
					SqlCommandBuilder.DeriveParameters(cmd) ;
				}
				catch(Exception e)
				{
					//执行失败
					//从异常中获取失败信息
					string msg = e.Message ;
					//调用写日志方法
					//Trace.Write("DeriveParameters","Error",spName+"|"+msg) ;
				}

				//如果有返回值
				if (!hasReturn) 
				{
					cmd.Parameters.RemoveAt(0);
				}

				//将Parameters集中的参数复制到参数数组
				SqlParameter[] para = new SqlParameter[cmd.Parameters.Count] ;
				cmd.Parameters.CopyTo(para,0) ;

				return para ;
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
		/// 获取存储过程参数
		/// </summary>
		/// <param name="spName">存储过程名</param>
		/// <param name="hasReturn">是否包含返回值</param>
		/// <returns>返回参数序列</returns>
		public static SqlParameter[] GetSpParameters(string spName, bool hasReturn)
		{
			//缓存HashTable的主键
			string cacheKey = spName + (hasReturn ? ":hasReturn":"");
			//从Hachtable中获取参数
			SqlParameter[] cachedParameters  = (SqlParameter[])myCache[cacheKey];
			if(cachedParameters == null)
			{		
				//如果Hachtable中没有，调用获取存储过程参数数组方法
				cachedParameters = (SqlParameter[])(myCache[cacheKey] = GetSpParameterSet(spName,hasReturn)) ;
			}			

			return CloneParameters(cachedParameters);
		}
		#endregion

		#region 执行返回DataSet的存储过程
		/// <summary>
		/// 执行返回DataSet的存储过程
		/// </summary>
		/// <param name="commandType">命令类型，存储过程、Text等</param>
		/// <param name="commandText">存储过程名或SQL语句等</param>
		/// <param name="commandParameters">参数序列</param>
		/// <returns>查询结果DataSet</returns>
		private static DataSet ExecuteDataset_in(string commandText, params SqlParameter[] commandParameters)
		{	
			//如果数据连接未开启，打开它
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}

			//准备命令
			PrepareCommand(commandText, commandParameters);
			
			//创建DataAdapter和DataSet
			SqlDataAdapter da = new SqlDataAdapter(_command);
			DataSet ds = new DataSet();

			//填充DataSet
			try
			{
				da.Fill(ds);
			}
			catch(Exception e)
			{
				//执行失败
				//从异常中获取失败信息
				string msg = e.Message ;
				//调用写日志方法
				//Trace.Write("FillDataSet","Error",commandText+"|"+msg) ;
			}
			
			// 清除参数		
			_command.Parameters.Clear();

			_connection.Close() ;

			return ds ;
		}

		/// <summary>
		/// 执行返回DataSet的存储过程
		/// </summary>		
		/// <param name="spName">存储过程名</param>
		/// <param name="parameterValues">参数值序列</param>
		/// <returns>查询结果DataSet</returns>
		public static DataSet ExecuteDataset(string spName, params object[] parameterValues)
		{
			//如果有参数值, 先赋参数值再执行
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//获取存储过程参数
				SqlParameter[] commandParameters = GetSpParameters(spName,false);

				//为存储过程参数设定参数值
				AssignParameterValues(commandParameters, parameterValues);

				//调用执行带数值的存储过程方法
				return ExecuteDataset_in(spName, commandParameters);
			}
				//调用不带参数的方法
			else 
			{
				return ExecuteDataset_in(spName);
			}
		}		
		#endregion

		#region 执行返回DataTable的存储过程
		/// <summary>
		/// 执行返回DataTable的存储过程
		/// </summary>
		/// <param name="commandType">命令类型，存储过程、Text等</param>
		/// <param name="commandText">存储过程名或SQL语句等</param>
		/// <param name="commandParameters">参数序列</param>
		/// <returns>查询结果DataTable</returns>
		private static DataTable ExecuteDataTable_in(string commandText, params SqlParameter[] commandParameters)
		{	
			//如果数据连接未开启，打开它
			InitConn();
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}

			//准备命令
			PrepareCommand(commandText, commandParameters);
			
			//创建DataAdapter和DataSet
			SqlDataAdapter da = new SqlDataAdapter(_command);
			DataTable dt = new DataTable();

			//填充DataTable
			try
			{
				da.Fill(dt);
			}
			catch(Exception e)
			{
				//执行失败
				//从异常中获取失败信息
				string msg = e.Message ;
				//调用写日志方法
				//Trace.Write("FillDataTable","Error",commandText+"|"+msg) ;
			}
			
			// 清除参数		
			_command.Parameters.Clear();

			//执行完毕，关闭连接
			_connection.Close() ;

			return dt ;
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
				SqlParameter[] commandParameters = GetSpParameters(spName,false);

				//为存储过程参数设定参数值
				AssignParameterValues(commandParameters, parameterValues);

				//调用执行带数值的存储过程方法
				return ExecuteDataTable_in(spName, commandParameters);
			}
				//调用不带参数的方法
			else 
			{
				return ExecuteDataTable_in(spName);
			}
		}		
		#endregion

		#region 检索标量
		
		/// <summary>
		/// 执行检索单个标量的存储过程
		/// </summary>
		/// <param name="commandText">存储过程名</param>
		/// <param name="commandParameters">存储过程参数值序列</param>
		/// <returns>检索结果</returns>
		private static object ExecuteScalar_in(string commandText, params SqlParameter[] commandParameters)
		{
			//如果数据连接未开启，打开它
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}

			//准备命令
			PrepareCommand(commandText, commandParameters);

			//execute the command & return the results
			object retval = null ;
			try
			{
				retval = _command.ExecuteScalar();
			}
			catch(Exception e)
			{
				//执行失败
				//从异常中获取失败信息
				string msg = e.Message ;
				//调用写日志方法
				//Trace.Write("ExecuteScalar","Error",commandText+"|"+msg) ;
			}

			//清除参数.
			_command.Parameters.Clear();

			//关闭连接
			_connection.Close() ;

			return retval;
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
				SqlParameter[] commandParameters = GetSpParameters(spName,false);
				//参数值
				AssignParameterValues(commandParameters, parameterValues);

				//调用带参数的执行方法
				return ExecuteScalar_in(spName, commandParameters);
			}
				//调用不带参数的执行方法
			else 
			{
				return ExecuteScalar_in(spName);
			}
		}	
		#endregion

		#region DataAdapter

		public static int AdapterUpdate(DataTable dt,string tableName,string key)
		{
			int ret = -1 ;
			AdapterCommand(dt,tableName,key);	

			//如果数据连接未开启，打开它
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}		

			//执行
			try
			{
				ret = _adapter.Update(dt);
			}
			catch(Exception e)
			{
				//执行失败
				//从异常中获取失败信息
				string msg = e.Message ;
				//调用写日志方法
				//Trace.Write("AdapterUpdate","Error",tableName+"|"+msg) ;
			}

			return ret;
		}

		// 为Table在Adapter上生成insert和update命令
		private static void AdapterCommand(DataTable dt,string table,string key)
		{
			string in_sql = "" ;
			string up_sql = "" ;
			string val = "" ;

			//初始化插入命令
			SqlCommand in_cmd=new SqlCommand() ;
			in_cmd.CommandType=CommandType.Text;
			in_cmd.Connection=_connection;

			//初始化更新命令
			SqlCommand up_cmd=new SqlCommand() ;
			up_cmd.CommandType=CommandType.Text;
			up_cmd.Connection=_connection;

			//初始化删除命令
			SqlCommand de_cmd=new SqlCommand() ;
			de_cmd.CommandType = CommandType.Text;
			de_cmd.Connection = _connection;

			DataColumn dc = null ;

			for(int i=0;i<dt.Columns.Count;i++)
			{
				//拼写插入语句
				if(dt.Columns[i].ColumnName == key)
				{
					continue ;
				}

				if(in_sql != "" )
				{
					in_sql += "," ;
				}
				in_sql += dt.Columns[i].ColumnName;

				//值
				if( val != "" ) 
				{
					val += "," ;
				}
				val += "@?" ;				
				
				dc = dt.Columns[i];

				//添加插入命令参数
				in_cmd.Parameters.Add("@p"+i.ToString(),
					ColumnType(dc),
					(dc.MaxLength<0?200:dc.MaxLength),
					dc.ColumnName);

				//拼写更新语句
				if(up_sql != "")  
				{
					up_sql += "," ;
				}
				up_sql += dt.Columns[i].ColumnName + "=?" ;

				//添加更新命令参数
				up_cmd.Parameters.Add("@p"+i.ToString(),
					ColumnType(dc),
					(dc.MaxLength<0?2000:dc.MaxLength),
					dc.ColumnName);
			}

			StringWriter sw=new StringWriter();

			//如果有主键
			if ( key != "")
			{
				dc=dt.Columns[key];
				up_cmd.Parameters.Add("@p"+dt.Columns.Count.ToString(),
					ColumnType(dc),
					(dc.MaxLength<0?2000:dc.MaxLength),
					dc.ColumnName);

				//添加删除命令参数
				de_cmd.Parameters.Add("@p0",
					ColumnType(dc),
					(dc.MaxLength<0?2000:dc.MaxLength),
					dc.ColumnName);
				//删除命令
				de_cmd.CommandText="delete from " + table + " where " + key +"=@?";
				
				sw=null;
				sw=new StringWriter();
				sw.Write("update {0} set {1} where " + key + "=@?",table,up_sql);
				up_cmd.CommandText=sw.ToString();
			}

			//插入命令	
			sw = null ;
			sw = new StringWriter() ;
			sw.Write("insert into {0} ({1}) values({2})",
				table,in_sql,val);
			in_cmd.CommandText=sw.ToString();

			//为Adapter设置添加、更新、删除命令
			_adapter.InsertCommand = in_cmd ;
			_adapter.UpdateCommand = up_cmd ;
			_adapter.DeleteCommand = de_cmd ;
		}


		private static System.Data.SqlDbType ColumnType(DataColumn dc)
		{
			//默认为字符类型
			SqlDbType type = SqlDbType.VarChar;
			
			//新建一个C#数据类型和Sql Server数据类型的转换
			//暂时只处理日期、字符和整型三种数据类型
			object[] oType = new object[]
			{					
				new object[]{Type.GetType("System.DateTime"),SqlDbType.DateTime },
				new object[]{Type.GetType("System.String"),SqlDbType.VarChar },
				new object[]{Type.GetType("System.Int32"),SqlDbType.Int },
			};

			//将数据类型对应到SQL Server数据类型
			for(int i=0;i<oType.Length;i++)
			{
				object[] o = (object[])oType[i];
				if(dc.DataType == (Type)o[0])
				{
					type = (SqlDbType)o[1];
					break ;
				}
			}

			//返回SQL Server数据类型
			return type ;
		}

		#endregion
	}
}
