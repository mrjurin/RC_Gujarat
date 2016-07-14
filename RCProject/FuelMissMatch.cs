using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCProject
{
    public partial class FuelMissMatch : Form
    {
        MappingTables mappingTables = new MappingTables();
        DataTable dt = null;
        public FuelMissMatch()
        {
            InitializeComponent();
        }

        private void btnGetFuelMiss_Click(object sender, EventArgs e)
        {
            try
            {
                refreshGrid(mappingTables.GetRCFuelCodesAndDescriptionToBeAddedInMappingTable());
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refreshGrid(DataTable dataTable)
        {
            try
            {
                dataGridView1.Refresh();
                dt = new DataTable();
                dt = dataTable;
                txtRecords.Text = dt.Rows.Count.ToString();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                Common.MessageBoxError(ex.Message.ToString());
            }
        }
    }
}
