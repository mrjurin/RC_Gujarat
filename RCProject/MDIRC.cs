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
using System.Data.SqlClient;

namespace RCProject
{
    public partial class MDIRC : Form
    {
        
        Timer timer1;
        public MDIRC()
        {
            timer1 = new Timer();
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIRC_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Press OK if you want to EXIT", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    User user = new User();
                    DateTime logoutDateTime = DateTime.Now;
                    int logoutStatus = 0;

                    Application.ExitThread();
                    user.InsertLogoutDetails(LoggedInUser.userName, LoggedInUser.computerName, LoggedInUser.loginStatus, logoutStatus);
                }

                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void validationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string errors = CheckRequiredVehicleImagesAndAuthoritySignatures();
                if (!Common.ValidateStringValue(errors))
                {
                    Validation validation = new Validation();
                    validation.MdiParent = this;
                    validation.Show();
                }
                else
                {
                    Common.MessageBoxError(errors);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void createChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ChallanNo objChallanNo = new ChallanNo();
            //if (Convert.ToInt32(objChallanNo.GetChallanNo()) > 0)
            //{
                CreateChallan createChallan = new CreateChallan();
                createChallan.MdiParent = this;
                createChallan.Show();
            //}
            //else
            //{
            //    Common.MessageBoxError("No Records found For Challan No");
             
            //}
        }

        private void importFlatFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFlatFile importFlatFile = new ImportFlatFile();
            importFlatFile.MdiParent = this;
            importFlatFile.Show();
        }

        private void bulkPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string errors = CheckRequiredVehicleImagesAndAuthoritySignatures();
                if (!Common.ValidateStringValue(errors))
                {
                    DataBulkPrint dataBulkPrint = new DataBulkPrint();
                    DataTable dt = new DataTable();
                    dt = dataBulkPrint.GetBatchesForBulkPrinting();
                    if (dt.Rows.Count > 0)
                    {
                        BulkPrinting bulkPrinting = new BulkPrinting();
                        bulkPrinting.MdiParent = this;
                        bulkPrinting.Show();
                    }
                    else
                    {
                        Common.MessageBoxError("No Batches found for Bulk Printing");
                    }
                }
                else
                {
                    Common.MessageBoxError(errors);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void readCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReadCard rc = new ReadCard();
            //rc.MdiParent = this;
            //rc.Show();
        }

