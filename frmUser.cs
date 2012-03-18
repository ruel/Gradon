using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Gradon
{
    public partial class frmUser : Form
    {
        string id, m, type;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;
        bool valid = true;

        public frmUser(string mode, string t, string sid = "")
        {
            InitializeComponent();
            mConn = new MySqlConnection(connStr);
            id = sid;
            m = mode;
            type = t;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    Int32.Parse(txtId.Text);
                    valid = true;
                }
                catch
                {
                    tt.Show("This field must have numeric numbers only", txtId, 2000);
                    string newStr = txtId.Text.Substring(0, txtId.TextLength - 1);
                    txtId.Text = newStr;
                    txtId.Select(txtId.TextLength, 0);
                    valid = false;
                }
            }
        }

        private void checkPass()
        {
            if (txtPass.Text != "" && txtCPass.Text != "")
            {
                if (txtPass.Text != txtCPass.Text)
                {
                    tt.Show("Passwords must match", txtPass, 2000);
                    valid = false;
                }
                else
                {
                    valid = true;
                }
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (txtContact.Text != "")
            {
                try
                {
                    Double.Parse(txtContact.Text);
                    valid = true;
                }
                catch
                {
                    tt.Show("This field must have numeric numbers only", txtContact, 2000);
                    string newStr = txtContact.Text.Substring(0, txtContact.TextLength - 1);
                    txtContact.Text = newStr;
                    txtContact.Select(txtContact.TextLength, 0);
                    valid = false;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<Control> css = new List<Control>();
            foreach (Control c in gbAcc.Controls)
            {
                if (c.Enabled)
                {
                    css.Add(c);
                }
            }

            foreach (Control c in gbPer.Controls)
            {
                css.Add(c);
            }

            foreach (Control cs in css)
            {
                if (cs is TextBox)
                {
                    if (cs.Text == "")
                    {
                        valid = false;
                    }
                }
            }

            if (!valid)
            {
                MessageBox.Show("Please complete and validate all fields.", "Complete and Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m == "new")
            {
                Thread t1 = new Thread(u => doAdd());
                t1.Start();
            }
            else
            {
                Thread t1 = new Thread(u => doEdit());
                t1.Start();
            }
            DisableControls();
        }

        private void doEdit()
        {
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand();
            if (cbChp.Checked)
            {
                mCmd = new MySqlCommand("UPDATE users SET id = '" + MySqlHelper.EscapeString(txtId.Text) + "', password = '" + GenerateMD5Hash(txtPass.Text) + "', lastname = '" + MySqlHelper.EscapeString(txtLast.Text) + "', first = '" + MySqlHelper.EscapeString(txtFirst.Text) + "', email = '" + MySqlHelper.EscapeString(txtEmail.Text) + "', contact = '" + MySqlHelper.EscapeString(txtContact.Text) + "' WHERE id = '" + id + "'", mConn);
            }
            else
            {
                mCmd = new MySqlCommand("UPDATE users SET id = '" + MySqlHelper.EscapeString(txtId.Text) + "', lastname = '" + MySqlHelper.EscapeString(txtLast.Text) + "', first = '" + MySqlHelper.EscapeString(txtFirst.Text) + "', email = '" + MySqlHelper.EscapeString(txtEmail.Text) + "', contact = '" + MySqlHelper.EscapeString(txtContact.Text) + "' WHERE id = '" + id + "'", mConn);
            }
            if (mCmd.ExecuteNonQuery() < 1)
            {
                MessageBox.Show("An error has occured during the query. Please contact the administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Invoke(new MethodInvoker(EnableControls));
                mConn.Close();
            }
            else
            {
                MessageBox.Show("Successfully edited user!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(new MethodInvoker(this.Close));
                mConn.Close();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtEmail.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                valid = true;
            }
            else
            {
                tt.Show("E-mail address invalid", txtEmail, 2000);
                valid = false;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (m == "mode")
            {
                if (cbChp.Checked)
                {
                    checkPass();
                }
            }
            else
            {
                checkPass();
            }
            
        }

        private void txtCPass_Leave(object sender, EventArgs e)
        {
            if (m == "mode")
            {
                if (cbChp.Checked)
                {
                    checkPass();
                }
            }
            else
            {
                checkPass();
            }
        }

        private void doAdd()
        {
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("INSERT INTO users (id, password, type, lastname, first, email, contact) VALUES ('" + MySqlHelper.EscapeString(txtId.Text) + "', '" + GenerateMD5Hash(txtPass.Text) + "', '" + type + "', '" + MySqlHelper.EscapeString(txtLast.Text) + "', '" + MySqlHelper.EscapeString(txtFirst.Text) + "', '" + MySqlHelper.EscapeString(txtEmail.Text) + "', '" + MySqlHelper.EscapeString(txtContact.Text) + "')", mConn);
            if (mCmd.ExecuteNonQuery() < 1)
            {
                MessageBox.Show("An error has occured during the query. Please contact the administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Invoke(new MethodInvoker(EnableControls));
                mConn.Close();
            }
            else
            {
                MessageBox.Show("Successfully added user!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(new MethodInvoker(this.Close));
                mConn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void frmUser_Load(object sender, EventArgs e)
        {
            if (m == "edit")
            {
                cbChp.Enabled = true;
                txtId.Enabled = false;
                txtPass.Enabled = false;
                txtCPass.Enabled = false;
                Thread t1 = new Thread(i => init());
                t1.Start();
            }
        }

        private void init()
        {
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("SELECT lastname, first, email, contact FROM users WHERE id = '" + id + "'", mConn);
            MySqlDataReader reader = mCmd.ExecuteReader();
            if (reader.Read())
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    txtId.Text = id;
                    txtLast.Text = reader.GetString("lastname");
                    txtFirst.Text = reader.GetString("first");
                    txtEmail.Text = reader.GetString("email");
                    txtContact.Text = reader.GetString("contact");
                }));
            }
            mConn.Close();
        }

        private void cbChp_CheckedChanged(object sender, EventArgs e)
        {
            txtCPass.Enabled = cbChp.Checked;
            txtPass.Enabled = cbChp.Checked;
        }
    }
}
