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
    
    public partial class adminprofile : Form
    {
        sql cd = new sql();
        static string myconstring = ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.libraryMangementConnectionString"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(myconstring);
        public adminprofile()
        {
            InitializeComponent();
        }

        public void dataparse(string key)
        {

            btnUpdate.Visible = true;
            btnCreate.Visible = false;
            string sql = "SELECT * FROM admin  WHERE username='" + key + "'";
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtUsername.Text = reader["username"].ToString();
                    txtPassword.Text = reader["password0"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                   

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = " INSERT INTO admin(username,email,password0) VALUES('" + txtUsername.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "')";
            bool isSuccess = cd.insert(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Admin Registration is successfully!", "Admin Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE admin SET username='" + txtUsername.Text + "',password0='" + txtPassword.Text + "',email='" + txtEmail.Text + "' WHERE username='" + txtUsername.Text + "'";
            bool isSuccess = cd.update(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Admin details Updated is successfully!", "Admin Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void adminprofile_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
        }
    }
}
