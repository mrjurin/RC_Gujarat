using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.Data.SqlClient;
using BAL;
using System.Text.RegularExpressions;

namespace RCProject
{
    public partial class SearchStatus : Form
    {
        Validate validate = new Validate();
        DataTable dt = null;
        DMLSql dmlsql = null;
        public SearchStatus()
        {
            dmlsql = new DMLSql();
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^[A-Z0-9\s]{10}$");
            if (txtVehRegNo.Text == "")
            {
                Common.MessageBoxError("Enter Vehicle Registration No");
                txtVehRegNo.Focus();
                return;
            }
            else
            {
                string vehRegNo = txtVehRegNo.Text.ToUpper();
                if (rgx.IsMatch(vehRegNo))
                {
                    DataTable dt = new DataTable();
                    string query = "select rc.VEHREGNO, OWNERNAME, VEHCLASS, VEHICLE_TYPE, CONVERT(varchar(50),rc.IMPORT_DATETIME,103) as IMPORT_DATETIME,";
                    query += " lff.FLATFILE_NAME, [STATUS], CONVERT(varchar(50),PRINT_DATETIME,103) as PRINT_DATETIME";
                    query += " from RC_CASH rc left join LOG_FOR_FLATFILE lff on (rc.VEHREGNO = lff.VEHREGNO) where rc.VEHREGNO = '" + vehRegNo + "'";
                    SqlParameter[] sqlParameter = null;
                    dt = dmlsql.GetRecords(query, sqlParameter, CommandType.Text);
                    refreshGrid(dt);
                    if(dt.Rows.Count == 0)
                    {
                        Common.MessageBoxNone("No records found");
                    }
                }
                else
                {
                    Common.MessageBoxError("Vehicle Registration No. is Incorrect");
                    txtVehRegNo.Focus();
                    return;
                }
            }
        }

        public void refreshGrid(DataTable dataTable)
        {
            try
            {
                dataGridView1.Refresh();
                dt = new DataTable();
                dt = dataTable;
                txtRecords.Text = dt.Rows.Count.ToString();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message.ToString());
            }
        }
    }
}
