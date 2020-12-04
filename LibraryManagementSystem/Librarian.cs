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
    public partial class Librarian : Form
    {
        static string myconstring = ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.libraryMangementConnectionString"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(myconstring);
        sql cd = new sql();
        string email = "";
        public Librarian()
        {
            InitializeComponent();
        }
        string key = "";
        public void dataParse(string key)//data parsing who is loging
        {
            this.key = key;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            book x = new book();
            x.Show();
        }

        private void button1_Click(object sender, EventArgs e)//clear data
        {
            comboAccNo.Text = "";
            comboRegistrationNo.Text = "";
            txtBookName.Text = "";
            txtStudentName.Text = "";
            dateTimePicker1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)//inset isseu book data
        {
            string sql = "INSERT INTO issuebook(acc_no,book_name,student_reg,student_name,issue_date,closing_date,email) VALUES('" + comboAccNo.Text
                + "','" + txtBookName.Text
                + "','" + comboRegistrationNo.Text
                + "','" + txtStudentName.Text
                + "','" + DateTime.Now.Date.ToString("MM/dd/yyyy")
                + "','" + dateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
                + "','" + email+"')";
            bool isSuccess = cd.insert(sql);
            if (isSuccess == true)
            {
                //update availability
                string sql2 = "UPDATE book SET availability='issue' WHERE acc_no='"+comboAccNo.Text+"' ";
                bool iss = cd.update(sql2);
                MessageBox.Show("Book Issue is successfully!", "Book Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboAccNo.Text = "";
                comboRegistrationNo.Text = "";
                txtBookName.Text = "";
                txtStudentName.Text = "";
            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadCombo();
            loadCombo2();
            loadCombo3();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Librarian_Load(object sender, EventArgs e)//load combo and warnings color
        {
            loadCombo();
            loadCombo2();
            loadCombo3();
            if (cd.lableColor())
            {
                btnWarnings.BackColor = Color.Crimson;
            }
        }
        public void loadCombo()//acc no load for issue book
        {
            comboAccNo.Items.Clear();
            string sql = "SELECT * FROM book WHERE availability='yes' ";

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string acc = reader["acc_no"].ToString();
                    comboAccNo.Items.Add(acc);
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


        public void loadCombo2()//load student registration number
        {
            comboRegistrationNo.Items.Clear();
            string sql = "SELECT * FROM student";

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string ac = reader["registration_no"].ToString();
                    comboRegistrationNo.Items.Add(ac);
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

        public void loadCombo3()//for return book get issue book acc no
        {
            comboAccNoReturn.Items.Clear();
            string sql = "SELECT * FROM issuebook";

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string acc = reader["acc_no"].ToString();
                    comboAccNoReturn.Items.Add(acc);
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
        private void comboAccNo_SelectedIndexChanged(object sender, EventArgs e)//sugested
        {
            string sql = "SELECT * from book where acc_no='" + comboAccNo.Text + "'"; 

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtBookName.Text = reader["book_name"].ToString();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboRegistrationNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * from student where registration_no='" + comboRegistrationNo.Text + "'";

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtStudentName.Text = reader["name"].ToString();
                    email = reader["email"].ToString();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboAccNoReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * from issuebook where acc_no='" + comboAccNoReturn.Text + "'";

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtbName.Text = reader["book_name"].ToString();
                    txtSregNo.Text = reader["student_reg"].ToString();
                    txtSName.Text = reader["student_name"].ToString();
                    txtIssueDate.Text = reader["issue_date"].ToString();
                    txtEndDay.Text = reader["closing_date"].ToString();
                    orijinalDate.Text = DateTime.Now.Date.ToString("MM/dd/yyyy");
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtbName.Text = "";
            txtSregNo.Text = "";
            txtSName.Text = "";
            txtEndDay.Text = "";
            orijinalDate.ResetText();
            txtFinesAmount.Text = "";
            txtIssueDate.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO returnbook(acc_no,book_name,student_reg,student_name,return_date,closing_date,fines_amount) VALUES('" + comboAccNoReturn.Text
               + "','" + txtbName.Text
               + "','" + txtSregNo.Text
               + "','" + txtSName.Text
               + "','" + orijinalDate.Value.Date.ToString("MM/dd/yyyy")
               + "','" + txtEndDay.Text
               + "','" + txtFinesAmount.Text
               + "')";
            bool isSuccess = cd.insert(sql);
            if (isSuccess == true)
            {
                string sql2 = "UPDATE book SET availability='yes' WHERE acc_no='" + comboAccNoReturn.Text + "' ";
                cd.update(sql2);
                string sql3 = "DELETE FROM issuebook  WHERE acc_no='" + comboAccNoReturn.Text + "' ";
                cd.update(sql3);
                MessageBox.Show("Book return is successfully!", "Book Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbName.Text = "";
                txtSregNo.Text = "";
                txtSName.Text = "";
                txtEndDay.Text = "";
                txtIssueDate.Text = "";
                txtFinesAmount.Text = "";
                comboAccNoReturn.Text = "";
            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadCombo();
            loadCombo2();
            loadCombo3();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viewstudents x = new viewstudents();
            x.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewissuebook x = new viewissuebook();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            returnbooks x = new returnbooks();
            x.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            feedback x = new feedback();
            x.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            warnnings x = new warnnings();
            x.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            librianprofile x = new librianprofile();
            x.Show();
            x.dataparse(key);

        }
    }
}
