using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BAL;

namespace RCProject
{
    public partial class BodytypeMissMatch : Form
    {
        MappingTables mappingTables = new MappingTables();
        DataTable dt = null;
        public BodytypeMissMatch()
        {
            InitializeComponent();
        }

        private void btnGetBodytypeMiss_Click(object sender, EventArgs e)
        {
            try
            {
                refreshGrid(mappingTables.GetRCBodytypeCodesAndDescriptionToBeAddedInMappingTable());
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
