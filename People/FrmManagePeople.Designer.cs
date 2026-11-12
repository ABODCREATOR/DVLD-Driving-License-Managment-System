namespace Driving_License_Management_System.People
{
    partial class FrmManagePeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManagePeople));
            this.lblrecordscount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPeople = new System.Windows.Forms.ComboBox();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.dgvListPeople = new System.Windows.Forms.DataGridView();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updatePersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddNewPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblrecordscount
            // 
            this.lblrecordscount.AutoSize = true;
            this.lblrecordscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecordscount.Location = new System.Drawing.Point(108, 97);
            this.lblrecordscount.Name = "lblrecordscount";
            this.lblrecordscount.Size = new System.Drawing.Size(21, 24);
            this.lblrecordscount.TabIndex = 17;
            this.lblrecordscount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Records : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(516, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Manage People";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Filter By";
            // 
            // cbPeople
            // 
            this.cbPeople.FormattingEnabled = true;
            this.cbPeople.Location = new System.Drawing.Point(95, 147);
            this.cbPeople.Name = "cbPeople";
            this.cbPeople.Size = new System.Drawing.Size(121, 21);
            this.cbPeople.TabIndex = 12;
            this.cbPeople.SelectedIndexChanged += new System.EventHandler(this.cbPeople_SelectedIndexChanged);
            // 
            // txtfilter
            // 
            this.txtfilter.Location = new System.Drawing.Point(222, 147);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(227, 20);
            this.txtfilter.TabIndex = 11;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            this.txtfilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfilter_KeyPress);
            // 
            // dgvListPeople
            // 
            this.dgvListPeople.AllowUserToAddRows = false;
            this.dgvListPeople.AllowUserToDeleteRows = false;
            this.dgvListPeople.AllowUserToOrderColumns = true;
            this.dgvListPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPeople.ContextMenuStrip = this.MenuStrip;
            this.dgvListPeople.Location = new System.Drawing.Point(12, 202);
            this.dgvListPeople.Name = "dgvListPeople";
            this.dgvListPeople.ReadOnly = true;
            this.dgvListPeople.Size = new System.Drawing.Size(1021, 458);
            this.dgvListPeople.TabIndex = 10;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatePersonToolStripMenuItem,
            this.deletePersonToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.phoneCallToolStripMenuItem,
            this.showPersonInfoToolStripMenuItem});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(244, 194);
            // 
            // updatePersonToolStripMenuItem
            // 
            this.updatePersonToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatePersonToolStripMenuItem.Image = global::Driving_License_Management_System.Properties.Resources.Edit_User_32;
            this.updatePersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updatePersonToolStripMenuItem.Name = "updatePersonToolStripMenuItem";
            this.updatePersonToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.updatePersonToolStripMenuItem.Text = "&Update Person";
            this.updatePersonToolStripMenuItem.Click += new System.EventHandler(this.updatePersonToolStripMenuItem_Click);
            // 
            // deletePersonToolStripMenuItem
            // 
            this.deletePersonToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePersonToolStripMenuItem.Image = global::Driving_License_Management_System.Properties.Resources.Delete_User_32;
            this.deletePersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deletePersonToolStripMenuItem.Name = "deletePersonToolStripMenuItem";
            this.deletePersonToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.deletePersonToolStripMenuItem.Text = "&Delete Person";
            this.deletePersonToolStripMenuItem.Click += new System.EventHandler(this.deletePersonToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.sendEmailToolStripMenuItem.Image = global::Driving_License_Management_System.Properties.Resources.send_email_32;
            this.sendEmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.sendEmailToolStripMenuItem.Text = "&Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.phoneCallToolStripMenuItem.Image = global::Driving_License_Management_System.Properties.Resources.call_32;
            this.phoneCallToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.phoneCallToolStripMenuItem.Text = "&Phone Call";
            this.phoneCallToolStripMenuItem.Click += new System.EventHandler(this.phoneCallToolStripMenuItem_Click);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            this.showPersonInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.showPersonInfoToolStripMenuItem.Image = global::Driving_License_Management_System.Properties.Resources.Person_32;
            this.showPersonInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            this.showPersonInfoToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.showPersonInfoToolStripMenuItem.Text = "&Show Person Info";
            this.showPersonInfoToolStripMenuItem.Click += new System.EventHandler(this.showPersonInfoToolStripMenuItem_Click);
            // 
            // btn_AddNewPerson
            // 
            this.btn_AddNewPerson.BackgroundImage = global::Driving_License_Management_System.Properties.Resources.Add_Person_72;
            this.btn_AddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AddNewPerson.Location = new System.Drawing.Point(937, 114);
            this.btn_AddNewPerson.Name = "btn_AddNewPerson";
            this.btn_AddNewPerson.Size = new System.Drawing.Size(96, 71);
            this.btn_AddNewPerson.TabIndex = 18;
            this.btn_AddNewPerson.UseVisualStyleBackColor = true;
            this.btn_AddNewPerson.Click += new System.EventHandler(this.btn_AddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Driving_License_Management_System.Properties.Resources.Manage_People1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(509, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 92);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FrmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 672);
            this.Controls.Add(this.btn_AddNewPerson);
            this.Controls.Add(this.lblrecordscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPeople);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.dgvListPeople);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmManagePeople";
            this.Text = "FrmManagePeople";
            this.Load += new System.EventHandler(this.FrmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AddNewPerson;
        private System.Windows.Forms.Label lblrecordscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPeople;
        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.DataGridView dgvListPeople;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem updatePersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonInfoToolStripMenuItem;
    }
}