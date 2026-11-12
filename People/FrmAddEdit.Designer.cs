namespace Driving_License_Management_System.People
{
    partial class FrmAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEdit));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblfirst = new System.Windows.Forms.Label();
            this.lblsecond = new System.Windows.Forms.Label();
            this.lblthird = new System.Windows.Forms.Label();
            this.lbllast = new System.Windows.Forms.Label();
            this.txtfirst = new System.Windows.Forms.TextBox();
            this.txtthird = new System.Windows.Forms.TextBox();
            this.txtsecond = new System.Windows.Forms.TextBox();
            this.txtlast = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtnationalno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.lblgender = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.lblphone = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.llremove = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblPersonID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(442, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Person";
            // 
            // lblfirst
            // 
            this.lblfirst.AutoSize = true;
            this.lblfirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfirst.Location = new System.Drawing.Point(48, 19);
            this.lblfirst.Name = "lblfirst";
            this.lblfirst.Size = new System.Drawing.Size(101, 18);
            this.lblfirst.TabIndex = 1;
            this.lblfirst.Text = "FirstName : ";
            // 
            // lblsecond
            // 
            this.lblsecond.AutoSize = true;
            this.lblsecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsecond.Location = new System.Drawing.Point(469, 75);
            this.lblsecond.Name = "lblsecond";
            this.lblsecond.Size = new System.Drawing.Size(124, 18);
            this.lblsecond.TabIndex = 2;
            this.lblsecond.Text = "SecondName : ";
            // 
            // lblthird
            // 
            this.lblthird.AutoSize = true;
            this.lblthird.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblthird.Location = new System.Drawing.Point(48, 68);
            this.lblthird.Name = "lblthird";
            this.lblthird.Size = new System.Drawing.Size(105, 18);
            this.lblthird.TabIndex = 3;
            this.lblthird.Text = "ThirdName : ";
            // 
            // lbllast
            // 
            this.lbllast.AutoSize = true;
            this.lbllast.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllast.Location = new System.Drawing.Point(469, 124);
            this.lbllast.Name = "lbllast";
            this.lbllast.Size = new System.Drawing.Size(99, 18);
            this.lbllast.TabIndex = 4;
            this.lbllast.Text = "LastName : ";
            // 
            // txtfirst
            // 
            this.txtfirst.Location = new System.Drawing.Point(201, 76);
            this.txtfirst.Name = "txtfirst";
            this.txtfirst.Size = new System.Drawing.Size(192, 20);
            this.txtfirst.TabIndex = 5;
            // 
            // txtthird
            // 
            this.txtthird.Location = new System.Drawing.Point(201, 125);
            this.txtthird.Name = "txtthird";
            this.txtthird.Size = new System.Drawing.Size(192, 20);
            this.txtthird.TabIndex = 6;
            // 
            // txtsecond
            // 
            this.txtsecond.Location = new System.Drawing.Point(596, 75);
            this.txtsecond.Name = "txtsecond";
            this.txtsecond.Size = new System.Drawing.Size(192, 20);
            this.txtsecond.TabIndex = 7;
            // 
            // txtlast
            // 
            this.txtlast.Location = new System.Drawing.Point(596, 122);
            this.txtlast.Name = "txtlast";
            this.txtlast.Size = new System.Drawing.Size(192, 20);
            this.txtlast.TabIndex = 8;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.Location = new System.Drawing.Point(48, 167);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(121, 18);
            this.lblDateOfBirth.TabIndex = 10;
            this.lblDateOfBirth.Text = "Date Of Birth : ";
            // 
            // txtnationalno
            // 
            this.txtnationalno.Location = new System.Drawing.Point(175, 113);
            this.txtnationalno.Name = "txtnationalno";
            this.txtnationalno.Size = new System.Drawing.Size(192, 20);
            this.txtnationalno.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "NationalNo : ";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.Location = new System.Drawing.Point(175, 159);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(318, 28);
            this.dtpDateOfBirth.TabIndex = 9;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(181, 11);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(98, 28);
            this.rbFemale.TabIndex = 13;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(33, 11);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(73, 28);
            this.rbMale.TabIndex = 14;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // lblgender
            // 
            this.lblgender.AutoSize = true;
            this.lblgender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgender.Location = new System.Drawing.Point(48, 230);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(78, 18);
            this.lblgender.TabIndex = 15;
            this.lblgender.Text = "Gender : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbFemale);
            this.panel1.Controls.Add(this.rbMale);
            this.panel1.Location = new System.Drawing.Point(201, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 52);
            this.panel1.TabIndex = 16;
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(596, 168);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(192, 20);
            this.txtphone.TabIndex = 18;
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblphone.Location = new System.Drawing.Point(469, 170);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(71, 18);
            this.lblphone.TabIndex = 17;
            this.lblphone.Text = "Phone : ";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(201, 345);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(234, 106);
            this.txtAddress.TabIndex = 20;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(48, 288);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(84, 18);
            this.lblAddress.TabIndex = 19;
            this.lblAddress.Text = "Address : ";
            // 
            // llSetImage
            // 
            this.llSetImage.AutoSize = true;
            this.llSetImage.Location = new System.Drawing.Point(819, 142);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(52, 13);
            this.llSetImage.TabIndex = 22;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "SetImage";
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked);
            // 
            // llremove
            // 
            this.llremove.AutoSize = true;
            this.llremove.Location = new System.Drawing.Point(921, 142);
            this.llremove.Name = "llremove";
            this.llremove.Size = new System.Drawing.Size(47, 13);
            this.llremove.TabIndex = 23;
            this.llremove.TabStop = true;
            this.llremove.Text = "Remove";
            this.llremove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llremove_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Controls.Add(this.txtemail);
            this.panel2.Controls.Add(this.lblemail);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbCountries);
            this.panel2.Controls.Add(this.btn_Add);
            this.panel2.Controls.Add(this.txtnationalno);
            this.panel2.Controls.Add(this.lblAddress);
            this.panel2.Controls.Add(this.llremove);
            this.panel2.Controls.Add(this.pbPersonImage);
            this.panel2.Controls.Add(this.llSetImage);
            this.panel2.Controls.Add(this.lblgender);
            this.panel2.Controls.Add(this.lblDateOfBirth);
            this.panel2.Controls.Add(this.dtpDateOfBirth);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblthird);
            this.panel2.Controls.Add(this.lblfirst);
            this.panel2.Location = new System.Drawing.Point(26, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 405);
            this.panel2.TabIndex = 24;
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(824, 271);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(144, 53);
            this.btn_Close.TabIndex = 28;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // txtemail
            // 
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(570, 289);
            this.txtemail.Multiline = true;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(234, 95);
            this.txtemail.TabIndex = 27;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.Location = new System.Drawing.Point(493, 289);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(60, 18);
            this.lblemail.TabIndex = 26;
            this.lblemail.Text = "Email :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(516, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Country : ";
            // 
            // cbCountries
            // 
            this.cbCountries.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(604, 160);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(177, 32);
            this.cbCountries.TabIndex = 25;
            this.cbCountries.SelectedIndexChanged += new System.EventHandler(this.cbCountries_SelectedIndexChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(822, 330);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(144, 53);
            this.btn_Add.TabIndex = 24;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImage = global::Driving_License_Management_System.Properties.Resources.Male_512;
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Location = new System.Drawing.Point(822, 18);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(146, 109);
            this.pbPersonImage.TabIndex = 21;
            this.pbPersonImage.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(139, 20);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(32, 24);
            this.lblPersonID.TabIndex = 25;
            this.lblPersonID.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "PersonID : ";
            // 
            // FrmAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 478);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.lblphone);
            this.Controls.Add(this.txtlast);
            this.Controls.Add(this.txtsecond);
            this.Controls.Add(this.txtthird);
            this.Controls.Add(this.txtfirst);
            this.Controls.Add(this.lbllast);
            this.Controls.Add(this.lblsecond);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddEdit";
            this.Text = "FrmAddEdit";
            this.Load += new System.EventHandler(this.FrmAddEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblfirst;
        private System.Windows.Forms.Label lblsecond;
        private System.Windows.Forms.Label lblthird;
        private System.Windows.Forms.Label lbllast;
        private System.Windows.Forms.TextBox txtfirst;
        private System.Windows.Forms.TextBox txtthird;
        private System.Windows.Forms.TextBox txtsecond;
        private System.Windows.Forms.TextBox txtlast;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtnationalno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label lblgender;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.LinkLabel llremove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Button btn_Close;
    }
}