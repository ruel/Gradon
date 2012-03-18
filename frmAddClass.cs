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
    public partial class frmAddClass : Form
    {
        string mode;
        string id;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
        
        public frmAddClass(string m, string i)
        {
            InitializeComponent();
            mode = m;
            id = i;
            mConn = new MySqlConnection(connStr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbSec.Text == "" || cbSub.Text == "")
            {
                MessageBox.Show("Please complete the form", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Thread t1 = new Thread(i => doSave());
            t1.Start();
        }

        private void doSave()
        {
            mConn.Open();
            string subid = "", secid = "";
            this.Invoke(new MethodInvoker(delegate
            {
                subid = MySqlHelper.EscapeString((cbSub.SelectedItem as ComboboxItem).Value.ToString());
                secid = MySqlHelper.EscapeString((cbSec.SelectedItem as ComboboxItem).Value.ToString());
            }));
            MySqlCommand mCmd = new MySqlCommand("INSERT INTO classes (id, subid, secid) VALUES ('" + MySqlHelper.EscapeString(id) + "', '" + subid + "', '" + secid + "')", mConn);
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
            MessageBox.Show("Class added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Invoke(new MethodInvoker(delegate
            {
                this.Close();
            }));
        }

        private void llAddSub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddSub fas = new frmAddSub();
            fas.ShowDialog();
            Thread t1 = new Thread(i => doLoad());
            t1.Start();
        }

        private void llAddSec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddSec fas = new frmAddSec();
            fas.ShowDialog();
            Thread t1 = new Thread(i => doLoad());
            t1.Start();
        }

        private void frmAddClass_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(i => doLoad());
            t1.Start();
        }

        private void doLoad()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                cbSec.Items.Clear();
            }));
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("SELECT secid, section FROM sections", mConn);
            MySqlDataReader reader = mCmd.ExecuteReader();

            while (reader.Read())
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = reader.GetString("section");
                cbi.Value = reader.GetString("secid");
                this.Invoke(new MethodInvoker(delegate
                {
                    cbSec.Items.Add(cbi);
                }));
            }

            reader.Close();

            this.Invoke(new MethodInvoker(delegate
            {
                cbSub.Items.Clear();
            }));
            mCmd = new MySqlCommand("SELECT subid, subcode FROM subjects", mConn);
            reader = mCmd.ExecuteReader();

            while (reader.Read())
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = reader.GetString("subcode");
                cbi.Value = reader.GetString("subid");
                this.Invoke(new MethodInvoker(delegate
                {
                    cbSub.Items.Add(cbi);
                }));
            }

            mConn.Close();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
