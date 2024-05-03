using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement
{
    public partial class Incomes : Form
    {
        public Incomes()
        {
            InitializeComponent();
            GetTotalIncomes();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aiswa\OneDrive\Documents\FinanceManagementDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void DashboardLabel_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void ExpenseLabel_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void ViewIncomeLabel_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void ViewExpenseLabel_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        private void IncomeNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IncomeAmountTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void IncomeDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void IncomeDescriptionTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void IncomeSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IncomeNameTB.Text) || string.IsNullOrEmpty(IncomeAmountTB.Text) || string.IsNullOrEmpty(IncomeDescriptionTB.Text) || string.IsNullOrEmpty(Category.Text))
            {
                MessageBox.Show("Missing Informations");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("insert into IncomeTable(IncName, IncAmount, IncDescription, IncCategory, IncDate, IncUser) values (@IName, @IAmt, @IDesc, @ICat, @IDate, @IUser)", conn);
                    command.Parameters.AddWithValue("@IName", IncomeNameTB.Text);
                    command.Parameters.AddWithValue("@IAmt", IncomeAmountTB.Text);
                    command.Parameters.AddWithValue("@IDesc", IncomeDescriptionTB.Text);
                    command.Parameters.AddWithValue("@ICat", Category.SelectedItem.ToString());
                    //command.Parameters.AddWithValue("@UDOB", DOB.Text);
                    // Assuming IncomeDate.Text contains a date string in "MM/dd/yyyy" format
                    DateTime incomeDate;
                    if (DateTime.TryParseExact(IncomeDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incomeDate))
                    {
                        if (incomeDate >= SqlDateTime.MinValue.Value && incomeDate <= SqlDateTime.MaxValue.Value)
                        {
                            // Date is within the valid range, add it as a parameter
                            command.Parameters.AddWithValue("@IDate", SqlDbType.DateTime2).Value = incomeDate;
                        }
                    }
                    else
                    {
                        // Date string couldn't be parsed, handle error or display message to the user
                        MessageBox.Show("Invalid date format");
                        Clear();
                    }

                    //command.Parameters.AddWithValue("@IDate", incomeDate);
                    command.Parameters.AddWithValue("@IUser", Login.user);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Income Added !!!");
                    conn.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                    Clear();
                }
            }
        }
        private void GetTotalIncomes()
        {
            try
            {
                conn.Open();
                string query = $"select Sum(IncAmount) from IncomeTable where IncUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                TotalIncome.Text = "Rs " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void CloseIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Clear()
        {
            IncomeNameTB.Text = string.Empty;
            IncomeDescriptionTB.Text = string.Empty;
            Category.SelectedIndex = 0;
            IncomeAmountTB.Text = string.Empty;
            IncomeDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void LogoutIcon_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void LogoutLabel_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
