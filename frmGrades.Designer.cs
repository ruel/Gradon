namespace Gradon
{
    partial class frmGrades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrades));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMg = new System.Windows.Forms.TextBox();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.txtSfe = new System.Windows.Forms.TextBox();
            this.txtFe = new System.Windows.Forms.TextBox();
            this.txtFg = new System.Windows.Forms.TextBox();
            this.txtEq = new System.Windows.Forms.TextBox();
            this.cbMark = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkMark = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Midterm Grade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Class Standing:";
            // 
            // txtMg
            // 
            this.txtMg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMg.Location = new System.Drawing.Point(137, 26);
            this.txtMg.Name = "txtMg";
            this.txtMg.Size = new System.Drawing.Size(100, 23);
            this.txtMg.TabIndex = 1;
            this.txtMg.Text = "--";
            this.txtMg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMg.TextChanged += new System.EventHandler(this.txtMg_TextChanged);
            // 
            // txtCp
            // 
            this.txtCp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCp.Location = new System.Drawing.Point(137, 55);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(100, 23);
            this.txtCp.TabIndex = 2;
            this.txtCp.Text = "--";
            this.txtCp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCp.TextChanged += new System.EventHandler(this.txtCp_TextChanged);
            // 
            // txtSfe
            // 
            this.txtSfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSfe.Location = new System.Drawing.Point(137, 84);
            this.txtSfe.Name = "txtSfe";
            this.txtSfe.Size = new System.Drawing.Size(100, 23);
            this.txtSfe.TabIndex = 3;
            this.txtSfe.Text = "--";
            this.txtSfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSfe.TextChanged += new System.EventHandler(this.txtSfe_TextChanged);
            // 
            // txtFe
            // 
            this.txtFe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFe.Location = new System.Drawing.Point(137, 113);
            this.txtFe.Name = "txtFe";
            this.txtFe.Size = new System.Drawing.Size(100, 23);
            this.txtFe.TabIndex = 4;
            this.txtFe.Text = "--";
            this.txtFe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFe.TextChanged += new System.EventHandler(this.txtFe_TextChanged);
            // 
            // txtFg
            // 
            this.txtFg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFg.Location = new System.Drawing.Point(137, 142);
            this.txtFg.Name = "txtFg";
            this.txtFg.ReadOnly = true;
            this.txtFg.Size = new System.Drawing.Size(100, 23);
            this.txtFg.TabIndex = 5;
            this.txtFg.Text = "--";
            this.txtFg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEq
            // 
            this.txtEq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEq.Location = new System.Drawing.Point(137, 171);
            this.txtEq.Name = "txtEq";
            this.txtEq.ReadOnly = true;
            this.txtEq.Size = new System.Drawing.Size(100, 23);
            this.txtEq.TabIndex = 6;
            this.txtEq.Text = "--";
            this.txtEq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbMark
            // 
            this.cbMark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMark.Enabled = false;
            this.cbMark.FormattingEnabled = true;
            this.cbMark.Items.AddRange(new object[] {
            "DRP",
            "UD",
            "INC",
            "N/A"});
            this.cbMark.Location = new System.Drawing.Point(137, 227);
            this.cbMark.Name = "cbMark";
            this.cbMark.Size = new System.Drawing.Size(100, 24);
            this.cbMark.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Semi-Final Exam:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Final Exam:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Final Grade:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Equivalent:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mark as:";
            // 
            // chkMark
            // 
            this.chkMark.AutoSize = true;
            this.chkMark.Location = new System.Drawing.Point(52, 232);
            this.chkMark.Name = "chkMark";
            this.chkMark.Size = new System.Drawing.Size(15, 14);
            this.chkMark.TabIndex = 8;
            this.chkMark.UseVisualStyleBackColor = true;
            this.chkMark.CheckedChanged += new System.EventHandler(this.chkMark_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(148, 275);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 28);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 275);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 28);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmGrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(283, 316);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkMark);
            this.Controls.Add(this.cbMark);
            this.Controls.Add(this.txtEq);
            this.Controls.Add(this.txtFg);
            this.Controls.Add(this.txtFe);
            this.Controls.Add(this.txtSfe);
            this.Controls.Add(this.txtCp);
            this.Controls.Add(this.txtMg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmGrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grades";
            this.Load += new System.EventHandler(this.frmGrades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMg;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.TextBox txtSfe;
        private System.Windows.Forms.TextBox txtFe;
        private System.Windows.Forms.TextBox txtFg;
        private System.Windows.Forms.TextBox txtEq;
        private System.Windows.Forms.ComboBox cbMark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkMark;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
    }
}