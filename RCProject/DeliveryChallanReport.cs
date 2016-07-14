using BAL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.Management;

namespace RCProject
{
    public partial class DeliveryChallanReport : Form
    {
        DMLSql dMLSql;
        public DeliveryChallanReport()
        {
            dMLSql = new DMLSql();
            InitializeComponent();
        }

        private void DeliveryChallanReport_Load(object sender, EventArgs e)
        {
            try
            {
                cbxChallanNo.SelectedIndex = 0;

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string selectionFormula = string.Empty;
                if (dtpFrom.Value.Date <= dtpTo.Value.Date)
                {
                    if (cbxPrinters.SelectedIndex != -1)
                    {
                        ReportDocument cryRpt = new ReportDocument();
                        cryRpt.Load(Environment.CurrentDirectory + @"\RC Required\RC Reports\Delivery Challan.rpt");
                        if (cbxChallanNo.SelectedIndex == 0)
                        {
                            selectionFormula = "not isnull({RC_CASH.challan_no}) and ({RC_CASH.challan_datetime}>=Date ("
                                + dtpFrom.Value.Year + ","
                                + dtpFrom.Value.Month + ","
                                + dtpFrom.Value.Day + ") and {RC_CASH.challan_datetime}<=Date ("
                                + dtpTo.Value.Year + ","
                                + dtpTo.Value.Month + ","
                                + dtpTo.Value.Day +
                                "))";
                        }
                        else
                        {
                            selectionFormula = "not isnull({RC_CASH.challan_no}) and ({RC_CASH.challan_datetime}>=Date ("
                                + dtpFrom.Value.Year + ","
                                + dtpFrom.Value.Month + ","
                                + dtpFrom.Value.Day + ") and {RC_CASH.challan_datetime}<=Date ("
                                + dtpTo.Value.Year + ","
                                + dtpTo.Value.Month + ","
                                + dtpTo.Value.Day +
                                ")) and {RC_CASH.challan_no}='" + cbxChallanNo.Text +"'";
                        }

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
                        cryRpt.Refresh();
                        cryRpt.PrintOptions.PrinterName = cbxPrinters.SelectedValue.ToString();
                        cryRpt.PrintOptions.PaperSize = PaperSize.PaperA4;
                        cryRpt.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
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
                    Common.MessageBoxError("'From Date' cannot be greater than 'To Date'");
                }
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxChallanNo_DropDown(object sender, EventArgs e)
        {
            try
            {
                DataTable dtChallanNo = new DataTable();
                string query = "select distinct CHALLAN_NO from RC_CASH where cast(CHALLAN_DATETIME as date) >= '"
                                + dtpFrom.Value.ToString("dd-MMM-yyyy") +
                                "' and cast(CHALLAN_DATETIME as date) <= '"
                                + dtpTo.Value.ToString("dd-MMM-yyyy") +
                                "' and CHALLAN_NO is not null";
                dtChallanNo = dMLSql.GetRecords(query, CommandType.Text);
                cbxChallanNo.Items.Clear();
                cbxChallanNo.Items.Insert(0, "ALL");
                cbxChallanNo.SelectedIndex = 0;
                for (int i = 0; i < dtChallanNo.Rows.Count; i++)
                {
                    cbxChallanNo.Items.Insert(i + 1, dtChallanNo.Rows[i]["CHALLAN_NO"].ToString());
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
