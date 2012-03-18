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
    public partial class frmAddSec : Form
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
        public frmAddSec()
        {
            InitializeComponent();
            mConn = new MySqlConnection(connStr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSec.Text == "")
            {
                MessageBox.Show("Please complete the form", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Thread t1 = new Thread(i => doAdd());
            t1.Start();
        }

        private void doAdd()
        {
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("INSERT INTO sections (section) VALUES ('" + MySqlHelper.EscapeString(txtSec.Text) + "')", mConn);
            try
            {
                mCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mConn.Close();
                return;
            }
            mConn.Close();
            MessageBox.Show("Section added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Invoke(new MethodInvoker(delegate
            {
                this.Close();
            }));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
