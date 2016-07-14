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

namespace RCProject
{
    public partial class DailyCardGenerated : Form
    {
        public DailyCardGenerated()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFrom.Value.Date <= dtpTo.Value.Date)
                {

                    if (cbxPrinters.SelectedIndex != -1)
                    {
                        ReportDocument cryRpt = new ReportDocument();
                        cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\Daily.rpt");
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

                        string selectionFormula = "";
                        //selectionFormula = "{RC_CASH.PRINT_DATETIME}>=#" + dtpDateFrom.Text + "# and {RC_CASH.PRINT_DATETIME}<= #" + dtpDateTo.Text + "#";
                        //selectionFormula = "{RC_CASH.PRINT_DATETIME}>=Date (2015,05,01) and {RC_CASH.PRINT_DATETIME}<=Date (2016,06,20) and not isnull({RC_CASH.PRINT_FLAG})";
                        selectionFormula = "{RC_CASH.PRINT_DATETIME} >= Date ("
                            + dtpFrom.Value.Year + ","
                            + dtpFrom.Value.Month + ","
                            + dtpFrom.Value.Day + ") and {RC_CASH.PRINT_DATETIME}<=Date ("
                            + dtpTo.Value.Year + ","
                            + dtpTo.Value.Month + ","
                            + dtpTo.Value.Day +
                            ") and not isnull({RC_CASH.PRINT_FLAG})";
                        cryRpt.RecordSelectionFormula = selectionFormula;
                        cryRpt.DataDefinition.FormulaFields["FORMULA1"].Text = "'DAILY CARD PRINTING REPORT'";
                        cryRpt.DataDefinition.FormulaFields["FORMULA2"].Text = "'FROM : " + dtpFrom.Value.Date.ToString("dd-MM-yyyy") + "      TO : " + dtpTo.Value.Date.ToString("dd-MM-yyyy") + "'";
                        cryRpt.Refresh();
                        cryRpt.PrintOptions.PrinterName = cbxPrinters.SelectedValue.ToString();
                        cryRpt.PrintOptions.PaperSize = PaperSize.PaperA4;
                        cryRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                        cryRpt.PrintToPrinter(1, true, 0, 0);
                        cryRpt.Close();
                    }
                    else
                    {
                        Common.MessageBoxError("Select a Printer and then Print");
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

        private void DailyCardGenerated_Load(object sender, EventArgs e)
        {
            try
            {

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
