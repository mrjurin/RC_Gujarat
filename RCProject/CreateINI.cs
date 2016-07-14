using System;
using System.Windows.Forms;
using BAL;
using INI;



namespace RCProject
{
    public partial class CreateINI : Form
    {
        public CreateINI()
        {
            InitializeComponent();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!Common.ValidateStringValue(txtUserName.Text.Trim()))
                {
                    Common.MessageBoxNone("Please enter the User Name");
                    txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!Common.ValidateStringValue(txtPassword.Text.Trim()))
                {
                    Common.MessageBoxNone("Please enter the Password");
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void txtDSN_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!Common.ValidateStringValue(txtDSN.Text.Trim()))
                {
                    Common.MessageBoxNone("Please enter the DSN");
                    txtDSN.Focus();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void txtDatabaseName_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!Common.ValidateStringValue(txtDatabaseName.Text.Trim()))
                {
                    Common.MessageBoxNone("Please enter the Database Name");
                    txtDatabaseName.Focus();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //CreateINIFile createINIFile = new CreateINIFile(@"C:\RC_SQL_DB.ini");
                CreateINIFile createINIFile = new CreateINIFile(@"D:\RC_SQL_DB.ini");
                if (createINIFile.CreateFile(txtServerName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtDSN.Text.Trim(), txtDatabaseName.Text.Trim()))
                {
                    Common.MessageBoxSuccess("INI File Created Successfuly");
                    Login objlogin = new Login();
                    this.Hide();
                    objlogin.Show();
                }
                else
                    Common.MessageBoxError("Something Wrong, please contact ADMIN");
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

        private void txtServerName_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!Common.ValidateStringValue(txtServerName.Text.Trim()))
                {
                    Common.MessageBoxNone("Please enter the Server Name");
                    txtServerName.Focus();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