        private void rejectCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RejectCard rc = new RejectCard();
            rc.MdiParent = this;
            rc.Show();
        }

        private void userRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            userRegistration.MdiParent = this;
            userRegistration.Show();
        }

        private void manageRCVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRCVehicle manageRCVehicle = new ManageRCVehicle();
            manageRCVehicle.MdiParent = this;
            manageRCVehicle.Show();
        }

        private void issuingAuthoritySignatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssuingAuthoritySignature issuingAuthoritySignature = new IssuingAuthoritySignature();
            issuingAuthoritySignature.MdiParent = this;
            issuingAuthoritySignature.Show();
        }

        private void singleCardPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string errors = CheckRequiredVehicleImagesAndAuthoritySignatures();
                if (!Common.ValidateStringValue(errors))
                {
                    CardPersonalization cardPersonalization = new CardPersonalization();
                    cardPersonalization.MdiParent = this;
                    cardPersonalization.Show();
                }
                else
                {
                    Common.MessageBoxError(errors);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void reprintCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDIRC_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.WindowState = FormWindowState.Maximized;
                this.Text += "     User: " + LoggedInUser.userName + "     RTO Location: " + LoggedInUser.rtoLocation + "     RTO Code: " + LoggedInUser.rtoCode;

                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 900000;
                timer1.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void challanReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryChallanReport deliveryChallanReport = new DeliveryChallanReport();
            deliveryChallanReport.MdiParent = this;
            deliveryChallanReport.Show();
        }

        private void cardStatusReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardStatusReport cardStatusReport = new CardStatusReport();
            cardStatusReport.MdiParent = this;
            cardStatusReport.Show();
        }

        private void dailyCardGeneratedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyCardGenerated dailyCardGenerated = new DailyCardGenerated();
            dailyCardGenerated.MdiParent = this;
            dailyCardGenerated.Show();
        }

        private string CheckRequiredVehicleImagesAndAuthoritySignatures()
        {
            try
            {

                RCVehicle rCVehicle = new RCVehicle();
                IssueAuthority issueAuthority = new IssueAuthority();
                MappingTables mappingTables = new MappingTables();
                DataTable dt;
                string errors = string.Empty;

                dt = new DataTable();
                // To check whether to add any code in MAPPING_VEH_CLASS table
                dt = rCVehicle.GetRCVehicleCodesToBeAdded();

                if (dt.Rows.Count > 0)
                    errors = "First add required RC Vehicle Codes.\n";
                else
                {
                    dt = rCVehicle.GetRCVehicleCodesForAddingImage();

                    if (dt.Rows.Count > 0)
                        errors = "First add required RC Vehicle Images.\n";
                }

                dt = new DataTable();
                dt = issueAuthority.GetIssueAuthorityCodesToBeAdded();

                if (dt.Rows.Count > 0)
                    errors += "First add required Issuing Authority Codes.\n";
                else
                {
                    dt = issueAuthority.GetIssueAuthorityCodesForAddingSignature();

                    if (dt.Rows.Count > 0)
                        errors += "First add required Issuing Authority Signature.";
                }

                //dtRejectCard = new DataTable();
                //dtRejectCard = mappingTables.GetRCBodytypeCodesAndDescriptionToBeAddedInMappingTable();

                //if (dtRejectCard.Rows.Count > 0)
                //{
                //    errors += "First add following Bodytype Codes with description in table MAPPING_BODYTYPE.\n";
                //    for (int i = 0; i < dtRejectCard.Rows.Count; i++)
                //    {
                //        errors += "\"" + dtRejectCard.Rows[i]["BODYTYPE"].ToString().Trim() + "\"\n";
                //    }
                //}

                //dtRejectCard = new DataTable();
                //dtRejectCard = mappingTables.GetRCFuelCodesAndDescriptionToBeAddedInMappingTable();

                //if (dtRejectCard.Rows.Count > 0)
                //{
                //    errors += "First add following Fuel Codes with description in table MAPPING_FUEL.\n";
                //    for (int i = 0; i < dtRejectCard.Rows.Count; i++)
                //    {
                //        errors += "\"" + dtRejectCard.Rows[i]["FUEL"].ToString().Trim() + "\"\n";
                //    }
                //}

                //dtRejectCard = new DataTable();
                //dtRejectCard = mappingTables.GetRCMakerCodesAndDescriptionToBeAddedInMappingTable();

                //if (dtRejectCard.Rows.Count > 0)
                //{
                //    errors += "First add following Maker/Manufacturer Codes with description in table MAPPING_MAKER.\n";
                //    for (int i = 0; i < dtRejectCard.Rows.Count; i++)
                //    {
                //        errors += "\"" + dtRejectCard.Rows[i]["MANUFACTURER"].ToString().Trim() + "\"\n";
                //    }
                //}

                return errors;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void makerMissMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakerMissMatch makerMissMatch = new MakerMissMatch();
            makerMissMatch.MdiParent = this;
            makerMissMatch.Show();
        }

        private void bodytypeMissMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BodytypeMissMatch bodytypeMissMatch = new BodytypeMissMatch();
            bodytypeMissMatch.MdiParent = this;
            bodytypeMissMatch.Show();
        }

        private void fuelMissMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuelMissMatch fuelMissMatch = new FuelMissMatch();
            fuelMissMatch.MdiParent = this;
            fuelMissMatch.Show();
        }

        private void searchStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchStatus searchStatus = new SearchStatus();
            searchStatus.MdiParent = this;
            searchStatus.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Stop();
            SyncRecords();
        }

        private int SyncRecords()
        {
            try
            {
                DMLSql dmlsql = new DMLSql();
                //Procedure to sync NICTABLE
                string query = "InsertNicTable";
                SqlParameter[] sqlParameter = { };

                return dmlsql.ExecuteNonquery(query, sqlParameter, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
