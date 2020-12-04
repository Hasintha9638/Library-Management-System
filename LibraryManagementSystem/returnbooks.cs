using LibraryManagementSystem.datagathering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class returnbooks : Form
    {
        sql cd = new sql();
        public returnbooks()
        {
            InitializeComponent();
        }
        public void visibl()
        {
            btnDelete.Visible = true;
        }

        private void returnbooks_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM returnbook";
            tableReturnBooks.DataSource = cd.select(sql);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM returnbook where acc_no LIKE '%" + txtSearch.Text + "%' OR book_name LIKE '%" + txtSearch.Text + "%' OR student_reg  LIKE '%" + txtSearch.Text + "%' ";
            tableReturnBooks.DataSource = cd.select(sql);
        }

        private void radioToday_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM issuebook where issue_date LIKE '%" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "%' ";
            tableReturnBooks.DataSource = cd.select(sql);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            radioToday.Checked = false;
            string sql = "SELECT * FROM returnbook where return_date LIKE '%" + dateTimePicker1.Value.Date.ToString("MM/dd/yyyy") + "%' ";
            tableReturnBooks.DataSource = cd.select(sql);
        }
        int row = -1;
        string deletekey = "";
        private void tableReturnBooks_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            deletekey = tableReturnBooks.Rows[row].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE  FROM returnbook where acc_no='" + deletekey + "' ";
                    cd.update(sql);
                    string sql2 = "SELECT * FROM returnbook";
                    tableReturnBooks.DataSource = cd.select(sql2);
                    row = -1;
                }
            }
        }
    }
}
