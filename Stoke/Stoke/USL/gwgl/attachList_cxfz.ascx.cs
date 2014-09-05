namespace Stoke.USL.gwgl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		attachList_cxfz ��ժҪ˵����
	/// </summary>
	public class attachList_cxfz : System.Web.UI.UserControl
	{

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//BindData();
		}

		protected System.Web.UI.WebControls.Repeater attachRepeater;

		private string dataSource;
		public string DataSource
		{
			set
			{
				this.dataSource = value;
			}
		}

		public override void DataBind()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("attach_id");
			dt.Columns.Add("attach_name");
			dt.Columns.Add("attach_size");
			dt.Columns.Add("attach_link");

			if (dataSource.IndexOf("^") <= 0)
				return;
			string qx_bz = dataSource.Substring(dataSource.LastIndexOf("^") + 1).Trim();
			if (true)
			{
				dataSource = dataSource.Substring(0, dataSource.LastIndexOf("^"));
				string[] list1 = dataSource.Split('^');
				for (int i = 0; i < list1.Length; i++)
				{
					string[] list2 = list1[i].Split('$');
					DataRow row1 = dt.NewRow();
					row1["attach_id"] = list2[0];
					row1["attach_name"] = list2[1];
					row1["attach_size"] = Convert.ToInt32(list2[2]) > 0 ? list2[2] + "K" : "С��1K";
					if (list2[3] == "doc" || list2[3] == "xls")
					{
						row1["attach_link"] = "wordRead.aspx?id="+list2[0]+"&filename="+FileToMSSQL.Util.EncryptFilename(list2[1]);
					}
					else
					{
						row1["attach_link"] = "../filetosql/Download_fj.aspx?id="+list2[0]+"&filename="+FileToMSSQL.Util.EncryptFilename(list2[1]);
					}
					dt.Rows.Add(row1);
				}
			}
			
			this.attachRepeater.DataSource = dt.DefaultView;
			this.attachRepeater.DataBind();
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
