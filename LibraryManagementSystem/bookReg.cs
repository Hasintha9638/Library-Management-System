using LibraryManagementSystem.datagathering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class bookReg : Form
    {
        static string myconstring = ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.libraryMangementConnectionString"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(myconstring);
        sql cd = new sql();
        public bookReg()
        {
            InitializeComponent();
        }

        public void dataparse(string key)
        {
            btncreate.Visible = false;
            btnUpdate.Visible = true;
            txtAccNo.Enabled = false;
            lblView.Text = "Book's details update";

            string sql = "SELECT * FROM book  WHERE acc_no='" + key + "'";
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtAccNo.Text = reader["acc_no"].ToString();
                    txtName.Text = reader["book_name"].ToString();
                    txtAuthor.Text = reader["author"].ToString();
                    txtDetails.Text = reader["details"].ToString();
                    comboEdition.Text = reader["edition"].ToString();
                    string dep = reader["type"].ToString();
                    if (dep == "Science")
                    {
                        comboType.SelectedIndex = 0;
                    }
                    if (dep == "History")
                    {
                        comboType.SelectedIndex = 1;
                    }
                    if (dep == "Cs")
                    {
                        comboType.SelectedIndex = 2;
                    }
                    if (dep == "English")
                    {
                        comboType.SelectedIndex = 3;
                    }
                    if (dep == "Art")
                    {
                        comboType.SelectedIndex = 4;
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void bookReg_Load(object sender, EventArgs e)
        {
            comboEdition.SelectedIndex = 0;
            btnUpdate.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            txtAccNo.Text = "";
            txtAuthor.Text = "";
            txtName.Text = "";
            txtDetails.Text = "";
            comboType.Text = "";
            comboEdition.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO book (acc_no,book_name,author,availability,edition,type,details)VALUES ('"+txtAccNo.Text+"','"+txtName.Text+"','"+txtAuthor.Text+"','yes','"+comboEdition.Text+"','"+comboType.Text+"','"+txtDetails.Text+"')";
            bool isSuccess = cd.insert(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Book Registration is successfully!", "Book Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
                string sql = "UPDATE book SET book_name='" + txtName.Text + "',author='" + txtAuthor.Text + "',edition='" + comboEdition.Text + "',type='" + comboType.Text + "',details='" + txtDetails.Text + "' WHERE acc_no='" + txtAccNo.Text + "'";
                bool isSuccess = cd.update(sql);
                if (isSuccess == true)
                {
                    MessageBox.Show("Book details Updated is successfully!", "Book Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            
        }
    }
}
