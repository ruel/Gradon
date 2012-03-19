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
    public partial class frmInstructor : Form
    {
        string id;
        string classid;
        bool exflag = false;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
        List<ListViewItem> lvBackup = new List<ListViewItem>();
        public frmInstructor(string ins)
        {
            InitializeComponent();
            id = ins;
            mConn = new MySqlConnection(connStr);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInstructor_Load(object sender, EventArgs e)
        {
            cbSection.Items.Clear();
            Thread t1 = new Thread(u => init());
            t1.Start();
        }

        private void init()
        {
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("SELECT sections.section FROM sections INNER JOIN classes ON sections.secid = classes.secid WHERE classes.id = '" + id + "'", mConn);
            MySqlDataReader reader = mCmd.ExecuteReader();

            while (reader.Read())
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    cbSection.Items.Add(reader.GetString("section"));
                }));
            }
            reader.Close();
            

            MySqlCommand mCmd3 = new MySqlCommand("SELECT lastname, first FROM users WHERE id = '" + id + "'", mConn);
            reader = mCmd3.ExecuteReader();
            if (reader.Read())
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    lblLoggedIn.Text = "Logged in as: " + reader.GetString("first") + " " + reader.GetString("lastname");
                }));
            }
            mConn.Close();
        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvStud.Items.Clear();
            cbSubj.Items.Clear();

            Thread t1 = new Thread(u => loadSub());
            t1.Start();
        }

        private void loadSub()
        {
            mConn.Open();
            string cbs = "";
            this.Invoke(new MethodInvoker(delegate
            {
                cbs = cbSection.Text;
            }));
            MySqlCommand mCmd = new MySqlCommand("SELECT classes.classid, subjects.subcode FROM subjects INNER JOIN classes ON subjects.subid = classes.subid INNER JOIN sections ON sections.secid = classes.secid WHERE classes.id = '" + id + "' AND sections.section = '" + cbs + "'", mConn);
            MySqlDataReader reader = mCmd.ExecuteReader();
            while (reader.Read())
            {
                classid = reader.GetString("classid");
                this.Invoke(new MethodInvoker(delegate
                {
                    cbSubj.Items.Add(reader.GetString("subcode"));
                }));
            }
            mConn.Close();
        }

        private void loadStud()
        {
            mConn.Open();
            this.Invoke(new MethodInvoker(delegate
            {
                lvStud.Items.Clear();
            }));
            MySqlCommand mCmd = new MySqlCommand("SELECT users.id, users.lastname, users.first, users.email, users.contact FROM users INNER JOIN students ON students.id = users.id WHERE type = 'student' AND students.classid = '" + classid + "' ORDER BY lastname ASC", mConn);
            MySqlDataReader mReader = mCmd.ExecuteReader();
            while (mReader.Read())
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    lvStud.Items.Add(mReader.GetString("id")).SubItems.AddRange(new string[] { mReader.GetString("lastname"), mReader.GetString("first"), mReader.GetString("email"), mReader.GetString("contact") });
                }));
            }
            mConn.Close();

            this.Invoke(new MethodInvoker(delegate
            {
                foreach (ListViewItem lv in lvStud.Items)
                {
                    lvBackup.Add(lv);
                }
            }));
        }

        private void cbSubj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSection.Text == "" && cbSubj.Text == "")
            {
                btnAddS.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                return;
            }

            btnAddS.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;

            Thread t1 = new Thread(u => loadStud());
            t1.Start();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManClass ms = new frmManClass(id);
            ms.ShowDialog();

            lvStud.Items.Clear();
            cbSection.Items.Clear();
            cbSubj.Items.Clear();
            Thread t1 = new Thread(u => init());
            t1.Start();
        }

        private void btnAddS_Click(object sender, EventArgs e)
        {
            frmAddStud fas = new frmAddStud(classid);
            fas.ShowDialog();

            lvStud.Items.Clear();
            Thread t1 = new Thread(u => loadStud());
            t1.Start();
        }

        private void search(int index)
        {
            List<ListViewItem> lvs = new List<ListViewItem>();
            foreach (ListViewItem it in lvBackup)
            {
                lvs.Add(it);
            }
            lvStud.Items.Clear();
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
                lvStud.Items.Add(it);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            search(cbFilter.SelectedIndex);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            search(cbFilter.SelectedIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(t => doDel());
            t1.Start();
        }

        private void doDel()
        {
            int c = 0;
            this.Invoke(new MethodInvoker(delegate
            {
                c = lvStud.SelectedItems.Count;
            }));

            if (c > 0)
            {
                string rtext = "";
                this.Invoke(new MethodInvoker(delegate
                {
                    rtext = lvStud.SelectedItems[0].Text;
                }));
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    mConn.Open();
                    MySqlCommand mCmd = new MySqlCommand("DELETE FROM students WHERE id = '" + rtext + "' AND classid = '" + classid + "'", mConn);
                    MySqlCommand mCmdG = new MySqlCommand("DELETE FROM grades WHERE id = '" + rtext + "' AND classid = '" + classid + "'", mConn);
                    mCmdG.ExecuteNonQuery();
                    if (mCmd.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("An error has occured during the query. Please contact the administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvStud.Items.Clear();
                        }));
                        Thread t1 = new Thread(u => loadStud());
                        t1.Start();
                    }
                    mConn.Close();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvStud.SelectedItems.Count > 0)
            {
                frmGrades fg = new frmGrades(lvStud.SelectedItems[0].Text, classid);
                fg.ShowDialog();
            }
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser fu = new frmUser("edit", "instructor", id);
            fu.ShowDialog();
        }

        private void frmInstructor_FormClosing(object sender, FormClosingEventArgs e)
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
