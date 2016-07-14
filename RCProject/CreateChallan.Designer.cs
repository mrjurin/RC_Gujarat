namespace RCProject
{
    partial class CreateChallan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateChallan));
            this.cbxVehicleClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDatewise = new System.Windows.Forms.ComboBox();
            this.GrdViewChallan = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreateChallan = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.txtRecordsFound = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefreshAndLoad = new System.Windows.Forms.Button();
            this.txtChallanNo = new System.Windows.Forms.TextBox();
            this.txtSByRCNo = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkbxSelectPrintDate = new System.Windows.Forms.CheckBox();
            this.dtpSelectPrintDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.GrdViewChallan)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxVehicleClass
            // 
            this.cbxVehicleClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVehicleClass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVehicleClass.FormattingEnabled = true;
            this.cbxVehicleClass.Items.AddRange(new object[] {
            "ALL"});
            this.cbxVehicleClass.Location = new System.Drawing.Point(464, 129);
            this.cbxVehicleClass.Name = "cbxVehicleClass";
            this.cbxVehicleClass.Size = new System.Drawing.Size(192, 24);
            this.cbxVehicleClass.TabIndex = 79;
            this.cbxVehicleClass.DropDown += new System.EventHandler(this.cbxVehicleClass_DropDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSlateGray;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(349, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 78;
            this.label5.Text = "Vehicle Class";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxDatewise
            // 
            this.cbxDatewise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatewise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDatewise.FormattingEnabled = true;
            this.cbxDatewise.Items.AddRange(new object[] {
            "ALL",
            "IMPORT DATE",
            "REG DATE",
            "PRINT DATE"});
            this.cbxDatewise.Location = new System.Drawing.Point(136, 129);
            this.cbxDatewise.Name = "cbxDatewise";
            this.cbxDatewise.Size = new System.Drawing.Size(192, 24);
            this.cbxDatewise.TabIndex = 77;
            // 
            // GrdViewChallan
            // 
            this.GrdViewChallan.AllowUserToAddRows = false;
            this.GrdViewChallan.AllowUserToDeleteRows = false;
            this.GrdViewChallan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GrdViewChallan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdViewChallan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox});
            this.GrdViewChallan.Location = new System.Drawing.Point(12, 161);
            this.GrdViewChallan.Name = "GrdViewChallan";
            this.GrdViewChallan.Size = new System.Drawing.Size(924, 331);
            this.GrdViewChallan.TabIndex = 75;
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreateChallan);
            this.groupBox2.Controls.Add(this.btnSelectAll);
            this.groupBox2.Controls.Add(this.txtRecordsFound);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Location = new System.Drawing.Point(12, 498);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(924, 65);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // btnCreateChallan
            // 
            this.btnCreateChallan.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCreateChallan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateChallan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateChallan.Location = new System.Drawing.Point(608, 21);
            this.btnCreateChallan.Name = "btnCreateChallan";
            this.btnCreateChallan.Size = new System.Drawing.Size(132, 27);
            this.btnCreateChallan.TabIndex = 19;
            this.btnCreateChallan.Text = "Create Challan";
            this.btnCreateChallan.UseVisualStyleBackColor = false;
            this.btnCreateChallan.Click += new System.EventHandler(this.btnCreateChallan_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.Lime;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(437, 22);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(132, 27);
            this.btnSelectAll.TabIndex = 18;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // txtRecordsFound
            // 
            this.txtRecordsFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecordsFound.Location = new System.Drawing.Point(121, 23);
            this.txtRecordsFound.Name = "txtRecordsFound";
            this.txtRecordsFound.Size = new System.Drawing.Size(77, 26);
            this.txtRecordsFound.TabIndex = 17;
            this.txtRecordsFound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnClose.Location = new System.Drawing.Point(777, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSlateGray;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 76;
            this.label3.Text = "Datewise";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefreshAndLoad
            // 
            this.btnRefreshAndLoad.BackColor = System.Drawing.Color.Orange;
            this.btnRefreshAndLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshAndLoad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAndLoad.Location = new System.Drawing.Point(753, 127);
            this.btnRefreshAndLoad.Name = "btnRefreshAndLoad";
            this.btnRefreshAndLoad.Size = new System.Drawing.Size(178, 27);
            this.btnRefreshAndLoad.TabIndex = 3;
            this.btnRefreshAndLoad.Text = "Refresh And Load";
            this.btnRefreshAndLoad.UseVisualStyleBackColor = false;
            this.btnRefreshAndLoad.Click += new System.EventHandler(this.btnRefreshAndLoad_Click);
            // 
            // txtChallanNo
            // 
            this.txtChallanNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChallanNo.Location = new System.Drawing.Point(180, 20);
            this.txtChallanNo.Name = "txtChallanNo";
            this.txtChallanNo.ReadOnly = true;
            this.txtChallanNo.Size = new System.Drawing.Size(207, 26);
            this.txtChallanNo.TabIndex = 8;
            // 
            // txtSByRCNo
            // 
            this.txtSByRCNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSByRCNo.Location = new System.Drawing.Point(180, 65);
            this.txtSByRCNo.Name = "txtSByRCNo";
            this.txtSByRCNo.Size = new System.Drawing.Size(207, 26);
            this.txtSByRCNo.TabIndex = 9;
            this.txtSByRCNo.TextChanged += new System.EventHandler(this.txtSByRCNo_TextChanged);
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(515, 19);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(140, 26);
            this.txtDate.TabIndex = 14;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(778, 19);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(137, 26);
            this.txtTime.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(399, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(15, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Challan No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(15, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 26);
            this.label6.TabIndex = 22;
            this.label6.Text = "Search By RC No.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.Location = new System.Drawing.Point(662, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 26);
            this.label7.TabIndex = 23;
            this.label7.Text = "Time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtSByRCNo);
            this.groupBox1.Controls.Add(this.txtChallanNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 108);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Validate RC";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkbxSelectPrintDate);
            this.groupBox3.Controls.Add(this.dtpSelectPrintDate);
            this.groupBox3.Location = new System.Drawing.Point(399, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 43);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // chkbxSelectPrintDate
            // 
            this.chkbxSelectPrintDate.AutoSize = true;
            this.chkbxSelectPrintDate.BackColor = System.Drawing.Color.LightGray;
            this.chkbxSelectPrintDate.Font = new System.Drawing.Font("Arial", 12F);
            this.chkbxSelectPrintDate.Location = new System.Drawing.Point(6, 13);
            this.chkbxSelectPrintDate.Name = "chkbxSelectPrintDate";
            this.chkbxSelectPrintDate.Size = new System.Drawing.Size(145, 22);
            this.chkbxSelectPrintDate.TabIndex = 24;
            this.chkbxSelectPrintDate.Text = "Select Print Date";
            this.chkbxSelectPrintDate.UseVisualStyleBackColor = false;
            this.chkbxSelectPrintDate.CheckedChanged += new System.EventHandler(this.chkbxSelectPrintDate_CheckedChanged);
            // 
            // dtpSelectPrintDate
            // 
            this.dtpSelectPrintDate.Enabled = false;
            this.dtpSelectPrintDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSelectPrintDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSelectPrintDate.Location = new System.Drawing.Point(156, 12);
            this.dtpSelectPrintDate.Name = "dtpSelectPrintDate";
            this.dtpSelectPrintDate.Size = new System.Drawing.Size(160, 24);
            this.dtpSelectPrintDate.TabIndex = 25;
            // 
            // CreateChallan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(948, 574);
            this.Controls.Add(this.cbxVehicleClass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDatewise);
            this.Controls.Add(this.GrdViewChallan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRefreshAndLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateChallan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Challan";
            this.Load += new System.EventHandler(this.CreateChallan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdViewChallan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxVehicleClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDatewise;
        private System.Windows.Forms.DataGridView GrdViewChallan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCreateChallan;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.TextBox txtRecordsFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefreshAndLoad;
        private System.Windows.Forms.TextBox txtChallanNo;
        private System.Windows.Forms.TextBox txtSByRCNo;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkbxSelectPrintDate;
        private System.Windows.Forms.DateTimePicker dtpSelectPrintDate;
        private System.Windows.Forms.GroupBox groupBox3;

    }
}