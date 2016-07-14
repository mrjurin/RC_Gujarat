using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCProject
{
    public partial class ManageRCVehicle : Form
    {
        DataTable dt = new DataTable();
        RCVehicle rCVehicle = new RCVehicle();

        public ManageRCVehicle()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddCode.Text == "Add Code")
                {
                    btnAddCode.Text = "Exit Code";
                    btnAddCode.BackColor = Color.Tomato;
                    cbxRCVehicleCode.Visible = false;
                    txtAddRCVehicleCode.Visible = true;
                    txtAddRCVehicleCode.Focus();
                }
                else
                {
                    btnAddCode.Text = "Add Code";
                    btnAddCode.BackColor = Color.LightSlateGray;
                    cbxRCVehicleCode.Visible = true;
                    txtAddRCVehicleCode.Visible = false;
                    cbxRCVehicleCode.Focus();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }

        private void ManageRCVehicle_Load(object sender, EventArgs e)
        {
            try
            {
                refreshGrid();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                dt = rCVehicle.GetRCVehicleCodesToBeAdded();
                if (dt.Rows.Count == 0)
                {
                    btnAddImage.Visible = false;
                    btnSelectImage.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    btnSave.Visible = true;
                    cbxRCVehicleCode.Visible = true;
                    pbxRCVehicleImage.Visible = true;

                    refreshVehicleCodes();
                }
                else
                {
                    string vehicleCodes = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vehicleCodes += "\"" + dt.Rows[i]["VEHCLASS"].ToString().Trim() + "\"\n";
                    }
                    Common.MessageBoxError("Following RC Vehicle Codes required to be added:\n"+vehicleCodes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void refreshGrid()
        {
            try
            {
                dataGridView1.Refresh();
                dataGridView1.DataSource = rCVehicle.GetImageAddedRCVehicleCodes();
                dataGridView1.Columns[1].HeaderText = "VEHICLE CODE";
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "VEHICLE TYPE";
                dataGridView1.Columns[2].ReadOnly = true;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        private void refreshVehicleCodes()
        {
            try
            {
                cbxRCVehicleCode.Items.Clear();
                dt = rCVehicle.GetRCVehicleCodesForAddingImage();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxRCVehicleCode.Items.Insert(i, dt.Rows[i]["VEH_CLASS_CD"].ToString());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfileDialog = new OpenFileDialog();

                openfileDialog.InitialDirectory =Environment.CurrentDirectory+ @"\RC Required\RC VEHICLE IMAGES";
                openfileDialog.Filter = "bmp files (*.bmp)|*.bmp";
                openfileDialog.Title = "Please select a vehicle image.";


                DialogResult result = openfileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filename = openfileDialog.FileName;
                    pbxRCVehicleImage.SizeMode = PictureBoxSizeMode.AutoSize;
                    pbxRCVehicleImage.Image = Image.FromFile(filename);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int i = cbxRCVehicleCode.SelectedIndex;
                if (cbxRCVehicleCode.SelectedItem != null)
                {
                    if (pbxRCVehicleImage.Image != null)
                    {
                        if (rCVehicle.InsertRCVehicleImageWithCode(cbxRCVehicleCode.SelectedItem.ToString(), Common.ConvertBMPImageToByteArray(pbxRCVehicleImage.Image)))
                        {
                            refreshGrid();
                            refreshVehicleCodes();
                            pbxRCVehicleImage.Image = null;
                            Common.MessageBoxSuccess("Vehicle Image Added Successfully");
                        }
                        else
                        {
                            Common.MessageBoxError("Something Wrong");
                        }
                    }
                    else
                    {
                        Common.MessageBoxNone("Select A Vehicle Image");
                    }
                }
                else
                {
                    Common.MessageBoxNone("Select A Vehicle Code");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRowCollection Rows = dataGridView1.Rows;

                if (Rows.Count > 0)
                {
                    bool IsCheckedRecordsSelect = false;
                    string vehicleCode;
                    int recordsDeleted = 0;

                    for (int i = 0; i < Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(Rows[i].Cells[0].Value) == true)
                        {
                            vehicleCode = Rows[i].Cells[1].Value.ToString();

                            IsCheckedRecordsSelect = true;
                            int TempRecords = 0;
                            TempRecords = rCVehicle.DeleteRCVehicleImage(vehicleCode);
                            if (TempRecords > 0)
                            {
                                recordsDeleted += TempRecords;
                            }
                        }
                    }

                    // Check whether any rows are selected or not..
                    if (IsCheckedRecordsSelect)
                    {
                        if (recordsDeleted > 0)
                        {
                            Common.MessageBoxSuccess("Deleted " + recordsDeleted + " record(s) successfully");
                        }
                        else
                        {
                            Common.MessageBoxError("No Record(s) are Deleted");
                        }

                        refreshGrid();
                        refreshVehicleCodes();
                    }
                    else
                    {
                        Common.MessageBoxNone("Select Record(s) to delete");
                    }
                }
                else
                {
                    Common.MessageBoxNone("No Record(s) to delete");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
