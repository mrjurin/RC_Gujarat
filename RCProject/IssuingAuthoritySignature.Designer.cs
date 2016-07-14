namespace RCProject
{
    partial class IssuingAuthoritySignature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuingAuthoritySignature));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddCode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIssueAuthorityName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSignature = new System.Windows.Forms.Button();
            this.txtIssueAuthorityCode = new System.Windows.Forms.TextBox();
            this.pbxIssueAuthoritySign = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectSign = new System.Windows.Forms.Button();
            this.cbxIssueAuthorityCode = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIssueAuthoritySign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnAddCode);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(12, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 65);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Tomato;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(324, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 32);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Tomato;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(458, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddCode
            // 
            this.btnAddCode.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnAddCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCode.Location = new System.Drawing.Point(48, 19);
            this.btnAddCode.Name = "btnAddCode";
            this.btnAddCode.Size = new System.Drawing.Size(93, 32);
            this.btnAddCode.TabIndex = 2;
            this.btnAddCode.Text = "Add Code";
            this.btnAddCode.UseVisualStyleBackColor = false;
            this.btnAddCode.Visible = false;
            this.btnAddCode.Click += new System.EventHandler(this.btnAddCode_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(188, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIssueAuthorityName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddSignature);
            this.groupBox1.Controls.Add(this.txtIssueAuthorityCode);
            this.groupBox1.Controls.Add(this.pbxIssueAuthoritySign);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelectSign);
            this.groupBox1.Controls.Add(this.cbxIssueAuthorityCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 186);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RC Vehicle Image";
            // 
            // txtIssueAuthorityName
            // 
            this.txtIssueAuthorityName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueAuthorityName.Location = new System.Drawing.Point(210, 137);
            this.txtIssueAuthorityName.Name = "txtIssueAuthorityName";
            this.txtIssueAuthorityName.Size = new System.Drawing.Size(143, 25);
            this.txtIssueAuthorityName.TabIndex = 9;
            this.txtIssueAuthorityName.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Issue Authority Name :";
            this.label3.Visible = false;
            // 
            // btnAddSignature
            // 
            this.btnAddSignature.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnAddSignature.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSignature.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSignature.Location = new System.Drawing.Point(6, 47);
            this.btnAddSignature.Name = "btnAddSignature";
            this.btnAddSignature.Size = new System.Drawing.Size(555, 32);
            this.btnAddSignature.TabIndex = 7;
            this.btnAddSignature.Text = "Add Signature ";
            this.btnAddSignature.UseVisualStyleBackColor = false;
            this.btnAddSignature.Click += new System.EventHandler(this.btnAddSignature_Click);
            // 
            // txtIssueAuthorityCode
            // 
            this.txtIssueAuthorityCode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueAuthorityCode.Location = new System.Drawing.Point(210, 24);
            this.txtIssueAuthorityCode.Name = "txtIssueAuthorityCode";
            this.txtIssueAuthorityCode.Size = new System.Drawing.Size(143, 25);
            this.txtIssueAuthorityCode.TabIndex = 7;
            this.txtIssueAuthorityCode.Visible = false;
            // 
            // pbxIssueAuthoritySign
            // 
            this.pbxIssueAuthoritySign.Location = new System.Drawing.Point(210, 79);
            this.pbxIssueAuthoritySign.Name = "pbxIssueAuthoritySign";
            this.pbxIssueAuthoritySign.Size = new System.Drawing.Size(165, 34);
            this.pbxIssueAuthoritySign.TabIndex = 6;
            this.pbxIssueAuthoritySign.TabStop = false;
            this.pbxIssueAuthoritySign.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Issue Authority Sign :";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Issue Authority Code :";
            this.label1.Visible = false;
            // 
            // btnSelectSign
            // 
            this.btnSelectSign.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSelectSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectSign.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectSign.Location = new System.Drawing.Point(429, 19);
            this.btnSelectSign.Name = "btnSelectSign";
            this.btnSelectSign.Size = new System.Drawing.Size(122, 32);
            this.btnSelectSign.TabIndex = 3;
            this.btnSelectSign.Text = "Select Sign";
            this.btnSelectSign.UseVisualStyleBackColor = false;
            this.btnSelectSign.Visible = false;
            this.btnSelectSign.Click += new System.EventHandler(this.btnSelectSign_Click);
            // 
            // cbxIssueAuthorityCode
            // 
            this.cbxIssueAuthorityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIssueAuthorityCode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxIssueAuthorityCode.FormattingEnabled = true;
            this.cbxIssueAuthorityCode.Location = new System.Drawing.Point(210, 23);
            this.cbxIssueAuthorityCode.Name = "cbxIssueAuthorityCode";
            this.cbxIssueAuthorityCode.Size = new System.Drawing.Size(143, 25);
            this.cbxIssueAuthorityCode.TabIndex = 2;
            this.cbxIssueAuthorityCode.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkBox});
            this.dataGridView1.Location = new System.Drawing.Point(12, 204);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(567, 183);
            this.dataGridView1.TabIndex = 15;
            // 
            // checkBox
            // 
            this.checkBox.HeaderText = "";
            this.checkBox.Name = "checkBox";
            this.checkBox.Width = 5;
            // 
            // IssuingAuthoritySignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(590, 470);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IssuingAuthoritySignature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issuing Authority Signature";
            this.Load += new System.EventHandler(this.IssuingAuthoritySignature_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIssueAuthoritySign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddSignature;
        private System.Windows.Forms.TextBox txtIssueAuthorityCode;
        private System.Windows.Forms.PictureBox pbxIssueAuthoritySign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectSign;
        private System.Windows.Forms.ComboBox cbxIssueAuthorityCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkBox;
        private System.Windows.Forms.TextBox txtIssueAuthorityName;
        private System.Windows.Forms.Label label3;

    }
}