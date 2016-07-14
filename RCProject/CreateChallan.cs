using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DAL;

namespace RCProject
{
    public partial class CreateChallan : Form
    {
        ChallanNo challanNo;
        DataTable dt;
        string vehRegNoLike;
        DMLSql dMLSql;

        public CreateChallan()
        {
            challanNo = new ChallanNo();
            dt = new DataTable();
            dMLSql = new DMLSql();
            InitializeComponent();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    if (btnSelectAll.Text == "Select All")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            GrdViewChallan.Rows[i].Cells["checkbox"].Value = true;
                        }
                        btnSelectAll.Text = "De Select All";
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            GrdViewChallan.Rows[i].Cells["checkbox"].Value = false;
                        }
                        btnSelectAll.Text = "Select All";
                    }

                }
                else
                    Common.MessageBoxNone("No Records Found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateChallan_Load(object sender, EventArgs e)
        {
            try
            {
                challanReload();
                cbxDatewise.SelectedIndex = 0;
                cbxVehicleClass.SelectedIndex = 0;
                vehRegNoLike = null;
                dtpSelectPrintDate.Format = DateTimePickerFormat.Custom;
                dtpSelectPrintDate.CustomFormat = "dd-MM-yyyy";
                BindGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void BindGridView()
        {
            try
            {
                if (cbxDatewise.SelectedIndex != -1 && cbxVehicleClass.SelectedIndex != -1)
                {
                    string tempDate = null;
                    if (chkbxSelectPrintDate.Checked)
                        tempDate = dtpSelectPrintDate.Value.Date.ToString("dd-MMM-yyyy");

                    dt = challanNo.GetRecordsForChallan(cbxDatewise.Text, cbxVehicleClass.Text, vehRegNoLike, tempDate);
                    GrdViewChallan.Refresh();
                    if (dt.Rows.Count > 0)
                        txtRecordsFound.Text = dt.Rows.Count.ToString();
                    else
                        txtRecordsFound.Text = "0";

                    GrdViewChallan.DataSource = dt;
                    GrdViewChallan.Columns[1].HeaderText = "AUTOID";
                    GrdViewChallan.Columns[1].ReadOnly = true;
                    GrdViewChallan.Columns[1].Visible = false;
                    GrdViewChallan.Columns[2].HeaderText = "REG NO";
                    GrdViewChallan.Columns[2].ReadOnly = true;
                    GrdViewChallan.Columns[3].HeaderText = "REG DATE";
                    GrdViewChallan.Columns[3].ReadOnly = true;
                    GrdViewChallan.Columns[4].HeaderText = "IMPORT DATE";
                    GrdViewChallan.Columns[4].ReadOnly = true;
                    GrdViewChallan.Columns[5].HeaderText = "PRINT DATE";
                    GrdViewChallan.Columns[5].ReadOnly = true;
                    GrdViewChallan.Columns[6].HeaderText = "OWNER SERIAL";
                    GrdViewChallan.Columns[6].ReadOnly = true;
                    GrdViewChallan.Columns[7].HeaderText = "TRANS TYPE";
                    GrdViewChallan.Columns[7].ReadOnly = true;
                    GrdViewChallan.Columns[8].HeaderText = "VEH CLASS";
                    GrdViewChallan.Columns[8].ReadOnly = true;
                    GrdViewChallan.Columns[9].HeaderText = "VEH TYPE";
                    GrdViewChallan.Columns[9].ReadOnly = true;
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCreateChallan_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsCheckedRecordsSelect = false;
                DataGridViewRowCollection Rows = GrdViewChallan.Rows;
                int Records = 0;
                for (int i = 0; i < Rows.Count; i++)
                {
                    if (Convert.ToBoolean(Rows[i].Cells[0].Value) == true)
                    {
                        string AutoID = Rows[i].Cells["AUTOID"].Value.ToString();
                        string VehicleNo = Rows[i].Cells["VEHREGNO"].Value.ToString();
                        IsCheckedRecordsSelect = true;
                        int TempRecords = 0;
                        TempRecords = challanNo.CreateChallan(AutoID, VehicleNo, txtChallanNo.Text, LoggedInUser.userName);
                        if (TempRecords > 0)
                            Records += TempRecords;
                    }
                }
                if (!IsCheckedRecordsSelect)
                    Common.MessageBoxError("No Records are selected for challan, Please try again");
                else
                {
                    if (Records > 0)
                    {
                        Common.MessageBoxSuccess("Challan Created for " + Records + " Records ");
                        challanReload();
                        BindGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRefreshAndLoad_Click(object sender, EventArgs e)
        {
            try
            {
                vehRegNoLike = null;
                BindGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string makeChallanNo(string ChallanNo)
        {
            try
            {
                int length = 0;
                int tempValue = 0;
                if (Common.ValidateStringValue(ChallanNo))
                {
                    //Get ChallanNo 1 when no data Available in table like empty table
                    if (ChallanNo != "1")
                    {
                        //get the last six digits.
                        ChallanNo = ChallanNo.Substring(ChallanNo.Length - 6);
                        tempValue = Convert.ToInt32(ChallanNo);
                        //increment by one in current value
                        tempValue += 1;
                        ChallanNo = Convert.ToString(tempValue);
                    }
                        length = ChallanNo.Length;

                    // Append the zero based on values
                    switch (length)
                    {
                        case 1:
                            ChallanNo = "00000" + ChallanNo;
                            break;
                        case 2:
                            ChallanNo = "0000" + ChallanNo;
                            break;
                        case 3:
                            ChallanNo = "000" + ChallanNo;
                            break;
                        case 4:
                            ChallanNo = "00" + ChallanNo;
                            break;
                        case 5:
                            ChallanNo = "0" + ChallanNo;
                            break;
                        default:
                            break;
                    }
                }
                return ChallanNo;
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

        private void txtSByRCNo_TextChanged(object sender, EventArgs e)
        {
            vehRegNoLike = txtSByRCNo.Text;
            BindGridView();
        }

        private void cbxVehicleClass_DropDown(object sender, EventArgs e)
        {
            try
            {

                string query;
                DataTable dtVehClass = new DataTable();
                query = "SELECT DISTINCT VEHCLASS FROM RC_CASH where CHALLAN_DATETIME IS NULL and CHALLAN_NO IS NULL";
                query += " AND CHALLAN_USERNAME IS NULL AND BATCHNO IS NOT NULL AND PRINT_FLAG IS NOT NULL";
                query += " AND CHIP_FLAG IS NOT NULL AND CHIP_SERIAL_NO IS NOT NULL";

                dtVehClass = dMLSql.GetRecords(query, CommandType.Text);
                cbxVehicleClass.Items.Clear();
                cbxVehicleClass.Items.Insert(0, "ALL");
                cbxVehicleClass.SelectedIndex = 0;
                if (dtVehClass != null)
                {
                    if (dtVehClass.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtVehClass.Rows.Count; i++)
                        {
                            cbxVehicleClass.Items.Insert(i + 1, dtVehClass.Rows[i]["VEHCLASS"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void chkbxSelectPrintDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxSelectPrintDate.Checked)
            {
                dtpSelectPrintDate.Enabled = true;
            }
            else
            {
                dtpSelectPrintDate.Enabled = false;
            }
            BindGridView();
        }

        private void challanReload()
        {
            try
            {
                string RTOCODE = LoggedInUser.rtoCode;
                txtDate.Text = DateTime.Now.ToShortDateString();
                txtTime.Text = DateTime.Now.ToShortTimeString();
                //string ChallanNumber = Common.MakeChallanNo(challanNo.GetChallanNo());
                //txtChallanNo.Text = RTOCODE + "-" + DateTime.Now.Year + "" + Common.monthOrDayCheck(DateTime.Now.Month.ToString()) + "" + Common.monthOrDayCheck(DateTime.Now.Day.ToString()) + ChallanNumber;
                txtChallanNo.Text = RTOCODE + makeChallanNo(challanNo.GetChallanNo());
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message.ToString());
            }
        }
    }
}
