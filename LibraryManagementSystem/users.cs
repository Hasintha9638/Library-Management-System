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
    public partial class users : Form
    {
        sql cd = new sql();
        static string ky = "";
        public users()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            row = -1;
            btnDelete.Visible = true;
            button2.Visible = true;
            button5.Visible = true;
            string sql = "SELECT * FROM student";
            tableView.DataSource = cd.select(sql);
            lblView.Text = "Managing Student";

            ky = "student";
        }

        private void users_Load(object sender, EventArgs e)
        {
            
            string sql = "SELECT * FROM student";
            tableView.DataSource = cd.select(sql);
            lblView.Text = "Managing Student";
            ky = "student";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (ky == "student")
            {
                string sql = "SELECT * FROM student where registration_no LIKE '%" + txtSearch.Text + "%' OR name LIKE '%" + txtSearch.Text + "%' OR department LIKE '%" + txtSearch.Text + "%' ";
                tableView.DataSource = cd.select(sql);
            }
            if (ky=="book")
            {
                string sql = "SELECT * FROM book where acc_no LIKE '%" + txtSearch.Text + "%' OR book_name LIKE '%" + txtSearch.Text + "%' OR type LIKE '%" + txtSearch.Text + "%' ";
                tableView.DataSource = cd.select(sql);
            }
            if (ky == "librarian")
            {
                string sql = "SELECT * FROM librarian where librarian_id LIKE '%" + txtSearch.Text + "%' OR full_name LIKE '%" + txtSearch.Text + "%' ";
                tableView.DataSource = cd.select(sql);
            }
            if (ky == "admin")
            {
                string sql = "SELECT * FROM admin where username LIKE '%" + txtSearch.Text + "%' ";
                tableView.DataSource = cd.select(sql);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            row = -1;
            btnDelete.Visible = true;
            button2.Visible = true;
            button5.Visible = true;
            string sql = "SELECT * FROM book";
            tableView.DataSource = cd.select(sql);
            lblView.Text = "Managing Books";

            ky = "book";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            row = -1;
            btnDelete.Visible = true;
            button2.Visible = true;
            button5.Visible = true;
            string sql = "SELECT * FROM librarian";
            tableView.DataSource = cd.select(sql);
            lblView.Text = "Managing librarian";
            ky = "librarian";
        }
        int row = -1;
        string deletekey = "";
        private void tableView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            deletekey = tableView.Rows[row].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row>-1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result==DialogResult.Yes)
                {
                    if (ky == "student")
                    {
                        string sql = "DELETE  FROM student where registration_no='"+deletekey+"' ";
                         cd.update(sql);
                        string sql2 = "SELECT * FROM student";
                        tableView.DataSource = cd.select(sql2);
                        lblView.Text = "Managing Student";
                        ky = "student";
                    }
                    if (ky == "book")
                    {
                        string sql = "DELETE FROM book where acc_no ='" + deletekey + "'";
                         cd.update(sql);

                        string sq2l = "SELECT * FROM book";
                        tableView.DataSource = cd.select(sq2l);
                        lblView.Text = "Managing Books";
                        ky = "book";
                    }
                    if (ky == "librarian")
                    {
                        string sql = "DELETE FROM librarian where librarian_id='" + deletekey + "' ";
                        cd.update(sql);
                        string sql2 = "SELECT * FROM librarian";
                        tableView.DataSource = cd.select(sql2);
                        lblView.Text = "Managing librarian";
                        ky = "librarian";
                    }
                   
                    row = -1;
                }
             
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (row>-1)
            {
                if (ky == "student")
                {
                    studentReg x = new studentReg();
                    x.Show();
                    x.dataparse(deletekey);
                    string sql2 = "SELECT * FROM student";
                    tableView.DataSource = cd.select(sql2);
                    lblView.Text = "Managing Student";
                    ky = "student";
                }
                if (ky == "book")
                {
                    bookReg x = new bookReg();
                    x.Show();
                    x.dataparse(deletekey);

                    string sq2l = "SELECT * FROM book";
                    tableView.DataSource = cd.select(sq2l);
                    lblView.Text = "Managing Books";
                    ky = "book";
                }
                if (ky == "librarian")
                {
                    librarianReg x = new librarianReg();
                    x.Show();
                    x.dataparse(deletekey);
                    string sql2 = "SELECT * FROM librarian";
                    tableView.DataSource = cd.select(sql2);
                    lblView.Text = "Managing librarian";
                    ky = "librarian";
                }
                if (ky == "admin")
                {
                    string sql = "SELECT * FROM admin where username='" + deletekey + "'";
                    cd.update(sql);
                }
                row = -1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            users obj = new users();
            this.Dispose();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblView.Text = "Managing Admin";
            btnDelete.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            string sql = "SELECT * FROM admin";
            tableView.DataSource = cd.select(sql);
            ky = "admin";

        }
    }
}
