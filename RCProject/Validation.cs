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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace RCProject
{
    public partial class Validation : Form
    {
        Validate validate = new Validate();
        MappingTables mappingTables = new MappingTables();
        RCVehicle rCVehicle = new RCVehicle();
        DataTable dt;
        DMLSql dmlsql;
        bool skipBatch = false;

        int countNumber = 0;

        public Validation()
        {
            dmlsql = new DMLSql();
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            int vehCount = 0;
            string query = "select count(*) as vehicleCount from rc_cash where ISNULL(VEHICLE_TYPE,'') = ''";
            SqlParameter[] sqlParameter = null;
            vehCount = Convert.ToInt32(dmlsql.GetSingleRecord(query, sqlParameter, CommandType.Text));
            if(vehCount > 0)
            {
                Common.MessageBoxError("Validate vehicle type first pending records:" + vehCount);
            }
            else
            {
                loadValidationData(validate.GetDataForValidation(cbxDatewise.SelectedItem.ToString(),
                cbxVehicleClass.SelectedItem.ToString(), cbxVehicleType.SelectedItem.ToString(), cbxTransactionType.SelectedItem.ToString()));
                batchReload();
            }

        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!skipBatch)
                {
                    DataGridViewRowCollection Rows = dataGridView1.Rows;

                    if (Rows.Count > 0)
                    {
                        bool IsCheckedRecordsSelect = false;
                        string autoid = string.Empty;

                        int Records = 0;
                        for (int i = 0; i < Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(Rows[i].Cells[0].Value) == true)
                            {
                                autoid = Rows[i].Cells["AUTOID"].Value.ToString();

                                IsCheckedRecordsSelect = true;
                                int TempRecords = 0;
                                TempRecords = validate.ValidateRCRecords(autoid);

                                if (TempRecords > 0)
                                {
                                    validate.InsertValidatedRCRecordsDetails(txtBatchNo.Text, autoid, LoggedInUser.userName, "Validated");
                                    Records += TempRecords;
                                }
                                else
                                {
                                    validate.InsertValidatedRCRecordsDetails(txtBatchNo.Text, autoid, LoggedInUser.userName, "NotValidated");
                                }
                            }
                        }

                        // Check wether any RC record(s) are selected for validation or not..
                        if (IsCheckedRecordsSelect == true)
                        {
                            if (Records > 0)
                            {
                                validate = new Validate();
                                validate.InsertBatchRecords(txtBatchNo.Text, Records);
                                //loadValidationData(validate.GetDataForValidation());
                                Common.MessageBoxSuccess("Validated " + Records + " record(s) successfully");
                                loadValidationData(validate.GetDataForValidation(cbxDatewise.SelectedItem.ToString(),
                                cbxVehicleClass.SelectedItem.ToString(), cbxVehicleType.SelectedItem.ToString(), cbxTransactionType.SelectedItem.ToString()));

                            }
                            else
                            {
                                Common.MessageBoxError("No Records are Validated");
                            }
                        }
                        if (IsCheckedRecordsSelect == false)
                        {
                            Common.MessageBoxNone("Select Record(s) to Validate");
                        }
                        batchReload();
                    }
                    else
                    {
                        Common.MessageBoxNone("No Record(s) to Validate");
                    } 
                }
                else
                {
                    Common.MessageBoxError("Check the Server's Date.\nServer's Date is smaller than the Max Batch No Date");
                }
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message.ToString());
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (btnSelectAll.Text == "Select All")
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            //dataGridView1.Rows[i].Cells["checkbox"].Value = true;
                            dataGridView1.Rows[i].Cells[0].Value = true;
                        }
                        btnSelectAll.Text = "De Select All";
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            //dataGridView1.Rows[i].Cells["checkbox"].Value = false;
                            dataGridView1.Rows[i].Cells[0].Value = false;
                        }
                        btnSelectAll.Text = "Select All";
                    }

                }
                else
                    Common.MessageBoxError("No Records Found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validation_Load(object sender, EventArgs e)
        {
            //batchReload();
            try
            {
                txtDate.Text = DateTime.Now.ToShortDateString();
                txtTime.Text = DateTime.Now.ToShortTimeString();
                
                cbxDatewise.SelectedIndex = 0;
                cbxVehicleClass.SelectedIndex = 0;
                cbxVehicleType.SelectedIndex = 0;
                cbxTransactionType.SelectedIndex = 0;
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

        public void loadValidationData(DataTable dataTable)
        {
            try
            {
                dataGridView1.Refresh();
                DataTable dtLoad = new DataTable();
                dtLoad = dataTable;

                if (dtLoad.Rows.Count > 0)
                    txtRecords.Text = dtLoad.Rows.Count.ToString();
                else
                    txtRecords.Text = "0";

                dataGridView1.DataSource = dtLoad;
                dataGridView1.Columns[1].HeaderText = "REG NO";
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "REG DATE";
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "IMPORT DATE";
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "OWNER NAME";
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].HeaderText = "FNAME";
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].HeaderText = "VEH CLASS";
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].HeaderText = "OWNER SERIAL";
                dataGridView1.Columns[7].ReadOnly = true;
                dataGridView1.Columns[8].HeaderText = "TRANS TYPE";
                dataGridView1.Columns[8].ReadOnly = true;
                dataGridView1.Columns[9].HeaderText = "VEH TYPE";
                dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.Columns[10].HeaderText = "AUTOID";
                dataGridView1.Columns[10].ReadOnly = true;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].HeaderText = "STATUS";
                dataGridView1.Columns[11].ReadOnly = true;
                dataGridView1.Columns[12].HeaderText = "FUEL";
                dataGridView1.Columns[12].ReadOnly = true;
                dataGridView1.Columns[13].HeaderText = "BODYTYPE";
                dataGridView1.Columns[13].ReadOnly = true;
                dataGridView1.Columns[14].HeaderText = "MANUFACTURER";
                dataGridView1.Columns[14].ReadOnly = true;
                colorGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void batchReload()
        {
            try
            {
                string makeBatchNo;
                //get The RtoCode
                string RTOCODE = LoggedInUser.rtoCode;
                //Get Batch No
                string strBatchNo = validate.GetBatchNo();
                txtDate.Text = DateTime.Now.ToShortDateString();
                txtTime.Text = DateTime.Now.ToShortTimeString();
                makeBatchNo = MakeBatchNo(strBatchNo);
                if(makeBatchNo != "Wrong Batch")
                {
                    txtBatchNo.Text = RTOCODE + "-" + DateTime.Now.Year + "" + Common.monthOrDayCheck(DateTime.Now.Month.ToString()) + "" + Common.monthOrDayCheck(DateTime.Now.Day.ToString()) + makeBatchNo;
                }
                else
                {
                    txtBatchNo.Text = makeBatchNo;
                }
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message.ToString());
            }
        }

        public string MakeBatchNo(string BatchNo)
        {
            try
            {
                int length = 0;
                int TempValue = 0;
                int date = 0;
                if (Common.ValidateStringValue(BatchNo))
                {
                    //Get batchNo 1 when no data Available in table like empty table
                    if (BatchNo == "1")
                    {
                        length = Convert.ToInt32(BatchNo.Length);
                    }
                    else
                    {
                        // get the date of ChallanNo.
                        date = Convert.ToInt32(BatchNo.Substring(3, 8));

                        //get today date/
                        int TempDate = Convert.ToInt32(DateTime.Now.Date.ToString("yyyyMMdd"));

                        if (date == TempDate)
                        {
                            //get the last four digits
                            BatchNo = BatchNo.Substring(BatchNo.Length - 4);
                            TempValue = Convert.ToInt32(BatchNo);
                            //increment by one in current value
                            TempValue += 1;
                            BatchNo = Convert.ToString(TempValue);
                        }
                        else if (date < TempDate)
                        {
                            BatchNo = "1";
                        }
                        else if (date > TempDate)
                        {
                            Common.MessageBoxError("Check the Server's Date.\nServer's Date is smaller than the Max Batch No Date");
                            skipBatch = true;
                        }
                        length = Convert.ToInt32(BatchNo.Length);
                    }

                    // Append the zero based on values
                    switch (length)
                    {
                        case 1:
                            BatchNo = "000" + BatchNo;
                            break;
                        case 2:
                            BatchNo = "00" + BatchNo;
                            break;
                        case 3:
                            BatchNo = "0" + BatchNo;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (!skipBatch)
                return BatchNo;
            else
                return  "Wrong Batch";
        }

        private void txtSByRCNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt = null;
                dt = validate.GetDataForValidationSearchingRCNumber(Common.ConvertToUpperCase(txtSByRCNo.Text.Trim()), cbxDatewise.SelectedItem.ToString(),
                cbxVehicleClass.SelectedItem.ToString(), cbxVehicleType.SelectedItem.ToString(), cbxTransactionType.SelectedItem.ToString());
                countNumber = dt.Rows.Count;
                loadValidationData(dt);
                txtRecords.Text = countNumber.ToString();
                batchReload();
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message.ToString());
            }
        }

        private void btnGetVehicleType_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (validate.InsertVehicleTypeInRCRecordsBeforeValidation())
                {
                    //batchReload();
                    Common.MessageBoxSuccess("Vehicle Type Updated");
                }
                else
                {
                    Common.MessageBoxNone("No Record(s) Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbxVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cbxVehicleType.SelectedIndex == 0)
            //    {
            //        batchReload();
            //    }
            //    if (cbxVehicleType.SelectedIndex == 1)
            //    {
            //        rcRecordsByVehicleType('T');
            //    }
            //    if (cbxVehicleType.SelectedIndex == 2)
            //    {
            //        rcRecordsByVehicleType('N');
            //    }
                
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        //public void rcRecordsByVehicleType(char vehicleType)
        //{
        //    try
        //    {
        //        dtRejectCard = null;
        //        dtRejectCard = validate.GetDataForValidationByVehicleType(vehicleType);
        //        countNumber = dtRejectCard.Rows.Count;
        //        loadValidationData(dtRejectCard);
        //        txtRecords.Text = countNumber.ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        private void btnSelectRecords_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Regex rgx = null;
                rgx = new Regex(@"^[0-9]{1,3}$");
                if (txtSelectTopRecords.Text.Trim().ToString() == "")
                {
                    Common.MessageBoxError("Enter Record Count to Select");
                    txtSelectTopRecords.Focus();
                    return;
                }
                else if (rgx.IsMatch(txtSelectTopRecords.Text.Trim().ToString()))
                {
                    int recordCount = Convert.ToInt32(txtSelectTopRecords.Text.Trim().ToString());
                    for (int i = 0; i < recordCount; i++)
                    {
                        //dataGridView1.Rows[i].Cells["checkbox"].Value = true;
                        dataGridView1.Rows[i].Cells[0].Value = true;
                    }
                    if(dataGridView1.Rows.Count == recordCount)
                    {
                        btnSelectAll.Text = "De Select All";
                    }
                    for (int i = recordCount; i < dataGridView1.Rows.Count; i++)
                    {
                        //dataGridView1.Rows[i].Cells["checkbox"].Value = false;
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
                            dataGridView1.Rows[i].Cells[0].Value = false;
                    }
                }
                else
                {
                    Common.MessageBoxError("Enter Record Count to Select");
                }
            }
            else
            {
                Common.MessageBoxError("Please Load Data First");
                return;
            }
        }

        public void colorGrid()
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        DataTable dtFuel = new DataTable();
            //        DataTable dtBodyType = new DataTable();
            //        DataTable dtMaker = new DataTable();
            //        DataTable dtChallanNo = new DataTable();

            //        dtFuel = mappingTables.GetRCFuelCodesAndDescriptionToBeAddedInMappingTable();
            //        dtBodyType = mappingTables.GetRCBodytypeCodesAndDescriptionToBeAddedInMappingTable();
            //        dtMaker = mappingTables.GetRCMakerCodesAndDescriptionToBeAddedInMappingTable();
            //        dtChallanNo = rCVehicle.GetRCVehicleCodesToBeAdded();

            //        if (dtFuel.Rows.Count > 0)
            //        {
            //            if (row.DefaultCellStyle.ForeColor != Color.Red)
            //            {
            //                foreach (DataRow row1 in dtFuel.Rows)
            //                {
            //                    if (row.Cells["FUEL"].Value.ToString().Equals(row1[0].ToString()))
            //                    {
            //                        row.DefaultCellStyle.ForeColor = Color.Red;
            //                        //row.Cells["FUEL"].Style.ForeColor = Color.Red;
            //                        //row.Cells["FUEL"].Style.BackColor = Color.LightGray;
            //                    }
            //                }
            //            }
            //        }

            //        if (dtBodyType.Rows.Count > 0)
            //        {
            //            if (row.DefaultCellStyle.ForeColor != Color.Red)
            //            {
            //                foreach (DataRow row2 in dtBodyType.Rows)
            //                {
            //                    if (row.Cells["BODYTYPE"].Value.ToString().Equals(row2[0].ToString()))
            //                    {
            //                        row.DefaultCellStyle.ForeColor = Color.Red;
            //                        //row.Cells["BODYTYPE"].Style.ForeColor = Color.Red;
            //                        //row.Cells["BODYTYPE"].Style.BackColor = Color.LightGray;
            //                    }
            //                }
            //            }
            //        }

            //        if (dtMaker.Rows.Count > 0)
            //        {
            //            if (row.DefaultCellStyle.ForeColor != Color.Red)
            //            {
            //                foreach (DataRow row3 in dtMaker.Rows)
            //                {
            //                    if (row.Cells["MANUFACTURER"].Value.ToString().Equals(row3[0].ToString()))
            //                    {
            //                        row.DefaultCellStyle.ForeColor = Color.Red;
            //                        //row.Cells["MANUFACTURER"].Style.ForeColor = Color.Red;
            //                        //row.Cells["MANUFACTURER"].Style.BackColor = Color.LightGray;
            //                    }
            //                }
            //            }
            //        }

            //        //foreach (DataRow row4 in dtChallanNo.Rows)
            //        //{
            //        //    if (row.Cells["VEH CLASS"].Value.ToString().Equals(row4[0].ToString()))
            //        //    {
            //        //        row.DefaultCellStyle.ForeColor = Color.Red;
            //        //        row.Cells["VEH CLASS"].Style.ForeColor = Color.DarkRed;
            //        //    }
            //        //}
            //    }
            //}
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colorGrid();
        }

        private void cbxVehicleClass_DropDown(object sender, EventArgs e)
        {
            try
            {

                DataTable dtVehicleClass = new DataTable();
                dtVehicleClass = validate.GetVehicleClassBeforeValidation();
                cbxVehicleClass.Items.Clear();
                cbxVehicleClass.Items.Insert(0, "ALL");
                cbxVehicleClass.SelectedIndex = 0;
                if (dtVehicleClass != null)
                {
                    if (dtVehicleClass.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtVehicleClass.Rows.Count; i++)
                        {
                            cbxVehicleClass.Items.Insert(i + 1, dtVehicleClass.Rows[i]["VEHCLASS"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void cbxTransactionType_DropDown(object sender, EventArgs e)
        {
            try
            {

                DataTable dtTransacType = new DataTable();
                dtTransacType = validate.GetTransactionTypeBeforeValidation();
                cbxTransactionType.Items.Clear();
                cbxTransactionType.Items.Insert(0, "ALL");
                cbxTransactionType.SelectedIndex = 0;
                if (dtTransacType != null)
                {
                    if (dtTransacType.Rows.Count > 0)
                    {

                        for (int i = 0; i < dtTransacType.Rows.Count; i++)
                        {
                            cbxTransactionType.Items.Insert(i + 1, dtTransacType.Rows[i]["TRN_TY"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

    }
}
