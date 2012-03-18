namespace Gradon
{
    partial class frmAddClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddClass));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.llAddSec = new System.Windows.Forms.LinkLabel();
            this.llAddSub = new System.Windows.Forms.LinkLabel();
            this.cbSub = new System.Windows.Forms.ComboBox();
            this.cbSec = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sections:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(209, 135);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(89, 135);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // llAddSec
            // 
            this.llAddSec.AutoSize = true;
            this.llAddSec.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddSec.LinkColor = System.Drawing.Color.Silver;
            this.llAddSec.Location = new System.Drawing.Point(92, 98);
            this.llAddSec.Name = "llAddSec";
            this.llAddSec.Size = new System.Drawing.Size(64, 13);
            this.llAddSec.TabIndex = 10;
            this.llAddSec.TabStop = true;
            this.llAddSec.Text = "Add Section";
            this.llAddSec.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddSec_LinkClicked);
            // 
            // llAddSub
            // 
            this.llAddSub.AutoSize = true;
            this.llAddSub.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddSub.LinkColor = System.Drawing.Color.Silver;
            this.llAddSub.Location = new System.Drawing.Point(91, 46);
            this.llAddSub.Name = "llAddSub";
            this.llAddSub.Size = new System.Drawing.Size(65, 13);
            this.llAddSub.TabIndex = 10;
            this.llAddSub.TabStop = true;
            this.llAddSub.Text = "Add Subject";
            this.llAddSub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddSub_LinkClicked);
            // 
            // cbSub
            // 
            this.cbSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSub.FormattingEnabled = true;
            this.cbSub.Location = new System.Drawing.Point(161, 25);
            this.cbSub.Name = "cbSub";
            this.cbSub.Size = new System.Drawing.Size(183, 24);
            this.cbSub.TabIndex = 11;
            // 
            // cbSec
            // 
            this.cbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSec.FormattingEnabled = true;
            this.cbSec.Location = new System.Drawing.Point(161, 78);
            this.cbSec.Name = "cbSec";
            this.cbSec.Size = new System.Drawing.Size(183, 24);
            this.cbSec.TabIndex = 11;
            // 
            // frmAddClass
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 190);
            this.Controls.Add(this.cbSec);
            this.Controls.Add(this.cbSub);
            this.Controls.Add(this.llAddSub);
            this.Controls.Add(this.llAddSec);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmAddClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Management";
            this.Load += new System.EventHandler(this.frmAddClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel llAddSec;
        private System.Windows.Forms.LinkLabel llAddSub;
        private System.Windows.Forms.ComboBox cbSub;
        private System.Windows.Forms.ComboBox cbSec;
    }
}