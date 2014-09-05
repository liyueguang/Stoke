using System;
using System.IO ;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Caching ;
using System.Configuration;
//using ��������.comon;
using System.Collections.Specialized ;

namespace Stoke.Help
{
	/// <summary>
	/// DAL ��ժҪ˵����
	/// </summary>
	public class DataAccess
	{
		private static SqlConnection _connection  ;
		private static SqlCommand _command  ;
		private static SqlDataAdapter _adapter ;
		//		private static SqlCommand _command_ds  ;
		//		private static SqlCommand _command_sl  ;

		//�����Լ���Hashtable
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

		#region ��ʼ��
		/// <summary>
		/// ��ʼ����������
		/// </summary>
		/// <returns>true:�ɹ�  false:ʧ��</returns>
		public static bool InitConn()
		{
			bool ret = true ;

			//��ȡweb.config�����õ����������ִ�
			string str_conn = ConnectionString;
			if(str_conn != "")
				//��ʼ����������
				_connection = new SqlConnection(str_conn) ;
			else
			{
				ret = false ;
				return ret ;
			}

			//��ʼ������
			_command = new SqlCommand() ;

			//Ϊ����������������
			_command.Connection = _connection ;		

			//��ʼ������������
			_adapter = new SqlDataAdapter() ;
						
			return ret ;
		}
		#endregion

		#region ������ֵ
		/// <summary>
		/// ��SQL��������ֵ����SQL���SQL����洢���̣�
		/// </summary>
		/// <param name="commandParameters">��ָ����SQL����Ĳ�������</param>
		private static void AttachParameters(SqlParameter[] commandParameters)
		{
			foreach (SqlParameter p in commandParameters)
			{
				//��Ϊnull�����������ֵ
				if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
				{
					p.Value = DBNull.Value;
				}
				
				_command.Parameters.Add(p);
			}
		}

		/// <summary>
		/// ������ֵ���и�ֵ����Ӧ�Ĳ�������
		/// </summary>
		/// <param name="commandParameters">����ֵ�Ĳ�������</param>
		/// <param name="parameterValues">����ֵ����</param>
		private static bool AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			bool ret = true ;

			if ((commandParameters == null) || (parameterValues == null)) 
			{
				//������Ϊnull������
				return ret;
			}

			// �������鳤�������ֵ���鳤����ƥ��
			if (commandParameters.Length != parameterValues.Length)
			{
				ret = false ;
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
		/// Ϊ������SQL���SQL����洢���̣����������ӣ����������������ơ��������͵ȵ�
		/// ��Ϊ����Ĳ�����ֵ
		/// </summary>
		/// <param name="commandType">��������</param>
		/// <param name="commandText">�洢��������SQL���</param>
		/// <param name="commandParameters">��������</param>
		private static void PrepareCommand(string commandText, SqlParameter[] commandParameters)
		{
			//����������δ�򿪣�������
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}			

			//����command text (�洢������������SQL���)
			_command.CommandText = commandText;			

			//ָ���������ͣ��洢���̻�������SQL��䣩
			_command.CommandType = CommandType.StoredProcedure;

			//Ϊ������ֵ
			if (commandParameters != null)
			{
				AttachParameters(commandParameters);
			}

			return;
		}
		#endregion

		#region ִ���޲�ѯ�洢����
		/// <summary>
		/// ִ���޲�ѯ�洢����
		/// </summary>
		/// <param name="commandText">�洢������</param>
		/// <param name="HasReturn">�Ƿ��з���ֵ</param>
		/// <param name="commandParameters">����ֵ</param>
		/// <returns>����ִ�н��</returns>
		public static int ExecuteNonQuery_in(string commandText,bool HasReturn, params SqlParameter[] commandParameters)
		{
			int result = -1 ;
			//����������������			
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}		
			
			_command.Connection = _connection ;
			PrepareCommand(commandText, commandParameters);

			//����ִ�к���
			//ִ������
			try
			{
				result = _command.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				//ִ��ʧ��
				//���쳣�л�ȡʧ����Ϣ
				string msg = e.Message ;
				//����д��־����
				//Trace.Write("ExecuteNonQuery","Error",commandText+"|"+msg) ;
			}
			if(HasReturn)
			{
				result = (int)_command.Parameters["@RETURN_VALUE"].Value ;
			}				
			
			//�������
			_command.Parameters.Clear();

