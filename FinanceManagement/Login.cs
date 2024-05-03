using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void CloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aiswa\OneDrive\Documents\FinanceManagementDB.mdf;Integrated Security=True;Connect Timeout=30");
        public static string user;
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginUserNameTB.Text) || string.IsNullOrEmpty(LoginPasswordTB.Text))
            {
                MessageBox.Show("Enter both User Name and Password");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from UserTable where UserName = '" + LoginUserNameTB.Text + "' and UserPassword = '" + LoginPasswordTB.Text + "'", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        user = LoginUserNameTB.Text;
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserName or Password");
                        LoginUserNameTB.Text = string.Empty;
                        LoginPasswordTB.Text = string.Empty;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
