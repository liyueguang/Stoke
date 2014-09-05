namespace Stoke.COMMON
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		SlctPosition 的摘要说明。
	/// </summary>
	public class SlctPosition : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.ListBox LB_All;
		protected System.Web.UI.WebControls.DropDownList ddlBm;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.ListBox LB_Select;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				BindBm();
				BindLbAll(this.ddlBm.SelectedValue.Trim());
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.ddlBm.SelectedIndexChanged += new System.EventHandler(this.ddlBm_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string [] Send
		{
			get
			{
				string [] send = new string[2];
				send[0] = "";
				int count = LB_Select.Items.Count;
				send[1] = count.ToString();
				if( 0 != count)
				{
					for(int i = 0; i < count; i ++)
					{
						if(0 == i)
						{
							send[0] += LB_Select.Items[i].Text.Trim();
						}
						else
						{
							send[0] += "/" + LB_Select.Items[i].Text.Trim();
						}
					}
				}
				return send;
			}
			set
			{
				string [] send = new string [2];
				send = value;
				char [] seprator =new char [1];
				seprator[0] = '/';
				string [] Send = send[0].Split(seprator,10);
				int count = Send.Length;
				for(int i =0; i < count; i ++)
				{
					LB_Select.Items.Add(new ListItem(Send[i],Send[i]));
				}
			}
		}

		private void BindBm()
		{
			DataTable dt_bm = Stoke.BLL.Department.GetAll();		
			this.ddlBm.DataSource = dt_bm;
			this.ddlBm.DataTextField = "bm_mc";
			this.ddlBm.DataValueField = "bm_mc";
			this.ddlBm.DataBind();
			this.ddlBm.Items.Insert(0,"-请选择-");
			this.ddlBm.SelectedIndex = 0;
		}

		private void BindLbAll(string bm)
		{
			DataTable dt_zw = Stoke.Components.Staff.SelectZwByBm(bm);
			this.LB_All.DataSource = dt_zw;
			this.LB_All.DataTextField = "zw";
			this.LB_All.DataValueField = "zw";
			this.LB_All.DataBind();
			if(LB_All.Items.Count != 0 && LB_Select.Items.Count != 0)
			{
				for(int i = 0;i<LB_All.Items.Count;i++)
				{
					for(int j = 0;j<LB_Select.Items.Count;j++)
					{
						if(LB_All.Items[i].Text.ToString() == LB_Select.Items[j].Text.ToString())
						{
							LB_All.Items.Remove(LB_All.Items[i]);
							i--;
							break;
						}
					}
				}
			}
		}

		public void Clear()
		{ 
			this.ddlBm.SelectedIndex=0;
			this.LB_All.Items.Clear();
			this.LB_Select.Items.Clear();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			for(int i = 0;i<LB_All.Items.Count;i++)
			{
				if(LB_All.Items[i].Selected == true)
				{
					LB_Select.Items.Add(LB_All.Items[i]);
					LB_All.Items.Remove(LB_All.Items[i]); 
					i--;
				}
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			for(int i = 0;i<LB_Select.Items.Count;i++)
			{
				if(LB_Select.Items[i].Selected == true)
				{
					LB_All.Items.Add(LB_Select.Items[i]);
					LB_Select.Items.Remove(LB_Select.Items[i]); 
					i--;
				}
			}
		}

		private void ddlBm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindLbAll(this.ddlBm.SelectedValue.Trim());
		}

	}
}
