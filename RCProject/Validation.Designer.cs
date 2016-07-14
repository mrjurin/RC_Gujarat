namespace RCProject
{
    partial class Validation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Validation));
            this.cbxTransactionType = new System.Windows.Forms.ComboBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cbxVehicleType = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.cbxVehicleClass = new System.Windows.Forms.ComboBox();
            this.lblVehicleClass = new System.Windows.Forms.Label();
            this.cbxDatewise = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectRecords = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelectTopRecords = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.txtRecords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateVehicleType = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSByRCNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtSByRCNo = new System.Windows.Forms.TextBox();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.lblDatewise = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxTransactionType
            // 
            this.cbxTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTransactionType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTransactionType.FormattingEnabled = true;
            this.cbxTransactionType.Items.AddRange(new object[] {
            "ALL"});
            this.cbxTransactionType.Location = new System.Drawing.Point(890, 120);
            this.cbxTransactionType.Name = "cbxTransactionType";
            this.cbxTransactionType.Size = new System.Drawing.Size(140, 24);
            this.cbxTransactionType.TabIndex = 83;
            this.cbxTransactionType.DropDown += new System.EventHandler(this.cbxTransactionType_DropDown);
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblTransactionType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.Location = new System.Drawing.Point(780, 120);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(109, 25);
            this.lblTransactionType.TabIndex = 82;
            this.lblTransactionType.Text = "Transaction Type";
            this.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxVehicleType
            // 
            this.cbxVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVehicleType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVehicleType.FormattingEnabled = true;
            this.cbxVehicleType.Items.AddRange(new object[] {
            "TRANSPORT",
            "NON-TRANSPORT"});
            this.cbxVehicleType.Location = new System.Drawing.Point(634, 120);
            this.cbxVehicleType.Name = "cbxVehicleType";
            this.cbxVehicleType.Size = new System.Drawing.Size(140, 24);
            this.cbxVehicleType.TabIndex = 81;
            this.cbxVehicleType.SelectedIndexChanged += new System.EventHandler(this.cbxVehicleType_SelectedIndexChanged);
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblVehicleType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleType.Location = new System.Drawing.Point(524, 120);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(109, 25);
            this.lblVehicleType.TabIndex = 80;
            this.lblVehicleType.Text = "Vehicle Type";
            this.lblVehicleType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxVehicleClass
            // 
            this.cbxVehicleClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVehicleClass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVehicleClass.FormattingEnabled = true;
            this.cbxVehicleClass.Items.AddRange(new object[] {
            "ALL"});
            this.cbxVehicleClass.Location = new System.Drawing.Point(378, 120);
            this.cbxVehicleClass.Name = "cbxVehicleClass";
            this.cbxVehicleClass.Size = new System.Drawing.Size(140, 24);
            this.cbxVehicleClass.TabIndex = 79;
            this.cbxVehicleClass.DropDown += new System.EventHandler(this.cbxVehicleClass_DropDown);
            // 
            // lblVehicleClass
            // 
            this.lblVehicleClass.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblVehicleClass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleClass.Location = new System.Drawing.Point(268, 120);
            this.lblVehicleClass.Name = "lblVehicleClass";
            this.lblVehicleClass.Size = new System.Drawing.Size(109, 25);
            this.lblVehicleClass.TabIndex = 78;
            this.lblVehicleClass.Text = "Vehicle Class";
            this.lblVehicleClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxDatewise
            // 
            this.cbxDatewise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatewise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDatewise.FormattingEnabled = true;
            this.cbxDatewise.Items.AddRange(new object[] {
            "IMPORT DATE",
            "REG DATE"});
            this.cbxDatewise.Location = new System.Drawing.Point(122, 120);
            this.cbxDatewise.Name = "cbxDatewise";
            this.cbxDatewise.Size = new System.Drawing.Size(140, 24);
            this.cbxDatewise.TabIndex = 77;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox});
            this.dataGridView1.Location = new System.Drawing.Point(13, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1189, 338);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectRecords);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtSelectTopRecords);
            this.groupBox2.Controls.Add(this.btnValidate);
            this.groupBox2.Controls.Add(this.btnSelectAll);
            this.groupBox2.Controls.Add(this.txtRecords);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Location = new System.Drawing.Point(13, 496);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1189, 65);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // btnSelectRecords
            // 
            this.btnSelectRecords.BackColor = System.Drawing.Color.LawnGreen;
            this.btnSelectRecords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectRecords.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectRecords.Location = new System.Drawing.Point(442, 21);
            this.btnSelectRecords.Name = "btnSelectRecords";
            this.btnSelectRecords.Size = new System.Drawing.Size(132, 27);
            this.btnSelectRecords.TabIndex = 22;
            this.btnSelectRecords.Text = "Select Records";
            this.btnSelectRecords.UseVisualStyleBackColor = false;
            this.btnSelectRecords.Click += new System.EventHandler(this.btnSelectRecords_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(209, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Select Top Records";
            // 
            // txtSelectTopRecords
            // 
            this.txtSelectTopRecords.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectTopRecords.Location = new System.Drawing.Point(359, 22);
            this.txtSelectTopRecords.MaxLength = 3;
            this.txtSelectTopRecords.Name = "txtSelectTopRecords";
            this.txtSelectTopRecords.Size = new System.Drawing.Size(77, 26);
            this.txtSelectTopRecords.TabIndex = 20;
            this.txtSelectTopRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnValidate
            // 
            this.btnValidate.BackColor = System.Drawing.Color.LimeGreen;
            this.btnValidate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValidate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.Location = new System.Drawing.Point(900, 21);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(132, 27);
            this.btnValidate.TabIndex = 19;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(755, 21);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(132, 27);
            this.btnSelectAll.TabIndex = 18;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // txtRecords
            // 
            this.txtRecords.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecords.Location = new System.Drawing.Point(121, 23);
            this.txtRecords.Name = "txtRecords";
            this.txtRecords.ReadOnly = true;
            this.txtRecords.Size = new System.Drawing.Size(77, 26);
            this.txtRecords.TabIndex = 17;
            this.txtRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Records Found";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Tomato;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1043, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdateVehicleType
            // 
            this.btnUpdateVehicleType.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateVehicleType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateVehicleType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVehicleType.Location = new System.Drawing.Point(776, 55);
            this.btnUpdateVehicleType.Name = "btnUpdateVehicleType";
            this.btnUpdateVehicleType.Size = new System.Drawing.Size(256, 27);
            this.btnUpdateVehicleType.TabIndex = 20;
            this.btnUpdateVehicleType.Text = "STEP-1 Update Vehicle Type";
            this.btnUpdateVehicleType.UseVisualStyleBackColor = false;
            this.btnUpdateVehicleType.Click += new System.EventHandler(this.btnGetVehicleType_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdateVehicleType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblSByRCNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtSByRCNo);
            this.groupBox1.Controls.Add(this.txtBatchNo);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1189, 95);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Validate RC";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.Location = new System.Drawing.Point(777, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 26);
            this.label7.TabIndex = 23;
            this.label7.Text = "Time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSByRCNo
            // 
            this.lblSByRCNo.BackColor = System.Drawing.Color.LightGray;
            this.lblSByRCNo.Font = new System.Drawing.Font("Arial", 12F);
            this.lblSByRCNo.Location = new System.Drawing.Point(6, 54);
            this.lblSByRCNo.Name = "lblSByRCNo";
            this.lblSByRCNo.Size = new System.Drawing.Size(159, 26);
            this.lblSByRCNo.TabIndex = 22;
            this.lblSByRCNo.Text = "Search By RC No.";
            this.lblSByRCNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Batch No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(514, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(893, 19);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(137, 26);
            this.txtTime.TabIndex = 15;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(630, 19);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(140, 26);
            this.txtDate.TabIndex = 14;
            // 
            // txtSByRCNo
            // 
            this.txtSByRCNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSByRCNo.Location = new System.Drawing.Point(171, 55);
            this.txtSByRCNo.Name = "txtSByRCNo";
            this.txtSByRCNo.Size = new System.Drawing.Size(257, 26);
            this.txtSByRCNo.TabIndex = 9;
            this.txtSByRCNo.TextChanged += new System.EventHandler(this.txtSByRCNo_TextChanged);
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchNo.Location = new System.Drawing.Point(171, 20);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.ReadOnly = true;
            this.txtBatchNo.Size = new System.Drawing.Size(257, 26);
            this.txtBatchNo.TabIndex = 8;
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.Location = new System.Drawing.Point(1045, 117);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(157, 27);
            this.btnLoadData.TabIndex = 3;
            this.btnLoadData.Text = "STEP-2 Load Data";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // lblDatewise
            // 
            this.lblDatewise.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblDatewise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatewise.Location = new System.Drawing.Point(12, 120);
            this.lblDatewise.Name = "lblDatewise";
            this.lblDatewise.Size = new System.Drawing.Size(109, 25);
            this.lblDatewise.TabIndex = 76;
            this.lblDatewise.Text = "Datewise";
            this.lblDatewise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Validation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1214, 573);
            this.Controls.Add(this.cbxTransactionType);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.cbxVehicleType);
            this.Controls.Add(this.lblVehicleType);
            this.Controls.Add(this.cbxVehicleClass);
            this.Controls.Add(this.lblVehicleClass);
            this.Controls.Add(this.cbxDatewise);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDatewise);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Validation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validation";
            this.Load += new System.EventHandler(this.Validation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTransactionType;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.ComboBox cbxVehicleType;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cbxVehicleClass;
        private System.Windows.Forms.Label lblVehicleClass;
        private System.Windows.Forms.ComboBox cbxDatewise;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.TextBox txtRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSByRCNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtSByRCNo;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label lblDatewise;
        private System.Windows.Forms.Button btnUpdateVehicleType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelectTopRecords;
        private System.Windows.Forms.Button btnSelectRecords;

    }
}