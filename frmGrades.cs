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
    public partial class frmGrades : Form
    {
        string id, classid;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Gradon.My.MySettings.gradonConnectionString"].ConnectionString;
        MySqlConnection mConn;

        public frmGrades(string i, string cid)
        {
            InitializeComponent();
            mConn = new MySqlConnection(connStr);
            id = i;
            classid = cid;
        }

        private void chkMark_CheckedChanged(object sender, EventArgs e)
        {
            cbMark.Enabled = chkMark.Checked;
        }

        private void frmGrades_Load(object sender, EventArgs e)
        {
            cbMark.Text = "N/A";
            Thread t1 = new Thread(n => init());
            t1.Start();
        }

        private void init()
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

                    if (reader.GetString("remark") == "N/A")
                    {
                        chkMark.Checked = false;
                    }
                    else
                    {
                        chkMark.Checked = true;
                        cbMark.Text = reader.GetString("remark");
                    }
                }));
            }
            mConn.Close();
        }

        private void txtMg_TextChanged(object sender, EventArgs e)
        {
            tComp();
        }

        private void tComp()
        {
            if (txtMg.Text == "--" || txtCp.Text == "--" || txtSfe.Text == "--" || txtFe.Text == "--")
            {
                return;
            }

            int mg, cp, sfe, fe;
            Int32.TryParse(txtMg.Text, out mg);
            Int32.TryParse(txtCp.Text, out cp);
            Int32.TryParse(txtSfe.Text, out sfe);
            Int32.TryParse(txtFe.Text, out fe);

            int fg = (mg + cp + sfe + fe) / 4;
            txtFg.Text = fg.ToString();
            if (fg >= 98)
                txtEq.Text = "1.00";
            if (fg >= 95 && fg <= 97)
                txtEq.Text = "1.25";
            if (fg >= 92 && fg <= 94)
                txtEq.Text = "1.50";
            if (fg >= 89 && fg <= 91)
                txtEq.Text = "1.75";
            if (fg >= 86 && fg <= 88)
                txtEq.Text = "2.00";
            if (fg >= 83 && fg <= 85)
                txtEq.Text = "2.25";
            if (fg >= 80 && fg <= 82)
                txtEq.Text = "2.50";
            if (fg >= 77 && fg <= 79)
                txtEq.Text = "2.75";
            if (fg >= 75 && fg <= 76)
                txtEq.Text = "3.00";
            if (fg < 75)
                txtEq.Text = "5.00";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string mg = "", cp = "", sfe = "", fe = "", fg = "", fnum = "";
            if (txtMg.Text == "--")
                mg = "0";
            else
                mg = txtMg.Text;
            if (txtCp.Text == "--")
                cp = "0";
            else
                cp = txtCp.Text;
            if (txtSfe.Text == "--")
                sfe = "0";
            else
                sfe = txtSfe.Text;
            if (txtFe.Text == "--")
                fe = "0";
            else
                fe = txtFe.Text;
            if (txtFg.Text == "--")
                fg = "0";
            else
                fg = txtFg.Text;
            if (txtEq.Text == "--")
                fnum = "0";
            else
                fnum = txtEq.Text;

            Thread t1 = new Thread(y => upG(mg, cp, sfe, fe, fg, fnum));
            t1.Start();
        }

        private void upG(string mg, string cp, string sfe, string fe, string fg, string fnum)
        {
            string mm = "";
            this.Invoke(new MethodInvoker(delegate
            {
                mm = cbMark.Text;
            }));
            mConn.Open();
            MySqlCommand mCmd = new MySqlCommand("UPDATE grades SET mg = '" + mg + "', cp = '" + cp + "', sfe = '" + sfe + "', fe = '" + fe + "', fg = '" + fg + "', fnum = '" + fnum + "', remark = '" + mm + "' WHERE id = '" + id + "' AND classid = '" + classid + "'", mConn);
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
            MessageBox.Show("Grades updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Invoke(new MethodInvoker(delegate
            {
                this.Close();
            }));
        }

        private void txtCp_TextChanged(object sender, EventArgs e)
        {
            tComp();
        }

        private void txtSfe_TextChanged(object sender, EventArgs e)
        {
            tComp();
        }

        private void txtFe_TextChanged(object sender, EventArgs e)
        {
            tComp();
        }
    }
}
