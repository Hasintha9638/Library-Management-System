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
    public partial class studentReg : Form
    {   sql cd = new sql();
        string gender = "";
        static string myconstring = ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.libraryMangementConnectionString"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(myconstring);
        public studentReg()
        {
            InitializeComponent();
        }
        public void dataparse(string key)
        {
            btncreate.Visible = false;
            btnUpdate.Visible = true;
            txtRegNo.Enabled = false;
            lblView.Text = "Student's details update";

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
                    if (dep== "Computer Science")
                    {
                        comboDepartment.SelectedIndex = 0;
                    }
                    if (dep== "Physical Science")
                    {
                        comboDepartment.SelectedIndex = 1;
                    }
                    if (dep== "Language Studies")
                    {
                        comboDepartment.SelectedIndex = 2;
                    }
                    if (dep== "Bussiness Studies")
                    {
                        comboDepartment.SelectedIndex = 3;
                    }
                    string gen = reader["gender"].ToString();
                    if (gen == "Male")
                    {
                        radioMale.Checked = true;
                    }else
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
        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtRegNo.Text="";
            radioFemale.Checked = false;
            radioMale.Checked = false;
            comboDepartment.Text = "";
            txtEmail.Text = "";
        }

        private void studentReg_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {   
            string sql = "INSERT INTO student(registration_no,name,gender,address,email,department,contact_no,password0) VALUES('"+txtRegNo.Text+"','"+txtName.Text+"','"+gender+"','"+txtAddress.Text+"','"+txtEmail.Text+"','"+comboDepartment.Text+"','"+txtContactNo.Text+"','"+txtPassword.Text+"')";
            bool isSuccess = cd.insert(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Student Registration is successfully!", "Student Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE student SET name='"+txtName.Text+"',gender='"+gender+"',address='"+txtAddress.Text+"',email='"+txtEmail.Text+"',department='"+comboDepartment.Text+"',contact_no='"+txtContactNo.Text+"',password0='"+txtPassword.Text+"' WHERE registration_no='"+txtRegNo.Text+"'";
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
    }
}
