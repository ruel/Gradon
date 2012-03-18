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
    public partial class frmManClass : Form
    {
        string id;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;

        public frmManClass(string i)
        {
            InitializeComponent();
            id = i;
            mConn = new MySqlConnection(connStr);
        }

        private void frmManSub_Load(object sender, EventArgs e)
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
            MySqlCommand mCmd = new MySqlCommand("SELECT classes.classid, subjects.subcode, sections.section FROM subjects INNER JOIN classes ON subjects.subid = classes.subid INNER JOIN sections ON sections.secid = classes.secid  WHERE classes.id = '" + id + "'", mConn);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddClass fac = new frmAddClass("add", id);
            fac.ShowDialog();
            Thread t1 = new Thread(i => loadSub());
            t1.Start();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lbSub.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this class?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Thread t1 = new Thread(t => doDel());
                    t1.Start();
                }
            }
        }

        private void doDel()
        {
            string cid = "";
            this.Invoke(new MethodInvoker(delegate
            {
                cid = (lbSub.SelectedItem as ListItem).Value.ToString();
            }));
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("DELETE FROM classes WHERE classid ='" + cid + "'", mConn);
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
            MessageBox.Show("Class deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Thread t1 = new Thread(i => loadSub());
            t1.Start();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (lbSub.SelectedItems.Count > 0)
            {
                
            }
        }
    }
    public class ListItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
