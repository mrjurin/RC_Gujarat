namespace RCProject
{
    partial class BulkPrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkPrinting));
            this.cbxBatchNo = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxReaders = new System.Windows.Forms.ComboBox();
            this.cbxPrinters = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblRemainingCards = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPrintWrite = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVehicleType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegisterationNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDistinctVehicleTypes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxBatchNo
            // 
            this.cbxBatchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBatchNo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBatchNo.FormattingEnabled = true;
            this.cbxBatchNo.Location = new System.Drawing.Point(189, 46);
            this.cbxBatchNo.Name = "cbxBatchNo";
            this.cbxBatchNo.Size = new System.Drawing.Size(196, 25);
            this.cbxBatchNo.TabIndex = 84;
            this.cbxBatchNo.SelectedIndexChanged += new System.EventHandler(this.cbxBatchNo_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.LightSlateGray;
            this.label22.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(27, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(160, 26);
            this.label22.TabIndex = 83;
            this.label22.Text = "Batch No";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxReaders);
            this.groupBox3.Controls.Add(this.cbxPrinters);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lblRemainingCards);
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.lblTotalRecords);
            this.groupBox3.Controls.Add(this.label44);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.btnPrintWrite);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(11, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(978, 203);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // cbxReaders
            // 
            this.cbxReaders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReaders.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReaders.FormattingEnabled = true;
            this.cbxReaders.Location = new System.Drawing.Point(740, 85);
            this.cbxReaders.Name = "cbxReaders";
            this.cbxReaders.Size = new System.Drawing.Size(213, 25);
            this.cbxReaders.TabIndex = 76;
            // 
            // cbxPrinters
            // 
            this.cbxPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrinters.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPrinters.FormattingEnabled = true;
            this.cbxPrinters.Location = new System.Drawing.Point(740, 46);
            this.cbxPrinters.Name = "cbxPrinters";
            this.cbxPrinters.Size = new System.Drawing.Size(213, 25);
            this.cbxPrinters.TabIndex = 75;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightGray;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(616, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 26);
            this.label11.TabIndex = 72;
            this.label11.Text = "Printers";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LightGray;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(616, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 26);
            this.label12.TabIndex = 69;
            this.label12.Text = "Readers";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemainingCards
            // 
            this.lblRemainingCards.AutoSize = true;
            this.lblRemainingCards.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingCards.Location = new System.Drawing.Point(519, 85);
            this.lblRemainingCards.Name = "lblRemainingCards";
            this.lblRemainingCards.Size = new System.Drawing.Size(0, 17);
            this.lblRemainingCards.TabIndex = 23;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(380, 84);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(126, 17);
            this.label45.TabIndex = 22;
            this.label45.Text = "Remaining Cards:";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(519, 55);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(0, 17);
            this.lblTotalRecords.TabIndex = 21;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(404, 55);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(102, 17);
            this.label44.TabIndex = 20;
            this.label44.Text = "Total Records:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(342, 178);
            this.dataGridView1.TabIndex = 19;
            // 
            // btnPrintWrite
            // 
            this.btnPrintWrite.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPrintWrite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintWrite.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintWrite.Location = new System.Drawing.Point(631, 146);
            this.btnPrintWrite.Name = "btnPrintWrite";
            this.btnPrintWrite.Size = new System.Drawing.Size(132, 27);
            this.btnPrintWrite.TabIndex = 18;
            this.btnPrintWrite.Text = "Print/Write";
            this.btnPrintWrite.UseVisualStyleBackColor = false;
            this.btnPrintWrite.Click += new System.EventHandler(this.btnPrintWrite_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Tomato;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(809, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(516, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 26);
            this.label9.TabIndex = 81;
            this.label9.Text = "Vehicle Type";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVehicleType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRegisterationNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(11, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 62);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle Particulars";
            // 
            // txtVehicleType
            // 
            this.txtVehicleType.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleType.Location = new System.Drawing.Point(679, 20);
            this.txtVehicleType.Name = "txtVehicleType";
            this.txtVehicleType.ReadOnly = true;
            this.txtVehicleType.Size = new System.Drawing.Size(155, 25);
            this.txtVehicleType.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 26);
            this.label1.TabIndex = 26;
            this.label1.Text = "Registration Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRegisterationNo
            // 
            this.txtRegisterationNo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegisterationNo.Location = new System.Drawing.Point(182, 20);
            this.txtRegisterationNo.Name = "txtRegisterationNo";
            this.txtRegisterationNo.ReadOnly = true;
            this.txtRegisterationNo.Size = new System.Drawing.Size(158, 25);
            this.txtRegisterationNo.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightSlateGray;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(526, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 26);
            this.label10.TabIndex = 80;
            this.label10.Text = "Distinct Vehicle Types";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDistinctVehicleTypes
            // 
            this.txtDistinctVehicleTypes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistinctVehicleTypes.Location = new System.Drawing.Point(691, 45);
            this.txtDistinctVehicleTypes.Name = "txtDistinctVehicleTypes";
            this.txtDistinctVehicleTypes.ReadOnly = true;
            this.txtDistinctVehicleTypes.Size = new System.Drawing.Size(284, 25);
            this.txtDistinctVehicleTypes.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(978, 26);
            this.label4.TabIndex = 77;
            this.label4.Text = "Registration Certificate Information";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BulkPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1000, 357);
            this.Controls.Add(this.cbxBatchNo);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDistinctVehicleTypes);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BulkPrinting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Printing";
            this.Load += new System.EventHandler(this.BulkPrinting_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxBatchNo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxReaders;
        private System.Windows.Forms.ComboBox cbxPrinters;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblRemainingCards;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPrintWrite;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegisterationNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDistinctVehicleTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVehicleType;
    }
}