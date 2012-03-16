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
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
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
            Thread t1 = new Thread(u => init());
            t1.Start();
        }

        private void init()
        {
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("SELECT shortname FROM course", mConn);
            MySqlDataReader reader = mCmd.ExecuteReader();

            this.Invoke(new MethodInvoker(delegate
            {
                cbCourse.Items.Clear();
                cbSubj.Items.Clear();
            }));

            while (reader.Read())
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    cbCourse.Items.Add(reader.GetString("shortname"));
                }));
            }
            reader.Close();
            mCmd = new MySqlCommand("SELECT code FROM subject", mConn);
            reader = mCmd.ExecuteReader();
            while (reader.Read())
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    cbSubj.Items.Add(reader.GetString("code"));
                }));
            }

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
            if (cbCourse.SelectedText == "" && cbSubj.SelectedText == "")
            {
                return;
            }

            Thread t1 = new Thread(u => loadStud());
            t1.Start();
        }

        private void loadStud()
        {
            
        }

        private void cbSubj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCourse.SelectedText == "" && cbSubj.SelectedText == "")
            {
                return;
            }

            Thread t1 = new Thread(u => loadStud());
            t1.Start();
        }

    }
}
