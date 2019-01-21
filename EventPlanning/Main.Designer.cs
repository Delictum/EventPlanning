using System.Windows.Forms;

namespace EventPlanning
{
    partial class Main
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
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.dataGridViewExport = new System.Windows.Forms.DataGridView();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonMoveAll = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.textBoxEventName = new System.Windows.Forms.TextBox();
            this.labelEventName = new System.Windows.Forms.Label();
            this.buttonAddData = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.buttonWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExport)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(575, 234);
            this.dataGridViewEmployees.TabIndex = 0;
            this.dataGridViewEmployees.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployees_CellDoubleClick);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(1150, 252);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonExcel.TabIndex = 1;
            this.buttonExcel.Text = "Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // dataGridViewExport
            // 
            this.dataGridViewExport.AllowUserToAddRows = false;
            this.dataGridViewExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExport.Location = new System.Drawing.Point(674, 12);
            this.dataGridViewExport.Name = "dataGridViewExport";
            this.dataGridViewExport.ReadOnly = true;
            this.dataGridViewExport.Size = new System.Drawing.Size(551, 234);
            this.dataGridViewExport.TabIndex = 2;
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(593, 40);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 3;
            this.buttonMove.Text = "=>";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonMoveAll
            // 
            this.buttonMoveAll.Location = new System.Drawing.Point(593, 69);
            this.buttonMoveAll.Name = "buttonMoveAll";
            this.buttonMoveAll.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveAll.TabIndex = 4;
            this.buttonMoveAll.Text = "=>>";
            this.buttonMoveAll.UseVisualStyleBackColor = true;
            this.buttonMoveAll.Click += new System.EventHandler(this.buttonMoveAll_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 252);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 5;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonDetail
            // 
            this.buttonDetail.Location = new System.Drawing.Point(93, 252);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(75, 23);
            this.buttonDetail.TabIndex = 6;
            this.buttonDetail.Text = "Detail";
            this.buttonDetail.UseVisualStyleBackColor = true;
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // textBoxEventName
            // 
            this.textBoxEventName.Location = new System.Drawing.Point(741, 254);
            this.textBoxEventName.Name = "textBoxEventName";
            this.textBoxEventName.Size = new System.Drawing.Size(141, 20);
            this.textBoxEventName.TabIndex = 7;
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(671, 257);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(64, 13);
            this.labelEventName.TabIndex = 8;
            this.labelEventName.Text = "Event name";
            // 
            // buttonAddData
            // 
            this.buttonAddData.Location = new System.Drawing.Point(988, 253);
            this.buttonAddData.Name = "buttonAddData";
            this.buttonAddData.Size = new System.Drawing.Size(75, 23);
            this.buttonAddData.TabIndex = 9;
            this.buttonAddData.Text = "Add data";
            this.buttonAddData.UseVisualStyleBackColor = true;
            this.buttonAddData.Click += new System.EventHandler(this.buttonAddData_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(593, 166);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "<=";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(593, 195);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAll.TabIndex = 11;
            this.buttonRemoveAll.Text = "<<=";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(174, 252);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 12;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Location = new System.Drawing.Point(417, 254);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(170, 21);
            this.comboBoxPosition.TabIndex = 13;
            this.comboBoxPosition.SelectedValueChanged += new System.EventHandler(this.comboBoxPosition_SelectedValueChanged);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(255, 254);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(156, 21);
            this.comboBoxGroup.TabIndex = 14;
            this.comboBoxGroup.SelectedValueChanged += new System.EventHandler(this.comboBoxGroup_SelectedValueChanged);
            // 
            // buttonWord
            // 
            this.buttonWord.Location = new System.Drawing.Point(1069, 252);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(75, 23);
            this.buttonWord.TabIndex = 15;
            this.buttonWord.Text = "Word";
            this.buttonWord.UseVisualStyleBackColor = true;
            this.buttonWord.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 288);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.comboBoxPosition);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddData);
            this.Controls.Add(this.labelEventName);
            this.Controls.Add(this.textBoxEventName);
            this.Controls.Add(this.buttonDetail);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonMoveAll);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.dataGridViewExport);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.DataGridView dataGridViewExport;
        private System.Windows.Forms.Button buttonMove;
        private Button buttonMoveAll;
        private Button buttonCreate;
        private Button buttonDetail;
        private TextBox textBoxEventName;
        private Label labelEventName;
        private Button buttonAddData;
        private OpenFileDialog openFileDialog1;
        private Button buttonRemove;
        private Button buttonRemoveAll;
        private Button buttonRefresh;
        private ComboBox comboBoxPosition;
        private ComboBox comboBoxGroup;
        private Button buttonWord;
    }
}