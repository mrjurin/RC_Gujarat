using BAL;
using System;
using System.Data;
using System.Windows.Forms;
using INI;

namespace RCProject
{
    public partial class Login : Form
    {
        
        User objUser;
        RTODetails rtoDetails;
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                objUser = new User();
                rtoDetails = new RTODetails();

                if (string.Empty != objUser.CheckUserCredential(txtUsername.Text, txtPassword.Text).ToString())
                {
                    DataTable dt;
                    dt = rtoDetails.GetRTOData();
                    if (dt.Rows.Count > 0)
                    {
                        LoggedInUser.userName = txtUsername.Text;
                        LoggedInUser.rtoCode = dt.Rows[0]["RTOCODE"].ToString();
                        LoggedInUser.rtoLocation = dt.Rows[0]["RTOLOCATION"].ToString();
                        LoggedInUser.computerName = Environment.MachineName;
                        LoggedInUser.loginStatus = 1;

                        #region ////////Get Data from INI File...////////
                        //ReadINIFile objReadINIFile = new ReadINIFile(@"C:\RC_SQL_DB.ini");
                        ReadINIFile objReadINIFile = new ReadINIFile(@"D:\RC_SQL_DB.ini");
                        ConnectionDetails.ServerName = objReadINIFile.GetSetting("ServerName", "ServerName");
                        ConnectionDetails.DSN = objReadINIFile.GetSetting("DSN", "DSN");
                        ConnectionDetails.DatabaseName = objReadINIFile.GetSetting("DatabaseName", "DatabaseName");
                        ConnectionDetails.UserID = objReadINIFile.GetSetting("UserName", "UserName");
                        ConnectionDetails.Password = objReadINIFile.GetSetting("Password", "Password");
                        #endregion

                        //ConnectionDetails.ServerName = "RCVAHAN\\SQLEXPRESS";
                        //ConnectionDetails.DSN = "rcdsn";
                        //ConnectionDetails.DatabaseName = "RCGujarat";
                        //ConnectionDetails.UserID = "sa";
                        //ConnectionDetails.Password = "rtl";

                        //ConnectionDetails.CurrentDirectory = @"C:\";
                        ConnectionDetails.CurrentDirectory = @"D:\";

                        if (objUser.InsertLoginDetails(LoggedInUser.userName, LoggedInUser.computerName, LoggedInUser.loginStatus))
                        {
                            this.Hide();
                            MDIRC mdi = new MDIRC();
                            mdi.Show();
                        } 
                    }
                    else
                    {
                        Common.MessageBoxError("RTO Details are Missing");
                    }
                }
                else
                {
                    Common.MessageBoxError("Something Wrong ☺");
                }
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message);
            }
        }
    }
}
