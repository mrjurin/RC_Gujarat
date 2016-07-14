using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;

namespace RCProject
{
    public partial class ImportFlatFile : Form
    {
        string flatFileName = string.Empty;
        FlatFile flatFile = new FlatFile();
        DataTable dt = new DataTable();
        string VEHREGNO = string.Empty;
        string REGDATE = string.Empty;
        string OWNERNAME = string.Empty;
        string FNAME = string.Empty;
        string CADDRESS = string.Empty;
        string MANUFACTURER = string.Empty;
        string MODELNO = string.Empty;
        string COLOUR = string.Empty;
        string FUEL = string.Empty;
        string VEHCLASS = string.Empty;
        string BODYTYPE = string.Empty;
        string SEATCAP = string.Empty;
        string STANDCAP = string.Empty;
        string MANUFDATE = string.Empty;
        string UNLADENWT = string.Empty;
        string CUBICCAP = string.Empty;
        string WHEELBASE = string.Empty;
        string NOOFCYLIN = string.Empty;
        string OWNERSERIAL = string.Empty;
        string CHASISNO = string.Empty;
        string ENGINENO = string.Empty;
        string TAXPAIDUPTO = string.Empty;
        string REGNVALIDITY = string.Empty;
        string APPROVINGAUTH = string.Empty;
        string FINNAME = string.Empty;
        string FINADDRESS = string.Empty;
        string HYPOFROM = string.Empty;
        string HYPOTO = string.Empty;
        string NOCNO = string.Empty;
        string STATETO = string.Empty;
        string RTOTO = string.Empty;
        string NCRBCLEARNO = string.Empty;
        string NOCISSUEDT = string.Empty;
        string INSCOMPNAME = string.Empty;
        string COVERPOLICYNO = string.Empty;
        string INSTYPE = string.Empty;
        string INSVALIDUPTO = string.Empty;
        string PUCCENTERCODE = string.Empty;
        string PUCVALIDUPTO = string.Empty;
        string TAXAMOUNT = string.Empty;
        string FINE = string.Empty;
        string EXEMPTRECPTNO = string.Empty;
        string PAYMENTDT = string.Empty;
        string TAXVALIDFROM = string.Empty;
        string TAXVALIDTO = string.Empty;
        string EXEMPTION = string.Empty;
        string DRTOCODE = string.Empty;
        string BUFLAG = string.Empty;
        string FITVALIDUPTO = string.Empty;
        string FITINSOFFICER = string.Empty;
        string FITLOCATION = string.Empty;
        string GROSSVEHWT = string.Empty;
        string SEMITRAILERS = string.Empty;
        string TYREINFO = string.Empty;
        string AXLEINFO = string.Empty;
        string TRN_TY = string.Empty;
        string VIZ_MIZ = string.Empty;

