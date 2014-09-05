using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Configuration ;

namespace Stoke.Model.zhxxgl_xxyd
{
	/// <summary>
	/// Ggl ��ժҪ˵����
	/// </summary>
	public class Ggl_xxyd
	{
		//ѧϰ԰��
		public Ggl_xxyd()
		{
			
		}
		public int Ggl_Id
		{
			get
			{
				return this.ggl_id;
			}
			set
			{
				this.ggl_id = value;
			}
		}
		public string Ggl_ReleaseName //����������,hhw20101024
		{
			get
			{
				return this.ggl_releaseName;
			}
			set
			{
				this.ggl_releaseName = value;
			}
		}
		public string Ggl_Xxlb
		{
			get
			{
				return this.ggl_xxlb;
			}
			set
			{
				this.ggl_xxlb = value;
			}
		}
		public string Ggl_Fbsj
		{
			get
			{
				return this.ggl_fbsj;
			}
			set
			{
				this.ggl_fbsj = value;
			}
		}
		public string Ggl_Btm
		{
			get
			{
				return this.ggl_btm;
			}
			set
			{
				this.ggl_btm = value;
			}
		}
		public string Ggl_Xxnr
		{
			get
			{
				return this.ggl_xxnr;
			}
			set
			{
				this.ggl_xxnr = value;
			}
		}
		private int ggl_id;
		private string ggl_releaseName; //����������
		private string ggl_xxlb;
		private string ggl_fbsj;
		private string ggl_btm;
		private string ggl_xxnr;
	}

	public class Gggl_xxyd
	{
	  //������
		private int Zhxx_Xxfb_Id;//���
		private string Zhxx_Xxfb_Ngr;//�����
		private string Zhxx_Xxfb_Ssbm;//����
		private DateTime Zhxx_Xxfb_Sqrq;//��������
		private string Zhxx_Xxfb_Ngfl;//����
		private string Zhxx_Xxfb_Bt;//����
		private string Zhxx_Xxfb_Ztc;//�����
		private string Zhxx_Xxfb_Xxnr;//��Ϣ����
		private string Zhxx_Xxfb_Zhbsp;//�ۺϲ�����
		private string Zhxx_Xxfb_Zgfzrsp;//���ܸ�����
		private string Zhxx_Xxfb_Zjlsp;//�ܾ�������
		private string Zhxx_Xxfb_Bz;//��ע
		public int Xxfb_Id
		{
			get
			{
				return this.Zhxx_Xxfb_Id;
			}
			set
			{
				this.Zhxx_Xxfb_Id = value;
			}
		}
		public string Xxfb_ngr
		{
			get
			{
				return this.Zhxx_Xxfb_Ngr;
			}
			set
			{
				this.Zhxx_Xxfb_Ngr = value;
			}
		}
		public string Xxfb_ssbm
		{
			get
			{
				return this.Zhxx_Xxfb_Ssbm;
			}
			set
			{
				this.Zhxx_Xxfb_Ssbm = value;
			}
		}
		public DateTime  Xxfb_sqrq
		{
			get
			{
				return this.Zhxx_Xxfb_Sqrq;
			}
			set
			{
				this.Zhxx_Xxfb_Sqrq = value;
			}
		}
		public string Xxfb_ngfl
		{
			get
			{
				return this.Zhxx_Xxfb_Ngfl;
			}
			set
			{
				this.Zhxx_Xxfb_Ngfl = value;
			}
		}
		public string Xxfb_bt
		{
			get
			{
				return this.Zhxx_Xxfb_Bt;
			}
			set
			{
				this.Zhxx_Xxfb_Bt = value;
			}
		}
		public string Xxfb_xxnr
		{
			get
			{
				return this.Zhxx_Xxfb_Xxnr;
			}
			set
			{
				this.Zhxx_Xxfb_Xxnr = value;
			}
		}
		public string Xxfb_ztc
		{
			get
			{
				return this.Zhxx_Xxfb_Ztc;
			}
			set
			{
				this.Zhxx_Xxfb_Ztc = value;
			}
		}
		public string Xxfb_zhbsp
		{
			get
			{
				return this.Zhxx_Xxfb_Zhbsp;
			}
			set
			{
				this.Zhxx_Xxfb_Zhbsp = value;
			}
		}

		
		public string Xxfb_zgfzrsp
		{
			get
			{
				return this.Zhxx_Xxfb_Zgfzrsp;
			}
			set
			{
				this.Zhxx_Xxfb_Zgfzrsp = value;
			}
		}
		public string Xxfb_zjlsp
		{
			get
			{
				return this.Zhxx_Xxfb_Zjlsp;
			}
			set
			{
				this.Zhxx_Xxfb_Zjlsp = value;
			}
		}

		public string Xxfb_bz
		{
			get
			{
				return this.Zhxx_Xxfb_Bz;
			}
			set
			{
				this.Zhxx_Xxfb_Bz = value;
				
			}
		}
		

	}
}
