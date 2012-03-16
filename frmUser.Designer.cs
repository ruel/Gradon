namespace Gradon
{
    partial class frmUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.gbAcc = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPass = new System.Windows.Forms.TextBox();
            this.gbPer = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.cbChp = new System.Windows.Forms.CheckBox();
            this.gbAcc.SuspendLayout();
            this.gbPer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Location = new System.Drawing.Point(150, 31);
            this.txtId.MaxLength = 8;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(249, 23);
            this.txtId.TabIndex = 0;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Location = new System.Drawing.Point(150, 60);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(249, 23);
            this.txtPass.TabIndex = 1;
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // gbAcc
            // 
            this.gbAcc.Controls.Add(this.cbChp);
            this.gbAcc.Controls.Add(this.label3);
            this.gbAcc.Controls.Add(this.label2);
            this.gbAcc.Controls.Add(this.label1);
            this.gbAcc.Controls.Add(this.txtCPass);
            this.gbAcc.Controls.Add(this.txtId);
            this.gbAcc.Controls.Add(this.txtPass);
            this.gbAcc.Location = new System.Drawing.Point(12, 12);
            this.gbAcc.Name = "gbAcc";
            this.gbAcc.Size = new System.Drawing.Size(435, 164);
            this.gbAcc.TabIndex = 2;
            this.gbAcc.TabStop = false;
            this.gbAcc.Text = "Account Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            // 
            // txtCPass
            // 
            this.txtCPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPass.Location = new System.Drawing.Point(150, 89);
            this.txtCPass.Name = "txtCPass";
            this.txtCPass.PasswordChar = '●';
            this.txtCPass.Size = new System.Drawing.Size(249, 23);
            this.txtCPass.TabIndex = 2;
            this.txtCPass.Leave += new System.EventHandler(this.txtCPass_Leave);
            // 
            // gbPer
            // 
            this.gbPer.Controls.Add(this.label7);
            this.gbPer.Controls.Add(this.label6);
            this.gbPer.Controls.Add(this.label5);
            this.gbPer.Controls.Add(this.label4);
            this.gbPer.Controls.Add(this.txtContact);
            this.gbPer.Controls.Add(this.txtEmail);
            this.gbPer.Controls.Add(this.txtLast);
            this.gbPer.Controls.Add(this.txtFirst);
            this.gbPer.Location = new System.Drawing.Point(12, 182);
            this.gbPer.Name = "gbPer";
            this.gbPer.Size = new System.Drawing.Size(435, 170);
            this.gbPer.TabIndex = 3;
            this.gbPer.TabStop = false;
            this.gbPer.Text = "Personal Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Contact:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "E-mail:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "First Name:";
            // 
            // txtContact
            // 
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Location = new System.Drawing.Point(150, 122);
            this.txtContact.MaxLength = 15;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(249, 23);
            this.txtContact.TabIndex = 3;
            this.txtContact.TextChanged += new System.EventHandler(this.txtContact_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(150, 93);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(249, 23);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtLast
            // 
            this.txtLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLast.Location = new System.Drawing.Point(150, 64);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(249, 23);
            this.txtLast.TabIndex = 1;
            // 
            // txtFirst
            // 
            this.txtFirst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirst.Location = new System.Drawing.Point(150, 35);
            this.txtFirst.MaxLength = 50;
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(249, 23);
            this.txtFirst.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(236, 376);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 376);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tt
            // 
            this.tt.IsBalloon = true;
            this.tt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tt.ToolTipTitle = "Invalid Input";
            // 
            // cbChp
            // 
            this.cbChp.AutoSize = true;
            this.cbChp.Enabled = false;
            this.cbChp.Location = new System.Drawing.Point(151, 125);
            this.cbChp.Name = "cbChp";
            this.cbChp.Size = new System.Drawing.Size(129, 20);
            this.cbChp.TabIndex = 4;
            this.cbChp.Text = "Change Password";
            this.cbChp.UseVisualStyleBackColor = true;
            this.cbChp.CheckedChanged += new System.EventHandler(this.cbChp_CheckedChanged);
            // 
            // frmUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 417);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPer);
            this.Controls.Add(this.gbAcc);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Control";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.gbAcc.ResumeLayout(false);
            this.gbAcc.PerformLayout();
            this.gbPer.ResumeLayout(false);
            this.gbPer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.GroupBox gbAcc;
        private System.Windows.Forms.TextBox txtCPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbPer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.CheckBox cbChp;
    }
}