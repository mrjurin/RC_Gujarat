using BAL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace RCProject
{
    public partial class CardStatusReport : Form
    {
        DMLSql dMLSql;

        public CardStatusReport()
        {
            dMLSql = new DMLSql();
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                bool isChecked = false;
                string selectionFormula = string.Empty;
                string formula1 = string.Empty;
                string formula2 = string.Empty;
                string formulaVehClass = string.Empty;
                if (dtpFrom.Value.Date <= dtpTo.Value.Date)
                {
                    foreach(RadioButton rb in grpReportOptions.Controls)
                    {
                        if (rb.Checked)
                            isChecked = true;
                    }
                    if (isChecked)
                    {
                        if(cbxVehicleClass.SelectedIndex == 0)
                            formulaVehClass = "";
                        else
                            formulaVehClass = " and {RC_CASH.vehclass}='"+cbxVehicleClass.SelectedText+"'";
                        if (cbxPrinters.SelectedIndex != -1)
                        {
                            ReportDocument cryRpt = new ReportDocument();
                            formula2 = "'FROM : " + dtpFrom.Value.Date.ToString("dd-MM-yyyy") + "      TO : " + dtpTo.Value.Date.ToString("dd-MM-yyyy") + "      VEHICLE CLASS : "+cbxVehicleClass.Text+"'";  
                            if (rdoBtnRejectedCards.Checked)
                            {
                                cryRpt.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                                cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\REJECTED CARDS.rpt");
                                selectionFormula = "{REJECTCARD.REJECT_DATETIME}>=Date ("
                                    + dtpFrom.Value.Year + ","
                                    + dtpFrom.Value.Month + ","
                                    + dtpFrom.Value.Day + ") and {REJECTCARD.REJECT_DATETIME}<=Date ("
                                    + dtpTo.Value.Year + ","
                                    + dtpTo.Value.Month + ","
                                    + dtpTo.Value.Day +
                                    ")";
                                formula1 = "'Rejected Cards Report(RC)'";
                            }
                            else
                            {
                                cryRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                                cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\Status.rpt");
                                if (rdoBtnFlatFileImportedButCardsNotPrinted.Checked)
                                {
                                    selectionFormula = "isnull({RC_CASH.CHIP_FLAG}) and ({RC_CASH.IMPORT_DATETIME} >= Date ("
                                    + dtpFrom.Value.Year + ","
                                    + dtpFrom.Value.Month + ","
                                    + dtpFrom.Value.Day + ") and {RC_CASH.IMPORT_DATETIME}<=Date ("
                                    + dtpTo.Value.Year + ","
                                    + dtpTo.Value.Month + ","
                                    + dtpTo.Value.Day +
                                    "))" + formulaVehClass;
                                    formula1 = "'Status Report for Flat File imported but card not printed (RC)'";
                                }
                                else if(rdoBtnCardsPrintedButChallanNotCreated.Checked)
                                {
                                    selectionFormula = "not isnull({RC_CASH.CHIP_FLAG}) and  isnull({RC_CASH.CHALLAN_NO}) and ({RC_CASH.PRINT_DATETIME}>=Date ("
                                    + dtpFrom.Value.Year + ","
                                    + dtpFrom.Value.Month + ","
                                    + dtpFrom.Value.Day + ") and {RC_CASH.PRINT_DATETIME}<=Date ("
                                    + dtpTo.Value.Year + ","
                                    + dtpTo.Value.Month + ","
                                    + dtpTo.Value.Day +
                                    "))" + formulaVehClass;
                                    formula1 = "'Status Report for cards printing (RC)'";
                                }
                                else if(rdoBtnTotalCardsPrintedWithChallan.Checked)
                                {
                                    selectionFormula = "not isnull({RC_CASH.CHIP_FLAG}) and not isnull({RC_CASH.CHALLAN_NO}) and ({RC_CASH.CHALLAN_DATETIME}>=Date ("
                                    + dtpFrom.Value.Year + ","
                                    + dtpFrom.Value.Month + ","
                                    + dtpFrom.Value.Day + ") and {RC_CASH.CHALLAN_DATETIME}<=Date ("
                                    + dtpTo.Value.Year + ","
                                    + dtpTo.Value.Month + ","
                                    + dtpTo.Value.Day +
                                    "))" + formulaVehClass;
                                    formula1 = "'Status Report for cards printing with Challan(RC)'";
                                }
                                else if(rdoBtnTotalCardsPrinted.Checked)
                                {
                                    selectionFormula = "not isnull({RC_CASH.CHIP_FLAG}) and ({RC_CASH.PRINT_DATETIME}>=Date ("
                                    + dtpFrom.Value.Year + ","
                                    + dtpFrom.Value.Month + ","
                                    + dtpFrom.Value.Day + ") and {RC_CASH.PRINT_DATETIME}<=Date ("
                                    + dtpTo.Value.Year + ","
                                    + dtpTo.Value.Month + ","
                                    + dtpTo.Value.Day +
                                    "))" + formulaVehClass;
                                    formula1 = "'Total Cards Printed (RC)'";
                                }
                            }

                            //cryRpt.Load(ConnectionDetails.CurrentDirectory + @"RC Required\RC Reports\Daily.rpt");
                            //cryRpt.Load(@"C:\RC Required\RC Reports\Daily.rpt");
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
                            cryRpt.RecordSelectionFormula = selectionFormula;
                            cryRpt.DataDefinition.FormulaFields["FORMULA1"].Text = formula1;
                            cryRpt.DataDefinition.FormulaFields["FORMULA2"].Text = formula2;
                            cryRpt.Refresh();
                            cryRpt.PrintOptions.PrinterName = cbxPrinters.Text;
                            cryRpt.PrintOptions.PaperSize = PaperSize.PaperA4;
                            cryRpt.PrintToPrinter(1, true, 0, 0);
                            cryRpt.Close();
                        }
                        else
                        {
                            Common.MessageBoxError("Select a Printer first and then Print");
                        } 
                    }
                    else
                    {
                        Common.MessageBoxError("Select a Report Option");
                    }
                }
                else
                {
                    Common.MessageBoxError("'From Date' cannot be greater than 'To Date'");
                }
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message);
            }
        }

        private void CardStatusReport_Load(object sender, EventArgs e)
        {
            try
            {
                cbxVehicleClass.SelectedIndex = 0;

                dtpFrom.Format = DateTimePickerFormat.Custom;
                dtpFrom.CustomFormat = "dd-MM-yyyy";
                dtpTo.Format = DateTimePickerFormat.Custom;
                dtpTo.CustomFormat = "dd-MM-yyyy";

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

                DataTable dtVehClass = new DataTable();
                string query = "select distinct VEHCLASS from RC_CASH";
                dtVehClass = dMLSql.GetRecords(query, CommandType.Text);
                for (int i = 0; i < dtVehClass.Rows.Count; i++)
                {
                    cbxVehicleClass.Items.Insert(i + 1, dtVehClass.Rows[i]["VEHCLASS"].ToString());
                }
                
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
