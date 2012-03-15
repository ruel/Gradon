using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;

namespace Gradon
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmAdmin : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.lvTeachers = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chContact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvTeachers
            // 
            this.lvTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTeachers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chLastName,
            this.chFirstName,
            this.chEmail,
            this.chContact});
            this.lvTeachers.FullRowSelect = true;
            this.lvTeachers.GridLines = true;
            this.lvTeachers.Location = new System.Drawing.Point(12, 86);
            this.lvTeachers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvTeachers.Name = "lvTeachers";
            this.lvTeachers.Size = new System.Drawing.Size(984, 314);
            this.lvTeachers.TabIndex = 0;
            this.lvTeachers.UseCompatibleStateImageBehavior = false;
            this.lvTeachers.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "ID";
            this.chId.Width = 126;
            // 
            // chLastName
            // 
            this.chLastName.Text = "Last Name";
            this.chLastName.Width = 180;
            // 
            // chFirstName
            // 
            this.chFirstName.Text = "First Name";
            this.chFirstName.Width = 195;
            // 
            // chEmail
            // 
            this.chEmail.Text = "E-mail";
            this.chEmail.Width = 247;
            // 
            // chContact
            // 
            this.chContact.Text = "Contact";
            this.chContact.Width = 232;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Location = new System.Drawing.Point(60, 56);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(936, 23);
            this.txtFilter.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 58);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(42, 16);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Filter:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(15, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(981, 33);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Instructor Accounts";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 462);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lvTeachers);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1024, 500);
            this.Name = "frmAdmin";
            this.Text = "Gradon";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.ListView lvTeachers;
		internal System.Windows.Forms.ColumnHeader chId;
		internal System.Windows.Forms.ColumnHeader chLastName;
		internal System.Windows.Forms.ColumnHeader chFirstName;
		internal System.Windows.Forms.ColumnHeader chEmail;
		internal System.Windows.Forms.ColumnHeader chContact;
		internal System.Windows.Forms.TextBox txtFilter;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label lblTitle;
		
	}
	
}
