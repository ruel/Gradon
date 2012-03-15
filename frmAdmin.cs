using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using System.Threading;


namespace Gradon
{
	public partial class frmAdmin
	{
		private string id;
		gradonDataSet gds = new gradonDataSet();
		DataTable users;
		gradonDataSetTableAdapters.usersTableAdapter gDap = new gradonDataSetTableAdapters.usersTableAdapter();
		public frmAdmin(string user)
		{
			
			// This call is required by the designer.
			InitializeComponent();
			id = user;
		}
		public void frmAdmin_Load(System.Object sender, System.EventArgs e)
		{
			
		}
		
		private void Init()
		{
			
		}
	}
	
}
