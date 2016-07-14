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
using System.Management;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using persoRCDU;
using System.Runtime.InteropServices;
using ClientRuntime;

namespace RCProject
{
    public partial class SingleCardPrinting : Form
    {
        int hcontext;
        uint SChandle;
        uint scproto;
        //char flag;
        string ChipSerialNo = string.Empty;
        string VehicleRegNo = string.Empty;
        string AutoID = string.Empty;
        string vehicleType = string.Empty;
        DataSinglePrint dataSinglePrint = new DataSinglePrint();

        public SingleCardPrinting()
        {
            InitializeComponent();
        }

        public SingleCardPrinting(string vehcileRegNo,string autoID)
        {
            VehicleRegNo = vehcileRegNo;
            AutoID = autoID;
            InitializeComponent();
        }

        public void Print()
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                if (dataSinglePrint.GetVehicleTypeOfRCRecordForReport(VehicleRegNo, AutoID) != null)
                {
                    string vehicleType = dataSinglePrint.GetVehicleTypeOfRCRecordForReport(VehicleRegNo, AutoID).ToString();
                    if (vehicleType == "T" || vehicleType == "N")
                    {
                        vehicleType = dataSinglePrint.GetVehicleTypeOfRCRecordForReport(VehicleRegNo, AutoID).ToString();
                        if (vehicleType.Equals("T"))
                            //cryRpt.Load(ConnectionDetails.CurrentDirectory + "RC VEHICLE IMAGES\\RC_CARD_T.rpt");
                            //cryRpt.Load(@"C:\RC Required\RC Reports\RC_CARD_T.rpt");
                            cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\RC_CARD_T.rpt");

                        else if (vehicleType.Equals("N"))
                            //cryRpt.Load(ConnectionDetails.CurrentDirectory + "RC VEHICLE IMAGES\\RC_CARD_NT.rpt");
                            //cryRpt.Load(@"C:\RC Required\RC Reports\RC_CARD_NT.rpt");
                            cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\RC_CARD_NT.rpt");

                        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                        ConnectionInfo connectionInfo = new ConnectionInfo();
                        Tables CrTables;

                        connectionInfo.ServerName = ConnectionDetails.DSN;
                        connectionInfo.DatabaseName = ConnectionDetails.DatabaseName;
                        connectionInfo.UserID = ConnectionDetails.UserID;
                        connectionInfo.Password = ConnectionDetails.Password;

                        CrTables = cryRpt.Database.Tables;
                        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                        {
                            crtableLogoninfo = CrTable.LogOnInfo;
                            crtableLogoninfo.ConnectionInfo = connectionInfo;
                            CrTable.ApplyLogOnInfo(crtableLogoninfo);
                        }

                        BusinessHelper.IP = Common.IP;
                        BusinessHelper.Port = Common.Port;
                        BusinessHelper.CommType = Common.CommType;
                        string IsEmptyPrinter = BusinessHelper.SendCommand(cbxPrinters.Text, "Se", "5000");
                        if (IsEmptyPrinter == "OK")
                        {
                            cryRpt.RecordSelectionFormula = "{RC_CASH.VEHREGNO} = \"" + VehicleRegNo + "\" and {RC_CASH.AUTOID} = " + AutoID;
                            cryRpt.Refresh();
                            cryRpt.PrintOptions.PrinterName = cbxPrinters.Text;
                            cryRpt.PrintToPrinter(1, true, 1, 2);
                            System.Threading.Thread.Sleep(26500);
                            cryRpt.Close();
                        }
                        ChipSerialNo = null;
                        if (!UpdateFlagInRC_CashPrintandChipWrite(ChipSerialNo))
                        {
                            Common.MessageBoxSuccess("Something wrong when trying to Update RC_cash table after single Card Printing");
                            return;
                        }
                        else
                        {
                            Common.MessageBoxSuccess("Successfully Print");
                        }
                    }
                    else
                    {
                        Common.MessageBoxError("Vehicle Type = '" + vehicleType + "' is incorrect for autoid = '" + AutoID + "' and vehregno = '" + VehicleRegNo + "'");
                        btnPrint.Text = "Print";
                    }
                }
                else
                {
                    Common.MessageBoxError("Vehicle Type is missing for autoid = '" + AutoID + "' and vehregno = '" + VehicleRegNo + "'");
                    btnPrint.Text = "Print";
                }
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message);
            }
        }

        private bool UpdateFlagInRC_CashPrintandChipWrite(string chipSerialNo)
        {
            return dataSinglePrint.InsertDetailsForPrintedRCRecords(AutoID, VehicleRegNo, vehicleType, LoggedInUser.userName, 1, chipSerialNo);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxPrinters.SelectedIndex != -1)
                {

                    if (!cbxPrinters.Text.Contains("Evolis Primacy"))
                    {
                        DialogResult result = MessageBox.Show("Are you sure print this Card on another printers",
                            "Important Notice", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            btnPrint.Text = "Please Wait";
                            Print();
                        }

                    }
                    else
                    {
                        btnPrint.Text = "Please Wait";
                        Print();
                    }
                }
                else
                {
                    Common.MessageBoxError("Select a printer First");
                }
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.ToString());
            }
        }

        private void SingleCardPrinting_Load(object sender, EventArgs e)
        {
            try
            {
                bindPrinterlist();
                bindReaderlist();
                showRCDetails();
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
                persoRCDU.SMARTCARDHELPER objSCHELPER = new persoRCDU.SMARTCARDHELPER();
                List<string> strreaderList = new List<string>();
                hcontext = 0;
                string strErrorMSg = string.Empty;
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

        private void showRCDetails()
        {
            try
            {

                DataTable dt = dataSinglePrint.GetRCRecordsForPrinting(VehicleRegNo, AutoID);
                if (dt.Rows.Count > 0)
                {

                    txtTransactionType.Text = dt.Rows[0]["TRN_TY"].ToString();
                    txtVehicleType.Text = dt.Rows[0]["VEHICLE_TYPE"].ToString();

                    //VehicleParticulars
                    txtRegisterationNo.Text = dt.Rows[0]["VEHREGNO"].ToString();
                    txtModelNumber.Text = dt.Rows[0]["MODELNO"].ToString();
                    txtManufacturerName.Text = dt.Rows[0]["MANUFACTURER"].ToString();
                    txtRegistrationDate.Text = dt.Rows[0]["REGDATE"].ToString();
                    txtRegistrationValidity.Text = dt.Rows[0]["REGNVALIDITY"].ToString();
                    txtIssuingAuthorityID.Text = dt.Rows[0]["APPROVINGAUTH"].ToString();
                    txtTaxPaidUpto.Text = dt.Rows[0]["TAXPAIDUPTO"].ToString();
                    txtOwnerName.Text = dt.Rows[0]["OWNERNAME"].ToString();
                    txtSDWOf.Text = dt.Rows[0]["FNAME"].ToString();
                    txtAddress.Text = dt.Rows[0]["CADDRESS"].ToString();



                    //DETAILS

                    //Vehicle Details
                    txtColour.Text = dt.Rows[0]["COLOUR"].ToString();
                    txtFuel.Text = dt.Rows[0]["FUEL"].ToString();
                    txtVehicleClass.Text = dt.Rows[0]["VEHCLASS"].ToString();
                    txtBodyType.Text = dt.Rows[0]["BODYTYPE"].ToString();
                    txtSeatingCapacity.Text = dt.Rows[0]["SEATCAP"].ToString();
                    txtManufactureDate.Text = dt.Rows[0]["MANUFDATE"].ToString();
                    txtUnladenWeight.Text = dt.Rows[0]["UNLADENWT"].ToString();
                    txtCubicCapacity.Text = dt.Rows[0]["CUBICCAP"].ToString();
                    txtWheelBase.Text = dt.Rows[0]["WHEELBASE"].ToString();
                    txtNoOfCylinders.Text = dt.Rows[0]["NOOFCYLIN"].ToString();
                    txtOwnerSerial.Text = dt.Rows[0]["OWNERSERIAL"].ToString();


                    //Hypothecation Details
                    txtFinancerName.Text = dt.Rows[0]["FINNAME"].ToString();
                    txtFinancerAddress.Text = dt.Rows[0]["FINADDRESS"].ToString();
                    txtHypoFrom.Text = dt.Rows[0]["HYPOFROM"].ToString();
                    txtHypoTo.Text = dt.Rows[0]["HYPOTO"].ToString();


                    //NOC Details
                    txtNOCNo.Text = dt.Rows[0]["NOCNO"].ToString();
                    txtNCRBClearanceNo.Text = dt.Rows[0]["NCRBCLEARNO"].ToString();
                    txtNOCIssueDate.Text = dt.Rows[0]["NOCISSUEDT"].ToString();
                    txtStateTo.Text = dt.Rows[0]["STATETO"].ToString();
                    txtRTOTo.Text = dt.Rows[0]["DRTOCODE"].ToString();


                    //Insurance Details
                    txtInsuranceCompanyName.Text = dt.Rows[0]["INSCOMPNAME"].ToString();
                    txtCoverPolicyNo.Text = dt.Rows[0]["COVERPOLICYNO"].ToString();
                    txtInsuranceValidUpto.Text = dt.Rows[0]["INSVALIDUPTO"].ToString();
                    txtInsuranceType.Text = dt.Rows[0]["INSTYPE"].ToString();


                    //Fitness Details
                    txtFitnessValidityDate.Text = dt.Rows[0]["FITVALIDUPTO"].ToString();
                    txtFitnessOfficerCode.Text = dt.Rows[0]["FITINSOFFICER"].ToString();
                    txtFitnessLocation.Text = dt.Rows[0]["FITLOCATION"].ToString();


                    //PUC Details
                    txtPUCCenterCode.Text = dt.Rows[0]["PUCCENTERCODE"].ToString();
                    txtPUCValidationUpto.Text = dt.Rows[0]["PUCVALIDUPTO"].ToString();


                    //Tax Payment Details
                    txtTaxAmount.Text = dt.Rows[0]["TAXAMOUNT"].ToString();
                    txtFine.Text = dt.Rows[0]["FINE"].ToString();
                    txtExemptionReceiptNo.Text = dt.Rows[0]["EXEMPTRECPTNO"].ToString();
                    txtPaymentDate.Text = dt.Rows[0]["PAYMENTDT"].ToString();
                    txtTaxValidFrom.Text = dt.Rows[0]["TAXVALIDFROM"].ToString();
                    txtTaxValidTo.Text = dt.Rows[0]["TAXVALIDTO"].ToString();
                    txtExemption.Text = dt.Rows[0]["EXEMPTION"].ToString();
                    txtDRTOCode.Text = dt.Rows[0]["DRTOCODE"].ToString();
                    txtBackendUpdateFlag.Text = dt.Rows[0]["BUFLAG"].ToString();


                    //Additional Details
                    txtGrossVehicleWeight.Text = dt.Rows[0]["GROSSVEHWT"].ToString();
                    txtNumOfSemiTrailer.Text = dt.Rows[0]["SEMITRAILERS"].ToString();

                    if (dt.Rows[0]["AXLEINFO"].ToString().Length >= 6)
                    txtFrontAxle.Text = dt.Rows[0]["AXLEINFO"].ToString().Substring(0, 6);
                    if (dt.Rows[0]["AXLEINFO"].ToString().Length >= 12)
                        txtRearAxle.Text = dt.Rows[0]["AXLEINFO"].ToString().Substring(6, 6);
                    if (dt.Rows[0]["AXLEINFO"].ToString().Length >= 18)
                        txtTandemAxle.Text = dt.Rows[0]["AXLEINFO"].ToString().Substring(12, 6);
                    if (dt.Rows[0]["AXLEINFO"].ToString().Length == 24)
                        txtAnyOtherAxle.Text = dt.Rows[0]["AXLEINFO"].ToString().Substring(18, 6);
                }
                else
                {
                    Common.MessageBoxError("No Records Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxReaders.SelectedIndex != -1)
                {
                    VEHICLE_PERSONAL_REGESTARTION_DATA obj = new VEHICLE_PERSONAL_REGESTARTION_DATA();
                    GetRecordsRC_Cash objGetRc_Cash = new GetRecordsRC_Cash();
                    DataTable objHoldVehicleRecords = objGetRc_Cash.GetRecords(VehicleRegNo, AutoID);
                    PersoCardAssignData ObjCardAssignData=new PersoCardAssignData();
                    string ReturnMessage=string.Empty;
                   
                    ObjCardAssignData.PersoCard(objHoldVehicleRecords,cbxReaders.Text,hcontext,cbxPrinters.Text,ref ReturnMessage,true,ref ChipSerialNo);
                    if (ReturnMessage == "0:SUCESS")
                    {
                        if (UpdateFlagInRC_CashPrintandChipWrite(ChipSerialNo))
                            Common.MessageBoxSuccess(ReturnMessage);
                        else
                            Common.MessageBoxError("Chip Written Successfully but Something Wrong when Trying to Update in Database");
                    }
                    else
                        Common.MessageBoxError(ReturnMessage);
                }
                else               
                    Common.MessageBoxNone("Select a Reader First");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void btnPersonalization_Click(object sender, EventArgs e)
        {
            CardPersonalization cp = new CardPersonalization();
            cp.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

