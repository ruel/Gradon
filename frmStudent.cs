using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Gradon
{
    public partial class frmStudent : Form
    {
        string id;
        bool exflag = false;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
        public frmStudent(string i)
        {
            InitializeComponent();
            id = i;
            mConn = new MySqlConnection(connStr);
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(i => loadSub());
            t1.Start();
        }

        private void loadSub()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                lbSub.Items.Clear();
            }));
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("SELECT classes.classid, subjects.subcode, sections.section FROM subjects INNER JOIN classes ON subjects.subid = classes.subid INNER JOIN sections ON sections.secid = classes.secid INNER JOIN students ON students.classid = classes.classid WHERE students.id = '" + id + "'", mConn);
            MySqlDataReader reader = mCmd.ExecuteReader();
            while (reader.Read())
            {
                ListItem l = new ListItem();
                l.Text = reader.GetString("section") + " - " + reader.GetString("subcode");
                l.Value = reader.GetString("classid");
                this.Invoke(new MethodInvoker(delegate
                {
                    lbSub.Items.Add(l);
                }));
            }
            mConn.Close();
        }

        private void lbSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cid = (lbSub.SelectedItem as ListItem).Value.ToString();
            Thread t1 = new Thread(n => opG(cid));
            t1.Start();
        }

        private void opG(string classid)
        {
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("SELECT mg, cp, sfe, fe, fg, fnum, remark FROM grades WHERE id = '" + id + "' AND classid = '" + classid + "'", mConn);
            MySqlDataReader reader = mCmd.ExecuteReader();
            if (reader.Read())
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    if (reader.GetInt32("mg") == 0)
                    {
                        txtMg.Text = "--";
                    }
                    else
                    {
                        txtMg.Text = reader.GetInt32("mg").ToString();
                    }

                    if (reader.GetInt32("cp") == 0)
                    {
                        txtCp.Text = "--";
                    }
                    else
                    {
                        txtCp.Text = reader.GetInt32("cp").ToString();
                    }

                    if (reader.GetInt32("sfe") == 0)
                    {
                        txtSfe.Text = "--";
                    }
                    else
                    {
                        txtSfe.Text = reader.GetInt32("sfe").ToString();
                    }

                    if (reader.GetInt32("fe") == 0)
                    {
                        txtFe.Text = "--";
                    }
                    else
                    {
                        txtFe.Text = reader.GetInt32("fe").ToString();
                    }

                    if (reader.GetInt32("fg") == 0)
                    {
                        txtFg.Text = "--";
                    }
                    else
                    {
                        txtFg.Text = reader.GetInt32("fg").ToString();
                    }

                    if (reader.GetDouble("fnum") == 0)
                    {
                        txtEq.Text = "--";
                    }
                    else
                    {
                        txtEq.Text = reader.GetDouble("fnum").ToString();
                    }

                   
                    txtRem.Text = reader.GetString("remark");
                }));
            }
            mConn.Close();
        }

        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
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
