using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Gradon
{
	public partial class frmAdmin
	{
        bool exflag = false;
		private string id;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
        List<ListViewItem> lvBackup = new List<ListViewItem>();
		public frmAdmin(string user)
		{
			InitializeComponent();
			id = user;
            mConn = new MySqlConnection(connStr);
		}
		public void frmAdmin_Load(System.Object sender, System.EventArgs e)
		{
            cbFilter.SelectedIndex = 0;
            Thread t1 = new Thread(u => Init());
            t1.Start();
		}
		
		private void Init()
		{
            this.Invoke(new MethodInvoker(delegate
            {
                lvTeachers.Items.Clear();
            }));

            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("SELECT id, lastname, first, email, contact FROM users WHERE type = 'instructor' ORDER BY lastname ASC", mConn);
            MySqlDataReader mReader = mCmd.ExecuteReader();
            while (mReader.Read())
            {
                this.Invoke(new MethodInvoker(delegate 
                {
                    lvTeachers.Items.Add(mReader.GetString("id")).SubItems.AddRange(new string[] { mReader.GetString("lastname"), mReader.GetString("first"), mReader.GetString("email"), mReader.GetString("contact") });
                }));
            }
            mConn.Close();

            this.Invoke(new MethodInvoker(delegate
            {
                foreach (ListViewItem lv in lvTeachers.Items)
                {
                    lvBackup.Add(lv);
                }
            }));
		}

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            search(cbFilter.SelectedIndex);
        }

        private void search(int index)
        {
            List<ListViewItem> lvs = new List<ListViewItem>();
            foreach (ListViewItem it in lvBackup)
            {
                lvs.Add(it);
            }
            lvTeachers.Items.Clear();
            string regStr = Regex.Escape(txtFilter.Text);
            switch (index)
            {
                case 0:
                    foreach (ListViewItem it in lvBackup)
                    {
                        if (!Regex.IsMatch(it.Text, regStr, RegexOptions.IgnoreCase))
                        {
                            lvs.Remove(it);
                        }
                    }
                    break;
                case 1:
                    foreach (ListViewItem it in lvBackup)
                    {
                        if (!Regex.IsMatch(it.SubItems[index].Text, regStr, RegexOptions.IgnoreCase))
                        {
                            lvs.Remove(it);
                        }
                    }
                    break;
                case 2:
                    foreach (ListViewItem it in lvBackup)
                    {
                        if (!Regex.IsMatch(it.SubItems[index].Text, regStr, RegexOptions.IgnoreCase))
                        {
                            lvs.Remove(it);
                        }
                    }
                    break;
                case 3:
                    foreach (ListViewItem it in lvBackup)
                    {
                        if (!Regex.IsMatch(it.SubItems[index].Text, regStr, RegexOptions.IgnoreCase))
                        {
                            lvs.Remove(it);
                        }
                    }
                    break;
                case 4:
                    foreach (ListViewItem it in lvBackup)
                    {
                        if (!Regex.IsMatch(it.SubItems[index].Text, regStr, RegexOptions.IgnoreCase))
                        {
                            lvs.Remove(it);
                        }
                    }
                    break;
            }
            foreach (ListViewItem it in lvs)
            {
                lvTeachers.Items.Add(it);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            search(cbFilter.SelectedIndex);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmUser fni = new frmUser("new", "instructor");
            fni.ShowDialog(this);
            Thread t1 = new Thread(u => Init());
            t1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvTeachers.SelectedItems.Count > 0)
            {
                frmUser fni = new frmUser("edit", "instructor", lvTeachers.SelectedItems[0].Text);
                fni.ShowDialog(this);
                Thread t1 = new Thread(u => Init());
                t1.Start();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(u => delDb());
            t1.Start();
        }

        private void delDb()
        {
            int c = 0;
            this.Invoke(new MethodInvoker(delegate
            {
                c = lvTeachers.SelectedItems.Count;
            }));
            
            if (c > 0)
            {
                string rtext = "";
                this.Invoke(new MethodInvoker(delegate
                {
                    rtext = lvTeachers.SelectedItems[0].Text;
                }));
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    mConn.Open();
                    MySqlCommand mCmd = new MySqlCommand("DELETE FROM users WHERE id = '" + rtext + "'", mConn);
                    if (mCmd.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("An error has occured during the query. Please contact the administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvTeachers.Items.Remove(lvTeachers.SelectedItems[0]);
                        }));
                        Thread t1 = new Thread(u => Init());
                        t1.Start();
                    }
                    mConn.Close();
                }
            }
        }
        
        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exflag)
            {
                e.Cancel = false;
            }
            else if (MessageBox.Show("This will log you out, do you want to continue?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
                frmLogin lg = new frmLogin();
                lg.Show();
                exflag = true;
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }
	}
	
}
