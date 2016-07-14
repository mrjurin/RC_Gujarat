using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BAL;

namespace RCProject
{
    public partial class UserRegistration : Form
    {
        User objUser = null;
        DataTable dt = null;

        string errors;
        Boolean status;
        public UserRegistration()
        {
            status = false;
            errors = string.Empty;
            InitializeComponent();
            Reset();
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(dtpDateValidFrom.Text) > Convert.ToDateTime(dtpDateValidTill.Text))
                {
                    Common.MessageBoxError("Please Enter Valid Date in From and To ");
                    return;
                }
                else
	            {
	                errors = Common.fieldValidation(txtName.Text, txtUserName.Text, txtPassword.Text, txtConfirmPassword.Text, dudUserType.SelectedIndex, dtpDateValidFrom.Text, dtpDateValidTill.Text);

                    status = objUser.CheckIfUserNameExists(txtUserName.Text);
                    if (status)
                    {
                        errors = txtUserName.Tag + " : '" + txtUserName.Text + "' already exists";
                    }
                    if (string.IsNullOrEmpty(errors))
                    {
                        objUser.InsertUserDetails(txtName.Text, txtUserName.Text, txtPassword.Text, dudUserType.SelectedIndex, dtpDateValidFrom.Text, dtpDateValidTill.Text);
                        refresh();
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show(errors, "Correction Required");
                        errors = string.Empty;
                    } 
	            }

            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private void Reset()
        {
            //To Reset all fields and refreshGrid gridview

            txtName.Focus();
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            dudUserType.Text = "Select User Type";
            dtpDateValidFrom.Text = string.Empty;
            dtpDateValidTill.Text = string.Empty;
            errors = string.Empty;
        }

        public DataTable GetDataUser_Mast()
        {
            try
            {

                objUser = new User();
                dt = new DataTable();
                dt = objUser.GetUserDetails();
                return dt;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void refresh()
        {
            try
            {

                dataGridView1.Refresh();
                dataGridView1.DataSource = GetDataUser_Mast();
                dataGridView1.Columns[1].HeaderText = "NAME";
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "USER NAME";
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "PASSWORD";
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "USER TYPE";
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].HeaderText = "DATE VALID FROM";
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].HeaderText = "DATE VALID TILL";
                dataGridView1.Columns[6].ReadOnly = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            dtpDateValidFrom.Format = DateTimePickerFormat.Custom;
            dtpDateValidFrom.CustomFormat = "dd-MM-yyyy";
            dtpDateValidTill.Format = DateTimePickerFormat.Custom;
            dtpDateValidTill.CustomFormat = "dd-MM-yyyy";
        }
    }
}
