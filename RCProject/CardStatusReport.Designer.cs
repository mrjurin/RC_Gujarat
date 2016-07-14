namespace RCProject
{
    partial class CardStatusReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardStatusReport));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpReportOptions = new System.Windows.Forms.GroupBox();
            this.rdoBtnFlatFileImportedButCardsNotPrinted = new System.Windows.Forms.RadioButton();
            this.rdoBtnCardsPrintedButChallanNotCreated = new System.Windows.Forms.RadioButton();
            this.rdoBtnTotalCardsPrinted = new System.Windows.Forms.RadioButton();
            this.rdoBtnTotalCardsPrintedWithChallan = new System.Windows.Forms.RadioButton();
            this.rdoBtnRejectedCards = new System.Windows.Forms.RadioButton();
            this.cbxVehicleClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPrinters = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.grpReportOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpReportOptions);
            this.groupBox2.Controls.Add(this.cbxVehicleClass);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbxPrinters);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(11, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 345);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Criteria";
            // 
            // grpReportOptions
            // 
            this.grpReportOptions.Controls.Add(this.rdoBtnFlatFileImportedButCardsNotPrinted);
            this.grpReportOptions.Controls.Add(this.rdoBtnCardsPrintedButChallanNotCreated);
            this.grpReportOptions.Controls.Add(this.rdoBtnTotalCardsPrinted);
            this.grpReportOptions.Controls.Add(this.rdoBtnTotalCardsPrintedWithChallan);
            this.grpReportOptions.Controls.Add(this.rdoBtnRejectedCards);
            this.grpReportOptions.Location = new System.Drawing.Point(45, 110);
            this.grpReportOptions.Name = "grpReportOptions";
            this.grpReportOptions.Size = new System.Drawing.Size(413, 175);
            this.grpReportOptions.TabIndex = 80;
            this.grpReportOptions.TabStop = false;
            this.grpReportOptions.Text = "Report Options";
            // 
            // rdoBtnFlatFileImportedButCardsNotPrinted
            // 
            this.rdoBtnFlatFileImportedButCardsNotPrinted.AutoSize = true;
            this.rdoBtnFlatFileImportedButCardsNotPrinted.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBtnFlatFileImportedButCardsNotPrinted.Location = new System.Drawing.Point(11, 30);
            this.rdoBtnFlatFileImportedButCardsNotPrinted.Name = "rdoBtnFlatFileImportedButCardsNotPrinted";
            this.rdoBtnFlatFileImportedButCardsNotPrinted.Size = new System.Drawing.Size(303, 22);
            this.rdoBtnFlatFileImportedButCardsNotPrinted.TabIndex = 0;
            this.rdoBtnFlatFileImportedButCardsNotPrinted.TabStop = true;
            this.rdoBtnFlatFileImportedButCardsNotPrinted.Text = "Flat File Imported But Cards Not Printed";
            this.rdoBtnFlatFileImportedButCardsNotPrinted.UseVisualStyleBackColor = true;
            // 
            // rdoBtnCardsPrintedButChallanNotCreated
            // 
            this.rdoBtnCardsPrintedButChallanNotCreated.AutoSize = true;
            this.rdoBtnCardsPrintedButChallanNotCreated.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBtnCardsPrintedButChallanNotCreated.Location = new System.Drawing.Point(11, 58);
            this.rdoBtnCardsPrintedButChallanNotCreated.Name = "rdoBtnCardsPrintedButChallanNotCreated";
            this.rdoBtnCardsPrintedButChallanNotCreated.Size = new System.Drawing.Size(295, 22);
            this.rdoBtnCardsPrintedButChallanNotCreated.TabIndex = 4;
            this.rdoBtnCardsPrintedButChallanNotCreated.TabStop = true;
            this.rdoBtnCardsPrintedButChallanNotCreated.Text = "Cards Printed But Challan Not Created";
            this.rdoBtnCardsPrintedButChallanNotCreated.UseVisualStyleBackColor = true;
            // 
            // rdoBtnTotalCardsPrinted
            // 
            this.rdoBtnTotalCardsPrinted.AutoSize = true;
            this.rdoBtnTotalCardsPrinted.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBtnTotalCardsPrinted.Location = new System.Drawing.Point(11, 114);
            this.rdoBtnTotalCardsPrinted.Name = "rdoBtnTotalCardsPrinted";
            this.rdoBtnTotalCardsPrinted.Size = new System.Drawing.Size(159, 22);
            this.rdoBtnTotalCardsPrinted.TabIndex = 1;
            this.rdoBtnTotalCardsPrinted.TabStop = true;
            this.rdoBtnTotalCardsPrinted.Text = "Total Cards Printed";
            this.rdoBtnTotalCardsPrinted.UseVisualStyleBackColor = true;
            // 
            // rdoBtnTotalCardsPrintedWithChallan
            // 
            this.rdoBtnTotalCardsPrintedWithChallan.AutoSize = true;
            this.rdoBtnTotalCardsPrintedWithChallan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBtnTotalCardsPrintedWithChallan.Location = new System.Drawing.Point(11, 86);
            this.rdoBtnTotalCardsPrintedWithChallan.Name = "rdoBtnTotalCardsPrintedWithChallan";
            this.rdoBtnTotalCardsPrintedWithChallan.Size = new System.Drawing.Size(250, 22);
            this.rdoBtnTotalCardsPrintedWithChallan.TabIndex = 3;
            this.rdoBtnTotalCardsPrintedWithChallan.TabStop = true;
            this.rdoBtnTotalCardsPrintedWithChallan.Text = "Total Cards Printed With Challan";
            this.rdoBtnTotalCardsPrintedWithChallan.UseVisualStyleBackColor = true;
            // 
            // rdoBtnRejectedCards
            // 
            this.rdoBtnRejectedCards.AutoSize = true;
            this.rdoBtnRejectedCards.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBtnRejectedCards.Location = new System.Drawing.Point(11, 142);
            this.rdoBtnRejectedCards.Name = "rdoBtnRejectedCards";
            this.rdoBtnRejectedCards.Size = new System.Drawing.Size(135, 22);
            this.rdoBtnRejectedCards.TabIndex = 2;
            this.rdoBtnRejectedCards.TabStop = true;
            this.rdoBtnRejectedCards.Text = "Rejected Cards";
            this.rdoBtnRejectedCards.UseVisualStyleBackColor = true;
            // 
            // cbxVehicleClass
            // 
            this.cbxVehicleClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVehicleClass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVehicleClass.FormattingEnabled = true;
            this.cbxVehicleClass.Items.AddRange(new object[] {
            "ALL"});
            this.cbxVehicleClass.Location = new System.Drawing.Point(153, 23);
            this.cbxVehicleClass.Name = "cbxVehicleClass";
            this.cbxVehicleClass.Size = new System.Drawing.Size(192, 25);
            this.cbxVehicleClass.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 78;
            this.label3.Text = "Vehicle Class:";
            // 
            // cbxPrinters
            // 
            this.cbxPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrinters.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPrinters.FormattingEnabled = true;
            this.cbxPrinters.Location = new System.Drawing.Point(122, 302);
            this.cbxPrinters.Name = "cbxPrinters";
            this.cbxPrinters.Size = new System.Drawing.Size(336, 25);
            this.cbxPrinters.TabIndex = 77;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightGray;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(42, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 26);
            this.label11.TabIndex = 76;
            this.label11.Text = "Printers";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(297, 71);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(161, 24);
            this.dtpTo.TabIndex = 8;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(92, 71);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(160, 24);
            this.dtpFrom.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(268, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "To :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "From :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Location = new System.Drawing.Point(12, 363);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Tomato;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(391, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 27);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(283, 23);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CardStatusReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(524, 442);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CardStatusReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Status Report";
            this.Load += new System.EventHandler(this.CardStatusReport_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpReportOptions.ResumeLayout(false);
            this.grpReportOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoBtnCardsPrintedButChallanNotCreated;
        private System.Windows.Forms.RadioButton rdoBtnTotalCardsPrintedWithChallan;
        private System.Windows.Forms.RadioButton rdoBtnRejectedCards;
        private System.Windows.Forms.RadioButton rdoBtnTotalCardsPrinted;
        private System.Windows.Forms.RadioButton rdoBtnFlatFileImportedButCardsNotPrinted;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxPrinters;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxVehicleClass;
        private System.Windows.Forms.GroupBox grpReportOptions;
    }
}