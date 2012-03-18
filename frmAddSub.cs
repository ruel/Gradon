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
    public partial class frmAddSub : Form
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;

        public frmAddSub()
        {
            InitializeComponent();
            mConn = new MySqlConnection(connStr);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtDesc.Text == "")
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
            MySqlCommand mCmd = new MySqlCommand("INSERT INTO subjects (subcode, subdesc) VALUES ('" + MySqlHelper.EscapeString(txtCode.Text) + "', '" + MySqlHelper.EscapeString(txtDesc.Text) + "')", mConn);
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
            MessageBox.Show("Subject added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Invoke(new MethodInvoker(delegate
            {
                this.Close();
            }));
        }
    }
}
