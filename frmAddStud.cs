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
using System.Text.RegularExpressions;

namespace Gradon
{
    public partial class frmAddStud : Form
    {
        string classid;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
        List<string> ids = new List<string>();
        public frmAddStud(string cid)
        {
            InitializeComponent();
            classid = cid;
            mConn = new MySqlConnection(connStr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ids = new List<string>();
            MatchCollection mc = Regex.Matches(txtIds.Text, @"(\d{8})");
            foreach (Match m in mc)
            {
                ids.Add(m.Groups[1].Value);
            }
            Thread t1 = new Thread(o => doAdd());
            t1.Start();
        }

        private void doAdd()
        {
            int i = 0;
            mConn.Open();
            foreach (string id in ids)
            {
                MySqlCommand mCmd = new MySqlCommand("INSERT INTO students (id, classid) VALUES ((SELECT id FROM users WHERE id = '" + id + "'), '" + classid + "')", mConn);
                try
                {
                    i = mCmd.ExecuteNonQuery();
                }
                catch
                {
                    continue;
                }
            }
            mConn.Close();
            MessageBox.Show(i.ToString() + " students added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Invoke(new MethodInvoker(delegate
            {
                this.Close();
            }));
        }
    }
}
