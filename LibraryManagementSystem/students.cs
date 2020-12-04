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
    public partial class students : Form
    {
        sql cd = new sql();
        string gender = "";
        static string myconstring = ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.libraryMangementConnectionString"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(myconstring);
        public students()
        {
            InitializeComponent();
        }

        public void dataParse(string key)
        {
      

            string sql = "SELECT * FROM student  WHERE registration_no='" + key + "'";
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtRegNo.Text = reader["registration_no"].ToString();
                    txtName.Text = reader["name"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtContactNo.Text = reader["contact_no"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtPassword.Text = reader["password0"].ToString();
                    string dep = reader["department"].ToString();
                    if (dep == "Computer Science")
                    {
                        comboDepartment.SelectedIndex = 0;
                    }
                    if (dep == "Physical Science")
                    {
                        comboDepartment.SelectedIndex = 1;
                    }
                    if (dep == "Language Studies")
                    {
                        comboDepartment.SelectedIndex = 2;
                    }
                    if (dep == "Bussiness Studies")
                    {
                        comboDepartment.SelectedIndex = 3;
                    }
                    string gen = reader["gender"].ToString();
                    if (gen == "Male")
                    {
                        radioMale.Checked = true;
                    }
                    else
                    {
                        radioFemale.Checked = true;
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

        private void button7_Click(object sender, EventArgs e)
        {
            book x = new book();
            x.Show();
        }

        private void students_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE student SET name='" + txtName.Text + "',gender='" + gender + "',address='" + txtAddress.Text + "',email='" + txtEmail.Text + "',department='" + comboDepartment.Text + "',contact_no='" + txtContactNo.Text + "',password0='"+txtPassword.Text+"' WHERE registration_no='" + txtRegNo.Text + "'";
            bool isSuccess = cd.update(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Student details Updated is successfully!", "Student Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
        }


        private void button4_Click(object sender, EventArgs e) //sendfeedback
        {
            string details ="#"+txtMessage.Text;
            string sql = "INSERT INTO feedback (student_registration_no,student_name,send_date,message) VALUES('" + txtRegNo.Text
                + "','"+txtName.Text
                +"','"+DateTime.Now.Date
                +"','"+details+"')";
            bool isSuccess = cd.insert(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Feedback sending is successfully!", "Send Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMessage.Text = "";
            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
