namespace Driving_License_Management_System.People
{
    partial class ShowPersonCard
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
            this.ctrlPersonCardInfo1 = new Driving_License_Management_System.People.ctrlPersonCardInfo();
            this.SuspendLayout();
            // 
            // ctrlPersonCardInfo1
            // 
            this.ctrlPersonCardInfo1.Location = new System.Drawing.Point(46, 36);
            this.ctrlPersonCardInfo1.Name = "ctrlPersonCardInfo1";
            this.ctrlPersonCardInfo1.Size = new System.Drawing.Size(1071, 353);
            this.ctrlPersonCardInfo1.TabIndex = 0;
            // 
            // ShowPersonCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 548);
            this.Controls.Add(this.ctrlPersonCardInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowPersonCard";
            this.Text = "ShowPersonCard";
            this.Load += new System.EventHandler(this.ShowPersonCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCardInfo ctrlPersonCardInfo1;
    }
}