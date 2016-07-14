using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCProject
{
    public partial class IssuingAuthoritySignature : Form
    {
        DataTable dt = new DataTable();
        IssueAuthority issueAuthority = new IssueAuthority();

        public IssuingAuthoritySignature()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddCode.Text == "Add Code")
                {
                    btnAddCode.Text = "Exit Code";
                    btnAddCode.BackColor = Color.Tomato;
                    cbxIssueAuthorityCode.Visible = false;
                    txtIssueAuthorityCode.Visible = true;
                    txtIssueAuthorityCode.Focus();
                }
                else
                {
                    btnAddCode.Text = "Add Code";
                    btnAddCode.BackColor = Color.LightSlateGray;
                    cbxIssueAuthorityCode.Visible = true;
                    txtIssueAuthorityCode.Visible = false;
                    txtIssueAuthorityCode.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAddSignature_Click(object sender, EventArgs e)
        {
            try
            {

                dt = issueAuthority.GetIssueAuthorityCodesToBeAdded();
                if (dt.Rows.Count == 0)
                {
                    btnAddSignature.Visible = false;
                    btnSelectSign.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    btnSave.Visible = true;
                    cbxIssueAuthorityCode.Visible = true;
                    pbxIssueAuthoritySign.Visible = true;
                    label3.Visible = true;
                    txtIssueAuthorityName.Visible = true;

                    refreshIssueAuthorityCodes();
                }
                else
                {
                    string issueAuthorityCodes = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        issueAuthorityCodes += "\"" + dt.Rows[i]["APPROVINGAUTH"].ToString().Trim() + "\"\n";
                    }
                    Common.MessageBoxError("Following Issue Authority Codes required to be added:\n" + issueAuthorityCodes);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        private void refreshGrid()
        {
            try
            {
                dataGridView1.Refresh();
                dataGridView1.DataSource = issueAuthority.GetSignatureAddedIssueAuthorityCodes();
                dataGridView1.Columns[1].HeaderText = "ISSUE AUTHORITY CODE";
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "ISSUE AUTHORITY NAME";
                dataGridView1.Columns[2].ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void refreshIssueAuthorityCodes()
        {
            try
            {
                cbxIssueAuthorityCode.Items.Clear();
                dt = issueAuthority.GetIssueAuthorityCodesForAddingSignature();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxIssueAuthorityCode.Items.Insert(i, dt.Rows[i]["ISSUE_AUTH_CODE"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int i = cbxIssueAuthorityCode.SelectedIndex;
                if (cbxIssueAuthorityCode.SelectedItem != null)
                {
                    if (pbxIssueAuthoritySign.Image != null&&Common.ValidateStringValue(txtIssueAuthorityName.Text))
                    {
                        if (issueAuthority.InsertIssueAuthoritySignatureWithCodeAndName(cbxIssueAuthorityCode.SelectedItem.ToString(), Common.ConvertBMPImageToByteArray(pbxIssueAuthoritySign.Image), txtIssueAuthorityName.Text))
                        {
                            refreshGrid();
                            refreshIssueAuthorityCodes();
                            pbxIssueAuthoritySign.Image = null;
                            txtIssueAuthorityName.Clear();
                            Common.MessageBoxSuccess("Issue Authority Signature Added Successfully");
                        }
                        else
                        {
                            Common.MessageBoxError("Something Wrong");
                        }
                    }
                    else
                    {
                        Common.MessageBoxNone("Select an Issue Authority Signature\nAnd Enter Issue Authority Name");
                    }
                }
                else
                {
                    Common.MessageBoxNone("Select an Issue Authority Code");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnSelectSign_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfileDialog = new OpenFileDialog();

                openfileDialog.InitialDirectory =Environment.CurrentDirectory+ @"\RC Required\RC ISSUE AUTHORITY SIGNATURE";
                openfileDialog.Filter = "bmp files (*.bmp)|*.bmp";
                openfileDialog.Title = "Please select a Issue Authority Signature Image.";


                DialogResult result = openfileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filename = openfileDialog.FileName;
                    pbxIssueAuthoritySign.SizeMode = PictureBoxSizeMode.AutoSize;
                    pbxIssueAuthoritySign.Image = Image.FromFile(filename);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        private void IssuingAuthoritySignature_Load(object sender, EventArgs e)
        {
            try
            {
                refreshGrid();

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {


                DataGridViewRowCollection Rows = dataGridView1.Rows;

                if (Rows.Count > 0)
                {
                    bool IsCheckedRecordsSelect = false;
                    string issueAuthCode;
                    string issueAuthName;
                    int recordsDeleted = 0;

                    for (int i = 0; i < Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(Rows[i].Cells[0].Value) == true)
                        {
                            issueAuthCode = Rows[i].Cells[1].Value.ToString();
                            issueAuthName = Rows[i].Cells[2].Value.ToString();

                            IsCheckedRecordsSelect = true;
                            int TempRecords = 0;
                            TempRecords = issueAuthority.DeleteAddedIssueAuthoritySignatureAndName(issueAuthCode, issueAuthName);
                            if (TempRecords > 0)
                            {
                                recordsDeleted += TempRecords;
                            }
                        }
                    }

                    // Check whether any rows are selected or not..
                    if (IsCheckedRecordsSelect)
                    {
                        if (recordsDeleted > 0)
                        {
                            Common.MessageBoxSuccess("Deleted " + recordsDeleted + " record(s) successfully");
                        }
                        else
                        {
                            Common.MessageBoxError("No Record(s) are Deleted");
                        }

                        refreshGrid();
                        refreshIssueAuthorityCodes();
                    }
                    else
                    {
                        Common.MessageBoxNone("Select Record(s) to delete");
                    }
                }
                else
                {
                    Common.MessageBoxNone("No Record(s) to delete");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
