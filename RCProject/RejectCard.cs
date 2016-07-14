using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BAL;
using DAL;

namespace RCProject
{
    public partial class RejectCard : Form
    {
        DMLSql dMLSql;
        RejectCardDetails rejectCardDetails;
        public RejectCard()
        {
            dMLSql = new DMLSql();
            rejectCardDetails = new RejectCardDetails();
            InitializeComponent();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;
                DataTable dt1;
                string query = string.Empty;
                RejectCardDetails rejectCardDetails = new RejectCardDetails();
                dt = new DataTable();

                if (cbxReason.SelectedIndex != -1)
                {
                    if (cbxReason.Text == "KMS FAILED" || cbxReason.Text == "PERSONALIZATION FAILED")
                    {
                        if (!Common.ValidateStringValue(txtVehicleNumber.Text.Trim()))
                        {
                            Common.MessageBoxError("Please Provide The Registration No.");
                            txtVehicleNumber.Focus();
                            return;
                        }
                    }

                    if (cbxReason.Text != "PRINTING FAILED" && cbxReason.Text != "CHIP ERROR")
                    {
                        if (cbxReason.Text == "KMS FAILED")
                        {
                            query = "SELECT CHIP_SERIAL_NO,CHALLAN_NO,BATCHNO,PRINT_DATETIME,IMPORT_DATETIME from RC_CASH where VEHREGNO = '" + txtVehicleNumber.Text.Trim() + "'";
                            query += " AND BATCHNO IS NOT NULL ORDER BY IMPORT_DATETIME DESC";
                        }
                        else if (cbxReason.Text == "PERSONALIZATION FAILED")
                        {
                            query = "SELECT VEHREGNO FROM RC_CASH WHERE vehregno ='" + txtVehicleNumber.Text.Trim() + "' AND CHIP_FLAG IS NULL";
                            query += " AND PRINT_FLAG IS NOT NULL AND BATCHNO IS NOT NULL ORDER BY IMPORT_DATETIME DESC";
                        }
                        dt = dMLSql.GetRecords(query, CommandType.Text);
                        if (dt.Rows.Count == 0)
                        {
                            Common.MessageBoxError("Registration Number Does Not exist");
                            txtVehicleNumber.Focus();
                            return;
                        }
                    }
                    if (txtCardSerialNo.Text.Trim().Length < 8 && txtCardSerialNo.Text.Trim().Length > 9)
                    {
                        Common.MessageBoxError("Invalid Card Serial No.");
                        txtCardSerialNo.Focus();
                        return;
                    }
                    dt1 = new DataTable();
                    query = "SELECT CARD_SERIAL_NO FROM REJECTCARD WHERE CARD_SERIAL_NO='" + txtCardSerialNo.Text.Trim() + "'";
                    dt1 = dMLSql.GetRecords(query, CommandType.Text);
                    if (dt1.Rows.Count > 0)
                    {
                        Common.MessageBoxError("Card Serial Number Already Exist");
                        txtCardSerialNo.Focus();
                        return;
                    }
                    rejectCard(dt);
                }
                else
                {
                    Common.MessageBoxError("Select a Reason First");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void rejectCard(DataTable dtReject)
        {
            try
            {
                bool result = false;
                string chipSerial = null;
                string batchNo = null;
                string challanNo = null;
                string printDatetime = null;
                string importDatetime = null;

                if (cbxReason.Text == "KMS FAILED")
                {
                    if (dtReject.Rows.Count > 0)
                    {
                        if (!dtReject.Rows[0].IsNull("CHIP_SERIAL_NO") && dtReject.Rows.Count > 0)
                            chipSerial = dtReject.Rows[0]["CHIP_SERIAL_NO"].ToString();

                        if (!dtReject.Rows[0].IsNull("BATCHNO") && dtReject.Rows.Count > 0)
                            batchNo = dtReject.Rows[0]["BATCHNO"].ToString();

                        if (!dtReject.Rows[0].IsNull("CHALLAN_NO") && dtReject.Rows.Count > 0)
                            challanNo = dtReject.Rows[0]["CHALLAN_NO"].ToString();


                        if (!dtReject.Rows[0].IsNull("CHALLAN_NO") && dtReject.Rows.Count > 0)
                            challanNo = dtReject.Rows[0]["CHALLAN_NO"].ToString();


                        if (!dtReject.Rows[0].IsNull("PRINT_DATETIME") && dtReject.Rows.Count > 0)
                            printDatetime = dtReject.Rows[0]["PRINT_DATETIME"].ToString();


                        if (!dtReject.Rows[0].IsNull("IMPORT_DATETIME") && dtReject.Rows.Count > 0)
                            importDatetime = dtReject.Rows[0]["IMPORT_DATETIME"].ToString();

                        result = rejectCardDetails.InsertRejectCardDetails(txtVehicleNumber.Text.Trim(), cbxReason.Text, LoggedInUser.userName,
                            chipSerial, txtCardSerialNo.Text.Trim(), batchNo, challanNo, printDatetime, importDatetime);
                    }
                }
                else
                {
                    result = rejectCardDetails.InsertRejectCardDetails(txtVehicleNumber.Text.Trim(), cbxReason.Text,
                        LoggedInUser.userName, chipSerial, txtCardSerialNo.Text.Trim(), batchNo, challanNo, printDatetime, importDatetime);
                }

                if (result)
                {
                    Common.MessageBoxSuccess("Card Rejected Successfully");
                    cbxReason.SelectedIndex = -1;
                    txtVehicleNumber.Clear();
                    txtCardSerialNo.Clear();
                    cbxReason.Focus();
                    return;
                }
                else
                    Common.MessageBoxError("Card not Rejected");
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
    }
}
 