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
using System.Globalization;

namespace RCProject
{
    public partial class CardPersonalization : Form
    {
        DataTable dt = new DataTable();
        DataSinglePrint dataSinglePrint = new DataSinglePrint();
        int countNumber = 0; 

        public CardPersonalization()
        {
            InitializeComponent();
        }
        
        private void btnSendForPrinting_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRowCollection Rows = dataGridView1.Rows;
                DataGridViewRow row = null;

                for (int i = 0; i < Rows.Count; i++)
                {
                    if (Convert.ToBoolean(Rows[i].Cells[0].Value) == true)
                    {
                        row = new DataGridViewRow();
                        row = Rows[i];
                        break;
                    }
                }
                if (row != null)
                {
                    SingleCardPrinting scp = new SingleCardPrinting(row.Cells["VEHREGNO"].Value.ToString(), row.Cells["AUTOID"].Value.ToString());
                    scp.Show();
                    this.Close();
                }
                else
                {
                    Common.MessageBoxWarning("No Record Selected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void refresh(DataTable dataTable)
        {
            try
            {
                dataGridView1.Refresh();
                dt = dataTable;

                if (dt.Rows.Count > 0)
                    txtRecords.Text = dt.Rows.Count.ToString();
                else
                    txtRecords.Text = "0";

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].HeaderText = "AUTOID";
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "VEH REG NO";
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "REG DATE";
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "OWNER NAME";
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].HeaderText = "FNAME";
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].HeaderText = "OWNERSERIAL";
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].HeaderText = "TRANSAC TYPE";
                dataGridView1.Columns[7].ReadOnly = true;
                dataGridView1.Columns[8].HeaderText = "VEH TYPE";
                dataGridView1.Columns[8].ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CardPersonalization_Load(object sender, EventArgs e)
        {
            try
            {
                refresh(dataSinglePrint.GetDataForPersonalization());
                txtDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                txtTime.Text = DateTime.Now.TimeOfDay.ToString();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh(dataSinglePrint.GetDataForPersonalization());
        }

        private void txtSByRCNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt = null;
                dt = dataSinglePrint.GetDataForPersonalizationSearchingRCNumber(Common.ConvertToUpperCase(txtSByRCNo.Text));
                countNumber = dt.Rows.Count;
                refresh(dt);
                txtRecords.Text = countNumber.ToString();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    dr.Cells[0].Value = false;
                }
                dataGridView1.CurrentRow.Cells[0].Value = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    dr.Cells[0].Value = false;
                }
                dataGridView1.CurrentRow.Cells[0].Value = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSByRCNo.Clear();
            refresh(dataSinglePrint.GetDataForPersonalization());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
