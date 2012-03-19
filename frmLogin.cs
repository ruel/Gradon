using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Gradon
{
	public partial class frmLogin
	{

        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;


		public frmLogin()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;

            mConn = new MySqlConnection(connStr);
		}
		
#region Default Instance
		
		private static frmLogin defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static frmLogin Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmLogin();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		

		//gradonDataSet gds = new gradonDataSet();
		//gradonDataSet.usersDataTable users;
		//gradonDataSetTableAdapters.usersTableAdapter gDap = new gradonDataSetTableAdapters.usersTableAdapter();
		
		public void OK_Click(System.Object sender, System.EventArgs e)
		{
			
			if (txtUser.Text == "" && txtPass.Text == "")
			{
				MessageBox.Show("Please complete the fields", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			Thread tMain = new Thread(new System.Threading.ThreadStart(DoLogin));
			tMain.Start();
			DisableControls();
			
		}
		
		private void DisableControls()
		{
			foreach (Control con in this.Controls)
			{
				con.Enabled = false;
			}
		}
		
		private void EnableControls()
		{
			foreach (Control con in this.Controls)
			{
				con.Enabled = true;
			}
		}
		
		private void DoLogin()
		{
			string md5;
            mConn.Open();
			md5 = GenerateMD5Hash(txtPass.Text);
            MySqlCommand mCmd = new MySqlCommand("SELECT type FROM users WHERE id = \'" + MySqlHelper.EscapeString(txtUser.Text) + "\' AND password = \'" + md5 + "\'", mConn);
            MySqlDataReader mReader = mCmd.ExecuteReader();

			if (!mReader.Read())
			{
				MessageBox.Show("Invalid ID or password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mConn.Close();
                this.Invoke(new MethodInvoker(EnableControls));
				return;
			}

			string type = mReader.GetString("type");
            mConn.Close();
			this.Invoke(new MethodInvoker(delegate
			{
				switch (type)
				{
					case "admin":
						frmAdmin adFrm = new frmAdmin(txtUser.Text);
						adFrm.Show();
                        break;
                    case "instructor":
                        frmInstructor inFrm = new frmInstructor(txtUser.Text);
                        inFrm.Show();
                        break;
                    case "student":
                        frmStudent fs = new frmStudent(txtUser.Text);
                        fs.Show();
                        break;
				}
				
				this.Close();
			}
			));
		}
		
		public void Cancel_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		private string GenerateMD5Hash(string SourceText)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			byte[] bytesStr = Encoding.ASCII.GetBytes(SourceText);
			string @out = "";
			
			bytesStr = md5.ComputeHash(bytesStr);
			
			foreach (byte chr in bytesStr)
			{
				@out += chr.ToString("x2");
			}
			
			return @out;
		}

        private void llReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUser fni = new frmUser("new", "student");
            fni.ShowDialog(this);
        }
		
	}
	
}