        public ImportFlatFile()
        {
            InitializeComponent();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.ValidateStringValue(txtFilePath.Text)&& txtFilePath.Text.Length > 4)
                {
                    dt = flatFile.CheckIfFlatFileExist(flatFileName);

                    if (dt.Rows.Count == 0)
                    {
                        importFlatFile(txtFilePath.Text, flatFileName);
                        refreshGrid(flatFile.GetImportedFlatFileRecords(flatFileName));
                    }
                    else
                    {
                        string temp=string.Empty;
                        bool success = false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bool comparedFound = false;
                            if (flatFileName.ToLower().EndsWith(".txt"))
                            {
                                int tempLength = flatFileName.Length - 4;
                                temp = flatFileName.Substring(0, tempLength) + "_" + (i + 1) + flatFileName.Substring(tempLength);
                            } 
                            if (flatFileName.ToLower().EndsWith(".dat"))
                            {
                                int tempLength = flatFileName.Length - 4;
                                temp = flatFileName.Substring(0, tempLength) + "_" + (i + 1) + flatFileName.Substring(tempLength);
                            }
                            
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                string s = dt.Rows[j]["FLATFILE_NAME"].ToString();
                                if (temp.Equals(s))
                                {
                                    comparedFound = true;
                                    break;
                                }
                            }
                            if (!comparedFound)
                            {
                                importFlatFile(txtFilePath.Text, temp);
                                success = true;
                                refreshGrid(flatFile.GetImportedFlatFileRecords(flatFileName));
                                Common.MessageBoxSuccess("Flat file updated successfully");
                                break;
                            }
                        }
                        if (!success)
                        {
                            refreshGrid(flatFile.GetImportedFlatFileRecords(flatFileName));
                            Common.MessageBoxError("Flat file already exists and no records imported Now");
                        }
                    }
                }
                else
                    Common.MessageBoxNone("First browse and select a flat file.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                // Create OpenFileDialog 
                OpenFileDialog openfileDialog = new OpenFileDialog();


                openfileDialog.InitialDirectory = openFileDialog1.FileName;
                openfileDialog.Filter = "Text Files,DAT Files (*.txt, *.dat)|*.txt;*.dat";
                openfileDialog.Title = "Please select a flat file to import.";


                // Display OpenFileDialog by calling ShowDialog method 
                DialogResult result = openfileDialog.ShowDialog();


                // Get the selected file name and display in a TextBox 
                if (result == DialogResult.OK)
                {
                    // Open document 
                    txtFilePath.Text = openfileDialog.FileName;
                    flatFileName = openfileDialog.SafeFileName;
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

        private void importFlatFile(string filepath, string flatFileName)
        {
            try
            {
                bool error = false;
                int importedNow = 0;
                int allImported = 0;
                flatFile = new FlatFile();
                String[] lines = File.ReadAllLines(@"" + filepath);
                int index = 0;
                int errorLine = 0;
                try
                {
                    foreach (string line in lines)
                     {
                        if (index <= lines.Length)
                        {
                            index++;
                            if (line.ToString().Length >= 10)
                                VEHREGNO = line.Substring(0, 10).Trim();
                            if (line.ToString().Length >= 18)
                                REGDATE = line.Substring(10, 8).Trim();
                            if (line.ToString().Length >= 53)
                                OWNERNAME = line.Substring(18, 35).Trim();
                            if (line.ToString().Length >= 88)
                                FNAME = line.Substring(53, 35).Trim();
                            if (line.ToString().Length >= 224)
                                CADDRESS = line.Substring(88, 136).Trim();
                            if (line.ToString().Length >= 230)
                                MANUFACTURER = line.Substring(224, 6).Trim();
                            if (line.ToString().Length >= 260)
                                MODELNO = line.Substring(230, 30).Trim();
                            if (line.ToString().Length >= 275)
                                COLOUR = line.Substring(260, 15).Trim();
                            if (line.ToString().Length >= 281)
                                FUEL = line.Substring(275, 6).Trim();
                            if (line.ToString().Length >= 287)
                                VEHCLASS = line.Substring(281, 6).Trim();
                            if (line.ToString().Length >= 293)
                                BODYTYPE = line.Substring(287, 6).Trim();
                            if (line.ToString().Length >= 296)
                                SEATCAP = line.Substring(293, 3).Trim();
                            if (line.ToString().Length >= 298)
                                STANDCAP = line.Substring(296, 2).Trim();
                            if (line.ToString().Length >= 305)
                                MANUFDATE = line.Substring(298, 7).Trim();
                            if (line.ToString().Length >= 311)
                                UNLADENWT = line.Substring(305, 6).Trim();
                            if (line.ToString().Length >= 317)
                                CUBICCAP = line.Substring(311, 6).Trim();
                            if (line.ToString().Length >= 323)
                                WHEELBASE = line.Substring(317, 6).Trim();
                            if (line.ToString().Length >= 324)
                                NOOFCYLIN = line.Substring(323, 1).Trim();
                            if (line.ToString().Length >= 326)
                                OWNERSERIAL = line.Substring(324, 2).Trim();
                            if (line.ToString().Length >= 356)
                                CHASISNO = line.Substring(326, 30).Trim();
                            if (line.ToString().Length >= 386)
                                ENGINENO = line.Substring(356, 30).Trim();
                            if (line.ToString().Length >= 394)
                                TAXPAIDUPTO = line.Substring(386, 8).Trim();
                            if (line.ToString().Length >= 402)
                                REGNVALIDITY = line.Substring(394, 8).Trim();
                            if (line.ToString().Length >= 412)
                                APPROVINGAUTH = line.Substring(402, 10).Trim();
                            if (line.ToString().Length >= 447)
                                FINNAME = line.Substring(412, 35).Trim().Trim();
                            if (line.ToString().Length >= 477)
                                FINADDRESS = line.Substring(447, 30).Trim();
                            if (line.ToString().Length >= 485)
                                HYPOFROM = line.Substring(477, 8).Trim();
                            if (line.ToString().Length >= 493)
                                HYPOTO = line.Substring(485, 8).Trim();
                            if (line.ToString().Length >= 523)
                                NOCNO = line.Substring(493, 30).Trim();
                            if (line.ToString().Length >= 525)
                                STATETO = line.Substring(523, 2).Trim();
                            if (line.ToString().Length >= 529)
                                RTOTO = line.Substring(525, 4).Trim();
                            if (line.ToString().Length >= 549)
                                NCRBCLEARNO = line.Substring(529, 20).Trim();
                            if (line.ToString().Length >= 557)
                                NOCISSUEDT = line.Substring(549, 8).Trim();
                            if (line.ToString().Length >= 592)
                                INSCOMPNAME = line.Substring(557, 35).Trim();
                            if (line.ToString().Length >= 617)
                                COVERPOLICYNO = line.Substring(592, 25).Trim();
                            if (line.ToString().Length >= 618)
                                INSTYPE = line.Substring(617, 1).Trim();
                            if (line.ToString().Length >= 626)
                                INSVALIDUPTO = line.Substring(618, 8).Trim();
                            if (line.ToString().Length >= 630)
                                PUCCENTERCODE = line.Substring(626, 4).Trim();
                            if (line.ToString().Length >= 638)
                                PUCVALIDUPTO = line.Substring(630, 8).Trim();
                            if (line.ToString().Length >= 644)
                                TAXAMOUNT = line.Substring(638, 6).Trim();
                            if (line.ToString().Length >= 650)
                                FINE = line.Substring(644, 6).Trim();
                            if (line.ToString().Length >= 661)
                                EXEMPTRECPTNO = line.Substring(650, 11).Trim();
                            if (line.ToString().Length >= 669)
                                PAYMENTDT = line.Substring(661, 8).Trim();
                            if (line.ToString().Length >= 677)
                                TAXVALIDFROM = line.Substring(669, 8).Trim();
                            if (line.ToString().Length >= 685)
                                TAXVALIDTO = line.Substring(677, 8).Trim();
                            if (line.ToString().Length >= 686)
                                EXEMPTION = line.Substring(685, 1).Trim();
                            if (line.ToString().Length >= 688)
                                DRTOCODE = line.Substring(686, 2).Trim();
                            if (line.ToString().Length >= 690)
                                BUFLAG = line.Substring(688, 2).Trim();
                            if (line.ToString().Length >= 698)
                                FITVALIDUPTO = line.Substring(690, 8).Trim();
                            if (line.ToString().Length >= 714)
                                FITINSOFFICER = line.Substring(698, 16).Trim();
                            if (line.ToString().Length >= 730)
                                FITLOCATION = line.Substring(714, 16).Trim();
                            if (line.ToString().Length >= 736)
                                GROSSVEHWT = line.Substring(730, 6).Trim();
                            if (line.ToString().Length >= 738)
                                SEMITRAILERS = line.Substring(736, 2).Trim();
                            if (line.ToString().Length >= 802)
                                TYREINFO = line.Substring(738, 64).Trim();
                            if (line.ToString().Length >= 826)
                                AXLEINFO = line.Substring(802, 24).Trim();
                            if (line.ToString().Length >= 846)
                                TRN_TY = line.Substring(826, 20).Trim();

                            if (line.ToString().Length >= 846 && line.ToString().Length <= 880)
                            {
                                allImported++;
                                if (!Common.ValidateStringValue(flatFile.CheckWhetherVehicleRecordExist(VEHREGNO, OWNERSERIAL, TRN_TY)))
                                {
                                    importedNow++; 
                                    flatFile.InsertRCRecords(VEHREGNO, REGDATE, OWNERNAME, FNAME, CADDRESS, MANUFACTURER, MODELNO, COLOUR, FUEL, VEHCLASS, BODYTYPE, SEATCAP,
                                                                STANDCAP, MANUFDATE, UNLADENWT, CUBICCAP, WHEELBASE, NOOFCYLIN, OWNERSERIAL, CHASISNO, ENGINENO, TAXPAIDUPTO,
                                                                REGNVALIDITY, APPROVINGAUTH, FINNAME, FINADDRESS, HYPOFROM, HYPOTO, NOCNO, STATETO, RTOTO, NCRBCLEARNO, NOCISSUEDT,
                                                                INSCOMPNAME, COVERPOLICYNO, INSTYPE, INSVALIDUPTO, PUCCENTERCODE, PUCVALIDUPTO, TAXAMOUNT, FINE, EXEMPTRECPTNO,
                                                                PAYMENTDT, TAXVALIDFROM, TAXVALIDTO, EXEMPTION, DRTOCODE, BUFLAG, FITVALIDUPTO, FITINSOFFICER, FITLOCATION,
                                                                GROSSVEHWT, SEMITRAILERS, TYREINFO, AXLEINFO, TRN_TY, LoggedInUser.userName);

                                    flatFile.InsertFlatFileDetails(flatFileName, VEHREGNO, LoggedInUser.userName, "Success");
                                }
                            }
                            else
                            {
                                //if (line.ToString().Length >= 10)
                                //    flatFile.InsertFlatFileDetails(flatFileName, VEHREGNO, LoggedInUser.userName, DateTime.Now, "Error");
                                errorLine++;
                                if (line.ToString().Length >= 10)
                                {
                                    string tempError = flatFile.CheckWhetherErrorVehicleRecordExist(VEHREGNO);
                                    if (Common.ValidateStringValue(tempError))
                                    {
                                        if (tempError == "Error")
                                            flatFile.InsertFlatFileDetails(flatFileName, VEHREGNO, LoggedInUser.userName, "Error_1");

                                        else if (tempError.StartsWith("Error_"))
                                        {
                                            int tempNo = Convert.ToInt32(tempError.Substring(tempError.IndexOf("_") + 1));
                                            flatFile.InsertFlatFileDetails(flatFileName, VEHREGNO, LoggedInUser.userName, "Error_" + (tempNo + 1));
                                        }
                                    }
                                    else
                                    {
                                        flatFile.InsertFlatFileDetails(flatFileName, VEHREGNO, LoggedInUser.userName, "Error");
                                    }
                                }
                                else
                                {
                                    flatFile.InsertFlatFileDetails(flatFileName, "", LoggedInUser.userName, "Error on line No: " + index);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    Common.MessageBoxError("Flat file is corrupted or in a wrong format.");
                    
                }
                if (!error)
                    Common.MessageBoxSuccess(importedNow+" Record(s) Imported");
                txtRecordsInFlatfile.Text = lines.Length.ToString();
                txtErrorRecordsInFlatFile.Text = errorLine.ToString();
                txtTotalImportedRecords.Text = allImported.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void refreshGrid(DataTable dataTable)
        {
            try
            {
                dataGridView1.Refresh();
                dt = dataTable;
                txtTotalRecordsInLog.Text = dt.Rows.Count.ToString();
                dataGridView1.DataSource = dt;
                colorGrid();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void colorGrid()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["REMARK"].Value.ToString().Contains("Success"))
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    if (row.Cells["REMARK"].Value.ToString().Contains("Error"))
                        row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colorGrid();
        }
    }
}
