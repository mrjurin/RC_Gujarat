using BAL;
using DAL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using persoRCDU;
using System.Diagnostics;
//using SmartCardManager;
//using Fargo.PrinterSDK;
using ClientRuntime;
namespace RCProject
{
    public partial class BulkPrinting : Form
    {
        #region Default and Global Variables
        string VehicleRegNo = string.Empty;
        string AutoID = string.Empty;
        DataTable dt;
        DataBulkPrint dataBulkPrint = new DataBulkPrint();
        DataSinglePrint dataSinglePrint = new DataSinglePrint();
        //private SmartCardManager.SmartCardManager m_smartCardManager;
        List<string> strreaderList = new List<string>();
        int hcontext;
        SMARTCARDHELPER objSCHELPER = null;
        string strErrorMSg = string.Empty;
        string readerName = string.Empty;
        PersoCardAssignData objPersoCardAssignData = null;
        string ReturnMessage = string.Empty;
        string ChipSerialNo = string.Empty;
        DMLSql dMLSql;

        #endregion

        public BulkPrinting()
        {
            InitializeComponent();
            dMLSql = new DMLSql();
        }

        private void btnPrintWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxBatchNo.SelectedIndex != -1)
                {
                    dt = new DataTable();
                    //To get vehicle registration no and autoid
                    dt = dataBulkPrint.GetVehicleRegistrationNoForBulkPrinting(cbxBatchNo.Text);
                    bulkPrint(dt);
                }
                else
                    Common.MessageBoxNone("No batch selected");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bulkPrint(DataTable dt)
        {
            try
            {
                int CardPrint = 0;
                int printerIndex = cbxPrinters.SelectedIndex;
                int readerIndex = cbxReaders.SelectedIndex;
                if (printerIndex != -1 && readerIndex != -1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {   
                        ReturnMessage = string.Empty;
                        evolisParameters();
                        string printerStatus = BusinessHelper.PrinterGetState(cbxPrinters.Text);
                        if (printerStatus == "OFF,PRINTER_OFFLINE")
                        {
                            Common.MessageBoxError("Printer is offline, please start the printer");
                            break;
                        }
                        else if (printerStatus == "READY,PRINTER_READY")
                        {
                            #region else if (printerStatus == "READY,PRINTER_READY")
                            VehicleRegNo = dt.Rows[i]["VEHREGNO"].ToString();
                            AutoID = dt.Rows[i]["AUTOID"].ToString();

                            //Check if data is available in database
                            if (dataSinglePrint.GetVehicleTypeOfRCRecordForReport(VehicleRegNo, AutoID) != null)
                            {
                                string vehicleType = dataSinglePrint.GetVehicleTypeOfRCRecordForReport(VehicleRegNo, AutoID).ToString();
                                if (vehicleType == "T" || vehicleType == "N")
                                {
                                    txtRegisterationNo.Text = VehicleRegNo;
                                    txtVehicleType.Text = vehicleType;
                                    //showRCDetails(VehicleRegNo);
                                    GetRecordsRC_Cash getRecordsRC_Cash = new GetRecordsRC_Cash();

                                    //Get Data from database based on vehicle No.
                                    DataTable objHoldVehicleRecords = getRecordsRC_Cash.GetRecords(VehicleRegNo, AutoID);

                                    #region Evolis Printer Setting and chip writting
                                    if (cbxPrinters.Text.Contains("Evolis"))
                                    {
                                        evolisParameters();

                                        string IsEmptyPrinter = "";
                                        //Eject if there is a card in printer
                                        IsEmptyPrinter = BusinessHelper.SendCommand(cbxPrinters.Text, "Se", "5000");

                                        if (IsEmptyPrinter == "OK")
                                        {
                                            int timeOut = 1; 
                                            string IsResultOK=string.Empty;
                                            while (timeOut < 3)
                                            {
                                                IsResultOK = BusinessHelper.SendCommand(cbxPrinters.Text, "Sis", "5000");

                                                #region if (IsResultOK == "FEEDER EMPTY")
                                                if (IsResultOK == "FEEDER EMPTY")
                                                {
                                                    printerStatus = BusinessHelper.PrinterGetState(cbxPrinters.Text);
                                                    if (printerStatus == "ERROR,FEEDER_EMPTY")
                                                    {
                                                        BusinessHelper.SendCommand(cbxPrinters.Text, "Sa;d", "5000");
                                                    }
                                                    else if (printerStatus == "WARNING,FEEDER_EMPTY")
                                                    {
                                                        DialogResult result = MessageBox.Show("Insert Cards In Feeder and Press 'Retry'\nPress 'Cancel' to stop Bulk Printing", "FEEDER EMPTY", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                                        if (result == DialogResult.Retry)
                                                        {
                                                            timeOut = 0;
                                                        }
                                                        else if (result == DialogResult.Cancel)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                }
                                                #endregion
                                                else if(IsResultOK == "OK")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    timeOut++;
                                                }
                                            }
                                            // if result is Ok that means Card is in correct position\
                                            #region if (IsResultOK == "OK")
                                            if (IsResultOK == "OK")
                                            {
                                                //Reference create for Parso Card
                                                objPersoCardAssignData = new PersoCardAssignData();
                                                //System.Threading.Thread.Sleep(7000);
                                                //System.Threading.Thread.Sleep(3000);
                                                //Pass the data for Perso card
                                                objPersoCardAssignData.PersoCard(objHoldVehicleRecords, cbxReaders.SelectedValue.ToString(), hcontext, cbxPrinters.Text, ref ReturnMessage, false, ref ChipSerialNo);
                                                //SMARTCARDHELPER objSmartCard = new SMARTCARDHELPER();
                                                //System.Threading.Thread.Sleep(3000);
                                                // If Return Message is "0:SUCESS" means card perso is success...
                                                if (ReturnMessage != "0:SUCESS")
                                                {
                                                    if (ReturnMessage == "Smart Card Connection Error ... ")
                                                        i--;
                                                    //if ReturnMessage is another message then something wrong in perso card ... Reject the card and  
                                                    else
                                                    {
                                                        Common.MessageBoxError(ReturnMessage);
                                                        IsResultOK = BusinessHelper.SendCommand(cbxPrinters.Text, "Se", "5000");
                                                        break;
                                                    }
                                                }
                                            }
                                            #endregion
                                            else
                                            {
                                                //Common.MessageBoxError(IsResultOK);
                                                break;
                                                //return;
                                            }
                                        }
                                    }
                                    #endregion

                                    #region Card Printing after chip is written
                                    //Check if chip writting is successful
                                    if (ReturnMessage == "0:SUCESS")
                                    {
                                        if (Common.ValidateStringValue(ChipSerialNo))
                                        {
                                            #region Entries in database for RCRecord(Chip Written) and Load Crystal Report for Card Printing
                                            ReportDocument cryRpt = new ReportDocument();
                                            if (Convert.ToInt32(dataSinglePrint.InsertDetailsForPrintedRCRecords(AutoID, VehicleRegNo, vehicleType, LoggedInUser.userName, 1, ChipSerialNo)) > 0)
                                                ChipSerialNo = null;
                                            else
                                            {
                                                Common.MessageBoxError("Something wrong when trying to update in RC_Cash table... after chip writting...");
                                                break;
                                            }

                                            if (vehicleType.Equals("T"))
                                                //cryRpt.Load(ConnectionDetails.CurrentDirectory + "RC VEHICLE IMAGES\\RC_CARD_T.rpt");
                                                //cryRpt.Load(@"C:\RC Required\RC Reports\RC_CARD_T.rpt");
                                                cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\RC_CARD_T.rpt");

                                            else if (vehicleType.Equals("N"))
                                                //cryRpt.Load(ConnectionDetails.CurrentDirectory + "RC VEHICLE IMAGES\\RC_CARD_NT.rpt");
                                                //cryRpt.Load(@"C:\RC Required\RC Reports\RC_CARD_NT.rpt");
                                                cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\RC_CARD_NT.rpt");
                                            #endregion

                                            #region Validate DSN
                                            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                                            ConnectionInfo crConnectionInfo = new ConnectionInfo();
                                            Tables CrTables;

                                            crConnectionInfo.ServerName = ConnectionDetails.DSN;
                                            crConnectionInfo.DatabaseName = ConnectionDetails.DatabaseName;
                                            crConnectionInfo.UserID = ConnectionDetails.UserID;
                                            crConnectionInfo.Password = ConnectionDetails.Password;

                                            CrTables = cryRpt.Database.Tables;
                                            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                                            {
                                                crtableLogoninfo = CrTable.LogOnInfo;
                                                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                                                CrTable.ApplyLogOnInfo(crtableLogoninfo);
                                            }
                                            #endregion

                                            #region Selection Formula,printing commands and Entries in database for RCRecord(CardPrinted)
                                            cryRpt.RecordSelectionFormula = "{RC_CASH.VEHREGNO} = \"" + VehicleRegNo + "\" and {RC_CASH.AUTOID} = " + AutoID;
                                            cryRpt.Refresh();
                                            //System.Threading.Thread.Sleep(2000);
                                            System.Threading.Thread.Sleep(1000);

                                            moveToPrintLocation:
                                            // Move to Print Loction Card for Pritner
                                            string IsCardMoveToPrintLocation = BusinessHelper.SendCommand(cbxPrinters.Text, "Sib", "5000");
                                            printerStatus = BusinessHelper.PrinterGetState(cbxPrinters.Text);
                                            if (IsCardMoveToPrintLocation == "OK")
                                            {
                                                //System.Threading.Thread.Sleep(4000);
                                                //System.Threading.Thread.Sleep(2000);
                                                //double timingMilliSec = DateTime.Now.TimeOfDay.TotalMilliseconds;
                                                //double timingSec = DateTime.Now.TimeOfDay.TotalSeconds;
                                                cryRpt.PrintOptions.PrinterName = cbxPrinters.Text;
                                                cryRpt.PrintToPrinter(1, true, 1, 2);
                                                //System.Threading.Thread.Sleep(35000);
                                                System.Threading.Thread.Sleep(26000);
                                                //timingMilliSec = DateTime.Now.TimeOfDay.TotalMilliseconds - timingMilliSec;
                                                //timingSec = DateTime.Now.TimeOfDay.TotalSeconds - timingSec;
                                                cryRpt.Close();
                                                CardPrint += 1;
                                                if (Convert.ToInt32(dataSinglePrint.InsertDetailsForPrintedRCRecords(AutoID, VehicleRegNo, vehicleType, LoggedInUser.userName, 1, ChipSerialNo)) > 0)
                                                {
                                                    lblRemainingCards.Text = Convert.ToString(dt.Rows.Count - CardPrint);
                                                    refreshGrid();
                                                    System.Threading.Thread.Sleep(200);
                                                }
                                                else
                                                {
                                                    Common.MessageBoxError("Something wrong when trying to update in RC_Cash table after printing RC card");
                                                }
                                            }
                                            else
                                            {
                                                IsCardMoveToPrintLocation = BusinessHelper.SendCommand(cbxPrinters.Text, "Sib", "5000");
                                                goto moveToPrintLocation;
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            Common.MessageBoxError("Chip Serial not found after Chip Writing");
                                            i--;
                                        }
                                    }
                                    else
                                    {
                                        if (ReturnMessage != "Smart Card Connection Error ... ")
                                        {
                                            if (ReturnMessage != "")
                                            {
                                                Common.MessageBoxError(ReturnMessage);
                                            }
                                            i--;
                                        }
                                    }
                                    #endregion

                                }
                                else
                                {
                                    Common.MessageBoxError("Vehicle Type ='" + vehicleType + "' is incorrect for autoid = '" + AutoID + "' and vehregno = '" + VehicleRegNo + "'");
                                }
                            }
                            else
                            {
                                Common.MessageBoxError("Vehicle Type is missing for autoid = '" + AutoID + "' and vehregno = '" + VehicleRegNo + "'");
                            }

                        #endregion
                        }
                        else if(printerStatus == "ERROR,FEEDER_EMPTY")
                        {
                            string IsFeederEmpty = BusinessHelper.SendCommand(cbxPrinters.Text, "Sa;d", "2000");
                            if(IsFeederEmpty == "OK")
                            {
                                i--;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (printerStatus == "WARNING,FEEDER_EMPTY")
                        {
                            DialogResult result = MessageBox.Show("Insert Cards In Feeder and Press 'Retry'\nPress 'Cancel' to stop Bulk Printing", "FEEDER EMPTY", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                            if (result == DialogResult.Retry)
                            {
                                i--;
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                break;
                            }
                        }
                        else if (printerStatus == "READY,INF_PRINTING_RUNNING")
                        {
                            System.Threading.Thread.Sleep(500);
                            i--;
                        }
                        else if (printerStatus == "ERROR,RIBBON_ENDED")
                        {
                            DialogResult result = MessageBox.Show("Please replace the Ribbon and Check Printer Status.\nPress 'Retry' to continue.\nPress 'Cancel' to stop Bulk Printing", "RIBBON ENDED", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                            if (result == DialogResult.Retry)
                            {
                                i--;
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                break;
                            }
                        }
                        else if (printerStatus == "ERROR,ERR_RIBBON_ERROR")
                        {
                            DialogResult result = MessageBox.Show("Please check the Ribbon and Check Printer Status.\nPress 'Retry' to continue.\nPress 'Cancel' to stop Bulk Printing", "RIBBON ENDED", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                            if (result == DialogResult.Retry)
                            {
                                i--;
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                break;
                            }
                        }
                        else
                        {
                            Common.MessageBoxError("Printer is not ready, check Printer Status\n Printer Status : " + printerStatus);
                            break;
                        }
                    }
                    Common.MessageBoxNone(CardPrint + " Card(s) Printed");
                    if (CardPrint == Convert.ToInt32(lblTotalRecords.Text))
                        refreshBatches(0);
                    else
                        refreshBatches(cbxBatchNo.SelectedIndex);
                }
                else
                {
                    if (printerIndex == -1 && readerIndex == -1)
                        Common.MessageBoxError("First select a Printer and a Reader");
                    else if (printerIndex == -1 && readerIndex != -1)
                        Common.MessageBoxError("First select a Printer");
                    else if (printerIndex != -1 && readerIndex == -1)
                        Common.MessageBoxError("First select a Reader");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void showRCDetails(string vehicleRegNo)
        {
            try
            {
                //DataTable dtRejectCard = dataSinglePrint.GetRCRecordsForPrinting(vehicleRegNo);
                //if (dtRejectCard.Rows.Count > 0)
                //{
                //    txtTransactionType.Text = dtRejectCard.Rows[0]["TRN_TY"].ToString();
                //    txtVehicleType.Text = dtRejectCard.Rows[0]["VEHICLE_TYPE"].ToString();

                //    //VehicleParticulars
                //    txtRegisterationNo.Text = dtRejectCard.Rows[0]["VEHREGNO"].ToString();
                //    txtModelNumber.Text = dtRejectCard.Rows[0]["MODELNO"].ToString();
                //    txtManufacturerName.Text = dtRejectCard.Rows[0]["MANUFACTURER"].ToString();
                //    txtRegistrationDate.Text = dtRejectCard.Rows[0]["REGDATE"].ToString();
                //    txtRegistrationValidity.Text = dtRejectCard.Rows[0]["REGNVALIDITY"].ToString();
                //    txtIssuingAuthorityID.Text = dtRejectCard.Rows[0]["APPROVINGAUTH"].ToString();
                //    txtTaxPaidUpto.Text = dtRejectCard.Rows[0]["TAXPAIDUPTO"].ToString();
                //    txtOwnerName.Text = dtRejectCard.Rows[0]["OWNERNAME"].ToString();
                //    txtSDWOf.Text = dtRejectCard.Rows[0]["FNAME"].ToString();
                //    txtAddress.Text = dtRejectCard.Rows[0]["CADDRESS"].ToString();


                //    //DETAILS
                //    //Vehicle Details
                //    txtColour.Text = dtRejectCard.Rows[0]["COLOUR"].ToString();
                //    txtFuel.Text = dtRejectCard.Rows[0]["FUEL"].ToString();
                //    txtVehicleClass.Text = dtRejectCard.Rows[0]["VEHCLASS"].ToString();
                //    txtBodyType.Text = dtRejectCard.Rows[0]["BODYTYPE"].ToString();
                //    txtSeatingCapacity.Text = dtRejectCard.Rows[0]["SEATCAP"].ToString();
                //    txtManufactureDate.Text = dtRejectCard.Rows[0]["MANUFDATE"].ToString();
                //    txtUnladenWeight.Text = dtRejectCard.Rows[0]["UNLADENWT"].ToString();
                //    txtCubicCapacity.Text = dtRejectCard.Rows[0]["CUBICCAP"].ToString();
                //    txtWheelBase.Text = dtRejectCard.Rows[0]["WHEELBASE"].ToString();
                //    txtNoOfCylinders.Text = dtRejectCard.Rows[0]["NOOFCYLIN"].ToString();
                //    txtOwnerSerial.Text = dtRejectCard.Rows[0]["OWNERSERIAL"].ToString();


                //    //Hypothecation Details
                //    txtFinancerName.Text = dtRejectCard.Rows[0]["FINNAME"].ToString();
                //    txtFinancerAddress.Text = dtRejectCard.Rows[0]["FINADDRESS"].ToString();
                //    txtHypoFrom.Text = dtRejectCard.Rows[0]["HYPOFROM"].ToString();
                //    txtHypoTo.Text = dtRejectCard.Rows[0]["HYPOTO"].ToString();


                //    //NOC Details
                //    txtNOCNo.Text = dtRejectCard.Rows[0]["NOCNO"].ToString();
                //    txtNCRBClearanceNo.Text = dtRejectCard.Rows[0]["NCRBCLEARNO"].ToString();
                //    txtNOCIssueDate.Text = dtRejectCard.Rows[0]["NOCISSUEDT"].ToString();
                //    txtStateTo.Text = dtRejectCard.Rows[0]["STATETO"].ToString();
                //    txtRTOTo.Text = dtRejectCard.Rows[0]["RTOTO"].ToString();


                //    //Insurance Details
                //    txtInsuranceCompanyName.Text = dtRejectCard.Rows[0]["INSCOMPNAME"].ToString();
                //    txtCoverPolicyNo.Text = dtRejectCard.Rows[0]["COVERPOLICYNO"].ToString();
                //    txtInsuranceValidUpto.Text = dtRejectCard.Rows[0]["INSVALIDUPTO"].ToString();
                //    txtInsuranceType.Text = dtRejectCard.Rows[0]["INSTYPE"].ToString();


                //    //Fitness Details
                //    txtFitnessValidityDate.Text = dtRejectCard.Rows[0]["FITVALIDUPTO"].ToString();
                //    txtFitnessOfficerCode.Text = dtRejectCard.Rows[0]["FITINSOFFICER"].ToString();
                //    txtFitnessLocation.Text = dtRejectCard.Rows[0]["FITLOCATION"].ToString();


                //    //PUC Details
                //    txtPUCCenterCode.Text = dtRejectCard.Rows[0]["PUCCENTERCODE"].ToString();
                //    txtPUCValidationUpto.Text = dtRejectCard.Rows[0]["PUCVALIDUPTO"].ToString();


                //    //Tax Payment Details
                //    txtTaxAmount.Text = dtRejectCard.Rows[0]["TAXAMOUNT"].ToString();
                //    txtFine.Text = dtRejectCard.Rows[0]["FINE"].ToString();
                //    txtExemptionReceiptNo.Text = dtRejectCard.Rows[0]["EXEMPTRECPTNO"].ToString();
                //    txtPaymentDate.Text = dtRejectCard.Rows[0]["PAYMENTDT"].ToString();
                //    txtTaxValidFrom.Text = dtRejectCard.Rows[0]["TAXVALIDFROM"].ToString();
                //    txtTaxValidTo.Text = dtRejectCard.Rows[0]["TAXVALIDTO"].ToString();
                //    txtExemption.Text = dtRejectCard.Rows[0]["EXEMPTION"].ToString();
                //    txtDRTOCode.Text = dtRejectCard.Rows[0]["DRTOCODE"].ToString();
                //    txtBackendUpdateFlag.Text = dtRejectCard.Rows[0]["BUFLAG"].ToString();


                //    //Additional Details
                //    txtGrossVehicleWeight.Text = dtRejectCard.Rows[0]["GROSSVEHWT"].ToString();
                //    txtNumOfSemiTrailer.Text = dtRejectCard.Rows[0]["SEMITRAILERS"].ToString();
                //    txtFrontAxle.Text = dtRejectCard.Rows[0]["AXLEINFO"].ToString().Substring(0, 6);
                //    txtTandemAxle.Text = dtRejectCard.Rows[0]["AXLEINFO"].ToString().Substring(12, 6);
                //    txtRearAxle.Text = dtRejectCard.Rows[0]["AXLEINFO"].ToString().Substring(6, 6);
                //    txtAnyOtherAxle.Text = dtRejectCard.Rows[0]["AXLEINFO"].ToString().Substring(18, 6);
                //}
                //else
                //{
                //    //Common.MessageBoxError("No Records Found!!!!");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BulkPrinting_Load(object sender, EventArgs e)
        {
            try
            {
                bindPrinterlist();

                bindReaderlist();

                refreshBatches(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbxBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxBatchNo.SelectedIndex != -1)
                {
                    refreshGrid();
                    DataTable dt1 = new DataTable();
                    string query = "Select Distinct VEHICLE_TYPE from RC_CASH where BATCHNO = '" + cbxBatchNo.Text + "'";
                    lblTotalRecords.Text = dt.Rows.Count.ToString();
                    lblRemainingCards.Text = dt.Rows.Count.ToString();
                    txtDistinctVehicleTypes.Text = "";
                    if (dt.Rows.Count > 0)
                    { 
                        //    showRCDetails(dtRejectCard.Rows[0]["VEHREGNO"].ToString());
                        txtRegisterationNo.Text = dt.Rows[0]["VEHREGNO"].ToString();
                        dt1 = dMLSql.GetRecords(query, CommandType.Text);
                        if(dt1.Rows.Count > 0)
                        {   for(int i = 0; i < dt1.Rows.Count; i++)
                            {
                                if(i==(dt1.Rows.Count-1))
                                    txtDistinctVehicleTypes.Text += " " + dt1.Rows[i]["VEHICLE_TYPE"].ToString() + " ";
                                else
                                    txtDistinctVehicleTypes.Text += " " + dt1.Rows[i]["VEHICLE_TYPE"].ToString() + " , ";
                            }
                    
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void refreshGrid()
        {
            try
            {
                dt = new DataTable();
                dt = dataBulkPrint.GetVehicleRegistrationNoForBulkPrinting(cbxBatchNo.Text);
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void refreshBatches(int index)
        {
            try
            {
                dt = new DataTable();
                cbxBatchNo.Items.Clear();
                dt = dataBulkPrint.GetBatchesForBulkPrinting();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxBatchNo.Items.Insert(i, dt.Rows[i]["BATCH_NO"].ToString());
                }
                cbxBatchNo.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bindReaderlist()
        {
            try
            {
                objSCHELPER = new persoRCDU.SMARTCARDHELPER();
                objSCHELPER.Get_Reader_List(ref strreaderList, ref hcontext, ref strErrorMSg);

                cbxReaders.DataSource = strreaderList;
                cbxReaders.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void bindPrinterlist()
        {
            try
            {
                var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
                string DefaultPrinter = string.Empty;
                List<string> list = new List<string>();
                foreach (var printer in printerQuery.Get())
                {
                    list.Add(printer.GetPropertyValue("Name").ToString());
                    //var isDefault = printer.GetPropertyValue("Default");
                    //if (Convert.ToBoolean(isDefault))
                    //{
                    //    DefaultPrinter = printer.GetPropertyValue("Name").ToString();
                    //}
                }

                cbxPrinters.DataSource = list;
                cbxPrinters.SelectedIndex = -1;
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

        private void evolisParameters()
        {
            #region Parameters for connecting to Evolis
            BusinessHelper.IP = Common.IP;
            BusinessHelper.Port = Common.Port;
            BusinessHelper.CommType = Common.CommType;
            #endregion
        }

        //#region HID Printer Coding Parts Here
        //private string m_selectedPrinter;
        //private void DockAndUpdateStatus(string printerName)
        //{
        //    Boolean cardWasDockedOk;
        //    CardStatus cardStatus;

        //    cardStatus = CardStatus.CardFeeding;
        //    // updateCardStatus(cardStatus);

        //    cardWasDockedOk = DockTheCard(printerName);

        //    if (cardWasDockedOk)
        //    {
        //        cardStatus = CardStatus.CardDockedOk;
        //    }
        //    else
        //    {
        //        cardStatus = CardStatus.CardFeedError;
        //    }
        //    //updateCardStatus(cardStatus);
        //}

        //private void ConnectAndUpdateStatus(string printerName)
        //{
        //    Boolean cardConnected;
        //    CardStatus cardStatus;

        //    cardStatus = CardStatus.CardConnecting;
        //    // updateCardStatus(cardStatus);

        //    cardConnected = ConnectReader(printerName);

        //    if (cardConnected)
        //    {
        //        cardStatus = CardStatus.CardConnected;
        //    }
        //    else
        //    {
        //        cardStatus = CardStatus.CardHasError;
        //    }
        //    // updateCardStatus(cardStatus);
        //}


        //enum CardStatus
        //{
        //    NoCardInPrinter = 0,
        //    CardFeeding,
        //    CardDockedOk,
        //    CardConnecting,
        //    CardConnected,
        //    CardDisconnecting,
        //    CardDisconnected,
        //    CardEjecting,
        //    CardHasError,
        //    CardFeedError,
        //    CardPrinting,
        //};


        //private Boolean PollForPrinterReady(string printerName)
        //{
        //    Boolean returnCode;
        //    PrinterInfo printerInfo = new PrinterInfo(printerName);

        //    // Assume will work ok
        //    returnCode = true;

        //    int iStatusTries = 100;
        //    CurrentActivity currentActivity;

        //    do
        //    {
        //        System.Threading.Thread.Sleep(1000);
        //        currentActivity = printerInfo.CurrentActivity();
        //        iStatusTries--;
        //    } while ((currentActivity != CurrentActivity.CurrentActivityReady) &&
        //             (iStatusTries > 0)
        //             );


        //    // Card did not make it to encoder in reasonable time.
        //    if (iStatusTries == 0)
        //    {
        //        returnCode = false;
        //    }

        //    return (returnCode);
        //}
        //private Boolean EjectTheCard(string printerName)
        //{
        //    Boolean returnCode;
        //    Movement objMove = new Movement(printerName);

        //    // Eject the card to the last hopper.  Currently only HDP8500 has dual output hopper.
        //    objMove.MoveTo(Station.Eject, 0);

        //    // Wait for it to return to ready
        //    returnCode = PollForPrinterReady(printerName);
        //    return (returnCode);
        //}
        //private Boolean DockTheCard(string printerName)
        //{
        //    Boolean returnCode;
        //    Station targetStation;
        //    Movement objMove = new Movement(printerName);

        //    // Specify the target encoder.  5121 usually is configured for both.

        //    //targetStation = Station.MIFARE;
        //    targetStation = Station.SmartCard;

        //    // Move the card from the top input hopper to the encoder.
        //    objMove.MoveTo(targetStation, 1);

        //    // Wait for LCD to indicate encoding
        //    PrinterInfo printerInfo = new PrinterInfo(printerName);

        //    // Assume will not be ok
        //    returnCode = false;

        //    CurrentActivity currentActivity;

        //    int iStatusTries = 100;

        //    //
        //    // DTC1000/4000/4500
        //    //
        //    // DTC1000/4000/4500 does not support LCDInfo property
        //    if (printerName.Contains("DTC"))
        //    {
        //        do
        //        {
        //            System.Threading.Thread.Sleep(1000);
        //            currentActivity = printerInfo.CurrentActivity();
        //            iStatusTries--;
        //        } while (
        //                 (currentActivity != CurrentActivity.CurrentActivityException) &&
        //                 (currentActivity != CurrentActivity.CurrentActivityEncodeContact) &&
        //                 (currentActivity != CurrentActivity.CurrentActivityEncodeContactless) &&
        //                 (iStatusTries > 0)
        //                 );


        //    } // end if Neo


        //    // Check for HDP5000/HDPii
        //    else if (printerName.Contains("HDP"))
        //    {
        //        StationStatus stationStatus;
        //        do
        //        {
        //            System.Threading.Thread.Sleep(1000);
        //            stationStatus = printerInfo.StationStatus(targetStation);
        //            currentActivity = printerInfo.CurrentActivity();
        //            iStatusTries--;
        //        } while (
        //                (currentActivity != CurrentActivity.CurrentActivityException) &&
        //                (stationStatus != StationStatus.CardPresent) &&
        //                (iStatusTries > 0)
        //                );


        //        // Card did not make it to encoder in reasonable time.
        //        if ((iStatusTries != 0))
        //        {
        //            returnCode = true;
        //        }
        //    }
        //    // Unknown printer type
        //    else
        //    {
        //        currentActivity = CurrentActivity.CurrentActivityException;
        //    }

        //    if ((iStatusTries != 0) && (currentActivity != CurrentActivity.CurrentActivityException))
        //    {
        //        returnCode = true;
        //    }

        //    return (returnCode);
        //}

        //public Boolean ConnectReader(string strReader)
        //{
        //    Boolean wasConnected = false;

        //    try
        //    {
        //        //  Debug.WriteLine("Connecting to " + strReader);

        //        // If the reader is a one wire encoder then start the session between the Omnikey
        //        // service and the printer firmware.
        //        if (strReader.ToUpper().Contains("LAN"))
        //        {
        //            byte[] inBuffer = new byte[512];
        //            byte[] outBuffer = new byte[512];

        //            // Prepare a 6 second timeout
        //            uint ConnectionTimeout = 6000;
        //            inBuffer = BitConverter.GetBytes(ConnectionTimeout);

        //            // Attempt to connect the Omnikey Ethernet Driver Monitor Service to the
        //            // printer firmware and establish the connection to the card in the reader.
        //            // The "undefined" protocol type indicates to the driver that this
        //            // connection is only for purposes of sending a control code to it (no protocol
        //            // negotiation occurs)
        //            if (m_smartCardManager.Connect(strReader, SCardAccessMode.Direct, SCardProtocolIdentifiers.Undefined))
        //            {
        //                // Send a control code to the service (passes through driver) to start up the One-Wire 
        //                // session (with a timeout of 6 seconds)
        //                try
        //                {
        //                    // Control code 3410 is start session.
        //                    m_smartCardManager.Control(SmartCardManager.SmartCardManager.SCardCtlCode(3410), inBuffer, out outBuffer);
        //                }
        //                catch (Exception ex)
        //                { }

        //                // Wait for five seconds to allow the session to be established between the
        //                // one-wire service and the printer firmware.
        //                System.Threading.Thread.Sleep(5000);

        //                // Disconnect from the driver and leave the card in the reader.
        //                m_smartCardManager.Disconnect(SCardDisposition.LeaveCard);
        //            }
        //        }


        //        // Look for the reader to go NOT empty
        //        PollForEncoderNotEmpty(strReader);

        //        // Wait for the SCardConnect to be successful
        //        wasConnected = PollForEncoderConnect(strReader);

        //        //PollForInUse(strReader);

        //    }
        //    catch (System.InvalidOperationException ioEx)
        //    {
        //        //updateStatus(String.Format(Properties.Resources.SC_NoCardDetected, ioEx.Message, ioEx.InnerException));

        //    }
        //    //catch (PC_SC_Lib.SCardException sCardEx)
        //    //{
        //    //    //updateStatus(String.Format(Properties.Resources.SC_NoCardDetected, sCardEx.Message, sCardEx.InnerException));
        //    //}
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{0} {1}", ex.InnerException, ex.Message);
        //    }

        //    return (wasConnected);
        //    //return mSCResMgr;

        //}
        //private bool PollForEncoderConnect(string strReader)
        //{
        //    bool bPresent = false;
        //    int iConnectTries = 100;

        //    //Debug.WriteLine("Start looking for Connect");

        //    // Attempt to connect to the driver with both T0 and T1 protocols. (shared)
        //    do
        //    {
        //        System.Threading.Thread.Sleep(100);

        //        bPresent = m_smartCardManager.Connect(strReader, SCardAccessMode.Shared, SCardProtocolIdentifiers.T1 | SCardProtocolIdentifiers.T0);
        //        iConnectTries--;

        //        Debug.WriteLine("Attempting Connect: bPresent = " + bPresent.ToString() + " retrys left:" + iConnectTries.ToString());
        //    } while ((!bPresent) && (iConnectTries != 0));

        //    Debug.WriteLine("End Attempting Connect: bPresent = " + bPresent.ToString() + " retrys left:" + iConnectTries.ToString());

        //    return (bPresent);
        //}
        //private bool PollForEncoderNotEmpty(string strReader)
        //{
        //    // Create a state that hopefully the reader will be in when connect occurs.
        //    SCStateInfo StateInfo = new SCStateInfo();
        //    StateInfo.sReaderName = strReader;
        //    StateInfo.nCurrentState = SCStates.Unknown;
        //    StateInfo.nEventState = SCStates.Unknown;

        //    int iTotalStatusTries = 0;

        //    Debug.WriteLine("Start looking for Empty");

        //    // 10 seconds of looking for Empty to go false
        //    int iStatusTries = 100;
        //    do
        //    {
        //        System.Threading.Thread.Sleep(100);

        //        // Get the status of the card within the reader.
        //        m_smartCardManager.GetStatusChange(1000, ref StateInfo);

        //        iTotalStatusTries++;
        //        iStatusTries--;

        //        Debug.WriteLine("Polling For Empty: nEventState = " + StateInfo.nEventState.ToString("x") + " retrys left:" + iStatusTries.ToString());
        //    } while (((StateInfo.nEventState & SCStates.Empty) == SCStates.Empty) && iStatusTries >= 0);

        //    // Return true if not timed out
        //    return (iStatusTries != 0);
        //}


        //#endregion
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                