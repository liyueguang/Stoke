using System;
using System.Diagnostics;
using System.IO;


namespace Stoke.Components 
{
	/// <summary>
	/// �������������ڼ�¼������־
	/// </summary>
	public class Error {
		//��¼������־λ��
		private const string FILE_NAME = "c:\\udslog.txt";

		/// <summary>
		/// ��¼��־���ı��ļ�
		/// </summary>
		/// <param name="message">��¼������</param>
		public static void Log(string message) {
			if(File.Exists(FILE_NAME))
			{
				StreamWriter sr = File.AppendText(FILE_NAME);
				sr.WriteLine ("\n");
				sr.WriteLine (DateTime.Now.ToString()+message);
				sr.Close();
			}
			else
			{
				StreamWriter sr = File.CreateText(FILE_NAME);
				sr.Close();
			}
			
				
		}
	}
}