			//ִ����Ϻ�ر�����
			_connection.Close() ;

			return result ;
		}
		
		/// <summary>
		/// ִ���޷���ֵ�Ĵ洢����
		/// ע�����ֵ��˳������洢���̲���˳��һ��
		/// </summary>		
		/// <param name="spName">�洢������</param>
		/// <param name="parameterValues">����ֵ</param>
		/// <returns>ִ�н��</returns>
		public static int ExecuteNonQuery(string spName,bool hasReturns,params object[] parameterValues)
		{
			//����в���ֵ, �ȸ�����ֵ��ִ��
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//��ȡ�洢���̲���
				SqlParameter[] commandParameters = GetSpParameters(spName,hasReturns);

				//Ϊ�洢���̲����趨����ֵ
				AssignParameterValues(commandParameters, parameterValues);

				//����ִ�д�����ֵ�Ĵ洢���̷���
				return ExecuteNonQuery_in(spName,hasReturns, commandParameters);
			}
				//��������
			else 
			{
				return ExecuteNonQuery_in(spName,hasReturns);
			}
		}
		#endregion

		#region ��ȡ�洢���̲���
		/// <summary>
		/// ��ȡ�洢���̲�������
		/// </summary>
		/// <param name="spName">�洢������</param>
		/// <param name="hasReturn">�Ƿ�����������͵Ĳ���</param>
		/// <returns>��������</returns>
		private static SqlParameter[] GetSpParameterSet(string spName,bool hasReturn)
		{			
			using(SqlCommand cmd = new SqlCommand() )
			{
				//Ϊ����ָ������
				InitConn();
				cmd.Connection = _connection ;

				//�����������δ����������
				if(_connection.State != ConnectionState.Open)
				{
					_connection.Open() ;
				}
				//ָ��CommandTextΪ�洢������
				cmd.CommandText = spName ;
				cmd.CommandType = CommandType.StoredProcedure ;
				//�Ӵ洢�����м�����������䵽Parameters��
				try
				{
					SqlCommandBuilder.DeriveParameters(cmd) ;
				}
				catch(Exception e)
				{
					//ִ��ʧ��
					//���쳣�л�ȡʧ����Ϣ
					string msg = e.Message ;
					//����д��־����
					//Trace.Write("DeriveParameters","Error",spName+"|"+msg) ;
				}

				//����з���ֵ
				if (!hasReturn) 
				{
					cmd.Parameters.RemoveAt(0);
				}

				//��Parameters���еĲ������Ƶ���������
				SqlParameter[] para = new SqlParameter[cmd.Parameters.Count] ;
				cmd.Parameters.CopyTo(para,0) ;

				return para ;
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
		/// ��ȡ�洢���̲���
		/// </summary>
		/// <param name="spName">�洢������</param>
		/// <param name="hasReturn">�Ƿ��������ֵ</param>
		/// <returns>���ز�������</returns>
		public static SqlParameter[] GetSpParameters(string spName, bool hasReturn)
		{
			//����HashTable������
			string cacheKey = spName + (hasReturn ? ":hasReturn":"");
			//��Hachtable�л�ȡ����
			SqlParameter[] cachedParameters  = (SqlParameter[])myCache[cacheKey];
			if(cachedParameters == null)
			{		
				//���Hachtable��û�У����û�ȡ�洢���̲������鷽��
				cachedParameters = (SqlParameter[])(myCache[cacheKey] = GetSpParameterSet(spName,hasReturn)) ;
			}			

			return CloneParameters(cachedParameters);
		}
		#endregion

		#region ִ�з���DataSet�Ĵ洢����
		/// <summary>
		/// ִ�з���DataSet�Ĵ洢����
		/// </summary>
		/// <param name="commandType">�������ͣ��洢���̡�Text��</param>
		/// <param name="commandText">�洢��������SQL����</param>
		/// <param name="commandParameters">��������</param>
		/// <returns>��ѯ���DataSet</returns>
		private static DataSet ExecuteDataset_in(string commandText, params SqlParameter[] commandParameters)
		{	
			//�����������δ����������
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}

			//׼������
			PrepareCommand(commandText, commandParameters);
			
			//����DataAdapter��DataSet
			SqlDataAdapter da = new SqlDataAdapter(_command);
			DataSet ds = new DataSet();

			//���DataSet
			try
			{
				da.Fill(ds);
			}
			catch(Exception e)
			{
				//ִ��ʧ��
				//���쳣�л�ȡʧ����Ϣ
				string msg = e.Message ;
				//����д��־����
				//Trace.Write("FillDataSet","Error",commandText+"|"+msg) ;
			}
			
			// �������		
			_command.Parameters.Clear();

			_connection.Close() ;

			return ds ;
		}

		/// <summary>
		/// ִ�з���DataSet�Ĵ洢����
		/// </summary>		
		/// <param name="spName">�洢������</param>
		/// <param name="parameterValues">����ֵ����</param>
		/// <returns>��ѯ���DataSet</returns>
		public static DataSet ExecuteDataset(string spName, params object[] parameterValues)
		{
			//����в���ֵ, �ȸ�����ֵ��ִ��
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//��ȡ�洢���̲���
				SqlParameter[] commandParameters = GetSpParameters(spName,false);

				//Ϊ�洢���̲����趨����ֵ
				AssignParameterValues(commandParameters, parameterValues);

				//����ִ�д���ֵ�Ĵ洢���̷���
				return ExecuteDataset_in(spName, commandParameters);
			}
				//���ò��������ķ���
			else 
			{
				return ExecuteDataset_in(spName);
			}
		}		
		#endregion

		#region ִ�з���DataTable�Ĵ洢����
		/// <summary>
		/// ִ�з���DataTable�Ĵ洢����
		/// </summary>
		/// <param name="commandType">�������ͣ��洢���̡�Text��</param>
		/// <param name="commandText">�洢��������SQL����</param>
		/// <param name="commandParameters">��������</param>
		/// <returns>��ѯ���DataTable</returns>
		private static DataTable ExecuteDataTable_in(string commandText, params SqlParameter[] commandParameters)
		{	
			//�����������δ����������
			InitConn();
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}

			//׼������
			PrepareCommand(commandText, commandParameters);
			
			//����DataAdapter��DataSet
			SqlDataAdapter da = new SqlDataAdapter(_command);
			DataTable dt = new DataTable();

			//���DataTable
			try
			{
				da.Fill(dt);
			}
			catch(Exception e)
			{
				//ִ��ʧ��
				//���쳣�л�ȡʧ����Ϣ
				string msg = e.Message ;
				//����д��־����
				//Trace.Write("FillDataTable","Error",commandText+"|"+msg) ;
			}
			
			// �������		
			_command.Parameters.Clear();

			//ִ����ϣ��ر�����
			_connection.Close() ;

			return dt ;
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
				SqlParameter[] commandParameters = GetSpParameters(spName,false);

				//Ϊ�洢���̲����趨����ֵ
				AssignParameterValues(commandParameters, parameterValues);

				//����ִ�д���ֵ�Ĵ洢���̷���
				return ExecuteDataTable_in(spName, commandParameters);
			}
				//���ò��������ķ���
			else 
			{
				return ExecuteDataTable_in(spName);
			}
		}		
		#endregion

		#region ��������
		
		/// <summary>
		/// ִ�м������������Ĵ洢����
		/// </summary>
		/// <param name="commandText">�洢������</param>
		/// <param name="commandParameters">�洢���̲���ֵ����</param>
		/// <returns>�������</returns>
		private static object ExecuteScalar_in(string commandText, params SqlParameter[] commandParameters)
		{
			//�����������δ����������
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}

			//׼������
			PrepareCommand(commandText, commandParameters);

			//execute the command & return the results
			object retval = null ;
			try
			{
				retval = _command.ExecuteScalar();
			}
			catch(Exception e)
			{
				//ִ��ʧ��
				//���쳣�л�ȡʧ����Ϣ
				string msg = e.Message ;
				//����д��־����
				//Trace.Write("ExecuteScalar","Error",commandText+"|"+msg) ;
			}

			//�������.
			_command.Parameters.Clear();

			//�ر�����
			_connection.Close() ;

			return retval;
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
				SqlParameter[] commandParameters = GetSpParameters(spName,false);
				//����ֵ
				AssignParameterValues(commandParameters, parameterValues);

				//���ô�������ִ�з���
				return ExecuteScalar_in(spName, commandParameters);
			}
				//���ò���������ִ�з���
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

			//�����������δ����������
			if (_connection.State != ConnectionState.Open)
			{
				_connection.Open();
			}		

			//ִ��
			try
			{
				ret = _adapter.Update(dt);
			}
			catch(Exception e)
			{
				//ִ��ʧ��
				//���쳣�л�ȡʧ����Ϣ
				string msg = e.Message ;
				//����д��־����
				//Trace.Write("AdapterUpdate","Error",tableName+"|"+msg) ;
			}

			return ret;
		}

		// ΪTable��Adapter������insert��update����
		private static void AdapterCommand(DataTable dt,string table,string key)
		{
			string in_sql = "" ;
			string up_sql = "" ;
			string val = "" ;

			//��ʼ����������
			SqlCommand in_cmd=new SqlCommand() ;
			in_cmd.CommandType=CommandType.Text;
			in_cmd.Connection=_connection;

			//��ʼ����������
			SqlCommand up_cmd=new SqlCommand() ;
			up_cmd.CommandType=CommandType.Text;
			up_cmd.Connection=_connection;

			//��ʼ��ɾ������
			SqlCommand de_cmd=new SqlCommand() ;
			de_cmd.CommandType = CommandType.Text;
			de_cmd.Connection = _connection;

			DataColumn dc = null ;

			for(int i=0;i<dt.Columns.Count;i++)
			{
				//ƴд�������
				if(dt.Columns[i].ColumnName == key)
				{
					continue ;
				}

				if(in_sql != "" )
				{
					in_sql += "," ;
				}
				in_sql += dt.Columns[i].ColumnName;

				//ֵ
				if( val != "" ) 
				{
					val += "," ;
				}
				val += "@?" ;				
				
				dc = dt.Columns[i];

				//��Ӳ����������
				in_cmd.Parameters.Add("@p"+i.ToString(),
					ColumnType(dc),
					(dc.MaxLength<0?200:dc.MaxLength),
					dc.ColumnName);

				//ƴд�������
				if(up_sql != "")  
				{
					up_sql += "," ;
				}
				up_sql += dt.Columns[i].ColumnName + "=?" ;

				//��Ӹ����������
				up_cmd.Parameters.Add("@p"+i.ToString(),
					ColumnType(dc),
					(dc.MaxLength<0?2000:dc.MaxLength),
					dc.ColumnName);
			}

			StringWriter sw=new StringWriter();

			//���������
			if ( key != "")
			{
				dc=dt.Columns[key];
				up_cmd.Parameters.Add("@p"+dt.Columns.Count.ToString(),
					ColumnType(dc),
					(dc.MaxLength<0?2000:dc.MaxLength),
					dc.ColumnName);

				//���ɾ���������
				de_cmd.Parameters.Add("@p0",
					ColumnType(dc),
					(dc.MaxLength<0?2000:dc.MaxLength),
					dc.ColumnName);
				//ɾ������
				de_cmd.CommandText="delete from " + table + " where " + key +"=@?";
				
				sw=null;
				sw=new StringWriter();
				sw.Write("update {0} set {1} where " + key + "=@?",table,up_sql);
				up_cmd.CommandText=sw.ToString();
			}

			//��������	
			sw = null ;
			sw = new StringWriter() ;
			sw.Write("insert into {0} ({1}) values({2})",
				table,in_sql,val);
			in_cmd.CommandText=sw.ToString();

			//ΪAdapter������ӡ����¡�ɾ������
			_adapter.InsertCommand = in_cmd ;
			_adapter.UpdateCommand = up_cmd ;
			_adapter.DeleteCommand = de_cmd ;
		}


		private static System.Data.SqlDbType ColumnType(DataColumn dc)
		{
			//Ĭ��Ϊ�ַ�����
			SqlDbType type = SqlDbType.VarChar;
			
			//�½�һ��C#�������ͺ�Sql Server�������͵�ת��
			//��ʱֻ�������ڡ��ַ�������������������
			object[] oType = new object[]
			{					
				new object[]{Type.GetType("System.DateTime"),SqlDbType.DateTime },
				new object[]{Type.GetType("System.String"),SqlDbType.VarChar },
				new object[]{Type.GetType("System.Int32"),SqlDbType.Int },
			};

			//���������Ͷ�Ӧ��SQL Server��������
			for(int i=0;i<oType.Length;i++)
			{
				object[] o = (object[])oType[i];
				if(dc.DataType == (Type)o[0])
				{
					type = (SqlDbType)o[1];
					break ;
				}
			}

			//����SQL Server��������
			return type ;
		}

		#endregion
	}
}
