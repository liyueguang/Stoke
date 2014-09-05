using System;

namespace FileToMSSQL
{
	/// <summary>
	/// 
	/// </summary>
	public class Indicator
	{
		private long _totalLength = 0;
		private long _uploadedLength = 0;
		private string _currentFile = string.Empty;
		private int _totalCount = 0;
		private int _uploadedCount = 0;
		private int _percentage = 0;
		
		#region attributes
		public long TotalLength
		{
			get
			{
				return _totalLength;
			}
			set
			{
				_totalLength = value;
			}
		}

		public long UploadedLength
		{
			get
			{
				return _uploadedLength;
			}
			set
			{
				_uploadedLength = value;
			}
		}

		public string CurrentFile
		{
			get
			{
				return _currentFile;
			}
			set
			{				
				_currentFile = value;
			}
		}

		public int TotalCount
		{
			get
			{
				return _totalCount;
			}
			set
			{
				_totalCount = value;
			}
		}

		public int UploadedCount
		{
			get
			{
				return _uploadedCount;
			}
			set
			{
				_uploadedCount = value;
			}
		}

		public int Percentage
		{
			get
			{
				if(this._totalLength > 0)
				{
					_percentage = (int)(this._uploadedLength*100/this._totalLength);
				}
				return _percentage;
			}
		}
		#endregion

		public Indicator()
		{
		}
	}
}
