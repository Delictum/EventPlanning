namespace EventPlanning
{
    partial class Detail
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
            this.labelLastName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.labelSureName = new System.Windows.Forms.Label();
            this.textBoxSureName = new System.Windows.Forms.TextBox();
            this.groupBoxFullName = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.labelGroup = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.labelAdress = new System.Windows.Forms.Label();
            this.groupBoxFullName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(13, 26);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(56, 13);
            this.labelLastName.TabIndex = 0;
            this.labelLastName.Text = "Last name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First name";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(75, 23);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(100, 20);
            this.textBoxLastName.TabIndex = 2;
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Location = new System.Drawing.Point(74, 49);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstname.TabIndex = 3;
            // 
            // labelSureName
            // 
            this.labelSureName.AutoSize = true;
            this.labelSureName.Location = new System.Drawing.Point(13, 78);
            this.labelSureName.Name = "labelSureName";
            this.labelSureName.Size = new System.Drawing.Size(58, 13);
            this.labelSureName.TabIndex = 4;
            this.labelSureName.Text = "Sure name";
            // 
            // textBoxSureName
            // 
            this.textBoxSureName.Location = new System.Drawing.Point(74, 75);
            this.textBoxSureName.Name = "textBoxSureName";
            this.textBoxSureName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSureName.TabIndex = 5;
            // 
            // groupBoxFullName
            // 
            this.groupBoxFullName.Controls.Add(this.textBoxSureName);
            this.groupBoxFullName.Controls.Add(this.labelLastName);
            this.groupBoxFullName.Controls.Add(this.labelSureName);
            this.groupBoxFullName.Controls.Add(this.label2);
            this.groupBoxFullName.Controls.Add(this.textBoxFirstname);
            this.groupBoxFullName.Controls.Add(this.textBoxLastName);
            this.groupBoxFullName.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFullName.Name = "groupBoxFullName";
            this.groupBoxFullName.Size = new System.Drawing.Size(186, 117);
            this.groupBoxFullName.TabIndex = 6;
            this.groupBoxFullName.TabStop = false;
            this.groupBoxFullName.Text = "Full name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonFemale);
            this.groupBox1.Controls.Add(this.radioButtonMale);
            this.groupBox1.Location = new System.Drawing.Point(204, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 78);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gender floor";
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(16, 47);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFemale.TabIndex = 3;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Location = new System.Drawing.Point(16, 24);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMale.TabIndex = 2;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBirthday
            // 
            this.dateTimePickerBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBirthday.Location = new System.Drawing.Point(204, 109);
            this.dateTimePickerBirthday.MaxDate = new System.DateTime(2003, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerBirthday.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            this.dateTimePickerBirthday.Size = new System.Drawing.Size(101, 20);
            this.dateTimePickerBirthday.TabIndex = 8;
            this.dateTimePickerBirthday.Value = new System.DateTime(2003, 12, 31, 0, 0, 0, 0);
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Location = new System.Drawing.Point(225, 93);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(45, 13);
            this.labelBirthday.TabIndex = 6;
            this.labelBirthday.Text = "Birthday";
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Location = new System.Drawing.Point(12, 148);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(145, 21);
            this.comboBoxPosition.TabIndex = 9;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(64, 132);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(44, 13);
            this.labelPosition.TabIndex = 6;
            this.labelPosition.Text = "Position";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(163, 148);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(142, 21);
            this.comboBoxGroup.TabIndex = 10;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(218, 132);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(36, 13);
            this.labelGroup.TabIndex = 11;
            this.labelGroup.Text = "Group";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(123, 201);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(230, 201);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(57, 175);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(248, 20);
            this.textBoxAdress.TabIndex = 6;
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.Location = new System.Drawing.Point(12, 178);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(39, 13);
            this.labelAdress.TabIndex = 6;
            this.labelAdress.Text = "Adress";
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 234);
            this.Controls.Add(this.labelAdress);
            this.Controls.Add(this.textBoxAdress);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.comboBoxPosition);
            this.Controls.Add(this.labelBirthday);
            this.Controls.Add(this.dateTimePickerBirthday);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFullName);
            this.Name = "Detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail";
            this.groupBoxFullName.ResumeLayout(false);
            this.groupBoxFullName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstname;
        private System.Windows.Forms.Label labelSureName;
        private System.Windows.Forms.TextBox textBoxSureName;
        private System.Windows.Forms.GroupBox groupBoxFullName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthday;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.Label labelAdress;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
    }
}