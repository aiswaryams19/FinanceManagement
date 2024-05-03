using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace FinanceManagement
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        private void CloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aiswa\OneDrive\Documents\FinanceManagementDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(UserNameTB.Text) || string.IsNullOrEmpty(PhoneTB.Text) || string.IsNullOrEmpty(PasswordTB.Text) || string.IsNullOrEmpty(AddressTB.Text))
            {
                MessageBox.Show("Missing Informations");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("insert into UserTable(UserName, UserDOB, UserPhone, UserPassword, UserAddress) values (@UName, @UDOB, @UPh, @UPass, @UAdd)", conn);
                    command.Parameters.AddWithValue("@UName", UserNameTB.Text);
                    //command.Parameters.AddWithValue("@UDOB", "08-01-1998");
                    command.Parameters.AddWithValue("@UDOB", DOB.Text);
                    command.Parameters.AddWithValue("@UPh", PhoneTB.Text);
                    command.Parameters.AddWithValue("@UPass", PasswordTB.Text);
                    command.Parameters.AddWithValue("@UAdd", AddressTB.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("User Added !!!");
                    conn.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Clear()
        {
            UserNameTB.Text = string.Empty;
            PhoneTB.Text = string.Empty;
            PasswordTB.Text = string.Empty;
            AddressTB.Text = string.Empty;
            DOB.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void BackLabel_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
