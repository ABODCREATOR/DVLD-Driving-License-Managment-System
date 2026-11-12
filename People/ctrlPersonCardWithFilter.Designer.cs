namespace Driving_License_Management_System.People
{
    partial class ctrlPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.ctrlPersonCardInfo1 = new Driving_License_Management_System.People.ctrlPersonCardInfo();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFind);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Controls.Add(this.txtFilter);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(27, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(724, 90);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Find Person ";
            // 
            // btnFind
            // 
            this.btnFind.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFind.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFind.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFind.FillColor2 = System.Drawing.Color.Silver;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Image = global::Driving_License_Management_System.Properties.Resources.Add_Person_72;
            this.btnFind.ImageSize = new System.Drawing.Size(35, 35);
            this.btnFind.Location = new System.Drawing.Point(651, 19);
            this.btnFind.Name = "btnFind";
            this.btnFind.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnFind.Size = new System.Drawing.Size(64, 66);
            this.btnFind.TabIndex = 2;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Location = new System.Drawing.Point(6, 39);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(168, 36);
            this.cbFilter.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.DefaultText = "";
            this.txtFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.Location = new System.Drawing.Point(180, 39);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderText = "The Text Format Should Match The Combo box \'s DataType Item";
            this.txtFilter.SelectedText = "";
            this.txtFilter.Size = new System.Drawing.Size(465, 36);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // ctrlPersonCardInfo1
            // 
            this.ctrlPersonCardInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlPersonCardInfo1.Location = new System.Drawing.Point(27, 99);
            this.ctrlPersonCardInfo1.Name = "ctrlPersonCardInfo1";
            this.ctrlPersonCardInfo1.Size = new System.Drawing.Size(724, 296);
            this.ctrlPersonCardInfo1.TabIndex = 1;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.ctrlPersonCardInfo1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(761, 403);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btnFind;
        private ctrlPersonCardInfo ctrlPersonCardInfo1;
        public System.Windows.Forms.GroupBox gbFilter;
    }
}
